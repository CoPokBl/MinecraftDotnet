using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using Minecraft.Schemas.DataStructs;

namespace Minecraft.Implementations.Events;

public class EventNode<T> {
    public event Action<T>? HandleCallback;  // immutable
    public event Action<T>? MutableCallback;
    public event Action<Type>? OnListenerAdded;

    public EventNode<T>? Parent;

    public volatile CopyOnWriteList<(EventNode<T>, Func<T, bool>)> Children = [];

    // Maps each registered wrapper delegate → human-readable description captured at registration.
    private readonly ConcurrentDictionary<Action<T>, string> _descriptions = new();

    public EventNode<T> CreateChild<TS>(Func<TS, bool> condition) where TS : T {
        return CreateChild(e => e is not TS ts || condition(ts));
    }

    public EventNode<T> CreateChild(Func<T, bool>? condition = null) {
        EventNode<T> child = new();
        AddChild(child, condition);
        return child;
    }

    public void AddChild(EventNode<T> child, Func<T, bool>? condition = null) {
        condition ??= _ => true;
        child.Parent = this;
        Children.Add((child, condition));
    }

    public void AddChild<TS>(EventNode<T> child, Func<TS, bool> condition) where TS : T {
        AddChild(child, e => e is not TS ts || condition(ts));
    }

    public void RemoveChild(EventNode<T> child) {
        child.Parent = null;
        Children.RemoveAll(c => c.Item1 == child);
    }

    /// <summary>
    /// Registers a listener. The original <paramref name="callback"/> delegate is inspected
    /// at registration time to produce a human-readable name used by the profiler.
    /// </summary>
    public Action AddListener<TL>(Action<TL> callback, bool mutable = false) where TL : T {
        string desc = DescribeDelegate(callback, typeof(TL));
        return AddListenerCore(typeof(TL), v => callback((TL)v!), mutable, desc);
    }

    public Action AddListener(Type type, Action<T> callback, bool mutable = false) {
        string desc = DescribeDelegate(callback, type);
        return AddListenerCore(type, callback, mutable, desc);
    }

    private Action AddListenerCore(Type eventType, Action<T> innerCall, bool mutable, string description) {
        OnListenerAdded?.Invoke(eventType);

        // Wrap with the type-gate so the multicast stays type-safe.
        Action<T> wrapper = obj => {
            if (obj!.GetType().IsAssignableTo(eventType)) innerCall(obj);
        };

        _descriptions[wrapper] = description;

        if (mutable) MutableCallback += wrapper;
        else HandleCallback += wrapper;

        return () => {
            _descriptions.TryRemove(wrapper, out _);
            if (mutable) MutableCallback -= wrapper;
            else HandleCallback -= wrapper;
        };
    }

    private static string DescribeDelegate(Delegate d, Type eventType) {
        string? owner = d.Target?.GetType().FullName ?? d.Method.DeclaringType?.FullName;
        return $"{owner ?? "?"}.{d.Method.Name} [{eventType.Name}]";
    }

    public void OnFirst<TL>(Action<TL> callback, bool mutable = false) where TL : T {
        OnListenerAdded?.Invoke(typeof(TL));

        Action<T> actualListener = null!;
        actualListener = obj => {
            if (obj is not TL tl) return;
            callback(tl);
            if (mutable) MutableCallback -= actualListener;
            else HandleCallback -= actualListener;
        };

        if (mutable) MutableCallback += actualListener;
        else HandleCallback += actualListener;
    }

    public void OnFirstWhere<TL>(Func<TL, bool> condition, Action<TL> callback, bool mutable = false) where TL : T {
        OnListenerAdded?.Invoke(typeof(TL));

        Action<T> actualListener = null!;
        actualListener = obj => {
            if (obj is not TL tl || !condition(tl)) return;
            callback(tl);
            if (mutable) MutableCallback -= actualListener;
            else HandleCallback -= actualListener;
        };

        if (mutable) MutableCallback += actualListener;
        else HandleCallback += actualListener;
    }

    public void CallEvent(T e) {
        if (Parent != null) {
            Parent.CallEvent(e);
            return;
        }
        ExecuteEventCallbacks(e, true);
        ExecuteEventCallbacks(e, false);
    }

    private void ExecuteEventCallbacks(T e, bool mutable) {
        Action<T>? callbacks = mutable ? MutableCallback : HandleCallback;
        if (callbacks != null) {
            Action<string>? logger = EventProfiler.Logger;
            if (logger != null) {
                int threshold = EventProfiler.ThresholdMs;
                // Time each listener individually so slow ones are named in the log.
                foreach (Delegate d in callbacks.GetInvocationList()) {
                    long start = Stopwatch.GetTimestamp();
                    ((Action<T>)d)(e);
                    TimeSpan elapsed = Stopwatch.GetElapsedTime(start);
                    if (elapsed.TotalMilliseconds >= threshold) {
                        _descriptions.TryGetValue((Action<T>)d, out string? name);
                        name ??= DescribeDelegate(d, e!.GetType());
                        logger($"[SLOW LISTENER +{elapsed.TotalMilliseconds:F1}ms] {name}");
                    }
                }
            } else {
                callbacks(e);
            }
        }

        foreach ((EventNode<T> child, Func<T, bool> condition) in Children) {
            if (condition == null!) {
                Console.WriteLine("WARNING: EventNode<T> has a null condition, this is probably a bug in the code.");
                continue;
            }
            if (condition(e)) child.ExecuteEventCallbacks(e, mutable);
        }
    }

    public Exception? CallEventCatchErrors(T e) {
        try {
            CallEvent(e);
            return null;
        }
        catch (Exception ex) {
            return ex;
        }
    }

    public Exception? CallEventPrintErrors(T e) {
        Exception? ex = CallEventCatchErrors(e);
        if (ex != null) {
            Console.WriteLine($"Error while calling event {typeof(T).FullName}: {ex}");
        }
        return ex;
    }

    public void WaitFor<TE>(CancellationToken cancellationToken = default) where TE : T {
        WaitFor<TE>(_ => true, cancellationToken);
    }

    public void WaitFor<TE>(Func<TE, bool> condition, CancellationToken cancellationToken = default) where TE : T {
        GetWaiterFor(condition).Wait(cancellationToken);
    }

    public Task<TE> GetWaiterFor<TE>(Func<TE, bool>? condition = null) where TE : T {
        TaskCompletionSource<TE> tcs = new();
        OnFirst<TE>(v => {
            if (condition == null || condition(v)) tcs.SetResult(v);
        });
        return tcs.Task;
    }

    /// <summary>
    /// Registers this event node as the handler for all attribute-based event handlers.
    /// </summary>
    public void RegisterStaticListeners() {
        try {
            IEnumerable<MethodInfo> methods = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass)
                .SelectMany(x => x.GetMethods())
                .Where(x => x.GetCustomAttributes(typeof(EventListener<>), false).FirstOrDefault() != null);

            IEnumerable<MethodInfo> eventListenerMethods = methods.Where(m =>
                m.ReturnType == typeof(void)
                && m.GetParameters().Length == 1
                && m.GetParameters()[0].ParameterType.IsAssignableTo(typeof(T)));

            foreach (MethodInfo method in eventListenerMethods) {
                AddListener(method.GetParameters()[0].ParameterType, obj => method.Invoke(null, [obj]));
            }
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }
}

using System.Reflection;
using Minecraft.Schemas.DataStructs;

namespace Minecraft.Implementations.Events;

public class EventNode<T> {
    public event Action<T>? HandleCallback;  // immutable
    public event Action<T>? MutableCallback; 
    public event Action<Type>? OnListenerAdded;  // Ran before adding a listener, useful for debugging or validation

    public EventNode<T>? Parent;

    public volatile CopyOnWriteList<(EventNode<T>, Func<T, bool>)> Children = [];

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
    
    public Action AddListener<TL>(Action<TL> callback, bool mutable = false) where TL : T {
        OnListenerAdded?.Invoke(typeof(TL));
        
        Action<T> call = obj => {
            if (obj is not TL tl) {
                return;
            }

            callback(tl);
        };

        if (mutable) {
            MutableCallback += call;
        }
        else {
            HandleCallback += call;
        }

        return () => {
            if (mutable) {
                MutableCallback -= call;
            }
            else {
                HandleCallback -= call;
            }
        };
    }

    public Action AddListener(Type type, Action<T> callback, bool mutable = false) {
        OnListenerAdded?.Invoke(type);
        
        Action<T> call = obj => {
            if (obj!.GetType().IsAssignableTo(type)) {
                callback((T)obj);
            }
        };
        
        if (mutable) {
            MutableCallback += call;
        }
        else {
            HandleCallback += call;
        }

        return () => {
            if (mutable) {
                MutableCallback -= call;
            }
            else {
                HandleCallback -= call;
            }
        };
    }

    /// <summary>
    /// Listens for an event once and then never again.
    /// <p/>
    /// Disconnects the listener after getting triggered once.
    /// </summary>
    /// <param name="callback">The listener.</param>
    /// <param name="mutable"></param>
    /// <typeparam name="TL">The event type to listen for.</typeparam>
    public void OnFirst<TL>(Action<TL> callback, bool mutable = false) where TL : T {
        OnListenerAdded?.Invoke(typeof(TL));
        
        Action<T> actualListener = null!;
        actualListener = obj => {
            if (obj is not TL tl) {
                return;
            }

            callback(tl);
            if (mutable) {
                MutableCallback -= actualListener;
            }
            else {
                HandleCallback -= actualListener;
            }
        };
        
        if (mutable) {
            MutableCallback += actualListener;
        }
        else {
            HandleCallback += actualListener;
        }
    }
    
    public void OnFirstWhere<TL>(Func<TL, bool> condition, Action<TL> callback, bool mutable = false) where TL : T {
        OnListenerAdded?.Invoke(typeof(TL));
        
        Action<T> actualListener = null!;
        actualListener = obj => {
            if (obj is not TL tl || !condition(tl)) {
                return;
            }

            callback(tl);
            if (mutable) {
                MutableCallback -= actualListener;
            }
            else {
                HandleCallback -= actualListener;
            }
        };
        if (mutable) {
            MutableCallback += actualListener;
        }
        else {
            HandleCallback += actualListener;
        }
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
        (mutable ? MutableCallback : HandleCallback)?.Invoke(e);
        
        foreach ((EventNode<T> child, Func<T, bool> condition) in Children) {
            if (condition == null!) {
                Console.WriteLine("WARNING: EventNode<T> has a null condition, this is probably a bug in the code.");
                continue;
            }
            if (condition(e)) {
                child.ExecuteEventCallbacks(e, mutable);
            }
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

    public void WaitFor<TE>(CancellationToken cancellationToken = default) where TE : T {
        WaitFor<TE>(_ => true, cancellationToken);
    }
    
    public void WaitFor<TE>(Func<TE, bool> condition, CancellationToken cancellationToken = default) where TE : T {
        GetWaiterFor(condition).Wait(cancellationToken);
    }
    
    public Task<TE> GetWaiterFor<TE>(Func<TE, bool>? condition = null) where TE : T {
        TaskCompletionSource<TE> tcs = new();
        OnFirst<TE>(v => {
            if (condition == null || condition(v)) {
                tcs.SetResult(v);
            }
        });
        return tcs.Task;
    }

    /// <summary>
    /// Registers this event node as the handler for all attribute based
    /// event handlers in this context.
    /// </summary>
    public void RegisterStaticListeners() {
        try {
            IEnumerable<MethodInfo> methods = AppDomain.CurrentDomain.GetAssemblies() // Returns all currenlty loaded assemblies
                .SelectMany(x => x.GetTypes()) // returns all types defined in this assemblies
                .Where(x => x.IsClass) // only yields classes
                .SelectMany(x => x.GetMethods()) // returns all methods defined in those classes
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
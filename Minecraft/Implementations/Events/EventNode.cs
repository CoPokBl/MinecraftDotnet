using System.Reflection;

namespace Minecraft.Implementations.Events;

public class EventNode<T> {
    public List<(EventNode<T>, Func<T, bool>)> Children { get; } = [];
    public event Action<T>? Callback;

    public EventNode<T>? Parent;

    public EventNode<T> CreateChild<TS>(Func<TS, bool>? condition = null) where TS : T {
        EventNode<T> child = new() {
            Parent = this
        };
        Children.Add((child, condition == null ? e => e is TS : e => e is TS ts && condition(ts)));
        return child;
    }
    
    public EventNode<T> CreateChild(Func<T, bool>? condition = null) {
        EventNode<T> child = new() {
            Parent = this
        };
        Children.Add((child, condition ?? (_ => true)));
        return child;
    }
    
    public void AddChild(EventNode<T> child, Func<T, bool>? condition = null) {
        condition ??= _ => true;
        child.Parent = this;
        Children.Add((child, condition));
    }
    
    public void AddChild<TS>(EventNode<T> child, Func<TS, bool>? condition = null) where TS : T {
        Children.Add((child, condition == null ? e => e is TS : e => e is TS ts && condition(ts)));
        child.Parent = this;
    }
    
    public void RemoveChild(EventNode<T> child) {
        Children.RemoveAll(c => c.Item1 == child);
        child.Parent = null;
    }
    
    public Action AddListener<TL>(Action<TL> callback) where TL : T {
        Action<T> call = obj => {
            if (obj is not TL tl) {
                return;
            }

            callback(tl);
        };
        Callback += call;

        return () => {
            Callback -= call;
        };
    }

    public Action AddListener(Type type, Action<T> callback) {
        Action<T> call = obj => {
            if (obj!.GetType().IsAssignableTo(type)) {
                callback((T)obj);
            }
        };
        Callback += call;

        return () => {
            Callback -= call;
        };
    }

    /// <summary>
    /// Listens for an event once and then never again.
    /// <p/>
    /// Disconnects the listener after getting triggered once.
    /// </summary>
    /// <param name="callback">The listener.</param>
    /// <typeparam name="TL">The event type to listen for.</typeparam>
    public void OnFirst<TL>(Action<TL> callback) where TL : T {
        Action<T> actualListener = null!;
        actualListener = obj => {
            if (obj is not TL tl) {
                return;
            }

            callback(tl);
            Callback -= actualListener;
        };
        Callback += actualListener;
    }
    
    public void OnFirstWhere<TL>(Func<TL, bool> condition, Action<TL> callback) where TL : T {
        Action<T> actualListener = null!;
        actualListener = obj => {
            if (obj is not TL tl || !condition(tl)) {
                return;
            }

            callback(tl);
            Callback -= actualListener;
        };
        Callback += actualListener;
    }
    
    public void CallEvent(T e) {
        if (Parent != null) {
            Parent.CallEvent(e);
            return;
        }
        
        ExecuteEventCallbacks(e);
    }
    
    private void ExecuteEventCallbacks(T e) {
        try {
            // Stopwatch sw = Stopwatch.StartNew();
            Callback?.Invoke(e);
            
            (EventNode<T>, Func<T, bool>)[] children = Children.ToArray();  // avoid modifying while iterating
            foreach ((EventNode<T> child, Func<T, bool> condition) in children) {
                if (condition(e)) {
                    child.ExecuteEventCallbacks(e);
                }
            }
            // if (sw.ElapsedMilliseconds > 0) Console.WriteLine($"Event ({e.GetType().FullName}) took {sw.ElapsedMilliseconds}ms");
        }
        catch (StackOverflowException) {
            Console.WriteLine("Stack overflow occured while handling event");
            throw;
        }
        catch (Exception exception) {
            Console.WriteLine("An error occured while handling an event:");
            Console.WriteLine(exception);
            throw;
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
    
    public ManualResetEventSlim GetWaiterFor<TE>(Func<TE, bool> condition) where TE : T {
        ManualResetEventSlim mre = new(false);
        OnFirst<TE>(v => {
            if (condition(v)) {
                mre.Set();
            }
        });
        return mre;
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
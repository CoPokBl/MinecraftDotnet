using System.Reflection;

namespace Minecraft.Implementations.Events;

public class EventNode<T> {
    public List<EventNode<T>> Parents { get; }
    public event Action<T>? Callback;
    
    public EventNode(params EventNode<T>[] parents) {
        Parents = new List<EventNode<T>>(parents);

        foreach (EventNode<T> parent in parents) {
            Callback += e => parent.Callback!(e);  // We trigger our parent's callbacks
        }
    }

    public void AddParent(EventNode<T> parent) {
        Callback += e => parent.Callback!(e);
    }

    public void AddListener<TL>(Action<TL> callback) where TL : T {
        Callback += obj => {
            if (obj is not TL tl) {
                return;
            }

            callback(tl);
        };
    }

    public void AddListener(Type type, Action<T> callback) {
        Callback += obj => {
            if (obj!.GetType().IsAssignableTo(type)) {
                callback((T)obj);
            }
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
    
    public void CallEvent(T e) {
        try {
            Callback?.Invoke(e);
        }
        catch (Exception exception) {
            Console.WriteLine("An error occured while handling an event:");
            Console.WriteLine(exception);
            throw;
        }
    }

    public void CallEventCatchErrors(T e) {
        try {
            Callback?.Invoke(e);
        }
        catch (Exception exception) {
            Console.WriteLine("An error occured while handling an event:");
            Console.WriteLine(exception);
        }
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
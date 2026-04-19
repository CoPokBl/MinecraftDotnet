namespace ManagedServer.Scheduling;

public class ScheduledTask(Action action, Action? cancelAction = null) {
    public bool Cancelled {
        get => _cancelled;
        private set => _cancelled = value;
    }

    private volatile bool _cancelled;

    // Human-readable name derived from the delegate target and method, shown in slow-task warnings.
    public string Description { get; } = action.Target?.GetType().Name is { } t
        ? $"{t}.{action.Method.Name}"
        : $"static.{action.Method.Name}";

    public void Cancel() {
        Cancelled = true;
        cancelAction?.Invoke();
    }

    public void Run() {
        action();
    }
}

namespace ClientLib.Scheduling;

public class ScheduledTask(Action action, Action? cancelAction = null) {
    public bool Cancelled {
        get => _cancelled;
        private set => _cancelled = value;
    }

    private readonly object _lock = new();
    private volatile bool _cancelled;

    public void Cancel() {
        Cancelled = true;
        cancelAction?.Invoke();
    }

    public void Run() {
        action();
    }
}

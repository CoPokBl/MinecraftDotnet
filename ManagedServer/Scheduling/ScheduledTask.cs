namespace ManagedServer.Scheduling;

public class ScheduledTask(Action action, Action? cancelAction = null) {
    public bool Cancelled {
        get => _cancelled;
        private set => _cancelled = value;
    }

    private volatile bool _cancelled;

    public void Cancel() {
        Cancelled = true;
        cancelAction?.Invoke();
    }

    public void Run() {
        action();
    }
}

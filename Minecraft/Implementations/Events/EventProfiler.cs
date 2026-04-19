namespace Minecraft.Implementations.Events;

/// <summary>
/// Global hook for per-listener performance profiling in <see cref="EventNode{T}"/>.
/// When <see cref="Logger"/> is non-null, every event listener invocation is timed and
/// logged if it exceeds <see cref="ThresholdMs"/>. Set <see cref="Logger"/> to null
/// (the default) to disable profiling entirely — there is zero overhead when it is null.
/// </summary>
public static class EventProfiler {
    private static volatile Action<string>? _logger;
    private static volatile int _thresholdMs = 10;

    public static Action<string>? Logger {
        get => _logger;
        set => _logger = value;
    }

    /// <summary>Listeners taking at least this many milliseconds are logged.</summary>
    public static int ThresholdMs {
        get => _thresholdMs;
        set => _thresholdMs = value;
    }
}

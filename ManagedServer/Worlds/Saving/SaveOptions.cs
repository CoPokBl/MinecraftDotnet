using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds.Saving;

/// <summary>Which of a world's loaded chunks a save takes.</summary>
public enum SaveScope {
    /// <summary>
    /// Chunks written to, or generated, since the world's sink last stored them. What an autosave
    /// wants: a world where nobody has built costs nothing to save, however large it is.
    /// </summary>
    Changed,

    /// <summary>
    /// Every loaded chunk, whether or not it has changed. For rewriting a world after a format change,
    /// or for a first save of a map that was loaded from somewhere else.
    /// </summary>
    Loaded
}

public sealed record SaveOptions {
    public static readonly SaveOptions Default = new();

    public SaveScope Scope { get; init; } = SaveScope.Changed;

    /// <summary>
    /// A last say over which chunks are written, on top of <see cref="Scope"/>. What a world that
    /// persists a build area and throws away everything around it uses.
    /// </summary>
    public Func<Vec2<int>, bool>? Chunks { get; init; }

    /// <summary>
    /// How many chunks may be encoded and written at once.
    /// <p/>
    /// Bounded rather than handed to the pool whole, for the same reason chunk generation is: the
    /// pool's queue is global and first in first out, so a save posted as one item per chunk puts
    /// every packet and every scheduled task behind the whole world.
    /// </summary>
    public int MaxConcurrency { get; init; } = Math.Max(1, Environment.ProcessorCount / 2);

    /// <summary>Whether to make the sink durable at the end. Off for one save in a series.</summary>
    public bool Flush { get; init; } = true;

    /// <summary>
    /// Whether one chunk failing stops the save. Off by default, so a single unwritable chunk costs
    /// that chunk rather than everything after it in the sweep.
    /// </summary>
    public bool StopOnError { get; init; }
}

using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds.Saving;

/// <summary>
/// What a save actually did. Returned rather than logged, because a save that half failed and said
/// nothing is how a world quietly loses a region.
/// </summary>
public sealed record SaveReport {
    public required int Written { get; init; }

    /// <summary>Chunks the scope or the predicate passed over.</summary>
    public required int Skipped { get; init; }

    public required TimeSpan Duration { get; init; }

    public required IReadOnlyList<ChunkSaveFailure> Failures { get; init; }

    public int Failed => Failures.Count;

    public bool Success => Failures.Count == 0;

    public override string ToString() {
        return $"{Written} chunks in {Duration.TotalMilliseconds:N0} ms, {Skipped} skipped, {Failed} failed";
    }
}

/// <param name="Position">The chunk that failed, or null for a failure to make the sink durable.</param>
public sealed record ChunkSaveFailure(Vec2<int>? Position, Exception Error);

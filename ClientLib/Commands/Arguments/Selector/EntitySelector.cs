using ClientLib.Maths;
using Minecraft.Data.Entities;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>EntitySelector</c> sorting functions, as which one a selector asked for.</summary>
public enum EntitySelectorOrder {
    Arbitrary,
    Nearest,
    Furthest,
    Random
}

/// <summary>Vanilla's <c>EntitySelector</c> as the parser builds it, without the option predicates: the client never resolves one.</summary>
public sealed class EntitySelector(
    int maxResults,
    bool includesEntities,
    bool worldLimited,
    MinMaxBounds.Doubles? range,
    Func<Vec3d, Vec3d> position,
    EntitySelector.Box? aabb,
    EntitySelectorOrder order,
    bool currentEntity,
    string? playerName,
    Guid? entityUuid,
    IEntityType? type,
    bool usesSelector) {

    /// <summary>Vanilla's <c>AABB</c>, relative to the selector's position.</summary>
    public readonly record struct Box(double MinX, double MinY, double MinZ, double MaxX, double MaxY, double MaxZ);

    public int MaxResults { get; } = maxResults;
    public bool IncludesEntities { get; } = includesEntities;
    public bool IsWorldLimited { get; } = worldLimited;
    public MinMaxBounds.Doubles? Range { get; } = range;
    public Func<Vec3d, Vec3d> Position { get; } = position;
    public Box? Aabb { get; } = aabb;
    public EntitySelectorOrder Order { get; } = order;
    public bool IsSelfSelector { get; } = currentEntity;
    public string? PlayerName { get; } = playerName;
    public Guid? EntityUuid { get; } = entityUuid;

    /// <summary>Null is vanilla's <c>ANY_TYPE</c>.</summary>
    public IEntityType? Type { get; } = type;

    public bool UsesSelector { get; } = usesSelector;
}

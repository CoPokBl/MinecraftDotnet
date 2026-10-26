using Minecraft.Schemas.Vec;

namespace Minecraft.Data.Entities;

/// <summary>
/// The points hanging off an entity, relative to its position. Each one is a list because an entity
/// can have several: a boat has two seats.
/// </summary>
/// <param name="Passenger">Where something riding this entity sits.</param>
/// <param name="Vehicle">Where this entity sits when it is the one riding.</param>
/// <param name="NameTag">Where the name floats.</param>
/// <param name="WardenChest">What a warden aims its sonic boom at.</param>
public sealed record EntityAttachments(
    Vec3<double>[] Passenger,
    Vec3<double>[] Vehicle,
    Vec3<double>[] NameTag,
    Vec3<double>[] WardenChest);

using ClientLib.Entities;
using ClientLib.Maths;
using Minecraft.Schemas;

namespace ClientLib.Interaction;

/// <summary>What the crosshair is on: a block, an entity, or nothing within reach.</summary>
public abstract record HitResult(Vec3d Location);

public sealed record BlockHitResult(Vec3d Location, int X, int Y, int Z, BlockFace Face, bool Inside) : HitResult(Location);

public sealed record EntityHitResult(Vec3d Location, ClientEntity Entity) : HitResult(Location);

public sealed record MissResult(Vec3d Location) : HitResult(Location);

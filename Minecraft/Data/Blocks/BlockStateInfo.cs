using Minecraft.Data.Entities;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Blocks;

/// <summary>
/// Everything about a block that one of its states can disagree with another about. A top slab and
/// a bottom slab are the same block and collide differently, so the shapes and most of the flags
/// live here rather than on <see cref="BlockInfo"/>.
/// <p/>
/// Instances are shared: two states that describe the same thing get the same one.
/// </summary>
/// <param name="LightDampening">How much light the block takes out of what passes through it.</param>
/// <param name="RandomlyTicking">Whether the block gets random ticks, as crops and leaves do.</param>
/// <param name="Suffocating">Whether standing inside the block suffocates.</param>
/// <param name="ViewBlocking">Whether standing inside the block blinds the client.</param>
/// <param name="ViewBlockingNearPlane">
/// Whether it blinds the client only where the camera's near plane box meets the occlusion shape,
/// <c>Blocks.NEAR_PLANE_INTERSECTS_OUTLINE</c>, which slabs and stairs use. Never set together with
/// <paramref name="ViewBlocking"/>.
/// </param>
/// <param name="Instrument">What a note block sitting on top of this one plays.</param>
/// <param name="ValidSpawnFor">
/// The entity types that can spawn on this state, or null when every type can. Vanilla's predicate
/// takes the type and leaves use that, so a plain flag would not be the truth.
/// </param>
/// <param name="PathfindableLand">
/// <c>BlockState.isPathfindable(LAND)</c>, the first thing the node evaluator asks of a block and
/// the difference between a route through it and a wall. It is not the same as having no collision
/// shape: a closed door has one and is pathfindable through for a mob that can open it, and a lily
/// pad has one and is walked on.
/// </param>
/// <param name="PathfindableWater">The same for <c>WATER</c>, which is what a swimming mob asks.</param>
/// <param name="PathfindableAir">The same for <c>AIR</c>, which is what a flying mob asks.</param>
/// <param name="SupportShape">
/// <c>BlockState.getBlockSupportShape</c>, what <c>isFaceSturdy</c> measures and therefore what
/// decides whether a ladder, a door, a torch or a fence connection can attach here. It is the
/// collision shape for almost everything and deliberately not for a handful: leaves support
/// nothing, mud and soul sand support as full cubes though they do not collide as one, and an open
/// fence gate supports nothing.
/// </param>
public sealed record BlockStateInfo(
    float Hardness,
    int LightEmission,
    int LightDampening,
    PushReaction PushReaction,
    int MapColorId,
    string SoundType,
    NoteBlockInstrument Instrument,
    bool CanRespawnIn,
    bool Occludes,
    bool RequiresTool,
    bool Flammable,
    bool Air,
    bool Liquid,
    bool Replaceable,
    bool Solid,
    bool RedstoneConductor,
    bool SignalSource,
    bool RandomlyTicking,
    bool Suffocating,
    bool ViewBlocking,
    bool ViewBlockingNearPlane,
    bool SpawnTerrainParticles,
    bool PathfindableLand,
    bool PathfindableWater,
    bool PathfindableAir,
    Identifier[]? ValidSpawnFor,
    Identifier? Fluid,
    ICollisionBox BlockShape,
    ICollisionBox CollisionShape,
    ICollisionBox InteractionShape,
    ICollisionBox OcclusionShape,
    ICollisionBox VisualShape,
    ICollisionBox SupportShape) {

    /// <summary><c>BlockState.isValidSpawn</c>: whether the given entity type can spawn on this state.</summary>
    public bool IsValidSpawn(IEntityType type) {
        if (ValidSpawnFor is null) {
            return true;
        }

        foreach (Identifier allowed in ValidSpawnFor) {
            if (allowed.Equals(type.Identifier)) {
                return true;
            }
        }

        return false;
    }
}

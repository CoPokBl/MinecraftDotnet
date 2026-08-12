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
/// <param name="BlocksMotion">
/// Whether the block stops an entity walking into it, which is not the same as having a collision
/// shape: a lily pad has one and does not block motion.
/// </param>
/// <param name="RandomlyTicking">Whether the block gets random ticks, as crops and leaves do.</param>
/// <param name="Suffocating">Whether standing inside the block suffocates.</param>
/// <param name="ViewBlocking">Whether standing inside the block blinds the client.</param>
/// <param name="Instrument">What a note block sitting on top of this one plays.</param>
/// <param name="ValidSpawnFor">
/// The entity types that can spawn on this state, or null when every type can. Vanilla's predicate
/// takes the type and leaves use that, so a plain flag would not be the truth.
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
    bool BlocksMotion,
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
    bool SpawnTerrainParticles,
    Identifier[]? ValidSpawnFor,
    Identifier? Fluid,
    ICollisionBox BlockShape,
    ICollisionBox CollisionShape,
    ICollisionBox InteractionShape,
    ICollisionBox OcclusionShape,
    ICollisionBox VisualShape) {

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

using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Meta;

namespace ClientLib.Entities;

/// <summary>
/// <c>PrimedTnt</c>. Its tick never calls <c>baseTick</c>, so the fluid check comes last and nothing
/// checks for the bottom of the world.
/// </summary>
public sealed class ClientPrimedTnt(MinecraftClient client) : SimulatedEntity(client) {
    /// <summary><c>PrimedTnt.DEFAULT_FUSE_TIME</c>, the synced fuse's default.</summary>
    private const int DefaultFuseTime = 80;

    /// <summary>The client's own copy of the synced fuse, which its tick counts down until a sync replaces it.</summary>
    public int Fuse => Get(EntityDataFields.PrimedTnt.Fuse, DefaultFuseTime);

    /// <summary><c>PrimedTnt.tick</c>, client side: the explosion is the server's.</summary>
    protected override void EntityTick() {
        ApplyGravity();
        Move(DeltaMovement);
        ApplyEffectsFromBlocks();
        DeltaMovement *= AirDrag;
        if (OnGround) {
            DeltaMovement = DeltaMovement.Multiply(0.7, -0.5, 0.7);
        }
        int fuse = Fuse - 1;
        Set(EntityDataFields.PrimedTnt.Fuse, MetaFieldType.VarInt, fuse);
        if (fuse <= 0) {
            Client.Discard(this);
        }
        else {
            UpdateFluidInteraction();
        }
    }
}

/// <summary>
/// <c>FallingBlockEntity</c>. Landing, and the discard after <c>time</c> runs out, are the server's: the
/// client keeps falling against the floor until the block is placed and the entity removed. Its tick
/// never calls <c>baseTick</c>, so nothing checks for the bottom of the world.
/// </summary>
public sealed class ClientFallingBlock(MinecraftClient client) : SimulatedEntity(client) {
    /// <summary><c>FallingBlockEntity.tick</c>, client side.</summary>
    protected override void EntityTick() {
        // recreateFromPacket reads the block state from the spawn data, and state 0 is air.
        if (SpawnData == 0) {
            Client.Discard(this);
            return;
        }
        ApplyGravity();
        Move(DeltaMovement);
        ApplyEffectsFromBlocks();
        DeltaMovement *= AirDrag;
    }
}

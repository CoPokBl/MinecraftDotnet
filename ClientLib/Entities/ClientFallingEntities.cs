namespace ClientLib.Entities;

/// <summary><c>PrimedTnt</c>. Its tick never calls <c>baseTick</c>, so the fluid check comes last.</summary>
public sealed class ClientPrimedTnt(MinecraftClient client) : SimulatedEntity(client) {
    /// <summary><c>PrimedTnt.tick</c>, client side. The fuse is counted by whatever draws it.</summary>
    protected override void EntityTick() {
        ApplyGravity();
        Move(DeltaMovement);
        ApplyEffectsFromBlocks();
        DeltaMovement *= AirDrag;
        if (OnGround) {
            DeltaMovement = DeltaMovement.Multiply(0.7, -0.5, 0.7);
        }
        UpdateFluidInteraction();
    }
}

/// <summary>
/// <c>FallingBlockEntity</c>. Landing is the server's: the client keeps falling against the floor
/// until the block is placed and the entity removed.
/// </summary>
public sealed class ClientFallingBlock(MinecraftClient client) : SimulatedEntity(client) {
    /// <summary><c>FallingBlockEntity.tick</c>, client side.</summary>
    protected override void EntityTick() {
        // recreateFromPacket reads the block state from the spawn data, and state 0 is air.
        if (SpawnData == 0) {
            return;
        }
        ApplyGravity();
        Move(DeltaMovement);
        ApplyEffectsFromBlocks();
        DeltaMovement *= AirDrag;
    }
}

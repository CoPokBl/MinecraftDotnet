using ClientLib.Maths;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace ClientLib.Entities;

/// <summary>
/// <c>ItemEntity</c>. Its client tick is the server's without merging and without the bounce off a
/// slime block, which reach the client as corrections.
/// </summary>
public sealed class ClientItemEntity(MinecraftClient client) : SimulatedEntity(client) {
    protected override float BelowThatAffectsMovementOffset => 0.999999F;

    public ItemStack Item => Get(EntityDataFields.ItemEntity.Item) ?? ItemStack.Air;

    /// <summary><c>ItemEntity.tick</c>, client side.</summary>
    protected override void EntityTick() {
        if (Item.IsAir()) {
            Client.Discard(this);
            return;
        }

        BaseTick();
        if (IsInWater && Fluids.WaterHeight > 0.1F) {
            SetFluidMovement(0.99F);
        }
        else if (IsInLava && Fluids.LavaHeight > 0.1F) {
            SetFluidMovement(0.95F);
        }
        else {
            ApplyGravity();
        }

        if (OnGround && !(DeltaMovement.HorizontalDistanceSqr() > 1.0E-5F) && (TickCount + Id) % 4 != 0) {
            ApplyEffectsFromBlocksForLastMovements();
        }
        else {
            Move(DeltaMovement);
            ApplyEffectsFromBlocks();
            float groundFriction = AirDrag;
            if (OnGround) {
                groundFriction = AirDrag * FrictionBelow();
            }

            DeltaMovement = DeltaMovement.Multiply(groundFriction, AirDrag, groundFriction);
            if (OnGround) {
                Vec3d movement = DeltaMovement;
                if (movement.Y < 0.0) {
                    DeltaMovement = movement.Multiply(1.0, -0.5, 1.0);
                }
            }
        }

        UpdateFluidInteraction();
    }

    /// <summary><c>ItemEntity.setFluidMovement</c>.</summary>
    private void SetFluidMovement(double multiplier) {
        Vec3d movement = DeltaMovement;
        DeltaMovement = new Vec3d(movement.X * multiplier, movement.Y + (movement.Y < 0.06F ? 5.0E-4F : 0.0F), movement.Z * multiplier);
    }
}

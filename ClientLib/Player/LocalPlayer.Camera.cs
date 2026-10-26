using ClientLib.Interaction;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Player;

/// <summary>What the player's state does to the view: the spyglass, the field of view and the block the eyes are in.</summary>
public sealed partial class LocalPlayer {
    /// <summary>The block classes whose <c>getRenderShape</c> is <c>INVISIBLE</c>.</summary>
    private static readonly BlockClass[] InvisibleRenderShapes = [
        BlockClass.AirBlock, BlockClass.BarrierBlock, BlockClass.LightBlock, BlockClass.StructureVoidBlock, BlockClass.MovingPistonBlock,
        BlockClass.LiquidBlock, BlockClass.BubbleColumnBlock, BlockClass.EndPortalBlock, BlockClass.EndGatewayBlock
    ];

    /// <summary><c>Player.isScoping</c>.</summary>
    public bool IsScoping => IsUsingItem && UseItem.Type.Identifier == Item.Spyglass.Identifier;

    /// <summary><c>LivingEntity.getTicksUsingItem</c>.</summary>
    public int TicksUsingItem => IsUsingItem ? UsePrediction.UseDuration(UseItem) - UseItemRemainingTicks : 0;

    /// <summary><c>getItemBySlot</c>: the server never sends the player its own equipment, which is its inventory's.</summary>
    public ItemStack EquippedItem(EquipmentSlot slot) => slot switch {
        EquipmentSlot.MainHand => ItemInHand(Hand.MainHand),
        EquipmentSlot.OffHand => ItemInHand(Hand.OffHand),
        // Inventory.EQUIPMENT_SLOT_MAPPING.
        EquipmentSlot.Boots => _client.Inventory.Get(36).ToItemStack(),
        EquipmentSlot.Leggings => _client.Inventory.Get(37).ToItemStack(),
        EquipmentSlot.Chestplate => _client.Inventory.Get(38).ToItemStack(),
        EquipmentSlot.Helmet => _client.Inventory.Get(39).ToItemStack(),
        _ => GetItemBySlot(slot)
    };

    /// <summary><c>AbstractClientPlayer.getFieldOfViewModifier</c>.</summary>
    public float FieldOfViewModifier(bool firstPerson, float effectScale) {
        float modifier = 1.0F;
        if (Flying) {
            modifier *= 1.1F;
        }
        float walkingSpeed = WalkingSpeed;
        if (walkingSpeed != 0.0F) {
            float speedFactor = (float)AttributeValue(Attribute.MovementSpeed) / walkingSpeed;
            modifier *= (speedFactor + 1.0F) / 2.0F;
        }
        if (IsUsingItem) {
            if (UseItem.Type.Identifier == Item.Bow.Identifier) {
                float scale = Math.Min(TicksUsingItem / 20.0F, 1.0F);
                modifier *= 1.0F - scale * scale * 0.15F;
            }
            else if (firstPerson && IsScoping) {
                return 0.1F;
            }
        }
        return Minecraft.Schemas.Mth.Lerp(effectScale, 1.0F, modifier);
    }

    /// <summary>
    /// <c>ScreenEffectRenderer.getViewBlockingState</c>: the first block that blinds the view of the eight
    /// corners of a box about the eyes, which <c>ScreenEffectRenderer</c> draws over the screen.
    /// </summary>
    public IBlock? ViewBlockingState() {
        if (NoPhysics) {
            return null;
        }
        float width = DimensionsOf(Pose).Width;
        float scale = (float)AttributeValue(Attribute.Scale);
        double eyeY = Position.Y + CurrentEyeHeight;
        for (int i = 0; i < 8; i++) {
            int x = (int)Math.Floor(Position.X + ((i >> 0) % 2 - 0.5F) * width * 0.8F);
            int y = (int)Math.Floor(eyeY + ((i >> 1) % 2 - 0.5F) * 0.1F * scale);
            int z = (int)Math.Floor(Position.Z + ((i >> 2) % 2 - 0.5F) * width * 0.8F);
            IBlock state = Level.GetBlock(x, y, z);
            if (state.ViewBlocking && !InvisibleRenderShapes.Any(shape => BlockClasses.Is(state.Identifier, shape))) {
                return state;
            }
        }
        return null;
    }
}

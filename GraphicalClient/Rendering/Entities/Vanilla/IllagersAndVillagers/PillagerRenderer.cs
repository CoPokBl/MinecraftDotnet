using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class PillagerRenderer : IllagerRenderer<IllagerRenderState> {
    private const string Pillager = "minecraft:textures/entity/illager/pillager.png";

    public PillagerRenderer(EntityRendererContext context) : base(context) {
        AddLayer(new ItemInHandLayer<IllagerRenderState, IllagerModel<IllagerRenderState>>(this, context.Items));
    }

    public override string GetTextureLocation(IllagerRenderState state) => Pillager;

    /// <summary><c>Pillager.getArmPose</c>.</summary>
    protected override IllagerArmPose GetArmPose(ClientEntity entity) {
        if (entity.Get(EntityDataFields.Pillager.IsChargingCrossbow)) {
            return IllagerArmPose.CrossbowCharge;
        }
        // LivingEntity.isHolding: either hand.
        if (entity.ItemInHand(Hand.MainHand).Type.Identifier == Item.Crossbow.Identifier || entity.ItemInHand(Hand.OffHand).Type.Identifier == Item.Crossbow.Identifier) {
            return IllagerArmPose.CrossbowHold;
        }
        return HumanoidEntityData.IsAggressive(entity) ? IllagerArmPose.Attacking : IllagerArmPose.Neutral;
    }
}

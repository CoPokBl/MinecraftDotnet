using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>VindicatorRenderer</c>: the weapon shows only while aggressive.</summary>
public sealed class VindicatorRenderer : IllagerRenderer<IllagerRenderState> {
    private const string Vindicator = "minecraft:textures/entity/illager/vindicator.png";

    public VindicatorRenderer(EntityRendererContext context) : base(context) {
        AddLayer(new ConditionalItemInHandLayer(this, context.Items, state => state.IsAggressive));
    }

    public override string GetTextureLocation(IllagerRenderState state) => Vindicator;

    /// <summary><c>Vindicator.getArmPose</c>.</summary>
    protected override IllagerArmPose GetArmPose(ClientEntity entity) {
        if (HumanoidEntityData.IsAggressive(entity)) {
            return IllagerArmPose.Attacking;
        }
        return IsCelebrating(entity) ? IllagerArmPose.Celebrating : IllagerArmPose.Crossed;
    }
}

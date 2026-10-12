namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class PhantomEyesLayer : EyesLayer<PhantomRenderState, PhantomModel> {
    public PhantomEyesLayer(LivingEntityRenderer<PhantomRenderState, PhantomModel> parent) : base(parent) { }

    public override string Texture => "minecraft:textures/entity/phantom/phantom_eyes.png";
}

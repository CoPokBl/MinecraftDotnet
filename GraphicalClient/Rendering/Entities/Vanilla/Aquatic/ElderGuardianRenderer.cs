namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class ElderGuardianRenderer : GuardianRenderer {
    public const string GuardianElderLocation = "minecraft:textures/entity/guardian/guardian_elder.png";

    public ElderGuardianRenderer(EntityRendererContext context) : base(context, 1.2F, GuardianModel.CreateElderGuardianLayer()) { }

    public override string GetTextureLocation(GuardianRenderState state) => GuardianElderLocation;
}

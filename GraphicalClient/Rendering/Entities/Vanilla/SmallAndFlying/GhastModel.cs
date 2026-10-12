using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class GhastModel : EntityModel<GhastRenderState> {
    private readonly ModelPart[] _tentacles = new ModelPart[9];

    public GhastModel(ModelPart root) : base(root) {
        for (int i = 0; i < _tentacles.Length; i++) {
            _tentacles[i] = root.GetChild(Tentacle(i));
        }
    }

    /// <summary><c>PartNames.tentacle</c>.</summary>
    public static string Tentacle(int i) => "tentacle" + i;

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-8.0F, -8.0F, -8.0F, 16.0F, 16.0F, 16.0F), PartPose.Offset(0.0F, 17.6F, 0.0F));
        // RandomSource.createThreadLocalInstance(1660L) is a SingleThreadedRandomSource, the same LCG
        // stream as LegacyRandomSource.
        RandomSource random = new LegacyRandomSource(1660L);
        for (int i = 0; i < 9; i++) {
            float xo = ((i % 3 - i / 3 % 2 * 0.5F + 0.25F) / 2.0F * 2.0F - 1.0F) * 5.0F;
            float yo = (i / 3 / 2.0F * 2.0F - 1.0F) * 5.0F;
            int len = random.NextInt(7) + 8;
            root.AddOrReplaceChild(Tentacle(i), CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, len, 2.0F), PartPose.Offset(xo, 24.6F, yo));
        }
        return LayerDefinition.Create(mesh, 64, 32).Apply(MeshTransformers.Scaling(4.5F));
    }

    public override void SetupAnim(GhastRenderState state) {
        base.SetupAnim(state);
        AnimateTentacles(state, _tentacles);
    }

    public static void AnimateTentacles(EntityRenderState state, ModelPart[] tentacles) {
        for (int i = 0; i < tentacles.Length; i++) {
            tentacles[i].XRot = 0.2F * Mth.Sin(state.AgeInTicks * 0.3F + i) + 0.4F;
        }
    }
}

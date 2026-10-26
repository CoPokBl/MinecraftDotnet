namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BlazeModel : EntityModel<LivingEntityRenderState> {
    private readonly ModelPart[] _upperBodyParts;
    private readonly ModelPart _head;

    public BlazeModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _upperBodyParts = new ModelPart[12];
        for (int i = 0; i < _upperBodyParts.Length; i++) {
            _upperBodyParts[i] = root.GetChild(GetPartName(i));
        }
    }

    private static string GetPartName(int i) => "part" + i;

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -4.0F, -4.0F, 8.0F, 8.0F, 8.0F), PartPose.Zero);
        float angle = 0.0F;
        CubeListBuilder rod = CubeListBuilder.Create().TexOffs(0, 16).AddBox(0.0F, 0.0F, 0.0F, 2.0F, 8.0F, 2.0F);
        for (int i = 0; i < 4; i++) {
            float x = Mth.Cos(angle) * 9.0F;
            float y = -2.0F + Mth.Cos(i * 2 * 0.25F);
            float z = Mth.Sin(angle) * 9.0F;
            root.AddOrReplaceChild(GetPartName(i), rod, PartPose.Offset(x, y, z));
            angle++;
        }
        angle = MathF.PI / 4;
        for (int i = 4; i < 8; i++) {
            float x = Mth.Cos(angle) * 7.0F;
            float y = 2.0F + Mth.Cos(i * 2 * 0.25F);
            float z = Mth.Sin(angle) * 7.0F;
            root.AddOrReplaceChild(GetPartName(i), rod, PartPose.Offset(x, y, z));
            angle++;
        }
        angle = 0.47123894F;
        for (int i = 8; i < 12; i++) {
            float x = Mth.Cos(angle) * 5.0F;
            float y = 11.0F + Mth.Cos(i * 1.5F * 0.5F);
            float z = Mth.Sin(angle) * 5.0F;
            root.AddOrReplaceChild(GetPartName(i), rod, PartPose.Offset(x, y, z));
            angle++;
        }
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(LivingEntityRenderState state) {
        base.SetupAnim(state);
        float angle = state.AgeInTicks * MathF.PI * -0.1F;
        for (int i = 0; i < 4; i++) {
            _upperBodyParts[i].Y = -2.0F + Mth.Cos((i * 2 + state.AgeInTicks) * 0.25F);
            _upperBodyParts[i].X = Mth.Cos(angle) * 9.0F;
            _upperBodyParts[i].Z = Mth.Sin(angle) * 9.0F;
            angle++;
        }
        angle = MathF.PI / 4 + state.AgeInTicks * MathF.PI * 0.03F;
        for (int i = 4; i < 8; i++) {
            _upperBodyParts[i].Y = 2.0F + Mth.Cos((i * 2 + state.AgeInTicks) * 0.25F);
            _upperBodyParts[i].X = Mth.Cos(angle) * 7.0F;
            _upperBodyParts[i].Z = Mth.Sin(angle) * 7.0F;
            angle++;
        }
        angle = 0.47123894F + state.AgeInTicks * MathF.PI * -0.05F;
        for (int i = 8; i < 12; i++) {
            _upperBodyParts[i].Y = 11.0F + Mth.Cos((i * 1.5F + state.AgeInTicks) * 0.5F);
            _upperBodyParts[i].X = Mth.Cos(angle) * 5.0F;
            _upperBodyParts[i].Z = Mth.Sin(angle) * 5.0F;
            angle++;
        }
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
    }
}

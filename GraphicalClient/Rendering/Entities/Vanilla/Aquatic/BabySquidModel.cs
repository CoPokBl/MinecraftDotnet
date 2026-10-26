namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabySquidModel : SquidModel {
    public BabySquidModel(ModelPart root) : base(root) { }

    public static new LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -5.0F, -4.0F, 8.0F, 10.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 13.0F, 0.0F));
        CubeListBuilder tentacle = CubeListBuilder.Create().TexOffs(0, 18).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 6.0F, 2.0F);
        for (int i = 0; i < 8; i++) {
            double angle = i * Math.PI * 2.0 / 8.0;
            float x = (float)Math.Cos(angle) * 3.0F;
            float z = (float)Math.Sin(angle) * 3.0F;
            angle = i * Math.PI * -2.0 / 8.0 + Math.PI / 2;
            float yRot = (float)angle;
            root.AddOrReplaceChild(CreateTentacleName(i), tentacle, PartPose.OffsetAndRotation(x, 18.5F, z, 0.0F, yRot, 0.0F));
        }
        return LayerDefinition.Create(mesh, 32, 32);
    }
}

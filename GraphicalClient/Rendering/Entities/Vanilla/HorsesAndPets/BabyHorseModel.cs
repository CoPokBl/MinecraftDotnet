namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BabyHorseModel</c>, generic for the reason <see cref="HorseModel{S}"/> is.</summary>
public class BabyHorseModel<S>(ModelPart root) : HorseModel<S>(root) where S : EquineRenderState {
    public static LayerDefinition CreateBabyLayer(CubeDeformation g) => LayerDefinition.Create(CreateBabyMesh(g), 64, 64);

    public static MeshDefinition CreateBabyMesh(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 13).AddBox(-4.0F, -3.5F, -7.0F, 8.0F, 7.0F, 14.0F, g),
            PartPose.Offset(0.0F, 12.5F, 0.0F));
        body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(24, 34).AddBox(-1.5F, -1.5F, -1.0F, 3.0F, 3.0F, 8.0F, g),
            PartPose.OffsetAndRotation(0.0F, -1.0F, 7.0F, -0.7418F, 0.0F, 0.0F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(12, 46).AddBox(-1.5F, -1.0F, -1.5F, 3.0F, 9.0F, 3.0F, g),
            PartPose.Offset(2.4F, 16.0F, 5.4F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(0, 46).AddBox(-1.5F, -1.0F, -1.5F, 3.0F, 9.0F, 3.0F, g),
            PartPose.Offset(-2.4F, 16.0F, 5.4F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(12, 34).AddBox(-1.5F, -1.0F, -1.5F, 3.0F, 9.0F, 3.0F, g),
            PartPose.Offset(2.4F, 16.0F, -5.4F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(0, 34).AddBox(-1.5F, -1.0F, -1.5F, 3.0F, 9.0F, 3.0F, g),
            PartPose.Offset(-2.4F, 16.0F, -5.4F));
        PartDefinition neck = root.AddOrReplaceChild("head_parts", CubeListBuilder.Create().TexOffs(30, 0).AddBox(-2.0F, -6.0F, -2.0F, 4.0F, 8.0F, 4.0F, g),
            PartPose.OffsetAndRotation(0.0F, 10.0F, -6.0F, 0.6109F, 0.0F, 0.0F));
        PartDefinition head = neck.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.0F, -3.9484F, -6.705F, 6.0F, 4.0F, 9.0F, g),
            PartPose.Offset(0.0F, -6.0516F, -0.2951F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(0, 4).AddBox(-1.0F, -2.5F, -0.8F, 2.0F, 3.0F, 1.0F, g),
            PartPose.OffsetAndRotation(2.0F, -4.2484F, 1.9451F, 0.0F, 0.0F, 0.2618F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, -2.5F, -0.5F, 2.0F, 3.0F, 1.0F, g),
            PartPose.OffsetAndRotation(-2.0F, -4.2484F, 1.645F, 0.0F, 0.0F, -0.2618F));
        return mesh;
    }

    protected override float GetLegStandingYOffset() => 4.0F;

    protected override float GetLegStandingZOffset() => 0.0F;

    protected override float GetTailXRotOffset() => (float)(-Math.PI / 2);

    protected override void AnimateHeadPartsPlacement(float eating, float standing) {
        HeadParts.Y = HeadParts.Y + Mth.Lerp(eating, Mth.Lerp(standing, 0.0F, -2.0F), 2.0F);
        HeadParts.Z = Mth.Lerp(standing, HeadParts.Z, -4.0F);
    }
}

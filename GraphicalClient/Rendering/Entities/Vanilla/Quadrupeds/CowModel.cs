namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>Generic where vanilla's is fixed to <c>LivingEntityRenderState</c>, so the cow and the mooshroom renderer can each use their own state.</summary>
public class CowModel<S>(ModelPart root) : QuadrupedModel<S>(root) where S : LivingEntityRenderState {
    public ModelPart GetHead() => Head;
}

public static class CowModel {
    public static LayerDefinition CreateBodyLayer() => LayerDefinition.Create(CreateBaseCowModel(), 64, 64);

    public static MeshDefinition CreateBaseCowModel() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-4.0F, -4.0F, -6.0F, 8.0F, 8.0F, 6.0F)
            .TexOffs(1, 33).AddBox(-3.0F, 1.0F, -7.0F, 6.0F, 3.0F, 1.0F)
            .TexOffs(22, 0).AddBox("right_horn", -5.0F, -5.0F, -5.0F, 1.0F, 3.0F, 1.0F)
            .TexOffs(22, 0).AddBox("left_horn", 4.0F, -5.0F, -5.0F, 1.0F, 3.0F, 1.0F), PartPose.Offset(0.0F, 4.0F, -8.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(18, 4).AddBox(-6.0F, -10.0F, -7.0F, 12.0F, 18.0F, 10.0F)
            .TexOffs(52, 0).AddBox(-2.0F, 2.0F, -8.0F, 4.0F, 6.0F, 1.0F), PartPose.OffsetAndRotation(0.0F, 5.0F, 2.0F, MathF.PI / 2, 0.0F, 0.0F));
        CubeListBuilder leftLeg = CubeListBuilder.Create().Mirror().TexOffs(0, 16).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F);
        CubeListBuilder rightLeg = CubeListBuilder.Create().TexOffs(0, 16).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F);
        root.AddOrReplaceChild("right_hind_leg", rightLeg, PartPose.Offset(-4.0F, 12.0F, 7.0F));
        root.AddOrReplaceChild("left_hind_leg", leftLeg, PartPose.Offset(4.0F, 12.0F, 7.0F));
        root.AddOrReplaceChild("right_front_leg", rightLeg, PartPose.Offset(-4.0F, 12.0F, -5.0F));
        root.AddOrReplaceChild("left_front_leg", leftLeg, PartPose.Offset(4.0F, 12.0F, -5.0F));
        return mesh;
    }
}

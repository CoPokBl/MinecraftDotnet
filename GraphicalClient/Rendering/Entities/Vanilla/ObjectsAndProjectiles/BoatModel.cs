namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>AbstractBoatModel</c>.</summary>
public abstract class AbstractBoatModel : EntityModel<BoatRenderState> {
    private readonly ModelPart _leftPaddle;
    private readonly ModelPart _rightPaddle;

    protected AbstractBoatModel(ModelPart root) : base(root) {
        _leftPaddle = root.GetChild("left_paddle");
        _rightPaddle = root.GetChild("right_paddle");
    }

    public override void SetupAnim(BoatRenderState state) {
        base.SetupAnim(state);
        AnimatePaddle(state.RowingTimeLeft, 0, _leftPaddle);
        AnimatePaddle(state.RowingTimeRight, 1, _rightPaddle);
    }

    private static void AnimatePaddle(float time, int side, ModelPart paddle) {
        paddle.XRot = Mth.ClampedLerp((Mth.Sin(-time) + 1.0F) / 2.0F, (float)(-Math.PI / 3), (float)(-Math.PI / 12));
        paddle.YRot = Mth.ClampedLerp((Mth.Sin(-time + 1.0F) + 1.0F) / 2.0F, (float)(-Math.PI / 4), (float)(Math.PI / 4));
        if (side == 1) {
            paddle.YRot = (float)Math.PI - paddle.YRot;
        }
    }

    /// <summary>The chest the chest boat and chest raft layers both add, at the heights each gives.</summary>
    protected static void AddChest(PartDefinition root, float bottomY, float lidY, float lockY) {
        root.AddOrReplaceChild("chest_bottom", CubeListBuilder.Create().TexOffs(0, 76).AddBox(0.0F, 0.0F, 0.0F, 12.0F, 8.0F, 12.0F),
            PartPose.OffsetAndRotation(-2.0F, bottomY, -6.0F, 0.0F, (float)(-Math.PI / 2), 0.0F));
        root.AddOrReplaceChild("chest_lid", CubeListBuilder.Create().TexOffs(0, 59).AddBox(0.0F, 0.0F, 0.0F, 12.0F, 4.0F, 12.0F),
            PartPose.OffsetAndRotation(-2.0F, lidY, -6.0F, 0.0F, (float)(-Math.PI / 2), 0.0F));
        root.AddOrReplaceChild("chest_lock", CubeListBuilder.Create().TexOffs(0, 59).AddBox(0.0F, 0.0F, 0.0F, 2.0F, 4.0F, 1.0F),
            PartPose.OffsetAndRotation(-1.0F, lockY, -1.0F, 0.0F, (float)(-Math.PI / 2), 0.0F));
    }
}

/// <summary><c>BoatModel</c>.</summary>
public sealed class BoatModel : AbstractBoatModel {
    public BoatModel(ModelPart root) : base(root) { }

    private static void AddCommonParts(PartDefinition root) {
        root.AddOrReplaceChild("bottom", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-14.0F, -9.0F, -3.0F, 28.0F, 16.0F, 3.0F),
            PartPose.OffsetAndRotation(0.0F, 3.0F, 1.0F, (float)(Math.PI / 2), 0.0F, 0.0F));
        root.AddOrReplaceChild("back", CubeListBuilder.Create().TexOffs(0, 19).AddBox(-13.0F, -7.0F, -1.0F, 18.0F, 6.0F, 2.0F),
            PartPose.OffsetAndRotation(-15.0F, 4.0F, 4.0F, 0.0F, (float)(Math.PI * 3.0 / 2.0), 0.0F));
        root.AddOrReplaceChild("front", CubeListBuilder.Create().TexOffs(0, 27).AddBox(-8.0F, -7.0F, -1.0F, 16.0F, 6.0F, 2.0F),
            PartPose.OffsetAndRotation(15.0F, 4.0F, 0.0F, 0.0F, (float)(Math.PI / 2), 0.0F));
        root.AddOrReplaceChild("right", CubeListBuilder.Create().TexOffs(0, 35).AddBox(-14.0F, -7.0F, -1.0F, 28.0F, 6.0F, 2.0F),
            PartPose.OffsetAndRotation(0.0F, 4.0F, -9.0F, 0.0F, (float)Math.PI, 0.0F));
        root.AddOrReplaceChild("left", CubeListBuilder.Create().TexOffs(0, 43).AddBox(-14.0F, -7.0F, -1.0F, 28.0F, 6.0F, 2.0F), PartPose.Offset(0.0F, 4.0F, 9.0F));
        root.AddOrReplaceChild("left_paddle", CubeListBuilder.Create().TexOffs(62, 0).AddBox(-1.0F, 0.0F, -5.0F, 2.0F, 2.0F, 18.0F).AddBox(-1.001F, -3.0F, 8.0F, 1.0F, 6.0F, 7.0F),
            PartPose.OffsetAndRotation(3.0F, -5.0F, 9.0F, 0.0F, 0.0F, (float)(Math.PI / 16)));
        root.AddOrReplaceChild("right_paddle", CubeListBuilder.Create().TexOffs(62, 20).AddBox(-1.0F, 0.0F, -5.0F, 2.0F, 2.0F, 18.0F).AddBox(0.001F, -3.0F, 8.0F, 1.0F, 6.0F, 7.0F),
            PartPose.OffsetAndRotation(3.0F, -5.0F, -9.0F, 0.0F, (float)Math.PI, (float)(Math.PI / 16)));
    }

    public static LayerDefinition CreateBoatModel() {
        MeshDefinition mesh = new();
        AddCommonParts(mesh.Root);
        return LayerDefinition.Create(mesh, 128, 64);
    }

    public static LayerDefinition CreateChestBoatModel() {
        MeshDefinition mesh = new();
        AddCommonParts(mesh.Root);
        AddChest(mesh.Root, -5.0F, -9.0F, -6.0F);
        return LayerDefinition.Create(mesh, 128, 128);
    }

    public static LayerDefinition CreateWaterPatch() {
        MeshDefinition mesh = new();
        mesh.Root.AddOrReplaceChild("water_patch", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-14.0F, -9.0F, -3.0F, 28.0F, 16.0F, 3.0F),
            PartPose.OffsetAndRotation(0.0F, -3.0F, 1.0F, (float)(Math.PI / 2), 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 0, 0);
    }
}

/// <summary><c>RaftModel</c>.</summary>
public sealed class RaftModel : AbstractBoatModel {
    public RaftModel(ModelPart root) : base(root) { }

    private static void AddCommonParts(PartDefinition root) {
        root.AddOrReplaceChild("bottom",
            CubeListBuilder.Create().TexOffs(0, 0).AddBox(-14.0F, -11.0F, -4.0F, 28.0F, 20.0F, 4.0F).TexOffs(0, 0).AddBox(-14.0F, -9.0F, -8.0F, 28.0F, 16.0F, 4.0F),
            PartPose.OffsetAndRotation(0.0F, -2.1F, 1.0F, 1.5708F, 0.0F, 0.0F));
        root.AddOrReplaceChild("left_paddle", CubeListBuilder.Create().TexOffs(0, 24).AddBox(-1.0F, 0.0F, -5.0F, 2.0F, 2.0F, 18.0F).AddBox(-1.001F, -3.0F, 8.0F, 1.0F, 6.0F, 7.0F),
            PartPose.OffsetAndRotation(3.0F, -4.0F, 9.0F, 0.0F, 0.0F, (float)(Math.PI / 16)));
        root.AddOrReplaceChild("right_paddle", CubeListBuilder.Create().TexOffs(40, 24).AddBox(-1.0F, 0.0F, -5.0F, 2.0F, 2.0F, 18.0F).AddBox(0.001F, -3.0F, 8.0F, 1.0F, 6.0F, 7.0F),
            PartPose.OffsetAndRotation(3.0F, -4.0F, -9.0F, 0.0F, (float)Math.PI, (float)(Math.PI / 16)));
    }

    public static LayerDefinition CreateRaftModel() {
        MeshDefinition mesh = new();
        AddCommonParts(mesh.Root);
        return LayerDefinition.Create(mesh, 128, 64);
    }

    public static LayerDefinition CreateChestRaftModel() {
        MeshDefinition mesh = new();
        AddCommonParts(mesh.Root);
        AddChest(mesh.Root, -10.1F, -14.1F, -11.1F);
        return LayerDefinition.Create(mesh, 128, 128);
    }
}

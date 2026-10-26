using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>SkeletonModel</c>.</summary>
public class SkeletonModel<S> : HumanoidModel<S> where S : SkeletonRenderState {
    public SkeletonModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateMesh(CubeDeformation.None, 0.0F);
        PartDefinition root = mesh.Root;
        CreateDefaultSkeletonMesh(root);
        return LayerDefinition.Create(mesh, 64, 32);
    }

    protected static void CreateDefaultSkeletonMesh(PartDefinition root) {
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(40, 16).AddBox(-1.0F, -2.0F, -1.0F, 2.0F, 12.0F, 2.0F), PartPose.Offset(-5.0F, 2.0F, 0.0F));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(40, 16).Mirror().AddBox(-1.0F, -2.0F, -1.0F, 2.0F, 12.0F, 2.0F), PartPose.Offset(5.0F, 2.0F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 12.0F, 2.0F), PartPose.Offset(-2.0F, 12.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 16).Mirror().AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 12.0F, 2.0F), PartPose.Offset(2.0F, 12.0F, 0.0F));
    }

    public static LayerDefinition CreateSingleModelDualBodyLayer() {
        MeshDefinition meshdefinition = new();
        PartDefinition root = meshdefinition.Root;
        root.AddOrReplaceChild("body",
            CubeListBuilder.Create()
                .TexOffs(16, 16)
                .AddBox(-4.0F, 0.0F, -2.0F, 8.0F, 12.0F, 4.0F)
                .TexOffs(28, 0)
                .AddBox(-4.0F, 10.0F, -2.0F, 8.0F, 1.0F, 4.0F)
                .TexOffs(16, 48)
                .AddBox(-4.0F, 0.0F, -2.0F, 8.0F, 12.0F, 4.0F, new CubeDeformation(0.025F)),
            PartPose.Offset(0.0F, 0.0F, 0.0F));
        root.AddOrReplaceChild("head",
                CubeListBuilder.Create()
                    .TexOffs(0, 0)
                    .AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F)
                    .TexOffs(0, 32)
                    .AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, new CubeDeformation(0.2F)),
                PartPose.Offset(0.0F, 0.0F, 0.0F))
            .AddOrReplaceChild("hat", CubeListBuilder.Create(), PartPose.Zero);
        root.AddOrReplaceChild("right_arm",
            CubeListBuilder.Create()
                .TexOffs(40, 16)
                .AddBox(-1.0F, -2.0F, -1.0F, 2.0F, 12.0F, 2.0F)
                .TexOffs(42, 33)
                .AddBox(-1.55F, -2.025F, -1.5F, 3.0F, 12.0F, 3.0F),
            PartPose.Offset(-5.5F, 2.0F, 0.0F));
        root.AddOrReplaceChild("left_arm",
            CubeListBuilder.Create()
                .TexOffs(56, 16)
                .AddBox(-1.0F, -2.0F, -1.0F, 2.0F, 12.0F, 2.0F)
                .TexOffs(40, 48)
                .AddBox(-1.45F, -2.025F, -1.5F, 3.0F, 12.0F, 3.0F),
            PartPose.Offset(5.5F, 2.0F, 0.0F));
        root.AddOrReplaceChild("right_leg",
            CubeListBuilder.Create().TexOffs(0, 16).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 12.0F, 2.0F).TexOffs(0, 49).AddBox(-1.5F, -0.0F, -1.5F, 3.0F, 12.0F, 3.0F),
            PartPose.Offset(-2.0F, 12.0F, 0.0F));
        root.AddOrReplaceChild("left_leg",
            CubeListBuilder.Create().TexOffs(0, 16).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 12.0F, 2.0F).TexOffs(4, 49).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 12.0F, 3.0F),
            PartPose.Offset(2.0F, 12.0F, 0.0F));
        return LayerDefinition.Create(meshdefinition, 64, 64);
    }

    public override void SetupAnim(S state) {
        base.SetupAnim(state);
        if (state.IsAggressive && !state.IsHoldingBow) {
            float attackTime = state.AttackTime;
            float attack2 = Mth.Sin(attackTime * (float)Math.PI);
            float attack = Mth.Sin((1.0F - (1.0F - attackTime) * (1.0F - attackTime)) * (float)Math.PI);
            RightArm.ZRot = 0.0F;
            LeftArm.ZRot = 0.0F;
            RightArm.YRot = -(0.1F - attack2 * 0.6F);
            LeftArm.YRot = 0.1F - attack2 * 0.6F;
            RightArm.XRot = (float)(-Math.PI / 2);
            LeftArm.XRot = (float)(-Math.PI / 2);
            RightArm.XRot -= attack2 * 1.2F - attack * 0.4F;
            LeftArm.XRot -= attack2 * 1.2F - attack * 0.4F;
            AnimationUtils.BobArms(RightArm, LeftArm, state.AgeInTicks);
        }
    }

    public override void TranslateToHand(S state, HumanoidArm arm, PoseStack pose) {
        Root.TranslateAndRotate(pose);
        float offset = arm == HumanoidArm.Right ? 1.0F : -1.0F;
        ModelPart part = GetArm(arm);
        part.X += offset;
        part.TranslateAndRotate(pose);
        part.X -= offset;
    }
}

using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ZombieVillagerModel</c>.</summary>
public class ZombieVillagerModel<S> : HumanoidModel<S>, IVillagerLikeModel<S> where S : ZombieVillagerRenderState {
    public ZombieVillagerModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateMesh(CubeDeformation.None, 0.0F);
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head",
            CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -10.0F, -4.0F, 8.0F, 10.0F, 8.0F).TexOffs(24, 0).AddBox(-1.0F, -3.0F, -6.0F, 2.0F, 4.0F, 2.0F),
            PartPose.Zero);
        PartDefinition hat = head.AddOrReplaceChild("hat",
            CubeListBuilder.Create().TexOffs(32, 0).AddBox(-4.0F, -10.0F, -4.0F, 8.0F, 10.0F, 8.0F, new CubeDeformation(0.5F)), PartPose.Zero);
        hat.AddOrReplaceChild("hat_rim", CubeListBuilder.Create().TexOffs(30, 47).AddBox(-8.0F, -8.0F, -6.0F, 16.0F, 16.0F, 1.0F),
            PartPose.Rotation((float)(-Math.PI / 2), 0.0F, 0.0F));
        root.AddOrReplaceChild("body",
            CubeListBuilder.Create()
                .TexOffs(16, 20)
                .AddBox(-4.0F, 0.0F, -3.0F, 8.0F, 12.0F, 6.0F)
                .TexOffs(0, 38)
                .AddBox(-4.0F, 0.0F, -3.0F, 8.0F, 20.0F, 6.0F, new CubeDeformation(0.05F)),
            PartPose.Zero);
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(44, 22).AddBox(-3.0F, -2.0F, -2.0F, 4.0F, 12.0F, 4.0F), PartPose.Offset(-5.0F, 2.0F, 0.0F));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(44, 22).Mirror().AddBox(-1.0F, -2.0F, -2.0F, 4.0F, 12.0F, 4.0F), PartPose.Offset(5.0F, 2.0F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 22).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F), PartPose.Offset(-2.0F, 12.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 22).Mirror().AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F), PartPose.Offset(2.0F, 12.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public static LayerDefinition CreateNoHatLayer() => CreateBodyLayer().Apply(mesh => {
        mesh.Root.ClearChild("head").ClearRecursively();
        return mesh;
    });

    public static ArmorModelSet<LayerDefinition> CreateArmorLayerSet(CubeDeformation innerDeformation, CubeDeformation outerDeformation) =>
        CreateArmorMeshSet(CreateBaseArmorMesh, AdultArmorPartsPerSlot, innerDeformation, outerDeformation).Map(mesh => LayerDefinition.Create(mesh, 64, 32));

    private static MeshDefinition CreateBaseArmorMesh(CubeDeformation g) {
        MeshDefinition mesh = CreateMesh(g, 0.0F);
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -10.0F, -4.0F, 8.0F, 8.0F, 8.0F, g), PartPose.Zero);
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(16, 16).AddBox(-4.0F, 0.0F, -2.0F, 8.0F, 12.0F, 4.0F, g.Extend(0.1F)), PartPose.Zero);
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, g.Extend(0.1F)),
            PartPose.Offset(-2.0F, 12.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 16).Mirror().AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, g.Extend(0.1F)),
            PartPose.Offset(2.0F, 12.0F, 0.0F));
        head.GetChild("hat").AddOrReplaceChild("hat_rim", CubeListBuilder.Create(), PartPose.Zero);
        return mesh;
    }

    public override void SetupAnim(S state) {
        base.SetupAnim(state);
        AnimationUtils.AnimateZombieArms(LeftArm, RightArm, state.IsAggressive, state);
    }

    public void TranslateToArms(S state, PoseStack pose) => TranslateToHand(state, HumanoidArm.Right, pose);
}

/// <summary><c>BabyZombieVillagerModel</c>.</summary>
public class BabyZombieVillagerModel<S> : ZombieVillagerModel<S> where S : ZombieVillagerRenderState {
    public BabyZombieVillagerModel(ModelPart root) : base(root) { }

    public new static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body",
            CubeListBuilder.Create()
                .TexOffs(0, 15)
                .AddBox(-2.0F, -2.75F, -1.5F, 4.0F, 5.0F, 3.0F)
                .TexOffs(16, 22)
                .AddBox(-2.0F, -2.75F, -1.5F, 4.0F, 6.0F, 3.0F, new CubeDeformation(0.1F)),
            PartPose.Offset(0.0F, 18.75F, 0.0F));
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -8.0F, -3.5F, 8.0F, 8.0F, 7.0F),
            PartPose.Offset(0.0F, 16.0F, 0.0F));
        head.AddOrReplaceChild("hat", CubeListBuilder.Create().TexOffs(0, 31).AddBox(-4.0F, -4.0F, -3.5F, 8.0F, 8.0F, 7.0F, new CubeDeformation(0.3F)),
            PartPose.Offset(0.0F, -4.0F, 0.0F));
        head.AddOrReplaceChild("hat_rim", CubeListBuilder.Create().TexOffs(0, 46).AddBox(-7.0F, -0.5F, -6.0F, 14.0F, 1.0F, 12.0F), PartPose.Offset(0.0F, -4.5F, 0.0F));
        head.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(23, 0).AddBox(-1.0F, -1.0F, -0.5F, 2.0F, 2.0F, 1.0F), PartPose.Offset(0.0F, -1.0F, -4.0F));
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(24, 15).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 5.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-3.0F, 15.5F, 0.0F));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(16, 15).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 5.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(3.0F, 15.5F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(8, 23).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 3.0F, 2.0F), PartPose.Offset(-1.0F, 21.5F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 23).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 3.0F, 2.0F), PartPose.Offset(1.0F, 21.5F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public new static LayerDefinition CreateNoHatLayer() => CreateBodyLayer().Apply(mesh => {
        mesh.Root.ClearChild("head").ClearRecursively();
        return mesh;
    });
}

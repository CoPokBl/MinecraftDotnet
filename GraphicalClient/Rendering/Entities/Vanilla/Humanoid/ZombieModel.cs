namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>AbstractZombieModel</c>.</summary>
public abstract class AbstractZombieModel<S> : HumanoidModel<S> where S : ZombieRenderState {
    protected AbstractZombieModel(ModelPart root) : base(root) { }

    public override void SetupAnim(S state) {
        base.SetupAnim(state);
        AnimationUtils.AnimateZombieArms(LeftArm, RightArm, state.IsAggressive, state);
    }
}

/// <summary><c>ZombieModel</c>.</summary>
public class ZombieModel<S> : AbstractZombieModel<S> where S : ZombieRenderState {
    public ZombieModel(ModelPart root) : base(root) { }
}

/// <summary><c>BabyZombieModel</c>.</summary>
public class BabyZombieModel<S> : ZombieModel<S> where S : ZombieRenderState {
    public BabyZombieModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(16, 16).AddBox(-2.0F, -2.5F, -1.0F, 4.0F, 5.0F, 2.0F, g), PartPose.Offset(0.0F, 17.5F, 0.0F));
        PartDefinition head = root.AddOrReplaceChild("head",
            CubeListBuilder.Create()
                .TexOffs(3, 3)
                .AddBox(-3.0F, -6.25F, -3.0F, 6.0F, 6.0F, 6.0F, new CubeDeformation(0.0F))
                .TexOffs(35, 3)
                .AddBox(-3.0F, -6.15F, -3.0F, 6.0F, 6.0F, 6.0F, new CubeDeformation(0.25F)),
            PartPose.Offset(0.0F, 15.25F, 0.0F));
        head.AddOrReplaceChild("hat", CubeListBuilder.Create(), PartPose.Zero);
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(36, 16).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 5.0F, 2.0F, g), PartPose.Offset(-3.0F, 15.5F, 0.0F));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(28, 16).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 5.0F, 2.0F, g), PartPose.Offset(3.0F, 15.5F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(8, 16).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 4.0F, 2.0F, g), PartPose.Offset(-1.0F, 20.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 4.0F, 2.0F, g), PartPose.Offset(1.0F, 20.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}

/// <summary><c>GiantZombieModel</c>.</summary>
public sealed class GiantZombieModel : AbstractZombieModel<ZombieRenderState> {
    public GiantZombieModel(ModelPart root) : base(root) { }
}

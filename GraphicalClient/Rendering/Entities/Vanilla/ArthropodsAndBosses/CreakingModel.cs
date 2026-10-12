namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class CreakingModel : EntityModel<CreakingRenderState> {
    private readonly ModelPart _head;
    private readonly KeyframeAnimation _walkAnimation, _attackAnimation, _invulnerableAnimation, _deathAnimation;

    public CreakingModel(ModelPart roots) : base(roots) {
        ModelPart root = roots.GetChild("root");
        ModelPart upperBody = root.GetChild("upper_body");
        _head = upperBody.GetChild("head");
        _walkAnimation = CreakingAnimation.CreakingWalk.Bake(root);
        _attackAnimation = CreakingAnimation.CreakingAttack.Bake(root);
        _invulnerableAnimation = CreakingAnimation.CreakingInvulnerable.Bake(root);
        _deathAnimation = CreakingAnimation.CreakingDeath.Bake(root);
    }

    private static MeshDefinition CreateMesh() {
        MeshDefinition meshDefinition = new();
        PartDefinition partDefinition = meshDefinition.Root;
        PartDefinition root = partDefinition.AddOrReplaceChild("root", CubeListBuilder.Create(), PartPose.Offset(0.0F, 24.0F, 0.0F));
        PartDefinition upperBody = root.AddOrReplaceChild("upper_body", CubeListBuilder.Create(), PartPose.Offset(-1.0F, -19.0F, 0.0F));
        upperBody.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-3.0F, -10.0F, -3.0F, 6.0F, 10.0F, 6.0F)
                .TexOffs(28, 31).AddBox(-3.0F, -13.0F, -3.0F, 6.0F, 3.0F, 6.0F)
                .TexOffs(12, 40).AddBox(3.0F, -13.0F, 0.0F, 9.0F, 14.0F, 0.0F)
                .TexOffs(34, 12).AddBox(-12.0F, -14.0F, 0.0F, 9.0F, 14.0F, 0.0F),
            PartPose.Offset(-3.0F, -11.0F, 0.0F));
        upperBody.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 16).AddBox(0.0F, -3.0F, -3.0F, 6.0F, 13.0F, 5.0F)
                .TexOffs(24, 0).AddBox(-6.0F, -4.0F, -3.0F, 6.0F, 7.0F, 5.0F),
            PartPose.Offset(0.0F, -7.0F, 1.0F));
        upperBody.AddOrReplaceChild("right_arm", CubeListBuilder.Create()
                .TexOffs(22, 13).AddBox(-2.0F, -1.5F, -1.5F, 3.0F, 21.0F, 3.0F)
                .TexOffs(46, 0).AddBox(-2.0F, 19.5F, -1.5F, 3.0F, 4.0F, 3.0F),
            PartPose.Offset(-7.0F, -9.5F, 1.5F));
        upperBody.AddOrReplaceChild("left_arm", CubeListBuilder.Create()
                .TexOffs(30, 40).AddBox(0.0F, -1.0F, -1.5F, 3.0F, 16.0F, 3.0F)
                .TexOffs(52, 12).AddBox(0.0F, -5.0F, -1.5F, 3.0F, 4.0F, 3.0F)
                .TexOffs(52, 19).AddBox(0.0F, 15.0F, -1.5F, 3.0F, 4.0F, 3.0F),
            PartPose.Offset(6.0F, -9.0F, 0.5F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create()
                .TexOffs(42, 40).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 16.0F, 3.0F)
                .TexOffs(45, 55).AddBox(-1.5F, 15.7F, -4.5F, 5.0F, 0.0F, 9.0F),
            PartPose.Offset(1.5F, -16.0F, 0.5F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create()
                .TexOffs(0, 34).AddBox(-3.0F, -1.5F, -1.5F, 3.0F, 19.0F, 3.0F)
                .TexOffs(45, 46).AddBox(-5.0F, 17.2F, -4.5F, 5.0F, 0.0F, 9.0F)
                .TexOffs(12, 34).AddBox(-3.0F, -4.5F, -1.5F, 3.0F, 3.0F, 3.0F),
            PartPose.Offset(-1.0F, -17.5F, 0.5F));
        return meshDefinition;
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateMesh();
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public static LayerDefinition CreateEyesLayer() {
        MeshDefinition mesh = CreateMesh();
        mesh.Root.RetainExactParts(new HashSet<string> { "head" });
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(CreakingRenderState state) {
        base.SetupAnim(state);
        _head.XRot = state.XRot * (float)(Math.PI / 180.0);
        _head.YRot = state.YRot * (float)(Math.PI / 180.0);
        if (state.CanMove) {
            _walkAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, 1.0F, 1.0F);
        }
        _attackAnimation.Apply(state.AttackAnimationState, state.AgeInTicks);
        _invulnerableAnimation.Apply(state.InvulnerabilityAnimationState, state.AgeInTicks);
        _deathAnimation.Apply(state.DeathAnimationState, state.AgeInTicks);
    }
}

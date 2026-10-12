namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BreezeModel : EntityModel<BreezeRenderState> {
    private const float WindTopSpeed = 0.6F;
    private const float WindMiddleSpeed = 0.8F;
    private const float WindBottomSpeed = 1.0F;
    private readonly ModelPart _head, _eyes, _wind, _windTop, _windMid, _windBottom, _rods;
    private readonly KeyframeAnimation _idleAnimation, _shootAnimation, _slideAnimation, _slideBackAnimation, _inhaleAnimation, _jumpAnimation;

    public BreezeModel(ModelPart root) : base(root) {
        _wind = root.GetChild("wind_body");
        _windBottom = _wind.GetChild("wind_bottom");
        _windMid = _windBottom.GetChild("wind_mid");
        _windTop = _windMid.GetChild("wind_top");
        _head = root.GetChild("body").GetChild("head");
        _eyes = _head.GetChild("eyes");
        _rods = root.GetChild("body").GetChild("rods");
        _idleAnimation = BreezeAnimation.Idle.Bake(root);
        _shootAnimation = BreezeAnimation.Shoot.Bake(root);
        _slideAnimation = BreezeAnimation.Slide.Bake(root);
        _slideBackAnimation = BreezeAnimation.SlideBack.Bake(root);
        _inhaleAnimation = BreezeAnimation.Inhale.Bake(root);
        _jumpAnimation = BreezeAnimation.Jump.Bake(root);
    }

    /// <summary><c>entityTranslucent</c>.</summary>
    public override bool Translucent => true;

    private static MeshDefinition CreateBaseMesh() {
        MeshDefinition meshdefinition = new();
        PartDefinition partdefinition = meshdefinition.Root;
        PartDefinition body = partdefinition.AddOrReplaceChild("body", CubeListBuilder.Create(), PartPose.Offset(0.0F, 0.0F, 0.0F));
        PartDefinition rods = body.AddOrReplaceChild("rods", CubeListBuilder.Create(), PartPose.Offset(0.0F, 8.0F, 0.0F));
        rods.AddOrReplaceChild("rod_1", CubeListBuilder.Create().TexOffs(0, 17).AddBox(-1.0F, 0.0F, -3.0F, 2.0F, 8.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(2.5981F, -3.0F, 1.5F, -2.7489F, -1.0472F, 3.1416F));
        rods.AddOrReplaceChild("rod_2", CubeListBuilder.Create().TexOffs(0, 17).AddBox(-1.0F, 0.0F, -3.0F, 2.0F, 8.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(-2.5981F, -3.0F, 1.5F, -2.7489F, 1.0472F, 3.1416F));
        rods.AddOrReplaceChild("rod_3", CubeListBuilder.Create().TexOffs(0, 17).AddBox(-1.0F, 0.0F, -3.0F, 2.0F, 8.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, -3.0F, -3.0F, 0.3927F, 0.0F, 0.0F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(4, 24).AddBox(-5.0F, -5.0F, -4.2F, 10.0F, 3.0F, 4.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 4.0F, 0.0F));
        head.AddOrReplaceChild("eyes", CubeListBuilder.Create()
                .TexOffs(4, 24).AddBox(-5.0F, -5.0F, -4.2F, 10.0F, 3.0F, 4.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 0.0F, 0.0F));
        PartDefinition windBody = partdefinition.AddOrReplaceChild("wind_body", CubeListBuilder.Create(), PartPose.Offset(0.0F, 0.0F, 0.0F));
        PartDefinition windBottom = windBody.AddOrReplaceChild("wind_bottom", CubeListBuilder.Create().TexOffs(1, 83).AddBox(-2.5F, -7.0F, -2.5F, 5.0F, 7.0F, 5.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 24.0F, 0.0F));
        PartDefinition windMid = windBottom.AddOrReplaceChild("wind_mid", CubeListBuilder.Create()
                .TexOffs(74, 28).AddBox(-6.0F, -6.0F, -6.0F, 12.0F, 6.0F, 12.0F, new CubeDeformation(0.0F))
                .TexOffs(78, 32).AddBox(-4.0F, -6.0F, -4.0F, 8.0F, 6.0F, 8.0F, new CubeDeformation(0.0F))
                .TexOffs(49, 71).AddBox(-2.5F, -6.0F, -2.5F, 5.0F, 6.0F, 5.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -7.0F, 0.0F));
        windMid.AddOrReplaceChild("wind_top", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-9.0F, -8.0F, -9.0F, 18.0F, 8.0F, 18.0F, new CubeDeformation(0.0F))
                .TexOffs(6, 6).AddBox(-6.0F, -8.0F, -6.0F, 12.0F, 8.0F, 12.0F, new CubeDeformation(0.0F))
                .TexOffs(105, 57).AddBox(-2.5F, -8.0F, -2.5F, 5.0F, 8.0F, 5.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -6.0F, 0.0F));
        return meshdefinition;
    }

    /// <summary>
    /// <c>PartDefinition.retainPartsAndChildren</c>: every part not named is emptied of its cubes but kept,
    /// so the tree has the same shape in each layer baked from the mesh.
    /// </summary>
    private static void RetainPartsAndChildren(PartDefinition part, IReadOnlySet<string> parts) {
        foreach ((string name, PartDefinition child) in part.Children.ToList()) {
            if (!parts.Contains(name)) {
                RetainPartsAndChildren(part.AddOrReplaceChild(name, CubeListBuilder.Create(), child.Pose), parts);
            }
        }
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateBaseMesh();
        RetainPartsAndChildren(mesh.Root, new HashSet<string> { "head", "rods" });
        return LayerDefinition.Create(mesh, 32, 32);
    }

    public static LayerDefinition CreateWindLayer() {
        MeshDefinition mesh = CreateBaseMesh();
        RetainPartsAndChildren(mesh.Root, new HashSet<string> { "wind_body" });
        return LayerDefinition.Create(mesh, 128, 128);
    }

    public static LayerDefinition CreateEyesLayer() {
        MeshDefinition mesh = CreateBaseMesh();
        RetainPartsAndChildren(mesh.Root, new HashSet<string> { "eyes" });
        return LayerDefinition.Create(mesh, 32, 32);
    }

    public override void SetupAnim(BreezeRenderState state) {
        base.SetupAnim(state);
        _idleAnimation.Apply(state.Idle, state.AgeInTicks);
        _shootAnimation.Apply(state.Shoot, state.AgeInTicks);
        _slideAnimation.Apply(state.Slide, state.AgeInTicks);
        _slideBackAnimation.Apply(state.SlideBack, state.AgeInTicks);
        _inhaleAnimation.Apply(state.Inhale, state.AgeInTicks);
        _jumpAnimation.Apply(state.LongJump, state.AgeInTicks);
    }

    public ModelPart Head => _head;
    public ModelPart Eyes => _eyes;
    public ModelPart Rods => _rods;
    public ModelPart Wind => _wind;
}

using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>AllayModel</c>: its root is the mesh's <c>root</c> part, not the mesh root.</summary>
public sealed class AllayModel : EntityModel<AllayRenderState>, IArmedModel<AllayRenderState> {
    private const float FlyingAnimationXRot = (float)(Math.PI / 4);
    private const float MaxHandHoldingItemXRotRad = -1.134464F;
    private const float MinHandHoldingItemXRotRad = (float)(-Math.PI / 3);

    private readonly ModelPart _head, _body, _rightArm, _leftArm, _rightWing, _leftWing;

    public AllayModel(ModelPart root) : base(root.GetChild("root")) {
        _head = Root.GetChild("head");
        _body = Root.GetChild("body");
        _rightArm = _body.GetChild("right_arm");
        _leftArm = _body.GetChild("left_arm");
        _rightWing = _body.GetChild("right_wing");
        _leftWing = _body.GetChild("left_wing");
    }

    public override bool Translucent => true;

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition meshdefinition = new();
        PartDefinition partdefinition = meshdefinition.Root;
        PartDefinition root = partdefinition.AddOrReplaceChild("root", CubeListBuilder.Create(), PartPose.Offset(0.0F, 23.5F, 0.0F));
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.5F, -5.0F, -2.5F, 5.0F, 5.0F, 5.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -3.99F, 0.0F));
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 10).AddBox(-1.5F, 0.0F, -1.0F, 3.0F, 4.0F, 2.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 16).AddBox(-1.5F, 0.0F, -1.0F, 3.0F, 5.0F, 2.0F, new CubeDeformation(-0.2F)),
            PartPose.Offset(0.0F, -4.0F, 0.0F));
        body.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(23, 0).AddBox(-0.75F, -0.5F, -1.0F, 1.0F, 4.0F, 2.0F, new CubeDeformation(-0.01F)),
            PartPose.Offset(-1.75F, 0.5F, 0.0F));
        body.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(23, 6).AddBox(-0.25F, -0.5F, -1.0F, 1.0F, 4.0F, 2.0F, new CubeDeformation(-0.01F)),
            PartPose.Offset(1.75F, 0.5F, 0.0F));
        body.AddOrReplaceChild("right_wing", CubeListBuilder.Create().TexOffs(16, 14).AddBox(0.0F, 1.0F, 0.0F, 0.0F, 5.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-0.5F, 0.0F, 0.6F));
        body.AddOrReplaceChild("left_wing", CubeListBuilder.Create().TexOffs(16, 14).AddBox(0.0F, 1.0F, 0.0F, 0.0F, 5.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.5F, 0.0F, 0.6F));
        return LayerDefinition.Create(meshdefinition, 32, 32);
    }

    public override void SetupAnim(AllayRenderState state) {
        base.SetupAnim(state);
        float animationSpeed = state.WalkAnimationSpeed;
        float animationPos = state.WalkAnimationPos;
        float flapSpeed = state.AgeInTicks * 20.0F * (MathF.PI / 180.0F) + animationPos;
        float flapAmount = Mth.Cos(flapSpeed) * MathF.PI * 0.15F + animationSpeed;
        float idleBobSpeed = state.AgeInTicks * 9.0F * (MathF.PI / 180.0F);
        float flyingFactor = Math.Min(animationSpeed / 0.3F, 1.0F);
        float idleBobFactor = 1.0F - flyingFactor;
        float holdingItemFactor = state.HoldingAnimationProgress;
        if (state.IsDancing) {
            float danceSpeed = state.AgeInTicks * 8.0F * (MathF.PI / 180.0F) + animationSpeed;
            float danceFrequency = Mth.Cos(danceSpeed) * 16.0F * (MathF.PI / 180.0F);
            float spinningRotation = state.SpinningProgress;
            float headTiltZ = Mth.Cos(danceSpeed) * 14.0F * (MathF.PI / 180.0F);
            float headTiltY = Mth.Cos(danceSpeed) * 30.0F * (MathF.PI / 180.0F);
            Root.YRot = state.IsSpinning ? (float)(Math.PI * 4) * spinningRotation : Root.YRot;
            Root.ZRot = danceFrequency * (1.0F - spinningRotation);
            _head.YRot = headTiltY * (1.0F - spinningRotation);
            _head.ZRot = headTiltZ * (1.0F - spinningRotation);
        }
        else {
            _head.XRot = state.XRot * (MathF.PI / 180.0F);
            _head.YRot = state.YRot * (MathF.PI / 180.0F);
        }

        _rightWing.XRot = 0.43633232F * (1.0F - flyingFactor);
        _rightWing.YRot = (float)(-Math.PI / 4) + flapAmount;
        _leftWing.XRot = 0.43633232F * (1.0F - flyingFactor);
        _leftWing.YRot = (float)(Math.PI / 4) - flapAmount;
        _body.XRot = flyingFactor * FlyingAnimationXRot;
        float armFlyingRotX = holdingItemFactor * Mth.Lerp(flyingFactor, MinHandHoldingItemXRotRad, MaxHandHoldingItemXRotRad);
        Root.Y = Root.Y + (float)Math.Cos(idleBobSpeed) * 0.25F * idleBobFactor;
        _rightArm.XRot = armFlyingRotX;
        _leftArm.XRot = armFlyingRotX;
        float armIdleBobFactor = idleBobFactor * (1.0F - holdingItemFactor);
        float armIdleBobAmount = 0.43633232F - Mth.Cos(idleBobSpeed + (float)(Math.PI * 3.0 / 2.0)) * MathF.PI * 0.075F * armIdleBobFactor;
        _leftArm.ZRot = -armIdleBobAmount;
        _rightArm.ZRot = armIdleBobAmount;
        _rightArm.YRot = 0.27925268F * holdingItemFactor;
        _leftArm.YRot = -0.27925268F * holdingItemFactor;
    }

    public void TranslateToHand(AllayRenderState state, HumanoidArm arm, PoseStack pose) {
        Root.TranslateAndRotate(pose);
        _body.TranslateAndRotate(pose);
        pose.Translate(0.0F, 0.0625F, 0.1875F);
        pose.RotateX(_rightArm.XRot);
        pose.Scale(0.7F, 0.7F, 0.7F);
        pose.Translate(0.0625F, 0.0F, 0.0F);
    }
}

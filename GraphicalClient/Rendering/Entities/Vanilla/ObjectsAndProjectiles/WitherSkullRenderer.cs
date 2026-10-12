using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>WitherSkullRenderState</c>.</summary>
public class WitherSkullRenderState : EntityRenderState {
    public bool IsDangerous;
    public readonly SkullModelBase.State ModelState = new();
}

/// <summary><c>WitherSkullRenderer</c>.</summary>
public sealed class WitherSkullRenderer : EntityRenderer<WitherSkullRenderState> {
    private const string WitherInvulnerableLocation = "minecraft:textures/entity/wither/wither_invulnerable.png";
    private const string WitherLocation = "minecraft:textures/entity/wither/wither.png";

    private readonly SkullModel _model = new(CreateSkullLayer().BakeRoot());

    public static LayerDefinition CreateSkullLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 35).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => ThrownItemRenderer.HurtingProjectileShouldRenderAtSqrDistance(entity, distanceSqr);

    public override void Submit(WitherSkullRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        pose.Scale(-1.0F, -1.0F, 1.0F);
        _model.SetupAnim(state.ModelState);
        _model.RenderToBuffer(pose, _model.Translucent ? context.TranslucentBatch : context.Batch, new ModelDrawState(context.Texture(GetTextureLocation(state)), state));
        pose.Pop();
    }

    private static string GetTextureLocation(WitherSkullRenderState state) => state.IsDangerous ? WitherInvulnerableLocation : WitherLocation;

    public override void ExtractRenderState(ClientEntity entity, WitherSkullRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // getBlockLightLevel.
        state.BlockLight = 15;
        state.IsDangerous = entity.Get(EntityDataFields.WitherSkull.Dangerous);
        state.ModelState.YRot = GetYRot(entity, partialTick);
        state.ModelState.XRot = GetXRot(entity, partialTick);
    }
}

/// <summary><c>SkullModelBase</c>, a plain <c>Model</c> in vanilla whose state is not an entity's.</summary>
public abstract class SkullModelBase : EntityModel<SkullModelBase.State> {
    protected SkullModelBase(ModelPart root) : base(root) { }

    public override bool Translucent => true;

    /// <summary><c>SkullModelBase.State</c>.</summary>
    public class State : EntityRenderState {
        public float AnimationPos;
        public float YRot;
        public float XRot;
    }
}

/// <summary><c>SkullModel</c>.</summary>
public class SkullModel : SkullModelBase {
    protected readonly ModelPart Head;

    public SkullModel(ModelPart root) : base(root) {
        Head = root.GetChild("head");
    }

    public override void SetupAnim(State state) {
        base.SetupAnim(state);
        Head.YRot = state.YRot * (float)(Math.PI / 180.0);
        Head.XRot = state.XRot * (float)(Math.PI / 180.0);
    }
}

using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ArrowRenderState</c>.</summary>
public class ArrowRenderState : EntityRenderState {
    public float XRot;
    public float YRot;
    public float Shake;
}

/// <summary><c>ArrowRenderer</c>. Its model's <c>entityCutoutCull</c> type goes to the opaque batch.</summary>
public abstract class ArrowRenderer<S> : EntityRenderer<S> where S : ArrowRenderState, new() {
    private readonly ArrowModel _model = new(ArrowModel.CreateBodyLayer().BakeRoot());

    /// <summary><c>AbstractArrow.shouldRenderAtSqrDistance</c>: ten times the box's side.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => WithinViewDistance(entity, distanceSqr, 10.0);

    /// <summary><c>AbstractArrow.shakeTime</c>, which the client starts itself when it hears the arrow land.</summary>
    private sealed class ClientArrow {
        public int ShakeTime;
        public bool FirstTick = true;
        public readonly LocalEntityData<bool> InGround = new(EntityDataFields.AbstractArrow.InGround, false);
    }

    /// <summary><c>onSyncedDataUpdated</c>'s shake on landing, then <c>tick</c>'s count down.</summary>
    public override void Tick(ClientEntity entity) {
        ClientArrow arrow = (ClientArrow)(entity.RendererData ??= new ClientArrow());
        bool inGround = arrow.InGround.Sync(entity);
        if (!arrow.FirstTick && arrow.ShakeTime <= 0 && arrow.InGround.Arrived && inGround) {
            arrow.ShakeTime = 7;
        }
        arrow.FirstTick = false;
        if (arrow.ShakeTime > 0) {
            arrow.ShakeTime--;
        }
    }

    public override void Submit(S state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        pose.RotateYDegrees(state.YRot - 90.0F);
        pose.RotateZDegrees(state.XRot);
        _model.SetupAnim(state);
        _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(context.Texture(GetTextureLocation(state)), state));
        pose.Pop();
    }

    protected abstract string GetTextureLocation(S state);

    public override void ExtractRenderState(ClientEntity entity, S state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.XRot = GetXRot(entity, partialTick);
        state.YRot = GetYRot(entity, partialTick);
        state.Shake = (entity.RendererData is ClientArrow arrow ? arrow.ShakeTime : 0) - partialTick;
    }
}

/// <summary><c>SpectralArrowRenderer</c>.</summary>
public sealed class SpectralArrowRenderer : ArrowRenderer<ArrowRenderState> {
    private const string SpectralArrowLocation = "minecraft:textures/entity/projectiles/arrow_spectral.png";

    protected override string GetTextureLocation(ArrowRenderState state) => SpectralArrowLocation;
}

/// <summary><c>TippableArrowRenderState</c>.</summary>
public class TippableArrowRenderState : ArrowRenderState {
    public bool IsTipped;
}

/// <summary><c>TippableArrowRenderer</c>.</summary>
public sealed class TippableArrowRenderer : ArrowRenderer<TippableArrowRenderState> {
    private const string NormalArrowLocation = "minecraft:textures/entity/projectiles/arrow.png";
    private const string TippedArrowLocation = "minecraft:textures/entity/projectiles/arrow_tipped.png";

    protected override string GetTextureLocation(TippableArrowRenderState state) => state.IsTipped ? TippedArrowLocation : NormalArrowLocation;

    public override void ExtractRenderState(ClientEntity entity, TippableArrowRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsTipped = entity.Get(EntityDataFields.Arrow.IdEffectColor, -1) > 0;
    }
}

/// <summary><c>ArrowModel</c>.</summary>
public sealed class ArrowModel : EntityModel<ArrowRenderState> {
    public ArrowModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild(
            "back",
            CubeListBuilder.Create().TexOffs(0, 0).AddBox(0.0F, -2.5F, -2.5F, 0.0F, 5.0F, 5.0F),
            PartPose.OffsetAndRotation(-11.0F, 0.0F, 0.0F, (float)(Math.PI / 4), 0.0F, 0.0F).WithScale(0.8F));
        CubeListBuilder cross = CubeListBuilder.Create().TexOffs(0, 0).AddBox(-12.0F, -2.0F, 0.0F, 16.0F, 4.0F, 0.0F, CubeDeformation.None, 1.0F, 0.8F);
        root.AddOrReplaceChild("cross_1", cross, PartPose.Rotation((float)(Math.PI / 4), 0.0F, 0.0F));
        root.AddOrReplaceChild("cross_2", cross, PartPose.Rotation((float)(Math.PI * 3.0 / 4.0), 0.0F, 0.0F));
        return LayerDefinition.Create(mesh.Transformed(pose => pose.Scaled(0.9F)), 32, 32);
    }

    public override void SetupAnim(ArrowRenderState state) {
        base.SetupAnim(state);
        if (state.Shake > 0.0F) {
            float pow = -Mth.Sin(state.Shake * 3.0F) * state.Shake;
            Root.ZRot += pow * (float)(Math.PI / 180.0);
        }
    }
}

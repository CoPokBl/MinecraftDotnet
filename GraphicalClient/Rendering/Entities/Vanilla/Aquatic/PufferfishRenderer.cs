using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class PufferfishRenderState : LivingEntityRenderState {
    public int PuffState;
}

/// <summary>The fin flap the three puffer sizes' <c>setupAnim</c>s share, each over its own pair of fins.</summary>
public abstract class PufferfishModel(ModelPart root, string leftFin, string rightFin) : EntityModel<PufferfishRenderState>(root) {
    private readonly ModelPart _leftFin = root.GetChild(leftFin), _rightFin = root.GetChild(rightFin);

    public override void SetupAnim(PufferfishRenderState state) {
        base.SetupAnim(state);
        _rightFin.ZRot = -0.2F + 0.4F * Mth.Sin(state.AgeInTicks * 0.2F);
        _leftFin.ZRot = 0.2F - 0.4F * Mth.Sin(state.AgeInTicks * 0.2F);
    }
}

/// <summary><c>PufferfishRenderer</c>. Vanilla's three models take any state; a renderer's model here is typed by its own.</summary>
public sealed class PufferfishRenderer : MobRenderer<PufferfishRenderState, EntityModel<PufferfishRenderState>> {
    private readonly EntityModel<PufferfishRenderState> _small, _mid, _big;

    public PufferfishRenderer(EntityRendererContext context) : base(new PufferfishBigModel(PufferfishBigModel.CreateBodyLayer().BakeRoot()), 0.2F) {
        _big = Model;
        _mid = new PufferfishMidModel(PufferfishMidModel.CreateBodyLayer().BakeRoot());
        _small = new PufferfishSmallModel(PufferfishSmallModel.CreateBodyLayer().BakeRoot());
    }

    public override string GetTextureLocation(PufferfishRenderState state) => "minecraft:textures/entity/fish/pufferfish.png";

    // getShadowRadius (0.1 + 0.1 * puffState) is not ported: entity shadows are not drawn.

    public override void Submit(PufferfishRenderState state, PoseStack pose, EntityRenderContext context) {
        Model = state.PuffState switch {
            0 => _small,
            1 => _mid,
            _ => _big
        };
        base.Submit(state, pose, context);
    }

    public override void ExtractRenderState(ClientEntity entity, PufferfishRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.PuffState = entity.Get(EntityDataFields.Pufferfish.PuffState);
    }

    protected override void SetupRotations(PufferfishRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        pose.Translate(0.0F, Mth.Cos(state.AgeInTicks * 0.05F) * 0.08F, 0.0F);
        base.SetupRotations(state, pose, bodyRot, entityScale);
    }
}

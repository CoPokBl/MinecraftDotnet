using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class EvokerFangsRenderState : EntityRenderState {
    public float YRot, BiteProgress;
}

/// <summary><c>EvokerFangsRenderer</c>: nothing until the server's attack event arrives.</summary>
public sealed class EvokerFangsRenderer : EntityRenderer<EvokerFangsRenderState> {
    private const string TextureLocation = "minecraft:textures/entity/illager/evoker_fangs.png";

    private readonly EvokerFangsModel _model = new(EvokerFangsModel.CreateBodyLayer().BakeRoot());

    public EvokerFangsRenderer(EntityRendererContext context) { }

    /// <summary><c>EvokerFangs.clientSideAttackStarted</c> and <c>lifeTicks</c>.</summary>
    private sealed class Attack {
        public bool ClientSideAttackStarted;
        public int LifeTicks = 22;
    }

    /// <summary><c>EvokerFangs.handleEntityEvent</c>.</summary>
    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        if (eventId == 4) {
            ((Attack)(entity.RendererData ??= new Attack())).ClientSideAttackStarted = true;
        }
    }

    /// <summary>The client half of <c>EvokerFangs.tick</c>.</summary>
    public override void Tick(ClientEntity entity) {
        if (entity.RendererData is Attack { ClientSideAttackStarted: true } attack) {
            attack.LifeTicks--;
        }
    }

    public override void ExtractRenderState(ClientEntity entity, EvokerFangsRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.YRot = entity.YRot;
        state.BiteProgress = GetAnimationProgress(entity.RendererData as Attack, partialTick);
    }

    /// <summary><c>EvokerFangs.getAnimationProgress</c>.</summary>
    private static float GetAnimationProgress(Attack? attack, float a) {
        if (attack is not { ClientSideAttackStarted: true }) {
            return 0.0F;
        }
        int remainingLife = attack.LifeTicks - 2;
        return remainingLife <= 0 ? 1.0F : 1.0F - (remainingLife - a) / 20.0F;
    }

    public override void Submit(EvokerFangsRenderState state, PoseStack pose, EntityRenderContext context) {
        float biteProgress = state.BiteProgress;
        if (biteProgress == 0.0F) {
            return;
        }
        pose.Push();
        pose.RotateYDegrees(90.0F - state.YRot);
        pose.Scale(-1.0F, -1.0F, 1.0F);
        pose.Translate(0.0F, -1.501F, 0.0F);
        _model.SetupAnim(state);
        EntityTexture texture = context.Textures.Get(TextureLocation) ?? context.Textures.Missing;
        _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(texture, 0xFFFFFFFF, state.SkyLight, state.BlockLight, 0));
        pose.Pop();
    }
}

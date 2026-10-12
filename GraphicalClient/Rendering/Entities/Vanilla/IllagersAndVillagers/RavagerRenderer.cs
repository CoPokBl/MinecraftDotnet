using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class RavagerRenderState : LivingEntityRenderState {
    public float StunnedTicksRemaining, AttackTicksRemaining, RoarAnimation;
}

public sealed class RavagerRenderer : MobRenderer<RavagerRenderState, RavagerModel> {
    public RavagerRenderer(EntityRendererContext context) : base(new RavagerModel(RavagerModel.CreateBodyLayer().BakeRoot()), 1.1F) { }

    /// <summary><c>Ravager.attackTick</c>, <c>stunnedTick</c> and <c>roarTick</c>, which the client counts from entity events.</summary>
    private sealed class Ticks {
        public int Attack, Stunned, Roar;
    }

    /// <summary><c>Ravager.handleEntityEvent</c>.</summary>
    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        Ticks ticks = (Ticks)(entity.RendererData ??= new Ticks());
        if (eventId == 4) {
            ticks.Attack = 10;
        }
        else if (eventId == 39) {
            ticks.Stunned = 40;
        }
    }

    /// <summary>The counters of <c>Ravager.aiStep</c>.</summary>
    public override void Tick(ClientEntity entity) {
        if (entity.CurrentHealth <= 0) {
            return;
        }
        Ticks ticks = (Ticks)(entity.RendererData ??= new Ticks());
        if (ticks.Roar > 0) {
            ticks.Roar--;
        }
        if (ticks.Attack > 0) {
            ticks.Attack--;
        }
        if (ticks.Stunned > 0) {
            ticks.Stunned--;
            if (ticks.Stunned == 0) {
                ticks.Roar = 20;
            }
        }
    }

    public override string GetTextureLocation(RavagerRenderState state) => "minecraft:textures/entity/illager/ravager.png";

    public override void ExtractRenderState(ClientEntity entity, RavagerRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        Ticks ticks = entity.RendererData as Ticks ?? new Ticks();
        state.StunnedTicksRemaining = ticks.Stunned > 0.0F ? ticks.Stunned - partialTick : 0.0F;
        state.AttackTicksRemaining = ticks.Attack > 0.0F ? ticks.Attack - partialTick : 0.0F;
        state.RoarAnimation = ticks.Roar > 0 ? (20 - ticks.Roar + partialTick) / 20.0F : 0.0F;
    }
}

using ClientLib.Entities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>Crackiness.Level</c>.</summary>
public enum CrackinessLevel {
    None,
    Low,
    Medium,
    High
}

public class IronGolemRenderState : LivingEntityRenderState {
    public float AttackTicksRemaining;
    public int OfferFlowerTick;
    public IBlock? FlowerBlock;
    public CrackinessLevel Crackiness = CrackinessLevel.None;
}

public sealed class IronGolemRenderer : MobRenderer<IronGolemRenderState, IronGolemModel> {
    public IronGolemRenderer(EntityRendererContext context) : base(new IronGolemModel(IronGolemModel.CreateBodyLayer().BakeRoot()), 0.7F) {
        AddLayer(new IronGolemCrackinessLayer(this));
        AddLayer(new IronGolemFlowerLayer(this, context.Blocks));
    }

    /// <summary><c>IronGolem.attackAnimationTick</c> and <c>offerFlowerTick</c>, which the client counts from entity events.</summary>
    private sealed class Ticks {
        public int AttackAnimation, OfferFlower;
    }

    /// <summary><c>IronGolem.handleEntityEvent</c>.</summary>
    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        Ticks ticks = (Ticks)(entity.RendererData ??= new Ticks());
        if (eventId == 4) {
            ticks.AttackAnimation = 10;
        }
        else if (eventId == 11) {
            ticks.OfferFlower = 400;
        }
        else if (eventId == 34) {
            ticks.OfferFlower = 0;
        }
    }

    /// <summary>The counters of <c>IronGolem.aiStep</c>.</summary>
    public override void Tick(ClientEntity entity) {
        Ticks ticks = (Ticks)(entity.RendererData ??= new Ticks());
        if (ticks.AttackAnimation > 0) {
            ticks.AttackAnimation--;
        }
        if (ticks.OfferFlower > 0) {
            ticks.OfferFlower--;
        }
    }

    public override string GetTextureLocation(IronGolemRenderState state) => "minecraft:textures/entity/iron_golem/iron_golem.png";

    public override void ExtractRenderState(ClientEntity entity, IronGolemRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        Ticks ticks = entity.RendererData as Ticks ?? new Ticks();
        state.AttackTicksRemaining = ticks.AttackAnimation > 0.0F ? ticks.AttackAnimation - partialTick : 0.0F;
        state.OfferFlowerTick = ticks.OfferFlower;
        state.FlowerBlock = state.OfferFlowerTick > 0 ? Block.Poppy : null;
        state.Crackiness = GetCrackiness(entity);
    }

    /// <summary><c>IronGolem.getCrackiness</c>, through <c>Crackiness.GOLEM.byFraction</c>.</summary>
    private static CrackinessLevel GetCrackiness(ClientEntity entity) {
        float fraction = entity.CurrentHealth / (float)entity.Attributes.Value(Minecraft.Data.Generated.Attribute.MaxHealth);
        if (fraction < 0.25F) {
            return CrackinessLevel.High;
        }
        if (fraction < 0.5F) {
            return CrackinessLevel.Medium;
        }
        return fraction < 0.75F ? CrackinessLevel.Low : CrackinessLevel.None;
    }

    protected override void SetupRotations(IronGolemRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        base.SetupRotations(state, pose, bodyRot, entityScale);
        if (!(state.WalkAnimationSpeed < 0.01)) {
            float wp = state.WalkAnimationPos + 6.0F;
            float triangleWave = (Math.Abs(wp % 13.0F - 6.5F) - 3.25F) / 3.25F;
            pose.RotateZDegrees(6.5F * triangleWave);
        }
    }
}

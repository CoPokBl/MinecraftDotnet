using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>CreakingRenderState</c>. The animation states are the entity's own, shared rather than copied.</summary>
public sealed class CreakingRenderState : LivingEntityRenderState {
    public AnimationState InvulnerabilityAnimationState = new();
    public AnimationState AttackAnimationState = new();
    public AnimationState DeathAnimationState = new();
    public bool EyesGlowing, CanMove;
}

public sealed class CreakingRenderer : MobRenderer<CreakingRenderState, CreakingModel> {
    private const string EyesTextureLocation = "minecraft:textures/entity/creaking/creaking_eyes.png";

    public CreakingRenderer(EntityRendererContext context) : base(new CreakingModel(CreakingModel.CreateBodyLayer().BakeRoot()), 0.6F) {
        AddLayer(new LivingEntityEmissiveLayer<CreakingRenderState, CreakingModel>(this, _ => EyesTextureLocation,
            (state, _) => state.EyesGlowing ? 1.0F : 0.0F, new CreakingModel(CreakingModel.CreateEyesLayer().BakeRoot()), false, true));
    }

    /// <summary>
    /// What <c>Creaking</c> keeps on the client: its animation states and their countdowns, its own
    /// <c>deathTime</c> (which runs to 45 while tearing down) and eye flicker, and its
    /// <c>WalkAnimationState</c>, which <c>updateWalkAnimation</c> drives harder than the default.
    /// </summary>
    private sealed class CreakingData {
        public readonly AnimationState AttackAnimationState = new();
        public readonly AnimationState InvulnerabilityAnimationState = new();
        public readonly AnimationState DeathAnimationState = new();
        public int AttackAnimationRemainingTicks, InvulnerabilityAnimationRemainingTicks, DeathTime, NextFlickerTime;
        public bool EyesGlowing;
        public float WalkSpeedOld, WalkSpeed, WalkPosition;
    }

    // The entity's own random, which the server never shares, so any source flickers as faithfully.
    private static readonly Random Random = new();

    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        CreakingData data = (CreakingData)(entity.RendererData ??= new CreakingData());
        if (eventId == 66) {
            data.InvulnerabilityAnimationRemainingTicks = 8;
        }
        else if (eventId == 4) {
            data.AttackAnimationRemainingTicks = 15;
        }
    }

    /// <summary><c>Creaking.tick</c> on the client, with the parts of <c>aiStep</c>, <c>tickDeath</c> and <c>updateWalkAnimation</c> it reaches.</summary>
    public override void Tick(ClientEntity entity) {
        CreakingData data = (CreakingData)(entity.RendererData ??= new CreakingData());
        bool tearingDown = entity.Get(EntityDataFields.Creaking.IsTearingDown);
        if (entity.CurrentHealth <= 0) {
            data.DeathTime++;
        }

        if (data.InvulnerabilityAnimationRemainingTicks > 0) {
            data.InvulnerabilityAnimationRemainingTicks--;
        }
        if (data.AttackAnimationRemainingTicks > 0) {
            data.AttackAnimationRemainingTicks--;
        }

        // calculateEntityAnimation(false) into updateWalkAnimation; a dead or riding creaking's stops.
        if (entity.VehicleId == null && entity.CurrentHealth > 0) {
            data.WalkSpeedOld = data.WalkSpeed;
            double dx = entity.Position.X - entity.OldPosition.X, dz = entity.Position.Z - entity.OldPosition.Z;
            float distance = (float)Math.Sqrt(dx * dx + dz * dz);
            float targetSpeed = Math.Min(distance * 25.0F, 3.0F);
            data.WalkSpeed += (targetSpeed - data.WalkSpeed) * 0.4F;
            data.WalkPosition += data.WalkSpeed;
        }
        else {
            data.WalkSpeedOld = 0;
            data.WalkSpeed = 0;
            data.WalkPosition = 0;
        }

        // setupAnimationStates.
        data.AttackAnimationState.AnimateWhen(data.AttackAnimationRemainingTicks > 0, entity.TickCount);
        data.InvulnerabilityAnimationState.AnimateWhen(data.InvulnerabilityAnimationRemainingTicks > 0, entity.TickCount);
        data.DeathAnimationState.AnimateWhen(tearingDown, entity.TickCount);

        // checkEyeBlink.
        if (data.DeathTime > data.NextFlickerTime) {
            int min = data.EyesGlowing ? 2 : data.DeathTime / 4, max = data.EyesGlowing ? 8 : data.DeathTime / 2;
            data.NextFlickerTime = data.DeathTime + Random.Next(max - min + 1) + min;
            data.EyesGlowing = !data.EyesGlowing;
        }
    }

    public override string GetTextureLocation(CreakingRenderState state) => "minecraft:textures/entity/creaking/creaking.png";

    public override void ExtractRenderState(ClientEntity entity, CreakingRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        CreakingData data = (CreakingData)(entity.RendererData ??= new CreakingData());
        if (entity.VehicleId == null && entity.CurrentHealth > 0) {
            state.WalkAnimationPos = data.WalkPosition - data.WalkSpeed * (1.0F - partialTick);
            state.WalkAnimationSpeed = Math.Min(Mth.Lerp(partialTick, data.WalkSpeedOld, data.WalkSpeed), 1.0F);
        }
        state.AttackAnimationState = data.AttackAnimationState;
        state.InvulnerabilityAnimationState = data.InvulnerabilityAnimationState;
        state.DeathAnimationState = data.DeathAnimationState;
        if (entity.Get(EntityDataFields.Creaking.IsTearingDown)) {
            state.DeathTime = 0.0F;
            state.HasRedOverlay = false;
            state.EyesGlowing = data.EyesGlowing;
        }
        else {
            state.EyesGlowing = entity.Get(EntityDataFields.Creaking.IsActive);
        }
        state.CanMove = entity.Get(EntityDataFields.Creaking.CanMove, true);
    }
}

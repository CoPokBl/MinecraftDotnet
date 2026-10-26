using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class RabbitRenderer() : AgeableMobRenderer<RabbitRenderState, RabbitModel>(
    new AdultRabbitModel(AdultRabbitModel.CreateBodyLayer().BakeRoot()), new BabyRabbitModel(BabyRabbitModel.CreateBodyLayer().BakeRoot()), 0.3F) {
    private static readonly Dictionary<RabbitVariant, (string Adult, string Baby)> Textures = new() {
        [RabbitVariant.Brown] = ("minecraft:textures/entity/rabbit/rabbit_brown.png", "minecraft:textures/entity/rabbit/rabbit_brown_baby.png"),
        [RabbitVariant.WhiteSplotched] = ("minecraft:textures/entity/rabbit/rabbit_white_splotched.png", "minecraft:textures/entity/rabbit/rabbit_white_splotched_baby.png"),
        [RabbitVariant.Evil] = ("minecraft:textures/entity/rabbit/rabbit_caerbannog.png", "minecraft:textures/entity/rabbit/rabbit_caerbannog_baby.png"),
        [RabbitVariant.White] = ("minecraft:textures/entity/rabbit/rabbit_white.png", "minecraft:textures/entity/rabbit/rabbit_white_baby.png"),
        [RabbitVariant.Gold] = ("minecraft:textures/entity/rabbit/rabbit_gold.png", "minecraft:textures/entity/rabbit/rabbit_gold_baby.png"),
        [RabbitVariant.Black] = ("minecraft:textures/entity/rabbit/rabbit_black.png", "minecraft:textures/entity/rabbit/rabbit_black_baby.png"),
        [RabbitVariant.Salt] = ("minecraft:textures/entity/rabbit/rabbit_salt.png", "minecraft:textures/entity/rabbit/rabbit_salt_baby.png")
    };

    /// <summary>The jump and animation fields <c>Rabbit</c> keeps on the client's entity.</summary>
    private sealed class RabbitAnimation {
        // The draws are not from the entity's own random, so the idle head tilt lands at different ticks than vanilla's would.
        public int IdleAnimationTimeout = Random.Shared.Next(40) + 180;
        public int JumpTicks, JumpDuration;
        public readonly AnimationState HopAnimationState = new();
        public readonly AnimationState IdleHeadTiltAnimationState = new();
    }

    /// <summary>
    /// <c>Rabbit.baseTick</c>'s <c>setupAnimationStates</c>, then <c>aiStep</c>'s jump count. The client keeps
    /// no leash data, so <c>shouldPlayIdleAnimation</c> treats every rabbit as unleashed.
    /// </summary>
    public override void Tick(ClientEntity entity) {
        RabbitAnimation anim = (RabbitAnimation)(entity.RendererData ??= new RabbitAnimation());
        bool isNoAi = (entity.Get(EntityDataFields.Mob.MobFlags) & 1) != 0;
        if (anim.IdleAnimationTimeout <= 0 && !isNoAi) {
            anim.IdleAnimationTimeout = Random.Shared.Next(40) + 180;
            anim.IdleHeadTiltAnimationState.Start(entity.TickCount);
        }
        else if (anim.JumpTicks > 0) {
            anim.HopAnimationState.StartIfStopped(entity.TickCount);
            anim.IdleHeadTiltAnimationState.Stop();
        }
        else {
            anim.IdleAnimationTimeout--;
            anim.HopAnimationState.Stop();
        }
        if (anim.JumpTicks != anim.JumpDuration) {
            anim.JumpTicks++;
        }
        else if (anim.JumpDuration != 0) {
            anim.JumpTicks = 0;
            anim.JumpDuration = 0;
        }
    }

    /// <summary><c>Rabbit.handleEntityEvent</c>: 1 is a jump.</summary>
    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        if (eventId == 1) {
            RabbitAnimation anim = (RabbitAnimation)(entity.RendererData ??= new RabbitAnimation());
            anim.JumpDuration = 15;
            anim.JumpTicks = 0;
        }
    }

    public override string GetTextureLocation(RabbitRenderState state) {
        if (state.IsToast) {
            return state.IsBaby ? "minecraft:textures/entity/rabbit/rabbit_toast_baby.png" : "minecraft:textures/entity/rabbit/rabbit_toast.png";
        }
        return state.IsBaby ? Textures[state.Variant].Baby : Textures[state.Variant].Adult;
    }

    public override void ExtractRenderState(ClientEntity entity, RabbitRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        RabbitAnimation? anim = entity.RendererData as RabbitAnimation;
        state.JumpCompletion = anim == null || anim.JumpDuration == 0 ? 0.0F : (anim.JumpTicks + partialTick) / anim.JumpDuration;
        // MobRenderer.checkMagicName.
        state.IsToast = entity.CustomName == "Toast";
        // Rabbit.Variant.byId is sparse: an id it does not know is brown.
        RabbitVariant variant = (RabbitVariant)entity.Get(EntityDataFields.Rabbit.Type);
        state.Variant = Textures.ContainsKey(variant) ? variant : RabbitVariant.Brown;
        if (anim != null) {
            state.HopAnimationState = anim.HopAnimationState;
            state.IdleHeadTiltAnimationState = anim.IdleHeadTiltAnimationState;
        }
    }
}

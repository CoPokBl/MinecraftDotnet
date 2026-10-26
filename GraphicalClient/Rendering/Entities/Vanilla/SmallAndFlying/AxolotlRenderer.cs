using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>Axolotl.Variant</c>, by its synced id.</summary>
public enum AxolotlVariant {
    Lucy = 0,
    Wild = 1,
    Gold = 2,
    Cyan = 3,
    Blue = 4
}

public class AxolotlRenderState : LivingEntityRenderState {
    public AxolotlVariant Variant = AxolotlVariant.Lucy;
    public float PlayingDeadFactor, MovingFactor;
    public float InWaterFactor = 1.0F;
    public float OnGroundFactor;
    public AnimationState SwimAnimation = new();
    public AnimationState WalkAnimationState = new();
    public AnimationState WalkUnderWaterAnimationState = new();
    public AnimationState IdleUnderWaterAnimationState = new();
    public AnimationState IdleUnderWaterOnGroundAnimationState = new();
    public AnimationState IdleOnGroundAnimationState = new();
    public AnimationState PlayDeadAnimationState = new();
}

public sealed class AxolotlRenderer : AgeableMobRenderer<AxolotlRenderState, EntityModel<AxolotlRenderState>> {
    private static readonly string[] Names = ["lucy", "wild", "gold", "cyan", "blue"];
    private static readonly string[] Textures = Names.Select(name => $"minecraft:textures/entity/axolotl/axolotl_{name}.png").ToArray();
    private static readonly string[] BabyTextures = Names.Select(name => $"minecraft:textures/entity/axolotl/axolotl_{name}_baby.png").ToArray();

    public AxolotlRenderer(EntityRendererContext context)
        : base(new AdultAxolotlModel(AdultAxolotlModel.CreateBodyLayer().BakeRoot()), new BabyAxolotlModel(BabyAxolotlModel.CreateBodyLayer().BakeRoot()), 0.5F) { }

    /// <summary>What <c>Axolotl</c> keeps for its animations on the client.</summary>
    private sealed class Animations {
        public readonly BinaryAnimator PlayingDead = new(10, BinaryAnimator.InOutSine);
        public readonly BinaryAnimator InWater = new(10, BinaryAnimator.InOutSine);
        public readonly BinaryAnimator OnGround = new(10, BinaryAnimator.InOutSine);
        public readonly BinaryAnimator Moving = new(10, BinaryAnimator.InOutSine);
        public readonly AnimationState Swim = new(), Walk = new(), WalkUnderWater = new(), IdleUnderWater = new(), IdleUnderWaterOnGround = new(),
            IdleOnGround = new(), PlayDead = new();

        public AnimationState[] All => [Swim, Walk, WalkUnderWater, IdleUnderWater, IdleUnderWaterOnGround, IdleOnGround, PlayDead];
    }

    /// <summary><c>Axolotl.baseTick</c>'s client half.</summary>
    public override void Tick(ClientEntity entity, ClientLevel level) {
        Animations animations = (Animations)(entity.RendererData ??= new Animations());
        if (entity.IsBaby) {
            TickBabyAnimations(entity, level, animations);
        }
        else {
            TickAdultAnimations(entity, level, animations);
        }
    }

    /// <summary>
    /// <c>isMoving</c> as <c>baseTick</c> sees it: the walk speed before this tick moves it. Its rotation
    /// tests never hold on the client, where <c>setOldPosAndRot</c> has just run and only <c>aiStep</c>
    /// turns the entity.
    /// </summary>
    private static bool IsMoving(ClientEntity entity) => entity.WalkSpeedOld > 1.0E-5F;

    private static bool IsPlayingDead(ClientEntity entity) => entity.Get(EntityDataFields.Axolotl.PlayingDead);

    private static void TickBabyAnimations(ClientEntity entity, ClientLevel level, Animations animations) {
        bool isPlayingDead = IsPlayingDead(entity);
        bool isInWater = EntityWater.IsInWater(level, entity);
        bool onGround = entity.OnGround;
        bool isMoving = IsMoving(entity);
        animations.Moving.Tick(isMoving);
        AnimationState toStart = isPlayingDead ? animations.PlayDead
            : isMoving ? isInWater && !onGround ? animations.Swim : !isInWater && onGround ? animations.Walk : animations.WalkUnderWater
            : isInWater && !onGround ? animations.IdleUnderWater
            : isInWater && onGround ? animations.IdleUnderWaterOnGround
            : animations.IdleOnGround;
        SoloAnimation(entity, animations, toStart);
    }

    private static void SoloAnimation(ClientEntity entity, Animations animations, AnimationState toStart) {
        foreach (AnimationState animation in animations.All) {
            if (animation == toStart) {
                animation.StartIfStopped(entity.TickCount);
            }
            else {
                animation.Stop();
            }
        }
    }

    private static void TickAdultAnimations(ClientEntity entity, ClientLevel level, Animations animations) {
        bool playingDead = IsPlayingDead(entity);
        bool inWater = !playingDead && EntityWater.IsInWater(level, entity);
        bool onGround = !playingDead && !inWater && entity.OnGround;
        animations.PlayingDead.Tick(playingDead);
        animations.InWater.Tick(inWater);
        animations.OnGround.Tick(onGround);
        animations.Moving.Tick(IsMoving(entity));
    }

    public override string GetTextureLocation(AxolotlRenderState state) => (state.IsBaby ? BabyTextures : Textures)[(int)state.Variant];

    public override void ExtractRenderState(ClientEntity entity, AxolotlRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // Axolotl.Variant.byId, which falls back to the first for an id out of range.
        int id = entity.Get(EntityDataFields.Axolotl.Variant);
        state.Variant = id >= 0 && id < Names.Length ? (AxolotlVariant)id : AxolotlVariant.Lucy;
        if (entity.RendererData is Animations animations) {
            state.PlayingDeadFactor = animations.PlayingDead.GetFactor(partialTick);
            state.InWaterFactor = animations.InWater.GetFactor(partialTick);
            state.OnGroundFactor = animations.OnGround.GetFactor(partialTick);
            state.MovingFactor = animations.Moving.GetFactor(partialTick);
            state.SwimAnimation = animations.Swim;
            state.WalkAnimationState = animations.Walk;
            state.WalkUnderWaterAnimationState = animations.WalkUnderWater;
            state.IdleOnGroundAnimationState = animations.IdleOnGround;
            state.IdleUnderWaterOnGroundAnimationState = animations.IdleUnderWaterOnGround;
            state.IdleUnderWaterAnimationState = animations.IdleUnderWater;
            state.PlayDeadAnimationState = animations.PlayDead;
        }
        else {
            // An animator that has not ticked yet sits at zero.
            state.InWaterFactor = 0.0F;
        }
    }
}

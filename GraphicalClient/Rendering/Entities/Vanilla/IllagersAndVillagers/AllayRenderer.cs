using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class AllayRenderState : ArmedEntityRenderState {
    public bool IsDancing, IsSpinning;
    public float SpinningProgress, HoldingAnimationProgress;
}

/// <summary><c>AllayRenderer</c>: always at full block light.</summary>
public sealed class AllayRenderer : MobRenderer<AllayRenderState, AllayModel> {
    private readonly ItemRenderer _items;

    public AllayRenderer(EntityRendererContext context) : base(new AllayModel(AllayModel.CreateBodyLayer().BakeRoot()), 0.4F) {
        _items = context.Items;
        AddLayer(new ItemInHandLayer<AllayRenderState, AllayModel>(this, context.Items));
    }

    /// <summary><c>Allay</c>'s client side animation counters.</summary>
    private sealed class Animation {
        public float HoldingItemAnimationTicks, HoldingItemAnimationTicks0, DancingAnimationTicks, SpinningAnimationTicks, SpinningAnimationTicks0;

        /// <summary><c>isSpinning</c>.</summary>
        public bool IsSpinning => DancingAnimationTicks % 55.0F < 15.0F;
    }

    /// <summary>The client half of <c>Allay.tick</c>.</summary>
    public override void Tick(ClientEntity entity) {
        Animation animation = (Animation)(entity.RendererData ??= new Animation());
        animation.HoldingItemAnimationTicks0 = animation.HoldingItemAnimationTicks;
        // hasItemInHand.
        if (!entity.ItemInHand(Hand.MainHand).IsAir()) {
            animation.HoldingItemAnimationTicks = Mth.Clamp(animation.HoldingItemAnimationTicks + 1.0F, 0.0F, 5.0F);
        }
        else {
            animation.HoldingItemAnimationTicks = Mth.Clamp(animation.HoldingItemAnimationTicks - 1.0F, 0.0F, 5.0F);
        }

        if (entity.Get(EntityDataFields.Allay.Dancing)) {
            animation.DancingAnimationTicks++;
            animation.SpinningAnimationTicks0 = animation.SpinningAnimationTicks;
            if (animation.IsSpinning) {
                animation.SpinningAnimationTicks++;
            }
            else {
                animation.SpinningAnimationTicks--;
            }
            animation.SpinningAnimationTicks = Mth.Clamp(animation.SpinningAnimationTicks, 0.0F, 15.0F);
        }
        else {
            animation.DancingAnimationTicks = 0.0F;
            animation.SpinningAnimationTicks = 0.0F;
            animation.SpinningAnimationTicks0 = 0.0F;
        }
    }

    public override string GetTextureLocation(AllayRenderState state) => "minecraft:textures/entity/allay/allay.png";

    public override void ExtractRenderState(ClientEntity entity, AllayRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // getBlockLightLevel.
        state.BlockLight = 15;
        ArmedEntityRenderState.ExtractArmedEntityRenderState(entity, state, _items, partialTick);
        Animation animation = entity.RendererData as Animation ?? new Animation();
        state.IsDancing = entity.Get(EntityDataFields.Allay.Dancing);
        state.IsSpinning = animation.IsSpinning;
        state.SpinningProgress = Mth.Lerp(partialTick, animation.SpinningAnimationTicks0, animation.SpinningAnimationTicks) / 15.0F;
        state.HoldingAnimationProgress = Mth.Lerp(partialTick, animation.HoldingItemAnimationTicks0, animation.HoldingItemAnimationTicks) / 5.0F;
    }
}

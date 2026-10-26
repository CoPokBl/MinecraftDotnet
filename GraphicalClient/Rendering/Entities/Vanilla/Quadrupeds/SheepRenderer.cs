using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class SheepRenderState : LivingEntityRenderState {
    public float HeadEatPositionScale;
    public float HeadEatAngleScale;
    public bool IsSheared;
    public DyeColor WoolColor = DyeColor.White;
    public bool IsJebSheep;

    public uint GetWoolColor() => IsJebSheep ? ColorLerper.GetLerpedSheepColor(AgeInTicks) : ColorLerper.GetSheepColor(WoolColor);
}

public sealed class SheepRenderer : AgeableMobRenderer<SheepRenderState, SheepModel> {
    public SheepRenderer(EntityRendererContext context)
        : base(new SheepModel(SheepModel.CreateBodyLayer().BakeRoot()), new BabySheepModel(BabySheepModel.CreateBodyLayer().BakeRoot()), 0.7F) {
        AddLayer(new SheepWoolUndercoatLayer(this));
        AddLayer(new SheepWoolLayer(this));
    }

    /// <summary><c>Sheep.eatAnimationTick</c>, which entity event 10 starts.</summary>
    private sealed class EatAnimation {
        public int Tick;
    }

    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        if (eventId == 10) {
            ((EatAnimation)(entity.RendererData ??= new EatAnimation())).Tick = 40;
        }
    }

    /// <summary><c>Sheep.aiStep</c>'s client side countdown.</summary>
    public override void Tick(ClientEntity entity) {
        if (entity.RendererData is EatAnimation eat) {
            eat.Tick = Math.Max(0, eat.Tick - 1);
        }
    }

    public override string GetTextureLocation(SheepRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/sheep/sheep_baby.png" : "minecraft:textures/entity/sheep/sheep.png";

    public override void ExtractRenderState(ClientEntity entity, SheepRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        int eatTick = entity.RendererData is EatAnimation eat ? eat.Tick : 0;
        state.HeadEatAngleScale = GetHeadEatAngleScale(eatTick, partialTick, Mth.Lerp(partialTick, entity.XRotO, entity.XRot));
        state.HeadEatPositionScale = GetHeadEatPositionScale(eatTick, partialTick);
        sbyte wool = entity.Get(EntityDataFields.Sheep.Wool);
        // Sheep.isSheared and getColor: the low four bits are the dye, bit 4 the shearing.
        state.IsSheared = (wool & 16) != 0;
        state.WoolColor = (DyeColor)(wool & 15);
        state.IsJebSheep = entity.CustomName == "jeb_";
    }

    /// <summary><c>Sheep.getHeadEatPositionScale</c>.</summary>
    private static float GetHeadEatPositionScale(int eatAnimationTick, float a) {
        if (eatAnimationTick <= 0) {
            return 0.0F;
        }
        if (eatAnimationTick >= 4 && eatAnimationTick <= 36) {
            return 1.0F;
        }
        return eatAnimationTick < 4 ? (eatAnimationTick - a) / 4.0F : -(eatAnimationTick - 40 - a) / 4.0F;
    }

    /// <summary><c>Sheep.getHeadEatAngleScale</c>.</summary>
    private static float GetHeadEatAngleScale(int eatAnimationTick, float a, float xRot) {
        if (eatAnimationTick > 4 && eatAnimationTick <= 36) {
            float scale = (eatAnimationTick - 4 - a) / 32.0F;
            return MathF.PI / 5 + 0.21991149F * Mth.Sin(scale * 28.7F);
        }
        return eatAnimationTick > 0 ? MathF.PI / 5 : xRot * (MathF.PI / 180.0F);
    }
}

using ClientLib.Entities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>MushroomCow.Variant</c>.</summary>
public enum MushroomCowVariant { Red = 0, Brown = 1 }

public class MushroomCowRenderState : LivingEntityRenderState {
    public MushroomCowVariant Variant = MushroomCowVariant.Red;
    public IBlock MushroomModel = Block.RedMushroom;
}

public sealed class MushroomCowRenderer : AgeableMobRenderer<MushroomCowRenderState, CowModel<MushroomCowRenderState>> {
    private static readonly Dictionary<MushroomCowVariant, (string Adult, string Baby)> Textures = new() {
        [MushroomCowVariant.Brown] = ("minecraft:textures/entity/cow/mooshroom_brown.png", "minecraft:textures/entity/cow/mooshroom_brown_baby.png"),
        [MushroomCowVariant.Red] = ("minecraft:textures/entity/cow/mooshroom_red.png", "minecraft:textures/entity/cow/mooshroom_red_baby.png")
    };

    public MushroomCowRenderer(EntityRendererContext context)
        : base(new CowModel<MushroomCowRenderState>(CowModel.CreateBodyLayer().BakeRoot()),
            new CowModel<MushroomCowRenderState>(BabyCowModel.CreateBodyLayer().BakeRoot()), 0.7F) {
        AddLayer(new MushroomCowMushroomLayer(this, context.Blocks));
    }

    public override string GetTextureLocation(MushroomCowRenderState state) => state.IsBaby ? Textures[state.Variant].Baby : Textures[state.Variant].Adult;

    public override void ExtractRenderState(ClientEntity entity, MushroomCowRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // MushroomCow.Variant.byId: an id out of range is the first, red.
        state.Variant = entity.Get(EntityDataFields.MushroomCow.Type) == 1 ? MushroomCowVariant.Brown : MushroomCowVariant.Red;
        state.MushroomModel = state.Variant == MushroomCowVariant.Brown ? Block.BrownMushroom : Block.RedMushroom;
    }
}

using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class HorseRenderer : AbstractHorseRenderer<HorseRenderState, HorseModel<HorseRenderState>> {
    private static readonly Dictionary<HorseVariant, (string Adult, string Baby)> LocationByVariant = new() {
        [HorseVariant.White] = ("minecraft:textures/entity/horse/horse_white.png", "minecraft:textures/entity/horse/horse_white_baby.png"),
        [HorseVariant.Creamy] = ("minecraft:textures/entity/horse/horse_creamy.png", "minecraft:textures/entity/horse/horse_creamy_baby.png"),
        [HorseVariant.Chestnut] = ("minecraft:textures/entity/horse/horse_chestnut.png", "minecraft:textures/entity/horse/horse_chestnut_baby.png"),
        [HorseVariant.Brown] = ("minecraft:textures/entity/horse/horse_brown.png", "minecraft:textures/entity/horse/horse_brown_baby.png"),
        [HorseVariant.Black] = ("minecraft:textures/entity/horse/horse_black.png", "minecraft:textures/entity/horse/horse_black_baby.png"),
        [HorseVariant.Gray] = ("minecraft:textures/entity/horse/horse_gray.png", "minecraft:textures/entity/horse/horse_gray_baby.png"),
        [HorseVariant.DarkBrown] = ("minecraft:textures/entity/horse/horse_darkbrown.png", "minecraft:textures/entity/horse/horse_darkbrown_baby.png")
    };

    public HorseRenderer(EntityRendererContext context) : base(
        new HorseModel<HorseRenderState>(AbstractEquineModel<HorseRenderState>.CreateBodyLayer(CubeDeformation.None).Apply(MeshTransformers.Scaling(1.1F)).BakeRoot()),
        new BabyHorseModel<HorseRenderState>(BabyHorseModel<HorseRenderState>.CreateBabyLayer(CubeDeformation.None).BakeRoot())) {
        AddLayer(new HorseMarkingLayer(this));
        AddBodyArmorAndSaddleLayers(context, EquipmentClientInfo.LayerType.HorseSaddle, MeshTransformers.Scaling(1.1F));
    }

    public override string GetTextureLocation(HorseRenderState state) =>
        state.IsBaby ? LocationByVariant[state.Variant].Baby : LocationByVariant[state.Variant].Adult;

    public override void ExtractRenderState(ClientEntity entity, HorseRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        int typeVariant = entity.Get(EntityDataFields.Horse.IdTypeVariant);
        // Variant.byId and Markings.byId both wrap an id past the end.
        state.Variant = (HorseVariant)Wrap(typeVariant & 0xFF, 7);
        state.Markings = (HorseMarkings)Wrap((typeVariant & 0xFF00) >> 8, 5);
    }

    private static int Wrap(int id, int count) => ((id % count) + count) % count;
}

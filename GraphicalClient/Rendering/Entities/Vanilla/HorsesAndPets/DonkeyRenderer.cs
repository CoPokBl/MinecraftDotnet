using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>For the donkey and the mule.</summary>
public sealed class DonkeyRenderer : AbstractHorseRenderer<DonkeyRenderState, DonkeyModel> {
    /// <summary><c>DonkeyRenderer.Type</c>, with the adult and baby types folded into one.</summary>
    public sealed record Type(string Texture, string BabyTexture, float Scale, EquipmentClientInfo.LayerType SaddleLayer) {
        public static readonly Type Donkey = new("minecraft:textures/entity/horse/donkey.png", "minecraft:textures/entity/horse/donkey_baby.png", 0.87F,
            EquipmentClientInfo.LayerType.DonkeySaddle);
        public static readonly Type Mule = new("minecraft:textures/entity/horse/mule.png", "minecraft:textures/entity/horse/mule_baby.png", 0.92F,
            EquipmentClientInfo.LayerType.MuleSaddle);
    }

    private readonly Type _type;

    public DonkeyRenderer(EntityRendererContext context, Type type)
        : base(new DonkeyModel(DonkeyModel.CreateBodyLayer(type.Scale).BakeRoot()), new BabyDonkeyModel(BabyDonkeyModel.CreateBabyLayer().BakeRoot())) {
        _type = type;
        AddLayer(new SimpleEquipmentLayer<DonkeyRenderState, DonkeyModel, EquineRenderState>(this, EquipmentLayerRenderer.For(context), type.SaddleLayer,
            state => state.Saddle, new EquineSaddleModel(DonkeyModel.CreateSaddleLayer(type.Scale).BakeRoot()), null));
    }

    public override string GetTextureLocation(DonkeyRenderState state) => state.IsBaby ? _type.BabyTexture : _type.Texture;

    public override void ExtractRenderState(ClientEntity entity, DonkeyRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.HasChest = entity.Get(EntityDataFields.AbstractChestedHorse.IdChest);
    }
}

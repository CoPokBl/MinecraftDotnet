using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>For the llama and the trader llama, which bake the same layers.</summary>
public sealed class LlamaRenderer : AgeableMobRenderer<LlamaRenderState, LlamaModel> {
    private static readonly Dictionary<LlamaVariant, (string Adult, string Baby)> Textures = new() {
        [LlamaVariant.Creamy] = ("minecraft:textures/entity/llama/llama_creamy.png", "minecraft:textures/entity/llama/llama_creamy_baby.png"),
        [LlamaVariant.White] = ("minecraft:textures/entity/llama/llama_white.png", "minecraft:textures/entity/llama/llama_white_baby.png"),
        [LlamaVariant.Brown] = ("minecraft:textures/entity/llama/llama_brown.png", "minecraft:textures/entity/llama/llama_brown_baby.png"),
        [LlamaVariant.Gray] = ("minecraft:textures/entity/llama/llama_gray.png", "minecraft:textures/entity/llama/llama_gray_baby.png")
    };

    public LlamaRenderer(EntityRendererContext context) : base(
        new LlamaModel(LlamaModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()),
        new BabyLlamaModel(BabyLlamaModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()), 0.7F) {
        AddLayer(new LlamaDecorLayer(this, EquipmentLayerRenderer.For(context)));
    }

    public override string GetTextureLocation(LlamaRenderState state) => state.IsBaby ? Textures[state.Variant].Baby : Textures[state.Variant].Adult;

    public override void ExtractRenderState(ClientEntity entity, LlamaRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // Llama.Variant.byId clamps.
        state.Variant = (LlamaVariant)Math.Clamp(entity.Get(EntityDataFields.Llama.Variant), 0, 3);
        state.HasChest = !entity.IsBaby && entity.Get(EntityDataFields.AbstractChestedHorse.IdChest);
        state.BodyItem = entity.GetItemBySlot(EquipmentSlot.Body);
        state.IsTraderLlama = entity.Is(EntityClass.TraderLlama);
    }
}

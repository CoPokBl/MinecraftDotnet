using System.Numerics;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Special;

/// <summary><c>TridentSpecialRenderer</c>: the thrown trident's model, held.</summary>
public sealed class TridentSpecialRenderer(ISpriteGetter sprites, TridentModel model) : SpecialModelRenderer<object> {
    /// <summary><c>TridentModel.TEXTURE</c>, a texture of its own rather than an atlas sprite.</summary>
    private static readonly SpriteId Texture = new(TridentModel.Texture, "minecraft:entity/trident/trident");

    public override object? ExtractArgument(ItemStack stack) => null;

    public override void Submit(object? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight) =>
        model.RenderToBuffer(pose, sink, new ModelDrawState(sprites.Get(Texture), 0xFFFFFFFF, skyLight, blockLight, 0));

    /// <summary>The model again with <c>entityGlint</c>.</summary>
    public override void SubmitFoil(object? argument, PoseStack pose, IModelSink sink) =>
        model.RenderToBuffer(pose, new GlintSink(sink, GlintType.Entity), new ModelDrawState(sprites.Get(Texture), 0xFFFFFFFF, 15, 15, 0));

    public override void GetExtents(Action<Vector3> output) => model.RootPart.GetExtentsForGui(new PoseStack(), output);

    /// <summary><c>TridentSpecialRenderer.Unbaked</c>, which has no fields.</summary>
    public sealed class Unbaked : ISpecialModelUnbaked {
        public static readonly Unbaked Instance = new();

        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) =>
            new TridentSpecialRenderer(context.Sprites, new TridentModel(TridentModel.CreateLayer().BakeRoot()));
    }
}

using System.Numerics;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// <c>EnergySwirlLayer</c>: a second, larger model over the body, its texture scrolling and repeating,
/// added to what is behind it unlit. Drawn whether or not the entity is invisible, as vanilla's is.
/// </summary>
public abstract class EnergySwirlLayer<S, M>(LivingEntityRenderer<S, M> parent) : RenderLayer<S, M>(parent)
    where S : LivingEntityRenderState, new() where M : EntityModel<S> {
    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        if (!IsPowered(state) || context.AdditiveBatch is not { } additive || context.Textures.Get(TextureLocation) is not { } texture) {
            return;
        }
        float t = state.AgeInTicks;
        M model = Model;
        model.SetupAnim(state);
        Vector2 offset = new(XOffset(t) % 1.0F, t * 0.01F % 1.0F);
        EntityTexture? tiled = TiledTextures.Get(context.Textures, TextureLocation, ScrollingSink.Tiles, ScrollingSink.Tiles);
        model.RenderToBuffer(pose, new ScrollingSink(additive, offset, tiled), new ModelDrawState(texture, 0xFF808080, 15, 15, 0) { NoOutline = true });
    }

    protected abstract bool IsPowered(S state);

    protected abstract float XOffset(float t);

    protected abstract string TextureLocation { get; }

    protected abstract M Model { get; }
}

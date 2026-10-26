using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.Blocks;
using Minecraft.Data.Items;

namespace GraphicalClient.Assets;

/// <summary>Which pass a block is drawn in.</summary>
public enum RenderLayer : byte {
    Solid,
    /// <summary>Fully opaque or fully transparent pixels, no blending, so no sorting.</summary>
    Cutout,
    /// <summary>Blended, drawn last and back to front.</summary>
    Translucent
}

/// <summary>How a block's geometry is built.</summary>
public enum BlockGeometry : byte {
    None,
    /// <summary>The block's outline shape, face by face, culled against neighbours.</summary>
    Shape,
    /// <summary>Two crossed planes, the way plants are drawn.</summary>
    Cross,
    /// <summary>Quads baked from a resource pack's block model.</summary>
    Model,
    /// <summary>A fluid surface whose height follows the level property.</summary>
    Fluid
}

/// <summary>Faces in vanilla's <c>Direction</c> order: down, up, north, south, west, east.</summary>
public enum Face : byte {
    Down,
    Up,
    North,
    South,
    West,
    East
}

/// <summary>Which of the biome's colours multiplies a block's texture.</summary>
public enum TintKind : byte {
    None,
    Grass,
    Foliage,
    Water,
    DryFoliage
}

/// <param name="Textures">A texture key per face, in <see cref="Face"/> order.</param>
/// <param name="Tint">The biome colour the textures are multiplied by, which is why tinted art is drawn pale.</param>
/// <param name="TintFaces">Which faces take the tint, a bit per <see cref="Face"/>.</param>
/// <param name="Model">For <see cref="BlockGeometry.Model"/>: the baked quads, and the colours their tint indices take.</param>
/// <param name="Particle">The texture key of the block's particle sprite; null for its north face's texture.</param>
public sealed record BlockAppearance(BlockGeometry Geometry, RenderLayer Layer, string[] Textures,
    TintKind Tint = TintKind.None, byte TintFaces = 0x3F, BakedBlockModel? Model = null, TintSource[]? Tints = null, string? Particle = null) {
    public static readonly BlockAppearance Invisible = new(BlockGeometry.None, RenderLayer.Solid, ["", "", "", "", "", ""]);
}

/// <summary>
/// Where block appearances and their pixels come from. The renderer asks nothing else of it, so a
/// different source (a resource pack, say) can replace the built in art without touching the renderer.
/// </summary>
public interface IResourceSource {
    /// <summary>Asked once per block state at startup.</summary>
    BlockAppearance Appearance(IBlock state);

    /// <summary>The texture a key names: one of <see cref="BlockAppearance.Textures"/>, or a texture a baked quad uses.</summary>
    TextureImage Texture(string key);

    /// <summary>How a texture key animates, or null for a still texture.</summary>
    TextureAnimation? Animation(string key) => null;

    /// <summary>How a still texture's mipmaps are made, from its <c>.mcmeta</c>; an animated one carries its own.</summary>
    Rendering.TextureMipSettings MipSettings(string key) => Rendering.TextureMipSettings.Default;

    /// <summary>
    /// The texture key of a block atlas sprite that code draws rather than a block model names, such as
    /// <c>minecraft:block/fire_0</c> for a burning entity's flames.
    /// </summary>
    string SpriteKey(Minecraft.Schemas.Identifier sprite);

    /// <summary>An item's inventory icon, square, any size.</summary>
    TextureImage ItemIcon(IItem item);

    /// <summary>The item definition a model id names, <c>ClientItem.model</c> read into its tree; null for an item drawn as its icon.</summary>
    ItemModelNode? ItemDefinition(Minecraft.Schemas.Identifier modelId) => null;

    /// <summary><c>ClientItem.properties</c> of the definition a model id names.</summary>
    ClientItemProperties ItemProperties(Minecraft.Schemas.Identifier modelId) => ClientItemProperties.Default;

    /// <summary>The layers a definition chose for a stack, drawn into an icon; null when nothing in them draws.</summary>
    TextureImage? ItemIcon(IReadOnlyList<ItemModelLayer> layers, Minecraft.Schemas.Items.ItemStack stack) => null;

    /// <summary>What a stack's special layers draw as, so an icon is drawn once per look; null when that is a stack with no components.</summary>
    string? SpecialIdentity(IReadOnlyList<ItemModelLayer> layers, Minecraft.Schemas.Items.ItemStack stack) => null;

    /// <summary>A colour to stand for an item or entity type in places that need one, as 0xRRGGBB.</summary>
    uint ColourOf(string identifierPath);
}

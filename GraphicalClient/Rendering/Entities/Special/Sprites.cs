using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.BannerPattern;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Special;

/// <summary><c>SpriteId</c>: a texture by its atlas and its id within it, <c>minecraft:entity/shield/shield_base</c>.</summary>
public readonly record struct SpriteId(Identifier AtlasLocation, Identifier Texture) {
    /// <summary>Where a pack keeps the texture, as the atlas's <c>directory</c> source reads it.</summary>
    public string PackPath => $"assets/{Texture.Namespace}/textures/{Texture.Key}.png";
}

/// <summary><c>Sheets</c>: the atlases and the sprites the special renderers draw with.</summary>
public static partial class Sheets {
    public static readonly Identifier ShieldSheet = "minecraft:textures/atlas/shield_patterns.png";
    public static readonly Identifier BannerSheet = "minecraft:textures/atlas/banner_patterns.png";

    public static readonly SpriteId ShieldBase = ShieldSprite("minecraft:shield_base");
    public static readonly SpriteId ShieldBaseNoPattern = ShieldSprite("minecraft:shield_base_nopattern");
    public static readonly SpriteId ShieldPatternBase = ShieldSprite("minecraft:base");
    public static readonly SpriteId BannerPatternBase = BannerSprite("minecraft:base");

    /// <summary><c>SpriteMapper.apply</c> for <c>SHIELD_MAPPER</c>: the id under <c>entity/shield/</c>.</summary>
    private static SpriteId ShieldSprite(Identifier id) => new(ShieldSheet, new Identifier(id.Namespace, "entity/shield/" + id.Key));

    private static SpriteId BannerSprite(Identifier id) => new(BannerSheet, new Identifier(id.Namespace, "entity/banner/" + id.Key));

    public static SpriteId GetShieldSprite(IBannerPattern pattern) => ShieldSprite(pattern.AssetId);

    public static SpriteId GetBannerSprite(IBannerPattern pattern) => BannerSprite(pattern.AssetId);
}

/// <summary>
/// <c>SpriteGetter</c>: a sprite's pixels, and the same packed where a sink can draw it. The world packs
/// into the entity atlas; a GUI icon is drawn straight from the pixels.
/// </summary>
public interface ISpriteGetter {
    /// <summary>The sprite's pixels, from the pack or the built in art; null when there are none.</summary>
    TextureImage? Image(SpriteId sprite);

    /// <summary>
    /// An image made once under <paramref name="key"/> and packed for drawing: <see cref="EntityTextures.Pending"/>
    /// while it is made, the missing checks when it cannot be.
    /// </summary>
    EntityTexture Texture(string key, Func<TextureImage?> image);

    /// <summary><c>SpriteGetter.get</c>, which also finds a skin <see cref="Assets.Skins.SkinManager"/> downloaded.</summary>
    EntityTexture Get(SpriteId sprite) => Texture("sprite:" + sprite.Texture, () => Assets.Skins.SkinManager.Texture(sprite.Texture.ToString()) ?? Image(sprite));
}

/// <summary>Sprites packed into the entity atlas as they are first drawn.</summary>
public sealed class EntityTextureSprites(EntityTextures textures, Func<SpriteId, TextureImage?> images) : ISpriteGetter {
    public TextureImage? Image(SpriteId sprite) => images(sprite);

    public EntityTexture Texture(string key, Func<TextureImage?> image) => textures.Get(key, image) ?? textures.Missing;
}

/// <summary>
/// Sprites for a drawing made on the CPU: each texture is a whole image standing alone, which
/// <see cref="ImageOf"/> answers for the texture a quad was drawn with.
/// </summary>
public sealed class ImageSprites(Func<SpriteId, TextureImage?> images) : ISpriteGetter {
    private readonly Dictionary<string, EntityTexture> _byKey = new();
    private readonly Dictionary<EntityTexture, TextureImage> _images = new(ReferenceEqualityComparer.Instance);

    public TextureImage? Image(SpriteId sprite) => images(sprite);

    public EntityTexture Texture(string key, Func<TextureImage?> image) {
        if (_byKey.TryGetValue(key, out EntityTexture? known)) {
            return known;
        }
        TextureImage pixels = image() ?? MissingImage;
        EntityTexture texture = new(0, 0, 1, 1, pixels.Width, pixels.Height);
        _byKey[key] = texture;
        _images[texture] = pixels;
        return texture;
    }

    public TextureImage ImageOf(EntityTexture texture) => _images.TryGetValue(texture, out TextureImage? image) ? image : MissingImage;

    private static readonly TextureImage MissingImage = EntityTextures.MissingImage();
}

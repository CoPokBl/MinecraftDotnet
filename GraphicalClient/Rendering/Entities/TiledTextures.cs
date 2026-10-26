using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities.Special;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// A texture laid side by side with itself in the entity atlas, for one vanilla repeats: a quad whose
/// coordinates run over several repeats then needs cutting once per tile rather than once per repeat.
/// </summary>
public static class TiledTextures {
    /// <summary>The texture of an identifier, <paramref name="across"/> copies wide and <paramref name="down"/> high; null while it loads or without it.</summary>
    public static EntityTexture? Get(EntityTextures textures, string identifier, int across, int down) =>
        Placed(textures, textures.Get($"{identifier}#tiled{across}x{down}", () => textures.LoadIdentifier(identifier) is { } image ? Tile(image, across, down) : null));

    /// <inheritdoc cref="Get(EntityTextures, string, int, int)"/>
    public static EntityTexture? Get(ISpriteGetter sprites, EntityTextures textures, SpriteId sprite, int across, int down) =>
        Placed(textures, sprites.Texture($"sprite:{sprite.Texture}#tiled{across}x{down}", () => sprites.Image(sprite) is { } image ? Tile(image, across, down) : null));

    private static EntityTexture? Placed(EntityTextures textures, EntityTexture? texture) =>
        texture == null || ReferenceEquals(texture, textures.Pending) || ReferenceEquals(texture, textures.Missing) ? null : texture;

    public static TextureImage Tile(TextureImage image, int across, int down) {
        int width = image.Width * across, rowBytes = image.Width * 4;
        byte[] rgba = new byte[width * image.Height * down * 4];
        for (int y = 0; y < image.Height * down; y++) {
            for (int x = 0; x < across; x++) {
                Array.Copy(image.Rgba, y % image.Height * rowBytes, rgba, (y * width + x * image.Width) * 4, rowBytes);
            }
        }
        return new TextureImage(width, image.Height * down, rgba);
    }
}

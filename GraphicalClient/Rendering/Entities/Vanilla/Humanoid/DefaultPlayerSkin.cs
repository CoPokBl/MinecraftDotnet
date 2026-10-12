using Minecraft.Data.Components.Types;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>PlayerSkin</c>: texture identifiers as <see cref="EntityTextures"/> takes them, and whether the body is
/// for the slim arm model. <see cref="Secure"/> is whether the textures came from a signed profile property.
/// </summary>
public sealed record PlayerSkin(string Body, string? Cape, string? Elytra, bool Slim, bool Secure) {
    /// <summary><c>with</c>: the patch's resource textures in place of these, which makes the skin insecure.</summary>
    public PlayerSkin With(ProfileComponent.SkinPatch patch) => patch == ProfileComponent.SkinPatch.Empty
        ? this
        : new PlayerSkin(TexturePath(patch.Body) ?? Body, TexturePath(patch.Cape) ?? Cape, TexturePath(patch.Elytra) ?? Elytra, patch.Slim ?? Slim, false);

    /// <summary><c>ClientAsset.ResourceTexture</c>'s path for an asset id.</summary>
    private static string? TexturePath(Minecraft.Schemas.Identifier? id) => id is { } asset ? $"{asset.Namespace}:textures/{asset.Key}.png" : null;
}

/// <summary><c>DefaultPlayerSkin</c>: the skins in the resource pack, one picked by a profile's UUID.</summary>
public static class DefaultPlayerSkin {
    private static readonly PlayerSkin[] DefaultSkins = [
        Create("entity/player/slim/alex", true),
        Create("entity/player/slim/ari", true),
        Create("entity/player/slim/efe", true),
        Create("entity/player/slim/kai", true),
        Create("entity/player/slim/makena", true),
        Create("entity/player/slim/noor", true),
        Create("entity/player/slim/steve", true),
        Create("entity/player/slim/sunny", true),
        Create("entity/player/slim/zuri", true),
        Create("entity/player/wide/alex", false),
        Create("entity/player/wide/ari", false),
        Create("entity/player/wide/efe", false),
        Create("entity/player/wide/kai", false),
        Create("entity/player/wide/makena", false),
        Create("entity/player/wide/noor", false),
        Create("entity/player/wide/steve", false),
        Create("entity/player/wide/sunny", false),
        Create("entity/player/wide/zuri", false)
    ];

    public static PlayerSkin GetDefaultSkin() => DefaultSkins[6];

    public static PlayerSkin Get(Guid profileId) => DefaultSkins[FloorMod(JavaHashCode(profileId), DefaultSkins.Length)];

    /// <summary><c>UUID.hashCode</c>: the two halves xored, then the two words of that xored.</summary>
    public static int JavaHashCode(Guid uuid) {
        byte[] bytes = uuid.ToByteArray(true);
        long most = System.Buffers.Binary.BinaryPrimitives.ReadInt64BigEndian(bytes.AsSpan(0, 8));
        long least = System.Buffers.Binary.BinaryPrimitives.ReadInt64BigEndian(bytes.AsSpan(8, 8));
        long hilo = most ^ least;
        return (int)(hilo >> 32) ^ (int)hilo;
    }

    private static int FloorMod(int x, int y) => ((x % y) + y) % y;

    private static PlayerSkin Create(string body, bool slim) => new($"minecraft:textures/{body}.png", null, null, slim, true);
}

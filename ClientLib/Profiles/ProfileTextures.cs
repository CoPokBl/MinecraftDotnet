using System.Text;
using Minecraft.Schemas;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientLib.Profiles;

/// <summary>authlib's <c>SignatureState</c>: whether a profile property carries a signature Mojang's keys accept.</summary>
public enum SignatureState {
    Unsigned,
    Invalid,
    Signed
}

/// <summary>authlib's <c>MinecraftProfileTexture</c>: one texture a profile names, by URL.</summary>
public sealed record ProfileTexture(string Url, IReadOnlyDictionary<string, string>? Metadata) {
    public string? GetMetadata(string key) => Metadata?.GetValueOrDefault(key);

    /// <summary><c>getHash</c>: the last segment of the URL's path, less any extension.</summary>
    public string Hash => Path.GetFileNameWithoutExtension(new Uri(Url).AbsolutePath);
}

/// <summary>authlib's <c>MinecraftProfileTextures</c>: what a profile's <c>textures</c> property names.</summary>
public sealed record ProfileTextures(ProfileTexture? Skin, ProfileTexture? Cape, ProfileTexture? Elytra, SignatureState SignatureState) {
    public static readonly ProfileTextures Empty = new(null, null, null, SignatureState.Signed);

    /// <summary><c>YggdrasilMinecraftSessionService.getPackedTextures</c>: the first property named <c>textures</c>.</summary>
    public static ProfileProperty? Packed(IEnumerable<ProfileProperty> properties) => properties.FirstOrDefault(p => p.Name == "textures");

    /// <summary>
    /// <c>YggdrasilMinecraftSessionService.unpackTextures</c>: the base64 JSON payload's textures, all of them
    /// dropped when any one's URL is not on <c>textures.minecraft.net</c>.
    /// </summary>
    public static ProfileTextures Unpack(ProfileProperty packed, SignatureState signatureState) {
        JObject? payload;
        try {
            payload = JsonConvert.DeserializeObject<JObject>(Encoding.UTF8.GetString(Convert.FromBase64String(packed.Value)));
        }
        catch (Exception e) when (e is FormatException or JsonException) {
            return Empty;
        }
        if (payload?["textures"] is not JObject textures || !textures.HasValues) {
            return Empty;
        }
        Dictionary<string, ProfileTexture> byType = new();
        foreach ((string type, JToken? value) in textures) {
            string? url = value?.Value<string>("url");
            if (url == null || !IsAllowedTextureDomain(url)) {
                return Empty;
            }
            Dictionary<string, string>? metadata = (value!["metadata"] as JObject)?.Properties()
                .ToDictionary(p => p.Name, p => p.Value.ToString());
            byType[type] = new ProfileTexture(url, metadata);
        }
        return new ProfileTextures(byType.GetValueOrDefault("SKIN"), byType.GetValueOrDefault("CAPE"), byType.GetValueOrDefault("ELYTRA"),
            signatureState);
    }

    /// <summary>
    /// <c>TextureUrlChecker.isAllowedTextureDomain</c>: http or https on <c>textures.minecraft.net</c>, written in
    /// lower case.
    /// </summary>
    public static bool IsAllowedTextureDomain(string url) =>
        Uri.TryCreate(url, UriKind.Absolute, out Uri? uri) && uri.Scheme is "http" or "https" && uri.Host == "textures.minecraft.net"
        // Uri lower cases the host it parses, where java.net.URI keeps it as written.
        && url.Contains(uri.Host, StringComparison.Ordinal);
}

using System.Text;
using Minecraft.Implementations.Utils;
using Newtonsoft.Json.Linq;

namespace Minecraft.Schemas;

public record PlayerSkin(string Textures, string Signature) {
    public string SkinUrl {
        get {
            JObject texturesObject = JObject.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(Textures)));
            return texturesObject["textures"]?["SKIN"]?["url"]?.ToString() ?? string.Empty;
        }
    }
    
    public string CapeUrl {
        get {
            JObject texturesObject = JObject.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(Textures)));
            return texturesObject["textures"]?["CAPE"]?["url"]?.ToString() ?? string.Empty;
        }
    }

    public static Task<PlayerSkin?> FromUuid(Guid uuid) {
        return SkinFetcher.GetPlayerSkin(uuid);
    }
    
    public static async Task<PlayerSkin?> FromUsername(string username) {
        Guid? uuid = await MojangProfileUtils.LookupUuid(username);
        if (uuid == null) {
            return null;
        }
        return await SkinFetcher.GetPlayerSkin(uuid.Value);
    }
}

using System.Text;
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
}

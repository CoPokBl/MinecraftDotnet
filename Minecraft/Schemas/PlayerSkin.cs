using System.Text;
using Minecraft.Implementations.Utils;
using Newtonsoft.Json.Linq;

namespace Minecraft.Schemas;

public record PlayerSkin(string Textures, string Signature) {
    private JObject ParsedTextures => field ??= JObject.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(Textures)));

    public string SkinUrl => ParsedTextures["textures"]?["SKIN"]?["url"]?.ToString() ?? string.Empty;
    public string CapeUrl => ParsedTextures["textures"]?["CAPE"]?["url"]?.ToString() ?? string.Empty;

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

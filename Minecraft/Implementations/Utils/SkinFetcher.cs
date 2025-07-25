using System.Net;
using Minecraft.Schemas;
using Newtonsoft.Json.Linq;

namespace Minecraft.Implementations.Utils;

public static class SkinFetcher {
    private const string FetchUrl = "https://sessionserver.mojang.com/session/minecraft/profile/";

    public static async Task<PlayerSkin?> GetPlayerSkin(Guid uuid) {
        HttpClient client = new();
        string url = $"{FetchUrl}{uuid:N}?unsigned=false";
        
        HttpResponseMessage response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode) {
            throw new Exception($"Failed to fetch skin for UUID {uuid}. Status code: {response.StatusCode}");
        }

        if (response.StatusCode == HttpStatusCode.NoContent) {
            return null;
        }
        
        string content = await response.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(content);
        
        string textures = json["properties"]?[0]?["value"]?.ToString()!;
        string signature = json["properties"]?[0]?["signature"]?.ToString()!;
        return new PlayerSkin(textures, signature);
    }
}

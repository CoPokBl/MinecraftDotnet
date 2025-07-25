using System.Net;
using Newtonsoft.Json.Linq;

namespace Minecraft.Implementations.Utils;

public static class MojangProfileUtils {
    private const string FromUsernameUrl = "https://api.minecraftservices.com/minecraft/profile/lookup/name/";

    public static async Task<Guid?> LookupUuid(string username) {
        HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync(FromUsernameUrl + username);

        if (response.StatusCode == HttpStatusCode.NotFound) {
            return null;
        }
        
        if (!response.IsSuccessStatusCode) {
            throw new Exception($"Failed to lookup UUID for username {username}. Status code: {response.StatusCode}");
        }
        
        string content = await response.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(content);
        string id = json["id"]!.ToString();
        return Guid.Parse(id);
    }
}

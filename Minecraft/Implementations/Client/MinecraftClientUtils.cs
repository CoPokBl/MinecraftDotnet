using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using Minecraft.Schemas;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Minecraft.Implementations.Client;

public static class MinecraftClientUtils {
    public const string HasJoinedUrl = "https://sessionserver.mojang.com/session/minecraft/hasJoined?username={username}&serverId={serverId}";
    public const string JoinUrl = "https://sessionserver.mojang.com/session/minecraft/join";

    public static async Task<ServerConnection> ConnectToServer(string host, int port = 25565) {
        TcpClient client = new();
        await client.ConnectAsync(host, port);
        TcpServerConnection con = new(client);
        _ = con.HandlePackets();
        return con;
    }

    public static async Task AuthenticateToJoin(string minecraftAuthToken, string uuid, string serverId, byte[] sharedSecret, byte[] serverPubKey) {
        string serverIdHash = MinecraftSha1(Encoding.UTF8.GetBytes(serverId).Concat(sharedSecret).Concat(serverPubKey).ToArray());

        HttpClient client = new();

        dynamic reqData = new {
            accessToken = minecraftAuthToken,
            selectedProfile = uuid,
            serverId = serverIdHash
        };
        
        string json = JsonConvert.SerializeObject(reqData);
        HttpResponseMessage resp = await client.PostAsync(JoinUrl, 
            new StringContent(json, Encoding.UTF8, "application/json"));

        if (!resp.IsSuccessStatusCode) {
            throw new Exception(
                $"Failed to authenticate to join server: {resp.StatusCode} - {await resp.Content.ReadAsStringAsync()}");
        }
        
        // done :)
        string responseBody = await resp.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
        Console.WriteLine("status: " + resp.StatusCode);
    }

    public static async Task<JoinedUserResponse> CheckClientAuthentication(string username, string serverId, byte[] sharedSecret, byte[] serverPubKey) {
        string serverIdHash = MinecraftSha1(Encoding.UTF8.GetBytes(serverId).Concat(sharedSecret).Concat(serverPubKey).ToArray());
        string url = HasJoinedUrl.Replace("{username}", username).Replace("{serverId}", serverIdHash);
        
        HttpClient client = new();
        HttpResponseMessage resp = await client.GetAsync(url);
        if (resp.StatusCode == HttpStatusCode.NoContent || !resp.IsSuccessStatusCode) {  // Failure
            throw new Exception(
                $"Failed to check if client has joined server: {resp.StatusCode} - {await resp.Content.ReadAsStringAsync()}");
        }
        
        string responseBody = await resp.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(responseBody);

        string id = json["id"]!.Value<string>().ThrowIfNull();
        string un = json["name"]!.Value<string>().ThrowIfNull();
        ProfileProperty[] props = json["properties"].ThrowIfNull()
            .ToObject<JArray>().ThrowIfNull()
            .Select(prop => new ProfileProperty {
                Name = prop.Value<string>("name").ThrowIfNull(),
                Value = prop.Value<string>("value").ThrowIfNull(),
                Signature = prop.Value<string>("signature")
            }).ToArray();
        
        return new JoinedUserResponse(id, un, props);
    }
    
    // From: https://gist.github.com/ammaraskar/7b4a3f73bee9dc4136539644a0f27e63
    public static string MinecraftSha1(byte[] data) {
        byte[] hash = SHA1.HashData(data);
        // Reverse the bytes since BigInteger uses little endian
        Array.Reverse(hash);
        
        BigInteger b = new(hash);
        // very annoyingly, BigInteger in C# tries to be smart and puts in
        // a leading 0 when formatting as a hex number to allow roundtripping 
        // of negative numbers, thus we have to trim it off.
        if (b < 0) {
            // toss in a negative sign if the interpreted number is negative
            return "-" + (-b).ToString("x").TrimStart('0');
        }

        return b.ToString("x").TrimStart('0');
    }

    public record JoinedUserResponse(string Id, string Username, ProfileProperty[] Properties);
}

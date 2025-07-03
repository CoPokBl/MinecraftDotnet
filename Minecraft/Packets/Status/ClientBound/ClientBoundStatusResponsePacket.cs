using Minecraft.NBT;
using Minecraft.NBT.Text;
using Minecraft.Schemas;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Minecraft.Packets.Status.ClientBound;

public class ClientBoundStatusResponsePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:status_response";
    
    public bool? PreventsChatReports;
    public bool? EnforcesSecureChat;
    public string? FavIcon;
    public TextComponent? Description;
    public SamplePlayer[]? SamplePlayers;
    public required int OnlinePlayers;
    public required int MaxPlayers;
    public required int VersionProtocol;
    public required string VersionName;

    public string ToJson() {
        JObject data = new() {
            ["version"] = new JObject {
                ["name"] = VersionName,
                ["protocol"] = VersionProtocol
            },
            ["players"] = new JObject {
                ["max"] = MaxPlayers,
                ["online"] = OnlinePlayers
            }
        };

        if (SamplePlayers != null) {
            data["players"]!["sample"] = new JArray(SamplePlayers.Select<SamplePlayer, JObject>(p => new JObject {
                ["name"] = p.Name,
                ["id"] = p.Uuid
            }).ToArray<object>());
        }
        
        if (Description != null) {
            data["description"] = Description.ToJson();
        }
        
        if (FavIcon != null) {
            data["favicon"] = FavIcon;
        }
        
        if (EnforcesSecureChat.HasValue) {
            data["enforcesSecureChat"] = EnforcesSecureChat.Value;
        }
        
        if (PreventsChatReports.HasValue) {
            data["preventsChatReports"] = PreventsChatReports.Value;
        }

        return JsonConvert.SerializeObject(data);
    }

    protected override byte[] GetData() {
        string json = ToJson();
        DataWriter w = new();
        w.WriteString(json);
        return w.ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        string json = r.ReadString();
        JObject obj = JsonConvert.DeserializeObject<JObject>(json)!;
        
        // required (by notchian client)
        ClientBoundStatusResponsePacket packet = new() {
            VersionName = obj["version"]!["name"]!.ToObject<string>()!,
            VersionProtocol = obj["version"]!["protocol"]!.ToObject<int>(),
            MaxPlayers = obj["players"]!["max"]!.ToObject<int>(),
            OnlinePlayers = obj["players"]!["online"]!.ToObject<int>()
        };

        if (obj["players"]!["sample"] != null) {
            List<SamplePlayer> players = [];
            foreach (JToken sampleT in obj["players"]!["sample"]!.ToObject<JArray>()!) {
                if (sampleT.Type != JTokenType.Object) {
                    throw new JsonException("Expected 'sample' to be an array of objects.");
                }
                JObject sample = sampleT.ToObject<JObject>()!;
                players.Add(new SamplePlayer(sample["name"]!.ToObject<string>()!, sample["id"]!.ToObject<string>()!));
            }
            packet.SamplePlayers = players.ToArray();
        }
        
        if (obj.TryGetValue("description", out JToken? value)) {
            packet.Description = TextComponent.FromTag(INbtTag.FromJson(null, value));
        }

        if (obj.TryGetValue("favicon", out JToken? favicon)) {
            packet.FavIcon = favicon.ToObject<string>();
        }

        if (obj.TryGetValue("enforcesSecureChat", out JToken? enfSecChat)) {
            packet.EnforcesSecureChat = enfSecChat.ToObject<bool>();
        }

        if (obj.TryGetValue("preventsChatReports", out JToken? preChatRep)) {
            packet.PreventsChatReports = preChatRep.ToObject<bool>();
        }
        
        return packet;
    };
}

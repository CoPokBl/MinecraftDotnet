using Minecraft.Schemas;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Minecraft.Packets.Status.ClientBound;

public class ClientBoundStatusResponsePacket : ClientBoundPacket {
    public bool? PreventsChatReports;
    public bool? EnforcesSecureChat;
    public string? FavIcon;
    public string? Description;
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
            data["description"] = new JObject {
                ["text"] = Description
            };
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
    
    public static readonly PacketDataDeserialiser Deserialiser = r => {
        string json = r.ReadString();
        dynamic obj = JsonConvert.DeserializeObject<dynamic>(json)!;
        
        // required (by notchian client)
        ClientBoundStatusResponsePacket packet = new() {
            VersionName = obj.version.name,
            VersionProtocol = obj.version.protocol,
            MaxPlayers = obj.players.max,
            OnlinePlayers = obj.players.online
        };

        if (obj.players.sample != null) {
            List<SamplePlayer> players = [];
            foreach (dynamic sample in obj.players.sample) {
                players.Add(new SamplePlayer((string)sample.name, (string)sample.id));
            }
            packet.SamplePlayers = players.ToArray();
        }

        // TODO: This doesn't handle all text component formats
        // make TextComponent.FromJson(string or JValue) to correctly
        // parse it.
        if (obj.description?.text != null) {
            packet.Description = obj.description.text;
        }

        if (obj.favicon != null) {
            packet.FavIcon = obj.favicon;
        }

        if (obj.enforcesSecureChat != null) {
            packet.EnforcesSecureChat = obj.enforcesSecureChat;
        }

        if (obj.preventsChatReports != null) {
            packet.PreventsChatReports = obj.preventsChatReports;
        }
        
        return packet;
    };
}

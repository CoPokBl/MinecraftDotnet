using Minecraft.Schemas;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Minecraft.Packets.Status.ClientBound;

public class ClientBoundStatusResponsePacket(
    string versionName, 
    int versionProtocol, 
    int maxPlayers, 
    int onlinePlayers, 
    SamplePlayer[]? samplePlayers = null, 
    string? description = null, 
    string? favIcon = null, 
    bool? enforcesSecureChat = null, 
    bool? preventsChatReports = null) : MinecraftPacket {
    
    public bool? PreventsChatReports = preventsChatReports;
    public bool? EnforcesSecureChat = enforcesSecureChat;
    public string? FavIcon = favIcon;
    public string? Description = description;
    public SamplePlayer[]? SamplePlayers = samplePlayers;
    public int OnlinePlayers = onlinePlayers;
    public int MaxPlayers = maxPlayers;
    public int VersionProtocol = versionProtocol;
    public string VersionName = versionName;

    public ClientBoundStatusResponsePacket() : this("dotnet", -1, 1, 1) { }
    
    public override int GetPacketId() {
        return 0x00;
    }

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

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        string json = r.ReadString();

        dynamic obj = JsonConvert.DeserializeObject<dynamic>(json)!;
        
        // required (by notchian client)
        VersionName = obj.version.name;
        VersionProtocol = obj.version.protocol;
        MaxPlayers = obj.players.max;
        OnlinePlayers = obj.players.online;

        if (obj.players.sample != null) {
            List<SamplePlayer> players = new();
            foreach (dynamic sample in obj.players.sample) {
                players.Add(new SamplePlayer((string)sample.name, (string)sample.id));
            }
            SamplePlayers = players.ToArray();
        }

        // TODO: This doesn't handle all text component formats
        // make TextComponent.FromJson(string or JValue) to correctly
        // parse it.
        if (obj.description?.text != null) {
            Description = obj.description.text;
        }

        if (obj.favicon != null) {
            FavIcon = obj.favicon;
        }

        if (obj.enforcesSecureChat != null) {
            EnforcesSecureChat = obj.enforcesSecureChat;
        }

        if (obj.preventsChatReports != null) {
            PreventsChatReports = obj.preventsChatReports;
        }

        return this;
    }
}
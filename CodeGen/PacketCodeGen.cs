using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen;

public static class PacketCodeGen {
    private const string IdentSearch = "Identifier Identifier => \"";

    public static string CreatePacketEntries(JObject registriesJson) {
        StringBuilder entries = new();
        JObject packetsJson = JObject.Parse(CodeGenUtils.ReadVanillaDataFile("reports", "packets.json"));
        
        // <clientBound, state, identifier, protocolId>
        Dictionary<bool, Dictionary<string, Dictionary<string, int>>> packetIds = new();
        
        LoadPacketSet(packetsJson["handshake"]!["serverbound"]!.ToObject<JObject>()!, "handshake", false);
        LoadPacketSet(packetsJson["configuration"]!["clientbound"]!.ToObject<JObject>()!, "configuration", true);
        LoadPacketSet(packetsJson["configuration"]!["serverbound"]!.ToObject<JObject>()!, "configuration", false);
        LoadPacketSet(packetsJson["login"]!["clientbound"]!.ToObject<JObject>()!, "login", true);
        LoadPacketSet(packetsJson["login"]!["serverbound"]!.ToObject<JObject>()!, "login", false);
        LoadPacketSet(packetsJson["play"]!["clientbound"]!.ToObject<JObject>()!, "play", true);
        LoadPacketSet(packetsJson["play"]!["serverbound"]!.ToObject<JObject>()!, "play", false);
        LoadPacketSet(packetsJson["status"]!["clientbound"]!.ToObject<JObject>()!, "status", true);
        LoadPacketSet(packetsJson["status"]!["serverbound"]!.ToObject<JObject>()!, "status", false);
        
        // We should have all the packets, now to scan for actual packet implementation files
        Dictionary<bool, Dictionary<string, string>> packetClasses = new();  // map of clientBound? to map of packet identifier to class name
        string packetsFolder = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "Packets");
        LoadPacketClasses(Path.Combine(packetsFolder, "Handshake"), false);
        LoadDoublePacketEntries("Config");
        LoadDoublePacketEntries("Login");
        LoadDoublePacketEntries("Play");
        LoadDoublePacketEntries("Status");
        
        // Cool, we have all our classes, let's see how many we can match up
        foreach (KeyValuePair<bool, Dictionary<string, Dictionary<string, int>>> boundnessSet in packetIds) {
            bool clientBound = boundnessSet.Key;
            foreach (KeyValuePair<string, Dictionary<string, int>> stateSet in boundnessSet.Value) {
                string state = stateSet.Key;
                foreach (KeyValuePair<string, int> packetEntry in stateSet.Value) {
                    string identifier = packetEntry.Key;
                    int protocolId = packetEntry.Value;

                    if (!packetClasses[clientBound].TryGetValue(identifier, out string? className)) {
                        Console.WriteLine($"Warning: Class for packet: {identifier}, was not found");
                        continue;
                    }
                    
                    // We have it
                    string stateEnumVal = state switch {
                        "handshake" => "None",
                        "configuration" => "Configuration",
                        "login" => "Login",
                        "play" => "Play",
                        "status" => "Status",
                        _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
                    };
                    
                    // Add entry for this net id
                    // some classes may be added multiple times, that's expected
                    entries.Append($"{CodeGenUtils.GetIndentation(2)}Data.Packets.Add(ConnectionState.{stateEnumVal}, " +
                                   $"{clientBound.ToString().ToLower()}, " +
                                   $"0x{protocolId.ToString("X2")}, " +
                                   $"typeof({className}), " +
                                   $"{className}.Deserialiser);\n");
                }
            }
        }
        
        return entries.ToString();

        // LOCAL FUNCTIONS
        void LoadPacketSet(JObject packetSet, string state, bool clientBound) {
            if (!packetIds.TryGetValue(clientBound, out  Dictionary<string, Dictionary<string, int>>? vals)) {
                vals = new Dictionary<string, Dictionary<string, int>>();
                packetIds.Add(clientBound, vals);
            }
            if (!vals.TryGetValue(state, out Dictionary<string, int>? protocolIds)) {
                protocolIds = new Dictionary<string, int>();
                vals.Add(state, protocolIds);
            }

            foreach (KeyValuePair<string, JToken?> packet in packetSet) {
                string id = packet.Key;
                int protocolId = packet.Value!["protocol_id"]!.Value<int>();
                
                protocolIds.Add(id, protocolId);
            }

            entries.Append('\n');
        }

        void LoadDoublePacketEntries(string stateFolder) {
            LoadPacketClasses(Path.Combine(packetsFolder, stateFolder, "ClientBound"), true);
            LoadPacketClasses(Path.Combine(packetsFolder, stateFolder, "ServerBound"), false);
        }
        
        void LoadPacketClasses(string directory, bool clientBound) {
            string[] files = Directory.GetFiles(directory, "*.cs", SearchOption.AllDirectories);

            foreach (string file in files) {
                string fileContent = File.ReadAllText(file);
                string className = Path.GetFileNameWithoutExtension(file);

                string? identifier = CodeGenUtils.GetIdentifier(fileContent);
                if (identifier == null) {
                    Console.WriteLine("Skipping file without Identifier: " + file);
                    continue;
                }

                if (!packetClasses.TryGetValue(clientBound, out Dictionary<string, string>? vals)) {
                    vals = new Dictionary<string, string>();
                    packetClasses.Add(clientBound, vals);
                }
                vals.Add(identifier, className);
            }
        }
    }
}
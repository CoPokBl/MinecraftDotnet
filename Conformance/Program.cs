using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Conformance;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;

// Writes every client bound packet we implement to a corpus file, which Harness.java then
// feeds through the vanilla stream codecs. See Conformance/run.sh.

string outputPath = args.Length > 0 ? args[0] : "corpus.json";

ConnectionState[] states = [ConnectionState.Login, ConnectionState.Configuration, ConnectionState.Play];
List<string> entries = [];
List<string> skipped = [];
int built = 0;

foreach (Type type in VanillaRegistry.Data.Packets.GetPacketTypes(true).OrderBy(t => t.Name)) {
    ConnectionState? state = null;
    foreach (ConnectionState candidate in states) {
        try {
            _ = VanillaRegistry.Data.Packets[candidate, type];
            state = candidate;
            break;
        }
        catch (KeyNotFoundException) {
            // registered in a different state
        }
    }

    if (state == null) {
        skipped.Add($"{type.Name}: not registered in login/configuration/play");
        continue;
    }

    if (RichSamples.Covered.Contains(type)) {
        continue;  // built by hand below
    }

    MinecraftPacket packet;
    try {
        packet = SampleBuilder.Build(type);
    }
    catch (Exception ex) {
        // Packets carrying types we can't fabricate a value for. Worth a sample by hand if
        // one of them ever turns out to matter.
        skipped.Add($"{type.Name}: cannot build sample ({ex.Message})");
        continue;
    }

    byte[] framed;
    try {
        framed = packet.Serialise(state.Value);
    }
    catch (Exception ex) {
        skipped.Add($"{type.Name}: serialise threw ({ex.GetType().Name}: {ex.Message})");
        continue;
    }

    // The vanilla codec wants the packet id and body, without our length prefix
    DataReader reader = new(framed);
    reader.ReadVarInt();
    byte[] body = reader.Read((int)(reader.Length - reader.Position));

    entries.Add(Entry(state.Value, type.Name, body));
    built++;
}

// Entity metadata gets a packet per field type, since the value has to match the type id
// written next to it and reflection has no way to know that
foreach ((string name, string serialiser, MinecraftPacket packet) in MetaSamples.Build()) {
    try {
        DataReader reader = new(packet.Serialise(ConnectionState.Play));
        reader.ReadVarInt();
        entries.Add(Entry(ConnectionState.Play, name,
            reader.Read((int)(reader.Length - reader.Position)), serialiser));
        built++;
    }
    catch (Exception ex) {
        skipped.Add($"{name}: {ex.GetType().Name}: {ex.Message}");
    }
}

foreach (MetaFieldType uncovered in MetaSamples.Uncovered()) {
    skipped.Add($"ClientBoundSetEntityMetadataPacket[{uncovered}]: no sample in MetaSamples");
}

// Packets hanging off an abstract type, or a union whose tag has to match its payload
foreach ((string name, MinecraftPacket packet) in RichSamples.Build()) {
    try {
        DataReader reader = new(packet.Serialise(ConnectionState.Play));
        reader.ReadVarInt();
        entries.Add(Entry(ConnectionState.Play, name,
            reader.Read((int)(reader.Length - reader.Position))));
        built++;
    }
    catch (Exception ex) {
        skipped.Add($"{name}: {ex.GetType().Name}: {ex.Message}");
    }
}

// Chunks likewise: the section format is bit packed, so a fabricated one proves nothing
foreach ((string name, MinecraftPacket packet) in ChunkSamples.Build()) {
    try {
        DataReader reader = new(packet.Serialise(ConnectionState.Play));
        reader.ReadVarInt();
        entries.Add(Entry(ConnectionState.Play, name,
            reader.Read((int)(reader.Length - reader.Position)),
            sections: ChunkSamples.SectionCount));
        built++;
    }
    catch (Exception ex) {
        skipped.Add($"{name}: {ex.GetType().Name}: {ex.Message}");
    }
}

StringBuilder json = new();
json.AppendLine("[");
json.AppendLine(string.Join(",\n", entries));
json.AppendLine("]");
File.WriteAllText(outputPath, json.ToString());

Console.WriteLine($"Wrote {built} packets to {outputPath}");
if (skipped.Count > 0) {
    Console.WriteLine($"Skipped {skipped.Count}:");
    foreach (string reason in skipped) {
        Console.WriteLine($"  {reason}");
    }
}

return;

static string Entry(ConnectionState state, string name, byte[] body, string? serialiser = null,
    int? sections = null) {

    string extra = serialiser == null ? "" : $", \"serialiser\": \"{serialiser}\"";
    extra += sections == null ? "" : $", \"sections\": {sections}";
    return $"  {{\"state\": \"{state}\", \"name\": \"{name}\", " +
           $"\"hex\": \"{Convert.ToHexString(body).ToLowerInvariant()}\"{extra}}}";
}

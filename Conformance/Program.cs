using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Conformance;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using NBT;

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
foreach ((string name, MinecraftPacket packet, ChunkProbe[] probes) in ChunkSamples.Build()) {
    try {
        DataReader reader = new(packet.Serialise(ConnectionState.Play));
        reader.ReadVarInt();
        entries.Add(Entry(ConnectionState.Play, name,
            reader.Read((int)(reader.Length - reader.Position)),
            sections: ChunkSamples.SectionCount, probes: probes));
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

// Heightmap scenes, for Conformance/heightmap.sh. Separate from the packet corpus because what is
// being checked is not a wire format but the three predicates behind the numbers, which only the
// real Heightmap.primeHeightmaps can settle.
int heightmapArg = Array.IndexOf(args, "--heightmaps");
if (heightmapArg >= 0 && heightmapArg + 1 < args.Length) {
    File.WriteAllText(args[heightmapArg + 1], HeightmapSamples.BuildJson());
    Console.WriteLine($"Wrote {HeightmapSamples.SceneCount} heightmap scenes to {args[heightmapArg + 1]}");
}

// The datapack driven registries travel as NBT the client parses with the element codec rather
// than a stream codec, so decoding the packet they arrive in proves nothing about them.
// RegistryHarness.java runs those codecs. See Conformance/registries.sh.
// Skips a flag, so that a second positional really is a path: otherwise a mode like "--heightmaps"
// is taken as one and the registry corpus is written to a file of that name.
if (args.Length > 1 && !args[1].StartsWith("--")) {
    List<string> registries = [];
    int elements = 0;
    foreach (ISubRegistry sub in VanillaRegistry.Data.SubRegistries) {
        if (sub is not INbtSerialisableRegistry serialisable) {
            continue;
        }

        List<string> written = [];
        foreach ((string id, INbtTag element) in serialisable.ToNbt()) {
            written.Add($"    \"{id}\": {INbtTag.ToJsonString(element)}");
            elements++;
        }

        registries.Add($"  \"{sub.RegistryId}\": {{\n{string.Join(",\n", written)}\n  }}");
    }

    File.WriteAllText(args[1], "{\n" + string.Join(",\n", registries) + "\n}\n");
    Console.WriteLine($"Wrote {elements} elements across {registries.Count} registries to {args[1]}");
}
if (skipped.Count > 0) {
    Console.WriteLine($"Skipped {skipped.Count}:");
    foreach (string reason in skipped) {
        Console.WriteLine($"  {reason}");
    }
}

return;

static string Entry(ConnectionState state, string name, byte[] body, string? serialiser = null,
    int? sections = null, ChunkProbe[]? probes = null) {

    string extra = serialiser == null ? "" : $", \"serialiser\": \"{serialiser}\"";
    extra += sections == null ? "" : $", \"sections\": {sections}";

    // Positions the harness reads back out of the decoded section with vanilla's own getBlockState.
    // Without these a chunk sample only proves the blob is the right length.
    if (probes is { Length: > 0 }) {
        extra += ", \"probes\": [" + string.Join(", ", probes.Select(pr =>
            $"{{\"section\": {pr.Section}, \"x\": {pr.X}, \"y\": {pr.Y}, \"z\": {pr.Z}, " +
            $"\"state\": {pr.StateId}}}")) + "]";
    }
    return $"  {{\"state\": \"{state}\", \"name\": \"{name}\", " +
           $"\"hex\": \"{Convert.ToHexString(body).ToLowerInvariant()}\"{extra}}}";
}

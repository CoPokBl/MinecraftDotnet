using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Sends timing samples to the client's tick profiler.</summary>
public class ClientBoundDebugSamplePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:debug_sample";

    /// <summary>The measurements, in nanoseconds. Their meaning depends on <see cref="SampleType"/>.</summary>
    public required long[] Sample { get; init; }

    public required DebugSampleType SampleType { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePrefixedArray(Sample, (value, writer) => writer.WriteLong(value))
            .WriteVarInt((int)SampleType);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundDebugSamplePacket {
        Sample = r.ReadPrefixedArray(reader => reader.ReadLong()),
        SampleType = (DebugSampleType)r.ReadVarInt()
    };

    public enum DebugSampleType {
        TickTime = 0
    }
}

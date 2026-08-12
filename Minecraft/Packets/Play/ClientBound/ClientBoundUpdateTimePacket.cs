using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateTimePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_time";

    /// <summary>How long the world has existed, in ticks.</summary>
    public required long GameTime { get; init; }

    /// <summary>
    /// The clocks whose state changed. Time of day lives here as of 26.2 rather than in the
    /// packet itself, so a client that gets no entry for a clock keeps running its own.
    /// </summary>
    public required ClockUpdate[] ClockUpdates { get; init; }

    /// <param name="ClockId">Protocol id in the <c>minecraft:world_clock</c> registry.</param>
    /// <param name="TotalTicks">The clock's reading, which for the overworld clock is the time of day.</param>
    /// <param name="PartialTick">Sub tick offset, for interpolation.</param>
    /// <param name="Rate">Ticks the clock advances per game tick. Zero freezes it.</param>
    public readonly record struct ClockUpdate(int ClockId, long TotalTicks, float PartialTick, float Rate);

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteLong(GameTime)
            .WritePrefixedArray(ClockUpdates, (update, writer) => writer
                .WriteVarInt(update.ClockId)
                .WriteVarLong(update.TotalTicks)
                .WriteFloat(update.PartialTick)
                .WriteFloat(update.Rate));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUpdateTimePacket {
        GameTime = r.ReadLong(),
        ClockUpdates = r.ReadPrefixedArray(reader => new ClockUpdate(
            reader.ReadVarInt(),
            reader.ReadVarLong(),
            reader.ReadFloat(),
            reader.ReadFloat()))
    };
}

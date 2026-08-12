using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Plays one of the client's hardcoded effects, such as a door opening or a block breaking.
/// The meaning of <see cref="Data"/> depends on the event.
/// </summary>
public class ClientBoundWorldEventPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:level_event";

    public required int Event { get; init; }
    public required Vec3<int> Location { get; init; }
    public required int Data { get; init; }

    /// <summary>Plays the event regardless of distance, and ignores the client's volume settings.</summary>
    public required bool DisableRelativeVolume { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteInteger(Event)
            .WritePosition(Location)
            .WriteInteger(Data)
            .WriteBoolean(DisableRelativeVolume);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundWorldEventPacket {
        Event = r.ReadInteger(),
        Location = r.ReadPosition(),
        Data = r.ReadInteger(),
        DisableRelativeVolume = r.ReadBoolean()
    };
}

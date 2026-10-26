using Minecraft.Schemas;
using NBT;

namespace Minecraft.Packets.Config.ServerBound;

/// <summary>
/// Sent when the player activates a <c>minecraft:dynamic/custom</c> dialog action. Sent in both
/// the configuration and play states.
/// </summary>
public class ServerBoundCustomClickActionPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:custom_click_action";

    public required Identifier Id { get; init; }

    /// <summary>The dialog's collected inputs, or null when the action carries no payload.</summary>
    public INbtTag? Payload { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        // The payload is length prefixed, and an absent one is written as a bare END tag.
        byte[] payload = Payload?.Serialise() ?? [0];
        return w.WriteString(Id)
                .WriteVarInt(payload.Length)
                .Write(payload);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        Identifier id = r.ReadString();
        byte[] payload = r.Read(r.ReadVarInt());
        return new ServerBoundCustomClickActionPacket {
            Id = id,
            Payload = payload.Length != 0 && payload[0] != 0 ? new DataReader(payload).ReadNbt() : null
        };
    };
}

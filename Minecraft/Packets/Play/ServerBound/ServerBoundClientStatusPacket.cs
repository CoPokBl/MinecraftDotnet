using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundClientStatusPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:client_command";
    
    public required StatusAction Action { get; init; }

    public enum StatusAction {
        Respawn = 0,
        RequestStats = 1
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt((int)Action);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundClientStatusPacket {
        Action = (StatusAction)r.ReadVarInt()
    };
}

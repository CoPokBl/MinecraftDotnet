using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundClientStatusPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:client_command";
    
    public required StatusAction Action;

    public enum StatusAction {
        Respawn = 0,
        RequestStats = 1
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt((int)Action)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundClientStatusPacket {
        Action = (StatusAction)r.ReadVarInt()
    };
}

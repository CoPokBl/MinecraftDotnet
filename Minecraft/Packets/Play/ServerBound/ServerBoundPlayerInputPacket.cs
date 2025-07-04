using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPlayerInputPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:player_input";
    
    public required Input Flags;

    [Flags]
    public enum Input {
        Forward = 0x01,
        Backward = 0x02,
        Left = 0x04,
        Right = 0x08,
        Jump = 0x10,
        Sneak = 0x20,
        Sprint = 0x40
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteUnsignedByte((byte)Flags);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPlayerInputPacket {
        Flags = (Input)r.Read()
    };
}

using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundChatCommandPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:chat_command";

    public required string Command { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteString(Command);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundChatCommandPacket {
        Command = r.ReadString()
    };
}

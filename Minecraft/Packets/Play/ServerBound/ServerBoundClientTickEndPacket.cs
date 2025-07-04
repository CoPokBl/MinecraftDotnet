using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundClientTickEndPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:client_tick_end";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundClientTickEndPacket();
}

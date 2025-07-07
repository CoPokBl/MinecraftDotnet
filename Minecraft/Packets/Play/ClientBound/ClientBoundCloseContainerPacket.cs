using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundCloseContainerPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:container_close";

    // disregarded by the client
    public required int WindowId;
    
    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(WindowId);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (reader, _) => new ClientBoundCloseContainerPacket {
        WindowId = reader.ReadVarInt()
    };
}

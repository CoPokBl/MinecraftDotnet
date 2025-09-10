using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundCloseContainerPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:container_close";
    
    public required int WindowId { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(WindowId);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundCloseContainerPacket {
        WindowId = r.ReadVarInt()
    };
}

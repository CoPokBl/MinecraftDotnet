using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetHealthPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_health";
    
    public required float Health { get; init; }
    public required int Food { get; init; }
    public required float Saturation { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteFloat(Health)
            .WriteVarInt(Food)
            .WriteFloat(Saturation);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetHealthPacket {
        Health = r.ReadFloat(),
        Food = r.ReadVarInt(),
        Saturation = r.ReadFloat()
    };
}

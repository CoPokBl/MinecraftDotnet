using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetHealthPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_health";
    
    public required float Health;
    public required int Food;
    public required float Saturation;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteFloat(Health)
            .WriteVarInt(Food)
            .WriteFloat(Saturation)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetHealthPacket {
        Health = r.ReadFloat(),
        Food = r.ReadVarInt(),
        Saturation = r.ReadFloat()
    };
}

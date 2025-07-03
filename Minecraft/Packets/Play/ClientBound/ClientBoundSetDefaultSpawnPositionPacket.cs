using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetDefaultSpawnPositionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_default_spawn_position";
    
    public required BlockPosition Location;
    public required Angle Angle;

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePosition(Location)
            .WriteFloat(Angle.DegreesF)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetDefaultSpawnPositionPacket {
        Location = r.ReadPosition(),
        Angle = r.ReadFloat()
    };
}

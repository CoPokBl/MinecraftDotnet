using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetDefaultSpawnPositionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_default_spawn_position";
    
    public required BlockPosition Location;
    public required Angle Angle;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePosition(Location)
            .WriteFloat(Angle.DegreesF);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetDefaultSpawnPositionPacket {
        Location = r.ReadPosition(),
        Angle = r.ReadFloat()
    };
}

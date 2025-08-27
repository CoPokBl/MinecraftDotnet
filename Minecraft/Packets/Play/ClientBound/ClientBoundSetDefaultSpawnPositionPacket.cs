using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetDefaultSpawnPositionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_default_spawn_position";
    
    public required Vec3<int> Location { get; init; }
    public required Angle Angle { get; init; }

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

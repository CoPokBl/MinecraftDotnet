using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundResetScorePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:reset_score";
    
    public required string EntityName { get; init; }
    public string? ObjectiveName { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(EntityName)
            .WritePrefixedOptional(ObjectiveName, (s, wr) => wr.WriteString(s));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundResetScorePacket {
        EntityName = r.ReadString(),
        ObjectiveName = r.ReadPrefixedOptional(r2 => r2.ReadString())
    };
}

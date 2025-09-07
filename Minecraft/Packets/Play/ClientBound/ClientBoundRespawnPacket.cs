using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundRespawnPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:respawn";
    
    public required int DimensionType { get; init; }
    public required Identifier DimensionName { get; init; }
    public required long HashedSeed { get; init; }
    public required GameMode GameMode { get; init; }
    public required GameMode PreviousGameMode { get; init; }
    public required bool IsDebug { get; init; }
    public required bool IsFlat { get; init; }
    public DeathLocation? Location;
    public required int PortalCooldown { get; init; }
    public required int SeaLevel { get; init; }
    public required DataKeptTypes DataKept { get; init; }

    [Flags]
    public enum DataKeptTypes {
        Attributes = 0x01,
        Metadata = 0x02,
        
        All = Attributes | Metadata,
        None = 0x00
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(DimensionType)
            .WriteString(DimensionName)
            .WriteLong(HashedSeed)
            .WriteUnsignedByte((byte)GameMode)
            .WriteByte((int)PreviousGameMode)
            .WriteBoolean(IsDebug)
            .WriteBoolean(IsFlat)
            .WritePrefixedOptional(Location, (location, writer) => writer
                .WriteString(location.Dimension)
                .WritePosition(location.Position))
            .WriteVarInt(PortalCooldown)
            .WriteVarInt(SeaLevel)
            .WriteUnsignedByte((byte)DataKept);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundRespawnPacket {
        DimensionType = r.ReadVarInt(),
        DimensionName = r.ReadString(),
        HashedSeed = r.ReadLong(),
        GameMode = (GameMode)r.Read(),
        PreviousGameMode = (GameMode)r.ReadByte(),
        IsDebug = r.ReadBoolean(),
        IsFlat = r.ReadBoolean(),
        Location = r.ReadPrefixedOptional(re => 
            new DeathLocation(re.ReadString(), re.ReadPosition())),
        PortalCooldown = r.ReadVarInt(),
        SeaLevel = r.ReadVarInt(),
        DataKept = (DataKeptTypes)r.Read()
    };
}

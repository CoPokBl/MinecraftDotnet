using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundRespawnPacket : ClientBoundPacket {
    public required int DimensionType;
    public required string DimensionName;
    public required long HashedSeed;
    public required GameMode GameMode;
    public required GameMode PreviousGameMode;
    public required bool IsDebug;
    public required bool IsFlat;
    public DeathLocation? Location;
    public required int PortalCooldown;
    public required int SeaLevel;
    public required DataKeptTypes DataKept;

    [Flags]
    public enum DataKeptTypes {
        Attributes = 0x01,
        Metadata = 0x02,
        
        All = Attributes | Metadata,
        None = 0x00
    }

    protected override byte[] GetData() {
        return new DataWriter()
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
            .WriteUnsignedByte((byte)DataKept)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundRespawnPacket {
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

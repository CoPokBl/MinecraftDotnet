using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundRespawnPacket(
    int dimensionType,
    string dimensionName,
    long hashedSeed,
    GameMode gameMode,
    GameMode previousGameMode,
    bool isDebug,
    bool isFlat,
    DeathLocation? deathLocation,
    int portalCooldown,
    int seaLevel,
    ClientBoundRespawnPacket.DataKeptTypes dataKept) : MinecraftPacket {
    
    public int DimensionType = dimensionType;
    public string DimensionName = dimensionName;
    public long HashedSeed = hashedSeed;
    public GameMode GameMode = gameMode;
    public GameMode PreviousGameMode = previousGameMode;
    public bool IsDebug = isDebug;
    public bool IsFlat = isFlat;
    public DeathLocation? Location = deathLocation;
    public int PortalCooldown = portalCooldown;
    public int SeaLevel = seaLevel;
    public DataKeptTypes DataKept = dataKept;

    public ClientBoundRespawnPacket() : this(0, "", 0, 0, 0, false, false, null, 0, 0, DataKeptTypes.None) { }

    [Flags]
    public enum DataKeptTypes {
        Attributes = 0x01,
        Metadata = 0x02,
        
        All = Attributes | Metadata,
        None = 0x00
    }

    public override int GetPacketId() {
        return 0x4B;
    }

    protected override byte[] GetData() {
        DataWriter w = new DataWriter()
            .WriteVarInt(DimensionType)
            .WriteString(DimensionName)
            .WriteLong(HashedSeed)
            .WriteUnsignedByte((byte)GameMode)
            .WriteByte((int)PreviousGameMode)
            .WriteBoolean(IsDebug)
            .WriteBoolean(IsFlat);

        if (Location == null) {
            w.WriteBoolean(false);
        }
        else {
            w.WriteBoolean(true)
                .WriteString(Location.Dimension)
                .WritePosition(Location.Position);
        }
        
        w.WriteVarInt(PortalCooldown)
            .WriteVarInt(SeaLevel)
            .WriteUnsignedByte((byte)DataKept);
        
        return w.ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        DimensionType = r.ReadVarInt();
        DimensionName = r.ReadString();
        HashedSeed = r.ReadLong();
        GameMode = (GameMode)r.Read();
        PreviousGameMode = (GameMode)r.ReadByte();
        IsDebug = r.ReadBoolean();
        IsFlat = r.ReadBoolean();
        if (r.ReadBoolean()) {
            Location = new DeathLocation(
                r.ReadString(),
                r.ReadPosition()
            );
        }
        else {
            Location = null;
        }
        PortalCooldown = r.ReadVarInt();
        SeaLevel = r.ReadVarInt();
        DataKept = (DataKeptTypes)r.Read();
        return this;
    }
}
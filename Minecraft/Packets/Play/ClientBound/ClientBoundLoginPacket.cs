using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundLoginPacket(
    int entityId,
    bool isHardcore,
    string[] dimensions,
    int maxPlayers,
    int viewDistance,
    int simulationDistance,
    bool reducedDebugInfo,
    bool enableRespawnScreen,
    bool doLimitedCrafting,
    int dimensionType,
    string dimensionName,
    long hashedSeed,
    byte gameMode,
    byte previousGameMode,
    bool isDebug,
    bool isFlat,
    DeathLocation? deathLocation,
    int portalCooldown,
    int seaLevel,
    bool enforcesSecureChat) : MinecraftPacket {
    
    public bool EnforcesSecureChat = enforcesSecureChat;
    public int SeaLevel = seaLevel;
    public int PortalCooldown = portalCooldown;
    public DeathLocation? Location = deathLocation;
    public bool IsFlat = isFlat;
    public bool IsDebug = isDebug;
    public byte PreviousGameMode = previousGameMode;
    public byte GameMode = gameMode;
    public long HashedSeed = hashedSeed;
    public string DimensionName = dimensionName;
    public int DimensionType = dimensionType;
    public bool DoLimitedCrafting = doLimitedCrafting;
    public bool EnableRespawnScreen = enableRespawnScreen;
    public bool ReducedDebugInfo = reducedDebugInfo;
    public int SimulationDistance = simulationDistance;
    public int ViewDistance = viewDistance;
    public int MaxPlayers = maxPlayers;
    public string[] Dimensions = dimensions;
    public bool IsHardcore = isHardcore;
    public int EntityId = entityId;

    public ClientBoundLoginPacket() : this(0, false, [], 0, 0, 0, 
        false, false, false, 0, "", 0, 
        0, 0, false, false, null, 0, 0, false) { }
    
    public override int GetPacketId() {
        return 0x2B;
    }

    protected override byte[] GetData() {
        DataWriter w = new DataWriter()
            .WriteInteger(EntityId)
            .WriteBoolean(IsHardcore)
            .WritePrefixedArray(Dimensions, (s, writer) => writer.WriteString(s))
            .WriteVarInt(MaxPlayers)
            .WriteVarInt(ViewDistance)
            .WriteVarInt(SimulationDistance)
            .WriteBoolean(ReducedDebugInfo)
            .WriteBoolean(EnableRespawnScreen)
            .WriteBoolean(DoLimitedCrafting)
            .WriteVarInt(DimensionType)
            .WriteString(DimensionName)
            .WriteLong(HashedSeed)
            .WriteUnsignedByte(GameMode)
            .WriteByte(PreviousGameMode)
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
            .WriteBoolean(EnforcesSecureChat);
        
        return w.ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadInteger();
        IsHardcore = r.ReadBoolean();
        Dimensions = r.ReadPrefixedArray(reader => reader.ReadString());
        MaxPlayers = r.ReadVarInt();
        ViewDistance = r.ReadVarInt();
        SimulationDistance = r.ReadVarInt();
        ReducedDebugInfo = r.ReadBoolean();
        EnableRespawnScreen = r.ReadBoolean();
        DoLimitedCrafting = r.ReadBoolean();
        DimensionType = r.ReadVarInt();
        DimensionName = r.ReadString();
        HashedSeed = r.ReadLong();
        GameMode = r.Read();
        PreviousGameMode = r.ReadByte();
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
        EnforcesSecureChat = r.ReadBoolean();
        return this;
    }
}
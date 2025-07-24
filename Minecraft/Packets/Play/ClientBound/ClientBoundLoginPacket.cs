using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundLoginPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:login";
    
    public required bool EnforcesSecureChat;
    public required int SeaLevel;
    public required int PortalCooldown;
    public DeathLocation? Location;
    public required bool IsFlat;
    public required bool IsDebug;
    public required GameMode PreviousGameMode;
    public required GameMode GameMode;
    public required long HashedSeed;
    public required Identifier DimensionName;
    public required int DimensionType;
    public required bool DoLimitedCrafting;
    public required bool EnableRespawnScreen;
    public required bool ReducedDebugInfo;
    public required int SimulationDistance;
    public required int ViewDistance;
    public required int MaxPlayers;
    public required Identifier[] Dimensions;
    public required bool IsHardcore;
    public required int EntityId;

    protected override DataWriter WriteData(DataWriter w) {
        return w
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
            .WriteUnsignedByte((byte)GameMode)
            .WriteByte((int)PreviousGameMode)
            .WriteBoolean(IsDebug)
            .WriteBoolean(IsFlat)
            .WritePrefixedOptional(Location,
            (location, wr) => wr
                .WriteString(location.Dimension)
                .WritePosition(location.Position))
            .WriteVarInt(PortalCooldown)
            .WriteVarInt(SeaLevel)
            .WriteBoolean(EnforcesSecureChat);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundLoginPacket {
        EntityId = r.ReadInteger(),
        IsHardcore = r.ReadBoolean(),
        Dimensions = r.ReadPrefixedArray<Identifier>(reg),
        MaxPlayers = r.ReadVarInt(),
        ViewDistance = r.ReadVarInt(),
        SimulationDistance = r.ReadVarInt(),
        ReducedDebugInfo = r.ReadBoolean(),
        EnableRespawnScreen = r.ReadBoolean(),
        DoLimitedCrafting = r.ReadBoolean(),
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
        EnforcesSecureChat = r.ReadBoolean()
    };
}

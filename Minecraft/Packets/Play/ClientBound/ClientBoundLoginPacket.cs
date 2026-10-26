using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundLoginPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:login";
    
    public required bool EnforcesSecureChat { get; init; }

    /// <summary>
    /// Whether the server authenticates players with Mojang. Vanilla fills this from
    /// <c>MinecraftServer.usesAuthentication</c>.
    /// </summary>
    public bool OnlineMode { get; init; }

    public required int SeaLevel { get; init; }
    public required int PortalCooldown { get; init; }
    public DeathLocation? Location;
    public required bool IsFlat { get; init; }
    public required bool IsDebug { get; init; }
    public required GameMode PreviousGameMode { get; init; }
    public required GameMode GameMode { get; init; }
    public required long HashedSeed { get; init; }
    public required Identifier DimensionName { get; init; }
    public required int DimensionType { get; init; }
    public required bool DoLimitedCrafting { get; init; }
    public required bool EnableRespawnScreen { get; init; }
    public required bool ReducedDebugInfo { get; init; }
    public required int SimulationDistance { get; init; }
    public required int ViewDistance { get; init; }
    public required int MaxPlayers { get; init; }
    public required Identifier[] Dimensions { get; init; }
    public required bool IsHardcore { get; init; }
    public required int EntityId { get; init; }

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
            .WriteVarInt((int)GameMode)
            // GameType.OPTIONAL_STREAM_CODEC: none is 0 and a mode is its id plus one, which is what
            // Undefined being -1 makes of it.
            .WriteVarInt((int)PreviousGameMode + 1)
            .WriteBoolean(IsDebug)
            .WriteBoolean(IsFlat)
            .WritePrefixedOptional(Location,
            (location, wr) => wr
                .WriteString(location.Dimension)
                .WritePosition(location.Position))
            .WriteVarInt(PortalCooldown)
            .WriteVarInt(SeaLevel)
            .WriteBoolean(OnlineMode)
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
        GameMode = (GameMode)r.ReadVarInt(),
        PreviousGameMode = (GameMode)(r.ReadVarInt() - 1),
        IsDebug = r.ReadBoolean(),
        IsFlat = r.ReadBoolean(),
        Location = r.ReadPrefixedOptional(re => 
            new DeathLocation(re.ReadString(), re.ReadPosition())),
        PortalCooldown = r.ReadVarInt(),
        SeaLevel = r.ReadVarInt(),
        OnlineMode = r.ReadBoolean(),
        EnforcesSecureChat = r.ReadBoolean()
    };
}

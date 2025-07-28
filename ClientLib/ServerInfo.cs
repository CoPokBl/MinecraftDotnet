using Minecraft.Schemas;

namespace ClientLib;

public record ServerInfo(
    Identifier[]? FeatureFlags = null,
    KnownDataPack[]? KnownPacks = null,
    int SimulationDistance = 0,
    int ViewDistance = 0,
    bool EnforcesSecureChat = true);

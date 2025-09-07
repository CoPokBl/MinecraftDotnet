using Minecraft.Schemas;

namespace Minecraft.Data.CustomStatistics;

public record SimpleCustomStatistic(Identifier Identifier, int ProtocolId) : ICustomStatistic;

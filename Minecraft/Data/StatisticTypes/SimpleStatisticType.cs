using Minecraft.Schemas;

namespace Minecraft.Data.StatisticTypes;

public record SimpleStatisticType(Identifier Identifier, int ProtocolId) : IStatisticType;

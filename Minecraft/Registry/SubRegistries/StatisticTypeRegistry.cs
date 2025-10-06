using Minecraft.Data.StatisticTypes;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class StatisticTypeRegistry : ProtocolTypeRegistry<StatisticTypeRegistry, IStatisticType> {
    public override Identifier RegistryId => "minecraft:stat_type";
}

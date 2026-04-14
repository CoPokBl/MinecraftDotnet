using Minecraft.Data.CustomStatistics;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class CustomStatisticRegistry : MappedRegistry<CustomStatisticRegistry, ICustomStatistic> {
    public override Identifier RegistryId => "minecraft:custom_stat";
}

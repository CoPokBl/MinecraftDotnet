using Minecraft.Data.ArgumentParsers;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class CommandArgumentTypeRegistry : MappedRegistry<CommandArgumentTypeRegistry, IArgumentParser> {
    public override Identifier RegistryId => "minecraft:command_argument_type";
}

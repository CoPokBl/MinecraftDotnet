using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

/// <remarks>
/// Unlike the layers that set them, the attributes themselves are a fixed id table rather than
/// something a datapack can add to, so this is a mapped registry and never travels as NBT.
/// </remarks>
public class EnvironmentAttributeRegistry : MappedRegistry<EnvironmentAttributeRegistry, IEnvironmentAttribute> {
    public override Identifier RegistryId => "minecraft:environment_attribute";
}

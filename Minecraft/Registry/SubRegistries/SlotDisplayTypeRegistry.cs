using Minecraft.Data.SlotDisplayTypes;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class SlotDisplayTypeRegistry : MappedRegistry<SlotDisplayTypeRegistry, ISlotDisplayType> {
    public override Identifier RegistryId => "minecraft:slot_display";
}

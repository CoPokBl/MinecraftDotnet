using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

public record AttributeModifiersComponent() : IDataComponent<ItemAttributeModifier[]> {
    public override Identifier Identifier => "minecraft:attribute_modifiers";

    /// <summary>
    /// The attribute is under <c>type</c> and the modifier's own three fields sit beside it rather
    /// than nested, which is vanilla flattening its map codec into the entry.
    /// </summary>
    public override NbtCodec<ItemAttributeModifier[]>? Codec => Persistent;
    private static readonly NbtCodec<ItemAttributeModifier[]> Persistent = new(
        (val, _) => new ListTag(val
            .Select(modifier => (INbtTag)new CompoundBuilder()
                .Holder("type", modifier.Attribute)
                .Id("id", modifier.Id)
                .Double("amount", modifier.Value)
                .String("operation", modifier.Operation.ToProtocolString())
                .String("slot", modifier.Slot.Name, EquipmentSlotGroup.Any.Name)
                .TagWhen("display", WriteDisplay(modifier.DisplayMode),
                    modifier.DisplayMode.Type != ItemAttributeModifier.DisplayType.Default)
                .Build())
            .ToArray()),

        (tag, registry) => tag.AsList()
            .Select(entry => {
                NbtNode node = NbtNode.Of(entry, "minecraft:attribute_modifiers");
                ItemAttributeModifier modifier = new(
                    node.Holder("type", registry.Attributes),
                    node.Id("id"),
                    node.Double("amount"),
                    AttributeOperationExtensions.ParseAttributeOperation(node.String("operation")),
                    EquipmentSlotGroup.FromName(node.String("slot", EquipmentSlotGroup.Any.Name)),
                    node.Object("display", ReadDisplay, ItemAttributeModifier.Display.DefaultMode()));
                node.AssertRead();
                return modifier;
            })
            .ToArray());

    private static INbtTag WriteDisplay(ItemAttributeModifier.Display display) {
        CompoundBuilder builder = new CompoundBuilder()
            .String("type", display.Type switch {
                ItemAttributeModifier.DisplayType.Hidden => "hidden",
                ItemAttributeModifier.DisplayType.Override => "override",
                _ => "default"
            });

        if (display is ItemAttributeModifier.Display.Override over) {
            builder.Tag("value", over.Text.SerialiseToTag());
        }

        return builder.Build();
    }

    private static ItemAttributeModifier.Display ReadDisplay(NbtNode node) {
        string type = node.String("type");

        ItemAttributeModifier.Display display = type switch {
            "default" => ItemAttributeModifier.Display.DefaultMode(),
            "hidden" => ItemAttributeModifier.Display.HiddenMode(),
            "override" => ItemAttributeModifier.Display.OverrideMode(
                TextComponent.FromTag(node.Require("value"))),
            _ => throw new UnportedComponentException("minecraft:attribute_modifiers",
                $"display type \"{type}\" has no port.")
        };

        node.AssertRead();
        return display;
    }
    
    public override DataWriter WriteData(ItemAttributeModifier[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, registry);
    }

    public override ItemAttributeModifier[] ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray<ItemAttributeModifier>(registry);
    }

    public override bool ValuesEqual(ItemAttributeModifier[] val1, ItemAttributeModifier[] val2) {
        return val1.SequenceEqual(val2);
    }
}

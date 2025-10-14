using Minecraft.Data.Attributes;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnchantmentEffects.Types;

public record AttributeEnchantmentEffect(AttributeEnchantmentEffect.Effect[] Effects) : IEnchantmentEffectImpl {
    public string Id => "minecraft:attributes";
    
    public static AttributeEnchantmentEffect ParseData(INbtTag tag, MinecraftRegistry reg) {
        ListTag tags = tag.GetList();
        return new AttributeEnchantmentEffect(tags.Tags
            .Select(t => Parse(t.GetCompound(), reg))
            .ToArray());
    }

    private static Effect Parse(CompoundTag compound, MinecraftRegistry reg) {
        return new Effect(
            reg.Attributes[compound["attribute"].GetString()],
            ILevelBasedValue.FromNbt(compound["amount"]!), 
            compound["operation"].GetString() switch {
                "add_value" => AttributeOperation.Add,
                "add_multiplied_base" => AttributeOperation.AddMultipliedBase,
                "add_multiplied_total" => AttributeOperation.AddMultipliedTotal,
                _ => throw new ArgumentException("Unknown attribute operation: " + compound["operation"].GetString())
            });
    }

    public INbtTag SerialiseData() {
        return new ListTag(null, Effects.Select(INbtTag (e) => new CompoundTag(null, 
            new StringTag("id", Id), 
            new StringTag("attribute", e.Attribute.Identifier), 
            e.Amount.ToNbt("amount"), 
            new StringTag("operation", 
                e.Operation switch {
                    AttributeOperation.Add => "add_value",
                    AttributeOperation.AddMultipliedBase => "add_multiplied_base",
                    AttributeOperation.AddMultipliedTotal => "add_multiplied_total",
                    _ => throw new ArgumentException("Unknown attribute operation: " + e.Operation)
        }))).ToArray());
    }

    public record Effect(IAttribute Attribute, ILevelBasedValue Amount, AttributeOperation Operation);
}

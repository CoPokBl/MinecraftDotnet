using Minecraft.Data.EnchantmentEffects.Types;
using Minecraft.Registry;
using NBT;

namespace Minecraft.Data.EnchantmentEffects;

/// <summary>
/// An effect that an enchantment can have.
/// </summary>
public interface IEnchantmentEffect {
    string Id { get; }

    INbtTag SerialiseData();

    public static IEnchantmentEffect FromNbt(string id, INbtTag tag, MinecraftRegistry reg) {
        return id switch {
            "minecraft:attributes" => AttributeEnchantmentEffect.ParseData(tag, reg),
            
            // TODO: The rest of them, see Minestom's implementation for reference
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

/// <summary>
/// Interface that all implementations of <see cref="IEnchantmentEffect"/>
/// must implement to allow parsing from NBT.
/// this isn't included in <see cref="IEnchantmentEffect"/> so that it can
/// be used as a generic.
/// </summary>
public interface IEnchantmentEffectImpl : IEnchantmentEffect {
    static abstract AttributeEnchantmentEffect ParseData(INbtTag tag, MinecraftRegistry reg);
}

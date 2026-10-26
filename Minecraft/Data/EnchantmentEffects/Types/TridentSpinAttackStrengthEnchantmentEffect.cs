using Minecraft.Registry;
using NBT;

namespace Minecraft.Data.EnchantmentEffects.Types;

/// <summary><c>minecraft:trident_spin_attack_strength</c>: how hard releasing a trident launches its holder, which riptide sets.</summary>
public record TridentSpinAttackStrengthEnchantmentEffect(IEnchantmentValueEffect Value) : IEnchantmentEffectImpl {
    public string Id => "minecraft:trident_spin_attack_strength";

    public static IEnchantmentEffect ParseData(INbtTag tag, MinecraftRegistry reg) =>
        new TridentSpinAttackStrengthEnchantmentEffect(IEnchantmentValueEffect.FromNbt(tag));

    public INbtTag SerialiseData() => Value.ToNbt();
}

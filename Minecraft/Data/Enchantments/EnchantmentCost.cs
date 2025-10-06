using NBT;
using NBT.Tags;

namespace Minecraft.Data.Enchantments;

public record EnchantmentCost(int Base, int PerLevelAboveFirst) {
    
    public CompoundTag ToNbt(string name) {
        return new CompoundTag(name, 
            new IntegerTag("base", Base), 
            new IntegerTag("per_level_above_first", PerLevelAboveFirst));
    }
    
    public static EnchantmentCost FromNbt(CompoundTag tag) {
        int baseCost = tag["base"].GetInteger();
        int perLevel = tag["per_level_above_first"].GetInteger();
        return new EnchantmentCost(baseCost, perLevel);
    }
}

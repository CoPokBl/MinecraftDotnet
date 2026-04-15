using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnchantmentEffects;

public interface ILevelBasedValue {
    float Calculate(int level);
    INbtTag ToNbt();

    public static ILevelBasedValue FromNbt(INbtTag tag) {
        if (tag is FloatTag f) return new Constant(f.Value);
        if (tag is DoubleTag d) return new Constant((float)d.Value);

        if (tag is not CompoundTag compound) {
            throw new ArgumentException("Invalid tag type for ILevelBasedValue: " + tag.GetType().Name);
        }
        
        Identifier type = compound["type"].GetString();
        return type.Key switch {
            "linear" => new Linear(
                compound["base"].GetFloat(), 
                compound["per_level_above_first"].GetFloat()),
            
            "clamped" => new Clamped(
                FromNbt(compound["value"].ThrowIfNull()), 
                compound["min"].GetFloat(), 
                compound["max"].GetFloat()),
            
            "fraction" => new Fraction(
                FromNbt(compound["numerator"].ThrowIfNull()), 
                FromNbt(compound["denominator"].ThrowIfNull())),
            
            "levels_squared" => new LevelsSquared(
                compound["added"].GetFloat()),
            
            "lookup" => new Lookup(
                compound["values"].GetList().Tags.ToArray().Select(t => t.GetFloat()).ToArray(),
                FromNbt(compound["fallback"].ThrowIfNull())),
            
            _ => throw new ArgumentException("Unknown ILevelBasedValue type: " + type)
        };
    }

    public record Constant(float Value) : ILevelBasedValue {
        public float Calculate(int level) => Value;
        public INbtTag ToNbt() => new FloatTag(Value);
    }

    public record Linear(float Base, float PerLevelAboveFirst) : ILevelBasedValue {
        public float Calculate(int level) {
            return Base + PerLevelAboveFirst * (level - 1);
        }

        public INbtTag ToNbt() {
            return new CompoundTag(
                ("type", new StringTag("minecraft:linear")),
                ("base", new FloatTag(Base)),
                ("per_level_above_first", new FloatTag(PerLevelAboveFirst)));
        }
    }

    public record Clamped(ILevelBasedValue Value, float Min, float Max) : ILevelBasedValue {
        public float Calculate(int level) {
            return Math.Clamp(Value.Calculate(level), Min, Max);
        }
        
        public INbtTag ToNbt() {
            return new CompoundTag(
                ("type", new StringTag("minecraft:clamped")),
                ("value", Value.ToNbt()),
                ("min", new FloatTag(Min)),
                ("max", new FloatTag(Max)));
        }
    }

    public record Fraction(ILevelBasedValue Numerator, ILevelBasedValue Denominator) : ILevelBasedValue {
        public float Calculate(int level) {
            float denominator = Denominator.Calculate(level);
            if (denominator == 0) {
                return 0f;
            }
            return Numerator.Calculate(level) / denominator;
        }

        public INbtTag ToNbt() {
            return new CompoundTag(
                ("type", new StringTag("minecraft:fraction")),
                ("numerator", Numerator.ToNbt()),
                ("denominator", Denominator.ToNbt()));
        }
    }

    public record LevelsSquared(float Added) : ILevelBasedValue {
        public float Calculate(int level) {
            return level * level + Added;
        }

        public INbtTag ToNbt() {
            return new CompoundTag(
                ("type", new StringTag("minecraft:levels_squared")),
                ("added", new FloatTag(Added)));
        }
    }

    public record Lookup(float[] Values, ILevelBasedValue Fallback) : ILevelBasedValue {
        public float Calculate(int level) {
            if (level < 0 || level >= Values.Length) {
                return Fallback.Calculate(level);
            }
            return Values[level - 1];
        }

        public INbtTag ToNbt() {
            return new CompoundTag(
                ("type", new StringTag("minecraft:lookup")),
                ("values", new ListTag(Values.Select(v => (INbtTag)new FloatTag(v)).ToArray())),
                ("fallback", Fallback.ToNbt()));
        }
    }
}

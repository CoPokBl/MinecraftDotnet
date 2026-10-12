using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnchantmentEffects;

/// <summary>Vanilla's <c>EnchantmentValueEffect</c>: a step that turns a number into another, by enchantment level.</summary>
public interface IEnchantmentValueEffect {
    float Process(int enchantmentLevel, RandomSource random, float inputValue);

    INbtTag ToNbt();

    /// <exception cref="ArgumentOutOfRangeException">A type this library does not know.</exception>
    public static IEnchantmentValueEffect FromNbt(INbtTag tag) {
        CompoundTag compound = tag.GetCompound();
        Identifier type = compound["type"].GetString();
        return type.Key switch {
            "add" => new Add(ILevelBasedValue.FromNbt(compound["value"].ThrowIfNull())),
            "all_of" => new AllOf(compound["effects"].AsList().Select(FromNbt).ToArray()),
            "multiply" => new Multiply(ILevelBasedValue.FromNbt(compound["factor"].ThrowIfNull())),
            "remove_binomial" => new RemoveBinomial(ILevelBasedValue.FromNbt(compound["chance"].ThrowIfNull())),
            "exponential" => new Exponential(
                ILevelBasedValue.FromNbt(compound["base"].ThrowIfNull()),
                ILevelBasedValue.FromNbt(compound["exponent"].ThrowIfNull())),
            "set" => new Set(ILevelBasedValue.FromNbt(compound["value"].ThrowIfNull())),
            _ => throw new ArgumentOutOfRangeException(nameof(tag), "Unknown enchantment value effect: " + type)
        };
    }

    public record Add(ILevelBasedValue Value) : IEnchantmentValueEffect {
        public float Process(int enchantmentLevel, RandomSource random, float inputValue) => inputValue + Value.Calculate(enchantmentLevel);

        public INbtTag ToNbt() => new CompoundTag(("type", new StringTag("minecraft:add")), ("value", Value.ToNbt()));
    }

    public record AllOf(IEnchantmentValueEffect[] Effects) : IEnchantmentValueEffect {
        public float Process(int enchantmentLevel, RandomSource random, float inputValue) {
            float value = inputValue;
            foreach (IEnchantmentValueEffect effect in Effects) {
                value = effect.Process(enchantmentLevel, random, value);
            }
            return value;
        }

        public INbtTag ToNbt() => new CompoundTag(
            ("type", new StringTag("minecraft:all_of")),
            ("effects", new ListTag(Effects.Select(e => e.ToNbt()).ToArray())));
    }

    public record Multiply(ILevelBasedValue Factor) : IEnchantmentValueEffect {
        public float Process(int enchantmentLevel, RandomSource random, float inputValue) => inputValue * Factor.Calculate(enchantmentLevel);

        public INbtTag ToNbt() => new CompoundTag(("type", new StringTag("minecraft:multiply")), ("factor", Factor.ToNbt()));
    }

    public record RemoveBinomial(ILevelBasedValue Chance) : IEnchantmentValueEffect {
        public float Process(int level, RandomSource random, float n) {
            float p = Chance.Calculate(level);
            int drop = 0;
            if (!(n <= 128.0F) && !(n * p < 20.0F) && !(n * (1.0F - p) < 20.0F)) {
                double miu = Math.Floor(n * p);
                double sigma = Math.Sqrt(n * p * (1.0F - p));
                // Java's Math.round: the floor of the value plus a half.
                drop = (int)(long)Math.Floor(miu + random.NextGaussian() * sigma + 0.5);
                drop = (int)Math.Clamp((long)drop, 0, (int)n);
            }
            else {
                for (int y = 0; y < n; y++) {
                    if (random.NextFloat() < p) {
                        drop++;
                    }
                }
            }
            return n - drop;
        }

        public INbtTag ToNbt() => new CompoundTag(("type", new StringTag("minecraft:remove_binomial")), ("chance", Chance.ToNbt()));
    }

    public record Exponential(ILevelBasedValue Base, ILevelBasedValue Exponent) : IEnchantmentValueEffect {
        public float Process(int level, RandomSource random, float inputValue) =>
            (float)(inputValue * Math.Pow(Base.Calculate(level), Exponent.Calculate(level)));

        public INbtTag ToNbt() => new CompoundTag(
            ("type", new StringTag("minecraft:exponential")),
            ("base", Base.ToNbt()),
            ("exponent", Exponent.ToNbt()));
    }

    public record Set(ILevelBasedValue Value) : IEnchantmentValueEffect {
        public float Process(int enchantmentLevel, RandomSource random, float inputValue) => Value.Calculate(enchantmentLevel);

        public INbtTag ToNbt() => new CompoundTag(("type", new StringTag("minecraft:set")), ("value", Value.ToNbt()));
    }
}

using NBT;
using NBT.Tags;

namespace Minecraft.Schemas;

/// <summary>
/// A float the game rolls each time it needs one. Registry data that varies a value per use
/// carries one of these rather than a fixed number.
/// </summary>
/// <remarks>
/// A bare number is the shorthand for <see cref="Constant"/>, and vanilla writes it that way, so
/// the round trip has to preserve which of the two forms was used.
/// </remarks>
public abstract record FloatProvider {
    public abstract Identifier Type { get; }

    protected abstract (string, INbtTag)[] Fields { get; }

    public INbtTag ToNbt() {
        if (this is Constant constant) {
            return new FloatTag(constant.Value);
        }

        List<(string, INbtTag)> children = [("type", new StringTag(Type.ToString()))];
        children.AddRange(Fields);
        return new CompoundTag(children.ToArray());
    }

    public static FloatProvider FromNbt(INbtTag tag) {
        if (tag is not CompoundTag compound) {
            return new Constant(tag.AsFloat());
        }

        Identifier type = compound["type"]!.GetString();
        return type.ToString() switch {
            "minecraft:constant" => new Constant(compound["value"]!.AsFloat()),
            "minecraft:uniform" => new Uniform(
                compound["min_inclusive"]!.AsFloat(),
                compound["max_exclusive"]!.AsFloat()),
            "minecraft:clamped_normal" => new ClampedNormal(
                compound["mean"]!.AsFloat(),
                compound["deviation"]!.AsFloat(),
                compound["min"]!.AsFloat(),
                compound["max"]!.AsFloat()),
            "minecraft:trapezoid" => new Trapezoid(
                compound["min"]!.AsFloat(),
                compound["max"]!.AsFloat(),
                compound["plateau"]!.AsFloat()),
            _ => throw new ArgumentException($"Unknown float provider type {type}", nameof(tag))
        };
    }

    public record Constant(float Value) : FloatProvider {
        public override Identifier Type => "minecraft:constant";
        protected override (string, INbtTag)[] Fields => [("value", new FloatTag(Value))];
    }

    public record Uniform(float MinInclusive, float MaxExclusive) : FloatProvider {
        public override Identifier Type => "minecraft:uniform";
        protected override (string, INbtTag)[] Fields => [
            ("min_inclusive", new FloatTag(MinInclusive)),
            ("max_exclusive", new FloatTag(MaxExclusive))
        ];
    }

    public record ClampedNormal(float Mean, float Deviation, float Min, float Max) : FloatProvider {
        public override Identifier Type => "minecraft:clamped_normal";
        protected override (string, INbtTag)[] Fields => [
            ("mean", new FloatTag(Mean)),
            ("deviation", new FloatTag(Deviation)),
            ("min", new FloatTag(Min)),
            ("max", new FloatTag(Max))
        ];
    }

    public record Trapezoid(float Min, float Max, float Plateau) : FloatProvider {
        public override Identifier Type => "minecraft:trapezoid";
        protected override (string, INbtTag)[] Fields => [
            ("min", new FloatTag(Min)),
            ("max", new FloatTag(Max)),
            ("plateau", new FloatTag(Plateau))
        ];
    }
}

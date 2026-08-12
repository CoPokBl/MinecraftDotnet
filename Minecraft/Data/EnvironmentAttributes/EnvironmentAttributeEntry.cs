using Minecraft.Registry;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// What one layer says about an attribute: either a value outright, or an adjustment to whatever
/// the layers underneath worked out.
/// </summary>
public abstract record EnvironmentAttributeEntry {

    public abstract INbtTag ToNbt();

    public static EnvironmentAttributeEntry FromNbt(IEnvironmentAttribute attribute, INbtTag tag,
        MinecraftRegistry reg) {
        // An adjustment is the only form that's a compound naming a modifier, so that field is
        // what tells the two apart, which is the same test vanilla's `either` codec ends up making
        if (tag is CompoundTag compound && compound.Contains("modifier")) {
            return new Modified(
                EnvironmentAttributeOperationExtensions.ParseEnvironmentAttributeOperation(
                    compound["modifier"]!.GetString()),
                compound["argument"]!);
        }

        return new Constant(EnvironmentAttributeValue.FromNbt(attribute.ValueKind, tag, reg));
    }

    public record Constant(EnvironmentAttributeValue Value) : EnvironmentAttributeEntry {
        public override INbtTag ToNbt() => Value.ToNbt();
    }

    /// <param name="Argument">
    /// What the operation is applied with. Its shape depends on both the operation and the
    /// attribute's value type (<c>multiply</c> on a float takes a float, <c>alpha_blend</c> takes
    /// a <c>{value, alpha}</c> pair), so it stays as read rather than being forced into
    /// <see cref="EnvironmentAttributeValue"/>, which only covers the value's own type.
    /// </param>
    public record Modified(EnvironmentAttributeOperation Operation, INbtTag Argument) : EnvironmentAttributeEntry {
        public override INbtTag ToNbt() {
            return new CompoundTag(
                ("modifier", new StringTag(Operation.ToProtocolString())),
                ("argument", NarrowNumbers(Argument)));
        }

        /// <summary>
        /// Every number a modifier argument carries is a float on the vanilla side: the plain
        /// ones, and both halves of the <c>{value, alpha}</c> pair <c>alpha_blend</c> takes. JSON
        /// datapack data can't say which width it meant, so it's settled here rather than sending
        /// a double the client has to widen back down.
        /// </summary>
        private static INbtTag NarrowNumbers(INbtTag tag) {
            return tag switch {
                DoubleTag d => new FloatTag((float)d.Value),
                IntegerTag i => new FloatTag(i.Value),
                LongTag l => new FloatTag(l.Value),
                ShortTag s => new FloatTag(s.Value),
                CompoundTag c => new CompoundTag(c.Children
                    .ToArray()
                    .Select(child => (child.Item1, NarrowNumbers(child.Item2)))
                    .ToArray()),
                _ => tag
            };
        }
    }
}

public enum EnvironmentAttributeOperation {
    Override,
    AlphaBlend,
    Add,
    Subtract,
    Multiply,
    BlendToGray,
    Minimum,
    Maximum,
    And,
    Nand,
    Or,
    Nor,
    Xor,
    Xnor
}

public static class EnvironmentAttributeOperationExtensions {
    public static string ToProtocolString(this EnvironmentAttributeOperation operation) => operation switch {
        EnvironmentAttributeOperation.Override => "override",
        EnvironmentAttributeOperation.AlphaBlend => "alpha_blend",
        EnvironmentAttributeOperation.Add => "add",
        EnvironmentAttributeOperation.Subtract => "subtract",
        EnvironmentAttributeOperation.Multiply => "multiply",
        EnvironmentAttributeOperation.BlendToGray => "blend_to_gray",
        EnvironmentAttributeOperation.Minimum => "minimum",
        EnvironmentAttributeOperation.Maximum => "maximum",
        EnvironmentAttributeOperation.And => "and",
        EnvironmentAttributeOperation.Nand => "nand",
        EnvironmentAttributeOperation.Or => "or",
        EnvironmentAttributeOperation.Nor => "nor",
        EnvironmentAttributeOperation.Xor => "xor",
        EnvironmentAttributeOperation.Xnor => "xnor",
        _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
    };

    public static EnvironmentAttributeOperation ParseEnvironmentAttributeOperation(string value) => value switch {
        "override" => EnvironmentAttributeOperation.Override,
        "alpha_blend" => EnvironmentAttributeOperation.AlphaBlend,
        "add" => EnvironmentAttributeOperation.Add,
        "subtract" => EnvironmentAttributeOperation.Subtract,
        "multiply" => EnvironmentAttributeOperation.Multiply,
        "blend_to_gray" => EnvironmentAttributeOperation.BlendToGray,
        "minimum" => EnvironmentAttributeOperation.Minimum,
        "maximum" => EnvironmentAttributeOperation.Maximum,
        "and" => EnvironmentAttributeOperation.And,
        "nand" => EnvironmentAttributeOperation.Nand,
        "or" => EnvironmentAttributeOperation.Or,
        "nor" => EnvironmentAttributeOperation.Nor,
        "xor" => EnvironmentAttributeOperation.Xor,
        "xnor" => EnvironmentAttributeOperation.Xnor,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown environment attribute modifier")
    };
}

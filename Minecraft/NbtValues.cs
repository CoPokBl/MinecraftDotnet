using NBT;
using NBT.Tags;

namespace Minecraft;

/// <summary>
/// Reading a tag the way vanilla's <c>NbtOps</c> does, which is what every codec reading NBT goes
/// through. Anything decoding data another program wrote reads its primitives here rather than
/// through the NBT library's accessors.
/// </summary>
/// <remarks>
/// <c>NbtOps.getNumberValue</c> hands any numeric tag to any numeric codec, which then narrows it the
/// way Java's <c>Number</c> does: a fraction truncates, a long wraps, a double out of range
/// saturates. A server is free to send any of those pairs, and an older one behind a translating
/// proxy does (whole floats arrive as ints), where the library's accessors refuse most of them.
/// </remarks>
public static class NbtValues {

    /// <summary><c>Codec.INT</c>: <c>Number.intValue</c> of any numeric tag.</summary>
    public static int AsInt(this INbtTag? tag) {
        return tag switch {
            ByteTag b => b.Value,
            ShortTag s => s.Value,
            IntegerTag i => i.Value,
            LongTag l => unchecked((int)l.Value),
            FloatTag f => JavaInt(f.Value),
            DoubleTag d => JavaInt(d.Value),
            _ => throw NotA("number", tag)
        };
    }

    /// <summary><c>Codec.LONG</c>.</summary>
    public static long AsLong(this INbtTag? tag) {
        return tag switch {
            ByteTag b => b.Value,
            ShortTag s => s.Value,
            IntegerTag i => i.Value,
            LongTag l => l.Value,
            FloatTag f => JavaLong(f.Value),
            DoubleTag d => JavaLong(d.Value),
            _ => throw NotA("number", tag)
        };
    }

    /// <summary><c>Codec.BYTE</c>: the low byte of the int, which is how Java narrows.</summary>
    public static sbyte AsByte(this INbtTag? tag) {
        return unchecked((sbyte)tag.AsInt());
    }

    /// <summary><c>Codec.SHORT</c>.</summary>
    public static short AsShort(this INbtTag? tag) {
        return unchecked((short)tag.AsInt());
    }

    /// <summary><c>Codec.FLOAT</c>.</summary>
    public static float AsFloat(this INbtTag? tag) {
        return tag switch {
            FloatTag f => f.Value,
            DoubleTag d => (float)d.Value,
            _ => tag.AsLong()
        };
    }

    /// <summary><c>Codec.DOUBLE</c>.</summary>
    public static double AsDouble(this INbtTag? tag) {
        return tag switch {
            FloatTag f => f.Value,
            DoubleTag d => d.Value,
            _ => tag.AsLong()
        };
    }

    /// <summary><c>Codec.BOOL</c>, <c>NbtOps.getBooleanValue</c>: any number that is not zero.</summary>
    public static bool AsBool(this INbtTag? tag) {
        return tag.AsDouble() != 0.0;
    }

    /// <summary>Whether <see cref="AsInt"/> and the rest accept the tag, <c>NumericTag</c>.</summary>
    public static bool IsNumber(this INbtTag? tag) {
        return tag is ByteTag or ShortTag or IntegerTag or LongTag or FloatTag or DoubleTag;
    }

    /// <summary>
    /// The elements of any list, <c>NbtOps.getStream</c>: a list tag, or one of the three array tags
    /// as the numbers it holds.
    /// </summary>
    /// <remarks>
    /// A list whose elements differ in type travels as compounds each holding one unnamed entry, and
    /// vanilla takes the wrapper back off as it reads the list, so that happens here too.
    /// </remarks>
    public static INbtTag[] AsList(this INbtTag? tag) {
        switch (tag) {
            case ListTag list: {
                INbtTag[] values = list.Tags.ToArray();
                for (int i = 0; i < values.Length; i++) {
                    if (values[i] is CompoundTag { ChildCount: 1 } compound
                        && compound[""] is { } wrapped) {
                        values[i] = wrapped;
                    }
                }

                return values;
            }
            case ArrayTag<sbyte> bytes:
                return bytes.Values.ToArray().Select(INbtTag (b) => new ByteTag(b)).ToArray();
            case ArrayTag<int> ints:
                return ints.Values.ToArray().Select(INbtTag (i) => new IntegerTag(i)).ToArray();
            case ArrayTag<long> longs:
                return longs.Values.ToArray().Select(INbtTag (l) => new LongTag(l)).ToArray();
            default:
                throw NotA("list", tag);
        }
    }

    /// <summary>
    /// <c>ExtraCodecs.compactListCodec</c>: a list, or one element standing alone.
    /// </summary>
    public static INbtTag[] AsCompactList(this INbtTag tag) {
        return tag is ListTag or ArrayTag<sbyte> or ArrayTag<int> or ArrayTag<long> ? tag.AsList() : [tag];
    }

    /// <summary>Java's <c>d2i</c>: NaN is zero and anything out of range saturates.</summary>
    private static int JavaInt(double value) {
        if (double.IsNaN(value)) {
            return 0;
        }

        return value >= int.MaxValue ? int.MaxValue : value <= int.MinValue ? int.MinValue : (int)value;
    }

    private static long JavaLong(double value) {
        if (double.IsNaN(value)) {
            return 0;
        }

        return value >= long.MaxValue ? long.MaxValue : value <= long.MinValue ? long.MinValue : (long)value;
    }

    private static InvalidCastException NotA(string what, INbtTag? tag) {
        return new InvalidCastException($"Expected a {what}, got {tag?.GetType().Name ?? "nothing"}.");
    }
}

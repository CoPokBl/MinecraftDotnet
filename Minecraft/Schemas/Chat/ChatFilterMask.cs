using System.Collections;

namespace Minecraft.Schemas.Chat;

/// <summary>
/// Which parts of a message the server's chat filter objected to. Filtered words are drawn as
/// hashes by the client rather than removed.
/// </summary>
public record ChatFilterMask(ChatFilterMask.FilterType Type, BitArray? Mask = null) : IWritable {
    public static readonly ChatFilterMask PassThrough = new(FilterType.PassThrough);
    public static readonly ChatFilterMask FullyFiltered = new(FilterType.FullyFiltered);

    /// <summary>Marks the characters at the set indices as filtered.</summary>
    public static ChatFilterMask PartiallyFiltered(BitArray mask) {
        return new ChatFilterMask(FilterType.PartiallyFiltered, mask);
    }

    public void Write(DataWriter w) {
        w.WriteVarInt((int)Type);
        if (Type == FilterType.PartiallyFiltered) {
            w.WritePrefixedArray(Mask.ThrowIfNull().ToLongArray(), (l, writer) => writer.WriteLong(l));
        }
    }

    public static ChatFilterMask Read(DataReader r) {
        FilterType type = (FilterType)r.ReadVarInt();
        return type switch {
            FilterType.PassThrough => PassThrough,
            FilterType.FullyFiltered => FullyFiltered,
            FilterType.PartiallyFiltered => PartiallyFiltered(
                r.ReadPrefixedArray(reader => reader.ReadLong()).ToBitArray()),
            _ => throw new ArgumentOutOfRangeException(nameof(r), type, "Unknown chat filter type")
        };
    }

    public enum FilterType {
        PassThrough = 0,
        FullyFiltered = 1,
        PartiallyFiltered = 2
    }
}

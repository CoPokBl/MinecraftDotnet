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
            w.WritePrefixedArray((ReadOnlySpan<byte>)Mask.ThrowIfNull().ToJavaByteArray());
        }
    }

    /// <remarks>A type this does not know reads as passed through, as vanilla's id mapper falls back.</remarks>
    public static ChatFilterMask Read(DataReader r) {
        FilterType type = (FilterType)r.ReadVarInt();
        return type switch {
            FilterType.FullyFiltered => FullyFiltered,
            FilterType.PartiallyFiltered => PartiallyFiltered(r.Read(r.ReadVarInt()).FromJavaByteArray()),
            _ => PassThrough
        };
    }

    public enum FilterType {
        PassThrough = 0,
        FullyFiltered = 1,
        PartiallyFiltered = 2
    }
}

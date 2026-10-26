using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Schemas.Tags;

/// <summary>
/// A set of registry entries the way datapack data writes one: either the name of a tag, or an
/// explicit list of entry names. This is vanilla's <c>HolderSet</c> in its NBT form, which is what
/// the registry element data the client synchronises uses.
/// </summary>
/// <remarks>
/// <see cref="IdSet"/> is the same idea over the wire, where entries travel as protocol ids
/// instead of names. The two can't be one type because resolving between them needs to know which
/// registry the set belongs to, and neither form carries that.
/// </remarks>
public abstract record HolderSet {

    public abstract INbtTag ToNbt();

    public static HolderSet FromNbt(INbtTag tag) {
        if (tag is ListTag list) {
            return new Direct(list.Tags.ToArray().Select(t => (Identifier)t.GetString()).ToArray());
        }

        string value = tag.GetString();
        return value.StartsWith('#')
            ? new Tag(value[1..])
            : new Direct([value]);
    }

    /// <summary>Everything in the named tag.</summary>
    public record Tag(Identifier TagName) : HolderSet {
        public override INbtTag ToNbt() {
            return new StringTag("#" + TagName);
        }
    }

    /// <summary>An explicit list of entries.</summary>
    public record Direct(Identifier[] Entries) : HolderSet {
        public override INbtTag ToNbt() {
            // A one element set is written as a bare string, which is how vanilla writes it and
            // what the tag folders in the vanilla data contain
            if (Entries.Length == 1) {
                return new StringTag(Entries[0].ToString());
            }

            return new ListTag<StringTag>(Entries.Select(e => new StringTag(e.ToString())).ToArray());
        }

        public virtual bool Equals(Direct? other) {
            return other != null && Entries.SequenceEqual(other.Entries);
        }

        public override int GetHashCode() {
            return Entries.Aggregate(0, HashCode.Combine);
        }
    }
}

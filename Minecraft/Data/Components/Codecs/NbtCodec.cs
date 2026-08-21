using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;

namespace Minecraft.Data.Components.Codecs;

/// <summary>
/// A data component's persistent form: the one thing behind both a datapack's JSON and an item's
/// saved NBT, which is vanilla's <c>DataComponentType.codec</c>.
/// </summary>
/// <remarks>
/// <b>This is not the network form.</b> That is <see cref="IDataComponent{T}.WriteData"/>, and for
/// several components the two genuinely differ: the wire carries neither key names nor defaults, so
/// <c>blocks_attacks</c> travels as ten fields in order and writes as five keys with the rest left
/// off. Neither form can be derived from the other, or from the record.
/// <p/>
/// The tag is the intermediate for both formats, so two things true of NBT are true of the JSON
/// side as well. A list tag must be homogeneous, so a mixed JSON array is refused rather than read.
/// And reading JSON can only ever produce a <c>ListTag</c>, so a codec whose vanilla form is an int
/// array has to write an <c>ArrayTag</c> deliberately.
/// <p/>
/// A boolean is written as a <c>BooleanTag</c> and never a bare <c>ByteTag</c>. Both serialise to
/// the same byte, but only the first comes back out of <c>INbtTag.ToJson</c> as <c>true</c> rather
/// than <c>1</c>.
/// </remarks>
public sealed record NbtCodec<T>(
    Func<T, MinecraftRegistry, INbtTag> ToNbt,
    Func<INbtTag, MinecraftRegistry, T> FromNbt);

/// <summary>
/// A data component that cannot be read or written as data here, named.
/// </summary>
/// <remarks>
/// Thrown rather than answered with a default, so a caller has to decide what to do about it. A
/// component a datapack names is a component that changes what the item is, and reading it as
/// nothing is the silent failure. <c>RecipeParser</c> turns this into a countable decline.
/// </remarks>
public sealed class UnportedComponentException : InvalidOperationException {
    public Identifier Component { get; }

    public UnportedComponentException(Identifier component) : base(
        $"{component} has no persistent form here. Add an NbtCodec to its component rather than "
        + "letting it drop: a component a datapack names is one that changes what the item is.") {

        Component = component;
    }

    public UnportedComponentException(Identifier component, string detail)
        : base($"{component}: {detail}") {

        Component = component;
    }
}

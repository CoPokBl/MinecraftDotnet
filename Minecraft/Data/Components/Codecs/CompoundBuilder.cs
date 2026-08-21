using Minecraft.Data.Sounds;
using Minecraft.Registry.Templates;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Codecs;

/// <summary>
/// Builds a component's data, one field at a time.
/// </summary>
/// <remarks>
/// <b>Whether a field is left off at its default is a fact about vanilla's codec, not about the
/// value.</b> A shield leaves off <c>disable_cooldown_scale</c> and <c>damage_reductions</c> at
/// theirs, and writes <c>item_damage.factor</c> at its. So the two overloads are separate rather
/// than one that decides: the always written one is vanilla's <c>fieldOf</c>, and the one taking a
/// value to omit at is <c>optionalFieldOf</c> with a default. Guessing from the C# default gets it
/// wrong in both directions.
/// <p/>
/// The rule is about fields and never about the component itself, which is written even when every
/// field is at its default. An empty object is what several of them encode to.
/// </remarks>
public sealed class CompoundBuilder {
    private readonly List<(string, INbtTag)> _fields = [];

    public CompoundTag Build() {
        return new CompoundTag(_fields.ToArray());
    }

    /// <summary>The tag under <paramref name="key"/>, always written.</summary>
    public CompoundBuilder Tag(string key, INbtTag value) {
        _fields.Add((key, value));
        return this;
    }

    /// <summary>The tag under <paramref name="key"/>, written only when <paramref name="when"/>.</summary>
    public CompoundBuilder TagWhen(string key, INbtTag value, bool when) {
        return when ? Tag(key, value) : this;
    }

    // ------------------------------------------------------------------ primitives

    public CompoundBuilder Int(string key, int value) => Tag(key, new IntegerTag(value));
    public CompoundBuilder Int(string key, int value, int omitWhen) =>
        value == omitWhen ? this : Int(key, value);

    public CompoundBuilder Long(string key, long value) => Tag(key, new LongTag(value));
    public CompoundBuilder Long(string key, long value, long omitWhen) =>
        value == omitWhen ? this : Long(key, value);

    public CompoundBuilder Float(string key, float value) => Tag(key, new FloatTag(value));
    public CompoundBuilder Float(string key, float value, float omitWhen) =>
        value.Equals(omitWhen) ? this : Float(key, value);

    public CompoundBuilder Double(string key, double value) => Tag(key, new DoubleTag(value));
    public CompoundBuilder Double(string key, double value, double omitWhen) =>
        value.Equals(omitWhen) ? this : Double(key, value);

    /// <summary>
    /// A boolean, as a <see cref="BooleanTag"/>. Not a <see cref="ByteTag"/>: the two serialise to
    /// the same byte, but only this one comes back out of the JSON bridge as <c>true</c> rather
    /// than <c>1</c>.
    /// </summary>
    public CompoundBuilder Bool(string key, bool value) => Tag(key, new BooleanTag(value));
    public CompoundBuilder Bool(string key, bool value, bool omitWhen) =>
        value == omitWhen ? this : Bool(key, value);

    public CompoundBuilder String(string key, string value) => Tag(key, new StringTag(value));
    public CompoundBuilder String(string key, string? value, string? omitWhen) =>
        value == omitWhen ? this : String(key, value!);

    public CompoundBuilder Id(string key, Identifier value) => String(key, value.ToString());
    public CompoundBuilder Id(string key, Identifier? value) =>
        value is null ? this : Id(key, value.Value);

    // ------------------------------------------------------------------ composites

    /// <summary>A value written only when it is there, vanilla's <c>optionalFieldOf</c>.</summary>
    public CompoundBuilder Maybe<T>(string key, T? value, Func<T, INbtTag> write) where T : class {
        return value is null ? this : Tag(key, write(value));
    }

    public CompoundBuilder Maybe<T>(string key, T? value, Func<T, INbtTag> write) where T : struct {
        return value is null ? this : Tag(key, write(value.Value));
    }

    /// <summary>A list, always written. An empty one stays as an empty list.</summary>
    public CompoundBuilder List<T>(string key, IEnumerable<T> values, Func<T, INbtTag> write) {
        return Tag(key, new ListTag(values.Select(write).ToArray()));
    }

    /// <summary>A list left off when it is empty, which is what <c>listOf</c> encodes to.</summary>
    public CompoundBuilder ListOrOmit<T>(string key, IReadOnlyCollection<T> values,
        Func<T, INbtTag> write) {

        return values.Count == 0 ? this : List(key, values, write);
    }

    // ------------------------------------------------------------------ registry references

    public CompoundBuilder Holder(string key, IProtocolType value) => Id(key, value.Identifier);

    /// <summary>
    /// A sound, as the registry name it is or the object an inline one is. Five components carry one
    /// of these and all of them write it the same way.
    /// </summary>
    public CompoundBuilder Sound(string key, Or<ISoundType, SoundEvent>? value) {
        if (value is null) {
            return this;
        }

        return Tag(key, value.IsValue1
            ? new StringTag(value.Value1!.Identifier.ToString())
            : value.Value2!.ToNbt());
    }

    /// <summary>
    /// A set of registry entries, back to the tag name or entry names a datapack would carry.
    /// </summary>
    /// <remarks>
    /// The registry is named at the call site because an <see cref="IdSet"/> holds protocol ids and
    /// nothing about which registry they index.
    /// </remarks>
    public CompoundBuilder IdSet(string key, IdSet? value, IProtocolTypeRegistry registry) {
        if (value is null) {
            return this;
        }

        return Tag(key, NbtCodecs.ToHolderSet(value, registry).ToNbt());
    }

    // ------------------------------------------------------------------ enums

    public CompoundBuilder Enum<TEnum>(string key, TEnum value) where TEnum : struct, Enum {
        return String(key, NbtNode.NameOf(value));
    }

    public CompoundBuilder Enum<TEnum>(string key, TEnum value, TEnum omitWhen)
        where TEnum : struct, Enum {

        return value.Equals(omitWhen) ? this : Enum(key, value);
    }
}

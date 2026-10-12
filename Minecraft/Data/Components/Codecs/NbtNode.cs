using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas.Sound;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;
using NBT;
using NBT.Tags;
using System.Collections.Frozen;

namespace Minecraft.Data.Components.Codecs;

/// <summary>
/// A compound being read as a component's data, and the record of which of its keys were asked for.
/// </summary>
/// <remarks>
/// <b><see cref="AssertRead"/> is the point of it.</b> A key a datapack wrote that no codec here
/// looked at is a field that changes what the item is, and reading it as its default is silent where
/// a throw is not. The alternative, listing the expected keys beside the reads, duplicates them and
/// drifts; a node that records what it was asked for cannot.
/// <p/>
/// Coercion between tag types is left to <see cref="NbtValues"/>, which reads numbers and lists the
/// way vanilla's <c>NbtOps</c> does. What is added here is a key with a default, which they have no notion of, and an
/// error naming the component and the field, which they cannot see.
/// </remarks>
public sealed class NbtNode {
    private readonly CompoundTag _tag;
    private readonly Identifier _component;
    private readonly HashSet<string> _read = [];

    private NbtNode(CompoundTag tag, Identifier component) {
        _tag = tag;
        _component = component;
    }

    public static NbtNode Of(INbtTag tag, Identifier component) {
        if (tag is not CompoundTag compound) {
            throw new UnportedComponentException(component,
                $"expected an object, got {tag.GetType().Name}.");
        }

        return new NbtNode(compound, component);
    }

    /// <summary>Whether the data carries <paramref name="key"/> at all, without consuming it.</summary>
    public bool Has(string key) {
        return _tag.Contains(key);
    }

    /// <summary>The tag under <paramref name="key"/>, or null. Consumes the key either way.</summary>
    public INbtTag? Optional(string key) {
        _read.Add(key);
        return _tag[key];
    }

    /// <summary>The tag under <paramref name="key"/>. Consumes the key.</summary>
    public INbtTag Require(string key) {
        return Optional(key) ?? throw new UnportedComponentException(_component,
            $"no \"{key}\", which is not optional.");
    }

    // ------------------------------------------------------------------ primitives

    public int Int(string key) => Read(key, static tag => tag.AsInt());
    public int Int(string key, int fallback) => Read(key, static tag => tag.AsInt(), fallback);

    public long Long(string key) => Read(key, static tag => tag.AsLong());
    public long Long(string key, long fallback) => Read(key, static tag => tag.AsLong(), fallback);

    public float Float(string key) => Read(key, static tag => tag.AsFloat());
    public float Float(string key, float fallback) => Read(key, static tag => tag.AsFloat(), fallback);

    public double Double(string key) => Read(key, static tag => tag.AsDouble());
    public double Double(string key, double fallback) => Read(key, static tag => tag.AsDouble(), fallback);

    public bool Bool(string key) => Read(key, static tag => tag.AsBool());
    public bool Bool(string key, bool fallback) => Read(key, static tag => tag.AsBool(), fallback);

    public string String(string key) => Read(key, static tag => tag.GetString());
    public string String(string key, string fallback) => Read(key, static tag => tag.GetString(), fallback);
    public string? StringOrNull(string key) => Read<string?>(key, static tag => tag.GetString(), null);

    public Identifier Id(string key) => Read(key, static tag => (Identifier)tag.GetString());
    public Identifier Id(string key, Identifier fallback) =>
        Read(key, static tag => (Identifier)tag.GetString(), fallback);
    public Identifier? IdOrNull(string key) =>
        Read<Identifier?>(key, static tag => (Identifier)tag.GetString(), null);

    // ------------------------------------------------------------------ composites

    public T Object<T>(string key, Func<NbtNode, T> read) {
        return read(Of(Require(key), _component));
    }

    public T Object<T>(string key, Func<NbtNode, T> read, T fallback) {
        INbtTag? tag = Optional(key);
        return tag is null ? fallback : read(Of(tag, _component));
    }

    public T? ObjectOrNull<T>(string key, Func<NbtNode, T> read) where T : class {
        INbtTag? tag = Optional(key);
        return tag is null ? null : read(Of(tag, _component));
    }

    /// <summary>
    /// A list, empty when the key is absent.
    /// </summary>
    /// <remarks>
    /// Absent reads as empty because that is what vanilla's <c>listOf</c> does, but a field whose
    /// default is a non empty list is not one of those and must not use this: an absent
    /// <c>damage_reductions</c> means everything is blocked, not nothing.
    /// </remarks>
    public T[] List<T>(string key, Func<INbtTag, T> read) {
        INbtTag? tag = Optional(key);

        if (tag is null) {
            return [];
        }

        INbtTag[] list = Convert(key, static tag => tag.AsList(), tag);
        T[] values = new T[list.Length];
        for (int i = 0; i < values.Length; i++) {
            values[i] = read(list[i]);
        }

        return values;
    }

    /// <summary>The same, reading each element as an object.</summary>
    public T[] Objects<T>(string key, Func<NbtNode, T> read) {
        return List(key, tag => read(Of(tag, _component)));
    }

    // ------------------------------------------------------------------ registry references

    /// <summary>
    /// A registry entry named by identifier, vanilla's <c>Holder</c> in the form a datapack writes.
    /// </summary>
    public TType Holder<TType>(string key, IProtocolTypeRegistry<TType> registry)
        where TType : IProtocolType {

        Identifier id = Id(key);

        if (!registry.Contains(id)) {
            throw new UnportedComponentException(_component,
                $"\"{key}\" names {id}, which is not in {registry.RegistryId}.");
        }

        return registry.Get(id);
    }

    /// <summary>
    /// The same, but taking an inline definition as well, for a registry a datapack may extend.
    /// </summary>
    public TType Holder<TType>(string key, IProtocolTypeRegistry<TType> registry,
        Func<NbtNode, TType> inline) where TType : IProtocolType {

        INbtTag tag = Require(key);
        return tag is CompoundTag ? inline(Of(tag, _component)) : Resolve(key, registry, tag);
    }

    /// <summary>
    /// A set of registry entries, as a tag name or a list of entry names.
    /// </summary>
    /// <remarks>
    /// The registry is named at the call site because it cannot be recovered from the value: an
    /// <see cref="IdSet"/> holds protocol ids and the data holds names, and which registry maps
    /// between them is a property of the component. It is items for <c>repairable</c> and damage
    /// types for <c>damage_resistant</c>.
    /// </remarks>
    public IdSet IdSet(string key, IProtocolTypeRegistry registry) {
        return ToIdSet(key, HolderSet.FromNbt(Require(key)), registry);
    }

    public IdSet? IdSetOrNull(string key, IProtocolTypeRegistry registry) {
        INbtTag? tag = Optional(key);
        return tag is null ? null : ToIdSet(key, HolderSet.FromNbt(tag), registry);
    }

    /// <inheritdoc cref="CompoundBuilder.Sound"/>
    public Or<ISoundType, SoundEvent>? Sound(string key, MinecraftRegistry registry) {
        return Or(key,
            tag => registry.SoundTypes[(Identifier)tag.GetString()],
            node => SoundEvent.FromNbt(node._tag, registry));
    }

    // ------------------------------------------------------------------ unions

    /// <summary>
    /// One of two shapes, decided by the tag itself: a name for the first, an object for the second.
    /// This is vanilla's <c>Codec.either</c> over a registry entry and an inline one.
    /// </summary>
    public Or<T1, T2>? Or<T1, T2>(string key, Func<INbtTag, T1> named, Func<NbtNode, T2> inline) {
        INbtTag? tag = Optional(key);

        if (tag is null) {
            return null;
        }

        return tag is CompoundTag
            ? Schemas.Or<T1, T2>.FromValue2(inline(Of(tag, _component)))
            : Schemas.Or<T1, T2>.FromValue1(named(tag));
    }

    // ------------------------------------------------------------------ enums

    /// <summary>
    /// An enum by the name vanilla writes, which is the member's name in lower snake case.
    /// </summary>
    /// <remarks>
    /// An enum whose vanilla names are not that transform takes the overload with its own parse
    /// instead. Which enums those are is pinned by the conformance fixture rather than assumed.
    /// </remarks>
    public TEnum Enum<TEnum>(string key) where TEnum : struct, Enum {
        return Parse<TEnum>(key, String(key));
    }

    public TEnum Enum<TEnum>(string key, TEnum fallback) where TEnum : struct, Enum {
        string? name = StringOrNull(key);
        return name is null ? fallback : Parse<TEnum>(key, name);
    }

    /// <summary>Every member of <typeparamref name="TEnum"/> by the name vanilla writes for it.</summary>
    public static IReadOnlyDictionary<string, TEnum> NamesOf<TEnum>() where TEnum : struct, Enum {
        return EnumNames<TEnum>.ByName;
    }

    /// <summary>The name vanilla writes for one member.</summary>
    public static string NameOf<TEnum>(TEnum value) where TEnum : struct, Enum {
        return EnumNames<TEnum>.ByValue[value];
    }

    // ------------------------------------------------------------------ finishing

    /// <summary>
    /// Throws naming the first key nothing asked for. The last line of every codec's read.
    /// </summary>
    public void AssertRead() {
        foreach ((string key, INbtTag _) in _tag.Children) {
            if (!_read.Contains(key)) {
                throw new UnportedComponentException(_component,
                    $"field {key}, which this build does not read. A field a datapack carries is a "
                    + "field that changes what the item is.");
            }
        }
    }

    // ------------------------------------------------------------------ internals

    private T Read<T>(string key, Func<INbtTag, T> read) {
        return Convert(key, read, Require(key));
    }

    private T Read<T>(string key, Func<INbtTag, T> read, T fallback) {
        INbtTag? tag = Optional(key);
        return tag is null ? fallback : Convert(key, read, tag);
    }

    private T Convert<T>(string key, Func<INbtTag, T> read, INbtTag tag) {
        try {
            return read(tag);
        } catch (Exception e) when (e is InvalidCastException or ArgumentOutOfRangeException) {
            // The tag accessors say what they wanted and what they got, and nothing about where. At
            // a hundred codecs of a dozen fields each that is not enough to find the field by.
            throw new UnportedComponentException(_component,
                $"field {key} is a {tag.GetType().Name}, which does not read as one: {e.Message}");
        }
    }

    private TType Resolve<TType>(string key, IProtocolTypeRegistry<TType> registry, INbtTag tag)
        where TType : IProtocolType {

        Identifier id = tag.GetString();

        if (!registry.Contains(id)) {
            throw new UnportedComponentException(_component,
                $"\"{key}\" names {id}, which is not in {registry.RegistryId}.");
        }

        return registry.Get(id);
    }

    private IdSet ToIdSet(string key, HolderSet set, IProtocolTypeRegistry registry) {
        if (set is HolderSet.Tag tag) {
            return new IdSet.Tag(tag.TagName);
        }

        Identifier[] names = ((HolderSet.Direct)set).Entries;
        int[] ids = new int[names.Length];

        for (int i = 0; i < names.Length; i++) {
            if (!registry.Contains(names[i])) {
                throw new UnportedComponentException(_component,
                    $"\"{key}\" names {names[i]}, which is not in {registry.RegistryId}.");
            }

            ids[i] = registry.GetProtocolId(names[i]);
        }

        return new IdSet.Ids(ids);
    }

    private TEnum Parse<TEnum>(string key, string name) where TEnum : struct, Enum {
        if (!EnumNames<TEnum>.ByName.TryGetValue(name, out TEnum value)) {
            throw new UnportedComponentException(_component,
                $"\"{key}\" is \"{name}\", which is not a {typeof(TEnum).Name}.");
        }

        return value;
    }

    /// <summary>The two directions of one enum's vanilla names, built once.</summary>
    private static class EnumNames<TEnum> where TEnum : struct, Enum {
        public static readonly FrozenDictionary<string, TEnum> ByName;
        public static readonly FrozenDictionary<TEnum, string> ByValue;

        static EnumNames() {
            Dictionary<string, TEnum> byName = [];
            Dictionary<TEnum, string> byValue = [];

            foreach (TEnum value in System.Enum.GetValues<TEnum>()) {
                string name = SnakeCase(value.ToString()!);
                byName[name] = value;
                byValue.TryAdd(value, name);
            }

            ByName = byName.ToFrozenDictionary();
            ByValue = byValue.ToFrozenDictionary();
        }

        private static string SnakeCase(string name) {
            System.Text.StringBuilder builder = new(name.Length + 4);

            for (int i = 0; i < name.Length; i++) {
                if (char.IsUpper(name[i])) {
                    if (i != 0) {
                        builder.Append('_');
                    }

                    builder.Append(char.ToLowerInvariant(name[i]));
                    continue;
                }

                builder.Append(name[i]);
            }

            return builder.ToString();
        }
    }
}

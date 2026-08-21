using Minecraft.Registry;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Codecs;

/// <summary>
/// Codecs for the component shapes that carry no field names of their own.
/// </summary>
/// <remarks>
/// Roughly a third of the components are one of these, and writing each out by hand would be a third
/// of the surface where a read and a write can disagree, for no expressiveness gained.
/// <p/>
/// <b>Bare and wrapped are separate on purpose.</b> A component whose value is a lone number is not
/// interchangeable with one that puts the same number under a key, and which of the two a component
/// is does not follow from its type: <c>max_stack_size</c> is a bare number and <c>enchantable</c> is
/// <c>{"value": n}</c>. The overload taken says which, at the component.
/// </remarks>
public static class NbtCodecs {
    /// <summary>
    /// A component with no value, whose presence is the whole of it. Written as an empty object,
    /// which is what vanilla's <c>Unit</c> codec encodes to.
    /// </summary>
    public static NbtCodec<None> Unit() {
        return new NbtCodec<None>(
            (_, _) => new CompoundTag(),
            (_, _) => None.Value);
    }

    // ------------------------------------------------------------------ bare values

    public static NbtCodec<int> Int() {
        return new NbtCodec<int>(
            (val, _) => new IntegerTag(val),
            (tag, _) => tag.GetInteger());
    }

    public static NbtCodec<long> Long() {
        return new NbtCodec<long>(
            (val, _) => new LongTag(val),
            (tag, _) => tag.GetLong());
    }

    public static NbtCodec<float> Float() {
        return new NbtCodec<float>(
            (val, _) => new FloatTag(val),
            (tag, _) => tag.GetFloat());
    }

    public static NbtCodec<double> Double() {
        return new NbtCodec<double>(
            (val, _) => new DoubleTag(val),
            (tag, _) => tag.GetDouble());
    }

    public static NbtCodec<bool> Bool() {
        return new NbtCodec<bool>(
            (val, _) => new BooleanTag(val),
            (tag, _) => tag.GetBoolean());
    }

    public static NbtCodec<string> String() {
        return new NbtCodec<string>(
            (val, _) => new StringTag(val),
            (tag, _) => tag.GetString());
    }

    public static NbtCodec<Identifier> Id() {
        return new NbtCodec<Identifier>(
            (val, _) => new StringTag(val.ToString()),
            (tag, _) => tag.GetString());
    }

    public static NbtCodec<Identifier[]> Ids() {
        return new NbtCodec<Identifier[]>(
            (val, _) => new ListTag(val.Select(id => (INbtTag)new StringTag(id.ToString())).ToArray()),
            (tag, _) => tag.GetList().Tags.ToArray().Select(id => (Identifier)id.GetString()).ToArray());
    }

    /// <summary>An enum by the name vanilla writes for it, with no key around it.</summary>
    public static NbtCodec<TEnum> Enum<TEnum>(Identifier component) where TEnum : struct, Enum {
        return new NbtCodec<TEnum>(
            (val, _) => new StringTag(NbtNode.NameOf(val)),
            (tag, _) => {
                string name = tag.GetString();

                if (!NbtNode.NamesOf<TEnum>().TryGetValue(name, out TEnum value)) {
                    throw new UnportedComponentException(component,
                        $"\"{name}\" is not a {typeof(TEnum).Name}.");
                }

                return value;
            });
    }

    /// <summary>
    /// Arbitrary data, for a component whose value vanilla does not look inside either.
    /// </summary>
    public static NbtCodec<INbtTag> Raw() {
        return new NbtCodec<INbtTag>(
            (val, _) => val,
            (tag, _) => tag);
    }

    public static NbtCodec<TextComponent> Text() {
        return new NbtCodec<TextComponent>(
            (val, _) => val.SerialiseToTag(),
            (tag, _) => TextComponent.FromTag(tag));
    }

    public static NbtCodec<TextComponent[]> TextList() {
        return new NbtCodec<TextComponent[]>(
            (val, _) => new ListTag(val.Select(text => (INbtTag)text.SerialiseToTag()).ToArray()),
            (tag, _) => tag.GetList().Tags.ToArray().Select(TextComponent.FromTag).ToArray());
    }

    // ------------------------------------------------------------------ registry references

    /// <summary>A lone registry entry name.</summary>
    public static NbtCodec<T> Holder<T>(Identifier component,
        Func<MinecraftRegistry, IProtocolTypeRegistry<T>> registry) where T : IProtocolType {

        return new NbtCodec<T>(
            (val, _) => new StringTag(val.Identifier.ToString()),
            (tag, reg) => {
                IProtocolTypeRegistry<T> entries = registry(reg);
                Identifier id = tag.GetString();

                if (!entries.Contains(id)) {
                    throw new UnportedComponentException(component,
                        $"{id} is not in {entries.RegistryId}.");
                }

                return entries.Get(id);
            });
    }

    /// <summary>A lone tag name or list of entry names.</summary>
    public static NbtCodec<IdSet> IdSet(Identifier component,
        Func<MinecraftRegistry, IProtocolTypeRegistry> registry) {

        return new NbtCodec<IdSet>(
            (val, reg) => ToHolderSet(val, registry(reg)).ToNbt(),
            (tag, reg) => Resolve(component, HolderSet.FromNbt(tag), registry(reg)));
    }

    // ------------------------------------------------------------------ single field wrappers

    /// <summary>
    /// A value under a key of its own, for a component whose data is an object holding one field.
    /// </summary>
    public static NbtCodec<T> Wrapped<T>(Identifier component, string key,
        Func<T, MinecraftRegistry, INbtTag> write, Func<INbtTag, MinecraftRegistry, T> read) {

        return new NbtCodec<T>(
            (val, reg) => new CompoundTag((key, write(val, reg))),
            (tag, reg) => {
                NbtNode node = NbtNode.Of(tag, component);
                T value = read(node.Require(key), reg);
                node.AssertRead();
                return value;
            });
    }

    /// <summary>The same, over a codec that already knows the value's shape.</summary>
    public static NbtCodec<T> Wrapped<T>(Identifier component, string key, NbtCodec<T> inner) {
        return Wrapped(component, key, inner.ToNbt, inner.FromNbt);
    }

    /// <summary>An id set as the names a datapack writes, which is what <see cref="HolderSet"/> is.</summary>
    internal static HolderSet ToHolderSet(IdSet set, IProtocolTypeRegistry registry) {
        if (set is IdSet.Tag tag) {
            return new HolderSet.Tag(tag.TagName);
        }

        int[] ids = ((IdSet.Ids)set).Values;
        Identifier[] names = new Identifier[ids.Length];

        for (int i = 0; i < ids.Length; i++) {
            names[i] = registry.NameOf(ids[i]);
        }

        return new HolderSet.Direct(names);
    }

    private static IdSet Resolve(Identifier component, HolderSet set, IProtocolTypeRegistry registry) {
        if (set is HolderSet.Tag tag) {
            return new IdSet.Tag(tag.TagName);
        }

        Identifier[] names = ((HolderSet.Direct)set).Entries;
        int[] ids = new int[names.Length];

        for (int i = 0; i < names.Length; i++) {
            if (!registry.Contains(names[i])) {
                throw new UnportedComponentException(component,
                    $"{names[i]} is not in {registry.RegistryId}.");
            }

            ids[i] = registry.GetProtocolId(names[i]);
        }

        return new IdSet.Ids(ids);
    }
}

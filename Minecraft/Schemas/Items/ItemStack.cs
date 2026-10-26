using System.Collections.ObjectModel;
using Minecraft.Data;
using Minecraft.Data.Components;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Implementations.Tags;
using Minecraft.Registry;
using NBT;
using NBT.Tags;
using Newtonsoft.Json.Linq;

namespace Minecraft.Schemas.Items;

/// <summary>
/// Immutable representation of an stack of items.
/// Or a `Slot` in a container.
/// </summary>
public class ItemStack(
    IItem type,
    int count = 1,
    Dictionary<IDataComponent, object>? components = null,
    IDataComponent[]? removeComponents = null) : 
    IImmutableTaggability<ItemStack>, INetworkType<ItemStack>, 
    IEquatable<ItemStack> {

    public int Count { get; } = count;
    public IItem Type { get; }  = type;
    public IReadOnlyDictionary<IDataComponent, object> Components => new ReadOnlyDictionary<IDataComponent, object>(_components);
    public IReadOnlyCollection<IDataComponent> RemoveComponents => new ReadOnlyCollection<IDataComponent>(_removeComponents);
    
    private readonly Dictionary<IDataComponent, object> _components  = components ?? [];
    private readonly IDataComponent[] _removeComponents  = removeComponents ?? [];
    
    public static readonly ItemStack Air = new(Item.Air, 0);

    public ItemStack With<T>(IDataComponent<T> component, T value) where T : notnull {
        return With((IDataComponent)component, value);
    }

    /// <summary>
    /// The same, for a component whose value type is not known at the call site. Reading a stack out
    /// of data is that: the component comes back from the registry as an <see cref="IDataComponent"/>
    /// and its codec answers an <see cref="object"/>.
    /// </summary>
    public ItemStack With(IDataComponent component, object value) {
        Dictionary<IDataComponent, object> newComponents = new(_components) {
            [component] = value
        };
        // A patch says either what a component is or that it is gone, never both, so setting one that
        // had been removed takes the removal back off.
        return new ItemStack(Type, Count, newComponents,
            _removeComponents.Where(c => !c.Equals(component)).ToArray());
    }

    /// <summary>
    /// The stack without <paramref name="component"/>, including without the one its item type carries
    /// by default. That is the difference from never setting it: the removal travels to the client, so
    /// a shield with <c>minecraft:blocks_attacks</c> taken off stops blocking there as well as here.
    /// </summary>
    public ItemStack Without<T>(IDataComponent<T> component) {
        return new ItemStack(Type, Count,
            _components.Where(kvp => !kvp.Key.Equals(component)).ToDictionary(),
            _removeComponents.Contains(component) ? _removeComponents : [.._removeComponents, component]);
    }
    
    public ItemStack WithCount(int count) {
        return new ItemStack(Type, count, _components, _removeComponents);
    }

    public int GetMaxStackSize(int def = 64) {
        return GetStructOrNull(DataComponent.MaxStackSize) ?? def;
    }
    
    public ItemStack SubtractCount(int count) {
        if (Count <= count) {
            return Air;
        }
        
        return new ItemStack(Type, Count - count, _components, _removeComponents);
    }

    public bool CanStackWith(ItemStack other) {
        if (Type.Identifier != other.Type.Identifier) {
            return false;
        }

        if (_components.Count != other._components.Count) {
            return false;
        }

        if (_removeComponents.Length != other._removeComponents.Length) {
            return false;
        }

        foreach (KeyValuePair<IDataComponent, object> kvp in _components) {
            if (!other._components.TryGetValue(kvp.Key, out object? otherValue)) {
                return false;
            }
            if (!kvp.Key.ValuesEqual(kvp.Value, otherValue)) {
                return false;
            }
        }
        return true;
    }

    public bool Equals(ItemStack? other) {
        if (other == null) {
            return false;
        }

        if (ReferenceEquals(this, other)) {
            return true;
        }

        if (!CanStackWith(other)) {
            return false;
        }

        if (Count != other.Count) {
            return false;
        }
        
        return true;
    }

    public override bool Equals(object? obj) {
        return obj is ItemStack other && Equals(other);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Type.Identifier, Count, _components.Count, _removeComponents.Length) +
               _components.Aggregate(0, (hash, kvp) => hash ^ HashCode.Combine(kvp.Key.Identifier.GetHashCode(), kvp.Value)) +
               _removeComponents.Aggregate(0, (hash, component) => hash ^ component.Identifier.GetHashCode());
    }

    public bool IsAir() {
        return Count == 0 || Type.Identifier == Item.Air.Identifier;
    }
    
    public T Get<T>(IDataComponent<T> type, bool ignoreDefaults = false) {
        if (_components.TryGetValue(type, out object? component)) {
            return (T)component;
        }
        if (component == null && ignoreDefaults) {
            throw new KeyNotFoundException($"Component {type.Identifier} not found in ItemStack.");
        }

        // Look for default value, unless the stack says the item's default is gone
        if (!_removeComponents.Contains(type) && Type.DefaultComponents.TryGetValue(type, out object? defaultComponent)) {
            return (T)defaultComponent;
        }
        
        throw new KeyNotFoundException($"Component {type.Identifier} not found in ItemStack and no default value available.");
    }
    
    public T GetOrDefault<T>(IDataComponent<T> type, T defaultValue) {
        return Has(type) ? Get(type) : defaultValue;
    }
    
    public T? GetOrNull<T>(IDataComponent<T> type) where T : class {
        return Has(type) ? Get(type) : null;
    }
    
    public bool Has<T>(IDataComponent<T> type) {
        if (_components.ContainsKey(type)) {
            return true;
        }

        return !_removeComponents.Contains(type) && Type.DefaultComponents.ContainsKey(type);
    }

    public T? GetStructOrNull<T>(IDataComponent<T> type) where T : struct {
        return Has(type) ? Get(type) : null;
    }

    /// <summary>
    /// <c>EnchantmentHelper.getItemEnchantmentLevel</c>: the level of one enchantment on this stack,
    /// or zero when it is not on it.
    /// </summary>
    public int GetEnchantmentLevel(IEnchantment enchantment) {
        foreach ((IEnchantment present, int level) in GetOrDefault(DataComponent.Enchantments, [])) {
            if (present.Identifier == enchantment.Identifier) {
                return level;
            }
        }

        return 0;
    }

    /// <summary>
    /// <see cref="GetEnchantmentLevel(IEnchantment)"/> by name, for a caller holding an identifier
    /// rather than the registry entry. An enchantment that is not on the stack reads as level zero.
    /// </summary>
    public int GetEnchantmentLevel(Identifier enchantment) {
        foreach ((IEnchantment present, int level) in GetOrDefault(DataComponent.Enchantments, [])) {
            if (present.Identifier == enchantment) {
                return level;
            }
        }

        return 0;
    }

    public TradeItem AsTradeItem() {
        return new TradeItem(this);
    }
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        if (Count == 0 || Type.Identifier == "minecraft:air") {
            return writer.WriteVarInt(0);
        }
        
        writer.WriteVarInt(Count);
        writer.WriteVarInt(registry.Items.GetProtocolId(Type));
        return WriteComponentPatch(writer, registry);
    }

    /// <summary>
    /// The stack as a datapack or a saved world spells it, which is vanilla's <c>ItemStack.CODEC</c>.
    /// </summary>
    /// <remarks>
    /// <b>Not the wire form.</b> That is <see cref="WriteData"/>, where a component is a protocol id
    /// and a payload with no key names in it.
    /// <p/>
    /// A count of one is left off, as vanilla leaves it off. A component the patch removes is written
    /// under its name with a <c>!</c> in front, which is how one patch says both what a component is
    /// and that another is gone.
    /// </remarks>
    public CompoundTag ToNbt(MinecraftRegistry registry) {
        List<(string, INbtTag)> fields = [("id", new StringTag(Type.Identifier.ToString()))];

        if (Count != 1) {
            fields.Add(("count", new IntegerTag(Count)));
        }

        List<(string, INbtTag)> patch = [];

        foreach ((IDataComponent component, object value) in _components) {
            patch.Add((component.Identifier.ToString(), component.ToNbt(value, registry)));
        }

        foreach (IDataComponent component in _removeComponents) {
            patch.Add(("!" + component.Identifier, new CompoundTag()));
        }

        if (patch.Count != 0) {
            fields.Add(("components", new CompoundTag(patch.ToArray())));
        }

        return new CompoundTag(fields.ToArray());
    }

    /// <inheritdoc cref="ToNbt"/>
    public static ItemStack FromNbt(INbtTag tag, MinecraftRegistry registry) {
        CompoundTag compound = tag.GetCompound();
        Dictionary<IDataComponent, object> components = [];
        List<IDataComponent> removed = [];

        if (compound["components"] is { } patch) {
            foreach ((string key, INbtTag value) in patch.GetCompound().Children) {
                bool remove = key.StartsWith('!');
                Identifier name = remove ? key[1..] : key;

                if (!registry.DataComponents.Contains(name)) {
                    throw new InvalidOperationException($"No data component called \"{name}\".");
                }

                IDataComponent component = registry.DataComponents[name];

                if (remove) {
                    removed.Add(component);
                    continue;
                }

                components[component] = component.FromNbt(value, registry);
            }
        }

        return new ItemStack(
            registry.Items[(Identifier)compound["id"].GetString()],
            compound.Contains("count") ? compound["count"].AsInt() : 1,
            components,
            removed.ToArray());
    }

    public static ItemStack ReadData(DataReader reader, MinecraftRegistry registry) {
        int count = reader.ReadVarInt();
        if (count == 0) {
            return Air;
        }

        int itemId = reader.ReadVarInt();
        return ReadComponentPatch(reader, registry, registry.Items[itemId], count);
    }

    /// <summary>
    /// Writes the stack in the "template" form recipe displays use. It always names an item, so
    /// there is no encoding for an empty stack, and the item comes before the count.
    /// </summary>
    public DataWriter WriteTemplateData(DataWriter writer, MinecraftRegistry registry) {
        writer.WriteVarInt(registry.Items.GetProtocolId(Type));
        writer.WriteVarInt(Count);
        return WriteComponentPatch(writer, registry);
    }

    public static ItemStack ReadTemplateData(DataReader reader, MinecraftRegistry registry) {
        IItem item = registry.Items[reader.ReadVarInt()];
        int count = reader.ReadVarInt();
        return ReadComponentPatch(reader, registry, item, count);
    }

    private DataWriter WriteComponentPatch(DataWriter writer, MinecraftRegistry registry) {
        writer.WriteVarInt(_components.Count);  // components to add
        writer.WriteVarInt(_removeComponents.Length);  // components to remove

        writer.WriteArray(_components, (kvp, w) => w
            .WriteVarInt(registry.DataComponents.GetProtocolId(kvp.Key))
            .Write(wr => kvp.Key.WriteData(kvp.Value, wr, registry)));

        return writer.WriteArray(_removeComponents, (component, w) => w
            .WriteVarInt(registry.DataComponents.GetProtocolId(component)));
    }

    private static ItemStack ReadComponentPatch(DataReader reader, MinecraftRegistry registry, IItem item, int count) {
        int addCount = reader.ReadVarInt();
        int removeCount = reader.ReadVarInt();

        KeyValuePair<IDataComponent, object>[] components = reader.ReadArray(addCount, r => {
            int netId = r.ReadVarInt();
            IDataComponent component = registry.DataComponents[netId];
            return new KeyValuePair<IDataComponent, object>(component, component.ReadData(r, registry));
        });

        IDataComponent[] removeComponents = reader.ReadArray(removeCount, r => {
            int netId = r.ReadVarInt();
            return registry.DataComponents[netId];
        });

        return new ItemStack(item, count, new Dictionary<IDataComponent, object>(components), removeComponents);
    }

    public T GetTag<T>(Tag<T> tag) {
        if (!HasTag(tag)) {
            throw new KeyNotFoundException($"Tag {tag.Id} not found in ItemStack.");
        }
        
        CompoundTag nbt = Get(DataComponent.CustomData).GetCompound();
        JToken json = INbtTag.ToJson(nbt[tag.Id]!);
        
        return json.ToObject<T>() ?? throw new InvalidCastException($"Cannot cast tag {tag.Id} to {typeof(T).Name}.");
    }
    
    public bool HasTag<T>(Tag<T> tag) {
        INbtTag? nbt = GetOrNull(DataComponent.CustomData);
        return nbt is CompoundTag ct && ct.Contains(tag.Id);
    }
    
    public ItemStack WithTag<T>(Tag<T> tag, T? value) {
        CompoundTag nbt = GetOrNull(DataComponent.CustomData)?.GetCompound() ?? new CompoundTag();

        if (value == null) {
            return With(DataComponent.CustomData, new CompoundTag(nbt.Children
                .Where(t => t.Item1 != tag.Id)
                .ToArray()));
        }
        
        JToken json = JToken.FromObject(value);
        INbtTag nbtVal = INbtTag.FromJson(json);
        
        nbt = new CompoundTag(nbt.Children
            .Where(t => t.Item1 != tag.Id)
            .Append((tag.Id, nbtVal))
            .ToArray());
        
        return With(DataComponent.CustomData, nbt);
    }
    
    public ItemStack WithoutTag<T>(Tag<T> tag) {
        CompoundTag nbt = GetOrNull(DataComponent.CustomData)?.GetCompound() ?? new CompoundTag();
        
        if (!nbt.Contains(tag.Id)) {
            return this;  // No change if tag doesn't exist
        }
        
        nbt = new CompoundTag(nbt.Children
            .Where(t => t.Item1 != tag.Id)
            .ToArray());
        
        return With(DataComponent.CustomData, nbt);
    }
    
    public T? GetTagOrNull<T>(Tag<T> tag) {
        if (!HasTag(tag)) {
            return default;
        }
        
        return GetTag(tag);
    }
    
    public Optional<T> GetTagOptional<T>(Tag<T> tag) {
        if (!HasTag(tag)) {
            return Optional<T>.Empty;
        }
        
        return new Optional<T>(GetTag(tag));
    }
    
    public T GetTagOrDefault<T>(Tag<T> tag, T defaultValue) {
        if (!HasTag(tag)) {
            return defaultValue;
        }
        
        return GetTag(tag);
    }
}

using System.Collections.ObjectModel;
using Minecraft.Data;
using Minecraft.Data.Components;
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
    IImmutableTaggability<ItemStack>, INetworkType<ItemStack> {

    public int Count { get; } = count;
    public IItem Type { get; }  = type;
    public IReadOnlyDictionary<IDataComponent, object> Components => new ReadOnlyDictionary<IDataComponent, object>(_components);
    public IReadOnlyCollection<IDataComponent> RemoveComponents => new ReadOnlyCollection<IDataComponent>(_removeComponents);
    
    private readonly Dictionary<IDataComponent, object> _components  = components ?? [];
    private readonly IDataComponent[] _removeComponents  = removeComponents ?? [];
    
    public static readonly ItemStack Air = new(Item.Air, 0);

    public ItemStack With<T>(IDataComponent<T> component, T value) where T : notnull {
        Dictionary<IDataComponent, object> newComponents = new(_components) {
            [component] = value
        };
        return new ItemStack(Type, Count, newComponents, _removeComponents);
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

        // TODO: Check if all components match
        return true;
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
        
        // Look for default value
        if (Type.DefaultComponents.TryGetValue(type, out object? defaultComponent)) {
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
        return _components.ContainsKey(type) || Type.DefaultComponents.ContainsKey(type);
    }

    public T? GetStructOrNull<T>(IDataComponent<T> type) where T : struct {
        return Has(type) ? Get(type) : null;
    }
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        if (Count == 0 || Type.Identifier == "minecraft:air") {
            return writer.WriteVarInt(0);
        }
        
        writer.WriteVarInt(Count);
        writer.WriteVarInt(Type.ProtocolId);
        
        writer.WriteVarInt(_components.Count);  // components to add
        writer.WriteVarInt(_removeComponents.Length);  // components to remove

        writer.WriteArray(_components, (kvp, w) => w
            .WriteVarInt(kvp.Key.ProtocolId)
            .Write(wr => kvp.Key.WriteData(kvp.Value, wr, registry)));
        
        return writer.WriteArray(_removeComponents, (component, w) => w
            .WriteVarInt(component.ProtocolId));
    }

    public static ItemStack ReadData(DataReader reader, MinecraftRegistry registry) {
        int count = reader.ReadVarInt();
        if (count == 0) {
            return Air;
        }
        
        int itemId = reader.ReadVarInt();
        
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
        
        return new ItemStack(registry.Items[itemId], count, new Dictionary<IDataComponent, object>(components), removeComponents);
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
        return nbt is CompoundTag ct && ct.ChildrenMap.ContainsKey(tag.Id);
    }
    
    public ItemStack WithTag<T>(Tag<T> tag, T? value) {
        CompoundTag nbt = GetOrNull(DataComponent.CustomData)?.GetCompound() ?? new CompoundTag(null);

        if (value == null) {
            return With(DataComponent.CustomData, new CompoundTag(null, nbt.Children
                .Where(t => t?.GetName() != tag.Id)
                .ToArray()));
        }
        
        JToken json = JToken.FromObject(value);
        INbtTag nbtVal = INbtTag.FromJson(tag.Id, json);
        
        nbt = new CompoundTag(null, nbt.Children
            .Where(t => t?.GetName() != tag.Id)
            .Append(nbtVal)
            .ToArray());
        
        return With(DataComponent.CustomData, nbt);
    }
    
    public ItemStack WithoutTag<T>(Tag<T> tag) {
        CompoundTag nbt = GetOrNull(DataComponent.CustomData)?.GetCompound() ?? new CompoundTag(null);
        
        if (!nbt.ChildrenMap.ContainsKey(tag.Id)) {
            return this;  // No change if tag doesn't exist
        }
        
        nbt = new CompoundTag(null, nbt.Children
            .Where(t => t?.GetName() != tag.Id)
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

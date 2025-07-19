using Minecraft.Data.Components;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Implementations.Tags;
using Minecraft.Registry;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace Minecraft.Schemas.Items;

/// <summary>
/// Immutable representation of an stack of items.
/// Or a `Slot` in a container.
/// </summary>
public class ItemStack(int count, IItem? type = null, Dictionary<IDataComponent, object>? components = null, IDataComponent[]? removeComponents = null) {
    public readonly int Count = count;
    public readonly IItem Type = type ?? Item.Air;
    public readonly Dictionary<IDataComponent, object> Components = components ?? [];
    public readonly IDataComponent[] RemoveComponents = removeComponents ?? [];
    
    public static readonly ItemStack Air = new(0);

    public ItemStack With<T>(IDataComponent<T> component, T value) where T : notnull {
        Dictionary<IDataComponent, object> newComponents = new(Components) {
            [component] = value
        };
        return new ItemStack(Count, Type, newComponents, RemoveComponents);
    }
    
    public ItemStack WithCount(int count) {
        return new ItemStack(count, Type, Components, RemoveComponents);
    }
    
    public ItemStack SubtractCount(int count) {
        if (Count <= count) {
            return Air;
        }
        
        return new ItemStack(Count - count, Type, Components, RemoveComponents);
    }

    public bool CanStackWith(ItemStack other) {
        if (Type.Identifier != other.Type.Identifier) {
            return false;
        }

        if (Components.Count != other.Components.Count) {
            return false;
        }

        if (RemoveComponents.Length != other.RemoveComponents.Length) {
            return false;
        }

        // TODO: Check if all components match
        return true;
    }
    
    public bool IsAir() {
        return Count == 0 || Type.Identifier == Item.Air.Identifier;
    }
    
    public T? Get<T>(IDataComponent<T> type) {
        Components.TryGetValue(type, out object? component);
        return component == null ? default : (T)component;
    }

    public T? GetStruct<T>(IDataComponent<T> type) where T : struct {
        Components.TryGetValue(type, out object? component);
        return component == null ? default : (T)component;
    }
    
    public void Write(DataWriter writer, MinecraftRegistry registry) {
        if (Count == 0) {
            writer.WriteVarInt(0);
            return;
        }
        
        writer.WriteVarInt(Count);
        writer.WriteVarInt(Type.ProtocolId);
        
        writer.WriteVarInt(Components.Count);  // components to add
        writer.WriteVarInt(RemoveComponents.Length);  // components to remove

        writer.WriteArray(Components, (kvp, w) => w
            .WriteVarInt(kvp.Key.ProtocolId)
            .Write(wr => kvp.Key.WriteData(kvp.Value, wr, registry)));
        
        writer.WriteArray(RemoveComponents, (component, w) => w
            .WriteVarInt(registry.DataComponents[component.Identifier]));
    }

    public static ItemStack Read(DataReader reader, MinecraftRegistry registry) {
        int count = reader.ReadVarInt();
        if (count == 0) {
            return new ItemStack(0);
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
        
        return new ItemStack(count, registry.Items[itemId], new Dictionary<IDataComponent, object>(components), removeComponents);
    }

    public T GetTag<T>(Tag<T> tag) {
        if (!HasTag(tag)) {
            throw new KeyNotFoundException($"Tag {tag.Id} not found in ItemStack.");
        }
        
        CompoundTag nbt = Get(DataComponent.CustomData)!.GetCompound();

        return typeof(T) switch {
            { } t when t == typeof(int) => (T)(object)nbt[tag.Id].GetInteger(),
            { } t when t == typeof(string) => (T)(object)nbt[tag.Id].GetString(),
            { } t when t == typeof(float) => (T)(object)nbt[tag.Id].GetFloat(),
            { } t when t == typeof(double) => (T)(object)nbt[tag.Id].GetDouble(),
            { } t when t == typeof(bool) => (T)(object)nbt[tag.Id].GetBoolean(),
            { } t when t == typeof(byte) => (T)(object)nbt[tag.Id].GetByte(),
            _ => throw new NotSupportedException($"Tag type {typeof(T)} is not supported.")
        };
    }
    
    public bool HasTag<T>(Tag<T> tag) {
        INbtTag? nbt = Get(DataComponent.CustomData);
        return nbt is CompoundTag ct && ct.ChildrenMap.ContainsKey(tag.Id);
    }
    
    public ItemStack With<T>(Tag<T> tag, T? value) {
        CompoundTag nbt = Get(DataComponent.CustomData)?.GetCompound() ?? new CompoundTag(null);

        if (value == null) {
            return With(DataComponent.CustomData, new CompoundTag(null, nbt.Children
                .Where(t => t?.GetName() != tag.Id)
                .ToArray()));
        }
        
        INbtTag nbtVal = value switch {
            int i => new IntegerTag(tag.Id, i),
            string s => new StringTag(tag.Id, s),
            float f => new FloatTag(tag.Id, f),
            double d => new DoubleTag(tag.Id, d),
            bool b => new BooleanTag(tag.Id, b),
            sbyte b => new ByteTag(tag.Id, b),
            _ => throw new NotSupportedException($"Tag type {typeof(T)} is not supported.")
        };
        
        nbt = new CompoundTag(null, nbt.Children
            .Where(t => t?.GetName() != tag.Id)
            .Append(nbtVal)
            .ToArray());
        
        return With(DataComponent.CustomData, nbt);
    }

    /// <summary>
    /// DO NOT USE THIS METHOD.
    /// ItemStack is immutable, so this method does nothing.
    /// <p/>
    /// Use <see cref=""/>
    /// </summary>
    [Obsolete("Use With(Tag<T> tag, T value) instead.")]
    public void SetTag<T>(Tag<T> tag, T value) {
        throw new NotSupportedException("ItemStack is immutable. Use With(Tag<T> tag, T value) instead.");
    }
}

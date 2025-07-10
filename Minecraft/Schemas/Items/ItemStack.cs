using Minecraft.Data.Components;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Registry;

namespace Minecraft.Schemas.Items;

public class ItemStack(int count, IItem? type = null, IDataComponent[]? components = null, IDataComponent[]? removeComponents = null) {
    public readonly int Count = count;
    public readonly IItem Type = type ?? Item.Air;
    public readonly IDataComponent[] Components = components ?? [];
    public readonly IDataComponent[] RemoveComponents = removeComponents ?? [];
    
    public static readonly ItemStack Air = new(0);

    public ItemStack With<T>(IDataComponent<T> component) {
        return new ItemStack(Count, Type, Components.Append(component).ToArray(), RemoveComponents);
    }
    
    public ItemStack WithCount(int count) {
        return new ItemStack(count, Type, Components, RemoveComponents);
    }

    public bool CanStackWith(ItemStack other) {
        if (Type.Identifier != other.Type.Identifier) {
            return false;
        }

        if (Components.Length != other.Components.Length) {
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
    
    public IDataComponent<T>? Get<T>(IDataComponent<T> type) {
        return Components.Where(component => component.Identifier == type.Identifier).Cast<IDataComponent<T>>().FirstOrDefault();
    }
    
    public void Write(DataWriter writer, MinecraftRegistry registry) {
        if (Count == 0) {
            writer.WriteVarInt(0);
            return;
        }
        
        writer.WriteVarInt(Count);
        writer.WriteVarInt(Type.ProtocolId);
        
        writer.WriteVarInt(Components.Length);  // components to add
        writer.WriteVarInt(RemoveComponents.Length);  // components to remove

        writer.WriteArray(Components, (component, w) => w
            .WriteVarInt(registry.DataComponents[component.Identifier])
            .Write(wr => component.WriteData(wr, registry)));
        
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

        IDataComponent[] components = reader.ReadArray(addCount, r => {
            int netId = r.ReadVarInt();
            IDataComponent component = registry.DataComponents[netId];
            return component.ReadData(r, registry);
        });
        
        IDataComponent[] removeComponents = reader.ReadArray(removeCount, r => {
            int netId = r.ReadVarInt();
            return registry.DataComponents[netId];
        });
        
        return new ItemStack(count, registry.Items[itemId], components, removeComponents);
    }
}

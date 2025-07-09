using Minecraft.Data.Components;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Registry;

namespace Minecraft.Schemas.Items;

// this field should be prefixed optional when used in the ClickContainer packet
public class HashedSlot(int count, IItem? type = null, (IDataComponent, int)[]? components = null, IDataComponent[]? removeComponents = null) {
    public readonly int Count = count;
    public readonly IItem Type = type ?? Item.Air;
    public readonly (IDataComponent, int)[] Components = components ?? [];
    public readonly IDataComponent[] RemoveComponents = removeComponents ?? [];
    
    public void Write(DataWriter writer, MinecraftRegistry registry) {
        writer.WriteVarInt(Type.ProtocolId);
        writer.WriteVarInt(Count);

        writer.WritePrefixedArray(Components, (component, w) => w
            .WriteVarInt(registry.DataComponents[component.Item1.Identifier])
            .WriteInteger(component.Item2));
        
        writer.WritePrefixedArray(RemoveComponents, (component, w) => w
            .WriteVarInt(registry.DataComponents[component.Identifier]));
    }

    public static HashedSlot Read(DataReader reader, MinecraftRegistry registry) {
        int itemId = reader.ReadVarInt();
        int count = reader.ReadVarInt();

        (IDataComponent, int)[] components = reader.ReadPrefixedArray(r => {
            int netId = r.ReadVarInt();
            int hash = r.ReadInteger();
            IDataComponent component = registry.DataComponents[netId];
            return (component, hash);
        });
        
        IDataComponent[] removeComponents = reader.ReadPrefixedArray(r => {
            int netId = r.ReadVarInt();
            return registry.DataComponents[netId];
        });
        
        return new HashedSlot(count, registry.Items[itemId], components, removeComponents);
    }
}

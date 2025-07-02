namespace Minecraft.Schemas.Items;

public class Slot(int count, int itemId = 0) : IWritable {
    public int Count = count;
    public int ItemId = itemId;
    
    public static readonly Slot Air = new(0);

    public void Write(DataWriter writer) {
        if (Count == 0) {
            writer.WriteVarInt(0);
            return;
        }
        
        writer.WriteVarInt(Count);
        writer.WriteVarInt(ItemId);
        
        writer.WriteVarInt(0);  // components to add
        writer.WriteVarInt(0);  // components to remove
    }

    public static Slot Read(DataReader reader) {
        int count = reader.ReadVarInt();
        if (count == 0) {
            return new Slot(0, 0);
        }
        
        int itemId = reader.ReadVarInt();
        
        // TODO: Components, otherwise the packet won't deserialise correctly
        throw new NotImplementedException();
        return new Slot(count, itemId);
    }
}
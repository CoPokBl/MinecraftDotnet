namespace Minecraft.Schemas;

public class Slot(int count = 0, int itemId = 0) : IWritable, IDataReadable<Slot> {
    public int Count = count;
    public int ItemId = itemId;

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

    public Slot Read(DataReader reader) {
        Count = reader.ReadVarInt();
        if (Count == 0) {
            return this;
        }
        
        ItemId = reader.ReadVarInt();
        
        // TODO: Components
        return this;
    }
}
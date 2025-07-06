namespace Minecraft.Schemas;

public abstract record IdSet : IWritable {
    
    public static IdSet Read(DataReader reader) {
        int length = reader.ReadVarInt();
        if (length == 0) {
            return new Tag(reader.ReadString());
        }
        
        int valsCount = length - 1;
        int[] vals = reader.ReadArray(valsCount, r => r.ReadVarInt());
        return new Ids(vals);
    }

    public record Tag(Identifier TagName) : IdSet {
        public override void Write(DataWriter writer) {
            writer.WriteVarInt(0).Write(TagName);
        }
    }

    public record Ids(int[] Values) : IdSet {
        public override void Write(DataWriter writer) {
            writer.WriteVarInt(Values.Length + 1).WriteArray(Values, (i, w) => w.WriteVarInt(i));
        }
    }

    public abstract void Write(DataWriter writer);
}

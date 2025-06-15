using System.Buffers.Binary;
using System.Text;
using Minecraft.NBT.Tags;

namespace Minecraft.NBT;

public class NbtReader(DataReader input) {
    
    public NbtReader(byte[] data) : this(new DataReader(data)) { }

    public ITag ToTag() {
        // Start by reading the tag type
        byte type = input.Read();

        // At the root level no tag will have a name
        return type switch {
            NbtTagPrefix.String => new StringTag(null, ReadString()),
            NbtTagPrefix.Byte => new ByteTag(null, input.Read()),
            NbtTagPrefix.Integer => new IntegerTag(null, ReadInteger()),
            NbtTagPrefix.Float => new FloatTag(null, ReadFloat()),
            NbtTagPrefix.Double => new DoubleTag(null, ReadDouble()),
            NbtTagPrefix.Compound => ReadCompoundTag(),
            NbtTagPrefix.List => ReadList(),
            _ => throw new InvalidDataException($"Unknown type {type}")
        };
    }
    
    public static ITag ReadNbt(byte[] data) {
        return new NbtReader(data).ToTag();
    }

    public static ITag ReadNbt(DataReader reader) {
        return new NbtReader(reader).ToTag();
    }

    // returns it strongly typed for convenience, except when it contains nested lists
    public ListTag ReadList() {
        byte type = input.Read();
        int length = ReadInteger();
        ITag[] tags = new ITag[length];

        switch (type) {
            case NbtTagPrefix.String:
                for (int i = 0; i < length; i++) tags[i] = new StringTag(null, ReadString());
                return new ListTag<StringTag>(null, tags.Cast<StringTag>().ToArray());
            case NbtTagPrefix.Byte:
                for (int i = 0; i < length; i++) tags[i] = new ByteTag(null, input.Read());
                return new ListTag<ByteTag>(null, tags.Cast<ByteTag>().ToArray());
            case NbtTagPrefix.Integer:
                for (int i = 0; i < length; i++) tags[i] = new IntegerTag(null, ReadInteger());
                return new ListTag<IntegerTag>(null, tags.Cast<IntegerTag>().ToArray());
            case NbtTagPrefix.Float:
                for (int i = 0; i < length; i++) tags[i] = new FloatTag(null, ReadFloat());
                return new ListTag<FloatTag>(null, tags.Cast<FloatTag>().ToArray());
            case NbtTagPrefix.Double:
                for (int i = 0; i < length; i++) tags[i] = new DoubleTag(null, ReadDouble());
                return new ListTag<DoubleTag>(null, tags.Cast<DoubleTag>().ToArray());
            case NbtTagPrefix.List:
                for (int i = 0; i < length; i++) tags[i] = ReadList();
                return new ListTag<ListTag>(null, tags.Cast<ListTag>().ToArray());
            case NbtTagPrefix.Compound:
                for (int i = 0; i < length; i++) tags[i] = ReadCompoundTag();
                return new ListTag<CompoundTag>(null, tags.Cast<CompoundTag>().ToArray());
        }
        
        throw new InvalidDataException($"Unknown type {type}");
    }

    public CompoundTag ReadCompoundTag() {
        List<ITag> children = [];
        
        // each child is written, but with a name this time.
        while (true) {
            byte type = input.Read();
            if (type == NbtTagPrefix.End) {
                return new CompoundTag(null, children.ToArray());
            }
            
            string name = ReadString();
            
            switch (type) {
                case NbtTagPrefix.String:
                    children.Add(new StringTag(name, ReadString()));
                    break;
                case NbtTagPrefix.Byte:
                    children.Add(new ByteTag(name, input.Read()));
                    break;
                case NbtTagPrefix.Integer:
                    children.Add(new IntegerTag(name, ReadInteger()));
                    break;
                case NbtTagPrefix.Float:
                    children.Add(new FloatTag(name, ReadFloat()));
                    break;
                case NbtTagPrefix.Double:
                    children.Add(new DoubleTag(name, ReadDouble()));
                    break;
                case NbtTagPrefix.Compound:
                    children.Add(ReadCompoundTag().WithName(name));
                    break;
                case NbtTagPrefix.List:
                    children.Add(ReadList().WithName(name));
                    break;
                default:
                    throw new InvalidDataException($"Unknown tag type {type}");
            }
        }
    }

    public string ReadString() {
        // read the length
        byte[] lenBytes = input.Read(sizeof(ushort));
        ushort len = BinaryPrimitives.ReadUInt16BigEndian(lenBytes);

        byte[] textBytes = input.Read(len);
        return Encoding.UTF8.GetString(textBytes);
    }

    public int ReadInteger() {
        return BinaryPrimitives.ReadInt32BigEndian(input.Read(sizeof(int)));
    }
    
    public float ReadFloat() {
        return BinaryPrimitives.ReadSingleBigEndian(input.Read(sizeof(float)));
    }
    
    public double ReadDouble() {
        return BinaryPrimitives.ReadDoubleBigEndian(input.Read(sizeof(double)));
    }
}
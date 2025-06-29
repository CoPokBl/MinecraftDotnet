using System.Buffers.Binary;
using System.Text;
using Minecraft.NBT.Tags;

namespace Minecraft.NBT;

public class NbtReader(DataReader input, NbtCompressionType compression = NbtCompressionType.None) {
    private DataReader _input = input;

    public NbtReader(byte[] data, NbtCompressionType compression = NbtCompressionType.None) : this(new DataReader(data), compression) { }

    /// <summary>
    /// Parses the current object's data into a tag.
    /// </summary>
    /// <param name="impliedRoot">
    /// Whether there should be an implied root compound tag.
    /// NOTE that using this will read the entire input stream, so it should only be used
    /// when the input stream is a single NBT tag (or the remaining is a single NBT tag).
    /// </param>
    /// <returns>The parsed tag.</returns>
    /// <remarks><see cref="impliedRoot"/> is mainly used for NBT files.</remarks>
    /// <exception cref="InvalidDataException">When the data contains invalid information.</exception>
    public ITag ToTag(bool impliedRoot = false) {
        switch (compression) {
            case NbtCompressionType.GZip:
                throw new NotImplementedException();
            
            case NbtCompressionType.ZLib:
                _input = new DataReader(CompressionHelper.DecompressZlib(_input.ReadRemaining()));
                break;
            
            case NbtCompressionType.None:
                break;  // do nothing
            
            default:
                throw new ArgumentOutOfRangeException(nameof(compression), compression, null);
        }
        
        if (impliedRoot) {
            DataWriter w = new DataWriter()
                .Write(NbtTagPrefix.Compound)
                .Write(_input.ReadRemaining())
                .Write(NbtTagPrefix.End);
            _input = new DataReader(w.ToArray());
        }
        
        // Start by reading the tag type
        byte type = _input.Read();

        // At the root level no tag will have a name
        return type switch {
            NbtTagPrefix.String => new StringTag(null, ReadString()),
            NbtTagPrefix.Byte => new ByteTag(null, _input.Read()),
            NbtTagPrefix.Integer => new IntegerTag(null, ReadInteger()),
            NbtTagPrefix.Long => new LongTag(null, ReadLong()),
            NbtTagPrefix.Short => new ShortTag(null, ReadShort()),
            NbtTagPrefix.Float => new FloatTag(null, ReadFloat()),
            NbtTagPrefix.Double => new DoubleTag(null, ReadDouble()),
            NbtTagPrefix.Compound => ReadCompoundTag(),
            NbtTagPrefix.End => new EmptyTag(),
            NbtTagPrefix.List => ReadList(),
            NbtTagPrefix.Integers => ReadIntegers(),
            NbtTagPrefix.Bytes => ReadBytes(),
            NbtTagPrefix.Longs => ReadLongs(),
            _ => throw new InvalidDataException($"Unknown type {type}")
        };
    }
    
    public static ITag ReadNbt(byte[] data, bool impliedRoot = false, NbtCompressionType compression = NbtCompressionType.None) {
        return new NbtReader(data, compression).ToTag(impliedRoot);
    }

    public static ITag ReadNbt(DataReader reader, NbtCompressionType compression = NbtCompressionType.None) {
        return new NbtReader(reader, compression).ToTag();
    }

    // returns it strongly typed for convenience, except when it contains nested lists
    public ListTag ReadList() {
        byte type = _input.Read();
        int length = ReadInteger();
        ITag[] tags = new ITag[length];

        switch (type) {
            case NbtTagPrefix.End:  // an empty list
                return new ListTag(null, []);
            case NbtTagPrefix.String:
                for (int i = 0; i < length; i++) tags[i] = new StringTag(null, ReadString());
                return new ListTag<StringTag>(null, tags.Cast<StringTag>().ToArray());
            case NbtTagPrefix.Byte:
                for (int i = 0; i < length; i++) tags[i] = new ByteTag(null, _input.Read());
                return new ListTag<ByteTag>(null, tags.Cast<ByteTag>().ToArray());
            case NbtTagPrefix.Integer:
                for (int i = 0; i < length; i++) tags[i] = new IntegerTag(null, ReadInteger());
                return new ListTag<IntegerTag>(null, tags.Cast<IntegerTag>().ToArray());
            case NbtTagPrefix.Long:
                for (int i = 0; i < length; i++) tags[i] = new LongTag(null, ReadLong());
                return new ListTag<LongTag>(null, tags.Cast<LongTag>().ToArray());
            case NbtTagPrefix.Short:
                for (int i = 0; i < length; i++) tags[i] = new ShortTag(null, ReadShort());
                return new ListTag<ShortTag>(null, tags.Cast<ShortTag>().ToArray());
            case NbtTagPrefix.Float:
                for (int i = 0; i < length; i++) tags[i] = new FloatTag(null, ReadFloat());
                return new ListTag<FloatTag>(null, tags.Cast<FloatTag>().ToArray());
            case NbtTagPrefix.Double:
                for (int i = 0; i < length; i++) tags[i] = new DoubleTag(null, ReadDouble());
                return new ListTag<DoubleTag>(null, tags.Cast<DoubleTag>().ToArray());
            case NbtTagPrefix.List:
                for (int i = 0; i < length; i++) tags[i] = ReadList();
                return new ListTag<ListTag>(null, tags.Cast<ListTag>().ToArray());
            case NbtTagPrefix.Integers:
                for (int i = 0; i < length; i++) tags[i] = ReadIntegers();
                return new ListTag<IntegersTag>(null, tags.Cast<IntegersTag>().ToArray());
            case NbtTagPrefix.Bytes:
                for (int i = 0; i < length; i++) tags[i] = ReadBytes();
                return new ListTag<BytesTag>(null, tags.Cast<BytesTag>().ToArray());
            case NbtTagPrefix.Longs:
                for (int i = 0; i < length; i++) tags[i] = ReadLongs();
                return new ListTag<LongsTag>(null, tags.Cast<LongsTag>().ToArray());
            case NbtTagPrefix.Compound:
                for (int i = 0; i < length; i++) tags[i] = ReadCompoundTag();
                return new ListTag<CompoundTag>(null, tags.Cast<CompoundTag>().ToArray());
        }
        
        throw new InvalidDataException($"Unknown type {type}");
    }

    public IntegersTag ReadIntegers() {
        int length = ReadInteger();
        int[] integers = new int[length];
        for (int i = 0; i < length; i++) {
            integers[i] = ReadInteger();
        }
        return new IntegersTag(null, integers);
    }
    
    public LongsTag ReadLongs() {
        int length = ReadInteger();
        long[] longs = new long[length];
        for (int i = 0; i < length; i++) {
            longs[i] = ReadLong();
        }
        return new LongsTag(null, longs);
    }
    
    public BytesTag ReadBytes() {  // signed byte array
        int length = ReadInteger();
        int[] vals = new int[length];
        for (int i = 0; i < length; i++) {
            byte b = _input.Read();
            if (b >= 128) {
                // Convert to two's complement for negative values
                vals[i] = b - 256; // 256 - 128 = 128, so -128 becomes 128
            }
            else {
                vals[i] = b & 0xFF;
            }
        }
        return new BytesTag(null, vals);
    }

    public CompoundTag ReadCompoundTag() {
        List<ITag> children = [];
        
        // each child is written, but with a name this time.
        while (true) {
            byte type = _input.Read();
            if (type == NbtTagPrefix.End) {
                return new CompoundTag(null, children.ToArray());
            }
            
            string name = ReadString();
            
            switch (type) {
                case NbtTagPrefix.String:
                    children.Add(new StringTag(name, ReadString()));
                    break;
                case NbtTagPrefix.Byte:
                    children.Add(new ByteTag(name, _input.Read()));
                    break;
                case NbtTagPrefix.Integer:
                    children.Add(new IntegerTag(name, ReadInteger()));
                    break;
                case NbtTagPrefix.Long:
                    children.Add(new LongTag(name, ReadLong()));
                    break;
                case NbtTagPrefix.Short:
                    children.Add(new ShortTag(name, ReadShort()));
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
                case NbtTagPrefix.Integers:
                    children.Add(ReadIntegers().WithName(name));
                    break;
                case NbtTagPrefix.Bytes:
                    children.Add(ReadBytes().WithName(name));
                    break;
                case NbtTagPrefix.Longs:
                    children.Add(ReadLongs().WithName(name));
                    break;
                default:
                    throw new InvalidDataException($"Unknown tag type {type}");
            }
        }
    }

    public string ReadString() {
        // read the length
        byte[] lenBytes = _input.Read(sizeof(ushort));
        ushort len = BinaryPrimitives.ReadUInt16BigEndian(lenBytes);

        byte[] textBytes = _input.Read(len);
        return Encoding.UTF8.GetString(textBytes);
    }

    public int ReadInteger() {
        return BinaryPrimitives.ReadInt32BigEndian(_input.Read(sizeof(int)));
    }
    
    public long ReadLong() {
        return BinaryPrimitives.ReadInt64BigEndian(_input.Read(sizeof(long)));
    }
    
    public short ReadShort() {
        return BinaryPrimitives.ReadInt16BigEndian(_input.Read(sizeof(short)));
    }
    
    public float ReadFloat() {
        return BinaryPrimitives.ReadSingleBigEndian(_input.Read(sizeof(float)));
    }
    
    public double ReadDouble() {
        return BinaryPrimitives.ReadDoubleBigEndian(_input.Read(sizeof(double)));
    }
}
using System.Buffers.Binary;
using System.IO.Compression;
using System.Text;
using NBT.Tags;

namespace NBT;

public class NbtReader(Stream input, NbtCompressionType compression = NbtCompressionType.None) {
    private Stream _input = input;

    public NbtReader(byte[] data, NbtCompressionType compression = NbtCompressionType.None) : this(new MemoryStream(data), compression) { }

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
    public INbtTag ToTag(bool impliedRoot = false) {
        switch (compression) {
            case NbtCompressionType.GZip:
                throw new NotImplementedException();
            
            case NbtCompressionType.ZLib:
                // decompress the input stream with CompressionHelper.DecompressZlib
                _input = DecompressZlib(_input);
                break;
            
            case NbtCompressionType.None:
                break;  // do nothing
            
            default:
                throw new ArgumentOutOfRangeException(nameof(compression), compression, null);
        }
        
        if (impliedRoot) {
            MemoryStream ms = new();
            // Write the root compound tag prefix
            ms.WriteByte(NbtTagPrefix.Compound);
            _input.CopyTo(ms);
            ms.WriteByte(NbtTagPrefix.End);
            ms.Position = 0;  // reset the position to the start
            _input = ms;

            // DataWriter w = new DataWriter()
            //     .Write(NbtTagPrefix.Compound)
            //     .Write(_input.ReadRemaining())
            //     .Write(NbtTagPrefix.End);
            // _input = new DataReader(w.ToArray());
        }
        
        // Start by reading the tag type
        byte type = Read();

        // At the root level no tag will have a name
        return type switch {
            NbtTagPrefix.String => new StringTag(null, ReadString()),
            NbtTagPrefix.Byte => new ByteTag(null, ReadByte()),
            NbtTagPrefix.Integer => new IntegerTag(null, ReadInteger()),
            NbtTagPrefix.Long => new LongTag(null, ReadLong()),
            NbtTagPrefix.Short => new ShortTag(null, ReadShort()),
            NbtTagPrefix.Float => new FloatTag(null, ReadFloat()),
            NbtTagPrefix.Double => new DoubleTag(null, ReadDouble()),
            NbtTagPrefix.Compound => ReadCompoundTag(),
            NbtTagPrefix.End => new EmptyTag(),
            NbtTagPrefix.List => ReadList(),
            NbtTagPrefix.Integers => ReadArray(ReadInteger),
            NbtTagPrefix.Bytes => ReadArray(ReadByte),
            NbtTagPrefix.Longs => ReadArray(ReadLong),
            _ => throw new InvalidDataException($"Unknown type {type}")
        };
    }
    
    public static INbtTag ReadNbt(byte[] data, bool impliedRoot = false, NbtCompressionType compression = NbtCompressionType.None) {
        return new NbtReader(data, compression).ToTag(impliedRoot);
    }
    
    public static Stream DecompressZlib(Stream input) {
        ZLibStream zlibStream = new(input, CompressionMode.Decompress);
        // MemoryStream output = new();
        // zlibStream.CopyTo(output);
        return zlibStream;
    }


    // returns it strongly typed for convenience, except when it contains nested lists
    public ListTag ReadList() {
        byte type = Read();
        int length = ReadInteger();
        INbtTag[] tags = new INbtTag[length];

        switch (type) {
            case NbtTagPrefix.End:  // an empty list
                return new ListTag(null, []);
            case NbtTagPrefix.String:
                for (int i = 0; i < length; i++) tags[i] = new StringTag(null, ReadString());
                return new ListTag<StringTag>(null, tags.Cast<StringTag>().ToArray());
            case NbtTagPrefix.Byte:
                for (int i = 0; i < length; i++) tags[i] = new ByteTag(null, ReadByte());
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
                for (int i = 0; i < length; i++) tags[i] = ReadArray(ReadInteger);
                return new ListTag<ArrayTag<int>>(null, tags.Cast<ArrayTag<int>>().ToArray());
            case NbtTagPrefix.Bytes:
                for (int i = 0; i < length; i++) tags[i] = ReadArray(ReadByte);
                return new ListTag<ArrayTag<sbyte>>(null, tags.Cast<ArrayTag<sbyte>>().ToArray());
            case NbtTagPrefix.Longs:
                for (int i = 0; i < length; i++) tags[i] = ReadArray(ReadLong);
                return new ListTag<ArrayTag<long>>(null, tags.Cast<ArrayTag<long>>().ToArray());
            case NbtTagPrefix.Compound:
                for (int i = 0; i < length; i++) tags[i] = ReadCompoundTag();
                return new ListTag<CompoundTag>(null, tags.Cast<CompoundTag>().ToArray());
        }
        
        throw new InvalidDataException($"Unknown type {type}");
    }

    public ArrayTag<T> ReadArray<T>(Func<T> readFunc) {
        int length = ReadInteger();
        T[] vals = new T[length];
        for (int i = 0; i < length; i++) {
            vals[i] = readFunc();
        }
        return new ArrayTag<T>(null, vals);
    }

    private byte Read() {
        int b = _input.ReadByte();
        if (b == -1) {
            throw new EndOfStreamException("Reached end of stream while reading NBT data.");
        }
        return (byte)b;
    }
    
    private byte[] Read(int count) {
        byte[] buffer = new byte[count];
        int bytesRead = _input.Read(buffer, 0, count);
        if (bytesRead < count) {
            throw new EndOfStreamException($"Expected to read {count} bytes, but only read {bytesRead} bytes.");
        }
        return buffer;
    }
    
    public sbyte ReadByte() {
        byte b = Read();
        if (b >= 128) {
            // Convert to two's complement for negative values
            return (sbyte)(b - 256); // 256 - 128 = 128, so -128 becomes 128
        }
        return (sbyte)(b & 0xFF);
    }

    public CompoundTag ReadCompoundTag() {
        List<INbtTag> children = [];
        
        // each child is written, but with a name this time.
        while (true) {
            byte type = Read();
            if (type == NbtTagPrefix.End) {
                return new CompoundTag(null, children.ToArray());
            }
            
            string name = ReadString();
            
            switch (type) {
                case NbtTagPrefix.String:
                    children.Add(new StringTag(name, ReadString()));
                    break;
                case NbtTagPrefix.Byte:
                    children.Add(new ByteTag(name, ReadByte()));
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
                    children.Add(ReadArray(ReadInteger).WithName(name));
                    break;
                case NbtTagPrefix.Bytes:
                    children.Add(ReadArray(ReadByte).WithName(name));
                    break;
                case NbtTagPrefix.Longs:
                    children.Add(ReadArray(ReadLong).WithName(name));
                    break;
                default:
                    throw new InvalidDataException($"Unknown tag type {type}");
            }
        }
    }

    public string ReadString() {
        // read the length
        byte[] lenBytes = Read(sizeof(ushort));
        ushort len = BinaryPrimitives.ReadUInt16BigEndian(lenBytes);

        byte[] textBytes = Read(len);
        return Encoding.UTF8.GetString(textBytes);
    }

    public int ReadInteger() {
        return BinaryPrimitives.ReadInt32BigEndian(Read(sizeof(int)));
    }
    
    public long ReadLong() {
        return BinaryPrimitives.ReadInt64BigEndian(Read(sizeof(long)));
    }
    
    public short ReadShort() {
        return BinaryPrimitives.ReadInt16BigEndian(Read(sizeof(short)));
    }
    
    public float ReadFloat() {
        return BinaryPrimitives.ReadSingleBigEndian(Read(sizeof(float)));
    }
    
    public double ReadDouble() {
        return BinaryPrimitives.ReadDoubleBigEndian(Read(sizeof(double)));
    }
}

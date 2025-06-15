using System.Buffers.Binary;
using System.Text;
using Minecraft.NBT;
using Minecraft.NBT.Text;
using Minecraft.Schemas;

namespace Minecraft;

public class DataReader(byte[] data) {
    internal int Pos;
    private byte[] _data = data;
    public bool HasRemaining => Pos < _data.Length;

    public void UpdateData(byte[] newData) {
        _data = newData;
    }

    public byte Read() {
        return Read(1)[0];
    }

    public byte[] Read(uint bytes) => Read((int)bytes);
    
    public byte[] Read(int bytes) {
        if (Pos + bytes > _data.Length) {
            throw new Exception("Reached the end of the data.");
        }

        byte[] newData = _data[Pos..(Pos + bytes)];
        Pos += bytes;
        return newData;
    }

    public T? ReadPrefixedOptional<T>(Func<DataReader, T> reader) {
        bool exists = ReadBoolean();
        return exists ? reader(this) : default;
    }

    public int ReadVarInt() {
        int value = 0;
        int position = 0;
        byte currentByte;

        while (true) {
            currentByte = Read(1)[0];
            value |= (currentByte & ProtocolConstants.SegmentBits) << position;

            if ((currentByte & ProtocolConstants.ContinueBit) == 0) break;

            position += 7;

            if (position >= 32) throw new Exception("VarInt is too big");
        }

        return value;
    }
    
    public long[] ReadPacketDataArray(int bitsPerEntry, int lengthed = -1) {
        if (bitsPerEntry is < 1 or > 64) {
            throw new ArgumentOutOfRangeException(nameof(bitsPerEntry), "Bits per entry must be between 1 and 64.");
        }

        const int bitsPerLong = 64;
        int entriesPerLong = bitsPerLong / bitsPerEntry;
        int entryCount = lengthed == -1 ? ReadVarInt() : lengthed;

        int longCount = (entryCount + entriesPerLong - 1) / entriesPerLong;
        long[] result = new long[entryCount];

        for (int i = 0; i < longCount; i++) {
            long packed = ReadLong(); // assumes ReadLong reads long in big-endian order
            // If ReadLong reads in little-endian, use: packed = IPAddress.NetworkToHostOrder(packed);
            for (int j = 0; j < entriesPerLong; j++) {
                int index = i * entriesPerLong + j;
                if (index >= entryCount) {
                    break; // finished
                }

                int shift = j * bitsPerEntry;
                long mask = (1L << bitsPerEntry) - 1;
                result[index] = (packed >> shift) & mask;
            }
        }

        return result;
    }

    public string ReadString() {
        int length = ReadVarInt();
        return Encoding.UTF8.GetString(Read(length));
    }
    
    public ushort ReadUShort() {
        byte[] bytes = Read(2);
        return (ushort)((bytes[0] << 8) | bytes[1]);
    }
    
    public long ReadLong() {
        byte[] bytes = Read(8);
        long value = 0;
        for (int i = 0; i < 8; i++) {
            value |= (long)(bytes[i] & 0xFF) << (56 - i * 8); // Big-endian
        }
        return value;
    }

    public short ReadShort() {
        byte[] bytes = Read(2);
        return BinaryPrimitives.ReadInt16BigEndian(bytes);
    }

    public int ReadInteger() {
        byte[] bytes = Read(4);
        return (bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3];
    }
    
    public Vec3 ReadVec3() {
        double x = ReadDouble();
        double y = ReadDouble();
        double z = ReadDouble();
        return new Vec3(x, y, z);
    }
    
    public SVec3 ReadSVec3() {
        short x = ReadShort();
        short y = ReadShort();
        short z = ReadShort();
        return new SVec3(x, y, z);
    }
    
    public FVec3 ReadFVec3() {
        float x = ReadFloat();
        float y = ReadFloat();
        float z = ReadFloat();
        return new FVec3(x, y, z);
    }
    
    public float ReadFloat() {
        byte[] bytes = Read(4);
        if (BitConverter.IsLittleEndian) {
            Array.Reverse(bytes);
        }
        return BitConverter.ToSingle(bytes, 0);
    }
    
    public double ReadDouble() {
        byte[] bytes = Read(8);
        if (BitConverter.IsLittleEndian) {
            Array.Reverse(bytes);
        }
        return BitConverter.ToDouble(bytes, 0);
    }

    public bool ReadBoolean() {
        byte[] bytes = Read(1);
        return bytes[0] != 0;
    }
    
    // Sign-extension helper for bits-bit two's complement
    private static int SignExtend(int value, int bits) {
        int shift = 32 - bits; 
        return (value << shift) >> shift;
    }

    // An integer/block position: x (-33554432 to 33554431), z (-33554432 to 33554431), y (-2048 to 2047)
    // x as a 26-bit integer, followed by z as a 26-bit integer, followed by y as a 12-bit integer (all signed, two's complement).
    // Should be 8 bytes in total and big-endian.
    public BlockPosition ReadPosition() {
        // Read 8 bytes
        byte[] buffer = Read(8);

        // Combine into a 64-bit big-endian value:
        long packed = 0;
        for (int i = 0; i < 8; i++) {
            packed = (packed << 8) | (buffer[i] & 0xFF);
        }

        // Extract X (26 bits), Z (26 bits), Y (12 bits)
        int x = (int)((packed >> 38) & 0x3FFFFFF);
        x = SignExtend(x, 26);

        int z = (int)((packed >> 12) & 0x3FFFFFF);
        z = SignExtend(z, 26);

        int y = (int)(packed & 0xFFF);
        y = SignExtend(y, 12);

        return new BlockPosition(x, y, z);
    }
    
    // reads a signed 8-bit integer (two's complement)
    public byte ReadByte() {
        byte b = Read(1)[0];
        if (b >= 128) {
            // Convert to two's complement for negative values
            return (byte)(b - 256); // 256 - 128 = 128, so -128 becomes 128
        }
        return (byte)(b & 0xFF);
    }

    public Guid ReadUuid() {
        return new Guid(Read(16), true);
    }

    public Angle ReadAngle() {
        return new Angle {
            Value = Read()
        };
    }

    public ITag ReadNbt() {
        return new NbtReader(this).ToTag();
    }

    public TextComponent ReadText() {
        return TextComponent.FromTag(ReadNbt());
    }
    
    public T[] ReadPrefixedArray<T>(Func<DataReader, T> readerAdapter) {
        return ReadArray(ReadVarInt(), readerAdapter);
    }

    public T[] ReadArray<T>(int length, Func<DataReader, T> readerAdapter) {
        T[] arr = new T[length];
        for (int i = 0; i < length; i++) {
            arr[i] = readerAdapter.Invoke(this);
        }
        return arr;
    }
    
    public byte[] ReadRemaining() {
        return data[Pos..];
    }
}
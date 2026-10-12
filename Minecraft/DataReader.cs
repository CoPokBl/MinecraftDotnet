using System.Buffers.Binary;
using System.Collections;
using System.Text;
using Minecraft.Data;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using NBT;

namespace Minecraft;

public class DataReader(byte[] data) : Stream {
    public override bool CanRead => true;
    public override bool CanSeek => true;
    public override bool CanWrite => false;
    public override long Length => _data.Length;

    public override long Position {
        get => Pos;
        set => Pos = (int)value;
    }
    
    internal int Pos;
    private byte[] _data = data;
    public bool HasRemaining => Pos < _data.Length;

    public void UpdateData(byte[] newData) {
        _data = newData;
    }

    public byte Read() {
        if (Pos >= _data.Length) {
            throw new EndOfStreamException("Reached the end of the data.");
        }

        return _data[Pos++];
    }

    /// <summary>
    /// The next <paramref name="bytes"/> without copying them, for the scalar reads. A packed chunk is
    /// four thousand longs, and handing each one its own array is most of what reading a chunk costs.
    /// </summary>
    /// <remarks>
    /// Only safe because nothing here holds the span past the call that made it, and
    /// <see cref="UpdateData"/> is the one thing that swaps the array underneath.
    /// </remarks>
    private ReadOnlySpan<byte> ReadSpan(int bytes) {
        if (Pos + bytes > _data.Length) {
            throw new EndOfStreamException("Reached the end of the data.");
        }

        ReadOnlySpan<byte> span = _data.AsSpan(Pos, bytes);
        Pos += bytes;
        return span;
    }

    public byte[] Read(uint bytes) => Read((int)bytes);
    
    public byte[] Read(int bytes) {
        if (Pos + bytes > _data.Length) {
            throw new EndOfStreamException("Reached the end of the data.");
        }

        byte[] newData = _data[Pos..(Pos + bytes)];
        Pos += bytes;
        return newData;
    }

    public T? ReadPrefixedOptional<T>(Func<DataReader, T> reader) where T : class {
        bool exists = ReadBoolean();
        return exists ? reader(this) : null;
    }
    
    public T? ReadPrefixedOptional<T>(MinecraftRegistry reg) where T : class, INetworkType<T> {
        return ReadPrefixedOptional(r => T.ReadData(r, reg));
    }

    /// <summary>
    /// <see cref="ReadPrefixedOptional{T}(Func{DataReader,T})"/> for a value type, which has to be a
    /// separate method: an unconstrained <c>T?</c> is plain <c>T</c> for a struct, so an absent value
    /// would come back as a present zero.
    /// </summary>
    public T? ReadPrefixedOptionalValue<T>(Func<DataReader, T> reader) where T : struct {
        bool exists = ReadBoolean();
        return exists ? reader(this) : null;
    }

    public T? ReadPrefixedOptionalValue<T>(MinecraftRegistry reg) where T : struct, INetworkType<T> {
        return ReadPrefixedOptionalValue(r => T.ReadData(r, reg));
    }

    public T Read<T>(MinecraftRegistry reg) where T : INetworkType<T> {
        return T.ReadData(this, reg);
    }

    public int ReadVarInt() {
        int value = 0;
        int position = 0;

        while (true) {
            byte currentByte = Read();
            value |= (currentByte & ProtocolConstants.SegmentBits) << position;

            if ((currentByte & ProtocolConstants.ContinueBit) == 0) break;

            position += 7;

            if (position >= 32) throw new Exception("VarInt is too big");
        }

        return value;
    }
    
    public long ReadVarLong() {
        long value = 0;
        int position = 0;

        while (true) {
            byte currentByte = Read();
            value |= (long) (currentByte & ProtocolConstants.SegmentBits) << position;

            if ((currentByte & ProtocolConstants.ContinueBit) == 0) break;

            position += 7;

            if (position >= 64) throw new Exception("VarLong is too big");
        }

        return value;
    }

    public string ReadString() {
        int length = ReadVarInt();
        return Encoding.UTF8.GetString(ReadSpan(length));
    }
    
    public ushort ReadUShort() {
        return BinaryPrimitives.ReadUInt16BigEndian(ReadSpan(2));
    }
    
    public long ReadLong() {
        return BinaryPrimitives.ReadInt64BigEndian(ReadSpan(8));
    }

    public short ReadShort() {
        return BinaryPrimitives.ReadInt16BigEndian(ReadSpan(2));
    }

    public int ReadInteger() {
        return BinaryPrimitives.ReadInt32BigEndian(ReadSpan(4));
    }

    public uint ReadUInteger() {
        return BinaryPrimitives.ReadUInt32BigEndian(ReadSpan(4));
    }
    
    public Vec3<double> ReadVec3() {
        double x = ReadDouble();
        double y = ReadDouble();
        double z = ReadDouble();
        return new Vec3<double>(x, y, z);
    }
    
    public Vec3<short> ReadSVec3() {
        short x = ReadShort();
        short y = ReadShort();
        short z = ReadShort();
        return new Vec3<short>(x, y, z);
    }
    
    public Vec3<float> ReadFVec3() {
        float x = ReadFloat();
        float y = ReadFloat();
        float z = ReadFloat();
        return new Vec3<float>(x, y, z);
    }
    
    public Vec3<double> ReadLpVec3() {
        return LpVec3.Read(this);
    }

    public float ReadFloat() {
        return BinaryPrimitives.ReadSingleBigEndian(ReadSpan(4));
    }
    
    public double ReadDouble() {
        return BinaryPrimitives.ReadDoubleBigEndian(ReadSpan(8));
    }

    public bool ReadBoolean() {
        return Read() != 0;
    }
    
    // Sign-extension helper for bits-bit two's complement
    private static int SignExtend(int value, int bits) {
        int shift = 32 - bits; 
        return (value << shift) >> shift;
    }

    // An integer/block position: x (-33554432 to 33554431), z (-33554432 to 33554431), y (-2048 to 2047)
    // x as a 26-bit integer, followed by z as a 26-bit integer, followed by y as a 12-bit integer (all signed, two's complement).
    // Should be 8 bytes in total and big-endian.
    public Vec3<int> ReadPosition() {
        // Read 8 bytes
        long packed = ReadLong();

        // Extract X (26 bits), Z (26 bits), Y (12 bits)
        int x = (int)((packed >> 38) & 0x3FFFFFF);
        x = SignExtend(x, 26);

        int z = (int)((packed >> 12) & 0x3FFFFFF);
        z = SignExtend(z, 26);

        int y = (int)(packed & 0xFFF);
        y = SignExtend(y, 12);

        return new Vec3<int>(x, y, z);
    }
    
    // From an N-bit integer represented as a BitArray in big-endian order.
    public static ushort FromNBitInteger(int bits, BitArray bitArr) {
        if (bitArr.Count != bits) {
            throw new ArgumentOutOfRangeException(nameof(bitArr), $"Data must be {nameof(bits)} long.");
        }
        
        ushort value = 0;
        for (int i = 0; i < bits; i++) {
            if (bitArr[bits - i - 1]) {
                value |= (ushort)(1 << i);
            }
        }
        
        return value;
    }
    
    /// <remarks>
    /// Shifts the entries out of each long rather than building a <see cref="BitArray"/> per long and
    /// a sliced, reversed one per entry. That is three objects an entry, twelve thousand over a
    /// section, and it is the whole cost of reading a stored or received chunk back.
    /// </remarks>
    public ushort[] ReadPacketDataArray(int bitsPerEntry, int entryCount) {
        int entriesPerLong = 64 / bitsPerEntry;  // entries never straddle a long
        int longCount = (entryCount + entriesPerLong - 1) / entriesPerLong;

        ushort[] entries = new ushort[entryCount];
        UnpackLongs(entries, longCount, bitsPerEntry, entriesPerLong);
        return entries;
    }

    /// <summary>
    /// Fills <paramref name="entries"/> from <paramref name="longCount"/> packed longs read from here,
    /// stopping when it is full so a trailing long with spare room does not run off the end.
    /// </summary>
    private void UnpackLongs(ushort[] entries, int longCount, int bitsPerEntry, int entriesPerLong) {
        long mask = (1L << bitsPerEntry) - 1L;
        int currentEntry = 0;

        for (int i = 0; i < longCount; i++) {
            long value = ReadLong();
            for (int j = 0; j < entriesPerLong && currentEntry < entries.Length; j++) {
                entries[currentEntry++] = (ushort)((value >> (j * bitsPerEntry)) & mask);
            }
        }
    }
    
    /// <summary>
    /// <see cref="ReadPacketDataArray"/> over 32 bit entries, which is what a direct palette needs:
    /// its entries are raw block state ids rather than indices into a small table.
    /// </summary>
    /// <remarks>
    /// Shifts the entries out of each long rather than going through a <see cref="BitArray"/> per long
    /// and a sliced, reversed one per entry, which costs about three objects an entry and so some
    /// twelve thousand over a direct section.
    /// </remarks>
    public uint[] ReadPacketDataArray32(int bitsPerEntry, int entryCount) {
        int entriesPerLong = 64 / bitsPerEntry;  // entries never straddle a long
        int longCount = (entryCount + entriesPerLong - 1) / entriesPerLong;

        uint[] entries = new uint[entryCount];
        long mask = bitsPerEntry == 64 ? -1L : (1L << bitsPerEntry) - 1L;
        int currentEntry = 0;

        for (int i = 0; i < longCount; i++) {
            long value = ReadLong();
            for (int j = 0; j < entriesPerLong && currentEntry < entryCount; j++) {
                entries[currentEntry++] = (uint)((value >> (j * bitsPerEntry)) & mask);
            }
        }

        return entries;
    }

    public ushort[] ReadPrefixedPacketDataArray(int bitsPerEntry) {
        int entriesPerLong = 64 / bitsPerEntry;  // entries never straddle a long
        int longCount = ReadVarInt();

        ushort[] entries = new ushort[longCount * entriesPerLong];
        UnpackLongs(entries, longCount, bitsPerEntry, entriesPerLong);
        return entries;
    }
    
    // reads a signed 8-bit integer (two's complement)
    public new sbyte ReadByte() {
        byte b = Read();
        if (b >= 128) {
            // Convert to two's complement for negative values
            return (sbyte)(b - 256); // 256 - 128 = 128, so -128 becomes 128
        }
        return (sbyte)(b & 0xFF);
    }

    public Guid ReadUuid() {
        return new Guid(Read(16), true);
    }

    public Angle ReadAngle() {
        return Angle.FromByte(Read());
    }

    public INbtTag ReadNbt() {
        return new NbtReader(this).ToTag();
    }

    public TextComponent ReadText() {
        return TextComponent.FromTag(ReadNbt());
    }
    
    public Quaternion ReadQuaternion() {
        return new Quaternion(ReadFloat(), ReadFloat(), ReadFloat(), ReadFloat());
    }
    
    // int id or T
    // If id is 0, it returns the value of T, otherwise it returns the id - 1
    public Or<int, T>ReadIdOr<T>(Func<DataReader, T> readerAdapter) {
        int id = ReadVarInt();
        return id == 0 
            ? Or<int, T>.FromValue2(readerAdapter.Invoke(this)) 
            : Or<int, T>.FromValue1(id - 1);
    }
    
    public Or<TP, T> ReadIdOr<TP, T>(Func<int, TP> readerAdapter1, Func<DataReader, T> readerAdapter2) {
        int id = ReadVarInt();
        return id == 0 
            ? Or<TP, T>.FromValue2(readerAdapter2.Invoke(this)) 
            : Or<TP, T>.FromValue1(readerAdapter1.Invoke(id - 1));
    }
    
    /// <summary>
    /// Reads a vanilla <c>Holder</c>: a zero means the value follows inline, anything else is a
    /// registry protocol id offset by one.
    /// </summary>
    public T ReadHolder<T>(Func<int, T> byId, Func<DataReader, T> inlineReader) {
        int id = ReadVarInt();
        return id == 0 ? inlineReader.Invoke(this) : byId.Invoke(id - 1);
    }

    public T[] ReadPrefixedArray<T>(Func<DataReader, T> readerAdapter) {
        return ReadArray(ReadVarInt(), readerAdapter);
    }
    
    public T[] ReadPrefixedArray<T>(MinecraftRegistry reg) where T : INetworkType<T> {
        return ReadArray(ReadVarInt(), (r, _) => T.ReadData(r, reg));
    }

    public T[] ReadArray<T>(int length, Func<DataReader, T> readerAdapter) {
        T[] arr = new T[length];
        for (int i = 0; i < length; i++) {
            arr[i] = readerAdapter.Invoke(this);
        }
        return arr;
    }
    
    public T[] ReadArray<T>(int length, Func<DataReader, int, T> readerAdapter) {
        T[] arr = new T[length];
        for (int i = 0; i < length; i++) {
            arr[i] = readerAdapter.Invoke(this, i);
        }
        return arr;
    }
    
    public byte[] ReadRemaining() {
        byte[] remaining = _data[Pos..];
        Pos = _data.Length;
        return remaining;
    }
    
    public override void Flush() {
        // No-op for DataReader, as it does not write data
    }

    public override int Read(byte[] buffer, int offset, int count) {
        if (Pos + count > _data.Length) {
            count = _data.Length - Pos;  // Adjust count to not exceed the data length
        }

        Array.Copy(_data, Pos, buffer, offset, count);
        Pos += count;
        return count;  // Return the number of bytes read
    }

    public override long Seek(long offset, SeekOrigin origin) {
        switch (origin) {
            case SeekOrigin.Begin:
                Pos = (int)offset;
                break;
            case SeekOrigin.Current:
                Pos += (int)offset;
                break;
            case SeekOrigin.End:
                Pos = _data.Length + (int)offset;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(origin), origin, null);
        }

        if (Pos < 0 || Pos > _data.Length) {
            throw new ArgumentOutOfRangeException(nameof(offset), "Seek position is out of bounds.");
        }

        return Pos;
    }

    public override void SetLength(long value) {
        if (value < 0 || value > _data.Length) {
            throw new ArgumentOutOfRangeException(nameof(value), "Length must be within the bounds of the data.");
        }
        
        // Adjust the internal data array if necessary
        if (value < _data.Length) {
            Array.Resize(ref _data, (int)value);
        } else if (value > _data.Length) {
            byte[] newData = new byte[value];
            Array.Copy(_data, newData, _data.Length);
            _data = newData;
        }
    }

    public override void Write(byte[] buffer, int offset, int count) {
        throw new NotSupportedException("DataReader does not support writing data.");
    }
}

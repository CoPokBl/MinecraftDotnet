using System.Buffers.Binary;
using System.Collections;
using System.Text;
using Minecraft.Data;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Vec;
using NBT;

namespace Minecraft;

public class DataWriter : Stream, IWritable {
    public override bool CanRead => false;
    public override bool CanSeek => false;
    public override bool CanWrite => true;
    public override long Length => _data?.Count ?? _stream!.Length;

    public override long Position {
        get => _data?.Count ?? _stream!.Position;
        set => throw new NotSupportedException();
    }

    private readonly List<byte>? _data;
    private readonly Stream? _stream;

    public byte[] ToArray() => _data?.ToArray()!;
    
    public List<byte>? GetRaw() => _data;


    public DataWriter() {
        _data = [];
    }
    
    public DataWriter(Stream stream) {
        _stream = stream;
    }
    
    public DataWriter Write(byte[] value) {
        if (_data == null) {
            _stream!.Write(value);
        }
        else {
            _data.AddRange(value);
        }
        return this;
    }
    
    public DataWriter Write(IEnumerable<byte> value) {
        if (_data == null) {
            foreach (byte b in value) {
                _stream!.WriteByte(b);
            }
        }
        else {
            _data.AddRange(value);
        }
        return this;
    }
    
    public DataWriter Write(Stream stream) {
        if (_data == null) {
            stream.CopyTo(_stream!);
        }
        else {
            byte[] buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0) {
                _data.AddRange(buffer.AsSpan(0, bytesRead).ToArray());
            }
        }
        return this;
    }

    public DataWriter Write(byte value) {
        if (_data == null) {
            _stream!.WriteByte(value);
        }
        else {
            _data.Add(value);
        }
        return this;
    }

    /// <summary>
    /// Write this DataWriter's data to the given DataWriter.
    /// </summary>
    /// <param name="w"></param>
    public void Write(DataWriter w) {
        if (_data == null) {
            w.Write(_stream!);
        }
        else {
            foreach (byte b in _data) {
                w.Write(b);
            }
        }
    }

    public DataWriter Write(IWritable writable) {
        writable.Write(this);
        return this;
    }
    
    public DataWriter Write<T>(INetworkType<T> type, MinecraftRegistry reg) where T : INetworkType<T> {
        if (type is not T) {
            throw new ArgumentException("type is not T");
        }
        return type.WriteData(this, reg);
    }

    public DataWriter Write(Func<DataWriter, DataWriter> writeAction) {
        return writeAction(this);
    }

    public DataWriter Write(Action<DataWriter> writeAction) {
        writeAction(this);
        return this;
    }
    
    public DataWriter Write<T>(T val, Action<T, DataWriter> writeAction) {
        writeAction(val, this);
        return this;
    }

    public DataWriter WriteEntityMetaParam<T>(T? val, int index, MetaFieldType type, Action<T, DataWriter> writeAction) where T : class {
        if (val == null) {
            return this;
        }

        return WriteUnsignedByte((byte)index).WriteVarInt((int)type).Write(val, writeAction);
    }
    
    public DataWriter WriteEntityMetaParam<T>(T? val, int index, MetaFieldType type, Action<T, DataWriter> writeAction) where T : struct {
        if (val == null) {
            return this;
        }

        return WriteUnsignedByte((byte)index).WriteVarInt((int)type).Write(val.Value, writeAction);
    }

    public DataWriter WriteVarInt(int value) {
        while (true) {
            if ((value & ~ProtocolConstants.SegmentBits) == 0) {
                Write((byte)value);
                return this;
            }

            Write((byte)((value & ProtocolConstants.SegmentBits) | ProtocolConstants.ContinueBit));

            // Note: >>> means that the sign bit is shifted with the rest of the number rather than being left alone
            value >>>= 7;
        }
    }
    
    public DataWriter WriteVarLong(long value) {
        while (true) {
            if ((value & ~(long) ProtocolConstants.SegmentBits) == 0) {
                Write((byte)value);
                return this;
            }

            Write((byte)((value & ProtocolConstants.SegmentBits) | ProtocolConstants.ContinueBit));

            // Note: >>> means that the sign bit is shifted with the rest of the number rather than being left alone
            value >>>= 7;
        }
    }
    
    public DataWriter WriteVec3(Vec3<double> value) {
        return WriteDouble(value.X)
            .WriteDouble(value.Y)
            .WriteDouble(value.Z);
    }
    
    public DataWriter WriteVec3(Vec3<short> value) {
        return WriteShort(value.X)
            .WriteShort(value.Y)
            .WriteShort(value.Z);
    }
    
    public DataWriter WriteVec3(Vec3<float> value) {
        return WriteFloat(value.X)
            .WriteFloat(value.Y)
            .WriteFloat(value.Z);
    }
    
    public DataWriter WriteQuaternion(Quaternion value) {
        return WriteFloat(value.X)
            .WriteFloat(value.Y)
            .WriteFloat(value.Z)
            .WriteFloat(value.W);
    }
    
    // A single-precision 32-bit IEEE 754 floating point number, big endian
    public DataWriter WriteFloat(float value) {
        byte[] buffer = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian) {
            Array.Reverse(buffer); // Convert to big-endian
        }
        return Write(buffer);
    }
    
    // Signed 32-bit integer, two's complement
    public DataWriter WriteInteger(int value) {
        byte[] buffer = new byte[4];
        buffer[0] = (byte)(value >> 24); // High byte first (big-endian)
        buffer[1] = (byte)(value >> 16);
        buffer[2] = (byte)(value >> 8);
        buffer[3] = (byte)(value & 0xFF); // Low byte last
        return Write(buffer);
    }
    
    // A double-precision 64-bit IEEE 754 floating point number, big endian
    public DataWriter WriteDouble(double value) {
        byte[] buffer = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian) {
            Array.Reverse(buffer); // Convert to big-endian
        }
        return Write(buffer);
    }

    public DataWriter WriteString(string value) {
        byte[] bs = Encoding.UTF8.GetBytes(value);
        WriteVarInt(bs.Length);
        Write(bs);
        return this;
    }

    public DataWriter WriteUShort(ushort value) {
        byte[] buffer = new byte[2];
        buffer[0] = (byte)(value >> 8);      // High byte first (big-endian)
        buffer[1] = (byte)(value & 0xFF);    // Low byte second
        return Write(buffer);
    }
    
    // Signed 16-bit integer, two's complement
    public DataWriter WriteShort(short value) {
        Span<byte> span = new(new byte[sizeof(short)]);
        BinaryPrimitives.WriteInt16BigEndian(span, value);
        return Write(span.ToArray());
    }
    
    // writes a signed 64-bit integer (two's complement)
    public DataWriter WriteLong(long value) {
        byte[] buffer = new byte[8];
        for (int i = 0; i < 8; i++) {
            buffer[i] = (byte)((value >> (56 - i * 8)) & 0xFF); // Big-endian
        }
        return Write(buffer);
    }
    
    // To an N-bit integer represented as a BitArray in big-endian order.
    public static BitArray ToNBitInteger(int bits, ushort value) {
        if (bits is < 1 or > 64) {
            throw new ArgumentOutOfRangeException(nameof(bits), "Bits must be between 1 and 64.");
        }
        
        BitArray bitArray = new(bits);
        for (int i = 0; i < bits; i++) {
            // Set the bit at position i to the corresponding bit in value
            // The least significant bit is at index 0, so we use (bits - 1 - i) to reverse the order
            bitArray[bits - 1 - i] = (value & (1L << i)) != 0;
            // bitArray[i] = (value & (1L << i)) != 0;
        }

        return bitArray;
    }

    /// <summary>
    /// Writes a non length prefixed long array as defined by:
    /// https://minecraft.wiki/w/Java_Edition_protocol/Chunk_format#Data_Array_format
    /// </summary>
    /// <param name="bitsPerEntry">Amount of bits to use per entry</param>
    /// <param name="entries">The list of entries to write</param>
    /// <returns>The data writer object</returns>
    /*
       A single long of the array holds several entries. The entries are tightly packed within the long, with the first
       entry on the least significant bits. An entry cannot span across multiple longs; instead, padding is inserted as required,
       starting from the most significant bits.

       For example, assuming a bits per block value of 15, and that bit 0 is the least significant bit,
       the data is stored such that bits 0 through 14 are the first entry, 15 through 29 are the second, and so on.
       The fourth entry ends on bit 59, and since only 4 bits are left, they become padding, and the fifth entry starts on the next long.

       Note that since longs are sent in big endian order, the least significant bit of the first entry in a long
       will be on the last byte of the long on the wire.
     */
    public DataWriter WritePacketDataArray(int bitsPerEntry, ushort[] entries) {
        long[] packed = PackToLongArray(bitsPerEntry, entries);
        WriteArray(packed, (l, w) => w.WriteLong(l));
        return this;
    }
    
    public DataWriter WritePrefixedPacketDataArray(int bitsPerEntry, ushort[] entries) {
        long[] packed = PackToLongArray(bitsPerEntry, entries);
        WritePrefixedArray(packed, (l, w) => w.WriteLong(l));
        return this;
    }
    
    public static long[] PackToLongArray(int bitsPerEntry, ushort[] data) {
        double intsPerLong = Math.Floor(64d / bitsPerEntry);
        int intsPerLongCeil = (int)Math.Ceiling(intsPerLong);
        
        int longCount = (int)Math.Ceiling((double)data.Length / intsPerLongCeil);
        long[] outp = new long[longCount];

        long mask = (1L << bitsPerEntry) - 1L;
        for (int i = 0; i < data.Length; i++) {
            int longIndex = i / intsPerLongCeil;
            int subIndex = i % intsPerLongCeil;

            outp[longIndex] |= (data[i] & mask) << (bitsPerEntry * subIndex);
        }

        return outp;
    }
    
    /// <summary>
    /// Deprecated data array writer method that packs data into longs.
    /// Use significantly faster <see cref="WritePacketDataArray"/> instead.
    /// </summary>
    /// <param name="bitsPerEntry"></param>
    /// <param name="entries"></param>
    /// <returns></returns>
    [Obsolete("Use WritePacketDataArray instead.")]
    public DataWriter WritePacketDataArraySlow(int bitsPerEntry, ushort[] entries) {
        Queue<BitArray> packedBits = new(entries.Length);
        foreach (ushort t in entries) {
            packedBits.Enqueue(ToNBitInteger(bitsPerEntry, t));
        }
        
        // Pack into longs
        int entriesPerLong = 64 / bitsPerEntry;  // How many entries fit into one long
        int longCount = (int)Math.Ceiling((double)entries.Length / entriesPerLong);
        int paddingPerLong = 64 % bitsPerEntry;  // How many bits are left unused in each long
        
        // Manually pack the bits into big endian longs (8 bytes each).
        byte[] packedBytes = new byte[longCount * 8]; // 8 bytes per long
        for (int i = 0; i < longCount; i++) {
            BitArray packedBitsInLong = new(64);

            BitArray[] valsInLong = new BitArray[entriesPerLong];
            for (int j = 0; j < entriesPerLong; j++) {
                if (packedBits.Count == 0) {
                    valsInLong[j] = new BitArray(bitsPerEntry); // Empty entry if no more bits are available
                    continue;
                }
                valsInLong[j] = packedBits.Dequeue();
            }
            
            // Add the padding
            for (int j = 0; j < paddingPerLong; j++) {
                packedBitsInLong[j] = false; // Set padding bits to false
            }

            int index = paddingPerLong;
            for (int j = 0; j < entriesPerLong; j++) {  // for every entry
                for (int k = 0; k < bitsPerEntry; k++) {  // and every bit in every entry
                    packedBitsInLong[index++] = valsInLong[entriesPerLong - 1 - j][k];
                }
            }
            
            // Write the packedBitsInLong to the packedBytes array. Write them sequentially as they appear.
            // 010000000 should literally be written as that as a byte. The amount of bits in packedBitsInLong is always 64.
            for (int j = 0; j < 8; j++) {
                // Get the next 8 bits from packedBitsInLong
                byte b = 0;
                for (int k = 0; k < 8; k++) {
                    if (packedBitsInLong[j * 8 + k]) {
                        b |= (byte)(1 << (7 - k)); // Set the bit in the correct position
                    }
                }
                packedBytes[i * 8 + j] = b; // Write to the packedBytes array
            }
        }
        
        // Write out each packed long.
        Write(packedBytes);
        return this;
    }
    
    // writes a signed 8-bit integer (two's complement)
    public DataWriter WriteByte(int value) {
        if (value is < -128 or > 127) {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be between -128 and 127.");
        }

        if (value >= 0) {
            return Write((byte)value);
        }
        
        // Convert to two's complement for negative values
        return Write((byte)(256 + value)); // 256 - 128 = 128, so -128 becomes 128
    }
    
    // unsigned 8-bit integer
    public DataWriter WriteUnsignedByte(byte value) {
        return Write(value);
    }

    public DataWriter WriteBoolean(bool value) {
        return Write((byte)(value ? 0x01 : 0x00));
    }

    // An integer/block position: x (-33554432 to 33554431), z (-33554432 to 33554431), y (-2048 to 2047)
    // x as a 26-bit integer, followed by z as a 26-bit integer, followed by y as a 12-bit integer (all signed, two's complement).
    // Should be 8 bytes in total and big-endian.
    public DataWriter WritePosition(Vec3<int> value) {
        //  X: 26 bits, Z: 26 bits, Y: 12 bits (all two's complement)
        //  bits 63..38 => X
        //  bits 37..12 => Z
        //  bits 11..0  => Y

        long x = value.X & 0x3FFFFFF; // mask to 26 bits
        long z = value.Z & 0x3FFFFFF; // mask to 26 bits
        long y = value.Y & 0xFFF;     // mask to 12 bits

        long packed = (x << 38) | (z << 12) | y;

        // Write 8 bytes, big-endian:
        for (int shift = 56; shift >= 0; shift -= 8) {
            Write((byte)((packed >> shift) & 0xFF));
        }
        return this;
    }

    public DataWriter WritePrefixedOptional<T>(T? value, Action<T, DataWriter> writer) where T : class {
        if (value == null) {
            return WriteBoolean(false);
        }

        WriteBoolean(true);
        writer.Invoke(value, this);
        return this;
    }
    
    public DataWriter WritePrefixedOptional<T>(T? value, MinecraftRegistry reg) where T : class, INetworkType<T> {
        return WritePrefixedOptional(value, (v, w) => v.WriteData(w, reg));
    }
    
    public DataWriter WritePrefixedOptional<T>(Optional<T> value, Action<T, DataWriter> writer) {
        if (!value.Present) {
            return WriteBoolean(false);
        }

        WriteBoolean(true);
        writer.Invoke(value.Value, this);
        return this;
    }
    
    public DataWriter WritePrefixedOptional<T>(T? value, Action<T, DataWriter> writer) where T : struct {
        if (!value.HasValue) {
            return WriteBoolean(false);
        }

        WriteBoolean(true);
        writer.Invoke(value.Value, this);
        return this;
    }
    
    public DataWriter WriteIfPresent<T>(Optional<T> value, Action<T, DataWriter> writer) {
        if (!value.Present) {
            return this; // Do nothing if not present
        }

        writer.Invoke(value.Value, this);
        return this;
    }

    public DataWriter WriteIfPresent<T>(T? value, Action<T, DataWriter> writer) where T : class {
        if (value == null) {
            return this; // Do nothing if not present
        }

        writer.Invoke(value, this);
        return this;
    }
    
    public DataWriter WriteIfPresent<T>(T? value, Action<T, DataWriter> writer) where T : struct {
        if (!value.HasValue) {
            return this; // Do nothing if not present
        }

        writer.Invoke(value.Value, this);
        return this;
    }

    public DataWriter WriteNbt(INbtTag nbt) {
        byte[] dat = nbt.Serialise();
        return Write(dat);
    }

    public DataWriter WriteUuid(Guid value) {
        return Write(value.ToByteArray(true));
    }

    public DataWriter WriteAngle(Angle angle) {
        return Write(angle.ByteValue);
    }
    
    public DataWriter WriteIdOr<T>(Or<int, T> idOr, Action<T, DataWriter> writerAction) {
        if (idOr.IsValue1) {
            return WriteVarInt(idOr.Value1 + 1);  // +1 because 0 is reserved for no value
        }
        
        // If it's a right value, write the value using the provided action
        WriteVarInt(0); // 0 indicates a right value
        writerAction.Invoke(idOr.Value2!, this);
        return this;
    }

    public DataWriter WriteIdOr<TP, T>(Or<TP, T> idOr, Action<T, DataWriter> writerAction) where TP : IProtocolType {
        Or<int, T> newOr = idOr.IsValue1 ? Or<int, T>.FromValue1(idOr.Value1!.ProtocolId) : Or<int, T>.FromValue2(idOr.Value2!);
        return WriteIdOr(newOr, writerAction);
    }
    
    public DataWriter WriteIdOr<TP, T>(Or<TP, T> idOr, MinecraftRegistry reg) where TP : IProtocolType where T : INetworkType<T> {
        return WriteIdOr(idOr, (type, writer) => type.WriteData(writer, reg));
    }

    public DataWriter WritePrefixedArray<T>(T[] values, Action<T, DataWriter> writerAction) {
        return WriteVarInt(values.Length).WriteArray(values, writerAction);
    }
    
    public DataWriter WritePrefixedArray<T>(T[] values, MinecraftRegistry reg) where T : INetworkType<T> {
        return WritePrefixedArray(values, (type, writer) => type.WriteData(writer, reg));
    }

    public DataWriter WriteArray<T>(IEnumerable<T> values, Action<T, DataWriter> writerAction) {
        foreach (T value in values) {
            writerAction.Invoke(value, this);
        }
        return this;
    }
    
    public override void Flush() {
        // No-op for DataReader, as it does not write data
    }

    public override int Read(byte[] buffer, int offset, int count) {
        throw new NotSupportedException("DataWriter does not support reading data.");
    }

    public override long Seek(long offset, SeekOrigin origin) {
        throw new NotSupportedException("DataWriter does not support seeking.");
    }

    public override void SetLength(long value) {
        throw new NotSupportedException("DataWriter does not support setting length.");
    }

    public override void Write(byte[] buffer, int offset, int count) {
        if (buffer == null) {
            throw new ArgumentNullException(nameof(buffer), "Buffer cannot be null.");
        }
        
        if (offset < 0 || count < 0 || offset + count > buffer.Length) {
            throw new ArgumentOutOfRangeException(nameof(count), "Offset and count must be within the bounds of the buffer.");
        }

        for (int i = offset; i < offset + count; i++) {
            Write(buffer[i]);
        }
    }
}

using System.Buffers.Binary;
using System.Collections;
using System.Text;
using Minecraft.NBT;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Vec;

namespace Minecraft;

public class DataWriter : IWritable {
    private readonly List<byte> _data = [];

    public byte[] ToArray() => _data.ToArray();
    
    public DataWriter Write(byte[] value) {
        _data.AddRange(value);
        return this;
    }

    public DataWriter Write(byte value) {
        _data.Add(value);
        return this;
    }

    public void Write(DataWriter w) {
        foreach (byte b in _data) {
            w.Write(b);
        }
    }

    public DataWriter Write(IWritable writable) {
        writable.Write(this);
        return this;
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

    public DataWriter WriteMetaParam<T>(T? val, int index, MetaFieldType type, Action<T, DataWriter> writeAction) where T : class {
        if (val == null) {
            return this;
        }

        return WriteUnsignedByte((byte)index).WriteVarInt((int)type).Write(val, writeAction);
    }
    
    public DataWriter WriteMetaParam<T>(T? val, int index, MetaFieldType type, Action<T, DataWriter> writeAction) where T : struct {
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
    
    public DataWriter WriteVec3(Vec3 value) {
        return WriteDouble(value.X)
            .WriteDouble(value.Y)
            .WriteDouble(value.Z);
    }
    
    public DataWriter WriteVec3(SVec3 value) {
        return WriteShort(value.X)
            .WriteShort(value.Y)
            .WriteShort(value.Z);
    }
    
    public DataWriter WriteVec3(FVec3 value) {
        return WriteFloat(value.X)
            .WriteFloat(value.Y)
            .WriteFloat(value.Z);
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
    public static BitArray ToNBitInteger(int bits, long value) {
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
    public DataWriter WritePacketDataArray(int bitsPerEntry, long[] entries) {
        Queue<BitArray> packedBits = new(entries.Length);
        foreach (long t in entries) {
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
    public DataWriter WritePosition(BlockPosition value) {
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

    public DataWriter WriteNbt(ITag nbt) {
        byte[] dat = nbt.Serialise();
        return Write(dat);
    }

    public DataWriter WriteUuid(Guid value) {
        return Write(value.ToByteArray(true));
    }

    public DataWriter WriteAngle(Angle angle) {
        return Write(angle.Value);
    }

    public DataWriter WritePrefixedArray<T>(T[] values, Action<T, DataWriter> writerAction) {
        return WriteVarInt(values.Length).WriteArray(values, writerAction);
    }

    public DataWriter WriteArray<T>(IEnumerable<T> values, Action<T, DataWriter> writerAction) {
        foreach (T value in values) {
            writerAction.Invoke(value, this);
        }
        return this;
    }
}
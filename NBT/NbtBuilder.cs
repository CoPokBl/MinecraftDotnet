using System.Buffers.Binary;
using System.Text;

namespace NBT;

public class NbtBuilder {
    private readonly List<byte> _data = [];
    
    public byte[] ToArray() {
        return _data.ToArray();
    }

    public NbtBuilder WriteDouble(double value) {
        Span<byte> span = new(new byte[sizeof(double)]);
        BinaryPrimitives.WriteDoubleBigEndian(span, value);
        return Write(span);
    }

    public NbtBuilder WriteFloat(float value) {
        Span<byte> span = new(new byte[sizeof(float)]);
        BinaryPrimitives.WriteSingleBigEndian(span, value);
        return Write(span);
    }

    public NbtBuilder Write(byte[] value) {
        return Write((IEnumerable<byte>)value);
    }

    public NbtBuilder Write(IEnumerable<byte> value) {
        _data.AddRange(value);
        return this;
    }

    public NbtBuilder Write(Span<byte> value) {
        _data.AddRange(value);
        return this;
    }
    
    public NbtBuilder Write(byte value) {
        _data.Add(value);
        return this;
    }

    public NbtBuilder WriteType(byte value, bool noType) {
        if (!noType) Write(value);
        return this;
    }

    public NbtBuilder WriteName(string? name) {
        if (name != null) WriteString(name);
        return this;
    }

    public NbtBuilder Write(INbtTag tag) {
        return Write(tag.Serialise());
    }

    public NbtBuilder WriteString(string value) {
        const int shortSize = 2;
        
        int length = Encoding.UTF8.GetByteCount(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(length, ushort.MaxValue);

        Span<byte> span = new(new byte[shortSize]);
        BinaryPrimitives.WriteUInt16BigEndian(span, (ushort)length);
        byte[] textBytes = Encoding.UTF8.GetBytes(value);
        
        Write(span);
        Write(textBytes);
        return this;
    }

    public NbtBuilder WriteInteger(int value) {
        Span<byte> span = new(new byte[sizeof(int)]);
        BinaryPrimitives.WriteInt32BigEndian(span, value);
        return Write(span);
    }
    
    public NbtBuilder WriteLong(long value) {
        Span<byte> span = new(new byte[sizeof(long)]);
        BinaryPrimitives.WriteInt64BigEndian(span, value);
        return Write(span);
    }
    
    public NbtBuilder WriteShort(short value) {
        Span<byte> span = new(new byte[sizeof(short)]);
        BinaryPrimitives.WriteInt16BigEndian(span, value);
        return Write(span);
    }
    
    public NbtBuilder WriteByte(sbyte value) {
        _data.Add((byte)(value < 0 ? 256 + value : value));
        return this;
    }
}

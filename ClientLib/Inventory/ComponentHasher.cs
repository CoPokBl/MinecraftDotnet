using System.Buffers.Binary;
using Minecraft.Data.Components;
using Minecraft.Registry;
using NBT;
using NBT.Tags;

namespace ClientLib.Inventory;

/// <summary>
/// The hash a container click carries for each component a stack patches: vanilla's <c>HashOps</c>
/// with CRC32C, run over the component's persistent form. That form is taken from the component's
/// NBT codec, so the tag tree stands in for what the codec would hand <c>HashOps</c> directly; the two
/// agree because the codecs write booleans as <see cref="BooleanTag"/> and numbers at their own width.
/// <p/>
/// A wrong hash is not fatal: the server takes it as the client being out of date and sends the slot
/// again. That makes a mistake here silent, which is why <c>ComponentHasherTest</c> pins it against
/// numbers from the jar.
/// </summary>
public static class ComponentHasher {
    private const byte TagMapStart = 2, TagMapEnd = 3, TagListStart = 4, TagListEnd = 5;
    private const byte TagByte = 6, TagShort = 7, TagInt = 8, TagLong = 9, TagFloat = 10, TagDouble = 11;
    private const byte TagString = 12, TagBoolean = 13;
    private const byte TagByteArrayStart = 14, TagByteArrayEnd = 15, TagIntArrayStart = 16, TagIntArrayEnd = 17;
    private const byte TagLongArrayStart = 18, TagLongArrayEnd = 19;

    /// <returns>Null when the component has no persistent form to hash, which the transient ones do not.</returns>
    public static int? Hash(IDataComponent component, object value, MinecraftRegistry registry) {
        if (!component.HasNbtForm) {
            return null;
        }
        return (int)Hash(component.ToNbt(value, registry));
    }

    public static uint Hash(INbtTag tag) {
        Crc32C crc = new();
        switch (tag) {
            case BooleanTag b:
                crc.Byte(TagBoolean).Byte((byte)(b.Value ? 1 : 0));
                break;
            case ByteTag b:
                crc.Byte(TagByte).Byte((byte)b.Value);
                break;
            case ShortTag s:
                crc.Byte(TagShort).Short(s.Value);
                break;
            case IntegerTag i:
                crc.Byte(TagInt).Int(i.Value);
                break;
            case LongTag l:
                crc.Byte(TagLong).Long(l.Value);
                break;
            case FloatTag f:
                crc.Byte(TagFloat).Int(BitConverter.SingleToInt32Bits(f.Value));
                break;
            case DoubleTag d:
                crc.Byte(TagDouble).Long(BitConverter.DoubleToInt64Bits(d.Value));
                break;
            case StringTag s:
                return HashString(s.Value);
            case CompoundTag compound: {
                List<(uint Key, uint Value)> entries = [];
                foreach ((string key, INbtTag child) in compound.Children) {
                    entries.Add((HashString(key), Hash(child)));
                }
                // HashOps.MAP_ENTRY_ORDER: by key hash, then value hash, both as unsigned.
                entries.Sort((a, b) => a.Key != b.Key ? a.Key.CompareTo(b.Key) : a.Value.CompareTo(b.Value));
                crc.Byte(TagMapStart);
                foreach ((uint key, uint value) in entries) {
                    crc.Int((int)key).Int((int)value);
                }
                crc.Byte(TagMapEnd);
                break;
            }
            case ListTag list:
                crc.Byte(TagListStart);
                foreach (INbtTag child in list.Tags) {
                    crc.Int((int)Hash(child));
                }
                crc.Byte(TagListEnd);
                break;
            case ArrayTag<sbyte> bytes:
                crc.Byte(TagByteArrayStart);
                foreach (sbyte b in bytes.Values) {
                    crc.Byte((byte)b);
                }
                crc.Byte(TagByteArrayEnd);
                break;
            case ArrayTag<int> ints:
                crc.Byte(TagIntArrayStart);
                foreach (int i in ints.Values) {
                    crc.Int(i);
                }
                crc.Byte(TagIntArrayEnd);
                break;
            case ArrayTag<long> longs:
                crc.Byte(TagLongArrayStart);
                foreach (long l in longs.Values) {
                    crc.Long(l);
                }
                crc.Byte(TagLongArrayEnd);
                break;
            default:
                throw new ArgumentException($"Cannot hash a {tag.GetType().Name}");
        }
        return crc.Value;
    }

    /// <summary><c>createString</c>: the length, then each UTF-16 unit, Guava's <c>putUnencodedChars</c>.</summary>
    private static uint HashString(string value) {
        Crc32C crc = new();
        crc.Byte(TagString).Int(value.Length);
        foreach (char c in value) {
            crc.Short((short)c);
        }
        return crc.Value;
    }

    /// <summary>Guava's CRC32C hasher. Its multi byte puts are little endian.</summary>
    private sealed class Crc32C {
        private static readonly uint[] Table = BuildTable();
        private uint _crc = 0xFFFFFFFF;

        private static uint[] BuildTable() {
            uint[] table = new uint[256];
            for (uint i = 0; i < 256; i++) {
                uint c = i;
                for (int k = 0; k < 8; k++) {
                    c = (c & 1) != 0 ? 0x82F63B78 ^ (c >> 1) : c >> 1;
                }
                table[i] = c;
            }
            return table;
        }

        public Crc32C Byte(byte b) {
            _crc = Table[(_crc ^ b) & 0xFF] ^ (_crc >> 8);
            return this;
        }

        public Crc32C Short(short value) {
            Span<byte> bytes = stackalloc byte[2];
            BinaryPrimitives.WriteInt16LittleEndian(bytes, value);
            return Bytes(bytes);
        }

        public Crc32C Int(int value) {
            Span<byte> bytes = stackalloc byte[4];
            BinaryPrimitives.WriteInt32LittleEndian(bytes, value);
            return Bytes(bytes);
        }

        public Crc32C Long(long value) {
            Span<byte> bytes = stackalloc byte[8];
            BinaryPrimitives.WriteInt64LittleEndian(bytes, value);
            return Bytes(bytes);
        }

        private Crc32C Bytes(ReadOnlySpan<byte> bytes) {
            foreach (byte b in bytes) {
                Byte(b);
            }
            return this;
        }

        public uint Value => _crc ^ 0xFFFFFFFF;
    }
}

using System.Buffers.Binary;
using System.IO.Compression;
using System.Text;

namespace CodeGen;

/// <summary>
/// Reads constant returning methods straight out of the class files in the server jar.
/// <p/>
/// A handful of values the generator needs are neither in a report nor reachable from a registry:
/// an entity's gravity and air drag are <c>getDefaultGravity()</c> and <c>getAirDrag()</c>
/// overrides on the entity class, so getting at them means either constructing an entity or
/// reading the method body. The bodies are single constants, so reading them is the cheap and
/// safe option, and anything more complicated than a constant throws rather than guessing.
/// </summary>
public sealed class JavaClassConstants(string jarPath) : IDisposable {
    private readonly ZipArchive _jar = ZipFile.OpenRead(jarPath);
    private readonly Dictionary<string, ClassFile?> _classes = [];

    public enum Lookup {
        /// <summary>Found, and its body is a constant that <see cref="Result.Value"/> carries.</summary>
        Constant,

        /// <summary>Found, but it does something else, so the caller has to decide what to do.</summary>
        NotConstant,

        /// <summary>Nothing in the class chain declares it, which usually means it was renamed.</summary>
        NotDeclared
    }

    /// <param name="DeclaringClass">
    /// The class the method was found on, which is somewhere at or above the one asked about. Null
    /// when it was not found at all.
    /// </param>
    public readonly record struct Result(Lookup Kind, double Value, string? DeclaringClass);

    /// <summary>
    /// Looks for <paramref name="methodName"/> on the nearest class at or above
    /// <paramref name="className"/> that declares it, and reads the constant it returns.
    /// </summary>
    /// <param name="className">Binary name, eg. <c>net.minecraft.world.entity.item.ItemEntity</c>.</param>
    /// <param name="descriptor">Eg. <c>()D</c>. Matched so an overload cannot be picked by mistake.</param>
    public Result FindConstant(string className, string methodName, string descriptor) {
        string? internalName = className.Replace('.', '/');
        while (internalName != null) {
            ClassFile file = Load(internalName)
                ?? throw new FileNotFoundException($"{internalName}.class is not in the server jar");

            Lookup kind = file.ConstantReturnedBy(methodName, descriptor, out double value);
            if (kind != Lookup.NotDeclared) {
                return new Result(kind, value, internalName.Replace('/', '.'));
            }

            internalName = file.SuperName;
        }

        return new Result(Lookup.NotDeclared, 0, null);
    }

    private ClassFile? Load(string internalName) {
        if (_classes.TryGetValue(internalName, out ClassFile? cached)) {
            return cached;
        }

        ZipArchiveEntry? entry = _jar.GetEntry(internalName + ".class");
        ClassFile? file = null;
        if (entry != null) {
            using Stream stream = entry.Open();
            using MemoryStream buffer = new();
            stream.CopyTo(buffer);
            file = new ClassFile(buffer.ToArray());
        }

        _classes[internalName] = file;
        return file;
    }

    public void Dispose() {
        _jar.Dispose();
    }

    /// <summary>
    /// Only the parts of the class file format needed to walk to a method body: the constant pool,
    /// the super class, and each method's Code attribute.
    /// </summary>
    private sealed class ClassFile {
        public string? SuperName { get; }

        private readonly byte[] _data;
        private readonly int[] _poolOffsets;
        private readonly byte[] _poolTags;
        private readonly List<(string Name, string Descriptor, int CodeOffset, int CodeLength)> _methods = [];

        public ClassFile(byte[] data) {
            _data = data;
            int at = 8;  // magic, minor and major version

            int poolCount = ReadU2(ref at);
            _poolOffsets = new int[poolCount];
            _poolTags = new byte[poolCount];
            for (int i = 1; i < poolCount; i++) {
                byte tag = _data[at++];
                _poolTags[i] = tag;
                _poolOffsets[i] = at;
                at += tag switch {
                    1 => 2 + ReadU2At(at),           // Utf8
                    3 or 4 or 9 or 10 or 11 or 12 or 17 or 18 => 4,
                    5 or 6 => 8,                     // Long, Double
                    7 or 8 or 16 or 19 or 20 => 2,
                    15 => 3,                         // MethodHandle
                    _ => throw new InvalidDataException($"Unknown constant pool tag {tag}")
                };

                if (tag is 5 or 6) {
                    i++;  // takes two slots, and the second one is unusable
                }
            }

            at += 2;  // access flags
            at += 2;  // this class
            int superIndex = ReadU2(ref at);
            SuperName = superIndex == 0 ? null : Utf8(ReadU2At(_poolOffsets[superIndex]));

            at += 2 + ReadU2At(at) * 2;  // interfaces

            SkipMembers(ref at);  // fields
            ReadMethods(ref at);
        }

        public Lookup ConstantReturnedBy(string name, string descriptor, out double value) {
            value = 0;
            foreach ((string methodName, string methodDescriptor, int offset, int length) in _methods) {
                if (methodName == name && methodDescriptor == descriptor) {
                    return ReadConstantBody(offset, length, out value);
                }
            }

            return Lookup.NotDeclared;
        }

        /// <summary>
        /// Matches a body that is exactly "push a constant, return it". Anything else reports
        /// <see cref="Lookup.NotConstant"/> rather than making something up from a partial read.
        /// </summary>
        private Lookup ReadConstantBody(int offset, int length, out double value) {
            int at = offset;
            switch (_data[at++]) {
                case 0x0e: value = 0; break;                           // dconst_0
                case 0x0f: value = 1; break;                           // dconst_1
                case 0x0b: value = 0; break;                           // fconst_0
                case 0x0c: value = 1; break;                           // fconst_1
                case 0x0d: value = 2; break;                           // fconst_2
                case 0x12: value = PoolNumber(_data[at++]); break;     // ldc
                case 0x13: value = PoolNumber(ReadU2(ref at)); break;  // ldc_w
                case 0x14: value = PoolNumber(ReadU2(ref at)); break;  // ldc2_w
                default:
                    value = 0;
                    return Lookup.NotConstant;
            }

            if (_data[at++] is not (0xae or 0xaf) || at - offset != length) {  // freturn, dreturn
                value = 0;
                return Lookup.NotConstant;
            }

            return Lookup.Constant;
        }

        private double PoolNumber(int index) {
            int offset = _poolOffsets[index];
            return _poolTags[index] switch {
                3 => BinaryPrimitives.ReadInt32BigEndian(_data.AsSpan(offset)),
                4 => BitConverter.Int32BitsToSingle(BinaryPrimitives.ReadInt32BigEndian(_data.AsSpan(offset))),
                5 => BinaryPrimitives.ReadInt64BigEndian(_data.AsSpan(offset)),
                6 => BitConverter.Int64BitsToDouble(BinaryPrimitives.ReadInt64BigEndian(_data.AsSpan(offset))),
                var tag => throw new InvalidDataException($"Constant pool entry {index} is a {tag}, not a number")
            };
        }

        private void ReadMethods(ref int at) {
            int count = ReadU2(ref at);
            for (int i = 0; i < count; i++) {
                at += 2;  // access flags
                string name = Utf8(ReadU2(ref at));
                string descriptor = Utf8(ReadU2(ref at));

                int attributeCount = ReadU2(ref at);
                for (int j = 0; j < attributeCount; j++) {
                    string attributeName = Utf8(ReadU2(ref at));
                    int attributeLength = ReadU4(ref at);
                    int end = at + attributeLength;

                    if (attributeName == "Code") {
                        at += 4;  // max stack, max locals
                        int codeLength = ReadU4(ref at);
                        _methods.Add((name, descriptor, at, codeLength));
                    }

                    at = end;
                }
            }
        }

        private void SkipMembers(ref int at) {
            int count = ReadU2(ref at);
            for (int i = 0; i < count; i++) {
                at += 6;  // access flags, name, descriptor
                int attributeCount = ReadU2(ref at);
                for (int j = 0; j < attributeCount; j++) {
                    at += 2;  // name
                    at += 4 + ReadU4At(at);
                }
            }
        }

        private string Utf8(int index) {
            int offset = _poolOffsets[index];
            return Encoding.UTF8.GetString(_data, offset + 2, ReadU2At(offset));
        }

        private int ReadU2(ref int at) {
            int value = ReadU2At(at);
            at += 2;
            return value;
        }

        private int ReadU4(ref int at) {
            int value = ReadU4At(at);
            at += 4;
            return value;
        }

        private int ReadU2At(int at) => BinaryPrimitives.ReadUInt16BigEndian(_data.AsSpan(at));

        private int ReadU4At(int at) => BinaryPrimitives.ReadInt32BigEndian(_data.AsSpan(at));
    }
}

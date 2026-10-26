using System.Reflection;
using System.Runtime.CompilerServices;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;

namespace Conformance;

/// <summary>
/// Fabricates a packet instance with a value in every field, so it can be serialised and
/// handed to the vanilla decoder. The values are meaningless, only their wire shape matters.
/// </summary>
/// <remarks>
/// Reflection rather than hand written samples, so a packet added later is covered without
/// anyone remembering to add it here. Types we can't fabricate throw, and the caller reports
/// the packet as skipped rather than failing the run.
/// </remarks>
public static class SampleBuilder {
    private const int MaxDepth = 6;

    public static MinecraftPacket Build(Type packetType) {
        return (MinecraftPacket)Fill(RuntimeHelpers.GetUninitializedObject(packetType), 0);
    }

    private static object Fill(object instance, int depth) {
        Type type = instance.GetType();

        foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
            if (!property.CanWrite || property.GetIndexParameters().Length > 0) {
                continue;
            }

            property.SetValue(instance, ValueFor(property.PropertyType, depth + 1));
        }

        foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.Instance)) {
            if (field.IsInitOnly) {
                continue;
            }

            field.SetValue(instance, ValueFor(field.FieldType, depth + 1));
        }

        return instance;
    }

    private static object? ValueFor(Type type, int depth) {
        if (depth > MaxDepth) {
            throw new InvalidOperationException($"nested too deep at {type.Name}");
        }

        // Optionals go empty: it keeps the sample small and still exercises the prefix byte
        if (Nullable.GetUnderlyingType(type) != null) {
            return null;
        }

        if (type.IsEnum) {
            Array values = Enum.GetValues(type);
            if (values.Length == 0) {
                throw new InvalidOperationException($"empty enum {type.Name}");
            }

            return values.GetValue(0);
        }

        if (type == typeof(string)) return "minecraft:test";
        if (type == typeof(bool)) return false;
        if (type == typeof(byte)) return (byte)0;
        if (type == typeof(sbyte)) return (sbyte)0;
        if (type == typeof(short)) return (short)0;
        if (type == typeof(ushort)) return (ushort)0;
        if (type == typeof(int)) return 0;
        if (type == typeof(uint)) return 0u;
        if (type == typeof(long)) return 0L;
        if (type == typeof(ulong)) return 0ul;
        if (type == typeof(float)) return 0f;
        if (type == typeof(double)) return 0d;
        if (type == typeof(Guid)) return Guid.Empty;
        if (type == typeof(Identifier)) return (Identifier)"minecraft:test";
        if (type == typeof(TextComponent)) return TextComponent.Empty();
        if (type == typeof(byte[])) return Array.Empty<byte>();

        // Empty collections: element shape is the packet author's business, and an empty one
        // still proves the length prefix is written the way vanilla reads it
        if (type.IsArray) {
            return Array.CreateInstance(type.GetElementType()!, 0);
        }

        if (type.IsGenericType) {
            Type definition = type.GetGenericTypeDefinition();
            if (definition == typeof(List<>) || definition == typeof(Dictionary<,>)) {
                return Activator.CreateInstance(type);
            }

            if (definition == typeof(IReadOnlyList<>)) {
                return Array.CreateInstance(type.GetGenericArguments()[0], 0);
            }
        }

        if (typeof(INbtTag).IsAssignableFrom(type)) {
            return INbtTag.FromJson("{}");
        }

        if (type.IsValueType) {
            object instance = Activator.CreateInstance(type)!;
            return type.IsPrimitive ? instance : Fill(instance, depth);
        }

        if (type.IsAbstract || type.IsInterface) {
            // Blocks, particles, sounds and friends are interfaces backed by a registry, so
            // borrow a real entry rather than giving up on the packet
            return FromRegistry(type)
                   ?? throw new InvalidOperationException($"no value for abstract {type.Name}");
        }

        return Fill(RuntimeHelpers.GetUninitializedObject(type), depth);
    }

    /// <summary>
    /// Finds any vanilla registry whose entries fit <paramref name="type"/> and returns one.
    /// </summary>
    private static object? FromRegistry(Type type) {
        foreach (ISubRegistry registry in VanillaRegistry.Data.SubRegistries) {
            Type? mapped = registry.GetType();
            while (mapped != null && !(mapped.IsGenericType
                                       && mapped.GetGenericTypeDefinition() == typeof(MappedRegistry<>))) {
                mapped = mapped.BaseType;
            }

            if (mapped == null || !type.IsAssignableFrom(mapped.GetGenericArguments()[0])) {
                continue;
            }

            PropertyInfo? byProtocolId = mapped.GetProperty("Item", [typeof(int)]);
            if (byProtocolId == null) {
                continue;
            }

            // Protocol ids are dense in practice, but not every registry starts at zero
            for (int id = 0; id < 16; id++) {
                try {
                    return byProtocolId.GetValue(registry, [id]);
                }
                catch (TargetInvocationException) {
                    // no entry with that id
                }
            }
        }

        return null;
    }
}

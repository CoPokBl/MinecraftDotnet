using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;
using System.Buffers.Binary;

namespace Minecraft.Data.Components.Types;

public record ProfileComponent() : IDataComponent<ProfileComponent.Data> {
    public override Identifier Identifier => "minecraft:profile";

    /// <summary>
    /// A lone string where only the name is known, which is the shorthand vanilla writes and accepts.
    /// The unique id travels as four ints rather than as its text form.
    /// </summary>
    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => val is { Name: not null, UniqueId: null, Properties.Length: 0 }
            ? new StringTag(val.Name)
            : new CompoundBuilder()
                .String("name", val.Name, null)
                .Maybe("id", val.UniqueId, id => new ArrayTag<int>(ToInts(id)))
                .ListOrOmit("properties", val.Properties, property => new CompoundBuilder()
                    .String("name", property.Name)
                    .String("value", property.Value)
                    .String("signature", property.Signature, null)
                    .Build())
                .Build(),

        (tag, _) => {
            if (tag is StringTag name) {
                return new Data(name.Value, null, []);
            }

            NbtNode node = NbtNode.Of(tag, "minecraft:profile");

            Data data = new(
                node.StringOrNull("name"),
                node.Has("id") ? FromInts(node.Require("id").GetIntegers()) : null,
                node.Objects("properties", property => {
                    ProfileProperty read = new() {
                        Name = property.String("name"),
                        Value = property.String("value"),
                        Signature = property.StringOrNull("signature")
                    };
                    property.AssertRead();
                    return read;
                }));

            node.AssertRead();
            return data;
        });


    private static int[] ToInts(Guid id) {
        Span<byte> bytes = stackalloc byte[16];
        id.TryWriteBytes(bytes, bigEndian: true, out _);

        return [
            BinaryPrimitives.ReadInt32BigEndian(bytes[..4]),
            BinaryPrimitives.ReadInt32BigEndian(bytes[4..8]),
            BinaryPrimitives.ReadInt32BigEndian(bytes[8..12]),
            BinaryPrimitives.ReadInt32BigEndian(bytes[12..])
        ];
    }

    private static Guid FromInts(ReadOnlySpan<int> parts) {
        Span<byte> bytes = stackalloc byte[16];

        for (int i = 0; i < 4; i++) {
            BinaryPrimitives.WriteInt32BigEndian(bytes[(i * 4)..], parts[i]);
        }

        return new Guid(bytes, bigEndian: true);
    }

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WritePrefixedOptional(val.Name, (s, wr) => wr.WriteString(s))
            .WritePrefixedOptional(val.UniqueId, (guid, wr) => wr.WriteUuid(guid))
            .WritePrefixedArray(val.Properties, registry);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(
            reader.ReadPrefixedOptional(r => r.ReadString()),
            reader.ReadPrefixedOptional(r => r.ReadUuid()),
            reader.ReadPrefixedArray(r => ProfileProperty.ReadData(r, registry))
        );
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Equals(val2);
    }

    public record Data(string? Name, Guid? UniqueId, ProfileProperty[] Properties) {
        public virtual bool Equals(Data? other) {
            if (other is null) return false;
            if (Name != other.Name) return false;
            if (UniqueId != other.UniqueId) return false;
            if (!Properties.SequenceEqual(other.Properties)) return false;
            return true;
        }

        public override int GetHashCode() {
            int propsHash = 17;
            foreach (ProfileProperty prop in Properties) {
                propsHash = propsHash * 31 + prop.GetHashCode();
            }
            return HashCode.Combine(Name, UniqueId, propsHash);
        }
    }
}

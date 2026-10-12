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
        (val, _) => val is { Name: not null, UniqueId: null, Properties.Length: 0 } && val.Patch == SkinPatch.Empty
            ? new StringTag(val.Name)
            : new CompoundBuilder()
                .String("name", val.Name, null)
                .Maybe("id", val.UniqueId, id => new ArrayTag<int>(ToInts(id)))
                .ListOrOmit("properties", val.Properties, property => new CompoundBuilder()
                    .String("name", property.Name)
                    .String("value", property.Value)
                    .String("signature", property.Signature, null)
                    .Build())
                .Id("texture", val.Patch.Body)
                .Id("cape", val.Patch.Cape)
                .Id("elytra", val.Patch.Elytra)
                .String("model", val.Patch.Slim is { } slim ? slim ? "slim" : "wide" : null, null)
                .Build(),

        (tag, _) => {
            if (tag is StringTag name) {
                return new Data(name.Value, null, []);
            }

            NbtNode node = NbtNode.Of(tag, "minecraft:profile");

            Data data = new(
                node.StringOrNull("name"),
                node.Has("id") ? FromInts(node.List("id", value => value.AsInt())) : null,
                node.Objects("properties", property => {
                    ProfileProperty read = new() {
                        Name = property.String("name"),
                        Value = property.String("value"),
                        Signature = property.StringOrNull("signature")
                    };
                    property.AssertRead();
                    return read;
                })) {
                Patch = new SkinPatch(
                    node.IdOrNull("texture"),
                    node.IdOrNull("cape"),
                    node.IdOrNull("elytra"),
                    node.StringOrNull("model") switch {
                        "slim" => true,
                        "wide" => false,
                        null => null,
                        var model => throw new FormatException($"Unknown player model {model}")
                    })
            };

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

    /// <summary>
    /// <c>ResolvableProfile.STREAM_CODEC</c>: either a whole game profile or a partial one, then the skin
    /// patch. A profile with both a name and an id goes as a whole one, which decodes to the same profile.
    /// </summary>
    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        if (val is { Name: { } name, UniqueId: { } id }) {
            writer.WriteBoolean(true).WriteUuid(id).WriteString(name);
        }
        else {
            writer.WriteBoolean(false)
                .WritePrefixedOptional(val.Name, (s, wr) => wr.WriteString(s))
                .WritePrefixedOptional(val.UniqueId, (guid, wr) => wr.WriteUuid(guid));
        }
        return writer
            .WritePrefixedArray(val.Properties, registry)
            .WritePrefixedOptional(val.Patch.Body?.ToString(), (s, wr) => wr.WriteString(s))
            .WritePrefixedOptional(val.Patch.Cape?.ToString(), (s, wr) => wr.WriteString(s))
            .WritePrefixedOptional(val.Patch.Elytra?.ToString(), (s, wr) => wr.WriteString(s))
            .WritePrefixedOptional(val.Patch.Slim, (slim, wr) => wr.WriteBoolean(slim));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) => Read(reader, registry);

    public static Data Read(DataReader reader, MinecraftRegistry registry) {
        string? name;
        Guid? id;
        if (reader.ReadBoolean()) {
            id = reader.ReadUuid();
            name = reader.ReadString();
        }
        else {
            name = reader.ReadPrefixedOptional(r => r.ReadString());
            id = reader.ReadPrefixedOptionalValue(r => r.ReadUuid());
        }
        return new Data(name, id, reader.ReadPrefixedArray(r => ProfileProperty.ReadData(r, registry))) {
            Patch = new SkinPatch(ReadAssetId(reader), ReadAssetId(reader), ReadAssetId(reader), reader.ReadPrefixedOptionalValue(r => r.ReadBoolean()))
        };
    }

    private static Identifier? ReadAssetId(DataReader reader) =>
        reader.ReadPrefixedOptional(r => r.ReadString()) is { } id ? Identifier.Parse(id) : (Identifier?)null;

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Equals(val2);
    }

    public record Data(string? Name, Guid? UniqueId, ProfileProperty[] Properties) {
        public SkinPatch Patch { get; init; } = SkinPatch.Empty;

        public virtual bool Equals(Data? other) {
            if (other is null) return false;
            if (Name != other.Name) return false;
            if (UniqueId != other.UniqueId) return false;
            if (!Properties.SequenceEqual(other.Properties)) return false;
            if (Patch != other.Patch) return false;
            return true;
        }

        public override int GetHashCode() {
            int propsHash = 17;
            foreach (ProfileProperty prop in Properties) {
                propsHash = propsHash * 31 + prop.GetHashCode();
            }
            return HashCode.Combine(Name, UniqueId, propsHash, Patch);
        }
    }

    /// <summary>
    /// <c>PlayerSkin.Patch</c>: resource pack textures, by asset id, drawn in place of the profile's own,
    /// and the arm model, slim or not, likewise.
    /// </summary>
    public sealed record SkinPatch(Identifier? Body, Identifier? Cape, Identifier? Elytra, bool? Slim) {
        public static readonly SkinPatch Empty = new(null, null, null, null);
    }
}

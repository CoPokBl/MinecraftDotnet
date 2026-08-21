using Minecraft.Data.Components.Codecs;
using Minecraft.Data.MapDecorationTypes;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// Markers drawn on a filled map that are not worked out from the world, keyed by a name the item
/// picks so a later update can move or replace one. Vanilla has no network form for it, so the value
/// travels as the tag its datapack form would be.
/// </summary>
public record MapDecorationsComponent() : IDataComponent<Dictionary<string, MapDecorationsComponent.Entry>> {
    public override Identifier Identifier => "minecraft:map_decorations";

    public override NbtCodec<Dictionary<string, Entry>>? Codec => Persistent;
    private static readonly NbtCodec<Dictionary<string, Entry>> Persistent = new(
        (val, _) => new CompoundTag(val
            .Select(decoration => (decoration.Key, (INbtTag)new CompoundBuilder()
                .Holder("type", decoration.Value.Type)
                .Double("x", decoration.Value.X)
                .Double("z", decoration.Value.Z)
                .Float("rotation", decoration.Value.Rotation)
                .Build()))
            .ToArray()),
        (tag, registry) => tag.GetCompound().Children.ToDictionary(
            decoration => decoration.key,
            decoration => {
                NbtNode node = NbtNode.Of(decoration.child, "minecraft:map_decorations");
                Entry entry = new(
                    node.Holder("type", registry.MapDecorationTypes),
                    node.Double("x"),
                    node.Double("z"),
                    node.Float("rotation"));
                node.AssertRead();
                return entry;
            }));

    public override DataWriter WriteData(Dictionary<string, Entry> val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(new CompoundTag(val
            .Select(d => (d.Key, (INbtTag)new CompoundTag(
                ("type", new StringTag(d.Value.Type.Identifier.ToString())),
                ("x", new DoubleTag(d.Value.X)),
                ("z", new DoubleTag(d.Value.Z)),
                ("rotation", new FloatTag(d.Value.Rotation)))))
            .ToArray()));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        CompoundTag tag = (CompoundTag)reader.ReadNbt();
        return tag.Children.ToDictionary(d => d.key, d => {
            CompoundTag entry = (CompoundTag)d.child;
            return new Entry(
                registry.MapDecorationTypes[(Identifier)entry["type"]!.GetString()],
                entry["x"]!.GetDouble(),
                entry["z"]!.GetDouble(),
                entry["rotation"]!.GetFloat());
        });
    }

    public override bool ValuesEqual(Dictionary<string, Entry> val1, Dictionary<string, Entry> val2) {
        return val1.Count == val2.Count &&
               val1.All(d => val2.TryGetValue(d.Key, out Entry? other) && other == d.Value);
    }

    /// <param name="X">World x the marker sits at, not a map pixel.</param>
    /// <param name="Rotation">Degrees clockwise from north.</param>
    public record Entry(IMapDecorationType Type, double X, double Z, float Rotation) {
        public virtual bool Equals(Entry? other) {
            return other != null && Type.Identifier == other.Type.Identifier && X.Equals(other.X) &&
                   Z.Equals(other.Z) && Rotation.Equals(other.Rotation);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Type.Identifier, X, Z, Rotation);
        }
    }
}

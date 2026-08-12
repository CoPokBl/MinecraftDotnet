using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// What one layer of the world (a biome, a dimension, a timeline) has to say about the
/// environment attributes.
/// </summary>
public record EnvironmentAttributeMap(IReadOnlyDictionary<IEnvironmentAttribute, EnvironmentAttributeEntry> Entries) {

    public static readonly EnvironmentAttributeMap Empty =
        new(new Dictionary<IEnvironmentAttribute, EnvironmentAttributeEntry>());

    public int Count => Entries.Count;

    public EnvironmentAttributeEntry? this[IEnvironmentAttribute attribute] =>
        Entries.GetValueOrDefault(attribute);

    /// <param name="syncableOnly">
    /// Drop the attributes the client is never told about. The registry data sent during
    /// configuration is filtered this way, so a map written for the client has to match.
    /// </param>
    public INbtTag ToNbt(bool syncableOnly = false) {
        return new CompoundTag(Entries
            .Where(e => !syncableOnly || e.Key.Syncable)
            .Select(e => (e.Key.Identifier.ToString(), e.Value.ToNbt()))
            .ToArray());
    }

    public static EnvironmentAttributeMap FromNbt(INbtTag tag, MinecraftRegistry reg) {
        Dictionary<IEnvironmentAttribute, EnvironmentAttributeEntry> entries = [];
        foreach ((string key, INbtTag value) in ((CompoundTag)tag).Children) {
            Identifier id = key;
            if (!reg.EnvironmentAttributes.Contains(id)) {
                // A datapack can name an attribute this version doesn't have. Dropping it beats
                // failing the whole biome, since nothing can be done with a value whose type is
                // unknown anyway.
                Console.WriteLine($"WARNING: skipping unknown environment attribute {id}");
                continue;
            }

            IEnvironmentAttribute attribute = reg.EnvironmentAttributes[id];
            entries[attribute] = EnvironmentAttributeEntry.FromNbt(attribute, value, reg);
        }

        return new EnvironmentAttributeMap(entries);
    }

    public virtual bool Equals(EnvironmentAttributeMap? other) {
        return other != null && Entries.Count == other.Entries.Count
               && Entries.All(e => other.Entries.TryGetValue(e.Key, out EnvironmentAttributeEntry? v)
                                   && v == e.Value);
    }

    public override int GetHashCode() {
        return Entries.Count;
    }
}

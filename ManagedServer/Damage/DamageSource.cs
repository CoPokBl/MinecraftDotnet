using System.Runtime.CompilerServices;
using ManagedServer.Entities.Types;
using Minecraft.Data.DamageType;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Damage;

/// <summary>
/// What a hit was, vanilla's <c>DamageSource</c>. The <see cref="Type"/> is the whole of what the
/// client is told and most of what the server decides from: which reductions apply, whether fire
/// resistance stops it, and what the death message reads, are all tag lookups on it rather than
/// anything a damage source has to carry itself.
/// <p/>
/// <see cref="Attacker"/> and <see cref="Direct"/> are vanilla's <c>getEntity</c> and
/// <c>getDirectEntity</c>: for a shot arrow they are the archer and the arrow. Both are null for
/// environmental damage, which is what <see cref="Position"/> is for.
/// </summary>
public record DamageSource(IDamageType Type) {
    /// <summary>Who is responsible, i.e. the mob or player credited with the kill.</summary>
    public Entity? Attacker { get; init; }

    /// <summary>
    /// What actually landed the hit, such as the arrow rather than the archer. A melee hit sets this
    /// to the attacker as well, which is what vanilla's one entity constructor does, and what makes
    /// the hit have a position: blocking a hit from nowhere is not possible.
    /// </summary>
    public Entity? Direct { get; init; }

    /// <summary>Where sourceless damage came from, such as the centre of an explosion.</summary>
    public Vec3<double>? Position { get; init; }

    /// <summary>
    /// The weapon the hit was dealt with, which is what armour effectiveness enchantments read.
    /// Null for anything not swung.
    /// </summary>
    public ItemStack? Weapon { get; init; }

    /// <summary>
    /// Where the hit came from, vanilla's <c>getSourcePosition</c>: the position given for sourceless
    /// damage, and otherwise wherever the thing that landed it is. Null for damage with neither, which
    /// is what makes drowning and starving come from no direction at all.
    /// </summary>
    public Vec3<double>? SourcePosition => Position ?? Direct?.Position;

    /// <summary>
    /// Whether this source's damage type is in a <c>minecraft:damage_type</c> tag, which is how
    /// vanilla's <c>DamageSource.is</c> answers every question about what a hit ignores. A tag the
    /// registry does not have reads as empty, so an unloaded tag denies rather than throws.
    /// </summary>
    public bool IsIn(MinecraftRegistry registry, Identifier tag) {
        return TagContents(registry, tag).Contains(Type.Identifier);
    }

    /// <summary>
    /// <c>GetValueIds</c> builds a fresh array and walks any tag references inside it, and the
    /// pipeline asks about the same handful of tags on every hit, so the answers are kept per
    /// registry. The table holds registries weakly so a test that builds its own does not pin it.
    /// </summary>
    private static readonly ConditionalWeakTable<MinecraftRegistry, Dictionary<Identifier, HashSet<Identifier>>>
        TagCache = new();

    private static HashSet<Identifier> TagContents(MinecraftRegistry registry, Identifier tag) {
        Dictionary<Identifier, HashSet<Identifier>> cache = TagCache.GetOrCreateValue(registry);
        lock (cache) {
            if (cache.TryGetValue(tag, out HashSet<Identifier>? contents)) {
                return contents;
            }

            contents = registry.DamageTypes.Tags.Contains(tag)
                ? [..registry.DamageTypes.Tags[tag].GetValueIds(registry)]
                : [];
            cache[tag] = contents;
            return contents;
        }
    }
}

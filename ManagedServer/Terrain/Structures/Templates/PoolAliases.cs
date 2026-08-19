using System.Text.Json;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// <c>PoolAliasBinding</c>: a rule that redirects one pool id to another for a single structure.
/// </summary>
/// <remarks>
/// This is how a trial chamber picks one mob for all of its spawners at once: the templates name an
/// alias pool, and the structure resolves that alias once, so every spawner in the chamber holds the
/// same kind. A per spawner draw would give a chamber of assorted mobs.
/// </remarks>
public interface IPoolAliasBinding {
    /// <summary>Adds this binding's resolved pairs to the map being built.</summary>
    void Resolve(RandomSource random, Dictionary<Identifier, Identifier> into);

    public sealed record Direct(Identifier Alias, Identifier Target) : IPoolAliasBinding {
        public void Resolve(RandomSource random, Dictionary<Identifier, Identifier> into) {
            into[Alias] = Target;
        }
    }

    public sealed class Random(Identifier alias, WeightedList<Identifier> targets)
        : IPoolAliasBinding {

        public void Resolve(RandomSource random, Dictionary<Identifier, Identifier> into) {
            into[alias] = targets.GetRandomOrThrow(random);
        }
    }

    /// <summary>
    /// One of several whole groups of bindings, drawn together.
    /// </summary>
    /// <remarks>
    /// The group is what keeps a set of aliases consistent with each other: a chamber that drew a
    /// skeleton for its ranged spawners gets the skeleton variant of its slow ranged ones too, because
    /// both pairs are in the same group.
    /// </remarks>
    public sealed class RandomGroup(WeightedList<IReadOnlyList<IPoolAliasBinding>> groups)
        : IPoolAliasBinding {

        public void Resolve(RandomSource random, Dictionary<Identifier, Identifier> into) {
            foreach (IPoolAliasBinding binding in groups.GetRandomOrThrow(random)) {
                binding.Resolve(random, into);
            }
        }
    }
}

/// <summary>
/// <c>PoolAliasLookup</c>: the alias map a single structure resolved, or the identity.
/// </summary>
/// <remarks>
/// Built from a random seeded on the structure's <b>starting position</b>, so every chunk that replays
/// the structure resolves the same aliases and the two halves of a chamber across a border hold the
/// same mobs.
/// </remarks>
public sealed class PoolAliasLookup {
    public static readonly PoolAliasLookup Identity = new(null);

    private readonly Dictionary<Identifier, Identifier>? _map;

    private PoolAliasLookup(Dictionary<Identifier, Identifier>? map) {
        _map = map;
    }

    public static PoolAliasLookup Create(IReadOnlyList<IPoolAliasBinding> bindings, Vec3<int> pos,
        long seed) {

        if (bindings.Count == 0) {
            return Identity;
        }

        RandomSource random = new LegacyRandomSource(seed).ForkPositional().At(pos.X, pos.Y, pos.Z);
        Dictionary<Identifier, Identifier> map = [];

        foreach (IPoolAliasBinding binding in bindings) {
            binding.Resolve(random, map);
        }

        return new PoolAliasLookup(map);
    }

    public Identifier Lookup(Identifier alias) {
        return _map is not null && _map.TryGetValue(alias, out Identifier target) ? target : alias;
    }
}

/// <summary>Reads the <c>pool_aliases</c> list of a jigsaw structure file.</summary>
public static class PoolAliasParser {
    public static List<IPoolAliasBinding> ParseAll(JsonElement element) {
        return element.EnumerateArray().Select(Parse).ToList();
    }

    public static IPoolAliasBinding Parse(JsonElement element) {
        string type = Identifier.Parse(element.GetProperty("type").GetString()!).Key;

        switch (type) {
            case "direct":
                return new IPoolAliasBinding.Direct(
                    Identifier.Parse(element.GetProperty("alias").GetString()!),
                    Identifier.Parse(element.GetProperty("target").GetString()!));

            case "random":
                return new IPoolAliasBinding.Random(
                    Identifier.Parse(element.GetProperty("alias").GetString()!),
                    Weighted(element.GetProperty("targets"),
                        entry => Identifier.Parse(entry.GetString()!)));

            case "random_group":
                return new IPoolAliasBinding.RandomGroup(
                    Weighted<IReadOnlyList<IPoolAliasBinding>>(element.GetProperty("groups"),
                        ParseAll));

            default:
                throw new FormatException($"Unknown pool alias binding type \"{type}\".");
        }
    }

    /// <summary>
    /// A weighted list in the <c>{data, weight}</c> form the alias bindings use.
    /// </summary>
    /// <remarks>
    /// The weight is optional and defaults to one, which is what every vanilla entry writes anyway.
    /// </remarks>
    private static WeightedList<T> Weighted<T>(JsonElement element, Func<JsonElement, T> read) {
        List<(T Value, int Weight)> entries = [];

        foreach (JsonElement entry in element.EnumerateArray()) {
            entries.Add((read(entry.GetProperty("data")),
                entry.TryGetProperty("weight", out JsonElement weight) ? weight.GetInt32() : 1));
        }

        return new WeightedList<T>(entries);
    }
}

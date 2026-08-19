using Minecraft.Schemas;

namespace ManagedServer.Terrain.Features.Values;

/// <summary>
/// Vanilla's <c>WeightedList</c>: one draw against the total weight, then a walk to find which entry
/// that index landed in.
/// </summary>
/// <remarks>
/// Vanilla picks between a flat expansion and a cumulative walk on a threshold of 64. Both answer the
/// same entry for the same index, so only the walk is here; the split upstream is about the cost of
/// the lookup, not about the result.
/// <p/>
/// An empty list is a state the datapack format allows and <c>getRandomOrThrow</c> rejects, so it is
/// rejected here too rather than silently placing nothing.
/// </remarks>
public sealed class WeightedList<T> {
    private readonly (T Value, int Weight)[] _entries;
    private readonly int _totalWeight;

    public WeightedList(IReadOnlyList<(T Value, int Weight)> entries) {
        _entries = [..entries];
        _totalWeight = _entries.Sum(entry => entry.Weight);
    }

    public IReadOnlyList<(T Value, int Weight)> Entries => _entries;

    public IEnumerable<T> Values => _entries.Select(entry => entry.Value);

    public int TotalWeight => _totalWeight;

    public T GetRandomOrThrow(RandomSource random) {
        if (_totalWeight == 0) {
            throw new InvalidOperationException("A weighted list with no elements was drawn from.");
        }

        int selection = random.NextInt(_totalWeight);
        foreach ((T value, int weight) in _entries) {
            selection -= weight;
            if (selection < 0) {
                return value;
            }
        }

        // Unreachable while the weights sum to the total, which the constructor is what decides.
        throw new InvalidOperationException("A weighted list's weights do not sum to its total.");
    }
}

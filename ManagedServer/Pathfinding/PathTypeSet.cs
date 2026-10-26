using System.Collections;
using Minecraft.Data.Generated;

namespace ManagedServer.Pathfinding;

/// <summary>
/// A set of <see cref="PathType"/>s that iterates in <b>declaration order</b>, standing in for
/// vanilla's <c>EnumSet</c>.
/// <p/>
/// The ordering is not a detail. <c>WalkNodeEvaluator.getPathTypeOfMob</c> picks the type with the
/// highest malus using <c>&gt;=</c>, so every tie is won by whichever comes <b>last</b> in
/// iteration. A mob standing on the floor sees <c>WALKABLE</c> at its feet and <c>OPEN</c> at its
/// head, both costing nothing; in ordinal order that resolves to <c>WALKABLE</c> and the mob can
/// start a search, and in insertion order it resolves to <c>OPEN</c> and the search refuses to
/// begin. A hash set looks like a faithful translation of <c>EnumSet</c> and is not.
/// <p/>
/// Backed by a bitmask, since there are 27 types and this is built once per candidate position.
/// </summary>
public struct PathTypeSet : IEnumerable<PathType> {
    private uint _mask;

    public void Add(PathType type) {
        _mask |= 1u << (int)type;
    }

    public readonly bool Contains(PathType type) {
        return (_mask & (1u << (int)type)) != 0;
    }

    public readonly int Count => System.Numerics.BitOperations.PopCount(_mask);

    /// <summary>The only member of a single element set. Undefined for anything else.</summary>
    public readonly PathType Single => (PathType)System.Numerics.BitOperations.TrailingZeroCount(_mask);

    public readonly IEnumerator<PathType> GetEnumerator() {
        uint remaining = _mask;

        while (remaining != 0) {
            int index = System.Numerics.BitOperations.TrailingZeroCount(remaining);
            remaining &= remaining - 1;
            yield return (PathType)index;
        }
    }

    readonly IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}

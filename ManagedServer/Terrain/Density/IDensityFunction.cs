using System.Runtime.CompilerServices;
using ManagedServer.Terrain.Noise;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Density;

/// <summary>Where a density function is being sampled, vanilla's <c>DensityFunction.FunctionContext</c>.</summary>
/// <remarks>
/// An interface rather than three ints because the cell interpolator implements it over mutable state
/// it advances as it walks a cell, so a function reads the current position without anything being
/// copied per sample.
/// </remarks>
public interface IFunctionContext {
    int BlockX { get; }
    int BlockY { get; }
    int BlockZ { get; }
}

/// <summary>A single position to sample at, vanilla's <c>SinglePointContext</c>.</summary>
public readonly record struct SinglePointContext(int BlockX, int BlockY, int BlockZ) : IFunctionContext;

/// <summary>
/// Supplies the positions behind a bulk <see cref="IDensityFunction.FillArray"/>, vanilla's
/// <c>ContextProvider</c>.
/// </summary>
/// <remarks>
/// The indirection is what lets a cache decide whether to fill its own array or delegate: a function
/// that has nothing to bulk optimise calls <see cref="FillAllDirectly"/> and gets a plain loop.
/// </remarks>
public interface IContextProvider {
    IFunctionContext ForIndex(int index);

    void FillAllDirectly(double[] output, IDensityFunction function);
}

/// <summary>
/// Rewrites a function tree, vanilla's <c>DensityFunction.Visitor</c>. This is how a bare tree parsed
/// from JSON becomes one bound to a world: the noise holders get their noise and the markers become
/// the caches and interpolators that make a chunk cheap to fill.
/// </summary>
public interface IDensityFunctionVisitor {
    IDensityFunction Apply(IDensityFunction input);

    /// <summary>Binds a named noise to a real one. The default leaves it unbound.</summary>
    NoiseHolder VisitNoise(NoiseHolder noise) => noise;
}

/// <summary>
/// A named noise and, once a visitor has bound it, the noise itself. Vanilla's
/// <c>DensityFunction.NoiseHolder</c>.
/// </summary>
/// <remarks>
/// Unbound it reads as flat zero with a max of two, which is what lets a tree be parsed, have its
/// value range computed, and only then be given a seed.
/// </remarks>
public sealed record NoiseHolder(Identifier NoiseId, NormalNoise? Noise = null) {
    public double GetValue(double x, double y, double z) {
        return Noise?.GetValue(x, y, z) ?? 0.0;
    }

    public double MaxValue => Noise?.MaxValue ?? 2.0;
}

/// <summary>
/// One node of vanilla's density function tree: a scalar field over block positions that every part
/// of noise terrain, from the shape of a mountain to whether a cave has lava in it, is expressed in.
/// </summary>
/// <remarks>
/// <see cref="MinValue"/> and <see cref="MaxValue"/> are not diagnostics. Ranges propagate up the tree
/// and are what let <c>min</c> and <c>max</c> nodes collapse to one side at build time, and what lets
/// the chunk filler skip a cell whose density cannot reach the surface threshold. A node reporting a
/// range it can leave produces terrain with holes in it that look like a noise bug.
/// </remarks>
public interface IDensityFunction {
    double Compute(IFunctionContext context);

    /// <summary>
    /// Samples a whole run of positions. Usually a plain loop through the provider; a node implements
    /// it differently when doing the run at once is cheaper, which for the caches and the interpolator
    /// is the whole point.
    /// </summary>
    void FillArray(double[] output, IContextProvider provider);

    /// <summary>Rebuilds this node with the visitor applied to its children, and nothing else.</summary>
    /// <remarks>
    /// Deliberately has no default: a node that holds children and forgets this silently keeps the
    /// unbound ones, so its noise reads flat zero and its terrain comes out empty.
    /// </remarks>
    IDensityFunction MapChildren(IDensityFunctionVisitor visitor);

    double MinValue { get; }

    double MaxValue { get; }

    /// <summary>
    /// The visitor applied to the whole tree, bottom up: children first, then the node holding them.
    /// </summary>
    /// <remarks>
    /// Passing a <see cref="DensityFunctionRewrite"/> continues that rewrite rather than starting a
    /// new one, which is how several trees are mapped as one pass and end up sharing their caches.
    /// </remarks>
    IDensityFunction MapAll(IDensityFunctionVisitor visitor) {
        return DensityFunctionRewrite.Of(visitor).Apply(this);
    }
}

/// <summary>
/// One rewrite of a function tree, vanilla's <c>RecursiveVisitor</c> and the memo beside it.
/// </summary>
/// <remarks>
/// The memo is what makes caching mean anything. A density function reached through a <c>$ref</c> is
/// the same node object however many paths lead to it, and a marker under it has to become
/// <b>one</b> cache rather than one per path: the overworld's ten distinct <c>flat_cache</c> markers
/// occur over eighteen hundred times between them, and building a
/// <see cref="NoiseChunk"/>'s flat cache samples its whole subtree twenty five times.
/// <p/>
/// Keyed by reference on the node going in. Vanilla keys on the node coming out and reaches the same
/// answer because its density functions are records with structural equality, so two separately
/// built but structurally identical subtrees share one cache there and get one each here. That costs
/// cache objects, never values.
/// <p/>
/// A node this rewrite produced is returned untouched. That is what lets a tree be mapped twice:
/// <see cref="NoiseChunk"/> maps the router, then maps the final density again to put a cell cache
/// over it, and the second pass has to find the first pass's interpolators rather than build a
/// parallel set that samples the same noise all over again.
/// </remarks>
public sealed class DensityFunctionRewrite(IDensityFunctionVisitor visitor) : IDensityFunctionVisitor {
    private readonly Dictionary<IDensityFunction, IDensityFunction> _rewritten =
        new(ReferenceComparer.Instance);

    private readonly HashSet<IDensityFunction> _produced = new(ReferenceComparer.Instance);

    /// <summary>Continues <paramref name="visitor"/>'s rewrite if it is one, otherwise starts one.</summary>
    public static DensityFunctionRewrite Of(IDensityFunctionVisitor visitor) {
        return visitor as DensityFunctionRewrite ?? new DensityFunctionRewrite(visitor);
    }

    public IDensityFunction Apply(IDensityFunction input) {
        if (_produced.Contains(input)) {
            return input;
        }

        if (_rewritten.TryGetValue(input, out IDensityFunction? existing)) {
            return existing;
        }

        IDensityFunction result = visitor.Apply(input.MapChildren(this));
        _rewritten[input] = result;
        _produced.Add(result);
        return result;
    }

    public NoiseHolder VisitNoise(NoiseHolder noise) => visitor.VisitNoise(noise);

    /// <summary>
    /// Identity rather than equality, because a node here is a class and two of them holding equal
    /// values are still two functions.
    /// </summary>
    private sealed class ReferenceComparer : IEqualityComparer<IDensityFunction> {
        public static readonly ReferenceComparer Instance = new();

        public bool Equals(IDensityFunction? x, IDensityFunction? y) => ReferenceEquals(x, y);

        public int GetHashCode(IDensityFunction obj) => RuntimeHelpers.GetHashCode(obj);
    }
}

/// <summary>
/// A function with no children, vanilla's <c>SimpleFunction</c>. It has nothing to rebuild and nothing
/// to bulk optimise, so a visitor passes straight through it and a bulk fill is a plain loop.
/// </summary>
public interface ISimpleDensityFunction : IDensityFunction {
    void IDensityFunction.FillArray(double[] output, IContextProvider provider) {
        provider.FillAllDirectly(output, this);
    }

    IDensityFunction IDensityFunction.MapChildren(IDensityFunctionVisitor visitor) => this;
}

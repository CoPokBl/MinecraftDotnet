using ManagedServer.Terrain.Noise;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ManagedServer.Terrain.Density;

/// <summary>
/// One node of a density function tree as the data describes it, vanilla's <c>DensityFunction</c>.
/// It is compiled into an <see cref="IDensitySampler"/> before anything samples it.
/// </summary>
/// <remarks>
/// Nodes are records and equality is structural, as upstream, because the compiler deduplicates
/// <c>cache</c> nodes by their input's equality: two separately parsed but identical subtrees share
/// one cache. A node holding a list overrides equality to compare its elements. A reference into the
/// registry is equal only to a reference with the same id, never to the function it names, so a cache
/// over a reference and a cache over the same function written inline are two caches.
/// <p/>
/// The rewrite methods compare children by reference, never with <c>==</c>, which a record overloads
/// to mean equality.
/// </remarks>
public interface IDensityFunction {
    IDensitySampler CompileSampler(ICompileContext context);

    /// <summary>This node with <paramref name="rule"/> applied to each child, or this node itself when no child changed.</summary>
    IDensityFunction RewriteChildren(IDfRewriteRule rule);

    Interval Range { get; }

    /// <summary>The axes this node's value depends on, a mask of <see cref="DensityAxes"/>.</summary>
    int DomainAxes { get; }
}

/// <summary>The axis bits of <see cref="IDensityFunction.DomainAxes"/>.</summary>
public static class DensityAxes {
    public const int X = 1;
    public const int Y = 2;
    public const int Z = 4;
    public const int None = 0;
    public const int All = 7;

    public static int From(Axis axis) {
        return axis switch {
            Axis.X => X,
            Axis.Y => Y,
            Axis.Z => Z,
            _ => throw new ArgumentOutOfRangeException(nameof(axis))
        };
    }

    public static int Choose(this Axis axis, int x, int y, int z) {
        return axis switch {
            Axis.X => x,
            Axis.Y => y,
            _ => z
        };
    }
}

/// <summary>What compiling a node needs from the world, vanilla's <c>DensityFunction.CompileContext</c>.</summary>
public interface ICompileContext {
    INoise CreateNoiseSampler(NoiseHolder noise);

    RandomSource CreateRandom(Identifier seed);

    /// <summary>The end's island noise is seeded from the world seed directly. Deprecated upstream.</summary>
    RandomSource CreateEndIslandRandom();
}

/// <summary>A tree rewrite, vanilla's <c>DfRewriteRule</c>.</summary>
public interface IDfRewriteRule {
    IDensityFunction Rewrite(IDensityFunction function);
}

/// <summary>
/// A named noise as a node refers to it, vanilla's <c>Holder&lt;NormalNoise&gt;</c>. A registry entry
/// carries its <see cref="Key"/>; one written inline does not, and only the nether's two legacy noises
/// can be compiled without one.
/// </summary>
public sealed record NoiseHolder(Identifier? Key, NormalNoise Value) {
    public bool Equals(NoiseHolder? other) {
        if (other is null) {
            return false;
        }

        return Key is { } key ? other.Key == key : other.Key is null && Value.Equals(other.Value);
    }

    public override int GetHashCode() => Key?.GetHashCode() ?? Value.GetHashCode();
}

/// <summary>
/// A reference into the <c>worldgen/density_function</c> registry, vanilla's <c>HolderHolder</c>. The
/// compiler inlines it; until then it stands for the function without being equal to it.
/// </summary>
public sealed class DensityFunctionReference(Identifier id, Func<Identifier, IDensityFunction> resolve)
    : IDensityFunction, IEquatable<DensityFunctionReference> {

    private IDensityFunction? _value;

    public Identifier Id => id;

    /// <summary>Resolved on first use, so a reference can name a function registered after it.</summary>
    public IDensityFunction Value => _value ??= resolve(id);

    public IDensitySampler CompileSampler(ICompileContext context) => Value.CompileSampler(context);

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) {
        IDensityFunction value = Value;
        IDensityFunction rewritten = rule.Rewrite(value);
        return ReferenceEquals(rewritten, value) ? this : rewritten;
    }

    public Interval Range => Value.Range;

    public int DomainAxes => Value.DomainAxes;

    public bool Equals(DensityFunctionReference? other) => other is not null && other.Id == id;

    public override bool Equals(object? obj) => Equals(obj as DensityFunctionReference);

    public override int GetHashCode() => id.GetHashCode();

    public override string ToString() => id.ToString();
}

/// <summary>The rewrites the compiler runs, vanilla's <c>DfRewriteRule</c> constants.</summary>
public static class DfRewriteRules {
    public static IDensityFunction InlineReference(IDensityFunction function) {
        return function is DensityFunctionReference reference ? reference.Value : function;
    }

    /// <summary>
    /// Wraps each child that depends on fewer axes than its parent in a <c>slice</c> at 0 on every axis
    /// it does not read, X then Z then Y. Values are unchanged; what changes is which positions a cache
    /// under the child is keyed on, which is the point.
    /// </summary>
    public sealed record SliceUniformAxes(int ParentDomainAxes) : IDfRewriteRule {
        public static readonly SliceUniformAxes Root = new(DensityAxes.All);

        public IDensityFunction Rewrite(IDensityFunction function) {
            if (ShouldSkip(function)) {
                return function;
            }

            int domainAxes = function.DomainAxes;
            if (ParentDomainAxes == domainAxes) {
                return function.RewriteChildren(this);
            }

            IDensityFunction newFunction = function.RewriteChildren(new SliceUniformAxes(domainAxes));
            int removedAxes = ParentDomainAxes & ~domainAxes;
            return RemoveAxes(newFunction, removedAxes);
        }

        private static IDensityFunction RemoveAxes(IDensityFunction function, int axes) {
            int filteredAxes = axes & ~ExistingRemovedAxes(function);
            if ((filteredAxes & DensityAxes.X) != 0) {
                function = new SliceFunction(Axis.X, 0, function);
            }

            if ((filteredAxes & DensityAxes.Z) != 0) {
                function = new SliceFunction(Axis.Z, 0, function);
            }

            if ((filteredAxes & DensityAxes.Y) != 0) {
                function = new SliceFunction(Axis.Y, 0, function);
            }

            return function;
        }

        private static int ExistingRemovedAxes(IDensityFunction function) {
            int axes = 0;
            while (function is SliceFunction slice) {
                axes |= DensityAxes.From(slice.Axis);
                function = slice.Input;
            }

            return axes;
        }

        private static bool ShouldSkip(IDensityFunction function) {
            return function is ConstantFunction or GradientFunction;
        }
    }
}

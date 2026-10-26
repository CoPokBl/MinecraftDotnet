using System.Collections.Concurrent;

namespace ManagedServer.Terrain.Density;

/// <summary>
/// Turns density functions into samplers for one world, vanilla's <c>DensityFunctionCompiler</c>.
/// </summary>
/// <remarks>
/// Each <c>cache</c> becomes a <see cref="CachingDensitySampler"/> with an id shared by every
/// occurrence of a structurally equal input, across every function this compiler is asked for. Ids
/// are handed out in compile order, which only decides which cache cell a context indexes, never a
/// value.
/// </remarks>
public sealed class DensityFunctionCompiler {
    private readonly ICompileContext _context;
    private readonly ConcurrentDictionary<IDensityFunction, IDensitySampler> _samplers = new();
    private readonly Dictionary<IDensityFunction, PreparedCache> _preparedCaches = new();
    private readonly Lock _compileLock = new();
    private readonly IDfRewriteRule _dedupeRule;
    private int _nextCacheId;

    public DensityFunctionCompiler(ICompileContext context) {
        _context = context;
        _dedupeRule = new DedupeCachesRule(this);
    }

    public IDensitySampler GetSampler(IDensityFunction function) {
        if (_samplers.TryGetValue(function, out IDensitySampler? existing)) {
            return existing;
        }

        IDensitySampler compiled = OptimizeAndCompile(function);
        return _samplers.GetOrAdd(function, compiled);
    }

    private IDensityFunction Optimize(IDensityFunction function) {
        return DfRewriteRules.SliceUniformAxes.Root.Rewrite(_dedupeRule.Rewrite(function));
    }

    private IDensitySampler OptimizeAndCompile(IDensityFunction function) {
        lock (_compileLock) {
            return Optimize(function).CompileSampler(_context);
        }
    }

    private IDensityFunction ReuseOrPrepareCache(CacheFunction cache) {
        if (!_preparedCaches.TryGetValue(cache.Input, out PreparedCache? prepared)) {
            prepared = PrepareCache(cache);
            _preparedCaches[cache.Input] = prepared;
        }

        return prepared;
    }

    private PreparedCache PrepareCache(CacheFunction cache) {
        int id = _nextCacheId++;
        IDensityFunction input = Optimize(cache.Input);
        CachingDensitySampler cachingSampler = new(id, input.CompileSampler(_context));
        return new PreparedCache(id, input.Range, input.DomainAxes, cachingSampler);
    }

    private sealed class DedupeCachesRule(DensityFunctionCompiler compiler) : IDfRewriteRule {
        public IDensityFunction Rewrite(IDensityFunction function) {
            function = DfRewriteRules.InlineReference(function);
            return function is CacheFunction cache ? compiler.ReuseOrPrepareCache(cache) : function.RewriteChildren(this);
        }
    }

    /// <summary>A deduplicated cache, already compiled. Equal only to itself.</summary>
    private sealed class PreparedCache(int id, Interval range, int domainAxes, IDensitySampler cachingSampler) : IDensityFunction {
        public int Id => id;

        public IDensitySampler CompileSampler(ICompileContext context) => cachingSampler;

        public IDensityFunction RewriteChildren(IDfRewriteRule rule) => this;

        public Interval Range => range;

        public int DomainAxes => domainAxes;
    }
}

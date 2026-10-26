using Minecraft.Schemas;

namespace ClientLib.Recipes;

/// <summary>
/// <c>FullTextSearchTree</c> as <c>SessionSearchTrees.updateRecipes</c> builds it over the book's collections:
/// a query without a colon is a substring of a result's tooltip line, and <c>namespace:path</c> needs a result
/// whose namespace contains the first half and whose path or a tooltip line contains the second. Matches come
/// back in the order the collections were given.
/// </summary>
/// <remarks>
/// Vanilla answers from suffix arrays. A book holds at most a couple of thousand lines, so a substring scan per
/// keystroke costs well under a millisecond and gives the same matches.
/// </remarks>
public sealed class RecipeSearchTree {
    private readonly List<(RecipeCollection Collection, string[] Names, (string Namespace, string Path)[] Ids)> _entries = [];

    public static readonly RecipeSearchTree Empty = new([], _ => [], _ => []);

    /// <param name="names">Tooltip lines of every result, formatting stripped and trimmed.</param>
    /// <param name="ids">The registry key of every result.</param>
    public RecipeSearchTree(IEnumerable<RecipeCollection> collections, Func<RecipeCollection, IEnumerable<string>> names,
        Func<RecipeCollection, IEnumerable<Identifier>> ids) {
        foreach (RecipeCollection collection in collections) {
            _entries.Add((collection,
                names(collection).Where(name => name.Length > 0).Select(name => name.ToLowerInvariant()).ToArray(),
                ids(collection).Select(id => (id.Namespace.ToLowerInvariant(), id.Key.ToLowerInvariant())).ToArray()));
        }
    }

    public List<RecipeCollection> Search(string text) {
        int colon = text.IndexOf(':');
        if (colon == -1) {
            return _entries.Where(e => e.Names.Any(name => name.Contains(text, StringComparison.Ordinal))).Select(e => e.Collection).ToList();
        }
        string ns = text[..colon].Trim(), path = text[(colon + 1)..].Trim();
        return _entries.Where(e => e.Ids.Any(id => id.Namespace.Contains(ns, StringComparison.Ordinal))
                                   && (e.Ids.Any(id => id.Path.Contains(path, StringComparison.Ordinal))
                                       || e.Names.Any(name => name.Contains(path, StringComparison.Ordinal))))
            .Select(e => e.Collection).ToList();
    }
}

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>VillagerProfession</c>'s keys by registry id. The registry is built in rather than sent, so the
/// ids are <c>VillagerProfession.bootstrap</c>'s registration order.
/// </summary>
public static class VillagerProfessions {
    public const int None = 0;
    public const int Nitwit = 11;

    private static readonly string[] Keys = [
        "none", "armorer", "butcher", "cartographer", "cleric", "farmer", "fisherman", "fletcher", "leatherworker", "librarian", "mason",
        "nitwit", "shepherd", "toolsmith", "weaponsmith"
    ];

    /// <summary>The key's path, or null for an id the build does not know.</summary>
    public static string? KeyOf(int id) => id >= 0 && id < Keys.Length ? Keys[id] : null;
}

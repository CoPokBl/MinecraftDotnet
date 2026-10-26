using ClientLib.Packs;
using Minecraft.Text;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary><c>Pack.Position</c>.</summary>
public enum PackPosition {
    Top,
    Bottom
}

/// <summary><c>PackSource</c>: what a pack's description says about where it came from.</summary>
public enum PackOrigin {
    Default,
    BuiltIn,
    Server,

    /// <summary>Not vanilla's: a pack given with <c>--resource-pack</c>.</summary>
    Launch
}

/// <summary>
/// <c>Pack</c>: one resource pack the repository knows, and how it sits in the selection.
/// <see cref="Open"/> opens its files afresh for each reload, which closes them after.
/// </summary>
public sealed class ClientPack(string id, TextComponent title, PackMetadata metadata, PackOrigin origin, bool required, bool fixedPosition,
    PackPosition defaultPosition, Func<IReadOnlyList<(string Name, PackFiles.IPack Pack)>> open) {
    public string Id { get; } = id;
    public TextComponent Title { get; } = title;
    public PackMetadata Metadata { get; } = metadata;
    public PackOrigin Origin { get; } = origin;
    public bool Required { get; } = required;
    public bool FixedPosition { get; } = fixedPosition;
    public PackPosition DefaultPosition { get; } = defaultPosition;

    public IReadOnlyList<(string Name, PackFiles.IPack Pack)> Open() => open();

    /// <summary><c>PackSource.decorate</c> of the description.</summary>
    public TextComponent ExtendedDescription => Origin switch {
        PackOrigin.BuiltIn => Decorated("pack.source.builtin"),
        PackOrigin.Server => Decorated("pack.source.server"),
        PackOrigin.Launch => Decorated("pack.source.launch"),
        _ => Metadata.Description
    };

    private TextComponent Decorated(string source) =>
        TextComponent.Translatable("pack.nameAndSource", with: [Metadata.Description, TextComponent.Translatable(source)]).WithColor(TextColor.Gray);

    /// <summary>The pack's <c>pack.png</c>, or null for the unknown pack icon.</summary>
    public byte[]? Icon() {
        try {
            foreach ((_, PackFiles.IPack pack) in Open()) {
                using (pack) {
                    if (pack.Read("pack.png") is { } png) {
                        return png;
                    }
                }
            }
        }
        catch (Exception e) when (e is IOException or InvalidDataException or UnauthorizedAccessException) {
        }
        return null;
    }
}

/// <summary>
/// <c>PackRepository</c> for client resources, with vanilla's sources: the game's own pack at the bottom,
/// the bundled packs the asset index carries, the packs in the <c>resourcepacks</c> folder and the server's
/// packs on top. Packs given at launch sit fixed just above the game's own, in the order given.
/// </summary>
public sealed class ClientPackRepository(string folder, LaunchOptions options, DownloadedPackSource serverPacks) {
    public const string VanillaId = "vanilla";

    private Dictionary<string, ClientPack> _available = new();
    private List<ClientPack> _selected = [];

    /// <summary>The folder vanilla calls <c>resourcepacks</c>, which the selection screen opens.</summary>
    public string Folder { get; } = folder;

    public IReadOnlyCollection<ClientPack> Available => _available.Values;

    /// <summary>Lowest first.</summary>
    public IReadOnlyList<ClientPack> Selected => _selected;

    public ClientPack? Get(string id) => _available.GetValueOrDefault(id);

    /// <summary><c>reload</c>: finds the packs afresh, keeping what was selected where it is still there.</summary>
    public void Reload() {
        List<string> currentlySelected = _selected.Select(p => p.Id).ToList();
        _available = DiscoverAvailable();
        _selected = RebuildSelected(currentlySelected);
    }

    public void SetSelected(IEnumerable<string> ids) => _selected = RebuildSelected(ids);

    /// <summary>
    /// <c>rebuildSelected</c>: the named packs that exist, in order, then each required pack not among them
    /// put at its end of the list. The available packs are walked in id order, as vanilla's tree map is, so of
    /// the server's packs the last pushed, whose serial is lowest, ends on top.
    /// </summary>
    private List<ClientPack> RebuildSelected(IEnumerable<string> ids) {
        List<ClientPack> selected = ids.Select(id => _available.GetValueOrDefault(id)).OfType<ClientPack>().Distinct().ToList();
        // The game's own pack goes in first so the launch packs, also fixed at the bottom, stack above it.
        foreach (ClientPack pack in _available.Values.OrderBy(p => p.Id != VanillaId).ThenBy(p => p.Id, StringComparer.Ordinal)) {
            if (pack.Required && !selected.Contains(pack)) {
                Insert(selected, pack, pack.DefaultPosition);
            }
        }
        return selected;
    }

    /// <summary><c>Pack.Position.insert</c>: past the fixed packs already holding that end.</summary>
    public static int Insert(List<ClientPack> list, ClientPack value, PackPosition position, bool reverse = false) {
        PackPosition self = reverse ? position == PackPosition.Top ? PackPosition.Bottom : PackPosition.Top : position;
        int index;
        if (self == PackPosition.Bottom) {
            for (index = 0; index < list.Count; index++) {
                if (!list[index].FixedPosition || list[index].DefaultPosition != position) {
                    break;
                }
            }
            list.Insert(index, value);
            return index;
        }
        for (index = list.Count - 1; index >= 0; index--) {
            if (!list[index].FixedPosition || list[index].DefaultPosition != position) {
                break;
            }
        }
        list.Insert(index + 1, value);
        return index + 1;
    }

    private Dictionary<string, ClientPack> DiscoverAvailable() {
        Dictionary<string, ClientPack> found = new();
        void Add(ClientPack? pack) {
            if (pack != null) {
                found[pack.Id] = pack;
            }
        }
        Add(VanillaPack());
        if (options.VanillaAssets is { } assets) {
            Add(BundledPack(assets, "programmer_art", "resourcePack.programmer_art.name"));
            Add(BundledPack(assets, "high_contrast", "resourcePack.high_contrast.name"));
        }
        // Each launch pack is fixed above the last, so their ids sort in the order they were given.
        for (int i = 0; i < options.ResourcePacks.Count; i++) {
            Add(LaunchPack(i, options.ResourcePacks[i]));
        }
        try {
            Directory.CreateDirectory(Folder);
            foreach (string path in Directory.EnumerateFileSystemEntries(Folder)) {
                Add(FolderPack(path));
            }
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException) {
            Console.Error.WriteLine($"Failed to list packs in {Folder}: {e.Message}");
        }
        foreach (ServerResourcePack server in serverPacks.Packs) {
            Add(new ClientPack(server.Id, TextComponent.Translatable("resourcePack.server.name"), server.Metadata, PackOrigin.Server, true, true,
                PackPosition.Top, () => [(server.Id, PackFiles.Open(server.Path, server.Metadata.Overlays))]));
        }
        return found;
    }

    /// <summary>
    /// <c>ClientPackSource.createVanillaPackSource</c>: the game's jar and its asset index, or this client's own
    /// art when it has neither, which opens to no files at all.
    /// </summary>
    private ClientPack VanillaPack() {
        PackMetadata metadata = new(TextComponent.Translatable("resourcePack.vanilla.description"), PackCompatibility.Compatible);
        return new ClientPack(VanillaId, TextComponent.Translatable("resourcePack.vanilla.name"), metadata, PackOrigin.BuiltIn, true, true, PackPosition.Bottom,
            () => {
                // VanillaPackResourcesBuilder.build reverses the order the paths were pushed in, so the asset index
                // pushed after the jar is searched first: the jar's 1x1 panorama placeholders lose to the real ones.
                List<(string, PackFiles.IPack)> packs = [];
                if (options.VanillaJar is { } jar) {
                    packs.Add((Path.GetFileName(jar), PackFiles.Open(jar)));
                }
                if (options.VanillaAssets is { } assets) {
                    packs.Add(("assets", assets));
                }
                return packs;
            });
    }

    /// <summary><c>BuiltInPackSource.discoverPacksInPath</c> over the asset index's <c>resourcepacks</c>, which fetches the zip to read it.</summary>
    private static ClientPack? BundledPack(VanillaAssets assets, string id, string titleKey) {
        if (assets.LocalFile($"assets/minecraft/resourcepacks/{id}.zip") is not { } zip || ReadMetadata(zip) is not { } metadata) {
            return null;
        }
        return new ClientPack(id, TextComponent.Translatable(titleKey), metadata, PackOrigin.BuiltIn, false, false, PackPosition.Top,
            () => [(id, PackFiles.Open(zip, metadata.Overlays))]);
    }

    /// <summary>
    /// A <c>--resource-pack</c> pack. A game jar has no <c>pack.mcmeta</c>, which would leave it out of vanilla's
    /// list; one given at launch is kept whatever it has.
    /// </summary>
    private static ClientPack LaunchPack(int index, string path) {
        string name = Path.GetFileName(Path.TrimEndingDirectorySeparator(path));
        PackMetadata metadata = ReadMetadata(path) ?? new PackMetadata(TextComponent.Text(path), PackCompatibility.Compatible);
        return new ClientPack($"launch/{index:D3}/{name}", TextComponent.Text(name), metadata, PackOrigin.Launch, true, true, PackPosition.Bottom,
            () => [(name, PackFiles.Open(path, metadata.Overlays))]);
    }

    /// <summary><c>FolderRepositorySource</c>: a folder holding a <c>pack.mcmeta</c>, or a <c>.zip</c>, under <c>file/</c> and its file name.</summary>
    private static ClientPack? FolderPack(string path) {
        bool directory = Directory.Exists(path);
        if (directory ? !File.Exists(Path.Combine(path, "pack.mcmeta")) : !path.EndsWith(".zip", StringComparison.Ordinal)) {
            return null;
        }
        if (ReadMetadata(path) is not { } metadata) {
            Console.Error.WriteLine($"Missing or broken metadata in pack {path}");
            return null;
        }
        string name = Path.GetFileName(path);
        return new ClientPack("file/" + name, TextComponent.Text(name), metadata, PackOrigin.Default, false, false, PackPosition.Top,
            () => [(name, PackFiles.Open(path, metadata.Overlays))]);
    }

    private static PackMetadata? ReadMetadata(string path) {
        try {
            using PackFiles.IPack pack = PackFiles.Open(path);
            return PackMetadata.Read(pack.Read("pack.mcmeta"));
        }
        catch (Exception e) when (e is IOException or InvalidDataException or UnauthorizedAccessException) {
            return null;
        }
    }
}

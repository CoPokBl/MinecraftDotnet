using System.Runtime.ExceptionServices;
using ClientLib.Packs;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Gui;

namespace GraphicalClient;

/// <summary>
/// The resource packs everything is drawn and played from, and vanilla's <c>Minecraft.reloadResourcePacks</c>
/// over them: the repository is searched again on the spot, then a <see cref="ResourceReload"/> opens the selection
/// and prepares the language and the window's <see cref="Listeners"/> off the render thread under a
/// <see cref="LoadingOverlay"/>, while the game goes on ticking, sending and drawing.
/// </summary>
public sealed class ClientResources : IDisposable {
    private readonly GameSettings _settings;
    private bool _pendingReload;
    private ResourceReload? _reload;

    public ClientPackRepository Repository { get; }
    public DownloadedPackSource ServerPacks { get; }
    public LanguageManager Languages { get; }
    public PackFiles? Files { get; private set; }

    /// <summary>What the window prepares from a reload's packs and applies, after the language: its sounds and renderer.</summary>
    public Func<IReadOnlyList<ReloadListener>>? Listeners { get; set; }

    /// <summary><c>Screen.init</c>, which the overlay asks for as it starts to fade out.</summary>
    public Action? InitScreen { get; set; }

    /// <summary>The <see cref="LoadingLogo"/> texture the overlay draws, 0 for none.</summary>
    public Func<uint> LogoTexture { get; set; } = () => 0;

    /// <summary>The overlay while a reload shows one, through to the end of its fade out.</summary>
    public LoadingOverlay? Overlay { get; private set; }

    public ClientResources(string dataDirectory, LaunchOptions options, GameSettings settings) {
        _settings = settings;
        ServerPacks = new DownloadedPackSource(Path.Combine(dataDirectory, "downloads"));
        ServerPacks.ReloadResources = RequestReload;
        ServerPacks.Log += message => Console.WriteLine(message);
        Repository = new ClientPackRepository(Path.Combine(dataDirectory, "resourcepacks"), options, ServerPacks);
        Languages = new LanguageManager(settings.Language);
        Repository.Reload();
        LoadSelectedResourcePacks();
        Files = Open();
        Languages.Reload(Files);
    }

    /// <summary>
    /// <c>Options.loadSelectedResourcePacks</c>: the saved selection, dropping packs that are gone and packs whose
    /// format no longer fits unless the player chose them knowing that.
    /// </summary>
    private void LoadSelectedResourcePacks() {
        List<string> selected = [];
        foreach (string id in _settings.ResourcePacks.ToList()) {
            ClientPack? pack = Repository.Get(id);
            if (pack == null && !id.StartsWith("file/", StringComparison.Ordinal)) {
                pack = Repository.Get("file/" + id);
            }
            if (pack == null) {
                Console.WriteLine($"Removed resource pack {id} from options because it doesn't seem to exist anymore");
                _settings.ResourcePacks.Remove(id);
            }
            else if (pack.Metadata.Compatibility != PackCompatibility.Compatible && !_settings.IncompatibleResourcePacks.Contains(id)) {
                Console.WriteLine($"Removed resource pack {id} from options because it is no longer compatible");
                _settings.ResourcePacks.Remove(id);
            }
            else if (pack.Metadata.Compatibility == PackCompatibility.Compatible && _settings.IncompatibleResourcePacks.Remove(id)) {
                // Vanilla leaves it out of this session's selection too, though it stays among the saved packs.
                Console.WriteLine($"Removed resource pack {id} from incompatibility list because it's now compatible");
            }
            else {
                selected.Add(pack.Id);
            }
        }
        Repository.SetSelected(selected.Distinct());
    }

    /// <summary>
    /// <c>Options.updateResourcePacks</c>, as the selection screen commits: the chosen packs that are not fixed in
    /// place are saved, and a change reloads.
    /// </summary>
    public void UpdateResourcePacks() {
        List<string> oldPacks = [.. _settings.ResourcePacks];
        _settings.ResourcePacks.Clear();
        _settings.IncompatibleResourcePacks.Clear();
        foreach (ClientPack pack in Repository.Selected) {
            if (!pack.FixedPosition) {
                _settings.ResourcePacks.Add(pack.Id);
                if (pack.Metadata.Compatibility != PackCompatibility.Compatible) {
                    _settings.IncompatibleResourcePacks.Add(pack.Id);
                }
            }
        }
        _settings.Save();
        if (!_settings.ResourcePacks.SequenceEqual(oldPacks)) {
            RequestReload();
        }
    }

    public void RequestReload() => ReloadResourcePacks(false);

    /// <summary>
    /// <c>Minecraft.reloadResourcePacks</c>. While a reload's overlay is up another is held back, however many
    /// times it is asked for, and starts from <see cref="StartPendingReload"/> once the overlay has gone.
    /// </summary>
    private void ReloadResourcePacks(bool isRecovery) {
        if (_pendingReload) {
            return;
        }
        if (!isRecovery && Overlay != null) {
            _pendingReload = true;
            return;
        }
        Repository.Reload();
        List<ClientPack> selected = [.. Repository.Selected];
        string language = Languages.Selected;
        ReloadListener languages = new(files => Task.Run<object>(() => LanguageManager.Prepare(files, language)),
            prepared => Languages.Apply((LanguageManager.Prepared)prepared));
        ResourceReload reload = new(() => Open(selected), [languages, .. Listeners?.Invoke() ?? []]);
        _reload = reload;
        LoadingOverlay? overlay = null;
        overlay = new LoadingOverlay(reload, failure => OnFinish(reload, failure, isRecovery), !isRecovery, () => {
            if (Overlay == overlay) {
                Overlay = null;
            }
        }, () => InitScreen?.Invoke(), () => LogoTexture());
        Overlay = overlay;
    }

    /// <summary>The start of <c>Minecraft.runTick</c>: a reload held back while the last one's overlay was up.</summary>
    public void StartPendingReload() {
        if (_pendingReload && Overlay == null) {
            _pendingReload = false;
            ReloadResourcePacks(false);
        }
    }

    /// <summary><c>Minecraft.runAllTasks</c> for the reload: its next step on the render thread.</summary>
    public void RunTasks() => _reload?.RunTasks();

    /// <summary>The overlay's <c>onFinish</c>, with the packs the reload opened taking over from the old ones on success.</summary>
    private void OnFinish(ResourceReload reload, Exception? failure, bool isRecovery) {
        if (failure == null) {
            PackFiles? old = Files;
            Files = reload.Packs;
            if (old != Files) {
                old?.Dispose();
            }
            ServerPacks.OnReloadSuccess();
            return;
        }
        if (reload.Applied == 0) {
            reload.Packs?.Dispose();
        }
        if (failure is not (IOException or InvalidDataException or UnauthorizedAccessException or Newtonsoft.Json.JsonException)) {
            ExceptionDispatchInfo.Throw(failure);
        }
        Console.Error.WriteLine($"Caught error loading resourcepacks: {failure.Message}");
        if (isRecovery) {
            ServerPacks.OnRecoveryFailure();
            return;
        }
        // Minecraft.clearResourcePacksOnError: everything the player chose goes, and the reload is tried again.
        ServerPacks.OnRecovery();
        Repository.SetSelected([]);
        _settings.ResourcePacks.Clear();
        _settings.IncompatibleResourcePacks.Clear();
        _settings.Save();
        ReloadResourcePacks(true);
    }

    /// <summary>For the window closing: a reload under way is waited out and what it made dropped, while GL is still there.</summary>
    public void AbandonReload() {
        if (_reload is not { } reload || reload.IsDone && Overlay == null) {
            return;
        }
        reload.Abandon();
        if (reload.Packs != Files) {
            reload.Packs?.Dispose();
        }
        _reload = null;
    }

    /// <summary>
    /// A file from the game's own pack alone, whatever packs sit above it, read when the returned function is called,
    /// which may be on any thread. Null when there is no game pack or it lacks the file.
    /// </summary>
    public Func<byte[]?> VanillaFile(string path) {
        ClientPack? vanilla = Repository.Get(ClientPackRepository.VanillaId);
        return () => {
            if (vanilla == null) {
                return null;
            }
            IReadOnlyList<(string Name, PackFiles.IPack Pack)> packs = vanilla.Open();
            try {
                for (int i = packs.Count - 1; i >= 0; i--) {
                    if (packs[i].Pack.Read(path) is { } data) {
                        return data;
                    }
                }
                return null;
            }
            finally {
                foreach ((_, PackFiles.IPack pack) in packs) {
                    pack.Dispose();
                }
            }
        };
    }

    /// <summary>The selected packs' files, lowest first; null when the selection is the built in art alone.</summary>
    private PackFiles? Open() => Open(Repository.Selected);

    private static PackFiles? Open(IReadOnlyList<ClientPack> selected) {
        List<(string Name, PackFiles.IPack Pack)> packs = [];
        foreach (ClientPack pack in selected) {
            packs.AddRange(pack.Open());
        }
        return packs.Count == 0 ? null : new PackFiles(packs);
    }

    public void Dispose() {
        AbandonReload();
        Files?.Dispose();
        ServerPacks.Dispose();
    }
}

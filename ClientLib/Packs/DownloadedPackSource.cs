using System.Collections.Concurrent;
using System.Globalization;
using System.IO.Compression;
using System.Text.RegularExpressions;
using ClientLib.Multiplayer;
using Minecraft;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Text;

namespace ClientLib.Packs;

/// <summary>A server pack loaded for the resource reload, <c>DownloadedPackSource.loadRequestedPacks</c>' <c>Pack</c>.</summary>
/// <param name="Id"><c>server/%08X/uuid</c>, a fresh serial each reload.</param>
public sealed record ServerResourcePack(string Id, Guid PackId, string Path, PackMetadata Metadata);

/// <summary>
/// <c>DownloadedPackSource</c>: the server's packs from push to applied, with the packets that report each
/// step. The host reloads its resources when <see cref="ReloadResources"/> asks, stacking <see cref="Packs"/>
/// on top of its own, and answers with <see cref="OnReloadSuccess"/>, or <see cref="OnRecovery"/> then
/// <see cref="OnRecoveryFailure"/> when a reload fails.
/// </summary>
public sealed partial class DownloadedPackSource : IDisposable {
    /// <summary>The packet a <see cref="PackUpdate"/> or <see cref="PackFinalResult"/> is reported with, <c>createPackResponseSender</c>.</summary>
    public static ServerBoundResourcePackResponsePacket.PackResponse Response(PackUpdate update) => update switch {
        PackUpdate.Accepted => ServerBoundResourcePackResponsePacket.PackResponse.Accepted,
        _ => ServerBoundResourcePackResponsePacket.PackResponse.Downloaded
    };

    /// <inheritdoc cref="Response(PackUpdate)"/>
    public static ServerBoundResourcePackResponsePacket.PackResponse Response(PackFinalResult result) => result switch {
        PackFinalResult.Applied => ServerBoundResourcePackResponsePacket.PackResponse.SuccessfulDownload,
        PackFinalResult.DownloadFailed => ServerBoundResourcePackResponsePacket.PackResponse.FailedDownload,
        PackFinalResult.Declined => ServerBoundResourcePackResponsePacket.PackResponse.Declined,
        PackFinalResult.Discarded => ServerBoundResourcePackResponsePacket.PackResponse.Discarded,
        _ => ServerBoundResourcePackResponsePacket.PackResponse.FailedToReload
    };

    private const int MaxPackSizeBytes = 262144000;

    [GeneratedRegex("^[a-fA-F0-9]{40}$")]
    private static partial Regex Sha1();

    private sealed class LogOnlyFeedback : IPackLoadFeedback {
        public void ReportUpdate(Guid id, PackUpdate update) {
        }

        public void ReportFinalResult(Guid id, PackFinalResult result) {
        }
    }

    private sealed class ResponseSender(MinecraftClient client) : IPackLoadFeedback {
        public void ReportUpdate(Guid id, PackUpdate update) => client.Send(new ServerBoundResourcePackResponsePacket { PackId = id, Result = Response(update) });

        public void ReportFinalResult(Guid id, PackFinalResult result) =>
            client.Send(new ServerBoundResourcePackResponsePacket { PackId = id, Result = Response(result) });
    }

    private sealed class ForwardingFeedback(DownloadedPackSource source) : IPackLoadFeedback {
        public void ReportUpdate(Guid id, PackUpdate update) {
            source.Log?.Invoke($"Server pack {id}: {update}");
            source._packFeedback.ReportUpdate(id, update);
        }

        public void ReportFinalResult(Guid id, PackFinalResult result) {
            source.Log?.Invoke($"Server pack {id}: {result}");
            source._packFeedback.ReportFinalResult(id, result);
        }
    }

    private static readonly IPackLoadFeedback LogOnly = new LogOnlyFeedback();

    private readonly ConcurrentQueue<Action> _tasks = new();
    private MinecraftClient? _client;
    private readonly string _packCache;
    private PackDownloadQueue? _downloadQueue;
    private readonly ServerPackManager _manager;
    private IPackReloadCallbacks? _pendingReload;
    private IPackLoadFeedback _packFeedback = LogOnly;
    private int _packIdSerialNumber;
    private bool _scheduledInMainExecutor, _hasUpdates;

    /// <summary>The server's packs as of the last reload, lowest first: the order they were pushed in.</summary>
    public IReadOnlyList<ServerResourcePack> Packs { get; private set; } = [];

    /// <summary><c>Minecraft.reloadResourcePacks</c>. Without one, a reload is taken to succeed at once.</summary>
    public Action? ReloadResources { get; set; }

    /// <summary>The download toast's title and message while there is one to show.</summary>
    public (TextComponent Title, TextComponent? Message)? Toast { get; private set; }

    public event Action<string>? Log;

    public DownloadedPackSource(string packCache) {
        _packCache = packCache;
        _manager = new ServerPackManager(Download, new ForwardingFeedback(this), StartReload, RequestUpdate, PackPromptStatus.Pending);
    }

    /// <summary><c>createUpdateScheduler</c>: however many updates are asked for, one task runs <c>tick</c> until none are left.</summary>
    private void RequestUpdate() {
        _hasUpdates = true;
        if (!_scheduledInMainExecutor) {
            _scheduledInMainExecutor = true;
            Schedule(RunAllUpdates);
        }
    }

    /// <summary><c>Minecraft.schedule</c>: the task runs on the game thread when the host next calls <see cref="RunAllTasks"/>.</summary>
    private void Schedule(Action task) => _tasks.Enqueue(task);

    /// <summary><c>Minecraft.runAllTasks</c> for this source's tasks, including tasks they schedule.</summary>
    public void RunAllTasks() {
        while (_tasks.TryDequeue(out Action? task)) {
            task();
        }
    }

    private void RunAllUpdates() {
        while (_hasUpdates) {
            _hasUpdates = false;
            _manager.Tick();
        }
        _scheduledInMainExecutor = false;
    }

    /// <summary><c>createDownloadHeaders</c>, and the <c>Accept</c> that <c>HttpURLConnection</c> adds to every request.</summary>
    private List<(string, string)> DownloadHeaders() => [
        ("X-Minecraft-Username", _client?.Profile.Username ?? ""),
        ("X-Minecraft-UUID", _client?.Profile.Uuid.ToString("N") ?? ""),
        ("X-Minecraft-Version", ProtocolConstants.CurrentVersionString),
        ("X-Minecraft-Version-ID", ProtocolConstants.CurrentVersionString),
        ("X-Minecraft-Pack-Format", PackFormat.Current.ToString()),
        ("User-Agent", "Minecraft Java/" + ProtocolConstants.CurrentVersionString),
        ("Accept", "text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2")
    ];

    private void Download(Dictionary<Guid, PackDownloadRequest> requests, Action<PackBatchResult> output) {
        // Opened at the first download rather than at startup, so a client that is never sent a pack never makes the folder.
        _downloadQueue ??= new PackDownloadQueue(_packCache);
        _downloadQueue.DownloadBatch(MaxPackSizeBytes, DownloadHeaders(), new DownloadNotifier(this, requests.Count), requests)
            .ContinueWith(task => Schedule(() => output(task.Result)), TaskContinuationOptions.OnlyOnRanToCompletion);
    }

    /// <summary><c>createDownloadNotifier</c>: the toast, kept up to date from the download thread.</summary>
    private sealed class DownloadNotifier(DownloadedPackSource source, int totalCount) : IDownloadProgressListener {
        private TextComponent _title = TextComponent.Empty();
        private TextComponent? _message;
        private int _count, _failCount;
        private long? _totalBytes;

        private void UpdateToast() {
            (TextComponent, TextComponent?) toast = (_title, _message);
            source.Schedule(() => source.Toast = toast);
        }

        private void UpdateProgress(long bytesSoFar) {
            _message = _totalBytes is { } total
                ? TextComponent.Translatable("download.pack.progress.percent", with: [(bytesSoFar * 100L / Math.Max(1, total)).ToString(CultureInfo.InvariantCulture)])
                : TextComponent.Translatable("download.pack.progress.bytes", with: [HumanReadable(bytesSoFar)]);
            UpdateToast();
        }

        public void RequestStart() {
            _count++;
            _title = TextComponent.Translatable("download.pack.title", with: [_count.ToString(CultureInfo.InvariantCulture), totalCount.ToString(CultureInfo.InvariantCulture)]);
            UpdateToast();
        }

        public void DownloadStart(long? sizeBytes) {
            _totalBytes = sizeBytes;
            UpdateProgress(0);
        }

        public void DownloadedBytes(long bytesSoFar) => UpdateProgress(bytesSoFar);

        public void RequestFinished(bool success) {
            if (!success) {
                _failCount++;
            }
            if (_count != totalCount) {
                return;
            }
            if (_failCount > 0) {
                _title = TextComponent.Translatable("download.pack.failed",
                    with: [_failCount.ToString(CultureInfo.InvariantCulture), totalCount.ToString(CultureInfo.InvariantCulture)]);
                _message = null;
                UpdateToast();
            }
            else {
                source.Schedule(() => source.Toast = null);
            }
        }

        /// <summary><c>Unit.humanReadable</c>.</summary>
        private static string HumanReadable(long bytes) {
            if (bytes < 1024L) {
                return bytes + " B";
            }
            int exp = (int)(Math.Log(bytes) / Math.Log(1024.0));
            return (bytes / Math.Pow(1024.0, exp)).ToString("F1", CultureInfo.InvariantCulture) + " " + "KMGTPE"[exp - 1] + "B";
        }
    }

    /// <summary><c>loadRequestedPacks</c>: null when any pack's metadata does not read, which fails the whole set.</summary>
    private List<ServerResourcePack>? LoadRequestedPacks(IReadOnlyList<(Guid Id, string Path)> packsToLoad) {
        List<ServerResourcePack> packs = new(packsToLoad.Count);
        foreach ((Guid id, string path) in packsToLoad.Reverse()) {
            string name = string.Format(CultureInfo.InvariantCulture, "server/{0:X8}/{1}", _packIdSerialNumber++, id);
            if (ReadMetadata(path) is not { } metadata) {
                Log?.Invoke($"Invalid pack metadata in {path}, ignoring all");
                return null;
            }
            packs.Add(new ServerResourcePack(name, id, path, metadata));
        }
        // Each is inserted at the top below those already there, so the stack ends up in push order.
        packs.Reverse();
        return packs;
    }

    private static PackMetadata? ReadMetadata(string zip) {
        try {
            using ZipArchive archive = ZipFile.OpenRead(zip);
            if (archive.GetEntry("pack.mcmeta") is not { } entry) {
                return null;
            }
            using Stream stream = entry.Open();
            using MemoryStream memory = new();
            stream.CopyTo(memory);
            return PackMetadata.Read(memory.ToArray());
        }
        catch (Exception e) when (e is IOException or InvalidDataException or UnauthorizedAccessException) {
            return null;
        }
    }

    private void StartReload(IPackReloadCallbacks callbacks) {
        _pendingReload = callbacks;
        List<ServerResourcePack>? packs = LoadRequestedPacks(callbacks.PacksToLoad());
        if (packs == null) {
            callbacks.OnFailure(false);
            packs = LoadRequestedPacks(callbacks.PacksToLoad());
            if (packs == null) {
                Log?.Invoke("Double failure in loading server packs");
                packs = [];
            }
        }
        Packs = packs;
        if (ReloadResources is { } reload) {
            reload();
        }
        else {
            Schedule(OnReloadSuccess);
        }
    }

    /// <summary><c>onRecovery</c>: the reload failed and is being retried without the user's packs.</summary>
    public void OnRecovery() {
        if (_pendingReload != null) {
            _pendingReload.OnFailure(false);
            List<ServerResourcePack>? packs = LoadRequestedPacks(_pendingReload.PacksToLoad());
            if (packs == null) {
                Log?.Invoke("Double failure in loading server packs");
                packs = [];
            }
            Packs = packs;
        }
    }

    public void OnRecoveryFailure() {
        if (_pendingReload != null) {
            _pendingReload.OnFailure(true);
            _pendingReload = null;
            Packs = [];
        }
    }

    public void OnReloadSuccess() {
        if (_pendingReload != null) {
            _pendingReload.OnSuccess();
            _pendingReload = null;
        }
    }

    /// <summary>
    /// <c>pushPack</c>, after <c>handleResourcePackPush</c> has parsed the URL. A hash that is not 40 hex digits
    /// is ignored, so the download is kept under whatever hash it has.
    /// </summary>
    public void PushPack(Guid id, Uri url, string? hash) =>
        _manager.PushPack(id, url, hash != null && Sha1().IsMatch(hash) ? hash.ToLowerInvariant() : null);

    public void PopPack(Guid id) => _manager.PopPack(id);

    public void PopAll() => _manager.PopAll();

    /// <summary><c>configureForServerControl</c>, as <c>ConnectScreen</c> calls it once the connection is open.</summary>
    public void ConfigureForServerControl(MinecraftClient client, ServerPackStatus status) {
        _client = client;
        _packFeedback = new ResponseSender(client);
        switch (status) {
            case ServerPackStatus.Enabled:
                _manager.AllowServerPacks();
                break;
            case ServerPackStatus.Disabled:
                _manager.RejectServerPacks();
                break;
            case ServerPackStatus.Prompt:
                _manager.ResetPromptStatus();
                break;
        }
    }

    public void AllowServerPacks() => _manager.AllowServerPacks();

    public void RejectServerPacks() => _manager.RejectServerPacks();

    public void CleanupAfterDisconnect() {
        _manager.PopAll();
        _packFeedback = LogOnly;
        _manager.ResetPromptStatus();
    }

    public void Dispose() => _downloadQueue?.Dispose();
}

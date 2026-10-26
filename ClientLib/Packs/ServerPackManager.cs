namespace ClientLib.Packs;

/// <summary><c>ServerPackManager.PackPromptStatus</c>.</summary>
public enum PackPromptStatus {
    Pending,
    Allowed,
    Declined
}

/// <summary><c>PackLoadFeedback.Update</c>.</summary>
public enum PackUpdate {
    Accepted,
    Downloaded
}

/// <summary><c>PackLoadFeedback.FinalResult</c>.</summary>
public enum PackFinalResult {
    Declined,
    Applied,
    Discarded,
    DownloadFailed,
    ActivationFailed
}

/// <summary><c>PackLoadFeedback</c>.</summary>
public interface IPackLoadFeedback {
    void ReportUpdate(Guid id, PackUpdate update);

    void ReportFinalResult(Guid id, PackFinalResult result);
}

/// <summary><c>PackReloadConfig.Callbacks</c>.</summary>
public interface IPackReloadCallbacks {
    void OnSuccess();

    void OnFailure(bool isRecovery);

    /// <summary>The packs to stack, in the order the server pushed them.</summary>
    IReadOnlyList<(Guid Id, string Path)> PacksToLoad();
}

/// <summary><c>DownloadQueue.DownloadRequest</c>: the hash is lower case hex, or null when the server gave none that parses.</summary>
public sealed record PackDownloadRequest(Uri Url, string? Hash);

/// <summary><c>DownloadQueue.BatchResult</c>.</summary>
public sealed class PackBatchResult {
    public Dictionary<Guid, string> Downloaded { get; } = new();
    public HashSet<Guid> Failed { get; } = [];
}

/// <summary>
/// <c>ServerPackManager</c>: the server's packs, what the player said about them, and which are downloaded
/// and active. Everything runs on the game thread; <c>tick</c> runs whenever <c>updateRequest</c> asks.
/// </summary>
public sealed class ServerPackManager(
    Action<Dictionary<Guid, PackDownloadRequest>, Action<PackBatchResult>> downloader,
    IPackLoadFeedback packLoadFeedback,
    Action<IPackReloadCallbacks> scheduleReload,
    Action updateRequest,
    PackPromptStatus packPromptStatus) {
    private PackPromptStatus _packPromptStatus = packPromptStatus;
    private readonly List<ServerPackData> _packs = [];

    private enum ActivationStatus {
        Inactive,
        Pending,
        Active
    }

    private enum PackDownloadStatus {
        Requested,
        Pending,
        Done
    }

    private enum RemovalReason {
        DownloadFailed,
        ActivationFailed,
        Declined,
        Discarded,
        ServerRemoved,
        ServerReplaced
    }

    private static PackFinalResult? ServerResponse(RemovalReason reason) => reason switch {
        RemovalReason.DownloadFailed => PackFinalResult.DownloadFailed,
        RemovalReason.ActivationFailed => PackFinalResult.ActivationFailed,
        RemovalReason.Declined => PackFinalResult.Declined,
        RemovalReason.Discarded => PackFinalResult.Discarded,
        _ => null
    };

    private sealed class ServerPackData(Guid id, Uri url, string? hash) {
        public readonly Guid Id = id;
        public readonly Uri Url = url;
        public readonly string? Hash = hash;
        public string? Path;
        public RemovalReason? RemovalReason;
        public PackDownloadStatus DownloadStatus = PackDownloadStatus.Requested;
        public ActivationStatus ActivationStatus = ActivationStatus.Inactive;
        public bool PromptAccepted;

        public void SetRemovalReasonIfNotSet(RemovalReason reason) => RemovalReason ??= reason;

        public bool IsRemoved => RemovalReason != null;
    }

    private void RegisterForUpdate() => updateRequest();

    private void ReportApplied(Guid id) => packLoadFeedback.ReportFinalResult(id, PackFinalResult.Applied);

    private void MarkExistingPacksAsRemoved(Guid id) {
        foreach (ServerPackData pack in _packs) {
            if (pack.Id == id) {
                pack.SetRemovalReasonIfNotSet(RemovalReason.ServerReplaced);
            }
        }
    }

    public void PushPack(Guid id, Uri url, string? hash) {
        if (_packPromptStatus == PackPromptStatus.Declined) {
            packLoadFeedback.ReportFinalResult(id, PackFinalResult.Declined);
        }
        else {
            PushNewPack(id, new ServerPackData(id, url, hash));
        }
    }

    private void PushNewPack(Guid id, ServerPackData pack) {
        MarkExistingPacksAsRemoved(id);
        _packs.Add(pack);
        if (_packPromptStatus == PackPromptStatus.Allowed) {
            AcceptPack(pack);
        }
        RegisterForUpdate();
    }

    private void AcceptPack(ServerPackData pack) {
        packLoadFeedback.ReportUpdate(pack.Id, PackUpdate.Accepted);
        pack.PromptAccepted = true;
    }

    private ServerPackData? FindPackInfo(Guid id) {
        foreach (ServerPackData pack in _packs) {
            if (!pack.IsRemoved && pack.Id == id) {
                return pack;
            }
        }
        return null;
    }

    public void PopPack(Guid id) {
        if (FindPackInfo(id) is { } packInfo) {
            packInfo.SetRemovalReasonIfNotSet(RemovalReason.ServerRemoved);
            RegisterForUpdate();
        }
    }

    public void PopAll() {
        foreach (ServerPackData pack in _packs) {
            pack.SetRemovalReasonIfNotSet(RemovalReason.ServerRemoved);
        }
        RegisterForUpdate();
    }

    public void AllowServerPacks() {
        _packPromptStatus = PackPromptStatus.Allowed;
        foreach (ServerPackData pack in _packs) {
            if (!pack.PromptAccepted && !pack.IsRemoved) {
                AcceptPack(pack);
            }
        }
        RegisterForUpdate();
    }

    public void RejectServerPacks() {
        _packPromptStatus = PackPromptStatus.Declined;
        foreach (ServerPackData pack in _packs) {
            if (!pack.PromptAccepted) {
                pack.SetRemovalReasonIfNotSet(RemovalReason.Declined);
            }
        }
        RegisterForUpdate();
    }

    public void ResetPromptStatus() => _packPromptStatus = PackPromptStatus.Pending;

    public void Tick() {
        bool downloadsPending = UpdateDownloads();
        if (!downloadsPending) {
            TriggerReloadIfNeeded();
        }
        CleanupRemovedPacks();
    }

    private void CleanupRemovedPacks() {
        _packs.RemoveAll(data => {
            if (data.ActivationStatus != ActivationStatus.Inactive) {
                return false;
            }
            if (data.RemovalReason is { } reason) {
                if (ServerResponse(reason) is { } response) {
                    packLoadFeedback.ReportFinalResult(data.Id, response);
                }
                return true;
            }
            return false;
        });
    }

    private void OnDownload(List<ServerPackData> data, PackBatchResult result) {
        if (result.Failed.Count > 0) {
            foreach (ServerPackData pack in _packs) {
                if (pack.ActivationStatus != ActivationStatus.Active) {
                    pack.SetRemovalReasonIfNotSet(result.Failed.Contains(pack.Id) ? RemovalReason.DownloadFailed : RemovalReason.Discarded);
                }
            }
        }

        foreach (ServerPackData pack in data) {
            if (result.Downloaded.TryGetValue(pack.Id, out string? packFile)) {
                pack.DownloadStatus = PackDownloadStatus.Done;
                pack.Path = packFile;
                if (!pack.IsRemoved) {
                    packLoadFeedback.ReportUpdate(pack.Id, PackUpdate.Downloaded);
                }
            }
        }
        RegisterForUpdate();
    }

    private bool UpdateDownloads() {
        List<ServerPackData> downloadPacks = [];
        bool downloadsInProgress = false;
        foreach (ServerPackData pack in _packs) {
            if (!pack.IsRemoved && pack.PromptAccepted) {
                if (pack.DownloadStatus != PackDownloadStatus.Done) {
                    downloadsInProgress = true;
                }
                if (pack.DownloadStatus == PackDownloadStatus.Requested) {
                    pack.DownloadStatus = PackDownloadStatus.Pending;
                    downloadPacks.Add(pack);
                }
            }
        }

        if (downloadPacks.Count > 0) {
            Dictionary<Guid, PackDownloadRequest> downloadRequests = new();
            foreach (ServerPackData pack in downloadPacks) {
                downloadRequests[pack.Id] = new PackDownloadRequest(pack.Url, pack.Hash);
            }
            downloader(downloadRequests, result => OnDownload(downloadPacks, result));
        }
        return downloadsInProgress;
    }

    private void TriggerReloadIfNeeded() {
        bool needsReload = false;
        List<ServerPackData> packsToLoad = [];
        List<ServerPackData> packsToUnload = [];
        foreach (ServerPackData pack in _packs) {
            if (pack.ActivationStatus == ActivationStatus.Pending) {
                return;
            }
            bool shouldBeActive = pack.PromptAccepted && pack.DownloadStatus == PackDownloadStatus.Done && !pack.IsRemoved;
            if (shouldBeActive && pack.ActivationStatus == ActivationStatus.Inactive) {
                packsToLoad.Add(pack);
                needsReload = true;
            }
            if (pack.ActivationStatus == ActivationStatus.Active) {
                if (!shouldBeActive) {
                    needsReload = true;
                    packsToUnload.Add(pack);
                }
                else {
                    packsToLoad.Add(pack);
                }
            }
        }

        if (!needsReload) {
            return;
        }
        foreach (ServerPackData pack in packsToLoad) {
            if (pack.ActivationStatus != ActivationStatus.Active) {
                pack.ActivationStatus = ActivationStatus.Pending;
            }
        }
        foreach (ServerPackData pack in packsToUnload) {
            pack.ActivationStatus = ActivationStatus.Pending;
        }
        scheduleReload(new ReloadCallbacks(this, packsToLoad, packsToUnload));
    }

    private sealed class ReloadCallbacks(ServerPackManager manager, List<ServerPackData> packsToLoad, List<ServerPackData> packsToUnload) : IPackReloadCallbacks {
        public void OnSuccess() {
            foreach (ServerPackData pack in packsToLoad) {
                pack.ActivationStatus = ActivationStatus.Active;
                if (pack.RemovalReason == null) {
                    manager.ReportApplied(pack.Id);
                }
            }
            foreach (ServerPackData pack in packsToUnload) {
                pack.ActivationStatus = ActivationStatus.Inactive;
            }
            manager.RegisterForUpdate();
        }

        public void OnFailure(bool isRecovery) {
            if (!isRecovery) {
                packsToLoad.Clear();
                foreach (ServerPackData pack in manager._packs) {
                    switch (pack.ActivationStatus) {
                        case ActivationStatus.Inactive:
                            pack.SetRemovalReasonIfNotSet(RemovalReason.Discarded);
                            break;
                        case ActivationStatus.Pending:
                            pack.ActivationStatus = ActivationStatus.Inactive;
                            pack.SetRemovalReasonIfNotSet(RemovalReason.ActivationFailed);
                            break;
                        case ActivationStatus.Active:
                            packsToLoad.Add(pack);
                            break;
                    }
                }
                manager.RegisterForUpdate();
            }
            else {
                foreach (ServerPackData pack in manager._packs) {
                    if (pack.ActivationStatus == ActivationStatus.Pending) {
                        pack.ActivationStatus = ActivationStatus.Inactive;
                    }
                }
            }
        }

        public IReadOnlyList<(Guid Id, string Path)> PacksToLoad() => packsToLoad.Select(pack => (pack.Id, pack.Path!)).ToList();
    }
}

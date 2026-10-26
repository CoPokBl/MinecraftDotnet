using GraphicalClient.Assets.ResourcePacks;

namespace GraphicalClient;

/// <summary>
/// <c>PreparableReloadListener</c>'s two halves. <see cref="Prepare"/> runs off the render thread on the opened
/// packs and must change nothing in use; <see cref="Apply"/> puts its result in use on the render thread. A
/// result that is never applied, because another listener failed or the window closed, goes to <see cref="Discard"/>.
/// </summary>
public sealed record ReloadListener(Func<PackFiles?, Task<object>> Prepare, Action<object> Apply, Action<object>? Discard = null);

/// <summary>
/// <c>SimpleReloadInstance</c>: the packs are opened and every listener prepares off the render thread, and only
/// once all have does each apply, in listener order, on the render thread, one a frame from <see cref="RunTasks"/>,
/// so the old resources stay in use until their replacements are whole. A failed preparation fails the reload with
/// nothing applied, as vanilla's barrier never opens for it.
/// </summary>
public sealed class ResourceReload {
    private readonly ReloadListener[] _listeners;
    private readonly Task<PackFiles?> _packs;
    private readonly Task<object>[] _prepared;
    private int _startedTasks, _finishedTasks, _startedApplies;

    /// <summary>Listeners whose result has been put in use.</summary>
    public int Applied { get; private set; }

    public bool IsDone { get; private set; }

    /// <summary>Why the reload failed, once <see cref="IsDone"/>; null when it did not.</summary>
    public Exception? Failure { get; private set; }

    /// <summary>The packs the reload opened, once it has.</summary>
    public PackFiles? Packs => _packs.IsCompletedSuccessfully ? _packs.Result : null;

    public ResourceReload(Func<PackFiles?> openPacks, IReadOnlyList<ReloadListener> listeners) {
        _listeners = [.. listeners];
        _packs = Track(Task.Run(openPacks));
        _prepared = _listeners.Select(listener => Track(Prepare(listener))).ToArray();
    }

    private async Task<object> Prepare(ReloadListener listener) => await listener.Prepare(await _packs);

    private Task<T> Track<T>(Task<T> task) {
        Interlocked.Increment(ref _startedTasks);
        task.ContinueWith(_ => Interlocked.Increment(ref _finishedTasks), TaskContinuationOptions.ExecuteSynchronously);
        return task;
    }

    /// <summary><c>getActualProgress</c>, by vanilla's weights: two for each task and each apply, one for each listener prepared.</summary>
    public float Progress {
        get {
            int prepared = _prepared.Count(task => task.IsCompleted);
            float done = Volatile.Read(ref _finishedTasks) * 2 + Applied * 2 + prepared;
            float total = Volatile.Read(ref _startedTasks) * 2 + _startedApplies * 2 + _listeners.Length;
            return done / total;
        }
    }

    /// <summary>The render thread's part, once a frame: the next apply, once every preparation is in.</summary>
    public void RunTasks() {
        if (IsDone) {
            return;
        }
        if (_startedApplies == 0) {
            if (!_prepared.All(task => task.IsCompleted)) {
                return;
            }
            if (_prepared.FirstOrDefault(task => !task.IsCompletedSuccessfully) is { } failed) {
                Fail(failed.Exception?.InnerException ?? new OperationCanceledException(), 0);
                return;
            }
            _startedApplies = _listeners.Length;
        }
        if (Applied < _listeners.Length) {
            try {
                _listeners[Applied].Apply(_prepared[Applied].Result);
            }
            catch (Exception e) {
                Fail(e, Applied + 1);
                return;
            }
            Applied++;
        }
        IsDone = Applied == _listeners.Length;
    }

    private void Fail(Exception failure, int firstUnapplied) {
        Failure = failure;
        IsDone = true;
        Discard(firstUnapplied);
    }

    private void Discard(int from) {
        for (int i = from; i < _listeners.Length; i++) {
            if (_prepared[i].IsCompletedSuccessfully) {
                _listeners[i].Discard?.Invoke(_prepared[i].Result);
            }
        }
    }

    /// <summary>For a window closing mid reload: waits out the preparations, which may hold a GL context, and drops what they made.</summary>
    public void Abandon() {
        if (IsDone) {
            return;
        }
        try {
            Task.WaitAll(_prepared);
        }
        catch (AggregateException) {
            // Failed preparations have nothing to drop.
        }
        IsDone = true;
        Discard(Applied);
    }
}

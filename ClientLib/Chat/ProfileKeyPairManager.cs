using ClientLib.Profiles;

namespace ClientLib.Chat;

/// <summary>
/// <c>ProfileKeyPairManager</c>: the chat key pair, fetched off the game thread. Vanilla's account manager
/// also keeps the pair in a file, but only while running in a development environment; elsewhere it
/// deletes that file, so every launch fetches afresh, which is what this does.
/// </summary>
public abstract class ProfileKeyPairManager {
    /// <summary><c>EMPTY_KEY_MANAGER</c>, for a player with no account to sign with.</summary>
    public static readonly ProfileKeyPairManager Empty = new EmptyManager();

    public abstract Task<ProfileKeyPair?> PrepareKeyPair();

    public abstract bool ShouldRefreshKeyPair();

    private sealed class EmptyManager : ProfileKeyPairManager {
        public override Task<ProfileKeyPair?> PrepareKeyPair() => Task.FromResult<ProfileKeyPair?>(null);

        public override bool ShouldRefreshKeyPair() => false;
    }
}

/// <summary><c>AccountProfileKeyPairManager</c>.</summary>
public sealed class AccountProfileKeyPairManager(UserApiService userApiService, Action<string>? log = null) : ProfileKeyPairManager {
    private static readonly TimeSpan MinimumProfileKeyRefreshInterval = TimeSpan.FromHours(1);

    private Task<ProfileKeyPair?> _keyPair = Task.FromResult<ProfileKeyPair?>(null);
    private DateTimeOffset _nextProfileKeyRefreshTime = DateTimeOffset.UnixEpoch;

    public override Task<ProfileKeyPair?> PrepareKeyPair() {
        _nextProfileKeyRefreshTime = DateTimeOffset.UtcNow + MinimumProfileKeyRefreshInterval;
        Task<ProfileKeyPair?> previous = _keyPair;
        _keyPair = Task.Run(async () => await ReadOrFetchProfileKeyPair(await previous));
        return _keyPair;
    }

    public override bool ShouldRefreshKeyPair() =>
        _keyPair.IsCompleted && DateTimeOffset.UtcNow > _nextProfileKeyRefreshTime && (_keyPair.Result?.DueRefresh ?? true);

    private async Task<ProfileKeyPair?> ReadOrFetchProfileKeyPair(ProfileKeyPair? cachedKeyPair) {
        if (cachedKeyPair is { DueRefresh: false }) {
            return cachedKeyPair;
        }
        try {
            return await userApiService.GetKeyPair();
        }
        catch (Exception e) when (e is HttpRequestException or TaskCanceledException or System.Security.Cryptography.CryptographicException
                                       or Newtonsoft.Json.JsonException) {
            log?.Invoke($"Failed to retrieve profile key pair: {e.Message}");
            return cachedKeyPair;
        }
    }
}

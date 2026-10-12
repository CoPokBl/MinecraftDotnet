using System.Collections.Concurrent;
using System.Security.Cryptography;
using Minecraft;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// The game's assets that are not in the client jar, sounds above all, for <c>--vanilla-pack</c>. The
/// launcher keeps these as content addressed objects listed by an asset index; this downloads the same
/// way, into the same layout, on the user's machine. Nothing from it ships with this client.
/// <para>
/// The index and <c>sounds.json</c> are fetched before the game starts. The sounds themselves are
/// fetched in the background, everything but music straight away and music when it is first wanted,
/// so a sound asked for before its file has arrived is silent that once rather than holding the game up.
/// </para>
/// </summary>
public sealed class VanillaAssets : PackFiles.IPack {
    /// <summary>The asset indexes this build knows, by version, which is all the protocol needs.</summary>
    private static readonly IReadOnlyDictionary<string, string> IndexUrls = new Dictionary<string, string> {
        ["26.2"] = "https://piston-meta.mojang.com/v1/packages/72b2ca7f98a3af7c84ac7c47a3292faea80280c5/32.json"
    };

    private const string ObjectUrl = "https://resources.download.minecraft.net/";

    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromMinutes(5) };

    private readonly string _objects;
    private readonly Dictionary<string, (string Hash, long Size)> _index;
    private readonly ConcurrentDictionary<string, Task> _downloads = new();
    private readonly SemaphoreSlim _parallel = new(8);

    private static readonly string CacheDirectory = VanillaClientJar.Cache("assets");

    private VanillaAssets(string objects, Dictionary<string, (string, long)> index) {
        _objects = objects;
        _index = index;
    }

    /// <summary>Fetches the index and <c>sounds.json</c> if they are not cached, then starts on the sounds.</summary>
    public static async Task<VanillaAssets> Get(CancellationToken cancellation = default) {
        string version = ProtocolConstants.CurrentVersionString;
        if (!IndexUrls.TryGetValue(version, out string? url)) {
            throw new InvalidOperationException($"No asset index URL is known for {version}.");
        }
        string expected = url.Split('/')[^2];
        string indexPath = Path.Combine(CacheDirectory, "indexes", url.Split('/')[^1]);
        Directory.CreateDirectory(Path.GetDirectoryName(indexPath)!);
        if (!File.Exists(indexPath) || Sha1(await File.ReadAllBytesAsync(indexPath, cancellation)) != expected) {
            byte[] data = await Http.GetByteArrayAsync(url, cancellation);
            if (Sha1(data) != expected) {
                throw new InvalidOperationException($"The asset index from {url} does not have the SHA-1 that URL names.");
            }
            await File.WriteAllBytesAsync(indexPath, data, cancellation);
        }

        Dictionary<string, (string, long)> index = new(StringComparer.Ordinal);
        foreach ((string name, JToken? entry) in (JObject)JObject.Parse(await File.ReadAllTextAsync(indexPath, cancellation))["objects"]!) {
            index[name] = (entry!.Value<string>("hash")!, entry.Value<long>("size"));
        }
        VanillaAssets assets = new(Path.Combine(CacheDirectory, "objects"), index);
        if (index.ContainsKey("minecraft/sounds.json")) {
            await assets.Fetch("minecraft/sounds.json", cancellation);
        }
        assets.PrefetchSounds();
        return assets;
    }

    private static string Sha1(byte[] data) => Convert.ToHexStringLower(SHA1.HashData(data));

    private string ObjectPath(string hash) => Path.Combine(_objects, hash[..2], hash);

    /// <summary>Pack paths are <c>assets/minecraft/...</c>; the index names the same files <c>minecraft/...</c>.</summary>
    private static string? IndexName(string path) => path.StartsWith("assets/", StringComparison.Ordinal) ? path["assets/".Length..] : null;

    /// <summary>Every sound but music and records, which are most of the bytes and wait until they are played.</summary>
    private void PrefetchSounds() {
        List<string> wanted = _index.Keys
            .Where(name => name.StartsWith("minecraft/sounds/", StringComparison.Ordinal)
                           && !name.StartsWith("minecraft/sounds/music/", StringComparison.Ordinal)
                           && !name.StartsWith("minecraft/sounds/records/", StringComparison.Ordinal)
                           && !File.Exists(ObjectPath(_index[name].Hash)))
            .ToList();
        if (wanted.Count == 0) {
            return;
        }
        Console.WriteLine($"Fetching {wanted.Count} vanilla sounds in the background ({wanted.Sum(n => _index[n].Size) >> 20} MiB), into {CacheDirectory}.");
        _ = Task.Run(async () => {
            await Task.WhenAll(wanted.Select(name => Fetch(name, CancellationToken.None)));
            Console.WriteLine("Vanilla sounds fetched.");
        });
    }

    private Task Fetch(string name, CancellationToken cancellation) {
        return _downloads.GetOrAdd(name, key => Task.Run(async () => {
            (string hash, long _) = _index[name];
            string path = ObjectPath(hash);
            if (File.Exists(path)) {
                return;
            }
            await _parallel.WaitAsync(cancellation);
            try {
                byte[] data = await Http.GetByteArrayAsync($"{ObjectUrl}{hash[..2]}/{hash}", cancellation);
                if (Sha1(data) != hash) {
                    throw new InvalidOperationException($"{name} arrived with the wrong SHA-1.");
                }
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                string temporary = VanillaClientJar.TemporaryFor(path);
                await File.WriteAllBytesAsync(temporary, data, cancellation);
                File.Move(temporary, path, overwrite: true);
            }
            catch (Exception e) when (e is HttpRequestException or IOException or InvalidOperationException or TaskCanceledException) {
                Console.Error.WriteLine($"Could not fetch {name}: {e.Message}");
                // Forgotten, so a later request tries again.
                _downloads.TryRemove(name, out _);
            }
            finally {
                _parallel.Release();
            }
        }, cancellation));
    }

    /// <summary>The file if it has arrived; otherwise null, and it is asked for.</summary>
    public byte[]? Read(string path) {
        if (IndexName(path) is not { } name || !_index.TryGetValue(name, out (string Hash, long Size) entry)) {
            return null;
        }
        string file = ObjectPath(entry.Hash);
        if (File.Exists(file)) {
            try {
                return File.ReadAllBytes(file);
            }
            catch (IOException) {
                return null;
            }
        }
        _ = Fetch(name, CancellationToken.None);
        return null;
    }

    public bool Exists(string path) => IndexName(path) is { } name && _index.ContainsKey(name);

    public IEnumerable<string> Paths(string prefix) =>
        IndexName(prefix) is { } name ? _index.Keys.Where(k => k.StartsWith(name, StringComparison.Ordinal)).Select(k => "assets/" + k) : [];

    public void Dispose() { }
}

using System.Security.Cryptography;
using Minecraft;

namespace ManagedServer.Terrain.Data;

/// <summary>
/// Fetches a vanilla server jar and hands it back as a datapack.
/// </summary>
/// <remarks>
/// <b>Nothing here is shipped and nothing runs on its own.</b> The jar is Mojang's, so it is not in
/// this repository or in the package; a consumer who wants vanilla worldgen calls this and their own
/// machine fetches their own copy, once, to a directory they name.
/// <p/>
/// Mojang's object URLs are content addressed, so the SHA-1 of the file is the path segment it was
/// downloaded from. That makes verification free and is why <see cref="Download"/> can promise the
/// bytes are what the URL claims rather than merely that something arrived.
/// </remarks>
public static class VanillaDatapack {
    /// <summary>
    /// The versions this build knows a jar for.
    /// </summary>
    /// <remarks>
    /// A URL rather than a lookup against the launcher manifest, so no network call is needed to find
    /// out that a version is unknown. The one this build targets is
    /// <see cref="ProtocolConstants.CurrentVersionString"/>; the rest are here because the conformance
    /// harnesses and a consumer pinning an older protocol both want them.
    /// </remarks>
    public static readonly IReadOnlyDictionary<string, string> JarUrls = new Dictionary<string, string> {
        ["1.21.5"] = "https://piston-data.mojang.com/v1/objects/e6ec2f64e6080b9b5d9b471b291c33cc7f509733/server.jar",
        ["1.21.6"] = "https://piston-data.mojang.com/v1/objects/6e64dcabba3c01a7271b4fa6bd898483b794c59b/server.jar",
        ["1.21.7"] = "https://piston-data.mojang.com/v1/objects/05e4b48fbc01f0385adb74bcff9751d34552486c/server.jar",
        ["1.21.10"] = "https://piston-data.mojang.com/v1/objects/95495a7f485eedd84ce928cef5e223b757d2f764/server.jar",
        ["1.21.11"] = "https://piston-data.mojang.com/v1/objects/64bb6d763bed0a9f1d632ec347938594144943ed/server.jar",
        ["26.2"] = "https://piston-data.mojang.com/v1/objects/823e2250d24b3ddac457a60c92a6a941943fcd6a/server.jar"
    };

    /// <summary>Where a jar is cached when no directory is named.</summary>
    /// <remarks>
    /// Under the user's local application data rather than beside the assembly, so several projects on
    /// one machine share a download and a published application does not write into its own directory.
    /// </remarks>
    public static string DefaultCacheDirectory {
        get => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MinecraftDotnet", "jars");
    }

    /// <summary>
    /// The jar for a version, downloaded if it is not already cached, as a datapack.
    /// </summary>
    /// <remarks>
    /// Verified against the SHA-1 in its own URL, on the way in and again when a cached file is reused,
    /// so a truncated download is a failure here rather than a missing density function later.
    /// </remarks>
    public static async Task<IDatapackSource> Download(string? version = null,
        string? cacheDirectory = null, CancellationToken cancellation = default) {

        version ??= ProtocolConstants.CurrentVersionString;

        if (!JarUrls.TryGetValue(version, out string? url)) {
            throw new ArgumentException(
                $"No server jar URL for \"{version}\". Known versions: "
                + string.Join(", ", JarUrls.Keys.Order(StringComparer.Ordinal)) + ".",
                nameof(version));
        }

        string directory = cacheDirectory ?? DefaultCacheDirectory;
        Directory.CreateDirectory(directory);

        string path = Path.Combine(directory, $"server-{version}.jar");
        string expected = ExpectedHash(url);

        if (!File.Exists(path) || !await Matches(path, expected, cancellation)) {
            await Fetch(url, path, expected, cancellation);
        }

        return new ZipDatapack(path);
    }

    /// <summary>
    /// The cached jar for a version without going near the network, or null if it is not there.
    /// </summary>
    /// <remarks>
    /// For a caller that wants to decide for itself whether downloading is acceptable, a test run
    /// among them.
    /// </remarks>
    public static IDatapackSource? Cached(string? version = null, string? cacheDirectory = null) {
        version ??= ProtocolConstants.CurrentVersionString;
        string path = Path.Combine(cacheDirectory ?? DefaultCacheDirectory, $"server-{version}.jar");

        return File.Exists(path) ? new ZipDatapack(path) : null;
    }

    /// <summary>The SHA-1 in a content addressed object URL, which is the segment before the name.</summary>
    private static string ExpectedHash(string url) {
        string[] parts = url.Split('/');
        return parts[^2];
    }

    private static async Task<bool> Matches(string path, string expected,
        CancellationToken cancellation) {

        await using FileStream file = File.OpenRead(path);
        byte[] hash = await SHA1.HashDataAsync(file, cancellation);

        return Convert.ToHexStringLower(hash) == expected;
    }

    /// <summary>
    /// Downloads to a temporary file and moves it into place once it has been verified.
    /// </summary>
    /// <remarks>
    /// Two processes fetching at once is the normal case for a test run, so the destination is only
    /// ever a completed file: a half written jar under the cache name would be read by the other
    /// process as a datapack with most of the world missing.
    /// </remarks>
    private static async Task Fetch(string url, string path, string expected,
        CancellationToken cancellation) {

        string temporary = path + "." + Guid.NewGuid().ToString("N") + ".part";

        try {
            using HttpClient client = new() { Timeout = TimeSpan.FromMinutes(10) };

            await using (Stream response = await client.GetStreamAsync(url, cancellation))
            await using (FileStream target = File.Create(temporary)) {
                await response.CopyToAsync(target, cancellation);
            }

            if (!await Matches(temporary, expected, cancellation)) {
                throw new InvalidOperationException(
                    $"The jar downloaded from {url} does not have the SHA-1 that URL names.");
            }

            File.Move(temporary, path, overwrite: true);
        } finally {
            if (File.Exists(temporary)) {
                File.Delete(temporary);
            }
        }
    }
}

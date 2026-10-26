using System.Security.Cryptography;
using Minecraft;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// Fetches the vanilla client jar for <c>--vanilla-pack</c>, the game's own look as a resource pack.
/// Nothing from it ships with this client: the user's machine downloads its own copy from Mojang, once,
/// into the same cache the framework keeps server jars in.
/// <p/>
/// Mojang's object URLs are content addressed, so the SHA-1 in the URL is checked on the way in and
/// again whenever the cached file is reused; a truncated download is a failure here rather than a
/// world of missing textures later.
/// </summary>
public static class VanillaClientJar {
    /// <summary>The client jars this build knows, by version. Only the one it speaks the protocol of is useful.</summary>
    private static readonly IReadOnlyDictionary<string, string> JarUrls = new Dictionary<string, string> {
        ["26.2"] = "https://piston-data.mojang.com/v1/objects/2dc72797acbc1b63fc16a11c4ac393605f453754/client.jar",
        ["26.3"] = "https://piston-data.mojang.com/v1/objects/e877b6a07acd633fb3bb475002175cec036e7b87/client.jar"
    };

    /// <summary>Where the framework caches what it fetches from Mojang, under a folder per kind.</summary>
    internal static string Cache(string kind) => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MinecraftDotnet", kind);

    /// <summary>A name to write a download under until it is verified and moved, so a reader never sees half a file.</summary>
    internal static string TemporaryFor(string path) => path + "." + Guid.NewGuid().ToString("N") + ".part";

    /// <summary>The cached jar's path, downloading it first if it is missing or does not match its hash.</summary>
    public static async Task<string> Get(CancellationToken cancellation = default) {
        string version = ProtocolConstants.CurrentVersionString;
        if (!JarUrls.TryGetValue(version, out string? url)) {
            throw new InvalidOperationException($"No client jar URL is known for {version}.");
        }
        string directory = Cache("jars");
        Directory.CreateDirectory(directory);
        string path = Path.Combine(directory, $"client-{version}.jar");
        string expected = url.Split('/')[^2];
        if (File.Exists(path) && await Matches(path, expected, cancellation)) {
            return path;
        }

        Console.WriteLine($"Downloading the vanilla {version} client jar for its resource pack, to {path}. This happens once.");
        string temporary = TemporaryFor(path);
        try {
            using HttpClient client = new() { Timeout = TimeSpan.FromMinutes(10) };
            using HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellation);
            response.EnsureSuccessStatusCode();
            long length = response.Content.Headers.ContentLength ?? 0;
            await using (Stream source = await response.Content.ReadAsStreamAsync(cancellation))
            await using (FileStream target = File.Create(temporary)) {
                byte[] buffer = new byte[1 << 16];
                long done = 0;
                int lastPercent = -1;
                int read;
                while ((read = await source.ReadAsync(buffer, cancellation)) > 0) {
                    await target.WriteAsync(buffer.AsMemory(0, read), cancellation);
                    done += read;
                    int percent = length > 0 ? (int)(done * 100 / length) : -1;
                    if (percent >= 0 && percent / 10 != lastPercent / 10) {
                        Console.WriteLine($"  {percent}% of {length / 1048576} MiB");
                        lastPercent = percent;
                    }
                }
            }
            if (!await Matches(temporary, expected, cancellation)) {
                throw new InvalidOperationException($"The jar downloaded from {url} does not have the SHA-1 that URL names.");
            }
            File.Move(temporary, path, overwrite: true);
        }
        finally {
            if (File.Exists(temporary)) {
                File.Delete(temporary);
            }
        }
        return path;
    }

    private static async Task<bool> Matches(string path, string expected, CancellationToken cancellation) {
        await using FileStream file = File.OpenRead(path);
        return Convert.ToHexStringLower(await SHA1.HashDataAsync(file, cancellation)) == expected;
    }
}

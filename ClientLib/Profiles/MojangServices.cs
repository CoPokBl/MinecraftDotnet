using System.Collections.Concurrent;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using Minecraft.Schemas;
using Newtonsoft.Json.Linq;

namespace ClientLib.Profiles;

/// <summary>
/// The parts of authlib's Yggdrasil services a client uses without signing in: the keys that sign profile
/// properties, and looking profiles up by name or id. Every call goes to Mojang, so none is made on a
/// thread that must not wait.
/// </summary>
public static class MojangServices {
    private const string SessionHost = "https://sessionserver.mojang.com", ServicesHost = "https://api.minecraftservices.com";

    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(30) };
    private static readonly Lazy<Task<ServicesKeySet>> KeySet = new(FetchKeySet);

    /// <summary>The <c>/publickeys</c> sets: <c>profilePropertyKeys</c> and <c>playerCertificateKeys</c>.</summary>
    private sealed record ServicesKeySet(RSAParameters[] PropertyKeys, RSAParameters[] CertificateKeys);

    /// <summary>Starts fetching the services keys, as authlib does when its service is made, so a later wait is short.</summary>
    public static void PrefetchKeys() => _ = KeySet.Value;

    /// <summary>
    /// The keys that sign players' chat keys, waiting for the fetch as <c>ServicesKeySet.lazy</c> does; empty when
    /// the key server could not be reached, which is vanilla's <c>canValidateProfileKeys</c> being false.
    /// </summary>
    public static IReadOnlyList<RSAParameters> PlayerCertificateKeys => KeySet.Value.GetAwaiter().GetResult().CertificateKeys;

    // ProfileResolver.Cached forgets an entry ten minutes after its last use; these last the session.
    private static readonly ConcurrentDictionary<Guid, Task<GameProfile?>> ById = new();
    private static readonly ConcurrentDictionary<string, Task<GameProfile?>> ByName = new(StringComparer.Ordinal);

    /// <summary>
    /// <c>getPropertySignatureState</c>: signed when any of the <c>/publickeys</c> profile property keys verifies
    /// the signature, which an unreachable key server leaves none to do.
    /// </summary>
    public static async Task<SignatureState> SignatureStateOf(ProfileProperty property) {
        if (property.Signature == null) {
            return SignatureState.Unsigned;
        }
        byte[] signature;
        try {
            signature = Convert.FromBase64String(property.Signature);
        }
        catch (FormatException) {
            return SignatureState.Invalid;
        }
        byte[] hash = SHA1.HashData(Encoding.UTF8.GetBytes(property.Value));
        foreach (RSAParameters key in (await KeySet.Value).PropertyKeys) {
            if (VerifySha1WithRsa(key, hash, signature)) {
                return SignatureState.Signed;
            }
        }
        return SignatureState.Invalid;
    }

    /// <summary>The DER <c>DigestInfo</c> header for a SHA-1 hash.</summary>
    private static readonly byte[] Sha1DigestInfo = [0x30, 0x21, 0x30, 0x09, 0x06, 0x05, 0x2B, 0x0E, 0x03, 0x02, 0x1A, 0x05, 0x00, 0x04, 0x14];

    /// <summary>
    /// <c>SHA1withRSA</c> verification, PKCS #1 v1.5, done by hand: OpenSSL under a system crypto policy that
    /// forbids SHA-1 signatures, as Fedora's default does, refuses the check outright.
    /// </summary>
    public static bool VerifySha1WithRsa(RSAParameters key, byte[] hash, byte[] signature) {
        BigInteger modulus = new(key.Modulus, true, true);
        BigInteger s = new(signature, true, true);
        if (s >= modulus) {
            return false;
        }
        byte[] decoded = BigInteger.ModPow(s, new BigInteger(key.Exponent, true, true), modulus).ToByteArray(true, true);
        int length = key.Modulus!.Length;
        byte[] expected = new byte[length];
        expected[1] = 0x01;
        int digestStart = length - Sha1DigestInfo.Length - hash.Length;
        expected.AsSpan(2, digestStart - 3).Fill(0xFF);
        Sha1DigestInfo.CopyTo(expected, digestStart);
        hash.CopyTo(expected, length - hash.Length);
        // The leading zero byte is dropped by the big endian conversion.
        return decoded.Length == length - 1 && decoded.AsSpan().SequenceEqual(expected.AsSpan(1));
    }

    /// <summary><c>YggdrasilServicesKeyInfo.fetch</c>, without its retries: empty sets when the keys cannot be had.</summary>
    private static async Task<ServicesKeySet> FetchKeySet() {
        try {
            JObject response = JObject.Parse(await Http.GetStringAsync(ServicesHost + "/publickeys"));
            return new ServicesKeySet(ParseList(response["profilePropertyKeys"]), ParseList(response["playerCertificateKeys"]));
        }
        catch (Exception e) when (e is HttpRequestException or TaskCanceledException or FormatException or CryptographicException
                                       or Newtonsoft.Json.JsonException) {
            return new ServicesKeySet([], []);
        }
    }

    private static RSAParameters[] ParseList(JToken? keys) => (keys as JArray ?? []).Select(key => {
        using RSA rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(key.Value<string>("publicKey")!), out _);
        return rsa.ExportParameters(false);
    }).ToArray();

    /// <summary>
    /// <c>ProfileResolver.Cached.fetchByName</c>: the name's id from <c>/minecraft/profile/lookup/name</c>, then
    /// that profile; null for a name no account has or one <c>StringUtil.isValidPlayerName</c> refuses.
    /// </summary>
    public static Task<GameProfile?> FetchByName(string name) {
        if (name.Length > 16 || name.Any(c => c <= 32 || c >= 127)) {
            return Task.FromResult<GameProfile?>(null);
        }
        return ByName.GetOrAdd(name, async n => {
            JObject? found = await GetJson($"{ServicesHost}/minecraft/profile/lookup/name/{n.ToLowerInvariant()}");
            return found?.Value<string>("id") is { } id ? await FetchById(Guid.Parse(id)) : null;
        });
    }

    /// <summary>
    /// <c>YggdrasilMinecraftSessionService.fetchProfile</c> with <c>requireSecure</c>: the profile and its signed
    /// properties from the session server.
    /// </summary>
    public static Task<GameProfile?> FetchById(Guid id) => ById.GetOrAdd(id, async key => {
        JObject? profile = await GetJson($"{SessionHost}/session/minecraft/profile/{key:N}?unsigned=false");
        if (profile?.Value<string>("id") is not { } profileId || profile.Value<string>("name") is not { } name) {
            return null;
        }
        ProfileProperty[] properties = (profile["properties"] as JArray ?? []).Select(p => new ProfileProperty {
            Name = p.Value<string>("name")!,
            Value = p.Value<string>("value")!,
            Signature = p.Value<string>("signature")
        }).ToArray();
        return new GameProfile(name, Guid.Parse(profileId)) { Properties = properties };
    });

    /// <summary>The body of a 2xx answer as JSON, or null for anything else, a failure included.</summary>
    private static async Task<JObject?> GetJson(string url) {
        try {
            using HttpResponseMessage response = await Http.GetAsync(url);
            return response.IsSuccessStatusCode && response.StatusCode != System.Net.HttpStatusCode.NoContent
                ? JObject.Parse(await response.Content.ReadAsStringAsync())
                : null;
        }
        catch (Exception e) when (e is HttpRequestException or TaskCanceledException or Newtonsoft.Json.JsonException) {
            return null;
        }
    }
}

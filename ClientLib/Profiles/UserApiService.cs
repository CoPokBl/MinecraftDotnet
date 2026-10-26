using System.Net.Http.Headers;
using System.Security.Cryptography;
using ClientLib.Chat;
using Newtonsoft.Json.Linq;

namespace ClientLib.Profiles;

/// <summary><c>UserApiService.UserFlag</c>, the ones the client acts on.</summary>
[Flags]
public enum UserFlags {
    None = 0,
    ChatAllowed = 1,
    ProfanityFilterEnabled = 2,
    ChatFriendsOnly = 4
}

/// <summary>
/// authlib's <c>YggdrasilUserApiService</c>: the signed in account's own services, behind its access token.
/// Every call goes to Mojang, so none is made on a thread that must not wait.
/// </summary>
public sealed class UserApiService(string accessToken) {
    private const string ServicesHost = "https://api.minecraftservices.com";

    /// <summary><c>UserApiService.OFFLINE_PROPERTIES</c>, what vanilla falls back to when the attributes cannot be had.</summary>
    public const UserFlags OfflineProperties = UserFlags.ChatAllowed;

    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(30) };

    /// <summary>
    /// <c>fetchProperties</c>: the account's flags from <c>/player/attributes</c>, or
    /// <see cref="OfflineProperties"/> on any failure, as <c>Minecraft</c>'s constructor substitutes them.
    /// </summary>
    public async Task<UserFlags> FetchProperties() {
        try {
            using HttpRequestMessage request = new(HttpMethod.Get, ServicesHost + "/player/attributes");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            using HttpResponseMessage response = await Http.SendAsync(request);
            if (!response.IsSuccessStatusCode) {
                return OfflineProperties;
            }
            JObject attributes = JObject.Parse(await response.Content.ReadAsStringAsync());
            UserFlags flags = UserFlags.None;
            if (attributes["privileges"]?["onlineChat"]?.Value<bool?>("enabled") == true) {
                flags |= UserFlags.ChatAllowed;
            }
            if (attributes["profanityFilterPreferences"]?.Value<bool?>("profanityFilterOn") == true) {
                flags |= UserFlags.ProfanityFilterEnabled;
            }
            switch (attributes["chatPreferences"]?.Value<string>("textCommunication")) {
                case "ENABLED":
                    flags |= UserFlags.ChatAllowed;
                    break;
                case "FRIENDS_ONLY":
                    flags |= UserFlags.ChatAllowed | UserFlags.ChatFriendsOnly;
                    break;
            }
            return flags;
        }
        catch (Exception e) when (e is HttpRequestException or TaskCanceledException or Newtonsoft.Json.JsonException or InvalidCastException) {
            return OfflineProperties;
        }
    }

    /// <summary>
    /// <c>getKeyPair</c> and <c>AccountProfileKeyPairManager.fetchProfileKeyPair</c>: an empty POST to
    /// <c>/player/certificates</c>, its PEM keys read as <c>Crypt</c> reads them.
    /// </summary>
    /// <exception cref="HttpRequestException">The services refused or could not be reached.</exception>
    /// <exception cref="CryptographicException">The answer held no usable key pair.</exception>
    public async Task<ProfileKeyPair?> GetKeyPair() {
        using HttpRequestMessage request = new(HttpMethod.Post, ServicesHost + "/player/certificates");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        request.Content = new ByteArrayContent([]);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
        using HttpResponseMessage response = await Http.SendAsync(request);
        response.EnsureSuccessStatusCode();
        // Dates stay strings: Json.NET would otherwise turn them into DateTime and back through the local culture.
        using Newtonsoft.Json.JsonTextReader reader = new(new System.IO.StringReader(await response.Content.ReadAsStringAsync())) {
            DateParseHandling = Newtonsoft.Json.DateParseHandling.None
        };
        JObject json = JObject.Load(reader);
        if (json["keyPair"] is not JObject keyPair) {
            return null;
        }
        string? publicKey = keyPair.Value<string>("publicKey");
        string? signature = json.Value<string>("publicKeySignatureV2");
        if (string.IsNullOrEmpty(publicKey) || string.IsNullOrEmpty(signature)) {
            throw new CryptographicException("Missing public key");
        }
        try {
            ProfilePublicKey.KeyData data = new(Instant(json.Value<string>("expiresAt")!), FromPem(publicKey, "RSA PUBLIC KEY"),
                Convert.FromBase64String(signature));
            RSA privateKey = RSA.Create();
            privateKey.ImportPkcs8PrivateKey(FromPem(keyPair.Value<string>("privateKey")!, "RSA PRIVATE KEY"), out _);
            return new ProfileKeyPair(privateKey, new ProfilePublicKey(data), Instant(json.Value<string>("refreshedAfter")!));
        }
        catch (FormatException e) {
            throw new CryptographicException("Malformed key pair", e);
        }
    }

    /// <summary><c>Instant.parse</c>.</summary>
    private static DateTimeOffset Instant(string value) =>
        DateTimeOffset.Parse(value, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal);

    /// <summary>
    /// <c>Crypt.rsaStringToKey</c>: the base64 between the header and the footer. Despite their labels the
    /// services send PKCS #8 and X.509 encodings, not PKCS #1.
    /// </summary>
    private static byte[] FromPem(string pem, string label) {
        string header = $"-----BEGIN {label}-----", footer = $"-----END {label}-----";
        int begin = pem.IndexOf(header, StringComparison.Ordinal);
        if (begin != -1) {
            begin += header.Length;
            pem = pem[begin..pem.IndexOf(footer, begin, StringComparison.Ordinal)];
        }
        return Convert.FromBase64String(string.Concat(pem.Where(c => !char.IsWhiteSpace(c))));
    }
}

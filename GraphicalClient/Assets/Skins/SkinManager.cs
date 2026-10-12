using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;
using ClientLib;
using ClientLib.Profiles;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Components.Types;
using Minecraft.Schemas;
using PlayerSkin = GraphicalClient.Rendering.Entities.Vanilla.PlayerSkin;

namespace GraphicalClient.Assets.Skins;

/// <summary>
/// <c>SkinManager</c>, <c>SkinTextureDownloader</c> and <c>PlayerSkinRenderCache</c>: the skin, cape and elytra a
/// profile's <c>textures</c> property names, fetched from Mojang into the user's cache directory on a worker.
/// Every lookup answers at once, with the profile's default skin until its own is in.
/// </summary>
public static class SkinManager {
    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(30) };
    private static readonly string Root = VanillaClientJar.Cache("skins");

    // Vanilla lets an unused entry go after 15 seconds (5 minutes for a profile); a session's worth is kept here.
    private static readonly ConcurrentDictionary<(Guid Id, string? Value, string? Signature), Task<PlayerSkin?>> Skins = new();
    private static readonly ConcurrentDictionary<ProfileComponent.Data, Task<PlayerSkin?>> Profiles = new();
    private static readonly ConcurrentDictionary<string, Task<string>> Textures = new();
    private static readonly ConcurrentDictionary<string, TextureImage> Downloaded = new();

    /// <summary>
    /// The client whose player list answers for a player's skin and is asked first for a profile, where vanilla
    /// reaches for <c>Minecraft.getInstance()</c>.
    /// </summary>
    public static MinecraftClient? Client { get; set; }

    /// <summary>
    /// <c>PlayerInfo.getSkin</c>: the skin of the player list entry with the id, signed unless it is the local
    /// player's own, else the default for the id.
    /// </summary>
    public static PlayerSkin ForPlayer(Guid profileId) =>
        Client != null && Client.PlayerList.TryGetValue(profileId, out PlayerListEntry? info)
            ? Lookup(profileId, info.Properties, profileId != Client.Profile.Uuid)
            : DefaultPlayerSkin.Get(profileId);

    /// <summary>
    /// <c>SkinManager.createLookup</c> for a game profile: its own skin once loaded, unless that is unsigned and
    /// <paramref name="requireSecure"/> asks for a signed one.
    /// </summary>
    public static PlayerSkin Lookup(Guid profileId, ProfileProperty[] properties, bool requireSecure) =>
        Get(profileId, properties) is { IsCompletedSuccessfully: true, Result: { } skin } && (!requireSecure || skin.Secure)
            ? skin
            : DefaultPlayerSkin.Get(profileId);

    /// <summary>
    /// <c>PlayerSkinRenderCache.lookup</c>, for a <c>minecraft:profile</c> on a player head or a mannequin, and null
    /// until it is in: a profile with only a name or only an id is looked up first, in the player list and then
    /// at Mojang.
    /// </summary>
    public static PlayerSkin? Lookup(ProfileComponent.Data profile) =>
        Profiles.GetOrAdd(profile, p => {
            // LocalPlayerResolver, asked here on the game thread that owns the player list.
            GameProfile? local = IsDynamic(p) ? LocalProfile(p) : null;
            return Task.Run(async () => {
                GameProfile resolved = IsDynamic(p) ? local ?? await FetchByNameOrId(p) ?? PartialProfile(p) : PartialProfile(p);
                return await Get(resolved.Uuid, resolved.Properties) is { } skin ? skin.With(p.Patch) : null;
            });
        }) is { IsCompletedSuccessfully: true, Result: { } found } ? found : null;

    /// <summary><c>PlayerSkinRenderCache.getOrDefault</c>: the default skin for the profile's id until its own is in.</summary>
    public static PlayerSkin GetOrDefault(ProfileComponent.Data profile) =>
        Lookup(profile) ?? DefaultPlayerSkin.Get(PartialProfile(profile).Uuid).With(profile.Patch);

    /// <summary>A texture a skin names that came from Mojang rather than a pack, once its download is in.</summary>
    public static TextureImage? Texture(string identifier) => Downloaded.GetValueOrDefault(identifier);

    /// <summary><c>ResolvableProfile.create</c>'s test for a <c>Dynamic</c> profile: no properties and only one of the name and the id.</summary>
    private static bool IsDynamic(ProfileComponent.Data profile) => profile.Properties.Length == 0 && profile.Name != null != (profile.UniqueId != null);

    /// <summary><c>createPartialProfile</c>: a missing id is the offline one of the name, or nil without one.</summary>
    private static GameProfile PartialProfile(ProfileComponent.Data profile) =>
        new(profile.Name ?? "", profile.UniqueId ?? (profile.Name != null ? MinecraftClient.OfflineUuid(profile.Name) : Guid.Empty)) {
            Properties = profile.Properties
        };

    private static GameProfile? LocalProfile(ProfileComponent.Data profile) {
        PlayerListEntry? entry = profile.UniqueId is { } id
            ? Client?.PlayerList.GetValueOrDefault(id)
            : Client?.PlayerList.Values.FirstOrDefault(e => string.Equals(e.Name, profile.Name, StringComparison.OrdinalIgnoreCase));
        return entry == null ? null : new GameProfile(entry.Name, entry.Uuid) { Properties = entry.Properties };
    }

    private static Task<GameProfile?> FetchByNameOrId(ProfileComponent.Data profile) =>
        profile.Name != null ? MojangServices.FetchByName(profile.Name) : MojangServices.FetchById(profile.UniqueId!.Value);

    /// <summary><c>SkinManager.get</c>: null when a texture fails to load, which the lookups answer with the default.</summary>
    private static Task<PlayerSkin?> Get(Guid profileId, ProfileProperty[] properties) {
        ProfileProperty? packed = ProfileTextures.Packed(properties);
        return Skins.GetOrAdd((profileId, packed?.Value, packed?.Signature), _ => Task.Run(async () => {
            try {
                ProfileTextures textures = packed == null ? ProfileTextures.Empty : ProfileTextures.Unpack(packed, await MojangServices.SignatureStateOf(packed));
                return await RegisterTextures(profileId, textures);
            }
            catch (Exception e) {
                Console.Error.WriteLine($"Failed to load texture for profile {profileId}: {e.Message}");
                return null;
            }
        }));
    }

    /// <summary><c>registerTextures</c>.</summary>
    private static async Task<PlayerSkin?> RegisterTextures(Guid profileId, ProfileTextures textures) {
        string body;
        bool slim;
        if (textures.Skin is { } skinInfo) {
            body = await GetOrLoad("skins", skinInfo, true);
            // PlayerModelType.byLegacyServicesName: anything but "slim" is the wide model.
            slim = skinInfo.GetMetadata("model") == "slim";
        }
        else {
            PlayerSkin defaultSkin = DefaultPlayerSkin.Get(profileId);
            body = defaultSkin.Body;
            slim = defaultSkin.Slim;
        }
        string? cape = textures.Cape is { } capeInfo ? await GetOrLoad("capes", capeInfo, false) : null;
        string? elytra = textures.Elytra is { } elytraInfo ? await GetOrLoad("elytra", elytraInfo, false) : null;
        return new PlayerSkin(body, cape, elytra, slim, textures.SignatureState == SignatureState.Signed);
    }

    /// <summary>
    /// <c>TextureCache.getOrLoad</c>: one download per texture hash and kind, kept under
    /// <c>skins/&lt;two characters&gt;/&lt;sha1&gt;</c> as vanilla keeps its own.
    /// </summary>
    private static Task<string> GetOrLoad(string kind, ProfileTexture texture, bool processLegacySkin) =>
        Textures.GetOrAdd(kind + "/" + texture.Hash, _ => Task.Run(async () => {
            // Hashing.sha1().hashUnencodedChars: the hash of the UTF-16 code units, little end first.
            string hash = Convert.ToHexStringLower(SHA1.HashData(Encoding.Unicode.GetBytes(texture.Hash)));
            string identifier = $"minecraft:{kind}/{hash}";
            string file = Path.Combine(Root, hash.Length > 2 ? hash[..2] : "xx", hash);
            TextureImage image = Png.Decode(await DownloadSkin(file, texture.Url));
            if (processLegacySkin) {
                byte[] processed = SkinTextureProcessing.ProcessLegacySkin(image.Width, image.Height, image.Rgba)
                    ?? throw new InvalidDataException($"Discarding incorrectly sized ({image.Width}x{image.Height}) skin texture from {texture.Url}");
                image = new TextureImage(64, 64, processed);
            }
            Downloaded[identifier] = image;
            return identifier;
        }));

    /// <summary><c>SkinTextureDownloader.downloadSkin</c>: the cached copy when there is one, else the URL's, cached on the way.</summary>
    private static async Task<byte[]> DownloadSkin(string localCopy, string url) {
        if (File.Exists(localCopy)) {
            return await File.ReadAllBytesAsync(localCopy);
        }
        byte[] contents = await Http.GetByteArrayAsync(url);
        try {
            Directory.CreateDirectory(Path.GetDirectoryName(localCopy)!);
            string temporary = VanillaClientJar.TemporaryFor(localCopy);
            await File.WriteAllBytesAsync(temporary, contents);
            File.Move(temporary, localCopy, true);
        }
        catch (IOException) {
            Console.Error.WriteLine($"Failed to cache texture {url} in {localCopy}");
        }
        return contents;
    }
}

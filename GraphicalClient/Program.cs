using System.Diagnostics;
using ClientLib;
using GraphicalClient;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Implementations.Client.Tools;
using Newtonsoft.Json;

LaunchOptions options;
try {
    options = LaunchOptions.Parse(args);
}
catch (HelpRequestedException) {
    Console.WriteLine(LaunchOptions.Usage);
    return 0;
}
catch (Exception e) {
    Console.Error.WriteLine(e.Message);
    Console.Error.WriteLine(LaunchOptions.Usage);
    return 2;
}

ClientOptions clientOptions = new() {
    Username = options.Username,
    ViewDistance = options.ViewDistance,
    AutoRespawn = options.AutoRespawn
};
if (options.Brand != null) {
    clientOptions.Brand = options.Brand;
}
if (options.ServerPacks is { } serverPacks) {
    clientOptions.ServerPackStatus = serverPacks;
}
foreach ((string key, string value) in options.SettingOverrides) {
    if (key == "lang") {
        clientOptions.Locale = value;
    }
    if (key == "chatSigning") {
        clientOptions.ChatSigning = value == "true";
    }
}
if (options.Microsoft) {
    clientOptions.Account = await SignIn();
    // Minecraft's userPropertiesFuture: the account's chat permission, and the profanity filter the client information reports.
    clientOptions.UserFlags = await new ClientLib.Profiles.UserApiService(clientOptions.Account.AccessToken).FetchProperties();
    clientOptions.TextFiltering = (clientOptions.UserFlags & ClientLib.Profiles.UserFlags.ProfanityFilterEnabled) != 0;
}

if (options.Headless) {
    return await RunHeadless(options, clientOptions);
}

if (options.VanillaPack) {
    if (await Fetch(() => VanillaClientJar.Get(), "Could not get the vanilla pack, carrying on without it") is { } jar) {
        options.VanillaJar = jar;
    }
    options.VanillaAssets = await Fetch(() => VanillaAssets.Get(), "Could not get the vanilla sounds, carrying on with the built in ones");
}

using GameWindow game = new(options, clientOptions);
game.Run();
return game.ExitCode;

static async Task<T?> Fetch<T>(Func<Task<T>> get, string failure) where T : class {
    try {
        return await get();
    }
    catch (Exception e) when (e is HttpRequestException or IOException or InvalidOperationException or TaskCanceledException) {
        Console.Error.WriteLine($"{failure}: {e.Message}");
        return null;
    }
}

static async Task<MicrosoftAuthenticator.MinecraftProfile> SignIn() {
    string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "mcdotnet-client");
    string file = Path.Combine(directory, "account.json");
    if (File.Exists(file)) {
        MicrosoftAuthenticator.MinecraftProfile? cached = JsonConvert.DeserializeObject<MicrosoftAuthenticator.MinecraftProfile>(File.ReadAllText(file));
        if (cached != null && File.GetLastWriteTimeUtc(file) > DateTime.UtcNow.AddHours(-20)) {
            Console.WriteLine($"Signed in as {cached.Username} (cached)");
            return cached;
        }
    }

    MicrosoftAuthenticator.MinecraftProfile profile = await new MicrosoftAuthenticator().Authenticate(url => Console.WriteLine($"Sign in at: {url}"));
    Directory.CreateDirectory(directory);
    File.WriteAllText(file, JsonConvert.SerializeObject(profile));
    Console.WriteLine($"Signed in as {profile.Username}");
    return profile;
}

static async Task<int> RunHeadless(LaunchOptions options, ClientOptions clientOptions) {
    clientOptions.AutoRespawn = true;
    MinecraftClient client = new(clientOptions);
    client.Log += message => Console.WriteLine(message);
    client.ChatMessages.Logged += message => Console.WriteLine(message);
    await client.Connect(options.Host, options.Port);

    Stopwatch clock = Stopwatch.StartNew();
    LaunchScript script = new(options, client, clock);
    TimeSpan tickLength = TimeSpan.FromMilliseconds(50);
    TimeSpan nextTick = TimeSpan.Zero;
    while (client.Phase != ClientPhase.Disconnected) {
        client.ProcessPackets();
        while (clock.Elapsed >= nextTick) {
            client.Tick();
            nextTick += tickLength;
        }

        script.SendCommands();
        if (options.ExitAfter is { } exitAfter && clock.Elapsed.TotalSeconds > exitAfter) {
            Console.WriteLine($"Exiting after {exitAfter}s: {client.Level?.Chunks.Count ?? 0} chunks, {client.Entities.Count} entities, " +
                              $"{client.Connection?.PacketsReceived} packets, {client.Connection?.BytesReceived / 1024} KiB");
            client.Disconnect("Quit");
            return 0;
        }
        Thread.Sleep(5);
    }
    Console.WriteLine($"Disconnected: {client.DisconnectReason}");
    return 1;
}

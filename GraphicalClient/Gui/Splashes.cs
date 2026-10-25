using System.Diagnostics;
using System.Numerics;
using System.Text;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Audio;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>SplashManager</c>: the lines of the top pack's <c>texts/splashes.txt</c>, one picked for each title screen.
/// Where no pack has the file this client's own lines stand in, where vanilla would show none; the dated
/// splashes are this client's own wording.
/// </summary>
public sealed class SplashManager(string userName) {
    private const string SplashesLocation = "assets/minecraft/texts/splashes.txt";
    private const uint DefaultColor = 0xFFFFFF00;

    private static readonly LegacyRandom Random = new();

    private IReadOnlyList<string> _splashes = BuiltIn;

    /// <summary>The prepare half of the reload: trimmed lines, less the one vanilla's file keeps to say it never shows.</summary>
    public static IReadOnlyList<string> Prepare(PackFiles? files) {
        if (files?.Read(SplashesLocation) is not { } data) {
            return BuiltIn;
        }
        List<string> lines = [];
        using StringReader reader = new(Encoding.UTF8.GetString(data));
        while (reader.ReadLine() is { } line) {
            string trimmed = JavaTrim(line);
            if (ClientLib.Multiplayer.ServerData.JavaHashCode(trimmed) != 125780783) {
                lines.Add(trimmed);
            }
        }
        return lines;
    }

    public void Apply(IReadOnlyList<string> splashes) => _splashes = splashes;

    /// <summary><c>String.trim</c>, which takes off everything up to the space and nothing else.</summary>
    private static string JavaTrim(string text) {
        int start = 0, end = text.Length;
        while (start < end && text[start] <= ' ') {
            start++;
        }
        while (end > start && text[end - 1] <= ' ') {
            end--;
        }
        return text[start..end];
    }

    /// <summary><c>getSplash</c>: a dated one, else one in as many draws as there are lines is the player's own name.</summary>
    public SplashRenderer? GetSplash(DateTime today) {
        switch (today.Month, today.Day) {
            case (12, 24):
                return new SplashRenderer("Unwrapping packets by the fire!", DefaultColor);
            case (1, 1):
                return new SplashRenderer("Tick zero of a brand new year!", DefaultColor);
            case (10, 31):
                return new SplashRenderer("Boo! A ghost entity id!", DefaultColor);
        }
        if (_splashes.Count == 0) {
            return null;
        }
        return Random.NextInt(_splashes.Count) == 42
            ? new SplashRenderer("Hello, " + userName + ", from the other end of the socket!", DefaultColor)
            : new SplashRenderer(_splashes[Random.NextInt(_splashes.Count)], DefaultColor);
    }

    /// <summary>This client's own splashes, for when no resource pack brings any.</summary>
    public static readonly IReadOnlyList<string> BuiltIn = [
        "Written from scratch!",
        "Now in C#!",
        "Powered by .NET!",
        "Twenty ticks a second!",
        "Byte for byte!",
        "Tick for tick!",
        "Parity is the standard!",
        "Read the jar!",
        "Transcribed, not imitated!",
        "No flags from Grim!",
        "Anticheat approved, hopefully!",
        "Every packet in order!",
        "VarInts all the way down!",
        "Now with chunk batches!",
        "Keep alive!",
        "Ping? Pong!",
        "Encrypted with AES/CFB8!",
        "Compressed above the threshold!",
        "Mind the protocol version!",
        "Handshake first!",
        "Login, configure, play!",
        "Also on Linux!",
        "Wayland friendly!",
        "Vsync optional!",
        "1000 frames a second!",
        "Vertex bound!",
        "Shader packs welcome!",
        "Bring your own pack!",
        "Generated art only!",
        "Nullable reference types!",
        "async all the things!",
        "Garbage collected!",
        "Zero allocations, almost!",
        "Span<T>!",
        "Records and pattern matching!",
        "dotnet build!",
        "dotnet test!",
        "Hundreds of tests!",
        "Hand-worked numbers!",
        "Conformance harness approved!",
        "The jar is the arbiter!",
        "Diffable against the original!",
        "Same random draws!",
        "Java's LCG, in C#!",
        "Floats, not doubles!",
        "Doubles, not floats!",
        "Collision boxes included!",
        "Sweeping AABBs!",
        "Step height respected!",
        "Sprinting since tick one!",
        "Riptide tested!",
        "Elytra checked!",
        "Bundles sorted!",
        "The server is always right!",
        "Teleport confirmed!",
        "Chunk sections, meshed!",
        "Greedy meshing!",
        "Frustum culled!",
        "Occlusion walked!",
        "GPU prefix sums!",
        "OpenGL 4.5!",
        "Silk.NET inside!",
        "Mipmapped!",
        "Smooth lighting!",
        "Light engine settled!",
        "Now with server lists!",
        "Pinging...",
        "Five bars!",
        "LAN party!",
        "Join, leave, repeat!",
        "Fresh client every join!",
        "No leaks!",
        "Cookies carried over!",
        "Transfer accepted!",
        "Resource packs, served!",
        "Chat, signed!",
        "Secure chat!",
        "The mcdotnet edition!",
        "mcdotnet!",
        "Open source!",
        "Built on a protocol library!",
        "Packets are data!",
        "Clientbound and serverbound!",
        "Registries synchronised!",
        "Tags arrived!",
        "Known packs: core!",
        "Feature flags set!",
        "Also a server framework!",
        "Everything is opt in!",
        "Vanilla is a feature!",
        "Prefer a type over a string!",
        "Generated types!"
    ];
}

/// <summary><c>SplashRenderer</c>: the splash beside the logo, tilted 20 degrees up and pulsing once a second.</summary>
public sealed class SplashRenderer(string splash, uint color) {
    private const float WidthOffset = 123.0F, HeightOffset = 69.0F, TextAngle = -MathF.PI / 9.0F;

    public string Text => splash;

    public void Render(GuiContext context, int screenWidth, float alpha) {
        int textWidth = context.Text.Width(splash);
        long millis = (long)(Stopwatch.GetTimestamp() * (1000.0 / Stopwatch.Frequency));
        float textPhase = 1.8F - MathF.Abs(MathF.Sin(millis % 1000L / 1000.0F * (MathF.PI * 2)) * 0.1F);
        float textScale = textPhase * 100.0F / (textWidth + 32);
        Matrix3x2 pose = Matrix3x2.CreateScale(textScale) * Matrix3x2.CreateRotation(TextAngle) * Matrix3x2.CreateTranslation(screenWidth / 2.0F + WidthOffset, HeightOffset);
        context.Gui.Pose = pose;
        context.Text.Draw(splash, -textWidth / 2, -8, (uint)(Math.Clamp(alpha, 0, 1) * 255) << 24 | color & 0xFFFFFF);
        context.Gui.Pose = Matrix3x2.Identity;
    }
}

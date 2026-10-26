using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using GraphicalClient.Assets.ResourcePacks;

namespace GraphicalClient.Rendering;

/// <summary>
/// The end portal's layer colours, handed to shader packs as <c>endPortalColours</c>. The first tints the
/// sky texture and the nth the nth layer of stars. They are read from the <c>COLORS</c> table of the pack's
/// own <c>rendertype_end_portal.fsh</c> where one is loaded, and otherwise are this client's palette.
/// </summary>
public static class EndPortalPalette {
    public const int Layers = 16;

    private const string VanillaShader = "assets/minecraft/shaders/core/rendertype_end_portal.fsh";

    private static readonly Regex Vec3 = new(@"vec3\(\s*([-0-9.eE]+)\s*,\s*([-0-9.eE]+)\s*,\s*([-0-9.eE]+)\s*\)");

    /// <summary>Set from <see cref="Read"/> on the render thread, where shader packs read it.</summary>
    public static Vector3[] Colours { get; set; } = Generated();

    public static Vector3[] Read(PackFiles? packs) =>
        packs?.Read(VanillaShader) is { } source && Parse(Encoding.UTF8.GetString(source)) is { } read ? read : Generated();

    private static Vector3[]? Parse(string source) {
        int table = source.IndexOf("COLORS", StringComparison.Ordinal);
        if (table < 0) {
            return null;
        }
        Vector3[] colours = Vec3.Matches(source[table..]).Take(Layers)
            .Select(m => new Vector3(Float(m.Groups[1].Value), Float(m.Groups[2].Value), Float(m.Groups[3].Value))).ToArray();
        return colours.Length == Layers ? colours : null;
    }

    private static float Float(string text) => float.Parse(text, CultureInfo.InvariantCulture);

    /// <summary>A dim teal sky under layers that brighten and drift from sea green toward violet and sky blue.</summary>
    private static Vector3[] Generated() {
        Vector3[] colours = new Vector3[Layers];
        for (int i = 0; i < Layers; i++) {
            float t = i / (Layers - 1.0F);
            float wobble = MathF.Sin(i * 2.4F) * 0.5F + 0.5F;
            float brightness = 0.1F + 0.3F * t * t;
            Vector3 hue = Vector3.Lerp(new Vector3(0.25F, 0.9F, 0.8F), new Vector3(0.55F, 0.45F, 1.0F), wobble);
            colours[i] = Vector3.Lerp(hue, new Vector3(0.2F, 0.75F, 1.0F), t * 0.5F) * brightness;
        }
        return colours;
    }
}

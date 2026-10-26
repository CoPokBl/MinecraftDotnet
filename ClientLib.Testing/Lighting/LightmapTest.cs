using System.Numerics;
using ClientLib.World;

namespace ClientLib.Testing.Lighting;

/// <summary>
/// Entries of the lightmap worked from <c>lightmap.fsh</c> by hand, in single precision, for states the overworld
/// reaches: noon and midnight at the default brightness and at Moody, a boss darkening the world, and the darkness
/// effect at the height of its pulse. Each picked entry sits clear of a rounding boundary.
/// </summary>
public class LightmapTest {
    /// <summary><c>visual/block_light_tint</c>'s default, <c>#ffd88c</c>.</summary>
    private static readonly Vector3 BlockLightTint = new Vector3(255, 216, 140) / 255.0F;

    /// <summary>The overworld's <c>ambient_light_color</c>, <c>#0a0a0a</c>.</summary>
    private static readonly Vector3 Ambient = new Vector3(10) / 255.0F;

    private static readonly LightmapState Noon = new(1.0F, 1.4F, 0.0F, 0.0F, 0.0F, 0.5F, BlockLightTint, Vector3.One, Ambient, new Vector3(0.6F));

    /// <summary>The day timeline's night: a quarter of the sky light, tinted by <c>NIGHT_SKY_LIGHT_COLOR</c> floored to eight bits.</summary>
    private static readonly LightmapState Midnight = Noon with { SkyFactor = 0.24F, SkyLightColor = new Vector3(122, 122, 255) / 255.0F };

    private static (byte R, byte G, byte B) Entry(in LightmapState state, int block, int sky) {
        byte[] table = new byte[16 * 16 * 4];
        Lightmap.Compute(state, table);
        int i = (sky * 16 + block) * 4;
        Assert.That(table[i + 3], Is.EqualTo(255));
        return (table[i], table[i + 1], table[i + 2]);
    }

    [Test]
    public void NoonAtDefaultBrightness() {
        Assert.Multiple(() => {
            Assert.That(Entry(Noon, 0, 0), Is.EqualTo(((byte)24, (byte)24, (byte)24)));
            Assert.That(Entry(Noon, 7, 0), Is.EqualTo(((byte)132, (byte)115, (byte)81)));
            Assert.That(Entry(Noon, 3, 9), Is.EqualTo(((byte)161, (byte)157, (byte)150)));
            Assert.That(Entry(Noon, 10, 5), Is.EqualTo(((byte)203, (byte)182, (byte)141)));
            Assert.That(Entry(Noon, 0, 15), Is.EqualTo(((byte)255, (byte)255, (byte)255)));
            Assert.That(Entry(Noon, 15, 15), Is.EqualTo(((byte)255, (byte)255, (byte)255)));
        });
    }

    [Test]
    public void MidnightSkyIsBlue() {
        Assert.Multiple(() => {
            Assert.That(Entry(Midnight, 0, 15), Is.EqualTo(((byte)71, (byte)71, (byte)129)));
            // Block light is the same by night as by day, the sky only adding to it.
            Assert.That(Entry(Midnight, 7, 0), Is.EqualTo(Entry(Noon, 7, 0)));
        });
    }

    [Test]
    public void MoodyLeavesTheCurveUnbent() {
        Assert.That(Entry(Midnight with { BrightnessFactor = 0.0F }, 7, 0), Is.EqualTo(((byte)74, (byte)64, (byte)45)));
    }

    [Test]
    public void BossOverlayDarkensTowardRed() {
        Assert.That(Entry(Noon with { BossOverlayWorldDarkeningFactor = 1.0F, BrightnessFactor = 0.0F }, 7, 0), Is.EqualTo(((byte)52, (byte)39, (byte)27)));
    }

    /// <summary>A texel the darkness takes to black divides zero by zero in <c>notGamma</c>, which a UNORM target stores as zero.</summary>
    [Test]
    public void DarknessTakesDimTexelsToBlack() {
        LightmapState darkness = Midnight with { DarknessScale = 0.45F, BrightnessFactor = 0.0F };
        Assert.Multiple(() => {
            Assert.That(Entry(darkness, 0, 0), Is.EqualTo(((byte)0, (byte)0, (byte)0)));
            Assert.That(Entry(darkness, 15, 0), Is.EqualTo(((byte)252, (byte)247, (byte)236)));
        });
    }
}

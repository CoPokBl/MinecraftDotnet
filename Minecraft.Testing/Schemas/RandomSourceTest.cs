using Minecraft.Schemas;

namespace Minecraft.Testing.Schemas;

/// <summary>
/// Pins <see cref="LegacyRandomSource"/> against the generator in the jar. Every expected sequence
/// here was printed by <c>Conformance/mth.sh</c> running vanilla's own
/// <c>LegacyRandomSource</c>.
/// <p/>
/// A random generator agrees with any test written against it, which is the whole reason these come
/// from outside: the point of the port is not that it produces random numbers, it is that it produces
/// <b>the same</b> numbers, so a goal's cadence can be reproduced and diffed against vanilla.
/// </summary>
[TestFixture]
public class RandomSourceTest {
    private const long Seed = 1234L;

    [Test]
    public void TestNextIntMatchesVanilla() {
        LegacyRandomSource random = new(Seed);
        int[] expected = [
            -1517918040, 1115789266, -208917030, 1019800440,
            -611652875, 1362132786, 1968097058, -1933932397
        ];

        Assert.Multiple(() => {
            for (int i = 0; i < expected.Length; i++) {
                Assert.That(random.NextInt(), Is.EqualTo(expected[i]), $"draw {i}");
            }
        });
    }

    /// <summary>
    /// Sixteen takes the power of two branch, which is a multiply and a shift; ten and seven take the
    /// rejection loop. A port that used a plain modulo for both agrees on the first eight and drifts
    /// on the rest.
    /// </summary>
    [Test]
    public void TestBoundedNextIntMatchesVanillaOnBothBranches() {
        LegacyRandomSource random = new(Seed);
        int[] expected = [
            10, 4, 15, 3, 13, 5, 7, 8,
            7, 7, 0, 8, 7, 6, 9, 4,
            4, 5, 3, 0, 4, 5, 5, 0
        ];

        Assert.Multiple(() => {
            for (int i = 0; i < 8; i++) {
                Assert.That(random.NextInt(16), Is.EqualTo(expected[i]), $"NextInt(16) draw {i}");
            }

            for (int i = 0; i < 8; i++) {
                Assert.That(random.NextInt(10), Is.EqualTo(expected[8 + i]), $"NextInt(10) draw {i}");
            }

            for (int i = 0; i < 8; i++) {
                Assert.That(random.NextInt(7), Is.EqualTo(expected[16 + i]), $"NextInt(7) draw {i}");
            }
        });
    }

    [Test]
    public void TestNextFloatMatchesVanilla() {
        LegacyRandomSource random = new(Seed);
        float[] expected = [
            0.6465821f, 0.25978988f, 0.95135766f, 0.23744076f,
            0.8575884f, 0.31714624f, 0.4582333f, 0.54972124f
        ];

        Assert.Multiple(() => {
            for (int i = 0; i < expected.Length; i++) {
                Assert.That(random.NextFloat(), Is.EqualTo(expected[i]), $"draw {i}");
            }
        });
    }

    [Test]
    public void TestNextDoubleMatchesVanilla() {
        LegacyRandomSource random = new(Seed);
        double[] expected = [
            0.6465821602909256, 0.9513577109193919, 0.8575884598068334, 0.45823330506267057,
            0.3359524025416939, 0.20387478195313158, 0.34690742873967684, 0.617314071997303
        ];

        Assert.Multiple(() => {
            for (int i = 0; i < expected.Length; i++) {
                Assert.That(random.NextDouble(), Is.EqualTo(expected[i]), $"draw {i}");
            }
        });
    }

    /// <summary>
    /// The two halves are added rather than or'd, so a negative low half borrows from the high one.
    /// Getting that wrong shows up here and nowhere else.
    /// </summary>
    [Test]
    public void TestNextLongMatchesVanilla() {
        LegacyRandomSource random = new(Seed);
        long[] expected = [
            -6519408338692630574L, -897291810407650440L, -2627029093267243214L, 8452912497529882771L
        ];

        Assert.Multiple(() => {
            for (int i = 0; i < expected.Length; i++) {
                Assert.That(random.NextLong(), Is.EqualTo(expected[i]), $"draw {i}");
            }
        });
    }

    [Test]
    public void TestNextBooleanMatchesVanilla() {
        LegacyRandomSource random = new(Seed);
        bool[] expected = [true, false, true, false, true, false, false, true, false, false, false, false];

        Assert.Multiple(() => {
            for (int i = 0; i < expected.Length; i++) {
                Assert.That(random.NextBoolean(), Is.EqualTo(expected[i]), $"draw {i}");
            }
        });
    }

    /// <summary>
    /// The polar method produces two values per pass and hands the spare out next call, so the pairs
    /// only line up if the rejection loop rejects exactly what vanilla's does.
    /// </summary>
    [Test]
    public void TestNextGaussianMatchesVanilla() {
        LegacyRandomSource random = new(Seed);
        double[] expected = [
            0.14115907833078006, 0.4346588858045114, 1.1384720144986948,
            -0.13297468645923347, -0.6052515488113404, -1.0925502698112701
        ];

        Assert.Multiple(() => {
            for (int i = 0; i < expected.Length; i++) {
                Assert.That(random.NextGaussian(), Is.EqualTo(expected[i]), $"draw {i}");
            }
        });
    }

    /// <summary>
    /// The seed is scrambled by the multiplier before use and masked to forty eight bits, so a
    /// negative seed has to come out the same way it does upstream.
    /// </summary>
    [Test]
    public void TestNegativeSeedMatchesVanilla() {
        LegacyRandomSource random = new(-987654321L);
        int[] expected = [-1314770571, -1648208228, -1702638463, -1035876036, -755381876, 2017137082];

        Assert.Multiple(() => {
            for (int i = 0; i < expected.Length; i++) {
                Assert.That(random.NextInt(), Is.EqualTo(expected[i]), $"draw {i}");
            }
        });
    }

    /// <summary>Reseeding throws the half used gaussian pair away, as <c>MarsagliaPolarGaussian.reset</c> does.</summary>
    [Test]
    public void TestReseedingDiscardsTheSpareGaussian() {
        LegacyRandomSource random = new(Seed);
        double first = random.NextGaussian();
        random.SetSeed(Seed);

        Assert.That(random.NextGaussian(), Is.EqualTo(first),
            "the spare from before the reseed should not be handed out");
    }
}

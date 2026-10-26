using Minecraft.Schemas;

namespace Minecraft.Testing.Schemas;

/// <summary>
/// Pins <see cref="Mth"/> against the real one. Every expected value here was printed by
/// <c>Conformance/mth.sh</c>, which calls vanilla's own methods out of the server jar, so these are
/// not recomputations of the port.
/// <p/>
/// That matters most for <see cref="Mth.Atan2"/>, which is an approximation: it is wrong against
/// <see cref="Math.Atan2"/> by up to about 3e-7, and every mob's facing is computed through it, so a
/// port that quietly used the accurate function would pass any test written from first principles.
/// </summary>
[TestFixture]
public class MthTest {
    private static readonly double[][] Atan2Cases = [
        [0.0, 1.0], [1.0, 0.0], [1.0, 1.0], [-1.0, 1.0], [1.0, -1.0], [-1.0, -1.0],
        [0.5, 2.0], [2.0, 0.5], [-0.5, 2.0], [2.0, -0.5], [-2.0, -0.5], [-0.5, -2.0],
        [1.0E-8, 1.0], [1.0, 1.0E-8], [123.456, -78.9], [-0.001, 0.002], [0.0, -1.0], [0.0, 0.0]
    ];

    private static readonly double[] ExpectedAtan2 = [
        0.0, 1.5707963267948966, 0.7853981366411398, -0.7853981366411398, 2.356194516948653,
        -2.356194516948653, 0.2449784461902417, 1.3258178806046548, -0.2449784461902417,
        1.8157747729851383, -1.8157747729851383, -2.8966142073995513, 9.983081427118146E-9,
        1.570796316811815, 2.1394668741030665, -0.46364665360693563, 3.141592653589793, 0.0
    ];

    [Test]
    public void TestAtan2MatchesVanilla() {
        Assert.Multiple(() => {
            for (int i = 0; i < Atan2Cases.Length; i++) {
                Assert.That(Mth.Atan2(Atan2Cases[i][0], Atan2Cases[i][1]), Is.EqualTo(ExpectedAtan2[i]),
                    $"atan2({Atan2Cases[i][0]}, {Atan2Cases[i][1]})");
            }
        });
    }

    /// <summary>
    /// The whole reason the approximation is ported rather than delegated. If this ever stops failing
    /// then <see cref="Mth.Atan2"/> has been replaced by the accurate function.
    /// </summary>
    [Test]
    public void TestAtan2IsNotTheAccurateFunction() {
        Assert.That(Mth.Atan2(1.0, 1.0), Is.Not.EqualTo(Math.Atan2(1.0, 1.0)));
        Assert.That(Mth.Atan2(1.0, 1.0), Is.EqualTo(Math.Atan2(1.0, 1.0)).Within(1e-6),
            "but it is still an arctangent");
    }

    private static readonly double[] ExpectedFastInvSqrt = [
        0.9983081427118145, 0.7069296507954639, 0.4991540713559072, 1.996616285423629,
        0.09984476108311885, 999.2111496578983, 0.008992565706850876
    ];

    [Test]
    public void TestFastInvSqrtMatchesVanilla() {
        double[] inputs = [1.0, 2.0, 4.0, 0.25, 100.0, 1.0E-6, 12345.678];

        Assert.Multiple(() => {
            for (int i = 0; i < inputs.Length; i++) {
                Assert.That(Mth.FastInvSqrt(inputs[i]), Is.EqualTo(ExpectedFastInvSqrt[i]), $"1/sqrt({inputs[i]})");
            }
        });
    }

    /// <summary>Both sides of every wrap boundary, plus angles well outside one turn.</summary>
    private static readonly float[] DegreesCases = [
        0.0f, 1.0f, 179.9f, 180.0f, 180.1f, 359.0f, 360.0f, 540.0f, 720.5f,
        -0.5f, -179.9f, -180.0f, -180.1f, -360.0f, -540.0f, 1e7f
    ];

    /// <summary>
    /// Note 180 wraps to -180 rather than staying put: vanilla's test is <c>&gt;= 180</c>, so the
    /// range is [-180, 180).
    /// </summary>
    private static readonly float[] ExpectedWrapFloat = [
        0.0f, 1.0f, 179.9f, -180.0f, -179.9f, -1.0f, 0.0f, -180.0f, 0.5f,
        -0.5f, -179.9f, -180.0f, 179.9f, -0.0f, -180.0f, -80.0f
    ];

    /// <summary>
    /// The double overload widens the same literals first, so its answers are the float inputs'
    /// exact values rather than the float results. Anything mixing the two drifts.
    /// </summary>
    private static readonly double[] ExpectedWrapDouble = [
        0.0, 1.0, 179.89999389648438, -180.0, -179.89999389648438, -1.0, 0.0, -180.0, 0.5,
        -0.5, -179.89999389648438, -180.0, 179.89999389648438, -0.0, -180.0, -80.0
    ];

    private static readonly float[] ExpectedDifferenceFrom170 = [
        -170.0f, -169.0f, 9.899994f, 10.0f, 10.100006f, -171.0f, -170.0f, 10.0f, -169.5f,
        -170.5f, 10.100006f, 10.0f, 9.899994f, -170.0f, 10.0f, 110.0f
    ];

    private static readonly float[] ExpectedRotateIfNecessary = [
        10.0f, 10.0f, 149.9f, 150.0f, 150.1f, 370.0f, 370.0f, 510.0f, 730.0f,
        10.0f, -209.9f, -210.0f, -210.1f, -350.0f, -570.0f, 1.000003E7f
    ];

    private static readonly float[] ExpectedApproachDegrees = [
        0.0f, 1.0f, 40.0f, 40.0f, 40.0f, -1.0f, 0.0f, 40.0f, 0.5f,
        -0.5f, 40.0f, 40.0f, 40.0f, 0.0f, 40.0f, -20.0f
    ];

    private static readonly float[] ExpectedRotLerp = [
        119.0f, 119.3f, 172.97f, 173.0f, 173.03f, 118.7f, 119.0f, 173.0f, 119.149994f,
        118.85f, 173.03f, 173.0f, 172.97f, 119.0f, 173.0f, 203.0f
    ];

    [Test]
    public void TestDegreeHelpersMatchVanilla() {
        Assert.Multiple(() => {
            for (int i = 0; i < DegreesCases.Length; i++) {
                float degrees = DegreesCases[i];
                Assert.That(Mth.WrapDegrees(degrees), Is.EqualTo(ExpectedWrapFloat[i]), $"WrapDegrees({degrees}f)");
                Assert.That(Mth.WrapDegrees((double)degrees), Is.EqualTo(ExpectedWrapDouble[i]),
                    $"WrapDegrees({degrees}d)");
                Assert.That(Mth.DegreesDifference(170.0f, degrees), Is.EqualTo(ExpectedDifferenceFrom170[i]),
                    $"DegreesDifference(170, {degrees})");
                Assert.That(Mth.RotateIfNecessary(10.0f, degrees, 30.0f), Is.EqualTo(ExpectedRotateIfNecessary[i]),
                    $"RotateIfNecessary(10, {degrees}, 30)");
                Assert.That(Mth.ApproachDegrees(10.0f, degrees, 30.0f), Is.EqualTo(ExpectedApproachDegrees[i]),
                    $"ApproachDegrees(10, {degrees}, 30)");
                Assert.That(Mth.RotLerp(0.3f, 170.0f, degrees), Is.EqualTo(ExpectedRotLerp[i]),
                    $"RotLerp(0.3, 170, {degrees})");
            }
        });
    }

    /// <summary>
    /// <c>Goal.adjustedTickDelay</c> halves a cadence with this, so a negative numerator has to round
    /// vanilla's way and not C# integer division's way.
    /// </summary>
    [Test]
    public void TestPositiveCeilDivMatchesVanilla() {
        int[][] cases = [[0, 2], [1, 2], [2, 2], [3, 2], [4, 2], [-1, 2], [-3, 2], [7, 3], [-7, 3], [20, 7]];
        int[] expected = [0, 1, 1, 2, 2, 0, -1, 3, -2, 3];

        Assert.Multiple(() => {
            for (int i = 0; i < cases.Length; i++) {
                Assert.That(Mth.PositiveCeilDiv(cases[i][0], cases[i][1]), Is.EqualTo(expected[i]),
                    $"PositiveCeilDiv({cases[i][0]}, {cases[i][1]})");
            }
        });
    }
}

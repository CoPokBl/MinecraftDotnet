using Minecraft.Schemas.Vec;

namespace Minecraft.Testing.Schemas.Vec;

public class LpVec3Test {

    private static Vec3<double> RoundTrip(Vec3<double> value) {
        return new DataReader(new DataWriter().WriteLpVec3(value).ToArray()).ReadLpVec3();
    }

    private static int WrittenLength(Vec3<double> value) {
        return new DataWriter().WriteLpVec3(value).ToArray().Length;
    }

    [Test]
    public void TestZeroIsASingleByte() {
        Vec3<double> zero = new(0, 0, 0);
        Assert.That(WrittenLength(zero), Is.EqualTo(1));
        Assert.That(RoundTrip(zero), Is.EqualTo(zero));
    }

    [Test]
    public void TestValuesBelowMinimumBecomeZero() {
        // Anything smaller than the minimum representable magnitude collapses to zero
        Vec3<double> tiny = new(LpVec3.AbsMinValue / 2, 0, 0);
        Assert.That(WrittenLength(tiny), Is.EqualTo(1));
        Assert.That(RoundTrip(tiny), Is.EqualTo(new Vec3<double>(0, 0, 0)));
    }

    [Test]
    public void TestSmallScaleFitsInTheHeader() {
        // A scale of 3 fits in the header's 2 bits, so no continuation VarInt is written
        Vec3<double> value = new(1.5, -2.25, 0.75);
        Assert.That(WrittenLength(value), Is.EqualTo(6));

        Vec3<double> redone = RoundTrip(value);
        Assert.Multiple(() => {
            Assert.That(redone.X, Is.EqualTo(value.X).Within(0.001));
            Assert.That(redone.Y, Is.EqualTo(value.Y).Within(0.001));
            Assert.That(redone.Z, Is.EqualTo(value.Z).Within(0.001));
        });
    }

    [Test]
    public void TestLargeScaleWritesContinuation() {
        // A scale this big needs the continuation VarInt on top of the 6 byte body
        Vec3<double> value = new(1000.5, -2000.25, 500.0);
        Assert.That(WrittenLength(value), Is.GreaterThan(6));

        Vec3<double> redone = RoundTrip(value);
        Assert.Multiple(() => {
            Assert.That(redone.X, Is.EqualTo(value.X).Within(0.2));
            Assert.That(redone.Y, Is.EqualTo(value.Y).Within(0.2));
            Assert.That(redone.Z, Is.EqualTo(value.Z).Within(0.2));
        });
    }

    [Test]
    public void TestNaNIsTreatedAsZero() {
        Vec3<double> redone = RoundTrip(new Vec3<double>(double.NaN, 1.0, 0));
        Assert.Multiple(() => {
            Assert.That(redone.X, Is.EqualTo(0).Within(0.001));
            Assert.That(redone.Y, Is.EqualTo(1.0).Within(0.001));
        });
    }

    [Test]
    public void TestValuesAreClampedToTheMaximum() {
        Vec3<double> redone = RoundTrip(new Vec3<double>(LpVec3.AbsMaxValue * 10, 0, 0));
        Assert.That(redone.X, Is.EqualTo(LpVec3.AbsMaxValue).Within(LpVec3.AbsMaxValue * 0.001));
    }

    // Encodings taken from the vanilla server, so that the quantisation stays byte for byte
    // compatible with what the client sends and expects.
    [TestCase(0, 0, 0, "00")]
    [TestCase(1.5, -2.25, 0.75, "fbff9ffe4002")]
    [TestCase(1000.5, -2000.25, 500.0, "fdff9ffa001af403")]
    [TestCase(0.0000001, 0, 0, "00")]
    [TestCase(double.NaN, 1.0, 0, "f9ff7ffffff9")]
    [TestCase(-0.5, -0.5, -0.5, "010040008001")]
    [TestCase(3.0, 3.0, 3.0, "f3fffffdfffb")]
    [TestCase(4.0, 0.1, -0.1, "f4ff7ccb066701")]
    [TestCase(17179869183.0, 0, 0, "f7ff7ffeffffffffffff0f")]
    [TestCase(0.001, -0.002, 0.003, "79008060ff7a")]
    public void TestMatchesVanillaEncoding(double x, double y, double z, string expected) {
        byte[] written = new DataWriter().WriteLpVec3(new Vec3<double>(x, y, z)).ToArray();
        Assert.That(Convert.ToHexString(written).ToLowerInvariant(), Is.EqualTo(expected));
    }
}

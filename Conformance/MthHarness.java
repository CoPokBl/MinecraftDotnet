import net.minecraft.util.Mth;
import net.minecraft.util.RandomSource;
import net.minecraft.world.level.levelgen.LegacyRandomSource;

/**
 * Prints what vanilla's Mth and LegacyRandomSource actually answer, for the fixtures in
 * Minecraft.Testing/Schemas/MthTest.cs and RandomSourceTest.cs.
 *
 * Unlike TravelHarness beside it this one really does drive vanilla: Mth is static and
 * LegacyRandomSource needs nothing but a seed, so every number below came out of the jar rather than
 * out of a transcription. That makes it the thing that decides whether the ports are right, because
 * neither is something our own tests could otherwise check: Mth.atan2 is an approximation with its own
 * error, and a random generator agrees with any test written against it.
 *
 * Run it with Conformance/mth.sh and paste the arrays it prints into the tests.
 */
public class MthHarness {
    public static void main(String[] args) {
        atan2();
        degrees();
        misc();
        random();
    }

    /** Chosen to cover every branch: both signs of each argument, and both sides of the swap. */
    static final double[][] ATAN2_CASES = {
        {0.0, 1.0}, {1.0, 0.0}, {1.0, 1.0}, {-1.0, 1.0}, {1.0, -1.0}, {-1.0, -1.0},
        {0.5, 2.0}, {2.0, 0.5}, {-0.5, 2.0}, {2.0, -0.5}, {-2.0, -0.5}, {-0.5, -2.0},
        {1.0E-8, 1.0}, {1.0, 1.0E-8}, {123.456, -78.9}, {-0.001, 0.002}, {0.0, -1.0}, {0.0, 0.0}
    };

    static void atan2() {
        System.out.println("== atan2 (y, x) ==");
        StringBuilder out = new StringBuilder();
        for (double[] c : ATAN2_CASES) {
            double v = Mth.atan2(c[0], c[1]);
            System.out.println("  atan2(" + c[0] + ", " + c[1] + ") = " + v
                + "   (Math.atan2 = " + Math.atan2(c[0], c[1]) + ")");
            out.append(v).append(", ");
        }
        System.out.println("  [" + out + "]");
    }

    static final float[] DEGREES_CASES = {
        0.0f, 1.0f, 179.9f, 180.0f, 180.1f, 359.0f, 360.0f, 540.0f, 720.5f,
        -0.5f, -179.9f, -180.0f, -180.1f, -360.0f, -540.0f, 1e7f
    };

    static void degrees() {
        System.out.println("== wrapDegrees(float) ==");
        StringBuilder out = new StringBuilder();
        for (float f : DEGREES_CASES) {
            out.append(Mth.wrapDegrees(f)).append("f, ");
        }
        System.out.println("  [" + out + "]");

        System.out.println("== wrapDegrees(double) ==");
        out = new StringBuilder();
        for (float f : DEGREES_CASES) {
            out.append(Mth.wrapDegrees((double) f)).append(", ");
        }
        System.out.println("  [" + out + "]");

        System.out.println("== degreesDifference(from=170, to) ==");
        out = new StringBuilder();
        for (float f : DEGREES_CASES) {
            out.append(Mth.degreesDifference(170.0f, f)).append("f, ");
        }
        System.out.println("  [" + out + "]");

        System.out.println("== rotateIfNecessary(toRotate=10, target, maxDelta=30) ==");
        out = new StringBuilder();
        for (float f : DEGREES_CASES) {
            out.append(Mth.rotateIfNecessary(10.0f, f, 30.0f)).append("f, ");
        }
        System.out.println("  [" + out + "]");

        System.out.println("== approachDegrees(value=10, target, step=30) ==");
        out = new StringBuilder();
        for (float f : DEGREES_CASES) {
            out.append(Mth.approachDegrees(10.0f, f, 30.0f)).append("f, ");
        }
        System.out.println("  [" + out + "]");

        System.out.println("== rotLerp(0.3, start=170, end) ==");
        out = new StringBuilder();
        for (float f : DEGREES_CASES) {
            out.append(Mth.rotLerp(0.3f, 170.0f, f)).append("f, ");
        }
        System.out.println("  [" + out + "]");
    }

    static void misc() {
        System.out.println("== positiveCeilDiv ==");
        int[][] cases = {{0, 2}, {1, 2}, {2, 2}, {3, 2}, {4, 2}, {-1, 2}, {-3, 2}, {7, 3}, {-7, 3}, {20, 7}};
        StringBuilder out = new StringBuilder();
        for (int[] c : cases) {
            out.append(Mth.positiveCeilDiv(c[0], c[1])).append(", ");
        }
        System.out.println("  [" + out + "]");

        System.out.println("== fastInvSqrt ==");
        out = new StringBuilder();
        for (double d : new double[] {1.0, 2.0, 4.0, 0.25, 100.0, 1.0E-6, 12345.678}) {
            out.append(Mth.fastInvSqrt(d)).append(", ");
        }
        System.out.println("  [" + out + "]");
    }

    static void random() {
        System.out.println("== LegacyRandomSource(1234) ==");
        RandomSource r = new LegacyRandomSource(1234L);
        StringBuilder ints = new StringBuilder();
        for (int i = 0; i < 8; i++) ints.append(r.nextInt()).append(", ");
        System.out.println("  nextInt():        [" + ints + "]");

        r = new LegacyRandomSource(1234L);
        StringBuilder bounded = new StringBuilder();
        // 16 is a power of two (the multiply-shift branch), 10 and 7 are not (the rejection loop).
        for (int i = 0; i < 8; i++) bounded.append(r.nextInt(16)).append(", ");
        for (int i = 0; i < 8; i++) bounded.append(r.nextInt(10)).append(", ");
        for (int i = 0; i < 8; i++) bounded.append(r.nextInt(7)).append(", ");
        System.out.println("  nextInt(16/10/7): [" + bounded + "]");

        r = new LegacyRandomSource(1234L);
        StringBuilder floats = new StringBuilder();
        for (int i = 0; i < 8; i++) floats.append(r.nextFloat()).append("f, ");
        System.out.println("  nextFloat():      [" + floats + "]");

        r = new LegacyRandomSource(1234L);
        StringBuilder doubles = new StringBuilder();
        for (int i = 0; i < 8; i++) doubles.append(r.nextDouble()).append(", ");
        System.out.println("  nextDouble():     [" + doubles + "]");

        r = new LegacyRandomSource(1234L);
        StringBuilder longs = new StringBuilder();
        for (int i = 0; i < 4; i++) longs.append(r.nextLong()).append("L, ");
        System.out.println("  nextLong():       [" + longs + "]");

        r = new LegacyRandomSource(1234L);
        StringBuilder bools = new StringBuilder();
        for (int i = 0; i < 12; i++) bools.append(r.nextBoolean()).append(", ");
        System.out.println("  nextBoolean():    [" + bools + "]");

        r = new LegacyRandomSource(1234L);
        StringBuilder gauss = new StringBuilder();
        for (int i = 0; i < 6; i++) gauss.append(r.nextGaussian()).append(", ");
        System.out.println("  nextGaussian():   [" + gauss + "]");

        // A negative seed, since the scramble and the sign of the shift are where a port goes wrong.
        r = new LegacyRandomSource(-987654321L);
        StringBuilder neg = new StringBuilder();
        for (int i = 0; i < 6; i++) neg.append(r.nextInt()).append(", ");
        System.out.println("  seed -987654321:  [" + neg + "]");

        // Reseeding must throw the spare gaussian away.
        r = new LegacyRandomSource(1234L);
        double first = r.nextGaussian();
        r.setSeed(1234L);
        System.out.println("  gaussian resets:  " + first + " then " + r.nextGaussian());
    }
}

import java.lang.reflect.Method;
import net.minecraft.util.Mth;
import net.minecraft.world.entity.ai.control.MoveControl;

/**
 * Prints what vanilla's MoveControl decides, for the fixtures in ManagedServer.Testing/Ai/MoveControlTest.cs.
 *
 * MoveControl.tick needs a live Mob and a level, which is out of reach for the same reason
 * FlowingFluid.spread is. What is reachable is the arithmetic, and the arithmetic is where every
 * mistake in the port would be:
 *
 *   - rotlerp is a protected instance method, so it is called reflectively on an allocated but
 *     uninitialised MoveControl (it touches no field). It is the 90 degree per tick cap and the single
 *     add/subtract wrap, which is not the same function as Mth.wrapDegrees.
 *   - the wanted yaw is (float)(Mth.atan2(zd, xd) * 180.0F / (float)Math.PI) - 90.0F. Two operations
 *     in double against the float pi, not one multiply by a folded radians constant; folding them
 *     moves the last bits. Driving it here is what proves the shape was kept.
 *   - MIN_SPEED_SQR is read off the class rather than recomputed, since it is a float field compared
 *     against a double and squaring 5.0E-4f here would land somewhere else.
 *
 * Run it with Conformance/movecontrol.sh and paste the arrays it prints into the test.
 */
public class MoveControlHarness {
    public static void main(String[] args) throws Exception {
        minSpeedSqr();
        rotlerp();
        wantedYaw();
    }

    static void minSpeedSqr() throws Exception {
        java.lang.reflect.Field f = MoveControl.class.getDeclaredField("MIN_SPEED_SQR");
        f.setAccessible(true);
        float raw = (Float)f.get(null);
        System.out.println("== MIN_SPEED_SQR ==");
        System.out.println("  as declared (float): " + raw);
        // tick() compares a double against it, so this widening is the number that decides.
        System.out.println("  as compared (double): " + (double)raw);
        System.out.println();
    }

    /** current, target, maxDelta. The maxDelta MoveControl.tick uses is always 90. */
    static final float[][] ROTLERP_CASES = {
        {0.0f, 0.0f, 90.0f},
        {0.0f, 45.0f, 90.0f},
        {0.0f, 180.0f, 90.0f},
        {0.0f, -180.0f, 90.0f},
        {0.0f, 179.0f, 90.0f},
        {0.0f, -179.0f, 90.0f},
        {170.0f, -170.0f, 90.0f},
        {-170.0f, 170.0f, 90.0f},
        {350.0f, 10.0f, 90.0f},
        {10.0f, 350.0f, 90.0f},
        {0.0f, 30.0f, 10.0f},
        {0.0f, -30.0f, 10.0f},
        {359.0f, 5.0f, 90.0f},
        {-359.0f, -5.0f, 90.0f},
        {720.0f, 0.0f, 90.0f},
        {-720.0f, 0.0f, 90.0f},
        {45.5f, 46.25f, 90.0f}
    };

    static void rotlerp() throws Exception {
        Method m = MoveControl.class.getDeclaredMethod("rotlerp", float.class, float.class, float.class);
        m.setAccessible(true);

        // rotlerp reads no field, so an instance that was never constructed is enough and we avoid
        // needing a Mob. Unsafe.allocateInstance is the only way to get one without the constructor.
        MoveControl control = (MoveControl)allocate(MoveControl.class);

        System.out.println("== rotlerp(current, target, maxDelta) ==");
        StringBuilder out = new StringBuilder();
        for (float[] c : ROTLERP_CASES) {
            float v = (Float)m.invoke(control, c[0], c[1], c[2]);
            System.out.println("  rotlerp(" + c[0] + ", " + c[1] + ", " + c[2] + ") = " + v);
            out.append(v).append("f, ");
        }
        System.out.println("  { " + out + "}");
        System.out.println();
    }

    /** dx, dz as MoveControl.tick computes them: wantedX - getX(), wantedZ - getZ(). */
    static final double[][] YAW_CASES = {
        {1.0, 0.0}, {0.0, 1.0}, {-1.0, 0.0}, {0.0, -1.0},
        {1.0, 1.0}, {-1.0, 1.0}, {1.0, -1.0}, {-1.0, -1.0},
        {8.0, 3.0}, {-8.0, 3.0}, {0.25, -7.5}, {123.456, -78.9},
        {1.0E-4, 1.0E-4}, {0.0, 0.0}
    };

    @SuppressWarnings("unchecked")
    static Object allocate(Class<?> type) throws Exception {
        java.lang.reflect.Field f = sun.misc.Unsafe.class.getDeclaredField("theUnsafe");
        f.setAccessible(true);
        return ((sun.misc.Unsafe)f.get(null)).allocateInstance(type);
    }

    static void wantedYaw() {
        System.out.println("== wanted yaw, (float)(Mth.atan2(zd, xd) * 180.0F / (float)Math.PI) - 90.0F ==");
        StringBuilder out = new StringBuilder();
        for (double[] c : YAW_CASES) {
            double dx = c[0];
            double dz = c[1];
            float v = (float)(Mth.atan2(dz, dx) * 180.0F / (float)Math.PI) - 90.0F;
            System.out.println("  dx=" + dx + " dz=" + dz + " -> " + v
                + "   (accurate would be " + ((float)(Math.atan2(dz, dx) * (180.0 / Math.PI)) - 90.0F) + ")");
            out.append(v).append("f, ");
        }
        System.out.println("  { " + out + "}");
        System.out.println();
    }
}

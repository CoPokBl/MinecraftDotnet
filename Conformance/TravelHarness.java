import net.minecraft.util.Mth;

/**
 * Regenerates the expected positions in ManagedServer.Testing/Physics/EntityTravelInputTest.cs:
 * a living entity walking forward on a flat floor, on stone and on ice.
 *
 * READ THIS BEFORE TRUSTING IT. Unlike the other harnesses beside it, this one does NOT drive
 * vanilla code. A LivingEntity cannot be constructed without a ServerLevel, which CLAUDE.md already
 * lists as out of reach, so the loop below is a transcription of LivingEntity.aiStep,
 * travelInAir and Entity.moveRelative, with the collision resolve cut down to the single flat floor
 * plane the test world has.
 *
 * What it therefore pins is the arithmetic: vanilla's real Mth sine table, and the order the float
 * terms are multiplied in before they widen, which is where a port actually drifts. It does not pin
 * the method structure, and it cannot: that has to be diffed against the jar by eye. Keep this file
 * and the C# side in step, because nothing checks that they agree except the test passing.
 *
 * Run it with Conformance/travel.sh and paste the two arrays it prints into the test.
 */
public class TravelHarness {
    static final float MOVEMENT_SPEED = 0.23000000417232513f;   // zombie's default attribute
    static final double GRAVITY = 0.08;                          // minecraft:gravity default
    static final double MIN_MOVEMENT = 0.003;
    static final double FLOOR_TOP = 65.0;

    public static void main(String[] args) {
        run("stone", 0.6f);
        run("ice", 0.98f);
    }

    static void run(String name, float blockFriction) {
        double y = FLOOR_TOP, z = 8.5;   // the test spawns it here, and the accumulation rounds from it
        double vy = 0.0, vz = 0.0;
        float xxa = 0.0f, zza = 1.0f;
        float speed = MOVEMENT_SPEED;
        float yaw = 0.0f;                     // facing +Z
        boolean onGround = true;              // the test spawns it resting on the floor

        System.out.println("== " + name + " (friction " + blockFriction + ") ==");
        StringBuilder zs = new StringBuilder();
        for (int tick = 0; tick < 12; tick++) {
            // --- aiStep: MIN_MOVEMENT_DISTANCE clamp, then applyInput ---
            if (Math.abs(vz) < MIN_MOVEMENT) vz = 0.0;
            if (Math.abs(vy) < MIN_MOVEMENT) vy = 0.0;
            xxa *= 0.98f;
            zza *= 0.98f;

            // --- travelInAir ---
            float friction = onGround ? blockFriction : 1.0f;
            float influenced = getFrictionInfluencedSpeed(speed, blockFriction, onGround);

            // Entity.moveRelative + getInputVector.
            double ix = xxa, iz = zza;
            double lenSqr = ix * ix + iz * iz;
            if (lenSqr >= 1.0E-7) {
                if (lenSqr > 1.0) {
                    double len = Math.sqrt(lenSqr);
                    ix /= len; iz /= len;
                }
                ix *= influenced; iz *= influenced;
                float sin = Mth.sin(yaw * ((float) Math.PI / 180F));
                float cos = Mth.cos(yaw * ((float) Math.PI / 180F));
                vz += iz * cos + ix * sin;
            }

            // Entity.move against a flat floor plane.
            double wantedY = y + vy;
            // Only the floor can be hit in the test world, so a collision is a landing and nothing else.
            boolean verticalCollision = wantedY < FLOOR_TOP;
            if (verticalCollision) {
                wantedY = FLOOR_TOP;
            }
            z += vz;
            boolean below = verticalCollision && vy < 0.0;
            y = wantedY;
            onGround = below;
            if (verticalCollision) vy = 0.0;

            // gravity after the move, then drag
            vy -= GRAVITY;
            float airDrag = 0.91f;
            float horizontal = friction * airDrag;
            vz *= horizontal;
            vy *= 0.98f;

            zs.append(z).append(", ");
            System.out.println("  " + tick + ": z=" + z + " onGround=" + onGround);
        }
        System.out.println("  [" + zs + "]");
    }

    static float getFrictionInfluencedSpeed(float speed, float blockFriction, boolean onGround) {
        if (!onGround) return 0.02f;                     // getFlyingSpeed
        return (double) blockFriction > 0.6
                ? speed * (0.21600002f / (blockFriction * blockFriction * blockFriction))
                : speed;
    }
}

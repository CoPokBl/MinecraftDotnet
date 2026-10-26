import net.minecraft.SharedConstants;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.Mirror;
import net.minecraft.world.level.block.Rotation;
import net.minecraft.world.level.block.state.BlockState;

import java.io.BufferedOutputStream;
import java.io.DataOutputStream;
import java.io.FileOutputStream;
import java.util.zip.GZIPOutputStream;

/**
 * Puts every block state in the game through vanilla's own {@code rotate} and {@code mirror} and
 * writes what came back.
 *
 * <p>This is the only thing standing behind {@code BlockStateTransform}, which is written per
 * property where vanilla writes 65 overrides per block class. A block class whose rule is not one of
 * the handful that side implements comes back unturned, which looks exactly like a block that has no
 * rule, so nothing on our side of the fence can tell the two apart.
 *
 * <p>Identity entries are dropped: most of the game does not turn at all, and writing those out
 * would be a megabyte saying nothing. A state missing from the fixture is asserted to be unchanged
 * by all five transforms, so the omission is checked rather than assumed.
 */
public final class BlockTransformHarness {
    private static final Rotation[] ROTATIONS = {
        Rotation.CLOCKWISE_90, Rotation.CLOCKWISE_180, Rotation.COUNTERCLOCKWISE_90
    };

    private static final Mirror[] MIRRORS = { Mirror.LEFT_RIGHT, Mirror.FRONT_BACK };

    public static void main(String[] args) throws Exception {
        if (args.length < 1) {
            System.err.println("usage: BlockTransformHarness <output>");
            System.exit(2);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        int states = 0;
        int written = 0;

        try (DataOutputStream out = new DataOutputStream(new BufferedOutputStream(
                new GZIPOutputStream(new FileOutputStream(args[0]))))) {

            for (Block block : BuiltInRegistries.BLOCK) {
                for (BlockState state : block.getStateDefinition().getPossibleStates()) {
                    states++;

                    int id = Block.getId(state);
                    int[] results = new int[ROTATIONS.length + MIRRORS.length];
                    boolean moved = false;

                    for (int i = 0; i < ROTATIONS.length; i++) {
                        results[i] = Block.getId(state.rotate(ROTATIONS[i]));
                        moved |= results[i] != id;
                    }

                    for (int i = 0; i < MIRRORS.length; i++) {
                        int at = ROTATIONS.length + i;
                        results[at] = Block.getId(state.mirror(MIRRORS[i]));
                        moved |= results[at] != id;
                    }

                    if (!moved) {
                        continue;
                    }

                    out.writeInt(id);

                    for (int result : results) {
                        out.writeInt(result);
                    }

                    written++;
                }
            }
        }

        System.out.printf("%d states, %d of which move under some transform%n", states, written);
    }
}

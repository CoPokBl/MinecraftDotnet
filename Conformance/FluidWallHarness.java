import java.io.DataOutputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.zip.GZIPOutputStream;

import net.minecraft.SharedConstants;
import net.minecraft.core.BlockPos;
import net.minecraft.core.Direction;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.EmptyBlockGetter;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.phys.shapes.Shapes;
import net.minecraft.world.phys.shapes.VoxelShape;

/**
 * Answers {@code FlowingFluid.canPassThroughWall} for every pair of distinct collision shapes in the
 * game, and writes the answers into the fixture FluidWallConformanceTest replays.
 * <p>
 * Every other part of the fluid port is a transcription of a vanilla method and reads like one. This
 * one is not: vanilla asks whether two touching faces close the boundary between them by merging two
 * voxel shapes and testing the union, and there is no voxel shape on the C# side to merge, so the
 * question is answered from the boxes instead. Nothing in our own tests can tell a rule derived from
 * the boxes from the rule the game applies, which is what this is for.
 * <p>
 * One state per distinct collision shape is enough: the answer depends on the two shapes and the
 * direction and on nothing else, so two states that collide the same way cannot disagree.
 * <p>
 * Compiled and run by Conformance/fluid-wall.sh.
 */
public final class FluidWallHarness {
    public static void main(String[] args) throws Exception {
        if (args.length != 1) {
            System.err.println("Usage: FluidWallHarness <output-file>");
            System.exit(1);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        List<Integer> states = representatives();

        try (OutputStream raw = Files.newOutputStream(Path.of(args[0]));
             GZIPOutputStream zipped = new GZIPOutputStream(raw);
             DataOutputStream out = new DataOutputStream(zipped)) {
            out.writeBytes("MCFLUIDWALL2");

            out.writeInt(ORIGINS.length);
            for (BlockPos origin : ORIGINS) {
                out.writeInt(origin.getX());
                out.writeInt(origin.getY());
                out.writeInt(origin.getZ());
            }

            out.writeInt(states.size());
            for (int state : states) {
                out.writeInt(state);
            }

            // The pairs are the whole cross product in a fixed order, so only the answers travel: one
            // bit each, origin major, then source, then target, then direction. Our BlockFace has the
            // same order as Direction, so the ordinal is the index on both sides.
            int answers = ORIGINS.length * states.size() * states.size() * Direction.values().length;
            out.writeInt(answers);

            int bits = 0;
            int filled = 0;
            for (BlockPos origin : ORIGINS) {
                for (int source : states) {
                    BlockState sourceState = Block.BLOCK_STATE_REGISTRY.byId(source);
                    for (int target : states) {
                        BlockState targetState = Block.BLOCK_STATE_REGISTRY.byId(target);
                        for (Direction direction : Direction.values()) {
                            if (canPassThroughWall(direction, origin, sourceState, origin.relative(direction), targetState)) {
                                bits |= 1 << filled;
                            }

                            if (++filled == 8) {
                                out.writeByte(bits);
                                bits = 0;
                                filled = 0;
                            }
                        }
                    }
                }
            }

            if (filled > 0) {
                out.writeByte(bits);
            }

            System.out.println("Wrote " + states.size() + " shapes at " + ORIGINS.length
                    + " positions, " + answers + " answers, to " + args[0]);
        }
    }

    /**
     * Where the pair is stood. A block whose shape is moved by a hash of its position answers
     * differently depending on where it is, so more than one position is needed to see that at all:
     * the origin is the one place the offset is exactly minus the block's maximum, which is a corner
     * case rather than a representative one.
     */
    private static final BlockPos[] ORIGINS = {
            BlockPos.ZERO,
            new BlockPos(13, 64, -7),
            new BlockPos(-25, 31, 42),
            new BlockPos(101, 5, 98),
    };

    /** One state id per distinct collision shape, in state id order. */
    private static List<Integer> representatives() {
        Map<String, Integer> byShape = new LinkedHashMap<>();

        for (BlockState state : Block.BLOCK_STATE_REGISTRY) {
            VoxelShape shape;
            try {
                shape = state.getCollisionShape(EmptyBlockGetter.INSTANCE, BlockPos.ZERO);
            } catch (RuntimeException e) {
                continue;  // a shape that needs a real level is not one a fixture can describe
            }

            // The identity of Shapes.block() and Shapes.empty() is part of the rule, so it is part of
            // the key rather than something the boxes alone would capture.
            String key = (shape == Shapes.block() ? "BLOCK " : shape == Shapes.empty() ? "EMPTY " : "")
                    + shape.toAabbs();
            byShape.putIfAbsent(key, Block.BLOCK_STATE_REGISTRY.getId(state));
        }

        return new ArrayList<>(byShape.values());
    }

    /** {@code FlowingFluid.canPassThroughWall}, without its debug flags and its cache. */
    private static boolean canPassThroughWall(Direction direction, BlockPos sourcePos, BlockState sourceState,
                                              BlockPos targetPos, BlockState targetState) {
        VoxelShape targetShape = targetState.getCollisionShape(EmptyBlockGetter.INSTANCE, targetPos);
        if (targetShape == Shapes.block()) {
            return false;
        }

        VoxelShape sourceShape = sourceState.getCollisionShape(EmptyBlockGetter.INSTANCE, sourcePos);
        if (sourceShape == Shapes.block()) {
            return false;
        }

        if (sourceShape == Shapes.empty() && targetShape == Shapes.empty()) {
            return true;
        }

        return !Shapes.mergedFaceOccludes(sourceShape, targetShape, direction);
    }
}

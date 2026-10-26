import java.io.DataOutputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Random;
import java.util.zip.GZIPOutputStream;

import net.minecraft.SharedConstants;
import net.minecraft.core.BlockPos;
import net.minecraft.core.Direction;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.BlockGetter;
import net.minecraft.world.level.ClipContext;
import net.minecraft.world.level.EmptyBlockGetter;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.Blocks;
import net.minecraft.world.level.block.entity.BlockEntity;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.material.FluidState;
import net.minecraft.world.phys.BlockHitResult;
import net.minecraft.world.phys.HitResult;
import net.minecraft.world.phys.Vec3;
import net.minecraft.world.phys.shapes.CollisionContext;
import net.minecraft.world.phys.shapes.VoxelShape;
import org.jspecify.annotations.Nullable;

/**
 * Runs the real {@code BlockGetter.clip} over one block state per distinct pickable shape, from a fan
 * of rays, and writes what it decided into the fixture ClipConformanceTest replays.
 * <p>
 * This is what holds the C# port of the clip honest. Three parts of it are invisible to our own tests:
 * it reads the outline shape rather than the collision shape, the face of a hit comes from the box that
 * was struck rather than from the block boundary the ray crossed, and the interaction shape can replace
 * that face without moving the hit. A port can get all three wrong, stay perfectly self consistent, and
 * put a bucket of water one block away from where the game would.
 * <p>
 * Both fluid modes are covered, since a filled bucket looks with NONE and an empty one with SOURCE_ONLY
 * and they are different clips over the same scene.
 * <p>
 * Compiled and run by Conformance/clip.sh.
 */
public final class ClipHarness {
    public static void main(String[] args) throws Exception {
        if (args.length != 1) {
            System.err.println("Usage: ClipHarness <output-file>");
            System.exit(1);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        List<Integer> states = representatives();
        double[][] rays = rays();

        try (OutputStream raw = Files.newOutputStream(Path.of(args[0]));
             GZIPOutputStream zipped = new GZIPOutputStream(raw);
             DataOutputStream out = new DataOutputStream(zipped)) {
            out.writeBytes("MCCLIP1");

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

            // Rays are relative to the block being aimed at, so one set covers every origin.
            out.writeInt(rays.length);
            for (double[] ray : rays) {
                for (double v : ray) {
                    out.writeDouble(v);
                }
            }

            int written = 0;
            for (BlockPos origin : ORIGINS) {
                for (int id : states) {
                    BlockState state = Block.BLOCK_STATE_REGISTRY.byId(id);
                    BlockGetter level = new SingleBlock(origin, state);

                    for (double[] ray : rays) {
                        Vec3 from = new Vec3(origin.getX() + ray[0], origin.getY() + ray[1], origin.getZ() + ray[2]);
                        Vec3 to = new Vec3(origin.getX() + ray[3], origin.getY() + ray[4], origin.getZ() + ray[5]);

                        for (ClipContext.Fluid fluid : FLUID_MODES) {
                            BlockHitResult hit = level.clip(
                                    new ClipContext(from, to, ClipContext.Block.OUTLINE, fluid, CollisionContext.empty()));

                            if (hit.getType() == HitResult.Type.MISS) {
                                out.writeByte(0);
                            } else {
                                out.writeByte(1);
                                out.writeInt(hit.getBlockPos().getX());
                                out.writeInt(hit.getBlockPos().getY());
                                out.writeInt(hit.getBlockPos().getZ());
                                out.writeByte(hit.getDirection().ordinal());
                            }

                            written++;
                        }
                    }
                }
            }

            System.out.println("Wrote " + states.size() + " shapes at " + ORIGINS.length + " positions, "
                    + rays.length + " rays, " + written + " clips, to " + args[0]);
        }
    }

    private static final ClipContext.Fluid[] FLUID_MODES = { ClipContext.Fluid.NONE, ClipContext.Fluid.SOURCE_ONLY };

    /**
     * Where the block is stood. A shape moved by a hash of its position clips differently depending on
     * where it is, and the offset at the origin is a corner case rather than a representative one, so
     * the same set of awkward positions the fluid wall harness uses is used here.
     */
    private static final BlockPos[] ORIGINS = {
            BlockPos.ZERO,
            new BlockPos(13, 64, -7),
            new BlockPos(-25, 31, 42),
            new BlockPos(101, 5, 98),
    };

    /**
     * One state id per distinct combination of the things the clip reads. Two states that present the
     * same outline, the same interaction shape and the same fluid cannot clip differently, and there
     * are far too many states to run the whole registry through a fan of rays.
     */
    private static List<Integer> representatives() {
        Map<String, Integer> byShape = new LinkedHashMap<>();

        for (BlockState state : Block.BLOCK_STATE_REGISTRY) {
            String key;
            try {
                VoxelShape outline = state.getShape(EmptyBlockGetter.INSTANCE, BlockPos.ZERO);
                VoxelShape interaction = state.getInteractionShape(EmptyBlockGetter.INSTANCE, BlockPos.ZERO);
                FluidState fluid = state.getFluidState();
                key = outline.toAabbs() + "|" + interaction.toAabbs()
                        + "|" + fluid.getType() + "|" + fluid.getAmount() + "|" + fluid.isSource()
                        + "|" + state.getBlock().hasDynamicShape() + "|" + state.hasOffsetFunction();
            } catch (RuntimeException e) {
                continue;  // a shape that needs a real level is not one a fixture can describe
            }

            byShape.putIfAbsent(key, Block.BLOCK_STATE_REGISTRY.getId(state));
        }

        return new ArrayList<>(byShape.values());
    }

    /**
     * Where the rays run, relative to the corner of the block being aimed at. The fixed ones aim at the
     * places a hand written test would never think to: the exact centre of each face, the edges and the
     * corners, and a start already inside the block. The random ones are what actually finds the
     * disagreements, since a shape can be wrong in a direction nobody thought of.
     */
    private static double[][] rays() {
        List<double[]> rays = new ArrayList<>();

        // Straight at the middle of each face from outside, and back out of the block again.
        double[][] axes = { { 1, 0, 0 }, { -1, 0, 0 }, { 0, 1, 0 }, { 0, -1, 0 }, { 0, 0, 1 }, { 0, 0, -1 } };
        for (double[] axis : axes) {
            double fx = 0.5 - axis[0] * 3.0, fy = 0.5 - axis[1] * 3.0, fz = 0.5 - axis[2] * 3.0;
            rays.add(new double[] { fx, fy, fz, fx + axis[0] * 6.0, fy + axis[1] * 6.0, fz + axis[2] * 6.0 });
            rays.add(new double[] { 0.5, 0.5, 0.5, 0.5 + axis[0] * 4.5, 0.5 + axis[1] * 4.5, 0.5 + axis[2] * 4.5 });
        }

        // Along each edge and corner of the cube, where a hit and a miss are a hair apart.
        double[] grazes = { 0.0, 1.0E-6, 0.0625, 0.5, 0.9375, 1.0 - 1.0E-6, 1.0 };
        for (double a : grazes) {
            for (double b : grazes) {
                rays.add(new double[] { a, 3.0, b, a, -3.0, b });
                rays.add(new double[] { -3.0, a, b, 3.0, a, b });
                rays.add(new double[] { a, b, -3.0, a, b, 3.0 });
            }
        }

        // A fan of arbitrary rays, which is what covers the shapes nobody pictured.
        Random random = new Random(20260813L);
        for (int i = 0; i < 240; i++) {
            double fx = random.nextDouble() * 9.0 - 4.0;
            double fy = random.nextDouble() * 9.0 - 4.0;
            double fz = random.nextDouble() * 9.0 - 4.0;
            double tx = random.nextDouble() * 3.0 - 1.0;
            double ty = random.nextDouble() * 3.0 - 1.0;
            double tz = random.nextDouble() * 3.0 - 1.0;
            rays.add(new double[] { fx, fy, fz, tx, ty, tz });
        }

        return rays.toArray(new double[0][]);
    }

    /** The smallest {@link BlockGetter} a clip will accept: one block, air everywhere else. */
    private record SingleBlock(BlockPos pos, BlockState state) implements BlockGetter {
        @Override
        public @Nullable BlockEntity getBlockEntity(BlockPos at) {
            return null;
        }

        @Override
        public BlockState getBlockState(BlockPos at) {
            return at.equals(this.pos) ? this.state : Blocks.AIR.defaultBlockState();
        }

        @Override
        public FluidState getFluidState(BlockPos at) {
            return this.getBlockState(at).getFluidState();
        }

        @Override
        public int getHeight() {
            return 4064;
        }

        @Override
        public int getMinY() {
            return -2032;
        }
    }

    private ClipHarness() {
    }
}

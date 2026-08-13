import java.io.DataOutputStream;
import java.io.OutputStream;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;
import java.util.zip.GZIPOutputStream;

import net.minecraft.SharedConstants;
import net.minecraft.core.BlockPos;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.server.Bootstrap;
import net.minecraft.server.packs.PackType;
import net.minecraft.server.packs.repository.ServerPacksSource;
import net.minecraft.server.packs.resources.MultiPackResourceManager;
import net.minecraft.tags.TagLoader;
import net.minecraft.world.entity.Entity;
import net.minecraft.world.level.BlockGetter;
import net.minecraft.world.level.CollisionGetter;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.Blocks;
import net.minecraft.world.level.block.entity.BlockEntity;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.border.WorldBorder;
import net.minecraft.world.level.material.FluidState;
import net.minecraft.world.level.pathfinder.PathType;
import net.minecraft.world.level.pathfinder.PathfindingContext;
import net.minecraft.world.level.pathfinder.WalkNodeEvaluator;
import net.minecraft.world.phys.AABB;
import net.minecraft.world.phys.shapes.VoxelShape;
import org.jspecify.annotations.Nullable;

/**
 * Commits what the real {@code WalkNodeEvaluator} makes of a block, so the C# classification can be
 * diffed against vanilla rather than against itself.
 * <p>
 * This is the harness CLAUDE.md's rule is really about. Nothing the client computes is involved, so
 * there is no desync to catch; the problem is that a wrong classification rule is one our own tests
 * would encode too, and would then agree with. A mob that treats a closed wooden door as a wall, or
 * a lily pad as open air, passes every test written from the same misreading.
 * <p>
 * Two things are pinned, because they fail differently:
 * <ul>
 * <li>{@code getPathTypeFromState} over <b>every</b> block state. Pure per state data, which is
 * what {@code BlockPathData} caches, and cheap enough to be exhaustive rather than sampled.</li>
 * <li>{@code getPathTypeStatic} over built scenes. That is the layer above: the switch that decides
 * what standing <i>on</i> a block means, and {@code checkNeighbourBlocks}, which is what makes a mob
 * refuse a square next to lava. Both read blocks other than the one being asked about, so no amount
 * of per state data covers them.</li>
 * </ul>
 * The type names travel with the fixture and the C# side matches on them, never on the ordinal:
 * these are enum positions, so an insertion upstream shifts every one after it and a shifted
 * ordinal is still a perfectly valid type.
 * <p>
 * {@code getPathTypeFromState} is {@code protected static}, so it is reached reflectively rather
 * than by declaring this class in vanilla's package: the server jar is signed, and an unsigned
 * class in a signed package makes the whole package fail to load. Compiled and run by
 * Conformance/pathtype.sh.
 */
public final class PathTypeHarness {
    public static void main(String[] args) throws Exception {
        if (args.length != 1) {
            System.err.println("Usage: PathTypeHarness <output-file>");
            System.exit(1);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();
        bindTags();

        List<Scene> scenes = scenes();

        try (OutputStream raw = Files.newOutputStream(Path.of(args[0]));
             GZIPOutputStream zipped = new GZIPOutputStream(raw);
             DataOutputStream out = new DataOutputStream(zipped)) {
            out.writeBytes("MCPATH1");

            // The names, so the reader can map its own enum by name. Ordinals are not stable.
            PathType[] types = PathType.values();
            out.writeInt(types.length);
            for (PathType type : types) {
                out.writeUTF(type.name());
                out.writeFloat(type.getMalus());
            }

            int stateCount = Block.BLOCK_STATE_REGISTRY.size();
            out.writeInt(stateCount);
            for (int id = 0; id < stateCount; id++) {
                BlockState state = Block.BLOCK_STATE_REGISTRY.byId(id);
                BlockGetter level = new Scene3d(new Scene(new Placed[] {
                        new Placed(BlockPos.ZERO, state),
                }));
                out.writeByte(fromState(level, BlockPos.ZERO).ordinal());
            }

            out.writeInt(scenes.size());
            for (Scene scene : scenes) {
                out.writeInt(scene.blocks.length);
                for (Placed placed : scene.blocks) {
                    out.writeInt(placed.pos.getX());
                    out.writeInt(placed.pos.getY());
                    out.writeInt(placed.pos.getZ());
                    out.writeInt(Block.BLOCK_STATE_REGISTRY.getId(placed.state));
                }
                out.writeByte(PathTypeHarness.classify(scene).ordinal());
            }

            System.out.println("Wrote " + stateCount + " states and " + scenes.size()
                    + " scenes to " + args[0]);
        }
    }

    /**
     * Loads the block tags onto the built in registries.
     * <p>
     * <b>Without this the harness lies.</b> {@code Bootstrap.bootStrap()} leaves every tag empty, so
     * {@code blockState.is(BlockTags.TRAPDOORS)} and {@code fluidState.is(FluidTags.LAVA)} answer
     * false for everything, and the classification quietly falls through to a later branch: lava
     * comes out as FIRE instead of LAVA, every trapdoor as OPEN, every fence as OPEN. Nothing throws.
     * The fixture then disagrees with a correct port, which reads as a bug on our side.
     */
    private static void bindTags() {
        MultiPackResourceManager resources = new MultiPackResourceManager(
                PackType.SERVER_DATA, List.of(ServerPacksSource.createVanillaPackSource()));

        TagLoader.loadTagsForExistingRegistries(
                        resources, RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY))
                .forEach(Registry.PendingTags::apply);
    }

    /**
     * {@code WalkNodeEvaluator.getPathTypeFromState}, which is protected. Resolved once and named
     * explicitly, so an upstream rename fails here rather than quietly dropping the coverage.
     */
    private static PathType fromState(BlockGetter level, BlockPos pos) {
        try {
            return (PathType) FROM_STATE.invoke(null, level, pos);
        } catch (ReflectiveOperationException e) {
            throw new RuntimeException(e);
        }
    }

    private static final Method FROM_STATE = fromStateMethod();

    private static Method fromStateMethod() {
        try {
            Method found = WalkNodeEvaluator.class
                    .getDeclaredMethod("getPathTypeFromState", BlockGetter.class, BlockPos.class);
            found.setAccessible(true);
            return found;
        } catch (NoSuchMethodException e) {
            throw new RuntimeException("WalkNodeEvaluator.getPathTypeFromState has moved or changed shape", e);
        }
    }

    /** {@code getPathTypeStatic} at the origin of a scene, which is where every scene asks. */
    private static PathType classify(Scene scene) {
        PathfindingContext context = context(new Scene3d(scene));
        return WalkNodeEvaluator.getPathTypeStatic(context, new BlockPos.MutableBlockPos(0, 0, 0));
    }

    /**
     * A {@link PathfindingContext} without a mob.
     * <p>
     * Its constructor takes one only to read {@code mob.level()} and {@code mob.blockPosition()},
     * neither of which the classification uses, and building a real mob needs a {@code ServerLevel}.
     * So the object is allocated without running a constructor and its four fields are filled in.
     * The cache is left null, which is the branch that calls straight through to
     * {@code getPathTypeFromState}.
     */
    private static PathfindingContext context(CollisionGetter level) {
        try {
            sun.misc.Unsafe unsafe = unsafe();
            PathfindingContext context = (PathfindingContext) unsafe.allocateInstance(PathfindingContext.class);
            set(context, "level", level);
            set(context, "cache", null);
            set(context, "mobPosition", BlockPos.ZERO);
            set(context, "mutablePos", new BlockPos.MutableBlockPos());
            return context;
        } catch (ReflectiveOperationException e) {
            throw new RuntimeException("PathfindingContext no longer has the fields this fills in", e);
        }
    }

    private static void set(Object target, String name, @Nullable Object value)
            throws ReflectiveOperationException {
        Field field = PathfindingContext.class.getDeclaredField(name);
        field.setAccessible(true);
        field.set(target, value);
    }

    private static sun.misc.Unsafe unsafe() throws ReflectiveOperationException {
        Field field = sun.misc.Unsafe.class.getDeclaredField("theUnsafe");
        field.setAccessible(true);
        return (sun.misc.Unsafe) field.get(null);
    }

    /**
     * The blocks the scenes are built from. Every branch of {@code getPathTypeFromState} has at
     * least one, plus the ones the layer above singles out: a walkable floor, water, lava, fire and
     * the two damage kinds are what {@code checkNeighbourBlocks} looks for by name.
     */
    private static BlockState[] palette() {
        List<BlockState> palette = new ArrayList<>();
        palette.add(Blocks.AIR.defaultBlockState());
        palette.add(Blocks.STONE.defaultBlockState());
        palette.add(Blocks.WATER.defaultBlockState());
        palette.add(Blocks.LAVA.defaultBlockState());
        palette.add(Blocks.FIRE.defaultBlockState());
        palette.add(Blocks.SOUL_FIRE.defaultBlockState());
        palette.add(Blocks.MAGMA_BLOCK.defaultBlockState());
        palette.add(Blocks.CAMPFIRE.defaultBlockState());
        palette.add(Blocks.LAVA_CAULDRON.defaultBlockState());
        palette.add(Blocks.CACTUS.defaultBlockState());
        palette.add(Blocks.SWEET_BERRY_BUSH.defaultBlockState());
        palette.add(Blocks.POWDER_SNOW.defaultBlockState());
        palette.add(Blocks.HONEY_BLOCK.defaultBlockState());
        palette.add(Blocks.COCOA.defaultBlockState());
        palette.add(Blocks.WITHER_ROSE.defaultBlockState());
        palette.add(Blocks.POINTED_DRIPSTONE.defaultBlockState());
        palette.add(Blocks.OAK_LEAVES.defaultBlockState());
        palette.add(Blocks.OAK_DOOR.defaultBlockState());
        palette.add(Blocks.IRON_DOOR.defaultBlockState());
        palette.add(Blocks.OAK_TRAPDOOR.defaultBlockState());
        palette.add(Blocks.LILY_PAD.defaultBlockState());
        palette.add(Blocks.BIG_DRIPLEAF.defaultBlockState());
        palette.add(Blocks.RAIL.defaultBlockState());
        palette.add(Blocks.OAK_FENCE.defaultBlockState());
        palette.add(Blocks.COBBLESTONE_WALL.defaultBlockState());
        palette.add(Blocks.OAK_FENCE_GATE.defaultBlockState());
        palette.add(Blocks.SCAFFOLDING.defaultBlockState());
        return palette.toArray(new BlockState[0]);
    }

    /**
     * What gets asked. Two families, because the two rules above the per state data fail in
     * different ways:
     * <ul>
     * <li>Every palette block under every palette block. That is the switch on what is below an
     * open square, and it is the rule that decides a mob will stand on honey but not in it.</li>
     * <li>Every palette block at each of the 26 offsets around an open square with stone under it.
     * That is {@code checkNeighbourBlocks}, whose loop deliberately skips the two positions with
     * {@code dx == 0 && dz == 0}, so a block directly above or below is not a neighbour and a port
     * that scans a plain 3x3x3 is wrong for exactly two of 26 cases.</li>
     * </ul>
     */
    private static List<Scene> scenes() {
        List<Scene> scenes = new ArrayList<>();
        BlockState[] palette = palette();
        BlockState stone = Blocks.STONE.defaultBlockState();

        for (BlockState at : palette) {
            for (BlockState below : palette) {
                scenes.add(new Scene(new Placed[] {
                        new Placed(BlockPos.ZERO, at),
                        new Placed(new BlockPos(0, -1, 0), below),
                }));
            }
        }

        for (BlockState neighbour : palette) {
            for (int dx = -1; dx <= 1; dx++) {
                for (int dy = -1; dy <= 1; dy++) {
                    for (int dz = -1; dz <= 1; dz++) {
                        if (dx == 0 && dy == 0 && dz == 0) {
                            continue;
                        }
                        scenes.add(new Scene(new Placed[] {
                                new Placed(new BlockPos(0, -1, 0), stone),
                                new Placed(new BlockPos(dx, dy, dz), neighbour),
                        }));
                    }
                }
            }
        }

        return scenes;
    }

    private record Placed(BlockPos pos, BlockState state) {
    }

    private record Scene(Placed[] blocks) {
    }

    /** A scene as something the classification can read: the placed blocks, air everywhere else. */
    private record Scene3d(Scene scene) implements CollisionGetter {
        @Override
        public @Nullable BlockEntity getBlockEntity(BlockPos at) {
            return null;
        }

        /**
         * Scanned backwards so a later placement wins, which is what any reader replaying the
         * scene by setting blocks in order will do. Two of the scene families put a block on the
         * same position, so taking the first instead would describe a scene nobody can reproduce.
         */
        @Override
        public BlockState getBlockState(BlockPos at) {
            for (int i = this.scene.blocks.length - 1; i >= 0; i--) {
                if (this.scene.blocks[i].pos.equals(at)) {
                    return this.scene.blocks[i].state;
                }
            }
            return Blocks.AIR.defaultBlockState();
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

        @Override
        public WorldBorder getWorldBorder() {
            return new WorldBorder();
        }

        @Override
        public @Nullable BlockGetter getChunkForCollisions(int chunkX, int chunkZ) {
            return this;
        }

        @Override
        public List<VoxelShape> getEntityCollisions(@Nullable Entity entity, AABB box) {
            return List.of();
        }
    }

    private PathTypeHarness() {
    }
}

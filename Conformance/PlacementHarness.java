import java.io.DataOutputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;
import java.util.zip.GZIPOutputStream;

import net.minecraft.SharedConstants;
import net.minecraft.core.BlockPos;
import net.minecraft.core.Direction;
import net.minecraft.core.Holder;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.server.Bootstrap;
import net.minecraft.server.packs.PackType;
import net.minecraft.server.packs.repository.ServerPacksSource;
import net.minecraft.server.packs.resources.MultiPackResourceManager;
import net.minecraft.tags.TagLoader;
import net.minecraft.util.RandomSource;
import net.minecraft.world.attribute.EnvironmentAttributeReader;
import net.minecraft.world.entity.Entity;
import net.minecraft.world.flag.FeatureFlagSet;
import net.minecraft.world.flag.FeatureFlags;
import net.minecraft.world.level.BlockGetter;
import net.minecraft.world.level.LevelReader;
import net.minecraft.world.level.ScheduledTickAccess;
import net.minecraft.world.level.biome.Biome;
import net.minecraft.world.level.biome.BiomeManager;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.Blocks;
import net.minecraft.world.level.block.entity.BlockEntity;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.border.WorldBorder;
import net.minecraft.world.level.chunk.ChunkAccess;
import net.minecraft.world.level.chunk.status.ChunkStatus;
import net.minecraft.world.level.dimension.DimensionType;
import net.minecraft.world.level.levelgen.Heightmap;
import net.minecraft.world.level.lighting.LevelLightEngine;
import net.minecraft.world.level.material.Fluid;
import net.minecraft.world.level.material.FluidState;
import net.minecraft.world.phys.AABB;
import net.minecraft.world.phys.shapes.VoxelShape;
import net.minecraft.world.ticks.LevelTickAccess;
import net.minecraft.world.ticks.ScheduledTick;
import net.minecraft.world.ticks.TickPriority;
import org.jspecify.annotations.Nullable;

/**
 * Commits what the real {@code canSurvive} and {@code updateShape} make of every block state, so the
 * placement rules can be diffed against vanilla rather than against themselves.
 * <p>
 * These are the two hooks that keep running after a block is placed: the shape cascade in
 * {@code World.SetBlock} drives them on every neighbouring change for the rest of the block's life,
 * so a wrong answer is not a one off flicker, it is a world that quietly settles into the wrong
 * arrangement. They are also the two that a hand written test cannot catch, because the test and the
 * rule come from one reading of the same method.
 * <p>
 * Deliberately <b>not</b> covered: {@code getStateForPlacement}. It needs a {@code BlockPlaceContext},
 * which needs a real {@code Level}, and that is out of reach for a harness. These two take only a
 * {@link LevelReader} and a {@link ScheduledTickAccess}, both interfaces, so they are reachable from
 * a stub in a way the placement context is not.
 * <p>
 * Three things travel with the fixture beyond the answers themselves:
 * <ul>
 * <li>Every scene and palette entry is written out as the blocks it places, so the C# side rebuilds
 * the scene rather than agreeing with a description of it.</li>
 * <li>The neighbour palette carries a <b>self</b> entry, index {@code -1}, which means the subject's
 * own state. Fences, walls, panes, chorus plants and chests only connect to their own kind, so a
 * palette of fixed states never exercises the branch that matters for them.</li>
 * <li>Whether the call <b>scheduled a tick</b>. There is no block tick scheduler in the port, and a
 * good few vanilla {@code updateShape} bodies do nothing else, so the honest port of those is no rule
 * at all. That claim is currently a reading of the decompile; this measures it.</li>
 * </ul>
 * The grid is exhaustive and mostly identity, so only the cases that change anything are written.
 * Absence means "vanilla returned the state it was given and scheduled nothing", which the reader
 * asserts as much as it asserts the exceptions.
 * <p>
 * Compiled and run by Conformance/placement.sh.
 */
public final class PlacementHarness {
    public static void main(String[] args) throws Exception {
        if (args.length != 1) {
            System.err.println("Usage: PlacementHarness <output-file>");
            System.exit(1);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();
        bindTags();

        List<Scene> scenes = supportScenes();
        int[] palette = neighbourPalette();
        Direction[] directions = Direction.values();
        int stateCount = Block.BLOCK_STATE_REGISTRY.size();

        try (OutputStream raw = Files.newOutputStream(Path.of(args[0]));
             GZIPOutputStream zipped = new GZIPOutputStream(raw);
             DataOutputStream out = new DataOutputStream(zipped)) {
            out.writeBytes("MCPLACE1");
            out.writeInt(stateCount);

            writeSupport(out, scenes, stateCount);
            writeShapes(out, palette, directions, stateCount);
        }
    }

    // ---------------------------------------------------------------- canSurvive

    /**
     * {@code BlockState.canSurvive} for every state in every scene, one byte each.
     * <p>
     * Exhaustive rather than sampled: 63 classes override this, and the whole {@code VegetationBlock}
     * family inherits one line from a parent while overriding the tag it asks about, so the answers
     * only separate when the block underneath varies. That is what the scene list is.
     */
    private static void writeSupport(DataOutputStream out, List<Scene> scenes, int stateCount)
            throws Exception {
        out.writeInt(scenes.size());
        for (Scene scene : scenes) {
            out.writeUTF(scene.name);
            out.writeByte(scene.brightness);
            out.writeInt(scene.blocks.size());
            for (Placed placed : scene.blocks) {
                out.writeByte(placed.pos.getX());
                out.writeByte(placed.pos.getY());
                out.writeByte(placed.pos.getZ());
                out.writeInt(Block.BLOCK_STATE_REGISTRY.getId(placed.state));
            }
        }

        int survived = 0;
        for (Scene scene : scenes) {
            for (int id = 0; id < stateCount; id++) {
                BlockState state = Block.BLOCK_STATE_REGISTRY.byId(id);
                StubLevel level = new StubLevel(scene.blocks, BlockPos.ZERO, state, scene.brightness);
                boolean can;
                try {
                    can = state.canSurvive(level, BlockPos.ZERO);
                } catch (RuntimeException e) {
                    // A throw is an answer too, and it is one worth seeing rather than hiding: it
                    // means the stub is short of something the rule reads.
                    throw new RuntimeException(
                            "canSurvive threw for " + state + " in scene " + scene.name, e);
                }
                out.writeBoolean(can);
                if (can) {
                    survived++;
                }
            }
        }

        System.out.println("canSurvive: " + stateCount + " states over " + scenes.size()
                + " scenes, " + survived + " survived");
    }

    // ---------------------------------------------------------------- updateShape

    /**
     * {@code BlockState.updateShape} over the whole grid of state, direction and neighbour, writing
     * only the cases that returned something different or scheduled a tick.
     */
    private static void writeShapes(DataOutputStream out, int[] palette, Direction[] directions,
            int stateCount) throws Exception {
        out.writeInt(palette.length);
        for (int entry : palette) {
            out.writeInt(entry);
        }

        out.writeInt(directions.length);
        for (Direction direction : directions) {
            out.writeUTF(direction.name());
        }

        int cells = directions.length * palette.length;
        int[] results = new int[cells];
        boolean[] ticked = new boolean[cells];
        boolean[] everTicks = new boolean[stateCount];

        List<StateBlock> written = new ArrayList<>();
        int changed = 0;
        int scheduled = 0;

        for (int id = 0; id < stateCount; id++) {
            BlockState state = Block.BLOCK_STATE_REGISTRY.byId(id);

            for (int d = 0; d < directions.length; d++) {
                Direction direction = directions[d];
                BlockPos neighbourPos = BlockPos.ZERO.relative(direction);

                for (int p = 0; p < palette.length; p++) {
                    BlockState neighbour = palette[p] == SELF
                            ? state
                            : Block.BLOCK_STATE_REGISTRY.byId(palette[p]);

                    List<Placed> blocks = List.of(new Placed(neighbourPos, neighbour));
                    StubLevel level = new StubLevel(blocks, BlockPos.ZERO, state);
                    Ticks ticks = new Ticks();

                    BlockState result;
                    try {
                        // A fresh source per call, seeded the same way every time, so the fixture is
                        // reproducible. Almost nothing reads it; a block that did would show up as a
                        // rule the port cannot be faithful to, which is worth knowing.
                        result = state.updateShape(level, ticks, BlockPos.ZERO, direction,
                                neighbourPos, neighbour, RandomSource.create(0L));
                    } catch (RuntimeException e) {
                        throw new RuntimeException("updateShape threw for " + state + " towards "
                                + direction + " against " + neighbour, e);
                    }

                    int cell = d * palette.length + p;
                    results[cell] = Block.BLOCK_STATE_REGISTRY.getId(result);
                    ticked[cell] = ticks.scheduled;

                    if (results[cell] != id) {
                        changed++;
                    }
                    if (ticks.scheduled) {
                        scheduled++;
                        everTicks[id] = true;
                    }
                }
            }

            StateBlock block = compress(id, results);
            if (block != null) {
                written.add(block);
            }
        }

        writeStateBlocks(out, written, palette.length);
        writeTickBitmap(out, everTicks);

        long grid = (long) stateCount * cells;
        System.out.println("updateShape: " + grid + " calls, " + changed + " not the identity, "
                + scheduled + " scheduled a tick, " + written.size() + " states in the fixture");
    }

    /**
     * One state's whole grid as a most common answer plus the cells that disagree with it.
     * <p>
     * Almost every state answers the same thing everywhere: a block with no override returns itself
     * for all of them, and a plant with no floor answers air for all of them. Written out flat that
     * is six million near identical rows and a fixture too big to keep in the repository, so the
     * common answer is stated once. Returns null when the whole grid is the identity with no tick,
     * which is the majority case and is stored as the state simply being absent.
     */
    private static @Nullable StateBlock compress(int id, int[] results) {
        int modeResult = results[0];
        int modeCount = 0;

        for (int candidate : results) {
            int count = 0;
            for (int result : results) {
                if (result == candidate) {
                    count++;
                }
            }
            if (count > modeCount) {
                modeCount = count;
                modeResult = candidate;
            }
        }

        if (modeCount == results.length && modeResult == id) {
            return null;
        }

        List<Divergent> exceptions = new ArrayList<>();
        for (int i = 0; i < results.length; i++) {
            if (results[i] != modeResult) {
                exceptions.add(new Divergent(i, results[i]));
            }
        }

        return new StateBlock(id, modeResult, exceptions);
    }

    /**
     * The compressed grid.
     * <p>
     * State ids go out as a delta from the previous state written and result ids as a delta from the
     * state being described, both zig zagged, because a block's states are consecutive in the
     * registry: a fence losing a connection lands a few ids away from where it started, so the delta
     * is one byte where the id is four.
     */
    private static void writeStateBlocks(DataOutputStream out, List<StateBlock> blocks, int paletteSize)
            throws Exception {
        if (paletteSize > 32) {
            throw new IllegalStateException("the palette index has to fit in five bits, see below");
        }

        out.writeInt(blocks.size());
        int previous = 0;

        for (StateBlock block : blocks) {
            writeVarInt(out, block.state - previous);
            previous = block.state;

            writeVarInt(out, zigZag(block.modeResult - block.state));
            writeVarInt(out, block.exceptions.size());

            for (Divergent exception : block.exceptions) {
                // Six directions need three bits and the palette index five, so a cell is one byte.
                out.writeByte((exception.cell / paletteSize) << 5 | (exception.cell % paletteSize));
                writeVarInt(out, zigZag(exception.result - block.state));
            }
        }
    }

    /**
     * One bit per state: whether any cell of its grid scheduled a tick.
     * <p>
     * Kept apart from the results rather than carried on each cell, because it is a different kind of
     * fact. There is no tick scheduler in the port, so this is not something the C# side can be held
     * to; it is the measurement of the gap. Per state rather than per cell for the same reason, and
     * because the waterlogged blocks schedule a water tick in every cell, which would otherwise put
     * seven eighths of the registry into the results grid carrying nothing the test can assert.
     */
    private static void writeTickBitmap(DataOutputStream out, boolean[] everTicks) throws Exception {
        int ticking = 0;
        for (int i = 0; i < everTicks.length; i += 8) {
            int packed = 0;
            for (int bit = 0; bit < 8 && i + bit < everTicks.length; bit++) {
                if (everTicks[i + bit]) {
                    packed |= 1 << bit;
                    ticking++;
                }
            }
            out.writeByte(packed);
        }

        System.out.println("scheduler gap: " + ticking + " states schedule a tick from updateShape");
    }

    private static int zigZag(int value) {
        return value << 1 ^ value >> 31;
    }

    private static void writeVarInt(DataOutputStream out, int value) throws Exception {
        int remaining = value;
        while ((remaining & ~0x7F) != 0) {
            out.writeByte(remaining & 0x7F | 0x80);
            remaining >>>= 7;
        }
        out.writeByte(remaining);
    }

    // ---------------------------------------------------------------- scenes

    /** The neighbour's own state means "the same state as the subject". */
    private static final int SELF = -1;

    /**
     * The two light levels the support scenes are run at.
     * <p>
     * {@code MushroomBlock} and {@code CropBlock} both read {@code getRawBrightness}, and there is no
     * per position light query in the port, so both rules there err permissive. Running the scenes at
     * both extremes turns that from a note into a measurement: the states whose two answers differ
     * are exactly the ones the divergence covers, and the test asserts the permissive one and reports
     * the list.
     */
    private static final int FULL_LIGHT = 15;
    private static final int DARK = 0;

    /**
     * What a block gets asked to survive on.
     * <p>
     * The list is the support tests the rules actually make, one scene each, rather than a sample:
     * the three {@code SupportType} regions separate on a slab, a fence post and a full block, the
     * vegetation tags separate on dirt, farmland, sand and soul soil, and the water scenes are what
     * the coral, seagrass and lily pad rules read.
     */
    private static List<Scene> supportScenes() {
        List<Scene> scenes = new ArrayList<>();
        BlockState stone = Blocks.STONE.defaultBlockState();
        BlockState water = Blocks.WATER.defaultBlockState();

        scenes.add(new Scene("air", List.of()));
        scenes.add(new Scene("stone below", List.of(below(stone))));
        scenes.add(new Scene("stone above", List.of(above(stone))));
        scenes.add(new Scene("stone north", List.of(new Placed(new BlockPos(0, 0, -1), stone))));
        scenes.add(new Scene("stone all round", List.of(
                below(stone), above(stone),
                new Placed(new BlockPos(0, 0, -1), stone),
                new Placed(new BlockPos(0, 0, 1), stone),
                new Placed(new BlockPos(-1, 0, 0), stone),
                new Placed(new BlockPos(1, 0, 0), stone))));

        // The three support regions, which are different shapes rather than degrees of the same one.
        scenes.add(new Scene("bottom slab below", List.of(below(Blocks.OAK_SLAB.defaultBlockState()))));
        scenes.add(new Scene("fence below", List.of(below(Blocks.OAK_FENCE.defaultBlockState()))));
        scenes.add(new Scene("chain above", List.of(above(Blocks.IRON_CHAIN.defaultBlockState()))));
        scenes.add(new Scene("leaves below", List.of(below(Blocks.OAK_LEAVES.defaultBlockState()))));
        scenes.add(new Scene("soul sand below", List.of(below(Blocks.SOUL_SAND.defaultBlockState()))));
        scenes.add(new Scene("mud below", List.of(below(Blocks.MUD.defaultBlockState()))));
        scenes.add(new Scene("open fence gate below",
                List.of(below(Blocks.OAK_FENCE_GATE.defaultBlockState()))));

        // What the vegetation tags separate on.
        scenes.add(new Scene("dirt below", List.of(below(Blocks.DIRT.defaultBlockState()))));
        scenes.add(new Scene("grass below", List.of(below(Blocks.GRASS_BLOCK.defaultBlockState()))));
        scenes.add(new Scene("farmland below", List.of(below(Blocks.FARMLAND.defaultBlockState()))));
        scenes.add(new Scene("sand below", List.of(below(Blocks.SAND.defaultBlockState()))));
        scenes.add(new Scene("soul soil below", List.of(below(Blocks.SOUL_SOIL.defaultBlockState()))));
        scenes.add(new Scene("mycelium below", List.of(below(Blocks.MYCELIUM.defaultBlockState()))));
        scenes.add(new Scene("nylium below", List.of(below(Blocks.CRIMSON_NYLIUM.defaultBlockState()))));
        scenes.add(new Scene("moss below", List.of(below(Blocks.MOSS_BLOCK.defaultBlockState()))));
        scenes.add(new Scene("clay below", List.of(below(Blocks.CLAY.defaultBlockState()))));

        // Water, for the things that live in it and the things that refuse to.
        //
        // Nothing can be placed at the origin: the subject owns it, so a scene that put a block
        // there would simply not be seen. That is why there is no "in water" scene, and it is not a
        // gap: a block's own fluid is its waterlogged property, which is part of the state being
        // swept rather than part of the scene around it.
        scenes.add(new Scene("water below", List.of(below(water))));
        scenes.add(new Scene("water above", List.of(above(water))));
        scenes.add(new Scene("water north", List.of(new Placed(new BlockPos(0, 0, -1), water))));
        scenes.add(new Scene("water below, dirt under that", List.of(
                below(water), new Placed(new BlockPos(0, -2, 0), Blocks.DIRT.defaultBlockState()))));

        // The same floors in the dark. Only the two light reading rules move, and which states move
        // is the measurement.
        scenes.add(new Scene("dark, dirt below", List.of(below(Blocks.DIRT.defaultBlockState())), DARK));
        scenes.add(new Scene("dark, grass below",
                List.of(below(Blocks.GRASS_BLOCK.defaultBlockState())), DARK));
        scenes.add(new Scene("dark, farmland below",
                List.of(below(Blocks.FARMLAND.defaultBlockState())), DARK));
        scenes.add(new Scene("dark, mycelium below",
                List.of(below(Blocks.MYCELIUM.defaultBlockState())), DARK));
        scenes.add(new Scene("dark, stone below", List.of(below(stone)), DARK));

        return scenes;
    }

    /**
     * The neighbour states an {@code updateShape} is run against.
     * <p>
     * Sized by what the rules branch on rather than by coverage of the registry: the connection
     * blocks, the two support shapes a slab and a fence give, water for the waterlogging branch, and
     * {@link #SELF} for everything that only joins its own kind.
     */
    private static int[] neighbourPalette() {
        List<BlockState> states = new ArrayList<>();
        states.add(Blocks.AIR.defaultBlockState());
        states.add(Blocks.STONE.defaultBlockState());
        states.add(Blocks.WATER.defaultBlockState());
        states.add(Blocks.LAVA.defaultBlockState());
        states.add(Blocks.DIRT.defaultBlockState());
        states.add(Blocks.OAK_LEAVES.defaultBlockState());
        states.add(Blocks.OAK_LOG.defaultBlockState());
        states.add(Blocks.OAK_SLAB.defaultBlockState());
        states.add(Blocks.OAK_STAIRS.defaultBlockState());
        states.add(Blocks.OAK_FENCE.defaultBlockState());
        states.add(Blocks.OAK_FENCE_GATE.defaultBlockState());
        states.add(Blocks.COBBLESTONE_WALL.defaultBlockState());
        states.add(Blocks.IRON_BARS.defaultBlockState());
        states.add(Blocks.GLASS.defaultBlockState());
        states.add(Blocks.CHEST.defaultBlockState());
        states.add(Blocks.SCAFFOLDING.defaultBlockState());
        states.add(Blocks.CHORUS_PLANT.defaultBlockState());
        states.add(Blocks.VINE.defaultBlockState());
        states.add(Blocks.OAK_DOOR.defaultBlockState());
        states.add(Blocks.GRASS_BLOCK.defaultBlockState());
        states.add(Blocks.FARMLAND.defaultBlockState());
        states.add(Blocks.POINTED_DRIPSTONE.defaultBlockState());

        int[] palette = new int[states.size() + 1];
        palette[0] = SELF;
        for (int i = 0; i < states.size(); i++) {
            palette[i + 1] = Block.BLOCK_STATE_REGISTRY.getId(states.get(i));
        }
        return palette;
    }

    private static Placed below(BlockState state) {
        return new Placed(new BlockPos(0, -1, 0), state);
    }

    private static Placed above(BlockState state) {
        return new Placed(new BlockPos(0, 1, 0), state);
    }

    // ---------------------------------------------------------------- plumbing

    /**
     * Loads the block tags onto the built in registries.
     * <p>
     * <b>Without this the harness lies</b>, the same way it would for the path type one.
     * {@code Bootstrap.bootStrap()} leaves every tag empty, and a good half of these rules are a
     * chain of {@code state.is(BlockTags.X)} tests: with the tags unbound every one answers false,
     * every plant refuses every floor, and nothing throws to say so.
     */
    private static void bindTags() {
        MultiPackResourceManager resources = new MultiPackResourceManager(
                PackType.SERVER_DATA, List.of(ServerPacksSource.createVanillaPackSource()));

        TagLoader.loadTagsForExistingRegistries(
                        resources, RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY))
                .forEach(Registry.PendingTags::apply);
    }

    private record Placed(BlockPos pos, BlockState state) {
    }

    /**
     * A scene carries its light level, because two rules read it and nothing else in the level can
     * express it. See {@link StubLevel#getRawBrightness}.
     */
    private record Scene(String name, List<Placed> blocks, int brightness) {
        Scene(String name, List<Placed> blocks) {
            this(name, blocks, FULL_LIGHT);
        }
    }

    /** One cell of a state's grid that disagrees with the state's most common answer. */
    private record Divergent(int cell, int result) {
    }

    private record StateBlock(int state, int modeResult, List<Divergent> exceptions) {
    }

    /**
     * A {@link ScheduledTickAccess} that only records that it was asked.
     * <p>
     * This is the seam the port does not have. Recording rather than dropping is what makes the
     * fixture able to say which rules are nothing but a scheduled tick, which is the difference
     * between a rule we are right to leave out and one we have missed.
     */
    private static final class Ticks implements ScheduledTickAccess {
        private boolean scheduled;

        @Override
        public <T> ScheduledTick<T> createTick(BlockPos pos, T type, int delay, TickPriority priority) {
            this.scheduled = true;
            return new ScheduledTick<>(type, pos, 0L, priority, 0L);
        }

        @Override
        public <T> ScheduledTick<T> createTick(BlockPos pos, T type, int delay) {
            this.scheduled = true;
            return new ScheduledTick<>(type, pos, 0L, 0L);
        }

        @Override
        public LevelTickAccess<Block> getBlockTicks() {
            return new NoTicks<>();
        }

        @Override
        public LevelTickAccess<Fluid> getFluidTicks() {
            return new NoTicks<>();
        }
    }

    /** Nothing is ever already scheduled, which is the state a single call is made from. */
    private static final class NoTicks<T> implements LevelTickAccess<T> {
        @Override
        public boolean hasScheduledTick(BlockPos pos, T type) {
            return false;
        }

        @Override
        public void schedule(ScheduledTick<T> tick) {
        }

        @Override
        public boolean willTickThisTick(BlockPos pos, T type) {
            return false;
        }

        @Override
        public int count() {
            return 0;
        }
    }

    /**
     * The smallest {@link LevelReader} these two hooks will accept: the scene's blocks, air
     * everywhere else.
     * <p>
     * Everything a rule genuinely reads is answered properly. What is left throws rather than
     * returning a plausible default, so a rule that reaches for chunks, biomes or world generation
     * fails the harness loudly instead of being pinned against a fabricated answer.
     */
    private record StubLevel(List<Placed> blocks, BlockPos subjectPos, BlockState subject,
            int brightness) implements LevelReader {
        StubLevel(List<Placed> blocks, BlockPos subjectPos, BlockState subject) {
            this(blocks, subjectPos, subject, FULL_LIGHT);
        }

        @Override
        public BlockState getBlockState(BlockPos at) {
            if (at.equals(this.subjectPos)) {
                return this.subject;
            }
            // Backwards, so a later placement wins, matching a reader that replays the scene by
            // setting the blocks in order.
            for (int i = this.blocks.size() - 1; i >= 0; i--) {
                if (this.blocks.get(i).pos.equals(at)) {
                    return this.blocks.get(i).state;
                }
            }
            return Blocks.AIR.defaultBlockState();
        }

        @Override
        public FluidState getFluidState(BlockPos at) {
            return this.getBlockState(at).getFluidState();
        }

        @Override
        public @Nullable BlockEntity getBlockEntity(BlockPos at) {
            return null;
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
        public int getSeaLevel() {
            return 63;
        }

        @Override
        public boolean isClientSide() {
            return false;
        }

        @Override
        public int getSkyDarken() {
            return 0;
        }

        @Override
        public boolean hasChunk(int chunkX, int chunkZ) {
            return true;
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

        @Override
        public FeatureFlagSet enabledFeatures() {
            return FeatureFlags.VANILLA_SET;
        }

        /**
         * Vanilla's own empty reader, which answers every attribute with its default. That is the
         * one the creaking heart reads, so its dormant branch here is vanilla's answer for a
         * dimension with no attributes rather than a guess.
         */
        @Override
        public EnvironmentAttributeReader environmentAttributes() {
            return EnvironmentAttributeReader.EMPTY;
        }

        @Override
        public RegistryAccess registryAccess() {
            return RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY);
        }

        @Override
        public int getHeight(Heightmap.Types type, int x, int z) {
            throw new UnsupportedOperationException("a rule read the heightmap");
        }

        @Override
        public ChunkAccess getChunk(int chunkX, int chunkZ, ChunkStatus status, boolean force) {
            throw new UnsupportedOperationException("a rule read a chunk");
        }

        @Override
        public BiomeManager getBiomeManager() {
            throw new UnsupportedOperationException("a rule read the biome manager");
        }

        @Override
        public Holder<Biome> getUncachedNoiseBiome(int x, int y, int z) {
            throw new UnsupportedOperationException("a rule read a biome");
        }

        @Override
        public DimensionType dimensionType() {
            throw new UnsupportedOperationException("a rule read the dimension type");
        }

        /**
         * The scene's light level, flat everywhere.
         * <p>
         * Overridden here rather than by standing up a {@link LevelLightEngine}, which would need a
         * chunk source: these are the only two light readers among the placement rules, both want a
         * single level at a single position, and a flat answer is exactly what a scene with one
         * light value means. {@link #getLightEngine} still throws, so anything reaching past this
         * for the real engine is not quietly served a fabricated answer.
         */
        @Override
        public int getRawBrightness(BlockPos at, int skySubtracted) {
            return this.brightness;
        }

        @Override
        public LevelLightEngine getLightEngine() {
            throw new UnsupportedOperationException("a rule read the light engine");
        }
    }

    private PlacementHarness() {
    }
}

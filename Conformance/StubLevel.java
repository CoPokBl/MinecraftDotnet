import java.util.ArrayList;
import java.util.List;
import java.util.function.Predicate;
import net.minecraft.core.BlockPos;
import net.minecraft.core.Holder;
import net.minecraft.core.QuartPos;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.registries.Registries;
import net.minecraft.commands.arguments.blocks.BlockStateParser;
import net.minecraft.resources.Identifier;
import net.minecraft.util.RandomSource;
import net.minecraft.world.level.WorldGenLevel;
import net.minecraft.world.level.biome.Biome;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.Blocks;
import net.minecraft.world.level.block.EntityBlock;
import net.minecraft.world.level.block.entity.BlockEntity;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.levelgen.Heightmap;
import net.minecraft.core.SectionPos;
import net.minecraft.world.level.ChunkPos;
import net.minecraft.world.level.LevelHeightAccessor;
import net.minecraft.world.level.chunk.ChunkAccess;
import net.minecraft.world.level.chunk.PalettedContainerFactory;
import net.minecraft.world.level.chunk.ProtoChunk;
import net.minecraft.world.level.chunk.status.ChunkStatus;
import net.minecraft.world.level.levelgen.LegacyRandomSource;
import net.minecraft.world.level.chunk.UpgradeData;
import net.minecraft.world.level.material.FluidState;

/**
 * A {@code WorldGenLevel} over a fixed three by three of chunks, with nothing behind it.
 *
 * <p>What a feature actually asks a level for is a handful of things: the state at a position, the
 * heightmaps, the biome, and somewhere to write. Everything else on the interface throws, so a feature
 * that reaches for a part of the world this cannot answer fails loudly instead of being measured
 * against a lie.
 *
 * <p>The heightmaps are rescanned per query rather than maintained. That is not how a chunk does it,
 * but it is the same answer, and the feature pass writes far fewer blocks than it reads.
 */
public final class StubLevel implements WorldGenLevel {

    private final ParityScene scene;
    private final RegistryAccess.Frozen registries;
    private final List<BlockState> palette = new ArrayList<>();
    private final List<Holder<Biome>> biomes = new ArrayList<>();
    private final RandomSource random = new LegacyRandomSource(0L);

    /**
     * The zoomer a biome lookup by block position goes through.
     * <p>
     * {@code LevelReader.getBiome} is {@code getBiomeManager().getBiome(pos)}, not the quart grid, so
     * every placement filter that asks about a biome asks through the fuzzy offset zoomer. Answering
     * the grid instead puts a feature's biome test on a four block boundary rather than the ragged one
     * the world really has, which drops candidates near a border and keeps others.
     */
    private final net.minecraft.world.level.biome.BiomeManager biomeManager;

    /**
     * The three by three as real chunks.
     * <p>
     * A plain block array is not enough: {@code OreFeature} reads through {@code BulkSectionAccess},
     * which asks the level for a chunk and then for a section of it, and the heightmaps a placement
     * filter compares have to be the ones {@code ProtoChunk.setBlockState} maintains rather than a
     * rescan that happens to agree. The status is <b>carvers</b>, which is what a chunk is at when its
     * neighbour decorates and what decides which four heightmaps are live.
     */
    private final ProtoChunk[] chunks = new ProtoChunk[9];

    /**
     * Which feature last wrote each position, so a difference names the feature that caused it.
     * <p>
     * Recorded as it happens rather than by diffing after each feature: a decoration pass runs about
     * a hundred features over a three by three of a million positions, and walking that per feature
     * costs more than the pass.
     */
    private final String[] lastWriter;

    /**
     * The last state {@link #attribute} saw at each position, or null while it is switched off.
     * <p>
     * <b>An ore does not write through {@code setBlock}.</b> {@code OreFeature} holds a
     * {@code BulkSectionAccess} and calls {@code LevelChunkSection.setBlockState} straight, so the
     * level never sees it and every ore block is left unattributed. Diffing the whole three by three
     * after each feature is what covers that, at a cost only one scene at a time can afford.
     */
    private BlockState[] attributed;

    /** The feature being placed, which every write is attributed to. */
    public String currentFeature = "?";


    public StubLevel(ParityScene scene, RegistryAccess.Frozen registries) {
        this.scene = scene;
        this.registries = registries;
        this.lastWriter = new String[scene.before.length];
        this.biomeManager = new net.minecraft.world.level.biome.BiomeManager(this,
            net.minecraft.world.level.biome.BiomeManager.obfuscateSeed(scene.seed));

        Registry<Block> blocks = registries.lookupOrThrow(Registries.BLOCK);
        for (String written : scene.paletteNames) {
            try {
                palette.add(BlockStateParser.parseForBlock(blocks, written, false).blockState());
            } catch (Exception e) {
                throw new IllegalStateException("Cannot parse " + written, e);
            }
        }

        Registry<Biome> biomeRegistry = registries.lookupOrThrow(Registries.BIOME);
        for (String written : scene.biomeNames) {
            biomes.add(biomeRegistry.get(Identifier.parse(written))
                .orElseThrow(() -> new IllegalStateException("No biome " + written)));
        }

        LevelHeightAccessor bounds = new LevelHeightAccessor() {
            @Override
            public int getHeight() {
                return scene.height;
            }

            @Override
            public int getMinY() {
                return scene.minY;
            }
        };

        BlockPos.MutableBlockPos pos = new BlockPos.MutableBlockPos();

        for (int dx = -1; dx <= 1; dx++) {
            for (int dz = -1; dz <= 1; dz++) {
                int slot = (dx + 1) * 3 + (dz + 1);
                ProtoChunk chunk = new ProtoChunk(new ChunkPos(scene.chunkX + dx, scene.chunkZ + dz),
                    UpgradeData.EMPTY, bounds, PalettedContainerFactory.create(registries), null);

                chunk.setPersistedStatus(ChunkStatus.TERRAIN);
                chunks[slot] = chunk;

                for (int y = 0; y < scene.height; y++) {
                    for (int z = 0; z < 16; z++) {
                        for (int x = 0; x < 16; x++) {
                            int at = ((slot * scene.height + y) * 16 + z) * 16 + x;
                            BlockState state = palette.get(scene.before[at]);

                            // Only the state a fresh ProtoChunk already holds is skipped. Cave air is
                            // air to isAir and a different state to everything that compares one, and
                            // a carved chunk is full of it, so skipping on isAir loses every one.
                            if (state == Blocks.AIR.defaultBlockState()) {
                                continue;
                            }

                            pos.set(((scene.chunkX + dx) << 4) + x, scene.minY + y,
                                ((scene.chunkZ + dz) << 4) + z);
                            chunk.setBlockState(pos, state, 0);
                        }
                    }
                }

            }
        }
    }

    /** The chunk covering a position, or null outside the three by three. */
    private ProtoChunk chunkAt(int x, int z) {
        int dx = Math.floorDiv(x, 16) - scene.chunkX;
        int dz = Math.floorDiv(z, 16) - scene.chunkZ;

        return dx < -1 || dx > 1 || dz < -1 || dz > 1 ? null : chunks[(dx + 1) * 3 + (dz + 1)];
    }

    /** Which feature last wrote a position, or null if vanilla never wrote it. */
    public String writerOf(int at) {
        return lastWriter[at];
    }

    /**
     * Attributes to {@code currentFeature} every position that has changed since the last call, which
     * is the only way to see a write that went round the level.
     */
    public void attribute() {
        if (attributed == null) {
            attributed = new BlockState[scene.before.length];
        }

        BlockPos.MutableBlockPos pos = new BlockPos.MutableBlockPos();

        for (int slot = 0; slot < 9; slot++) {
            ProtoChunk chunk = chunks[slot];

            for (int y = 0; y < scene.height; y++) {
                for (int z = 0; z < 16; z++) {
                    for (int x = 0; x < 16; x++) {
                        pos.set(((scene.chunkX + slot / 3 - 1) << 4) + x, scene.minY + y,
                            ((scene.chunkZ + slot % 3 - 1) << 4) + z);

                        BlockState state = chunk.getBlockState(pos);
                        int at = ((slot * scene.height + y) * 16 + z) * 16 + x;

                        if (attributed[at] != state) {
                            attributed[at] = state;
                            lastWriter[at] = currentFeature;
                        }
                    }
                }
            }
        }
    }

    /** A state as the port writes it, so the two sets of writes are diffed as text. */
    public String describe(BlockState state) {
        return BlockStateParser.serialize(state);
    }

    // --- what a feature actually uses ---------------------------------------

    @Override
    public BlockState getBlockState(BlockPos pos) {
        ProtoChunk chunk = chunkAt(pos.getX(), pos.getZ());
        return chunk == null ? Blocks.AIR.defaultBlockState() : chunk.getBlockState(pos);
    }

    @Override
    public FluidState getFluidState(BlockPos pos) {
        return getBlockState(pos).getFluidState();
    }

    @Override
    public boolean setBlock(BlockPos pos, BlockState state, int flags, int recursionLeft) {
        ProtoChunk chunk = chunkAt(pos.getX(), pos.getZ());
        if (chunk == null || isOutsideBuildHeight(pos)) {
            return false;
        }

        // Every write, with what was there and which feature is running. A difference the block pair
        // cannot explain is usually a second writer nobody suspected, and this is the only place that
        // shows one: PARITY_WATCH=<block id> reports the writes that replaced that block.
        String watched = System.getenv("PARITY_WATCH");
        if (watched != null) {
            BlockState had = chunk.getBlockState(pos);

            if (had.getBlock().builtInRegistryHolder().key().identifier().toString().equals(watched)) {
                System.out.printf("REPLACED %d %d %d %s -> %s by %s flags=%d%n", pos.getX(),
                    pos.getY(), pos.getZ(), had, state, currentFeature, flags);
            }
        }

        // The draw count at each write of a watched block, which is how a phase boundary inside a
        // feature is found from out here. A tree's trunk, foliage and decorators are hundreds of draws
        // apart, so the count at its first vine says what the foliage cost.
        String drawn = System.getenv("PARITY_DRAWS");
        if (drawn != null && state.toString().contains(drawn)
            && DecorationParityHarness.currentRandom != null) {

            System.out.printf("DRAWAT %d %d %d %s count=%d by %s%n", pos.getX(), pos.getY(),
                pos.getZ(), state, DecorationParityHarness.currentRandom.getCount(), currentFeature);
        }

        chunk.setBlockState(pos, state, flags);

        // ProtoChunk.setBlockState does not build a block entity. WorldGenRegion.setBlock writes a
        // DUMMY tag beside the block and its getBlockEntity materialises one from that on the first
        // ask, so a feature really does find a container where it just wrote a chest: without this a
        // monster room's loot seed and spawner mob are never drawn and every draw after them lands
        // somewhere else.
        if (state.hasBlockEntity() && state.getBlock() instanceof EntityBlock entityBlock) {
            BlockEntity entity = entityBlock.newBlockEntity(pos.immutable(), state);

            if (entity != null) {
                chunk.setBlockEntity(entity);
            } else {
                chunk.removeBlockEntity(pos);
            }
        }

        int at = scene.indexOf(pos.getX(), pos.getY(), pos.getZ());
        if (at >= 0) {
            lastWriter[at] = currentFeature;
        }

        return true;
    }

    @Override
    public boolean isStateAtPosition(BlockPos pos, Predicate<BlockState> predicate) {
        return predicate.test(getBlockState(pos));
    }

    @Override
    public boolean isFluidAtPosition(BlockPos pos, Predicate<FluidState> predicate) {
        return predicate.test(getFluidState(pos));
    }

    /** {@code WorldGenRegion.getHeight}: the chunk's own answer plus one, which is first available. */
    @Override
    public int getHeight(Heightmap.Types type, int x, int z) {
        int dx = Math.floorDiv(x, 16) - scene.chunkX;
        int dz = Math.floorDiv(z, 16) - scene.chunkZ;

        if (dx < -1 || dx > 1 || dz < -1 || dz > 1) {
            return scene.minY;
        }

        // The worldgen pair is carried in the scene rather than read off the chunk. Carvers is the
        // first status whose heightmapsAfter is the final four, so these two stopped being maintained
        // before this scene was recorded and a chunk built out of it has no copy of them at all;
        // rescanning would answer the ground with whatever a neighbour forked in on top of it.
        if (type == Heightmap.Types.WORLD_SURFACE_WG || type == Heightmap.Types.OCEAN_FLOOR_WG) {
            int at = (((dx + 1) * 3 + (dz + 1)) * 16 + (z & 15)) * 16 + (x & 15);

            return type == Heightmap.Types.WORLD_SURFACE_WG
                ? scene.worldSurfaceWg[at]
                : scene.oceanFloorWg[at];
        }

        return chunks[(dx + 1) * 3 + (dz + 1)].getHeight(type, x & 15, z & 15) + 1;
    }

    @Override
    public Holder<Biome> getUncachedNoiseBiome(int quartX, int quartY, int quartZ) {
        int at = scene.biomeIndexOf(quartX, quartY, quartZ);
        return at < 0 ? biomes.get(0) : biomes.get(scene.biomes[at]);
    }

    /** The biomes of one chunk of the three by three, which is what the decoration loop runs over. */
    public java.util.Set<Holder<Biome>> biomesOf(int dx, int dz) {
        java.util.Set<Holder<Biome>> present = new java.util.LinkedHashSet<>();
        int chunk = (dx + 1) * 3 + (dz + 1);
        int cells = scene.height / 4 * 16;

        for (int i = 0; i < cells; i++) {
            present.add(biomes.get(scene.biomes[chunk * cells + i]));
        }

        return present;
    }

    @Override
    public RegistryAccess registryAccess() {
        return registries;
    }

    @Override
    public RandomSource getRandom() {
        return random;
    }

    @Override
    public int getMinY() {
        return scene.minY;
    }

    @Override
    public int getHeight() {
        return scene.height;
    }

    @Override
    public long getSeed() {
        return scene.seed;
    }

    @Override
    public boolean removeBlock(BlockPos pos, boolean isMoving) {
        return setBlock(pos, Blocks.AIR.defaultBlockState(), 3, 512);
    }

    @Override
    public boolean destroyBlock(BlockPos pos, boolean dropBlock, net.minecraft.world.entity.Entity entity,
        int recursionLeft) {

        return removeBlock(pos, false);
    }

    /**
     * A scheduled tick goes on the chunk upstream and does not run during generation, so dropping it
     * measures the same thing. {@code LeavesBlock.updateShape} schedules one per leaf at the edge of
     * every tree, which is the only reason this is reached at all.
     */
    @Override
    public void scheduleTick(BlockPos pos, net.minecraft.world.level.block.Block block, int delay) {
    }

    @Override
    public void scheduleTick(BlockPos pos, net.minecraft.world.level.block.Block block, int delay,
        net.minecraft.world.ticks.TickPriority priority) {
    }

    @Override
    public void scheduleTick(BlockPos pos, net.minecraft.world.level.material.Fluid fluid, int delay) {
    }

    @Override
    public void scheduleTick(BlockPos pos, net.minecraft.world.level.material.Fluid fluid, int delay,
        net.minecraft.world.ticks.TickPriority priority) {
    }

    @Override
    public ChunkAccess getChunk(int chunkX, int chunkZ, ChunkStatus status, boolean load) {
        int dx = chunkX - scene.chunkX;
        int dz = chunkZ - scene.chunkZ;

        return dx < -1 || dx > 1 || dz < -1 || dz > 1 ? null : chunks[(dx + 1) * 3 + (dz + 1)];
    }

    @Override
    public boolean hasChunk(int chunkX, int chunkZ) {
        return Math.abs(chunkX - scene.chunkX) <= 1 && Math.abs(chunkZ - scene.chunkZ) <= 1;
    }

    // --- everything else, so a feature reaching past this fails loudly ----------

    @Override
    public void addParticle(net.minecraft.core.particles.ParticleOptions p0, double p1, double p2, double p3, double p4, double p5, double p6) {
    }

    @Override
    public <T> net.minecraft.world.ticks.ScheduledTick<T> createTick(net.minecraft.core.BlockPos p0, T p1, int p2) {
        throw new UnsupportedOperationException("createTick");
    }

    @Override
    public <T> net.minecraft.world.ticks.ScheduledTick<T> createTick(net.minecraft.core.BlockPos p0, T p1, int p2, net.minecraft.world.ticks.TickPriority p3) {
        throw new UnsupportedOperationException("createTick");
    }

    @Override
    public net.minecraft.world.level.dimension.DimensionType dimensionType() {
        throw new UnsupportedOperationException("dimensionType");
    }

    /**
     * What a vanilla world has enabled, which is what a jigsaw piece's processors read through
     * {@code LevelReader.holderLookup} when they resolve a block.
     */
    @Override
    public net.minecraft.world.flag.FeatureFlagSet enabledFeatures() {
        return net.minecraft.world.flag.FeatureFlags.DEFAULT_FLAGS;
    }

    @Override
    public net.minecraft.world.attribute.EnvironmentAttributeReader environmentAttributes() {
        throw new UnsupportedOperationException("environmentAttributes");
    }

    @Override
    public void gameEvent(net.minecraft.core.Holder<net.minecraft.world.level.gameevent.GameEvent> p0, net.minecraft.world.phys.Vec3 p1, net.minecraft.world.level.gameevent.GameEvent.Context p2) {
    }

    @Override
    public net.minecraft.world.level.biome.BiomeManager getBiomeManager() {
        return biomeManager;
    }

    @Override
    public net.minecraft.world.level.block.entity.BlockEntity getBlockEntity(net.minecraft.core.BlockPos p0) {
        // Always absent, which is what the port answers: nothing here ports a block entity, so a
        // feature that would fill one places its block and stops, on both sides.
        ProtoChunk chunk = chunkAt(p0.getX(), p0.getZ());
        return chunk == null ? null : chunk.getBlockEntity(p0);
    }

    @Override
    public <T extends net.minecraft.world.level.block.entity.BlockEntity> java.util.Optional<T> getBlockEntity(net.minecraft.core.BlockPos p0, net.minecraft.world.level.block.entity.BlockEntityType<T> p1) {
        return java.util.Optional.empty();
    }

    @Override
    public net.minecraft.world.ticks.LevelTickAccess<net.minecraft.world.level.block.Block> getBlockTicks() {
        throw new UnsupportedOperationException("getBlockTicks");
    }

    @Override
    public net.minecraft.world.level.BlockGetter getChunkForCollisions(int p0, int p1) {
        throw new UnsupportedOperationException("getChunkForCollisions");
    }

    @Override
    public net.minecraft.world.level.chunk.ChunkSource getChunkSource() {
        throw new UnsupportedOperationException("getChunkSource");
    }


    @Override
    public net.minecraft.world.DifficultyInstance getCurrentDifficultyAt(net.minecraft.core.BlockPos p0) {
        throw new UnsupportedOperationException("getCurrentDifficultyAt");
    }

    @Override
    public java.util.List<net.minecraft.world.entity.Entity> getEntities(net.minecraft.world.entity.Entity p0, net.minecraft.world.phys.AABB p1, java.util.function.Predicate<? super net.minecraft.world.entity.Entity> p2) {
        throw new UnsupportedOperationException("getEntities");
    }

    @Override
    public <T extends net.minecraft.world.entity.Entity> java.util.List<T> getEntities(net.minecraft.world.level.entity.EntityTypeTest<net.minecraft.world.entity.Entity, T> p0, net.minecraft.world.phys.AABB p1, java.util.function.Predicate<? super T> p2) {
        throw new UnsupportedOperationException("getEntities");
    }

    @Override
    public java.util.List<net.minecraft.world.phys.shapes.VoxelShape> getEntityCollisions(net.minecraft.world.entity.Entity p0, net.minecraft.world.phys.AABB p1) {
        throw new UnsupportedOperationException("getEntityCollisions");
    }

    @Override
    public net.minecraft.world.ticks.LevelTickAccess<net.minecraft.world.level.material.Fluid> getFluidTicks() {
        throw new UnsupportedOperationException("getFluidTicks");
    }

    @Override
    public net.minecraft.core.BlockPos getHeightmapPos(net.minecraft.world.level.levelgen.Heightmap.Types p0, net.minecraft.core.BlockPos p1) {
        return new BlockPos(p1.getX(), getHeight(p0, p1.getX(), p1.getZ()), p1.getZ());
    }

    @Override
    public net.minecraft.server.level.ServerLevel getLevel() {
        throw new UnsupportedOperationException("getLevel");
    }

    @Override
    public net.minecraft.world.level.storage.LevelData getLevelData() {
        throw new UnsupportedOperationException("getLevelData");
    }

    @Override
    public net.minecraft.world.level.lighting.LevelLightEngine getLightEngine() {
        throw new UnsupportedOperationException("getLightEngine");
    }

    /**
     * Full sky light and no block light, which is what a {@code WorldGenRegion} answers while a chunk
     * is decorating.
     * <p>
     * This is read off the engine rather than chosen. A chunk reaches {@code INITIALIZE_LIGHT} after
     * {@code FEATURES}, so nothing has written a light section yet, and
     * {@code SkyLightSectionStorage.getLightValue} then finds {@code topSections} still at its default
     * of {@code currentLowestY}, takes the else branch, and returns 15 for every position however deep
     * it is. Block light has no such shortcut and answers 0.
     * <p>
     * <b>So a crop placed by a structure survives its own {@code updateShape}, and answering zero here
     * kills it.</b> That is not the port erring permissive: a mansion's farm room really does keep its
     * wheat, because the light that would refuse it is not computed until the pass is over.
     */
    @Override
    public int getBrightness(net.minecraft.world.level.LightLayer layer, net.minecraft.core.BlockPos pos) {
        return layer == net.minecraft.world.level.LightLayer.SKY ? 15 : 0;
    }

    @Override
    public int getRawBrightness(net.minecraft.core.BlockPos pos, int skyDarken) {
        return Math.max(0, 15 - skyDarken);
    }

    @Override
    public net.minecraft.core.Holder<net.minecraft.world.level.biome.Biome> getNoiseBiome(int p0, int p1, int p2) {
        // The scene's own grid rather than the chunk's. The three by three is built by writing blocks
        // into bare ProtoChunks, whose biome containers are left at the default, so asking the chunk
        // answers plains everywhere.
        return getUncachedNoiseBiome(p0, p1, p2);
    }

    @Override
    public int getSeaLevel() {
        return 63;
    }

    @Override
    public net.minecraft.server.MinecraftServer getServer() {
        throw new UnsupportedOperationException("getServer");
    }

    @Override
    public int getSkyDarken() {
        throw new UnsupportedOperationException("getSkyDarken");
    }

    @Override
    public net.minecraft.world.level.border.WorldBorder getWorldBorder() {
        throw new UnsupportedOperationException("getWorldBorder");
    }


    /**
     * A server, which is what generates a world. A shipwreck's piece is the caller that asks: it
     * takes the branch that fills its chests, and answering the other way would skip writes.
     */
    @Override
    public boolean isClientSide() {
        return false;
    }

    @Override
    public void levelEvent(net.minecraft.world.entity.Entity p0, int p1, net.minecraft.core.BlockPos p2, int p3) {
    }

    @Override
    public long nextSubTickCount() {
        throw new UnsupportedOperationException("nextSubTickCount");
    }

    @Override
    public void playSound(net.minecraft.world.entity.Entity p0, net.minecraft.core.BlockPos p1, net.minecraft.sounds.SoundEvent p2, net.minecraft.sounds.SoundSource p3, float p4, float p5) {
    }

    @Override
    public java.util.List<? extends net.minecraft.world.entity.player.Player> players() {
        throw new UnsupportedOperationException("players");
    }
}

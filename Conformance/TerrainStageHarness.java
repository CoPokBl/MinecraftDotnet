import java.io.DataOutputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.function.Predicate;
import java.util.zip.GZIPOutputStream;
import net.minecraft.SharedConstants;
import net.minecraft.core.Holder;
import net.minecraft.core.QuartPos;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.registries.Registries;
import net.minecraft.resources.ResourceKey;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.ChunkPos;
import net.minecraft.world.level.LevelHeightAccessor;
import net.minecraft.world.level.StructureManager;
import net.minecraft.world.level.biome.Biome;
import net.minecraft.world.level.biome.BiomeGenerationSettings;
import net.minecraft.world.level.biome.BiomeManager;
import net.minecraft.world.level.biome.BiomeSource;
import net.minecraft.world.level.biome.MultiNoiseBiomeSource;
import net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterList;
import net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterLists;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.chunk.CarvingMask;
import net.minecraft.world.level.chunk.ChunkAccess;
import net.minecraft.world.level.chunk.ChunkGenerator;
import net.minecraft.world.level.chunk.PalettedContainerFactory;
import net.minecraft.world.level.chunk.ProtoChunk;
import net.minecraft.world.level.chunk.UpgradeData;
import net.minecraft.world.level.chunk.status.ChunkStatus;
import net.minecraft.world.level.levelgen.LegacyRandomSource;
import net.minecraft.world.level.levelgen.NoiseBasedChunkGenerator;
import net.minecraft.world.level.levelgen.NoiseChunk;
import net.minecraft.world.level.levelgen.NoiseGeneratorSettings;
import net.minecraft.world.level.levelgen.RandomState;
import net.minecraft.world.level.levelgen.WorldGenerationContext;
import net.minecraft.world.level.levelgen.WorldgenRandom;
import net.minecraft.world.level.levelgen.blending.Blender;
import net.minecraft.world.level.levelgen.carver.CarvingContext;
import net.minecraft.world.level.levelgen.carver.ConfiguredWorldCarver;
import net.minecraft.world.level.levelgen.structure.Structure;
import net.minecraft.world.level.levelgen.structure.StructureStart;

/**
 * Writes down every block the vanilla noise pass and the vanilla surface pass leave in a chunk, into
 * the fixture {@code TerrainStageConformanceTest} replays.
 *
 * <p>Usage: {@code java TerrainStageHarness <fixture> <seed> <chunkX>:<chunkZ>...}. See
 * Conformance/terrainstage.sh.
 *
 * <p><b>This is what stands between two things that were already exact and measured nothing.</b>
 * {@code terrain.sh} pins all fifteen entries of the {@code NoiseRouter}, the climate sample and the
 * biome the parameter list picks, at zero tolerance. Nothing pinned the step from those numbers to a
 * block: the aquifer deciding water, lava or stone from {@code barrier} and the two
 * {@code fluid_level} noises, {@code OreVeinifier} turning the three {@code vein} noises into ore, the
 * interpolation walk over the cells, and the whole surface rule tree on top. All of it was visible
 * only through {@code worldparity.sh}, whose error bar is about a third of its own value.
 *
 * <p><b>It is a pass rather than a baseline, and that is the point.</b> Both passes are pure functions
 * of the world seed and the chunk position: no neighbour is read, no shared random is drawn across
 * chunks, and nothing depends on what order chunks were asked for. So the order dependence that stops
 * whole-world parity ever reaching zero does not exist here, and any difference at all is the port.
 *
 * <p>Vanilla's own entry points are used unchanged for the first two passes, and both have an overload
 * that takes no level: {@code createBiomes}, {@code fillFromNoise} and the {@code buildSurface} that
 * takes a {@code BiomeManager} rather than a {@code WorldGenRegion}. Only the structure manager has to
 * be stubbed, and it answers <b>no starts</b>, which is what makes the beardifier zero and matches
 * {@code VanillaTerrainGenerator.Overworld(seed)} without {@code WithStructures}. The carver pass is
 * the exception and is reached through a transcription of {@code applyCarvers}; see {@link #carve}.
 *
 * <p>Fixture format, all big endian and gzipped: a long seed, an int chunk count, then per chunk the
 * chunk x, chunk z, minimum y and height, followed by three arrays of {@code height * 256} ints, the
 * block state after the noise pass, after the surface pass and after the carver pass. The ids are
 * {@code Block.getId}, which is the same global palette the chunk packet carries, so a state id means
 * the same thing on both sides without a name table between them.
 */
public class TerrainStageHarness {

    /** What a chunk is generated over: the overworld's own range. */
    private static final int MIN_Y = -64;
    private static final int HEIGHT = 384;

    public static void main(String[] args) throws Exception {
        if (args.length < 3) {
            System.err.println("usage: TerrainStageHarness <fixture> <seed> <chunkX>:<chunkZ>...");
            System.exit(2);
        }

        Path out = Path.of(args[0]);
        long seed = Long.parseLong(args[1]);

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        RegistryAccess.Frozen registries = Harness.buildRegistryAccess();
        NoiseBasedChunkGenerator generator = overworldGenerator(registries);

        NoiseGeneratorSettings settings = registries.lookupOrThrow(Registries.NOISE_SETTINGS)
            .getOrThrow(NoiseGeneratorSettings.OVERWORLD).value();
        RandomState randomState = RandomState.create(settings,
            registries.lookupOrThrow(Registries.NOISE), seed);

        List<ChunkPos> positions = new ArrayList<>();
        for (int i = 2; i < args.length; i++) {
            String[] parts = args[i].split(":");
            positions.add(new ChunkPos(Integer.parseInt(parts[0]), Integer.parseInt(parts[1])));
        }

        LevelHeightAccessor bounds = new LevelHeightAccessor() {
            public int getHeight() {
                return HEIGHT;
            }

            public int getMinY() {
                return MIN_Y;
            }
        };

        StructureManager structures = new NoStructures();
        Set<Holder<Biome>> possible = Set.copyOf(generator.getBiomeSource().possibleBiomes());

        try (OutputStream raw = Files.newOutputStream(out);
             GZIPOutputStream gzip = new GZIPOutputStream(raw);
             DataOutputStream data = new DataOutputStream(gzip)) {

            data.writeLong(seed);
            data.writeInt(positions.size());

            for (ChunkPos position : positions) {
                // The three by three, because the biome zoom reaches a quart either side and a
                // WorldGenRegion would answer that out of the neighbour's own grid. Only the middle
                // one is given a noise pass; the ring exists for its biomes alone.
                ProtoChunk[] around = new ProtoChunk[9];
                for (int dx = -1; dx <= 1; dx++) {
                    for (int dz = -1; dz <= 1; dz++) {
                        ProtoChunk neighbour = new ProtoChunk(
                            new ChunkPos(position.x() + dx, position.z() + dz), UpgradeData.EMPTY,
                            bounds, PalettedContainerFactory.create(registries), null);

                        // Vanilla's chunk status order: BIOMES before NOISE, so the surface pass reads
                        // a grid that already exists rather than one it fills as it goes.
                        generator.createBiomes(randomState, Blender.empty(), structures, neighbour)
                            .join();

                        // ProtoChunk refuses a biome query until its status says it has biomes, and
                        // the status is the chunk pipeline's job rather than createBiomes'.
                        neighbour.setPersistedStatus(ChunkStatus.BIOMES);
                        around[((dx + 1) * 3) + dz + 1] = neighbour;
                    }
                }

                ProtoChunk chunk = around[4];
                generator.fillFromNoise(Blender.empty(), randomState, structures, chunk).join();

                data.writeInt(position.x());
                data.writeInt(position.z());
                data.writeInt(MIN_Y);
                data.writeInt(HEIGHT);
                write(data, chunk);

                // The biome manager a WorldGenRegion would hand it, over the grid createBiomes just
                // filled. Its zoom is what stops a beach having visible steps on a four block grid.
                BiomeManager biomes = new BiomeManager(
                    (x, y, z) -> noiseBiome(around, position, x, y, z),
                    BiomeManager.obfuscateSeed(seed));

                generator.buildSurface(chunk, new WorldGenerationContext(generator, bounds),
                    randomState, structures, biomes, Blender.empty(), possible);

                write(data, chunk);

                carve(generator, registries, settings, randomState, seed, chunk, biomes, position);

                write(data, chunk);
                System.out.println("chunk " + position.x() + " " + position.z() + " done");
            }
        }

        System.out.println("Wrote " + positions.size() + " chunks to " + out);
    }

    /**
     * The carver pass, over the chunk the surface pass just finished.
     *
     * <p><b>This is the one stage here that is not vanilla's own entry point.</b>
     * {@code ChunkGenerator.applyCarvers} takes a {@code WorldGenRegion}, which is a concrete class
     * over a {@code ServerLevel} and cannot be stubbed, while everything under it takes a
     * {@code ChunkAccess}: {@code ConfiguredWorldCarver.carve}, {@code CarvingContext} and the
     * aquifer are all level free. So the loop is transcribed here and the carving is vanilla's.
     *
     * <p>What that leaves unmeasured is the loop itself: which chunks are replayed, and how each
     * carver in each of them is seeded. What it measures is everything the carve does, which is the
     * walk, the ellipsoid, the block decisions, the aquifer's answer and the surface fix-up.
     *
     * <p>Two details of the loop are load bearing and are why it is transcribed rather than
     * approximated. The biome that decides which carvers start in a source chunk goes through
     * {@code randomState.sampler()}, the <b>flattened</b> sampler, because a source chunk is up to
     * eight away and a {@code NoiseChunk}'s caches only cover its own chunk; and the biome handed to
     * the carve itself is a {@code BiomeManager} whose source has been swapped for that same flat
     * sampler by {@code withDifferentSource}, rather than the zoomed one the surface pass used.
     */
    private static void carve(NoiseBasedChunkGenerator generator, RegistryAccess registries,
        NoiseGeneratorSettings settings, RandomState randomState, long seed, ProtoChunk chunk,
        BiomeManager biomes, ChunkPos position) {

        BiomeManager carverBiomes = biomes.withDifferentSource(
            (x, y, z) -> generator.getBiomeSource().getNoiseBiome(x, y, z, randomState.sampler()));

        // Reseeded from setLargeFeatureSeed before every carver, so what it starts as never reaches
        // anything. Upstream that is RandomSupport.generateUniqueSeed().
        WorldgenRandom random = new WorldgenRandom(new LegacyRandomSource(0L));

        NoiseChunk noiseChunk = chunk.getOrCreateNoiseChunk(unused -> {
            throw new IllegalStateException("fillFromNoise did not leave a noise chunk to carve with");
        });

        CarvingContext context = new CarvingContext(generator, registries,
            chunk.getHeightAccessorForGeneration(), noiseChunk, randomState, settings.surfaceRule());

        CarvingMask mask = chunk.getOrCreateCarvingMask();

        // Every chunk within eight, because a walk that started there may reach this one. That is
        // vanilla's own shape rather than an approximation of something cheaper.
        for (int dx = -8; dx <= 8; dx++) {
            for (int dz = -8; dz <= 8; dz++) {
                ChunkPos source = new ChunkPos(position.x() + dx, position.z() + dz);

                BiomeGenerationSettings biomeSettings = generator.getBiomeGenerationSettings(
                    generator.getBiomeSource().getNoiseBiome(QuartPos.fromSection(source.x()), 0,
                        QuartPos.fromSection(source.z()), randomState.sampler()));

                int index = 0;

                for (Holder<ConfiguredWorldCarver<?>> holder : biomeSettings.getCarvers()) {
                    ConfiguredWorldCarver<?> carver = holder.value();

                    // The index is the biome's own, so two biomes listing one carver in different
                    // positions genuinely give it different seeds.
                    random.setLargeFeatureSeed(seed + index, source.x(), source.z());

                    if (carver.isStartChunk(random)) {
                        carver.carve(context, chunk, carverBiomes::getBiome, random,
                            noiseChunk.aquifer(), source, mask);
                    }

                    index++;
                }
            }
        }
    }

    /**
     * The biome at a quart position, out of whichever of the three by three holds it.
     *
     * <p>The y is clamped into the world, which is what {@code ChunkAccess.getNoiseBiome} does and
     * what the zoom needs at the very bottom and top of the column: it reads a quart below the
     * position it was asked about.
     */
    private static Holder<Biome> noiseBiome(ProtoChunk[] around, ChunkPos centre, int x, int y, int z) {
        int dx = Math.max(-1, Math.min(1, (x >> 2) - centre.x()));
        int dz = Math.max(-1, Math.min(1, (z >> 2) - centre.z()));

        int lowest = MIN_Y >> 2;
        int highest = (MIN_Y + HEIGHT - 1) >> 2;

        return around[((dx + 1) * 3) + dz + 1]
            .getNoiseBiome(x, Math.max(lowest, Math.min(highest, y)), z);
    }

    /** Every block of a chunk as a global state id, in y then z then x order. */
    private static void write(DataOutputStream data, ChunkAccess chunk) throws Exception {
        net.minecraft.core.BlockPos.MutableBlockPos at = new net.minecraft.core.BlockPos.MutableBlockPos();

        for (int y = MIN_Y; y < MIN_Y + HEIGHT; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    at.set((chunk.getPos().x() << 4) + x, y, (chunk.getPos().z() << 4) + z);
                    data.writeInt(Block.getId(chunk.getBlockState(at)));
                }
            }
        }
    }

    private static NoiseBasedChunkGenerator overworldGenerator(RegistryAccess.Frozen registries) {
        Holder<MultiNoiseBiomeSourceParameterList> parameters =
            registries.lookupOrThrow(Registries.MULTI_NOISE_BIOME_SOURCE_PARAMETER_LIST)
                .getOrThrow(MultiNoiseBiomeSourceParameterLists.OVERWORLD);

        BiomeSource source = MultiNoiseBiomeSource.createFromPreset(parameters);

        ResourceKey<NoiseGeneratorSettings> key = NoiseGeneratorSettings.OVERWORLD;
        return new NoiseBasedChunkGenerator(source,
            registries.lookupOrThrow(Registries.NOISE_SETTINGS).getOrThrow(key));
    }

    /**
     * A structure manager holding nothing, which is what makes the beardifier zero.
     *
     * <p>Its constructor only assigns the three fields it is handed, so nulls are safe: what the
     * noise pass asks it is {@code startsForStructure}, and the answer being empty is the whole of
     * the stub.
     */
    private static final class NoStructures extends StructureManager {
        NoStructures() {
            super(null, null, null);
        }

        @Override
        public List<StructureStart> startsForStructure(ChunkPos chunk, Predicate<Structure> wanted) {
            return List.of();
        }
    }
}

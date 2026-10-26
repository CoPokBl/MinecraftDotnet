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
import java.lang.reflect.Method;
import net.minecraft.world.level.chunk.ChunkAccess;
import net.minecraft.world.level.levelgen.NoiseSettings;
import net.minecraft.world.level.levelgen.material.rule.MaterialRule;
import net.minecraft.world.level.levelgen.structure.Structure;
import net.minecraft.world.level.levelgen.structure.StructureStart;

/**
 * Writes down every block the vanilla fill, surface and carver passes leave in a chunk, into
 * the fixture {@code TerrainStageConformanceTest} replays.
 *
 * <p>Usage: {@code java TerrainStageHarness <fixture> <seed> <chunkX>:<chunkZ>...}. See
 * Conformance/terrainstage.sh.
 *
 * <p>{@code terrain.sh} pins the density functions, the climate sample and the biome the parameter
 * list picks. This pins the step from those numbers to blocks: the aquifer deciding water, lava or
 * stone, the material rules with the ore veins in them, and the carvers' mask and its application.
 *
 * <p><b>It is a pass rather than a baseline, and that is the point.</b> Both passes are pure functions
 * of the world seed and the chunk position: no neighbour is read, no shared random is drawn across
 * chunks, and nothing depends on what order chunks were asked for. So the order dependence that stops
 * whole-world parity ever reaching zero does not exist here, and any difference at all is the port.
 *
 * <p>Vanilla's own code runs every pass: {@code createBiomes}, then {@code createNoiseChunk},
 * {@code doFill}, {@code buildSurface} and {@code generateCarvers} over one noise chunk as
 * {@code buildTerrain} does, reached by reflection because they are private and {@code buildTerrain}
 * itself takes a {@code WorldGenRegion}. The carvers get no region, so their source biomes come from
 * the uncached resolver, which is also what a region falls back to. Only the structure manager is
 * stubbed, and it answers <b>no starts</b>, which makes the beardifier zero and matches
 * {@code VanillaTerrainGenerator.Overworld(seed)} without {@code WithStructures}.
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
        RandomState randomState = RandomState.create(registries.lookupOrThrow(Registries.NOISE), seed, settings);

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
                BiomeManager biomes = new BiomeManager(
                    (x, y, z) -> noiseBiome(around, position, x, y, z),
                    BiomeManager.obfuscateSeed(seed));
                MaterialRule rule = settings.materialRule().value();
                Method create = NoiseBasedChunkGenerator.class.getDeclaredMethod("createNoiseChunk", ChunkAccess.class,
                    StructureManager.class, Blender.class, RandomState.class, NoiseSettings.class);
                Method fill = NoiseBasedChunkGenerator.class.getDeclaredMethod("doFill", NoiseChunk.class, ChunkAccess.class);
                Method surface = NoiseBasedChunkGenerator.class.getDeclaredMethod("buildSurface", ChunkAccess.class, NoiseChunk.class,
                    RandomState.class, BiomeManager.class, Set.class, MaterialRule.class);
                Method carvers = NoiseBasedChunkGenerator.class.getDeclaredMethod("generateCarvers", ChunkAccess.class, Blender.class,
                    NoiseChunk.class, RandomState.class, BiomeManager.class, net.minecraft.server.level.WorldGenRegion.class, MaterialRule.class);
                for (Method m : new Method[] {create, fill, surface, carvers}) m.setAccessible(true);
                NoiseSettings noise = settings.noiseSettings().clampToHeightAccessor(chunk.getHeightAccessorForGeneration());
                try (NoiseChunk noiseChunk = (NoiseChunk) create.invoke(generator, chunk, structures, Blender.empty(), randomState, noise)) {
                    fill.invoke(generator, noiseChunk, chunk);
                    data.writeInt(position.x());
                    data.writeInt(position.z());
                    data.writeInt(MIN_Y);
                    data.writeInt(HEIGHT);
                    write(data, chunk);
                    surface.invoke(generator, chunk, noiseChunk, randomState, biomes, possible, rule);
                    write(data, chunk);
                    carvers.invoke(generator, chunk, Blender.empty(), noiseChunk, randomState, biomes, null, rule);
                    write(data, chunk);
                }
                System.out.println("chunk " + position.x() + " " + position.z() + " done");
            }
        }

        System.out.println("Wrote " + positions.size() + " chunks to " + out);
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
        public List<StructureStart> startsForStructure(int chunkX, int chunkZ, Predicate<Structure> wanted) {
            return List.of();
        }
    }
}

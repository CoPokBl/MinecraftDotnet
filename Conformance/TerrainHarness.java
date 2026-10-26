import net.minecraft.SharedConstants;
import net.minecraft.core.HolderLookup;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.registries.Registries;
import net.minecraft.resources.Identifier;
import net.minecraft.resources.ResourceKey;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.biome.Biome;
import net.minecraft.world.level.biome.Climate;
import net.minecraft.world.level.levelgen.Aquifer;
import net.minecraft.world.level.levelgen.NoiseGeneratorSettings;
import net.minecraft.world.level.levelgen.NoiseRouter;
import net.minecraft.world.level.levelgen.RandomState;
import net.minecraft.world.level.levelgen.densityfunction.DensityBuffer;
import net.minecraft.world.level.levelgen.densityfunction.DensityFunction;
import net.minecraft.world.level.levelgen.densityfunction.DensityVolume;
import net.minecraft.world.level.levelgen.densityfunction.SamplerContext;
import net.minecraft.world.level.levelgen.synth.NormalNoise;

import java.io.DataOutputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;
import java.util.zip.GZIPOutputStream;

/**
 * Runs the real vanilla density functions over a grid of positions and writes down every number they
 * produced, for {@code TerrainConformanceTest} to replay.
 *
 * <p>This is the only thing that can tell the density function port from a plausible impostor: a wrong
 * constant, a wrong spline derivative or a noise seeded from the wrong name all produce terrain that
 * looks like Minecraft and is not the world vanilla would have generated.
 *
 * <p>Two halves, because the compiled samplers have two paths that round differently. The point half
 * is {@code sampleBlockValueUncached}, every router entry at every position. The volume
 * half samples whole chunks through a caching context the way the noise fill and the biome fill do:
 * the final density over 16 by height by 16, the six climate functions over the chunk's quart grid,
 * and {@code chunk_surface_level} over 16 by 1 by 16 at y 0.
 *
 * <p>Usage: {@code java TerrainHarness <fixture> [overworld|nether|end]}.
 *
 * <p>Fixture format, all big endian: the seed; the minimum y and height the volumes cover; an int
 * count of entry names, each a UTF string; an int count, then per sample three int coordinates
 * and one float per entry; an int count of climate samples, each three ints and six longs; the
 * biome each resolves to as a UTF string; then an int count of chunks, each two ints followed by the
 * three volumes' floats in buffer order.
 */
public final class TerrainHarness {
    /** The order the floats are written in, which the fixture carries for the C# side to read back. */
    static final String[] OVERWORLD_ENTRIES = {
        "temperature", "vegetation", "continents", "erosion", "depth", "ridges", "chunk_surface_level", "final_density",
        "aquifer_barrier", "aquifer_fluid_level_floodedness", "aquifer_fluid_level_spread", "aquifer_lava",
        "aquifer_exclusion", "aquifer_surface_level",
        "overworld/ore_vein/toggle", "overworld/ore_vein/mask", "overworld/ore_vein/gap",
        "overworld/ore_vein/richness", "overworld/ore_vein/copper_density", "overworld/ore_vein/iron_density"
    };

    /** The nether has no aquifer config and no veins, so its router is the whole of what it reads. */
    static final String[] NETHER_ENTRIES = {
        "temperature", "vegetation", "continents", "erosion", "depth", "ridges", "chunk_surface_level", "final_density",
        "nether/base_3d_noise"
    };

    /**
     * The end's: its two islands functions, and the old blended noise under them. {@code erosion} is
     * {@code end/islands} itself, which is what the biome source reads.
     */
    static final String[] END_ENTRIES = {
        "temperature", "vegetation", "continents", "erosion", "depth", "ridges", "chunk_surface_level", "final_density",
        "end/base_3d_noise", "end/islands", "end/sloped_cheese"
    };

    static final int[][] VOLUME_CHUNKS = {{0, 0}, {-5, 3}, {41, -17}};

    /**
     * Past the central island too, where the outer islands are, and one chunk across the 64 chunk
     * circle the biome source and the outer island function both draw.
     */
    static final int[][] END_VOLUME_CHUNKS = {{0, 0}, {-5, 3}, {41, -17}, {64, 1}, {70, -12}, {-130, 95}};

    private static final long SEED = 1234567890L;

    public static void main(String[] args) throws Exception {
        Path out = Path.of(args.length > 0 ? args[0] : "vanilla-terrain.bin.gz");
        Files.createDirectories(out.getParent());
        String dimension = args.length > 1 ? args[1] : "overworld";
        boolean nether = dimension.equals("nether");
        boolean end = dimension.equals("end");
        String[] entries = nether ? NETHER_ENTRIES : end ? END_ENTRIES : OVERWORLD_ENTRIES;
        int[][] volumeChunks = end ? END_VOLUME_CHUNKS : VOLUME_CHUNKS;

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        // Decoded from the vanilla pack rather than taken from VanillaRegistries' bootstrap objects,
        // because the pack is what a server reads and the port parses. See Harness.buildRegistryAccess.
        RegistryAccess.Frozen vanilla = Harness.buildRegistryAccess();
        HolderLookup.RegistryLookup<NoiseGeneratorSettings> settingsLookup = vanilla.lookupOrThrow(Registries.NOISE_SETTINGS);
        HolderLookup.RegistryLookup<NormalNoise> noises = vanilla.lookupOrThrow(Registries.NOISE);
        HolderLookup.RegistryLookup<DensityFunction> functions = vanilla.lookupOrThrow(Registries.DENSITY_FUNCTION);

        NoiseGeneratorSettings settings = settingsLookup.getOrThrow(nether ? NoiseGeneratorSettings.NETHER
            : end ? NoiseGeneratorSettings.END : NoiseGeneratorSettings.OVERWORLD).value();
        RandomState randomState = RandomState.create(noises, SEED, settings);
        NoiseRouter router = settings.noiseRouter();
        Aquifer.Config aquifers = settings.aquifers().orElse(null);
        int minY = settings.noiseSettings().minY();
        int height = settings.noiseSettings().height();

        List<int[]> positions = samplePositions(minY, height);

        try (OutputStream raw = Files.newOutputStream(out);
             GZIPOutputStream gzip = new GZIPOutputStream(raw);
             DataOutputStream data = new DataOutputStream(gzip)) {

            data.writeLong(SEED);
            data.writeInt(minY);
            data.writeInt(height);
            data.writeInt(entries.length);
            for (String entry : entries) {
                data.writeUTF(entry);
            }

            data.writeInt(positions.size());
            for (int[] position : positions) {
                data.writeInt(position[0]);
                data.writeInt(position[1]);
                data.writeInt(position[2]);
                for (String entry : entries) {
                    data.writeFloat(randomState.sampleBlockValueUncached(entryOf(router, aquifers, functions, entry),
                        position[0], position[1], position[2]));
                }
            }

            Climate.Sampler sampler = randomState.createClimateSampler(SamplerContext.EMPTY_UNCACHED);
            data.writeInt(positions.size());
            for (int[] position : positions) {
                // Quart coordinates, which is what the biome grid is indexed by.
                int quartX = position[0] >> 2;
                int quartY = position[1] >> 2;
                int quartZ = position[2] >> 2;
                data.writeInt(quartX);
                data.writeInt(quartY);
                data.writeInt(quartZ);
                Climate.TargetPoint target = sampler.sample(quartX, quartY, quartZ);
                data.writeLong(target.temperature());
                data.writeLong(target.humidity());
                data.writeLong(target.continentalness());
                data.writeLong(target.erosion());
                data.writeLong(target.depth());
                data.writeLong(target.weirdness());
            }

            // The biome each of those climates resolves to, which pins the R-tree search against the
            // region table rather than against our own reading of it. The end has no table: its source
            // reads the erosion entry at the middle of the sixteen by sixteen.
            if (end) {
                net.minecraft.world.level.biome.BiomeResolver resolver = net.minecraft.world.level.biome.TheEndBiomeSource
                    .create(vanilla.lookupOrThrow(Registries.BIOME)).createResolver(sampler);
                for (int[] position : positions) {
                    data.writeUTF(resolver.getNoiseBiome(position[0] >> 2, position[1] >> 2, position[2] >> 2)
                        .unwrapKey().orElseThrow().identifier().toString());
                }
            } else {
                Climate.ParameterList<ResourceKey<Biome>> parameters =
                        net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterList.knownPresets()
                                .get(nether ? net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterList.Preset.NETHER
                                    : net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterList.Preset.OVERWORLD);
                for (int[] position : positions) {
                    Climate.TargetPoint target = sampler.sample(position[0] >> 2, position[1] >> 2, position[2] >> 2);
                    data.writeUTF(parameters.findValue(target).identifier().toString());
                }
            }

            data.writeInt(volumeChunks.length);
            for (int[] chunk : volumeChunks) {
                data.writeInt(chunk[0]);
                data.writeInt(chunk[1]);

                // One caching context per chunk, as NoiseChunk has, with nothing in its fields: no
                // beardifier reads as zero.
                SamplerContext fill = SamplerContext.builder().enableCaches().build();
                DensityVolume volume = new DensityVolume(16, height, 16, chunk[0] << 4, minY, chunk[1] << 4);
                writeVolume(data, randomState, fill, router.finalDensity(), volume);

                SamplerContext biomes = SamplerContext.builder().enableCaches().build();
                DensityVolume quarts = new DensityVolume(4, height >> 2, 4, chunk[0] << 4, minY, chunk[1] << 4, 4, 4, 4);
                for (DensityFunction climate : new DensityFunction[]{router.temperature(), router.vegetation(), router.continents(),
                        router.erosion(), router.depth(), router.ridges()}) {
                    writeVolume(data, randomState, biomes, climate, quarts);
                }

                DensityVolume surface = new DensityVolume(16, 1, 16, chunk[0] << 4, 0, chunk[1] << 4);
                writeVolume(data, randomState, fill, router.chunkSurfaceLevel(), surface);
            }
        }

        System.out.println("Wrote " + positions.size() + " samples and " + volumeChunks.length + " chunk volumes to " + out);
    }

    private static void writeVolume(DataOutputStream data, RandomState randomState, SamplerContext context, DensityFunction function,
            DensityVolume volume) throws java.io.IOException {
        DensityBuffer buffer = DensityBuffer.createUnpooled(volume.size());
        randomState.getSampler(function).sampleVolume(context, buffer, volume);
        for (int i = 0; i < volume.size(); i++) {
            data.writeFloat(buffer.get(i));
        }
    }

    private static DensityFunction entryOf(NoiseRouter router, Aquifer.Config aquifers, HolderLookup.RegistryLookup<DensityFunction> functions,
            String name) {
        return switch (name) {
            case "temperature" -> router.temperature();
            case "vegetation" -> router.vegetation();
            case "continents" -> router.continents();
            case "erosion" -> router.erosion();
            case "depth" -> router.depth();
            case "ridges" -> router.ridges();
            case "chunk_surface_level" -> router.chunkSurfaceLevel();
            case "final_density" -> router.finalDensity();
            case "aquifer_barrier" -> aquifers.barrierNoise();
            case "aquifer_fluid_level_floodedness" -> aquifers.fluidLevelFloodednessNoise();
            case "aquifer_fluid_level_spread" -> aquifers.fluidLevelSpreadNoise();
            case "aquifer_lava" -> aquifers.lavaNoise();
            case "aquifer_exclusion" -> aquifers.exclusion();
            case "aquifer_surface_level" -> aquifers.surfaceLevel();
            default -> functions.getOrThrow(ResourceKey.create(Registries.DENSITY_FUNCTION, Identifier.withDefaultNamespace(name))).value();
        };
    }

    /**
     * A spread of positions rather than a block: the tree has branches that only run at particular
     * heights (the vein bands, the deep dark check, the y gradients) and particular climates, so a
     * cluster near the origin would leave most of it unmeasured.
     */
    private static List<int[]> samplePositions(int minY, int height) {
        List<int[]> positions = new ArrayList<>();

        // Every height a router branch changes at, over a horizontal spread wide enough to cross
        // several continents worth of climate noise. The nether's are its two gradients' ends, the
        // lava sea and the roof, and cover the end's two gradients' ends as well.
        int[] heights = minY == 0
            ? new int[]{0, 3, 7, 8, 16, 24, 31, 32, 33, 50, 64, 100, 104, 112, 120, 127}
            : new int[]{-64, -60, -32, -8, 0, 16, 50, 63, 64, 96, 128, 192, 256, 319};
        int[] coords = {-8192, -1024, -333, -64, -4, 0, 5, 61, 512, 1777, 9000};

        for (int x : coords) {
            for (int z : coords) {
                for (int y : heights) {
                    positions.add(new int[]{x, y, z});
                }
            }
        }

        // A dense run through one chunk as well, which is where the cell interpolation and the four
        // block climate grid actually land.
        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                positions.add(new int[]{x, minY == 0 ? 31 : 63, z});
                positions.add(new int[]{x, minY == 0 ? 75 : 11, z});
            }
        }

        return positions;
    }
}

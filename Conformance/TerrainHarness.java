import net.minecraft.SharedConstants;
import net.minecraft.core.HolderLookup;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.registries.Registries;
import net.minecraft.resources.Identifier;
import net.minecraft.resources.ResourceKey;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.biome.Biome;
import net.minecraft.world.level.biome.Climate;
import net.minecraft.world.level.levelgen.DensityFunction;
import net.minecraft.world.level.levelgen.NoiseGeneratorSettings;
import net.minecraft.world.level.levelgen.NoiseRouter;
import net.minecraft.world.level.levelgen.RandomState;
import net.minecraft.world.level.levelgen.synth.NormalNoise;

import java.io.DataOutputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;
import java.util.zip.GZIPOutputStream;

/**
 * Runs the real vanilla noise router over a grid of positions and writes down every number it
 * produced, for {@code TerrainConformanceTest} to replay.
 *
 * <p>This is the only thing that can tell the density function port from a plausible impostor. Our own
 * tests can check that terrain has a ground level and that biomes vary, and a tree with a wrong
 * constant, a wrong spline derivative or a noise seeded from the wrong name passes all of them while
 * producing a different world. The router is what every part of terrain generation reads, so pinning
 * its fifteen entries pins the noise primitives, the whole density function tree, the JSON parsing and
 * the per octave seeding at once.
 *
 * <p>Sampled through {@code RandomState}, which is the seeded tree with no chunk caches attached: a
 * cache is per chunk and a marker computes exactly what it wraps, so the values are the same either
 * way and this needs no {@code ChunkAccess}.
 *
 * <p>The climate half is sampled separately and quantised, because that is what the biome search
 * actually compares.
 *
 * <p>Fixture format, all big endian: an int count, then per sample the three int coordinates followed
 * by fifteen doubles in {@link #ROUTER_ENTRIES} order. Then an int count of climate samples, each
 * three ints and six longs.
 */
public final class TerrainHarness {
    /** The order the doubles are written in, and the order the C# side reads them back. */
    static final String[] ROUTER_ENTRIES = {
        "barrier", "fluid_level_floodedness", "fluid_level_spread", "lava",
        "temperature", "vegetation", "continents", "erosion", "depth", "ridges",
        "preliminary_surface_level", "final_density", "vein_toggle", "vein_ridged", "vein_gap"
    };

    private static final long SEED = 1234567890L;

    public static void main(String[] args) throws Exception {
        Path out = Path.of(args.length > 0 ? args[0] : "vanilla-terrain.bin.gz");
        Files.createDirectories(out.getParent());

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        // Decoded from the vanilla pack rather than taken from VanillaRegistries' bootstrap objects,
        // because the pack is what a server reads and the port parses. See Harness.buildRegistryAccess.
        RegistryAccess.Frozen vanilla = Harness.buildRegistryAccess();
        HolderLookup.RegistryLookup<NoiseGeneratorSettings> settingsLookup =
                vanilla.lookupOrThrow(Registries.NOISE_SETTINGS);
        HolderLookup.RegistryLookup<NormalNoise.NoiseParameters> noises =
                vanilla.lookupOrThrow(Registries.NOISE);

        NoiseGeneratorSettings settings = settingsLookup.getOrThrow(NoiseGeneratorSettings.OVERWORLD).value();
        RandomState randomState = RandomState.create(settings, noises, SEED);
        NoiseRouter router = randomState.router();

        List<int[]> positions = samplePositions();

        try (OutputStream raw = Files.newOutputStream(out);
             GZIPOutputStream gzip = new GZIPOutputStream(raw);
             DataOutputStream data = new DataOutputStream(gzip)) {

            data.writeLong(SEED);

            data.writeInt(positions.size());
            for (int[] position : positions) {
                data.writeInt(position[0]);
                data.writeInt(position[1]);
                data.writeInt(position[2]);

                DensityFunction.FunctionContext context =
                        new DensityFunction.SinglePointContext(position[0], position[1], position[2]);

                for (String entry : ROUTER_ENTRIES) {
                    data.writeDouble(entryOf(router, entry).compute(context));
                }
            }

            Climate.Sampler sampler = randomState.sampler();
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

            // The biome each of those climates resolves to, which is what pins the R-tree search
            // against the 7599 region table rather than against our own reading of it.
            Climate.ParameterList<ResourceKey<Biome>> parameters =
                    net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterList.knownPresets()
                            .get(net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterList.Preset.OVERWORLD);

            data.writeInt(positions.size());
            for (int[] position : positions) {
                Climate.TargetPoint target = sampler.sample(position[0] >> 2, position[1] >> 2, position[2] >> 2);
                data.writeUTF(parameters.findValue(target).identifier().toString());
            }
        }

        System.out.println("Wrote " + positions.size() + " samples to " + out);
    }

    private static DensityFunction entryOf(NoiseRouter router, String name) {
        return switch (name) {
            case "barrier" -> router.barrierNoise();
            case "fluid_level_floodedness" -> router.fluidLevelFloodednessNoise();
            case "fluid_level_spread" -> router.fluidLevelSpreadNoise();
            case "lava" -> router.lavaNoise();
            case "temperature" -> router.temperature();
            case "vegetation" -> router.vegetation();
            case "continents" -> router.continents();
            case "erosion" -> router.erosion();
            case "depth" -> router.depth();
            case "ridges" -> router.ridges();
            case "preliminary_surface_level" -> router.preliminarySurfaceLevel();
            case "final_density" -> router.finalDensity();
            case "vein_toggle" -> router.veinToggle();
            case "vein_ridged" -> router.veinRidged();
            case "vein_gap" -> router.veinGap();
            default -> throw new IllegalArgumentException("Unknown router entry: " + name);
        };
    }

    /**
     * A spread of positions rather than a block: the tree has branches that only run at particular
     * heights (the vein bands, the deep dark check, the y gradients) and particular climates, so a
     * cluster near the origin would leave most of it unmeasured.
     */
    private static List<int[]> samplePositions() {
        List<int[]> positions = new ArrayList<>();

        // Every height a router branch changes at, over a horizontal spread wide enough to cross
        // several continents worth of climate noise.
        int[] heights = {-64, -60, -32, -8, 0, 16, 50, 63, 64, 96, 128, 192, 256, 319};
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
                positions.add(new int[]{x, 63, z});
                positions.add(new int[]{x, 11, z});
            }
        }

        return positions;
    }
}

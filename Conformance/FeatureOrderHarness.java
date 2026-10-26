import java.io.BufferedOutputStream;
import java.io.DataOutputStream;
import java.io.FileOutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;
import java.util.zip.GZIPOutputStream;
import net.minecraft.SharedConstants;
import net.minecraft.core.Holder;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.registries.Registries;
import net.minecraft.resources.ResourceKey;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.biome.Biome;
import net.minecraft.world.level.biome.BiomeSource;
import net.minecraft.world.level.biome.FeatureSorter;
import net.minecraft.world.level.biome.MultiNoiseBiomeSource;
import net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterList;
import net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterLists;
import net.minecraft.world.level.levelgen.placement.PlacedFeature;

/**
 * Writes down the order the vanilla feature sorter puts every placed feature in, per decoration step,
 * for the overworld and the nether biome sources.
 *
 * <p>Usage: {@code java FeatureOrderHarness <fixture>}. See Conformance/featureorder.sh.
 *
 * <p>That order is not decoration: a feature's <b>index in this list</b> is what seeds it, so two
 * builds that disagree about it generate different worlds out of identical features. It is also
 * decided by things a port has no reason to think are load bearing, chiefly which biomes are fed to
 * the sorter and in what order, since that is what breaks a tie between two features nothing orders
 * against each other.
 */
public class FeatureOrderHarness {

    public static void main(String[] args) throws Exception {
        if (args.length < 1) {
            System.err.println("usage: FeatureOrderHarness <fixture>");
            System.exit(2);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        RegistryAccess.Frozen registries = Harness.buildRegistryAccess();
        Path fixture = Path.of(args[0]);
        Files.createDirectories(fixture.getParent());

        try (DataOutputStream out = new DataOutputStream(new GZIPOutputStream(
            new BufferedOutputStream(new FileOutputStream(fixture.toFile()))))) {

            out.writeInt(3);
            write(out, registries, "minecraft:overworld", preset(registries, MultiNoiseBiomeSourceParameterLists.OVERWORLD));
            write(out, registries, "minecraft:nether", preset(registries, MultiNoiseBiomeSourceParameterLists.NETHER));
            write(out, registries, "minecraft:the_end",
                net.minecraft.world.level.biome.TheEndBiomeSource.create(registries.lookupOrThrow(Registries.BIOME)));
        }

        System.out.println("=== feature order fixture vs " + SharedConstants.getCurrentVersion().name()
            + " ===");
        System.out.println(Files.size(fixture) + " bytes written to " + fixture);
    }

    private static BiomeSource preset(RegistryAccess.Frozen registries, ResourceKey<MultiNoiseBiomeSourceParameterList> preset) {
        return MultiNoiseBiomeSource.createFromPreset(
            registries.lookupOrThrow(Registries.MULTI_NOISE_BIOME_SOURCE_PARAMETER_LIST).getOrThrow(preset));
    }

    private static void write(DataOutputStream out, RegistryAccess.Frozen registries, String name,
        BiomeSource source) throws Exception {

        Registry<PlacedFeature> placed = registries.lookupOrThrow(Registries.PLACED_FEATURE);
        List<Holder<Biome>> biomes = List.copyOf(source.possibleBiomes());

        List<FeatureSorter.StepFeatureData> steps = FeatureSorter.buildFeaturesPerStep(biomes,
            biome -> biome.value().getGenerationSettings().features(), true);

        out.writeUTF(name);

        // The biomes the sorter was given, in the order it was given them, which is what breaks ties
        // between two features nothing else orders.
        out.writeInt(biomes.size());
        for (Holder<Biome> biome : biomes) {
            out.writeUTF(biome.getRegisteredName());
        }

        out.writeInt(steps.size());
        for (FeatureSorter.StepFeatureData step : steps) {
            out.writeInt(step.features().size());
            for (PlacedFeature feature : step.features()) {
                out.writeUTF(placed.getResourceKey(feature)
                    .map(ResourceKey::identifier)
                    .orElseThrow(() -> new IllegalStateException("A placed feature is not in the registry"))
                    .toString());
            }
        }

        System.out.println(name + ": " + biomes.size() + " biomes, " + steps.size() + " steps, "
            + steps.stream().mapToInt(step -> step.features().size()).sum() + " features");
    }
}

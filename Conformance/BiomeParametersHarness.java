import net.minecraft.core.registries.Registries;
import net.minecraft.resources.ResourceKey;
import net.minecraft.world.level.biome.Biome;
import net.minecraft.world.level.biome.Climate;
import net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterList;

import com.mojang.datafixers.util.Pair;

import java.io.PrintWriter;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;
import java.util.Map;

/**
 * Writes each multi noise biome source preset out as JSON: one entry per biome region, carrying its
 * six climate ranges, its offset and the biome it selects.
 *
 * <p>The overworld's list is not in the datapack. {@code multi_noise_biome_source_parameter_list}
 * holds only the name of a preset, and the preset itself is {@code OverworldBiomeBuilder}, a thousand
 * lines of hand written parameter ranges compiled into the jar. Dumping it is how the C# side gets the
 * real table instead of a transcription of it, and the ranges are quantised longs so a transcription
 * would be a thousand chances to move a boundary by one ten thousandth.
 *
 * <p>{@code knownPresets} resolves against the identity function rather than a registry, so this needs
 * no server, no datapacks and no registry access.
 */
public final class BiomeParametersHarness {
    public static void main(String[] args) throws Exception {
        Path out = Path.of(args.length > 0 ? args[0] : "biome-parameters.json");
        Files.createDirectories(out.getParent());

        Map<MultiNoiseBiomeSourceParameterList.Preset, Climate.ParameterList<ResourceKey<Biome>>> presets =
                MultiNoiseBiomeSourceParameterList.knownPresets();

        StringBuilder sb = new StringBuilder();
        sb.append("{");

        boolean firstPreset = true;
        // Sorted so the file does not churn between runs on hash order alone.
        List<MultiNoiseBiomeSourceParameterList.Preset> ordered = presets.keySet().stream()
                .sorted((a, b) -> a.id().toString().compareTo(b.id().toString()))
                .toList();

        for (MultiNoiseBiomeSourceParameterList.Preset preset : ordered) {
            if (!firstPreset) {
                sb.append(",");
            }
            firstPreset = false;

            sb.append("\"").append(preset.id()).append("\":[");

            boolean firstEntry = true;
            for (Pair<Climate.ParameterPoint, ResourceKey<Biome>> entry : presets.get(preset).values()) {
                if (!firstEntry) {
                    sb.append(",");
                }
                firstEntry = false;

                Climate.ParameterPoint point = entry.getFirst();
                sb.append("{\"biome\":\"").append(entry.getSecond().identifier()).append("\",\"p\":[");
                appendParameter(sb, point.temperature());
                sb.append(",");
                appendParameter(sb, point.humidity());
                sb.append(",");
                appendParameter(sb, point.continentalness());
                sb.append(",");
                appendParameter(sb, point.erosion());
                sb.append(",");
                appendParameter(sb, point.depth());
                sb.append(",");
                appendParameter(sb, point.weirdness());
                sb.append("],\"offset\":").append(point.offset()).append("}");
            }

            sb.append("]");
        }

        sb.append("}");

        try (PrintWriter writer = new PrintWriter(Files.newBufferedWriter(out, StandardCharsets.UTF_8))) {
            writer.print(sb);
        }

        int total = presets.values().stream().mapToInt(list -> list.values().size()).sum();
        System.out.println("Wrote " + presets.size() + " presets, " + total + " entries, to " + out);
    }

    /** The quantised longs verbatim, since that is what the search actually compares. */
    private static void appendParameter(StringBuilder sb, Climate.Parameter parameter) {
        sb.append("[").append(parameter.min()).append(",").append(parameter.max()).append("]");
    }
}

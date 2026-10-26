import java.io.BufferedWriter;
import java.io.OutputStreamWriter;
import java.lang.reflect.Method;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Optional;
import java.util.zip.GZIPOutputStream;

import net.minecraft.SharedConstants;
import net.minecraft.core.Holder;
import net.minecraft.core.HolderLookup;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.particles.ParticleOptions;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.core.registries.Registries;
import net.minecraft.resources.Identifier;
import net.minecraft.resources.RegistryDataLoader;
import net.minecraft.resources.ResourceKey;
import net.minecraft.server.Bootstrap;
import net.minecraft.server.RegistryLayer;
import net.minecraft.server.packs.PackType;
import net.minecraft.server.packs.repository.ServerPacksSource;
import net.minecraft.server.packs.resources.MultiPackResourceManager;
import net.minecraft.sounds.Music;
import net.minecraft.sounds.SoundEvent;
import net.minecraft.tags.TagLoader;
import net.minecraft.util.Mth;
import net.minecraft.util.TriState;
import net.minecraft.world.attribute.AmbientAdditionsSettings;
import net.minecraft.world.attribute.AmbientParticle;
import net.minecraft.world.attribute.AmbientSounds;
import net.minecraft.world.attribute.BackgroundMusic;
import net.minecraft.world.attribute.BedRule;
import net.minecraft.world.attribute.EnvironmentAttribute;
import net.minecraft.world.attribute.EnvironmentAttributeSystem;
import net.minecraft.world.attribute.EnvironmentAttributes;
import net.minecraft.world.attribute.GaussianSampler;
import net.minecraft.world.attribute.SpatialAttributeInterpolator;
import net.minecraft.world.attribute.WeatherAttributes;
import net.minecraft.world.clock.ClockInstance;
import net.minecraft.world.clock.ClockManager;
import net.minecraft.world.entity.schedule.Activity;
import net.minecraft.world.level.MoonPhase;
import net.minecraft.world.level.biome.Biome;
import net.minecraft.world.level.biome.BiomeManager;
import net.minecraft.world.level.dimension.DimensionType;
import net.minecraft.world.phys.Vec3;
import net.minecraft.world.timeline.Timeline;
import org.joml.Vector3fc;
import org.joml.Vector4fc;

/**
 * Drives the real EnvironmentAttributeSystem over the vanilla pack's dimension types, biomes and timelines, and
 * writes what every attribute comes to across positions, clock times and weather, for
 * EnvironmentAttributeConformanceTest to replay through the port.
 * <p>
 * The level is the only thing stood in for. The biomes come from a fixed layout over quart cells that the test
 * repeats, the clock is a number, and the weather is two. Everything else is the vanilla builder: the dimension's
 * constant layer, the biome layer (reached by reflection, being private), each timeline in the dimension's holder
 * set, and WeatherAttributes for a dimension that can have weather. Each position is asked twice: with the
 * camera's GaussianSampler blend of biomes, as EnvironmentAttributeProbe fills it, and without, as any other
 * reader asks.
 */
public final class EnvironmentAttributeHarness {
    private static long clockTicks;
    private static float rainLevel;
    private static float thunderLevel;

    public static void main(String[] args) throws Exception {
        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();
        RegistryAccess.Frozen registries = buildRegistryAccess();

        Registry<Biome> biomeRegistry = registries.lookupOrThrow(Registries.BIOME);
        List<Holder.Reference<Biome>> biomes = new ArrayList<>(biomeRegistry.listElements().toList());
        biomes.sort(Comparator.comparing(holder -> holder.key().identifier().toString()));
        Holder<Biome> plains = biomeRegistry.getOrThrow(net.minecraft.world.level.biome.Biomes.PLAINS);

        BiomeManager biomeManager = new BiomeManager((x, y, z) -> layout(biomes, plains, x, y, z), 0L);
        ClockManager clocks = clock -> new ClockInstance() {
            public long totalTicks() { return clockTicks; }
            public float partialTick() { return 0.0F; }
            public float rate() { return 1.0F; }
            public boolean isPaused() { return false; }
        };
        WeatherAttributes.WeatherAccess weather = new WeatherAttributes.WeatherAccess() {
            public float rainLevel() { return rainLevel; }
            public float thunderLevel() { return thunderLevel; }
        };
        Method addBiomeLayer = EnvironmentAttributeSystem.class.getDeclaredMethod("addBiomeLayer",
            EnvironmentAttributeSystem.Builder.class, HolderLookup.class, BiomeManager.class);
        addBiomeLayer.setAccessible(true);

        List<EnvironmentAttribute<?>> attributes = new ArrayList<>();
        for (EnvironmentAttribute<?> attribute : BuiltInRegistries.ENVIRONMENT_ATTRIBUTE) {
            // Kept as a tag on the C# side, and spawning is a server's business.
            if (attribute != EnvironmentAttributes.NATURAL_MOB_SPAWNS) {
                attributes.add(attribute);
            }
        }

        double[][] positions = {
            {0.3, 64.7, 0.9}, {17.5, 70.2, -33.1}, {-100.25, 12.0, 250.75}, {5.0, 300.0, 5.0}, {1000.6, -50.3, -2000.4},
            {-7.9, 64.0, 40.1}, {33.33, 100.5, 77.77}, {-63.2, 0.1, -8.6}, {9000.5, 64.0, 9000.5}
        };
        long[] overworldTicks = {
            0, 71, 92, 133, 300, 627, 730, 3000, 6000, 6001, 9000, 11270, 11867, 12000, 12399, 12600, 13000, 13252, 13670, 15000,
            18000, 21062, 22330, 23401, 23757, 23999, 24000 + 6000, 48000 + 18000, 96000 + 12500, 120000, 168000 + 23000, 192000 * 3 + 100
        };
        long[] otherTicks = {0, 2000, 9500, 12000, 23999};
        float[][] overworldWeather = {{0.0F, 0.0F}, {0.5F, 0.0F}, {1.0F, 0.0F}, {1.0F, 0.3F}, {1.0F, 1.0F}, {0.25F, 0.25F}};
        float[][] noWeather = {{0.0F, 0.0F}};

        Path out = Path.of(args[0]);
        Files.createDirectories(out.getParent());
        try (BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(new GZIPOutputStream(Files.newOutputStream(out)), StandardCharsets.UTF_8))) {
            writer.write("biomes");
            for (Holder.Reference<Biome> biome : biomes) {
                writer.write(" " + biome.key().identifier());
            }
            writer.write("\n");

            Registry<DimensionType> dimensionTypes = registries.lookupOrThrow(Registries.DIMENSION_TYPE);
            for (String name : new String[] {"minecraft:overworld", "minecraft:the_nether", "minecraft:the_end"}) {
                DimensionType dimension = dimensionTypes.getValueOrThrow(ResourceKey.create(Registries.DIMENSION_TYPE, Identifier.parse(name)));
                boolean canHaveWeather = dimension.hasSkyLight() && !dimension.hasCeiling() && !name.equals("minecraft:the_end");

                EnvironmentAttributeSystem.Builder builder = EnvironmentAttributeSystem.builder();
                builder.addConstantLayer(dimension.attributes());
                addBiomeLayer.invoke(null, builder, biomeRegistry, biomeManager);
                dimension.timelines().forEach(timeline -> builder.addTimelineLayer(timeline, clocks));
                if (canHaveWeather) {
                    WeatherAttributes.addBuiltinLayers(builder, weather);
                }
                EnvironmentAttributeSystem system = builder.build();

                boolean overworld = name.equals("minecraft:overworld");
                for (float[] weatherCase : overworld ? overworldWeather : noWeather) {
                    for (long ticks : overworld ? overworldTicks : otherTicks) {
                        for (double[] position : positions) {
                            clockTicks = ticks;
                            rainLevel = weatherCase[0];
                            thunderLevel = weatherCase[1];
                            system.invalidateTickCache();
                            Vec3 pos = new Vec3(position[0], position[1], position[2]);
                            SpatialAttributeInterpolator interpolator = new SpatialAttributeInterpolator();
                            GaussianSampler.sample(pos.scale(0.25), biomeManager::getNoiseBiomeAtQuart,
                                (weight, biome) -> interpolator.accumulate(weight, biome.value().getAttributes()));
                            writer.write("case " + name + " " + ticks + " " + bits(weatherCase[0]) + " " + bits(weatherCase[1]) + " "
                                + Long.toHexString(Double.doubleToRawLongBits(position[0])) + " "
                                + Long.toHexString(Double.doubleToRawLongBits(position[1])) + " "
                                + Long.toHexString(Double.doubleToRawLongBits(position[2])) + "\n");
                            for (EnvironmentAttribute<?> attribute : attributes) {
                                String id = BuiltInRegistries.ENVIRONMENT_ATTRIBUTE.getKey(attribute).toString();
                                if (attribute.isPositional()) {
                                    writer.write(id + " " + encode(system.getValue(attribute, pos, interpolator)) + " "
                                        + encode(system.getValue(attribute, pos, null)) + "\n");
                                }
                                else {
                                    writer.write(id + " " + encode(system.getDimensionValue(attribute)) + "\n");
                                }
                            }
                        }
                    }
                }
            }
        }
        System.out.println("Wrote " + out);
    }

    /** The test's biome layout: blocks of three by three quarts, five high, with a lone biome far out east and south. */
    private static Holder<Biome> layout(List<Holder.Reference<Biome>> biomes, Holder<Biome> plains, int quartX, int quartY, int quartZ) {
        if (quartX >= 2000 && quartZ >= 2000) {
            return plains;
        }
        int index = Math.floorMod(Math.floorDiv(quartX, 3) * 7 + Math.floorDiv(quartZ, 3) * 13 + Math.floorDiv(quartY, 5) * 3, biomes.size());
        return biomes.get(index);
    }

    private static String bits(float value) {
        return Integer.toHexString(Float.floatToRawIntBits(value));
    }

    private static String bits(double value) {
        return Long.toHexString(Double.doubleToRawLongBits(value));
    }

    private static String sound(Holder<SoundEvent> sound) {
        return sound.value().location().toString();
    }

    private static String music(Optional<Music> music) {
        return music.map(m -> sound(m.sound()) + "/" + m.minDelay() + "/" + m.maxDelay() + "/" + m.replaceCurrentMusic()).orElse("-");
    }

    /** One value as a single space free token, the same way the test writes the port's. */
    private static String encode(Object value) {
        return switch (value) {
            case Float number -> bits(number);
            case Boolean bool -> bool.toString();
            case Vector3fc vector -> bits(vector.x()) + "," + bits(vector.y()) + "," + bits(vector.z());
            case Vector4fc vector -> bits(vector.x()) + "," + bits(vector.y()) + "," + bits(vector.z()) + "," + bits(vector.w());
            case TriState state -> state.getSerializedName();
            case MoonPhase phase -> phase.getSerializedName();
            case Activity activity -> BuiltInRegistries.ACTIVITY.getKey(activity).toString();
            case ParticleOptions particle -> BuiltInRegistries.PARTICLE_TYPE.getKey(particle.getType()).toString();
            case BedRule rule -> rule.canSleep().getSerializedName() + "|" + rule.canSetSpawn().getSerializedName() + "|" + rule.destroyOnUse() + "|"
                + rule.destroyOnLeave() + "|" + rule.errorMessage().isPresent();
            case BackgroundMusic music -> music(music.defaultMusic()) + "|" + music(music.creativeMusic()) + "|" + music(music.underwaterMusic());
            case AmbientSounds sounds -> sounds.loop().map(EnvironmentAttributeHarness::sound).orElse("-") + "|"
                + sounds.mood().map(m -> sound(m.soundEvent()) + "/" + m.tickDelay() + "/" + m.blockSearchExtent() + "/" + bits(m.soundPositionOffset()))
                    .orElse("-") + "|"
                + String.join(";", sounds.additions().stream().map(EnvironmentAttributeHarness::addition).toList());
            case List<?> list -> list.isEmpty() ? "[]" : String.join(";", list.stream().map(element -> {
                AmbientParticle particle = (AmbientParticle) element;
                return BuiltInRegistries.PARTICLE_TYPE.getKey(particle.particle().getType()) + "@" + bits(particle.probability());
            }).toList());
            default -> throw new IllegalArgumentException("Cannot encode " + value.getClass());
        };
    }

    private static String addition(AmbientAdditionsSettings addition) {
        return sound(addition.soundEvent()) + "/" + bits(addition.tickChance());
    }

    /** The worldgen registries from the vanilla pack, with their own tags bound, as RegistryHarness builds them. */
    private static RegistryAccess.Frozen buildRegistryAccess() {
        List<Registry<?>> all = new ArrayList<>();
        java.util.Set<ResourceKey<? extends Registry<?>>> seen = new java.util.HashSet<>();
        RegistryLayer.createRegistryAccess().compositeAccess().registries().forEach(entry -> {
            all.add(entry.value());
            seen.add(entry.key());
        });
        MultiPackResourceManager resources = new MultiPackResourceManager(PackType.SERVER_DATA,
            List.of(ServerPacksSource.createVanillaPackSource().fullResources()));
        // Twice: the block tags before the pack decodes, or #infiniburn_overworld fails every dimension type, and the
        // timeline tags a dimension type's holder set names once the timeline registry exists.
        TagLoader.loadTagsForExistingRegistries(resources, RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY))
            .forEach(Registry.PendingTags::apply);
        List<HolderLookup.RegistryLookup<?>> lookups = new ArrayList<>();
        all.forEach(registry -> lookups.add((HolderLookup.RegistryLookup<?>) registry));
        RegistryDataLoader.load(resources, lookups, RegistryDataLoader.WORLD_REGISTRIES, Runnable::run).join()
            .registries().filter(entry -> !seen.contains(entry.key()))
            .forEach(entry -> all.add(entry.value()));
        RegistryAccess.Frozen registries = new RegistryAccess.ImmutableRegistryAccess(all).freeze();
        TagLoader.loadTagsForExistingRegistries(resources, registries).forEach(Registry.PendingTags::apply);
        return registries;
    }

    private EnvironmentAttributeHarness() {
    }
}

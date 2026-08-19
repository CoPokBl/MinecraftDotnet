import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import com.mojang.serialization.Codec;
import com.mojang.serialization.DataResult;
import com.mojang.serialization.DynamicOps;
import com.mojang.serialization.JsonOps;
import com.mojang.serialization.Lifecycle;
import java.io.FileReader;
import java.io.Reader;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import net.minecraft.SharedConstants;
import net.minecraft.core.Holder;
import net.minecraft.core.HolderLookup;
import net.minecraft.core.MappedRegistry;
import net.minecraft.core.RegistrationInfo;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.nbt.NbtOps;
import net.minecraft.nbt.Tag;
import net.minecraft.resources.RegistryDataLoader;
import net.minecraft.resources.RegistryOps;
import net.minecraft.resources.ResourceKey;
import net.minecraft.server.Bootstrap;
import net.minecraft.server.RegistryLayer;
import net.minecraft.server.packs.PackType;
import net.minecraft.server.packs.repository.ServerPacksSource;
import net.minecraft.server.packs.resources.MultiPackResourceManager;
import net.minecraft.tags.TagLoader;

/**
 * Parses the datapack driven registries our server sends with the same element codecs the client
 * uses on them, which is the one thing decoding the packet they arrive in cannot check.
 *
 * <p>Those registries travel as opaque NBT inside {@code registry_data}: its stream codec reads a
 * tag and stops, so <i>any</i> blob decodes and a malformed element only explodes later, when the
 * client runs {@code RegistryDataLoader} over it and refuses to finish configuration. The failure
 * looks like a client that connects and then drops with no useful message, so this runs those
 * codecs here instead.
 *
 * <p>The elements arrive here as JSON rather than as the NBT they go out as, so a number lands in
 * whatever tag type it fits rather than the one we wrote: a float of 2.0 arrives as a byte. Vanilla's
 * numeric codecs take any of them, so this checks the shape of an element rather than the exact tag
 * types in it.
 *
 * <p>Usage: {@code java RegistryHarness <registries.json>}, with the server jar and its libraries
 * on the classpath. See Conformance/registries.sh.
 */
public class RegistryHarness {

    public static void main(String[] args) throws Exception {
        if (args.length < 1) {
            System.err.println("usage: RegistryHarness <registries.json>");
            System.exit(2);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        RegistryAccess.Frozen registries = buildRegistryAccess();
        DynamicOps<Tag> ops = RegistryOps.create(NbtOps.INSTANCE, registries);

        JsonObject ours;
        try (Reader reader = new FileReader(args[0])) {
            ours = JsonParser.parseReader(reader).getAsJsonObject();
        }

        List<String> failures = new ArrayList<>();
        List<String> missing = new ArrayList<>();
        int checked = 0;

        for (RegistryDataLoader.RegistryData<?> data : RegistryDataLoader.SYNCHRONIZED_REGISTRIES) {
            ResourceKey<? extends Registry<?>> key = data.key();
            String name = key.identifier().toString();

            JsonElement entries = ours.get(name);
            if (entries == null) {
                // Every synchronised registry has to be there, or the client stops in
                // configuration waiting for one it never gets.
                missing.add(name);
                continue;
            }

            Codec<?> codec = data.elementCodec();
            JsonObject elements = entries.getAsJsonObject();
            if (elements.size() == 0) {
                failures.add(name + ": sent with no elements");
                continue;
            }

            for (Map.Entry<String, JsonElement> element : elements.entrySet()) {
                Tag tag = JsonOps.INSTANCE.convertTo(NbtOps.INSTANCE, element.getValue());
                DataResult<?> result = codec.parse(ops, tag);
                if (result.isError()) {
                    failures.add(name + " / " + element.getKey() + ": "
                        + result.error().orElseThrow().message());
                    continue;
                }

                checked++;
            }
        }

        System.out.println();
        System.out.println("=== registry conformance vs " + SharedConstants.getCurrentVersion().name() + " ===");
        for (String failure : failures) {
            System.out.println("FAIL  " + failure);
        }

        if (!missing.isEmpty()) {
            System.out.println("Missing " + missing.size() + " synchronised registries:");
            for (String name : missing) {
                System.out.println("  " + name);
            }
        }

        System.out.println(checked + " elements parsed, " + failures.size() + " failed");
        System.exit(failures.isEmpty() && missing.isEmpty() ? 0 : 1);
    }

    /**
     * As in Harness, vanilla's own registries so codecs that resolve ids have a target, but with
     * the tags loaded on top.
     *
     * <p>The tags are what makes this harness mean anything. Half the synchronised registries hold
     * a {@code HolderSet} written as a tag reference: an enchantment's {@code supported_items} is
     * {@code #minecraft:enchantable/armor}, a dialog sits in {@code #minecraft:quick_actions}. With
     * no tags bound the codec cannot resolve any of them and reports every element as broken, which
     * looks exactly like our data being wrong.
     */
    @SuppressWarnings({"unchecked", "rawtypes"})
    private static RegistryAccess.Frozen buildRegistryAccess() {
        List<Registry<?>> all = new ArrayList<>();
        java.util.Set<ResourceKey<? extends Registry<?>>> seen = new java.util.HashSet<>();

        RegistryLayer.createRegistryAccess().compositeAccess().registries().forEach(entry -> {
            all.add(entry.value());
            seen.add(entry.key());
        });

        MultiPackResourceManager resources = new MultiPackResourceManager(PackType.SERVER_DATA,
            List.of(ServerPacksSource.createVanillaPackSource()));

        // Tags twice, and both are needed. The block and item tags have to be bound before the pack
        // decodes or a dimension type naming #infiniburn_overworld fails its whole registry; the
        // datapack registries' own tags can only be bound once those registries exist.
        TagLoader.loadTagsForExistingRegistries(resources,
                RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY))
            .forEach(Registry.PendingTags::apply);

        List<HolderLookup.RegistryLookup<?>> lookups = new ArrayList<>();
        all.forEach(registry -> lookups.add((HolderLookup.RegistryLookup<?>) registry));

        RegistryDataLoader
            .load(resources, lookups, RegistryDataLoader.WORLDGEN_REGISTRIES, Runnable::run)
            .join()
            .registries().filter(entry -> !seen.contains(entry.key()))
            .forEach(entry -> all.add(entry.value()));

        RegistryAccess.Frozen registries = new RegistryAccess.ImmutableRegistryAccess(all).freeze();

        TagLoader.loadTagsForExistingRegistries(resources, registries)
            .forEach(Registry.PendingTags::apply);

        return registries;
    }
}

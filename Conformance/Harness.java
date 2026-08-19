import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import java.io.FileReader;
import java.io.Reader;
import java.util.ArrayList;
import java.util.List;
import java.util.function.Function;
import net.minecraft.SharedConstants;
import net.minecraft.core.Holder;
import net.minecraft.core.HolderLookup;
import net.minecraft.core.MappedRegistry;
import net.minecraft.core.RegistrationInfo;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.tags.TagLoader;
import net.minecraft.server.packs.resources.MultiPackResourceManager;
import net.minecraft.server.packs.repository.ServerPacksSource;
import net.minecraft.server.packs.PackType;
import net.minecraft.resources.RegistryDataLoader;
import net.minecraft.core.component.DataComponentInitializers;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.network.FriendlyByteBuf;
import net.minecraft.network.ProtocolInfo;
import net.minecraft.network.RegistryFriendlyByteBuf;
import net.minecraft.network.protocol.Packet;
import net.minecraft.network.protocol.configuration.ConfigurationProtocols;
import net.minecraft.network.protocol.game.ClientboundLevelChunkWithLightPacket;
import net.minecraft.network.protocol.game.ClientboundSetEntityDataPacket;
import net.minecraft.network.protocol.game.GameProtocols;
import net.minecraft.network.syncher.EntityDataSerializer;
import net.minecraft.network.syncher.EntityDataSerializers;
import net.minecraft.network.protocol.login.LoginProtocols;
import net.minecraft.resources.ResourceKey;
import net.minecraft.server.Bootstrap;
import net.minecraft.server.RegistryLayer;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.chunk.LevelChunkSection;
import net.minecraft.world.level.chunk.PalettedContainerFactory;

/**
 * Decodes a corpus of packets produced by our C# implementation using the vanilla stream
 * codecs, which is the same code the client runs. A packet that decodes cleanly and consumes
 * exactly the bytes we wrote is wire compatible; anything else is reported.
 *
 * <p>Usage: {@code java Harness <corpus.json>}, with the server jar and its libraries on the
 * classpath. See Conformance/run.sh.
 */
public class Harness {

    public static void main(String[] args) throws Exception {
        if (args.length < 1) {
            System.err.println("usage: Harness <corpus.json>");
            System.exit(2);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        RegistryAccess.Frozen registries = buildRegistryAccess();
        Function<ByteBuf, RegistryFriendlyByteBuf> gameDecorator =
            buf -> new RegistryFriendlyByteBuf(buf, registries);

        ProtocolInfo<?> play = GameProtocols.CLIENTBOUND_TEMPLATE.bind(gameDecorator);
        ProtocolInfo<?> configuration = ConfigurationProtocols.CLIENTBOUND_TEMPLATE.bind(FriendlyByteBuf::new);
        ProtocolInfo<?> login = LoginProtocols.CLIENTBOUND_TEMPLATE.bind(FriendlyByteBuf::new);

        JsonArray corpus;
        try (Reader reader = new FileReader(args[0])) {
            corpus = JsonParser.parseReader(reader).getAsJsonArray();
        }

        int passed = 0;
        List<String> failures = new ArrayList<>();

        for (JsonElement element : corpus) {
            JsonObject entry = element.getAsJsonObject();
            String state = entry.get("state").getAsString();
            String name = entry.get("name").getAsString();
            byte[] bytes = hexToBytes(entry.get("hex").getAsString());

            ProtocolInfo<?> protocol = switch (state) {
                case "Play" -> play;
                case "Configuration" -> configuration;
                case "Login" -> login;
                default -> null;
            };
            if (protocol == null) {
                failures.add(name + " [" + state + "]: no vanilla protocol for that state");
                continue;
            }

            ByteBuf buf = Unpooled.wrappedBuffer(bytes);
            try {
                Packet<?> packet = protocol.codec().decode(buf);
                int extra = buf.readableBytes();

                if (entry.has("sections")) {
                    String mismatch = checkChunkSections(packet, entry.get("sections").getAsInt(),
                        registries, entry.has("probes") ? entry.get("probes").getAsJsonArray() : null);
                    if (mismatch != null) {
                        failures.add(name + " [" + state + "]: " + mismatch);
                        continue;
                    }
                }

                if (entry.has("serialiser")) {
                    String mismatch = checkSerialiser(packet, entry.get("serialiser").getAsString());
                    if (mismatch != null) {
                        failures.add(name + " [" + state + "]: " + mismatch);
                        continue;
                    }
                }

                if (extra > 0) {
                    // The same complaint the client makes: our writer emitted trailing data
                    failures.add(name + " [" + state + "]: vanilla read "
                        + (bytes.length - extra) + " of " + bytes.length + " bytes, "
                        + extra + " left over (decoded as " + packet.getClass().getSimpleName() + ")");
                    continue;
                }
                passed++;
            }
            catch (Exception ex) {
                Throwable root = ex;
                while (root.getCause() != null) root = root.getCause();
                failures.add(name + " [" + state + "]: " + root.getClass().getSimpleName()
                    + ": " + root.getMessage());
            }
        }

        System.out.println();
        System.out.println("=== packet conformance vs " + SharedConstants.getCurrentVersion().name() + " ===");
        for (String failure : failures) {
            System.out.println("FAIL  " + failure);
        }
        System.out.println(passed + " passed, " + failures.size() + " failed");
        System.exit(failures.isEmpty() ? 0 : 1);
    }

    /**
     * Reads the chunk's sections the way the client does after the packet decodes.
     *
     * <p>Decoding a chunk packet proves almost nothing on its own: the sections arrive as one
     * opaque byte array, so a blob of the wrong length or with a mis-encoded section sails
     * through and only explodes later in {@code LevelChunk.replaceWithPacketData}. That's this
     * check: parse exactly as many sections as the world height implies, then insist the blob
     * is spent.
     *
     * <p>Being spent is necessary and not sufficient. A paletted container written at the wrong
     * bits per entry occupies exactly the right number of bytes and decodes happily into different
     * blocks, which is how a silently corrupt direct palette passed this harness for as long as it
     * existed. So the probes are read back with vanilla's own {@code getBlockState} and compared
     * against the state ids our writer put in.
     *
     * @return a description of the mismatch, or null when it lines up
     */
    private static String checkChunkSections(Packet<?> packet, int expectedSections,
        RegistryAccess.Frozen registries, JsonArray probes) {

        if (!(packet instanceof ClientboundLevelChunkWithLightPacket chunk)) {
            return "expected a level_chunk_with_light packet, got " + packet.getClass().getSimpleName();
        }

        FriendlyByteBuf buf = chunk.getChunkData().getReadBuffer();
        int size = buf.readableBytes();
        PalettedContainerFactory factory = PalettedContainerFactory.create(registries);

        LevelChunkSection[] sections = new LevelChunkSection[expectedSections];
        for (int i = 0; i < expectedSections; i++) {
            try {
                sections[i] = new LevelChunkSection(factory);
                sections[i].read(buf);
            }
            catch (Exception ex) {
                return "section " + i + " of " + expectedSections + " failed to read at byte "
                    + buf.readerIndex() + " of " + size + ": " + ex.getClass().getSimpleName()
                    + ": " + ex.getMessage();
            }
        }

        int extra = buf.readableBytes();
        if (extra > 0) {
            return expectedSections + " sections read, " + extra + " of " + size
                + " bytes left over";
        }

        if (probes == null) {
            return null;
        }

        for (JsonElement element : probes) {
            JsonObject probe = element.getAsJsonObject();
            int index = probe.get("section").getAsInt();
            int x = probe.get("x").getAsInt();
            int y = probe.get("y").getAsInt();
            int z = probe.get("z").getAsInt();
            int expected = probe.get("state").getAsInt();

            if (index < 0 || index >= sections.length) {
                return "probe names section " + index + ", of " + sections.length;
            }

            int actual = Block.getId(sections[index].getBlockState(x, y, z));
            if (actual != expected) {
                return "section " + index + " at " + x + "," + y + "," + z
                    + ": we wrote state " + expected + ", vanilla read " + actual
                    + " (" + sections[index].getBlockState(x, y, z) + ")";
            }
        }

        return null;
    }

    /**
     * Checks that the metadata type id we wrote resolves to the serializer we meant, named as
     * its field in {@link net.minecraft.network.syncher.EntityDataSerializers}.
     *
     * <p>Bytes alone can't tell a mis-numbered type from a correct one when the two serializers
     * share a wire shape, every variant being a var int, so the packet decodes cleanly while
     * meaning something else entirely. Only the id is checked here; the value's encoding is
     * already covered by the decode itself.
     *
     * @return a description of the mismatch, or null when it lines up
     */
    private static String checkSerialiser(Packet<?> packet, String expectedField) throws Exception {
        if (!(packet instanceof ClientboundSetEntityDataPacket data)) {
            return "expected a set_entity_data packet, got " + packet.getClass().getSimpleName();
        }
        if (data.packedItems().size() != 1) {
            return "expected exactly one metadata field, got " + data.packedItems().size();
        }

        Object expected = EntityDataSerializers.class.getField(expectedField).get(null);
        EntityDataSerializer<?> actual = data.packedItems().getFirst().serializer();
        if (actual == expected) {
            return null;
        }

        return "type id " + EntityDataSerializers.getSerializedId(actual) + " is "
            + nameOf(actual) + ", expected " + expectedField + " (id "
            + EntityDataSerializers.getSerializedId((EntityDataSerializer<?>) expected) + ")";
    }

    private static String nameOf(EntityDataSerializer<?> serializer) throws Exception {
        for (java.lang.reflect.Field field : EntityDataSerializers.class.getFields()) {
            if (field.get(null) == serializer) {
                return field.getName();
            }
        }
        return serializer.getClass().getSimpleName();
    }

    /**
     * Vanilla's own registries, so codecs that resolve ids (block states, dimension types,
     * world clocks) have something to resolve against. Element ids won't match the ones our
     * server hands out, which is fine: this checks packet shape, not registry contents.
     */
    @SuppressWarnings({"unchecked", "rawtypes"})
    static RegistryAccess.Frozen buildRegistryAccess() {
        List<Registry<?>> all = new ArrayList<>();
        java.util.Set<ResourceKey<? extends Registry<?>>> seen = new java.util.HashSet<>();

        // The static registries (blocks, items, entity types, ...) come ready made
        RegistryLayer.createRegistryAccess().compositeAccess().registries().forEach(entry -> {
            all.add(entry.value());
            seen.add(entry.key());
        });

        // The datapack driven ones are decoded from the vanilla pack, which is where a server gets
        // them: RegistryDataLoader over the resource manager is the only route they take, and it is
        // what lets a datapack replace any of them.
        //
        // They are deliberately not VanillaRegistries' bootstrap objects. Those are the input to the
        // data generator that writes the pack, and the encode is lossy wherever a codec's forGetter
        // names the wrong field: CherryFoliagePlacer's corner_hole_chance reads
        // wideBottomLayerHoleChance, so the shipped cherry.json says 0.25 where the bootstrap object
        // holds 0.5, and every cherry tree a server grows uses the 0.25. A harness built on the
        // bootstrap objects measures against a configuration no world is generated with.
        MultiPackResourceManager resources = new MultiPackResourceManager(
            PackType.SERVER_DATA, List.of(ServerPacksSource.createVanillaPackSource()));

        // Half the pack's own elements name a tag: a dimension type holds #infiniburn_overworld, and
        // decoding one with tags unbound fails the whole registry rather than reading as empty.
        TagLoader.loadTagsForExistingRegistries(resources,
                RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY))
            .forEach(Registry.PendingTags::apply);

        List<HolderLookup.RegistryLookup<?>> lookups = new ArrayList<>();
        all.forEach(registry -> lookups.add((HolderLookup.RegistryLookup<?>) registry));

        RegistryAccess.Frozen worldgen = RegistryDataLoader
            .load(resources, lookups, RegistryDataLoader.WORLDGEN_REGISTRIES, Runnable::run)
            .join();

        worldgen.registries().filter(entry -> !seen.contains(entry.key()))
            .forEach(entry -> all.add(entry.value()));

        RegistryAccess.Frozen combined = new RegistryAccess.ImmutableRegistryAccess(all).freeze();

        // An item's default components are data driven now, and ItemStack's own decoding walks them, so
        // any packet carrying a stack throws "Components not bound yet" until these are baked.
        BuiltInRegistries.DATA_COMPONENT_INITIALIZERS.build(combined)
            .forEach(DataComponentInitializers.PendingComponents::apply);

        return combined;
    }

    private static byte[] hexToBytes(String hex) {
        byte[] out = new byte[hex.length() / 2];
        for (int i = 0; i < out.length; i++) {
            out[i] = (byte) Integer.parseInt(hex.substring(i * 2, i * 2 + 2), 16);
        }
        return out;
    }
}

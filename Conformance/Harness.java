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
import net.minecraft.core.component.DataComponentInitializers;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.data.registries.VanillaRegistries;
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
                    String mismatch = checkChunkSections(packet, entry.get("sections").getAsInt(), registries);
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
     * check — parse exactly as many sections as the world height implies, then insist the blob
     * is spent.
     *
     * @return a description of the mismatch, or null when it lines up
     */
    private static String checkChunkSections(Packet<?> packet, int expectedSections,
        RegistryAccess.Frozen registries) {

        if (!(packet instanceof ClientboundLevelChunkWithLightPacket chunk)) {
            return "expected a level_chunk_with_light packet, got " + packet.getClass().getSimpleName();
        }

        FriendlyByteBuf buf = chunk.getChunkData().getReadBuffer();
        int size = buf.readableBytes();
        PalettedContainerFactory factory = PalettedContainerFactory.create(registries);

        for (int i = 0; i < expectedSections; i++) {
            try {
                new LevelChunkSection(factory).read(buf);
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

        return null;
    }

    /**
     * Checks that the metadata type id we wrote resolves to the serializer we meant, named as
     * its field in {@link net.minecraft.network.syncher.EntityDataSerializers}.
     *
     * <p>Bytes alone can't tell a mis-numbered type from a correct one when the two serializers
     * share a wire shape — every variant is a var int — so the packet decodes cleanly while
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
    private static RegistryAccess.Frozen buildRegistryAccess() {
        List<Registry<?>> all = new ArrayList<>();
        java.util.Set<ResourceKey<? extends Registry<?>>> seen = new java.util.HashSet<>();

        // The static registries (blocks, items, entity types, ...) come ready made
        RegistryLayer.createRegistryAccess().compositeAccess().registries().forEach(entry -> {
            all.add(entry.value());
            seen.add(entry.key());
        });

        // The datapack ones have to be rebuilt from the vanilla defaults, which arrive as a
        // lookup provider rather than as registries. It overlaps the static set, and a
        // duplicate key blows up ImmutableRegistryAccess.
        HolderLookup.Provider vanilla = VanillaRegistries.createLookup();

        // An item's default components are data driven now, and ItemStack's own decoding walks them, so
        // any packet carrying a stack throws "Components not bound yet" until these are baked.
        BuiltInRegistries.DATA_COMPONENT_INITIALIZERS.build(vanilla)
            .forEach(DataComponentInitializers.PendingComponents::apply);

        vanilla.listRegistryKeys().filter(key -> !seen.contains(key)).forEach(key -> {
            HolderLookup.RegistryLookup lookup = vanilla.lookupOrThrow((ResourceKey) key);
            MappedRegistry registry = new MappedRegistry((ResourceKey) key, com.mojang.serialization.Lifecycle.stable());
            lookup.listElements().forEach(holder -> {
                Holder.Reference reference = (Holder.Reference) holder;
                registry.register(reference.key(), reference.value(), RegistrationInfo.BUILT_IN);
            });
            all.add(registry.freeze());
        });

        return new RegistryAccess.ImmutableRegistryAccess(all).freeze();
    }

    private static byte[] hexToBytes(String hex) {
        byte[] out = new byte[hex.length() / 2];
        for (int i = 0; i < out.length; i++) {
            out[i] = (byte) Integer.parseInt(hex.substring(i * 2, i * 2 + 2), 16);
        }
        return out;
    }
}

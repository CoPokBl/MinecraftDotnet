import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import io.netty.buffer.Unpooled;
import it.unimi.dsi.fastutil.ints.IntArrayList;
import it.unimi.dsi.fastutil.ints.IntList;
import net.minecraft.core.HolderLookup;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.RegistrySynchronization;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.nbt.Tag;
import net.minecraft.network.FriendlyByteBuf;
import net.minecraft.resources.Identifier;
import net.minecraft.resources.RegistryDataLoader;
import net.minecraft.resources.ResourceKey;
import net.minecraft.server.packs.resources.ResourceProvider;
import net.minecraft.tags.TagNetworkSerialization;

import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.Set;
import java.util.UUID;
import java.util.stream.Stream;
import java.util.zip.Inflater;

/**
 * Connects to a Minecraft Dotnet server as a client and checks the configuration phase
 * against the vanilla server jar's own codecs. See README.md.
 *
 * Only the packet framing lives here; everything that decides correctness is Mojang's.
 */
public final class ConformanceCheck {

    private static final int SEGMENT_BITS = 0x7F;
    private static final int CONTINUE_BIT = 0x80;

    private static Map<String, Integer> loginClientBound;
    private static Map<String, Integer> configClientBound;
    private static Map<String, Integer> configServerBound;
    private static Map<String, Integer> loginServerBound;

    private static int compressionThreshold = -1;

    /** registry id -> (entry id -> nbt, null when the server sent no data for it) */
    private static final Map<String, Map<String, Tag>> received = new LinkedHashMap<>();

    /** registry id -> (tag id -> the numeric entries the server put in it) */
    private static final Map<String, Map<String, IntList>> receivedTags = new LinkedHashMap<>();

    private static Path vanillaDataDir;

    private static final List<String> errors = new ArrayList<>();

    public static void main(String[] args) throws Exception {
        if (args.length < 3) {
            System.err.println("Usage: ConformanceCheck <host> <port> <vanilladata-dir> [protocolVersion]");
            System.exit(2);
        }
        String host = args[0];
        int port = Integer.parseInt(args[1]);
        vanillaDataDir = Path.of(args[2]);
        loadPacketIds(vanillaDataDir.resolve(Path.of("reports", "packets.json")));

        int protocolVersion = args.length > 3
                ? Integer.parseInt(args[3])
                : net.minecraft.SharedConstants.getProtocolVersion();

        System.out.println("Connecting to " + host + ":" + port + " with protocol " + protocolVersion);

        try (Socket socket = new Socket()) {
            socket.connect(new InetSocketAddress(host, port), 10_000);
            socket.setSoTimeout(15_000);
            InputStream in = socket.getInputStream();
            OutputStream out = socket.getOutputStream();

            handshake(out, host, port, protocolVersion);
            doLogin(in, out);
            doConfiguration(in, out);
        }

        validate();

        if (errors.isEmpty()) {
            System.out.println();
            System.out.println("PASS - the vanilla loader accepted everything the server sent");
            System.exit(0);
        }

        System.out.println();
        System.out.println("FAIL - " + errors.size() + " problem(s):");
        for (String error : errors) {
            System.out.println("  * " + error);
        }
        System.exit(1);
    }

    // ------------------------------------------------------------------
    // Protocol phases
    // ------------------------------------------------------------------

    private static void handshake(OutputStream out, String host, int port, int protocolVersion) throws IOException {
        FriendlyByteBuf buf = buffer();
        buf.writeVarInt(0); // minecraft:intention
        buf.writeVarInt(protocolVersion);
        buf.writeUtf(host);
        buf.writeShort(port);
        buf.writeVarInt(2); // login intent
        sendPacket(out, buf);
    }

    private static void doLogin(InputStream in, OutputStream out) throws IOException {
        FriendlyByteBuf hello = buffer();
        hello.writeVarInt(loginServerBound.get("minecraft:hello"));
        hello.writeUtf("ConformanceBot");
        hello.writeUUID(UUID.nameUUIDFromBytes("ConformanceBot".getBytes(StandardCharsets.UTF_8)));
        sendPacket(out, hello);

        while (true) {
            FriendlyByteBuf packet = readPacket(in);
            int id = packet.readVarInt();

            if (id == loginClientBound.get("minecraft:login_compression")) {
                compressionThreshold = packet.readVarInt();
                System.out.println("Compression enabled, threshold " + compressionThreshold);
            } else if (id == loginClientBound.get("minecraft:login_finished")) {
                System.out.println("Login finished, entering configuration");
                FriendlyByteBuf ack = buffer();
                ack.writeVarInt(loginServerBound.get("minecraft:login_acknowledged"));
                sendPacket(out, ack);
                return;
            } else if (id == loginClientBound.get("minecraft:hello")) {
                throw new IllegalStateException(
                        "Server requested encryption. Run it with encryption disabled, e.g. "
                                + "LoginProcedureFeature(false), so the check can connect.");
            } else if (id == loginClientBound.get("minecraft:login_disconnect")) {
                throw new IllegalStateException("Disconnected during login: " + packet.readUtf());
            }
        }
    }

    private static void doConfiguration(InputStream in, OutputStream out) throws IOException {
        while (true) {
            FriendlyByteBuf packet = readPacket(in);
            int id = packet.readVarInt();

            if (id == configClientBound.get("minecraft:select_known_packs")) {
                // Echo the packs straight back so the server believes we have them all
                int count = packet.readVarInt();
                FriendlyByteBuf reply = buffer();
                reply.writeVarInt(configServerBound.get("minecraft:select_known_packs"));
                reply.writeVarInt(count);
                for (int i = 0; i < count; i++) {
                    reply.writeUtf(packet.readUtf());
                    reply.writeUtf(packet.readUtf());
                    reply.writeUtf(packet.readUtf());
                }
                sendPacket(out, reply);
            } else if (id == configClientBound.get("minecraft:registry_data")) {
                readRegistryData(packet);
            } else if (id == configClientBound.get("minecraft:update_tags")) {
                readUpdateTags(packet);
            } else if (id == configClientBound.get("minecraft:ping")) {
                int value = packet.readInt();
                FriendlyByteBuf pong = buffer();
                pong.writeVarInt(configServerBound.get("minecraft:pong"));
                pong.writeInt(value);
                sendPacket(out, pong);
            } else if (id == configClientBound.get("minecraft:keep_alive")) {
                long value = packet.readLong();
                FriendlyByteBuf alive = buffer();
                alive.writeVarInt(configServerBound.get("minecraft:keep_alive"));
                alive.writeLong(value);
                sendPacket(out, alive);
            } else if (id == configClientBound.get("minecraft:disconnect")) {
                throw new IllegalStateException("Disconnected during configuration");
            } else if (id == configClientBound.get("minecraft:finish_configuration")) {
                System.out.println("Configuration finished, received "
                        + received.size() + " registries");
                return;
            }
        }
    }

    private static void readRegistryData(FriendlyByteBuf packet) {
        String registryId = packet.readUtf();
        int count = packet.readVarInt();

        Map<String, Tag> entries = received.computeIfAbsent(registryId, k -> new LinkedHashMap<>());
        for (int i = 0; i < count; i++) {
            String entryId = packet.readUtf();
            entries.put(entryId, packet.readBoolean() ? packet.readNbt() : null);
        }
    }

    private static void readUpdateTags(FriendlyByteBuf packet) {
        int registryCount = packet.readVarInt();
        for (int i = 0; i < registryCount; i++) {
            String registryId = packet.readUtf();
            Map<String, IntList> tags = receivedTags.computeIfAbsent(registryId, k -> new LinkedHashMap<>());

            int tagCount = packet.readVarInt();
            for (int t = 0; t < tagCount; t++) {
                String tagId = packet.readUtf();
                int entryCount = packet.readVarInt();
                IntList entries = new IntArrayList(entryCount);
                for (int e = 0; e < entryCount; e++) {
                    entries.add(packet.readVarInt());
                }
                tags.put(tagId, entries);
            }
        }
    }

    /**
     * Runs the client's pipeline: bind tags, load the registries, then run the item
     * component initialisers. Anything the client rejects surfaces here as the same error.
     */
    private static void validate() {
        net.minecraft.SharedConstants.tryDetectVersion();
        net.minecraft.server.Bootstrap.bootStrap();

        // Datapack elements refer to item tags, so built in tags have to be bound first.
        bindBuiltInTags();

        Set<String> datapackRegistries = new LinkedHashSet<>();
        for (RegistryDataLoader.RegistryData<?> data : RegistryDataLoader.SYNCHRONIZED_REGISTRIES) {
            datapackRegistries.add(data.key().identifier().toString());
        }

        Map<ResourceKey<? extends Registry<?>>, RegistryDataLoader.NetworkedRegistryData> networked =
                new LinkedHashMap<>();

        Set<String> registryIds = new LinkedHashSet<>(received.keySet());
        registryIds.addAll(receivedTags.keySet());
        registryIds.retainAll(datapackRegistries);

        for (String registryId : registryIds) {
            List<RegistrySynchronization.PackedRegistryEntry> elements = new ArrayList<>();
            for (Map.Entry<String, Tag> entry : received.getOrDefault(registryId, Map.of()).entrySet()) {
                elements.add(new RegistrySynchronization.PackedRegistryEntry(
                        Identifier.parse(entry.getKey()), Optional.ofNullable(entry.getValue())));
            }

            Map<Identifier, IntList> tags = new LinkedHashMap<>();
            for (Map.Entry<String, IntList> tag
                    : receivedTags.getOrDefault(registryId, Map.of()).entrySet()) {
                tags.put(Identifier.parse(tag.getKey()), tag.getValue());
            }

            networked.put(ResourceKey.createRegistryKey(Identifier.parse(registryId)),
                    new RegistryDataLoader.NetworkedRegistryData(
                            elements, new TagNetworkSerialization.NetworkPayload(tags)));
        }

        System.out.println();
        System.out.println("Loading " + networked.size() + " registries the way the client does");

        RegistryAccess.Frozen builtIn = RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY);
        List<HolderLookup.RegistryLookup<?>> base = builtIn.listRegistries().toList();

        RegistryAccess.Frozen loaded;
        try {
            loaded = RegistryDataLoader.load(networked, ResourceProvider.EMPTY, base,
                    RegistryDataLoader.SYNCHRONIZED_REGISTRIES, Runnable::run).join();
        } catch (Throwable t) {
            errors.add("Registry loading failed - " + rootCause(t));
            return;
        }

        System.out.println("Registries loaded, running item component initialisers");

        // The initialisers reach into both the built in and the networked registries.
        HolderLookup.Provider combined = HolderLookup.Provider.create(
                Stream.concat(base.stream(), loaded.listRegistries()));

        try {
            BuiltInRegistries.DATA_COMPONENT_INITIALIZERS.build(combined);
        } catch (Throwable t) {
            errors.add("Item component initialisation failed - " + rootCause(t));
        }
    }

    @SuppressWarnings({"unchecked", "rawtypes"})
    private static void bindBuiltInTags() {
        int bound = 0;
        for (Map.Entry<String, Map<String, IntList>> entry : receivedTags.entrySet()) {
            Registry registry = BuiltInRegistries.REGISTRY.getValue(Identifier.parse(entry.getKey()));
            if (registry == null) {
                continue; // A datapack registry, the loader deals with those
            }

            Map<Identifier, IntList> tags = new LinkedHashMap<>();
            for (Map.Entry<String, IntList> tag : entry.getValue().entrySet()) {
                tags.put(Identifier.parse(tag.getKey()), tag.getValue());
            }

            try {
                TagNetworkSerialization.NetworkPayload payload =
                        new TagNetworkSerialization.NetworkPayload(tags);
                registry.prepareTagReload(payload.resolve(registry)).apply();
                bound++;
            } catch (Throwable t) {
                errors.add("Tags for " + entry.getKey() + " could not be applied - " + rootCause(t));
            }
        }
        System.out.println("Bound tags for " + bound + " built in registries");
    }

    private static String rootCause(Throwable thrown) {
        Throwable current = thrown;
        while (current.getCause() != null && current.getCause() != current) {
            current = current.getCause();
        }
        return current.getClass().getSimpleName() + ": " + current.getMessage();
    }
    // ------------------------------------------------------------------
    // Framing
    // ------------------------------------------------------------------

    private static FriendlyByteBuf buffer() {
        return new FriendlyByteBuf(Unpooled.buffer());
    }

    private static void sendPacket(OutputStream out, FriendlyByteBuf payload) throws IOException {
        byte[] data = new byte[payload.readableBytes()];
        payload.readBytes(data);

        ByteArrayOutputStream body = new ByteArrayOutputStream();
        if (compressionThreshold >= 0) {
            // Never worth compressing at these sizes, so always use the uncompressed form
            writeVarInt(body, 0);
        }
        body.write(data);

        byte[] framed = body.toByteArray();
        writeVarInt(out, framed.length);
        out.write(framed);
        out.flush();
    }

    private static FriendlyByteBuf readPacket(InputStream in) throws IOException {
        int length = readVarInt(in);
        byte[] raw = in.readNBytes(length);
        if (raw.length != length) {
            throw new IOException("Connection closed mid packet");
        }

        if (compressionThreshold < 0) {
            return new FriendlyByteBuf(Unpooled.wrappedBuffer(raw));
        }

        DataInputStream framed = new DataInputStream(new java.io.ByteArrayInputStream(raw));
        int uncompressedSize = readVarInt(framed);
        byte[] rest = framed.readAllBytes();
        if (uncompressedSize == 0) {
            return new FriendlyByteBuf(Unpooled.wrappedBuffer(rest));
        }

        byte[] inflated = new byte[uncompressedSize];
        Inflater inflater = new Inflater();
        inflater.setInput(rest);
        try {
            inflater.inflate(inflated);
        } catch (Exception e) {
            throw new IOException("Failed to decompress packet", e);
        } finally {
            inflater.end();
        }
        return new FriendlyByteBuf(Unpooled.wrappedBuffer(inflated));
    }

    private static int readVarInt(InputStream in) throws IOException {
        int value = 0;
        int position = 0;
        while (true) {
            int current = in.read();
            if (current == -1) {
                throw new IOException("Connection closed while reading a VarInt");
            }
            value |= (current & SEGMENT_BITS) << position;
            if ((current & CONTINUE_BIT) == 0) {
                return value;
            }
            position += 7;
            if (position >= 32) {
                throw new IOException("VarInt too big");
            }
        }
    }

    private static void writeVarInt(OutputStream out, int value) throws IOException {
        while (true) {
            if ((value & ~SEGMENT_BITS) == 0) {
                out.write(value);
                return;
            }
            out.write((value & SEGMENT_BITS) | CONTINUE_BIT);
            value >>>= 7;
        }
    }

    // ------------------------------------------------------------------
    // Packet ids, read from the generated report so this tracks the version
    // ------------------------------------------------------------------

    private static void loadPacketIds(Path packetsJson) throws IOException {
        try (FileReader reader = new FileReader(packetsJson.toFile())) {
            JsonObject root = JsonParser.parseReader(reader).getAsJsonObject();
            loginClientBound = idsFor(root, "login", "clientbound");
            loginServerBound = idsFor(root, "login", "serverbound");
            configClientBound = idsFor(root, "configuration", "clientbound");
            configServerBound = idsFor(root, "configuration", "serverbound");
        }
    }

    private static Map<String, Integer> idsFor(JsonObject root, String state, String direction) {
        JsonObject packets = root.getAsJsonObject(state).getAsJsonObject(direction);
        Map<String, Integer> ids = new LinkedHashMap<>();
        for (String name : packets.keySet()) {
            ids.put(name, packets.getAsJsonObject(name).get("protocol_id").getAsInt());
        }
        return ids;
    }

    private ConformanceCheck() {
    }
}

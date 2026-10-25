import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import com.mojang.brigadier.CommandDispatcher;
import com.mojang.brigadier.ParseResults;
import com.mojang.brigadier.builder.LiteralArgumentBuilder;
import com.mojang.brigadier.builder.RequiredArgumentBuilder;
import com.mojang.brigadier.tree.LiteralCommandNode;
import io.netty.buffer.Unpooled;
import java.io.FileReader;
import java.lang.reflect.Method;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.PublicKey;
import java.security.Signature;
import java.time.Instant;
import java.util.ArrayList;
import java.util.Base64;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.UUID;
import net.minecraft.SharedConstants;
import net.minecraft.commands.arguments.ArgumentSignatures;
import net.minecraft.commands.arguments.EntityArgument;
import net.minecraft.commands.arguments.MessageArgument;
import net.minecraft.network.FriendlyByteBuf;
import net.minecraft.network.chat.LastSeenMessages;
import net.minecraft.network.chat.LastSeenMessagesValidator;
import net.minecraft.network.chat.LocalChatSession;
import net.minecraft.network.chat.MessageSignature;
import net.minecraft.network.chat.RemoteChatSession;
import net.minecraft.network.chat.SignableCommand;
import net.minecraft.network.chat.SignedMessageBody;
import net.minecraft.network.chat.SignedMessageChain;
import net.minecraft.network.protocol.game.ServerboundChatAckPacket;
import net.minecraft.network.protocol.game.ServerboundChatCommandPacket;
import net.minecraft.network.protocol.game.ServerboundChatCommandSignedPacket;
import net.minecraft.network.protocol.game.ServerboundChatPacket;
import net.minecraft.network.protocol.game.ServerboundChatSessionUpdatePacket;
import net.minecraft.server.Bootstrap;
import net.minecraft.util.Crypt;
import net.minecraft.util.SignatureValidator;
import net.minecraft.world.entity.player.ProfileKeyPair;
import net.minecraft.world.entity.player.ProfilePublicKey;

/**
 * Secure chat, both ways round, against the jar.
 *
 * verify plays the server's part for what ChatSigningSamples.cs had our client send: every packet decoded with
 * the vanilla stream codec, every last seen update applied to vanilla's own LastSeenMessagesValidator (which
 * checks the offset, the acknowledged bits and the checksum), and every signature unpacked by the
 * SignedMessageChain.Decoder the server makes from the session, which checks the link index, the timestamp order
 * and the SHA256withRSA signature over what vanilla thinks the body is. Commands are parsed against the same tree
 * ChatSigningSamples.cs builds, and their signed arguments matched as ServerGamePacketListenerImpl matches them.
 *
 * fixture goes the other way: it has vanilla sign a profile key with a stand in services key and sign a few
 * chained messages, and prints them for ClientLib.Testing/Chat/IncomingChatTest.cs to verify with our code.
 *
 * Run it with Conformance/chatsigning.sh.
 */
public class ChatSigningHarness {
    private static int failures;

    public static void main(String[] args) throws Exception {
        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();
        if (args[0].equals("fixture")) {
            fixture();
            return;
        }
        JsonArray sessions;
        try (FileReader reader = new FileReader(args[1])) {
            sessions = JsonParser.parseReader(reader).getAsJsonArray();
        }
        for (JsonElement session : sessions) {
            verify(session.getAsJsonObject());
        }
        System.out.println(failures == 0 ? "All chat signing checks passed" : failures + " chat signing checks failed");
        System.exit(failures == 0 ? 0 : 1);
    }

    /** The command tree ChatSigningSamples.cs builds. */
    static CommandDispatcher<Object> dispatcher() {
        CommandDispatcher<Object> dispatcher = new CommandDispatcher<>();
        LiteralCommandNode<Object> msg = dispatcher.register(LiteralArgumentBuilder.literal("msg")
            .then(RequiredArgumentBuilder.argument("targets", EntityArgument.players())
                .then(RequiredArgumentBuilder.argument("message", MessageArgument.message()).executes(c -> 1))));
        dispatcher.register(LiteralArgumentBuilder.literal("tell").redirect(msg));
        dispatcher.register(LiteralArgumentBuilder.literal("say")
            .then(RequiredArgumentBuilder.argument("message", MessageArgument.message()).executes(c -> 1)));
        dispatcher.register(LiteralArgumentBuilder.literal("me")
            .then(RequiredArgumentBuilder.argument("action", MessageArgument.message()).executes(c -> 1)));
        dispatcher.register(LiteralArgumentBuilder.literal("execute")
            .then(LiteralArgumentBuilder.literal("run").redirect(dispatcher.getRoot())));
        dispatcher.register(LiteralArgumentBuilder.literal("tp")
            .then(RequiredArgumentBuilder.argument("target", EntityArgument.entity()).executes(c -> 1)));
        return dispatcher;
    }

    static void verify(JsonObject session) throws Exception {
        UUID profileId = UUID.fromString(session.get("profileId").getAsString());
        boolean signed = session.has("sessionId");
        String name = signed ? "signed session" : "no session";
        SignedMessageChain.Decoder decoder;
        if (signed) {
            PublicKey key = Crypt.byteToPublicKey(Base64.getDecoder().decode(session.get("publicKey").getAsString()));
            ProfilePublicKey publicKey = new ProfilePublicKey(new ProfilePublicKey.Data(
                Instant.ofEpochMilli(session.get("expiresAt").getAsLong()), key, new byte[0]));
            decoder = new SignedMessageChain(profileId, UUID.fromString(session.get("sessionId").getAsString())).decoder(publicKey);
        } else {
            // A server not enforcing secure chat takes unsigned messages from a player without a session.
            decoder = SignedMessageChain.Decoder.unsigned(profileId, () -> false);
        }
        LastSeenMessagesValidator validator = new LastSeenMessagesValidator(20);
        CommandDispatcher<Object> commands = dispatcher();
        int step = 0;
        for (JsonElement element : session.getAsJsonArray("events")) {
            JsonObject event = element.getAsJsonObject();
            step++;
            if (event.has("received")) {
                validator.addPending(new MessageSignature(Base64.getDecoder().decode(event.get("received").getAsString())));
                continue;
            }
            String kind = event.get("sent").getAsString();
            FriendlyByteBuf body = new FriendlyByteBuf(Unpooled.wrappedBuffer(Base64.getDecoder().decode(event.get("body").getAsString())));
            String where = name + ", event " + step + " (" + kind + ")";
            try {
                switch (kind) {
                    case "chat" -> {
                        ServerboundChatPacket packet = ServerboundChatPacket.STREAM_CODEC.decode(body);
                        expectConsumed(body, where);
                        LastSeenMessages lastSeen = applyUpdate(validator, packet.lastSeenMessages(), where);
                        expect(signed == (packet.signature() != null), where + ": signature present " + (packet.signature() != null));
                        decoder.unpack(packet.signature(), new SignedMessageBody(packet.message(), packet.timeStamp(), packet.salt(), lastSeen));
                        System.out.println("ok   " + where + ": '" + packet.message() + "', " + lastSeen.entries().size() + " last seen");
                    }
                    case "chat_command_signed" -> {
                        ServerboundChatCommandSignedPacket packet = ServerboundChatCommandSignedPacket.STREAM_CODEC.decode(body);
                        expectConsumed(body, where);
                        LastSeenMessages lastSeen = applyUpdate(validator, packet.lastSeenMessages(), where);
                        SignableCommand<Object> command = SignableCommand.of(commands.parse(packet.command(), new Object()));
                        expect(!command.arguments().isEmpty(), where + ": vanilla finds nothing to sign in '" + packet.command() + "'");
                        collectSignedArguments(packet, command, lastSeen, decoder, signed, where);
                        System.out.println("ok   " + where + ": '/" + packet.command() + "', " + packet.argumentSignatures().entries().size()
                            + " signed arguments, " + lastSeen.entries().size() + " last seen");
                    }
                    case "chat_command" -> {
                        ServerboundChatCommandPacket packet = ServerboundChatCommandPacket.STREAM_CODEC.decode(body);
                        expectConsumed(body, where);
                        ParseResults<Object> parse = commands.parse(packet.command(), new Object());
                        expect(!SignableCommand.hasSignableArguments(parse), where + ": '" + packet.command() + "' went unsigned but vanilla signs it");
                        System.out.println("ok   " + where + ": '/" + packet.command() + "'");
                    }
                    case "chat_session_update" -> {
                        ServerboundChatSessionUpdatePacket packet = ServerboundChatSessionUpdatePacket.STREAM_CODEC.decode(body);
                        expectConsumed(body, where);
                        RemoteChatSession.Data data = packet.chatSession();
                        expect(data.sessionId().equals(UUID.fromString(session.get("sessionId").getAsString())), where + ": session id " + data.sessionId());
                        expect(data.profilePublicKey().expiresAt().toEpochMilli() == session.get("expiresAt").getAsLong(), where + ": expiry");
                        expect(java.util.Arrays.equals(data.profilePublicKey().key().getEncoded(), Base64.getDecoder().decode(session.get("publicKey").getAsString())),
                            where + ": public key");
                        expect(java.util.Arrays.equals(data.profilePublicKey().keySignature(), Base64.getDecoder().decode(event.get("keySignature").getAsString())),
                            where + ": key signature");
                        System.out.println("ok   " + where + ": session " + data.sessionId());
                    }
                    case "chat_ack" -> {
                        ServerboundChatAckPacket packet = ServerboundChatAckPacket.STREAM_CODEC.decode(body);
                        expectConsumed(body, where);
                        validator.applyOffset(packet.offset());
                        System.out.println("ok   " + where + ": offset " + packet.offset());
                    }
                    default -> expect(false, where + ": unexpected packet");
                }
            } catch (Exception e) {
                expect(false, where + ": " + e);
            }
        }
    }

    /** ServerGamePacketListenerImpl.unpackAndApplyLastSeen, with the checksum the client must not leave at zero. */
    static LastSeenMessages applyUpdate(LastSeenMessagesValidator validator, LastSeenMessages.Update update, String where) throws Exception {
        expect(update.checksum() != LastSeenMessages.Update.IGNORE_CHECKSUM, where + ": checksum left at zero, which vanilla never sends");
        LastSeenMessages lastSeen = validator.applyUpdate(update);
        expect(update.checksum() == lastSeen.computeChecksum(), where + ": checksum " + update.checksum() + ", vanilla " + lastSeen.computeChecksum());
        return lastSeen;
    }

    /** ServerGamePacketListenerImpl.collectSignedArguments. */
    static void collectSignedArguments(ServerboundChatCommandSignedPacket packet, SignableCommand<Object> command, LastSeenMessages lastSeen,
        SignedMessageChain.Decoder decoder, boolean signed, String where) throws Exception {
        List<ArgumentSignatures.Entry> entries = packet.argumentSignatures().entries();
        expect(signed == !entries.isEmpty(), where + ": " + entries.size() + " argument signatures");
        if (entries.isEmpty()) {
            for (SignableCommand.Argument<Object> argument : command.arguments()) {
                decoder.unpack(null, SignedMessageBody.unsigned(argument.value()));
            }
            return;
        }
        Set<String> seen = new HashSet<>();
        for (ArgumentSignatures.Entry entry : entries) {
            SignableCommand.Argument<Object> expected = command.getArgument(entry.name());
            expect(expected != null, where + ": signed an argument '" + entry.name() + "' vanilla does not find");
            decoder.unpack(entry.signature(), new SignedMessageBody(expected.value(), packet.timeStamp(), packet.salt(), lastSeen));
            seen.add(entry.name());
        }
        for (SignableCommand.Argument<Object> argument : command.arguments()) {
            expect(seen.contains(argument.name()), where + ": left '" + argument.name() + "' unsigned");
        }
    }

    static void expectConsumed(FriendlyByteBuf body, String where) {
        expect(body.readableBytes() == 0, where + ": " + body.readableBytes() + " bytes left after decoding");
    }

    static void expect(boolean condition, String message) {
        if (!condition) {
            failures++;
            System.out.println("FAIL " + message);
        }
    }

    static void fixture() throws Exception {
        KeyPairGenerator generator = KeyPairGenerator.getInstance("RSA");
        generator.initialize(2048);
        KeyPair services = generator.generateKeyPair();
        KeyPair player = generator.generateKeyPair();
        UUID profileId = UUID.fromString("069a79f4-44e9-4726-a5be-fca90e38aaf5");
        UUID sessionId = UUID.fromString("5d8a1d38-1c4b-4f3a-9a2e-3c1b2a4d5e6f");
        Instant expiresAt = Instant.parse("2100-01-01T00:00:00Z");

        // ProfilePublicKey.Data.signedPayload is what the services sign; reflection rather than a restatement of it.
        ProfilePublicKey.Data unsignedData = new ProfilePublicKey.Data(expiresAt, player.getPublic(), new byte[0]);
        Method signedPayload = ProfilePublicKey.Data.class.getDeclaredMethod("signedPayload", UUID.class);
        signedPayload.setAccessible(true);
        Signature sha1 = Signature.getInstance("SHA1withRSA");
        sha1.initSign(services.getPrivate());
        sha1.update((byte[]) signedPayload.invoke(unsignedData, profileId));
        ProfilePublicKey.Data data = new ProfilePublicKey.Data(expiresAt, player.getPublic(), sha1.sign());
        ProfilePublicKey publicKey = ProfilePublicKey.createValidated(SignatureValidator.from(services.getPublic(), "SHA1withRSA"), profileId, data);

        LocalChatSession session = new LocalChatSession(sessionId, new ProfileKeyPair(player.getPrivate(), publicKey, expiresAt));
        SignedMessageChain.Encoder encoder = session.createMessageEncoder(profileId);
        Base64.Encoder base64 = Base64.getEncoder();
        StringBuilder out = new StringBuilder();
        out.append("{\n  \"servicesKey\": \"").append(base64.encodeToString(services.getPublic().getEncoded())).append("\",\n");
        out.append("  \"profileId\": \"").append(profileId).append("\",\n");
        out.append("  \"sessionId\": \"").append(sessionId).append("\",\n");
        out.append("  \"expiresAt\": ").append(expiresAt.toEpochMilli()).append(",\n");
        out.append("  \"publicKey\": \"").append(base64.encodeToString(player.getPublic().getEncoded())).append("\",\n");
        out.append("  \"keySignature\": \"").append(base64.encodeToString(data.keySignature())).append("\",\n");
        out.append("  \"messages\": [\n");
        String[] contents = {"hello", "\u00fcnic\u00f8de \u2603", "a third, seeing both"};
        List<MessageSignature> seen = new ArrayList<>();
        for (int i = 0; i < contents.length; i++) {
            Instant timeStamp = Instant.parse("2026-10-12T01:02:03.456Z").plusMillis(1500L * i);
            long salt = -1234567890123456789L + i;
            LastSeenMessages lastSeen = new LastSeenMessages(List.copyOf(seen));
            MessageSignature signature = encoder.pack(new SignedMessageBody(contents[i], timeStamp, salt, lastSeen));
            out.append("    {\"index\": ").append(i).append(", \"content\": \"").append(contents[i]).append("\", \"timeStamp\": ")
                .append(timeStamp.toEpochMilli()).append(", \"salt\": ").append(salt).append(", \"checksum\": ").append(lastSeen.computeChecksum())
                .append(", \"lastSeen\": [");
            for (int j = 0; j < seen.size(); j++) {
                out.append(j > 0 ? ", " : "").append('"').append(base64.encodeToString(seen.get(j).bytes())).append('"');
            }
            out.append("], \"signature\": \"").append(base64.encodeToString(signature.bytes())).append("\"}")
                .append(i < contents.length - 1 ? ",\n" : "\n");
            seen.add(signature);
        }
        out.append("  ]\n}");
        System.out.println(out);
    }
}

using Minecraft.Data.Generated;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Schemas;

namespace Minecraft.Testing.Packets;

/// <summary>
/// minecraft:login_finished gained a session id in 26.2, and getting it wrong disconnects the
/// client before it ever reaches configuration, so the encoding is pinned against vanilla here.
/// </summary>
/// <remarks>
/// The expected bytes come from running the vanilla codec, the same way as
/// <see cref="Schemas.LpVec3Test"/>:
/// <code>
/// ClientboundLoginFinishedPacket.STREAM_CODEC.encode(buf,
///     new ClientboundLoginFinishedPacket(new GameProfile(uuid, "Tester"), sessionId));
/// </code>
/// </remarks>
public class LoginFinishedPacketTest {
    private static readonly Guid PlayerUuid = Guid.Parse("4566e69f-c907-48ee-8d71-d7ba5aa00d20");
    private static readonly Guid SessionId = Guid.Parse("11111111-2222-3333-4444-555555555555");

    // profile uuid, name, empty property array, then the session id
    private const string VanillaEncoding =
        "4566e69fc90748ee8d71d7ba5aa00d20" + "06546573746572" + "00"
        + "11111111222233334444555555555555";

    [Test]
    public void TestMatchesVanillaEncoding() {
        ClientBoundLoginSuccessPacket packet = new() {
            Uuid = PlayerUuid,
            Username = "Tester",
            SessionId = SessionId
        };

        byte[] framed = packet.Serialise(ConnectionState.Login);
        DataReader reader = new(framed);
        reader.ReadVarInt();  // frame length
        reader.ReadVarInt();  // packet id
        byte[] body = reader.Read((int)(reader.Length - reader.Position));

        Assert.That(Convert.ToHexString(body).ToLowerInvariant(), Is.EqualTo(VanillaEncoding));
    }

    [Test]
    public void TestReadsVanillaEncoding() {
        ClientBoundLoginSuccessPacket packet = (ClientBoundLoginSuccessPacket)
            ClientBoundLoginSuccessPacket.Deserialiser(
                new DataReader(Convert.FromHexString(VanillaEncoding)), VanillaRegistry.Data);

        Assert.Multiple(() => {
            Assert.That(packet.Uuid, Is.EqualTo(PlayerUuid));
            Assert.That(packet.Username, Is.EqualTo("Tester"));
            Assert.That(packet.SessionId, Is.EqualTo(SessionId));
        });
    }
}

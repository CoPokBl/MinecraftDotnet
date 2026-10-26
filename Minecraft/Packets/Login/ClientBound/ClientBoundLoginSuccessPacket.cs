using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundLoginSuccessPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:login_finished";
    
    public required string Username { get; init; }
    public required Guid Uuid { get; init; }

    /// <summary>
    /// Identifies this run of the server, not the player. Vanilla generates one per server
    /// start and sends the same value to every client, so a server that hands out a fresh one
    /// per connection is still well formed, just less useful to the client.
    /// </summary>
    /// <remarks>Added in 26.2, before which the packet ended after the game profile.</remarks>
    public Guid SessionId { get; init; } = Guid.NewGuid();

    protected override DataWriter WriteData(DataWriter w) {
        // The game profile: id, name, then its properties (skin, cape, ...)
        w.WriteUuid(Uuid);
        w.WriteString(Username);
        w.WritePrefixedArray(Array.Empty<int>(), (_, _) => { });
        w.WriteUuid(SessionId);
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundLoginSuccessPacket {
        Uuid = r.ReadUuid(),
        Username = r.ReadString(),
        SessionId = ReadSessionId(r)
    };

    // The properties array sits between the name and the session id, so it has to be consumed
    // even though we don't keep it
    private static Guid ReadSessionId(DataReader r) {
        r.ReadPrefixedArray(reader => {
            reader.ReadString();
            reader.ReadString();
            reader.ReadPrefixedOptional(re => re.ReadString());
            return 0;
        });
        return r.ReadUuid();
    }
}

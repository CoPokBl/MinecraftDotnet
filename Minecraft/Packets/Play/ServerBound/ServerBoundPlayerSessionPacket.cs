using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>
/// Announces the public key the player will sign their chat messages with. Mojang's session
/// server signs the key itself, which is what <see cref="KeySignature"/> carries.
/// </summary>
public class ServerBoundPlayerSessionPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:chat_session_update";

    public required Guid SessionId { get; init; }

    /// <summary>When the key stops being accepted.</summary>
    public required DateTimeOffset ExpiresAt { get; init; }

    /// <summary>The player's RSA public key, in DER SubjectPublicKeyInfo form.</summary>
    public required byte[] PublicKey { get; init; }

    /// <summary>Mojang's signature over the key.</summary>
    public required byte[] KeySignature { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteUuid(SessionId)
            .WriteLong(ExpiresAt.ToUnixTimeMilliseconds())
            .WriteVarInt(PublicKey.Length)
            .Write(PublicKey)
            .WriteVarInt(KeySignature.Length)
            .Write(KeySignature);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPlayerSessionPacket {
        SessionId = r.ReadUuid(),
        ExpiresAt = DateTimeOffset.FromUnixTimeMilliseconds(r.ReadLong()),
        PublicKey = r.Read(r.ReadVarInt()),
        KeySignature = r.Read(r.ReadVarInt())
    };
}

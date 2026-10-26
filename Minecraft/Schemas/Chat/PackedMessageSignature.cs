namespace Minecraft.Schemas.Chat;

/// <summary>
/// A chat message signature on the wire. Both sides keep a cache of the signatures they have
/// already seen, so a message can refer to one by index instead of repeating all 256 bytes.
/// </summary>
public class PackedMessageSignature : IWritable {
    public const int SignatureLength = 256;

    /// <summary>Index into the recipient's signature cache, or -1 when <see cref="Signature"/> is sent.</summary>
    public int Id { get; }

    /// <summary>The full signature, only present when <see cref="Id"/> is -1.</summary>
    public byte[]? Signature { get; }

    private PackedMessageSignature(int id, byte[]? signature) {
        Id = id;
        Signature = signature;
    }

    public static PackedMessageSignature FromCache(int id) {
        if (id < 0) {
            throw new ArgumentOutOfRangeException(nameof(id), id, "Cache index cannot be negative");
        }
        return new PackedMessageSignature(id, null);
    }

    public static PackedMessageSignature FromSignature(byte[] signature) {
        if (signature.Length != SignatureLength) {
            throw new ArgumentException($"Signature must be {SignatureLength} bytes", nameof(signature));
        }
        return new PackedMessageSignature(-1, signature);
    }

    public void Write(DataWriter w) {
        w.WriteVarInt(Id + 1);
        if (Signature != null) {
            w.Write(Signature);
        }
    }

    public static PackedMessageSignature Read(DataReader r) {
        int id = r.ReadVarInt() - 1;
        return id == -1
            ? FromSignature(r.Read(SignatureLength))
            : FromCache(id);
    }
}

using System.Buffers.Binary;
using System.Security.Cryptography;
using System.Text;
using Minecraft;
using Minecraft.Schemas.Chat;
using Minecraft.Text;

namespace ClientLib.Chat;

/// <summary><c>SignatureUpdater</c>: writes the bytes a signature covers, in order.</summary>
public delegate void SignatureUpdater(Stream output);

/// <summary><c>SignatureValidator</c>.</summary>
public delegate bool SignatureValidator(SignatureUpdater updater, byte[] signature);

public static class Signatures {
    /// <summary><c>Signer.from(privateKey, "SHA256withRSA")</c>.</summary>
    public static byte[] Sign(RSA privateKey, SignatureUpdater updater) =>
        privateKey.SignData(Collect(updater), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

    /// <summary><c>SignatureValidator.from(publicKey, "SHA256withRSA")</c>.</summary>
    public static SignatureValidator Sha256WithRsa(RSA publicKey) =>
        (updater, signature) => publicKey.VerifyData(Collect(updater), signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

    private static byte[] Collect(SignatureUpdater updater) {
        using MemoryStream output = new();
        updater(output);
        return output.ToArray();
    }

    internal static void WriteInt(Stream output, int value) {
        Span<byte> bytes = stackalloc byte[4];
        BinaryPrimitives.WriteInt32BigEndian(bytes, value);
        output.Write(bytes);
    }

    internal static void WriteLong(Stream output, long value) {
        Span<byte> bytes = stackalloc byte[8];
        BinaryPrimitives.WriteInt64BigEndian(bytes, value);
        output.Write(bytes);
    }

    /// <summary><c>UUIDUtil.uuidToByteArray</c>: the most significant half then the least, both big endian.</summary>
    internal static void WriteUuid(Stream output, Guid uuid) => output.Write(uuid.ToByteArray(bigEndian: true));

    /// <summary><c>Crypt.SaltSupplier.getLong</c>.</summary>
    public static long Salt() => BinaryPrimitives.ReadInt64BigEndian(RandomNumberGenerator.GetBytes(8));
}

/// <summary><c>MessageSignature</c>: a message's 256 byte RSA signature, equal by content.</summary>
public sealed class MessageSignature : IEquatable<MessageSignature> {
    public const int Bytes = 256;

    public MessageSignature(byte[] bytes) {
        if (bytes.Length != Bytes) {
            throw new ArgumentException("Invalid message signature size", nameof(bytes));
        }
        Data = bytes;
    }

    public byte[] Data { get; }

    /// <summary><c>checksum</c>, which is Java's <c>Arrays.hashCode</c> over the signed bytes.</summary>
    public int Checksum() {
        int hash = 1;
        foreach (byte b in Data) {
            hash = 31 * hash + (sbyte)b;
        }
        return hash;
    }

    public bool Verify(SignatureValidator validator, SignatureUpdater updater) => validator(updater, Data);

    /// <summary><c>pack</c>: the cache index when the cache holds it, the bytes otherwise.</summary>
    public PackedMessageSignature Pack(MessageSignatureCache cache) {
        int id = cache.Pack(this);
        return id != MessageSignatureCache.NotFound ? PackedMessageSignature.FromCache(id) : PackedMessageSignature.FromSignature(Data);
    }

    public static MessageSignature? Unpack(PackedMessageSignature packed, MessageSignatureCache cache) =>
        packed.Signature != null ? new MessageSignature(packed.Signature) : cache.Unpack(packed.Id);

    public bool Equals(MessageSignature? other) => other != null && Data.AsSpan().SequenceEqual(other.Data);

    public override bool Equals(object? obj) => obj is MessageSignature other && Equals(other);

    public override int GetHashCode() => Checksum();

    public override string ToString() => Convert.ToBase64String(Data);
}

/// <summary><c>SignedMessageLink</c>: a message's place in its sender's chain.</summary>
public sealed record SignedMessageLink(int Index, Guid Sender, Guid SessionId) {
    public static SignedMessageLink Unsigned(Guid sender) => Root(sender, Guid.Empty);

    public static SignedMessageLink Root(Guid sender, Guid sessionId) => new(0, sender, sessionId);

    public void UpdateSignature(Stream output) {
        Signatures.WriteUuid(output, Sender);
        Signatures.WriteUuid(output, SessionId);
        Signatures.WriteInt(output, Index);
    }

    public bool IsDescendantOf(SignedMessageLink link) => Index > link.Index && Sender == link.Sender && SessionId == link.SessionId;

    public SignedMessageLink? Advance() => Index == int.MaxValue ? null : this with { Index = Index + 1 };
}

/// <summary><c>LastSeenMessages</c>: the signatures a message says its sender had seen, oldest first.</summary>
public sealed record LastSeenMessages(IReadOnlyList<MessageSignature> Entries) {
    public const int MaxLength = 20;
    public static readonly LastSeenMessages Empty = new([]);

    public bool Equals(LastSeenMessages? other) => other != null && Entries.SequenceEqual(other.Entries);

    public override int GetHashCode() => Entries.Count;

    public void UpdateSignature(Stream output) {
        Signatures.WriteInt(output, Entries.Count);
        foreach (MessageSignature entry in Entries) {
            output.Write(entry.Data);
        }
    }

    public PackedMessageSignature[] Pack(MessageSignatureCache cache) => Entries.Select(entry => entry.Pack(cache)).ToArray();

    /// <summary><c>Packed.unpack</c>: null when an entry refers to a cache slot that is empty.</summary>
    public static LastSeenMessages? Unpack(PackedMessageSignature[] packed, MessageSignatureCache cache) {
        List<MessageSignature> unpacked = new(packed.Length);
        foreach (PackedMessageSignature entry in packed) {
            if (MessageSignature.Unpack(entry, cache) is not { } signature) {
                return null;
            }
            unpacked.Add(signature);
        }
        return new LastSeenMessages(unpacked);
    }

    public byte ComputeChecksum() {
        int checksum = 1;
        foreach (MessageSignature entry in Entries) {
            checksum = 31 * checksum + entry.Checksum();
        }
        byte checksumByte = (byte)checksum;
        return checksumByte == 0 ? (byte)1 : checksumByte;
    }

    /// <summary>
    /// <c>LastSeenMessages.Update</c>: the count to acknowledge, which of the twenty tracked slots are in the
    /// message, and the checksum. <see cref="Acknowledged"/> is the bit set as <c>writeFixedBitSet</c> writes it.
    /// </summary>
    public sealed record Update(int Offset, byte[] Acknowledged, byte Checksum);
}

/// <summary><c>SignedMessageBody</c>: what a player signs, the text with when it was sent and what they had seen.</summary>
public sealed record SignedMessageBody(string Content, DateTimeOffset TimeStamp, long Salt, LastSeenMessages LastSeen) {
    public static SignedMessageBody Unsigned(string content) => new(content, DateTimeOffset.UtcNow, 0L, LastSeenMessages.Empty);

    public void UpdateSignature(Stream output) {
        Signatures.WriteLong(output, Salt);
        Signatures.WriteLong(output, TimeStamp.ToUnixTimeSeconds());
        byte[] contentBytes = Encoding.UTF8.GetBytes(Content);
        Signatures.WriteInt(output, contentBytes.Length);
        output.Write(contentBytes);
        LastSeen.UpdateSignature(output);
    }
}

/// <summary><c>PlayerChatMessage</c>.</summary>
public sealed record PlayerChatMessage(
    SignedMessageLink Link,
    MessageSignature? Signature,
    SignedMessageBody SignedBody,
    TextComponent? UnsignedContent,
    ChatFilterMask FilterMask) {
    public static readonly TimeSpan MessageExpiresAfterServer = TimeSpan.FromMinutes(5);
    public static readonly TimeSpan MessageExpiresAfterClient = MessageExpiresAfterServer + TimeSpan.FromMinutes(2);

    public static PlayerChatMessage Unsigned(Guid sender, string content) =>
        new(SignedMessageLink.Unsigned(sender), null, SignedMessageBody.Unsigned(content), null, ChatFilterMask.PassThrough);

    public PlayerChatMessage RemoveUnsignedContent() => UnsignedContent != null ? this with { UnsignedContent = null } : this;

    public PlayerChatMessage RemoveSignature() =>
        this with { Link = SignedMessageLink.Unsigned(Sender), Signature = null, SignedBody = SignedMessageBody.Unsigned(SignedContent) };

    public static void UpdateSignature(Stream output, SignedMessageLink link, SignedMessageBody body) {
        Signatures.WriteInt(output, 1);
        link.UpdateSignature(output);
        body.UpdateSignature(output);
    }

    public bool Verify(SignatureValidator validator) => Signature != null && Signature.Verify(validator, output => UpdateSignature(output, Link, SignedBody));

    public string SignedContent => SignedBody.Content;

    public TextComponent DecoratedContent => UnsignedContent ?? TextComponent.Text(SignedContent);

    public bool HasExpiredServer(DateTimeOffset now) => now > SignedBody.TimeStamp + MessageExpiresAfterServer;

    public bool HasExpiredClient(DateTimeOffset now) => now > SignedBody.TimeStamp + MessageExpiresAfterClient;

    public Guid Sender => Link.Sender;

    /// <summary>Java's record equality, which compares the text and the mask by value.</summary>
    public bool Equals(PlayerChatMessage? other) =>
        other != null && Link == other.Link && Equals(Signature, other.Signature) && SignedBody == other.SignedBody
        && UnsignedContent?.SerialiseToTag().ToString() == other.UnsignedContent?.SerialiseToTag().ToString()
        && FilterMask.Type == other.FilterMask.Type && (FilterMask.Mask?.ToLongArray() ?? []).SequenceEqual(other.FilterMask.Mask?.ToLongArray() ?? []);

    public override int GetHashCode() => HashCode.Combine(Link, Signature);

    public bool HasSignature => Signature != null;

    public bool IsFullyFiltered => FilterMask.Type == ChatFilterMask.FilterType.FullyFiltered;

    public override string ToString() =>
        $"'{SignedContent}' @ {SignedBody.TimeStamp:O}\n - From: {Sender}/{Link.SessionId}, message #{Link.Index}\n - Salt: {SignedBody.Salt}\n"
        + $" - Signature: {Signature?.ToString() ?? "<no signature>"}\n - Last Seen: [\n"
        + string.Concat(SignedBody.LastSeen.Entries.Select(entry => $"     {entry}\n")) + " ]\n";
}

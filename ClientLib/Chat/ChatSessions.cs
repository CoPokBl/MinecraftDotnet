using System.Buffers.Binary;
using System.Security.Cryptography;
using ClientLib.Profiles;

namespace ClientLib.Chat;

/// <summary><c>ProfilePublicKey</c>: a player's chat key, which Mojang signs for one profile until it expires.</summary>
public sealed class ProfilePublicKey(ProfilePublicKey.KeyData data) {
    public static readonly TimeSpan ExpiryGracePeriod = TimeSpan.FromHours(8);

    public KeyData Data { get; } = data;

    /// <summary><c>createValidated</c>: null where vanilla throws, for a signature none of the services keys made.</summary>
    public static ProfilePublicKey? CreateValidated(IReadOnlyList<RSAParameters> servicesKeys, Guid profileId, KeyData data) =>
        data.ValidateSignature(servicesKeys, profileId) ? new ProfilePublicKey(data) : null;

    public SignatureValidator CreateSignatureValidator() => Signatures.Sha256WithRsa(Data.Rsa);

    /// <summary><c>ProfilePublicKey.Data</c>. <see cref="Key"/> is the key's DER <c>SubjectPublicKeyInfo</c>, which is <c>getEncoded</c>.</summary>
    public sealed class KeyData(DateTimeOffset expiresAt, byte[] key, byte[] keySignature) : IEquatable<KeyData> {
        private RSA? _rsa;

        public DateTimeOffset ExpiresAt { get; } = expiresAt;
        public byte[] Key { get; } = key;
        public byte[] KeySignature { get; } = keySignature;

        public RSA Rsa {
            get {
                if (_rsa == null) {
                    RSA rsa = RSA.Create();
                    rsa.ImportSubjectPublicKeyInfo(Key, out _);
                    _rsa = rsa;
                }
                return _rsa;
            }
        }

        /// <summary>
        /// <c>validateSignature</c> against the services' <c>playerCertificateKeys</c>, which sign with SHA1withRSA,
        /// over the profile id, the expiry in milliseconds and the encoded key.
        /// </summary>
        public bool ValidateSignature(IReadOnlyList<RSAParameters> servicesKeys, Guid profileId) {
            byte[] payload = new byte[24 + Key.Length];
            profileId.ToByteArray(bigEndian: true).CopyTo(payload, 0);
            BinaryPrimitives.WriteInt64BigEndian(payload.AsSpan(16), ExpiresAt.ToUnixTimeMilliseconds());
            Key.CopyTo(payload, 24);
            byte[] hash = SHA1.HashData(payload);
            return servicesKeys.Any(serviceKey => MojangServices.VerifySha1WithRsa(serviceKey, hash, KeySignature));
        }

        public bool HasExpired() => ExpiresAt < DateTimeOffset.UtcNow;

        public bool HasExpired(TimeSpan gracePeriod) => ExpiresAt + gracePeriod < DateTimeOffset.UtcNow;

        public bool Equals(KeyData? other) =>
            other != null && ExpiresAt == other.ExpiresAt && Key.AsSpan().SequenceEqual(other.Key) && KeySignature.AsSpan().SequenceEqual(other.KeySignature);

        public override bool Equals(object? obj) => obj is KeyData other && Equals(other);

        public override int GetHashCode() => ExpiresAt.GetHashCode();
    }
}

/// <summary><c>ProfileKeyPair</c>: the chat key pair the services issued, and when to ask them for another.</summary>
public sealed class ProfileKeyPair(RSA privateKey, ProfilePublicKey publicKey, DateTimeOffset refreshedAfter) : IEquatable<ProfileKeyPair> {
    public RSA PrivateKey { get; } = privateKey;
    public ProfilePublicKey PublicKey { get; } = publicKey;
    public DateTimeOffset RefreshedAfter { get; } = refreshedAfter;

    public bool DueRefresh => RefreshedAfter < DateTimeOffset.UtcNow;

    public bool Equals(ProfileKeyPair? other) =>
        other != null && (ReferenceEquals(this, other)
                          || PublicKey.Data.Equals(other.PublicKey.Data) && RefreshedAfter == other.RefreshedAfter
                          && PrivateKey.ExportPkcs8PrivateKey().AsSpan().SequenceEqual(other.PrivateKey.ExportPkcs8PrivateKey()));

    public override bool Equals(object? obj) => obj is ProfileKeyPair other && Equals(other);

    public override int GetHashCode() => RefreshedAfter.GetHashCode();
}

/// <summary><c>SignedMessageChain</c>'s encoder: signs each body with the next link of one chain.</summary>
public sealed class SignedMessageChain(Guid profileId, Guid sessionId) {
    private SignedMessageLink? _nextLink = SignedMessageLink.Root(profileId, sessionId);

    /// <summary><c>Encoder</c>: a body's signature, or null when there is nothing to sign with.</summary>
    public delegate MessageSignature? Encoder(SignedMessageBody body);

    public static readonly Encoder Unsigned = _ => null;

    public Encoder CreateEncoder(RSA privateKey) => body => {
        SignedMessageLink? link = _nextLink;
        if (link == null) {
            return null;
        }
        _nextLink = link.Advance();
        return new MessageSignature(Signatures.Sign(privateKey, output => PlayerChatMessage.UpdateSignature(output, link, body)));
    };
}

/// <summary><c>LocalChatSession</c>.</summary>
public sealed record LocalChatSession(Guid SessionId, ProfileKeyPair KeyPair) {
    public static LocalChatSession Create(ProfileKeyPair keyPair) => new(Guid.NewGuid(), keyPair);

    public SignedMessageChain.Encoder CreateMessageEncoder(Guid profileId) => new SignedMessageChain(profileId, SessionId).CreateEncoder(KeyPair.PrivateKey);

    public RemoteChatSession AsRemote() => new(SessionId, KeyPair.PublicKey);
}

/// <summary><c>RemoteChatSession</c>: another player's session, as player info announces it.</summary>
public sealed record RemoteChatSession(Guid SessionId, ProfilePublicKey ProfilePublicKey) {
    public SignedMessageValidator CreateMessageValidator(TimeSpan gracePeriod) =>
        new SignedMessageValidator.KeyBased(ProfilePublicKey.CreateSignatureValidator(), () => ProfilePublicKey.Data.HasExpired(gracePeriod));

    public bool HasExpired => ProfilePublicKey.Data.HasExpired();
}

/// <summary><c>SignedMessageValidator</c>.</summary>
public abstract class SignedMessageValidator {
    /// <summary>Logs what vanilla logs at error level.</summary>
    public static Action<string> Log { get; set; } = _ => { };

    public static readonly SignedMessageValidator AcceptUnsigned = new Fixed(message => message.RemoveSignature());

    public static readonly SignedMessageValidator RejectAll = new Fixed(message => {
        Log($"Received chat message from {message.Sender}, but they have no chat session initialized and secure chat is enforced");
        return null;
    });

    public abstract PlayerChatMessage? UpdateAndValidate(PlayerChatMessage message);

    private sealed class Fixed(Func<PlayerChatMessage, PlayerChatMessage?> validate) : SignedMessageValidator {
        public override PlayerChatMessage? UpdateAndValidate(PlayerChatMessage message) => validate(message);
    }

    public sealed class KeyBased(SignatureValidator validator, Func<bool> expired) : SignedMessageValidator {
        private PlayerChatMessage? _lastMessage;
        private bool _isChainValid = true;

        private bool ValidateChain(PlayerChatMessage message) {
            if (message.Equals(_lastMessage)) {
                return true;
            }
            if (_lastMessage != null && !message.Link.IsDescendantOf(_lastMessage.Link)) {
                Log($"Received out-of-order chat message from {message.Sender}: expected index > {_lastMessage.Link.Index} for session "
                    + $"{_lastMessage.Link.SessionId}, but was {message.Link.Index} for session {message.Link.SessionId}");
                return false;
            }
            return true;
        }

        private bool Validate(PlayerChatMessage message) {
            if (expired()) {
                Log($"Received message with expired profile public key from {message.Sender} with session {message.Link.SessionId}");
                return false;
            }
            if (!message.Verify(validator)) {
                Log($"Received message with invalid signature (is the session wrong, or signature cache out of sync?): {message}");
                return false;
            }
            return ValidateChain(message);
        }

        public override PlayerChatMessage? UpdateAndValidate(PlayerChatMessage message) {
            _isChainValid = _isChainValid && Validate(message);
            if (!_isChainValid) {
                return null;
            }
            _lastMessage = message;
            return message;
        }
    }
}

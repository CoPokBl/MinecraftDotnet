namespace ClientLib.Chat;

/// <summary>
/// <c>LastSeenMessagesTracker</c>: the signed messages the player has been shown, in a ring of twenty, which
/// every chat message and signed command reports back to the server.
/// </summary>
public sealed class LastSeenMessagesTracker(int lastSeenCount) {
    private readonly Entry?[] _trackedMessages = new Entry?[lastSeenCount];
    private int _tail;
    private MessageSignature? _lastTrackedMessage;

    /// <summary><c>LastSeenTrackedEntry</c>.</summary>
    private sealed record Entry(MessageSignature Signature, bool Pending) {
        public Entry Acknowledge() => Pending ? this with { Pending = false } : this;
    }

    public int Offset { get; private set; }

    public bool AddPending(MessageSignature message, bool wasShown) {
        if (Equals(message, _lastTrackedMessage)) {
            return false;
        }
        _lastTrackedMessage = message;
        AddEntry(wasShown ? new Entry(message, true) : null);
        return true;
    }

    private void AddEntry(Entry? entry) {
        int index = _tail;
        _tail = (index + 1) % _trackedMessages.Length;
        Offset++;
        _trackedMessages[index] = entry;
    }

    public void IgnorePending(MessageSignature pendingMessage) {
        for (int i = 0; i < _trackedMessages.Length; i++) {
            Entry? entry = _trackedMessages[i];
            if (entry is { Pending: true } && pendingMessage.Equals(entry.Signature)) {
                _trackedMessages[i] = null;
                break;
            }
        }
    }

    public int GetAndClearOffset() {
        int originalOffset = Offset;
        Offset = 0;
        return originalOffset;
    }

    public (LastSeenMessages LastSeen, LastSeenMessages.Update Update) GenerateAndApplyUpdate() {
        int offset = GetAndClearOffset();
        // BitSet.toByteArray copied into writeFixedBitSet's ceil(20 / 8) bytes: bit i is bit i % 8 of byte i / 8.
        byte[] acknowledged = new byte[(_trackedMessages.Length + 7) / 8];
        List<MessageSignature> lastSeenEntries = new(_trackedMessages.Length);
        for (int i = 0; i < _trackedMessages.Length; i++) {
            int index = (_tail + i) % _trackedMessages.Length;
            Entry? message = _trackedMessages[index];
            if (message != null) {
                acknowledged[i / 8] |= (byte)(1 << (i % 8));
                lastSeenEntries.Add(message.Signature);
                _trackedMessages[index] = message.Acknowledge();
            }
        }
        LastSeenMessages lastSeen = new(lastSeenEntries);
        return (lastSeen, new LastSeenMessages.Update(offset, acknowledged, lastSeen.ComputeChecksum()));
    }
}

/// <summary>
/// <c>MessageSignatureCache</c>: the signatures the server may refer to by index, most recent first, mirrored
/// from what the server's own cache holds for this client.
/// </summary>
public sealed class MessageSignatureCache(int capacity) {
    public const int NotFound = -1;

    private readonly MessageSignature?[] _entries = new MessageSignature?[capacity];

    public static MessageSignatureCache CreateDefault() => new(128);

    public int Pack(MessageSignature signature) {
        for (int i = 0; i < _entries.Length; i++) {
            if (signature.Equals(_entries[i])) {
                return i;
            }
        }
        return NotFound;
    }

    /// <summary>An index past the end throws, as the array read does in vanilla.</summary>
    public MessageSignature? Unpack(int id) => _entries[id];

    public void Push(SignedMessageBody body, MessageSignature? signature) {
        LinkedList<MessageSignature> queue = new(body.LastSeen.Entries);
        if (signature != null) {
            queue.AddLast(signature);
        }
        Push(queue);
    }

    internal void Push(IEnumerable<MessageSignature> entries) => Push(new LinkedList<MessageSignature>(entries));

    private void Push(LinkedList<MessageSignature> queue) {
        HashSet<MessageSignature> newEntries = [..queue];
        for (int i = 0; queue.Count > 0 && i < _entries.Length; i++) {
            MessageSignature? entry = _entries[i];
            _entries[i] = queue.Last!.Value;
            queue.RemoveLast();
            if (entry != null && !newEntries.Contains(entry)) {
                queue.AddFirst(entry);
            }
        }
    }
}

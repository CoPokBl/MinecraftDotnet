using ClientLib.Maths;
using ClientLib.World;

namespace ClientLib.Interaction;

/// <summary>
/// <c>BlockStatePredictionHandler</c>, one per level as vanilla's belongs to the <c>ClientLevel</c>. A block changed locally ahead of the server remembers what the
/// server last said about it; server updates for it are held back rather than applied, and the
/// acknowledgement of the action's sequence number settles it on the server's word.
/// </summary>
public sealed class BlockPredictions {
    private readonly Dictionary<(int, int, int), Verified> _verified = new();
    private int _lastTeleportSequence = -1;

    public int Sequence { get; private set; }
    public bool Predicting { get; private set; }

    private sealed class Verified(int sequence, ushort state, Vec3d playerPosition) {
        public int Sequence = sequence;
        public ushort State = state;
        public readonly Vec3d PlayerPosition = playerPosition;
    }

    /// <summary>Opens a prediction: changes made until <see cref="End"/> are the client's guess.</summary>
    public int Begin() {
        Sequence++;
        Predicting = true;
        return Sequence;
    }

    public void End() {
        Predicting = false;
    }

    /// <summary><c>ClientLevel.setBlock</c> while predicting: remember the server's state the first time.</summary>
    public void RetainServerState(int x, int y, int z, ushort serverState, Vec3d playerPosition) {
        if (_verified.TryGetValue((x, y, z), out Verified? existing)) {
            existing.Sequence = Sequence;
        }
        else {
            _verified[(x, y, z)] = new Verified(Sequence, serverState, playerPosition);
        }
    }

    /// <summary>
    /// <c>updateKnownServerState</c>: true when a prediction is pending here, so the server's update is
    /// recorded for later instead of applied now.
    /// </summary>
    public bool UpdateServerState(int x, int y, int z, ushort state) {
        if (!_verified.TryGetValue((x, y, z), out Verified? verified)) {
            return false;
        }
        verified.State = state;
        return true;
    }

    /// <summary>
    /// <c>endPredictionsUpTo</c>: every prediction the acknowledgement covers falls back to what the
    /// server says is there. The player is put back where it stood for a correction that happened
    /// since the last teleport, as vanilla's <c>syncBlockState</c> does.
    /// </summary>
    public void Acknowledge(int sequence, ClientLevel level, Action<Vec3d, int, int, int>? moveBackIfStuck) {
        List<(int, int, int)> done = [];
        foreach (((int X, int Y, int Z) pos, Verified verified) in _verified) {
            if (verified.Sequence > sequence) {
                continue;
            }
            done.Add(pos);
            ushort current = level.GetState(pos.X, pos.Y, pos.Z);
            if (current != verified.State) {
                level.SetState(pos.X, pos.Y, pos.Z, verified.State);
                if (_lastTeleportSequence < sequence) {
                    moveBackIfStuck?.Invoke(verified.PlayerPosition, pos.X, pos.Y, pos.Z);
                }
            }
        }
        foreach ((int, int, int) pos in done) {
            _verified.Remove(pos);
        }
    }

    public void OnTeleport() {
        _lastTeleportSequence = Sequence;
    }
}

using Minecraft.Packets.Play.ServerBound;

namespace ClientLib.Player;

/// <summary>
/// The movement keys held this tick, vanilla's <c>Input.keyPresses</c>. Whatever drives the client
/// writes it before each tick; the player reads it in <c>aiStep</c>.
/// </summary>
public readonly record struct PlayerInput(
    bool Forward = false,
    bool Backward = false,
    bool Left = false,
    bool Right = false,
    bool Jump = false,
    bool Shift = false,
    bool Sprint = false) {

    public static readonly PlayerInput None = new();

    public ServerBoundPlayerInputPacket.Input ToPacketFlags() {
        ServerBoundPlayerInputPacket.Input flags = 0;
        if (Forward) flags |= ServerBoundPlayerInputPacket.Input.Forward;
        if (Backward) flags |= ServerBoundPlayerInputPacket.Input.Backward;
        if (Left) flags |= ServerBoundPlayerInputPacket.Input.Left;
        if (Right) flags |= ServerBoundPlayerInputPacket.Input.Right;
        if (Jump) flags |= ServerBoundPlayerInputPacket.Input.Jump;
        if (Shift) flags |= ServerBoundPlayerInputPacket.Input.Sneak;
        if (Sprint) flags |= ServerBoundPlayerInputPacket.Input.Sprint;
        return flags;
    }
}

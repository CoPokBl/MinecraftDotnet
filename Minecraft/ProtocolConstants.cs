namespace Minecraft;

/// <summary>
/// Some constants used in the Minecraft protocol.
/// These two are for variable length integers (VarInt and VarLong).
/// </summary>
public static class ProtocolConstants {
    public const int SegmentBits = 0x7F;
    public const int ContinueBit = 0x80;

    public const string CurrentVersionString = "26.2";
    public const int ProtocolVersion = 776;

    public static readonly Version CurrentVersion = new(26, 2);
}

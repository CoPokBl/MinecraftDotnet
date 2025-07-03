namespace Minecraft;

/// <summary>
/// Some constants used in the Minecraft protocol.
/// These two are for variable length integers (VarInt and VarLong).
/// </summary>
public static class ProtocolConstants {
    public const int SegmentBits = 0x7F;
    public const int ContinueBit = 0x80;
}

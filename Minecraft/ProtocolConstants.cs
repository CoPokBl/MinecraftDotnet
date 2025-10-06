namespace Minecraft;

/// <summary>
/// Some constants used in the Minecraft protocol.
/// These two are for variable length integers (VarInt and VarLong).
/// </summary>
public static class ProtocolConstants {
    public const int SegmentBits = 0x7F;
    public const int ContinueBit = 0x80;
    
    public const string CurrentVersion = "1.21.8";
    public const int ProtocolVersion = 771;
}

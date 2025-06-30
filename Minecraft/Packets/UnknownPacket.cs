namespace Minecraft.Packets;

/// <summary>
/// Represents a packet that could not be parsed or is unknown.
/// </summary>
public class UnknownPacket : MinecraftPacket {
    public required int Id;
    public required byte[] Data;
    
    protected override byte[] GetData() {
        return Data;
    }
}

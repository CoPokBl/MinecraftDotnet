using Minecraft.Schemas;

namespace Minecraft.Packets;

/// <summary>
/// Represents a packet that could not be parsed or is unknown.
/// </summary>
public class UnknownPacket : MinecraftPacket {
    public override Identifier Identifier => "minecraftcs:unknown";
    
    public required int Id;
    public required byte[] Data;

    protected override DataWriter WriteData(DataWriter w) {
        return w.Write(Data);
    }
}

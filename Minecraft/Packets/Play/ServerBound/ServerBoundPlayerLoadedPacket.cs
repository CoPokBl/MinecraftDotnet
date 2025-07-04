using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPlayerLoadedPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:player_loaded";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundPlayerLoadedPacket();
}

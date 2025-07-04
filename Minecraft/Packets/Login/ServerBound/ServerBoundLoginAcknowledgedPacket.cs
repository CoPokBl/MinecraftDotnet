using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundLoginAcknowledgedPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:login_acknowledged";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundLoginAcknowledgedPacket();
}

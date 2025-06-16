using Minecraft.NBT.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundCombatDeathPacket(int playerId, TextComponent message) : MinecraftPacket {
    public int PlayerId = playerId;
    public TextComponent Message = message;
    
    public ClientBoundCombatDeathPacket() : this(0, TextComponent.Empty()) { }

    public override int GetPacketId() {
        return 0x3D;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(PlayerId)
            .WriteNbt(Message)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        PlayerId = r.ReadVarInt();
        Message = r.ReadText();
        return this;
    }
}
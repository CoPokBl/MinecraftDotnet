using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPlayerCommandPacket(int entityId, PlayerAction action, int jumpBoost) : MinecraftPacket {
    public int EntityId = entityId;
    public PlayerAction PlayAction = action;
    public int JumpBoost = jumpBoost;

    public ServerBoundPlayerCommandPacket() : this(0, PlayerAction.PressSneak, 0) { }

    public override int GetPacketId() {
        return 0x28;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteVarInt((int)PlayAction)
            .WriteVarInt(JumpBoost)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        PlayAction = (PlayerAction)r.ReadVarInt();
        JumpBoost = r.ReadVarInt();
        return this;
    }
}
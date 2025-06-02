using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundGameEventPacket(GameEvent gameEvent, float value) : MinecraftPacket {
    public GameEvent Event = gameEvent;
    public float Value = value;

    public ClientBoundGameEventPacket() : this(GameEvent.NoRespawnBlock, 0) { }

    public override int GetPacketId() {
        return 0x22;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteUnsignedByte((byte)Event)
            .WriteFloat(Value)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Event = (GameEvent)r.Read();
        Value = r.ReadFloat();
        return this;
    }
}
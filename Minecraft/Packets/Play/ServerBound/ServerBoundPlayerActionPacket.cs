using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPlayerActionPacket(ServerBoundPlayerActionPacket.Status status, BlockPosition location, BlockFace face, int sequence) : MinecraftPacket {
    public Status ActionStatus = status;
    public BlockPosition Location = location;
    public BlockFace Face = face;
    public int Sequence = sequence;
    
    public ServerBoundPlayerActionPacket() : this(Status.DropItem, new BlockPosition(0, 0, 0), BlockFace.NegX, 0) { }

    public enum Status {
        StartedDigging,
        CancelledDigging,
        FinishedDigging,
        DropItemStack,
        DropItem,
        UpdateHeldItem,  // used for after eating or pulling back a bow or using a bucket (anything that should change item state)
        SwapItem
    }

    public override int GetPacketId() {
        return 0x27;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt((int)ActionStatus)
            .WritePosition(Location)
            .WriteByte((int)Face)
            .WriteVarInt(Sequence)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        ActionStatus = (Status)r.ReadVarInt();
        Location = r.ReadPosition();
        Face = (BlockFace)r.ReadByte();
        Sequence = r.ReadVarInt();
        return this;
    }
}
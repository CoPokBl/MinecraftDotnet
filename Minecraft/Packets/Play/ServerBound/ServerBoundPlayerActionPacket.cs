using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPlayerActionPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:player_action";
    
    public required Status ActionStatus;
    public required BlockPosition Location;
    public required BlockFace Face;
    public required int Sequence;

    public enum Status {
        StartedDigging,
        CancelledDigging,
        FinishedDigging,
        DropItemStack,
        DropItem,
        UpdateHeldItem,  // used for after eating or pulling back a bow or using a bucket (anything that should change item state)
        SwapItem
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt((int)ActionStatus)
            .WritePosition(Location)
            .WriteByte((int)Face)
            .WriteVarInt(Sequence);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPlayerActionPacket {
        ActionStatus = (Status)r.ReadVarInt(),
        Location = r.ReadPosition(),
        Face = (BlockFace)r.ReadByte(),
        Sequence = r.ReadVarInt()
    };
}
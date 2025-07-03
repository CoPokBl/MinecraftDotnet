using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPlayerCommandPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:player_command";
    
    public required int EntityId;
    public required PlayerAction PlayAction;
    public required int JumpBoost;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteVarInt((int)PlayAction)
            .WriteVarInt(JumpBoost)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPlayerCommandPacket {
        EntityId = r.ReadVarInt(),
        PlayAction = (PlayerAction)r.ReadVarInt(),
        JumpBoost = r.ReadVarInt()
    };
}

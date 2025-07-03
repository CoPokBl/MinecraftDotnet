using Minecraft.NBT.Text;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundCombatDeathPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_combat_kill";
    
    public required int PlayerId;
    public required TextComponent Message;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(PlayerId)
            .WriteNbt(Message)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundCombatDeathPacket {
        PlayerId = r.ReadVarInt(),
        Message = r.ReadText()
    };
}
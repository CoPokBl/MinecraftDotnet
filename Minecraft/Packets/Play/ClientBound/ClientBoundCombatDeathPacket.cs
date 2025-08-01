using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundCombatDeathPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_combat_kill";
    
    public required int PlayerId;
    public required TextComponent Message;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(PlayerId)
            .WriteNbt(Message);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundCombatDeathPacket {
        PlayerId = r.ReadVarInt(),
        Message = r.ReadText()
    };
}
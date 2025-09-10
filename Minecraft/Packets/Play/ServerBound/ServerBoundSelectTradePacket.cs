using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSelectTradePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:select_trade";
    
    public required int SelectedSlot { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(SelectedSlot);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSelectTradePacket {
        SelectedSlot = r.ReadVarInt()
    };
}

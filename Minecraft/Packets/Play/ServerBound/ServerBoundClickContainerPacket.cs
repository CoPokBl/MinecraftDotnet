using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundClickContainerPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:container_click";

    public required int WindowId { get; init; }
    public required int StateId { get; init; }
    public required short Slot { get; init; }
    public required sbyte Button { get; init; }
    public required int Mode { get; init; }
    public required Dictionary<short, HashedSlot?> ChangedSlots { get; init; }
    public required HashedSlot? CursorItem { get; init; }
    
    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return
            w.WriteVarInt(WindowId)
                .WriteVarInt(StateId)
                .WriteShort(Slot)
                .WriteByte(Button)
                .WriteVarInt(Mode)
                .WritePrefixedArray(ChangedSlots.ToArray(), (pair, wr) => 
                    wr.WriteShort(pair.Key)
                        .Write(wri => {
                            wri.WriteBoolean(pair.Value != null);
                            if (pair.Value != null) {
                                wri.Write(pair.Value, reg);
                            }
                        }))
                .WritePrefixedOptional(CursorItem, reg);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ServerBoundClickContainerPacket {
        WindowId = r.ReadVarInt(),
        StateId = r.ReadVarInt(),
        Slot = r.ReadShort(),
        Button = r.ReadByte(),
        Mode = r.ReadVarInt(),
        ChangedSlots = r.ReadPrefixedArray(r2 => {
            short key = r2.ReadShort();
            bool hasValue = r2.ReadBoolean();
            HashedSlot? value = hasValue ? r2.Read<HashedSlot>(reg) : null;
            return (key, value);
        }).ToDictionary(pair => pair.key, pair => pair.value),
        CursorItem = r.ReadPrefixedOptional<HashedSlot>(reg)
    };
}

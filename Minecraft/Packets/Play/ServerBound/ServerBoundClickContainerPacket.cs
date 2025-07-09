using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundClickContainerPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:container_click";

    public required int WindowId;
    public required int StateId;
    public required short Slot;
    public required sbyte Button;
    public required int Mode;
    public required Dictionary<short, HashedSlot?> ChangedSlots;
    public required HashedSlot? CursorItem;
    
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
                            pair.Value?.Write(wri, reg);
                        }))
                .WritePrefixedOptional(CursorItem, (slot, wr) => slot.Write(wr, reg));
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
            HashedSlot? value = hasValue ? HashedSlot.Read(r2, reg) : null;
            return (key, value);
        }).ToDictionary(pair => pair.key, pair => pair.value),
        CursorItem = r.ReadPrefixedOptional(r2 => HashedSlot.Read(r2, reg))
    };
}

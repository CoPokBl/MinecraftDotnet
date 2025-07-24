using System.Diagnostics.CodeAnalysis;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetEquipmentPacket() : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_equipment";

    public required int EntityId;
    public required Dictionary<EquipmentSlot, ItemStack> Equipment;

    [SetsRequiredMembers]
    public ClientBoundSetEquipmentPacket(int entityId, Dictionary<EquipmentSlot, ItemStack> equipment) : this() {
        if (equipment.Count == 0) {
            throw new ArgumentException("Equipment cannot be empty.", nameof(equipment));
        }
        EntityId = entityId;
        Equipment = equipment;
    }
    
    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        if (Equipment.Count == 0) {
            throw new ArgumentException("Equipment cannot be empty.", nameof(Equipment));
        }
        
        w.WriteVarInt(EntityId);
        KeyValuePair<EquipmentSlot, ItemStack>[] equipment = Equipment.ToArray();
        for (int i = 0; i < equipment.Length; i++) {
            (EquipmentSlot slot, ItemStack item) = equipment[i];
            
            // If this is the last item then slotId should be positive, otherwise it should be negative
            sbyte slotId = (sbyte)slot;
            if (i != equipment.Length - 1) {
                slotId = (sbyte)(slotId | 0x80); // set the high bit to indicate it's not the last item
            }

            w.WriteByte(slotId);
            w.Write(item, registry);
        }

        return w;
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (reader, registry) => {
        int entityId = reader.ReadVarInt();
        
        Dictionary<EquipmentSlot, ItemStack> equipment = new();
        while (true) {
            sbyte slotId = reader.ReadByte();
            if (slotId >= 0) { // positive
                EquipmentSlot slot = (EquipmentSlot)slotId;
                ItemStack item = reader.Read<ItemStack>(registry);
                equipment[slot] = item;
                break; // last item
            } else { // negative
                EquipmentSlot slot = (EquipmentSlot)(slotId & 0x7F);
                ItemStack item = reader.Read<ItemStack>(registry);
                equipment[slot] = item;
            }
        }

        return new ClientBoundSetEquipmentPacket {
            EntityId = entityId,
            Equipment = equipment
        };
    };
}

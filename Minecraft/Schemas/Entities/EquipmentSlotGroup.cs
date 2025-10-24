namespace Minecraft.Schemas.Entities;

public record EquipmentSlotGroup(int ProtocolId, string Name, params EquipmentSlot[] Slots) : INbtEnum {
    public static readonly EquipmentSlotGroup Any = new(0, "any", EquipmentSlot.MainHand, EquipmentSlot.OffHand, EquipmentSlot.Boots, EquipmentSlot.Leggings, EquipmentSlot.Chestplate, EquipmentSlot.Helmet, EquipmentSlot.Body, EquipmentSlot.Saddle);
    public static readonly EquipmentSlotGroup MainHand = new(1, "mainhand", EquipmentSlot.MainHand);
    public static readonly EquipmentSlotGroup OffHand = new(2, "offhand", EquipmentSlot.OffHand);
    public static readonly EquipmentSlotGroup Hand = new(3, "hand", EquipmentSlot.MainHand, EquipmentSlot.OffHand);
    public static readonly EquipmentSlotGroup Feet = new(4, "feet", EquipmentSlot.Boots);
    public static readonly EquipmentSlotGroup Legs = new(5, "legs", EquipmentSlot.Leggings);
    public static readonly EquipmentSlotGroup Chest = new(6, "chest", EquipmentSlot.Chestplate);
    public static readonly EquipmentSlotGroup Head = new(7, "head", EquipmentSlot.Helmet);
    public static readonly EquipmentSlotGroup Armor = new(8, "armor", EquipmentSlot.Boots, EquipmentSlot.Leggings, EquipmentSlot.Chestplate, EquipmentSlot.Helmet);
    public static readonly EquipmentSlotGroup Body = new(9, "body", EquipmentSlot.Body);
    public static readonly EquipmentSlotGroup Saddle = new(10, "saddle", EquipmentSlot.Saddle);
    
    public static readonly EquipmentSlotGroup[] Values = [Any, MainHand, OffHand, Hand, Feet, Legs, Chest, Head, Armor, 
        Body, Saddle];
    
    public static EquipmentSlotGroup FromName(string value) => Values.First(v => v.Name == value);
    public static EquipmentSlotGroup FromProtocolId(int id) => Values.First(v => v.ProtocolId == id);
    
    public bool ContainsSlot(EquipmentSlot slot) => Slots.Contains(slot);
}

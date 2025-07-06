namespace Minecraft.Schemas;

/// <summary>
/// Enum representing what slot an item must be in to apply an attribute modifier.
/// </summary>
public enum AttributeActiveSlot {
    Any = 0,
    MainHand = 1,
    OffHand = 2,
    Hand = 3,
    Feet = 4,
    Legs = 5,
    Chest = 6,
    Head = 7,
    Armor = 8,
    Body = 9
}

namespace Minecraft.Schemas.Entities;

[Flags]
public enum ArmorStandState : sbyte {
    None = 0x00,
    Small = 0x01,
    Arms = 0x04,
    NoBasePlate = 0x08,
    Marker = 0x10
}

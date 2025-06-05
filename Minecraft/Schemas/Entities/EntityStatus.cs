namespace Minecraft.Schemas.Entities;

[Flags]
public enum EntityStatus {
    OnFire = 0x01,
    Sneaking = 0x02,
    Riding = 0x04,  // UNUSED by notchian server/client
    Sprinting = 0x08,
    Swimming = 0x10,
    Invisible = 0x20,
    Glowing = 0x40,
    ElytraFlying = 0x80,
    
    None = 0x00
}

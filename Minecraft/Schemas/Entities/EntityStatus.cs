namespace Minecraft.Schemas.Entities;

[Flags]
public enum EntityStatus : sbyte {
    OnFire = 0x01,
    Sneaking = 0x02,
    Riding = 0x04,  // UNUSED by notchian server/client
    Sprinting = 0x08,
    Swimming = 0x10,
    Invisible = 0x20,
    Glowing = 0x40,
    ElytraFlying = -128,  // can't be 0x80 because it's a signed byte (because java uses signed bytes)
    
    None = 0x00
}

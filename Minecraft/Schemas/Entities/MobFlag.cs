namespace Minecraft.Schemas.Entities;

[Flags]
public enum MobFlag {
    None = 0x00,
    NoAi = 0x01,
    IsLeftHanded = 0x02,
    IsAggressive = 0x04
}

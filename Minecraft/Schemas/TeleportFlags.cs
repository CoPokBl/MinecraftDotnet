namespace Minecraft.Schemas;

[Flags]
public enum TeleportFlags {
    RelativeX = 1 << 0,
    RelativeY = 1 << 1,
    RelativeZ = 1 << 2,
    RelativeYaw = 1 << 3,
    RelativePitch = 1 << 4,
    RelativeVelocityX = 1 << 5,
    RelativeVelocityY = 1 << 6,
    RelativeVelocityZ = 1 << 7,
    RotVelWithDeltaVelocity = 1 << 8,
    
    RelativeRotation = RelativeYaw | RelativePitch,
    RelativeVelocity = RelativeVelocityX | RelativeVelocityY | RelativeVelocityZ,
    RelativeAll = RelativeX | RelativeY | RelativeZ | RelativeRotation | RelativeVelocity,
    None = 0,
}
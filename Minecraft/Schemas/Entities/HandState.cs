namespace Minecraft.Schemas.Entities;

[Flags]
public enum HandState {
    HandActive = 0x01,
    ActiveHandOffhand = 0x02,  // disable for Main hand, set for Offhand
    IsRiptideSpinAttacking = 0x04,
    
    None = 0x00
}
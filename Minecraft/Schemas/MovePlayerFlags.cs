namespace Minecraft.Schemas;

public enum MovePlayerFlags {
    OnGround = 0x01,
    AgainstWall = 0x02,
    
    None = 0x00,
    All = OnGround | AgainstWall
}
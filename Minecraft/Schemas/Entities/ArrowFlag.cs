namespace Minecraft.Schemas.Entities;

[Flags]
public enum ArrowFlag {
    Critical = 0x01,
    
    /// <summary>
    /// Used by loyalty tridents when returning to the player.
    /// </summary>
    NoClip = 0x02
}

namespace Minecraft.Schemas;

/// <summary>
/// Which point of an entity a facing calculation uses, matching the anchor argument of
/// <c>/teleport</c> and <c>/execute facing</c>.
/// </summary>
public enum EntityAnchor {
    Feet = 0,
    Eyes = 1
}

namespace Minecraft.Schemas.Items;

/// <summary>
/// What the client does to a map item the next time the server hands it one, vanilla's
/// <c>MapPostProcessing</c>.
/// </summary>
public enum MapPostProcessing {
    Lock = 0,
    Scale = 1
}

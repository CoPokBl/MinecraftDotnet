using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class CatRenderState : FelineRenderState {
    public const string DefaultTexture = "minecraft:textures/entity/cat/cat_tabby.png";

    public string Texture = DefaultTexture;
    public bool IsLyingOnTopOfSleepingPlayer;
    public DyeColor? CollarColor;
}

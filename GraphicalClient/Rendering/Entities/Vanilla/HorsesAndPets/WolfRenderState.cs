using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class WolfRenderState : LivingEntityRenderState {
    public const string DefaultTexture = "minecraft:textures/entity/wolf/wolf.png";

    public bool IsAngry;
    public bool IsSitting;
    public float TailAngle = (float)(Math.PI / 5);
    public float HeadRollAngle;
    public float ShakeAnim;
    public float WetShade = 1.0F;
    public string Texture = DefaultTexture;
    public DyeColor? CollarColor;
    public ItemStack BodyArmorItem = ItemStack.Air;

    public float GetBodyRollAngle(float offset) {
        float progress = (ShakeAnim + offset) / 1.8F;
        if (progress < 0.0F) {
            progress = 0.0F;
        }
        else if (progress > 1.0F) {
            progress = 1.0F;
        }
        return Mth.Sin(progress * MathF.PI) * Mth.Sin(progress * MathF.PI * 11.0F) * 0.15F * MathF.PI;
    }
}

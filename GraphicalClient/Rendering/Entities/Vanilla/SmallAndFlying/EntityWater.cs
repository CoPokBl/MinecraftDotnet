using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.World;
using Minecraft.Physics;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>Entity.isInWater</c> for an entity the client does not simulate: <c>updateFluidInteraction</c>'s
/// water test against the box <c>getDimensions</c> gives it.
/// </summary>
internal static class EntityWater {
    /// <remarks>
    /// Tested where the entity stood when this tick began: <c>baseTick</c> runs the test before
    /// <c>aiStep</c> moves it, so that is the position vanilla's flag holds for the whole tick.
    /// </remarks>
    public static bool IsInWater(ClientLevel level, ClientEntity entity) {
        Vec3d at = entity.OldPosition;
        // LivingEntity.getScale: the age scale times the scale attribute.
        double scale = entity.IsBaby ? 0.5 : 1.0;
        if (entity.IsLiving) {
            double attribute = entity.Attributes.Value(Minecraft.Data.Generated.Attribute.Scale);
            scale *= attribute > 0 ? attribute : 1.0;
        }
        double halfWidth = entity.Width * scale / 2.0, height = entity.Height * scale;
        Box box = new(at.X - halfWidth, at.Y, at.Z - halfWidth, at.X + halfWidth, at.Y + height, at.Z + halfWidth);
        FluidInteraction fluids = new();
        fluids.Update(level, box, (int)Math.Floor(at.X), at.Y + entity.EyeHeight * scale, (int)Math.Floor(at.Z), true);
        return fluids.InWater;
    }
}

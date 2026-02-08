using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record DisplayMeta(
    int? InterpolationDelay = null,
    int? TransformationInterpolationDelay = null,
    int? PositionRotationInterpolationDuration = null,
    Vec3<float>? Translation = null,
    Vec3<float>? Scale = null,
    Quaternion? RotationLeft = null,
    Quaternion? RotationRight = null,
    DisplayMeta.BillboardConstraint? BillboardConstraints = null,
    int? BrightnessOverride = null,
    float? ViewRange = null,
    float? ShadowRadius = null,
    float? ShadowStrength = null,
    float? Width = null,
    float? Height = null,
    int? GlowColorOverride = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (DisplayMeta)base.LoadFields(container) with {
            InterpolationDelay = container.GetValue<int>(8),
            TransformationInterpolationDelay = container.GetValue<int>(9),
            PositionRotationInterpolationDuration = container.GetValue<int>(10),
            Translation = container.GetValue<Vec3<float>>(11),
            Scale = container.GetValue<Vec3<float>>(12),
            RotationLeft = container.GetValue<Quaternion>(13),
            RotationRight = container.GetValue<Quaternion>(14),
            BillboardConstraints = container.GetValue<BillboardConstraint>(15),
            BrightnessOverride = container.GetValue<int>(16),
            ViewRange = container.GetValue<float>(17),
            ShadowRadius = container.GetValue<float>(18),
            ShadowStrength = container.GetValue<float>(19),
            Width = container.GetValue<float>(20),
            Height = container.GetValue<float>(21),
            GlowColorOverride = container.GetValue<int>(22)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.VarInt, InterpolationDelay)
            .WithField(9, MetaFieldType.VarInt, TransformationInterpolationDelay)
            .WithField(10, MetaFieldType.VarInt, PositionRotationInterpolationDuration)
            .WithField(11, MetaFieldType.Vector3, Translation)
            .WithField(12, MetaFieldType.Vector3, Scale)
            .WithField(13, MetaFieldType.Quaternion, RotationLeft)
            .WithField(14, MetaFieldType.Quaternion, RotationRight)
            .WithField(15, MetaFieldType.Byte, BillboardConstraints)
            .WithField(16, MetaFieldType.VarInt, BrightnessOverride)
            .WithField(17, MetaFieldType.Float, ViewRange)
            .WithField(18, MetaFieldType.Float, ShadowRadius)
            .WithField(19, MetaFieldType.Float, ShadowStrength)
            .WithField(20, MetaFieldType.Float, Width)
            .WithField(21, MetaFieldType.Float, Height)
            .WithField(22, MetaFieldType.VarInt, GlowColorOverride);
    }
    
    public enum BillboardConstraint : sbyte {
        Fixed = 0,
        Vertical = 1,
        Horizontal = 2,
        Center = 3
    }
}

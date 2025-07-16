using Minecraft.Data.Particles;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record AreaEffectCloudMeta(
    float? Radius = null,
    bool? SinglePoint = null,
    IParticle? Particle = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (AreaEffectCloudMeta)base.LoadFields(container) with {
            Radius = container.GetValue<float>(8),
            SinglePoint = container.GetValue<bool>(9),
            Particle = container.GetValue<IParticle>(10)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Float, Radius)
            .WithField(9, MetaFieldType.Boolean, SinglePoint)
            .WithField(10, MetaFieldType.Particle, Particle);
    }
}

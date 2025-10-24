using NBT;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record PlayerMeta(
    float? AdditionalHearts = null,
    int? Score = null,
    INbtTag? LeftShoulderEntity = null,
    INbtTag? RightShoulderEntity = null) : AvatarMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (PlayerMeta)base.LoadFields(container) with {
            AdditionalHearts = container.GetValue<float>(17),
            Score = container.GetValue<int>(18),
            LeftShoulderEntity = container.GetValue<INbtTag>(19),
            RightShoulderEntity = container.GetValue<INbtTag>(20)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(17, MetaFieldType.Float, AdditionalHearts)
            .WithField(18, MetaFieldType.VarInt, Score)
            .WithField(19, MetaFieldType.Nbt, LeftShoulderEntity)
            .WithField(20, MetaFieldType.Nbt, RightShoulderEntity);
    }
}

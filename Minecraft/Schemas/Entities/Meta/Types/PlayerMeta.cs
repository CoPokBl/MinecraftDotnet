using NBT;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record PlayerMeta(
    float? AdditionalHearts = null,
    int? Score = null,
    int? LeftShoulderEntity = null,
    int? RightShoulderEntity = null) : AvatarMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (PlayerMeta)base.LoadFields(container) with {
            AdditionalHearts = container.GetValue<float>(17),
            Score = container.GetValue<int>(18),
            LeftShoulderEntity = container.GetValue<int?>(19),
            RightShoulderEntity = container.GetValue<int?>(20)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(17, MetaFieldType.Float, AdditionalHearts)
            .WithField(18, MetaFieldType.VarInt, Score)
            .WithField(19, MetaFieldType.OptionalVarInt, LeftShoulderEntity)
            .WithField(20, MetaFieldType.OptionalVarInt, RightShoulderEntity);
    }
}

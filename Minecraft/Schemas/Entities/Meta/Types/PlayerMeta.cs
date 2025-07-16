using NBT;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record PlayerMeta(
    float? AdditionalHearts = null,
    int? Score = null,
    SkinParts? SkinFlags = null,
    DominantHand? MainHand = null,
    INbtTag? LeftShoulderEntity = null,
    INbtTag? RightShoulderEntity = null) : LivingEntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (PlayerMeta)base.LoadFields(container) with {
            AdditionalHearts = container.GetValue<float>(15),
            Score = container.GetValue<int>(16),
            SkinFlags = container.GetValue<SkinParts>(17),
            MainHand = container.GetValue<DominantHand>(18),
            LeftShoulderEntity = container.GetValue<INbtTag>(19),
            RightShoulderEntity = container.GetValue<INbtTag>(20)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(15, MetaFieldType.Float, AdditionalHearts)
            .WithField(16, MetaFieldType.VarInt, Score)
            .WithField(17, MetaFieldType.Byte, SkinFlags)
            .WithField(18, MetaFieldType.Byte, MainHand)
            .WithField(19, MetaFieldType.Nbt, LeftShoulderEntity)
            .WithField(20, MetaFieldType.Nbt, RightShoulderEntity);
    }
}

using Minecraft.NBT;

namespace Minecraft.Schemas.Entities.Meta;

public class PlayerMeta : LivingEntityMeta {
    public float? AdditionalHearts = null;
    public int? Score = null;
    public SkinParts? SkinFlags = null;
    public DominantHand? MainHand = null;
    public ITag? LeftShoulderEntity = null;
    public ITag? RightShoulderEntity = null;

    public new DataWriter Serialise(DataWriter writer) {
        return base.Serialise(writer)
            .WriteMetaParam(AdditionalHearts, 15, MetaFieldType.Float, (f, w) => w.WriteFloat(f))
            .WriteMetaParam(Score, 16, MetaFieldType.VarInt, (i, w) => w.WriteVarInt(i))
            .WriteMetaParam(SkinFlags, 17, MetaFieldType.Byte, (parts, w) => w.Write((byte)parts))
            .WriteMetaParam(MainHand, 18, MetaFieldType.Byte, (hand, w) => w.Write((byte)hand))
            .WriteMetaParam(LeftShoulderEntity, 19, MetaFieldType.Nbt, (tag, w) => w.WriteNbt(tag))
            .WriteMetaParam(RightShoulderEntity, 20, MetaFieldType.Nbt, (tag, w) => w.WriteNbt(tag));
    }
}
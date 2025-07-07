using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Entities.Meta;

public class LivingEntityMeta : EntityMeta {
    public HandState? HandStates = null;
    public float? Health = null;
    public int[]? Particles = null;
    public bool? IsPotionAmbient = null;
    public int? ArrowsInEntity = null;
    public int? BeeStingersInEntity = null;
    public Optional<IVec3>? SleepingBed = null;

    public new DataWriter Serialise(DataWriter writer) {
        return base.Serialise(writer)
            .WriteMetaParam(HandStates, 8, MetaFieldType.Byte, (state, w) => w.Write((byte)state))
            .WriteMetaParam(Health, 9, MetaFieldType.Float, (f, w) => w.WriteFloat(f))
            .WriteMetaParam(Particles, 10, MetaFieldType.Particles, (ints, w) => 
                w.WritePrefixedArray(ints, (i, w2) => w2.WriteVarInt(i)))
            .WriteMetaParam(IsPotionAmbient, 11, MetaFieldType.Boolean, (b, w) => w.WriteBoolean(b))
            .WriteMetaParam(ArrowsInEntity, 12, MetaFieldType.VarInt, (i, w) => w.WriteVarInt(i))
            .WriteMetaParam(BeeStingersInEntity, 13, MetaFieldType.VarInt, (i, w) => w.WriteVarInt(i))
            .WriteMetaParam(SleepingBed, 14, MetaFieldType.OptionalPosition, (optional, w) => 
                w.WritePrefixedOptional(optional, (position, w2) => w2.WritePosition(position)));
    }
}
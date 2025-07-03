using Minecraft.Text;

namespace Minecraft.Schemas.Entities.Meta;

public class EntityMeta {
    public EntityStatus? Status = null;
    public int? AirTicks = null;
    public Optional<TextComponent>? CustomName = null;
    public bool? CustomNameVisible = null;
    public bool? Silent = null;
    public bool? NoGravity = null;
    public EntityPose? Pose = null;
    public int? TicksInPowderedSnow = null;

    public DataWriter Serialise(DataWriter writer) {
        return writer
            .WriteMetaParam(Status, 0, MetaFieldType.Byte, (v, w) => w.Write((byte)v))
            .WriteMetaParam(AirTicks, 1, MetaFieldType.VarInt, (i, w) => w.WriteVarInt(i))
            .WriteMetaParam(CustomName, 2, MetaFieldType.OptionalTextComponent, (optional, w) => 
                w.WritePrefixedOptional(optional, (c, w2) => w2.WriteNbt(c)))
            .WriteMetaParam(CustomNameVisible, 3, MetaFieldType.Boolean, (b, w) => w.WriteBoolean(b))
            .WriteMetaParam(Silent, 4, MetaFieldType.Boolean, (b, w) => w.WriteBoolean(b))
            .WriteMetaParam(NoGravity, 5, MetaFieldType.Boolean, (b, w) => w.WriteBoolean(b))
            .WriteMetaParam(Pose, 6, MetaFieldType.Pose, (i, w) => w.WriteVarInt((int)i))
            .WriteMetaParam(TicksInPowderedSnow, 7, MetaFieldType.VarInt, (i, w) => w.WriteVarInt(i));
    }
}
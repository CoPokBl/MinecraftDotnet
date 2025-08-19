using Minecraft.Data.Blocks;
using Minecraft.Data.Particles;
using Minecraft.Registry;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using NBT;

namespace Minecraft.Schemas.Entities.Meta;

public class EntityMetaContainer {
    public Dictionary<int, MetaField> Fields { get; } = new();
    
    private static readonly Dictionary<MetaFieldType, Func<MinecraftRegistry, DataReader, MetaField>> FieldTypeReaders = new() {
        { MetaFieldType.Byte, (_, reader) => new MetaField<sbyte>(MetaFieldType.Byte, reader.ReadByte()) },
        { MetaFieldType.VarInt, (_, reader) => new MetaField<int>(MetaFieldType.VarInt, reader.ReadVarInt()) },
        { MetaFieldType.VarLong, (_, reader) => new MetaField<long>(MetaFieldType.VarLong, reader.ReadVarLong()) },
        { MetaFieldType.Float, (_, reader) => new MetaField<float>(MetaFieldType.Float, reader.ReadFloat()) },
        { MetaFieldType.String, (_, reader) => new MetaField<string>(MetaFieldType.String, reader.ReadString()) },
        { MetaFieldType.TextComponent, (_, reader) => new MetaField<TextComponent>(MetaFieldType.TextComponent, reader.ReadText()) },
        { MetaFieldType.OptionalTextComponent, (_, reader) => new MetaField<Optional<TextComponent>>(MetaFieldType.OptionalTextComponent, 
            reader.ReadPrefixedOptional(r => r.ReadText())) },
        { MetaFieldType.Slot, (reg, reader) => new MetaField<ItemStack>(MetaFieldType.Slot, reader.Read<ItemStack>(reg)) },
        { MetaFieldType.Boolean, (_, reader) => new MetaField<bool>(MetaFieldType.Boolean, reader.ReadBoolean()) },
        { MetaFieldType.Rotations, (_, reader) => new MetaField<Vec3<float>>(MetaFieldType.Rotations, reader.ReadFVec3()) },
        { MetaFieldType.Position, (_, reader) => new MetaField<Vec3<int>>(MetaFieldType.Position, reader.ReadPosition()) },
        { MetaFieldType.OptionalPosition, (_, reader) => new MetaField<Optional<Vec3<int>>>(MetaFieldType.OptionalPosition, 
            reader.ReadPrefixedOptional(r => r.ReadPosition())) },
        { MetaFieldType.Direction, (_, reader) => new MetaField<Cardinal>(MetaFieldType.Direction, (Cardinal)reader.ReadVarInt()) },
        { MetaFieldType.OptionalLivingEntityReference, (_, reader) => new MetaField<Optional<Guid>>(MetaFieldType.OptionalLivingEntityReference, 
            reader.ReadPrefixedOptional(r => r.ReadUuid())) },
        { MetaFieldType.BlockState, (reg, reader) => new MetaField<IBlock>(MetaFieldType.BlockState, reg.Blocks.GetByStateId((uint)reader.ReadVarInt())) },
        { MetaFieldType.OptionalBlockState, (reg, reader) => new MetaField<Optional<IBlock>>(MetaFieldType.OptionalBlockState, 
            Optional<IBlock>.FromNullable(reader.ReadPrefixedOptional(r => reg.Blocks.GetByStateId((uint)r.ReadVarInt())))) },
        { MetaFieldType.Nbt, (_, reader) => new MetaField<INbtTag>(MetaFieldType.Nbt, reader.ReadNbt()) },
        { MetaFieldType.Particle, (reg, reader) => new MetaField<IParticle>(MetaFieldType.Particle, 
            reg.Particles[reader.ReadVarInt()].ReadData(reader, reg)) },
        { MetaFieldType.Particles, (reg, reader) => new MetaField<IParticle[]>(MetaFieldType.Particles, 
            reader.ReadPrefixedArray(r => reg.Particles[r.ReadVarInt()].ReadData(r, reg))) },
        { MetaFieldType.VillagerData, (_, reader) => new MetaField<(int, int, int)>(MetaFieldType.VillagerData, 
            (reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt())) },
        { MetaFieldType.OptionalVarInt, (_, reader) => new MetaField<Optional<int>>(MetaFieldType.OptionalVarInt, 
            reader.ReadPrefixedOptional(r => r.ReadVarInt())) },
        { MetaFieldType.Pose, (_, reader) => new MetaField<EntityPose>(MetaFieldType.Pose, (EntityPose)reader.ReadVarInt()) },
        { MetaFieldType.CatVariant, (_, reader) => new MetaField<int>(MetaFieldType.CatVariant, reader.ReadVarInt()) },
        { MetaFieldType.CowVariant, (_, reader) => new MetaField<int>(MetaFieldType.CowVariant, reader.ReadVarInt()) },
        { MetaFieldType.WolfVariant, (_, reader) => new MetaField<int>(MetaFieldType.WolfVariant, reader.ReadVarInt()) },
        { MetaFieldType.WolfSoundVariant, (_, reader) => new MetaField<int>(MetaFieldType.WolfSoundVariant, reader.ReadVarInt()) },
        { MetaFieldType.FrogVariant, (_, reader) => new MetaField<int>(MetaFieldType.FrogVariant, reader.ReadVarInt()) },
        { MetaFieldType.PigVariant, (_, reader) => new MetaField<int>(MetaFieldType.PigVariant, reader.ReadVarInt()) },
        { MetaFieldType.ChickenVariant, (_, reader) => new MetaField<int>(MetaFieldType.ChickenVariant, reader.ReadVarInt()) },
        { MetaFieldType.OptionalGlobalPosition, (_, reader) => new MetaField<Optional<(Identifier, Vec3<int>)>>(MetaFieldType.OptionalGlobalPosition, 
            reader.ReadPrefixedOptional(r => (r.ReadString(), r.ReadPosition()))) },
        { MetaFieldType.PaintingVariant, (_, reader) => new MetaField<Or<int, PaintingVariant>>(MetaFieldType.PaintingVariant, 
            reader.ReadIdOr(PaintingVariant.Read)) },
        { MetaFieldType.SnifferState, (_, reader) => new MetaField<SnifferState>(MetaFieldType.SnifferState, 
            (SnifferState)reader.ReadVarInt()) },
        { MetaFieldType.ArmadilloState, (_, reader) => new MetaField<ArmadilloState>(MetaFieldType.ArmadilloState,
            (ArmadilloState)reader.ReadVarInt()) },
        { MetaFieldType.Vector3, (_, reader) => new MetaField<Vec3<float>>(MetaFieldType.Vector3, reader.ReadFVec3()) },
        { MetaFieldType.Quaternion, (_, reader) => new MetaField<Quaternion>(MetaFieldType.Quaternion, reader.ReadQuaternion()) }
    };
    
    private static readonly Dictionary<MetaFieldType, Action<MinecraftRegistry, DataWriter, MetaField>> FieldTypeWriters = new() {
        { MetaFieldType.Byte, (_, writer, field) => writer.WriteByte(field.GetValue<sbyte>()) },
        { MetaFieldType.VarInt, (_, writer, field) => writer.WriteVarInt(field.GetValue<int>()) },
        { MetaFieldType.VarLong, (_, writer, field) => writer.WriteVarLong(field.GetValue<long>()) },
        { MetaFieldType.Float, (_, writer, field) => writer.WriteFloat(field.GetValue<float>()) },
        { MetaFieldType.String, (_, writer, field) => writer.WriteString(field.GetValue<string>()) },
        { MetaFieldType.TextComponent, (_, writer, field) => writer.WriteNbt(field.GetValue<TextComponent>()) },
        { MetaFieldType.OptionalTextComponent, (_, writer, field) => 
            writer.WritePrefixedOptional(field.GetValue<Optional<TextComponent>>(), (c, w) => w.WriteNbt(c)) },
        { MetaFieldType.Slot, (reg, writer, field) => writer.Write(field.GetValue<ItemStack>(), reg) },
        { MetaFieldType.Boolean, (_, writer, field) => writer.WriteBoolean(field.GetValue<bool>()) },
        { MetaFieldType.Rotations, (_, writer, field) => writer.WriteVec3(field.GetValue<Vec3<float>>()) },
        { MetaFieldType.Position, (_, writer, field) => writer.WritePosition(field.GetValue<Vec3<int>>()) },
        { MetaFieldType.OptionalPosition, (_, writer, field) => 
            writer.WritePrefixedOptional(field.GetValue<Optional<Vec3<int>>>(), (pos, w) => w.WritePosition(pos)) },
        { MetaFieldType.Direction, (_, writer, field) => writer.WriteVarInt((int)field.GetValue<Cardinal>()) },
        { MetaFieldType.OptionalLivingEntityReference, (_, writer, field) => 
            writer.WritePrefixedOptional(field.GetValue<Optional<Guid>>(), (uuid, w) => w.WriteUuid(uuid)) },
        { MetaFieldType.BlockState, (_, writer, field) => writer.WriteVarInt((int)field.GetValue<IBlock>().StateId) },
        { MetaFieldType.OptionalBlockState, (_, writer, field) => 
            writer.WritePrefixedOptional(field.GetValue<Optional<IBlock>>(), (block, w) => w.WriteVarInt((int)block.StateId)) },
        { MetaFieldType.Nbt, (_, writer, field) => writer.WriteNbt(field.GetValue<INbtTag>()) },
        { MetaFieldType.Particle, (reg, writer, field) => 
            writer.WriteVarInt(field.GetValue<IParticle>().ProtocolId).Write(wr => field.GetValue<IParticle>().WriteData(wr, reg)) },
        { MetaFieldType.Particles, (reg, writer, field) => 
            writer.WritePrefixedArray(field.GetValue<IParticle[]>(), (particle, w) => 
                w.WriteVarInt(particle.ProtocolId).Write(wr => particle.WriteData(wr, reg))) },
        { MetaFieldType.VillagerData, (_, writer, field) => {
            (int type, int profession, int level) = field.GetValue<(int, int, int)>();
            writer.WriteVarInt(type).WriteVarInt(profession).WriteVarInt(level);
        }},
        { MetaFieldType.OptionalVarInt, (_, writer, field) => 
            writer.WritePrefixedOptional(field.GetValue<Optional<int>>(), (i, w) => w.WriteVarInt(i)) },
        { MetaFieldType.Pose, (_, writer, field) => writer.WriteVarInt((int)field.GetValue<EntityPose>()) },
        { MetaFieldType.CatVariant, (_, writer, field) => writer.WriteVarInt(field.GetValue<int>()) },
        { MetaFieldType.CowVariant, (_, writer, field) => writer.WriteVarInt(field.GetValue<int>()) },
        { MetaFieldType.WolfVariant, (_, writer, field) => writer.WriteVarInt(field.GetValue<int>()) },
        { MetaFieldType.WolfSoundVariant, (_, writer, field) => writer.WriteVarInt(field.GetValue<int>()) },
        { MetaFieldType.FrogVariant, (_, writer, field) => writer.WriteVarInt(field.GetValue<int>()) },
        { MetaFieldType.PigVariant, (_, writer, field) => writer.WriteVarInt(field.GetValue<int>()) },
        { MetaFieldType.ChickenVariant, (_, writer, field) => writer.WriteVarInt(field.GetValue<int>()) },
        { MetaFieldType.OptionalGlobalPosition, (_, writer, field) => 
            writer.WritePrefixedOptional(field.GetValue<Optional<(Identifier, Vec3<int>)>>(), 
                (tuple, w) => w.WriteString(tuple.Item1).WritePosition(tuple.Item2)) },
        { MetaFieldType.PaintingVariant, (_, writer, field) => 
            writer.WriteIdOr(field.GetValue<Or<int, PaintingVariant>>(), (v, w) => v.Write(w)) },
        { MetaFieldType.SnifferState, (_, writer, field) => writer.WriteVarInt((int)field.GetValue<SnifferState>()) },
        { MetaFieldType.ArmadilloState, (_, writer, field) => writer.WriteVarInt((int)field.GetValue<ArmadilloState>()) },
        { MetaFieldType.Vector3, (_, writer, field) => writer.WriteVec3(field.GetValue<Vec3<float>>()) },
        { MetaFieldType.Quaternion, (_, writer, field) => writer.WriteQuaternion(field.GetValue<Quaternion>()) }
    };

    public EntityMetaContainer ReadData(MinecraftRegistry reg, DataReader reader) {
        while (true) {
            byte index = reader.Read();
            if (index == 0xFF) {
                break; // End of metadata
            }

            MetaFieldType type = (MetaFieldType)reader.ReadVarInt();  // right now we assume the type from the index
            Fields.Add(index, FieldTypeReaders[type](reg, reader));
        }
        
        return this;
    }
    
    public void Write(MinecraftRegistry reg, DataWriter writer) {
        foreach ((int index, MetaField field) in Fields.OrderBy(kvp => kvp.Key)) {
            writer.Write((byte)index);
            writer.WriteVarInt((int)field.Type);
            FieldTypeWriters[field.Type](reg, writer, field);
        }
        writer.Write(0xFF); // End of metadata
    }
    
    public MetaField<T>? GetField<T>(int index) {
        if (!Fields.TryGetValue(index, out MetaField? field)) return null;
        
        if (field is MetaField<T> typedField) {
            return typedField;
        }
        throw new InvalidCastException($"Field at index {index} is not of type {typeof(T).Name}");
    }
    
    public T? GetValue<T>(int index) {
        MetaField<T>? field = GetField<T>(index);
        return field != null ? field.Value : default;
    }
    
    public EntityMetaContainer WithField<T>(int index, MetaFieldType type, T? value) {
        if (value == null) {
            return this;
        }
        Fields[index] = new MetaField<T>(type, value);
        return this;
    }
}

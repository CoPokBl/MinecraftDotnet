using Minecraft.Data;
using Minecraft.Registry;
using NBT;
using NBT.Tags;

namespace Minecraft.Schemas.Entities.Attributes;

public record AttributeModifier(Identifier Id, double Value, AttributeOperation Operation) : INetworkType<AttributeModifier> {

    /// <remarks>The value is called <c>amount</c> in the data form, unlike over the wire.</remarks>
    public INbtTag ToNbt() {
        return new CompoundTag(
            ("id", new StringTag(Id.ToString())),
            ("amount", new DoubleTag(Value)),
            ("operation", new StringTag(Operation.ToProtocolString())));
    }

    public static AttributeModifier FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new AttributeModifier(
            compound["id"]!.GetString(),
            compound["amount"]!.AsDouble(),
            AttributeOperationExtensions.ParseAttributeOperation(compound["operation"]!.GetString()));
    }

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry _) {
        return writer
            .WriteString(Id)
            .WriteDouble(Value)
            .WriteByte((int)Operation);
    }
        
    public static AttributeModifier ReadData(DataReader reader, MinecraftRegistry _) {
        return new AttributeModifier(
            reader.ReadString(),
            reader.ReadDouble(),
            (AttributeOperation)reader.ReadByte()
        );
    }
}

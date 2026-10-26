using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Schemas.Items;

/// <summary>
/// <c>ResolvableInt</c>: a number written out, or the name of a <c>context_int_provider</c> worked out
/// against a loot context when it is used. Exactly one of the two is set.
/// </summary>
public sealed record ResolvableInt(int? Constant, Identifier? Reference) {
    public static ResolvableInt Of(int value) => new(value, null);
    public static ResolvableInt Of(Identifier key) => new(null, key);

    public INbtTag ToNbt() {
        return Reference is { } key ? new StringTag(key.ToString()) : new IntegerTag(Constant!.Value);
    }

    public static ResolvableInt FromNbt(INbtTag tag) {
        return tag is StringTag name ? Of((Identifier)name.Value) : Of(tag.AsInt());
    }

    /// <summary><c>ByteBufCodecs.either</c>: true and a four byte int, or false and the key.</summary>
    public DataWriter WriteData(DataWriter writer) {
        return Reference is { } key ? writer.WriteBoolean(false).WriteString(key.ToString()) : writer.WriteBoolean(true).WriteInteger(Constant!.Value);
    }

    public static ResolvableInt ReadData(DataReader reader) {
        return reader.ReadBoolean() ? Of(reader.ReadInteger()) : Of((Identifier)reader.ReadString());
    }
}

/// <summary><c>ResolvableFloat</c>, the same over a <c>context_float_provider</c>.</summary>
public sealed record ResolvableFloat(float? Constant, Identifier? Reference) {
    public static ResolvableFloat Of(float value) => new(value, null);
    public static ResolvableFloat Of(Identifier key) => new(null, key);

    public INbtTag ToNbt() {
        return Reference is { } key ? new StringTag(key.ToString()) : new FloatTag(Constant!.Value);
    }

    public static ResolvableFloat FromNbt(INbtTag tag) {
        return tag is StringTag name ? Of((Identifier)name.Value) : Of(tag.AsFloat());
    }

    public DataWriter WriteData(DataWriter writer) {
        return Reference is { } key ? writer.WriteBoolean(false).WriteString(key.ToString()) : writer.WriteBoolean(true).WriteFloat(Constant!.Value);
    }

    public static ResolvableFloat ReadData(DataReader reader) {
        return reader.ReadBoolean() ? Of(reader.ReadFloat()) : Of((Identifier)reader.ReadString());
    }
}

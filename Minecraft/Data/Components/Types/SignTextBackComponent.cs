using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>The text on the back of the sign a sign item places.</summary>
public record SignTextBackComponent() : IDataComponent<SignText> {
    public override Identifier Identifier => "minecraft:sign_text_back";

    public override NbtCodec<SignText>? Codec => Persistent;
    private static readonly NbtCodec<SignText> Persistent = new((val, _) => val.ToNbt(), (tag, _) => SignText.Read(tag));

    public override DataWriter WriteData(SignText val, DataWriter writer, MinecraftRegistry registry) {
        return val.WriteData(writer);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return SignText.ReadData(reader);
    }

    public override bool ValuesEqual(SignText val1, SignText val2) {
        return val1.Equals(val2);
    }
}

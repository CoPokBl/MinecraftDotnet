using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>How much a villager gains from eating the item.</summary>
public record VillagerFoodComponent() : IDataComponent<int> {
    public override Identifier Identifier => "minecraft:villager_food";

    public override NbtCodec<int>? Codec => Persistent;
    private static readonly NbtCodec<int> Persistent = NbtCodecs.Wrapped("minecraft:villager_food", "nutrition", NbtCodecs.Int());

    public override DataWriter WriteData(int val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadVarInt();
    }

    public override bool ValuesEqual(int val1, int val2) {
        return val1 == val2;
    }
}

using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// Extra emeralds a villager charges for a trade. The component is network only, so it never
/// survives a save.
/// </summary>
public record AdditionalTradeCostComponent() : IDataComponent<int> {
    public override Identifier Identifier => "minecraft:additional_trade_cost";

    /// <summary>
    /// None. <b>Vanilla marks this component transient</b>, so it has no persistent form to port:
    /// it is a price already worked into the offer that carries it, and no datapack or saved stack ever carries one.
    /// </summary>
    public override NbtCodec<int>? Codec => null;

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

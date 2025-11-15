using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record TooltipDisplayComponent(int ProtocolId) : IDataComponent<TooltipDisplayComponent.Info> {
    public override Identifier Identifier => "minecraft:tooltip_display";
    
    public override DataWriter WriteData(Info val, DataWriter writer, MinecraftRegistry registry) {
        writer.WriteBoolean(val.HideTooltip);
        writer.WritePrefixedArray(val.Hidden,
            (component, w) => w.WriteVarInt(registry.DataComponents[component.Identifier].ProtocolId));
        return writer;
    }

    public override Info ReadData(DataReader reader, MinecraftRegistry registry) {
        bool hideTooltip = reader.ReadBoolean();
        IDataComponent[] hiddenComponents = reader.ReadPrefixedArray(r => registry.DataComponents[r.ReadVarInt()]);
        return new Info(hideTooltip, hiddenComponents);
    }

    public override bool ValuesEqual(Info val1, Info val2) {
        if (val1.HideTooltip != val2.HideTooltip) return false;
        if (val1.Hidden.Length != val2.Hidden.Length) return false;
        for (int i = 0; i < val1.Hidden.Length; i++) {
            if (val1.Hidden[i].Identifier != val2.Hidden[i].Identifier) return false;
        }
        return true;
    }

    public record Info(bool HideTooltip, params IDataComponent[] Hidden);
}

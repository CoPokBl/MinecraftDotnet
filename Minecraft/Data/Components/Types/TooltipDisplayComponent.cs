using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record TooltipDisplayComponent(int ProtocolId) : IDataComponent<TooltipDisplayComponent.Info> {
    public override Identifier Identifier => "minecraft:tooltip_display";
    
    public override DataWriter WriteData(Info val, DataWriter writer, MinecraftRegistry registry) {
        writer.WriteBoolean(val.HideTooltip);
        writer.WritePrefixedArray(val.Hidden,
            (component, w) => w.WriteVarInt(registry.DataComponents[component.Identifier]));
        return writer;
    }

    public override Info ReadData(DataReader reader, MinecraftRegistry registry) {
        bool hideTooltip = reader.ReadBoolean();
        IDataComponent[] hiddenComponents = reader.ReadPrefixedArray(r => registry.DataComponents[r.ReadVarInt()]);
        return new Info(hideTooltip, hiddenComponents);
    }
    
    public record Info(bool HideTooltip, params IDataComponent[] Hidden);
}

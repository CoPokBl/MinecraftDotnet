using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record TooltipDisplayComponent(TooltipDisplayComponent.Info Value) : IDataComponent<TooltipDisplayComponent.Info> {
    public Identifier Identifier => "minecraft:tooltip_display";
    public static TooltipDisplayComponent Default => new(new Info(false));
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        writer.WriteBoolean(Value.HideTooltip);
        writer.WritePrefixedArray(Value.Hidden,
            (component, w) => w.WriteVarInt(registry.DataComponents[component.Identifier]));
        return writer;
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        bool hideTooltip = reader.ReadBoolean();
        IDataComponent[] hiddenComponents = reader.ReadPrefixedArray(r => registry.DataComponents[r.ReadVarInt()]);
        return new TooltipDisplayComponent(new Info(hideTooltip, hiddenComponents));
    }
    
    public record Info(bool HideTooltip, params IDataComponent[] Hidden);
}

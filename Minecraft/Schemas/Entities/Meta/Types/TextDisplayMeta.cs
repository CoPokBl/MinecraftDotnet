using Minecraft.Text;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record TextDisplayMeta(
    TextComponent? Text = null, 
    int? LineWidth = null, 
    int? BackgroundColor = null,
    sbyte? TextOpacity = null,
    TextDisplayMeta.Flags? TextDisplayFlags = null) : DisplayMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (TextDisplayMeta)base.LoadFields(container) with {
            Text = container.GetValue<TextComponent>(23),
            LineWidth = container.GetValue<int>(24),
            BackgroundColor = container.GetValue<int>(25),
            TextOpacity = container.GetValue<sbyte>(26),
            TextDisplayFlags = container.GetValue<Flags>(27)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(23, MetaFieldType.TextComponent, Text)
            .WithField(24, MetaFieldType.VarInt, LineWidth)
            .WithField(25, MetaFieldType.VarInt, BackgroundColor)
            .WithField(26, MetaFieldType.Byte, TextOpacity)
            .WithField(27, MetaFieldType.Byte, (sbyte?)TextDisplayFlags);
    }
    
    public enum Flags : sbyte {
        None = 0x00,
        HasShadow = 0x01,
        IsSeeThrough = 0x02,
        UseDefaultBackground = 0x04,
        
        // Alignment seems to take 2 bits?
        AlignCenter = 0x00,
        AlignLeft = 0x08,
        AlignRight = 0x16
    }
}

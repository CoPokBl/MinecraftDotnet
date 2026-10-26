using Minecraft.Registry;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace Minecraft.Schemas.Advancements;

/// <summary>How an advancement is drawn in the advancement screen and its toast.</summary>
public class AdvancementDisplay {
    public required TextComponent Title { get; init; }
    public required TextComponent Description { get; init; }

    /// <summary>The item drawn in the advancement's box.</summary>
    public required ItemStack Icon { get; init; }

    public AdvancementFrame Frame { get; init; } = AdvancementFrame.Task;

    /// <summary>Texture tiled behind the tab, only set on root advancements.</summary>
    public Identifier? Background { get; init; }

    /// <summary>Whether completing it pops up a toast.</summary>
    public bool ShowToast { get; init; } = true;

    /// <summary>Whether it stays hidden until completed.</summary>
    public bool Hidden { get; init; }

    /// <summary>
    /// Position in the tab, in advancement box widths from the root. It travels beside the advancement
    /// in <c>update_advancements</c> rather than in the display, which is why it can be set after a read.
    /// </summary>
    public required float X { get; set; }
    public required float Y { get; set; }

    public void Write(DataWriter w, MinecraftRegistry reg) {
        w.WriteNbt(Title)
            .WriteNbt(Description);
        Icon.WriteTemplateData(w, reg);
        w.WriteVarInt((int)Frame);

        int flags = 0;
        if (Background != null) {
            flags |= 0x1;
        }
        if (ShowToast) {
            flags |= 0x2;
        }
        if (Hidden) {
            flags |= 0x4;
        }
        w.WriteInteger(flags);

        if (Background != null) {
            w.Write(Background.Value);
        }
    }

    public static AdvancementDisplay Read(DataReader r, MinecraftRegistry reg) {
        TextComponent title = r.ReadText();
        TextComponent description = r.ReadText();
        ItemStack icon = ItemStack.ReadTemplateData(r, reg);
        AdvancementFrame frame = (AdvancementFrame)r.ReadVarInt();
        int flags = r.ReadInteger();

        return new AdvancementDisplay {
            Title = title,
            Description = description,
            Icon = icon,
            Frame = frame,
            Background = (flags & 0x1) != 0 ? (Identifier?)(Identifier)r.ReadString() : null,
            ShowToast = (flags & 0x2) != 0,
            Hidden = (flags & 0x4) != 0,
            X = 0,
            Y = 0
        };
    }
}

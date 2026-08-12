using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Dialogs;

/// <summary>
/// A screen the server can put in front of a player, built out of text, inputs and buttons. The
/// client resolves the ones in the pause menu by name, so the registry has to carry real entries
/// rather than placeholders.
/// </summary>
public interface IDialog : IProtocolType {
    /// <summary>Which kind of dialog this is.</summary>
    public Identifier Type { get; }

    public CommonDialogData Common { get; }

    /// <summary>The fields this kind adds on top of <see cref="Common"/>.</summary>
    protected (string, INbtTag)[] ExtraFields { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [("type", new StringTag(Type.ToString()))];
        children.AddRange(Common.ToFields());
        children.AddRange(ExtraFields);
        return new CompoundTag(children.ToArray());
    }

    public static IDialog FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        Identifier type = tag["type"]!.GetString();
        CommonDialogData common = CommonDialogData.FromNbt(tag);

        DialogActionButton? ExitAction() => tag.Contains("exit_action")
            ? DialogActionButton.FromNbt(tag["exit_action"]!)
            : null;

        int Columns() => tag.Contains("columns") ? tag["columns"]!.GetInteger() : 2;
        int ButtonWidth() => tag.Contains("button_width") ? tag["button_width"]!.GetInteger() : 150;

        return type.ToString() switch {
            "minecraft:notice" => new NoticeDialog(ident, common,
                tag.Contains("action")
                    ? DialogActionButton.FromNbt(tag["action"]!)
                    : NoticeDialog.DefaultAction),

            "minecraft:confirmation" => new ConfirmationDialog(ident, common,
                DialogActionButton.FromNbt(tag["yes"]!),
                DialogActionButton.FromNbt(tag["no"]!)),

            "minecraft:multi_action" => new MultiActionDialog(ident, common,
                ((ListTag)tag["actions"]!).Tags.ToArray().Select(DialogActionButton.FromNbt).ToArray(),
                ExitAction(),
                Columns()),

            "minecraft:dialog_list" => new DialogListDialog(ident, common,
                HolderSet.FromNbt(tag["dialogs"]!),
                ExitAction(),
                Columns(),
                ButtonWidth()),

            "minecraft:server_links" => new ServerLinksDialog(ident, common,
                ExitAction(),
                Columns(),
                ButtonWidth()),

            _ => throw new ArgumentException($"Unknown dialog type {type}", nameof(tag))
        };
    }
}

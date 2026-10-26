using Minecraft.Packets.Config.ClientBound;
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

        int Columns() => tag.Contains("columns") ? tag["columns"]!.AsInt() : 2;
        int ButtonWidth() => tag.Contains("button_width") ? tag["button_width"]!.AsInt() : 150;

        return type.ToString() switch {
            "minecraft:notice" => new NoticeDialog(ident, common,
                tag.Contains("action")
                    ? DialogActionButton.FromNbt(tag["action"]!)
                    : NoticeDialog.DefaultAction),

            "minecraft:confirmation" => new ConfirmationDialog(ident, common,
                DialogActionButton.FromNbt(tag["yes"]!),
                DialogActionButton.FromNbt(tag["no"]!)),

            "minecraft:multi_action" => new MultiActionDialog(ident, common,
                tag["actions"]!.AsList().Select(DialogActionButton.FromNbt).ToArray(),
                ExitAction(),
                Columns()),

            "minecraft:dialog_list" => new DialogListDialog(ident, common,
                DialogsFromNbt(tag["dialogs"]!, reg),
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

    /// <summary>
    /// <c>Dialog.LIST_CODEC</c>, whose elements are a <c>RegistryFileCodec</c>: names, a tag, or
    /// dialogs defined in place, each alone or in a list.
    /// </summary>
    private static Or<HolderSet, IDialog[]> DialogsFromNbt(INbtTag tag, MinecraftRegistry reg) {
        INbtTag[] elements = tag.AsCompactList();
        if (elements.Length == 0 || elements[0] is not CompoundTag) {
            return HolderSet.FromNbt(tag);
        }

        return elements
            .Select(e => FromNbt(ClientBoundShowDialogPacket.InlineIdentifier, (CompoundTag)e, reg))
            .ToArray();
    }
}

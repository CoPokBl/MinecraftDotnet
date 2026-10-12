using Minecraft.Schemas;
using Minecraft.Schemas.Tags;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Dialogs;

/// <summary>A message with a single button under it.</summary>
public record NoticeDialog(
    Identifier Identifier,
    CommonDialogData Common,
    DialogActionButton Action) : IDialog {

    /// <summary>The plain OK button used when no action is given.</summary>
    public static readonly DialogActionButton DefaultAction =
        new(TextComponent.Translatable("gui.ok"));

    public Identifier Type => "minecraft:notice";

    (string, INbtTag)[] IDialog.ExtraFields => Action == DefaultAction
        ? []
        : [("action", Action.ToNbt())];
}

/// <summary>A question with a yes and a no button.</summary>
public record ConfirmationDialog(
    Identifier Identifier,
    CommonDialogData Common,
    DialogActionButton Yes,
    DialogActionButton No) : IDialog {

    public Identifier Type => "minecraft:confirmation";

    (string, INbtTag)[] IDialog.ExtraFields => [
        ("yes", Yes.ToNbt()),
        ("no", No.ToNbt())
    ];
}

/// <summary>A grid of buttons, each doing something different.</summary>
/// <param name="ExitAction">An extra button below the grid, usually a way back.</param>
public record MultiActionDialog(
    Identifier Identifier,
    CommonDialogData Common,
    DialogActionButton[] Actions,
    DialogActionButton? ExitAction = null,
    int Columns = 2) : IDialog {

    public Identifier Type => "minecraft:multi_action";

    (string, INbtTag)[] IDialog.ExtraFields {
        get {
            List<(string, INbtTag)> fields = [
                ("actions", new ListTag<CompoundTag>(Actions.Select(a => (CompoundTag)a.ToNbt()).ToArray()))
            ];

            if (ExitAction != null) {
                fields.Add(("exit_action", ExitAction.ToNbt()));
            }

            if (Columns != 2) {
                fields.Add(("columns", new IntegerTag(Columns)));
            }

            return fields.ToArray();
        }
    }

    public virtual bool Equals(MultiActionDialog? other) {
        return other != null && Identifier == other.Identifier && Common == other.Common
               && ExitAction == other.ExitAction && Columns == other.Columns
               && Actions.SequenceEqual(other.Actions);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Identifier, Common, ExitAction, Columns, Actions.Length);
    }
}

/// <summary>A menu of other dialogs.</summary>
/// <param name="Dialogs">Registry entries by name or tag, or dialogs written out in place.</param>
public record DialogListDialog(
    Identifier Identifier,
    CommonDialogData Common,
    Or<HolderSet, IDialog[]> Dialogs,
    DialogActionButton? ExitAction = null,
    int Columns = 2,
    int ButtonWidth = 150) : IDialog {

    public Identifier Type => "minecraft:dialog_list";

    (string, INbtTag)[] IDialog.ExtraFields {
        get {
            INbtTag dialogs = Dialogs.IsValue1
                ? Dialogs.Value1!.ToNbt()
                : Dialogs.Value2!.Length == 1
                    ? Dialogs.Value2[0].ToNbt()
                    : new ListTag(Dialogs.Value2.Select(d => d.ToNbt()).ToArray());
            List<(string, INbtTag)> fields = [("dialogs", dialogs)];

            if (ExitAction != null) {
                fields.Add(("exit_action", ExitAction.ToNbt()));
            }

            if (Columns != 2) {
                fields.Add(("columns", new IntegerTag(Columns)));
            }

            if (ButtonWidth != 150) {
                fields.Add(("button_width", new IntegerTag(ButtonWidth)));
            }

            return fields.ToArray();
        }
    }
}

/// <summary>The links the server advertised, one button each.</summary>
public record ServerLinksDialog(
    Identifier Identifier,
    CommonDialogData Common,
    DialogActionButton? ExitAction = null,
    int Columns = 2,
    int ButtonWidth = 150) : IDialog {

    public Identifier Type => "minecraft:server_links";

    (string, INbtTag)[] IDialog.ExtraFields {
        get {
            List<(string, INbtTag)> fields = [];

            if (ExitAction != null) {
                fields.Add(("exit_action", ExitAction.ToNbt()));
            }

            if (Columns != 2) {
                fields.Add(("columns", new IntegerTag(Columns)));
            }

            if (ButtonWidth != 150) {
                fields.Add(("button_width", new IntegerTag(ButtonWidth)));
            }

            return fields.ToArray();
        }
    }
}

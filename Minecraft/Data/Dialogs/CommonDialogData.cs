using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Dialogs;

/// <summary>The parts every dialog has, whatever kind it is.</summary>
/// <param name="ExternalTitle">
/// Shown on the button that opens this dialog from a list; the title is used when unset.
/// </param>
/// <param name="CanCloseWithEscape">Whether escape dismisses the dialog.</param>
/// <param name="Pause">Whether a singleplayer world is paused while it's open.</param>
public record CommonDialogData(
    TextComponent Title,
    TextComponent? ExternalTitle = null,
    bool CanCloseWithEscape = true,
    bool Pause = true,
    DialogAfterAction AfterAction = DialogAfterAction.Close,
    DialogBody[]? Body = null,
    DialogInput[]? Inputs = null) {

    public (string, INbtTag)[] ToFields() {
        List<(string, INbtTag)> fields = [("title", Title.SerialiseToTag())];

        if (ExternalTitle != null) {
            fields.Add(("external_title", ExternalTitle.SerialiseToTag()));
        }

        if (!CanCloseWithEscape) {
            fields.Add(("can_close_with_escape", new BooleanTag(false)));
        }

        if (!Pause) {
            fields.Add(("pause", new BooleanTag(false)));
        }

        if (AfterAction != DialogAfterAction.Close) {
            fields.Add(("after_action", new StringTag(AfterAction.ToProtocolString())));
        }

        if (Body is { Length: > 0 }) {
            fields.Add(("body", DialogBody.ListToNbt(Body)));
        }

        if (Inputs is { Length: > 0 }) {
            fields.Add(("inputs", new ListTag<CompoundTag>(Inputs
                .Select(i => (CompoundTag)i.ToNbt())
                .ToArray())));
        }

        return fields.ToArray();
    }

    public static CommonDialogData FromNbt(CompoundTag tag) {
        return new CommonDialogData(
            TextComponent.FromTag(tag["title"]!),
            tag.Contains("external_title") ? TextComponent.FromTag(tag["external_title"]!) : null,
            !tag.Contains("can_close_with_escape") || tag["can_close_with_escape"]!.AsBool(),
            !tag.Contains("pause") || tag["pause"]!.AsBool(),
            tag.Contains("after_action")
                ? DialogAfterActionExtensions.ParseDialogAfterAction(tag["after_action"]!.GetString())
                : DialogAfterAction.Close,
            tag.Contains("body") ? DialogBody.ListFromNbt(tag["body"]!) : [],
            tag.Contains("inputs")
                ? tag["inputs"]!.AsList().Select(DialogInput.FromNbt).ToArray()
                : []);
    }

    public virtual bool Equals(CommonDialogData? other) {
        return other != null && Title.Equals(other.Title)
               && Equals(ExternalTitle, other.ExternalTitle)
               && CanCloseWithEscape == other.CanCloseWithEscape && Pause == other.Pause
               && AfterAction == other.AfterAction
               && (Body ?? []).SequenceEqual(other.Body ?? [])
               && (Inputs ?? []).SequenceEqual(other.Inputs ?? []);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Title, CanCloseWithEscape, Pause, AfterAction,
            Body?.Length ?? 0, Inputs?.Length ?? 0);
    }
}

/// <summary>A button on a dialog, and what pressing it does.</summary>
/// <param name="Action">Unset means the button just closes the dialog.</param>
public record DialogActionButton(
    TextComponent Label,
    TextComponent? Tooltip = null,
    int Width = 150,
    DialogAction? Action = null) {

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [("label", Label.SerialiseToTag())];

        if (Tooltip != null) {
            children.Add(("tooltip", Tooltip.SerialiseToTag()));
        }

        if (Width != 150) {
            children.Add(("width", new IntegerTag(Width)));
        }

        if (Action != null) {
            children.Add(("action", Action.ToNbt()));
        }

        return new CompoundTag(children.ToArray());
    }

    public static DialogActionButton FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new DialogActionButton(
            TextComponent.FromTag(compound["label"]!),
            compound.Contains("tooltip") ? TextComponent.FromTag(compound["tooltip"]!) : null,
            compound.Contains("width") ? compound["width"]!.AsInt() : 150,
            compound.Contains("action") ? DialogAction.FromNbt(compound["action"]!) : null);
    }
}

using Minecraft.Data.Dialogs;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Schemas;
using Minecraft.Text;

namespace ManagedServer.Dialogs;

/// <summary>
/// A dialog with a callback behind each of its buttons. Build one with a <see cref="DialogBuilder"/>
/// or one of the factories here, then show it with
/// <see cref="PlayerDialogExtensions.ShowDialog(ManagedServer.Entities.Types.Player,ManagedDialog)"/>.
/// The callbacks only run if
/// <see cref="ManagedServer.Features.Basic.DialogFeature"/> is registered, which the basics bundle
/// does.
/// </summary>
public class ManagedDialog {
    /// <summary>The dialog as it goes on the wire.</summary>
    public IDialog Dialog { get; }

    /// <summary>
    /// Namespaced id the buttons' custom actions start with; each button appends its own index to it.
    /// </summary>
    private readonly string _actionPrefix;

    private readonly Action<DialogResponse>?[] _handlers;

    internal ManagedDialog(IDialog dialog, string actionPrefix, Action<DialogResponse>?[] handlers) {
        Dialog = dialog;
        _actionPrefix = actionPrefix;
        _handlers = handlers;
    }

    /// <summary>The inputs the player fills in, in the order they're shown.</summary>
    public DialogInput[] Inputs => Dialog.Common.Inputs ?? [];

    /// <summary>
    /// Which of this dialog's buttons the given custom action id belongs to, or -1 when the id
    /// isn't one of ours. The exit button comes after the rest.
    /// </summary>
    public int ButtonIndexFor(Identifier actionId) {
        string id = actionId.ToString();
        if (!id.StartsWith(_actionPrefix + '/')) {
            return -1;
        }

        return int.TryParse(id[(_actionPrefix.Length + 1)..], out int index) && index < _handlers.Length
            ? index
            : -1;
    }

    internal void RunHandler(int buttonIndex, DialogResponse response) {
        _handlers[buttonIndex]?.Invoke(response);
    }

    /// <summary>A message with a single button that closes it.</summary>
    public static ManagedDialog Notice(TextComponent title, TextComponent message,
        TextComponent? buttonLabel = null, Action<DialogResponse>? onClick = null) {

        return new DialogBuilder(title)
            .Body(message)
            .Button(buttonLabel ?? TextComponent.Translatable("gui.ok"), onClick)
            .Build();
    }

    /// <summary>A question with a yes and a no button.</summary>
    public static ManagedDialog Confirmation(TextComponent title, TextComponent message,
        Action<DialogResponse>? onYes, Action<DialogResponse>? onNo = null,
        TextComponent? yesLabel = null, TextComponent? noLabel = null) {

        string prefix = NewActionPrefix();
        ConfirmationDialog dialog = new(
            ClientBoundShowDialogPacket.InlineIdentifier,
            new CommonDialogData(title, Body: [new DialogBody.PlainMessage(message)]),
            new DialogActionButton(yesLabel ?? TextComponent.Translatable("gui.yes"),
                Action: new DialogAction.Custom(ButtonAction(prefix, 0), null)),
            new DialogActionButton(noLabel ?? TextComponent.Translatable("gui.no"),
                Action: new DialogAction.Custom(ButtonAction(prefix, 1), null)));

        return new ManagedDialog(dialog, prefix, [onYes, onNo]);
    }

    /// <summary>
    /// A fresh prefix for one dialog's buttons. It only has to be unique per dialog rather than per
    /// showing, because which dialog a player has open is tracked per player.
    /// </summary>
    internal static string NewActionPrefix() {
        return "managedserver:dialog/" + Guid.NewGuid().ToString("N");
    }

    internal static Identifier ButtonAction(string prefix, int index) {
        return $"{prefix}/{index}";
    }
}

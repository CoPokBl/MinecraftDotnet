using ManagedServer.Entities.Types;
using Minecraft;
using Minecraft.Data.Dialogs;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Schemas;

namespace ManagedServer.Dialogs;

public static class PlayerDialogExtensions {
    /// <summary>
    /// The dialog whose buttons <see cref="ManagedServer.Features.Basic.DialogFeature"/> is
    /// currently routing for this player.
    /// </summary>
    internal static readonly Tag<ManagedDialog> OpenDialogTag = new("managedserver:dialogs:open");

    /// <summary>
    /// Opens a dialog and runs the callbacks its buttons were built with when the player presses
    /// them. Requires <see cref="ManagedServer.Features.Basic.DialogFeature"/>, which is in the
    /// basics bundle.
    /// </summary>
    public static void ShowDialog(this Player player, ManagedDialog dialog) {
        player.SetTag(OpenDialogTag, dialog);
        player.SendPacket(ClientBoundShowDialogPacket.Inline(dialog.Dialog));
    }

    /// <summary>Opens a dialog built by hand, with nothing routed back to the server.</summary>
    public static void ShowDialog(this Player player, IDialog dialog) {
        player.RemoveTag(OpenDialogTag);
        player.SendPacket(ClientBoundShowDialogPacket.Inline(dialog));
    }

    /// <summary>Opens a dialog from the server's dialog registry by name.</summary>
    public static void ShowDialog(this Player player, Identifier dialog) {
        player.RemoveTag(OpenDialogTag);
        player.SendPacket(ClientBoundShowDialogPacket.Reference(dialog));
    }

    /// <summary>
    /// Closes whatever dialog the player has open. There's no packet for the player closing one
    /// themselves, so a dialog they dismissed with escape stays "open" as far as the server knows
    /// until it's replaced or cleared.
    /// </summary>
    public static void CloseDialog(this Player player) {
        player.RemoveTag(OpenDialogTag);
        player.SendPacket(new ClientBoundClearDialogPacket());
    }

    /// <summary>The dialog last shown to this player, if it was one with callbacks attached.</summary>
    public static ManagedDialog? GetOpenDialog(this Player player) {
        return player.GetTagOrNull(OpenDialogTag);
    }
}

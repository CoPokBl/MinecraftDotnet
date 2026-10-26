using ManagedServer.Dialogs;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using Minecraft.Data.Dialogs;
using Minecraft.Packets.Config.ServerBound;
using NBT.Tags;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Routes custom dialog actions back to the callbacks the dialog was built with, and fires
/// <see cref="PlayerCustomClickActionEvent"/> for every one of them.
/// See <see cref="PlayerDialogExtensions.ShowDialog(Player,ManagedDialog)"/>.
/// </summary>
[CallsEvent(typeof(PlayerCustomClickActionEvent))]
public class DialogFeature : ScopedFeature {

    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundCustomClickActionPacket packet) {
                return;
            }

            ManagedDialog? dialog = e.Player.GetOpenDialog();
            int buttonIndex = dialog?.ButtonIndexFor(packet.Id) ?? -1;

            DialogResponse response = new() {
                Player = e.Player,
                ActionId = packet.Id,
                Dialog = buttonIndex == -1 ? null : dialog,
                ButtonIndex = buttonIndex,
                Payload = packet.Payload as CompoundTag
            };

            PlayerCustomClickActionEvent clickEvent = new() {
                Player = e.Player,
                World = e.World,
                Id = packet.Id,
                Response = response
            };
            CallEvent(clickEvent);

            if (clickEvent.Cancelled || buttonIndex == -1) {
                return;
            }

            // Dropped before the handler runs, so a handler that opens another dialog isn't undone
            if (dialog!.Dialog.Common.AfterAction == DialogAfterAction.Close) {
                e.Player.RemoveTag(PlayerDialogExtensions.OpenDialogTag);
            }

            dialog.RunHandler(buttonIndex, response);
        });
    }
}

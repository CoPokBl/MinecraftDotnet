using Minecraft.Data.Dialogs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT.Tags;

namespace Minecraft.Packets.Config.ClientBound;

/// <summary>
/// Opens a dialog on the client. Sent in both the configuration and play states.
/// </summary>
public class ClientBoundShowDialogPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:show_dialog";

    /// <summary>
    /// Either the key of a dialog in the dialog registry, or a dialog sent inline with the packet.
    /// </summary>
    public required Or<Identifier, IDialog> Dialog { get; init; }

    public static ClientBoundShowDialogPacket Reference(Identifier dialog) {
        return new ClientBoundShowDialogPacket { Dialog = Or<Identifier, IDialog>.FromValue1(dialog) };
    }

    public static ClientBoundShowDialogPacket Inline(IDialog dialog) {
        return new ClientBoundShowDialogPacket { Dialog = Or<Identifier, IDialog>.FromValue2(dialog) };
    }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        Or<int, IDialog> idOr = Dialog.IsValue1
            ? Or<int, IDialog>.FromValue1(reg.Dialogs.GetProtocolId(Dialog.Value1!))
            : Or<int, IDialog>.FromValue2(Dialog.Value2!);
        return w.WriteIdOr(idOr, (dialog, writer) => writer.WriteNbt(dialog.ToNbt()));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundShowDialogPacket {
        Dialog = r.ReadIdOr(
            id => reg.Dialogs[id].Identifier,
            reader => IDialog.FromNbt(InlineIdentifier, (CompoundTag)reader.ReadNbt(), reg))
    };

    /// <summary>
    /// Inline dialogs have no registry key, but <see cref="IDialog"/> implementations all carry one,
    /// so deserialised inline dialogs get this placeholder.
    /// </summary>
    public static readonly Identifier InlineIdentifier = "minecraft:inline_dialog";
}

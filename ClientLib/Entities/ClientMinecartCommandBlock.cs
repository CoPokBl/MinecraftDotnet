using ClientLib.World.BlockEntities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Text;

namespace ClientLib.Entities;

/// <summary><c>MinecartCommandBlock</c>'s client half: the command and last output its synced data carries.</summary>
public sealed class ClientMinecartCommandBlock : ClientEntity {
    public BaseCommandBlock CommandBlock { get; } = new();

    /// <summary>What <c>MinecartCommandBlockEditScreen.populateAndSendPacket</c> sends.</summary>
    public ServerBoundProgramCommandBlockMinecartPacket SetCommandPacket(string command) =>
        new() { EntityId = Id, Command = command, TrackOutput = CommandBlock.TrackOutput };

    /// <summary><c>MinecartCommandBlock.onSyncedDataUpdated</c>.</summary>
    public override void OnSyncedDataUpdated(int index) {
        base.OnSyncedDataUpdated(index);
        if (index == EntityDataFields.MinecartCommandBlock.IdLastOutput.Index) {
            CommandBlock.SetLastOutput(Get(EntityDataFields.MinecartCommandBlock.IdLastOutput) ?? TextComponent.Empty());
        }
        else if (index == EntityDataFields.MinecartCommandBlock.IdCommandName.Index) {
            CommandBlock.SetCommand(Get(EntityDataFields.MinecartCommandBlock.IdCommandName) ?? "");
        }
    }
}

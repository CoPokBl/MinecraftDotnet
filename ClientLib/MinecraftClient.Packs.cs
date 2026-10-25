using ClientLib.Multiplayer;
using ClientLib.Packs;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Text;

namespace ClientLib;

/// <summary>A pack the server pushed while the player is being asked about its packs, <c>PackConfirmScreen.PendingRequest</c>.</summary>
public sealed record PendingPackRequest(Guid Id, Uri Url, string Hash);

/// <summary>
/// What the pack prompt shows for the newest push: <c>addOrUpdatePackPrompt</c> builds a new screen from it,
/// with the requests already waiting on an open prompt plus this one.
/// </summary>
public sealed record PackPromptRequest(PendingPackRequest Request, bool Required, TextComponent? Prompt);

public sealed partial class MinecraftClient {
    /// <summary>
    /// The server's resource packs. Vanilla's <c>Minecraft.downloadedPackSource</c> outlives a connection, so a
    /// host making a client per connection hands each the same one before connecting.
    /// </summary>
    public DownloadedPackSource ServerPacks { get; set; }

    /// <summary>
    /// The server's packs need asking about: the host shows <c>PackConfirmScreen</c> and answers with
    /// <see cref="AnswerPackPrompt"/>. With nobody listening, the answer is no.
    /// </summary>
    public event Action<PackPromptRequest>? ResourcePackPrompt;

    /// <summary><c>ServerData.setResourcePackStatus</c> followed by <c>ServerList.saveSingleServer</c>.</summary>
    public event Action<ServerPackStatus>? ServerPackStatusChanged;

    /// <summary><c>ClientCommonPacketListenerImpl.handleResourcePackPush</c>.</summary>
    private void HandleResourcePackPush(ClientBoundAddResourcePackPacket packet) {
        if (ParseResourcePackUrl(packet.Url) is not { } url) {
            Send(new ServerBoundResourcePackResponsePacket { PackId = packet.Uuid, Result = ServerBoundResourcePackResponsePacket.PackResponse.InvalidUrl });
            return;
        }
        ServerPackStatus status = Options.ServerPackStatus;
        if (status != ServerPackStatus.Prompt && (!packet.Forced || status != ServerPackStatus.Disabled)) {
            ServerPacks.PushPack(packet.Uuid, url, packet.Hash);
            return;
        }
        PackPromptRequest request = new(new PendingPackRequest(packet.Uuid, url, packet.Hash), packet.Forced, packet.Prompt);
        if (ResourcePackPrompt is { } prompt) {
            prompt(request);
        }
        else {
            AnswerPackPrompt([request.Request], packet.Forced, false);
        }
    }

    /// <summary><c>handleResourcePackPop</c>: one pack, or every pack when no id is given.</summary>
    private void HandleResourcePackPop(ClientBoundRemoveResourcePackPacket packet) {
        if (packet.Uuid is { } id) {
            ServerPacks.PopPack(id);
        }
        else {
            ServerPacks.PopAll();
        }
    }

    /// <summary><c>parseResourcePackUrl</c>: only http and https, as <c>java.net.URL</c> parses them.</summary>
    internal static Uri? ParseResourcePackUrl(string url) =>
        Uri.TryCreate(url, UriKind.Absolute, out Uri? parsed) && parsed.Scheme is "http" or "https" ? parsed : null;

    /// <summary>
    /// <c>PackConfirmScreen</c>'s answer: yes allows every pack of the server's for the rest of the
    /// connection; no to a required pack disconnects.
    /// </summary>
    public void AnswerPackPrompt(IReadOnlyList<PendingPackRequest> requests, bool required, bool accepted) {
        if (accepted) {
            SetServerPackStatus(ServerPackStatus.Enabled);
            ServerPacks.AllowServerPacks();
        }
        else {
            ServerPacks.RejectServerPacks();
            if (required) {
                DisconnectReasonText = TextComponent.Translatable("multiplayer.requiredTexturePrompt.disconnect");
                Disconnect(TextFlattener.Plain(DisconnectReasonText));
            }
            else {
                SetServerPackStatus(ServerPackStatus.Disabled);
            }
        }
        foreach (PendingPackRequest request in requests) {
            ServerPacks.PushPack(request.Id, request.Url, request.Hash);
        }
    }

    private void SetServerPackStatus(ServerPackStatus status) {
        Options.ServerPackStatus = status;
        ServerPackStatusChanged?.Invoke(status);
    }

    /// <summary>
    /// <c>Minecraft.clearDownloadedResourcePacks</c> on a disconnect: always from configuration, and from play
    /// unless the server is transferring the player, whose packs then carry over.
    /// </summary>
    private void ClearDownloadedResourcePacks(ClientPhase phase) {
        if (phase == ClientPhase.Play && PendingTransfer != null) {
            return;
        }
        ServerPacks.CleanupAfterDisconnect();
        ServerPacks.RunAllTasks();
    }
}

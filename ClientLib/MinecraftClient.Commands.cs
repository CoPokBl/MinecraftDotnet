using ClientLib.Brigadier;
using ClientLib.Commands;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using EntityEvent = Minecraft.Packets.Play.ClientBound.ClientBoundEntityEventPacket.EntityEventType;
using OpLevel = ClientLib.Commands.PermissionLevel;

namespace ClientLib;

public sealed partial class MinecraftClient {
    private ClientSuggestionProvider? _suggestionsProvider;

    /// <summary><c>ClientPacketListener.commands</c>: empty until the server sends a tree.</summary>
    public CommandDispatcher<ClientSuggestionProvider> Commands { get; internal set; } = new();

    /// <summary><c>LocalPlayer.permissions</c> as entity events 24 to 28 set it; null is vanilla's <c>NO_PERMISSIONS</c>.</summary>
    public OpLevel? PermissionLevel { get; private set; }

    /// <summary><c>Player.canUseGameMasterBlocks</c>: creative, with the game master level.</summary>
    public bool CanUseGameMasterBlocks => Player is { InstaBuild: true } && PermissionLevel >= OpLevel.Gamemasters;

    /// <summary>The source the chat screen parses as: the player's permissions, plus restricted nodes.</summary>
    public ClientSuggestionProvider SuggestionsProvider => _suggestionsProvider ??= new ClientSuggestionProvider(this, new PlayerPermissions(() => PermissionLevel));

    private void HandleCommandPacket(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundCommandsPacket commands:
                Commands = new CommandDispatcher<ClientSuggestionProvider>(
                    ClientCommandTree.GetRoot(commands, new CommandBuildContext(Registry, Tags, EnabledFeatures)));
                break;
            case ClientBoundCommandSuggestionsResponsePacket response:
                SuggestionsProvider.CompleteCustomSuggestions(response.TransactionId, ToSuggestions(response));
                break;
            case ClientBoundChatSuggestionsPacket completions:
                SuggestionsProvider.ModifyCustomCompletions(completions.Action, completions.Entries);
                break;
            case ClientBoundEntityEventPacket entityEvent when Player != null && entityEvent.EntityId == Player.Id:
                if (entityEvent.Status == EntityEvent.PlayerFinishedUsing) {
                    Player.CompleteUsingItem();
                }
                PermissionLevel = entityEvent.Status switch {
                    EntityEvent.PlayerPermissionLevel0 => null,
                    EntityEvent.PlayerPermissionLevel1 => OpLevel.Moderators,
                    EntityEvent.PlayerPermissionLevel2 => OpLevel.Gamemasters,
                    EntityEvent.PlayerPermissionLevel3 => OpLevel.Admins,
                    EntityEvent.PlayerPermissionLevel4 => OpLevel.Owners,
                    _ => PermissionLevel
                };
                break;
        }
    }

    /// <summary><c>ClientboundCommandSuggestionsPacket.toSuggestions</c>.</summary>
    private static Suggestions ToSuggestions(ClientBoundCommandSuggestionsResponsePacket packet) {
        StringRange range = StringRange.Between(packet.Start, packet.Start + packet.Length);
        return new Suggestions(range, packet.Suggestions.Select(entry => new Suggestion(range, entry.Text, entry.Tooltip)).ToList());
    }

    /// <summary>A new connection is a new <c>ClientPacketListener</c>, with an empty tree and no permissions.</summary>
    private void ResetCommands() {
        Commands = new CommandDispatcher<ClientSuggestionProvider>();
        PermissionLevel = null;
        _suggestionsProvider = null;
    }
}

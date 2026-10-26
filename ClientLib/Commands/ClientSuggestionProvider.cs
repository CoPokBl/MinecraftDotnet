using ClientLib.Brigadier;
using ClientLib.Interaction;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ClientLib.Commands;

/// <summary>Vanilla's <c>ClientSuggestionProvider</c>.</summary>
public sealed class ClientSuggestionProvider(MinecraftClient client, IPermissionSet permissions) : ISharedSuggestionProvider {
    private int _pendingSuggestionsId = -1;
    private TaskCompletionSource<Suggestions>? _pendingSuggestionsFuture;
    private readonly HashSet<string> _customCompletionSuggestions = [];

    public IPermissionSet Permissions { get; } = permissions;

    /// <summary><c>getOnlinePlayers</c> is every player info entry, listed or not.</summary>
    public IReadOnlyCollection<string> OnlinePlayerNames => client.PlayerList.Values.Select(info => info.Name).ToList();

    public IReadOnlyCollection<string> CustomTabSuggestions {
        get {
            if (_customCompletionSuggestions.Count == 0) {
                return OnlinePlayerNames;
            }
            HashSet<string> result = [..OnlinePlayerNames];
            result.UnionWith(_customCompletionSuggestions);
            return result;
        }
    }

    public IReadOnlyCollection<string> SelectedEntities =>
        client.Interactions.Target is EntityHitResult entity ? [entity.Entity.Uuid.ToString("D")] : [];

    public IReadOnlyCollection<string> AllTeams => client.Scoreboard.Teams.Keys.ToList();

    /// <summary>Vanilla lists the sound manager's events, which a pack's sounds.json adds to; a pack only sound is not suggested here.</summary>
    public IEnumerable<Identifier> AvailableSounds => client.Registry.SoundTypes.All.Select(s => s.Identifier);

    /// <summary>Vanilla lists its shader manager's loaded chains; here whatever the renderer says it can run.</summary>
    public IEnumerable<Identifier> AvailablePostEffects => client.AvailablePostEffects;

    public Task<Suggestions> SuggestRegistryElements<TSource>(Identifier key, SharedSuggestionProvider.ElementSuggestionType elements,
        SuggestionsBuilder builder, CommandContext<TSource> context) {
        IRegistryLookup? registry = BuildContext().Lookup(key);
        if (registry == null) {
            return CustomSuggestion(context);
        }
        ((ISharedSuggestionProvider)this).SuggestRegistryElements(registry, elements, builder);
        return builder.BuildFuture();
    }

    public IRegistryLookup? Lookup(Identifier registryKey) => BuildContext().Lookup(registryKey);

    public CommandBuildContext BuildContext() => new(client.Registry, client.Tags, client.EnabledFeatures);

    /// <summary>An older request's task is cancelled, as vanilla cancels its future.</summary>
    public Task<Suggestions> CustomSuggestion<TSource>(CommandContext<TSource> context) {
        _pendingSuggestionsFuture?.TrySetCanceled();
        _pendingSuggestionsFuture = new TaskCompletionSource<Suggestions>();
        int id = ++_pendingSuggestionsId;
        client.Send(new ServerBoundCommandSuggestionsRequestPacket { TransactionId = id, Command = context.Input });
        return _pendingSuggestionsFuture.Task;
    }

    public IReadOnlyCollection<SharedSuggestionProvider.TextCoordinates> RelevantCoordinates => client.Interactions.Target is BlockHitResult hit
        ? [new SharedSuggestionProvider.TextCoordinates(PrettyPrint(hit.X), PrettyPrint(hit.Y), PrettyPrint(hit.Z))]
        : [SharedSuggestionProvider.TextCoordinates.DefaultGlobal];

    public IReadOnlyCollection<SharedSuggestionProvider.TextCoordinates> AbsoluteCoordinates => client.Interactions.Target is BlockHitResult hit
        ? [new SharedSuggestionProvider.TextCoordinates(PrettyPrint(hit.Location.X), PrettyPrint(hit.Location.Y), PrettyPrint(hit.Location.Z))]
        : [SharedSuggestionProvider.TextCoordinates.DefaultGlobal];

    private static string PrettyPrint(double value) => JavaText.FormatFixed(value, 2);

    private static string PrettyPrint(int value) => value.ToString(System.Globalization.CultureInfo.InvariantCulture);

    public IReadOnlyCollection<Identifier> Levels => client.Dimensions;

    public IReadOnlyCollection<Identifier> EnabledFeatures => client.EnabledFeatures;

    /// <summary>Continuations of the pending task run inline on the packet thread, so the chat screen sees the answer before the next packet.</summary>
    public void CompleteCustomSuggestions(int id, Suggestions result) {
        if (id != _pendingSuggestionsId || _pendingSuggestionsFuture == null) {
            return;
        }
        TaskCompletionSource<Suggestions> future = _pendingSuggestionsFuture;
        _pendingSuggestionsFuture = null;
        _pendingSuggestionsId = -1;
        future.TrySetResult(result);
    }

    public void ModifyCustomCompletions(ClientBoundChatSuggestionsPacket.SuggestionAction action, IEnumerable<string> entries) {
        switch (action) {
            case ClientBoundChatSuggestionsPacket.SuggestionAction.Add:
                _customCompletionSuggestions.UnionWith(entries);
                break;
            case ClientBoundChatSuggestionsPacket.SuggestionAction.Remove:
                foreach (string entry in entries) {
                    _customCompletionSuggestions.Remove(entry);
                }
                break;
            case ClientBoundChatSuggestionsPacket.SuggestionAction.Set:
                _customCompletionSuggestions.Clear();
                _customCompletionSuggestions.UnionWith(entries);
                break;
        }
    }
}

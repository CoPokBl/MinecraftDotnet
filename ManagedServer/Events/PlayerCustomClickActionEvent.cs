using ManagedServer.Dialogs;
using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Implementations.Events;
using Minecraft.Schemas;

namespace ManagedServer.Events;

/// <summary>
/// Fired when a player activates a custom action, which is a dialog button or a <c>custom</c> click
/// event in a text component. Cancelling it stops the dialog's own callback from running.
/// </summary>
[NotCalledByDefault]
public class PlayerCustomClickActionEvent : IPlayerEvent, ICancelableEvent {
    public required World World { get; init; }
    public required Player Player { get; init; }

    /// <summary>The id the action carried.</summary>
    public required Identifier Id { get; init; }

    /// <summary>What was sent with it, including the values of any dialog inputs.</summary>
    public required DialogResponse Response { get; init; }

    public Entity Entity {
        get => Player;
        init { }
    }

    public bool Cancelled { get; set; }
}

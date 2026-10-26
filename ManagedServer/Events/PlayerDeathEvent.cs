using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Features.Basic;
using Minecraft.Text;

namespace ManagedServer.Events;

/// <summary>
/// Called in place of a plain <see cref="EntityDeathEvent"/> when the entity that died is a player. It
/// derives from that one, so a listener on <see cref="EntityDeathEvent"/> sees player deaths too and
/// only a listener on this sees nothing else.
/// <p/>
/// A player is never removed, so what cancelling skips here is the death screen. A server that puts its
/// dead players somewhere of its own (spectator, a lobby, straight back in) cancels and does that
/// instead.
/// </summary>
[NotCalledByDefault]
public class PlayerDeathEvent : EntityDeathEvent, IPlayerEvent {
    /// <summary>
    /// The message on the death screen. Starts as whatever <see cref="DeathFeature.DeathMessage"/>
    /// produced, and a listener is free to replace it.
    /// </summary>
    public required TextComponent Message { get; set; }

    public Player Player {
        get => (Player)LivingEntity;
        init { }
    }
}

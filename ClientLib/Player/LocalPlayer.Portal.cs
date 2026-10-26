using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ClientLib.Player;

/// <summary><c>Portal.Transition</c>: what the client shows while the player stands in a portal.</summary>
public enum PortalTransition {
    None,
    Confusion
}

/// <summary>
/// <c>PortalProcessor</c> as far as a client keeps one. Its portal time only moves in
/// <c>processPortalTeleportation</c>, which runs on the server, so a client's processor is never decayed
/// or dropped and lasts until the player is replaced.
/// </summary>
public sealed class PortalProcessor(Identifier portal) {
    public bool InsidePortalThisTick { get; set; } = true;

    /// <summary><c>getPortalLocalTransition</c>: <c>NetherPortalBlock</c> is the only portal with one.</summary>
    public PortalTransition LocalTransition => portal.Equals(Block.NetherPortal.Identifier) ? PortalTransition.Confusion : PortalTransition.None;

    public bool IsSamePortal(Identifier other) => portal.Equals(other);
}

/// <summary>The portal a player stands in, and the effect that grows while it does.</summary>
public sealed partial class LocalPlayer {
    /// <summary><c>Entity.portalProcess</c>.</summary>
    public PortalProcessor? PortalProcess { get; private set; }

    /// <summary><c>Entity.portalCooldown</c>, which a login or respawn sets from the server's.</summary>
    public int PortalCooldown { get; set; }

    /// <summary><c>LocalPlayer.portalEffectIntensity</c> and its value a tick ago, 0 to 1. A respawn carries both over.</summary>
    public float PortalEffectIntensity { get; set; }

    /// <inheritdoc cref="PortalEffectIntensity"/>
    public float OPortalEffectIntensity { get; set; }

    /// <summary>The effect started: <c>PORTAL_TRIGGER</c> as a local ambience, at this pitch.</summary>
    public event Action<float>? PortalTriggered;

    /// <summary><c>getActivePortalLocalTransition</c>.</summary>
    public PortalTransition ActivePortalLocalTransition => PortalProcess?.LocalTransition ?? PortalTransition.None;

    /// <summary><c>LivingEntity.canUsePortal(false)</c>.</summary>
    private bool CanUsePortal => !IsPassenger && !IsDead && !IsSleeping;

    /// <summary><c>Entity.setAsInsidePortal</c>, with <c>Player.getDimensionChangingDelay</c>'s 10 ticks.</summary>
    private void SetAsInsidePortal(Identifier portal) {
        if (PortalCooldown > 0) {
            PortalCooldown = 10;
        }
        else if (PortalProcess == null || !PortalProcess.IsSamePortal(portal)) {
            PortalProcess = new PortalProcessor(portal);
        }
        else if (!PortalProcess.InsidePortalThisTick) {
            PortalProcess.InsidePortalThisTick = true;
        }
    }

    /// <summary><c>Entity.processPortalCooldown</c>.</summary>
    private void ProcessPortalCooldown() {
        if (PortalCooldown > 0) {
            PortalCooldown--;
        }
    }

    /// <summary><c>LocalPlayer.handlePortalTransitionEffect</c>.</summary>
    private void HandlePortalTransitionEffect(bool active) {
        OPortalEffectIntensity = PortalEffectIntensity;
        float step = 0.0F;
        if (active && PortalProcess is { InsidePortalThisTick: true }) {
            _client.OnInsideConfusionPortal();
            if (PortalEffectIntensity == 0.0F) {
                PortalTriggered?.Invoke(_random.NextFloat() * 0.4F + 0.8F);
            }
            step = 0.0125F;
            PortalProcess.InsidePortalThisTick = false;
        }
        else if (PortalEffectIntensity > 0.0F) {
            step = -0.05F;
        }
        PortalEffectIntensity = Math.Clamp(PortalEffectIntensity + step, 0.0F, 1.0F);
    }
}

using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Text;

namespace ClientLib;

/// <summary>What the server tells the local player about itself: where it is, its health, its abilities.</summary>
public sealed partial class MinecraftClient {
    public TextComponent? DeathMessage { get; private set; }

    private bool _healthReceived;
    private long _respawnRequestedTick = -100;

    private bool HandlePlayerPacket(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundSynchronisePlayerPositionPacket position:
                HandlePlayerPosition(position);
                return true;
            case ClientBoundPlayerRotationPacket rotation:
                HandlePlayerRotation(rotation);
                return true;
            case ClientBoundSetCooldownPacket cooldown:
                if (cooldown.Ticks == 0) {
                    Player?.Cooldowns.RemoveCooldown(cooldown.CooldownGroup);
                }
                else {
                    Player?.Cooldowns.AddCooldown(cooldown.CooldownGroup, cooldown.Ticks);
                }
                return true;
            case ClientBoundSetHealthPacket health:
                if (Player != null) {
                    // LocalPlayer.hurtTo: a drop is a hit, and the only sign of one landing inside the
                    // invulnerable window, which gets no damage event. The first value after joining is not.
                    if (_healthReceived) {
                        float damage = Player.Health - health.Health;
                        if (damage > 0) {
                            Player.InvulnerableTime = 20;
                            Player.HurtTime = 10;
                        }
                        else if (damage < 0) {
                            Player.InvulnerableTime = 10;
                        }
                    }
                    _healthReceived = true;
                    Player.Health = health.Health;
                    Player.Food = health.Food;
                    Player.Saturation = health.Saturation;
                }
                return true;
            case ClientBoundSetExperiencePacket experience:
                if (Player != null) {
                    Player.ExperienceProgress = experience.ExperienceProgress;
                    Player.ExperienceLevel = experience.Level;
                    Player.TotalExperience = experience.TotalExperience;
                }
                return true;
            case ClientBoundPlayerAbilitiesPacket abilities:
                Player?.ApplyAbilities(abilities);
                return true;
            case ClientBoundSetHeldItemPacket held:
                if (held.Slot is >= 0 and < 9) {
                    Inventory.SelectedSlot = held.Slot;
                }
                return true;
            case ClientBoundCombatDeathPacket death:
                // ClientPacketListener.handlePlayerCombatKill: no death screen means straight back.
                if (Player != null && death.PlayerId == Player.Id) {
                    DeathMessage = death.Message;
                    if (!Player.ShowDeathScreen) {
                        Respawn();
                    }
                }
                return true;
            case ClientBoundExplosionPacket explosion:
                Particles.HandleExplosion(explosion);
                // ClientPacketListener.handleExplosion: the knockback is the server's, added as sent.
                if (Player != null && explosion.PlayerKnockback is { } knockback) {
                    Player.DeltaMovement = Player.DeltaMovement.Add(knockback.X, knockback.Y, knockback.Z);
                }
                return true;
            default:
                return false;
        }
    }

    /// <summary><c>LocalPlayer.respawn</c>: asks the server to bring a dead player back.</summary>
    public void Respawn() {
        Send(new ServerBoundClientStatusPacket { Action = ServerBoundClientStatusPacket.StatusAction.Respawn });
        Interactions.Keys.ResetToggleKeys();
        _respawnRequestedTick = ClientTicks;
    }
}

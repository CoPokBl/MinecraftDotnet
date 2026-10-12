using ClientLib.World;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ClientLib.Player;

/// <summary>The sleeping half of <c>Player</c>: the counter the fade reads and waking up.</summary>
public sealed partial class LocalPlayer {
    /// <summary><c>Player.getSleepTimer</c>: ticks asleep up to 100, then on to 110 over the wake.</summary>
    public int SleepTimer { get; private set; }

    /// <summary><c>Player.isSleepingLongEnough</c>.</summary>
    public bool IsSleepingLongEnough => IsSleeping && SleepTimer >= 100;

    /// <summary><c>Player.tick</c>'s sleep counter; the check that the bed rule still allows sleep is the server's.</summary>
    private void TickSleepCounter() {
        if (IsSleeping) {
            SleepTimer++;
            if (SleepTimer > 100) {
                SleepTimer = 100;
            }
        }
        else if (SleepTimer > 0) {
            SleepTimer++;
            if (SleepTimer >= 110) {
                SleepTimer = 0;
            }
        }
    }

    public override void StopSleeping(ClientLevel? level) {
        base.StopSleeping(level);
        Pose = EntityPose.Standing;
    }

    /// <summary><c>Player.stopSleepInBed</c>, which the client runs on the server's wake up animation.</summary>
    public void StopSleepInBed(bool forcefulWakeUp) {
        StopSleeping(_client.Level);
        SleepTimer = forcefulWakeUp ? 0 : 100;
    }

    /// <summary><c>InBedChatScreen.sendWakeUp</c>: the server wakes the player and answers with the animation.</summary>
    public void SendWakeUp() {
        _client.Send(new ServerBoundPlayerCommandPacket {
            EntityId = Id,
            PlayAction = PlayerAction.LeaveBed,
            JumpBoost = 0
        });
    }
}

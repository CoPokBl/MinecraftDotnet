using ClientLib.Stats;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;

namespace ClientLib;

/// <summary>The player's statistics, which the server sends only when asked.</summary>
public sealed partial class MinecraftClient {
    /// <summary><c>LocalPlayer.getStats</c>: made anew by each login and handed on by a respawn.</summary>
    public StatsCounter Stats { get; private set; } = new();

    /// <summary>How many award packets have been handled, so a screen can tell its answer came.</summary>
    public int StatsUpdates { get; private set; }

    /// <summary>What <c>StatsScreen.init</c> sends, once per screen.</summary>
    public void RequestStats() => Send(new ServerBoundClientStatusPacket { Action = ServerBoundClientStatusPacket.StatusAction.RequestStats });

    private void ResetStatsForLogin() => Stats = new StatsCounter();

    private bool HandleStatsPacket(MinecraftPacket packet) {
        if (packet is not ClientBoundAwardStatisticsPacket award) {
            return false;
        }
        HandleAwardStats(award);
        return true;
    }

    /// <summary><c>ClientPacketListener.handleAwardStats</c>: each value replaces the one held.</summary>
    internal void HandleAwardStats(ClientBoundAwardStatisticsPacket packet) {
        if (Player == null) {
            return;
        }
        foreach (ClientBoundAwardStatisticsPacket.Entry entry in packet.Statistics) {
            Stats.SetValue(new Stat(entry.Category, entry.Statistic), entry.Value);
        }
        StatsUpdates++;
    }
}

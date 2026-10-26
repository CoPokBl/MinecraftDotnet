using Minecraft.Packets.Play.ClientBound;

namespace ClientLib;

/// <summary>
/// The state half of vanilla's <c>BossHealthOverlay</c>: the bars the server has shown, in the order it
/// added them, which is the order they draw down the screen.
/// </summary>
public sealed class BossHealthOverlay {
    private readonly OrderedDictionary<Guid, LerpingBossEvent> _events = new();

    public IEnumerable<LerpingBossEvent> Events => _events.Values;

    public int Count => _events.Count;

    public void Update(ClientBoundBossBarPacket packet) => Update(packet, LerpingBossEvent.Millis());

    /// <summary>
    /// <c>BossHealthOverlay.update</c>. An update for a bar that was never added throws in vanilla and
    /// drops the connection; it is ignored here.
    /// </summary>
    public void Update(ClientBoundBossBarPacket packet, long nowMillis) {
        Guid id = packet.Uuid;
        if (packet.Action is ClientBoundBossBarPacket.Add add) {
            ClientBoundBossBarPacket.Flags flags = add.Flags;
            _events[id] = new LerpingBossEvent(id, add.Title, add.Health, add.Color, add.Division,
                (flags & ClientBoundBossBarPacket.Flags.DarkenSky) != 0,
                (flags & ClientBoundBossBarPacket.Flags.IsDragonBar) != 0,
                (flags & ClientBoundBossBarPacket.Flags.CreateFog) != 0,
                nowMillis);
            return;
        }
        if (packet.Action is ClientBoundBossBarPacket.Remove) {
            _events.Remove(id);
            return;
        }
        if (!_events.TryGetValue(id, out LerpingBossEvent? bossEvent)) {
            return;
        }
        switch (packet.Action) {
            case ClientBoundBossBarPacket.UpdateHealth health:
                bossEvent.SetProgress(health.Health, nowMillis);
                break;
            case ClientBoundBossBarPacket.UpdateTitle title:
                bossEvent.Name = title.Title;
                break;
            case ClientBoundBossBarPacket.UpdateStyle style:
                bossEvent.Color = style.Color;
                bossEvent.Overlay = style.Division;
                break;
            case ClientBoundBossBarPacket.UpdateFlags properties:
                bossEvent.DarkenScreen = (properties.Flags & ClientBoundBossBarPacket.Flags.DarkenSky) != 0;
                bossEvent.PlayBossMusic = (properties.Flags & ClientBoundBossBarPacket.Flags.IsDragonBar) != 0;
                bossEvent.CreateWorldFog = (properties.Flags & ClientBoundBossBarPacket.Flags.CreateFog) != 0;
                break;
        }
    }

    public void Reset() => _events.Clear();

    public bool ShouldPlayMusic() => _events.Values.Any(e => e.PlayBossMusic);

    public bool ShouldDarkenScreen() => _events.Values.Any(e => e.DarkenScreen);

    public bool ShouldCreateWorldFog() => _events.Values.Any(e => e.CreateWorldFog);
}

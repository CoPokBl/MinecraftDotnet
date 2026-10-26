using System.Diagnostics;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Text;

namespace ClientLib;

/// <summary>
/// Vanilla's <c>LerpingBossEvent</c> over <c>BossEvent</c>: a boss bar whose progress glides to each new
/// value over <see cref="LerpMilliseconds"/> of wall clock time rather than jumping.
/// </summary>
public sealed class LerpingBossEvent {
    public const long LerpMilliseconds = 100;

    private float _progress;
    private float _targetPercent;
    private long _setTime;

    public Guid Id { get; }
    public TextComponent Name { get; set; }
    public ClientBoundBossBarPacket.Color Color { get; set; }
    public ClientBoundBossBarPacket.Division Overlay { get; set; }
    public bool DarkenScreen { get; set; }
    public bool PlayBossMusic { get; set; }
    public bool CreateWorldFog { get; set; }

    public LerpingBossEvent(Guid id, TextComponent name, float progress, ClientBoundBossBarPacket.Color color,
        ClientBoundBossBarPacket.Division overlay, bool darkenScreen, bool playMusic, bool createWorldFog, long nowMillis) {
        Id = id;
        Name = name;
        Color = color;
        Overlay = overlay;
        _targetPercent = progress;
        _progress = progress;
        _setTime = nowMillis;
        DarkenScreen = darkenScreen;
        PlayBossMusic = playMusic;
        CreateWorldFog = createWorldFog;
    }

    /// <summary>Vanilla's <c>Util.getMillis</c>: a monotonic clock, not the time of day.</summary>
    public static long Millis() => Stopwatch.GetTimestamp() * 1000 / Stopwatch.Frequency;

    public float Progress => GetProgress(Millis());

    public void SetProgress(float progress, long nowMillis) {
        _progress = GetProgress(nowMillis);
        _targetPercent = progress;
        _setTime = nowMillis;
    }

    public float GetProgress(long nowMillis) {
        long timeSinceSet = nowMillis - _setTime;
        float lerpPercent = Math.Clamp((float)timeSinceSet / LerpMilliseconds, 0.0F, 1.0F);
        return _progress + lerpPercent * (_targetPercent - _progress);
    }
}

using Minecraft.Schemas;

namespace ClientLib.World;

/// <summary>
/// <c>EndFlashState</c>: the flash in the end's sky. Every 600 ticks of the dimension's clock a generator seeded
/// with the interval's number picks when in it the flash starts, how long it lasts and where in the sky it is, so
/// every client sees the same flashes at the same time.
/// </summary>
public sealed class EndFlashState {
    private const int FlashIntervalInTicks = 600;
    private const int MaxFlashOffsetInTicks = 200;
    private const int MinFlashDurationInTicks = 100;
    private const int MaxFlashDurationInTicks = 380;

    private long _flashSeed;
    private int _offset;
    private int _duration;
    private float _intensity;
    private float _oldIntensity;

    public float XAngle { get; private set; }
    public float YAngle { get; private set; }

    public void Tick(long clockTime) {
        CalculateFlashParameters(clockTime);
        _oldIntensity = _intensity;
        _intensity = CalculateIntensity(clockTime);
    }

    private void CalculateFlashParameters(long clockTime) {
        long newSeed = clockTime / FlashIntervalInTicks;
        if (newSeed == _flashSeed) {
            return;
        }
        LegacyRandomSource random = new(newSeed);
        random.NextFloat();
        _offset = random.NextIntBetweenInclusive(0, MaxFlashOffsetInTicks);
        _duration = random.NextIntBetweenInclusive(MinFlashDurationInTicks, Math.Min(MaxFlashDurationInTicks, FlashIntervalInTicks - _offset));
        XAngle = random.NextFloat() * (10.0F - -60.0F) + -60.0F;
        YAngle = random.NextFloat() * (180.0F - -180.0F) + -180.0F;
        _flashSeed = newSeed;
    }

    private float CalculateIntensity(long clockTime) {
        long within = clockTime % FlashIntervalInTicks;
        return within >= _offset && within <= _offset + _duration
            ? Mth.Sin((float)(within - _offset) * MathF.PI / _duration)
            : 0.0F;
    }

    public float GetIntensity(float partialTick) => _oldIntensity + partialTick * (_intensity - _oldIntensity);

    public bool FlashStartedThisTick => _intensity > 0.0F && _oldIntensity <= 0.0F;
}

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BinaryAnimator</c>: a factor that eases toward 1 while active and back to 0 while not.</summary>
public sealed class BinaryAnimator {
    private readonly int _animationLength;
    private readonly Func<float, float> _easing;
    private int _ticks, _ticksOld;

    public BinaryAnimator(int animationLength, Func<float, float> easing) {
        _animationLength = animationLength;
        _easing = easing;
    }

    public BinaryAnimator(int animationLength) : this(animationLength, x => x) { }

    public void Tick(bool active) {
        _ticksOld = _ticks;
        if (active) {
            if (_ticks < _animationLength) {
                _ticks++;
            }
        }
        else if (_ticks > 0) {
            _ticks--;
        }
    }

    public float GetFactor(float partialTicks) {
        float factor = Mth.Lerp(partialTicks, _ticksOld, _ticks) / _animationLength;
        return _easing(factor);
    }

    /// <summary><c>Ease.inOutSine</c>.</summary>
    public static float InOutSine(float x) => -(Mth.Cos(MathF.PI * x) - 1.0F) / 2.0F;
}

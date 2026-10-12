namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>DragonFlightHistory</c>: the dragon's height and heading over its last 64 ticks, which its neck and tail trail through.</summary>
public sealed class DragonFlightHistory {
    public const int Length = 64;
    private const int Mask = 63;

    private readonly Sample[] _samples = new Sample[Length];
    private int _head = -1;

    public DragonFlightHistory() {
        Array.Fill(_samples, new Sample(0.0, 0.0F));
    }

    public void CopyFrom(DragonFlightHistory history) {
        Array.Copy(history._samples, _samples, Length);
        _head = history._head;
    }

    public void Record(double y, float yRot) {
        Sample sample = new(y, yRot);
        if (_head < 0) {
            Array.Fill(_samples, sample);
        }
        if (++_head == Length) {
            _head = 0;
        }
        _samples[_head] = sample;
    }

    public Sample Get(int delay) => _samples[(_head - delay) & Mask];

    public Sample Get(int delay, float partialTicks) {
        Sample sample = Get(delay);
        Sample sampleOld = Get(delay + 1);
        return new Sample(sampleOld.Y + partialTicks * (sample.Y - sampleOld.Y), Mth.RotLerp(partialTicks, sampleOld.YRot, sample.YRot));
    }

    public readonly record struct Sample(double Y, float YRot);
}

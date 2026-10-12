using System.Diagnostics;

namespace ClientLib.Network;

/// <summary>
/// Vanilla's <c>ChunkBatchSizeCalculator</c>: how many chunks a tick the client asks the server for,
/// from how long batches take to arrive. Seven milliseconds of chunks a tick at the running average.
/// </summary>
public sealed class ChunkBatchSizeCalculator {
    private double _aggregatedNanosPerChunk = 2000000.0;
    private int _oldSamplesWeight = 1;
    private long _batchStart = Stopwatch.GetTimestamp();

    public void OnBatchStart() {
        _batchStart = Stopwatch.GetTimestamp();
    }

    public void OnBatchFinished(int batchSize) {
        if (batchSize <= 0) {
            return;
        }

        double duration = Stopwatch.GetElapsedTime(_batchStart).Ticks * 100.0;
        double nanosPerChunk = duration / batchSize;
        double clamped = Math.Clamp(nanosPerChunk, _aggregatedNanosPerChunk / 3.0, _aggregatedNanosPerChunk * 3.0);
        _aggregatedNanosPerChunk = (_aggregatedNanosPerChunk * _oldSamplesWeight + clamped) / (_oldSamplesWeight + 1);
        _oldSamplesWeight = Math.Min(49, _oldSamplesWeight + 1);
    }

    public float DesiredChunksPerTick => (float)(7000000.0 / _aggregatedNanosPerChunk);
}

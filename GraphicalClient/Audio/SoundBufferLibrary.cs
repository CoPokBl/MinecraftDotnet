using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Schemas;
using Silk.NET.OpenAL;

namespace GraphicalClient.Audio;

/// <summary>
/// vanilla's <c>SoundBufferLibrary</c>: sounds decoded once on a worker and kept as OpenAL buffers, and
/// streams opened for music. A sound whose file has not arrived (a vanilla asset still downloading) is
/// not remembered as missing, so it plays once it has.
/// </summary>
public sealed unsafe class SoundBufferLibrary(AudioDevice device, PackFiles? packs) : IDisposable {
    private readonly Dictionary<Identifier, Task<AudioData?>> _decoding = new();
    private readonly Dictionary<Identifier, uint> _buffers = new();

    private byte[]? Read(Identifier location) => packs?.Read(Sound.FileOf(location));

    /// <summary>The sound's buffer once it is decoded; null while it is, or when it cannot be.</summary>
    public uint? Buffer(Identifier location, out bool failed) {
        failed = false;
        if (_buffers.TryGetValue(location, out uint buffer)) {
            return buffer;
        }
        if (!_decoding.TryGetValue(location, out Task<AudioData?>? task)) {
            _decoding[location] = Task.Run(() => Decode(location));
            return null;
        }
        if (!task.IsCompleted) {
            return null;
        }
        _decoding.Remove(location);
        if (!task.IsCompletedSuccessfully || task.Result is not { } data) {
            failed = true;
            return null;
        }
        buffer = device.Al.GenBuffers(1)[0];
        fixed (short* samples = data.Samples) {
            device.Al.BufferData(buffer, data.Channels == 1 ? (BufferFormat)0x1101 : (BufferFormat)0x1103, samples, data.Samples.Length * 2, data.SampleRate);
        }
        _buffers[location] = buffer;
        return buffer;
    }

    private AudioData? Decode(Identifier location) {
        if (location.Namespace == Sound.DevNamespace) {
            return DevSounds.Synthesize(location.Key);
        }
        return Read(location) is { } file ? OggDecoder.Decode(file) : null;
    }

    /// <summary><c>getStream</c>: opened on a worker, as the file has to be read first.</summary>
    public Task<IAudioStream?> Stream(Identifier location, bool looping) => Task.Run<IAudioStream?>(() => {
        if (location.Namespace == Sound.DevNamespace) {
            return new DataStream(DevSounds.Synthesize(location.Key), looping);
        }
        return Read(location) is { } file ? OggDecoder.Stream(file, looping) : null;
    });

    /// <summary>A decoded sound handed out a piece at a time, for the built in art's music.</summary>
    private sealed class DataStream(AudioData data, bool looping) : IAudioStream {
        private int _position;

        public int Channels => data.Channels;
        public int SampleRate => data.SampleRate;

        public short[]? Read(int samples) {
            if (_position >= data.Samples.Length) {
                if (!looping) {
                    return null;
                }
                _position = 0;
            }
            int count = Math.Min(samples, data.Samples.Length - _position);
            short[] result = data.Samples[_position..(_position + count)];
            _position += count;
            return result;
        }

        public void Dispose() { }
    }

    public void Dispose() {
        foreach (uint buffer in _buffers.Values) {
            device.Al.DeleteBuffer(buffer);
        }
        _buffers.Clear();
    }
}

using NVorbis;

namespace GraphicalClient.Audio;

/// <summary>A whole sound decoded to signed 16 bit samples, interleaved when it has more than one channel.</summary>
public sealed record AudioData(short[] Samples, int Channels, int SampleRate);

/// <summary>Samples read a piece at a time, for music, which is too long to hold decoded.</summary>
public interface IAudioStream : IDisposable {
    int Channels { get; }
    int SampleRate { get; }

    /// <summary>Up to <paramref name="samples"/> samples; null once the sound has ended.</summary>
    short[]? Read(int samples);
}

/// <summary>Ogg Vorbis, the only format packs ship sounds in, decoded by NVorbis.</summary>
public static class OggDecoder {
    public static AudioData Decode(byte[] file) {
        using VorbisReader reader = new(new MemoryStream(file), true);
        List<short> samples = new((int)Math.Min(int.MaxValue, reader.TotalSamples * reader.Channels));
        float[] buffer = new float[4096 * reader.Channels];
        int read;
        while ((read = reader.ReadSamples(buffer, 0, buffer.Length)) > 0) {
            for (int i = 0; i < read; i++) {
                samples.Add(ToShort(buffer[i]));
            }
        }
        return new AudioData(samples.ToArray(), reader.Channels, reader.SampleRate);
    }

    public static IAudioStream Stream(byte[] file, bool looping) => new OggStream(file, looping);

    private static short ToShort(float sample) => (short)Math.Clamp((int)(sample * 32767.0F), short.MinValue, short.MaxValue);

    /// <summary>vanilla's <c>JOrbisAudioStream</c>, wrapped in <c>LoopingAudioStream</c> when it loops.</summary>
    private sealed class OggStream(byte[] file, bool looping) : IAudioStream {
        private VorbisReader _reader = new(new MemoryStream(file), true);
        private float[] _buffer = [];

        public int Channels => _reader.Channels;
        public int SampleRate => _reader.SampleRate;

        public short[]? Read(int samples) {
            if (_buffer.Length < samples) {
                _buffer = new float[samples];
            }
            float[] buffer = _buffer;
            int read = _reader.ReadSamples(buffer, 0, samples - samples % Channels);
            if (read == 0 && looping) {
                _reader.Dispose();
                _reader = new VorbisReader(new MemoryStream(file), true);
                read = _reader.ReadSamples(buffer, 0, samples - samples % Channels);
            }
            if (read == 0) {
                return null;
            }
            short[] result = new short[read];
            for (int i = 0; i < read; i++) {
                result[i] = ToShort(buffer[i]);
            }
            return result;
        }

        public void Dispose() => _reader.Dispose();
    }
}

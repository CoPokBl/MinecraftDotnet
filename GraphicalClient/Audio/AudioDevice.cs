using System.Numerics;
using Silk.NET.OpenAL;

namespace GraphicalClient.Audio;

/// <summary>
/// The OpenAL device and its sources, blaze3d's <c>Library</c>: the device's mixing channels split into
/// a few for streams and the rest for whole buffers, as vanilla splits them. Every AL call is made on
/// the game thread. A machine with no audio device leaves <see cref="Available"/> false and the game
/// silent rather than failing.
/// </summary>
public sealed unsafe class AudioDevice : IDisposable {
    // AL_EXT_source_distance_model and AL_EXT_LINEAR_DISTANCE, which Silk.NET's enums do not name.
    private const int SourceDistanceModel = 0x200;
    private const int SourceDistanceModelProperty = 0xD000;
    private const int LinearDistance = 0xD003;
    private const int OutputLimiterSoft = 0x199A;
    private const int MonoSources = 0x1010;
    private const int DefaultChannelCount = 30;

    private readonly ALContext? _alc;
    private readonly Device* _device;
    private readonly Context* _context;
    private readonly ChannelPool? _static, _streaming;

    public AL Al { get; } = null!;

    public bool Available { get; }

    public AudioDevice() {
        try {
            _alc = ALContext.GetApi(true);
            Al = AL.GetApi(true);
            _device = _alc.OpenDevice("");
            if (_device == null) {
                Console.Error.WriteLine("No audio device; the game will be silent.");
                return;
            }
            int* attributes = stackalloc int[] { OutputLimiterSoft, 1, 0 };
            _context = _alc.CreateContext(_device, attributes);
            _alc.MakeContextCurrent(_context);
            int total = ChannelCount();
            int streaming = Math.Clamp((int)MathF.Sqrt(total), 2, 8);
            int staticCount = Math.Clamp(total - streaming, 8, 255);
            _static = new ChannelPool(this, staticCount);
            _streaming = new ChannelPool(this, streaming);
            Al.Enable((Capability)SourceDistanceModel);
            Available = true;
        }
        catch (Exception e) when (e is DllNotFoundException or InvalidOperationException or EntryPointNotFoundException) {
            Console.Error.WriteLine($"Could not open OpenAL ({e.Message}); the game will be silent.");
        }
    }

    /// <summary><c>Library.getChannelCount</c>: the device's mono sources, or thirty when it will not say.</summary>
    private int ChannelCount() {
        int size;
        _alc!.GetContextProperty(_device, (GetContextInteger)0x1002, 1, &size);
        if (size <= 0) {
            return DefaultChannelCount;
        }
        int* attributes = stackalloc int[size];
        _alc.GetContextProperty(_device, (GetContextInteger)0x1003, size, attributes);
        for (int i = 0; i + 1 < size; i += 2) {
            if (attributes[i] == 0) {
                break;
            }
            if (attributes[i] == MonoSources) {
                return attributes[i + 1];
            }
        }
        return DefaultChannelCount;
    }

    /// <summary>A free source from the pool for the sound's kind, or null when they are all playing.</summary>
    public Channel? Acquire(bool streaming) => Available ? (streaming ? _streaming : _static)!.Acquire() : null;

    public void Release(Channel channel) {
        (channel.Streaming ? _streaming : _static)?.Release(channel);
    }

    /// <summary><c>Listener.setTransform</c>.</summary>
    public void SetListener(Vector3 position, Vector3 forward, Vector3 up) {
        if (!Available) {
            return;
        }
        Al.SetListenerProperty(ListenerVector3.Position, position.X, position.Y, position.Z);
        float* orientation = stackalloc float[] { forward.X, forward.Y, forward.Z, up.X, up.Y, up.Z };
        Al.SetListenerProperty(ListenerFloatArray.Orientation, orientation);
    }

    public void Dispose() {
        _static?.Dispose();
        _streaming?.Dispose();
        if (_context != null) {
            _alc!.MakeContextCurrent(null);
            _alc.DestroyContext(_context);
        }
        if (_device != null) {
            _alc!.CloseDevice(_device);
        }
    }

    /// <summary><c>Library.CountingChannelPool</c>: sources made as they are first needed, up to a limit.</summary>
    private sealed class ChannelPool(AudioDevice device, int limit) : IDisposable {
        private readonly HashSet<Channel> _used = [];

        public Channel? Acquire() {
            if (_used.Count >= limit) {
                return null;
            }
            Channel channel = new(device, this == device._streaming);
            _used.Add(channel);
            return channel;
        }

        public void Release(Channel channel) {
            if (_used.Remove(channel)) {
                channel.Destroy();
            }
        }

        public void Dispose() {
            foreach (Channel channel in _used) {
                channel.Destroy();
            }
            _used.Clear();
        }
    }

    internal void ApplyLinearAttenuation(uint source, float maxDistance) {
        Al.SetSourceProperty(source, (SourceInteger)SourceDistanceModelProperty, LinearDistance);
        Al.SetSourceProperty(source, SourceFloat.MaxDistance, maxDistance);
        Al.SetSourceProperty(source, SourceFloat.RolloffFactor, 1.0F);
        Al.SetSourceProperty(source, SourceFloat.ReferenceDistance, 0.0F);
    }

    internal void DisableAttenuation(uint source) {
        Al.SetSourceProperty(source, (SourceInteger)SourceDistanceModelProperty, 0);
    }
}

/// <summary>blaze3d's <c>Channel</c>: one OpenAL source, playing a whole buffer or a stream fed a second at a time.</summary>
public sealed unsafe class Channel {
    private const int QueuedBufferCount = 4;

    private readonly AudioDevice _device;
    private readonly uint _source;
    private bool _initialised = true;
    private IAudioStream? _stream;
    private int _streamingSamples;
    private int _queued;
    private bool _streamEnded;

    /// <summary>The stream's next second, decoded on a worker: a second of music is several milliseconds of a frame otherwise.</summary>
    private Task<short[]?>? _decoding;

    public bool Streaming { get; }

    internal Channel(AudioDevice device, bool streaming) {
        _device = device;
        Streaming = streaming;
        _source = device.Al.GenSources(1)[0];
    }

    private AL Al => _device.Al;

    private SourceState State {
        get {
            if (!_initialised) {
                return SourceState.Stopped;
            }
            Al.GetSourceProperty(_source, GetSourceInteger.SourceState, out int state);
            return (SourceState)state;
        }
    }

    internal void Destroy() {
        if (!_initialised) {
            return;
        }
        _initialised = false;
        Al.SourceStop(_source);
        if (_stream is { } stream) {
            if (_decoding is { } decoding) {
                decoding.ContinueWith(_ => stream.Dispose(), TaskScheduler.Default);
                _decoding = null;
            }
            else {
                stream.Dispose();
            }
            RemoveProcessedBuffers();
            _stream = null;
        }
        Al.DeleteSource(_source);
    }

    public void Play() => Al.SourcePlay(_source);

    public void Pause() {
        if (State == SourceState.Playing) {
            Al.SourcePause(_source);
        }
    }

    public void Unpause() {
        if (State == SourceState.Paused) {
            Al.SourcePlay(_source);
        }
    }

    public void Stop() {
        if (_initialised) {
            Al.SourceStop(_source);
        }
    }

    public bool Playing => State == SourceState.Playing;

    public bool Stopped => State == SourceState.Stopped;

    public void SetSelfPosition(Vector3 position) => Al.SetSourceProperty(_source, SourceVector3.Position, position.X, position.Y, position.Z);

    public void SetPitch(float pitch) => Al.SetSourceProperty(_source, SourceFloat.Pitch, pitch);

    public void SetLooping(bool looping) => Al.SetSourceProperty(_source, SourceBoolean.Looping, looping);

    public void SetVolume(float volume) => Al.SetSourceProperty(_source, SourceFloat.Gain, volume);

    public void DisableAttenuation() => _device.DisableAttenuation(_source);

    public void LinearAttenuation(float maxDistance) => _device.ApplyLinearAttenuation(_source, maxDistance);

    public void SetRelative(bool relative) => Al.SetSourceProperty(_source, SourceBoolean.SourceRelative, relative);

    public void AttachStaticBuffer(uint buffer) => Al.SetSourceProperty(_source, SourceInteger.Buffer, buffer);

    /// <summary>
    /// A second's worth of samples per buffer, four queued, as vanilla streams. The first second is decoded
    /// at once so the source has something to play; the rest arrive from the worker over the next ticks.
    /// </summary>
    public void AttachBufferStream(IAudioStream stream) {
        _stream = stream;
        _streamingSamples = stream.SampleRate * stream.Channels;
        Queue(stream.Read(_streamingSamples));
        DecodeAhead();
    }

    private void Queue(short[]? samples) {
        if (_stream == null || samples == null || samples.Length == 0) {
            _streamEnded = true;
            return;
        }
        uint buffer = Al.GenBuffers(1)[0];
        fixed (short* data = samples) {
            Al.BufferData(buffer, _stream.Channels == 1 ? (BufferFormat)0x1101 : (BufferFormat)0x1103, data, samples.Length * 2, _stream.SampleRate);
        }
        Al.SourceQueueBuffers(_source, 1, &buffer);
        _queued++;
    }

    private void DecodeAhead() {
        if (_stream is { } stream && !_streamEnded && _decoding == null) {
            int samples = _streamingSamples;
            _decoding = Task.Run(() => stream.Read(samples));
        }
    }

    /// <summary>
    /// Once a tick: drops the buffers that finished and queues what the worker decoded, waiting for it only
    /// when the source would otherwise run dry.
    /// </summary>
    public void UpdateStream() {
        if (_stream == null) {
            return;
        }
        _queued -= RemoveProcessedBuffers();
        while (_queued < QueuedBufferCount && _decoding is { } decoding && (decoding.IsCompleted || _queued == 0)) {
            _decoding = null;
            Queue(decoding.GetAwaiter().GetResult());
            DecodeAhead();
        }
    }

    private int RemoveProcessedBuffers() {
        Al.GetSourceProperty(_source, GetSourceInteger.BuffersProcessed, out int processed);
        if (processed > 0) {
            uint* ids = stackalloc uint[processed];
            Al.SourceUnqueueBuffers(_source, processed, ids);
            Al.DeleteBuffers(processed, ids);
        }
        return processed;
    }
}

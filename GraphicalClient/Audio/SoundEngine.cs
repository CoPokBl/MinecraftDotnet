using System.Numerics;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace GraphicalClient.Audio;

/// <summary>
/// vanilla's <c>SoundEngine</c> and <c>SoundManager</c>: plays sound instances on the device, keeps the
/// moving ones moving, loops and delays the ones that ask, and lets go of a channel once its sound
/// has finished. Everything runs on the game thread; decoding happens on workers and a sound whose
/// data is not ready yet holds its channel until it is.
/// </summary>
public sealed class SoundEngine : IDisposable {
    // MIN_SOURCE_LIFETIME: a channel is not reclaimed before this many ticks, even once stopped.
    private const int MinSourceLifetime = 20;

    private readonly AudioDevice _device;
    private readonly SoundBufferLibrary _buffers;
    private readonly Dictionary<SoundInstance, Channel> _instanceToChannel = new();
    private readonly Dictionary<SoundInstance, int> _soundDeleteTime = new();
    private readonly List<TickableSoundInstance> _tickingSounds = [];
    private readonly Dictionary<SoundInstance, int> _queuedSounds = new();
    private readonly List<TickableSoundInstance> _queuedTickableSounds = [];
    private readonly List<(SoundInstance Instance, Channel Channel)> _waitingForData = [];
    private readonly List<(SoundInstance Instance, Channel Channel, Task<IAudioStream?> Stream)> _waitingForStream = [];
    private readonly float[] _gainBySource = Enumerable.Repeat(1.0F, Enum.GetValues<SoundCategory>().Length).ToArray();
    private int _tickCount;

    public SoundRegistry Registry { get; }

    /// <summary>The volume sliders, <c>Options.getSoundSourceVolume</c>, by category.</summary>
    public float[] CategoryVolumes { get; } = Enumerable.Repeat(1.0F, Enum.GetValues<SoundCategory>().Length).ToArray();

    public SoundEngine(PackFiles? packs) {
        _device = new AudioDevice();
        _buffers = new SoundBufferLibrary(_device, packs);
        Registry = new SoundRegistry(packs);
    }

    public bool Available => _device.Available;

    /// <summary>Sounds holding a channel, for the debug line.</summary>
    public int Playing => _instanceToChannel.Count;

    /// <summary><c>Options.getFinalSoundSourceVolume</c>: a category's slider times the master slider.</summary>
    private float FinalVolume(SoundCategory source) =>
        source == SoundCategory.Master ? CategoryVolumes[(int)source] : CategoryVolumes[(int)source] * CategoryVolumes[(int)SoundCategory.Master];

    private float CalculateVolume(float volume, SoundCategory source) =>
        Math.Clamp(volume, 0.0F, 1.0F) * Math.Clamp(FinalVolume(source), 0.0F, 1.0F) * _gainBySource[(int)source];

    /// <summary><c>updateCategoryVolume</c>: a gain on top of the slider, which the music fade drives.</summary>
    public void UpdateCategoryVolume(SoundCategory source, float gain) {
        _gainBySource[(int)source] = Math.Clamp(gain, 0.0F, 1.0F);
        RefreshCategoryVolume(source);
    }

    /// <summary>A slider moved: <c>SoundManager.refreshCategoryVolume</c>, which reaches sounds already playing.</summary>
    public void SetCategoryVolume(SoundCategory source, float volume) {
        CategoryVolumes[(int)source] = volume;
        RefreshCategoryVolume(source);
    }

    private void RefreshCategoryVolume(SoundCategory source) {
        foreach ((SoundInstance instance, Channel channel) in _instanceToChannel) {
            if (source == instance.Source || source == SoundCategory.Master) {
                channel.SetVolume(CalculateVolume(instance.Volume, instance.Source));
            }
        }
    }

    private static float CalculatePitch(SoundInstance instance) => Math.Clamp(instance.Pitch, 0.5F, 2.0F);

    private static bool ShouldLoopManually(SoundInstance instance) => instance.Looping && instance.Delay > 0;

    private static bool ShouldLoopAutomatically(SoundInstance instance) => instance.Looping && instance.Delay <= 0;

    public bool IsActive(SoundInstance instance) =>
        _soundDeleteTime.TryGetValue(instance, out int time) && time <= _tickCount || _instanceToChannel.ContainsKey(instance);

    /// <summary><c>play</c>.</summary>
    public void Play(SoundInstance instance) {
        if (!_device.Available || !instance.CanPlaySound) {
            return;
        }
        if (instance.Resolve(Registry) == null) {
            return;
        }
        Sound sound = instance.Sound!;
        if (sound == Sound.IntentionallyEmpty || sound == Sound.Empty) {
            return;
        }
        float instanceVolume = instance.Volume;
        float attenuationDistance = Math.Max(instanceVolume, 1.0F) * sound.AttenuationDistance;
        float volume = CalculateVolume(instanceVolume, instance.Source);
        float pitch = CalculatePitch(instance);
        if (volume == 0.0F && !instance.CanStartSilent && instance.Source != SoundCategory.Music) {
            return;
        }
        bool looping = ShouldLoopAutomatically(instance);
        Channel? channel = _device.Acquire(sound.Stream);
        if (channel == null) {
            return;
        }
        _soundDeleteTime[instance] = _tickCount + MinSourceLifetime;
        _instanceToChannel[instance] = channel;
        channel.SetPitch(pitch);
        channel.SetVolume(volume);
        if (instance.Attenuation == Attenuation.Linear) {
            channel.LinearAttenuation(attenuationDistance);
        }
        else {
            channel.DisableAttenuation();
        }
        channel.SetLooping(looping && !sound.Stream);
        channel.SetSelfPosition(new Vector3((float)instance.X, (float)instance.Y, (float)instance.Z));
        channel.SetRelative(instance.Relative);
        if (sound.Stream) {
            _waitingForStream.Add((instance, channel, _buffers.Stream(sound.Location, looping)));
        }
        else {
            _waitingForData.Add((instance, channel));
        }
        if (instance is TickableSoundInstance tickable) {
            _tickingSounds.Add(tickable);
        }
        StartReady();
    }

    /// <summary>Attaches and starts the sounds whose data has arrived since they were played.</summary>
    private void StartReady() {
        for (int i = _waitingForData.Count - 1; i >= 0; i--) {
            (SoundInstance instance, Channel channel) = _waitingForData[i];
            if (!_instanceToChannel.ContainsKey(instance)) {
                _waitingForData.RemoveAt(i);
                continue;
            }
            uint? buffer = _buffers.Buffer(instance.Sound!.Location, out bool failed);
            if (buffer is { } ready) {
                channel.AttachStaticBuffer(ready);
                channel.Play();
                _waitingForData.RemoveAt(i);
            }
            else if (failed) {
                _waitingForData.RemoveAt(i);
                ReleaseInstance(instance);
            }
        }
        for (int i = _waitingForStream.Count - 1; i >= 0; i--) {
            (SoundInstance instance, Channel channel, Task<IAudioStream?> stream) = _waitingForStream[i];
            if (!stream.IsCompleted) {
                continue;
            }
            _waitingForStream.RemoveAt(i);
            if (!_instanceToChannel.ContainsKey(instance)) {
                stream.Result?.Dispose();
                continue;
            }
            if (stream.IsCompletedSuccessfully && stream.Result is { } opened) {
                channel.AttachBufferStream(opened);
                channel.Play();
            }
            else {
                ReleaseInstance(instance);
            }
        }
    }

    private void ReleaseInstance(SoundInstance instance) {
        if (_instanceToChannel.Remove(instance, out Channel? channel)) {
            _device.Release(channel);
        }
        _soundDeleteTime.Remove(instance);
        if (instance is TickableSoundInstance tickable) {
            _tickingSounds.Remove(tickable);
        }
    }

    public void PlayDelayed(SoundInstance instance, int delay) => _queuedSounds[instance] = _tickCount + delay;

    public void QueueTickingSound(TickableSoundInstance instance) => _queuedTickableSounds.Add(instance);

    public void Stop(SoundInstance instance) {
        if (_instanceToChannel.TryGetValue(instance, out Channel? channel)) {
            channel.Stop();
        }
    }

    /// <summary><c>stop(sound, source)</c>, what the stop sound packet asks for; neither given stops everything.</summary>
    public void Stop(Identifier? sound, SoundCategory? source) {
        foreach (SoundInstance instance in _instanceToChannel.Keys.ToArray()) {
            if ((source == null || instance.Source == source) && (sound == null || instance.Identifier == sound)) {
                Stop(instance);
            }
        }
        if (sound == null && source == null) {
            _queuedSounds.Clear();
        }
    }

    public void StopAll() {
        foreach (SoundInstance instance in _instanceToChannel.Keys.ToArray()) {
            ReleaseInstance(instance);
        }
        _queuedSounds.Clear();
        _queuedTickableSounds.Clear();
        _waitingForData.Clear();
        _waitingForStream.Clear();
        Array.Fill(_gainBySource, 1.0F);
    }

    /// <summary><c>updateSource</c>: the listener is the camera, once a frame.</summary>
    public void UpdateListener(Vector3 position, Vector3 forward, Vector3 up) {
        _device.SetListener(position, forward, up);
        StartReady();
    }

    /// <summary><c>tickInGameSound</c> and <c>ChannelAccess.scheduleTick</c>, once a game tick.</summary>
    public void Tick() {
        if (!_device.Available) {
            return;
        }
        _tickCount++;
        foreach (TickableSoundInstance queued in _queuedTickableSounds) {
            if (queued.CanPlaySound) {
                Play(queued);
            }
        }
        _queuedTickableSounds.Clear();

        foreach (TickableSoundInstance instance in _tickingSounds.ToArray()) {
            if (!instance.CanPlaySound) {
                Stop(instance);
            }
            instance.Tick();
            if (instance.IsStopped) {
                Stop(instance);
            }
            else if (_instanceToChannel.TryGetValue(instance, out Channel? channel)) {
                channel.SetVolume(CalculateVolume(instance.Volume, instance.Source));
                channel.SetPitch(CalculatePitch(instance));
                channel.SetSelfPosition(new Vector3((float)instance.X, (float)instance.Y, (float)instance.Z));
            }
        }

        foreach ((SoundInstance instance, Channel channel) in _instanceToChannel.ToArray()) {
            if (channel.Stopped && _soundDeleteTime.TryGetValue(instance, out int deleteTime) && deleteTime <= _tickCount
                && !_waitingForData.Exists(w => w.Instance == instance) && !_waitingForStream.Exists(w => w.Instance == instance)) {
                if (ShouldLoopManually(instance)) {
                    _queuedSounds[instance] = _tickCount + instance.Delay;
                }
                ReleaseInstance(instance);
            }
            else {
                channel.UpdateStream();
            }
        }

        foreach ((SoundInstance instance, int time) in _queuedSounds.ToArray()) {
            if (_tickCount >= time) {
                if (instance is TickableSoundInstance tickable) {
                    tickable.Tick();
                }
                Play(instance);
                _queuedSounds.Remove(instance);
            }
        }
    }

    public void Dispose() {
        StopAll();
        _buffers.Dispose();
        _device.Dispose();
    }
}

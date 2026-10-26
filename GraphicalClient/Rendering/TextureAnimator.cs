using System.Numerics;
using GraphicalClient.Assets.ResourcePacks;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// Plays animated block textures in the texture array, once per game tick as
/// <c>SpriteContents.AnimationState</c> does: each frame holds for its ticks, and an interpolated
/// animation blends toward the next frame across them. Ticking works out the new pixels; uploading
/// them is a separate step, so it can wait for the GL half of the frame.
/// </summary>
public sealed unsafe class TextureAnimator {
    private sealed class Playing(int layer, TextureAnimation animation) {
        public readonly int Layer = layer;
        public readonly TextureAnimation Animation = animation;
        public int Frame;
        public int SubFrame;
        public bool Dirty = true;

        /// <summary>Each frame's mip chain, built the first time it is shown.</summary>
        public readonly byte[][]?[] Chains = new byte[][]?[animation.Frames.Length];

        /// <summary>Where an interpolated frame is blended, reused tick to tick.</summary>
        public byte[][]? Blended;

        /// <summary>The top level last sent, and how many times it has changed.</summary>
        public byte[]? Shown;
        public int Version;
    }

    private readonly GL _gl;
    private readonly TextureArray _array;
    private readonly List<Playing> _playing = [];
    private readonly Dictionary<int, Playing> _byLayer = new();
    private readonly List<(int Layer, byte[][] Levels)> _pending = [];

    public int Count => _playing.Count;

    public TextureAnimator(GL gl, TextureArray array, IEnumerable<(int Layer, TextureAnimation Animation)> animations) {
        _gl = gl;
        _array = array;
        foreach ((int layer, TextureAnimation animation) in animations) {
            Playing playing = new(layer, animation);
            _playing.Add(playing);
            _byLayer[layer] = playing;
        }
    }

    /// <summary>One game tick. No GL calls.</summary>
    public void Tick() {
        foreach (Playing playing in _playing) {
            (int Index, int Time)[] sequence = playing.Animation.Sequence;
            int old = sequence[playing.Frame].Index;
            playing.SubFrame++;
            if (playing.SubFrame >= sequence[playing.Frame].Time) {
                playing.Frame = (playing.Frame + 1) % sequence.Length;
                playing.SubFrame = 0;
                playing.Dirty |= sequence[playing.Frame].Index != old;
            }
            if (!playing.Dirty && !playing.Animation.Interpolate) {
                continue;
            }
            playing.Dirty = false;
            byte[][] current = ChainOf(playing, sequence[playing.Frame].Index);
            if (playing.Animation.Interpolate) {
                // Blended level by level rather than blending the top level and filtering it down again;
                // the box filter is linear, so the two differ only in rounding.
                byte[][] next = ChainOf(playing, sequence[(playing.Frame + 1) % sequence.Length].Index);
                float progress = (float)playing.SubFrame / sequence[playing.Frame].Time;
                playing.Blended ??= current.Select(level => new byte[level.Length]).ToArray();
                for (int level = 0; level < current.Length; level++) {
                    Blend(current[level], next[level], playing.Blended[level], progress);
                }
                current = playing.Blended;
            }
            _pending.Add((playing.Layer, current));
            playing.Shown = current[0];
            playing.Version++;
        }
    }

    /// <summary>Each byte <c>from + (to - from) * progress</c>, truncated; the vectors do the same float arithmetic as the scalar tail.</summary>
    private static void Blend(byte[] from, byte[] to, byte[] into, float progress) {
        int i = 0;
        if (Vector.IsHardwareAccelerated) {
            Vector<float> scale = new(progress);
            for (; i <= into.Length - Vector<byte>.Count; i += Vector<byte>.Count) {
                Vector.Widen(new Vector<byte>(from, i), out Vector<ushort> from0, out Vector<ushort> from1);
                Vector.Widen(new Vector<byte>(to, i), out Vector<ushort> to0, out Vector<ushort> to1);
                Vector.Narrow(Blend(from0, to0, scale), Blend(from1, to1, scale)).CopyTo(into, i);
            }
        }
        for (; i < into.Length; i++) {
            into[i] = (byte)(from[i] + (to[i] - from[i]) * progress);
        }
    }

    private static Vector<ushort> Blend(Vector<ushort> from, Vector<ushort> to, Vector<float> scale) {
        Vector.Widen(from, out Vector<uint> from0, out Vector<uint> from1);
        Vector.Widen(to, out Vector<uint> to0, out Vector<uint> to1);
        return Vector.Narrow(Blend(from0, to0, scale), Blend(from1, to1, scale));
    }

    private static Vector<uint> Blend(Vector<uint> from, Vector<uint> to, Vector<float> scale) {
        Vector<float> a = Vector.ConvertToSingle(Vector.AsVectorInt32(from)), b = Vector.ConvertToSingle(Vector.AsVectorInt32(to));
        return Vector.AsVectorUInt32(Vector.ConvertToInt32(a + (b - a) * scale));
    }

    /// <summary>
    /// What a layer shows at the array's size, for a copy kept elsewhere; null for a layer that does not
    /// animate or has not ticked. An interpolated layer's pixels are rewritten in place on the next tick,
    /// so a copy is taken whenever the version moves.
    /// </summary>
    public (byte[]? Pixels, int Version) Showing(int layer) =>
        _byLayer.TryGetValue(layer, out Playing? playing) ? (playing.Shown, playing.Version) : (null, 0);

    private byte[][] ChainOf(Playing playing, int frame) =>
        playing.Chains[frame] ??= playing.Animation.FrameLevels(frame, _array.Size, _array.Levels).Select(level => level.Rgba).ToArray();

    /// <summary>Sends what the last ticks changed to the texture array.</summary>
    public void Upload() {
        if (_pending.Count == 0) {
            return;
        }
        _gl.BindTexture(TextureTarget.Texture2DArray, _array.Handle);
        foreach ((int layer, byte[][] levels) in _pending) {
            int size = _array.Size;
            for (int level = 0; level < levels.Length; level++) {
                fixed (byte* p = levels[level]) {
                    _gl.TexSubImage3D(TextureTarget.Texture2DArray, level, 0, 0, layer, (uint)size, (uint)size, 1, PixelFormat.Rgba, PixelType.UnsignedByte, p);
                }
                size = Math.Max(1, size / 2);
            }
        }
        _pending.Clear();
    }
}

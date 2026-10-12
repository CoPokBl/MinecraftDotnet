using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering.Entities;

/// <summary>Where one texture sits in the entity atlas.</summary>
public sealed record EntityTexture(float U0, float V0, float U1, float V1, int Width, int Height) {
    public float U(float u) => U0 + u * (U1 - U0);
    public float V(float v) => V0 + v * (V1 - V0);
}

/// <summary>
/// Entity textures packed into one atlas as they are first asked for, a texel of padding round each so
/// nearest sampling at a cube's edge cannot reach the neighbour. A texture loads on a worker and answers
/// <see cref="Pending"/> until it is done, so a mob is invisible for a frame or two the first time its
/// kind appears rather than stalling the game.
/// </summary>
public sealed unsafe class EntityTextures : IDisposable {
    private const int Size = 4096;

    private readonly GL _gl;
    private readonly ResourcePackSource? _pack;
    private readonly Lock _lock = new();
    private readonly Dictionary<string, EntityTexture?> _known = new();
    private readonly Dictionary<string, Task<TextureImage?>> _loading = new();
    private readonly List<(int X, int Y, TextureImage Image)> _pending = [];
    private int _shelfX, _shelfY, _shelfHeight;

    public uint Handle { get; }

    /// <summary>A white texel, for geometry that is coloured rather than textured.</summary>
    public EntityTexture White { get; }

    /// <summary>The magenta and black checks a texture the pack lacks draws as.</summary>
    public EntityTexture Missing { get; }

    /// <summary>A clear texel: what a texture still loading draws as, which discards every pixel.</summary>
    public EntityTexture Pending { get; }

    public EntityTextures(GL gl, ResourcePackSource? pack) {
        _gl = gl;
        _pack = pack;
        Handle = gl.CreateTexture(TextureTarget.Texture2D);
        gl.TextureStorage2D(Handle, 1, SizedInternalFormat.Rgba8, Size, Size);
        gl.TextureParameter(Handle, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        gl.TextureParameter(Handle, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        gl.TextureParameter(Handle, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
        gl.TextureParameter(Handle, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
        White = Place(new TextureImage(4, 4, Enumerable.Repeat((byte)255, 64).ToArray()))!;
        Missing = Place(MissingImage())!;
        Pending = Place(new TextureImage(1, 1, new byte[4]))!;
    }

    /// <summary>The magenta and black checks, eight texels to a square.</summary>
    public static TextureImage MissingImage() {
        byte[] checks = new byte[16 * 16 * 4];
        for (int i = 0; i < 256; i++) {
            bool magenta = ((i % 16) / 8 + (i / 16) / 8) % 2 == 0;
            checks[i * 4] = checks[i * 4 + 2] = magenta ? (byte)0xF8 : (byte)0;
            checks[i * 4 + 3] = 255;
        }
        return new TextureImage(16, 16, checks);
    }

    /// <summary>
    /// A texture by its identifier as vanilla's renderers name them, <c>minecraft:textures/entity/zombie/zombie.png</c>,
    /// or a downloaded skin's; <see cref="Pending"/> while it loads, then null without a pack or when the pack lacks it.
    /// </summary>
    public EntityTexture? Get(string identifier) => Get(identifier, () => LoadIdentifier(identifier));

    private TextureImage? LoadIdentifier(string identifier) {
        if (Assets.Skins.SkinManager.Texture(identifier) is { } downloaded) {
            return downloaded;
        }
        if (_pack == null) {
            return null;
        }
        Minecraft.Schemas.Identifier id = Minecraft.Schemas.Identifier.Parse(identifier);
        string path = id.Key.EndsWith(".png", StringComparison.Ordinal) ? id.Key : $"textures/{id.Key}.png";
        return _pack.LoadFirstFrame($"assets/{id.Namespace}/{path}");
    }

    /// <summary>
    /// An image the caller loads, packed once under <paramref name="key"/>; <see cref="Pending"/> while
    /// <paramref name="load"/> runs on a worker, then null when it cannot load or fit.
    /// </summary>
    public EntityTexture? Get(string key, Func<TextureImage?> load) {
        lock (_lock) {
            if (_known.TryGetValue(key, out EntityTexture? known)) {
                return known;
            }
            if (!_loading.TryGetValue(key, out Task<TextureImage?>? task)) {
                _loading[key] = Task.Run(load);
                return Pending;
            }
            if (!task.IsCompleted) {
                return Pending;
            }
            _loading.Remove(key);
            EntityTexture? texture = task.IsCompletedSuccessfully && task.Result is { } image ? Place(image) : null;
            _known[key] = texture;
            return texture;
        }
    }

    /// <summary>
    /// <see cref="Get(string, Func{TextureImage?})"/> waited out, for a worker building something that
    /// keeps the texture, where a placeholder would stay for good.
    /// </summary>
    public EntityTexture? GetNow(string key, Func<TextureImage?> load) {
        Task<TextureImage?>? task;
        TaskCompletionSource<TextureImage?>? mine = null;
        lock (_lock) {
            if (_known.TryGetValue(key, out EntityTexture? known)) {
                return known;
            }
            if (!_loading.TryGetValue(key, out task)) {
                mine = new TaskCompletionSource<TextureImage?>();
                task = mine.Task;
                _loading[key] = task;
            }
        }
        // Loaded outside the lock, which the game thread takes every frame.
        if (mine != null) {
            try {
                mine.SetResult(load());
            }
            catch (Exception e) {
                mine.SetException(e);
            }
        }
        try {
            task.Wait();
        }
        catch (AggregateException) {
            // Get answers null for a load that failed.
        }
        return Get(key, load);
    }

    private EntityTexture? Place(TextureImage image) {
        int w = image.Width + 2, h = image.Height + 2;
        if (_shelfX + w > Size) {
            _shelfX = 0;
            _shelfY += _shelfHeight;
            _shelfHeight = 0;
        }
        if (_shelfY + h > Size || w > Size) {
            return null;
        }
        int x = _shelfX + 1, y = _shelfY + 1;
        _shelfX += w;
        _shelfHeight = Math.Max(_shelfHeight, h);
        _pending.Add((x, y, image));
        return new EntityTexture(x / (float)Size, y / (float)Size, (x + image.Width) / (float)Size, (y + image.Height) / (float)Size, image.Width, image.Height);
    }

    /// <summary>New pixels for a placed texture, at its size, sent by the next <see cref="Upload"/>.</summary>
    public void Replace(EntityTexture texture, byte[] rgba) {
        lock (_lock) {
            _pending.Add(((int)MathF.Round(texture.U0 * Size), (int)MathF.Round(texture.V0 * Size), new TextureImage(texture.Width, texture.Height, rgba)));
        }
    }

    public void Upload() {
        lock (_lock) {
            foreach ((int x, int y, TextureImage image) in _pending) {
                fixed (byte* p = image.Rgba) {
                    _gl.TextureSubImage2D(Handle, 0, x, y, (uint)image.Width, (uint)image.Height, PixelFormat.Rgba, PixelType.UnsignedByte, p);
                }
            }
            _pending.Clear();
        }
    }

    public void Dispose() => _gl.DeleteTexture(Handle);
}

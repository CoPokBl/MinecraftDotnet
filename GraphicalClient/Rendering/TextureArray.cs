using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// Every block texture as one layer of a 2D array texture. Layers cannot bleed into each other the
/// way an atlas's neighbours do under mipmapping, so no padding or border tricks are needed. Every
/// layer is the size of the largest texture; smaller ones are scaled up by whole texels.
/// </summary>
public sealed class TextureArray : IDisposable {
    private readonly GL _gl;
    private readonly Dictionary<string, int> _layers = new();

    public uint Handle { get; }
    public int Count { get; }
    public int Size { get; }
    public int Levels { get; }

    /// <param name="levels">
    /// A texture's mipmap levels at the array's size and level count; null makes every texture's with the default
    /// settings, as a still texture without a <c>.mcmeta</c> gets them.
    /// </param>
    public unsafe TextureArray(GL gl, IEnumerable<string> keys, Func<string, TextureImage> images,
        Func<string, TextureImage, int, int, TextureImage[]>? levels = null) {
        _gl = gl;
        List<string> ordered = ["missing", .. keys.Where(k => k != "missing").OrderBy(k => k, StringComparer.Ordinal)];
        Count = ordered.Count;
        TextureImage[] loaded = new TextureImage[Count];
        for (int i = 0; i < Count; i++) {
            loaded[i] = ordered[i] == "missing"
                ? DevArt.MissingTexture()
                : images(ordered[i]);
        }
        Size = loaded.Max(t => Math.Max(t.Width, t.Height));

        Handle = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2DArray, Handle);
        Levels = Math.Min(5, (int)Math.Log2(Size) + 1);
        gl.TexStorage3D(TextureTarget.Texture2DArray, (uint)Levels, SizedInternalFormat.Rgba8, (uint)Size, (uint)Size, (uint)Count);
        for (int layer = 0; layer < Count; layer++) {
            _layers[ordered[layer]] = layer;
            TextureImage[] chain = levels?.Invoke(ordered[layer], loaded[layer], Size, Levels)
                                   ?? Mipmaps.Generate(loaded[layer].Resized(Size), TextureMipSettings.Default, false, Levels);
            for (int level = 0; level < Levels; level++) {
                int size = Math.Max(1, Size >> level);
                fixed (byte* p = chain[level].Rgba) {
                    gl.TexSubImage3D(TextureTarget.Texture2DArray, level, 0, 0, layer, (uint)size, (uint)size, 1,
                        PixelFormat.Rgba, PixelType.UnsignedByte, p);
                }
            }
        }
        gl.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.NearestMipmapLinear);
        gl.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        gl.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureMaxLevel, Levels - 1);
        gl.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        gl.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
    }

    public int LayerOf(string key) => _layers.GetValueOrDefault(key, 0);

    public void Dispose() => _gl.DeleteTexture(Handle);
}

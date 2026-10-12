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

    public unsafe TextureArray(GL gl, IEnumerable<string> keys, Func<string, TextureImage> images) {
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
        int levels = Math.Min(5, (int)Math.Log2(Size) + 1);
        Levels = levels;
        gl.TexStorage3D(TextureTarget.Texture2DArray, (uint)levels, SizedInternalFormat.Rgba8, (uint)Size, (uint)Size, (uint)Count);
        for (int layer = 0; layer < Count; layer++) {
            _layers[ordered[layer]] = layer;
            byte[] data = loaded[layer].Resized(Size).Rgba;
            fixed (byte* p = data) {
                gl.TexSubImage3D(TextureTarget.Texture2DArray, 0, 0, 0, layer, (uint)Size, (uint)Size, 1,
                    PixelFormat.Rgba, PixelType.UnsignedByte, p);
            }
        }
        gl.GenerateMipmap(TextureTarget.Texture2DArray);
        gl.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.NearestMipmapLinear);
        gl.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        gl.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureMaxLevel, levels - 1);
        gl.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        gl.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
    }

    public int LayerOf(string key) => _layers.GetValueOrDefault(key, 0);

    public void Dispose() => _gl.DeleteTexture(Handle);
}

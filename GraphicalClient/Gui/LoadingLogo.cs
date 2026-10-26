using GraphicalClient.Assets.ResourcePacks;
using Silk.NET.OpenGL;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>LoadingOverlay.LogoTexture</c>: the logo the game's own pack supplies, read from that pack whatever packs sit
/// above it and sampled blurred and clamped, as its texture metadata asks. Read on any thread, put in use on the render
/// thread; with no game pack there is none, and the overlay draws this client's lettering instead.
/// </summary>
public sealed unsafe class LoadingLogo(GL gl) : IDisposable {
    public const string Location = "assets/minecraft/textures/gui/title/mojangstudios.png";

    public uint Texture { get; private set; }

    public static TextureImage? Read(Func<byte[]?> file) {
        try {
            return file() is { } png ? Png.Decode(png) : null;
        }
        catch (Exception e) when (e is IOException or InvalidDataException or UnauthorizedAccessException) {
            Console.Error.WriteLine($"Failed to load the loading screen logo: {e.Message}");
            return null;
        }
    }

    public void Set(TextureImage? image) {
        Dispose();
        if (image == null) {
            return;
        }
        Texture = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2D, Texture);
        fixed (byte* p = image.Rgba) {
            gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, (uint)image.Width, (uint)image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
    }

    public void Dispose() {
        if (Texture != 0) {
            gl.DeleteTexture(Texture);
            Texture = 0;
        }
    }
}

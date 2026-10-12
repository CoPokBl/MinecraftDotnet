using System.Numerics;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering.Entities;

/// <summary>The render types that draw the glint: <c>glint</c>, <c>entityGlint</c> and <c>armorEntityGlint</c>.</summary>
public enum GlintType : byte {
    /// <summary>Over an item model, along the quad's atlas coordinates.</summary>
    Item,
    /// <summary>Over an entity model a special item renderer draws, along its texture.</summary>
    Entity,
    /// <summary>Over worn equipment, from the armour glint texture.</summary>
    Armor
}

/// <summary>
/// The enchantment glint's two textures (<c>enchanted_glint_item.png</c> and <c>enchanted_glint_armor.png</c>,
/// or the built in art's stand in), and <c>TextureTransform.setupGlintTexturing</c> for each
/// <see cref="GlintType"/> as of this frame, which a glint's texture coordinates are taken through before
/// they reach a shader.
/// </summary>
public sealed unsafe class EnchantmentGlint : IDisposable {
    private readonly GL _gl;
    private readonly Matrix3x2[] _matrices = new Matrix3x2[3];

    public uint ItemTexture { get; }
    public uint ArmorTexture { get; }

    /// <summary>The <c>glintStrength</c> option, vanilla's <c>GlintAlpha</c>.</summary>
    public float Strength { get; private set; } = 0.75F;

    public EnchantmentGlint(GL gl, ResourcePackSource? pack) {
        _gl = gl;
        ItemTexture = CreateTexture(pack?.LoadFirstFrame("assets/minecraft/textures/misc/enchanted_glint_item.png") ?? DevArt.EnchantmentGlint());
        ArmorTexture = CreateTexture(pack?.LoadFirstFrame("assets/minecraft/textures/misc/enchanted_glint_armor.png") ?? DevArt.EnchantmentGlint());
        Update(0, 0.5, 0.75);
    }

    /// <summary>Both textures are <c>blur</c> in their metadata: linear, and repeating as the scroll needs.</summary>
    private uint CreateTexture(TextureImage image) {
        uint texture = _gl.CreateTexture(TextureTarget.Texture2D);
        _gl.TextureStorage2D(texture, 1, SizedInternalFormat.Rgba8, (uint)image.Width, (uint)image.Height);
        fixed (byte* p = image.Rgba) {
            _gl.TextureSubImage2D(texture, 0, 0, 0, (uint)image.Width, (uint)image.Height, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        _gl.TextureParameter(texture, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        _gl.TextureParameter(texture, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        _gl.TextureParameter(texture, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        _gl.TextureParameter(texture, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
        return texture;
    }

    /// <summary>
    /// <c>setupGlintTexturing(scale)</c>: translated by two offsets that wrap every 110 and 30 seconds at
    /// full speed, turned a tenth of a half turn, then scaled, in that order as column vectors.
    /// </summary>
    /// <param name="millis"><c>Util.getMillis</c>.</param>
    public void Update(long millis, double speed, double strength) {
        Strength = (float)strength;
        long scrolled = (long)(millis * speed * 8.0);
        float layerOffset0 = scrolled % 110000L / 110000.0F;
        float layerOffset1 = scrolled % 30000L / 30000.0F;
        Matrix3x2 turn = Matrix3x2.CreateRotation(MathF.PI / 18) * Matrix3x2.CreateTranslation(-layerOffset0, layerOffset1);
        _matrices[(int)GlintType.Item] = Matrix3x2.CreateScale(8.0F) * turn;
        _matrices[(int)GlintType.Entity] = Matrix3x2.CreateScale(0.5F) * turn;
        _matrices[(int)GlintType.Armor] = Matrix3x2.CreateScale(0.16F) * turn;
    }

    public Matrix3x2 Matrix(GlintType type) => _matrices[(int)type];

    public void Dispose() {
        _gl.DeleteTexture(ItemTexture);
        _gl.DeleteTexture(ArmorTexture);
    }
}

/// <summary>A sink that draws each quad given to it as the glint over that quad, as submitting a model with a glint render type does.</summary>
public sealed class GlintSink(IModelSink inner, GlintType type) : IModelSink {
    public void Quad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, Vector3 normal, ModelDrawState draw) => inner.Glint(corners, uvs, type);
}

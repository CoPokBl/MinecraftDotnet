using System.Numerics;
using System.Text;
using ClientLib.Interaction;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities;
using Minecraft.Data.Items;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Silk.NET.OpenGL;

namespace GraphicalClient.Gui;

/// <summary>
/// Every item's icon in one texture, 64 to a row. Cells are 64 texels so a rendered block icon keeps
/// its detail at large GUI scales; smaller icons are scaled up by whole texels, and mipmaps scale
/// them back down evenly at small ones. The last rows hold icons of stacks whose model, read for the
/// GUI and the local player, chose something other than a plain stack of their item does: drawn the
/// first time that choice is shown, and replaced oldest first once the rows are full.
/// </summary>
public sealed unsafe class ItemAtlas : IDisposable {
    private const int Columns = 64;
    private const int Icon = 64;
    private const int StackRows = 8;
    private const int MipLevels = 7;

    private readonly GL _gl;
    private readonly IResourceSource _source;
    private readonly ItemModelResolver _resolver;
    private readonly Dictionary<Identifier, int> _index = new();
    private readonly int _rows, _firstStackCell;
    private readonly Dictionary<IItem, string?> _defaultKeys = new();
    private readonly Dictionary<string, int> _stackCells = new();
    private readonly string?[] _stackKeys = new string?[StackRows * Columns];
    private readonly StringBuilder _key = new();
    private int _nextStackCell;

    public uint Texture { get; }
    public EnchantmentGlint Glint { get; }

    public ItemAtlas(GL gl, MinecraftRegistry registry, IResourceSource source, ItemModelResolver resolver, EnchantmentGlint glint) {
        _gl = gl;
        _source = source;
        _resolver = resolver;
        Glint = glint;
        List<IItem> items = registry.Items.All.ToList();
        _firstStackCell = (items.Count + Columns - 1) / Columns * Columns;
        _rows = _firstStackCell / Columns + StackRows;
        int width = Columns * Icon, height = _rows * Icon;
        byte[] atlas = new byte[width * height * 4];
        for (int i = 0; i < items.Count; i++) {
            _index[items[i].Identifier] = i;
            byte[] icon = source.ItemIcon(items[i]).Resized(Icon).Rgba;
            int ox = i % Columns * Icon, oy = i / Columns * Icon;
            for (int y = 0; y < Icon; y++) {
                System.Buffer.BlockCopy(icon, y * Icon * 4, atlas, ((oy + y) * width + ox) * 4, Icon * 4);
            }
        }
        Texture = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2D, Texture);
        fixed (byte* p = atlas) {
            gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, (uint)width, (uint)height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        gl.GenerateMipmap(TextureTarget.Texture2D);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMaxLevel, MipLevels - 1);
    }

    public bool TryUv(Identifier item, out (float U0, float V0, float U1, float V1) uv) {
        if (!_index.TryGetValue(item, out int index)) {
            uv = default;
            return false;
        }
        uv = Uv(index);
        return true;
    }

    /// <summary>
    /// A stack's icon as <c>GuiGraphicsExtractor.item</c> resolves it for the local player, and the glint
    /// its layers take; false when its model draws nothing. <paramref name="heldIn"/> is the player's hand
    /// the stack is in and <paramref name="carried"/> whether it is the one on the cursor.
    /// </summary>
    public bool TryUv(ItemStack stack, int seed, Hand? heldIn, bool carried, out (float U0, float V0, float U1, float V1) uv, out FoilType foil) {
        ItemModelOutput output = _resolver.Update(stack, ItemDisplayContext.Gui, _resolver.Player, seed, heldIn, carried);
        foil = FoilType.None;
        if (output.Layers.Count == 0) {
            if (output.Missing && ItemModelProperties.HasFoil(stack)) {
                foil = FoilType.Standard;
            }
            uv = default;
            return output.Missing && TryUv(stack.Type.Identifier, out uv);
        }
        foreach (ItemModelLayer layer in output.Layers) {
            foil = (FoilType)Math.Max((int)foil, (int)layer.Foil);
        }
        string key = Key(output.Layers, stack);
        if (key == DefaultKey(stack.Type)) {
            return TryUv(stack.Type.Identifier, out uv);
        }
        if (!_stackCells.TryGetValue(key, out int cell)) {
            cell = _nextStackCell;
            _nextStackCell = (_nextStackCell + 1) % _stackKeys.Length;
            if (_stackKeys[cell] is { } evicted) {
                _stackCells.Remove(evicted);
            }
            _stackKeys[cell] = key;
            _stackCells[key] = cell;
            Upload(_firstStackCell + cell, _source.ItemIcon(output.Layers, stack) ?? new TextureImage(1, 1, new byte[4]));
        }
        uv = Uv(_firstStackCell + cell);
        return true;
    }

    /// <summary>
    /// <c>appendModelIdentityElement</c>'s list, as far as it changes the icon: the leaves chosen, their
    /// tints and what their special renderers read. The glint is drawn over the icon, so it is left out.
    /// </summary>
    private string Key(List<ItemModelLayer> layers, ItemStack stack) {
        _key.Clear();
        bool special = false;
        foreach ((ItemModelLeaf leaf, uint[] tints, _) in layers) {
            _key.Append(leaf.Id);
            foreach (uint tint in tints) {
                _key.Append(',').Append(tint);
            }
            _key.Append(';');
            special |= leaf.Model.Special != null;
        }
        if (special && _source.SpecialIdentity(layers, stack) is { } identity) {
            _key.Append(identity);
        }
        return _key.ToString();
    }

    /// <summary>The key of the drawing the item's own cell holds; null for an item with no definition.</summary>
    private string? DefaultKey(IItem item) {
        if (_defaultKeys.TryGetValue(item, out string? key)) {
            return key;
        }
        ItemStack stack = new(item);
        if (_resolver.Definition(stack) is { } definition) {
            ItemModelOutput output = new();
            definition.UpdateDefault(output, item);
            key = Key(output.Layers, stack);
        }
        _defaultKeys[item] = key;
        return key;
    }

    /// <summary>
    /// Where a GUI icon's corners, clockwise from the top left, fall on the glint before its texturing:
    /// the front face of a flat item filling the slot, as vanilla draws a generated item there.
    /// </summary>
    public static void GlintUvs(FoilType foil, Span<Vector2> output) {
        ReadOnlySpan<Vector2> uvs = [new(0, 0), new(1, 0), new(1, 1), new(0, 1)];
        ReadOnlySpan<Vector3> positions = [new(0, 1, 8.5F / 16), new(1, 1, 8.5F / 16), new(1, 0, 8.5F / 16), new(0, 0, 8.5F / 16)];
        ItemRenderer.GlintUvs(positions, uvs, Vector3.UnitZ, 16, 16, foil, ItemDisplayContext.Gui, output);
    }

    /// <summary>One cell and its mip chain, each level a box filter of the last, so the rest of the atlas is left alone.</summary>
    private void Upload(int index, TextureImage image) {
        byte[] level = image.Resized(Icon).Rgba;
        int size = Icon, x = index % Columns * Icon, y = index / Columns * Icon;
        for (int mip = 0; mip < MipLevels; mip++) {
            fixed (byte* p = level) {
                _gl.TextureSubImage2D(Texture, mip, x >> mip, y >> mip, (uint)size, (uint)size, PixelFormat.Rgba, PixelType.UnsignedByte, p);
            }
            if (size == 1) {
                break;
            }
            int half = size / 2;
            byte[] next = new byte[half * half * 4];
            for (int j = 0; j < half; j++) {
                for (int i = 0; i < half; i++) {
                    for (int c = 0; c < 4; c++) {
                        int sum = level[((j * 2) * size + i * 2) * 4 + c] + level[((j * 2) * size + i * 2 + 1) * 4 + c]
                                  + level[((j * 2 + 1) * size + i * 2) * 4 + c] + level[((j * 2 + 1) * size + i * 2 + 1) * 4 + c];
                        next[(j * half + i) * 4 + c] = (byte)((sum + 2) / 4);
                    }
                }
            }
            level = next;
            size = half;
        }
    }

    private (float U0, float V0, float U1, float V1) Uv(int index) {
        float u0 = index % Columns / (float)Columns;
        float v0 = index / Columns / (float)_rows;
        return (u0, v0, u0 + 1.0F / Columns, v0 + 1.0F / _rows);
    }

    public void Dispose() => _gl.DeleteTexture(Texture);
}

using Silk.NET.OpenGL;

namespace GraphicalClient.Gui;

/// <summary>
/// The HUD's 9 by 9 status icons, drawn here as pixel art: hearts, food, armour and air, in cells of
/// an atlas. The player's hearts come as <c>Hud.HeartType</c>'s containers and fills, each plain or
/// hardcore, and blinking or not; a fill's half covers only its left side, over the container.
/// </summary>
public sealed unsafe class HudIcons : IDisposable {
    public enum Icon {
        HeartFull, HeartHalf, HeartEmpty,
        FoodFull, FoodHalf, FoodEmpty,
        ArmourFull, ArmourHalf, ArmourEmpty,
        Bubble, BubblePopped
    }

    /// <summary><c>Hud.HeartType</c> less the container, which has its own cells.</summary>
    public enum HeartType { Normal, Poisoned, Withered, Absorbing, Frozen }

    public const int Size = 9;
    private const int AtlasWidth = 128;
    private const int AtlasHeight = 64;
    private const int Columns = AtlasWidth / Size;
    private const int ContainerCells = 4;
    private const int FirstContainer = (int)Icon.BubblePopped + 1;
    private const int FirstFill = FirstContainer + ContainerCells;

    private static readonly (uint Fill, uint Highlight)[] HeartColours = [
        (0xFFE02020, 0xFFFF9090),
        (0xFF6A9A1A, 0xFFB8E060),
        (0xFF2A2A2A, 0xFF707070),
        (0xFFE0B020, 0xFFFFF0A0),
        (0xFF70C0F0, 0xFFE0F8FF)
    ];

    private const uint ContainerColour = 0xFF3A0808;
    private const uint BlinkOutline = 0xFFFFFFFF;

    private static readonly string[] Heart = [
        ".kk...kk.",
        "kffk.kffk",
        "kfhfffffk",
        "kfffffffk",
        "kfffffffk",
        ".kfffffk.",
        "..kfffk..",
        "...kfk...",
        "....k...."
    ];

    /// <summary>The hardcore heart: the same body under horned lobes.</summary>
    private static readonly string[] HardcoreHeart = [
        "k.k...k.k",
        "kkfk.kfkk",
        "kfhfffffk",
        "kfffffffk",
        "kfffffffk",
        ".kfffffk.",
        "..kfffk..",
        "...kfk...",
        "....k...."
    ];

    private static readonly string[] Food = [
        "....kkk..",
        "...kfffk.",
        "..kfhfffk",
        "..kfffffk",
        "..kffffk.",
        ".kbkkkk..",
        "kbbk.....",
        "kbk......",
        ".k......."
    ];

    private static readonly string[] Armour = [
        ".kk...kk.",
        "kffkkkffk",
        "kfhfffffk",
        ".kfffffk.",
        ".kfffffk.",
        ".kfffffk.",
        ".kfffffk.",
        ".kfffffk.",
        "..kkkkk.."
    ];

    private static readonly string[] Bubble = [
        "..kkkkk..",
        ".kfffffk.",
        "kfhfffffk",
        "kfhfffffk",
        "kfffffffk",
        "kfffffffk",
        "kfffffffk",
        ".kfffffk.",
        "..kkkkk.."
    ];

    private readonly GL _gl;
    public uint Texture { get; }

    /// <param name="sprites">A resource pack's HUD sprites, which replace the built in art where the pack has them.</param>
    public HudIcons(GL gl, GuiSprites? sprites = null) {
        _gl = gl;
        byte[] rgba = new byte[AtlasWidth * AtlasHeight * 4];
        Paint(rgba, Icon.HeartFull, Heart, 0xFFE02020, 0xFFFF9090, 0xFFE02020, 1.0F);
        Paint(rgba, Icon.HeartHalf, Heart, 0xFFE02020, 0xFFFF9090, 0xFF3A0808, 0.5F);
        Paint(rgba, Icon.HeartEmpty, Heart, 0xFF3A0808, 0xFF3A0808, 0xFF3A0808, 1.0F);
        Paint(rgba, Icon.FoodFull, Food, 0xFFB5672F, 0xFFE09050, 0xFFB5672F, 1.0F, 0xFFE8E0D0);
        Paint(rgba, Icon.FoodHalf, Food, 0xFFB5672F, 0xFFE09050, 0xFF2A1A10, 0.5F, 0xFFE8E0D0);
        Paint(rgba, Icon.FoodEmpty, Food, 0xFF2A1A10, 0xFF2A1A10, 0xFF2A1A10, 1.0F, 0xFF2A1A10);
        Paint(rgba, Icon.ArmourFull, Armour, 0xFFC8C8C8, 0xFFFFFFFF, 0xFFC8C8C8, 1.0F);
        Paint(rgba, Icon.ArmourHalf, Armour, 0xFFC8C8C8, 0xFFFFFFFF, 0xFF303030, 0.5F);
        Paint(rgba, Icon.ArmourEmpty, Armour, 0xFF303030, 0xFF303030, 0xFF303030, 1.0F);
        Paint(rgba, Icon.Bubble, Bubble, 0xFF5AA0FF, 0xFFE0F0FF, 0xFF5AA0FF, 1.0F);
        Paint(rgba, Icon.BubblePopped, Bubble, 0x40FFFFFF, 0x40FFFFFF, 0x40FFFFFF, 1.0F);
        foreach (bool hardcore in (bool[])[false, true]) {
            string[] shape = hardcore ? HardcoreHeart : Heart;
            foreach (bool blink in (bool[])[false, true]) {
                uint outline = blink ? BlinkOutline : 0xFF000000;
                Paint(rgba, ContainerCell(hardcore, blink), shape, ContainerColour, ContainerColour, ContainerColour, 1.0F, outline: outline);
                foreach (HeartType type in Enum.GetValues<HeartType>()) {
                    (uint fill, uint highlight) = HeartColours[(int)type];
                    Paint(rgba, FillCell(type, hardcore, false, blink), shape, fill, highlight, fill, 1.0F, outline: outline);
                    Paint(rgba, FillCell(type, hardcore, true, blink), shape, fill, highlight, fill, 0.5F, outline: outline, clipRight: true);
                }
            }
        }
        if (sprites is { Available: true }) {
            // Vanilla draws a heart or food icon as its empty background with the fill on top.
            Compose(rgba, sprites, Icon.HeartFull, "hud/heart/container", "hud/heart/full");
            Compose(rgba, sprites, Icon.HeartHalf, "hud/heart/container", "hud/heart/half");
            Compose(rgba, sprites, Icon.HeartEmpty, "hud/heart/container");
            Compose(rgba, sprites, Icon.FoodFull, "hud/food_empty", "hud/food_full");
            Compose(rgba, sprites, Icon.FoodHalf, "hud/food_empty", "hud/food_half");
            Compose(rgba, sprites, Icon.FoodEmpty, "hud/food_empty");
            Compose(rgba, sprites, Icon.ArmourFull, "hud/armor_full");
            Compose(rgba, sprites, Icon.ArmourHalf, "hud/armor_half");
            Compose(rgba, sprites, Icon.ArmourEmpty, "hud/armor_empty");
            Compose(rgba, sprites, Icon.Bubble, "hud/air");
            Compose(rgba, sprites, Icon.BubblePopped, "hud/air_bursting");
        }

        Texture = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2D, Texture);
        fixed (byte* p = rgba) {
            gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, AtlasWidth, AtlasHeight, 0, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
    }

    /// <param name="fill">Colour of the left part, up to <paramref name="split"/> of the width.</param>
    /// <param name="empty">Colour of the fill past the split, which is what makes a half icon.</param>
    /// <param name="clipRight">Leaves everything past the split out, outline included, so the cell below shows there.</param>
    private static void Paint(byte[] rgba, Icon icon, string[] art, uint fill, uint highlight, uint empty, float split, uint bone = 0) =>
        Paint(rgba, (int)icon, art, fill, highlight, empty, split, bone);

    private static void Paint(byte[] rgba, int cell, string[] art, uint fill, uint highlight, uint empty, float split, uint bone = 0,
        uint outline = 0xFF000000, bool clipRight = false) {
        (int originX, int originY) = Origin(cell);
        for (int y = 0; y < Size; y++) {
            string row = art[y];
            for (int x = 0; x < Size && x < row.Length; x++) {
                bool right = x >= Size * split;
                if (right && clipRight) {
                    continue;
                }
                uint colour = row[x] switch {
                    'k' => outline,
                    'f' => right ? empty : fill,
                    'h' => right ? empty : highlight,
                    'b' => bone,
                    _ => 0
                };
                if (colour == 0) {
                    continue;
                }
                int i = ((originY + y) * AtlasWidth + originX + x) * 4;
                rgba[i] = (byte)(colour >> 16);
                rgba[i + 1] = (byte)(colour >> 8);
                rgba[i + 2] = (byte)colour;
                rgba[i + 3] = (byte)(colour >> 24);
            }
        }
    }

    /// <summary>Replaces an icon's cell with pack sprites layered in order, if the pack has all of them.</summary>
    private static void Compose(byte[] rgba, GuiSprites sprites, Icon icon, params string[] layers) {
        Assets.ResourcePacks.TextureImage?[] images = layers.Select(sprites.Image).ToArray();
        if (images.Any(i => i == null)) {
            return;
        }
        (int originX, int originY) = Origin((int)icon);
        for (int y = 0; y < Size; y++) {
            for (int x = 0; x < Size; x++) {
                int o = ((originY + y) * AtlasWidth + originX + x) * 4;
                rgba[o] = rgba[o + 1] = rgba[o + 2] = rgba[o + 3] = 0;
            }
        }
        foreach (Assets.ResourcePacks.TextureImage image in images!) {
            Assets.ResourcePacks.TextureImage cell = image.Resized(Size);
            for (int i = 0; i < Size * Size; i++) {
                if (cell.Rgba[i * 4 + 3] == 0) {
                    continue;
                }
                int o = ((originY + i / Size) * AtlasWidth + originX + i % Size) * 4;
                Array.Copy(cell.Rgba, i * 4, rgba, o, 4);
            }
        }
    }

    public (float U0, float V0, float U1, float V1) Uv(Icon icon) => Uv((int)icon);

    public (float U0, float V0, float U1, float V1) ContainerUv(bool hardcore, bool blink) => Uv(ContainerCell(hardcore, blink));

    public (float U0, float V0, float U1, float V1) HeartUv(HeartType type, bool hardcore, bool half, bool blink) =>
        Uv(FillCell(type, hardcore, half, blink));

    private static int ContainerCell(bool hardcore, bool blink) => FirstContainer + (hardcore ? 2 : 0) + (blink ? 1 : 0);

    private static int FillCell(HeartType type, bool hardcore, bool half, bool blink) =>
        FirstFill + (int)type * 8 + (hardcore ? 4 : 0) + (half ? 2 : 0) + (blink ? 1 : 0);

    private static (int X, int Y) Origin(int cell) => (cell % Columns * Size, cell / Columns * Size);

    private static (float U0, float V0, float U1, float V1) Uv(int cell) {
        (int x, int y) = Origin(cell);
        return (x / (float)AtlasWidth, y / (float)AtlasHeight, (x + Size) / (float)AtlasWidth, (y + Size) / (float)AtlasHeight);
    }

    public void Dispose() => _gl.DeleteTexture(Texture);
}

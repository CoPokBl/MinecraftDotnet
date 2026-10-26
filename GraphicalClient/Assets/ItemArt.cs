namespace GraphicalClient.Assets;

/// <summary>
/// Item icons, 16 by 16 RGBA. A block item is drawn as a small isometric cube from its own block
/// textures; anything else gets a silhouette chosen from its name and tinted by its material.
/// </summary>
public static class ItemArt {
    private const int S = 16;

    /// <param name="top">The block's top texture, 16 by 16 RGBA.</param>
    /// <param name="side">The block's side texture.</param>
    /// <param name="topTint">Multiplies the top face, 0xRRGGBB, for blocks whose art takes a biome colour.</param>
    public static byte[] Cube(byte[] top, byte[] side, uint topTint = 0xFFFFFF, uint sideTint = 0xFFFFFF) {
        top = Tinted(top, topTint);
        side = Tinted(side, sideTint);
        byte[] icon = new byte[S * S * 4];
        for (int py = 0; py < S; py++) {
            for (int px = 0; px < S; px++) {
                float x = px + 0.5F, y = py + 0.5F;
                // Top: origin (8,1), u toward (15,4.5), v toward (1,4.5).
                if (Solve(x - 8, y - 1, 7, 3.5F, -7, 3.5F, out float u, out float v)) {
                    Copy(icon, px, py, top, u, v, 1.0F);
                }
                // Left: origin (1,4.5), u toward (8,8), v straight down.
                else if (Solve(x - 1, y - 4.5F, 7, 3.5F, 0, 7, out u, out v)) {
                    Copy(icon, px, py, side, u, v, 0.8F);
                }
                // Right: origin (8,8), u toward (15,4.5), v straight down.
                else if (Solve(x - 8, y - 8, 7, -3.5F, 0, 7, out u, out v)) {
                    Copy(icon, px, py, side, u, v, 0.6F);
                }
            }
        }
        return icon;
    }

    /// <summary>Solves p = u*a + v*b for u and v, true when both land inside the face.</summary>
    private static bool Solve(float px, float py, float ax, float ay, float bx, float by, out float u, out float v) {
        float det = ax * by - ay * bx;
        u = (px * by - py * bx) / det;
        v = (ax * py - ay * px) / det;
        return u is >= 0 and < 1 && v is >= 0 and < 1;
    }

    private static void Copy(byte[] icon, int px, int py, byte[] texture, float u, float v, float shade) {
        int tx = Math.Clamp((int)(u * S), 0, S - 1), ty = Math.Clamp((int)(v * S), 0, S - 1);
        int src = (ty * S + tx) * 4, dst = (py * S + px) * 4;
        byte alpha = texture[src + 3];
        if (alpha == 0) {
            return;
        }
        icon[dst] = (byte)(texture[src] * shade);
        icon[dst + 1] = (byte)(texture[src + 1] * shade);
        icon[dst + 2] = (byte)(texture[src + 2] * shade);
        icon[dst + 3] = Math.Max(alpha, (byte)200);
    }

    /// <summary>A flat icon from a texture, as plants and torches show in the hotbar.</summary>
    public static byte[] Flat(byte[] texture, uint tint = 0xFFFFFF) => Tinted(texture, tint);

    private static byte[] Tinted(byte[] texture, uint tint) {
        byte[] copy = (byte[])texture.Clone();
        if (tint == 0xFFFFFF) {
            return copy;
        }
        for (int i = 0; i < copy.Length; i += 4) {
            copy[i] = (byte)(copy[i] * ((tint >> 16) & 0xFF) / 255);
            copy[i + 1] = (byte)(copy[i + 1] * ((tint >> 8) & 0xFF) / 255);
            copy[i + 2] = (byte)(copy[i + 2] * (tint & 0xFF) / 255);
        }
        return copy;
    }

    public static byte[] Silhouette(string path, uint fallbackColour) {
        uint material = MaterialColour(path) ?? fallbackColour;
        string[] art = ShapeFor(path);
        byte[] icon = new byte[S * S * 4];
        for (int y = 0; y < S && y < art.Length; y++) {
            for (int x = 0; x < S && x < art[y].Length; x++) {
                uint colour = art[y][x] switch {
                    'k' => 0xFF1A1A1A,
                    'm' => 0xFF000000 | material,
                    'l' => 0xFF000000 | DevArt.Shade(material, 1.25F),
                    'd' => 0xFF000000 | DevArt.Shade(material, 0.7F),
                    'w' => 0xFF6B4A2A,
                    'f' => 0xFF000000 | FillColour(path),
                    _ => 0
                };
                if (colour != 0) {
                    DevArt.Put(icon, y * S + x, colour);
                }
            }
        }
        return icon;
    }

    private static uint? MaterialColour(string path) {
        if (path.StartsWith("wooden_")) return 0x9C7A48;
        if (path.StartsWith("stone_")) return 0x8A8A8A;
        if (path.StartsWith("iron_") || path == "iron_ingot" || path == "shears" || path == "bucket" || path.EndsWith("_bucket")) return 0xD8D8D8;
        if (path.StartsWith("golden_") || path.StartsWith("gold_")) return 0xFAD64A;
        if (path.StartsWith("diamond")) return 0x5DECF5;
        if (path.StartsWith("netherite")) return 0x4A3F45;
        if (path.StartsWith("copper")) return 0xE07850;
        if (path.StartsWith("leather_")) return 0x9B5A33;
        if (path.StartsWith("chainmail_")) return 0xA0A0A0;
        if (path.StartsWith("emerald")) return 0x17DD62;
        if (path.Contains("redstone")) return 0xD01010;
        if (path.Contains("lapis")) return 0x2050D0;
        if (path.Contains("coal") || path == "charcoal") return 0x2A2A2A;
        if (path.Contains("quartz")) return 0xEFE8E0;
        if (path.Contains("amethyst")) return 0x9A5CC6;
        if (path == "stick" || path == "bowl") return 0x8A6A3A;
        if (path is "bone" or "bone_meal" or "sugar") return 0xEDEBDF;
        if (path.Contains("apple") && !path.Contains("golden")) return 0xD02828;
        if (path.Contains("bread") || path.Contains("cookie") || path == "wheat") return 0xC8963C;
        if (path.Contains("carrot")) return 0xF08020;
        if (path.Contains("potato")) return 0xC8A060;
        if (path.StartsWith("cooked_")) return 0x8A5030;
        if (path is "beef" or "porkchop" or "mutton" or "chicken" or "rabbit") return 0xE08080;
        if (path.Contains("cod") || path.Contains("salmon")) return 0x8AA0B0;
        if (path.Contains("melon")) return 0xD84040;
        if (path.Contains("slime")) return 0x70C060;
        if (path.Contains("ender_pearl") || path.Contains("ender_eye")) return 0x2A8070;
        if (path.Contains("string") || path.Contains("feather") || path == "snowball") return 0xF0F0F0;
        if (path.Contains("flint")) return 0x404040;
        if (path.Contains("leather")) return 0x9B5A33;
        return null;
    }

    private static uint FillColour(string path) {
        if (path.StartsWith("water")) return 0x3F76E4;
        if (path.StartsWith("lava")) return 0xE3601B;
        if (path.StartsWith("milk")) return 0xF8F8F8;
        if (path.Contains("powder_snow")) return 0xF0F8F8;
        return 0x30A0C0;
    }

    private static string[] ShapeFor(string path) {
        if (path.EndsWith("_sword")) return Sword;
        if (path.EndsWith("_pickaxe")) return Pickaxe;
        if (path.EndsWith("_axe")) return Axe;
        if (path.EndsWith("_shovel")) return Shovel;
        if (path.EndsWith("_hoe")) return Hoe;
        if (path.EndsWith("_helmet")) return Helmet;
        if (path.EndsWith("_chestplate")) return Chestplate;
        if (path.EndsWith("_leggings")) return Leggings;
        if (path.EndsWith("_boots")) return Boots;
        if (path.EndsWith("_ingot") || path.EndsWith("_scrap") || path == "brick" || path == "nether_brick") return Ingot;
        if (path.EndsWith("_nugget")) return Nugget;
        if (path is "diamond" or "emerald" or "amethyst_shard" or "quartz" or "prismarine_crystals" or "echo_shard" || path.EndsWith("_gem")) return Gem;
        if (path is "bucket" || path.EndsWith("_bucket")) return path == "bucket" ? Bucket : FilledBucket;
        if (path is "stick" or "bone" or "blaze_rod" or "breeze_rod" or "end_rod") return Rod;
        if (path is "bow" or "crossbow") return Bow;
        if (path.Contains("arrow")) return Arrow;
        if (path.EndsWith("_spawn_egg") || path == "egg" || path.EndsWith("_egg")) return Egg;
        if (path.StartsWith("music_disc")) return Disc;
        if (path.Contains("book") || path == "paper" || path.Contains("map")) return Book;
        if (path.Contains("potion") || path.Contains("bottle")) return Bottle;
        if (path.EndsWith("_dye") || path.EndsWith("dust") || path is "gunpowder" or "sugar" or "bone_meal" or "redstone") return Pile;
        return Lump;
    }

    private static readonly string[] Sword = [
        "...........kkk..", "..........kllk..", ".........klmk...", "........klmk....",
        ".......klmk.....", "......klmk......", ".kk..klmk.......", ".kmkklmk........",
        "..kdmmk.........", "...kdk..........", "..kwkdk.........", ".kwk..kk........",
        "kwk.............", "kk..............", "................", "................"];

    private static readonly string[] Pickaxe = [
        "....kkkkkk......", "...klllmmmk.....", "..kmk...kdmk....", ".kk.....kwkmk...",
        ".......kwk.kmk..", "......kwk...kk..", ".....kwk........", "....kwk.........",
        "...kwk..........", "..kwk...........", ".kwk............", "kwk.............",
        "kk..............", "................", "................", "................"];

    private static readonly string[] Axe = [
        ".......kkk......", "......klmmk.....", ".....klmmmmk....", ".....kmmkwmk....",
        "......kkwkk.....", ".......kwk......", "......kwk.......", ".....kwk........",
        "....kwk.........", "...kwk..........", "..kwk...........", ".kwk............",
        "kwk.............", "kk..............", "................", "................"];

    private static readonly string[] Shovel = [
        "...........kkk..", "..........klmmk.", ".........klmmmk.", ".........kmmmk..",
        "........kwkkk...", ".......kwk......", "......kwk.......", ".....kwk........",
        "....kwk.........", "...kwk..........", "..kwk...........", ".kwk............",
        "kwk.............", "kk..............", "................", "................"];

    private static readonly string[] Hoe = [
        "........kkkk....", ".......klmmmk...", "......kkkwk.k...", ".........kwk....",
        "........kwk.....", ".......kwk......", "......kwk.......", ".....kwk........",
        "....kwk.........", "...kwk..........", "..kwk...........", ".kwk............",
        "kwk.............", "kk..............", "................", "................"];

    private static readonly string[] Helmet = [
        "................", "................", "................", "....kkkkkkkk....",
        "...kllmmmmmmk...", "...kmmmmmmmdk...", "...kmmkkkkmdk...", "...kmk....kdk...",
        "...kk......kk...", "................", "................", "................",
        "................", "................", "................", "................"];

    private static readonly string[] Chestplate = [
        "................", "...kkk....kkk...", "..klmmkkkkmmdk..", "..kmmmmmmmmmdk..",
        "..kkkmmmmmmkkk..", "....kmmmmmmk....", "....kmmmmmmk....", "....kmmmmmmk....",
        "....kmmmmmmk....", "....kmmmmmdk....", "....kkkkkkkk....", "................",
        "................", "................", "................", "................"];

    private static readonly string[] Leggings = [
        "................", "...kkkkkkkkkk...", "...klmmmmmmmdk..", "...kmmmmmmmmdk..",
        "...kmmmk.kmmdk..", "...kmmk...kmdk..", "...kmmk...kmdk..", "...kmmk...kmdk..",
        "...kmmk...kmdk..", "...kkkk...kkkk..", "................", "................",
        "................", "................", "................", "................"];

    private static readonly string[] Boots = [
        "................", "................", "................", "................",
        "................", "...kkk....kkk...", "...kmk....kmk...", "...kmk....kmk...",
        "..kmmk...kmmk...", ".klmmk..klmmk...", ".kkkkk..kkkkk...", "................",
        "................", "................", "................", "................"];

    private static readonly string[] Ingot = [
        "................", "................", "................", "................",
        "................", "....kkkkkkkk....", "...kllllllmdk...", "..kllmmmmmmddk..",
        ".kmmmmmmmmmmdk..", ".kddddddddddk...", "..kkkkkkkkkk....", "................",
        "................", "................", "................", "................"];

    private static readonly string[] Nugget = [
        "................", "................", "................", "................",
        "................", "......kkk.......", ".....klmmk......", "....klmmmdk.....",
        "....kmmmddk.....", ".....kdddk......", "......kkk.......", "................",
        "................", "................", "................", "................"];

    private static readonly string[] Gem = [
        "................", "................", ".....kkkkkk.....", "....kllllmmk....",
        "...kllmmmmmdk...", "..kkkkkkkkkkkk..", "...kmmmmmmmdk...", "....kmmmmmdk....",
        ".....kmmmdk.....", "......kmdk......", ".......kk.......", "................",
        "................", "................", "................", "................"];

    private static readonly string[] Bucket = [
        "................", "................", "....kkkkkkkk....", "...kk......kk...",
        "..kk........kk..", "..kmkkkkkkkkmk..", "..kmmmmmmmmmdk..", "...kmmmmmmmdk...",
        "...kmmmmmmmdk...", "....kmmmmmdk....", "....kmmmmmdk....", ".....kkkkkk.....",
        "................", "................", "................", "................"];

    private static readonly string[] FilledBucket = [
        "................", "................", "....kkkkkkkk....", "...kk......kk...",
        "..kk........kk..", "..kmkkkkkkkkmk..", "..kmffffffffmk..", "...kmmmmmmmdk...",
        "...kmmmmmmmdk...", "....kmmmmmdk....", "....kmmmmmdk....", ".....kkkkkk.....",
        "................", "................", "................", "................"];

    private static readonly string[] Rod = [
        "................", "...........kk...", "..........kmlk..", ".........kmlk...",
        "........kmlk....", ".......kmlk.....", "......kmlk......", ".....kmlk.......",
        "....kmlk........", "...kmlk.........", "..kmlk..........", "...kk...........",
        "................", "................", "................", "................"];

    private static readonly string[] Bow = [
        "........kkk.....", "......kkwwk.....", ".....kw..k......", "....kw...k......",
        "...kw....k......", "...kw....k......", "..kw.....k......", "..kw.....k......",
        "..kw.....k......", "...kw....k......", "...kw....k......", "....kw...k......",
        ".....kw..k......", "......kkwwk.....", "........kkk.....", "................"];

    private static readonly string[] Arrow = [
        "................", "...........kkk..", "...........kmk..", "..........kmmk..",
        ".........kwkk...", "........kwk.....", ".......kwk......", "......kwk.......",
        ".....kwk........", "....kwk.........", "..kkwk..........", "..kdk...........",
        "..kk............", "................", "................", "................"];

    private static readonly string[] Egg = [
        "................", "................", "......kkkk......", ".....kllmmk.....",
        "....klmmmmdk....", "....kmmdmmdk....", "...kmmmmmmmdk...", "...kmdmmmdmdk...",
        "...kmmmmmmmdk...", "....kmmmmmdk....", ".....kddddk.....", "......kkkk......",
        "................", "................", "................", "................"];

    private static readonly string[] Disc = [
        "................", "................", ".....kkkkkk.....", "....kddddddk....",
        "...kddmmmmddk...", "..kddmkkkkmddk..", "..kdmk....kmdk..", "..kdmk....kmdk..",
        "..kddmkkkkmddk..", "...kddmmmmddk...", "....kddddddk....", ".....kkkkkk.....",
        "................", "................", "................", "................"];

    private static readonly string[] Book = [
        "................", "................", "...kkkkkkkkkk...", "...kmmmmmmmmlk..",
        "...kmllllllmlk..", "...kmmmmmmmmlk..", "...kmmmmmmmmlk..", "...kmmmmmmmmlk..",
        "...kmmmmmmmmlk..", "...kmmmmmmmmlk..", "...kddddddddkk..", "...kkkkkkkkkk...",
        "................", "................", "................", "................"];

    private static readonly string[] Bottle = [
        "................", "......kkkk......", "......kwwk......", "......kllk......",
        ".....kllllk.....", "....klfffffk....", "...klffffffdk...", "...kfffffffdk...",
        "...kfffffffdk...", "....kffffffk....", ".....kkkkkk.....", "................",
        "................", "................", "................", "................"];

    private static readonly string[] Pile = [
        "................", "................", "................", "................",
        "................", ".......kk.......", "......klmk......", ".....klmmdk.....",
        "....klmmmmdk....", "...klmmmmmmdk...", "...kkkkkkkkkk...", "................",
        "................", "................", "................", "................"];

    private static readonly string[] Lump = [
        "................", "................", "................", "......kkkk......",
        "....kkllmmkk....", "...klllmmmmdk...", "...kllmmmmmdk...", "..klmmmmmmmmdk..",
        "..kmmmmmmmmmdk..", "...kmmmmmmddk...", "...kdmmmmdddk...", "....kkddddkk....",
        "......kkkk......", "................", "................", "................"];
}

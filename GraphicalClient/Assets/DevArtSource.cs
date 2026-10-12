using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Data.Blocks;
using Minecraft.Data.Items;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Assets;

/// <summary>
/// The built in art: a block's look is decided from its generated data (map colour, shape, category)
/// and its name, and every texture is drawn by <see cref="DevArt"/>.
/// </summary>
public sealed class DevArtSource : IResourceSource {
    /// <summary>
    /// <c>MapColor</c>'s base colours by id, the colour a block shows on a map. These are vanilla's
    /// constants, which is why the art matches what a player expects each block to be roughly.
    /// </summary>
    private static readonly uint[] MapColours = [
        0x000000, 0x7FB238, 0xF7E9A3, 0xC7C7C7, 0xFF0000, 0xA0A0FF, 0xA7A7A7, 0x007C00,
        0xFFFFFF, 0xA4A8B8, 0x976D4D, 0x707070, 0x4040FF, 0x8F7748, 0xFFFCF5, 0xD87F33,
        0xB24CD8, 0x6699D8, 0xE5E533, 0x7FCC19, 0xF27FA5, 0x4C4C4C, 0x999999, 0x4C7F99,
        0x7F3FB2, 0x334CB2, 0x664C33, 0x667F33, 0x993333, 0x191919, 0xFAEE4D, 0x5CDBD5,
        0x4A80FF, 0x00D93A, 0x815631, 0x700200, 0xD1B1A1, 0x9F5224, 0x95576C, 0x706C8A,
        0xBA8524, 0x677535, 0xA04D4E, 0x392923, 0x876B62, 0x575C5C, 0x7A4958, 0x4C3E5C,
        0x4C3223, 0x4C522A, 0x8E3C2E, 0x251610, 0xBD3031, 0x943F61, 0x5C191D, 0x167E86,
        0x3A8E8C, 0x562C3E, 0x14B485, 0x646464, 0xD8AF93, 0x7FA796
    ];

    private static readonly HashSet<string> CrossCategories = [
        "flower", "tall_flower", "tall_grass", "short_dry_grass", "tall_dry_grass", "bush", "firefly_bush",
        "dry_vegetation", "mushroom", "nether_roots", "nether_fungus", "nether_sprouts", "sapling", "eyeblossom",
        "wither_rose", "web", "seagrass", "tall_seagrass", "kelp", "kelp_plant", "coral_plant", "base_coral_plant",
        "sugar_cane", "sweet_berry_bush", "double_plant", "bamboo_sapling", "hanging_roots", "weeping_vines",
        "weeping_vines_plant", "twisting_vines", "twisting_vines_plant", "cave_vines", "cave_vines_plant", "crop",
        "carrot", "potato", "beetroot", "nether_wart", "torchflower_crop", "pitcher_crop", "stem", "attached_stem",
        "mangrove_propagule", "spore_blossom", "hanging_moss", "cactus_flower", "torch", "wall_torch",
        "redstone_torch", "redstone_wall_torch", "fire", "soul_fire", "coral_fan", "base_coral_fan",
        "coral_wall_fan", "base_coral_wall_fan", "small_dripleaf", "pointed_dripstone", "amethyst_cluster",
        "tripwire"
    ];

    /// <summary>Thin panels that lie against a face, drawn from their outline shape with see through art.</summary>
    private static readonly HashSet<string> PanelCategories = [
        "glow_lichen", "sculk_vein", "multiface", "vine", "leaf_litter", "flower_bed", "frogspawn", "lily_pad",
        "mossy_carpet", "redstone_wire"
    ];

    private static readonly string[] WoodTypes = [
        "oak", "spruce", "birch", "jungle", "acacia", "dark_oak", "mangrove", "cherry", "pale_oak", "bamboo",
        "crimson", "warped"
    ];

    /// <summary>The light grey that tinted art is drawn in, so the biome colour decides the hue.</summary>
    private const uint Pale = 0xD8D8D8;

    /// <summary>Flower petals by a word in the name, first match wins.</summary>
    private static readonly (string[] Words, uint Colour)[] PetalColours = [
        (["red", "poppy", "rose"], 0xD02828), (["dandelion", "sunflower", "yellow"], 0xF0D020), (["blue", "cornflower", "orchid"], 0x3060E0),
        (["white", "azure", "lily_of"], 0xF0F0F0), (["pink", "peony"], 0xF090C0), (["orange"], 0xF08020), (["allium", "lilac", "purple"], 0xB060D0),
        (["wither"], 0x202020)
    ];

    /// <summary>Ore veins by a word in the name, first match wins.</summary>
    private static readonly (string Word, uint Colour)[] OreColours = [
        ("coal", 0x202020), ("iron", 0xD8AF93), ("copper", 0xE07850), ("gold", 0xFCEE4B), ("redstone", 0xFF1010), ("lapis", 0x2050D0),
        ("diamond", 0x5DECF5), ("emerald", 0x17DD62), ("quartz", 0xEFE8E0), ("debris", 0x654740)
    ];

    /// <summary>Log ends by the wood's name prefix, first match wins.</summary>
    private static readonly (string Prefix, uint Colour)[] WoodColours = [
        ("oak", 0xB8945F), ("spruce", 0x82613A), ("birch", 0xD7CB8D), ("jungle", 0xB88764), ("acacia", 0xBA6337), ("dark_oak", 0x4F3218),
        ("mangrove", 0x773636), ("cherry", 0xE7C3BB), ("pale_oak", 0xE8DEDA), ("crimson", 0x7E3A56), ("warped", 0x398382), ("bamboo", 0xC7B35A)
    ];

    private const string SpritePrefix = "sprite:";
    private const int FireFrames = 16;

    private readonly MinecraftRegistry _registry;
    private readonly Dictionary<string, DevArt.Spec> _specs = new();
    private readonly Dictionary<string, int> _fireSprites = new();
    private readonly SpecialItemIcons _specialIcons = new(DevArtSprites.Image);

    public DevArtSource(MinecraftRegistry registry) {
        _registry = registry;
    }

    public TextureImage Texture(string key) =>
        _specs.TryGetValue(key, out DevArt.Spec spec) ? new TextureImage(DevArt.Size, DevArt.Size, DevArt.Draw(spec)) : DevArt.MissingTexture();

    public uint ColourOf(string identifierPath) => HsvToRgb(DevArt.Hash(identifierPath) % 360, 0.55F, 0.85F);

    public TextureImage ItemIcon(IItem item) {
        if (DevArtItemModels.Definition(item.Identifier) is { } definition) {
            ItemModelOutput output = new();
            definition.UpdateDefault(output, item);
            if (SpecialIcon(output.Layers, null) is { } icon) {
                return icon;
            }
        }
        return new TextureImage(16, 16, DrawItemIcon(item));
    }

    public ItemModelNode? ItemDefinition(Identifier modelId) => DevArtItemModels.Definition(modelId);

    public TextureImage? ItemIcon(IReadOnlyList<ItemModelLayer> layers, ItemStack stack) => SpecialIcon(layers, stack);

    public string? SpecialIdentity(IReadOnlyList<ItemModelLayer> layers, ItemStack stack) => _specialIcons.Identity(layers.Select(l => l.Leaf.Model), stack);

    private TextureImage? SpecialIcon(IReadOnlyList<ItemModelLayer> layers, ItemStack? stack) {
        List<IconQuad> quads = [];
        foreach (ItemModelLayer layer in layers) {
            if (layer.Leaf.Model.Special is { } special) {
                quads.AddRange(_specialIcons.Quads(special, layer.Leaf.Model.Local, stack));
            }
        }
        return layers.Count == 0 || quads.Count == 0 ? null : IconRasterizer.Render(quads, layers[0].Leaf.Model.Gui, layers[0].Leaf.Model.SideLit, 64);
    }

    private byte[] DrawItemIcon(IItem item) {
        string path = item.Identifier.Key;
        if (item.CorrespondingBlock is { } blockId && _registry.Blocks.Contains(blockId)) {
            BlockAppearance appearance = Appearance(_registry.Blocks[blockId]);
            // An item has no biome, so tinted art takes a temperate default as vanilla's item colours do.
            uint tint = appearance.Tint switch {
                TintKind.Grass => 0x7CBD6B,
                TintKind.Foliage => 0x48B518,
                TintKind.Water => 0x3F76E4,
                _ => 0xFFFFFF
            };
            uint TintOf(Face face) => (appearance.TintFaces & (1 << (int)face)) != 0 ? tint : 0xFFFFFF;
            switch (appearance.Geometry) {
                case BlockGeometry.Cross:
                    return ItemArt.Flat(Texture(appearance.Textures[(int)Face.North]).Rgba, tint);
                case BlockGeometry.Shape:
                    return ItemArt.Cube(Texture(appearance.Textures[(int)Face.Up]).Rgba, Texture(appearance.Textures[(int)Face.North]).Rgba,
                        TintOf(Face.Up), TintOf(Face.North));
            }
        }
        return ItemArt.Silhouette(path, ColourOf(path));
    }

    /// <summary>
    /// <c>ModelBakery.FIRE_0</c> and <c>FIRE_1</c> are drawn as animated flames, two seeds apart; any other
    /// sprite is the missing checks.
    /// </summary>
    public string SpriteKey(Identifier sprite) {
        string key = SpritePrefix + sprite;
        if (sprite.Namespace == "minecraft" && sprite.Key is "block/fire_0" or "block/fire_1") {
            int seed = sprite.Key == "block/fire_0" ? 0x0F1E : 0x0F1F;
            _fireSprites[key] = seed;
            Register(key, new DevArt.Spec(DevArt.Style.Fire, 0, 0, seed));
        }
        return key;
    }

    public TextureAnimation? Animation(string key) {
        if (!_fireSprites.TryGetValue(key, out int seed)) {
            return null;
        }
        return new TextureAnimation(
            [..Enumerable.Range(0, FireFrames).Select(frame => new TextureImage(DevArt.Size, DevArt.Size, DevArt.Draw(new DevArt.Spec(DevArt.Style.Fire, 0, (uint)frame, seed))))],
            [..Enumerable.Range(0, FireFrames).Select(frame => (frame, 1))], false);
    }

    private string Register(string key, DevArt.Spec spec) {
        _specs.TryAdd(key, spec);
        return key;
    }

    public BlockAppearance Appearance(IBlock state) {
        string path = state.Identifier.Key;
        string category = state.Category.Key;

        if (state.Air || path is "barrier" or "light" or "structure_void" or "moving_piston" or "end_gateway"
            || category is "end_portal" or "bubble_column" || Rendering.BlockEntities.BlockEntityRenderers.DrawsWholeBlock(state)) {
            return BlockAppearance.Invisible;
        }

        int seed = DevArt.Hash(path);
        uint colour = BaseColour(state, path);

        if (path == "water") {
            string tex = Register("water", new DevArt.Spec(DevArt.Style.Water, 0xE8E8E8, 0, seed));
            return new BlockAppearance(BlockGeometry.Fluid, RenderLayer.Translucent, Six(tex), Tint: TintKind.Water);
        }
        if (path == "lava") {
            string tex = Register("lava", new DevArt.Spec(DevArt.Style.Lava, 0xE3601B, 0, seed));
            return new BlockAppearance(BlockGeometry.Fluid, RenderLayer.Solid, Six(tex), true);
        }

        if (CrossCategories.Contains(category) || path.EndsWith("_sapling") || path is "dead_bush" or "short_grass" or "fern" or "large_fern" or "tall_grass" or "cobweb") {
            return CrossAppearance(path, category, colour, seed);
        }

        RenderLayer layer = RenderLayer.Solid;
        DevArt.Style style = DevArt.Style.Noise;
        uint accent = DevArt.Shade(colour, 0.6F);
        TintKind tint = TintKind.None;

        if (PanelCategories.Contains(category)) {
            uint panel = category switch {
                "vine" => Pale,
                "redstone_wire" => 0xB01010u,
                _ => colour
            };
            string panelKey = Register(path + ":panel", new DevArt.Spec(DevArt.Style.Leaves, panel, 0, seed));
            return new BlockAppearance(BlockGeometry.Shape, RenderLayer.Cutout, Six(panelKey), Tint: category == "vine" ? TintKind.Foliage : TintKind.None);
        }

        if (path.Contains("glass")) {
            bool stained = path.Contains("stained") || path == "tinted_glass";
            layer = stained ? RenderLayer.Translucent : RenderLayer.Cutout;
            style = DevArt.Style.Glass;
            colour = stained ? (0x90u << 24) | (colour & 0xFFFFFF) : 0xFFD8F0F8;
        }
        else if (path.Contains("leaves")) {
            layer = RenderLayer.Cutout;
            style = DevArt.Style.Leaves;
            colour = path switch {
                "birch_leaves" => 0x80A755,
                "spruce_leaves" => 0x619961,
                "cherry_leaves" => 0xE8A8C8,
                "azalea_leaves" or "flowering_azalea_leaves" => 0x6E8F33,
                "pale_oak_leaves" => 0x8C9488,
                _ => Pale
            };
            tint = colour == Pale ? TintKind.Foliage : TintKind.None;
        }
        else if (path is "ice" or "frosted_ice" or "slime_block" or "honey_block") {
            layer = RenderLayer.Translucent;
            style = DevArt.Style.Smooth;
            colour = (0xA8u << 24) | (colour & 0xFFFFFF);
        }
        else if (path == "nether_portal") {
            layer = RenderLayer.Translucent;
            style = DevArt.Style.Water;
            colour = 0xC07A2BE0;
        }
        else if (path.EndsWith("_ore") || path is "ancient_debris" or "gilded_blackstone") {
            style = DevArt.Style.Ore;
            accent = OreColour(path);
            colour = path.StartsWith("deepslate") ? 0x4D4D52u : path.StartsWith("nether") || path == "ancient_debris" ? 0x6F3333u : 0x7D7D7Du;
        }
        else if (path.Contains("brick")) {
            style = DevArt.Style.Bricks;
            accent = DevArt.Mix(colour, 0xB0A890, 0.6F);
        }
        else if (path.Contains("tiles") || path.StartsWith("chiseled_")) {
            style = DevArt.Style.Tiles;
        }
        else if (path.Contains("planks") || (WoodTypes.Any(w => path.StartsWith(w + "_")) && (category is "stair" or "slab" or "fence" or "fence_gate" or "pressure_plate" or "button" or "standing_sign" or "wall_sign" or "shelf"))) {
            style = DevArt.Style.Planks;
        }
        else if (path.Contains("sand") || path.Contains("gravel") || path.Contains("concrete_powder") || path is "suspicious_sand" or "suspicious_gravel") {
            style = DevArt.Style.Sand;
        }
        else if (path.Contains("wool") || path.Contains("carpet")) {
            style = DevArt.Style.Wool;
        }
        else if (path.Contains("concrete") || path.Contains("terracotta") || path.Contains("smooth") || path.Contains("polished")) {
            style = DevArt.Style.Smooth;
        }
        else if (category is "rail" or "powered_rail" or "detector_rail") {
            layer = RenderLayer.Cutout;
            style = DevArt.Style.Rail;
            colour = 0x6B5233;
            accent = 0x9A9A9A;
        }
        else if (category == "ladder") {
            layer = RenderLayer.Cutout;
            style = DevArt.Style.Ladder;
        }
        else if (category is "door" or "weathering_copper_door") {
            style = DevArt.Style.Door;
        }
        else if (category is "trapdoor" or "weathering_copper_trapdoor") {
            layer = RenderLayer.Cutout;
            style = DevArt.Style.Trapdoor;
        }
        else if (category is "iron_bars" or "weathering_copper_bar" or "chain" or "weathering_copper_chain" or "scaffolding" or "lantern" or "weathering_lantern") {
            layer = RenderLayer.Cutout;
            style = DevArt.Style.Machine;
        }

        bool emissive = state.LightEmission >= 14 && path is not ("beacon" or "conduit" or "end_rod");

        // Columns: a log's end grain faces along its axis, everything else is bark.
        if (category is "rotated_pillar" or "infested_rotated_pillar" or "hay" || path.EndsWith("_log") || path.EndsWith("_stem") || path.Contains("basalt")) {
            bool wood = path.EndsWith("_log") || path.EndsWith("_stem") || path.EndsWith("_wood") || path.EndsWith("_hyphae");
            bool allBark = path.EndsWith("_wood") || path.EndsWith("_hyphae");
            uint inner = wood ? WoodColour(path) : colour;
            string side = Register(path + ":side", new DevArt.Spec(wood ? DevArt.Style.LogSide : style == DevArt.Style.Noise ? DevArt.Style.Smooth : style, colour, accent, seed));
            string end = allBark ? side : Register(path + ":end", new DevArt.Spec(wood ? DevArt.Style.LogEnd : DevArt.Style.Tiles, inner, colour, seed));
            string axis = StateProperties.Get(state, "axis") ?? "y";
            string[] faces = axis switch {
                "x" => [side, side, side, side, end, end],
                "z" => [side, side, end, end, side, side],
                _ => [end, end, side, side, side, side]
            };
            return new BlockAppearance(BlockGeometry.Shape, layer, faces, emissive);
        }

        if (path is "grass_block" or "podzol" or "mycelium" or "crimson_nylium" or "warped_nylium") {
            uint dirt = path.EndsWith("nylium") ? 0x6F3333u : 0x8B6343u;
            bool snowy = StateProperties.Get(state, "snowy") == "true";
            uint top = path switch {
                "grass_block" => snowy ? 0xF0F8F8u : Pale,
                "podzol" => 0x7A5A2Bu,
                "mycelium" => 0x7B6B7Fu,
                _ => colour
            };
            string topKey = Register(path + ":top" + top, new DevArt.Spec(DevArt.Style.GrassTop, top, 0, seed));
            // One texture per face cannot tint only the side's fringe, so the side keeps a fixed green.
            uint fringe = top == Pale ? 0x6AA84Fu : top;
            string sideKey = Register(path + ":side" + fringe, new DevArt.Spec(DevArt.Style.GrassSide, dirt, fringe, seed));
            string bottom = Register("dirt", new DevArt.Spec(DevArt.Style.Noise, 0x8B6343, 0, DevArt.Hash("dirt")));
            return new BlockAppearance(BlockGeometry.Shape, layer, [bottom, topKey, sideKey, sideKey, sideKey, sideKey],
                Tint: path == "grass_block" && !snowy ? TintKind.Grass : TintKind.None, TintFaces: 1 << (int)Face.Up);
        }

        if (path is "furnace" or "blast_furnace" or "smoker" or "dispenser" or "dropper" or "observer" or "carved_pumpkin" or "jack_o_lantern" or "crafter" or "beehive" or "bee_nest" or "loom") {
            string sideKey = Register(path + ":side", new DevArt.Spec(DevArt.Style.Machine, colour, accent, seed));
            uint faceColour = path is "jack_o_lantern" ? 0xFFD040u : path is "carved_pumpkin" ? 0x3A2410u : 0x202020u;
            string front = Register(path + ":front", new DevArt.Spec(DevArt.Style.MachineFront, colour, faceColour, seed));
            string[] faces = Six(sideKey);
            faces[Directions.Parse(StateProperties.Get(state, "facing")) ?? (int)Face.North] = front;
            return new BlockAppearance(BlockGeometry.Shape, layer, faces, emissive);
        }

        if (path is "crafting_table" or "bookshelf" or "tnt" or "cartography_table" or "fletching_table" or "smithing_table") {
            string sideKey = Register(path + ":side", new DevArt.Spec(DevArt.Style.MachineFront, colour, path == "tnt" ? 0xF0F0F0u : DevArt.Shade(colour, 0.5F), seed));
            string topKey = Register(path + ":top", new DevArt.Spec(DevArt.Style.Tiles, path == "tnt" ? 0xD03020u : colour, 0, seed));
            return new BlockAppearance(BlockGeometry.Shape, layer, [topKey, topKey, sideKey, sideKey, sideKey, sideKey]);
        }

        string key = Register(path, new DevArt.Spec(style, colour, accent, seed));
        return new BlockAppearance(BlockGeometry.Shape, layer, Six(key), emissive, tint);
    }

    private BlockAppearance CrossAppearance(string path, string category, uint colour, int seed) {
        DevArt.Spec spec;
        if (category is "torch" or "wall_torch" or "redstone_torch" or "redstone_wall_torch") {
            uint flame = category.StartsWith("redstone") ? 0xFF2020u : path.Contains("soul") ? 0x60E0F0u : path.Contains("copper") ? 0x70F0A0u : 0xFFD040u;
            spec = new DevArt.Spec(DevArt.Style.Torch, 0x7A5A33, flame, seed);
        }
        else if (category is "fire" or "soul_fire") {
            spec = new DevArt.Spec(DevArt.Style.Plant, category == "soul_fire" ? 0x40D0E0u : 0xFF9020u, 0, seed);
        }
        else if (category is "flower" or "tall_flower" or "wither_rose" or "eyeblossom" or "flower_bed" or "cactus_flower") {
            spec = new DevArt.Spec(DevArt.Style.Flower, 0x4F8F2F, FlowerColour(path, colour), seed);
        }
        else if (category is "crop" or "carrot" or "potato" or "beetroot" or "nether_wart" or "torchflower_crop" or "pitcher_crop" or "stem" or "attached_stem" or "sweet_berry_bush") {
            uint head = path switch {
                "wheat" => 0xD8C060, "carrots" => 0xF08020, "potatoes" => 0xC8A060, "beetroots" => 0xA02030,
                "nether_wart" => 0xA02020, "sweet_berry_bush" => 0xC02040, _ => 0x80C040
            };
            spec = new DevArt.Spec(DevArt.Style.Crop, 0x5F9F2F, head, seed);
        }
        else if (category == "web") {
            spec = new DevArt.Spec(DevArt.Style.Glass, 0xFFE8E8E8, 0, seed);
        }
        else {
            uint plant = colour == 0 ? 0x5F9F2Fu : colour;
            if (path is "short_grass" or "tall_grass" or "fern" or "large_fern" or "sugar_cane") {
                plant = Pale;
            }
            spec = new DevArt.Spec(DevArt.Style.Plant, plant, 0, seed);
        }
        string key = category == "fire" ? SpriteKey("minecraft:block/fire_0") : Register(path + ":cross", spec);
        bool emissive = category is "torch" or "wall_torch" or "fire" or "soul_fire";
        bool grassy = path is "short_grass" or "tall_grass" or "fern" or "large_fern" or "sugar_cane";
        return new BlockAppearance(BlockGeometry.Cross, RenderLayer.Cutout, Six(key), emissive, grassy ? TintKind.Grass : TintKind.None);
    }

    private static uint FlowerColour(string path, uint mapColour) {
        foreach ((string[] words, uint colour) in PetalColours) {
            if (words.Any(path.Contains)) {
                return colour;
            }
        }
        return mapColour == 0 ? 0xE0E040 : mapColour;
    }

    private static uint OreColour(string path) {
        foreach ((string word, uint colour) in OreColours) {
            if (path.Contains(word)) {
                return colour;
            }
        }
        return 0xFFFFFF;
    }

    private static uint WoodColour(string path) {
        if (path.StartsWith("stripped_")) {
            path = path["stripped_".Length..];
        }
        foreach ((string prefix, uint colour) in WoodColours) {
            if (path.StartsWith(prefix)) {
                return colour;
            }
        }
        return 0xB8945F;
    }

    private uint BaseColour(IBlock state, string path) {
        int id = state.MapColorId;
        // Seagrass and kelp map as water, which would draw them in the colour of what they stand in.
        const int waterMapColour = 12;
        if (id == waterMapColour && path != "water" && path != "bubble_column") {
            return 0x3E8A3A;
        }
        if (id > 0 && id < MapColours.Length) {
            return MapColours[id];
        }
        return ColourOf(path);
    }

    private static string[] Six(string key) => [key, key, key, key, key, key];

    private static uint HsvToRgb(float hue, float saturation, float value) {
        float c = value * saturation;
        float x = c * (1 - Math.Abs(hue / 60.0F % 2 - 1));
        float m = value - c;
        (float r, float g, float b) = hue switch {
            < 60 => (c, x, 0F),
            < 120 => (x, c, 0F),
            < 180 => (0F, c, x),
            < 240 => (0F, x, c),
            < 300 => (x, 0F, c),
            _ => (c, 0F, x)
        };
        return (uint)((int)((r + m) * 255) << 16 | (int)((g + m) * 255) << 8 | (int)((b + m) * 255));
    }
}

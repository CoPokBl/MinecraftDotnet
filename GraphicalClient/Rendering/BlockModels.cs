using System.Numerics;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Shapes;
using NBT;
using NBT.Tags;

namespace GraphicalClient.Rendering;

/// <summary>A box in block local coordinates, as floats for the mesher.</summary>
public readonly record struct ModelBox(float MinX, float MinY, float MinZ, float MaxX, float MaxY, float MaxZ);

/// <summary>A resource pack quad, ready for the mesher: positions in block space, texture coordinates 0 to 1.</summary>
public sealed class MeshQuad {
    public required Vector3[] Positions;
    public required Vector2[] Uvs;
    public ushort Texture;
    public RenderLayer Layer;

    /// <summary>The <see cref="Face"/> whose neighbour hides this quad, or -1.</summary>
    public sbyte Cull = -1;

    /// <summary>The <see cref="Face"/> an axis aligned quad faces, or <see cref="SectionMesh.Unaligned"/>.</summary>
    public byte Facing;

    /// <summary>The <see cref="Face"/> nearest the quad's normal, which aligned or not it is shaded as.</summary>
    public byte Direction;

    /// <summary>Lies in the plane of the block's face on its facing side, so it is lit from the block beyond.</summary>
    public bool OnBoundary;

    public TintSource Tint;

    /// <summary>Lit as a plant, from either side: the model shades it as facing up, as a cross's and a vine's planes are.</summary>
    public bool Plant;

    /// <summary>The element's <c>light_emission</c>, which <c>putBlockBakedQuad</c> raises the quad's light to.</summary>
    public byte Emission;

    /// <summary>The element's <c>shade_direction_override</c>, or -1 to be shaded as <see cref="Direction"/>.</summary>
    public sbyte ShadeOverride = -1;

    /// <summary>The <see cref="Face"/> <c>getDirectionalBrightness</c> shades the quad as.</summary>
    public int ShadeDirection => ShadeOverride >= 0 ? ShadeOverride : Direction;
}

/// <summary>One of a part's weighted alternatives.</summary>
public sealed class MeshOption {
    public required MeshQuad[] Quads;
    public int Weight;
    public bool AmbientOcclusion;
}

/// <summary>A set of alternatives of which one is drawn; see <see cref="BakedBlockModel.Choose"/> for how.</summary>
public sealed class MeshPart {
    public required MeshOption[] Options;
    public int TotalWeight;
}

/// <summary>Which <c>skipRendering</c> override a block's class inherits, the nearest up its chain.</summary>
public enum SkipRendering : byte {
    None,

    /// <summary><c>HalfTransparentBlock</c> and <c>PowderSnowBlock</c>: hidden against the same block.</summary>
    SameBlock,

    /// <summary><c>IronBarsBlock</c>: against the same block or other bars, vertically, or where both connect.</summary>
    Bars,

    /// <summary><c>MangroveRootsBlock</c>: vertically against mangrove roots.</summary>
    MangroveRoots
}

/// <summary>Everything the mesher needs about one block state, flattened so a worker thread reads arrays.</summary>
public sealed class BlockModel {
    public BlockGeometry Geometry;
    public RenderLayer Layer;
    public ushort[] TextureLayers = new ushort[6];
    public ModelBox[] Boxes = [];
    public bool FullCube;

    /// <summary>Bit per <see cref="Face"/>: this state's occlusion shape covers that whole face of the cube.</summary>
    public byte OccludesFaces;

    /// <summary>The occlusion shape's boxes, none for a state that does not occlude.</summary>
    public ModelBox[] OcclusionBoxes = [];

    /// <summary>Bit per <see cref="Face"/> whose <c>getFaceOcclusionShape</c> is <c>Shapes.block()</c>, which hides a neighbour's face outright.</summary>
    public byte BlockFaces;

    /// <summary>Bit per <see cref="Face"/> whose <c>getFaceOcclusionShape</c> is empty.</summary>
    public byte EmptyFaces = 0x3F;

    /// <summary><c>getShadeBrightness</c>: how dark the state makes the smooth light corners around it.</summary>
    public float ShadeBrightness = 1.0F;

    /// <summary><c>isSolidRender</c>.</summary>
    public bool SolidRender;

    /// <summary><c>isLightPermeable</c>: a smooth light corner may look past it to the diagonal.</summary>
    public bool LightPermeable = true;

    /// <summary><c>isCollisionShapeFullBlock</c>.</summary>
    public bool CollisionShapeFullBlock;

    /// <summary><c>emissiveRendering</c>: lit at full brightness whatever the light around it, as magma is.</summary>
    public bool EmissiveRendering;

    /// <summary><c>isSolid</c>, the legacy solidity a fluid's corner height asks of its neighbours.</summary>
    public bool Solid;

    /// <summary>A <c>HalfTransparentBlock</c> or <c>LeavesBlock</c>, which water's side shows its overlay sprite against.</summary>
    public bool Overlay;

    public SkipRendering Skip;

    /// <summary>In the <c>bars</c> block tag.</summary>
    public bool InBarsTag;

    /// <summary>For <see cref="SkipRendering.Bars"/>: bit per horizontal <see cref="Face"/> whose connection property is true.</summary>
    public byte Connections;

    public TintKind Tint;
    public byte TintFaces;

    /// <summary>A colour fixed by the state rather than the biome, per <see cref="Face"/>: spruce and birch leaves, redstone.</summary>
    public uint[] FixedTints = [0xFFFFFF, 0xFFFFFF, 0xFFFFFF, 0xFFFFFF, 0xFFFFFF, 0xFFFFFF];
    public bool HasOffset;
    public BlockInfo Info = null!;

    /// <summary>Block identity, for the same-block culling glass and fluids use.</summary>
    public int BlockKey;

    /// <summary>Water to draw alongside the block: water itself, and anything waterlogged.</summary>
    public bool HasWater;
    public bool IsLava;

    /// <summary>The fluid's <c>level</c> property, 0 for a source and 8 and up for falling.</summary>
    public int FluidLevel;

    /// <summary>For <see cref="BlockGeometry.Model"/>: what is drawn, one entry per part.</summary>
    public MeshPart[] Parts = [];
    public bool Multipart;

    /// <summary><c>getLightEmission</c>; <c>tesselateBlock</c> lights a block that gives any off flat rather than smooth.</summary>
    public int LightEmission;

    /// <summary>
    /// The options drawn at a world position, <c>ModelBlockRenderer.tesselateBlock</c>'s draw: the random
    /// is seeded from the position, a weighted part draws one entry, and a multipart draws a long it
    /// reseeds with before each part.
    /// </summary>
    public void Choose(int x, int y, int z, Span<MeshOption> chosen) {
        bool random = false;
        foreach (MeshPart part in Parts) {
            random |= part.Options.Length > 1;
        }
        if (!random) {
            for (int i = 0; i < Parts.Length; i++) {
                chosen[i] = Parts[i].Options[0];
            }
            return;
        }
        JavaRandom rng = new(JavaRandom.PositionSeed(x, y, z));
        long partSeed = Multipart ? rng.NextLong() : 0;
        for (int i = 0; i < Parts.Length; i++) {
            if (Multipart) {
                rng.SetSeed(partSeed);
            }
            MeshPart part = Parts[i];
            if (part.Options.Length == 1) {
                chosen[i] = part.Options[0];
                continue;
            }
            int selection = rng.NextInt(part.TotalWeight);
            MeshOption pick = part.Options[^1];
            foreach (MeshOption option in part.Options) {
                selection -= option.Weight;
                if (selection < 0) {
                    pick = option;
                    break;
                }
            }
            chosen[i] = pick;
        }
    }
}

/// <summary>Resolves every block state's look once, at startup.</summary>
public sealed class BlockModels {
    public BlockModel[] ByState { get; }
    public TextureArray Textures { get; }

    /// <summary>The texture array layers that animate, and how.</summary>
    public List<(int Layer, TextureAnimation Animation)> Animations { get; } = [];

    /// <summary><c>ModelBakery.FIRE_0</c>, the flame on a burning entity and the first person fire overlay.</summary>
    public static readonly Identifier Fire0 = "minecraft:block/fire_0";

    /// <summary><c>ModelBakery.FIRE_1</c>.</summary>
    public static readonly Identifier Fire1 = "minecraft:block/fire_1";

    private static readonly Identifier BarsTag = "minecraft:bars";

    /// <summary>Sprites code draws, which go in the array whether or not a block model names them.</summary>
    private static readonly Identifier[] CodeSprites = [Fire0, Fire1];

    private readonly Dictionary<Identifier, (int Layer, TextureImage Image)> _sprites = new();
    private readonly IResourceSource _source;
    private readonly string[] _particles;

    /// <summary>One of the sprites code draws: its layer, and its pixels before any animation.</summary>
    public (int Layer, TextureImage Image) Sprite(Identifier sprite) => _sprites[sprite];

    /// <summary><c>BlockStateModelSet.getParticleMaterial</c>: a state's particle sprite, its layer and its pixels before any animation.</summary>
    public (int Layer, TextureImage Image) Particle(uint stateId) {
        string key = _particles[stateId];
        return (Textures.LayerOf(key), key == "missing" ? MissingImage() : _source.Texture(key));
    }

    private static TextureImage MissingImage() => new(1, 1, [0xF8, 0, 0xF8, 0xFF]);

    public BlockModels(MinecraftRegistry registry, IResourceSource source,
        Func<IEnumerable<string>, Func<string, TextureImage>, Func<string, TextureImage, int, int, TextureImage[]>, TextureArray> buildTextures) {
        int count = (int)registry.Blocks.StatesCount;
        _source = source;
        _particles = new string[count];
        ByState = new BlockModel[count];
        BlockAppearance[] appearances = new BlockAppearance[count];
        HashSet<string> keys = [];
        Dictionary<string, int> blockKeys = new();

        for (uint state = 0; state < count; state++) {
            IBlock block = registry.Blocks.GetByStateId(state);
            BlockAppearance appearance = source.Appearance(block);
            appearances[state] = appearance;
            foreach (string key in appearance.Textures) {
                if (key.Length > 0) {
                    keys.Add(key);
                }
            }
            string north = appearance.Textures[(int)Face.North];
            _particles[state] = appearance.Particle ?? (north.Length > 0 ? north : "missing");
            keys.Add(_particles[state]);
            foreach (BakedPart part in appearance.Model?.Parts ?? []) {
                foreach (BakedOption option in part.Options) {
                    foreach (BakedQuad quad in option.Quads) {
                        keys.Add(TextureKey(quad.Texture));
                    }
                }
            }
        }

        Dictionary<Identifier, string> spriteKeys = CodeSprites.ToDictionary(sprite => sprite, source.SpriteKey);
        keys.UnionWith(spriteKeys.Values);

        Dictionary<string, TextureImage> images = new();
        TextureImage Image(string key) {
            if (!images.TryGetValue(key, out TextureImage? image)) {
                image = key == "missing" ? MissingImage() : source.Texture(key);
                images[key] = image;
            }
            return image;
        }
        Dictionary<string, TextureAnimation?> animations = new();
        TextureAnimation? AnimationOf(string key) =>
            animations.TryGetValue(key, out TextureAnimation? animation) ? animation : animations[key] = source.Animation(key);
        // An animated texture shows its first frame until the animator takes over, cut from the strip's own levels.
        TextureImage[] Levels(string key, TextureImage image, int size, int levels) => AnimationOf(key) is { } animation
            ? animation.FrameLevels(0, size, levels)
            : Mipmaps.Generate(image.Resized(size), source.MipSettings(key), ResourcePackSource.IsItemSprite(key), levels);
        Textures = buildTextures(keys, Image, Levels);
        foreach ((Identifier sprite, string key) in spriteKeys) {
            _sprites[sprite] = (Textures.LayerOf(key), Image(key));
        }
        foreach (string key in keys) {
            if (AnimationOf(key) is { } animation) {
                Animations.Add((Textures.LayerOf(key), animation));
            }
        }
        Dictionary<(string, int, int, int, int), RenderLayer> transparency = new();
        HashSet<Identifier> bars = registry.Blocks.Tags.Contains(BarsTag) ? registry.Blocks.Tags[BarsTag].GetValueIds(registry).ToHashSet() : [];

        for (uint state = 0; state < count; state++) {
            IBlock block = registry.Blocks.GetByStateId(state);
            BlockAppearance appearance = appearances[state];
            BlockModel model = new() {
                Geometry = appearance.Geometry,
                Layer = appearance.Layer,
                Tint = appearance.Tint,
                TintFaces = appearance.TintFaces,
                BlockKey = BlockKeyOf(blockKeys, block.Identifier.ToString())
            };
            for (int face = 0; face < 6; face++) {
                string key = appearance.Textures[face];
                model.TextureLayers[face] = key.Length > 0 ? (ushort)Textures.LayerOf(key) : (ushort)0;
            }
            ApplyState(model, block, state, bars);
            if (appearance.Model is { } baked) {
                ConvertModel(model, baked, appearance.Tints ?? [], Image, transparency);
            }
            ByState[state] = model;
        }
    }

    /// <summary>What the mesher reads of a state that does not come from the pack: its shapes, the lighter's flags and its fluid.</summary>
    /// <param name="bars">The <c>bars</c> block tag's members.</param>
    public static void ApplyState(BlockModel model, IBlock block, uint state, IReadOnlySet<Identifier> bars) {
        model.Info = block.Info;
        model.Boxes = BoxesOf(block.BlockShape);
        model.FullCube = model.Boxes.Length == 1 && IsUnit(model.Boxes[0]);
        model.HasOffset = block.Info.Offsets(BlockShapeOffsets.Block);
        if (block.Occludes) {
            model.OcclusionBoxes = BoxesOf(block.OcclusionShape);
            model.OccludesFaces = FullFaces(model.OcclusionBoxes);
        }
        model.BlockFaces = BlockRenderTable.FullFacesOf(state);
        model.EmptyFaces = BlockRenderTable.EmptyFacesOf(state);
        byte render = BlockRenderTable.FlagsOf(state);
        model.SolidRender = (render & BlockRenderTable.SolidRender) != 0;
        model.LightPermeable = (render & BlockRenderTable.LightPermeable) != 0;
        model.CollisionShapeFullBlock = (render & BlockRenderTable.CollisionShapeFullBlock) != 0;
        model.EmissiveRendering = (render & BlockRenderTable.EmissiveRendering) != 0;
        model.ShadeBrightness = BlockRenderTable.ShadeBrightnessOf(state);
        model.Solid = block.Solid;
        model.Overlay = BlockClasses.Is(block.Identifier, BlockClass.HalfTransparentBlock) || BlockClasses.Is(block.Identifier, BlockClass.LeavesBlock);
        model.LightEmission = block.LightEmission;
        model.InBarsTag = bars.Contains(block.Identifier);
        foreach (BlockClass type in BlockClasses.Of(block.Identifier)) {
            if (type == BlockClass.HalfTransparentBlock || type == BlockClass.PowderSnowBlock) {
                model.Skip = SkipRendering.SameBlock;
            }
            else if (type == BlockClass.IronBarsBlock) {
                model.Skip = SkipRendering.Bars;
            }
            else if (type == BlockClass.MangroveRootsBlock) {
                model.Skip = SkipRendering.MangroveRoots;
            }
            else if (type != BlockClass.LeavesBlock) {
                continue;
            }
            break;
        }
        if (model.Skip == SkipRendering.Bars) {
            Dictionary<string, string> properties = StateProperties.Of(block);
            foreach ((string name, Face face) in (ReadOnlySpan<(string, Face)>)[("north", Face.North), ("south", Face.South), ("west", Face.West), ("east", Face.East)]) {
                if (properties.TryGetValue(name, out string? value) && value == "true") {
                    model.Connections |= (byte)(1 << (int)face);
                }
            }
        }

        string path = block.Identifier.Key;
        if (path == "lava") {
            model.IsLava = true;
            model.FluidLevel = IntProperty(block, "level");
        }
        else if (path == "water" || (block.Fluid?.Key is "water" or "flowing_water")) {
            model.HasWater = true;
            model.FluidLevel = path == "water" ? IntProperty(block, "level") : 0;
        }
    }

    /// <summary>
    /// The texture array key of a pack texture; quads whose texture did not resolve use the missing one, as does
    /// <c>minecraft:missingno</c>, the name <c>MissingTextureAtlasSprite</c> goes by, which air's model names.
    /// </summary>
    public static string TextureKey(string? texture) => texture is null or "minecraft:missingno" ? "missing" : "pack:" + texture;

    // Most states share their baked parts with many others, so each part is converted once per set of tints.
    private readonly Dictionary<(BakedPart, string), MeshPart> _converted = new();

    private void ConvertModel(BlockModel model, BakedBlockModel baked, TintSource[] tints, Func<string, TextureImage> image,
        Dictionary<(string, int, int, int, int), RenderLayer> transparency) {
        model.Multipart = baked.Multipart;
        string tintKey = tints.Length == 0 ? "" : string.Join(',', tints.Select(t => $"{t.Kind}:{t.Rgb}"));
        model.Parts = baked.Parts.Select(part => {
            if (!_converted.TryGetValue((part, tintKey), out MeshPart? converted)) {
                converted = new MeshPart {
                    Options = part.Options.Select(option => new MeshOption {
                        Quads = OneSidedCutout(option.Quads.Select(q => ConvertQuad(q, tints, image, transparency)).ToArray()),
                        Weight = option.Weight,
                        AmbientOcclusion = option.AmbientOcclusion
                    }).ToArray(),
                    TotalWeight = part.TotalWeight
                };
                _converted[(part, tintKey)] = converted;
            }
            return converted;
        }).ToArray();

        // What the rest of the renderer reads per face (distant terrain, culling between alike blocks)
        // comes from the first quad lying on each face of the block, which is the base layer where a
        // face has several.
        RenderLayer layer = RenderLayer.Solid;
        byte tintFaces = 0, set = 0;
        TintKind tint = TintKind.None;
        foreach (MeshPart part in model.Parts) {
            foreach (MeshQuad quad in part.Options[0].Quads) {
                if (!quad.OnBoundary || quad.Facing >= 6 || (set & 1 << quad.Facing) != 0) {
                    continue;
                }
                set |= (byte)(1 << quad.Facing);
                model.TextureLayers[quad.Facing] = quad.Texture;
                if (quad.Tint.Kind != TintKind.None) {
                    tintFaces |= (byte)(1 << quad.Facing);
                    tint = quad.Tint.Kind;
                }
                else {
                    model.FixedTints[quad.Facing] = quad.Tint.Rgb;
                }
                layer = (RenderLayer)Math.Max((int)layer, (int)quad.Layer);
            }
        }
        model.Layer = layer;
        model.Tint = tint;
        model.TintFaces = tintFaces;
    }

    /// <summary>
    /// Drops the second of each back to back pair of cutout plant quads, as a cross model's planes come.
    /// A plant is drawn from both sides, so both would draw in one plane and fight for depth, each with
    /// its texture mirrored against the other's. The one kept is seen from behind mirrored, and is filed
    /// as unaligned so it is not culled with the faces turned away from the camera. Any other pair, leaf
    /// litter's top and underside, stays two quads that are each drawn from the front only.
    /// </summary>
    private static MeshQuad[] OneSidedCutout(MeshQuad[] quads) {
        List<MeshQuad>? kept = null;
        for (int i = 0; i < quads.Length; i++) {
            MeshQuad quad = quads[i];
            bool twin = false;
            for (int j = 0; j < i && !twin; j++) {
                MeshQuad other = quads[j];
                twin = quad.Layer == RenderLayer.Cutout && other.Layer == RenderLayer.Cutout && quad.Plant && other.Plant
                       && quad.Texture == other.Texture && quad.Cull == other.Cull && SamePoints(quad.Positions, other.Positions)
                       && Vector3.Dot(Normal(quad.Positions), Normal(other.Positions)) < 0;
                if (twin) {
                    other.Facing = SectionMesh.Unaligned;
                }
            }
            if (twin) {
                kept ??= quads.Take(i).ToList();
            }
            else {
                kept?.Add(quad);
            }
        }
        return kept?.ToArray() ?? quads;

        static Vector3 Normal(Vector3[] p) => Vector3.Cross(p[1] - p[0], p[2] - p[0]);

        static bool SamePoints(Vector3[] a, Vector3[] b) =>
            a.All(p => b.Any(q => Vector3.DistanceSquared(p, q) < 1e-8F)) && b.All(p => a.Any(q => Vector3.DistanceSquared(p, q) < 1e-8F));
    }

    private MeshQuad ConvertQuad(BakedQuad q, TintSource[] tints, Func<string, TextureImage> image,
        Dictionary<(string, int, int, int, int), RenderLayer> transparency) {
        string key = TextureKey(q.Texture);
        Vector3 normal = Vector3.Cross(q.Positions[1] - q.Positions[0], q.Positions[2] - q.Positions[0]);
        int facing = SectionMesh.Unaligned;
        bool onBoundary = false;
        if (Directions.Closest(normal) is { } closest) {
            int axis = BlockFaces.Axis(closest);
            float plane = BlockFaces.Component(q.Positions[0], axis);
            bool flat = q.Positions.All(p => Math.Abs(BlockFaces.Component(p, axis) - plane) < 1e-5F);
            float off = MathF.Sqrt(normal.LengthSquared() - BlockFaces.Component(normal, axis) * BlockFaces.Component(normal, axis));
            if (flat && off < 1e-5F) {
                facing = closest;
                onBoundary = closest % 2 == 1 ? plane >= 1 - 1e-5F : plane <= 1e-5F;
            }
        }
        return new MeshQuad {
            Positions = q.Positions,
            Uvs = q.Uvs,
            Texture = (ushort)Textures.LayerOf(key),
            Layer = q.ForceTranslucent ? RenderLayer.Translucent : LayerOf(key, image(key), q.Uvs, transparency),
            Cull = (sbyte)(q.CullFace ?? -1),
            Facing = (byte)facing,
            Direction = (byte)q.Direction,
            OnBoundary = onBoundary,
            Tint = q.TintIndex >= 0 && q.TintIndex < tints.Length ? tints[q.TintIndex] : new TintSource(TintKind.None),
            Plant = q.ShadeDirection == (int)Face.Up,
            Emission = (byte)q.LightEmission,
            ShadeOverride = (sbyte)(q.ShadeDirection ?? -1)
        };
    }

    /// <summary>
    /// <c>SpriteContents.computeTransparency</c> over the part of the texture a quad shows: blended if
    /// any texel there is partly transparent, cut out if any is fully, else solid.
    /// </summary>
    private static RenderLayer LayerOf(string key, TextureImage image, Vector2[] uvs, Dictionary<(string, int, int, int, int), RenderLayer> cache) {
        float minU = uvs.Min(u => u.X), maxU = uvs.Max(u => u.X), minV = uvs.Min(u => u.Y), maxV = uvs.Max(u => u.Y);
        int x0 = Math.Clamp((int)MathF.Floor(minU * image.Width), 0, image.Width - 1);
        int x1 = Math.Clamp((int)MathF.Ceiling(maxU * image.Width), x0 + 1, image.Width);
        int y0 = Math.Clamp((int)MathF.Floor(minV * image.Height), 0, image.Height - 1);
        int y1 = Math.Clamp((int)MathF.Ceiling(maxV * image.Height), y0 + 1, image.Height);
        if (cache.TryGetValue((key, x0, y0, x1, y1), out RenderLayer known)) {
            return known;
        }
        RenderLayer layer = RenderLayer.Solid;
        for (int y = y0; y < y1 && layer != RenderLayer.Translucent; y++) {
            for (int x = x0; x < x1; x++) {
                byte alpha = image.Rgba[(y * image.Width + x) * 4 + 3];
                if (alpha == 0) {
                    layer = RenderLayer.Cutout;
                }
                else if (alpha < 255) {
                    layer = RenderLayer.Translucent;
                    break;
                }
            }
        }
        cache[(key, x0, y0, x1, y1)] = layer;
        return layer;
    }

    private static int BlockKeyOf(Dictionary<string, int> keys, string id) {
        if (!keys.TryGetValue(id, out int key)) {
            key = keys.Count + 1;
            keys[id] = key;
        }
        return key;
    }

    private static bool IsUnit(ModelBox box) => box.MinX <= 0 && box.MinY <= 0 && box.MinZ <= 0 && box.MaxX >= 1 && box.MaxY >= 1 && box.MaxZ >= 1;

    private static ModelBox[] BoxesOf(ICollisionBox shape) {
        List<ModelBox> boxes = [];
        Collect(shape, boxes);
        return boxes.ToArray();
    }

    private static void Collect(ICollisionBox shape, List<ModelBox> into) {
        switch (shape) {
            case Aabb aabb:
                into.Add(new ModelBox(
                    (float)aabb.Position.X, (float)aabb.Position.Y, (float)aabb.Position.Z,
                    (float)(aabb.Position.X + aabb.Size.X), (float)(aabb.Position.Y + aabb.Size.Y), (float)(aabb.Position.Z + aabb.Size.Z)));
                break;
            case CompositeBox composite:
                foreach (ICollisionBox child in composite.Children) {
                    Collect(child, into);
                }
                break;
        }
    }

    /// <summary>Faces of the unit cube that some single box of the shape covers entirely.</summary>
    private static byte FullFaces(ModelBox[] boxes) {
        byte mask = 0;
        foreach (ModelBox b in boxes) {
            bool xFull = b.MinX <= 0 && b.MaxX >= 1;
            bool yFull = b.MinY <= 0 && b.MaxY >= 1;
            bool zFull = b.MinZ <= 0 && b.MaxZ >= 1;
            if (xFull && zFull && b.MinY <= 0) mask |= 1 << (int)Face.Down;
            if (xFull && zFull && b.MaxY >= 1) mask |= 1 << (int)Face.Up;
            if (xFull && yFull && b.MinZ <= 0) mask |= 1 << (int)Face.North;
            if (xFull && yFull && b.MaxZ >= 1) mask |= 1 << (int)Face.South;
            if (yFull && zFull && b.MinX <= 0) mask |= 1 << (int)Face.West;
            if (yFull && zFull && b.MaxX >= 1) mask |= 1 << (int)Face.East;
        }
        return mask;
    }

    private static int IntProperty(IBlock state, string name) {
        foreach ((string key, INbtTag value) in state.ToStateNbt().Children) {
            if (key == name) {
                return value switch {
                    StringTag s when int.TryParse(s.Value, out int parsed) => parsed,
                    IntegerTag i => i.Value,
                    _ => 0
                };
            }
        }
        return 0;
    }
}

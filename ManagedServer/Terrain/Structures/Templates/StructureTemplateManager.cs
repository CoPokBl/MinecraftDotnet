using System.IO.Compression;
using ManagedServer.Terrain.Data;
using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// <c>StructureTemplateManager</c>: the templates a pack holds, parsed on first ask and kept.
/// </summary>
/// <remarks>
/// <b>Lazy rather than eager.</b> The vanilla pack has 1370 templates and about 3.7MB of them
/// uncompressed, and a world generating overworld terrain touches maybe a tenth: a nether pack's
/// bastions and the end's cities are parsed by nobody. Loading them all would put the cost on every
/// server start rather than on the first structure that wants one.
/// <p/>
/// Parsing is done <b>outside the lock</b> and the loser of a race is discarded, because a template is
/// an immutable value and two threads building the same one build equal ones. Holding the lock across
/// a parse would put every chunk generating anywhere behind one file read.
/// </remarks>
public sealed class StructureTemplateManager {
    private static readonly Dictionary<(MinecraftRegistry, IDatapackSource), StructureTemplateManager>
        Cache = new();

    private static readonly Lock CacheLock = new();

    private readonly IDatapackSource _source;
    private readonly MinecraftRegistry _registry;

    /// <summary>Where each template id lives inside the pack, listed once.</summary>
    private readonly Dictionary<Identifier, string> _paths;

    private readonly Dictionary<Identifier, StructureTemplate> _loaded = [];
    private readonly SortedSet<string> _missing = [];
    private readonly Lock _gate = new();

    /// <summary>What a pool asked for and the pack does not have.</summary>
    private static readonly StructureTemplate EmptyTemplate =
        new(new Vec3<int>(0, 0, 0), [new TemplatePalette([])], []);

    private StructureTemplateManager(MinecraftRegistry registry, IDatapackSource source) {
        _registry = registry;
        _source = source;

        _paths = source.Entries("structure", ".nbt")
            .ToDictionary(entry => entry.Id, entry => entry.Path);

        if (_paths.Count == 0) {
            throw new InvalidOperationException(
                $"\"{source.Describe()}\" carries no structure templates: it has no "
                + "data/<namespace>/structure. Shipwrecks, igloos, villages and every other "
                + "template built structure need them.");
        }
    }

    public static StructureTemplateManager Load(IDatapackSource source,
        MinecraftRegistry? registry = null) {

        MinecraftRegistry actual = registry ?? VanillaRegistry.Data;

        lock (CacheLock) {
            if (Cache.TryGetValue((actual, source), out StructureTemplateManager? existing)) {
                return existing;
            }

            StructureTemplateManager manager = new(actual, source);
            Cache[(actual, source)] = manager;
            return manager;
        }
    }

    /// <summary>Whether the pack has a template under this id.</summary>
    public bool Has(Identifier id) => _paths.ContainsKey(id);

    /// <summary>Every template id the pack holds.</summary>
    public IEnumerable<Identifier> Ids => _paths.Keys;

    /// <summary>
    /// The templates something asked for and the pack does not have, in the order they are named.
    /// </summary>
    /// <remarks>
    /// Grows as templates are resolved, since they are parsed on first use, so a reader gets what has
    /// been reached rather than what exists.
    /// </remarks>
    public IReadOnlyCollection<string> Missing {
        get {
            lock (_gate) {
                return [.._missing];
            }
        }
    }

    /// <summary>
    /// The named template, or an empty one where the pack does not have it.
    /// </summary>
    /// <remarks>
    /// <b>An empty template rather than a failure</b>, which is <c>getOrCreate</c>'s own behaviour and
    /// is depended on: the vanilla pack names <c>ancient_city/walls/intact_horizontal_wall_stairs_5</c>
    /// and ships four of those, so that wall piece really does place nothing in vanilla too. Failing
    /// the load would take the whole ancient city with it.
    /// <p/>
    /// Reported through <see cref="Missing"/> rather than silent, since a template that places nothing
    /// and a template that was never asked for look the same from outside the pass.
    /// </remarks>
    public StructureTemplate Get(Identifier id) {
        lock (_gate) {
            if (_loaded.TryGetValue(id, out StructureTemplate? cached)) {
                return cached;
            }
        }

        if (!_paths.TryGetValue(id, out string? path)) {
            lock (_gate) {
                _missing.Add(id.ToString());
                _loaded[id] = EmptyTemplate;
            }

            return EmptyTemplate;
        }

        StructureTemplate parsed = Parse(id, path);

        lock (_gate) {
            if (_loaded.TryGetValue(id, out StructureTemplate? raced)) {
                return raced;
            }

            _loaded[id] = parsed;
            return parsed;
        }
    }

    private StructureTemplate Parse(Identifier id, string path) {
        CompoundTag root;

        using (Stream stream = _source.Open(path)) {
            root = ReadNamedRoot(stream);
        }

        try {
            return Read(root);
        } catch (Exception error) {
            throw new FormatException($"The structure template \"{id}\" ({path}) did not read: "
                + error.Message, error);
        }
    }

    /// <summary>
    /// A gzipped NBT file whose root compound carries a name, which is the form on disk.
    /// </summary>
    /// <remarks>
    /// Two things the reader does not do. It has no gzip path, so the stream is decompressed here;
    /// and <c>ReadCompoundTag</c> reads a compound's <b>entries</b> rather than its header, which is
    /// right for the network form where a root has no name and wrong for a file, where the root is a
    /// type byte and a name before the first entry. Handing it the whole file reads that name as the
    /// first entry's type and length, and the empty name every vanilla template has looks exactly
    /// like an end tag: the template comes out empty rather than failing.
    /// <p/>
    /// So the header is stepped over and the rest is read as an implied root, which is the shape the
    /// reader wants.
    /// </remarks>
    private static CompoundTag ReadNamedRoot(Stream stream) {
        using MemoryStream buffer = new();

        using (GZipStream gzip = new(stream, CompressionMode.Decompress)) {
            gzip.CopyTo(buffer);
        }

        byte[] raw = buffer.ToArray();

        if (raw.Length < 3 || raw[0] != CompoundPrefix) {
            throw new FormatException("A structure template does not start with a compound tag.");
        }

        int nameLength = (raw[1] << 8) | raw[2];
        int start = 3 + nameLength;

        if (start > raw.Length) {
            throw new FormatException("A structure template's root name runs past the end of it.");
        }

        return NbtReader.ReadNbt(raw[start..], impliedRoot: true).GetCompound();
    }

    /// <summary><c>TAG_Compound</c>, which every template file starts with.</summary>
    private const byte CompoundPrefix = 10;

    /// <summary>
    /// <c>StructureTemplate.load</c>.
    /// </summary>
    /// <remarks>
    /// The <c>palettes</c> key is the multi palette form and <c>palette</c> the single one, and a file
    /// carries exactly one of the two. Both share the same block list: an entry's <c>state</c> is an
    /// index into whichever palette is in use, so the alternates are the <b>same shape</b> in
    /// different materials rather than different shapes.
    /// </remarks>
    private StructureTemplate Read(CompoundTag root) {
        Vec3<int> size = ReadIntTriple(root["size"].GetList());
        ListTag blocks = root.Contains("blocks") ? root["blocks"].GetList() : new ListTag();

        List<TemplatePalette> palettes = [];

        if (root.Contains("palettes")) {
            foreach (INbtTag palette in root["palettes"].GetList().Tags) {
                palettes.Add(ReadPalette(palette.GetList(), blocks));
            }
        } else {
            palettes.Add(ReadPalette(
                root.Contains("palette") ? root["palette"].GetList() : new ListTag(), blocks));
        }

        List<TemplateEntityInfo> entities = [];

        if (root.Contains("entities")) {
            foreach (INbtTag entry in root["entities"].GetList().Tags) {
                CompoundTag entity = entry.GetCompound();

                if (!entity.Contains("nbt")) {
                    continue;
                }

                entities.Add(new TemplateEntityInfo(
                    ReadDoubleTriple(entity["pos"].GetList()),
                    ReadIntTriple(entity["blockPos"].GetList()),
                    entity["nbt"].GetCompound()));
            }
        }

        return new StructureTemplate(size, palettes.ToArray(), entities.ToArray());
    }

    /// <summary>
    /// One palette's blocks, ordered as vanilla's <c>buildInfoList</c> orders them.
    /// </summary>
    /// <remarks>
    /// Full cubes first, then everything else, then anything carrying a block entity, and each of the
    /// three sorted by y, then x, then z. That is what stops a torch being written before the wall it
    /// hangs on, and a chest before the floor under it.
    /// <p/>
    /// The full cube test is <c>isCollisionShapeFullBlock</c> over an <b>empty</b> block getter, so it
    /// is the state's own shape and not what it would be somewhere. <c>hasDynamicShape</c> excludes
    /// the shulker box, whose shape depends on a block entity.
    /// </remarks>
    private TemplatePalette ReadPalette(ListTag palette, ListTag blocks) {
        uint[] states = new uint[palette.Tags.Length];

        for (int i = 0; i < states.Length; i++) {
            // A template saved before data version 5006 spells these Name and Properties, and
            // BlockStateFieldNamesFix renames them on load.
            CompoundTag entry = palette.Tags[i].GetCompound();
            INbtTag? properties = entry["properties"] ?? entry["Properties"];

            states[i] = StateParser.Read(_registry,
                Identifier.Parse((entry["id"] ?? entry["Name"]).GetString()),
                properties?.GetCompound()).StateId;
        }

        List<TemplateBlockInfo> fullBlocks = [];
        List<TemplateBlockInfo> others = [];
        List<TemplateBlockInfo> withEntities = [];

        foreach (INbtTag entry in blocks.Tags) {
            CompoundTag block = entry.GetCompound();

            int index = block.Contains("state") ? block["state"].GetInteger() : 0;

            TemplateBlockInfo info = new(
                ReadIntTriple(block["pos"].GetList()),
                index >= 0 && index < states.Length ? states[index] : Block.Air.StateId,
                block.Contains("nbt") ? block["nbt"].GetCompound() : null);

            if (info.Nbt is not null) {
                withEntities.Add(info);
            } else if (IsFullCube(info.StateId)) {
                fullBlocks.Add(info);
            } else {
                others.Add(info);
            }
        }

        fullBlocks.Sort(ByPosition);
        others.Sort(ByPosition);
        withEntities.Sort(ByPosition);

        return new TemplatePalette([..fullBlocks, ..others, ..withEntities]);
    }

    private bool IsFullCube(uint stateId) {
        IBlock block = _registry.Blocks.GetByStateId(stateId);

        return !HasDynamicShape.Contains(block.Identifier)
            && ShapeSupport.IsShapeFullBlock(block.CollisionShape);
    }

    /// <summary>
    /// <c>Block.hasDynamicShape</c>: the blocks whose shape is not a function of their state alone.
    /// </summary>
    /// <remarks>
    /// A hand table because the value is a method override on the block class rather than anything the
    /// dumper can reflect off a state. Only the shulker boxes declare it, and they do because an open
    /// one's shape follows its lid.
    /// </remarks>
    private static readonly HashSet<Identifier> HasDynamicShape = [
        Block.ShulkerBox.Identifier, Block.WhiteShulkerBox.Identifier,
        Block.OrangeShulkerBox.Identifier, Block.MagentaShulkerBox.Identifier,
        Block.LightBlueShulkerBox.Identifier, Block.YellowShulkerBox.Identifier,
        Block.LimeShulkerBox.Identifier, Block.PinkShulkerBox.Identifier,
        Block.GrayShulkerBox.Identifier, Block.LightGrayShulkerBox.Identifier,
        Block.CyanShulkerBox.Identifier, Block.PurpleShulkerBox.Identifier,
        Block.BlueShulkerBox.Identifier, Block.BrownShulkerBox.Identifier,
        Block.GreenShulkerBox.Identifier, Block.RedShulkerBox.Identifier,
        Block.BlackShulkerBox.Identifier
    ];

    private static int ByPosition(TemplateBlockInfo left, TemplateBlockInfo right) {
        int y = left.Pos.Y.CompareTo(right.Pos.Y);
        if (y != 0) return y;

        int x = left.Pos.X.CompareTo(right.Pos.X);
        return x != 0 ? x : left.Pos.Z.CompareTo(right.Pos.Z);
    }

    private static Vec3<int> ReadIntTriple(ListTag list) {
        return new Vec3<int>(
            list.Tags.Length > 0 ? list.Tags[0].GetInteger() : 0,
            list.Tags.Length > 1 ? list.Tags[1].GetInteger() : 0,
            list.Tags.Length > 2 ? list.Tags[2].GetInteger() : 0);
    }

    private static Vec3<double> ReadDoubleTriple(ListTag list) {
        return new Vec3<double>(
            list.Tags.Length > 0 ? list.Tags[0].GetDouble() : 0,
            list.Tags.Length > 1 ? list.Tags[1].GetDouble() : 0,
            list.Tags.Length > 2 ? list.Tags[2].GetDouble() : 0);
    }
}

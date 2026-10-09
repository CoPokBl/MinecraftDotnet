using System.Numerics;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Storage;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace Minecraft.Implementations.AnvilWorld;

/// <summary>
/// A chunk as vanilla's own on disk NBT. Pair it with <see cref="AnvilRegionBlobStore"/> for a world
/// directory a vanilla server will open, or with any other store to keep the format and change where
/// it lives.
/// </summary>
/// <remarks>
/// The bytes are the chunk's NBT with its root name and <b>no compression</b>. A region file
/// compresses what it is given and records which scheme it used, so a codec that compressed as well
/// would be storing a zlib stream inside a zlib stream.
/// </remarks>
public sealed class AnvilChunkCodec(MinecraftRegistry registry) : IChunkCodec {
    /// <summary>
    /// Stamped on everything written and never checked on read. Vanilla only consults it to decide
    /// which data fixers a chunk needs, and runs every one after it, so it has to be the version that
    /// actually wrote the chunk.
    /// </summary>
    public const int DataVersion = GameVersion.DataVersion;

    /// <summary>Block state storage never goes below four bits.</summary>
    private const int MinBlockBits = 4;

    public Identifier Format => "minecraft:anvil";

    /// <summary>
    /// What a chunk is stamped with beyond its blocks. Vanilla's reader wants these keys present even
    /// when they are empty, and a chunk without them is one it declines to load.
    /// </summary>
    public string Status { get; set; } = "minecraft:full";

    public void Encode(ChunkData chunk, DataWriter writer) {
        int minSection = chunk.MinY / ChunkSection.Size;

        INbtTag[] sections = new INbtTag[chunk.Sections.Length];
        for (int i = 0; i < chunk.Sections.Length; i++) {
            sections[i] = EncodeSection(chunk.Sections[i], minSection + i);
        }

        List<INbtTag> blockEntities = [];
        foreach ((Vec3<int> pos, BlockEntity entity) in chunk.BlockEntities) {
            blockEntities.Add(EncodeBlockEntity(chunk, pos, entity));
        }

        // Heightmaps are deliberately absent. They are a function of the blocks, vanilla primes the
        // ones a chunk arrives without, and storing them is a second copy of the truth that goes stale
        // the moment anything writes a block.
        CompoundTag root = new(
            ("DataVersion", new IntegerTag(DataVersion)),
            ("xPos", new IntegerTag(chunk.ChunkX)),
            ("yPos", new IntegerTag(minSection)),
            ("zPos", new IntegerTag(chunk.ChunkZ)),
            ("Status", new StringTag(Status)),
            ("LastUpdate", new LongTag(0)),
            ("InhabitedTime", new LongTag(0)),
            ("isLightOn", new ByteTag(0)),
            ("sections", new ListTag(sections)),
            ("block_entities", new ListTag(blockEntities.ToArray())),
            ("block_ticks", new ListTag()),
            ("fluid_ticks", new ListTag()),
            ("PostProcessing", new ListTag(Enumerable.Range(0, chunk.Sections.Length)
                .Select(INbtTag (_) => new ListTag()).ToArray())),
            ("structures", new CompoundTag(("starts", new CompoundTag()), ("References", new CompoundTag())))
        );

        writer.Write(NbtRoot.Serialise(root));
    }

    public ChunkData Decode(DataReader reader, ChunkCodecContext context) {
        ChunkData chunk = context.NewChunk();
        CompoundTag root = NbtRoot.Parse(reader.ReadRemaining());

        int minSection = context.MinY / ChunkSection.Size;

        if (root["sections"] is ListTag sections) {
            foreach (INbtTag sectionTag in sections.Tags) {
                CompoundTag section = sectionTag.GetCompound();
                int index = section["Y"].GetByte() - minSection;

                // Vanilla writes a section either side of the block range to carry light, so the list
                // runs one wider than the chunk in both directions.
                if (index < 0 || index >= chunk.Sections.Length) {
                    continue;
                }

                DecodeSection(chunk.Sections[index], section);
            }
        }

        if (root["block_entities"] is ListTag entities) {
            foreach (INbtTag entityTag in entities.Tags) {
                DecodeBlockEntity(chunk, entityTag.GetCompound());
            }
        }

        return chunk;
    }

    // -- sections ------------------------------------------------------------

    private CompoundTag EncodeSection(ChunkSection section, int sectionY) {
        return new CompoundTag(
            ("Y", new ByteTag((sbyte)sectionY)),
            ("block_states", EncodeBlocks(section)),
            ("biomes", EncodeBiomes(section)));
    }

    private CompoundTag EncodeBlocks(ChunkSection section) {
        if (section.UniformState is { } uniform) {
            return new CompoundTag(("palette", new ListTag(BlockStateNames.ToPaletteTag(uniform, registry))));
        }

        // The section's own palette is already the distinct set with an index per position, which is
        // exactly what Anvil stores. Taking it whole is the difference between converting a few dozen
        // states and converting four thousand blocks.
        if (section.Palette is IndirectPalette indirect) {
            INbtTag[] palette = new INbtTag[indirect.PaletteValues.Length];
            for (int i = 0; i < palette.Length; i++) {
                palette[i] = BlockStateNames.ToPaletteTag(indirect.PaletteValues[i], registry);
            }

            return PackContainer(palette, indirect.Blocks, StateBits(palette.Length));
        }

        uint[] flat = new uint[ChunkSection.Size * ChunkSection.Size * ChunkSection.Size];
        section.FillFlatStateIds(flat);
        (uint[] values, ushort[] indices) = Distinct(flat);

        INbtTag[] tags = new INbtTag[values.Length];
        for (int i = 0; i < values.Length; i++) {
            tags[i] = BlockStateNames.ToPaletteTag(values[i], registry);
        }

        return PackContainer(tags, indices, StateBits(tags.Length));
    }

    private CompoundTag EncodeBiomes(ChunkSection section) {
        Palette palette = section.BiomesPalette;

        if (palette is SingleValuePalette single) {
            return new CompoundTag(("palette", new ListTag(BiomeName(single.Value))));
        }

        int volume = ChunkSection.BiomeDimension * ChunkSection.BiomeDimension * ChunkSection.BiomeDimension;
        uint[] flat = new uint[volume];
        uint[,,] biomes = palette.GetData();
        int at = 0;
        for (int y = 0; y < ChunkSection.BiomeDimension; y++) {
            for (int z = 0; z < ChunkSection.BiomeDimension; z++) {
                for (int x = 0; x < ChunkSection.BiomeDimension; x++) {
                    flat[at++] = biomes[x, y, z];
                }
            }
        }

        (uint[] values, ushort[] indices) = Distinct(flat);
        INbtTag[] tags = new INbtTag[values.Length];
        for (int i = 0; i < values.Length; i++) {
            tags[i] = BiomeName(values[i]);
        }

        return PackContainer(tags, indices, CeilLog2(tags.Length));
    }

    private void DecodeSection(ChunkSection section, CompoundTag tag) {
        if (tag["block_states"] is CompoundTag blocks && blocks["palette"] is ListTag blockPalette) {
            uint[] values = new uint[blockPalette.Tags.Length];
            for (int i = 0; i < values.Length; i++) {
                values[i] = BlockStateNames.FromPaletteTag(blockPalette.Tags[i].GetCompound(), registry);
            }

            section.Palette = ReadContainer(values, blocks["data"], ChunkSection.Size, StateBits(values.Length),
                ChunkSection.BlocksMaxBpe, ChunkSection.BlocksMinBpe, registry.Blocks.StatesCount);
        }

        if (tag["biomes"] is CompoundTag biomes && biomes["palette"] is ListTag biomePalette) {
            uint[] values = new uint[biomePalette.Tags.Length];
            for (int i = 0; i < values.Length; i++) {
                values[i] = (uint)registry.Biomes.GetProtocolId(biomePalette.Tags[i].GetString());
            }

            section.BiomesPalette = ReadContainer(values, biomes["data"], ChunkSection.BiomeDimension,
                CeilLog2(values.Length), ChunkSection.BiomesMaxBpe, ChunkSection.BiomesMinBpe,
                registry.Biomes.Count);
        }
    }

    // -- paletted containers -------------------------------------------------

    private static CompoundTag PackContainer(INbtTag[] palette, ushort[] indices, int bits) {
        if (bits == 0) {
            return new CompoundTag(("palette", new ListTag(palette)));
        }

        return new CompoundTag(
            ("palette", new ListTag(palette)),
            ("data", new ArrayTag<long>(DataWriter.PackToLongArray(bits, indices))));
    }

    /// <summary>
    /// The palette and its indices as one of our own palettes.
    /// </summary>
    /// <remarks>
    /// <b>The stored entries are always indices into the palette written beside them</b>, at
    /// <paramref name="bits"/> wide, whatever that width is. A file format is not the wire format: on
    /// the wire a container past eight bits drops its palette and stores raw state ids, and reading a
    /// stored chunk that way turns a section with more than 256 distinct states into noise.
    /// </remarks>
    private static Palette ReadContainer(uint[] values, INbtTag? data, int dimension, int bits,
        int maxBitsPerEntry, int minBitsPerEntry, long globalCount) {

        if (values.Length == 0) {
            throw new InvalidDataException("A stored paletted container has an empty palette.");
        }

        if (bits == 0 || data == null) {
            return new SingleValuePalette(dimension, maxBitsPerEntry, minBitsPerEntry, values[0]);
        }

        int volume = dimension * dimension * dimension;
        ReadOnlySpan<long> packed = data.GetLongs();
        uint[] flat = new uint[volume];

        int perLong = 64 / bits;
        long mask = (1L << bits) - 1L;
        for (int i = 0; i < volume; i++) {
            long word = packed[i / perLong];
            flat[i] = values[(int)((word >>> (bits * (i % perLong))) & mask)];
        }

        return PaletteBuilder.FromFlat(flat, dimension, maxBitsPerEntry, minBitsPerEntry, globalCount);
    }

    /// <summary>
    /// <c>PalettedContainer.Strategy.calculateBitsForSerialization</c> for block states: four is the
    /// floor, a single entry stores no data at all, and past eight the width is still the palette's
    /// own rather than the registry's.
    /// </summary>
    private static int StateBits(int paletteSize) {
        int bits = CeilLog2(paletteSize);
        return bits == 0 ? 0 : Math.Max(MinBlockBits, bits);
    }

    private static int CeilLog2(int values) {
        return values <= 1 ? 0 : BitOperations.Log2((uint)(values - 1)) + 1;
    }

    private static (uint[] Values, ushort[] Indices) Distinct(ReadOnlySpan<uint> flat) {
        Dictionary<uint, ushort> seen = new(64);
        List<uint> values = [];
        ushort[] indices = new ushort[flat.Length];

        for (int i = 0; i < flat.Length; i++) {
            if (!seen.TryGetValue(flat[i], out ushort index)) {
                index = (ushort)values.Count;
                values.Add(flat[i]);
                seen[flat[i]] = index;
            }

            indices[i] = index;
        }

        return (values.ToArray(), indices);
    }

    private StringTag BiomeName(uint biomeId) {
        return new StringTag(registry.Biomes[(int)biomeId].Identifier.ToString());
    }

    // -- block entities ------------------------------------------------------

    /// <summary>
    /// Anvil stores a block entity's position in world coordinates and its payload beside them, while
    /// a chunk holds it keyed by a position local in x and z. The four keys vanilla owns are stripped
    /// on the way in and restored on the way out, so a consumer's own tags survive the round trip.
    /// </summary>
    private static CompoundTag EncodeBlockEntity(ChunkData chunk, Vec3<int> local, BlockEntity entity) {
        List<(string, INbtTag)> children = [
            ("id", new StringTag(entity.Type.Identifier.ToString())),
            ("x", new IntegerTag(chunk.ChunkX * ChunkSection.Size + local.X)),
            ("y", new IntegerTag(local.Y)),
            ("z", new IntegerTag(chunk.ChunkZ * ChunkSection.Size + local.Z)),
            ("keepPacked", new ByteTag(0))
        ];

        foreach ((string key, INbtTag child) in entity.Data.GetCompound().Children) {
            children.Add((key, child));
        }

        return new CompoundTag(children.ToArray());
    }

    private void DecodeBlockEntity(ChunkData chunk, CompoundTag tag) {
        IBlockEntityType type = registry.BlockEntityTypes[tag["id"].GetString()];

        int x = tag["x"].GetInteger();
        int y = tag["y"].GetInteger();
        int z = tag["z"].GetInteger();

        string[] owned = ["id", "x", "y", "z", "keepPacked"];
        CompoundTag data = new(tag.Children.Where(c => !owned.Contains(c.key)).ToArray()!);

        Vec3<int> local = new(((x % 16) + 16) % 16, y, ((z % 16) + 16) % 16);
        chunk.BlockEntities[local] = new BlockEntity(local.X, y, local.Z, type, data);
    }
}

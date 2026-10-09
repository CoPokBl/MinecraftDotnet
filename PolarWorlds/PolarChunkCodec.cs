using System.Numerics;
using Minecraft;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Implementations.Storage;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace PolarWorlds;

/// <summary>
/// One chunk in Polar's layout: a section at a time, each a palette of state strings and an index per
/// position.
/// </summary>
/// <remarks>
/// The record carries no section count of its own, so a reader has to be told how tall the world is.
/// <see cref="PolarBundle"/> takes that from the file header and puts it in the context.
/// <p/>
/// Light is written as absent. It is a function of the blocks and of whichever lighting provider the
/// world has, and a stored copy is wrong for any world that lights differently from the one that
/// saved it.
/// </remarks>
public sealed class PolarChunkCodec(MinecraftRegistry registry) : IChunkCodec {
    private const int MaxHeightmaps = 32;

    public Identifier Format => "polar:chunk";

    public void Encode(ChunkData chunk, DataWriter writer) {
        writer.WriteVarInt(chunk.ChunkX);
        writer.WriteVarInt(chunk.ChunkZ);

        foreach (ChunkSection section in chunk.Sections) {
            WriteSection(writer, section);
        }

        writer.WriteVarInt(chunk.BlockEntities.Count);
        foreach ((Vec3<int> local, BlockEntity entity) in chunk.BlockEntities) {
            writer.WriteInteger(PolarLoader.GetIndexFromCoords(local.X, local.Y, local.Z));
            writer.WritePrefixedOptional(Optional<Identifier>.FromNullable(entity.Type.Identifier),
                (v, w) => w.WriteString(v.Value));
            writer.WriteBoolean(true);
            writer.WriteNbt(entity.Data);
        }

        // Heightmaps are derived from the blocks and are recomputed on load, so none are stored.
        writer.WriteInteger(0);
        writer.WritePrefixedArray(Array.Empty<byte>(), (b, w) => w.Write(b));  // User data
    }

    public ChunkData Decode(DataReader reader, ChunkCodecContext context) {
        int chunkX = reader.ReadVarInt();
        int chunkZ = reader.ReadVarInt();

        ChunkData chunk = context.NewChunk();
        chunk.ChunkX = chunkX;
        chunk.ChunkZ = chunkZ;

        for (int i = 0; i < chunk.Sections.Length; i++) {
            chunk.Sections[i] = ReadSection(reader);
        }

        int blockEntityCount = reader.ReadVarInt();
        for (int i = 0; i < blockEntityCount; i++) {
            int packed = reader.ReadInteger();
            string? id = reader.ReadPrefixedOptional(r => r.ReadString());

            if (!reader.ReadBoolean()) {
                continue;
            }

            INbtTag data = reader.ReadNbt();
            IBlockEntityType type = registry.BlockEntityTypes[id.ThrowIfNull()];
            Vec3<int> local = new(PolarLoader.GetXFromIndex(packed), PolarLoader.GetYFromIndex(packed),
                PolarLoader.GetZFromIndex(packed));

            chunk.BlockEntities[local] = new BlockEntity(local.X, local.Y, local.Z, type, data);
        }

        int heightmapMask = reader.ReadInteger();
        for (int i = 0; i < MaxHeightmaps; i++) {
            if ((heightmapMask & (1 << i)) != 0) {
                reader.ReadPrefixedArray(r => r.ReadLong());
            }
        }

        reader.ReadPrefixedArray(r => r.Read());  // User data
        return chunk;
    }

    private void WriteSection(DataWriter writer, ChunkSection section) {
        // An air section with the default biome is the one case the format can say nothing about at
        // all, and it is most of a world.
        if (section.UniformState == 0 && section.BiomesPalette is SingleValuePalette { Value: 0 }) {
            writer.WriteBoolean(true);
            return;
        }

        writer.WriteBoolean(false);

        string[] blocks = BlockPalette(section, out ushort[]? blockIndices);
        WritePalettedContainer(writer, blocks, blockIndices);

        string[] biomes = BiomePalette(section, out ushort[]? biomeIndices);
        WritePalettedContainer(writer, biomes, biomeIndices);

        writer.WriteByte((sbyte)LightContent.Missing);  // Block light
        writer.WriteByte((sbyte)LightContent.Missing);  // Sky light
    }

    private ChunkSection ReadSection(DataReader reader) {
        ChunkSection section = new();
        if (reader.ReadBoolean()) {
            return section;
        }

        string[] blockPalette = reader.ReadPrefixedArray(r => r.ReadString());
        uint[] blockValues = new uint[blockPalette.Length];
        for (int i = 0; i < blockValues.Length; i++) {
            blockValues[i] = BlockStateNames.FromStateString(blockPalette[i], registry);
        }

        section.Palette = ReadPalettedContainer(reader, blockValues, ChunkSection.Size,
            ChunkSection.BlocksMaxBpe, ChunkSection.BlocksMinBpe, registry.Blocks.StatesCount);

        string[] biomePalette = reader.ReadPrefixedArray(r => r.ReadString());
        uint[] biomeValues = new uint[biomePalette.Length];
        for (int i = 0; i < biomeValues.Length; i++) {
            biomeValues[i] = (uint)registry.Biomes.GetProtocolId(biomePalette[i]);
        }

        section.BiomesPalette = ReadPalettedContainer(reader, biomeValues, ChunkSection.BiomeDimension,
            ChunkSection.BiomesMaxBpe, ChunkSection.BiomesMinBpe, registry.Biomes.Count);

        ReadLight(reader);  // Block light
        ReadLight(reader);  // Sky light

        return section;
    }

    /// <summary>
    /// The section's block states as a palette of names plus an index per position, taking the
    /// section's own palette whole where it has one.
    /// </summary>
    /// <remarks>
    /// The indices are null for a palette of one, which is the shape the format stores without any
    /// data at all. Everything here is per distinct state rather than per position, which is what
    /// keeps a chunk's worth of work in the tens rather than the hundreds of thousands.
    /// </remarks>
    private string[] BlockPalette(ChunkSection section, out ushort[]? indices) {
        if (section.UniformState is { } uniform) {
            indices = null;
            return [BlockStateNames.ToStateString(uniform, registry)];
        }

        if (section.Palette is IndirectPalette indirect) {
            indices = indirect.Blocks;
            string[] names = new string[indirect.PaletteValues.Length];
            for (int i = 0; i < names.Length; i++) {
                names[i] = BlockStateNames.ToStateString(indirect.PaletteValues[i], registry);
            }

            return names;
        }

        uint[] flat = new uint[ChunkSection.Size * ChunkSection.Size * ChunkSection.Size];
        section.FillFlatStateIds(flat);
        (uint[] values, ushort[] built) = Distinct(flat);

        indices = values.Length > 1 ? built : null;
        string[] result = new string[values.Length];
        for (int i = 0; i < result.Length; i++) {
            result[i] = BlockStateNames.ToStateString(values[i], registry);
        }

        return result;
    }

    private string[] BiomePalette(ChunkSection section, out ushort[]? indices) {
        Palette palette = section.BiomesPalette;

        if (palette is SingleValuePalette single) {
            indices = null;
            return [BiomeName(single.Value)];
        }

        int dimension = ChunkSection.BiomeDimension;
        uint[] flat = new uint[dimension * dimension * dimension];
        uint[,,] biomes = palette.GetData();
        int at = 0;
        for (int y = 0; y < dimension; y++) {
            for (int z = 0; z < dimension; z++) {
                for (int x = 0; x < dimension; x++) {
                    flat[at++] = biomes[x, y, z];
                }
            }
        }

        (uint[] values, ushort[] built) = Distinct(flat);
        indices = values.Length > 1 ? built : null;

        string[] result = new string[values.Length];
        for (int i = 0; i < result.Length; i++) {
            result[i] = BiomeName(values[i]);
        }

        return result;
    }

    private static void WritePalettedContainer(DataWriter writer, string[] palette, ushort[]? indices) {
        writer.WritePrefixedArray(palette, (id, w) => w.WriteString(id));

        int bits = CeilLog2(palette.Length);
        if (bits > 0 && indices != null) {
            writer.WritePrefixedPacketDataArray(bits, indices);
        }
    }

    private static Palette ReadPalettedContainer(DataReader reader, uint[] values, int dimension,
        int maxBitsPerEntry, int minBitsPerEntry, long globalCount) {

        if (values.Length == 0) {
            throw new InvalidDataException("A stored paletted container has an empty palette.");
        }

        int bits = CeilLog2(values.Length);
        if (bits == 0) {
            return new SingleValuePalette(dimension, maxBitsPerEntry, minBitsPerEntry, values[0]);
        }

        ushort[] indices = reader.ReadPrefixedPacketDataArray(bits);

        int volume = dimension * dimension * dimension;
        uint[] flat = new uint[volume];
        for (int i = 0; i < volume; i++) {
            flat[i] = values[indices[i]];
        }

        return PaletteBuilder.FromFlat(flat, dimension, maxBitsPerEntry, minBitsPerEntry, globalCount);
    }

    /// <summary>
    /// Walks one chunk record without building anything from it, so a bundle can find where the next
    /// one starts. A format that stores its chunks back to back has to be able to do this before it
    /// can hand any one of them out on its own.
    /// </summary>
    internal static void Skip(DataReader reader, int sectionCount) {
        reader.ReadVarInt();  // Chunk x
        reader.ReadVarInt();  // Chunk z

        for (int i = 0; i < sectionCount; i++) {
            if (reader.ReadBoolean()) {
                continue;
            }

            SkipPalettedContainer(reader);
            SkipPalettedContainer(reader);
            ReadLight(reader);
            ReadLight(reader);
        }

        int blockEntityCount = reader.ReadVarInt();
        for (int i = 0; i < blockEntityCount; i++) {
            reader.ReadInteger();
            reader.ReadPrefixedOptional(r => r.ReadString());
            if (reader.ReadBoolean()) {
                reader.ReadNbt();
            }
        }

        int heightmapMask = reader.ReadInteger();
        for (int i = 0; i < MaxHeightmaps; i++) {
            if ((heightmapMask & (1 << i)) != 0) {
                reader.ReadPrefixedArray(r => r.ReadLong());
            }
        }

        reader.ReadPrefixedArray(r => r.Read());  // User data
    }

    private static void SkipPalettedContainer(DataReader reader) {
        string[] palette = reader.ReadPrefixedArray(r => r.ReadString());
        if (CeilLog2(palette.Length) > 0) {
            reader.ReadPrefixedArray(r => r.ReadLong());
        }
    }

    private static void ReadLight(DataReader reader) {
        if ((LightContent)reader.ReadByte() == LightContent.Present) {
            reader.Read(2048);
        }
    }

    private string BiomeName(uint biomeId) => registry.Biomes[(int)biomeId].Identifier.ToString();

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

    internal enum LightContent {
        Missing = 0,
        Empty = 1,
        Full = 2,
        Present = 3
    }
}

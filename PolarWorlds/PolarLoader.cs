using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;
using ZstdSharp;

namespace PolarWorlds;

public class PolarLoader : ITerrainProvider {
    private const int MagicNumber = 0x506F6C72;
    private const short LatestVersion = 7;
    private const int MaxHeightmaps = 32;
    private const int BlockPaletteSize = 4096;
    private const int DataVersion = 4325;
    
    public Dictionary<Vec2<int>, ChunkData> Chunks = null!;
    private MinecraftRegistry _registry;

    public PolarLoader(string path, MinecraftRegistry registry) : this(File.ReadAllBytes(path), registry) {
        
    }
    
    public PolarLoader(byte[] data, MinecraftRegistry registry) {
        _registry = registry;
        Load(data);
    }

    public static byte[] CreateWorld(AnvilLoader anvilWorld) {
        ChunkData[] chunks = anvilWorld.GetAllChunks();
        if (chunks.Length == 0) {
            throw new InvalidOperationException("No chunks found in the Anvil world.");
        }
        return CreateWorld(chunks);
    }

    public static byte[] CreateWorld(ChunkData[] chunks, MinecraftRegistry? registry = null) {
        registry ??= VanillaRegistry.Data;
        
        DataWriter writer = new();

        writer.WriteInteger(MagicNumber);
        writer.WriteShort(LatestVersion);
        writer.WriteVarInt(DataVersion);

        // This data will be compressed later
        DataWriter data = new();
        data.WriteByte(0);  // Min section
        data.WriteByte(chunks[0].WorldHeight / ChunkSection.Size - 1);  // Max section

        data.WritePrefixedArray(Array.Empty<byte>(), (b, w) => w.Write(b));  // User data
        
        data.WriteVarInt(chunks.Length);  // Number of chunks
        foreach (ChunkData chunk in chunks) {
            Console.WriteLine("Writing chunk: " + chunk.ChunkX + ", " + chunk.ChunkZ);
            WriteChunk(data, chunk, registry);
        }
        
        // Cool, now we compress the data
        writer.WriteByte((sbyte)CompressionType.Zstd);  // Compression type
        byte[] compressedData = CompressZstd(data.ToArray());
        writer.WriteVarInt((int)data.Length);  // Original length of the data before compression
        Console.WriteLine("Compressed data length: " + data.Length);
        writer.Write(compressedData);  // Compressed data
        return writer.ToArray();
    }

    public void Load(byte[] data) {
        DataReader reader = new(data);

        int magicNumber = reader.ReadInteger();
        if (magicNumber != MagicNumber) {
            throw new InvalidDataException("Invalid magic number for Polar data.");
        }
        
        short version = reader.ReadShort();
        if (version > LatestVersion) {
            throw new InvalidDataException($"Unsupported Polar version: {version}. Latest supported version is {LatestVersion}.");
        }
        
        int dataVersion = reader.ReadVarInt();

        CompressionType compressionType = (CompressionType)reader.ReadByte();
        int compressedDataLength = reader.ReadVarInt();  // original length of the data before compression

        switch (compressionType) {
            case CompressionType.None:
                break;
            
            case CompressionType.Zstd:
                DecompressZstd(reader, compressedDataLength);
                break;
        }
        
        sbyte minSection = reader.ReadByte();
        sbyte maxSection = reader.ReadByte();
        if (minSection >= maxSection) {
            throw new InvalidDataException($"Invalid section range: {minSection} to {maxSection}.");
        }

        byte[] userData = reader.ReadPrefixedArray(r => r.Read());
        
        int chunkCount = reader.ReadVarInt();
        Chunks = [];
        for (int i = 0; i < chunkCount; i++) {
            ChunkData chunkData = ReadChunk(reader, version, dataVersion, maxSection - minSection + 1);
            Chunks.Add(new Vec2<int>(chunkData.ChunkX, chunkData.ChunkZ), chunkData);
        }
    }

    private static void DecompressZstd(DataReader reader, int length) {
        using Decompressor decompressor = new();
        byte[] outputBuffer = new byte[length];
        int byteCount = decompressor.Unwrap(reader.ReadRemaining(), outputBuffer);
        if (byteCount > length) {
            throw new InvalidDataException($"Decompressed data length {byteCount} exceeds expected length {length}.");
        }
        Array.Resize(ref outputBuffer, byteCount);
        reader.Position = 0;
        reader.UpdateData(outputBuffer);
    }
    
    private static byte[] CompressZstd(ReadOnlySpan<byte> data) {
        using Compressor compressor = new();
        return compressor.Wrap(data).ToArray();
    }
    
    public static int GetXFromIndex(int index) {
        return index & 0xF;  // 0-3 bits
    }
    
    public static int GetYFromIndex(int index) {
        int y = (index & 0x07FFFFF0) >>> 4;
        if ((index & 0x08000000) != 0) y = -y;  // bit 28 indicates negative Y
        return y;  // 4-28 bits
    }
    
    public static int GetZFromIndex(int index) {
        return (index >>> 28) & 0xF;  // bits 28-31
    }
    
    public static int GetIndexFromCoords(int x, int y, int z) {
        if (x < 0 || x > 15 || y < -2048 || y > 2047 || z < 0 || z > 15) {
            throw new ArgumentOutOfRangeException("Coordinates out of range for Polar chunk indexing.");
        }

        int index = 0;
        index |= x & 0xF;  // 0-3 bits for X
        index |= (z & 0xF) << 28;
        if (y < 0) {
            index |= 0x08000000;  // Set bit 28 if Y is negative
            index |= ((-y) << 4) & 0x07FFFFF0;  // 4-28 bits for Y, shifted left by 4
        }
        else {
            index |= (y << 4) & 0x07FFFFF0;  // 4-28 bits for Y, shifted left by 4
        }
        return index;
    }

    private static void WriteChunk(DataWriter writer, ChunkData data, MinecraftRegistry registry) {
        writer.WriteVarInt(data.ChunkX);
        writer.WriteVarInt(data.ChunkZ);
        
        foreach (ChunkSection section in data.Sections) {
            WriteSection(writer, section, registry);
        }
        
        // Block entities
        writer.WriteVarInt(data.BlockEntities.Count);
        foreach (BlockEntity entity in data.BlockEntities.Values) {
            writer.WriteInteger(GetIndexFromCoords(entity.X, entity.Y, entity.Z));
            writer.WritePrefixedOptional(Optional<Identifier>.FromNullable(entity.Type.Identifier), 
                (v, w) => w.WriteString(v.Value));
            writer.WriteBoolean(true);
            
            writer.WriteNbt(entity.Data);
        }
        
        // Heightmaps
        // we don't support that yet, so just write 0
        const int heightmapMask = 0;  // No heightmaps
        writer.WriteInteger(heightmapMask);
        
        writer.WritePrefixedArray(Array.Empty<byte>(), (b, w) => w.Write(b));  // User data
    }

    private ChunkData ReadChunk(DataReader reader, short version, int dataVersion, int sectionCount) {
        int chunkX = reader.ReadVarInt();
        int chunkZ = reader.ReadVarInt();
        
        Dictionary<Vec3<int>, BlockEntity> blockEntities = new();
        
        ChunkSection[] sections = new ChunkSection[sectionCount];
        for (int i = 0; i < sectionCount; i++) {
            sections[i] = ReadSection(reader, version, dataVersion);
        }
        
        int blockEntityCount = reader.ReadVarInt();
        for (int i = 0; i < blockEntityCount; i++) {
            int posIndex = reader.ReadInteger();  // posIndex
            string? id = reader.ReadPrefixedOptional(r => r.ReadString());

            INbtTag nbt = new CompoundTag(null);
            if (reader.ReadBoolean()) {
                nbt = reader.ReadNbt();
                BlockEntity entity = new(
                    GetXFromIndex(posIndex), 
                    GetYFromIndex(posIndex), 
                    GetZFromIndex(posIndex), 
                    _registry.BlockEntityTypes[id.ThrowIfNull()],
                    nbt);
                blockEntities.Add(new Vec3<int>(entity.X, entity.Y, entity.Z), entity);
            }
        }
        
        // Heightmaps
        int[][] heightmaps = new int[MaxHeightmaps][];
        int heightmapMask = reader.ReadInteger();
        for (int i = 0; i < MaxHeightmaps; i++) {
            if ((heightmapMask & (1 << i)) == 0) {
                continue;
            }
            
            // if not skipped (always true here)
            long[] packed = reader.ReadPrefixedArray(r => r.ReadLong());
        }
        
        byte[] userData = reader.ReadPrefixedArray(r => r.Read());

        return new ChunkData(sectionCount * 16) {
            ChunkX = chunkX,
            ChunkZ = chunkZ,
            Sections = sections,
            BlockEntities = blockEntities
        };
    }

    private static void WriteSection(DataWriter writer, ChunkSection section, MinecraftRegistry registry) {
        Dictionary<string, int> blockPaletteMap = [];
        List<string> blockPalette = [];
        ushort[] blockData = new ushort[ChunkSection.Size * ChunkSection.Size * ChunkSection.Size];
        int cBlockDataIndex = 0;
        for (int y = 0; y < ChunkSection.Size; y++) {
            for (int z = 0; z < ChunkSection.Size; z++) {
                for (int x = 0; x < ChunkSection.Size; x++) {
                    IBlock block = section.LookupBlock(x, y, z, registry);
                    string blockStr = GetStateStringFromBlock(block);
                    
                    if (!blockPaletteMap.TryGetValue(blockStr, out int paletteIndex)) {
                        paletteIndex = blockPalette.Count;
                        blockPaletteMap[blockStr] = paletteIndex;
                        blockPalette.Add(blockStr);
                    }
                    blockData[cBlockDataIndex++] = (ushort)paletteIndex;
                }
            }
        }

        // if (blockPalette.Count == 1) {
        //     writer.WriteBoolean(true);
        //     return;
        // }
        
        writer.WriteBoolean(false);

        // Block data
        {
            writer.WritePrefixedArray(blockPalette.ToArray(), (id, w) => w.WriteString(id));
            int bitsPerEntry = (int) Math.Ceiling(Math.Log(blockPalette.Count) / Math.Log(2));
            if (bitsPerEntry > 0) {
                writer.WritePrefixedPacketDataArray(bitsPerEntry, blockData);
            }
        }
        
        // TODO: Biome data
        {
            string[] biomePalette = ["minecraft:plains"];
            writer.WritePrefixedArray(biomePalette, (id, w) => w.WriteString(id));
            int bitsPerEntry = (int) Math.Ceiling(Math.Log(biomePalette.Length) / Math.Log(2));
            if (bitsPerEntry > 0) {
                throw new NotImplementedException("Biome data packing is not implemented yet.");
            }
        }
        
        
        // TODO: Light data
        writer.WriteByte((byte)LightContent.Missing);  // Block light
        writer.WriteByte((byte)LightContent.Missing);  // Sky light
    }

    private ChunkSection ReadSection(DataReader reader, short version, int dataVersion) {
        ChunkSection section = new();
        
        if (reader.ReadBoolean()) {
            return section;
        }
        
        string[] blockPalette = reader.ReadPrefixedArray(r => r.ReadString());
        if (blockPalette.Length > 1) {
            // Convert palette strings to state IDs once instead of repeatedly in the loop
            uint[] stateIdPalette = new uint[blockPalette.Length];
            for (int i = 0; i < blockPalette.Length; i++) {
                stateIdPalette[i] = GetBlockFromString(blockPalette[i]).StateId;
            }
            
            int bitsPerEntry = (int) Math.Ceiling(Math.Log(blockPalette.Length) / Math.Log(2));
            ushort[] blockData = reader.ReadPrefixedPacketDataArray(bitsPerEntry);  // palette indices for blocks
            for (int y = 0; y < ChunkSection.Size; y++) {
                for (int z = 0; z < ChunkSection.Size; z++) {
                    for (int x = 0; x < ChunkSection.Size; x++) {
                        int index = y * ChunkSection.Size * ChunkSection.Size + z * ChunkSection.Size + x;
                        section.Blocks[x, y, z] = stateIdPalette[blockData[index]];
                    }
                }
            }
        }
        else {
            section.Fill(GetBlockFromString(blockPalette[0]));
        }
        
        string[] biomePalette = reader.ReadPrefixedArray(r => r.ReadString());
        ushort[]? biomeData = null;
        if (biomePalette.Length > 1) {
            int bitsPerEntry = (int) Math.Ceiling(Math.Log(biomePalette.Length) / Math.Log(2));
            biomeData = reader.ReadPrefixedPacketDataArray(bitsPerEntry);
        }
        
        // TODO: Light data properly
        byte[]? blockLight = null;
        byte[]? skyLight = null;
        
        LightContent blockLightContent = (LightContent)reader.ReadByte();
        if (blockLightContent == LightContent.Present) {
            blockLight = reader.ReadArray(2048, r => r.Read());
        }
        
        LightContent skyLightContent = (LightContent)reader.ReadByte();
        if (skyLightContent == LightContent.Present) {
            skyLight = reader.ReadArray(2048, r => r.Read());
        }
        
        return section;
    }
    
    private IBlock GetBlockFromString(string blockStr) {
        // Example: "minecraft:stone[variant=granite]"
        string[] parts = blockStr.Split('[', 2);
        string blockName = parts[0];
        
        // To prevent updates breaking worlds
        if (RenamedBlocks.Map.TryGetValue(blockName, out Identifier newVal)) {
            blockName = newVal.ToString();
        }
        
        IBlock block = _registry.Blocks[blockName];
        
        if (parts.Length <= 1) {
            return block;
        }
        
        CompoundTag properties = PropertiesStringToNbt(parts[1].TrimEnd(']'));
        return block.WithState(properties);
    }
    
    private static CompoundTag PropertiesStringToNbt(string propsStr) {
        // string should look like: north=false,south=false,west=true,waterlogged=false,east=true
        // so just chuck it into a string, string dictionary
        List<INbtTag?> props = [];
        string[] pairs = propsStr.Split(',');
        foreach (string pair in pairs) {
            string[] vals = pair.Split('=');
            string key = vals[0].Trim();
            string value = vals[1].Trim();
            props.Add(new StringTag(key, value));
        }

        return new CompoundTag(null, props.ToArray());
    }
    
    private static string GetStateStringFromBlock(IBlock block) {
        // Example: "minecraft:stone[variant=granite]"
        string blockName = block.Identifier.ToString();
        string propsStr = GetPropsStringFromBlock(block);
        if (string.IsNullOrEmpty(propsStr)) {
            return blockName;  // No properties, just return the block name
        }
        return $"{blockName}[{propsStr}]";
    }

    private static string GetPropsStringFromBlock(IBlock block) {
        CompoundTag properties = block.ToStateNbt();
        List<string> props = [];
        foreach (INbtTag? tag in properties.Children) {
            if (tag is StringTag stringTag) {
                props.Add($"{stringTag.Name}={stringTag.Value}");
            }
            else {
                throw new NotSupportedException($"Unsupported tag type: {tag!.GetType().Name}");
            }
        }
        return string.Join(",", props);
    }
    
    private enum CompressionType : sbyte {
        None = 0,
        Zstd = 1
    }
    
    private enum LightContent {
        Missing = 0,
        Empty = 1,
        Full = 2,
        Present = 3
    }

    public void GetChunk(ref ChunkData chunk) {
        Chunks.TryGetValue(new Vec2<int>(chunk.ChunkX, chunk.ChunkZ), out ChunkData? data);
        if (data == null) {
            Console.WriteLine("Polar chunk not found: " + chunk.ChunkX + ", " + chunk.ChunkZ);
            return;
        }
        
        chunk = data.Clone();  // Update the original chunk reference with the loaded data
    }

    public void GetChunks(int start, int count, ChunkData[] chunks) {
        for (int i = start; i < start + count; i++) {
            if (Chunks.TryGetValue(new Vec2<int>(chunks[i].ChunkX, chunks[i].ChunkZ), out ChunkData? data)) {
                chunks[i] = data;
            } else {
                Console.WriteLine("Polar chunk not found: " + chunks[i].ChunkX + ", " + chunks[i].ChunkZ);
            }
        }
    }
}

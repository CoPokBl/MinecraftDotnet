using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
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
    
    public Dictionary<Vec2<int>, ChunkData> Chunks = null!;

    public PolarLoader(string path) : this(File.ReadAllBytes(path)) {
        
    }
    
    public PolarLoader(byte[] data) {
        Load(data);
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
        
        CompressionType compressionType = GetCompressionFromId(reader.ReadByte());
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
        byte[] outputBuffer = new byte[length];  // 10 MB output buffer
        int byteCount = decompressor.Unwrap(reader.ReadRemaining(), outputBuffer);
        if (byteCount > length) {
            throw new InvalidDataException($"Decompressed data length {byteCount} exceeds expected length {length}.");
        }
        Array.Resize(ref outputBuffer, byteCount);
        reader.Position = 0;
        reader.UpdateData(outputBuffer);
    }
    
    private static int GetXFromIndex(int index) {
        return index & 0xF;  // 0-3 bits
    }
    
    private static int GetYFromIndex(int index) {
        int y = (index & 0x07FFFFF0) >>> 4;
        if ((index & 0x08000000) != 0) y = -y;  // bit 28 indicates negative Y
        return y;  // 4-28 bits
    }
    
    private static int GetZFromIndex(int index) {
        return (index >>> 28) & 0xF;  // bits 28-31
    }

    private static ChunkData ReadChunk(DataReader reader, short version, int dataVersion, int sectionCount) {
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
                    VanillaRegistry.Data.BlockEntityTypes[id.ThrowIfNull()],
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

    private static ChunkSection ReadSection(DataReader reader, short version, int dataVersion) {
        if (reader.ReadBoolean()) {
            return new ChunkSection();
        }
        
        string[] blockPalette = reader.ReadPrefixedArray(r => r.ReadString());
        ushort[]? blockData = null;  // palette indices for blocks
        if (blockPalette.Length > 1) {
            int bitsPerEntry = (int) Math.Ceiling(Math.Log(blockPalette.Length) / Math.Log(2));
            blockData = reader.ReadPrefixedPacketDataArray(bitsPerEntry);
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

        ChunkSection section = new();
        if (blockData != null) {
            for (int y = 0; y < ChunkSection.Size; y++) {
                for (int z = 0; z < ChunkSection.Size; z++) {
                    for (int x = 0; x < ChunkSection.Size; x++) {
                        int index = y * ChunkSection.Size * ChunkSection.Size + z * ChunkSection.Size + x;
                        string key = blockPalette[blockData[index]];
                        
                        uint stateId = GetBlockFromString(key).StateId;
                        section.Blocks[x, y, z] = stateId;
                    }
                }
            }
        }
        
        return section;
    }
    
    private static IBlock GetBlockFromString(string blockStr) {
        // Example: "minecraft:stone[variant=granite]"
        string[] parts = blockStr.Split('[', 2);
        string blockName = parts[0];
        IBlock block = VanillaRegistry.Data.Blocks[blockName];
        
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
    
    private static CompressionType GetCompressionFromId(sbyte id) {
        return id switch {
            0 => CompressionType.None,
            1 => CompressionType.Zstd,
            _ => throw new ArgumentOutOfRangeException(nameof(id), $"Unknown compression type: {id}")
        };
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
        
        chunk = data;  // Update the original chunk reference with the loaded data
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

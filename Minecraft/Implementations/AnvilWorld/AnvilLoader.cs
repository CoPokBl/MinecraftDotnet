using Minecraft.Data.Blocks;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace Minecraft.Implementations.AnvilWorld;

public class AnvilLoader : ITerrainProvider {
    private readonly MinecraftRegistry _registry;
    private readonly Dictionary<string, AnvilRegionFile> _regions = [];
    
    public AnvilWorldInfo WorldInfo { get; private init; }
    
    public AnvilLoader(string path, MinecraftRegistry registry) {
        _registry = registry;
        string levelDatPath = Path.Join(path, "level");
        if (!File.Exists(levelDatPath)) {
            throw new Exception("Invalid world: level not found in the specified path.");
        }

        byte[] data = File.ReadAllBytes(levelDatPath);
        INbtTag levelDataGen = NbtReader.ReadNbt(data, true);
        
        if (levelDataGen is not CompoundTag levelDataRoot) {
            throw new Exception("Invalid world: level.dat does not contain a valid CompoundTag.");
        }
        
        CompoundTag levelData = levelDataRoot[""]!.GetCompound()["Data"].ThrowIfNull() as CompoundTag ?? throw new InvalidOperationException();
        WorldInfo = new AnvilWorldInfo(
            Hardcore: levelData["hardcore"].ThrowIfNull().GetBoolean(),
            Raining: levelData["raining"].ThrowIfNull().GetBoolean(),
            Thundering: levelData["thundering"].ThrowIfNull().GetBoolean(),
            GameType: levelData["GameType"].ThrowIfNull().GetInteger(),
            RainTicks: levelData["rainTime"].ThrowIfNull().GetInteger(),
            Spawn: new IVec3(levelData["SpawnX"].ThrowIfNull().GetInteger(),
                levelData["SpawnY"].ThrowIfNull().GetInteger(), 
                levelData["SpawnZ"].ThrowIfNull().GetInteger()),
            ThunderTicks: levelData["thunderTime"].ThrowIfNull().GetInteger(),
            Version: levelData["version"].ThrowIfNull().GetInteger(),
            LastPlayed: levelData["LastPlayed"].ThrowIfNull().GetLong(),
            Time: levelData["Time"].ThrowIfNull().GetLong(),
            LevelName: levelData["LevelName"].ThrowIfNull().GetString()
        );
        
        Console.WriteLine($"World: {WorldInfo}");
        
        // get regions
        string regionPath = Path.Join(path, "region");
        if (!Directory.Exists(regionPath)) {
            throw new Exception("Invalid world: region directory not found.");
        }
        
        string[] regionFiles = Directory.GetFiles(regionPath, "r.*.*.mca");
        if (regionFiles.Length == 0) {
            throw new Exception("Invalid world: no region files found.");
        }

        foreach (string regionFile in regionFiles) {
            Console.WriteLine($"Found region file: {regionFile}");
            AnvilRegionFile region = new(regionFile);
            _regions[Path.GetFileName(regionFile)] = region;
        }
    }

    public ChunkData? GetChunkData(int chunkX, int chunkZ) {
        int regionX = chunkX >> 5; // Divide by 32
        int regionZ = chunkZ >> 5; // Divide by 32
        string regionName = RegionNameFor(regionX, regionZ);
        
        if (!_regions.TryGetValue(regionName, out AnvilRegionFile? region)) {
            Console.WriteLine($"Region {regionName} not found.");
            return null;
        }
        
        INbtTag? chunkTag = region.ReadChunkData(chunkX, chunkZ);
        
        if (chunkTag is not CompoundTag chunk) {
            // Console.WriteLine($"Chunk ({chunkX}, {chunkZ}) not found in region {regionName}.");
            return null;
        }
        
        // Console.WriteLine(chunk.ToJsonString());
        string status = chunk["status"]?.GetString() ?? "Unknown";
        // Console.WriteLine("Chunk Status: " + status);
        
        // Load actual chunk data
        ChunkData data = new();
        INbtTag? sectionsTag = chunk["sections"];
        if (sectionsTag is not ListTag sectionsList) {
            Console.WriteLine(chunk.ToJsonString());
            throw new Exception($"Invalid chunk data: 'sections' tag not found or is not a ListTag. Null: {sectionsTag == null}");
        }
        
        // Allocate once for block state indices
        int[] blockStateIndices = new int[ChunkSection.Size * ChunkSection.Size * ChunkSection.Size];
        
        foreach (INbtTag sectionTag in sectionsList.Tags) {
            CompoundTag sectionData = sectionTag.GetCompound();
            int sectionY = sectionData["Y"].GetInteger();
            // Console.WriteLine($"Section Y: {sectionY}");
            int yOffset = sectionY * 16;
            
            // TODO: Throw out invalid sections, see Minestom implementation (above and below valid area)
            if (sectionY < -4 || sectionY > 11) {
                // Console.WriteLine($"Invalid section Y: {sectionY}, skipping.");
                continue;
            }
            
            ChunkSection section = data.Sections[sectionY + 4];  // Sections are indexed from -4 to 11, so we add 4 to the Y value to get index
            
            CompoundTag blockStates = sectionData["block_states"].GetCompound();
            ListTag blockPalette = blockStates["palette"].GetList();  // list of compound tags
                    
            IBlock[] palette = LoadPalette(blockPalette);
            if (palette.Length == 1) {
                // Single block state, no need to process further
                section.Fill(palette[0]); // 0 for air, 1 for solid block
                // Console.WriteLine("Single block state found: " + palette[0]);
            }
            else {
                long[] packedStates = blockStates["data"].GetLongs();
                UnpackPalette(blockStateIndices, packedStates, packedStates.Length * 64 / blockStateIndices.Length);
                
                for (int y = 0; y < ChunkSection.Size; y++) {
                    for (int z = 0; z < ChunkSection.Size; z++) {
                        for (int x = 0; x < ChunkSection.Size; x++) {
                            int blockIndex = y * ChunkSection.Size * ChunkSection.Size + z * ChunkSection.Size + x;
                            int paletteIndex = blockStateIndices[blockIndex];
                            IBlock block = palette[paletteIndex];
                            data.SetBlock(x, y + yOffset + 64, z, block);
                            // if (y + yOffset < 5) {
                            //     Console.WriteLine($"Block: {x},{y + yOffset},{z} = {block} (Index: {paletteIndex})");
                            // }
                        }
                    }
                }
            }
        }
        
        return data;
    }

    private static void UnpackPalette(int[] outp, long[] data, int bitsPerEntry) {
        double intsPerLong = Math.Floor(64d / bitsPerEntry);
        int intsPerLongCeil = (int)Math.Ceiling(intsPerLong);

        long mask = (1L << bitsPerEntry) - 1L;
        for (int i = 0; i < outp.Length; i++) {
            int longIndex = i / intsPerLongCeil;
            int subIndex = i % intsPerLongCeil;

            outp[i] = (int) ((data[longIndex] >>> (bitsPerEntry * subIndex)) & mask);
        }
    }

    private IBlock[] LoadPalette(ListTag paletteTag) {
        IBlock[] palette = new IBlock[paletteTag.Tags.Length];
        for (int i = 0; i < paletteTag.Tags.Length; i++) {
            if (paletteTag.Tags[i] is CompoundTag compound) {
                string name = compound["Name"].GetString();
                IBlock block = _registry.Blocks[name];
                if (compound.ChildrenMap.TryGetValue("Properties", out INbtTag? propsTag)) {
                    block = block.WithState(propsTag.GetCompound());
                }
                palette[i] = block;
            } else {
                throw new InvalidCastException("Expected a CompoundTag in the block palette.");
            }
        }
        return palette;
    }
    
    private static string RegionNameFor(int regionX, int regionZ) {
        return $"r.{regionX}.{regionZ}.mca";
    }

    public record AnvilWorldInfo(
        bool Hardcore,
        bool Raining,
        bool Thundering,
        int GameType,
        int RainTicks,
        IVec3 Spawn,
        int ThunderTicks,
        int Version,
        long LastPlayed,
        long Time,
        string LevelName);

    public ChunkData GetChunk(ChunkPosition chunk) {
        try {
            ChunkData data = GetChunkData(chunk.X, chunk.Z) ?? new ChunkData();
            data.ChunkX = chunk.X;
            data.ChunkZ = chunk.Z;
            return data;
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<ChunkData> GetChunks(int count, params ChunkPosition[] chunks) {
        List<ChunkData> chunkDataList = [];
        foreach (ChunkPosition chunk in chunks) {
            ChunkData? data = GetChunkData(chunk.X, chunk.Z);
            if (data == null) continue;
            data.ChunkX = chunk.X;
            data.ChunkZ = chunk.Z;
            chunkDataList.Add(data);
        }
        
        return chunkDataList;
    }
}

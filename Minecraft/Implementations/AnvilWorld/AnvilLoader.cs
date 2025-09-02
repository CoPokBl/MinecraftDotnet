using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace Minecraft.Implementations.AnvilWorld;

/// <summary>
/// Terrain provider for worlds stored in the Anvil format.
/// </summary>
/// <remarks>
/// Keep in mind that worlds that are outdated may not load properly.
/// If you are missing chunks then try loading the world in a newer version of Minecraft
/// and trying again.
/// </remarks>
public class AnvilLoader : ITerrainProvider {
    private readonly MinecraftRegistry _registry;
    private readonly Dictionary<string, AnvilRegionFile> _regions = [];
    private readonly int _minY;

    public AnvilWorldInfo? WorldInfo { get; private init; }
    
    public AnvilLoader(string path, MinecraftRegistry registry, int minY = -64) {
        if (minY % 16 != 0) {
            throw new ArgumentException("minY must be a multiple of 16.", nameof(minY));
        }
        
        _registry = registry;
        _minY = minY;
        string levelDatPath = Path.Join(path, "level");
        if (File.Exists(levelDatPath)) {
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
                Spawn: new Vec3<int>(levelData["SpawnX"].ThrowIfNull().GetInteger(),
                    levelData["SpawnY"].ThrowIfNull().GetInteger(), 
                    levelData["SpawnZ"].ThrowIfNull().GetInteger()),
                ThunderTicks: levelData["thunderTime"].ThrowIfNull().GetInteger(),
                Version: levelData["version"].ThrowIfNull().GetInteger(),
                LastPlayed: levelData["LastPlayed"].ThrowIfNull().GetLong(),
                Time: levelData["Time"].ThrowIfNull().GetLong(),
                LevelName: levelData["LevelName"].ThrowIfNull().GetString()
            );
        }
        
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
            AnvilRegionFile region = new(regionFile);
            _regions[Path.GetFileName(regionFile)] = region;
        }
    }

    public void GetChunkData(ref ChunkData data) {
        int chunkX = data.ChunkX;
        int chunkZ = data.ChunkZ;
        
        int regionX = chunkX >> 5; // Divide by 32
        int regionZ = chunkZ >> 5; // Divide by 32
        string regionName = RegionNameFor(regionX, regionZ);
        
        if (!_regions.TryGetValue(regionName, out AnvilRegionFile? region)) {
            return;
        }
        
        INbtTag? chunkTag = region.ReadChunkData(chunkX, chunkZ);
        
        if (chunkTag is not CompoundTag chunk) {
            return;
        }
        
        string status = chunk["status"]?.GetString() ?? "Unknown";
        
        // Load actual chunk data
        INbtTag? sectionsTag = chunk["sections"] ?? chunk["Sections"];
        if (sectionsTag is not ListTag sectionsList) {
            // Probably old format, just ignore
            return;
            // throw new Exception($"Invalid chunk data: 'sections' tag not found or is not a ListTag. Null: {sectionsTag == null}");
        }
        
        // Allocate once for block state indices
        int[] blockStateIndices = new int[ChunkSection.Size * ChunkSection.Size * ChunkSection.Size];
        
        foreach (INbtTag sectionTag in sectionsList.Tags) {
            CompoundTag sectionData = sectionTag.GetCompound();
            int sectionY = sectionData["Y"].GetInteger();
            int yOffset = sectionY * ChunkSection.Size;

            int minSection = _minY / ChunkSection.Size;
            int maxSection = (_minY + data.WorldHeight) / ChunkSection.Size;
            if (sectionY < minSection || sectionY > maxSection) {
                continue;
            }
            
            ChunkSection section = data.Sections[sectionY - minSection];
            
            CompoundTag blockStates = sectionData["block_states"].GetCompound();
            ListTag blockPalette = blockStates["palette"].GetList();  // list of compound tags
                    
            IBlock[] palette = LoadPalette(blockPalette);
            if (palette.Length == 1) {
                // Single block state, no need to process further
                section.Fill(palette[0]); // 0 for air, 1 for solid block
                // Console.WriteLine("Single block state found: " + palette[0]);
            }
            else {
                // Console.WriteLine(chunk.ToJsonString());
                long[] packedStates = blockStates["data"].GetLongs();
                UnpackPalette(blockStateIndices, packedStates, packedStates.Length * 64 / blockStateIndices.Length);
                
                for (int y = 0; y < ChunkSection.Size; y++) {
                    for (int z = 0; z < ChunkSection.Size; z++) {
                        for (int x = 0; x < ChunkSection.Size; x++) {
                            int blockIndex = y * ChunkSection.Size * ChunkSection.Size + z * ChunkSection.Size + x;
                            int paletteIndex = blockStateIndices[blockIndex];
                            IBlock block = palette[paletteIndex];
                            data.SetBlock(x, y + yOffset + 64, z, block);
                        }
                    }
                }
            }
        }
        
        // Block entities
        ListTag blockEntitiesTag = chunk["block_entities"].GetList();
        foreach (INbtTag blockEntityGeneric in blockEntitiesTag.Tags) {
            CompoundTag blockEntityData = blockEntityGeneric.GetCompound();
            
            // get important props
            string id = blockEntityData["id"].GetString();
            IBlockEntityType type = _registry.BlockEntityTypes[id];
            
            int x = blockEntityData["x"].GetInteger();
            int y = blockEntityData["y"].GetInteger();
            int z = blockEntityData["z"].GetInteger();
            bool _ = blockEntityData["keepPacked"].GetBoolean();  // What is this prop for? We'll ignore it for now
            
            // Create a new compound tag for the block entity
            // but without any of the above properties
            string[] excludeProps = ["id", "x", "y", "z", "keepPacked"];
            CompoundTag entityData = new(null, blockEntityData.Children.Where(t => 
                !excludeProps.Contains(t?.GetName())).ToArray());
            data.BlockEntities[new Vec3<int>(x, y, z)] = new BlockEntity(x, y, z, type, entityData);
        }
    }

    public ChunkData[] GetAllChunks() {
        List<ChunkData> chunks = [];
        foreach ((string regionName, AnvilRegionFile region) in _regions) {
            Console.WriteLine("Checking region: " + regionName);
            string[] nameParts = regionName.Split('.');
            int regionX = int.Parse(nameParts[1]);
            int regionZ = int.Parse(nameParts[2]);
            
            for (int x = 0; x < 32; x++) {
                for (int z = 0; z < 32; z++) {
                    int chunkX = regionX * 32 + x;
                    int chunkZ = regionZ * 32 + z;
                    if (region.HasChunkData(chunkX, chunkZ)) {
                        ChunkData chunkData = new(ChunkData.VanillaOverworldHeight) {
                            ChunkX = chunkX,
                            ChunkZ = chunkZ
                        };
                        GetChunkData(ref chunkData);
                        chunks.Add(chunkData);
                        Console.WriteLine("Got chunk at " + chunkX + ", " + chunkZ + " in region " + regionName);
                    }
                }
            }
        }
        return chunks.ToArray();
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
        Vec3<int> Spawn,
        int ThunderTicks,
        int Version,
        long LastPlayed,
        long Time,
        string LevelName);

    public void GetChunk(ref ChunkData data) {
        try {
            GetChunkData(ref data);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public void GetChunks(int start, int count, ChunkData[] chunks) {
        for (int i = start; i < start + count; i++) {
            GetChunk(ref chunks[i]);
        }
    }
}

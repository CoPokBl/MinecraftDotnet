using System.Buffers.Binary;
using NBT;

namespace Minecraft.Implementations.AnvilWorld;

public class AnvilRegionFile : IDisposable {
    private const int SectorSize = 4096; // 4 KiB
    private const int MaxEntryCount = 1024; // 1024 entries per region file
    
    // Internal data stuff
    private readonly List<bool> _freeSectors = new(2); // ???
    private readonly int[] _locations = new int[MaxEntryCount]; // Locations of entries in the region file
    private readonly int[] _timestamps = new int[MaxEntryCount]; // Timestamps of entries in the region file
    private readonly FileStream _file;

    public AnvilRegionFile(string filePath) {
        _file = File.Open(filePath, FileMode.Open);
        ReadHeader();
    }
    
    private void ReadHeader() {
        _file.Seek(0, SeekOrigin.Begin);
            
        // Read header (first 8192 bytes)
        long totalSectors = (_file.Length - 1) / SectorSize + 1; // Round up, last sector does not need to be full size
        for (int i = 0; i < totalSectors; i++) _freeSectors.Add(true);
        _freeSectors[0] = false;  // First sector is locations
        _freeSectors[1] = false;  // Second sector is timestamps

        // Read locations
        _file.Seek(0, SeekOrigin.Begin);
        for (int i = 0; i < MaxEntryCount; i++) {
            int location = _locations[i] = ReadInteger(_file);
            if (location != 0) {
                MarkLocation(location, false);
            }
        }

        // Read timestamps
        for (int i = 0; i < MaxEntryCount; i++) {
            _timestamps[i] = ReadInteger(_file);
        }
    }

    public INbtTag? ReadChunkData(int chunkX, int chunkZ) {
        if (!HasChunkData(chunkX, chunkZ)) return null;

        lock (_file) {
            int location = _locations[GetChunkIndex(chunkX, chunkZ)];
            _file.Seek((long) (location >> 8) * SectorSize, SeekOrigin.Begin); // Move to start of first sector
            int length = ReadInteger(_file);
            int compressionType = ReadByte(_file);
            NbtCompressionType compression = compressionType switch {
                1 => NbtCompressionType.GZip,
                2 => NbtCompressionType.ZLib,
                3 => NbtCompressionType.None,
                _ => throw new IOException("Unsupported compression type: " + compressionType)
            };

            // Read the raw content
            byte[] data = new byte[length - 1];
            _file.ReadExactly(data);

            // Parse it as a compound tag
            return NbtReader.ReadNbt(data, true, compression).GetCompound()[""];
        }
    }
    
    public bool HasChunkData(int chunkX, int chunkZ) {
        int index = GetChunkIndex(chunkX, chunkZ);
        return _locations[index] != 0;
    }
    
    private static int GetChunkIndex(int x, int z) {
        return (x & 0x1F) + ((z & 0x1F) << 5);
    }
    
    private static int ChunkToRegion(int coord) {
        return coord >> 5; // Divide by 32
    }
    
    private void MarkLocation(int location, bool free) {
        int sectorCount = location & 0xFF;
        int sectorStart = location >> 8;
        for (int i = sectorStart; i < sectorStart + sectorCount; i++) {
            _freeSectors[i] = free;
        }
    }
    
    private static int ReadInteger(FileStream file) {
        byte[] buffer = new byte[4];
        file.ReadExactly(buffer, 0, 4);
        return BinaryPrimitives.ReadInt32BigEndian(buffer);
    }
    
    public static byte ReadByte(FileStream file) {
        int value = file.ReadByte();
        if (value == -1) throw new EndOfStreamException("Unexpected end of stream while reading byte.");
        return (byte)value;
    }
    
    public void Dispose() {
        _file.Dispose();
    }
}
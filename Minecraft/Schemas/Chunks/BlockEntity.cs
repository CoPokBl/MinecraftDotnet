using Minecraft.Data;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Registry;
using NBT;

namespace Minecraft.Schemas.Chunks;

/// <summary>
/// Represents an encoded block entity in a chunk.
/// See https://minecraft.wiki/w/Java_Edition_protocol/Packets#Chunk_Data
/// <p/>
/// Only used by <see cref="ChunkData"/>.
/// </summary>
/// <param name="PackedXz">The packed coordinate byte (Use <see cref="BlockEntity(int, int, int, IBlockEntityType, INbtTag)"/> if unknown).</param>
/// <param name="Y">The Y position of the block entity in the world.</param>
/// <param name="Type">The type of the block entity</param>
/// <param name="Data">The data in this block entity.</param>
public record BlockEntity(byte PackedXz, short Y, IBlockEntityType Type, INbtTag Data) : INetworkType<BlockEntity> {
    
    /// <summary>
    /// Create a new BlockEntity.
    /// </summary>
    /// <param name="x">The chunk relative X coordinate of this block.</param>
    /// <param name="y">The Y coordinate of this block.</param>
    /// <param name="z">The chunk relative Z coordinate of this block.</param>
    /// <param name="type">The type of the block entity.</param>
    /// <param name="data">The data in this block entity.</param>
    public BlockEntity(int x, int y, int z, IBlockEntityType type, INbtTag data) : this(
        (byte)(((x & 15) << 4) | (z & 15)), 
        (short)y, 
        type, 
        data) { }

    /// <summary>
    /// The decoded X coordinate of this block entity in the chunk.
    /// </summary>
    public int X => PackedXz >> 4;
    
    /// <summary>
    /// The decoded Z coordinate of this block entity in the chunk.
    /// </summary>
    public int Z => PackedXz & 0xF;

    public DataWriter WriteData(BlockEntity val, DataWriter writer, MinecraftRegistry registry) {
        writer.Write(val.PackedXz);
        writer.WriteShort(val.Y);
        writer.WriteVarInt(val.Type.ProtocolId);
        writer.WriteNbt(val.Data);
        return writer;
    }
    
    public static BlockEntity ReadData(DataReader reader, MinecraftRegistry registry) {
        byte packedXz = reader.Read();
        short y = reader.ReadShort();
        int typeId = reader.ReadVarInt();
        IBlockEntityType type = registry.BlockEntityTypes[typeId];
        INbtTag data = reader.ReadNbt();
        
        return new BlockEntity(packedXz, y, type, data);
    }
}

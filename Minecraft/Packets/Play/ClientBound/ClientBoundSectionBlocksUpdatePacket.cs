using Minecraft.Registry.SubRegistries;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

// https://minecraft.wiki/w/Java_Edition_protocol/Packets#Update_Section_Blocks
public class ClientBoundSectionBlocksUpdatePacket : ClientBoundPacket
{
    public override Identifier Identifier => "minecraft:section_blocks_update";

    public required Vec3<int> ChunkSectionPosition { get; init; }

    public required BlockUpdate[] BlockUpdates { get; init; }

    protected override DataWriter WriteData(DataWriter w)
    {
        return w
            .WriteLong(EncodeChunkSectionPosition(ChunkSectionPosition))
            .WritePrefixedArray(
                BlockUpdates, 
                (block, wr) => wr.WriteVarLong(EncodeBlock(block))
            );
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) =>
    {
        long chunkSectionPositionEncoded = r.ReadLong();
        long[] blocksEncoded = r.ReadPrefixedArray(r => r.ReadVarLong());

        BlockUpdate[] blockUpdates = new BlockUpdate[blocksEncoded.Length];

        for (int i = 0; i < blocksEncoded.Length; i++)
            blockUpdates[i] = DecodeBlock(blocksEncoded[i], reg.Blocks);

        return new ClientBoundSectionBlocksUpdatePacket()
        {
            ChunkSectionPosition = DecodeChunkSectionPosition(chunkSectionPositionEncoded),
            BlockUpdates = blockUpdates
        };
    };

    /// <summary>
    /// Chunk section coordinate (encoded chunk x and z with each 22 bits, and section y with 20 bits, from left to right).
    /// 22 bits x | 22 bits z | 20 bits y
    /// </summary>
    private static long EncodeChunkSectionPosition(Vec3<int> pos)
    {
        long encodedX = ((long)pos.X & 0x3FFFFF) << 42; // 22bit
        long encodedZ = ((long)pos.Z & 0x3FFFFF) << 20; // 22bit
        long encodedY = (long)pos.Y & 0x0FFFFF; // 20bit

        return encodedX | encodedZ | encodedY;
    }

    private static Vec3<int> DecodeChunkSectionPosition(long encoded)
    {
        int x = (int)((encoded >> 42) & 0x3FFFFF);
        int z = (int)((encoded >> 20) & 0x3FFFFF);
        int y = (int)(encoded & 0x0FFFFF);

        return new Vec3<int>(x, y, z);
    }

    /// <summary>
    /// Prefixed Array of VarLong
    /// Each entry is composed of the block state id, shifted left by 12, 
    /// and the relative block position in the chunk section (4 bits for x, z, and y, from left to right).
    /// 
    /// 12 bits stateId | 4 bits x | 4 bits z | 4 bits y
    /// </summary>
    private static long EncodeBlock(BlockUpdate blockUpdate)
    {
        long encodedStateId = blockUpdate.Block.StateId << 12;
        long encodedX = (blockUpdate.Location.X & 0xF) << 8;
        long encodedZ = (blockUpdate.Location.Z & 0xF) << 4;
        long encodedY = blockUpdate.Location.Y & 0xF;

        return encodedStateId | encodedX | encodedZ | encodedY;
    }

    private static BlockUpdate DecodeBlock(long encoded, BlockRegistry registry) 
    {
        int stateId = (int)(encoded >> 12);
        int x = (int)((encoded >> 8) & 0xF);
        int z = (int)((encoded >> 4) & 0xF);
        int y = (int)encoded & 0xF;

        return new BlockUpdate()
        {
            Block = registry[stateId],
            Location = new Vec3<int>(x, y, z)
        };
    }
}

using System.Collections.Concurrent;
using Minecraft.Data.Blocks;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ClientLib;

public class ClientWorld {
    private readonly MinecraftClient _client;
    
    public Identifier Name { get; }
    public int Type { get; }
    public int SeaLevel { get; }
    public bool Flat { get; }
    public long HashedSeed { get; }
    public Vec2<int> CenterChunk = Vec2<int>.Zero;
    public Dimension Dimension => _client.GetDimension(Name) 
        ?? throw new InvalidOperationException($"Dimension {Name} not found in dimension manager.");
    
    private readonly ConcurrentDictionary<Vec2<int>, ChunkData> _chunks = new();
    
    public static readonly Func<MinecraftClient, ClientWorld> Default = c => new ClientWorld(
        c, 
        "minecraft:overworld", 
        0, 
        64, 
        false, 
        0);
    
    public ClientWorld(MinecraftClient client, Identifier name, int type, int seaLevel, bool flat, long hashedSeed) {
        Name = name;
        Type = type;
        SeaLevel = seaLevel;
        Flat = flat;
        HashedSeed = hashedSeed;
        _client = client;
    }

    public ClientWorld(MinecraftClient client, ClientBoundRespawnPacket respawnPacket) : this(
        client,
        respawnPacket.DimensionName, 
        respawnPacket.DimensionType, 
        respawnPacket.SeaLevel,
        respawnPacket.IsFlat,
        respawnPacket.HashedSeed) { }

    internal void HandlePacket(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundSetCenterChunkPacket cc: {
                CenterChunk = new Vec2<int>(cc.X, cc.Z);
                break;
            }

            case ClientBoundChunkDataAndUpdateLightPacket cdul: {
                _chunks[new Vec2<int>(cdul.ChunkX, cdul.ChunkZ)] = cdul.Data;
                break;
            }
        }
    }
    
    #region data_accessors
    
    public ChunkData? RetrieveChunk(Vec2<int> pos) {
        return _chunks.GetValueOrDefault(pos);
    }

    public IBlock GetBlock(Vec3<int> pos) {
        CheckY(pos.Y);

        Vec2<int> chunk = GetChunkPos(pos);
        Vec3<int> chunkLocalPos = ToChunkLocalPos(GameToProtocolPos(pos));

        ChunkData? data = RetrieveChunk(chunk);
        if (data == null) {
            throw new InvalidOperationException($"Chunk at {chunk} is not loaded. Please load the chunk before accessing blocks.");
        }

        return data.LookupBlock(chunkLocalPos, _client.ProtocolRegistry);
    }

    public IBlock GetBlock(Vec3<double> pos) {
        // Convert Vec3 to IVec3
        return GetBlock(pos.ToBlockPos());
    }

    public IBlock GetBlockOr(Vec3<int> pos, IBlock def) {
        return IsInBounds(pos) ? IsBlockLoaded(pos) ? GetBlock(pos) : def : def;
    }

    public IBlock GetBlockOr(Vec3<double> pos, IBlock def) {
        return GetBlockOr(pos.ToBlockPos(), def);
    }

    public BlockEntity? GetBlockData(Vec3<int> pos) {
        CheckY(pos.Y);

        Vec2<int> chunk = GetChunkPos(pos);
        Vec3<int> chunkLocalPos = ToChunkLocalPos(pos);
        return RetrieveChunk(chunk)!.BlockEntities!.GetValueOrDefault(chunkLocalPos, null);
    }

    #endregion

    #region conversions

    // non-static so that you can use it with the world instance
    // eg. world.GetChunkPos instead of World.GetChunkPos
    // I think it's nicer this way
    public Vec2<int> GetChunkPos(Vec3<double> pos) {
        return new Vec2<int>((int)Math.Floor(pos.X / 16), (int)Math.Floor(pos.Z / 16));
    }

    private static Vec3<int> ToChunkLocalPos(Vec3<int> pos) {
        return new Vec3<int>((pos.X % 16 + 16) % 16, pos.Y, (pos.Z % 16 + 16) % 16);
    }

    /// <summary>
    /// Converts a protocol position to a game position.
    /// <p/>
    /// This is used because in the protocol Y=0 is Y=-64 in game.
    /// </summary>
    /// <param name="pos">The position to convert</param>
    /// <returns>The new position.</returns>
    private Vec3<int> ProtocolToGamePos(Vec3<int> pos) {
        return new Vec3<int>(pos.X, pos.Y + Dimension.MinY, pos.Z);
    }

    private Vec3<int> GameToProtocolPos(Vec3<int> pos) {
        return new Vec3<int>(pos.X, pos.Y - Dimension.MinY, pos.Z);
    }

    #endregion
    
    #region checks

    public bool IsBlockLoaded(Vec3<int> pos) {
        CheckY(pos.Y);
        
        Vec2<int> chunk = GetChunkPos(pos);
        return IsChunkLoaded(chunk);
    }
    
    public bool IsChunkLoaded(Vec2<int> pos) {
        return _chunks.ContainsKey(pos);
    }
    
    public bool IsInBounds(Vec3<double> pos) {
        return pos.Y >= Dimension.MinY && pos.Y < Dimension.MinY + Dimension.Height;
    }

    private void CheckY(int y) {
        if (y < Dimension.MinY || y > Dimension.MinY + Dimension.Height) {
            throw new ArgumentOutOfRangeException(nameof(y), "Y position is out of bounds for this dimension.");
        }
    }

    #endregion
}

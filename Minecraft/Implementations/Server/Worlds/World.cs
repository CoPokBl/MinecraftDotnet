using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Worlds;

public class World(ITerrainProvider provider, int viewDistance = 8) {
    private readonly List<PlayerConnection> _players = [];
    private const string LoadedChunksDataId = "minecraftdotnet:world:loadedchunks";

    public void AddPlayer(PlayerConnection connection) {
        connection.SendPacket(new ClientBoundGameEventPacket(GameEvent.StartWaitingForLevelChunks, 0)).AsTask().ContinueWith(_2 => {
            connection.Events.AddListener<PacketHandleEvent>(e => {
                Vec3 pos;
                switch (e.Packet) {
                    case ServerBoundSetPlayerPositionPacket sp:
                        pos = sp.Position;
                        break;
                    case ServerBoundSetPlayerPosAndRotPacket spar:
                        pos = spar.Position;
                        break;
                    default:
                        return;
                }

                ChunkPosition chunkPos = new((int)Math.Floor(pos.X / 16), (int)Math.Floor(pos.Z / 16));
                List<ChunkPosition> loaded = GetLoadedChunks(connection);

                List<MinecraftPacket> neededPackets = [];
                foreach (ChunkPosition loadedChunk in loaded) {
                    if (!loadedChunk.IsWithinRadiusOf(chunkPos, viewDistance)) {
                        neededPackets.Add(new ClientBoundUnloadChunkPacket(loadedChunk));  // not within radius, unload it
                    }
                }
                
                // Okay now get everything that should be loaded
                List<ChunkPosition> visibleChunks = [];
                for (int x = 0; x < viewDistance * 2 + 1; x++) {
                    for (int z = 0; z < viewDistance * 2 + 1; z++) {
                        visibleChunks.Add(new ChunkPosition(x + chunkPos.X - viewDistance, z + chunkPos.Z - viewDistance));
                    }
                }

                foreach (ChunkPosition chunk in visibleChunks) {
                    if (!loaded.Any(c => c.Equals(chunk))) {
                        neededPackets.Add(GetChunkPacket(chunk));
                        Console.WriteLine($"Loading {chunk.X}, {chunk.Z}");
                    }
                }
                
                SetLoadedChunks(connection, visibleChunks);

                if (neededPackets.Count != 0) {
                    neededPackets.Add(new ClientBoundSetCenterChunkPacket(chunkPos));
                    _ = connection.SendPackets(neededPackets.ToArray());
                }
            });
        });
        _players.Add(connection);
    }

    public void RemovePlayer(PlayerConnection connection) {
        // idk
        _players.Remove(connection);
    }

    public static List<ChunkPosition> GetLoadedChunks(PlayerConnection connection) {
        if (connection.Data.TryGetValue(LoadedChunksDataId, out object? value)) return (List<ChunkPosition>)value!;
        value = new List<ChunkPosition>();
        connection.Data.Add(LoadedChunksDataId, value);

        return (List<ChunkPosition>)value;
    }

    public static void SetLoadedChunks(PlayerConnection connection, List<ChunkPosition> chunks) {
        connection.Data[LoadedChunksDataId] = chunks;
    }

    public ClientBoundChunkDataAndUpdateLightPacket GetChunkPacket(ChunkPosition pos) {
        ChunkData data = new();
        for (int x = 0; x < 16; x++) {
            for (int y = 0; y < 384; y++) {
                for (int z = 0; z < 16; z++) {
                    int absX = pos.X * 16 + x;
                    int absZ = pos.Z * 16 + z;
                    data.SetBlock(x, y, z, provider.GetBlock(absX, y, absZ));
                }
            }
        }
        ClientBoundChunkDataAndUpdateLightPacket packet = new(pos.X, pos.Z, data, new LightData());
        return packet;
    }
}
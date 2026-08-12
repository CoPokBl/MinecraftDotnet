using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Worlds;

/// <summary>
/// A chunk lit before the chunks around it have loaded holds the best light available at the time,
/// not the light it settles on, so the world computes it again and sends it when they arrive. What
/// it must not do is let that correction overtake the chunk it is correcting: chunk packets go
/// through the per player queue a few per tick, and the client drops light for a chunk it has not
/// been given, so a correction that arrives first leaves the wrong light on screen for good.
/// <para>
/// Which is what the ramen sky wars map shows. Its island straddles four chunks, and the north west
/// one comes out 202 sky levels wrong, fifteen against one under the bowl, when it is lit without
/// the two chunks beside it. Whichever corner loses that race stays dark.
/// </para>
/// </summary>
[TestFixture]
public class ChunkLightDeliveryTest {
    private static readonly Vec2<int> Centre = new(0, 0);
    private static readonly Vec2<int> West = new(-1, 0);

    /// <summary>
    /// A roof over the middle chunk and nothing else, so everything under it is lit from the sides
    /// by the chunks around it. That is the island's overhang with the shape it needs and no more.
    /// </summary>
    private sealed class OverhangTerrain : ITerrainProvider {
        private const int RoofY = 100;

        public void GetChunk(ref ChunkData chunk) {
            if (chunk.ChunkX != Centre.X || chunk.ChunkZ != Centre.Y) {
                chunk.PackData();
                return;
            }

            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    chunk.SetBlock(x, RoofY, z, Block.Stone.StateId);
                }
            }
            chunk.PackData();
        }
    }

    /// <summary>Holds one chunk back until the test lets it through, which is the whole race.</summary>
    private sealed class GatedTerrain(ITerrainProvider inner, Vec2<int> held) : ITerrainProvider {
        public readonly ManualResetEventSlim Gate = new(false);

        public void GetChunk(ref ChunkData chunk) {
            if (chunk.ChunkX == held.X && chunk.ChunkZ == held.Y) {
                Gate.Wait(TimeSpan.FromSeconds(30));
            }
            inner.GetChunk(ref chunk);
        }
    }

    private sealed class RecordingConnection : PlayerConnection {
        private readonly List<MinecraftPacket> _sent = [];

        public List<MinecraftPacket> Sent {
            get {
                lock (_sent) return [.._sent];
            }
        }

        protected override void SendPacketInternal(MinecraftPacket packet) {
            lock (_sent) _sent.Add(packet);
        }

        public override void InitialiseEncryption() { }

        public override Task HandlePackets() => Task.CompletedTask;

        public override void Disconnect() { }
    }

    [Test]
    public void TheLastLightAClientIsSentIsTheLightWithEveryNeighbourIn() {
        ManagedMinecraftServer server = ManagedMinecraftServer.New();
        server.ViewDistance = 1;          // the eight around the player and nothing else
        server.WorldTickDelayMs = 0;      // every tick flushes
        server.WorldPacketsPerTick = 1;   // one packet a tick, which is what leaves a chunk queued
        server.TargetTicksPerSecond = 4;  // slowly, so the queue is somewhere to look rather than a moment

        GatedTerrain terrain = new(new OverhangTerrain(), West);
        World world = server.CreateWorld(terrain, "minecraft:overworld");
        server.Start();

        byte[] wanted = SkyLevels(Settled(world.Dimension.Height, withWest: true));

        // None of this means anything unless the held back chunk is one the middle chunk's light
        // depends on, which is the island's corner in miniature.
        Assert.That(SkyLevels(Settled(world.Dimension.Height, withWest: false)), Is.Not.EqualTo(wanted),
            "the terrain lights the same with and without the chunk being held back");

        RecordingConnection connection = new();
        Player player = new(server, connection, "test") {
            Position = new Vec3<double>(8, 120, 8)
        };
        world.AddPlayer(player);

        // The middle chunk and the seven neighbours that are not being held back are lit, and their
        // packets built, while it is still missing. What they hold for the middle chunk is the
        // light without it. Nothing has been flushed yet: the queue only moves when a tick runs.
        WaitUntil(() => Around(Centre).Append(Centre).All(c => c == West || world.IsChunkLoaded(c)));
        WaitUntil(() => ChunkPackets(connection, Centre).Count > 0);

        // A tick moves the built packets into the player's queue, where the middle chunk's now sits
        // holding the light it was given without its neighbour. Only one packet leaves per tick and
        // the centre marker was queued ahead of it, so it is still in there.
        WaitUntil(() => world.DoesPlayerHaveChunkLoaded(player, Centre));
        int beforeGate = ChunkPackets(connection, Centre).Count;

        // Letting it through is what makes the world compute the middle chunk again and send it.
        terrain.Gate.Set();
        WaitUntil(() => world.IsChunkLoaded(West));
        WaitUntil(() => ChunkPackets(connection, Centre).Count > beforeGate);

        WaitUntilQuiet(connection);
        server.Stop();

        List<ClientBoundChunkDataAndUpdateLightPacket> got = ChunkPackets(connection, Centre);
        Assert.That(got, Is.Not.Empty, "the client was never sent the middle chunk");

        byte[] last = SkyLevels(got[^1].Light);
        int wrong = 0;
        int first = -1;
        for (int i = 0; i < wanted.Length; i++) {
            if (last[i] == wanted[i]) continue;
            wrong++;
            if (first < 0) first = i;
        }

        Assert.That(wrong, Is.Zero,
            wrong == 0 ? "" : $"the last light the client holds for {Centre} is {wrong} levels out, " +
                              $"first at ({first & 15}, {first >> 8}, {first >> 4 & 15}): " +
                              $"got {last[first]}, wanted {wanted[first]}");
    }

    /// <summary>
    /// The middle chunk's light on its own, with the chunks around it there or with the west one
    /// missing the way the world sees it mid load.
    /// </summary>
    private static LightData Settled(int height, bool withWest) {
        OverhangTerrain terrain = new();
        Dictionary<Vec2<int>, ChunkData> chunks = new();

        ChunkData Chunk(Vec2<int> pos) {
            if (chunks.TryGetValue(pos, out ChunkData? existing)) return existing;
            ChunkData data = new(height) { ChunkX = pos.X, ChunkZ = pos.Y };
            terrain.GetChunk(ref data);
            chunks[pos] = data;
            return data;
        }

        return new CalculatedLightingProvider().GetLighting(Centre, Chunk(Centre),
            pos => !withWest && pos == West ? null : Chunk(pos), VanillaRegistry.Data, hasSkyLight: true);
    }

    private static IEnumerable<Vec2<int>> Around(Vec2<int> pos) {
        for (int dx = -1; dx <= 1; dx++) {
            for (int dz = -1; dz <= 1; dz++) {
                if (dx != 0 || dz != 0) yield return new Vec2<int>(pos.X + dx, pos.Y + dz);
            }
        }
    }

    /// <summary>Waits for the player's queue to run dry, ie. for the client to have it all.</summary>
    private static void WaitUntilQuiet(RecordingConnection connection) {
        int seen = -1;
        int still = 0;
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromSeconds(30);

        while (DateTime.UtcNow < deadline) {
            int count = connection.Sent.Count;
            still = count == seen ? still + 1 : 0;
            seen = count;
            if (still >= 4) return;
            Thread.Sleep(250);
        }

        Assert.Fail("the world never stopped sending");
    }

    private static List<ClientBoundChunkDataAndUpdateLightPacket> ChunkPackets(
        RecordingConnection connection, Vec2<int> pos) {

        return connection.Sent
            .OfType<ClientBoundChunkDataAndUpdateLightPacket>()
            .Where(p => p.ChunkX == pos.X && p.ChunkZ == pos.Y)
            .ToList();
    }

    /// <summary>A sky level per block of the chunk, in the order the packet stores them.</summary>
    private static byte[] SkyLevels(LightData data) {
        int sections = data.SkyLightMask.Length - 2;
        byte[] levels = new byte[sections * 4096];

        int at = 0;
        for (int section = 0; section < data.SkyLightMask.Length; section++) {
            if (!data.SkyLightMask[section]) continue;
            byte[] nibbles = data.SkyLight[at++];

            // The section below the world and the one above it are not the chunk's own blocks.
            if (section == 0 || section > sections) continue;

            for (int i = 0; i < 4096; i++) {
                byte packed = nibbles[i >> 1];
                levels[(section - 1) * 4096 + i] = (byte)((i & 1) == 0 ? packed & 0xF : packed >> 4);
            }
        }

        return levels;
    }

    private static void WaitUntil(Func<bool> condition) {
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromSeconds(30);
        while (DateTime.UtcNow < deadline) {
            if (condition()) return;
            Thread.Sleep(5);
        }
        Assert.Fail("timed out waiting for the world");
    }
}

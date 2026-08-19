using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Testing.Implementations.Server.Terrain;

/// <summary>
/// The one interleaving that loses a fork, driven deliberately.
/// </summary>
/// <remarks>
/// A generator forking into a chunk asks the world whether that chunk is loaded and, if not, parks the
/// terrain to be applied when it is. The window between the question and the parking is where a fork
/// goes missing: if the target publishes and drains its queue in there, the parked terrain sits behind
/// a drain that has already run and nothing looks at it again.
/// <p/>
/// <b>Load alone cannot test this.</b> The window is a few instructions wide, so neither the gated
/// fixtures nor the ninety six chunk pile-up in <c>GenerationForkTest</c> lands in it. The
/// interleaving is therefore produced rather than waited for: the host answers "not loaded", but only
/// after starting the target's announcement on another thread and giving it time to reach the queue.
/// <p/>
/// Under a queue that holds one lock across the question and the parking, that announcement blocks
/// until the fork is parked and then finds it. Under one that does not, it runs straight through, finds
/// nothing, and the fork is stranded with nothing thrown.
/// </remarks>
public class ForkRaceTest {
    private const int MinY = -64;
    private const int Height = ChunkData.VanillaOverworldHeight;

    private static readonly Vec2<int> Target = new(1, 0);
    private static readonly Vec3<int> ForkPos = new(20, 0, 3);

    /// <summary>Forks a block into the chunk to the east while generating the one at the origin.</summary>
    private sealed class Forker : IGenerator {
        public void Generate(IGenerationUnit unit) {
            unit.Fork(setter => setter.SetBlock(ForkPos, Block.DiamondBlock));
        }
    }

    /// <summary>
    /// A world that publishes the target at the worst possible moment: after it has been asked whether
    /// the target is loaded, and before it has answered.
    /// </summary>
    private sealed class RacingHost : ITerrainHost {
        private readonly object _gate = new();
        private bool _loaded;
        private bool _raced;

        public readonly ChunkData Chunk = new(Height) {
            ChunkX = Target.X, ChunkZ = Target.Y, MinY = ForkRaceTest.MinY
        };

        public int MinY => ForkRaceTest.MinY;
        public int MaxY => ForkRaceTest.MinY + Height;
        public MinecraftRegistry Registry => VanillaRegistry.Data;

        public event Action<Vec2<int>>? ChunkAvailable;

        public bool TryApplyToLoadedChunk(Vec2<int> chunk, Action<ChunkData> apply) {
            bool race;
            lock (_gate) {
                if (_loaded) {
                    apply(Chunk);
                    return true;
                }

                race = !_raced;
                _raced = true;
            }

            if (!race) {
                return false;
            }

            // The target finishes loading and announces itself, on its own thread, in the gap between
            // this question and its answer.
            Thread publisher = new(() => {
                lock (_gate) {
                    _loaded = true;
                }
                ChunkAvailable?.Invoke(chunk);
            }) { IsBackground = true };

            publisher.Start();

            // Long enough for that thread to reach the fork queue and, in a correct implementation,
            // block there.
            Thread.Sleep(200);

            // And still answer what was true when the question was put, which is the whole point.
            return false;
        }
    }

    [Test]
    public void AForkIsNotLostWhenTheTargetPublishesMidPost() {
        GeneratorTerrainProvider provider = new(new Forker());
        RacingHost host = new();
        provider.Attach(host);

        ChunkData origin = new(Height) { ChunkX = 0, ChunkZ = 0, MinY = MinY };
        provider.GetChunk(ref origin);

        // The drain runs on the publisher thread, so give it a moment to land.
        for (int i = 0; i < 200; i++) {
            if (host.Chunk.GetBlock(ForkPos.X & 15, ForkPos.Y - MinY, ForkPos.Z) != 0) {
                break;
            }
            Thread.Sleep(10);
        }

        Assert.That(host.Chunk.GetBlock(ForkPos.X & 15, ForkPos.Y - MinY, ForkPos.Z),
            Is.EqualTo(Block.DiamondBlock.StateId),
            "the fork was parked behind a drain that had already run");
        Assert.That(provider.PendingForkChunks, Is.Zero);
    }
}

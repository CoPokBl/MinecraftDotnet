using System.Collections.Concurrent;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Tests;

public class GenerationUnitTest {

    [Test]
    public void GenerationUnit_AbsoluteStart_ReturnsCorrectPosition() {
        // Arrange
        ChunkData chunk = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 2,
            ChunkZ = 3
        };
        ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pending = new();
        GenerationUnit unit = new(chunk, -64, pending);

        // Act
        Vec3<int> start = unit.AbsoluteStart();

        // Assert
        Assert.That(start.X, Is.EqualTo(32)); // 2 * 16
        Assert.That(start.Y, Is.EqualTo(-64));
        Assert.That(start.Z, Is.EqualTo(48)); // 3 * 16
    }

    [Test]
    public void GenerationUnit_AbsoluteEnd_ReturnsCorrectPosition() {
        // Arrange
        ChunkData chunk = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 2,
            ChunkZ = 3
        };
        ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pending = new();
        GenerationUnit unit = new(chunk, -64, pending);

        // Act
        Vec3<int> end = unit.AbsoluteEnd();

        // Assert
        Assert.That(end.X, Is.EqualTo(48)); // (2 + 1) * 16
        Assert.That(end.Y, Is.EqualTo(-64 + ChunkData.VanillaOverworldHeight));
        Assert.That(end.Z, Is.EqualTo(64)); // (3 + 1) * 16
    }

    [Test]
    public void GenerationUnit_Modifier_SetBlock_SetsBlockInChunk() {
        // Arrange
        ChunkData chunk = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 0,
            ChunkZ = 0
        };
        ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pending = new();
        GenerationUnit unit = new(chunk, -64, pending);

        // Act - Set a block at absolute position (5, 0, 7)
        // Local position in chunk would be (5, 64, 7) - Y=0 absolute is Y=64 in chunk coords (0-based from minY=-64)
        unit.Modifier().SetBlock(new Vec3<int>(5, 0, 7), Block.Stone);

        // Assert - Check the block at local position
        Assert.That(chunk.GetBlock(5, 64, 7), Is.EqualTo(Block.Stone.StateId));
    }

    [Test]
    public void GenerationUnit_Modifier_FillHeight_FillsBlocksAtHeight() {
        // Arrange
        ChunkData chunk = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 0,
            ChunkZ = 0
        };
        ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pending = new();
        GenerationUnit unit = new(chunk, -64, pending);

        // Act - Fill from Y=-64 to Y=-60 (4 layers)
        unit.Modifier().FillHeight(-64, -60, Block.Bedrock);

        // Assert - Check some blocks in the filled area
        // Y=-64 is local Y=0, Y=-60 is local Y=4
        Assert.That(chunk.GetBlock(0, 0, 0), Is.EqualTo(Block.Bedrock.StateId));
        Assert.That(chunk.GetBlock(15, 0, 15), Is.EqualTo(Block.Bedrock.StateId));
        Assert.That(chunk.GetBlock(8, 3, 8), Is.EqualTo(Block.Bedrock.StateId));
        // Y=4 should not be filled (exclusive end)
        Assert.That(chunk.GetBlock(0, 4, 0), Is.Not.EqualTo(Block.Bedrock.StateId));
    }

    [Test]
    public void GenerationUnit_Modifier_Fill_FillsArea() {
        // Arrange
        ChunkData chunk = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 0,
            ChunkZ = 0
        };
        ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pending = new();
        GenerationUnit unit = new(chunk, -64, pending);

        // Act - Fill a 3x3x3 area starting at (2, -62, 2) = local (2, 2, 2)
        unit.Modifier().Fill(
            new Vec3<int>(2, -62, 2),
            new Vec3<int>(5, -59, 5),
            Block.Cobblestone
        );

        // Assert - Check blocks inside the filled area
        Assert.That(chunk.GetBlock(2, 2, 2), Is.EqualTo(Block.Cobblestone.StateId));
        Assert.That(chunk.GetBlock(4, 4, 4), Is.EqualTo(Block.Cobblestone.StateId));
        // Check block outside the filled area
        Assert.That(chunk.GetBlock(1, 2, 2), Is.Not.EqualTo(Block.Cobblestone.StateId));
        Assert.That(chunk.GetBlock(5, 2, 2), Is.Not.EqualTo(Block.Cobblestone.StateId)); // exclusive end
    }

    [Test]
    public void GenerationUnit_Fork_CreatesForkWithCorrectBounds() {
        // Arrange
        ChunkData chunk = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 0,
            ChunkZ = 0
        };
        ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pending = new();
        GenerationUnit unit = new(chunk, -64, pending);
        Vec3<int> start = unit.AbsoluteStart();

        // Act - Create a fork that extends beyond the chunk
        IGenerationUnit fork = unit.Fork(start, start + new Vec3<int>(32, 64, 32));

        // Assert
        Assert.That(fork.AbsoluteStart(), Is.EqualTo(start));
        Assert.That(fork.AbsoluteEnd(), Is.EqualTo(start + new Vec3<int>(32, 64, 32)));
    }

    [Test]
    public void GeneratorTerrainProvider_GeneratesChunkWithLambda() {
        // Arrange
        GeneratorTerrainProvider provider = new(unit => {
            // Fill bottom layer with stone
            unit.Modifier().FillHeight(-64, -63, Block.Stone);
        }, -64);

        ChunkData chunk = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 0,
            ChunkZ = 0
        };

        // Act
        provider.GetChunk(ref chunk);

        // Assert - Check that the bottom layer is filled with stone
        Assert.That(chunk.GetBlock(0, 0, 0), Is.EqualTo(Block.Stone.StateId));
        Assert.That(chunk.GetBlock(15, 0, 15), Is.EqualTo(Block.Stone.StateId));
        Assert.That(chunk.GetBlock(0, 1, 0), Is.Not.EqualTo(Block.Stone.StateId));
    }

    [Test]
    public void GeneratorTerrainProvider_Fork_ModifiesOriginChunkImmediately() {
        // Arrange
        GeneratorTerrainProvider provider = new(unit => {
            Vec3<int> start = unit.AbsoluteStart();
            
            // Fork to create a tall structure
            IGenerationUnit fork = unit.Fork(start, start + new Vec3<int>(16, 32, 16));
            fork.Modifier().SetBlock(start + new Vec3<int>(5, 0, 5), Block.DiamondBlock);
        }, -64);

        ChunkData chunk = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 0,
            ChunkZ = 0
        };

        // Act
        provider.GetChunk(ref chunk);

        // Assert - Block should be set in the origin chunk
        // start = (0, -64, 0), so (5, -64, 5) is local (5, 0, 5)
        Assert.That(chunk.GetBlock(5, 0, 5), Is.EqualTo(Block.DiamondBlock.StateId));
    }

    [Test]
    public void GeneratorTerrainProvider_Fork_QueuesPendingModificationsForOtherChunks() {
        // Arrange
        Vec3<int> targetPos = new(20, -64, 5); // This is in chunk (1, 0), not chunk (0, 0)

        GeneratorTerrainProvider provider = new(unit => {
            Vec3<int> start = unit.AbsoluteStart();
            
            // Only from chunk (0, 0), create a fork that extends to chunk (1, 0)
            if (start.X == 0 && start.Z == 0) {
                IGenerationUnit fork = unit.Fork(new Vec3<int>(0, -64, 0), new Vec3<int>(32, 0, 16));
                fork.Modifier().SetBlock(targetPos, Block.EmeraldBlock);
            }
        }, -64);

        ChunkData chunk0 = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 0,
            ChunkZ = 0
        };
        ChunkData chunk1 = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 1,
            ChunkZ = 0
        };

        // Act - Generate first chunk, then second chunk
        provider.GetChunk(ref chunk0);
        provider.GetChunk(ref chunk1);

        // Assert - The block should appear in chunk (1, 0)
        // targetPos (20, -64, 5) is local (4, 0, 5) in chunk (1, 0)
        Assert.That(chunk1.GetBlock(4, 0, 5), Is.EqualTo(Block.EmeraldBlock.StateId));
    }

    [Test]
    public void LambdaTerrainGenerator_SnowmanExample() {
        // This test replicates the Java example from the issue
        
        // Arrange
        int snowmanCount = 0;
        Random random = new(42); // Fixed seed for reproducibility

        LambdaTerrainGenerator generator = new(unit => {
            Vec3<int> start = unit.AbsoluteStart();

            // Create a snow carpet for the snowmen
            unit.Modifier().FillHeight(-64, -60, Block.Snow);

            // Exit out if unit is not the bottom unit, and exit 5 in 6 times otherwise
            if (start.Y > -64 || random.Next(6) != 0) {
                return;
            }

            snowmanCount++;

            // Fork this section to add a tall snowman
            // Add two extra sections worth of space (32 blocks height)
            IGenerationUnit fork = unit.Fork(start, start + new Vec3<int>(16, 32, 16));

            // Add the snowman
            fork.Modifier().Fill(start, start + new Vec3<int>(3, 19, 3), Block.PowderSnow);
            fork.Modifier().SetBlock(start + new Vec3<int>(1, 19, 1), Block.JackOLantern);
        });

        GeneratorTerrainProvider provider = new(generator, -64);

        ChunkData chunk = new(ChunkData.VanillaOverworldHeight) {
            ChunkX = 0,
            ChunkZ = 0
        };

        // Act
        provider.GetChunk(ref chunk);

        // Assert - Snow carpet should be present
        Assert.That(chunk.GetBlock(0, 0, 0), Is.EqualTo(Block.Snow.StateId));
        Assert.That(chunk.GetBlock(8, 3, 8), Is.EqualTo(Block.Snow.StateId));
        // Y=4 (local) = Y=-60 (absolute) should not be filled (exclusive)
        Assert.That(chunk.GetBlock(0, 4, 0), Is.Not.EqualTo(Block.Snow.StateId));
    }
}

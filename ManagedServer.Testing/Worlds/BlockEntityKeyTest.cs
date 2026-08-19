using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT.Tags;

namespace ManagedServer.Testing.Worlds;

/// <summary>
/// Where a block entity written by <see cref="World.SetBlock(Vec3{int},Minecraft.Data.Blocks.IBlock,
/// Minecraft.Data.BlockEntityTypes.IBlockEntityType?,NBT.INbtTag?,int,int)"/> is filed.
/// </summary>
/// <remarks>
/// A chunk's block entities are keyed by chunk local x and z with the <b>game</b> y, which is what the
/// <see cref="BlockEntity"/> record itself carries and what the wire form wants. Keying by the
/// absolute position instead agrees only inside the chunk at the origin, and everywhere else files the
/// entry where nothing looks: it is never read back, and writing air over the block never clears it.
/// </remarks>
public class BlockEntityKeyTest {
    private sealed class VoidTerrain : ITerrainProvider {
        public void GetChunk(ref ChunkData chunk) { }
    }

    private static World NewWorld() {
        ManagedMinecraftServer server = ManagedMinecraftServer.New();
        server.LogAction = _ => { };
        return server.CreateWorld(new VoidTerrain(), "minecraft:overworld", new FullBrightLightingProvider());
    }

    /// <summary>
    /// Positions whose chunk local coordinates differ from their absolute ones, which is every chunk
    /// but the one at the origin, plus a negative chunk where the two also differ in sign.
    /// </summary>
    private static readonly Vec3<int>[] Positions = [
        new(0, 64, 0),
        new(20, 64, 5),
        new(-13, 64, -3),
        new(300, -20, -177)
    ];

    [Test]
    public void ABlockEntityIsReadBackWhereItWasWritten() {
        World world = NewWorld();

        foreach (Vec3<int> pos in Positions) {
            world.LoadChunk(new Vec2<int>(pos.X >> 4, pos.Z >> 4)).Wait(TimeSpan.FromSeconds(30));

            CompoundTag data = new(("marker", new IntegerTag(pos.X)));
            world.SetBlock(pos, Block.Chest, BlockEntityType.Chest, data);

            BlockEntity? read = world.GetBlockData(pos);

            Assert.That(read, Is.Not.Null, $"nothing filed for {pos}");
            Assert.That(read!.Data, Is.EqualTo(data), $"wrong entry for {pos}");
        }
    }

    /// <summary>The record's own coordinates are chunk local x and z with the game y.</summary>
    [Test]
    public void TheRecordCarriesChunkLocalCoordinates() {
        World world = NewWorld();
        Vec3<int> pos = new(20, 64, 5);
        world.LoadChunk(new Vec2<int>(pos.X >> 4, pos.Z >> 4)).Wait(TimeSpan.FromSeconds(30));

        world.SetBlock(pos, Block.Chest, BlockEntityType.Chest, new CompoundTag());
        BlockEntity? read = world.GetBlockData(pos);

        Assert.That(read, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(read!.X, Is.EqualTo(4));
            Assert.That(read.Z, Is.EqualTo(5));
            Assert.That(read.Y, Is.EqualTo((short)64));
        });
    }

    /// <summary>
    /// Writing something without a block entity over one clears it. A wrong key leaves the entry
    /// behind silently, and the chunk keeps shipping a block entity for a block that is gone.
    /// </summary>
    [Test]
    public void WritingOverABlockEntityClearsIt() {
        World world = NewWorld();
        Vec3<int> pos = new(20, 64, 5);
        world.LoadChunk(new Vec2<int>(pos.X >> 4, pos.Z >> 4)).Wait(TimeSpan.FromSeconds(30));

        world.SetBlock(pos, Block.Chest, BlockEntityType.Chest, new CompoundTag());
        Assert.That(world.GetBlockData(pos), Is.Not.Null);

        world.SetBlock(pos, Block.Air);

        Assert.That(world.GetBlockData(pos), Is.Null);
    }
}

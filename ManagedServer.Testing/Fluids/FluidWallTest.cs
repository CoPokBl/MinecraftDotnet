using ManagedServer.Fluids;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Fluids;

/// <summary>
/// <c>FlowingFluid.canPassThroughWall</c> is the one piece of the fluid port that had to be built
/// rather than transcribed: vanilla answers it by merging two voxel shapes and asking whether the
/// result covers the boundary, and there is no voxel shape here to merge. What it does instead is
/// take the two faces meeting at the boundary as rectangles and ask whether they tile the square
/// between them, which is the same question.
/// <p/>
/// Slabs are what make the difference visible. A top slab closes the top of its block and a bottom
/// slab does not, so water pours onto one and stops on the other, and the pair of them is the whole
/// rule in two blocks.
/// </summary>
[TestFixture]
public class FluidWallTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    /// <summary>An arbitrary spot: none of the blocks here have a shape that moves with position.</summary>
    private static readonly Vec3<int> Origin = new(0, 64, 0);

    private static bool Passes(IBlock from, IBlock to, BlockFace face) {
        return FluidBlockData.CanPassThroughWall(
            FluidBlockData.Get(Registry, from), Origin,
            FluidBlockData.Get(Registry, to), FluidDirections.Relative(Origin, face),
            face);
    }

    [Test]
    public void NothingPassesIntoOrOutOfAFullBlock() {
        Assert.Multiple(() => {
            Assert.That(Passes(Block.Air, Block.Stone, BlockFace.PosX), Is.False);
            Assert.That(Passes(Block.Stone, Block.Air, BlockFace.PosX), Is.False);
            Assert.That(Passes(Block.Air, Block.Stone, BlockFace.NegY), Is.False);
        });
    }

    [Test]
    public void EmptyShapesNeverStopAnything() {
        Assert.Multiple(() => {
            Assert.That(Passes(Block.Air, Block.Air, BlockFace.PosX), Is.True);
            Assert.That(Passes(Block.Air, Block.Air, BlockFace.NegY), Is.True);
            Assert.That(Passes(Block.Water, Block.Air, BlockFace.NegY), Is.True);
        });
    }

    [Test]
    public void ATopSlabClosesTheTopOfItsBlockAndABottomSlabDoesNot() {
        IBlock top = Block.StoneSlab with { Type = SlabType.Top };
        IBlock bottom = Block.StoneSlab with { Type = SlabType.Bottom };

        Assert.Multiple(() => {
            // Its upper face fills the square, so nothing comes down into it.
            Assert.That(Passes(Block.Air, top, BlockFace.NegY), Is.False, "a top slab let a fluid in from above");

            // The bottom slab's shape stops halfway up, so the boundary above it is open.
            Assert.That(Passes(Block.Air, bottom, BlockFace.NegY), Is.True, "a bottom slab blocked a fluid from above");

            // Neither closes a side: half a square is not a square.
            Assert.That(Passes(Block.Air, top, BlockFace.PosX), Is.True);
            Assert.That(Passes(Block.Air, bottom, BlockFace.PosX), Is.True);
        });
    }

    [Test]
    public void ABottomSlabClosesTheBottomOfItsBlock() {
        IBlock bottom = Block.StoneSlab with { Type = SlabType.Bottom };

        Assert.Multiple(() => {
            Assert.That(Passes(Block.Air, bottom, BlockFace.PosY), Is.False,
                "a fluid rose into a bottom slab from below");
            Assert.That(Passes(bottom, Block.Air, BlockFace.NegY), Is.False,
                "a fluid fell out of the bottom of a bottom slab");
        });
    }

    /// <summary>
    /// Two halves of a boundary adding up is the case a per block test cannot see: neither face covers
    /// the square on its own, and vanilla still closes the boundary because their union does.
    /// </summary>
    [Test]
    public void TwoHalfFacesMeetingCloseTheBoundaryBetweenThem() {
        IBlock upper = Block.StoneSlab with { Type = SlabType.Bottom };  // its floor is a full square
        IBlock lower = Block.StoneSlab with { Type = SlabType.Top };     // its ceiling is a full square

        Assert.That(Passes(lower, upper, BlockFace.PosY), Is.False);
    }
}

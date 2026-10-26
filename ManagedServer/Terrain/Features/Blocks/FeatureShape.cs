using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Blocks;

/// <summary>
/// <c>BitSetDiscreteVoxelShape</c> over a feature's bounding box, together with
/// <c>StructureTemplate.updateShapeAtEdge</c>.
/// </summary>
/// <remarks>
/// A tree fills this with everything it wrote and then settles the states around the outside of it.
/// The only reason a feature needs a voxel shape at all is that walk: it visits a position exactly
/// where the filled region meets an empty one, so a block buried inside the canopy is left alone and
/// one at the surface is asked twice, once from each side.
/// </remarks>
public sealed class FeatureShape(Vec3<int> min, Vec3<int> max) {
    private readonly int _sizeX = max.X - min.X + 1;
    private readonly int _sizeY = max.Y - min.Y + 1;
    private readonly int _sizeZ = max.Z - min.Z + 1;
    private readonly bool[] _filled = new bool[(max.X - min.X + 1) * (max.Y - min.Y + 1)
        * (max.Z - min.Z + 1)];

    public void Fill(Vec3<int> pos) {
        if (Inside(pos)) {
            _filled[Index(pos.X - min.X, pos.Y - min.Y, pos.Z - min.Z)] = true;
        }
    }

    private bool Inside(Vec3<int> pos) {
        return pos.X >= min.X && pos.X <= max.X && pos.Y >= min.Y && pos.Y <= max.Y
            && pos.Z >= min.Z && pos.Z <= max.Z;
    }

    private int Index(int x, int y, int z) => (x * _sizeY + y) * _sizeZ + z;

    private bool At(int x, int y, int z) => _filled[Index(x, y, z)];

    /// <summary>
    /// <c>updateShapeAtEdge</c>: settle the block and its neighbour at every face of the shape.
    /// </summary>
    /// <remarks>
    /// The neighbour half is not an extra. What it reaches is the block just outside the shape, which
    /// is how a tree grown over an older one's vines takes those vines down: they belong to neither
    /// this tree's blocks nor its bounding box, and only the outward step finds them.
    /// </remarks>
    public void UpdateShapeAtEdge(IFeatureLevel level) {
        ForAllFaces((face, pos) => {
            Vec3<int> neighbourPos = pos + FeatureShapeUpdate.Step(face);

            IBlock state = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));
            IBlock neighbour = level.Registry.Blocks
                .GetByStateId(level.GetState(neighbourPos.X, neighbourPos.Y, neighbourPos.Z));

            IBlock updated = FeatureShapeUpdate.UpdateShape(state, level, pos, face);
            if (updated.StateId != state.StateId) {
                level.SetState(pos.X, pos.Y, pos.Z, updated.StateId);
            }

            IBlock settled = FeatureShapeUpdate.UpdateShape(neighbour, level, neighbourPos,
                FeatureShapeUpdate.Opposite(face));

            if (settled.StateId != neighbour.StateId) {
                level.SetState(neighbourPos.X, neighbourPos.Y, neighbourPos.Z, settled.StateId);
            }
        });
    }

    /// <summary>
    /// <c>DiscreteVoxelShape.forAllFaces</c>: every cell where a run of filled cells starts or ends,
    /// along each axis in turn.
    /// </summary>
    /// <remarks>
    /// The three passes go along <b>z, then y, then x</b>, and inside one the two cross axes are the
    /// inverse cycle's: for the z pass they are x then y, for the y pass z then x, for the x pass y
    /// then z. Upstream that falls out of running <c>AxisCycle.NONE</c>, <c>FORWARD</c> and
    /// <c>BACKWARD</c> over one loop; here the three are written out. It decides the order the
    /// updates land in, and a hanging column of vines settles differently depending on whether its
    /// top or its bottom is reached first.
    /// </remarks>
    private void ForAllFaces(Action<BlockFace, Vec3<int>> consume) {
        // Along z, x outermost.
        for (int x = 0; x < _sizeX; x++) {
            for (int y = 0; y < _sizeY; y++) {
                Run(_sizeZ, along => At(x, y, along), BlockFace.NegZ, BlockFace.PosZ,
                    along => new Vec3<int>(x, y, along), consume);
            }
        }

        // Along y, z outermost.
        for (int z = 0; z < _sizeZ; z++) {
            for (int x = 0; x < _sizeX; x++) {
                Run(_sizeY, along => At(x, along, z), BlockFace.NegY, BlockFace.PosY,
                    along => new Vec3<int>(x, along, z), consume);
            }
        }

        // Along x, y outermost.
        for (int y = 0; y < _sizeY; y++) {
            for (int z = 0; z < _sizeZ; z++) {
                Run(_sizeX, along => At(along, y, z), BlockFace.NegX, BlockFace.PosX,
                    along => new Vec3<int>(along, y, z), consume);
            }
        }
    }

    /// <summary>
    /// One line through the shape: the first cell of a filled run faces the negative direction and
    /// the last faces the positive one, which is what makes the two ends of a run different faces.
    /// </summary>
    private void Run(int length, Func<int, bool> filled, BlockFace negative, BlockFace positive,
        Func<int, Vec3<int>> at, Action<BlockFace, Vec3<int>> consume) {

        bool previous = false;

        for (int along = 0; along <= length; along++) {
            bool here = along != length && filled(along);

            if (!previous && here) {
                consume(negative, Offset(at(along)));
            }

            if (previous && !here) {
                consume(positive, Offset(at(along - 1)));
            }

            previous = here;
        }
    }

    private Vec3<int> Offset(Vec3<int> local) {
        return new Vec3<int>(min.X + local.X, min.Y + local.Y, min.Z + local.Z);
    }
}

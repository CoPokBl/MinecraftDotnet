using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>Beardifier</c>: the term added to the terrain density that makes the ground fit the structure
/// standing on it.
/// </summary>
/// <remarks>
/// It is a <b>density sampler</b> rather than a pass over blocks, which is why it has to exist before
/// the noise runs and why a structure's position must not depend on it. The generator asks for the
/// starts reaching a chunk, builds one of these and hands it to the chunk's sampler context, where the
/// data's <c>beardifier</c> node reads it. All of it is float.
/// <p/>
/// <b>The kernel is what makes a beard a beard.</b> A 24 cubed table of a Gaussian, sampled at the
/// offset from a piece, so ground is pulled up towards a piece that is hanging over a drop and the
/// pull falls away smoothly rather than at a cliff. <see cref="TerrainAdjustment.Bury"/> is the other
/// half and works the opposite way: it fills terrain <b>in</b> around the structure.
/// <p/>
/// <b>A jigsaw piece is treated differently from a plain one.</b> Only its rigid pieces are bearded,
/// since a terrain matching one is dropped onto the ground rather than standing on it, and the joins
/// between pieces contribute their own smaller term: without those a village path meeting a house
/// leaves a step where the two boxes stop.
/// </remarks>
public sealed class Beardifier : IDensitySampler {
    private const int KernelRadius = 12;
    private const int KernelSize = 24;

    /// <summary>
    /// The Gaussian falloff, worked out once. Indexed z, x, y, which is vanilla's own order.
    /// </summary>
    private static readonly float[] Kernel = BuildKernel();

    private static float[] BuildKernel() {
        float[] kernel = new float[KernelSize * KernelSize * KernelSize];

        for (int z = 0; z < KernelSize; z++) {
            for (int x = 0; x < KernelSize; x++) {
                for (int y = 0; y < KernelSize; y++) {
                    kernel[z * KernelSize * KernelSize + x * KernelSize + y] =
                        (float)Contribution(x - KernelRadius, y - KernelRadius + 0.5, z - KernelRadius);
                }
            }
        }

        return kernel;
    }

    /// <summary>A piece the terrain has to be adjusted around.</summary>
    /// <param name="GroundLevelDelta">
    /// How far the piece's own ground sits above the bottom of its box. Zero for a piece that is not
    /// part of a jigsaw structure, which is what makes the two kinds one case here.
    /// </param>
    private readonly record struct Rigid(BoundingBox Box, TerrainAdjustment Adjustment,
        int GroundLevelDelta);

    /// <summary>The beardifier for a chunk no adjusted structure reaches, which is almost all of them.</summary>
    public static readonly Beardifier Empty = new([], [], null);

    private readonly Rigid[] _pieces;
    private readonly JigsawJunction[] _junctions;
    private readonly BoundingBox? _affectedBox;

    private Beardifier(Rigid[] pieces, JigsawJunction[] junctions, BoundingBox? affectedBox) {
        _pieces = pieces;
        _junctions = junctions;
        _affectedBox = affectedBox;
    }

    /// <summary>
    /// Collects the pieces of every start that reaches the chunk and wants the terrain adjusted.
    /// </summary>
    /// <remarks>
    /// A piece counts if it is within twelve blocks of the chunk, which is the kernel's radius: past
    /// that it contributes nothing whatever the arithmetic says. The affected box is the union of them
    /// grown by 24, and a position outside it short circuits to zero, which is what keeps this
    /// affordable when a structure is only just in range.
    /// </remarks>
    public static Beardifier ForStructuresInChunk(IEnumerable<StructureStart> starts, int chunkX,
        int chunkZ) {

        List<Rigid> pieces = [];
        List<JigsawJunction> junctions = [];
        BoundingBox? union = null;

        int chunkStartX = chunkX << 4;
        int chunkStartZ = chunkZ << 4;

        foreach (StructureStart start in starts) {
            TerrainAdjustment adjustment = start.Structure.TerrainAdaptation;

            if (adjustment == TerrainAdjustment.None) {
                continue;
            }

            foreach (StructurePiece piece in start.Pieces) {
                if (!piece.IsCloseToChunk(chunkX, chunkZ, KernelRadius)) {
                    continue;
                }

                if (piece is not PoolElementStructurePiece pool) {
                    pieces.Add(new Rigid(piece.BoundingBox, adjustment, 0));
                    union = Include(union, piece.BoundingBox);
                    continue;
                }

                // A terrain matching piece follows the ground rather than sitting on it, so nothing
                // is bearded for it; its joins still are.
                if (pool.Element.Projection == PoolProjection.Rigid) {
                    pieces.Add(new Rigid(pool.BoundingBox, adjustment, pool.GroundLevelDelta));
                    union = Include(union, pool.BoundingBox);
                }

                foreach (JigsawJunction junction in pool.Junctions) {
                    if (junction.SourceX <= chunkStartX - KernelRadius
                        || junction.SourceZ <= chunkStartZ - KernelRadius
                        || junction.SourceX >= chunkStartX + 15 + KernelRadius
                        || junction.SourceZ >= chunkStartZ + 15 + KernelRadius) {

                        continue;
                    }

                    junctions.Add(junction);

                    union = Include(union, new BoundingBox(junction.SourceX, junction.SourceGroundY,
                        junction.SourceZ));
                }
            }
        }

        return union is null
            ? Empty
            : new Beardifier([..pieces], [..junctions], union.InflatedBy(KernelSize));
    }

    private static BoundingBox Include(BoundingBox? union, BoundingBox box) {
        return union is null
            ? new BoundingBox(box.MinX, box.MinY, box.MinZ, box.MaxX, box.MaxY, box.MaxZ)
            : union.Encapsulate(box);
    }

    public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
        output.Fill(0.0F);
        if (_affectedBox is not { } box
            || !volume.Intersects(box.MinX, box.MinY, box.MinZ, box.MaxX, box.MaxY, box.MaxZ)) {
            return;
        }

        int minX = Mth.FloorDiv(Math.Max(0, box.MinX - volume.MinBlockX), volume.StepBlockX);
        int minY = Mth.FloorDiv(Math.Max(0, box.MinY - volume.MinBlockY), volume.StepBlockY);
        int minZ = Mth.FloorDiv(Math.Max(0, box.MinZ - volume.MinBlockZ), volume.StepBlockZ);
        int maxX = Math.Min(volume.SizeX - 1, Mth.FloorDiv(box.MaxX - volume.MinBlockX, volume.StepBlockX));
        int maxY = Math.Min(volume.SizeY - 1, Mth.FloorDiv(box.MaxY - volume.MinBlockY, volume.StepBlockY));
        int maxZ = Math.Min(volume.SizeZ - 1, Mth.FloorDiv(box.MaxZ - volume.MinBlockZ, volume.StepBlockZ));

        for (int z = minZ; z <= maxZ; z++) {
            int blockZ = volume.BlockZ(z);
            for (int x = minX; x <= maxX; x++) {
                int blockX = volume.BlockX(x);
                for (int y = minY; y <= maxY; y++) {
                    output[volume.IndexUnchecked(x, y, z)] = SampleValueUnchecked(blockX, volume.BlockY(y), blockZ);
                }
            }
        }
    }

    public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
        return _affectedBox is { } box && box.IsInside(blockX, blockY, blockZ) ? SampleValueUnchecked(blockX, blockY, blockZ) : 0.0F;
    }

    private float SampleValueUnchecked(int blockX, int blockY, int blockZ) {
        float noiseValue = 0.0F;

        foreach (Rigid rigid in _pieces) {
            BoundingBox box = rigid.Box;
            int dx = Math.Max(0, Math.Max(box.MinX - blockX, blockX - box.MaxX));
            int dz = Math.Max(0, Math.Max(box.MinZ - blockZ, blockZ - box.MaxZ));
            int groundY = box.MinY + rigid.GroundLevelDelta;
            int dyToGround = blockY - groundY;

            int dy = rigid.Adjustment switch {
                TerrainAdjustment.Bury or TerrainAdjustment.BeardThin => dyToGround,
                TerrainAdjustment.BeardBox => Math.Max(0, Math.Max(groundY - blockY, blockY - box.MaxY)),
                TerrainAdjustment.Encapsulate => Math.Max(0, Math.Max(box.MinY - blockY, blockY - box.MaxY)),
                _ => 0
            };

            noiseValue += rigid.Adjustment switch {
                TerrainAdjustment.Bury => BuryContribution(dx, dy / 2.0F, dz),
                TerrainAdjustment.BeardThin or TerrainAdjustment.BeardBox => BeardContribution(dx, dy, dz, dyToGround) * 0.8F,
                TerrainAdjustment.Encapsulate => BuryContribution(dx / 2.0F, dy / 2.0F, dz / 2.0F) * 0.8F,
                _ => 0.0F
            };
        }

        // A join always contributes as a beard whatever the structure's own adjustment is: what it
        // smooths is the step between two pieces rather than the ground under either.
        foreach (JigsawJunction junction in _junctions) {
            int dx = blockX - junction.SourceX;
            int dy = blockY - junction.SourceGroundY;
            int dz = blockZ - junction.SourceZ;
            noiseValue += BeardContribution(dx, dy, dz, dy) * 0.4F;
        }

        return noiseValue;
    }

    /// <summary>Fills terrain in around a piece, falling from one to zero over six blocks.</summary>
    private static float BuryContribution(float dx, float dy, float dz) {
        float distanceSq = Mth.LengthSquared(dx, dy, dz);
        return distanceSq >= 36.0F ? 0.0F : 1.0F - Mth.Sqrt(distanceSq) / 6.0F;
    }

    /// <summary>
    /// Grows a skirt of ground under a piece, weighted by the kernel. The sign comes from
    /// <paramref name="yToGround"/>, so ground is pushed up below the piece and cut away above.
    /// <c>FastInvSqrt</c> rather than a real one is vanilla's, and it is not accurate.
    /// </summary>
    private static float BeardContribution(int dx, int dy, int dz, int yToGround) {
        int kernelX = dx + KernelRadius;
        int kernelY = dy + KernelRadius;
        int kernelZ = dz + KernelRadius;
        if (!InKernel(kernelX) || !InKernel(kernelY) || !InKernel(kernelZ)) {
            return 0.0F;
        }

        float dyWithOffset = yToGround + 0.5F;
        float distanceSqr = Mth.LengthSquared(dx, dyWithOffset, dz);
        float value = -dyWithOffset * (float)Mth.FastInvSqrt(distanceSqr / 2.0F) / 2.0F;
        return value * Kernel[kernelZ * KernelSize * KernelSize + kernelX * KernelSize + kernelY];
    }

    private static bool InKernel(int index) => index >= 0 && index < KernelSize;

    private static double Contribution(int dx, double dy, int dz) {
        double distanceSquared = dx * dx + dy * dy + dz * dz;
        return Math.Pow(Math.E, -distanceSquared / 16.0);
    }
}

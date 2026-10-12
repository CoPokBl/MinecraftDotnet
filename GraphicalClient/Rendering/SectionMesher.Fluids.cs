using GraphicalClient.Assets;

namespace GraphicalClient.Rendering;

public sealed partial class SectionMesher {
    private BlockModel ModelAt(SectionSnapshot snap, int x, int y, int z) => _models[snap.States[SectionSnapshot.Index(x, y, z)]];

    private bool IsSameFluid(SectionSnapshot snap, int x, int y, int z, bool lava) {
        BlockModel model = ModelAt(snap, x, y, z);
        return lava ? model.IsLava : model.HasWater;
    }

    /// <summary><c>LiquidBlockRenderer.getHeight</c>: a cell's surface height, -1 for a solid block that does not count.</summary>
    private float FluidHeight(SectionSnapshot snap, int x, int y, int z, bool lava) {
        BlockModel model = ModelAt(snap, x, y, z);
        if (!(lava ? model.IsLava : model.HasWater)) {
            return model.OccludesFaces == 0x3F ? -1.0F : 0.0F;
        }
        if (IsSameFluid(snap, x, y + 1, z, lava)) {
            return 1.0F;
        }
        int level = model.FluidLevel;
        int amount = level == 0 || level >= 8 ? 8 : 8 - level;
        return amount / 9.0F;
    }

    /// <summary><c>LiquidBlockRenderer.calculateAverageHeight</c>, where a nearly full cell outweighs the rest tenfold.</summary>
    private float CornerHeight(SectionSnapshot snap, int x, int y, int z, int dx, int dz, bool lava, float own) {
        float total = 0;
        int count = 0;
        Span<float> heights = [own, FluidHeight(snap, x + dx, y, z, lava), FluidHeight(snap, x, y, z + dz, lava), FluidHeight(snap, x + dx, y, z + dz, lava)];
        foreach (float h in heights) {
            if (h >= 1.0F) {
                return 1.0F;
            }
            if (h >= 0.8F) {
                total += h * 10.0F;
                count += 10;
            }
            else if (h >= 0.0F) {
                total += h;
                count++;
            }
        }
        return count == 0 ? own : total / count;
    }

    private void MeshFluid(SectionSnapshot snap, int x, int y, int z, BlockModel model) {
        bool lava = model.IsLava;
        ushort layer = (lava ? model : _models[WaterState]).TextureLayers[0];
        RenderLayer fluidLayer = lava ? RenderLayer.Solid : RenderLayer.Translucent;
        uint tint = lava ? 0xFFFFFF : TintOf(snap, TintKind.Water, x, y, z);

        float own = FluidHeight(snap, x, y, z, lava);
        bool covered = IsSameFluid(snap, x, y + 1, z, lava);
        float h00 = covered ? 1 : CornerHeight(snap, x, y, z, -1, -1, lava, own);
        float h10 = covered ? 1 : CornerHeight(snap, x, y, z, 1, -1, lava, own);
        float h11 = covered ? 1 : CornerHeight(snap, x, y, z, 1, 1, lava, own);
        float h01 = covered ? 1 : CornerHeight(snap, x, y, z, -1, 1, lava, own);

        byte light = snap.Light[SectionSnapshot.Index(x, y, z)];
        byte above = snap.Light[SectionSnapshot.Index(x, y + 1, z)];
        float sky = Math.Max(light >> 4, above >> 4);
        float blockLight = lava ? 15 : Math.Max(light & 15, above & 15);

        if (!covered) {
            const float inset = 0.001F;
            // The surface goes with the faces that look up, even sloped, so it takes its place in their
            // back to front order rather than being drawn over the ice above it.
            List<BlockVertex> up = Target(fluidLayer, (int)Face.Up);
            Add(up, x, y + h00 - inset, z, 0, 0, sky, blockLight, 1, FluidSurfaceFlag);
            Add(up, x, y + h01 - inset, z + 1, 0, 1, sky, blockLight, 1, FluidSurfaceFlag);
            Add(up, x + 1, y + h11 - inset, z + 1, 1, 1, sky, blockLight, 1, FluidSurfaceFlag);
            Add(up, x + 1, y + h10 - inset, z, 1, 0, sky, blockLight, 1, FluidSurfaceFlag);
            if (!lava) {
                // Seen from below, a surface is the same quad the other way round.
                List<BlockVertex> under = Target(fluidLayer, (int)Face.Down);
                Add(under, x, y + h00 - inset, z, 0, 0, sky, blockLight, 0, FluidSurfaceFlag);
                Add(under, x + 1, y + h10 - inset, z, 1, 0, sky, blockLight, 0, FluidSurfaceFlag);
                Add(under, x + 1, y + h11 - inset, z + 1, 1, 1, sky, blockLight, 0, FluidSurfaceFlag);
                Add(under, x, y + h01 - inset, z + 1, 0, 1, sky, blockLight, 0, FluidSurfaceFlag);
            }
        }

        if (!IsSameFluid(snap, x, y - 1, z, lava) && (ModelAt(snap, x, y - 1, z).OccludesFaces & (1 << (int)Face.Up)) == 0) {
            byte below = snap.Light[SectionSnapshot.Index(x, y - 1, z)];
            float belowSky = below >> 4, belowBlock = lava ? 15 : below & 15;
            List<BlockVertex> down = Target(fluidLayer, (int)Face.Down);
            Add(down, x, y, z, 0, 0, belowSky, belowBlock, 0);
            Add(down, x + 1, y, z, 1, 0, belowSky, belowBlock, 0);
            Add(down, x + 1, y, z + 1, 1, 1, belowSky, belowBlock, 0);
            Add(down, x, y, z + 1, 0, 1, belowSky, belowBlock, 0);
        }

        // Sides: north, south, west, east, each between two corner heights.
        Span<(int Face, int Dx, int Dz, float X0, float Z0, float X1, float Z1, float H0, float H1)> sides = [
            (2, 0, -1, 1, 0, 0, 0, h10, h00),
            (3, 0, 1, 0, 1, 1, 1, h01, h11),
            (4, -1, 0, 0, 0, 0, 1, h00, h01),
            (5, 1, 0, 1, 1, 1, 0, h11, h10)
        ];
        foreach ((int face, int dx, int dz, float x0, float z0, float x1, float z1, float hA, float hB) in sides) {
            if (IsSameFluid(snap, x + dx, y, z + dz, lava) || (ModelAt(snap, x + dx, y, z + dz).OccludesFaces & (1 << (face ^ 1))) != 0) {
                continue;
            }
            byte sideLight = snap.Light[SectionSnapshot.Index(x + dx, y, z + dz)];
            float s = Math.Max(sideLight >> 4, light >> 4);
            float bl = lava ? 15 : Math.Max(sideLight & 15, light & 15);
            List<BlockVertex> outward = Target(fluidLayer, face);
            Add(outward, x + x0, y, z + z0, 0, 1, s, bl, face);
            Add(outward, x + x1, y, z + z1, 1, 1, s, bl, face);
            Add(outward, x + x1, y + hB, z + z1, 1, 1 - hB, s, bl, face);
            Add(outward, x + x0, y + hA, z + z0, 0, 1 - hA, s, bl, face);
            if (!lava) {
                List<BlockVertex> inward = Target(fluidLayer, face ^ 1);
                Add(inward, x + x1, y, z + z1, 1, 1, s, bl, face);
                Add(inward, x + x0, y, z + z0, 0, 1, s, bl, face);
                Add(inward, x + x0, y + hA, z + z0, 0, 1 - hA, s, bl, face);
                Add(inward, x + x1, y + hB, z + z1, 1, 1 - hB, s, bl, face);
            }
        }

        void Add(List<BlockVertex> target, float px, float py, float pz, float u, float v, float s, float b, int face, byte flags = 0) =>
            target.Add(Vertex(px, py, pz, u, v, layer, s, b, 1.0F, face, tint, flags));
    }
}

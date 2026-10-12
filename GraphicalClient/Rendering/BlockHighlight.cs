using System.Numerics;
using ClientLib.World;
using GraphicalClient.Assets;
using Minecraft.Data.Blocks;
using Minecraft.Physics;
using Minecraft.Schemas.Vec;

namespace GraphicalClient.Rendering;

/// <summary>The outline round the targeted block, and the cracks on blocks being dug.</summary>
public static class BlockHighlight {
    /// <summary>
    /// <c>LevelRenderer.renderHitOutline</c>: the block's outline shape, each box's edges in black at
    /// 40% opacity, pushed out a hair so they win the depth test against the faces.
    /// </summary>
    public static void Outline(OverlayRenderer overlay, ClientLevel level, Camera camera, int x, int y, int z) {
        IBlock block = level.GetBlock(x, y, z);
        Box[] boxes = BlockPhysicsData.ShapeBoxesOf(block.BlockShape);
        Vec3<double> offset = block.Info.Offsets(BlockShapeOffsets.Block) ? block.Info.ShapeOffset(new Vec3<int>(x, y, z)) : Vec3<double>.Zero;
        foreach (Box box in boxes) {
            Vector3 min = Relative(camera, x + box.MinX + offset.X, y + box.MinY + offset.Y, z + box.MinZ + offset.Z) - new Vector3(0.002F);
            Vector3 max = Relative(camera, x + box.MaxX + offset.X, y + box.MaxY + offset.Y, z + box.MaxZ + offset.Z) + new Vector3(0.002F);
            overlay.BoxEdges(min, max, 0x66000000);
        }
    }

    /// <summary>Cracks spreading from the middle of each face, more of them the further along the dig is.</summary>
    public static void Cracks(OverlayRenderer overlay, Camera camera, int x, int y, int z, int stage) {
        if (stage < 0) {
            return;
        }
        int segments = 3 + stage * 3;
        Vector3 origin = Relative(camera, x, y, z);
        for (int face = 0; face < 6; face++) {
            int axis = face / 2;
            float plane = face % 2 == 0 ? -0.003F : 1.003F;
            for (int i = 0; i < segments; i++) {
                float a0 = DevArt.Noise(face * 97 + i, x, z), b0 = DevArt.Noise(face * 31 + i, y, x);
                float a1 = a0 + (DevArt.Noise(face * 13 + i, z, y) - 0.5F) * 0.35F;
                float b1 = b0 + (DevArt.Noise(face * 7 + i, x + y, z) - 0.5F) * 0.35F;
                // Pull the crack toward the centre for early stages, so it spreads outward as the dig goes on.
                float spread = 0.25F + stage * 0.085F;
                a0 = 0.5F + (a0 - 0.5F) * spread;
                b0 = 0.5F + (b0 - 0.5F) * spread;
                a1 = Math.Clamp(0.5F + (a1 - 0.5F) * spread, 0, 1);
                b1 = Math.Clamp(0.5F + (b1 - 0.5F) * spread, 0, 1);
                overlay.Line(origin + OnFace(axis, plane, a0, b0), origin + OnFace(axis, plane, a1, b1), 0xB0000000);
            }
        }
    }

    private static Vector3 OnFace(int axis, float plane, float a, float b) => axis switch {
        0 => new Vector3(a, plane, b),
        1 => new Vector3(a, b, plane),
        _ => new Vector3(plane, a, b)
    };

    private static Vector3 Relative(Camera camera, double x, double y, double z) =>
        new((float)(x - camera.Position.X), (float)(y - camera.Position.Y), (float)(z - camera.Position.Z));
}

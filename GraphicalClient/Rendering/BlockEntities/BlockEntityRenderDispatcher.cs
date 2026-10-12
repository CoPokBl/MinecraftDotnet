using System.Numerics;
using ClientLib.Maths;
using ClientLib.World;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary>
/// <c>BlockEntityRenderDispatcher</c>: every block entity with a renderer near the camera, drawn into
/// the entity batches after the entities. Vanilla takes them from the sections that survived its
/// occlusion walk; this tests each block against the frustum instead, which draws the same set
/// apart from block entities hidden behind terrain.
/// </summary>
public sealed class BlockEntityRenderDispatcher(Dictionary<Identifier, BlockEntityRenderer> renderers) {
    public BlockEntityRenderer? RendererFor(ClientBlockEntity blockEntity) => renderers.GetValueOrDefault(blockEntity.Type.Identifier);

    public void Render(EntityRenderContext context) {
        ClientLevel level = context.Level;
        Camera camera = context.Camera;
        Vec3d cameraPosition = camera.Position;
        Frustum frustum = Frustum.FromMatrix(camera.View * camera.CullProjection);
        int reach = renderers.Values.Max(r => r.ViewDistance) + 16;
        foreach (ClientChunk chunk in level.Chunks) {
            if (chunk.BlockEntities.Count == 0) {
                continue;
            }
            double dx = Math.Max(0, Math.Abs((chunk.X << 4) + 8 - cameraPosition.X) - 8), dz = Math.Max(0, Math.Abs((chunk.Z << 4) + 8 - cameraPosition.Z) - 8);
            if (dx * dx + dz * dz > (double)reach * reach) {
                continue;
            }
            foreach (ClientBlockEntity blockEntity in chunk.BlockEntities.Values) {
                if (RendererFor(blockEntity) is not { } renderer || !ClientBlockEntity.IsValid(blockEntity.Type, blockEntity.State)
                    || !renderer.ShouldRender(blockEntity, cameraPosition)) {
                    continue;
                }
                // The block's own space, grown by a block to take in what a renderer draws past its edges.
                Vector3 corner = new((float)(blockEntity.X - cameraPosition.X), (float)(blockEntity.Y - cameraPosition.Y), (float)(blockEntity.Z - cameraPosition.Z));
                if (!renderer.ShouldRenderOffScreen && !frustum.Intersects(corner - Vector3.One, corner + new Vector3(2))) {
                    continue;
                }
                renderer.Render(blockEntity, context);
            }
        }
    }
}

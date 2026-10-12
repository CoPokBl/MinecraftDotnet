using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using Minecraft.Data.Entities;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// <c>EntityRenderDispatcher</c>: picks each entity's renderer, culls as <c>EntityRenderer.shouldRender</c>
/// does, and draws the rest into the frame's batch.
/// </summary>
public sealed class EntityRenderDispatcher(Dictionary<IEntityType, EntityRenderer> renderers, DevArtEntities fallback) {
    public EntityRenderer? RendererFor(ClientEntity entity) => renderers.GetValueOrDefault(entity.Type);

    /// <summary>What an entity with no renderer draws as.</summary>
    public DevArtEntities Fallback => fallback;

    /// <summary>After the client's tick, for the state vanilla's client side entities keep.</summary>
    public void Tick(MinecraftClient client) {
        foreach (ClientEntity entity in client.Entities.Values) {
            if (!renderers.TryGetValue(entity.Type, out EntityRenderer? renderer)) {
                continue;
            }
            if (client.Level is { } level) {
                renderer.Tick(entity, level);
            }
            else {
                renderer.Tick(entity);
            }
        }
    }

    /// <summary>An <c>entity_event</c> packet, passed to the renderer of the entity it names.</summary>
    public void HandleEntityEvent(MinecraftClient client, int entityId, byte eventId) {
        if (client.Entities.TryGetValue(entityId, out ClientEntity? entity) && renderers.TryGetValue(entity.Type, out EntityRenderer? renderer)) {
            renderer.HandleEntityEvent(entity, eventId);
        }
    }

    /// <summary>
    /// <c>LevelExtractor</c>'s entity pass: the camera entity only from a detached view or asleep, and the
    /// local player only while it is the camera entity. A frozen entity is drawn where its last tick left it.
    /// </summary>
    public void Render(EntityRenderContext context, ClientEntity cameraEntity, bool detached) {
        Camera camera = context.Camera;
        Frustum frustum = Frustum.FromMatrix(camera.View * camera.CullProjection);
        float partialTick = context.PartialTick;
        foreach (ClientEntity entity in context.Client.Entities.Values) {
            if (entity == cameraEntity && !detached && !(entity.IsLiving && entity.IsSleeping)
                || entity == context.Client.Player && cameraEntity != entity) {
                continue;
            }
            context.PartialTick = context.Level.TickRateManager.IsEntityFrozen(entity) ? 1.0F : partialTick;
            double x = ClientEntity.Lerp(context.PartialTick, entity.OldPosition.X, entity.Position.X) - camera.Position.X;
            double y = ClientEntity.Lerp(context.PartialTick, entity.OldPosition.Y, entity.Position.Y) - camera.Position.Y;
            double z = ClientEntity.Lerp(context.PartialTick, entity.OldPosition.Z, entity.Position.Z) - camera.Position.Z;
            EntityRenderer? renderer = renderers.GetValueOrDefault(entity.Type);
            // isEntityVisible: whatever carries the local player is drawn however far or out of view it is.
            bool carriesPlayer = context.Client.Player is { } player && entity.HasIndirectPassenger(player);
            // Entity.shouldRender measures to where the entity is, not to where it is drawn this frame.
            double dx = entity.Position.X - camera.Position.X, dy = entity.Position.Y - camera.Position.Y, dz = entity.Position.Z - camera.Position.Z;
            double distanceSqr = dx * dx + dy * dy + dz * dz;
            if (!carriesPlayer && !(renderer?.ShouldRenderAtSqrDistance(entity, distanceSqr) ?? EntityRenderer.WithinViewDistance(entity, distanceSqr))) {
                continue;
            }
            // getBoundingBoxForCulling, inflated by half a block as shouldRender inflates it.
            Vector3 at = new((float)x, (float)y, (float)z);
            if (!carriesPlayer && (renderer == null || renderer.AffectedByCulling(entity))) {
                float half = (float)entity.Width / 2;
                (Vector3 min, Vector3 max) = renderer?.BoundingBoxForCulling(entity)
                    ?? (new Vector3(-half, 0, -half), new Vector3(half, (float)entity.Height, half));
                if (!frustum.Intersects(at + min - new Vector3(0.5F), at + max + new Vector3(0.5F))) {
                    continue;
                }
            }
            if (renderer != null) {
                renderer.Render(entity, context);
                continue;
            }
            context.SetOutlineColour(EntityRenderer.OutlineColourOf(entity, context.Client));
            fallback.Render(entity, context);
            context.SetOutlineColour(0);
            if (context.Flames != null && EntityRenderer.DisplayFireAnimation(entity, context.Client)) {
                PoseStack pose = new();
                pose.Translate(at);
                int sky = context.Level.GetSkyLight((int)Math.Floor(camera.Position.X + x), (int)Math.Floor(camera.Position.Y + y + entity.EyeHeight),
                    (int)Math.Floor(camera.Position.Z + z));
                context.Flames.Submit(pose, (float)entity.Width, (float)entity.Height, sky, camera, context.Batch);
            }
        }
        context.PartialTick = partialTick;
    }
}

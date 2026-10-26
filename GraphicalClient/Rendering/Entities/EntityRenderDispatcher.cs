using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using Minecraft.Data.Entities;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// Where entities that are out of view but may throw a shadow into it are drawn, for the shadow camera alone, and
/// the unit vector toward the light that throws it.
/// </summary>
public sealed record ShadowCasters(EntityRenderContext Context, Vector3 Light);

/// <summary>
/// <c>EntityRenderDispatcher</c>: picks each entity's renderer, culls as <c>EntityRenderer.shouldRender</c>
/// does, and draws the rest into the frame's batch.
/// </summary>
public sealed class EntityRenderDispatcher(Dictionary<IEntityType, EntityRenderer> renderers, DevArtEntities fallback) {
    /// <summary>
    /// The renderers by type instance: a type's own hash and equality compare all its fields, which every entity
    /// drawn each frame would otherwise pay for.
    /// </summary>
    private readonly Dictionary<IEntityType, EntityRenderer?> _byInstance = new(ReferenceEqualityComparer.Instance);

    public EntityRenderer? RendererFor(ClientEntity entity) {
        IEntityType type = entity.Type;
        if (!_byInstance.TryGetValue(type, out EntityRenderer? renderer)) {
            renderer = renderers.GetValueOrDefault(type);
            _byInstance[type] = renderer;
        }
        return renderer;
    }

    /// <summary>What an entity with no renderer draws as.</summary>
    public DevArtEntities Fallback => fallback;

    /// <summary>Time spent drawing each type since the last <see cref="TakeTimings"/>, kept only while set, for <c>--verbose</c>.</summary>
    public bool TimeByType { get; set; }

    private readonly Dictionary<IEntityType, (long Ticks, int Count)> _timings = new(ReferenceEqualityComparer.Instance);

    /// <summary>The types that took longest since the last call, worst first, as milliseconds over that time and calls.</summary>
    public List<(IEntityType Type, double Milliseconds, int Count)> TakeTimings() {
        List<(IEntityType, double, int)> result = _timings
            .Select(t => (t.Key, t.Value.Ticks * 1000.0 / System.Diagnostics.Stopwatch.Frequency, t.Value.Count))
            .OrderByDescending(t => t.Item2).ToList();
        _timings.Clear();
        return result;
    }

    private void Time(IEntityType type, long start) {
        (long ticks, int count) = _timings.GetValueOrDefault(type);
        _timings[type] = (ticks + System.Diagnostics.Stopwatch.GetTimestamp() - start, count + 1);
    }

    /// <summary>The types vanilla gives a <c>NoopRenderer</c>: they have no look, so the built in art must not stand in.</summary>
    private static readonly HashSet<string> Invisible = [
        Minecraft.Data.Generated.EntityType.AreaEffectCloud.Identifier,
        Minecraft.Data.Generated.EntityType.Interaction.Identifier,
        Minecraft.Data.Generated.EntityType.Marker.Identifier
    ];

    /// <summary>After the client's tick, for the state vanilla's client side entities keep.</summary>
    public void Tick(MinecraftClient client) {
        foreach (ClientEntity entity in client.Entities.Values) {
            if (RendererFor(entity) is not { } renderer) {
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

    /// <summary><c>getBoundingBoxForCulling</c>, relative to where the entity stands.</summary>
    private static (Vector3 Min, Vector3 Max) CullingBox(EntityRenderer? renderer, ClientEntity entity) {
        float half = (float)entity.Width / 2;
        return renderer?.BoundingBoxForCulling(entity) ?? (new Vector3(-half, 0, -half), new Vector3(half, (float)entity.Height, half));
    }

    /// <summary>
    /// <c>EntityRenderer.shouldRender</c> for a leashed entity out of view: drawn while its holder's box, or
    /// the box spanning both, is in view, so the lead does not vanish with it.
    /// </summary>
    private bool LeashInView(EntityRenderContext context, Frustum frustum, ClientEntity entity, Vector3 min, Vector3 max) {
        if (!Leashes.IsLeashable(entity) || Leashes.Holder(entity, context.Client) is not { } holder) {
            return false;
        }
        (Vector3 holderMin, Vector3 holderMax) = CullingBox(RendererFor(holder), holder);
        ClientLib.Maths.Vec3d camera = context.Camera.Position;
        Vector3 holderAt = new((float)(holder.Position.X - camera.X), (float)(holder.Position.Y - camera.Y), (float)(holder.Position.Z - camera.Z));
        holderMin += holderAt;
        holderMax += holderAt;
        return frustum.Intersects(holderMin, holderMax) || frustum.Intersects(Vector3.Min(min, holderMin), Vector3.Max(max, holderMax));
    }

    /// <summary>How far from the camera an entity out of view is still drawn for its shadow.</summary>
    private const double MaxCasterDistance = 64.0;

    /// <summary>
    /// Whether the shadow a box throws away from <paramref name="light"/> onto ground level with its bottom could be
    /// in view: the box swept along the light as far as its height carries it, at most 32 blocks.
    /// </summary>
    private static bool ShadowInView(Frustum frustum, Vector3 min, Vector3 max, Vector3 light) {
        float reach = Math.Min((max.Y - min.Y) / Math.Max(light.Y, 0.15F), 32.0F);
        Vector3 sweep = -light * reach;
        return frustum.Intersects(Vector3.Min(min, min + sweep), Vector3.Max(max, max + sweep));
    }

    /// <summary>An <c>entity_event</c> packet, passed to the renderer of the entity it names.</summary>
    public void HandleEntityEvent(MinecraftClient client, int entityId, byte eventId) {
        if (client.Entities.TryGetValue(entityId, out ClientEntity? entity) && RendererFor(entity) is { } renderer) {
            renderer.HandleEntityEvent(entity, eventId);
        }
    }

    /// <summary>
    /// <c>LevelExtractor</c>'s entity pass: the camera entity only from a detached view or asleep, and the
    /// local player only while it is the camera entity. A frozen entity is drawn where its last tick left it.
    /// With <paramref name="casters"/>, an entity culled for being out of view whose shadow could reach into it,
    /// and the player seen from its own eyes, are drawn into that instead.
    /// </summary>
    public void Render(EntityRenderContext context, ClientEntity cameraEntity, bool detached, ShadowCasters? casters = null) {
        Camera camera = context.Camera;
        Frustum frustum = Frustum.FromMatrix(camera.View * camera.CullProjection);
        float partialTick = context.PartialTick;
        foreach (ClientEntity entity in context.Client.Entities.Values) {
            bool viewedFromInside = entity == cameraEntity && !detached && !(entity.IsLiving && entity.IsSleeping);
            if (viewedFromInside || entity == context.Client.Player && cameraEntity != entity) {
                if (viewedFromInside && casters != null && entity == context.Client.Player && !EntityRenderer.IsSpectator(entity, context.Client)
                    && RendererFor(entity) is { } self) {
                    casters.Context.PartialTick = partialTick;
                    self.Render(entity, casters.Context);
                }
                continue;
            }
            context.PartialTick = context.Level.TickRateManager.IsEntityFrozen(entity) ? 1.0F : partialTick;
            double x = ClientEntity.Lerp(context.PartialTick, entity.OldPosition.X, entity.Position.X) - camera.Position.X;
            double y = ClientEntity.Lerp(context.PartialTick, entity.OldPosition.Y, entity.Position.Y) - camera.Position.Y;
            double z = ClientEntity.Lerp(context.PartialTick, entity.OldPosition.Z, entity.Position.Z) - camera.Position.Z;
            EntityRenderer? renderer = RendererFor(entity);
            if (renderer == null && Invisible.Contains(entity.Type.Identifier)) {
                continue;
            }
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
                (Vector3 min, Vector3 max) = CullingBox(renderer, entity);
                min += at - new Vector3(0.5F);
                max += at + new Vector3(0.5F);
                if (!frustum.Intersects(min, max) && !LeashInView(context, frustum, entity, min, max)
                    && renderer?.ShouldRenderOutOfView(entity, frustum, context) != true) {
                    if (casters != null && renderer != null && distanceSqr < MaxCasterDistance * MaxCasterDistance
                        && ShadowInView(frustum, min, max, casters.Light)) {
                        casters.Context.PartialTick = context.PartialTick;
                        renderer.Render(entity, casters.Context);
                    }
                    continue;
                }
            }
            if (renderer != null) {
                long start = TimeByType ? System.Diagnostics.Stopwatch.GetTimestamp() : 0;
                renderer.Render(entity, context);
                if (TimeByType) {
                    Time(entity.Type, start);
                }
                continue;
            }
            long fallbackStart = TimeByType ? System.Diagnostics.Stopwatch.GetTimestamp() : 0;
            context.SetOutlineColour(EntityRenderer.OutlineColourOf(entity, context.Client));
            fallback.Render(entity, context);
            context.SetOutlineColour(0);
            int bx = (int)Math.Floor(camera.Position.X + x), by = (int)Math.Floor(camera.Position.Y + y + entity.EyeHeight), bz = (int)Math.Floor(camera.Position.Z + z);
            int sky = context.Level.GetSkyLight(bx, by, bz);
            if (context.Flames != null && EntityRenderer.DisplayFireAnimation(entity, context.Client)) {
                PoseStack pose = new();
                pose.Translate(at);
                context.Flames.Submit(pose, (float)entity.Width, (float)entity.Height, sky, camera, context.Batch);
            }
            SubmitFallbackNameTags(entity, context, at, sky, entity.IsOnFire ? 15 : context.Level.GetBlockLight(bx, by, bz));
            if (TimeByType) {
                Time(entity.Type, fallbackStart);
            }
        }
        context.PartialTick = partialTick;
    }

    private readonly EntityRenderState _fallbackState = new();

    /// <summary>The name tags of an entity drawn as the built in art, which has no render state of its own to carry them.</summary>
    private void SubmitFallbackNameTags(ClientEntity entity, EntityRenderContext context, Vector3 at, float skyLight, float blockLight) {
        EntityRenderState state = _fallbackState;
        state.Entity = entity;
        state.IsDiscrete = entity.IsCrouching;
        state.SkyLight = skyLight;
        state.BlockLight = blockLight;
        NameTags.Extract(entity, state, context.PartialTick, context, NameTags.RuleFor(entity));
        if (state.NameTagAttachment == null) {
            return;
        }
        PoseStack pose = PoseStack.Rent();
        pose.Translate(at);
        NameTags.Submit(state, pose, context);
        PoseStack.Return(pose);
    }
}

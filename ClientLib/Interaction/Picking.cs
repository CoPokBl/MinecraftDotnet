using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Physics;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Interaction;

/// <summary>
/// <c>LocalPlayer.raycastHitResult</c>: the block the outline clip reaches first, or a pickable
/// entity nearer than it, each held to its own interaction range.
/// </summary>
public static class Picking {
    private static readonly Dictionary<uint, (Box[] Outline, Box[] Interaction)> Shapes = new();

    /// <param name="camera">What the ray starts from, <c>Minecraft.getCameraEntity</c>; the ranges are always the player's.</param>
    public static HitResult Pick(LocalPlayer player, ClientEntity camera, ClientLevel level, IEnumerable<ClientEntity> entities,
        IReadOnlyDictionary<Guid, PlayerListEntry> players, float partialTick) {
        double blockRange = player.Attributes.Value(Attribute.BlockInteractionRange);
        double entityRange = player.Attributes.Value(Attribute.EntityInteractionRange);
        double maxDistance = Math.Max(blockRange, entityRange);
        double maxDistanceSq = maxDistance * maxDistance;

        Vec3d from = EyePosition(camera, partialTick);
        Vec3d view = ViewVector(camera, partialTick);
        Vec3d to = from + view * maxDistance;
        IItem? held = camera.IsLiving ? camera.ItemInHand(Hand.MainHand).Type : null;
        HitResult blockHit = ClipBlocks(level, from, to, held);
        double blockDistanceSq = blockHit.Location.DistanceToSqr(from);
        if (blockHit is not MissResult) {
            maxDistanceSq = blockDistanceSq;
            maxDistance = Math.Sqrt(blockDistanceSq);
        }

        Vec3d entityTo = from + view * maxDistance;
        EntityHitResult? entityHit = PickEntity(camera, level, entities, players, from, entityTo, maxDistanceSq);
        return entityHit != null && entityHit.Location.DistanceToSqr(from) < blockDistanceSq
            ? Filter(entityHit, from, entityRange)
            : Filter(blockHit, from, blockRange);
    }

    /// <summary><c>Entity.getEyePosition(partialTick)</c>, from the interpolated feet.</summary>
    public static Vec3d EyePosition(ClientEntity entity, float partialTick) {
        return new Vec3d(
            ClientEntity.Lerp(partialTick, entity.OldPosition.X, entity.Position.X),
            ClientEntity.Lerp(partialTick, entity.OldPosition.Y, entity.Position.Y) + entity.CurrentEyeHeight,
            ClientEntity.Lerp(partialTick, entity.OldPosition.Z, entity.Position.Z));
    }

    /// <summary><c>Entity.calculateViewVector</c>, with vanilla's table sine so a ray lands where the server's does.</summary>
    public static Vec3d ViewVector(ClientEntity entity, float partialTick) {
        float xRot = partialTick == 1.0F ? entity.XRot : entity.XRotO + (entity.XRot - entity.XRotO) * partialTick;
        float yRot = partialTick == 1.0F ? entity.YRot : entity.YRotO + (entity.YRot - entity.YRotO) * partialTick;
        float xRad = xRot * ((float)Math.PI / 180.0F);
        float yRad = -yRot * ((float)Math.PI / 180.0F);
        float yCos = Mth.Cos(yRad);
        float ySin = Mth.Sin(yRad);
        float xCos = Mth.Cos(xRad);
        float xSin = Mth.Sin(xRad);
        return new Vec3d(ySin * xCos, -xSin, yCos * xCos);
    }

    private static HitResult Filter(HitResult hit, Vec3d from, double range) {
        if (hit.Location.DistanceToSqr(from) < range * range) {
            return hit;
        }
        return new MissResult(hit.Location);
    }

    /// <summary><c>BlockGetter.clip</c> with <c>ClipContext.Block.OUTLINE</c> and no fluids.</summary>
    /// <param name="heldItem">
    /// The main hand item of the entity the ray starts from: <c>isHoldingItem</c>, which turns the outline
    /// of a light block or a scaffolding into a full block while holding its own item.
    /// </param>
    public static HitResult ClipBlocks(ClientLevel level, Vec3d from, Vec3d to, IItem? heldItem = null) {
        Vec3<double> f = new(from.X, from.Y, from.Z), t = new(to.X, to.Y, to.Z);
        bool holdingLight = heldItem?.Identifier == Item.Light.Identifier;
        bool holdingScaffolding = heldItem?.Identifier == Item.Scaffolding.Identifier;
        (Vec3<int> Pos, BlockClip.ShapeHit Hit)? hit = BlockClip.TraverseBlocks<(Vec3<int>, BlockClip.ShapeHit)>(f, t, pos => {
            uint state = level.GetState(pos.X, pos.Y, pos.Z);
            (Box[] outline, Box[] interaction) = ShapesOf(level, state);
            if (holdingLight || holdingScaffolding) {
                Identifier id = level.Registry.Blocks.GetByStateId(state).Identifier;
                if (BlockClasses.Is(id, holdingLight ? BlockClass.LightBlock : BlockClass.ScaffoldingBlock)) {
                    outline = LevelCollisions.Block;
                }
            }
            if (outline.Length == 0) {
                return null;
            }
            IBlock block = level.Registry.Blocks.GetByStateId(state);
            Box[] moved = Moved(block, outline, BlockShapeOffsets.Block, pos);
            BlockClip.ShapeHit? result = BlockClip.ClipShape(moved, pos, f, t);
            if (result == null) {
                return null;
            }
            BlockClip.ShapeHit? over = BlockClip.ClipShape(Moved(block, interaction, BlockShapeOffsets.Interaction, pos), pos, f, t);
            if (over != null && over.Value.Scale < result.Value.Scale) {
                result = result.Value with { Face = over.Value.Face };
            }
            return (pos, result.Value);
        });

        if (hit == null) {
            return new MissResult(to);
        }
        (Vec3<int> blockPos, BlockClip.ShapeHit shapeHit) = hit.Value;
        Vec3d location = from + (to - from) * shapeHit.Scale;
        return new BlockHitResult(location, blockPos.X, blockPos.Y, blockPos.Z, shapeHit.Face, shapeHit.Scale <= 0.001);
    }

    private static (Box[] Outline, Box[] Interaction) ShapesOf(ClientLevel level, uint state) {
        lock (Shapes) {
            if (!Shapes.TryGetValue(state, out (Box[], Box[]) shapes)) {
                IBlock block = level.Registry.Blocks.GetByStateId(state);
                shapes = (BlockPhysicsData.ShapeBoxesOf(block.BlockShape), BlockPhysicsData.ShapeBoxesOf(block.InteractionShape));
                Shapes[state] = shapes;
            }
            return shapes;
        }
    }

    private static Box[] Moved(IBlock block, Box[] boxes, BlockShapeOffsets shape, Vec3<int> pos) {
        if (boxes.Length == 0 || !block.Info.Offsets(shape)) {
            return boxes;
        }
        Vec3<double> offset = block.Info.ShapeOffset(pos);
        Box[] moved = new Box[boxes.Length];
        for (int i = 0; i < boxes.Length; i++) {
            moved[i] = boxes[i].Translate(offset);
        }
        return moved;
    }

    /// <summary><c>ProjectileUtil.getEntityHitResult</c> over the entities a pick can land on.</summary>
    private static EntityHitResult? PickEntity(ClientEntity shooter, ClientLevel level, IEnumerable<ClientEntity> entities, IReadOnlyDictionary<Guid, PlayerListEntry> players,
        Vec3d from, Vec3d to, double maxDistanceSq) {
        Box search = (shooter is LocalPlayer local ? local.BoundingBox : BoundingBox(shooter)).ExpandTowards(to.X - from.X, to.Y - from.Y, to.Z - from.Z).Inflate(1.0);
        double nearest = maxDistanceSq;
        ClientEntity? hovered = null;
        Vec3d hoveredPos = default;
        Vec3<double> f = new(from.X, from.Y, from.Z), t = new(to.X, to.Y, to.Z);

        foreach (ClientEntity entity in entities) {
            if (entity == shooter || !IsPickable(entity, level, players)) {
                continue;
            }
            Box box = BoundingBox(entity);
            if (!box.Intersects(search)) {
                continue;
            }
            BlockClip.ShapeHit? clip = BlockClip.ClipAabb(box, f, t);
            bool inside = from.X >= box.MinX && from.X < box.MaxX && from.Y >= box.MinY && from.Y < box.MaxY && from.Z >= box.MinZ && from.Z < box.MaxZ;
            if (inside) {
                if (nearest >= 0.0) {
                    hovered = entity;
                    hoveredPos = clip != null ? from + (to - from) * clip.Value.Scale : from;
                    nearest = 0.0;
                }
            }
            else if (clip != null) {
                Vec3d location = from + (to - from) * clip.Value.Scale;
                double distance = from.DistanceToSqr(location);
                if (distance < nearest || nearest == 0.0) {
                    if (entity.RootVehicle == shooter.RootVehicle) {
                        if (nearest == 0.0) {
                            hovered = entity;
                            hoveredPos = location;
                        }
                    }
                    else {
                        hovered = entity;
                        hoveredPos = location;
                        nearest = distance;
                    }
                }
            }
        }

        return hovered == null ? null : new EntityHitResult(hoveredPos, hovered);
    }

    public static Box BoundingBox(ClientEntity entity) => entity.BoundingBox;

    /// <summary>
    /// <c>Entity.isPickable</c> and its overrides, by the entity's vanilla class. The dragon itself is
    /// never picked in vanilla, only its parts, which the server does not send as entities; its own box
    /// stands in for them so it can still be hit.
    /// </summary>
    public static bool IsPickable(ClientEntity entity, ClientLevel level, IReadOnlyDictionary<Guid, PlayerListEntry> players) {
        if (entity.Is(EntityClass.EnderDragon)) {
            return true;
        }
        if (entity.Is(EntityClass.Player)) {
            return !(players.TryGetValue(entity.Uuid, out PlayerListEntry? listed) && listed.GameMode == GameMode.Spectator);
        }
        if (entity.Is(EntityClass.ArmorStand)) {
            // ArmorStand.isMarker: CLIENT_FLAG_MARKER in DATA_CLIENT_FLAGS.
            return (entity.Get(EntityDataFields.ArmorStand.ClientFlags) & 16) == 0;
        }
        if (entity.Is(EntityClass.LivingEntity) || entity.Is(EntityClass.Interaction) || entity.Is(EntityClass.EndCrystal)
            || entity.Is(EntityClass.BlockAttachedEntity) || entity.Is(EntityClass.FallingBlockEntity) || entity.Is(EntityClass.PrimedTnt)
            || entity.Is(EntityClass.AbstractMinecart) || entity.Is(EntityClass.AbstractBoat) || entity.Is(EntityClass.ShulkerBullet)) {
            return true;
        }
        if (entity.Is(EntityClass.Projectile)) {
            bool redirectable = InEntityTag(level.Registry, RedirectableProjectile, entity.Type.Identifier);
            return entity.Is(EntityClass.AbstractArrow) ? redirectable && !entity.Get(EntityDataFields.AbstractArrow.InGround) : redirectable;
        }
        return false;
    }

    // EntityTypeTags.REDIRECTABLE_PROJECTILE. Entity type tags have no generated type; the server sends this one.
    internal static readonly Identifier RedirectableProjectile = "minecraft:redirectable_projectile";

    private static bool InEntityTag(MinecraftRegistry registry, Identifier tag, Identifier type) {
        if (!registry.EntityTypes.Tags.Contains(tag)) {
            return false;
        }
        foreach (Identifier value in registry.EntityTypes.Tags[tag].GetValueIds(registry)) {
            if (value.Equals(type)) {
                return true;
            }
        }
        return false;
    }
}

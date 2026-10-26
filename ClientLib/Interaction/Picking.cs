using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Physics;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Interaction;

/// <summary>
/// <c>LocalPlayer.raycastHitResult</c>: the block the outline clip reaches first, or a pickable
/// entity nearer than it, each held to its own interaction range. An active item with an attack range
/// is asked first, and its answer stands unless it found nothing.
/// </summary>
public static class Picking {
    private static readonly Dictionary<uint, (Box[] Outline, Box[] Interaction)> Shapes = new();

    /// <param name="camera">What the ray starts from, <c>Minecraft.getCameraEntity</c>; the ranges are always the player's.</param>
    public static HitResult Pick(LocalPlayer player, ClientEntity camera, ClientLevel level, IEnumerable<ClientEntity> entities,
        IReadOnlyDictionary<Guid, PlayerListEntry> players, float partialTick) {
        double blockRange = player.Attributes.Value(Attribute.BlockInteractionRange);
        HitResult? hit = null;
        if (ItemComponents.Get(ActiveItem(player), DataComponent.AttackRange) is { } attackRange) {
            hit = ClosestHit(attackRange, camera, level, entities, players, partialTick);
            if (hit is BlockHitResult) {
                hit = Filter(hit, EyePosition(camera, partialTick), blockRange);
            }
        }
        if (hit is null or MissResult) {
            double entityRange = player.Attributes.Value(Attribute.EntityInteractionRange);
            hit = Pick(camera, level, entities, players, blockRange, entityRange, partialTick);
        }
        return hit;
    }

    /// <summary><c>LocalPlayer.pick</c>: the outline clip, then an entity nearer than the block it reached.</summary>
    private static HitResult Pick(ClientEntity camera, ClientLevel level, IEnumerable<ClientEntity> entities,
        IReadOnlyDictionary<Guid, PlayerListEntry> players, double blockRange, double entityRange, float partialTick) {
        double maxDistance = Math.Max(blockRange, entityRange);
        double maxDistanceSq = maxDistance * maxDistance;

        Vec3d from = EyePosition(camera, partialTick);
        Vec3d view = ViewVector(camera, partialTick);
        Vec3d to = from + view * maxDistance;
        HitResult blockHit = ClipBlocks(level, from, to, HeldItem(camera));
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

    /// <summary><c>LivingEntity.getActiveItem</c>: nothing for a spectator, else the stack in use or the main hand.</summary>
    public static ItemStack ActiveItem(LocalPlayer player) {
        if (player.IsSpectator) {
            return ItemStack.Air;
        }
        return player.IsUsingItem ? player.UseItem : player.ItemInHand(Hand.MainHand);
    }

    /// <summary>
    /// <c>AttackRange.getClosesetHit</c>: the block <see cref="HitEntitiesAlong"/> stopped at, else the candidate
    /// nearest the interpolated eyes, the first of equals winning. Vanilla visits candidates in entity section
    /// order and <paramref name="entities"/> is visited as given, so only two candidates at exactly the same
    /// distance, such as two boxes both holding the near end of the reach, can be told apart differently.
    /// </summary>
    public static HitResult ClosestHit(AttackRangeComponent.Data range, ClientEntity attacker, ClientLevel level, IEnumerable<ClientEntity> entities,
        IReadOnlyDictionary<Guid, PlayerListEntry> players, float partialTick) {
        (HitResult? block, List<EntityHitResult>? targets) = HitEntitiesAlong(range, attacker, level, entities, players);
        if (block != null) {
            return block;
        }
        EntityHitResult? nearest = null;
        Vec3d attackerPos = EyePosition(attacker, partialTick);
        double closestDistance = double.MaxValue;
        foreach (EntityHitResult target in targets!) {
            double distance = attackerPos.DistanceToSqr(target.Location);
            if (distance < closestDistance) {
                closestDistance = distance;
                nearest = target;
            }
        }
        if (nearest != null) {
            return nearest;
        }
        return new MissResult(EyePosition(attacker, partialTick) + HeadLookAngle(attacker));
    }

    /// <summary>
    /// <c>ProjectileUtil.getHitEntitiesAlong</c> for an attack range: an outline clip from the eyes along the head's
    /// look to the far reach, lengthened by any movement along it. A block nearer than the near reach is the
    /// answer (<c>Either.left</c>), as is the clip's result when no entity lies between the reaches; otherwise
    /// every entity found (<c>Either.right</c>), unordered.
    /// </summary>
    public static (HitResult? Block, List<EntityHitResult>? Entities) HitEntitiesAlong(AttackRangeComponent.Data range, ClientEntity attacker,
        ClientLevel level, IEnumerable<ClientEntity> entities, IReadOnlyDictionary<Guid, PlayerListEntry> players) {
        Vec3d look = HeadLookAngle(attacker);
        Vec3d eye = EyePosition(attacker);
        Vec3d from = eye + look * EffectiveMinRange(range, attacker, players);
        Vec3d movement = KnownMovement(attacker);
        double movementComponent = movement.X * look.X + movement.Y * look.Y + movement.Z * look.Z;
        Vec3d to = eye + look * (EffectiveMaxRange(range, attacker, players) + Math.Max(0.0, movementComponent));

        IItem? held = HeldItem(attacker);
        HitResult hit = ClipIncludingBorder(level, eye, to, held);
        if (hit is not MissResult) {
            to = hit.Location;
            if (eye.DistanceToSqr(to) < eye.DistanceToSqr(from)) {
                return (hit, null);
            }
        }

        float margin = range.HitboxMargin;
        Box search = new Box(from.X - margin / 2.0, from.Y - margin / 2.0, from.Z - margin / 2.0,
                from.X + margin / 2.0, from.Y + margin / 2.0, from.Z + margin / 2.0)
            .ExpandTowards(to.X - from.X, to.Y - from.Y, to.Z - from.Z).Inflate(1.0);
        List<EntityHitResult> found = ManyEntityHitResult(attacker, level, entities, players, from, to, search, margin, held);
        return found.Count > 0 ? (null, found) : (hit, null);
    }

    /// <summary>
    /// <c>ProjectileUtil.getManyEntityHitResult</c> with <c>includeFromEntity</c>, under the outline clip. A box the ray
    /// misses but its margin catches counts where a ray from the margin towards the box's centre, stopped by any
    /// block in between, meets the box.
    /// </summary>
    private static List<EntityHitResult> ManyEntityHitResult(ClientEntity source, ClientLevel level, IEnumerable<ClientEntity> entities,
        IReadOnlyDictionary<Guid, PlayerListEntry> players, Vec3d from, Vec3d to, Box search, float margin, IItem? held) {
        List<EntityHitResult> collector = [];
        Vec3<double> f = new(from.X, from.Y, from.Z), t = new(to.X, to.Y, to.Z);
        foreach (ClientEntity entity in entities) {
            if (entity == source || !BoundingBox(entity).Intersects(search) || !IsPickable(entity, level, players)) {
                continue;
            }
            Box box = BoundingBox(entity);
            if (Contains(box, from)) {
                collector.Add(new EntityHitResult(from, entity));
                continue;
            }
            BlockClip.ShapeHit? exact = BlockClip.ClipAabb(box, f, t);
            if (exact != null) {
                collector.Add(new EntityHitResult(from + (to - from) * exact.Value.Scale, entity));
                continue;
            }
            if (margin <= 0.0) {
                continue;
            }
            BlockClip.ShapeHit? outside = BlockClip.ClipAabb(box.Inflate(margin), f, t);
            if (outside == null) {
                continue;
            }
            Vec3d outsidePosition = from + (to - from) * outside.Value.Scale;
            Vec3d towardsTarget = new(ClientEntity.Lerp(0.5, box.MinX, box.MaxX), ClientEntity.Lerp(0.5, box.MinY, box.MaxY),
                ClientEntity.Lerp(0.5, box.MinZ, box.MaxZ));
            HitResult blocked = ClipIncludingBorder(level, outsidePosition, towardsTarget, held);
            if (blocked is not MissResult) {
                towardsTarget = blocked.Location;
            }
            BlockClip.ShapeHit? surface = BlockClip.ClipAabb(box, new Vec3<double>(outsidePosition.X, outsidePosition.Y, outsidePosition.Z),
                new Vec3<double>(towardsTarget.X, towardsTarget.Y, towardsTarget.Z));
            if (surface != null) {
                collector.Add(new EntityHitResult(outsidePosition + (towardsTarget - outsidePosition) * surface.Value.Scale, entity));
            }
        }
        return collector;
    }

    /// <summary>
    /// <c>CollisionGetter.clipIncludingBorder</c>: a clip starting inside the world border that would end outside it
    /// stops at the border instead, as a hit on the block there.
    /// </summary>
    public static HitResult ClipIncludingBorder(ClientLevel level, Vec3d from, Vec3d to, IItem? heldItem) {
        HitResult hit = ClipBlocks(level, from, to, heldItem);
        WorldBorder border = level.WorldBorder;
        if (!border.IsWithinBounds(from.X, from.Z) || border.IsWithinBounds(hit.Location.X, hit.Location.Z)) {
            return hit;
        }
        Vec3d delta = hit.Location - from;
        BlockFace direction = BlockClip.ApproximateNearest(delta.X, delta.Y, delta.Z);
        Vec3d clamped = new(Clamp(hit.Location.X, border.MinX, border.MaxX - 1.0E-5F), hit.Location.Y,
            Clamp(hit.Location.Z, border.MinZ, border.MaxZ - 1.0E-5F));
        return new BlockHitResult(clamped, (int)Math.Floor(clamped.X), (int)Math.Floor(clamped.Y), (int)Math.Floor(clamped.Z), direction, false, true);
    }

    /// <summary><c>Mth.clamp</c>, which unlike <see cref="Math.Clamp(double, double, double)"/> does not throw on an empty range.</summary>
    private static double Clamp(double value, double min, double max) => value < min ? min : Math.Min(value, max);

    private static bool Contains(Box box, Vec3d point) =>
        point.X >= box.MinX && point.X < box.MaxX && point.Y >= box.MinY && point.Y < box.MaxY && point.Z >= box.MinZ && point.Z < box.MaxZ;

    /// <summary><c>AttackRange.effectiveMinRange</c>: a player's own pair by game mode, anything else the survival one scaled.</summary>
    public static float EffectiveMinRange(AttackRangeComponent.Data range, ClientEntity entity, IReadOnlyDictionary<Guid, PlayerListEntry> players) {
        if (entity.Is(EntityClass.Player)) {
            return IsCreative(entity, players) ? range.MinCreativeReach : range.MinReach;
        }
        return range.MinReach * range.MobFactor;
    }

    /// <summary><c>AttackRange.effectiveMaxRange</c>.</summary>
    public static float EffectiveMaxRange(AttackRangeComponent.Data range, ClientEntity entity, IReadOnlyDictionary<Guid, PlayerListEntry> players) {
        if (entity.Is(EntityClass.Player)) {
            return IsCreative(entity, players) ? range.MaxCreativeReach : range.MaxReach;
        }
        return range.MaxReach * range.MobFactor;
    }

    /// <summary><c>Player.isCreative</c>: the local player's own game mode, another player's from the player list.</summary>
    private static bool IsCreative(ClientEntity player, IReadOnlyDictionary<Guid, PlayerListEntry> players) => player is LocalPlayer local
        ? local.IsCreative
        : players.TryGetValue(player.Uuid, out PlayerListEntry? listed) && listed.GameMode == GameMode.Creative;

    /// <summary><c>Entity.getKnownMovement</c>: a living player's riding is its rider's movement.</summary>
    private static Vec3d KnownMovement(ClientEntity entity) {
        if (entity.ControllingPassenger is { } controller && controller.Is(EntityClass.Player)
            && !entity.IsRemoved && (!entity.IsLiving || entity.CurrentHealth > 0.0F)) {
            return KnownMovement(controller);
        }
        return entity.DeltaMovement;
    }

    /// <summary>The item <c>CollisionContext.of(entity)</c> holds for <c>isHoldingItem</c>: a living entity's main hand.</summary>
    public static IItem? HeldItem(ClientEntity entity) => entity.IsLiving ? entity.ItemInHand(Hand.MainHand).Type : null;

    /// <summary><c>Entity.getEyePosition()</c>: the feet as they are, which a lerp to 1 does not always reproduce.</summary>
    public static Vec3d EyePosition(ClientEntity entity) =>
        new(entity.Position.X, entity.Position.Y + entity.CurrentEyeHeight, entity.Position.Z);

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
        return CalculateViewVector(xRot, yRot);
    }

    /// <summary><c>Entity.getHeadLookAngle</c>: the pitch with the head's yaw, neither interpolated.</summary>
    public static Vec3d HeadLookAngle(ClientEntity entity) => CalculateViewVector(entity.XRot, entity.YHeadRot);

    /// <summary><c>Entity.calculateViewVector</c>.</summary>
    public static Vec3d CalculateViewVector(float xRot, float yRot) {
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
    /// <param name="heldItem">The main hand item of the entity the ray starts from, for <see cref="OutlineShape"/>.</param>
    public static HitResult ClipBlocks(ClientLevel level, Vec3d from, Vec3d to, IItem? heldItem = null) {
        Vec3<double> f = new(from.X, from.Y, from.Z), t = new(to.X, to.Y, to.Z);
        (Vec3<int> Pos, BlockClip.ShapeHit Hit)? hit = BlockClip.TraverseBlocks<(Vec3<int>, BlockClip.ShapeHit)>(f, t, pos => {
            uint state = level.GetState(pos.X, pos.Y, pos.Z);
            BlockClip.ShapeHit? result = BlockClip.ClipShape(OutlineShape(level, state, pos, heldItem), pos, f, t);
            if (result == null) {
                return null;
            }
            BlockClip.ShapeHit? over = BlockClip.ClipShape(InteractionShape(level, state, pos), pos, f, t);
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

    /// <summary>
    /// <c>BlockState.getShape(level, pos, CollisionContext.of(entity))</c> for an entity holding <paramref name="heldItem"/>
    /// in its main hand, in the block's own coordinates with its offset applied. The generated table is the shape
    /// with no block entity and nothing held, which is wrong only for an open shulker box and for a light block or
    /// scaffolding while holding its own item. A moving piston's outline is empty whatever its block entity holds.
    /// </summary>
    public static Box[] OutlineShape(ClientLevel level, int x, int y, int z, IItem? heldItem = null) =>
        OutlineShape(level, level.GetState(x, y, z), new Vec3<int>(x, y, z), heldItem);

    private static Box[] OutlineShape(ClientLevel level, uint state, Vec3<int> pos, IItem? heldItem) {
        if (LevelCollisions.ContextShapeOf(level.Registry, state) == LevelCollisions.ContextShape.ShulkerBox) {
            return LevelCollisions.ShulkerBoxShape(level, pos.X, pos.Y, pos.Z);
        }
        IBlock block = level.Registry.Blocks.GetByStateId(state);
        if (heldItem != null && (heldItem.Identifier == Item.Light.Identifier && BlockClasses.Is(block.Identifier, BlockClass.LightBlock)
                || heldItem.Identifier == Item.Scaffolding.Identifier && BlockClasses.Is(block.Identifier, BlockClass.ScaffoldingBlock))) {
            return LevelCollisions.Block;
        }
        return Moved(block, ShapesOf(level, state).Outline, BlockShapeOffsets.Block, pos);
    }

    /// <summary><c>BlockState.getInteractionShape</c>, which no block reads off the level for.</summary>
    private static Box[] InteractionShape(ClientLevel level, uint state, Vec3<int> pos) =>
        Moved(level.Registry.Blocks.GetByStateId(state), ShapesOf(level, state).Interaction, BlockShapeOffsets.Interaction, pos);

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
            if (!BoundingBox(entity).Intersects(search)) {
                continue;
            }
            Box box = BoundingBox(entity).Inflate(PickRadius(entity));
            BlockClip.ShapeHit? clip = BlockClip.ClipAabb(box, f, t);
            bool inside = from.X >= box.MinX && from.X < box.MaxX && from.Y >= box.MinY && from.Y < box.MaxY && from.Z >= box.MinZ && from.Z < box.MaxZ;
            if (inside) {
                if (nearest >= 0.0 && CanBePickedFromInside(entity)) {
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

    /// <summary><c>Entity.getPickRadius</c>: a projectile's box grows by a block on every side, for an entity already found pickable.</summary>
    private static double PickRadius(ClientEntity entity) => entity.Is(EntityClass.Projectile) ? 1.0F : 0.0F;

    /// <summary><c>Entity.canBePickedFromInside</c>: a sulfur cube carrying a block cannot be targeted from inside it.</summary>
    private static bool CanBePickedFromInside(ClientEntity entity) =>
        !entity.Is(EntityClass.SulfurCube) || entity.GetItemBySlot(EquipmentSlot.Body).IsAir();

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

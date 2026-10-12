using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ClientLib.Entities;

/// <summary>
/// <c>ExperienceOrb</c>: the one simulated entity that interpolates toward the server's positions,
/// and it chases the nearest player on the client as well.
/// </summary>
public sealed class ClientExperienceOrb : SimulatedEntity {
    private readonly InterpolationHandler _interpolation;
    private ClientEntity? _followingPlayer;

    public ClientExperienceOrb(MinecraftClient client) : base(client) {
        _interpolation = new InterpolationHandler(this);
    }

    protected override float BelowThatAffectsMovementOffset => 0.999999F;

    public override void InterpolateTo(Vec3d position, float yRot, float xRot) => _interpolation.InterpolateTo(position, yRot, xRot);

    public override void InterpolateTo(Vec3d position) => _interpolation.InterpolateTo(position, _interpolation.YRot, _interpolation.XRot);

    public override void InterpolateRotation(float yRot, float xRot) => _interpolation.InterpolateTo(_interpolation.Position, yRot, xRot);

    /// <summary><c>ExperienceOrb.tick</c>, client side.</summary>
    protected override void EntityTick() {
        _interpolation.Interpolate();
        if (FirstTick) {
            FirstTick = false;
            return;
        }

        BaseTick();
        bool colliding = !LevelCollisions.NoCollision(Level, BoundingBox) || !EntityCollisions.None(Client, null, BoundingBox);
        if (Fluids.EyeInWater) {
            SetUnderwaterMovement();
        }
        else if (!colliding) {
            ApplyGravity();
        }

        if (BlockAt(BlockX, BlockY, BlockZ).Fluid == FluidKind.Lava) {
            // The client's own random, which cannot follow the server's draws; the server corrects it.
            Random random = Random.Shared;
            DeltaMovement = new Vec3d((random.NextSingle() - random.NextSingle()) * 0.2F, 0.2F, (random.NextSingle() - random.NextSingle()) * 0.2F);
        }

        FollowNearbyPlayer();

        double fallSpeed = DeltaMovement.Y;
        Move(DeltaMovement);
        ApplyEffectsFromBlocks();
        float friction = AirDrag;
        if (OnGround) {
            friction *= FrictionBelow();
        }

        DeltaMovement *= friction;
        if (VerticalCollisionBelow && fallSpeed < -Gravity) {
            DeltaMovement = new Vec3d(DeltaMovement.X, -fallSpeed * 0.4, DeltaMovement.Z);
        }
    }

    /// <summary><c>ExperienceOrb.setUnderwaterMovement</c>.</summary>
    private void SetUnderwaterMovement() {
        Vec3d movement = DeltaMovement;
        DeltaMovement = new Vec3d(movement.X * 0.99F, Math.Min(movement.Y + 5.0E-4F, 0.06F), movement.Z * 0.99F);
    }

    /// <summary><c>ExperienceOrb.followNearbyPlayer</c>.</summary>
    private void FollowNearbyPlayer() {
        if (_followingPlayer == null || IsSpectator(_followingPlayer) || _followingPlayer.Position.DistanceToSqr(Position) > 64.0) {
            ClientEntity? nearest = NearestPlayer(8.0);
            _followingPlayer = nearest != null && !IsSpectator(nearest) && !(nearest.CurrentHealth <= 0.0F) ? nearest : null;
        }

        if (_followingPlayer is { } player) {
            Vec3d delta = new(
                player.Position.X - Position.X,
                player.Position.Y + EyeHeightOf(player) / 2.0 - Position.Y,
                player.Position.Z - Position.Z);
            double length = delta.LengthSqr();
            double power = 1.0 - Math.Sqrt(length) / 8.0;
            DeltaMovement += delta.Normalize() * (power * power * 0.1);
        }
    }

    /// <summary><c>EntityGetter.getNearestPlayer(entity, range)</c>, which skips spectators.</summary>
    private ClientEntity? NearestPlayer(double range) {
        double best = -1.0;
        ClientEntity? result = null;
        foreach (ClientEntity entity in Client.Entities.Values) {
            if (entity.Type != EntityType.Player || IsSpectator(entity)) {
                continue;
            }
            double distance = entity.Position.DistanceToSqr(Position);
            if ((range < 0.0 || distance < range * range) && (best == -1.0 || distance < best)) {
                best = distance;
                result = entity;
            }
        }
        return result;
    }

    private bool IsSpectator(ClientEntity player) {
        if (player is LocalPlayer local) {
            return local.IsSpectator;
        }
        return Client.PlayerList.TryGetValue(player.Uuid, out PlayerListEntry? entry) && entry.GameMode == GameMode.Spectator;
    }

    /// <summary>
    /// <c>Entity.getEyeHeight</c>. Another player's pose is not tracked, so it is taken as standing,
    /// which puts the orb's aim 0.175 high for a crouching one.
    /// </summary>
    private static double EyeHeightOf(ClientEntity player) => player is LocalPlayer local ? local.CurrentEyeHeight : (float)player.EyeHeight;
}

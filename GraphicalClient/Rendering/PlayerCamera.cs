using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using GraphicalClient.Rendering.Entities;
using Minecraft.Data.Generated;
using System.Numerics;

namespace GraphicalClient.Rendering;

/// <summary><c>Camera.setup</c>, and <c>GameRenderer</c>'s view bobbing from the camera entity and spinning effect from the player.</summary>
public sealed class PlayerCamera {
    private const float PortalSpinningSpeed = 20.0F, NauseaSpinningSpeed = 7.0F;

    private float _eyeHeight = 1.62F, _eyeHeightOld = 1.62F;
    private float _spinningEffectTime, _spinningEffectSpeed;

    // Vanilla's start at zero, which makes the projection singular until the first tick.
    private float _fovModifier = 1.0F, _oldFovModifier = 1.0F;

    /// <summary>F5's three views: first person, behind, in front.</summary>
    public int Mode { get; private set; }
    public bool FirstPerson => Mode == 0;

    public void CycleMode() => Mode = (Mode + 1) % 3;

    /// <summary>
    /// <c>Camera.tick</c>: the eye moves halfway to the entity's eye height each tick, so crouching glides,
    /// and the field of view eases halfway to the player's modifier. Then <c>GameRenderer.tick</c>'s spin, at
    /// a speed between the portal's and nausea's by how strong each is.
    /// </summary>
    public void Tick(ClientEntity? entity, LocalPlayer? player, float fovEffectScale) {
        if (entity != null) {
            _eyeHeightOld = _eyeHeight;
            _eyeHeight += (entity.CurrentEyeHeight - _eyeHeight) * 0.5F;
        }
        TickFov(entity, fovEffectScale);
        if (player == null) {
            return;
        }
        float portalIntensity = player.PortalEffectIntensity;
        float nauseaIntensity = player.GetEffectBlendFactor(PotionEffectType.Nausea, 1.0F);
        if (!(portalIntensity > 0.0F) && !(nauseaIntensity > 0.0F)) {
            _spinningEffectSpeed = 0.0F;
        }
        else {
            _spinningEffectSpeed = (portalIntensity * PortalSpinningSpeed + nauseaIntensity * NauseaSpinningSpeed) / (portalIntensity + nauseaIntensity);
            _spinningEffectTime = _spinningEffectTime + _spinningEffectSpeed;
        }
    }

    /// <summary>
    /// <c>Camera.tickFov</c>. Only the local player's modifier is known, so a camera on another player
    /// keeps the option's field of view, where vanilla gives it that player's.
    /// </summary>
    private void TickFov(ClientEntity? entity, float fovEffectScale) {
        float targetFovModifier = entity is LocalPlayer player ? player.FieldOfViewModifier(FirstPerson, fovEffectScale) : 1.0F;
        _oldFovModifier = _fovModifier;
        _fovModifier += (targetFovModifier - _fovModifier) * 0.5F;
        _fovModifier = Math.Clamp(_fovModifier, 0.1F, 1.5F);
    }

    /// <summary>
    /// <c>Camera.modifyFovBasedOnDeathOrFluid</c>. The fluid is the one in the block the camera is in,
    /// without the fluid height and the near plane corners <c>getFluidInCamera</c> also tests.
    /// </summary>
    private static float ModifyFovBasedOnDeathOrFluid(ClientEntity entity, ClientLevel level, Vec3d position, float partialTick, float fovEffectScale,
        float fov) {
        if (entity.IsLiving && entity.CurrentHealth <= 0) {
            float duration = Math.Min(entity.DeathTime + partialTick, 20.0F);
            fov /= (1.0F - 500.0F / (duration + 500.0F)) * 2.0F + 1.0F;
        }
        string? fluid = level.GetBlock((int)Math.Floor(position.X), (int)Math.Floor(position.Y), (int)Math.Floor(position.Z)).Fluid?.Key;
        if (fluid is "water" or "flowing_water" or "lava" or "flowing_lava") {
            fov *= Mth.Lerp(fovEffectScale, 1.0F, 0.85714287F);
        }
        return fov;
    }

    /// <summary>
    /// <c>Camera.alignWithEntity</c> and <c>calculateFov</c>, then the hurt tilt, the walk bob and the player's
    /// spinning effect. <paramref name="worldPartialTick"/> is the level's, which goes on moving while a
    /// frozen camera entity's is held at 1.
    /// </summary>
    public void Setup(Camera camera, ClientEntity entity, LocalPlayer player, ClientLevel level, float partialTick, float worldPartialTick,
        float screenEffectScale, int fov, float fovEffectScale, float aspect, float farPlane) {
        float eye = _eyeHeightOld + (_eyeHeight - _eyeHeightOld) * partialTick;
        Vec3d position = new(
            ClientEntity.Lerp(partialTick, entity.OldPosition.X, entity.Position.X),
            ClientEntity.Lerp(partialTick, entity.OldPosition.Y, entity.Position.Y) + eye,
            ClientEntity.Lerp(partialTick, entity.OldPosition.Z, entity.Position.Z));
        (float yaw, float pitch) = ViewRotation(entity, partialTick);
        if (Mode != 0) {
            (position, yaw, pitch) = ThirdPerson(level, position, yaw, pitch, Mode == 2, CameraDistance(entity));
        }
        else if (entity.IsLiving && entity.IsSleeping) {
            // Lying down, the view follows the bed rather than the entity, lifted by move(0, 0.15, 0).
            yaw = entity.BedOrientation(level) is { } bed ? ClientEntity.ToYRot(bed) - 180.0F : 0.0F;
            pitch = 0.0F;
            position = new Vec3d(position.X, position.Y + 0.15F, position.Z);
        }
        camera.FovDegrees = ModifyFovBasedOnDeathOrFluid(entity, level, position, partialTick, fovEffectScale,
            fov * Mth.Lerp(partialTick, _oldFovModifier, _fovModifier));
        camera.CullFovDegrees = fov;
        camera.HudFovDegrees = ModifyFovBasedOnDeathOrFluid(entity, level, position, partialTick, fovEffectScale, 70.0F);
        camera.Update(position, yaw, pitch, aspect, farPlane);
        PoseStack bob = new();
        BobHurt(entity, partialTick, bob);
        // Another player's walk bob is not tracked, so only the local player's view bobs.
        if (entity is LocalPlayer local) {
            BobView(local, partialTick, bob);
        }
        SpinningEffect(player, worldPartialTick, screenEffectScale, bob);
        camera.Bob = bob.Matrix;
    }

    /// <summary>
    /// <c>GameRenderer.renderLevel</c>'s warp of the projection by the stronger of the portal and nausea: a
    /// squash along an axis that turns with the spin.
    /// </summary>
    private void SpinningEffect(LocalPlayer player, float partialTick, float screenEffectScale, PoseStack pose) {
        float portalIntensity = Mth.Lerp(partialTick, player.OPortalEffectIntensity, player.PortalEffectIntensity);
        float nauseaIntensity = player.GetEffectBlendFactor(PotionEffectType.Nausea, partialTick);
        float spinningEffectIntensity = Math.Max(portalIntensity, nauseaIntensity) * (screenEffectScale * screenEffectScale);
        if (spinningEffectIntensity > 0.0F) {
            float skew = 5.0F / (spinningEffectIntensity * spinningEffectIntensity + 5.0F) - spinningEffectIntensity * 0.04F;
            skew *= skew;
            Vector3 axis = new(0.0F, MathF.Sqrt(2.0F) / 2.0F, MathF.Sqrt(2.0F) / 2.0F);
            float angle = (_spinningEffectTime + partialTick * _spinningEffectSpeed) * (float)(Math.PI / 180.0);
            pose.Rotate(Matrix4x4.CreateFromAxisAngle(axis, angle));
            pose.Scale(1.0F / skew, 1.0F, 1.0F);
            pose.Rotate(Matrix4x4.CreateFromAxisAngle(axis, -angle));
        }
    }

    /// <summary><c>getViewYRot</c> and <c>getViewXRot</c>: a living entity looks where its head turns.</summary>
    private static (float Yaw, float Pitch) ViewRotation(ClientEntity entity, float partialTick) {
        float pitch = entity.XRotO + (entity.XRot - entity.XRotO) * partialTick;
        if (entity is LocalPlayer) {
            return (entity.YRotO + (entity.YRot - entity.YRotO) * partialTick, pitch);
        }
        return entity.IsLiving
            ? ((float)ClientEntity.RotLerp(partialTick, entity.YHeadRotO, entity.YHeadRot), pitch)
            : ((float)ClientEntity.RotLerp(partialTick, entity.YRotO, entity.YRot), pitch);
    }

    /// <summary><c>Camera.alignWithEntity</c>'s zoom: the entity's camera distance, or its living mount's when that is further.</summary>
    private static double CameraDistance(ClientEntity entity) {
        static float Scaled(ClientEntity entity) =>
            entity.IsLiving
                ? (float)entity.Attributes.Value(Minecraft.Data.Generated.Attribute.Scale) * (float)entity.Attributes.Value(Minecraft.Data.Generated.Attribute.CameraDistance)
                : 4.0F;
        float distance = Scaled(entity);
        return entity.Vehicle is { IsLiving: true } mount ? Math.Max(distance, Scaled(mount)) : distance;
    }

    /// <summary>
    /// The detached views: back along the look, or in front facing back, pulled in to the first block in
    /// the way so the camera never sits inside terrain.
    /// </summary>
    private static (Vec3d Position, float Yaw, float Pitch) ThirdPerson(ClientLevel level, Vec3d eye, float yaw, float pitch, bool front, double distance) {
        if (front) {
            yaw += 180.0F;
            pitch = -pitch;
        }
        System.Numerics.Vector3 look = Camera.Look(yaw, pitch);
        for (int corner = 0; corner < 8; corner++) {
            double ox = ((corner & 1) * 2 - 1) * 0.1, oy = ((corner >> 1 & 1) * 2 - 1) * 0.1, oz = ((corner >> 2 & 1) * 2 - 1) * 0.1;
            Vec3d from = eye.Add(ox, oy, oz);
            Vec3d to = from - new Vec3d(look.X, look.Y, look.Z) * distance;
            if (Picking.ClipBlocks(level, from, to) is BlockHitResult blocked) {
                distance = Math.Min(distance, Math.Sqrt(blocked.Location.DistanceToSqr(eye)));
            }
        }
        return (eye - new Vec3d(look.X, look.Y, look.Z) * distance, yaw, pitch);
    }

    /// <summary><c>GameRenderer.bobHurt</c>: the tilt away from a hit, and the roll as the entity dies.</summary>
    private static void BobHurt(ClientEntity entity, float partialTick, PoseStack pose) {
        if (!entity.IsLiving) {
            return;
        }
        if (entity.CurrentHealth <= 0) {
            float duration = Math.Min(entity.DeathTime + partialTick, 20.0F);
            pose.RotateZDegrees(40.0F - 8000.0F / (duration + 200.0F));
        }
        float hurt = entity.HurtTime - partialTick;
        if (hurt < 0.0F) {
            return;
        }
        // LivingEntity.hurtDuration, which only the totem's animation ever sets to anything else.
        hurt /= 10.0F;
        hurt = Mth.Sin(hurt * hurt * hurt * hurt * MathF.PI);
        // LivingEntity.getHurtDir, which only the local player's hurt animation packet moves off zero.
        float rr = entity is LocalPlayer player ? player.HurtDir : 0.0F;
        pose.RotateYDegrees(-rr);
        pose.RotateZDegrees(-hurt * 14.0F);
        pose.RotateYDegrees(rr);
    }

    /// <summary><c>GameRenderer.bobView</c>.</summary>
    private static void BobView(LocalPlayer player, float partialTick, PoseStack pose) {
        float walk = -(player.WalkDist + (player.WalkDist - player.WalkDistO) * partialTick);
        float bob = player.BobO + (player.Bob - player.BobO) * partialTick;
        pose.Translate(Mth.Sin(walk * MathF.PI) * bob * 0.5F, -Math.Abs(Mth.Cos(walk * MathF.PI) * bob), 0.0F);
        pose.RotateZDegrees(Mth.Sin(walk * MathF.PI) * bob * 3.0F);
        pose.RotateXDegrees(Math.Abs(Mth.Cos(walk * MathF.PI - 0.2F) * bob) * 5.0F);
    }
}

using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta;
using Direction = Minecraft.Schemas.Blocks.BlockEnums.Direction;

namespace GraphicalClient.Rendering.Entities;

/// <summary>What a renderer draws with.</summary>
public sealed class EntityRenderContext {
    public required MinecraftClient Client { get; init; }
    public required ClientLevel Level { get; init; }
    public required Camera Camera { get; init; }
    public required EntityBatch Batch { get; init; }

    /// <summary>For vanilla's translucent entity render types: drawn after the opaque world with alpha blending.</summary>
    public required EntityBatch TranslucentBatch { get; init; }
    public required float PartialTick { get; set; }

    /// <summary>Draws the fire round a burning entity; null leaves it out.</summary>
    public FlameFeatureRenderer? Flames { get; init; }

    /// <summary>For vanilla's <c>waterMask</c> render type, a boat's water patch: depth only, drawn before the translucent terrain.</summary>
    public EntityBatch? WaterMaskBatch { get; init; }

    /// <summary>For the render types that add their colour to what is behind them: energy swirls, lightning, the dragon's death rays.</summary>
    public EntityBatch? AdditiveBatch { get; init; }

    /// <summary>For <c>RenderTypes.lines</c>: a fishing line.</summary>
    public OverlayRenderer? Lines { get; init; }

    /// <summary><c>CameraType.isFirstPerson</c> for the camera option.</summary>
    public bool FirstPerson { get; init; }

    /// <summary>Where the round shadows on the ground under entities go; null leaves them out.</summary>
    public EntityShadows? Shadows { get; init; }

    /// <summary>Where text displays and name tags go; null leaves them out.</summary>
    public TextDisplayBatch? TextDisplays { get; init; }

    /// <summary><c>Hud.isHidden</c>, which hides most name tags with it.</summary>
    public bool HideGui { get; init; }

    public EntityTextures Textures => Batch.Textures;

    /// <summary>Where a glowing entity's silhouette goes, in its outline colour; null where nothing outlines.</summary>
    public EntityBatch? Outline => Batch.Outlines;

    /// <summary>The outline colour of the entity being drawn, 0 for none: what it draws into either batch is drawn again into <see cref="Outline"/> in it.</summary>
    public void SetOutlineColour(uint argb) {
        if (Batch.Outlines is { } outlines) {
            outlines.OutlineColour = argb;
        }
    }

    /// <summary>A texture by its identifier, the missing checks when the pack lacks it.</summary>
    public EntityTexture Texture(string identifier) => Textures.Get(identifier) ?? Textures.Missing;
}

/// <summary><c>EntityRenderState</c>: what a renderer needs of an entity this frame, so the model never reads the entity.</summary>
public class EntityRenderState {
    public ClientEntity Entity = null!;
    public Minecraft.Data.Entities.IEntityType EntityType = null!;
    public double X, Y, Z;
    public float AgeInTicks;
    public float BoundingBoxWidth, BoundingBoxHeight, EyeHeight;
    public bool IsInvisible;
    public bool IsDiscrete;
    public bool DisplayFireAnimation;
    public float SkyLight = 15, BlockLight = 15;

    /// <summary>The opaque team colour while the entity appears glowing, otherwise 0.</summary>
    public uint OutlineColour;

    public List<LeashState>? LeashStates;

    /// <summary><c>nameTag</c> and <c>scoreText</c>, null for none.</summary>
    public List<TextRun>? NameTag, ScoreText;

    /// <summary><c>nameTagAttachment</c>: where both hang, relative to the entity.</summary>
    public Vector3? NameTagAttachment;

    public double DistanceToCameraSq;

    public bool AppearsGlowing => OutlineColour != 0;
}

/// <summary><c>LivingEntityRenderState</c>.</summary>
public class LivingEntityRenderState : EntityRenderState {
    public float BodyRot, YRot, XRot;
    public float DeathTime;
    public float WalkAnimationPos, WalkAnimationSpeed;
    public float Scale = 1, AgeScale = 1;
    public bool IsUpsideDown, IsFullyFrozen, IsBaby, IsInWater, IsAutoSpinAttack, HasRedOverlay, IsInvisibleToPlayer;
    public float TicksSinceKineticHitFeedback;
    public EntityPose Pose = EntityPose.Standing;
    public Direction? BedOrientation;

    public bool HasPose(EntityPose pose) => Pose == pose;
}

/// <summary><c>Model</c> and <c>EntityModel</c>: a baked part tree that <see cref="SetupAnim"/> poses from a state.</summary>
public abstract class EntityModel<S> where S : EntityRenderState {
    protected readonly ModelPart Root;
    private readonly List<ModelPart> _allParts;

    protected EntityModel(ModelPart root) {
        Root = root;
        _allParts = root.AllParts();
    }

    public ModelPart RootPart => Root;

    /// <summary>Whether the model's own render type is translucent, as <c>entityTranslucent</c> is, so its body draws into the translucent batch.</summary>
    public virtual bool Translucent => false;

    public virtual void SetupAnim(S state) => ResetPose();

    public void ResetPose() {
        foreach (ModelPart part in _allParts) {
            part.ResetPose();
        }
    }

    public void RenderToBuffer(PoseStack pose, IModelSink sink, ModelDrawState draw) => Root.Render(pose, sink, draw);
}

/// <summary>The untyped face of a renderer, which the dispatcher holds.</summary>
public abstract class EntityRenderer {
    /// <summary>Called once a game tick for each entity it draws, for state vanilla keeps on the client's entity.</summary>
    public virtual void Tick(ClientEntity entity) { }

    /// <summary>The same tick, for a renderer whose bookkeeping reads the world.</summary>
    public virtual void Tick(ClientEntity entity, ClientLevel level) => Tick(entity);

    /// <summary><c>Entity.handleEntityEvent</c> for an entity it draws, as the packet arrives.</summary>
    public virtual void HandleEntityEvent(ClientEntity entity, byte eventId) { }

    /// <summary><c>Entity.shouldRenderAtSqrDistance</c> for a type that overrides it; null keeps <see cref="WithinViewDistance"/>.</summary>
    public virtual bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => null;

    /// <summary>
    /// <c>Entity.viewScale</c>, which <c>LevelExtractor</c> sets every frame from the render distance and the
    /// entity distance option.
    /// </summary>
    public static double ViewScale = 1.0;

    /// <summary>
    /// <c>Entity.shouldRenderAtSqrDistance</c>: 64 blocks for each block of the box's mean side, times
    /// <see cref="ViewScale"/>, which puts a dropped item at 16 blocks and a ghast at 260 at the least. A remote
    /// player and an arrow scale the side by 10 first.
    /// </summary>
    public static bool WithinViewDistance(ClientEntity entity, double distanceSqr, double sideScale = 1.0) {
        double size = BoxSize(entity) * sideScale;
        size *= 64.0 * ViewScale;
        return distanceSqr < size * size;
    }

    /// <summary><c>AABB.getSize</c> of the entity's box: its mean side.</summary>
    public static double BoxSize(ClientEntity entity) {
        Minecraft.Physics.Box box = entity.BoundingBox;
        return (box.MaxX - box.MinX + box.MaxY - box.MinY + box.MaxZ - box.MinZ) / 3.0;
    }

    /// <summary><c>EntityRenderer.affectedByCulling</c>: false skips the frustum test.</summary>
    public virtual bool AffectedByCulling(ClientEntity entity) => true;

    /// <summary>
    /// <c>getBoundingBoxForCulling</c> relative to the entity's position, before the half block
    /// <c>shouldRender</c> inflates it by; null for the type's own box.
    /// </summary>
    public virtual (Vector3 Min, Vector3 Max)? BoundingBoxForCulling(ClientEntity entity) => null;

    /// <summary>The rest of <c>shouldRender</c> for an entity whose box is out of view: whether what it draws past its box is not.</summary>
    public virtual bool ShouldRenderOutOfView(ClientEntity entity, Frustum frustum, EntityRenderContext context) => false;

    /// <summary>Extracts and submits at once, where the entity stands this frame.</summary>
    public void Render(ClientEntity entity, EntityRenderContext context) {
        EntityRenderState state = Extract(entity, context.PartialTick, context);
        Vec3d camera = context.Camera.Position;
        Submit(state, state.X - camera.X, state.Y - camera.Y, state.Z - camera.Z, context);
        if (context.Shadows != null) {
            SubmitShadow(state, context.Shadows, camera);
        }
    }

    /// <summary><c>extractShadow</c> and the dispatcher's <c>submitShadow</c>: where the shadow falls is left to the shader pack.</summary>
    protected internal abstract void SubmitShadow(EntityRenderState state, EntityShadows shadows, Vec3d camera);

    /// <summary><c>EntityRenderDispatcher.extractEntity</c>: a state taken now, to be drawn by <see cref="Submit(EntityRenderState, double, double, double, PoseStack, EntityRenderContext)"/> later.</summary>
    public abstract EntityRenderState Extract(ClientEntity entity, float partialTick, EntityRenderContext context);

    public void Submit(EntityRenderState state, double x, double y, double z, EntityRenderContext context) {
        PoseStack pose = PoseStack.Rent();
        Submit(state, x, y, z, pose, context);
        PoseStack.Return(pose);
    }

    /// <summary><c>EntityRenderDispatcher.submit</c>: draws an extracted state at an offset from the camera, into a pose the caller may have set up.</summary>
    public abstract void Submit(EntityRenderState state, double x, double y, double z, PoseStack pose, EntityRenderContext context);

    /// <summary><c>Entity.isSpectator</c>: a player in spectator mode, by the player list for anyone but the local player.</summary>
    public static bool IsSpectator(ClientEntity entity, MinecraftClient client) {
        if (entity is ClientLib.Player.LocalPlayer local) {
            return local.IsSpectator;
        }
        return client.PlayerInfoOf(entity)?.GameMode == Minecraft.Schemas.GameMode.Spectator;
    }

    /// <summary>
    /// <c>Minecraft.shouldEntityAppearGlowing</c>. The spectator outlines key is unbound by default, as it is
    /// in vanilla, so it only shows players while a binding holds it.
    /// </summary>
    public static bool AppearsGlowing(ClientEntity entity, MinecraftClient client) =>
        entity.IsCurrentlyGlowing || client.Player is { IsSpectator: true } && entity.Is(EntityClass.Player)
        && Assets.ResourcePacks.ItemModelQuery.KeyMappingDown("key.spectatorOutlines") == true;

    /// <summary>The outline colour <c>EntityRenderer.extractRenderState</c> takes: <c>ARGB.opaque(getTeamColor())</c> while glowing.</summary>
    public static uint OutlineColourOf(ClientEntity entity, MinecraftClient client) =>
        AppearsGlowing(entity, client) ? 0xFF000000 | (uint)client.TeamColour(entity) : 0;

    /// <summary><c>Entity.displayFireAnimation</c>, with <c>FallingBlockEntity</c>'s override that never shows it.</summary>
    public static bool DisplayFireAnimation(ClientEntity entity, MinecraftClient client) =>
        !entity.Is(EntityClass.FallingBlockEntity) && entity.IsOnFire && !IsSpectator(entity, client);

    /// <summary><c>Entity.getXRot(partialTick)</c>.</summary>
    public static float GetXRot(ClientEntity entity, float partialTick) => partialTick == 1.0F ? entity.XRot : Mth.Lerp(partialTick, entity.XRotO, entity.XRot);

    /// <summary><c>Entity.getYRot(partialTick)</c>.</summary>
    public static float GetYRot(ClientEntity entity, float partialTick) => partialTick == 1.0F ? entity.YRot : Mth.RotLerp(partialTick, entity.YRotO, entity.YRot);
}

/// <summary><c>EntityRenderer</c>.</summary>
public abstract class EntityRenderer<S> : EntityRenderer where S : EntityRenderState, new() {
    public float ShadowRadius;
    public float ShadowStrength = 1.0F;

    protected virtual float GetShadowRadius(S state) => ShadowRadius;

    protected virtual float GetShadowStrength(S state) => ShadowStrength;

    protected internal override void SubmitShadow(EntityRenderState state, EntityShadows shadows, Vec3d camera) {
        if (state.IsInvisible) {
            return;
        }
        S typed = (S)state;
        float radius = Math.Min(GetShadowRadius(typed), 32.0F);
        if (radius <= 0.0F) {
            return;
        }
        double x = state.X - camera.X, y = state.Y - camera.Y, z = state.Z - camera.Z;
        float power = (float)((1.0 - (x * x + y * y + z * z) / 256.0) * GetShadowStrength(typed));
        if (power <= 0.0F) {
            return;
        }
        // The dispatcher submits a player's shadow after taking its render offset back off, anything else's before.
        Vector3 offset = state is Vanilla.AvatarRenderState ? Vector3.Zero : GetRenderOffset(typed);
        shadows.Add(state.X + offset.X, state.Y + offset.Y, state.Z + offset.Z, camera, radius, power);
    }

    public override EntityRenderState Extract(ClientEntity entity, float partialTick, EntityRenderContext context) {
        S state = RenderStateFor(entity);
        ExtractRenderState(entity, state, partialTick, context);
        return state;
    }

    /// <summary>The state <see cref="Extract"/> fills: a new one, unless a renderer keeps one per entity to fill again each frame.</summary>
    protected virtual S RenderStateFor(ClientEntity entity) => CreateRenderState();

    public override void Submit(EntityRenderState state, double x, double y, double z, PoseStack pose, EntityRenderContext context) {
        Vector3 offset = GetRenderOffset((S)state);
        pose.Push();
        pose.Translate((float)(x + offset.X), (float)(y + offset.Y), (float)(z + offset.Z));
        pose.Push();
        context.SetOutlineColour(state.OutlineColour);
        Submit((S)state, pose, context);
        context.SetOutlineColour(0);
        pose.Pop();
        if (state.LeashStates != null) {
            foreach (LeashState leash in state.LeashStates) {
                LeashFeatureRenderer.Submit(pose, leash, context.Batch);
            }
        }
        if (state.DisplayFireAnimation) {
            context.Flames?.Submit(pose, state.BoundingBoxWidth, state.BoundingBoxHeight, state.SkyLight, context.Camera, context.Batch);
        }
        NameTags.Submit(state, pose, context);
        pose.Pop();
    }

    /// <summary><c>getRenderOffset</c>: where the pose moves from the entity's position, for the model and the flame alike.</summary>
    public virtual Vector3 GetRenderOffset(S state) => Vector3.Zero;

    public virtual S CreateRenderState() => new();

    public virtual void ExtractRenderState(ClientEntity entity, S state, float partialTick, EntityRenderContext context) {
        state.Entity = entity;
        state.EntityType = entity.Type;
        state.X = ClientEntity.Lerp(partialTick, entity.OldPosition.X, entity.Position.X);
        state.Y = ClientEntity.Lerp(partialTick, entity.OldPosition.Y, entity.Position.Y);
        state.Z = ClientEntity.Lerp(partialTick, entity.OldPosition.Z, entity.Position.Z);
        state.IsInvisible = entity.IsInvisible;
        state.AgeInTicks = entity.TickCount + partialTick;
        state.BoundingBoxWidth = (float)entity.Width;
        state.BoundingBoxHeight = (float)entity.Height;
        state.EyeHeight = (float)entity.EyeHeight;
        state.IsDiscrete = entity.IsCrouching;
        state.DisplayFireAnimation = DisplayFireAnimation(entity, context.Client);
        state.OutlineColour = OutlineColourOf(entity, context.Client);
        state.LeashStates = LeashFeatureRenderer.Extract(entity, partialTick, context.Client, context.Level, state.LeashStates);
        // getPackedLightCoords: the light where the entity's eyes are, full block light while burning.
        int bx = (int)Math.Floor(state.X), by = (int)Math.Floor(state.Y + state.EyeHeight), bz = (int)Math.Floor(state.Z);
        state.SkyLight = context.Level.GetSkyLight(bx, by, bz);
        state.BlockLight = entity.IsOnFire ? 15 : context.Level.GetBlockLight(bx, by, bz);
        NameTags.Extract(entity, state, partialTick, context, NameTagRule);
    }

    /// <summary>Whose <c>shouldShowName</c> this renderer has.</summary>
    protected virtual NameTagRule NameTagRule => NameTagRule.Entity;

    public abstract void Submit(S state, PoseStack pose, EntityRenderContext context);
}

/// <summary><c>RenderLayer</c>: something drawn over a living entity's model, sharing its pose.</summary>
public abstract class RenderLayer<S, M> where S : LivingEntityRenderState, new() where M : EntityModel<S> {
    protected readonly LivingEntityRenderer<S, M> Parent;

    protected RenderLayer(LivingEntityRenderer<S, M> parent) {
        Parent = parent;
    }

    public abstract void Submit(PoseStack pose, EntityRenderContext context, S state);

    /// <summary><c>RenderLayer.coloredCutoutModelCopyLayerRender</c>: another model posed like the parent's, with its own texture.</summary>
    protected static void RenderColoredCutoutModel<OM>(OM model, string texture, PoseStack pose, EntityRenderContext context, S state, uint argb)
        where OM : EntityModel<S> {
        if (state.IsInvisible) {
            return;
        }
        model.SetupAnim(state);
        if (context.Textures.Get(texture) is { } resolved) {
            model.RenderToBuffer(pose, context.Batch, new ModelDrawState(resolved, argb, state.SkyLight, state.BlockLight, state.HasRedOverlay ? 1 : 0));
        }
    }
}

/// <summary><c>LivingEntityRenderer</c>.</summary>
public abstract class LivingEntityRenderer<S, M> : EntityRenderer<S> where S : LivingEntityRenderState, new() where M : EntityModel<S> {
    protected M Model;
    protected readonly List<RenderLayer<S, M>> Layers = [];

    protected LivingEntityRenderer(M model, float shadowRadius) {
        Model = model;
        ShadowRadius = shadowRadius;
    }

    public M CurrentModel => Model;

    protected override float GetShadowRadius(S state) => base.GetShadowRadius(state) * state.Scale;

    protected void AddLayer(RenderLayer<S, M> layer) => Layers.Add(layer);

    /// <summary>The texture identifier, as vanilla names it: <c>minecraft:textures/entity/creeper/creeper.png</c>.</summary>
    public abstract string GetTextureLocation(S state);

    public override void ExtractRenderState(ClientEntity entity, S state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        float headRot = Mth.RotLerp(partialTick, entity.YHeadRotO, entity.YHeadRot);
        state.BodyRot = SolveBodyRot(entity, headRot, partialTick);
        state.YRot = Mth.WrapDegrees(headRot - state.BodyRot);
        state.XRot = Mth.Lerp(partialTick, entity.XRotO, entity.XRot);
        state.IsUpsideDown = IsEntityUpsideDown(entity);
        if (state.IsUpsideDown) {
            state.XRot *= -1;
            state.YRot *= -1;
        }
        bool alive = entity.CurrentHealth > 0;
        if (entity.VehicleId == null && alive) {
            state.WalkAnimationPos = entity.WalkAnimationPosition(partialTick);
            state.WalkAnimationSpeed = Math.Min(Mth.Lerp(partialTick, entity.WalkSpeedOld, entity.WalkSpeed), 1.0F);
        }
        else {
            state.WalkAnimationPos = 0;
            state.WalkAnimationSpeed = 0;
        }
        float scale = (float)entity.Attributes.Value(Minecraft.Data.Generated.Attribute.Scale);
        state.Scale = scale > 0 ? scale : 1;
        state.IsBaby = entity.IsBaby;
        state.AgeScale = state.IsBaby ? 0.5F : 1.0F;
        state.Pose = entity.Get(EntityDataFields.Entity.Pose, EntityPose.Standing);
        state.BedOrientation = entity.BedOrientation(context.Level);
        if (state.BedOrientation != null) {
            // getEyeHeight(Pose.STANDING): the type's eye height scaled as its standing dimensions are.
            state.EyeHeight = (float)entity.EyeHeight * state.AgeScale * state.Scale;
        }
        state.IsFullyFrozen = entity.IsFullyFrozen;
        state.HasRedOverlay = entity.HurtTime > 0 || entity.DeathTime > 0;
        state.DeathTime = entity.DeathTime > 0 ? entity.DeathTime + partialTick : 0;
        state.IsInvisibleToPlayer = state.IsInvisible;
        state.TicksSinceKineticHitFeedback = entity.TicksSinceLastKineticHitFeedback(context.Level.GameTime, partialTick);
    }

    /// <summary><c>isEntityUpsideDown</c>: named Dinnerbone or Grumm.</summary>
    protected virtual bool IsEntityUpsideDown(ClientEntity entity) => entity.CustomName is "Dinnerbone" or "Grumm";

    protected override NameTagRule NameTagRule => NameTagRule.Living;

    /// <summary><c>LivingEntityRenderer.solveBodyRot</c>: a rider's body follows its mount's, within 85 degrees of its head.</summary>
    private static float SolveBodyRot(ClientEntity entity, float headRot, float partialTick) {
        if (entity.Vehicle is not { IsLiving: true } riding) {
            return Mth.RotLerp(partialTick, entity.YBodyRotO, entity.YBodyRot);
        }
        float bodyRot = Mth.RotLerp(partialTick, riding.YBodyRotO, riding.YBodyRot);
        float headDiff = Mth.Clamp(Mth.WrapDegrees(headRot - bodyRot), -85.0F, 85.0F);
        bodyRot = headRot - headDiff;
        if (Math.Abs(headDiff) > 50.0F) {
            bodyRot += headDiff * 0.2F;
        }
        return bodyRot;
    }

    public override void Submit(S state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        if (state.HasPose(EntityPose.Sleeping) && state.BedOrientation is { } bedOrientation) {
            float headOffset = state.EyeHeight - 0.1F;
            (int stepX, int stepZ) = StepOf(bedOrientation);
            pose.Translate(-stepX * headOffset, 0.0F, -stepZ * headOffset);
        }
        float scale = state.Scale;
        pose.Scale(scale, scale, scale);
        SetupRotations(state, pose, state.BodyRot, scale);
        pose.Scale(-1, -1, 1);
        Scale(state, pose);
        pose.Translate(0, -1.501F, 0);
        bool bodyVisible = IsBodyVisible(state);
        Model.SetupAnim(state);
        if (bodyVisible) {
            uint tint = MultiplyArgb(0xFFFFFFFF, GetModelTint(state));
            Model.RenderToBuffer(pose, Model.Translucent ? context.TranslucentBatch : context.Batch, new ModelDrawState(context.Texture(GetTextureLocation(state)), tint,
                state.SkyLight, state.BlockLight, state.HasRedOverlay ? 1 : 0, GetWhiteOverlayProgress(state)) { NoOutline = !BodyAffectsOutline(state) });
        }
        else if (state.AppearsGlowing && BodyAffectsOutline(state) && context.Outline is { } outline) {
            // RenderTypes.outline: the silhouette alone.
            Model.RenderToBuffer(pose, outline, new ModelDrawState(context.Texture(GetTextureLocation(state)), 0xFFFFFFFF, 15, 15, 0));
        }
        foreach (RenderLayer<S, M> layer in Layers) {
            layer.Submit(pose, context, state);
        }
        pose.Pop();
    }

    protected virtual void SetupRotations(S state, PoseStack pose, float bodyRot, float entityScale) {
        if (IsShaking(state)) {
            bodyRot += (float)(Math.Cos(Mth.Floor(state.AgeInTicks) * 3.25F) * Math.PI * 0.4F);
        }
        if (!state.HasPose(EntityPose.Sleeping)) {
            pose.RotateYDegrees(180.0F - bodyRot);
        }
        if (state.DeathTime > 0) {
            float fall = (state.DeathTime - 1.0F) / 20.0F * 1.6F;
            fall = Mth.Sqrt(fall);
            if (fall > 1) {
                fall = 1;
            }
            pose.RotateZDegrees(fall * GetFlipDegrees());
        }
        else if (state.IsAutoSpinAttack) {
            pose.RotateXDegrees(-90.0F - state.XRot);
            pose.RotateYDegrees(state.AgeInTicks * -75.0F);
        }
        else if (state.HasPose(EntityPose.Sleeping)) {
            float angle = state.BedOrientation is { } bedOrientation ? SleepDirectionToRotation(bedOrientation) : bodyRot;
            pose.RotateYDegrees(angle);
            pose.RotateZDegrees(GetFlipDegrees());
            pose.RotateYDegrees(270.0F);
        }
        else if (state.IsUpsideDown) {
            pose.Translate(0, (state.BoundingBoxHeight + 0.1F) / entityScale, 0);
            pose.RotateZDegrees(180.0F);
        }
    }

    private static float SleepDirectionToRotation(Direction direction) => direction switch {
        Direction.South => 90.0F,
        Direction.West => 0.0F,
        Direction.North => 270.0F,
        Direction.East => 180.0F,
        _ => 0.0F
    };

    /// <summary><c>Direction.getStepX</c> and <c>getStepZ</c>.</summary>
    private static (int X, int Z) StepOf(Direction direction) => direction switch {
        Direction.North => (0, -1),
        Direction.South => (0, 1),
        Direction.West => (-1, 0),
        _ => (1, 0)
    };

    /// <summary><c>isBodyVisible</c>.</summary>
    protected virtual bool IsBodyVisible(S state) => !state.IsInvisible;

    /// <summary>Whether the render type <c>getRenderType</c> picks for the body has an outline.</summary>
    protected virtual bool BodyAffectsOutline(S state) => true;

    protected virtual bool IsShaking(S state) => state.IsFullyFrozen;
    protected virtual float GetFlipDegrees() => 90.0F;
    protected virtual void Scale(S state, PoseStack pose) { }
    protected virtual float GetWhiteOverlayProgress(S state) => 0;
    protected virtual uint GetModelTint(S state) => 0xFFFFFFFF;

    protected static uint MultiplyArgb(uint a, uint b) => Argb.Multiply(a, b);
}

/// <summary><c>MobRenderer</c>.</summary>
public abstract class MobRenderer<S, M> : LivingEntityRenderer<S, M> where S : LivingEntityRenderState, new() where M : EntityModel<S> {
    protected MobRenderer(M model, float shadowRadius) : base(model, shadowRadius) { }

    protected override NameTagRule NameTagRule => NameTagRule.Mob;

    protected override float GetShadowRadius(S state) => base.GetShadowRadius(state) * state.AgeScale;
}

/// <summary><c>AgeableMobRenderer</c>: an adult and a baby model, chosen per frame.</summary>
public abstract class AgeableMobRenderer<S, M> : MobRenderer<S, M> where S : LivingEntityRenderState, new() where M : EntityModel<S> {
    private readonly M _adult, _baby;

    protected AgeableMobRenderer(M adult, M baby, float shadowRadius) : base(adult, shadowRadius) {
        _adult = adult;
        _baby = baby;
    }

    public override void Submit(S state, PoseStack pose, EntityRenderContext context) {
        Model = state.IsBaby ? _baby : _adult;
        base.Submit(state, pose, context);
    }
}

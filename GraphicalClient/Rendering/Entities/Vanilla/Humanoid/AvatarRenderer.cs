using ClientLib;
using GraphicalClient.Assets.Skins;
using Minecraft.Data.Components.Types;
using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using ConsumeAnimation = Minecraft.Data.Components.Types.ConsumableComponent.ConsumeAnimation;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>AvatarRenderState</c>. The arrows and stingers stuck in it, the shoulder parrots and the extra ears are
/// left out with the layers that read them.
/// </summary>
public class AvatarRenderState : HumanoidRenderState {
    public PlayerSkin Skin = DefaultPlayerSkin.GetDefaultSkin();
    public bool IsSpectator;
    public bool ShowHat = true;
    public bool ShowJacket = true;
    public bool ShowLeftPants = true;
    public bool ShowRightPants = true;
    public bool ShowLeftSleeve = true;
    public bool ShowRightSleeve = true;
    public bool ShowCape = true;
    public float CapeFlap, CapeLean, CapeLean2;
    public float FallFlyingTimeInTicks;
    public bool ShouldApplyFlyingYRot;
    public float FlyingYRot;
    public int Id;
    public ItemStackModel? HeldOnHead;

    public float FallFlyingScale() => Mth.Clamp(FallFlyingTimeInTicks * FallFlyingTimeInTicks / 100.0F, 0.0F, 1.0F);
}

/// <summary>
/// What <c>Avatar</c> and <c>ClientAvatarState</c> keep on the client beyond a humanoid's: <c>fallFlyTicks</c>,
/// <c>deltaMovementOnPreviousTick</c>, the cloak trailing the body, and another player's bob. The local
/// player's bob and walk distance are its own.
/// </summary>
public sealed class AvatarEntityData : HumanoidEntityData {
    public int FallFlyTicks;
    public Vec3d DeltaMovementOnPreviousTick = Vec3d.Zero;
    public Vec3d Cloak, CloakO;
    public float Bob, BobO;

    public override void Tick(ClientEntity entity) {
        base.Tick(entity);
        FallFlyTicks = IsFallFlying(entity) ? FallFlyTicks + 1 : 0;
        DeltaMovementOnPreviousTick = entity.DeltaMovement;
        // A player's ClientAvatarState ticks before it moves, a mannequin's after.
        MoveCloak(entity.Is(EntityClass.Player) ? entity.OldPosition : entity.Position);
        if (entity.Is(EntityClass.Player) && entity is not LocalPlayer) {
            // AbstractClientPlayer.updateBob from aiStep, then resetBob from rideTick. Swimming is bit 4 of the shared flags.
            float tBob = entity.OnGround && entity.CurrentHealth > 0 && (entity.SharedFlags & 0x10) == 0
                ? Math.Min(0.1F, (float)Math.Sqrt(entity.DeltaMovement.HorizontalDistanceSqr()))
                : 0.0F;
            BobO = Bob;
            Bob += (tBob - Bob) * 0.4F;
            if (entity.Vehicle != null) {
                BobO = Bob;
                Bob = 0.0F;
            }
        }
    }

    /// <summary><c>moveCloak</c>: a quarter of the way to the position each tick, jumping there from over 10 blocks off.</summary>
    private void MoveCloak(Vec3d position) {
        (double x, double xo) = Follow(Cloak.X, Cloak.X, position.X);
        (double y, double yo) = Follow(Cloak.Y, Cloak.Y, position.Y);
        (double z, double zo) = Follow(Cloak.Z, Cloak.Z, position.Z);
        Cloak = new Vec3d(x, y, z);
        CloakO = new Vec3d(xo, yo, zo);
    }

    private static (double Value, double Old) Follow(double cloak, double old, double target) {
        double d = target - cloak;
        return d is > 10.0 or < -10.0 ? (target, target) : (cloak + d * 0.25, old);
    }
}

/// <summary>
/// <c>AvatarRenderer</c>, for players and mannequins. Left out with the state they read: the
/// <c>ArrowLayer</c> and <c>BeeStingerLayer</c> (stuck arrows and stingers), <c>Deadmau5EarsLayer</c>,
/// <c>ParrotOnShoulderLayer</c>, and <c>SpinAttackEffectLayer</c> (a scrolling translucent texture).
/// </summary>
public sealed class AvatarRenderer : LivingEntityRenderer<AvatarRenderState, PlayerModel> {
    private readonly ItemRenderer _items;
    private EntityRenderContext? _context;

    public AvatarRenderer(EntityRendererContext context, bool slimSteve)
        : base(new PlayerModel(LayerDefinition.Create(PlayerModel.CreateMesh(CubeDeformation.None, slimSteve), 64, 64).BakeRoot(), slimSteve), 0.5F) {
        _items = context.Items;
        EquipmentLayerRenderer equipmentRenderer = EquipmentLayerRenderer.For(context);
        AddLayer(new UnlessSpectator(this, new HumanoidArmorLayer<AvatarRenderState, PlayerModel, PlayerModel>(this,
            ArmorModelSet.Bake(HumanoidLayers.PlayerArmor(), part => new PlayerModel(part, slimSteve)), equipmentRenderer)));
        AddLayer(new UnlessSpectator(this, new PlayerItemInHandLayer<AvatarRenderState, PlayerModel>(this, context.Items)));
        AddLayer(new UnlessSpectator(this, new CapeLayer(this, equipmentRenderer)));
        AddLayer(new UnlessSpectator(this, new CustomHeadLayer<AvatarRenderState, PlayerModel>(this, context.Items)));
        AddLayer(new UnlessSpectator(this, new WingsLayer<AvatarRenderState, PlayerModel>(this, equipmentRenderer)));
    }

    /// <summary><c>shouldRenderLayers</c>: a spectator draws none, which this wrapper stands in for on each layer.</summary>
    private sealed class UnlessSpectator(LivingEntityRenderer<AvatarRenderState, PlayerModel> parent, RenderLayer<AvatarRenderState, PlayerModel> layer)
        : RenderLayer<AvatarRenderState, PlayerModel>(parent) {
        public override void Submit(PoseStack pose, EntityRenderContext context, AvatarRenderState state) {
            if (!state.IsSpectator) {
                layer.Submit(pose, context, state);
            }
        }
    }

    public override void Tick(ClientEntity entity) => HumanoidEntityData.TickFor<AvatarEntityData>(entity);

    public override System.Numerics.Vector3 GetRenderOffset(AvatarRenderState state) =>
        state.IsCrouching ? new System.Numerics.Vector3(0.0F, state.Scale * -2.0F / 16.0F, 0.0F) : System.Numerics.Vector3.Zero;

    private static ArmPose GetArmPose(ClientEntity avatar, HumanoidArm arm, EntityRenderContext context) {
        ItemStack mainHandItem = avatar.ItemInHand(Hand.MainHand);
        ItemStack offHandItem = avatar.ItemInHand(Hand.OffHand);
        ArmPose mainHandPose = GetArmPose(avatar, mainHandItem, Hand.MainHand, context);
        ArmPose offHandPose = GetArmPose(avatar, offHandItem, Hand.OffHand, context);
        if (mainHandPose.IsTwoHanded()) {
            offHandPose = offHandItem.IsAir() ? ArmPose.Empty : ArmPose.Item;
        }
        return ArmedEntityRenderState.MainArmOf(avatar) == arm ? mainHandPose : offHandPose;
    }

    private static ArmPose GetArmPose(ClientEntity avatar, ItemStack itemInHand, Hand hand, EntityRenderContext context) {
        if (itemInHand.IsAir()) {
            return ArmPose.Empty;
        }
        if (!avatar.Swinging && itemInHand.Is(Item.Crossbow) && IsCharged(itemInHand)) {
            return ArmPose.CrossbowHold;
        }
        // getUseItemRemainingTicks() > 0: the remaining ticks run out only after the item's use
        // duration, which is not known here, so any use in progress counts.
        bool using_ = HumanoidEntityData.UsedItemHand(avatar) == hand && HumanoidEntityData.IsUsingItem(avatar);
        ArmPose? usePose = !using_ ? null : ItemInHandRenderer.UseAnimation(itemInHand) switch {
            ConsumeAnimation.Block => ArmPose.Block,
            ConsumeAnimation.Bow => ArmPose.BowAndArrow,
            ConsumeAnimation.Trident => ArmPose.ThrowTrident,
            ConsumeAnimation.Crossbow => ArmPose.CrossbowCharge,
            ConsumeAnimation.Spyglass => ArmPose.Spyglass,
            ConsumeAnimation.TootHorn => ArmPose.TootHorn,
            ConsumeAnimation.Brush => ArmPose.Brush,
            ConsumeAnimation.Spear => ArmPose.Spear,
            _ => null
        };
        if (usePose is { } pose) {
            return pose;
        }
        if (HumanoidMobRenderer.IsStab(itemInHand) && avatar.Swinging) {
            return ArmPose.Spear;
        }
        return HumanoidEntityData.IsSpear(itemInHand, context) ? ArmPose.Spear : ArmPose.Item;
    }

    /// <summary><c>CrossbowItem.isCharged</c>.</summary>
    private static bool IsCharged(ItemStack stack) => stack.Has(DataComponent.ChargedProjectiles) && stack.Get(DataComponent.ChargedProjectiles).Length > 0;

    public override string GetTextureLocation(AvatarRenderState state) => state.Skin.Body;

    protected override void Scale(AvatarRenderState state, PoseStack pose) => pose.Scale(0.9375F, 0.9375F, 0.9375F);

    /// <summary>
    /// <c>getSkin</c>: a player's through its player info, and a mannequin's for its synced profile, else
    /// <c>ClientMannequin.DEFAULT_SKIN</c>. A mannequin whose profile changes shows that default while the new
    /// skin loads, where vanilla keeps the old one.
    /// </summary>
    public static PlayerSkin SkinOf(ClientEntity entity) {
        if (entity.Is(EntityClass.Player)) {
            return SkinManager.ForPlayer(entity.Uuid);
        }
        return entity.Get(EntityDataFields.Mannequin.Profile) is ProfileComponent.Data profile
            ? SkinManager.Lookup(profile) ?? DefaultPlayerSkin.Get(Guid.Empty)
            : DefaultPlayerSkin.Get(Guid.Empty);
    }

    /// <summary><c>Avatar.isModelPartShown</c>, with <c>PlayerModelPart</c>'s bit.</summary>
    public static bool IsModelPartShown(ClientEntity entity, int bit) =>
        (entity.Get(EntityDataFields.Avatar.PlayerModeCustomisation) & (1 << bit)) == 1 << bit;

    private const int CapeBit = 0, JacketBit = 1, LeftSleeveBit = 2, RightSleeveBit = 3, LeftPantsBit = 4, RightPantsBit = 5, HatBit = 6;

    public override void ExtractRenderState(ClientEntity entity, AvatarRenderState state, float partialTick, EntityRenderContext context) {
        _context = context;
        base.ExtractRenderState(entity, state, partialTick, context);
        state.Pose = HumanoidEntityData.PoseOf(entity);
        state.IsAutoSpinAttack = HumanoidEntityData.IsAutoSpinAttack(entity);
        state.IsInWater = entity is LocalPlayer local ? local.IsInWater : EntityWater.IsInWater(context.Level, entity);
        HumanoidMobRenderer.ExtractHumanoidRenderState(entity, state, partialTick, _items, context);
        state.LeftArmPose = GetArmPose(entity, HumanoidArm.Left, context);
        state.RightArmPose = GetArmPose(entity, HumanoidArm.Right, context);
        state.Skin = SkinOf(entity);
        state.IsSpectator = IsSpectator(entity, context.Client);
        state.ShowHat = IsModelPartShown(entity, HatBit);
        state.ShowJacket = IsModelPartShown(entity, JacketBit);
        state.ShowLeftPants = IsModelPartShown(entity, LeftPantsBit);
        state.ShowRightPants = IsModelPartShown(entity, RightPantsBit);
        state.ShowLeftSleeve = IsModelPartShown(entity, LeftSleeveBit);
        state.ShowRightSleeve = IsModelPartShown(entity, RightSleeveBit);
        state.ShowCape = IsModelPartShown(entity, CapeBit);
        ExtractFlightData(entity, state, partialTick);
        ExtractCapeState(entity, state, partialTick);
        state.Id = entity.Id;
        state.HeldOnHead = null;
        if (state.IsUsingItem) {
            ItemStack useItem = entity.ItemInHand(state.UseItemHand);
            if (useItem.Is(Item.Spyglass)) {
                state.HeldOnHead = _items.Resolve(useItem, ItemDisplayContext.Head, entity);
            }
        }
    }

    private static void ExtractFlightData(ClientEntity entity, AvatarRenderState state, float partialTick) {
        AvatarEntityData data = entity.RendererData as AvatarEntityData ?? new AvatarEntityData();
        state.FallFlyingTimeInTicks = data.FallFlyTicks + partialTick;
        Vec3d lookAngle = ViewVector(Mth.Lerp(partialTick, entity.XRotO, entity.XRot), Mth.RotLerp(partialTick, entity.YHeadRotO, entity.YHeadRot));
        Vec3d previous = data.DeltaMovementOnPreviousTick, current = entity.DeltaMovement;
        Vec3d movement = new(previous.X + (current.X - previous.X) * partialTick, previous.Y + (current.Y - previous.Y) * partialTick,
            previous.Z + (current.Z - previous.Z) * partialTick);
        if (movement.HorizontalDistanceSqr() > 1.0E-5F && lookAngle.HorizontalDistanceSqr() > 1.0E-5F) {
            state.ShouldApplyFlyingYRot = true;
            Vec3d movementFlat = new Vec3d(movement.X, 0.0, movement.Z).Normalize();
            Vec3d lookFlat = new Vec3d(lookAngle.X, 0.0, lookAngle.Z).Normalize();
            double dot = movementFlat.X * lookFlat.X + movementFlat.Y * lookFlat.Y + movementFlat.Z * lookFlat.Z;
            double sign = movement.X * lookAngle.Z - movement.Z * lookAngle.X;
            state.FlyingYRot = (float)(Math.Sign(sign) * Math.Acos(Math.Min(1.0, Math.Abs(dot))));
        }
        else {
            state.ShouldApplyFlyingYRot = false;
            state.FlyingYRot = 0.0F;
        }
    }

    private static void ExtractCapeState(ClientEntity entity, AvatarRenderState state, float partialTick) {
        AvatarEntityData data = entity.RendererData as AvatarEntityData ?? new AvatarEntityData();
        double deltaX = Mth.Lerp(partialTick, data.CloakO.X, data.Cloak.X) - Mth.Lerp(partialTick, entity.OldPosition.X, entity.Position.X);
        double deltaY = Mth.Lerp(partialTick, data.CloakO.Y, data.Cloak.Y) - Mth.Lerp(partialTick, entity.OldPosition.Y, entity.Position.Y);
        double deltaZ = Mth.Lerp(partialTick, data.CloakO.Z, data.Cloak.Z) - Mth.Lerp(partialTick, entity.OldPosition.Z, entity.Position.Z);
        float yBodyRot = Mth.RotLerp(partialTick, entity.YBodyRotO, entity.YBodyRot);
        double forwardX = Mth.Sin(yBodyRot * (float)(Math.PI / 180.0));
        double forwardZ = -Mth.Cos(yBodyRot * (float)(Math.PI / 180.0));
        state.CapeFlap = (float)deltaY * 10.0F;
        state.CapeFlap = Mth.Clamp(state.CapeFlap, -6.0F, 32.0F);
        state.CapeLean = (float)(deltaX * forwardX + deltaZ * forwardZ) * 100.0F;
        state.CapeLean = state.CapeLean * (1.0F - state.FallFlyingScale());
        state.CapeLean = Mth.Clamp(state.CapeLean, 0.0F, 150.0F);
        state.CapeLean2 = (float)(deltaX * forwardZ - deltaZ * forwardX) * 100.0F;
        state.CapeLean2 = Mth.Clamp(state.CapeLean2, -20.0F, 20.0F);
        (float pow, float walkDistance) = entity is LocalPlayer local
            ? (Mth.Lerp(partialTick, local.BobO, local.Bob), Mth.Lerp(partialTick, local.WalkDistO, local.WalkDist))
            : (Mth.Lerp(partialTick, data.BobO, data.Bob), 0.0F);
        state.CapeFlap = state.CapeFlap + Mth.Sin(walkDistance * 6.0F) * 32.0F * pow;
    }

    /// <summary><c>Entity.calculateViewVector</c>.</summary>
    private static Vec3d ViewVector(float xRot, float yRot) {
        float realXRot = xRot * (float)(Math.PI / 180.0);
        float realYRot = -yRot * (float)(Math.PI / 180.0);
        float yCos = Mth.Cos(realYRot);
        float ySin = Mth.Sin(realYRot);
        float xCos = Mth.Cos(realXRot);
        float xSin = Mth.Sin(realXRot);
        return new Vec3d(ySin * xCos, -xSin, yCos * xCos);
    }

    /// <summary>
    /// <c>renderRightHand</c> and <c>renderLeftHand</c>: the bare arm and its sleeve, in the pose the first
    /// person renderer has set up.
    /// </summary>
    public void RenderHand(PoseStack pose, IModelSink sink, HumanoidArm arm, EntityTexture skinTexture, bool hasSleeve, float skyLight, float blockLight) {
        PlayerModel model = Model;
        ModelPart armPart = arm == HumanoidArm.Right ? model.RightArm : model.LeftArm;
        armPart.ResetPose();
        armPart.Visible = true;
        model.LeftSleeve.Visible = hasSleeve;
        model.RightSleeve.Visible = hasSleeve;
        model.LeftArm.ZRot = -0.1F;
        model.RightArm.ZRot = 0.1F;
        armPart.Render(pose, sink, new ModelDrawState(skinTexture, 0xFFFFFFFF, skyLight, blockLight, 0));
    }

    protected override void SetupRotations(AvatarRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        float swimAmount = state.SwimAmount;
        float xRot = state.XRot;
        if (state.IsFallFlying) {
            base.SetupRotations(state, pose, bodyRot, entityScale);
            float scale = state.FallFlyingScale();
            if (!state.IsAutoSpinAttack) {
                pose.RotateXDegrees(scale * (-90.0F - xRot));
            }
            if (state.ShouldApplyFlyingYRot) {
                pose.RotateY(state.FlyingYRot);
            }
        }
        else if (swimAmount > 0.0F) {
            base.SetupRotations(state, pose, bodyRot, entityScale);
            float targetXRot = state.IsInWater ? -90.0F - xRot : -90.0F;
            float xAngle = Mth.Lerp(swimAmount, 0.0F, targetXRot);
            pose.RotateXDegrees(xAngle);
            if (state.IsVisuallySwimming) {
                pose.Translate(0.0F, -1.0F, 0.3F);
            }
        }
        else {
            base.SetupRotations(state, pose, bodyRot, entityScale);
        }
    }

    /// <summary>
    /// <c>isEntityUpsideDown</c>: with the cape shown, a player by its profile's name and a mannequin by its
    /// custom name.
    /// </summary>
    protected override bool IsEntityUpsideDown(ClientEntity entity) {
        if (!IsModelPartShown(entity, CapeBit)) {
            return false;
        }
        if (entity.Is(EntityClass.Player)) {
            return _context != null && _context.Client.PlayerList.TryGetValue(entity.Uuid, out PlayerListEntry? info) && info.Name is "Dinnerbone" or "Grumm";
        }
        return base.IsEntityUpsideDown(entity);
    }
}

/// <summary>
/// <c>EntityRenderDispatcher.getAvatarRenderer</c>: vanilla keeps a wide and a slim
/// <see cref="AvatarRenderer"/> and draws each player or mannequin with the one its skin's model picks.
/// </summary>
public sealed class AvatarRenderers : EntityRenderer, IFirstPersonArmRenderer {
    private readonly AvatarRenderer _wide, _slim;

    public AvatarRenderers(EntityRendererContext context) {
        _wide = new AvatarRenderer(context, false);
        _slim = new AvatarRenderer(context, true);
    }

    /// <summary><c>RemotePlayer.shouldRenderAtSqrDistance</c>: another player at ten times the box's side.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) =>
        entity.Is(EntityClass.Player) && entity is not LocalPlayer ? WithinViewDistance(entity, distanceSqr, 10.0) : null;

    /// <summary>The two tick alike, so either serves where the skin is not to hand.</summary>
    public override void Tick(ClientEntity entity) => _wide.Tick(entity);

    public override void Tick(ClientEntity entity, ClientLevel level) => _wide.Tick(entity, level);

    public override EntityRenderState Extract(ClientEntity entity, float partialTick, EntityRenderContext context) =>
        (AvatarRenderer.SkinOf(entity).Slim ? _slim : _wide).Extract(entity, partialTick, context);

    public override void Submit(EntityRenderState state, double x, double y, double z, PoseStack pose, EntityRenderContext context) =>
        (((AvatarRenderState)state).Skin.Slim ? _slim : _wide).Submit(state, x, y, z, pose, context);

    /// <summary>
    /// <c>ItemInHandRenderer.renderPlayerArm</c>'s draw: the arm of the renderer for the player's skin, with
    /// its sleeve when that part is shown. The texture is looked up through the sink when it is an entity
    /// batch, the only sink with an atlas to look it up in.
    /// </summary>
    public void RenderHand(PoseStack pose, IModelSink sink, HumanoidArm arm, LocalPlayer player, float skyLight, float blockLight) {
        if (sink is not EntityBatch batch) {
            return;
        }
        PlayerSkin skin = AvatarRenderer.SkinOf(player);
        EntityTexture texture = batch.Textures.Get(skin.Body) ?? batch.Textures.Missing;
        bool hasSleeve = AvatarRenderer.IsModelPartShown(player, arm == HumanoidArm.Right ? 3 : 2);
        (skin.Slim ? _slim : _wide).RenderHand(pose, sink, arm, texture, hasSleeve, skyLight, blockLight);
    }
}

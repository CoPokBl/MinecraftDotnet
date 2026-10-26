using ClientLib;
using ClientLib.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities;

/// <summary>What draws the local player's bare arm in first person; the player renderer provides it.</summary>
public interface IFirstPersonArmRenderer {
    void RenderHand(PoseStack pose, IModelSink sink, HumanoidArm arm, LocalPlayer player, float skyLight, float blockLight);
}

/// <summary>
/// <c>ItemInHandRenderer</c>: the first person arms and held items, their swing, the dip after a swing or
/// a swap, the poses of each item use, and a filled map held up in one hand or both.
/// </summary>
public sealed class ItemInHandRenderer {
    private const string MapBackgroundLocation = "minecraft:textures/map/map_background.png";
    private const string MapBackgroundCheckerboardLocation = "minecraft:textures/map/map_background_checkerboard.png";

    private readonly ItemRenderer _items;
    private readonly MapRenderer _maps;
    private readonly Func<IFirstPersonArmRenderer?> _arms;
    private ItemStack _mainHandItem = ItemStack.Air, _offHandItem = ItemStack.Air;
    private float _mainHandHeight, _oMainHandHeight, _offHandHeight, _oOffHandHeight;

    public ItemInHandRenderer(ItemRenderer items, MapRenderer maps, Func<IFirstPersonArmRenderer?> arms) {
        _items = items;
        _maps = maps;
        _arms = arms;
    }

    /// <summary>
    /// <c>shouldInstantlyReplaceVisibleItem</c>, comparing the item and count where vanilla compares every
    /// component but those marked <c>ignoreSwapAnimation</c>, which the generated components do not record.
    /// </summary>
    private bool ShouldInstantlyReplaceVisibleItem(ItemStack current, ItemStack expected) =>
        current.Type.Identifier == expected.Type.Identifier && current.Count == expected.Count || !_items.Resolver.ShouldPlaySwapAnimation(expected);

    /// <summary><c>ItemInHandRenderer.tick</c>.</summary>
    public void Tick(LocalPlayer player) {
        _oMainHandHeight = _mainHandHeight;
        _oOffHandHeight = _offHandHeight;
        ItemStack nextMainHand = player.ItemInHand(Hand.MainHand);
        ItemStack nextOffHand = player.ItemInHand(Hand.OffHand);
        if (ShouldInstantlyReplaceVisibleItem(_mainHandItem, nextMainHand)) {
            _mainHandItem = nextMainHand;
        }
        if (ShouldInstantlyReplaceVisibleItem(_offHandItem, nextOffHand)) {
            _offHandItem = nextOffHand;
        }
        if (player.HandsBusy) {
            _mainHandHeight = Math.Clamp(_mainHandHeight - 0.4F, 0.0F, 1.0F);
            _offHandHeight = Math.Clamp(_offHandHeight - 0.4F, 0.0F, 1.0F);
        }
        else {
            float attackAnim = player.ItemSwapScale(1.0F);
            // Vanilla compares references here, which only differ once a swap was not instant; the client
            // builds a fresh stack each read, so the same is asked by value.
            float mainHandTargetHeight = !_mainHandItem.Equals(nextMainHand) ? 0.0F : attackAnim * attackAnim * attackAnim;
            float offHandTargetHeight = !_offHandItem.Equals(nextOffHand) ? 0.0F : 1.0F;
            _mainHandHeight += Math.Clamp(mainHandTargetHeight - _mainHandHeight, -0.4F, 0.4F);
            _offHandHeight += Math.Clamp(offHandTargetHeight - _offHandHeight, -0.4F, 0.4F);
        }
        if (_mainHandHeight < 0.1F) {
            _mainHandItem = nextMainHand;
        }
        if (_offHandHeight < 0.1F) {
            _offHandItem = nextOffHand;
        }
    }

    /// <summary><c>submitHandsWithItems</c>, through a pose that already takes view space to wherever the batch draws.</summary>
    public void SubmitHandsWithItems(float frameInterp, PoseStack pose, IModelSink sink, LocalPlayer player, MinecraftClient client,
        float skyLight, float blockLight) {
        float attackValue = player.GetSwingAnimation(frameInterp);
        Hand attackHand = player.CurrentSwing?.Hand ?? Hand.MainHand;
        float xRot = Mth.Lerp(frameInterp, player.XRotO, player.XRot);
        (bool renderMainHand, bool renderOffHand) = EvaluateWhichHandsToRender(player);
        // xBob and yBob are the camera rotation smoothed by LocalPlayer.aiStep; the arm lags the camera by
        // a tenth of the difference. That smoothing is not tracked, so the arm follows the camera exactly.
        if (renderMainHand) {
            float mainHandAttack = attackHand == Hand.MainHand ? attackValue : 0.0F;
            float inverseArmHeight = _items.Resolver.SwapAnimationScale(_mainHandItem) * (1.0F - Mth.Lerp(frameInterp, _oMainHandHeight, _mainHandHeight));
            SubmitArmWithItem(player, client, frameInterp, xRot, Hand.MainHand, mainHandAttack, _mainHandItem, inverseArmHeight, pose, sink, skyLight, blockLight);
        }
        if (renderOffHand) {
            float offHandAttack = attackHand == Hand.OffHand ? attackValue : 0.0F;
            float inverseArmHeight = _items.Resolver.SwapAnimationScale(_offHandItem) * (1.0F - Mth.Lerp(frameInterp, _oOffHandHeight, _offHandHeight));
            SubmitArmWithItem(player, client, frameInterp, xRot, Hand.OffHand, offHandAttack, _offHandItem, inverseArmHeight, pose, sink, skyLight, blockLight);
        }
    }

    /// <summary><c>evaluateWhichHandsToRender</c>: whether to draw the main hand and the off hand.</summary>
    internal static (bool MainHand, bool OffHand) EvaluateWhichHandsToRender(LocalPlayer player) {
        ItemStack mainHandItem = player.ItemInHand(Hand.MainHand);
        ItemStack offhandItem = player.ItemInHand(Hand.OffHand);
        bool holdsBow = mainHandItem.Is(Item.Bow) || offhandItem.Is(Item.Bow);
        bool holdsCrossbow = mainHandItem.Is(Item.Crossbow) || offhandItem.Is(Item.Crossbow);
        if (!holdsBow && !holdsCrossbow) {
            return (true, true);
        }
        if (player.IsUsingItem) {
            // selectionUsingItemWhileHoldingBowLike.
            ItemStack usedItemStack = player.UseItem;
            Hand usedHand = player.UsedItemHand;
            if (!usedItemStack.Is(Item.Bow) && !usedItemStack.Is(Item.Crossbow)) {
                return usedHand == Hand.MainHand && IsChargedCrossbow(offhandItem) ? (true, false) : (true, true);
            }
            return (usedHand == Hand.MainHand, usedHand == Hand.OffHand);
        }
        return IsChargedCrossbow(mainHandItem) ? (true, false) : (true, true);
    }

    private static bool IsChargedCrossbow(ItemStack item) => item.Is(Item.Crossbow) && IsCharged(item);

    /// <summary><c>CrossbowItem.isCharged</c>.</summary>
    private static bool IsCharged(ItemStack stack) => stack.Has(DataComponent.ChargedProjectiles) && stack.Get(DataComponent.ChargedProjectiles).Length > 0;

    private static HumanoidArm Opposite(HumanoidArm arm) => arm == HumanoidArm.Right ? HumanoidArm.Left : HumanoidArm.Right;

    private void SubmitArmWithItem(LocalPlayer player, MinecraftClient client, float frameInterp, float xRot, Hand hand, float attack, ItemStack itemStack,
        float inverseArmHeight, PoseStack pose, IModelSink sink, float skyLight, float blockLight) {
        if (player.IsScoping) {
            return;
        }
        bool isMainHand = hand == Hand.MainHand;
        HumanoidArm mainArm = player.Get(EntityDataFields.Avatar.PlayerMainHand, HumanoidArm.Right);
        HumanoidArm arm = isMainHand ? mainArm : Opposite(mainArm);
        pose.Push();
        if (itemStack.IsAir()) {
            if (isMainHand && !player.IsInvisible) {
                RenderPlayerArm(pose, sink, inverseArmHeight, attack, arm, player, skyLight, blockLight);
            }
            pose.Pop();
            return;
        }
        if (itemStack.Has(DataComponent.MapId)) {
            if (isMainHand && _offHandItem.IsAir()) {
                RenderTwoHandedMap(pose, sink, skyLight, blockLight, xRot, inverseArmHeight, attack, player, client);
            }
            else {
                RenderOneHandedMap(pose, sink, skyLight, blockLight, inverseArmHeight, arm, attack, itemStack, player, client);
            }
            pose.Pop();
            return;
        }
        bool isRightArm = arm == HumanoidArm.Right;
        int invert = isRightArm ? 1 : -1;
        bool usingThisHand = player.IsUsingItem && player.UseItemRemainingTicks > 0 && player.UsedItemHand == hand;
        if (itemStack.Is(Item.Crossbow)) {
            ApplyItemArmTransform(pose, arm, inverseArmHeight);
            bool charged = IsCharged(itemStack);
            if (usingThisHand && !charged) {
                pose.Translate(invert * -0.4785682F, -0.094387F, 0.05731531F);
                pose.RotateXDegrees(-11.935F);
                pose.RotateYDegrees(invert * 65.3F);
                pose.RotateZDegrees(invert * -9.785F);
                float timeHeld = player.UseDuration - (player.UseItemRemainingTicks - frameInterp + 1.0F);
                float power = timeHeld / Vanilla.HumanoidEntityData.CrossbowChargeDuration(itemStack);
                if (power > 1.0F) {
                    power = 1.0F;
                }
                Shake(pose, timeHeld, power);
                pose.Translate(power * 0.0F, power * 0.0F, power * 0.04F);
                pose.Scale(1.0F, 1.0F, 1.0F + power * 0.2F);
                pose.RotateYDegrees(-(invert * 45.0F));
            }
            else {
                SwingArm(attack, pose, invert, arm);
                if (charged && attack < 0.001F && isMainHand) {
                    pose.Translate(invert * -0.641864F, 0.0F, 0.0F);
                    pose.RotateYDegrees(invert * 10.0F);
                }
            }
        }
        else if (usingThisHand) {
            ConsumableComponent.ConsumeAnimation useAnimation = UseAnimation(itemStack);
            bool customArmTransform = useAnimation is ConsumableComponent.ConsumeAnimation.Eat or ConsumableComponent.ConsumeAnimation.Drink
                or ConsumableComponent.ConsumeAnimation.Spear;
            if (!customArmTransform) {
                ApplyItemArmTransform(pose, arm, inverseArmHeight);
            }
            float timeHeld = player.UseDuration - (player.UseItemRemainingTicks - frameInterp + 1.0F);
            switch (useAnimation) {
                case ConsumableComponent.ConsumeAnimation.Eat:
                case ConsumableComponent.ConsumeAnimation.Drink:
                    ApplyEatTransform(pose, frameInterp, arm, player);
                    ApplyItemArmTransform(pose, arm, inverseArmHeight);
                    break;
                case ConsumableComponent.ConsumeAnimation.Block:
                    // A shield's own model already holds it up; anything else that blocks is turned to face out.
                    if (!itemStack.Is(Item.Shield)) {
                        pose.Translate(invert * -0.14142136F, 0.08F, 0.14142136F);
                        pose.RotateXDegrees(-102.25F);
                        pose.RotateYDegrees(invert * 13.365F);
                        pose.RotateZDegrees(invert * 78.05F);
                    }
                    break;
                case ConsumableComponent.ConsumeAnimation.Bow: {
                    pose.Translate(invert * -0.2785682F, 0.18344387F, 0.15731531F);
                    pose.RotateXDegrees(-13.935F);
                    pose.RotateYDegrees(invert * 35.3F);
                    pose.RotateZDegrees(invert * -9.785F);
                    float power = timeHeld / 20.0F;
                    power = (power * power + power * 2.0F) / 3.0F;
                    if (power > 1.0F) {
                        power = 1.0F;
                    }
                    Shake(pose, timeHeld, power);
                    pose.Translate(power * 0.0F, power * 0.0F, power * 0.04F);
                    pose.Scale(1.0F, 1.0F, 1.0F + power * 0.2F);
                    pose.RotateYDegrees(-(invert * 45.0F));
                    break;
                }
                case ConsumableComponent.ConsumeAnimation.Trident: {
                    pose.Translate(invert * -0.5F, 0.7F, 0.1F);
                    pose.RotateXDegrees(-55.0F);
                    pose.RotateYDegrees(invert * 35.3F);
                    pose.RotateZDegrees(invert * -9.785F);
                    float power = timeHeld / 10.0F;
                    if (power > 1.0F) {
                        power = 1.0F;
                    }
                    Shake(pose, timeHeld, power);
                    pose.Translate(0.0F, 0.0F, power * 0.2F);
                    pose.Scale(1.0F, 1.0F, 1.0F + power * 0.2F);
                    pose.RotateYDegrees(-(invert * 45.0F));
                    break;
                }
                case ConsumableComponent.ConsumeAnimation.Brush:
                    ApplyBrushTransform(pose, frameInterp, arm, player);
                    break;
                case ConsumableComponent.ConsumeAnimation.Bundle:
                    SwingArm(attack, pose, invert, arm);
                    break;
                case ConsumableComponent.ConsumeAnimation.Spear:
                    pose.Translate(invert * 0.56F, -0.52F, -0.72F);
                    Vanilla.SpearAnimations.FirstPersonUse(player.TicksSinceLastKineticHitFeedback(client.Level?.GameTime ?? 0L, frameInterp), pose, timeHeld,
                        arm, itemStack);
                    break;
            }
        }
        else if (Vanilla.HumanoidEntityData.IsAutoSpinAttack(player)) {
            ApplyItemArmTransform(pose, arm, inverseArmHeight);
            pose.Translate(invert * -0.4F, 0.8F, 0.3F);
            pose.RotateYDegrees(invert * 65.0F);
            pose.RotateZDegrees(invert * -85.0F);
        }
        else {
            ApplyItemArmTransform(pose, arm, inverseArmHeight);
            switch (player.CurrentSwing is { } swing && swing.Hand == hand ? swing.Animation.Type : SwingAnimationType.None) {
                case SwingAnimationType.Whack:
                    SwingArm(attack, pose, invert, arm);
                    break;
                case SwingAnimationType.Stab:
                    Vanilla.SpearAnimations.FirstPersonAttack(attack, pose, invert);
                    break;
            }
        }
        _items.Render(itemStack, isRightArm ? ItemDisplayContext.FirstPersonRightHand : ItemDisplayContext.FirstPersonLeftHand, pose, sink, skyLight, blockLight,
            player, hand);
        pose.Pop();
    }

    private static void Shake(PoseStack pose, float timeHeld, float power) {
        if (power > 0.1F) {
            float shakeOffset = Mth.Sin((timeHeld - 0.1F) * 1.3F);
            float shakeIntensity = power - 0.1F;
            float shake = shakeOffset * shakeIntensity;
            pose.Translate(shake * 0.0F, shake * 0.004F, shake * 0.0F);
        }
    }

    /// <summary>
    /// <c>ItemStack.getUseAnimation</c>: the item classes that override <c>Item.getUseAnimation</c>, matched by
    /// item since there is no table of item classes, then the base method's components.
    /// </summary>
    internal static ConsumableComponent.ConsumeAnimation UseAnimation(ItemStack stack) {
        if (stack.Is(Item.Bow)) return ConsumableComponent.ConsumeAnimation.Bow;
        if (stack.Is(Item.Crossbow)) return ConsumableComponent.ConsumeAnimation.Crossbow;
        if (stack.Is(Item.Trident)) return ConsumableComponent.ConsumeAnimation.Trident;
        if (stack.Is(Item.Spyglass)) return ConsumableComponent.ConsumeAnimation.Spyglass;
        if (stack.Is(Item.GoatHorn)) return ConsumableComponent.ConsumeAnimation.TootHorn;
        if (stack.Is(Item.Brush)) return ConsumableComponent.ConsumeAnimation.Brush;
        if (ClientLib.Interaction.ItemBars.IsBundle(stack)) return ConsumableComponent.ConsumeAnimation.Bundle;
        if (stack.GetOrNull(DataComponent.Consumable) is { } consumable) return consumable.Animation;
        if (stack.Has(DataComponent.BlocksAttacks)) return ConsumableComponent.ConsumeAnimation.Block;
        return stack.Has(DataComponent.KineticWeapon) ? ConsumableComponent.ConsumeAnimation.Spear : ConsumableComponent.ConsumeAnimation.None;
    }

    private void RenderPlayerArm(PoseStack pose, IModelSink sink, float inverseArmHeight, float attackValue, HumanoidArm arm, LocalPlayer player,
        float skyLight, float blockLight) {
        if (_arms() is not { } arms) {
            return;
        }
        bool isRightArm = arm != HumanoidArm.Left;
        float invert = isRightArm ? 1.0F : -1.0F;
        float sqrtAttackValue = Mth.Sqrt(attackValue);
        float xSwingPosition = -0.3F * Mth.Sin(sqrtAttackValue * MathF.PI);
        float ySwingPosition = 0.4F * Mth.Sin(sqrtAttackValue * (MathF.PI * 2));
        float zSwingPosition = -0.4F * Mth.Sin(attackValue * MathF.PI);
        pose.Translate(invert * (xSwingPosition + 0.64000005F), ySwingPosition + -0.6F + inverseArmHeight * -0.6F, zSwingPosition + -0.71999997F);
        pose.RotateYDegrees(invert * 45.0F);
        float zSwingRotation = Mth.Sin(attackValue * attackValue * MathF.PI);
        float ySwingRotation = Mth.Sin(sqrtAttackValue * MathF.PI);
        pose.RotateYDegrees(invert * ySwingRotation * 70.0F);
        pose.RotateZDegrees(invert * zSwingRotation * -20.0F);
        pose.Translate(invert * -1.0F, 3.6F, 3.5F);
        pose.RotateZDegrees(invert * 120.0F);
        pose.RotateXDegrees(200.0F);
        pose.RotateYDegrees(invert * -135.0F);
        pose.Translate(invert * 5.6F, 0.0F, 0.0F);
        arms.RenderHand(pose, sink, arm, player, skyLight, blockLight);
    }

    /// <summary><c>calculateMapTilt</c>.</summary>
    private static float CalculateMapTilt(float xRot) {
        float tilt = 1.0F - xRot / 45.0F + 0.1F;
        tilt = Math.Clamp(tilt, 0.0F, 1.0F);
        return -Mth.Cos(tilt * MathF.PI) * 0.5F + 0.5F;
    }

    private void RenderMapHand(PoseStack pose, IModelSink sink, float skyLight, float blockLight, HumanoidArm arm, LocalPlayer player) {
        if (_arms() is not { } arms) {
            return;
        }
        pose.Push();
        float invert = arm == HumanoidArm.Right ? 1.0F : -1.0F;
        pose.RotateYDegrees(92.0F);
        pose.RotateXDegrees(45.0F);
        pose.RotateZDegrees(invert * -41.0F);
        pose.Translate(invert * 0.3F, -1.1F, 0.45F);
        arms.RenderHand(pose, sink, arm, player, skyLight, blockLight);
        pose.Pop();
    }

    private void RenderOneHandedMap(PoseStack pose, IModelSink sink, float skyLight, float blockLight, float inverseArmHeight, HumanoidArm arm,
        float attackValue, ItemStack map, LocalPlayer player, MinecraftClient client) {
        float invert = arm == HumanoidArm.Right ? 1.0F : -1.0F;
        pose.Translate(invert * 0.125F, -0.125F, 0.0F);
        if (!player.IsInvisible) {
            pose.Push();
            pose.RotateZDegrees(invert * 10.0F);
            RenderPlayerArm(pose, sink, inverseArmHeight, attackValue, arm, player, skyLight, blockLight);
            pose.Pop();
        }
        pose.Push();
        pose.Translate(invert * 0.51F, -0.08F + inverseArmHeight * -1.2F, -0.75F);
        float sqrtAttackValue = Mth.Sqrt(attackValue);
        float xSwing = Mth.Sin(sqrtAttackValue * MathF.PI);
        float xSwingPosition = -0.5F * xSwing;
        float ySwingPosition = 0.4F * Mth.Sin(sqrtAttackValue * (MathF.PI * 2));
        float zSwingPosition = -0.3F * Mth.Sin(attackValue * MathF.PI);
        pose.Translate(invert * xSwingPosition, ySwingPosition - 0.3F * xSwing, zSwingPosition);
        pose.RotateXDegrees(xSwing * -45.0F);
        pose.RotateYDegrees(invert * xSwing * -30.0F);
        RenderMap(pose, sink, skyLight, blockLight, map, client);
        pose.Pop();
    }

    private void RenderTwoHandedMap(PoseStack pose, IModelSink sink, float skyLight, float blockLight, float xRot, float inverseArmHeight,
        float attackValue, LocalPlayer player, MinecraftClient client) {
        float sqrtAttackValue = Mth.Sqrt(attackValue);
        float ySwingPosition = -0.2F * Mth.Sin(attackValue * MathF.PI);
        float zSwingPosition = -0.4F * Mth.Sin(sqrtAttackValue * MathF.PI);
        pose.Translate(0.0F, -ySwingPosition / 2.0F, zSwingPosition);
        float mapTilt = CalculateMapTilt(xRot);
        pose.Translate(0.0F, 0.04F + inverseArmHeight * -1.2F + mapTilt * -0.5F, -0.72F);
        pose.RotateXDegrees(mapTilt * -85.0F);
        if (!player.IsInvisible) {
            pose.Push();
            pose.RotateYDegrees(90.0F);
            RenderMapHand(pose, sink, skyLight, blockLight, HumanoidArm.Right, player);
            RenderMapHand(pose, sink, skyLight, blockLight, HumanoidArm.Left, player);
            pose.Pop();
        }
        float xzSwingRotation = Mth.Sin(sqrtAttackValue * MathF.PI);
        pose.RotateXDegrees(xzSwingRotation * 20.0F);
        pose.Scale(2.0F, 2.0F, 2.0F);
        RenderMap(pose, sink, skyLight, blockLight, _mainHandItem, client);
    }

    /// <summary><c>renderMap</c>: the parchment, a checkerboard under a map the server has sent, then the map.</summary>
    private void RenderMap(PoseStack pose, IModelSink sink, float skyLight, float blockLight, ItemStack itemStack, MinecraftClient client) {
        pose.RotateYDegrees(180.0F);
        pose.RotateZDegrees(180.0F);
        pose.Scale(0.38F, 0.38F, 0.38F);
        pose.Translate(-0.5F, -0.5F, 0.0F);
        pose.Scale(0.0078125F, 0.0078125F, 0.0078125F);
        int id = itemStack.Get(DataComponent.MapId);
        ClientLib.World.ClientMapData? data = client.MapData(id);
        EntityTextures textures = _maps.Textures;
        EntityTexture background = textures.Get(data == null ? MapBackgroundLocation : MapBackgroundCheckerboardLocation) ?? textures.Missing;
        System.Numerics.Matrix4x4 m = pose.Matrix;
        sink.Quad([System.Numerics.Vector3.Transform(new System.Numerics.Vector3(-7.0F, 135.0F, 0.0F), m),
                System.Numerics.Vector3.Transform(new System.Numerics.Vector3(135.0F, 135.0F, 0.0F), m),
                System.Numerics.Vector3.Transform(new System.Numerics.Vector3(135.0F, -7.0F, 0.0F), m),
                System.Numerics.Vector3.Transform(new System.Numerics.Vector3(-7.0F, -7.0F, 0.0F), m)],
            [new(0.0F, 1.0F), new(1.0F, 1.0F), new(1.0F, 0.0F), new(0.0F, 0.0F)], pose.TransformNormal(-System.Numerics.Vector3.UnitZ),
            new ModelDrawState(background, 0xFFFFFFFF, skyLight, blockLight, 0));
        if (data != null) {
            // The labels' backgrounds blend, which the hand's pass does not.
            _maps.Render(id, data, pose, sink, null, false, skyLight, blockLight);
        }
    }

    private static void ApplyEatTransform(PoseStack pose, float frameInterp, HumanoidArm arm, LocalPlayer player) {
        float currUsageTime = player.UseItemRemainingTicks - frameInterp + 1.0F;
        float scaledUsageTime = currUsageTime / player.UseDuration;
        if (scaledUsageTime < 0.8F) {
            float extraHeightOffset = Math.Abs(Mth.Cos(currUsageTime / 4.0F * MathF.PI) * 0.1F);
            pose.Translate(0.0F, extraHeightOffset, 0.0F);
        }
        float eatJiggle = 1.0F - (float)Math.Pow(scaledUsageTime, 27.0);
        int invert = arm == HumanoidArm.Right ? 1 : -1;
        pose.Translate(eatJiggle * 0.6F * invert, eatJiggle * -0.5F, eatJiggle * 0.0F);
        pose.RotateYDegrees(invert * eatJiggle * 90.0F);
        pose.RotateXDegrees(eatJiggle * 10.0F);
        pose.RotateZDegrees(invert * eatJiggle * 30.0F);
    }

    private static void ApplyBrushTransform(PoseStack pose, float frameInterp, HumanoidArm arm, LocalPlayer player) {
        float brushAnimationRemainingTicks = player.UseItemRemainingTicks % 10;
        float deltaSinceLastUpdate = brushAnimationRemainingTicks - frameInterp + 1.0F;
        float scaledUsageTime = 1.0F - deltaSinceLastUpdate / 10.0F;
        float currentSwipeAngle = -15.0F + 75.0F * Mth.Cos(scaledUsageTime * 2.0F * MathF.PI);
        if (arm != HumanoidArm.Right) {
            pose.Translate(0.1F, 0.83F, 0.35F);
            pose.RotateXDegrees(-80.0F);
            pose.RotateYDegrees(-90.0F);
            pose.RotateXDegrees(currentSwipeAngle);
            pose.Translate(-0.3F, 0.22F, 0.35F);
        }
        else {
            pose.Translate(-0.25F, 0.22F, 0.35F);
            pose.RotateXDegrees(-80.0F);
            pose.RotateYDegrees(90.0F);
            pose.RotateZDegrees(0.0F);
            pose.RotateXDegrees(currentSwipeAngle);
        }
    }

    private static void ApplyItemArmAttackTransform(PoseStack pose, HumanoidArm arm, float attackValue) {
        int invert = arm == HumanoidArm.Right ? 1 : -1;
        float ySwingRotation = Mth.Sin(attackValue * attackValue * MathF.PI);
        pose.RotateYDegrees(invert * (45.0F + ySwingRotation * -20.0F));
        float xzSwingRotation = Mth.Sin(Mth.Sqrt(attackValue) * MathF.PI);
        pose.RotateZDegrees(invert * xzSwingRotation * -20.0F);
        pose.RotateXDegrees(xzSwingRotation * -80.0F);
        pose.RotateYDegrees(invert * -45.0F);
    }

    private static void ApplyItemArmTransform(PoseStack pose, HumanoidArm arm, float inverseArmHeight) {
        int invert = arm == HumanoidArm.Right ? 1 : -1;
        pose.Translate(invert * 0.56F, -0.52F + inverseArmHeight * -0.6F, -0.72F);
    }

    private static void SwingArm(float attack, PoseStack pose, int invert, HumanoidArm arm) {
        float xSwingPosition = -0.4F * Mth.Sin(Mth.Sqrt(attack) * MathF.PI);
        float ySwingPosition = 0.2F * Mth.Sin(Mth.Sqrt(attack) * (MathF.PI * 2));
        float zSwingPosition = -0.2F * Mth.Sin(attack * MathF.PI);
        pose.Translate(invert * xSwingPosition, ySwingPosition, zSwingPosition);
        ApplyItemArmAttackTransform(pose, arm, attack);
    }
}

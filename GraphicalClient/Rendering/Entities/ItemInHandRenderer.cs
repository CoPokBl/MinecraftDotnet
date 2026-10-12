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
/// a swap, and the poses while eating, drawing a bow or blocking. Maps, the brush, the spear and the
/// crossbow's charging pose are not ported; those items are held in the plain pose instead.
/// </summary>
public sealed class ItemInHandRenderer {
    private readonly ItemRenderer _items;
    private readonly Func<IFirstPersonArmRenderer?> _arms;
    private ItemStack _mainHandItem = ItemStack.Air, _offHandItem = ItemStack.Air;
    private float _mainHandHeight, _oMainHandHeight, _offHandHeight, _oOffHandHeight;

    public ItemInHandRenderer(ItemRenderer items, Func<IFirstPersonArmRenderer?> arms) {
        _items = items;
        _arms = arms;
    }

    /// <summary>
    /// <c>shouldInstantlyReplaceVisibleItem</c>, comparing the item and count. Vanilla also ignores the
    /// <c>ignoreSwapAnimation</c> components and lets an item model turn the swap off; neither is known here.
    /// </summary>
    private static bool ShouldInstantlyReplaceVisibleItem(ItemStack current, ItemStack expected) =>
        current.Type.Identifier == expected.Type.Identifier && current.Count == expected.Count;

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
        float attackValue = player.GetAttackAnim(frameInterp);
        Hand attackHand = player.SwingingArm;
        float xRot = Mth.Lerp(frameInterp, player.XRotO, player.XRot);
        bool holdsBowLike = IsBowLike(player.ItemInHand(Hand.MainHand)) || IsBowLike(player.ItemInHand(Hand.OffHand));
        Hand? using_ = client.Interactions.UsingItem;
        bool renderMainHand = true, renderOffHand = true;
        if (holdsBowLike && using_ is { } usedHand && IsBowLike(player.ItemInHand(usedHand))) {
            renderMainHand = usedHand == Hand.MainHand;
            renderOffHand = usedHand == Hand.OffHand;
        }
        // xBob and yBob are the camera rotation smoothed by LocalPlayer.aiStep; the arm lags the camera by
        // a tenth of the difference. That smoothing is not tracked, so the arm follows the camera exactly.
        if (renderMainHand) {
            float mainHandAttack = attackHand == Hand.MainHand ? attackValue : 0.0F;
            float inverseArmHeight = 1.0F - Mth.Lerp(frameInterp, _oMainHandHeight, _mainHandHeight);
            SubmitArmWithItem(player, client, frameInterp, xRot, Hand.MainHand, mainHandAttack, _mainHandItem, inverseArmHeight, pose, sink, skyLight, blockLight);
        }
        if (renderOffHand) {
            float offHandAttack = attackHand == Hand.OffHand ? attackValue : 0.0F;
            float inverseArmHeight = 1.0F - Mth.Lerp(frameInterp, _oOffHandHeight, _offHandHeight);
            SubmitArmWithItem(player, client, frameInterp, xRot, Hand.OffHand, offHandAttack, _offHandItem, inverseArmHeight, pose, sink, skyLight, blockLight);
        }
    }

    private static bool IsBowLike(ItemStack stack) => stack.Is(Item.Bow) || stack.Is(Item.Crossbow);

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
        bool isRightArm = arm == HumanoidArm.Right;
        int invert = isRightArm ? 1 : -1;
        if (client.Interactions.UsingItem == hand && client.Interactions.UseItemRemainingTicks > 0) {
            ConsumableComponent.ConsumeAnimation useAnimation = UseAnimation(itemStack);
            bool customArmTransform = useAnimation is ConsumableComponent.ConsumeAnimation.Eat or ConsumableComponent.ConsumeAnimation.Drink
                or ConsumableComponent.ConsumeAnimation.Spear;
            if (!customArmTransform) {
                ApplyItemArmTransform(pose, arm, inverseArmHeight);
            }
            float timeHeld = client.Interactions.UseDuration - (client.Interactions.UseItemRemainingTicks - frameInterp + 1.0F);
            switch (useAnimation) {
                case ConsumableComponent.ConsumeAnimation.Eat:
                case ConsumableComponent.ConsumeAnimation.Drink:
                    ApplyEatTransform(pose, frameInterp, arm, client);
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
                case ConsumableComponent.ConsumeAnimation.Bundle:
                    SwingArm(attack, pose, invert, arm);
                    break;
            }
        }
        else {
            ApplyItemArmTransform(pose, arm, inverseArmHeight);
            if (itemStack.Get(DataComponent.SwingAnimation).Type == SwingAnimationType.Whack) {
                SwingArm(attack, pose, invert, arm);
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

    private static void ApplyEatTransform(PoseStack pose, float frameInterp, HumanoidArm arm, MinecraftClient client) {
        float currUsageTime = client.Interactions.UseItemRemainingTicks - frameInterp + 1.0F;
        float scaledUsageTime = currUsageTime / client.Interactions.UseDuration;
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

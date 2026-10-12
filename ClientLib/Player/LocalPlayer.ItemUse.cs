using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Physics;
using Minecraft.Data.Components.Types;
using Minecraft.Data.EnchantmentEffects.Types;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Player;

/// <summary>
/// The item use half of <c>LocalPlayer</c> and <c>LivingEntity</c>. Whether the player is using an item
/// is this client's own <c>startedUsingItem</c>, which the server's living entity flags only correct.
/// </summary>
public sealed partial class LocalPlayer {
    private bool _startedUsingItem;
    private Hand? _usingItemHand;

    /// <summary><c>LocalPlayer.isUsingItem</c>.</summary>
    public bool IsUsingItem => _startedUsingItem;

    /// <summary><c>LocalPlayer.getUsedItemHand</c>: the last hand used, kept after the use stops.</summary>
    public Hand UsedItemHand => _usingItemHand ?? Hand.MainHand;

    /// <summary><c>LivingEntity.useItem</c>, empty when nothing is in use.</summary>
    public ItemStack UseItem { get; private set; } = ItemStack.Air;

    /// <summary>
    /// <c>getUseItemRemainingTicks</c>. A client never completes a use itself, so this keeps counting
    /// below zero until the server says the use finished.
    /// </summary>
    public int UseItemRemainingTicks { get; private set; }

    /// <summary><c>useItem.getUseDuration</c>, which <see cref="UseItemRemainingTicks"/> counts down from.</summary>
    public int UseDuration { get; private set; }

    /// <summary>
    /// <c>LivingEntity.autoSpinAttackTicks</c>. The client counts its own down; the item
    /// <c>startAutoSpinAttack</c> also keeps is only read by the server's attack.
    /// </summary>
    public int AutoSpinAttackTicks { get; private set; }

    /// <summary><c>LivingEntity.autoSpinAttackDmg</c>, which <c>Player.attack</c> reads while the server's flag is set.</summary>
    private float _autoSpinAttackDamage;

    /// <summary><c>Entity.random</c>, which only an enchantment's <c>remove_binomial</c> and the portal trigger's pitch draw from here.</summary>
    private readonly RandomSource _random = new LegacyRandomSource(System.Random.Shared.NextInt64());

    /// <summary><c>LivingEntity.isFallFlying</c>.</summary>
    public bool IsFallFlying => (SharedFlags & 0x80) != 0;

    /// <summary><c>LivingEntity.isAutoSpinAttack</c>, the server's flag.</summary>
    private bool IsAutoSpinAttack => (Get(Minecraft.Data.Generated.EntityDataFields.LivingEntity.LivingEntityFlags) & 0x04) != 0;

    private UseEffectsComponent.Data UseEffects => ItemComponents.Get(UseItem, DataComponent.UseEffects) ?? UseEffectsComponent.Data.Default;

    private bool IsSlowDueToUsingItem => IsUsingItem && !UseEffects.CanSprint;

    private float ItemUseSpeedMultiplier => UseEffects.SpeedMultiplier;

    /// <summary><c>LocalPlayer.startUsingItem</c> over <c>LivingEntity.startUsingItem</c>, client side.</summary>
    public void StartUsingItem(Hand hand) {
        ItemStack itemStack = ItemInHand(hand);
        if (ItemComponents.IsEmpty(itemStack) || IsUsingItem) {
            return;
        }
        UseItem = itemStack;
        UseDuration = UsePrediction.UseDuration(itemStack);
        UseItemRemainingTicks = UseDuration;
        _startedUsingItem = true;
        _usingItemHand = hand;
    }

    /// <summary><c>LocalPlayer.stopUsingItem</c> over <c>LivingEntity.stopUsingItem</c>, client side.</summary>
    public void StopUsingItem() {
        UseItem = ItemStack.Air;
        UseItemRemainingTicks = 0;
        UseDuration = 0;
        _startedUsingItem = false;
    }

    /// <summary>
    /// <c>LivingEntity.releaseUsingItem</c>. Of the items' <c>releaseUsing</c> only the trident's moves the
    /// player, so only it runs here; the rest is the host's, through <see cref="MultiPlayerGameMode.ReleasedUsingItem"/>.
    /// </summary>
    public void ReleaseUsingItem() {
        ItemStack itemInUsedHand = ItemInHand(UsedItemHand);
        if (!ItemComponents.IsEmpty(UseItem) && itemInUsedHand.Type.Identifier.Equals(UseItem.Type.Identifier)) {
            UseItem = itemInUsedHand;
            if (UseItem.Type.Identifier == Item.Trident.Identifier) {
                ReleaseTrident(UseItem, UseItemRemainingTicks);
            }
        }
        StopUsingItem();
    }

    /// <summary>
    /// <c>TridentItem.releaseUsing</c>, client side: a riptide launch. The throw, the durability and the
    /// sound are the server's.
    /// </summary>
    private void ReleaseTrident(ItemStack itemStack, int remainingTime) {
        int timeHeld = UsePrediction.UseDuration(itemStack) - remainingTime;
        if (timeHeld < 10) {
            return;
        }
        float riptideStrength = TridentSpinAttackStrength(itemStack);
        if (riptideStrength > 0.0F && !(IsInWaterOrRain && !IsPassenger)) {
            return;
        }
        if (ItemModelProperties.NextDamageWillBreak(itemStack) || !(riptideStrength > 0.0F)) {
            return;
        }
        float yRot = YRot;
        float xRot = XRot;
        float xd = -Mth.Sin(yRot * (float)(Math.PI / 180.0)) * Mth.Cos(xRot * (float)(Math.PI / 180.0));
        float yd = -Mth.Sin(xRot * (float)(Math.PI / 180.0));
        float zd = Mth.Cos(yRot * (float)(Math.PI / 180.0)) * Mth.Cos(xRot * (float)(Math.PI / 180.0));
        float dist = Mth.Sqrt(xd * xd + yd * yd + zd * zd);
        xd *= riptideStrength / dist;
        yd *= riptideStrength / dist;
        zd *= riptideStrength / dist;
        Push(xd, yd, zd);
        StartAutoSpinAttack(20, 8.0F);
        if (OnGround) {
            Move(new Vec3d(0.0, 1.1999999F, 0.0));
        }
    }

    /// <summary><c>EnchantmentHelper.getTridentSpinAttackStrength</c>.</summary>
    private float TridentSpinAttackStrength(ItemStack trident) {
        float strength = 0.0F;
        foreach ((IEnchantment enchantment, int level) in ItemComponents.Get(trident, DataComponent.Enchantments) ?? []) {
            foreach (TridentSpinAttackStrengthEnchantmentEffect effect in enchantment.Effects.OfType<TridentSpinAttackStrengthEnchantmentEffect>()) {
                strength = effect.Value.Process(level, _random, strength);
            }
        }
        return strength;
    }

    /// <summary><c>TridentItem.use</c>'s FAIL: a trident about to break, or a riptide one out of water and rain.</summary>
    internal bool TridentUseFails(ItemStack trident) =>
        ItemModelProperties.NextDamageWillBreak(trident) || TridentSpinAttackStrength(trident) > 0.0F && !IsInWaterOrRain;

    /// <summary>
    /// <c>Player.handleEntityEvent(9)</c>, <c>LivingEntity.completeUsingItem</c> client side. Vanilla
    /// compares the stacks by identity, which this client's inventory does not keep, so they are
    /// compared by value. The stack <c>finishUsingItem</c> consumes is left for the server's slot update.
    /// </summary>
    public void CompleteUsingItem() {
        if (!IsUsingItem) {
            return;
        }
        if (!UseItem.Equals(ItemInHand(UsedItemHand))) {
            ReleaseUsingItem();
        }
        else if (!ItemComponents.IsEmpty(UseItem)) {
            StopUsingItem();
        }
    }

    /// <summary><c>LivingEntity.updatingUsingItem</c>. <c>onUseTick</c> is the host's, and reads the count before this takes one off.</summary>
    private void UpdatingUsingItem() {
        if (!IsUsingItem) {
            return;
        }
        ItemStack inHand = ItemInHand(UsedItemHand);
        if (inHand.Type.Identifier.Equals(UseItem.Type.Identifier)) {
            UseItem = inHand;
            UseItemRemainingTicks--;
        }
        else {
            StopUsingItem();
        }
    }

    /// <summary><c>Player.startAutoSpinAttack</c>, client side: the flag and the pose it gives are the server's.</summary>
    private void StartAutoSpinAttack(int activationTicks, float damage) {
        AutoSpinAttackTicks = activationTicks;
        _autoSpinAttackDamage = damage;
    }

    /// <summary>The auto spin attack countdown out of <c>LivingEntity.aiStep</c>, given the box from before <c>travel</c>.</summary>
    private void TickAutoSpinAttack(Box beforeTravelBox) {
        if (AutoSpinAttackTicks > 0) {
            AutoSpinAttackTicks--;
            CheckAutoSpinAttack(beforeTravelBox, BoundingBox);
        }
    }

    /// <summary><c>LivingEntity.checkAutoSpinAttack</c>, client side, where <c>doAutoAttackOnTouch</c> is <c>Player.attack</c>.</summary>
    private void CheckAutoSpinAttack(Box old, Box current) {
        Box minmax = old.MinMax(current);
        bool any = false;
        foreach (ClientEntity entity in _client.Entities.Values) {
            if (entity == this || entity.IsRemoved || EntityCollisions.IsSpectator(_client, entity) || !entity.BoundingBox.Intersects(minmax)) {
                continue;
            }
            any = true;
            if (entity.IsLiving) {
                Attack(entity);
                AutoSpinAttackTicks = 0;
                DeltaMovement = DeltaMovement * -0.2;
                break;
            }
        }
        if (!any && HorizontalCollision) {
            AutoSpinAttackTicks = 0;
        }
    }

    /// <summary><c>Entity.isInRain</c>: rain on the feet or on the top of the box.</summary>
    private bool IsInRain {
        get {
            int x = BlockX, y = BlockY, z = BlockZ;
            return Level.IsRainingAt(x, y, z) || Level.IsRainingAt(x, (int)Math.Floor(BoundingBox.MaxY), z);
        }
    }

    /// <summary><c>Entity.isInWaterOrRain</c>.</summary>
    public bool IsInWaterOrRain => IsInWater || IsInRain;

    /// <summary><c>Entity.push(double, double, double)</c>.</summary>
    internal void Push(double xa, double ya, double za) {
        if (double.IsFinite(xa) && double.IsFinite(ya) && double.IsFinite(za)) {
            DeltaMovement = DeltaMovement.Add(xa, ya, za);
        }
    }

    /// <summary><c>LocalPlayer.onSyncedDataUpdated</c> over <c>LivingEntity</c>'s, for a field the server sent.</summary>
    public override void OnSyncedDataUpdated(int index) {
        base.OnSyncedDataUpdated(index);
        if (index != EntityDataFields.LivingEntity.LivingEntityFlags.Index) {
            return;
        }
        if (IsUsingItem && ItemComponents.IsEmpty(UseItem)) {
            UseItem = ItemInHand(UsedItemHand);
            if (!ItemComponents.IsEmpty(UseItem)) {
                UseDuration = UsePrediction.UseDuration(UseItem);
                UseItemRemainingTicks = UseDuration;
            }
        }
        else if (!IsUsingItem && !ItemComponents.IsEmpty(UseItem)) {
            UseItem = ItemStack.Air;
            UseItemRemainingTicks = 0;
        }

        sbyte flags = Get(EntityDataFields.LivingEntity.LivingEntityFlags);
        bool serverUsingItem = (flags & 1) > 0;
        Hand serverUsingHand = (flags & 2) > 0 ? Hand.OffHand : Hand.MainHand;
        if (serverUsingItem && !_startedUsingItem) {
            StartUsingItem(serverUsingHand);
        }
        else if (!serverUsingItem && _startedUsingItem) {
            StopUsingItem();
        }
    }
}

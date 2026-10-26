using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using Minecraft;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Tags;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Holding an item up stops what it is pointed at, and an axe takes it away, i.e. shields. A port of
/// <c>LivingEntity.applyItemBlocking</c>, <c>Player.blockUsingItem</c> and the <c>BlocksAttacks</c>
/// component's own methods, registered as the pipeline's <see cref="IDamageBlocker"/>.
/// <p/>
/// Not part of any bundle: like <see cref="ArmourFeature"/> it changes what every hit is worth.
/// <p/>
/// What counts as a shield is <see cref="BlockingItem"/>, which reads the
/// <c>minecraft:blocks_attacks</c> component the item carries. That is where vanilla keeps it since
/// 1.21.5, and reading it rather than naming shields is what makes both directions possible: an item
/// with the component blocks, and a shield with it removed
/// (<c>new ItemStack(Item.Shield).Without(DataComponent.BlocksAttacks)</c>) is a cosmetic one that
/// blocks nothing here and does not animate on the client either.
/// <p/>
/// Any <see cref="LivingEntity"/> can block, not only a player. A player's shield goes up and down
/// with their use packets; anything else has to be told, since nothing here has mob AI to decide it,
/// so <see cref="StartBlocking"/> and <see cref="StopBlocking"/> are vanilla's <c>startUsingItem</c>
/// and <c>stopUsingItem</c> made public for whatever does.
/// <p/>
/// Two parts of a block are a player's alone in vanilla, and both are checks in the methods rather
/// than anything about how a mob is built, so they are checks here too: durability
/// (<c>hurtBlockingItem</c> does nothing for anything else) and being disabled by an axe, which is
/// reached from <c>Player.blockUsingItem</c> and not from the <c>LivingEntity</c> one it overrides. A
/// mob's shield therefore neither wears out nor can be knocked aside.
/// <p/>
/// A melee hit the item only partly stopped also pushes the blocker (<c>blockedByItem</c>); one it
/// stopped whole does not.
/// </summary>
public class ShieldFeature : ScopedFeature, IDamageBlocker {
    /// <summary>
    /// What the item stops while it is held up, or null if it cannot be blocked with at all. The
    /// component is what the client reads too, so overriding this to accept an item without one gives
    /// a shield the server believes in and the client does not.
    /// </summary>
    public Func<ItemStack, BlocksAttacksComponent.Data?> BlockingItem { get; set; } =
        item => item.GetOrNull(DataComponent.BlocksAttacks);

    /// <summary>
    /// The item a hit was dealt with, which is what decides whether it disables the block.
    /// <c>LivingEntity.getWeaponItem</c> is the attacker's main hand; a <see cref="DamageSource"/>
    /// that names its weapon is preferred, since a feature that fills that in knows better than a
    /// guess from the attacker's equipment.
    /// </summary>
    public Func<DamageSource, ItemStack?> AttackerWeapon { get; set; } =
        source => source.Weapon ?? (source.Attacker as LivingEntity)?.GetItemInHand(Hand.MainHand);

    /// <summary>
    /// How long hitting a blocking player with this weapon takes their block away, before the
    /// blocking item's own <c>disable_cooldown_scale</c>. Five seconds for an axe, nothing for
    /// anything else, which is the <c>minecraft:weapon</c> component talking rather than a rule about
    /// axes: give any item that component and it disables shields.
    /// </summary>
    public Func<ItemStack, float> DisableSeconds { get; set; } =
        weapon => weapon.GetOrNull(DataComponent.Weapon)?.DisableBlockingForSeconds ?? 0f;

    /// <summary>
    /// Whether blocking wears the item out, by the component's <c>item_damage</c> function. Off for a
    /// minigame that would rather a shield lasted the round.
    /// </summary>
    public bool DamageItems { get; set; } = true;

    /// <summary>Which hand is held up, since when, and with what. Absent while not blocking.</summary>
    private static readonly Tag<Raised> RaisedTag = new("managedserver:shield:raised");

    /// <summary>
    /// The tick the player may block again on. Vanilla puts the item on the player's cooldown and
    /// lets <c>Item.use</c> refuse it from there; nothing here shares that table, so the shield keeps
    /// its own and sends the client the same cooldown packet.
    /// </summary>
    private static readonly Tag<ulong> DisabledUntilTag = new("managedserver:shield:disabled_until");

    /// <summary>What the hit being dealt was blocked with, read back by <see cref="OnBlocked"/>.</summary>
    private static readonly Tag<BlocksAttacksComponent.Data> BlockedWithTag =
        new("managedserver:shield:blocked_with");

    /// <summary>
    /// The item is kept by type rather than by value, unlike vanilla's reference to the stack, because
    /// blocking damages it: comparing the whole stack would lower the shield on the hit that wore it.
    /// </summary>
    private record Raised(Hand Hand, Identifier Item, ulong StartTick);

    public override void Register() {
        AddDamageBlocker(this);

        AddEventHandler<PlayerPacketHandleEvent>(e => {
            switch (e.Packet) {
                case ServerBoundUseItemPacket use:
                    StartBlocking(e.Player, use.UsedHand);
                    break;

                // Vanilla's RELEASE_USE_ITEM, i.e. the right mouse button coming back up, and the swap
                // that puts a different item in the hand. Read off the packet rather than through
                // PlayerSwapItemEvent, which only exists when the feature that calls it is registered.
                case ServerBoundPlayerActionPacket {
                    ActionStatus: ServerBoundPlayerActionPacket.Status.UpdateHeldItem
                    or ServerBoundPlayerActionPacket.Status.SwapItem
                }:
                    StopBlocking(e.Player);
                    break;
            }
        });

        // The other two things that put a different item in the hand. The check in BlockingWith catches
        // the rest lazily, but the pose has to come down when it happens rather than at the next hit.
        AddEventHandler<PlayerSwitchHotbarSlotEvent>(e => StopBlocking(e.Player));
        AddEventHandler<PlayerLeavingWorldEvent>(e => StopBlocking(e.Player));
    }

    public float Block(LivingEntity entity, DamageSource source, float amount) {
        if (amount <= 0) {
            return 0;
        }

        ItemStack? blockingWith = BlockingWith(entity);
        if (blockingWith == null) {
            return 0;
        }

        BlocksAttacksComponent.Data data = BlockingItem(blockingWith)!;
        MinecraftRegistry registry = entity.Server.Registry;

        // What the item does not cover at all, which for a vanilla shield is everything that gets
        // past armour plus the fires and the falling anvils.
        if (data.BypassedBy != null && Covers(registry, data.BypassedBy, source)) {
            return 0;
        }

        float blocked = ResolveBlockedDamage(registry, data, source, amount, AngleTo(entity, source));
        HurtBlockingItem(entity, blockingWith, data, blocked);

        if (blocked <= 0) {
            return 0;
        }

        // Kept for OnBlocked, which runs once the hit is settled and may find the shield already gone,
        // broken by this hit or disabled by the axe that dealt it. Vanilla holds the same stack from the
        // top of hurtServer for the same reason.
        entity.SetTag(BlockedWithTag, data);

        // Vanilla only reaches blockUsingItem for a melee hit from something alive. The attacker's
        // blockedByItem runs first, then the Player override's disable.
        if (!source.IsIn(registry, DamageTypeTags.IsProjectile) && source.Direct is LivingEntity attacker) {
            BlockedByItem(attacker, entity, blocked >= amount);

            if (entity is Player player) {
                TryDisable(player, blockingWith, data, source);
            }
        }

        return blocked;
    }

    /// <summary>
    /// <c>LivingEntity.blockedByItem</c>: a hit the item only partly stopped pushes the blocker, a hit
    /// it stopped whole does not. The push is along the blocker minus the attacker, which
    /// <c>knockback</c> subtracts, so it is towards the attacker; that is the vanilla arithmetic. The
    /// overrides in <c>Hoglin</c>, <c>Zoglin</c> and <c>Ravager</c> are not ported, so those attackers
    /// push the same way as any other.
    /// </summary>
    private static void BlockedByItem(LivingEntity attacker, LivingEntity defender, bool fullyBlocked) {
        if (!fullyBlocked) {
            defender.Knockback(0.5, defender.Position.X - attacker.Position.X,
                defender.Position.Z - attacker.Position.Z);
        }
    }

    /// <summary>
    /// <c>BlocksAttacks.onBlocked</c>, the sound that tells everyone a hit was blocked. Core calls this
    /// only for a fresh hit, which is where vanilla's <c>tookFullDamage</c> puts it, so topping a hit up
    /// inside the invulnerable window does not sound like a second block.
    /// </summary>
    public void OnBlocked(LivingEntity entity, DamageSource source) {
        if (!entity.HasTag(BlockedWithTag)) {
            return;
        }

        BlocksAttacksComponent.Data data = entity.GetTag(BlockedWithTag);
        entity.RemoveTag(BlockedWithTag);
        PlaySound(entity, data.BlockSound, 1f);
    }

    /// <summary>
    /// Raises the item in a hand, vanilla's <c>startUsingItem</c> as <c>Item.use</c> calls it for
    /// anything carrying the component. Public because a player's client asks for this with a packet
    /// and nothing else has anything that would: no mob AI here decides to hold a shield up, so a mob
    /// blocks when something calls this.
    /// <p/>
    /// Does nothing for an item that cannot block, for a shield still disabled by an axe, or while
    /// something is already up: vanilla refuses to start using a second item the same way.
    /// </summary>
    public void StartBlocking(LivingEntity entity, Hand hand) {
        if (entity is Player { GameMode: GameMode.Spectator } || Disabled(entity) || entity.HasTag(RaisedTag)) {
            return;
        }

        ItemStack item = entity.GetItemInHand(hand);
        if (BlockingItem(item) == null) {
            return;
        }

        entity.SetTag(RaisedTag, new Raised(hand, item.Type.Identifier, entity.Server.CurrentTick));
        entity.Meta = entity.Meta with {
            HandStates = HandState.HandActive | (hand == Hand.OffHand ? HandState.ActiveHandOffhand : 0)
        };
    }

    /// <summary>
    /// Lowers whatever is up, vanilla's <c>stopUsingItem</c>. Public for the same reason
    /// <see cref="StartBlocking"/> is, and because the events this feature listens to are the ones
    /// every server has: a game that ends a round, or kills a player without taking their shield away,
    /// calls this to put the pose down.
    /// </summary>
    public static void StopBlocking(LivingEntity entity) {
        if (!entity.HasTag(RaisedTag)) {
            return;
        }

        entity.RemoveTag(RaisedTag);
        entity.Meta = entity.Meta with {
            HandStates = HandState.None
        };
    }

    /// <summary>
    /// The item the entity is blocking with, or null, i.e. <c>getItemBlockingWith</c>. Null inside the
    /// component's block delay, which is what makes a shield raised as the swing lands do nothing.
    /// </summary>
    private ItemStack? BlockingWith(LivingEntity player) {
        if (!player.HasTag(RaisedTag)) {
            return null;
        }

        Raised raised = player.GetTag(RaisedTag);
        ItemStack held = player.GetItemInHand(raised.Hand);
        BlocksAttacksComponent.Data? data = BlockingItem(held);

        // The item went somewhere without any of the events above saying so.
        if (data == null || !held.Type.Identifier.Equals(raised.Item)) {
            StopBlocking(player);
            return null;
        }

        return player.Server.CurrentTick - raised.StartTick < (ulong)data.BlockDelayTicks ? null : held;
    }

    /// <summary>
    /// <c>BlocksAttacks.resolveBlockedDamage</c>: every reduction that covers the hit's direction and
    /// damage type adds up, and none of them can block more of it than there is.
    /// </summary>
    private static float ResolveBlockedDamage(MinecraftRegistry registry, BlocksAttacksComponent.Data data,
        DamageSource source, float amount, double angle) {

        float blocked = 0;
        foreach (BlocksAttacksComponent.DamageReduction reduction in data.DamageReductions) {
            // The threshold is a float product upstream, widened only for the comparison. In double it
            // lands 4e-8 radians the other side of the arc, which is exactly where a hit from the side
            // is decided.
            if (angle > (float)(Math.PI / 180.0) * reduction.HorizontalBlockingAngle) {
                continue;
            }

            if (reduction.Type != null && !Covers(registry, reduction.Type, source)) {
                continue;
            }

            blocked += Math.Clamp(reduction.Base + reduction.Factor * amount, 0, amount);
        }

        return Math.Clamp(blocked, 0, amount);
    }

    /// <summary>
    /// How far off straight ahead the hit came from, in radians, i.e. the <c>angle</c>
    /// <c>applyItemBlocking</c> works out. A hit from nowhere in particular counts as coming from
    /// straight behind, so drowning is never blocked.
    /// <p/>
    /// Vanilla reads <c>getYHeadRot</c>. The body yaw is what that is here: a player's client reports
    /// one rotation and vanilla keeps it as both, and nothing maintains <see cref="Entity.HeadYaw"/> for
    /// anything else, which only travels in the spawn packet.
    /// </summary>
    private static double AngleTo(LivingEntity entity, DamageSource source) {
        if (source.SourcePosition is not { } position) {
            return Math.PI;
        }

        // calculateViewVector(0, yHeadRot), in floats and through the sine table, both of which are
        // vanilla's. The pitch is zero, so this is the horizontal facing.
        float yaw = (float)(-entity.Yaw.Degrees * (Math.PI / 180.0));
        Vec3<double> facing = new(Mth.Sin(yaw), 0, Mth.Cos(yaw));

        // Vec3.normalize, which gives up below a length of 1e-4 rather than at zero. That is what makes
        // a hit from the entity's own position count as ninety degrees off and so still blocked.
        Vec3<double> toSource = (position - entity.Position).WithY(0);
        double length = Math.Sqrt(toSource.X * toSource.X + toSource.Z * toSource.Z);
        toSource = length < 1.0E-4
            ? Vec3<double>.Zero
            : new Vec3<double>(toSource.X / length, 0, toSource.Z / length);

        return Math.Acos(toSource.DotProduct(facing));
    }

    /// <summary>
    /// Whether a <c>HolderSet&lt;DamageType&gt;</c> holds the hit's damage type. A tag goes through
    /// <see cref="DamageSource.IsIn"/> so it is answered from the cache the rest of the pipeline uses.
    /// </summary>
    private static bool Covers(MinecraftRegistry registry, IdSet set, DamageSource source) {
        return set switch {
            IdSet.Tag tag => source.IsIn(registry, tag.TagName),
            IdSet.Ids ids => ids.Values.Contains(registry.DamageTypes.GetProtocolId(source.Type)),
            _ => false
        };
    }

    /// <summary>
    /// <c>BlocksAttacks.hurtBlockingItem</c>. An item worn out this way breaks in the hand the way any
    /// other does, which also ends the block.
    /// </summary>
    private void HurtBlockingItem(LivingEntity entity, ItemStack item, BlocksAttacksComponent.Data data,
        float blocked) {

        // Vanilla's whole method is behind an instanceof Player, so a mob's shield never wears out.
        if (entity is not Player player || !DamageItems || item.Has(DataComponent.Unbreakable)) {
            return;
        }

        int damage = data.ItemDamage.Apply(blocked);
        int max = item.GetStructOrNull(DataComponent.MaxDamage) ?? 0;
        if (damage <= 0 || max <= 0) {
            return;
        }

        Raised raised = player.GetTag(RaisedTag);
        int current = (item.GetStructOrNull(DataComponent.Damage) ?? 0) + damage;
        if (current < max) {
            player.SetItemInHand(raised.Hand, item.With(DataComponent.Damage, current));
            return;
        }

        StopBlocking(player);
        player.SetItemInHand(raised.Hand, ItemStack.Air);

        // Nothing else tells the people watching that the hand is empty now, so the shield would stay
        // in it for them.
        player.RefreshEquipment();
        player.SendToSelfAndViewers(new ClientBoundEntityEventPacket {
            EntityId = player.NetId,
            Status = raised.Hand == Hand.OffHand
                ? ClientBoundEntityEventPacket.EntityEventType.LivingEntityOffHandBreak
                : ClientBoundEntityEventPacket.EntityEventType.LivingEntityMainHandBreak
        });
    }

    /// <summary>
    /// <c>Player.blockUsingItem</c> and <c>BlocksAttacks.disable</c>: an axe puts the shield on
    /// cooldown, and the client is told so it stops predicting a block of its own.
    /// </summary>
    private void TryDisable(Player player, ItemStack blockingWith, BlocksAttacksComponent.Data data,
        DamageSource source) {

        ItemStack? weapon = AttackerWeapon(source);
        if (weapon == null) {
            return;
        }

        // The shield broke blocking this very hit, so vanilla's getItemBlockingWith has already gone
        // null by the time it looks for something to disable.
        if (!player.HasTag(RaisedTag)) {
            return;
        }

        // getSecondsToDisableBlocking asks for the attacker's *active* item, so an axe swung while its
        // owner is holding up a shield of their own disables nothing.
        if (source.Attacker is LivingEntity attacker
            && attacker.HasTag(RaisedTag)
            && !attacker.GetTag(RaisedTag).Item.Equals(weapon.Type.Identifier)) {
            return;
        }

        float seconds = DisableSeconds(weapon) * data.DisableCooldownScale;
        int ticks = seconds > 0 ? (int)Math.Floor(seconds * 20f + 0.5f) : 0;
        if (ticks <= 0) {
            return;
        }

        player.SetTag(DisabledUntilTag, player.Server.CurrentTick + (ulong)ticks);
        player.SendPacket(new ClientBoundSetCooldownPacket {
            CooldownGroup = blockingWith.GetOrNull(DataComponent.UseCooldown)?.CooldownGroup
                            ?? blockingWith.Type.Identifier,
            Ticks = ticks
        });

        StopBlocking(player);
        PlaySound(player, data.DisableSound, 0.8f);
    }

    /// <summary>
    /// Whether an axe has the entity's shield out of use. Only a player is ever put on a cooldown, since
    /// that is <c>BlocksAttacks.disable</c> asking for one, but reading it is written for anything so
    /// that a mob handed the tag by something else is honoured rather than ignored.
    /// </summary>
    private static bool Disabled(LivingEntity entity) {
        return entity.HasTag(DisabledUntilTag) && entity.Server.CurrentTick < entity.GetTag(DisabledUntilTag);
    }

    /// <summary>
    /// The component's sounds, played the way vanilla plays them: for everyone, the blocker included,
    /// at a pitch that varies a little.
    /// <p/>
    /// The category is <c>getSoundSource</c>, which a hostile mob overrides to <c>HOSTILE</c>. That is a
    /// method on a Java class rather than anything in the data, so as with the fall and burning sounds
    /// everything that is not a player gets the base <c>NEUTRAL</c>.
    /// </summary>
    private static void PlaySound(LivingEntity entity, Or<ISoundType, SoundEvent>? sound, float volume) {
        if (sound == null) {
            return;
        }

        SoundCategory category = entity is Player ? SoundCategory.Players : SoundCategory.Neutral;
        float pitch = 0.8f + Random.Shared.NextSingle() * 0.4f;
        long seed = Random.Shared.NextInt64();
        entity.SendToSelfAndViewers(sound.IsValue1
            ? new ClientBoundSoundEffectPacket(sound.Value1!, category, entity.Position, volume, pitch, seed)
            : new ClientBoundSoundEffectPacket(sound.Value2!, category, entity.Position, volume, pitch, seed));
    }
}

using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class SkyWarsCombatFeature : ScopedFeature {
    private const int AttackCooldown = 500; // milliseconds
    
    private static readonly Tag<long> LastHitTag = new("skywars:lasthit");
    public static readonly Tag<float> DamageTag = new("skywars:damage");
    public static readonly Tag<float> KnockbackTag = new("skywars:knockback");
    public static readonly Tag<bool> SelfAttackingTag = new("skywars:selfattacking");
    public static readonly Tag<float> DamageReductionTag = new("skywars:damage_multiplier");
    public static readonly Tag<double> KnockbackReductionTag = new("skywars:knockback_multiplier");
    
    public override void Register() {
        // The armour tags reduce damage, so they belong in the pipeline rather than in the attack
        // handler below. Scoped to this feature, so only in the game world, and skipping the same
        // damage types vanilla armour does, which leaves falling and burning going straight through.
        AddDamageModifier(new DamageModifier(DamageStage.Armour, (entity, source, amount) => {
            if (entity is not Player player
                || source.IsIn(entity.Server.Registry, DamageTypeTags.BypassesArmor)) {
                return amount;
            }

            float reduction = Armour(player).Sum(piece => piece.GetTagOrDefault(DamageReductionTag, 0f));
            return amount * (1f - Math.Min(1f, reduction));
        }));

        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundAttackPacket packet) {
                return;
            }

            Entity? entity;
            Player attacker;
            try {
                entity = e.World.Entities.GetEntity(packet.EntityId);
                attacker = e.Player;
            
                if (entity == null) {
                    e.Player.SendMessage("You hit an entity that doesn't exist");
                    return;
                }
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                throw;
            }

            if (attacker.GameMode == GameMode.Spectator && entity is not Player { Name: "Michael" }) {
                return;
            }
            
            ItemStack weapon = attacker.HeldItem;
            if (weapon.GetTagOrDefault(SelfAttackingTag, false)) {
                entity = attacker;
            }
            
            // Check attack cooldown
            if (AttackCooldown != -1) {
                long lastHit = entity.GetTagOrDefault(LastHitTag, 0L);
                long time = DateTime.Now.UnixMillis();
                if (time - lastHit < AttackCooldown) {
                    // too soon
                    return;
                }
                
                entity.SetTag(LastHitTag, time);
            }
            
            float? weaponDamage = weapon.GetTagOrNull(DamageTag);
            float knockback = (float?)weapon.GetTagOrNull(KnockbackTag) ?? 0.0f; // Default knockback if not specified
            
            float damage = weaponDamage ?? 1.0f;  // Default damage if not specified
            double knockbackReduction = 0;
            
            if (entity is Player p) {
                foreach (ItemStack armourPiece in Armour(p)) {
                    SkyWarsItem? swItem = SkyWarsItemsFeature.GetItem(armourPiece);
                    swItem?.OnHitWhileWearing(p, attacker);

                    knockbackReduction += armourPiece.GetTagOrDefault(KnockbackReductionTag, 0.0);
                }
            }

            // The hurt sound and the red flash both ride on the damage event packet this sends, and
            // the armour reduction is applied by the modifier registered above.
            if (entity is LivingEntity le) {
                le.Damage(new DamageSource(DamageType.PlayerAttack) {
                    Attacker = attacker,
                    // Both, the way vanilla's one entity constructor does. The direct entity is where
                    // the hit came from, which is what a shield needs to know to block it.
                    Direct = attacker,
                    Weapon = weapon
                }, damage);
            }

            entity.Velocity = attacker.Direction
                .Multiply(0.90 + knockback * 0.3)
                .WithY(0.4)
                .Multiply(1 - knockbackReduction);  // Original 2.0 GOOD
        });
    }

    private static ItemStack[] Armour(Player player) => [
        player.Inventory.Helmet,
        player.Inventory.Chestplate,
        player.Inventory.Leggings,
        player.Inventory.Boots
    ];
}

using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class SkyWarsCombatFeature(Action<PlayerEntity> deathCallback) : ScopedFeature {
    private const int AttackCooldown = 500; // milliseconds
    
    private static readonly Tag<long> LastHitTag = new("skywars:lasthit");
    public static readonly Tag<float> DamageTag = new("skywars:damage");
    public static readonly Tag<float> KnockbackTag = new("skywars:knockback");
    public static readonly Tag<bool> SelfAttackingTag = new("skywars:selfattacking");
    
    public override void Register() {
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundInteractPacket packet) {
                return;
            }

            if (packet.Type != ServerBoundInteractPacket.InteractType.Attack) {
                return;
            }

            Entity? entity;
            PlayerEntity attacker;
            try {
                entity = e.World.Entities.GetEntityById(packet.EntityId);
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
            
            float damage = weaponDamage ?? 1.0f;  // Default damage if not specified
            float knockback = (float?)weapon.GetTagOrNull(KnockbackTag) ?? 0.0f; // Default knockback if not specified

            if (entity is LivingEntity le) {
                le.Damage(damage);
                if (le.Health <= 0 && le is PlayerEntity pe) {
                    // death
                    deathCallback(pe);
                }
            }
            
            if (entity is PlayerEntity p) {
                p.SetVelocity(attacker.Direction.Multiply(0.90 + knockback * 0.3).WithY(0.4));  // Original 2.0 GOOD
                p.PlaySound(SoundType.PlayerHurt, entity, SoundCategory.Players);
            }
            else {
                e.Player.SendMessage("Entity is not player");
            }
            
            entity.GetAudience().PlaySound(SoundType.PlayerHurt, entity, SoundCategory.Players);
            entity.Hurt();
        });
    }
}

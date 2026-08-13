using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;

namespace ManagedServer.Features.Impl;

public class SimpleCombatFeature(int attackCooldown = -1, float damage = 0) : ScopedFeature {
    private readonly Tag<long> _lastHitTag = new("minecraftdotnet:simplecombat:lasthit");
    
    public override void Register() {
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
            
            
            // Check attack cooldown
            if (attackCooldown != -1) {
                long lastHit = entity.GetTagOrDefault(_lastHitTag, 0L);
                long time = DateTime.Now.UnixMillis();
                if (time - lastHit < attackCooldown) {
                    // too soon
                    return;
                }
                
                entity.SetTag(_lastHitTag, time);
            }

            // The hurt sound and the red flash both ride on the damage event packet Damage sends, so
            // there is nothing to play here beyond the swing itself.
            if (entity is LivingEntity le) {
                le.Damage(new DamageSource(DamageType.PlayerAttack) {
                    Attacker = attacker,
                    Direct = attacker,
                    // What the hit was dealt with, which is what ShieldFeature reads to decide whether
                    // it takes the shield away and what ArmourFeature reads for the enchantments on it.
                    Weapon = attacker.HeldItem
                }, damage);
            }

            if (entity is Player p) {
                // p.SetVelocity(attacker.Direction.Multiply(0.5) with { Y = 0.5 });  // Original
                p.SetVelocity(attacker.Direction.Multiply(0.60).WithY(0.5));  // Original 2.0 GOOD
                p.SetVelocity(attacker.Direction.Multiply(0.90).WithY(0.4));  // Original 2.0 GOOD
                // p.SetVelocity(attacker.Direction.Multiply(0.8) with { Y = 0.35 });  // adam tweak
                // p.SetVelocity(attacker.Direction.Multiply(1) with { Y = 1 });  // dumb
            }
        });
    }
}

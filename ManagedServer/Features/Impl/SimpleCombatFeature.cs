using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Sound;

namespace ManagedServer.Features.Impl;

public class SimpleCombatFeature(int attackCooldown = -1, float damage = 0) : ScopedFeature {
    private readonly Tag<long> _lastHitTag = new("minecraftdotnet:simplecombat:lasthit");
    
    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundInteractPacket packet) {
                return;
            }

            if (packet.Type != ServerBoundInteractPacket.InteractType.Attack) {
                return;
            }

            Entity? entity;
            PlayerEntity attacker;
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

            MinecraftPacket soundPacket = new ClientBoundEntitySoundEffectPacket {
                Category = SoundCategory.Players,
                EntityId = entity.NetId,
                Type = SoundType.PlayerHurt, // sound id for "player.attack"
                Volume = 1f,
                Pitch = 1f,
                Seed = 0L
            };

            if (entity is LivingEntity le) {
                le.Damage(damage);
            }
            
            if (entity is PlayerEntity p) {
                // p.SetVelocity(attacker.Direction.Multiply(0.5) with { Y = 0.5 });  // Original
                p.SetVelocity(attacker.Direction.Multiply(0.60).WithY(0.5));  // Original 2.0 GOOD
                p.SetVelocity(attacker.Direction.Multiply(0.90).WithY(0.4));  // Original 2.0 GOOD
                // p.SetVelocity(attacker.Direction.Multiply(0.8) with { Y = 0.35 });  // adam tweak
                // p.SetVelocity(attacker.Direction.Multiply(1) with { Y = 1 });  // dumb
                p.Connection.SendPacket(soundPacket);
            }
            else {
                e.Player.SendMessage("Entity is not player");
            }
            
            e.World.Entities.SendPacketsToViewers(entity, soundPacket);
            entity.Hurt();
        });
    }
}

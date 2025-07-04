using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Sound;

namespace ManagedServer.Features;

public class SimpleCombatFeature(int attackCooldown = -1) : IWorldFeature {
    private readonly Tag<long> _lastHitTag = new("minecraftdotnet:simplecombat:lasthit");
    
    public void Register(World world) {
        world.Events.AddListener<PacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundInteractPacket packet) {
                return;
            }

            if (packet.Type != ServerBoundInteractPacket.InteractType.Attack) {
                return;
            }

            Entity? entity;
            PlayerEntity attacker;
            try {
                entity = world.Entities.GetEntityById(packet.EntityId);
                attacker = (PlayerEntity)world.Entities.Entities.Single(en => 
                    en is PlayerEntity pl && 
                    pl.Connection == e.Connection);
            
                if (entity == null) {
                    e.Connection.SendSystemMessage("You hit an entity that doesn't exist");
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
                Id = 1149, // sound id for "player.attack"
                Volume = 1f,
                Pitch = 1f,
                Seed = 0L
            };
            
            if (entity is PlayerEntity p) {
                // p.SetVelocity(attacker.Direction.Multiply(0.5) with { Y = 0.5 });  // Original
                p.SetVelocity(attacker.Direction.Multiply(0.60) with { Y = 0.5 });  // Original 2.0
                // p.SetVelocity(attacker.Direction.Multiply(0.8) with { Y = 0.35 });  // adam tweak
                // p.SetVelocity(attacker.Direction.Multiply(1) with { Y = 1 });  // dumb
                p.Connection.SendPacket(soundPacket);
            }
            else {
                e.Connection.SendSystemMessage("Entity is not player");
            }
            
            world.Entities.SendPacketsFor(entity, soundPacket);
            entity.Hurt();
        });
    }
    
    public void Unregister() {
        
    }

    public Type[] GetDependencies() {
        return [];
    }
}
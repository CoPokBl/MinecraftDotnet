using Minecraft.Implementations.Server.Entities;
using Minecraft.Implementations.Server.Events;
using Minecraft.NBT.Text;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Sound;

namespace Minecraft.Implementations.Server.Features;

public class SimpleCombatFeature(int attackCooldown = -1) : IFeature {
    private const string LastHitTag = "minecraftdotnet:simplecombat:lasthit";
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundInteractPacket packet) {
                return;
            }

            if (packet.Type != ServerBoundInteractPacket.InteractType.Attack) {
                return;
            }

            SimpleEntitiesFeature entities = server.Feature<SimpleEntitiesFeature>()!;
            
            Entity? entity = entities.GetEntityById(packet.EntityId);
            PlayerEntity attacker = (PlayerEntity)entities.Entities.Single(en => 
                en is PlayerEntity pl && 
                pl.Connection == e.Connection);
            
            if (entity == null) {
                e.Connection.SendPacket(
                    new ClientBoundSystemChatMessagePacket(TextComponent.Text("You hit an entity that doesn't exist"),
                        true));
                return;
            }
            
            // Check attack cooldown
            if (attackCooldown != -1) {
                long lastHit = (long)entity.Data.GetValueOrDefault(LastHitTag, 0L)!;
                long time = DateTime.Now.UnixMillis();
                if (time - lastHit < attackCooldown) {
                    // too soon
                    return;
                }
                
                entity.Data[LastHitTag] = time;
            }

            MinecraftPacket soundPacket = new ClientBoundEntitySoundEffectPacket(1149, SoundCategory.Players,
                entity.NetId, 1f, 1f, 0);
            
            if (entity is PlayerEntity p) {
                // p.SetVelocity(attacker.Direction.Multiply(0.5) with { Y = 0.5 });  // Original
                p.SetVelocity(attacker.Direction.Multiply(0.60) with { Y = 0.5 });  // Original 2.0
                // p.SetVelocity(attacker.Direction.Multiply(0.8) with { Y = 0.35 });  // adam tweak
                // p.SetVelocity(attacker.Direction.Multiply(1) with { Y = 1 });  // dumb
                p.Connection.SendPacket(soundPacket);
            }
            
            entities.SendPacketsFor(entity, soundPacket);
            entity.Hurt();
        });
    }

    public Type[] GetDependencies() {
        return [typeof(SimpleEntitiesFeature)];
    }
}
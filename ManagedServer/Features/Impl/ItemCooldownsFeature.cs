using ManagedServer.Events;
using Minecraft;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace ManagedServer.Features.Impl;

public class ItemCooldownsFeature : ScopedFeature {
    private static readonly Tag<Dictionary<Identifier, DateTime>> CooldownsTag = new("managedserver:itemcooldowns");
    
    public override void Register() {
        AddEventMutator<PlayerUseItemEvent>(e => {
            if (!e.Item.Has(DataComponent.UseCooldown)) {
                return;
            }
            
            UseCooldownComponent.Data cooldownData = e.Item.Get(DataComponent.UseCooldown);
            Identifier ident = cooldownData.CooldownGroup ?? e.Item.Type.Identifier;

            Dictionary<Identifier, DateTime> cooldowns = e.Player.GetTagOrDefault(CooldownsTag, []);

            DateTime lastUsed = cooldowns.GetValueOrDefault(ident, DateTime.MinValue);
            if (DateTime.UtcNow < lastUsed + TimeSpan.FromSeconds(cooldownData.Seconds)) {
                // Prevent item use if cooldown is still active
                e.Cancelled = true;
                return;
            }
            
            // Update the cooldown timestamp
            cooldowns[ident] = DateTime.UtcNow;
            e.Player.SetTag(CooldownsTag, cooldowns);
            
            // Send the cooldown packet
            e.Player.SendPacket(new ClientBoundSetCooldownPacket {
                CooldownGroup = e.Item.Type.Identifier,
                Ticks = (int)(cooldownData.Seconds * 20)
            });
        });
    }
}

using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Inventory;
using Minecraft.Implementations.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Attributes;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class AttributeModifiersFeature : ScopedFeature {
    public static readonly Tag<Modifier[]> AttributeModifiersTag = new("skywars:attribute_modifiers");

    public record Modifier(Identifier Attribute, double Amount, Identifier Id, AttributeOperation Operation) {
        
        public AttributeModifier ToAttributeModifier() {
            return new AttributeModifier(Id, Amount, Operation);
        }
    }
    
    public override void Register() {
        AddEventListener<InventoryChangeEvent>(e => {
            if (e.Inventory is not PlayerInventory inventory) {
                return;
            }
            
            int[] armourSlots = [
                PlayerInventory.HelmetSlot,
                PlayerInventory.ChestplateSlot,
                PlayerInventory.LeggingsSlot,
                PlayerInventory.BootsSlot
            ];
            if (!armourSlots.Contains(e.Slot)) {
                return;
            }

            if (e.NewItem.HasTag(AttributeModifiersTag)) {
                Modifier[] modifiers = e.NewItem.GetTag(AttributeModifiersTag);
                foreach (Modifier modifier in modifiers) {
                    inventory.Owner.RemoveAttributeModifier(Scope.Server.Registry.Attributes[modifier.Attribute], modifier.Id);
                    inventory.Owner.AddAttributeModifier(Scope.Server.Registry.Attributes[modifier.Attribute], modifier.ToAttributeModifier());
                }
            }
            
            if (e.PreviousItem.HasTag(AttributeModifiersTag)) {
                Modifier[] modifiers = e.PreviousItem.GetTag(AttributeModifiersTag);
                foreach (Modifier modifier in modifiers) {
                    inventory.Owner.RemoveAttributeModifier(Scope.Server.Registry.Attributes[modifier.Attribute], modifier.Id);
                }
            }
        });
    }
}

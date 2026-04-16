using Minecraft;
using Minecraft.Data.Entities;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Entities.Types;

public class LivingEntity(IEntityType type, LivingEntityMeta? meta = null) 
    : Entity(type, meta ?? new LivingEntityMeta()) {
    public float Health {
        get;
        set {
            field = value;
            Meta = Meta with {
                Health = value
            };
            SendHealthUpdate();
        }
    } = 20f;

    public int Food {
        get;
        set {
            field = value;
            SendHealthUpdate();
        }
    } = 20;

    public float Saturation {
        get;
        set {
            field = value;
            SendHealthUpdate();
        }
    } = 20f;

    private Dictionary<EquipmentSlot, ItemStack> _equipment = [];
    
    public new LivingEntityMeta Meta {
        get => (LivingEntityMeta)base.Meta;
        set => base.Meta = value;
    }

    public void Damage(float damage) {
        Hurt();
        Health = Math.Max(0, Health - damage);
    }

    public void Heal(float amount = -1) {
        float maxHealth = (float)GetAttributeValue(Attribute.MaxHealth);
        if (Math.Abs(amount - -1) < 0.01) {
            amount = maxHealth;
        }
        Health = Math.Min(maxHealth, Health + amount);
    }
    
    protected void SendHealthUpdate() {
        SendToSelf(new ClientBoundSetHealthPacket {
            Health = Health,
            Food = Food,
            Saturation = Saturation
        });
    }
    
    public void SetEquipmentItem(EquipmentSlot slot, ItemStack item) {
        _equipment[slot] = item;

        SendToViewers(new ClientBoundSetEquipmentPacket {
            EntityId = NetId,
            Equipment = new Dictionary<EquipmentSlot, ItemStack> {
                { slot, item }
            }
        });
    }
    
    public ItemStack GetEquipmentItem(EquipmentSlot slot) {
        return _equipment.TryGetValue(slot, out ItemStack? item) ? item : ItemStack.Air;
    }

    public override MinecraftPacket[] GenerateSpawnEntityPackets() {
        if (_equipment.Count == 0) {  // If no equipment, just return the base packets
            return base.GenerateSpawnEntityPackets();
        }
        
        MinecraftPacket[] arr = [
            new ClientBoundSetEquipmentPacket {
                EntityId = NetId,
                Equipment = _equipment
            }
        ];
        return arr.Combine(base.GenerateSpawnEntityPackets()).ToArray();
    }
}

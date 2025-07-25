using Minecraft;
using Minecraft.Data.Entities;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;

namespace ManagedServer.Entities.Types;

public class LivingEntity(IEntityType type, LivingEntityMeta? meta = null) 
    : Entity(type, meta ?? new LivingEntityMeta()) {
    
    public float Health {
        get => _health;
        set {
            _health = value;
            Meta = Meta with {
                Health = value
            };
            SendHealthUpdate();
        }
    }

    public int Food {
        get => _food;
        set {
            _food = value;
            SendHealthUpdate();
        }
    }
    
    public float Saturation {
        get => _saturation;
        set {
            _saturation = value;
            SendHealthUpdate();
        }
    }

    private float _health = 20f;
    private int _food = 20;
    private float _saturation = 20f;
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
        const float maxHealth = 20f;  // TODO: Actually get this value
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

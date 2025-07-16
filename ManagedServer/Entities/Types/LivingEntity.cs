using Minecraft.Data.Entities;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Entities.Meta.Types;

namespace ManagedServer.Entities.Types;

public class LivingEntity : Entity {
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
    
    public new LivingEntityMeta Meta {
        get => (LivingEntityMeta)base.Meta;
        set => base.Meta = value;
    }
    
    public LivingEntity(IEntityType type, EntityMeta? meta = null) : base(type, meta ?? new LivingEntityMeta()) {
        if (meta is not null and not LivingEntityMeta) {
            throw new ArgumentException("Meta must be of type LivingEntityMeta", nameof(meta));
        }
    }

    public void Damage(float damage) {
        Hurt();
        Health = Math.Max(0, Health - damage);
    }
    
    protected void SendHealthUpdate() {
        SendToSelf(new ClientBoundSetHealthPacket {
            Health = Health,
            Food = Food,
            Saturation = Saturation
        });
    }
}

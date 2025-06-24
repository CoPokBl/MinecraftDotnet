using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundInteractPacket : ServerBoundPacket {
    public required int EntityId;
    public required InteractType Type;
    public FVec3? Target;
    public Hand? UsedHand;
    public required bool SneakPressed;

    public static ServerBoundInteractPacket Attack(int entityId, bool sneakPressed) {
        return new ServerBoundInteractPacket {
            EntityId = entityId,
            SneakPressed = sneakPressed,
            Type = InteractType.Attack,
            Target = null,
            UsedHand = null
        };
    }
    
    public static ServerBoundInteractPacket Interact(int entityId, Hand hand, bool sneakPressed) {
        return new ServerBoundInteractPacket {
            EntityId = entityId,
            Type = InteractType.Interact,
            Target = null,
            UsedHand = hand,
            SneakPressed = sneakPressed
        };
    }
    
    public static ServerBoundInteractPacket InteractAt(int entityId, FVec3 target, Hand hand, bool sneakPressed) {
        return new ServerBoundInteractPacket {
            EntityId = entityId,
            Type = InteractType.InteractAt,
            Target = target,
            UsedHand = hand,
            SneakPressed = sneakPressed
        };
    }

    public enum InteractType {
        Interact = 0,
        Attack = 1,
        InteractAt = 2
    }

    protected override byte[] GetData() {
        DataWriter w = new DataWriter()
            .WriteVarInt(EntityId)
            .WriteVarInt((int)Type);

        switch (Type) {
            case InteractType.Interact:
                w.WriteVarInt((int)UsedHand.ThrowIfNull());
                break;
            
            case InteractType.InteractAt:
                w.WriteVec3(Target.ThrowIfNull());
                w.WriteVarInt((int)UsedHand.ThrowIfNull());
                break;
        }
        
        return w
            .WriteBoolean(SneakPressed)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => {
        int entityId = r.ReadVarInt();
        InteractType type = (InteractType)r.ReadVarInt();
        FVec3? target = null;
        Hand? usedHand = null;
        if (type == InteractType.InteractAt) {
            target = r.ReadFVec3();
        }
        if (type is InteractType.Interact or InteractType.InteractAt) {
            usedHand = (Hand)r.ReadVarInt();
        }
        bool sneakPressed = r.ReadBoolean();
        
        return new ServerBoundInteractPacket {
            EntityId = entityId,
            Type = type,
            Target = target,
            UsedHand = usedHand,
            SneakPressed = sneakPressed
        };
    };
}

using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundInteractPacket(int entityId, ServerBoundInteractPacket.InteractType type, FVec3? target, Hand? hand, bool sneakPressed) : MinecraftPacket {
    public int EntityId = entityId;
    public InteractType Type = type;
    public FVec3? Target = target;
    public Hand? UsedHand = hand;
    public bool SneakPressed = sneakPressed;

    public ServerBoundInteractPacket() : this(0, InteractType.Attack, null, null, false) { }

    public static ServerBoundInteractPacket Attack(int entityId, bool sneakPressed) {
        return new ServerBoundInteractPacket(entityId, InteractType.Attack, null, null, sneakPressed);
    }
    
    public static ServerBoundInteractPacket Interact(int entityId, Hand hand, bool sneakPressed) {
        return new ServerBoundInteractPacket(entityId, InteractType.Interact, null, hand, sneakPressed);
    }
    
    public static ServerBoundInteractPacket InteractAt(int entityId, FVec3 target, Hand hand, bool sneakPressed) {
        return new ServerBoundInteractPacket(entityId, InteractType.InteractAt, target, hand, sneakPressed);
    }

    public enum InteractType {
        Interact = 0,
        Attack = 1,
        InteractAt = 2
    }

    public override int GetPacketId() {
        return 0x18;
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

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        Type = (InteractType)r.ReadVarInt();

        if (Type == InteractType.InteractAt) {
            Target = r.ReadFVec3();
        }

        if (Type is InteractType.Interact or InteractType.InteractAt) {
            UsedHand = (Hand)r.ReadVarInt();
        }
        
        SneakPressed = r.ReadBoolean();
        return this;
    }
}
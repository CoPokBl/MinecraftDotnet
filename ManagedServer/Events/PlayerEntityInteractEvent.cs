using ManagedServer.Entities.Types;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

public class PlayerEntityInteractEvent : IServerEvent {
    public required Entity Target;
    public required PlayerEntity Player;
    public required ServerBoundInteractPacket.InteractType Type;
    public FVec3? TargetLocation;
    public Hand? UsedHand;
    public required bool SneakPressed;
}
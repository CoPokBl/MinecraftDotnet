using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Features;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Entities;

public class Entity(int type) {
    public Guid Uuid = Guid.NewGuid();
    public int Type = type;
    public Vec3 Position = Vec3.Zero;
    public Angle Pitch = Angle.Zero;
    public Angle Yaw = Angle.Zero;
    public Angle HeadYaw = Angle.Zero;
    public Func<PlayerConnection, bool> ViewableRule { get; set; } = _ => true;
    
    public int NetId;  // should be set by an entity tracker
    public SimpleEntitiesFeature Feat;

    public virtual MinecraftPacket[] GenerateSpawnEntityPackets() {
        return [new ClientBoundSpawnEntityPacket(NetId, Uuid, Type, Position, Pitch, Yaw, HeadYaw, 0, SVec3.Zero)];
    }

    public void Move(Vec3 newPos, Angle? yaw = null, Angle? pitch = null) {
        Feat.MoveEntity(this, newPos, yaw, pitch);
        Position = newPos;

        if (yaw != null) {
            Yaw = yaw.Value;
        }

        if (pitch != null) {
            Pitch = pitch.Value;
        }
    }

    public void SendToViewers(params MinecraftPacket[] packets) {
        Feat.SendPacketsFor(this, packets);
    }
}

using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Entities.Events;
using Minecraft.Implementations.Server.Events;
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
    public EventNode<ServerEvent> Events = new();
    public readonly Dictionary<string, object?> Data = new();
    
    public int NetId;  // should be set by an entity tracker
    public SimpleEntitiesFeature? Feat;

    /// <summary>
    /// A unit vector pointing in the direction that the player is facing.
    /// </summary>
    public Vec3 Direction {
        get {
            double rotX = Yaw.Radians;
            double rotY = Pitch.Radians;
            double xz = Math.Cos(rotY);
            return new Vec3(-xz * Math.Sin(rotX), -Math.Sin(rotY), xz * Math.Cos(rotX));
        }
    }

    public virtual MinecraftPacket[] GenerateSpawnEntityPackets() {
        return [new ClientBoundSpawnEntityPacket(NetId, Uuid, Type, Position, Pitch, Yaw, HeadYaw, 0, SVec3.Zero)];
    }

    /// <summary>
    /// Apply server side movement to entity.
    /// </summary>
    /// <param name="newPos">Their new position.</param>
    /// <param name="yaw">Their new yaw.</param>
    /// <param name="pitch">Their new pitch.</param>
    public void Move(Vec3 newPos, Angle? yaw = null, Angle? pitch = null) {
        EntityMoveEvent e = new() {
            Entity = this,
            NewPos = newPos
        };
        Events.CallEvent(e);
        
        Feat?.MoveEntity(this, newPos, yaw, pitch);
        Position = newPos;

        if (yaw != null) {
            Yaw = yaw.Value;
        }

        if (pitch != null) {
            Pitch = pitch.Value;
        }
    }

    public virtual void Teleport(PlayerPosition pos) {
        Move(pos.Position, pos.Yaw, pos.Pitch);
    }

    public virtual void Teleport(Vec3 pos, Angle? yaw = null, Angle? pitch = null) {
        Move(pos, yaw, pitch);
    }

    /// <summary>
    /// Play the hurt animation. (Flash red)
    /// </summary>
    public void Hurt() {
        SendToViewers(new ClientBoundHurtAnimationPacket(NetId, Angle.Zero));
    }
    
    /// <summary>
    /// Method that can be overriden for players.
    /// </summary>
    /// <param name="packets">The packets to send.</param>
    public virtual void SendToSelfAndViewers(params MinecraftPacket[] packets) {
        SendToViewers(packets);
    }

    public void SendToViewers(params MinecraftPacket[] packets) {
        Feat?.SendPacketsFor(this, packets);
    }
}

using System.Diagnostics;
using ManagedServer.Events;
using ManagedServer.Events.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Entities;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities.Types;

public class Entity(IEntityType type) : IViewable, ITaggable, IFeatureScope {
    public Guid Uuid = Guid.NewGuid();
    public readonly IEntityType Type = type;
    public Vec3 Position = Vec3.Zero;
    public Angle Pitch = Angle.Zero;
    public Angle Yaw = Angle.Zero;
    public Angle HeadYaw = Angle.Zero;

    private Func<PlayerConnection, bool> _viewableRule = _ => true;
    public Func<PlayerConnection, bool> ViewableRule {
        get => _viewableRule;
        set {
            _viewableRule = value;
            UpdateViewers();
        }
    }

    public EventNode<IServerEvent> Events { get; } = new();
    public virtual List<PlayerEntity> Players => [];
    public readonly Dictionary<string, object?> Data = new();

    private bool _crouching;
    public bool Crouching {
        get => _crouching;

        set {
            if (_crouching == value) {
                return;
            }
            
            Manager?.SetEntityCrouching(this, value);
            _crouching = value;
        }
    }
    
    // these should be set by an entity tracker
    // not doing so is unsupported and will cause issues.
    public int NetId;
    public EntityManager? Manager;
    public World? World;

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
        return [new ClientBoundSpawnEntityPacket {
            EntityType = Type,
            Uuid = Uuid,
            Id = NetId,
            Position = Position,
            Pitch = Pitch,
            Yaw = Yaw,
            HeadYaw = HeadYaw,
            Data = 0,
            Velocity = SVec3.Zero
        }];
    }

    /// <summary>
    /// Apply server side movement to entity.
    /// </summary>
    /// <param name="newPos">Their new position.</param>
    /// <param name="yaw">Their new yaw.</param>
    /// <param name="pitch">Their new pitch.</param>
    /// <param name="forceTeleport">Whether to force this method to use the Teleport packet.</param>
    public void Move(Vec3 newPos, Angle? yaw = null, Angle? pitch = null, bool forceTeleport = false) {
        EntityMoveEvent e = new() {
            Entity = this,
            NewPos = newPos,
            World = World!
        };
        Events.CallEvent(e);

        if (forceTeleport) {
            Manager?.TeleportEntity(this, newPos, yaw ?? Angle.Zero, pitch ?? Angle.Zero);
        }
        else Manager?.MoveEntity(this, newPos, yaw, pitch);
        Position = newPos;

        if (yaw != null) {
            Yaw = yaw.Value;
        }

        if (pitch != null) {
            Pitch = pitch.Value;
        }
    }
    
    public void RegisterFeature(ScopedFeature feature) {
        feature.Scope = this;
        feature.Register();
    }

    public void Teleport(PlayerPosition pos) {
        Teleport(pos.Position, pos.Yaw, pos.Pitch);
    }

    public virtual void Teleport(Vec3 pos, Angle? yaw = null, Angle? pitch = null) {
        Move(pos, yaw, pitch, true);
    }

    public virtual void SetWorld(World world) {
        Manager?.BaseEventNode.RemoveChild(Events);

        World?.Entities.Despawn(this);
        world.Entities.Spawn(this, NetId);  // this ensures that Manager will not be null (it sets it)
        World = world;

        Debug.Assert(Manager != null, nameof(Manager) + " != null");
        Manager!.BaseEventNode.AddChild<IEntityEvent>(Events, ee => ee.Entity == this);
    }

    public void Despawn() {
        Manager!.BaseEventNode.RemoveChild(Events);
        Manager.Despawn(this);
        Manager = null;
        World = null;
    }

    /// <summary>
    /// Play the hurt animation. (Flash red)
    /// </summary>
    public void Hurt() {
        SendToSelfAndViewers(new ClientBoundHurtAnimationPacket {
            EntityId = NetId,
            Yaw = Angle.Zero
        });
    }
    
    /// <summary>
    /// Method that can be overriden for players.
    /// </summary>
    /// <param name="packets">The packets to send.</param>
    public virtual void SendToSelfAndViewers(params MinecraftPacket[] packets) {
        SendToViewers(packets);
    }

    public void SendToViewers(params MinecraftPacket[] packets) {
        Manager?.SendPacketsFor(this, packets);
    }
    
    public void UpdateViewers() {
        if (Manager == null) {
            return;
        }
        
        
    }

    public PlayerEntity[] GetViewers() {
        return Manager?.GetViewersOf(this) ?? [];
    }
    
    public T GetTag<T>(Tag<T> tag) {
        return (T)Data[tag.Id]!;
    }

    public bool HasTag<T>(Tag<T> tag) {
        return Data.ContainsKey(tag.Id);
    }

    public void SetTag<T>(Tag<T> tag, T value) {
        Data[tag.Id] = value;
    }
}

using System.Diagnostics;
using ManagedServer.Events;
using ManagedServer.Events.Types;
using ManagedServer.Features;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Shapes;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities.Types;

public class Entity : MappedTaggable, IViewable, IFeatureScope {
    public Guid Uuid = Guid.NewGuid();
    public readonly IEntityType Type;
    public Vec3<double> Position = Vec3<double>.Zero;
    public Angle Pitch = Angle.Zero;
    public Angle Yaw = Angle.Zero;
    public Angle HeadYaw = Angle.Zero;
    
    public Aabb BoundingBox { get; init; }

    private Func<PlayerEntity, bool> _viewableRule = _ => true;
    public Func<PlayerEntity, bool> ViewableRule {
        get => _viewableRule;
        set {
            _viewableRule = value;
            UpdateViewers();
        }
    }

    public EntityMeta Meta {
        get => _meta;
        set {
            _meta = value;
            SendToSelfAndViewers(new ClientBoundSetEntityMetadataPacket {
                EntityId = NetId,
                Meta = _meta
            });
        }
    }
    
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

    private Vec3<double> _lastVelocity = Vec3<double>.Zero;
    public virtual Vec3<double> Velocity { get; set; } = Vec3<double>.Zero;  // units: m/(1/20)s
    
    public bool OnGround { get; set; }

    public virtual List<PlayerEntity> Players => [];  // for ScopedFeature
    public ManagedMinecraftServer Server => World.ThrowIfNull().Server;
    public FeatureHandler FeatureHandler { get; }
    public EventNode<IServerEvent> Events { get; } = new();
    
    // these should be set by an entity tracker
    // not doing so is unsupported and will cause issues.
    public int NetId = -1;
    public EntityManager? Manager;
    public World? World;
    
    private EntityMeta _meta = null!;  // set by the constructor, so it is never null
    private bool _crouching;

    public Entity(IEntityType type, EntityMeta? meta = null) {
        Type = type;
        FeatureHandler = new FeatureHandler(this);
        
        BoundingBox = new Aabb(new Vec3<double>(Type.Width * -0.5, 0.0, Type.Height * -0.5), new Vec3<double>(Type.Width, Type.Height, Type.Width));

        if (meta == null) {
            // guess the meta type based on the entity type
            if (type.Identifier == EntityType.Player.Identifier) {
                Meta = new PlayerMeta();
            } else if (type.Identifier == EntityType.Arrow.Identifier) {
                Meta = new ArrowMeta();
            } else if (type.Identifier == EntityType.AreaEffectCloud.Identifier) {
                Meta = new AreaEffectCloudMeta();
            } else if (type.Identifier == EntityType.FallingBlock.Identifier) {
                Meta = new FallingBlockMeta();
            } else if (type.Identifier == EntityType.Item.Identifier) {
                Meta = new ItemMeta();
            } else if (type.Identifier == EntityType.Painting.Identifier) {
                Meta = new PaintingMeta();
            } else if (type.Identifier == EntityType.EndCrystal.Identifier) {
                Meta = new EndCrystalMeta();
            } else if (type.Identifier == EntityType.ExperienceOrb.Identifier) {
                Meta = new ExperienceOrbMeta();
            } else if (type.Identifier == EntityType.EyeOfEnder.Identifier) {
                Meta = new EyeOfEnderMeta();
            } else if (type.Identifier == EntityType.Fireball.Identifier) {
                Meta = new FireballMeta();
            } else if (type.Identifier == EntityType.FireworkRocket.Identifier) {
                Meta = new FireworkRocketMeta();
            } else if (type.Identifier == EntityType.FishingBobber.Identifier) {
                Meta = new FishingBobberMeta();
            } else if (type.Identifier == EntityType.Interaction.Identifier) {
                Meta = new InteractionMeta();
            } else if (type.Identifier == EntityType.ItemFrame.Identifier) {
                Meta = new ItemFrameMeta();
            } else if (type.Identifier == EntityType.Item.Identifier) {
                Meta = new ItemMeta();
            } else {
                Meta = new EntityMeta();
            }
        }
        else {
            Meta = meta;
        }

        Events.AddListener<ServerTickEvent>(_ => Tick());
    }

    /// <summary>
    /// A unit vector pointing in the direction that the player is facing.
    /// </summary>
    public Vec3<double> Direction {
        get {
            double rotX = Yaw.Radians;
            double rotY = Pitch.Radians;
            double xz = Math.Cos(rotY);
            return new Vec3<double>(-xz * Math.Sin(rotX), -Math.Sin(rotY), xz * Math.Cos(rotX));
        }
    }

    protected void Tick() {
        // Check for changed properties
        if (_lastVelocity != Velocity) {
            SendToViewers(new ClientBoundSetEntityVelocityPacket {  // protocol velocity is in 8000ths of a block per tick (50ms)
                EntityId = NetId,
                Velocity = new Vec3<short>((short)(Velocity.X * 8000), (short)(Velocity.Y * 8000), (short)(Velocity.Z * 8000)),
            });
            _lastVelocity = Velocity;
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
            Velocity = Vec3<short>.Zero
        }, new ClientBoundSetEntityMetadataPacket {
            EntityId = NetId,
            Meta = Meta
        }];
    }

    /// <summary>
    /// Apply server side movement to entity.
    /// </summary>
    /// <param name="newPos">Their new position.</param>
    /// <param name="yaw">Their new yaw.</param>
    /// <param name="pitch">Their new pitch.</param>
    /// <param name="forceTeleport">Whether to force this method to use the Teleport packet.</param>
    public void Move(Vec3<double> newPos, Angle? yaw = null, Angle? pitch = null, bool forceTeleport = false) {
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

    public void Teleport(PlayerPosition pos) {
        Teleport(pos.Position, pos.Yaw, pos.Pitch);
    }

    public virtual void Teleport(Vec3<double> pos, Angle? yaw = null, Angle? pitch = null) {
        Move(pos, yaw, pitch, true);
    }

    public virtual void SetWorld(World world) {
        Manager?.BaseEventNode.RemoveChild(Events);

        World?.Entities.Despawn(this);
        world.Entities.Spawn(this, NetId == -1 ? null : NetId);  // this ensures that Manager will not be null (it sets it)
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
    public virtual void SendToSelf(params MinecraftPacket[] packets) {
        
    }
    
    
    public void SendToSelfAndViewers(params MinecraftPacket[] packets) {
        SendToViewers(packets);
        SendToSelf(packets);
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
}

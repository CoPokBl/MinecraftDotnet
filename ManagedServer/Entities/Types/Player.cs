using System.Collections.Concurrent;
using ManagedServer.Events;
using ManagedServer.Interaction;
using ManagedServer.Inventories;
using ManagedServer.Permissions;
using ManagedServer.Permissions.ContainerImpl;
using ManagedServer.Physics;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Attributes;
using Minecraft.Data.Generated;
using Minecraft.Implementations;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Attributes;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Entities.Types;

/// <summary>
/// Entity that represents a player and is controlled by a <see cref="PlayerConnection"/>.
/// </summary>
public class Player : LivingEntity, IAudience, IPermissionHolder {
    public readonly string Name;
    public readonly PlayerConnection Connection;
    public readonly PlayerInventory Inventory;

    /// <summary>The feature scope of a single player, which is themselves.</summary>
    public override SnapshotList<Player> Players { get; } = new();

    public IPermissionContainer PermissionContainer { get; set; } = new DummyPermissionContainer();
    public EventNode<IServerEvent> EventNode => Events;
    
    public new PlayerMeta Meta {
        get => (PlayerMeta)base.Meta;
        set => base.Meta = value;
    }

    public Inventory? OpenInventory {
        get;
        set {
            if (value == null) {
                if (field != null)
                    SendPacket(new ClientBoundCloseContainerPacket {
                        WindowId = field.WindowId
                    });
            }
            else value.AddViewer(this);

            field = value;
        }
    }

    public int ActiveHotbarSlot {
        get => _activeHotbarSlot;
        set {
            if (value is < 0 or > 8) throw new ArgumentOutOfRangeException(nameof(value), "Active hotbar slot must be between 0 and 8.");
            _activeHotbarSlot = value;
            SendPacket(new ClientBoundSetHeldItemPacket {
                Slot = _activeHotbarSlot
            });
            RefreshEquipment();
        }
    }

    public ItemStack CursorItem {
        get;
        set {
            field = value;
            SendPacket(new ClientBoundSetCursorItemPacket {
                Item = value
            });
        }
    } = ItemStack.Air;

    public GameMode GameMode {
        get;
        set {
            field = value;
            UpdateGameMode();
        }
    }

    /// <summary>
    /// A creative or spectating player is not a target. Vanilla arrives here by a different route
    /// (<c>canBeSeenAsEnemy</c> asks <c>isInvulnerable</c>, which creative sets), but the answer and
    /// the reason are the same: mobs must not pick a fight with somebody who cannot be hurt.
    /// </summary>
    public override bool CanBeSeenAsEnemy =>
        GameMode is not (GameMode.Creative or GameMode.Spectator) && base.CanBeSeenAsEnemy;

    /// <summary>
    /// <c>Player.experienceLevel</c>. Setting it moves the level and leaves the bar where it is, which
    /// is what <c>giveExperienceLevels</c> does; <see cref="GiveExperiencePoints"/> is the other way in
    /// and is what an orb uses.
    /// </summary>
    public int Level {
        get;
        set {
            field = value;
            if (field < 0) {
                field = 0;
                ExperienceProgress = 0f;
                TotalExperience = 0;
            }

            SendExperience();
        }
    }

    /// <summary>
    /// <c>Player.experienceProgress</c>, how far along the bar is between this level and the next, in
    /// [0, 1). Not a count of points: how many points a bar is worth grows with the level, which is
    /// what <see cref="XpNeededForNextLevel"/> answers.
    /// </summary>
    public float ExperienceProgress {
        get;
        set {
            field = value;
            SendExperience();
        }
    }

    /// <summary><c>Player.totalExperience</c>, everything ever collected, which is the score.</summary>
    public int TotalExperience {
        get;
        set {
            field = value;
            SendExperience();
        }
    }

    /// <summary>
    /// <c>Player.getXpNeededForNextLevel</c>: seven plus two a level to fifteen, then five a level to
    /// thirty, then nine. The three segments are why a level near thirty is worth four times one near
    /// zero.
    /// </summary>
    public int XpNeededForNextLevel => Level >= 30
        ? 112 + (Level - 30) * 9
        : Level >= 15
            ? 37 + (Level - 15) * 5
            : 7 + Level * 2;

    /// <summary>
    /// <c>Player.giveExperiencePoints</c>. Points are added to the bar and the bar carries into levels,
    /// so the loops here are the levelling curve rather than a rounding detail: taking points away can
    /// walk back down through several levels, and adding them can walk up through several.
    /// </summary>
    public void GiveExperiencePoints(int amount) {
        float progress = ExperienceProgress + (float)amount / XpNeededForNextLevel;
        int total = (int)Math.Clamp((long)TotalExperience + amount, 0, int.MaxValue);

        while (progress < 0.0f) {
            float remaining = progress * XpNeededForNextLevel;
            bool hadLevels = Level > 0;
            Level--;
            progress = hadLevels ? 1.0f + remaining / XpNeededForNextLevel : 0.0f;
        }

        while (progress >= 1.0f) {
            progress = (progress - 1.0f) * XpNeededForNextLevel;
            Level++;
            progress /= XpNeededForNextLevel;
        }

        // Written last and in one go: each of these setters sends the packet on its own, and setting
        // the level inside the loops above has already sent several.
        TotalExperience = total;
        ExperienceProgress = progress;
    }

    private void SendExperience() {
        SendPacket(new ClientBoundSetExperiencePacket {
            ExperienceProgress = ExperienceProgress,
            Level = Level,
            TotalExperience = TotalExperience
        });
    }

    public ItemStack HeldItem {
        get => Inventory.GetHotbarItem(ActiveHotbarSlot);
        set {
            Inventory.SetHotbarItem(ActiveHotbarSlot, value);
            RefreshEquipment();
        }
    }

    public override Vec3<double> Velocity {
        set => SetVelocity(value);
    }

    /// <summary>
    /// The entity that the player is viewing through. (Like in spectator when you click on an entity)
    /// </summary>
    public Entity? CameraEntity {
        get;
        set {
            field = value;
            SendPacket(new ClientBoundSetCameraPacket {
                EntityId = value?.NetId ?? NetId
            });
        }
    }

    public PlayerSkin? Skin {
        get;
        set {
            field = value;

            // To change the skin, we need to remove the player info and send a new one
            SendToSelfAndViewers(new ClientBoundPlayerInfoRemovePacket {
                Uuids = [Uuid]
            }, GetPlayerInfoPacket());
            if (World != null) {
                ResetEntity();
            }
        }
    }

    // Values according to https://minecraft.wiki/w/Player in the Trivia section
    // 1.27 seems to be the sqrt of 1.62 (the eye height of player while not crouching)
    public double EyeHeight => Crouching ? 1.27 : EntityType.Player.EyeHeight;

    /// <summary>
    /// <c>Player.isSecondaryUseActive</c>, which upstream is just "is crouching". It decides whether
    /// a right click reaches the block at all (see <c>BlockInteraction.UseItemOn</c>) and it is what
    /// several placement rules branch on, so there is one definition of it here rather than a
    /// <c>Crouching</c> read at each site.
    /// </summary>
    public virtual bool IsSecondaryUseActive => Crouching;

    public new ManagedMinecraftServer Server;

    private int _waitingTeleport = -1;
    
    // backend fields
    private int _activeHotbarSlot;

    private readonly ConcurrentQueue<MinecraftPacket> _packetProcessQueue = new();

    /// <summary>
    /// Drops this player's per tick listener. Registered for the life of the connection and, without
    /// this, never removed: every player who had ever joined kept costing a delegate call on every
    /// tick of the server for as long as it ran.
    /// </summary>
    private Action? _cancelTickListener;

    // Listen to movement packets so we can do stuff
    public Player(ManagedMinecraftServer server, PlayerConnection connection, string name, PlayerMeta? meta = null) 
        : base(EntityType.Player, meta ?? new PlayerMeta()) {
        Server = server;
        Name = name;
        Connection = connection;
        Inventory = new PlayerInventory(server, this);
        Players.Add(this);
        
        // There doesn't seem to be a good way to get this default value
        // and Minestom hardcodes it, so I guess we will too
        SetAttributeBaseValue(Attribute.MovementSpeed, 0.1);
        
        connection.Disconnected += () => {
            PlayerDisconnectEvent disconnectEvent = new() {
                Player = this,
                World = World!
            };
            Events.CallEvent(disconnectEvent);

            Despawn();

            _cancelTickListener?.Invoke();
            _cancelTickListener = null;
        };

        connection.Events.AddListener<PacketSendingEvent>(e => {
            PlayerPacketOutEvent playerEvent = new() {
                Player = this,
                Packet = e.Packet,
                World = World!
            };
            Events.CallEvent(playerEvent);
            if (playerEvent.Cancelled) {
                // don't send the packet
                e.Cancelled = true;
            }
        });

        connection.Events.AddListener<PacketReceiveEvent>(e => {
            PlayerPacketReceiveEvent playerEvent = new() {
                Player = this,
                Packet = e.Packet,
                World = World!
            };
            Events.CallEvent(playerEvent);

            if (playerEvent.Cancelled) {
                e.Cancelled = true;
            }
        });
        
        connection.Events.AddListener<PacketHandleEvent>(e => {
            _packetProcessQueue.Enqueue(e.Packet);
            // HandlePacket(e.Packet);
        });

        // Received packets are handled on the tick rather than on the network thread they arrived on,
        // which is what puts a player's movement, and therefore their viewport, in the same order as
        // everything else the tick does.
        _cancelTickListener = Server.Events.AddListener<ServerTickEvent>(_ => {
            while (_packetProcessQueue.TryDequeue(out MinecraftPacket? processPacket)) {
                HandlePacket(processPacket);
            }
        });
    }

    /// <summary>
    /// Runs a received packet as though it had come off the queue this tick. Public so a test can
    /// drive one at the point in the tick the queue would have, rather than firing
    /// <see cref="PlayerPacketHandleEvent"/> by hand, which no longer represents the whole path.
    /// </summary>
    public void HandlePacket(MinecraftPacket packet) {
        // ServerGamePacketListenerImpl.handleUseItem snaps the rotation to the packet's before running
        // the item. The client turns every frame but only reports its rotation once a tick, from the
        // level tick, which runs after the click that this packet is: mid turn, our rotation is always
        // the previous tick's. Anything raycasting off use_item aims a tick behind without this, and it
        // has to happen before the event, because that is where those features run.
        if (packet is ServerBoundUseItemPacket use) {
            SnapRotationTo(use.Yaw, use.Pitch);
        }

        PlayerPacketHandleEvent playerEvent = new() {
            Player = this,
            Packet = packet,
            World = World!
        };
        Events.CallEvent(playerEvent);
        
        switch (packet) {
            case ServerBoundSetPlayerPositionPacket sp: {
                if (_waitingTeleport != -1) return;
                OnGround = sp.Flags.HasFlag(MovePlayerFlags.OnGround);
                MoveFromClient(sp.Position);
                break;
            }

            case ServerBoundSetPlayerPosAndRotPacket sp: {
                if (_waitingTeleport != -1) return;
                OnGround = sp.Flags.HasFlag(MovePlayerFlags.OnGround);
                MoveFromClient(sp.Position, Angle.FromDegrees(sp.Yaw), Angle.FromDegrees(sp.Pitch));
                break;
            }

            case ServerBoundSetPlayerRotationPacket sr: {
                if (_waitingTeleport != -1) return;
                OnGround = sr.Flags.HasFlag(MovePlayerFlags.OnGround);

                MoveFromClient(Position, Angle.FromDegrees(sr.Yaw), Angle.FromDegrees(sr.Pitch));
                break;
            }

            // ServerGamePacketListenerImpl.handleAcceptTeleportPacket: no other move counts until the
            // teleport is acknowledged, and the acknowledgement is itself the move off the teleport.
            case ServerBoundConfirmTeleportPacket ct: {
                if (ct.TeleportId != _waitingTeleport) {
                    break;
                }

                _waitingTeleport = -1;
                // Vanilla disconnects for a NaN position or a non finite rotation. Nothing here validates a
                // move packet, so the move is dropped instead.
                if (!IsValidMove(ct.Position, ct.Yaw, ct.Pitch)) {
                    break;
                }

                OnGround = false;
                MoveFromClient(ct.Position, Angle.FromDegrees(ct.Yaw), Angle.FromDegrees(ct.Pitch));
                break;
            }

            case ServerBoundInteractPacket ip: {
                PlayerEntityInteractEvent interactEvent = new() {
                    Target = Manager!.GetEntity(ip.EntityId)!,
                    Player = this,
                    TargetLocation = ip.Target,
                    UsedHand = ip.UsedHand,
                    SneakPressed = ip.SneakPressed,
                    World = World!
                };
                Events.CallEvent(interactEvent);
                break;
            }

            case ServerBoundAttackPacket ap: {
                PlayerAttackEntityEvent attackEvent = new() {
                    Target = Manager!.GetEntity(ap.EntityId)!,
                    Player = this,
                    World = World!
                };
                Events.CallEvent(attackEvent);
                break;
            }

            // Right clicking a block runs a sequence, not a broadcast: the block's own interaction
            // first, then the held item. See BlockInteraction. Note that PlayerPacketHandleEvent has
            // already fired by the time this runs, so anything filtering that event for use_item_on
            // jumps ahead of the whole sequence and cannot be ordered against it. That is what
            // PlayerBlockInteractEvent and PlayerUseItemOnBlockEvent exist to replace.
            case ServerBoundUseItemOnPacket useOn: {
                BlockInteraction.HandleUseItemOn(this, useOn);
                break;
            }

            case ServerBoundSetHeldItemPacket sh: {
                _activeHotbarSlot = sh.Slot;
                RefreshEquipment();
                
                PlayerSwitchHotbarSlotEvent switchEvent = new() {
                    Player = this,
                    World = World!,
                    Slot = _activeHotbarSlot
                };
                Events.CallEvent(switchEvent);
                break;
            }

            case ServerBoundPlayerActionPacket pa: {
                // Respond to some inventory actions
                switch (pa.ActionStatus) {
                    case ServerBoundPlayerActionPacket.Status.DropItemStack:
                    case ServerBoundPlayerActionPacket.Status.DropItem:
                    case ServerBoundPlayerActionPacket.Status.UpdateHeldItem:
                        Inventory.SendUpdateTo(this);
                        break;
                }
                break;
            }
        }
    }
    
    /// <summary>
    /// A movement the client reported. Vanilla runs the same one through <c>Entity.move</c> and takes
    /// the fall out of what came back (<c>ServerGamePacketListenerImpl.handleMovePlayer</c>); a player's
    /// client owns their movement, so the position it sent is what that is here.
    /// </summary>
    /// <summary><c>ServerGamePacketListenerImpl.containsInvalidValues</c>, the other way round.</summary>
    private static bool IsValidMove(Vec3<double> position, float yaw, float pitch) {
        return !double.IsNaN(position.X) && !double.IsNaN(position.Y) && !double.IsNaN(position.Z)
               && float.IsFinite(yaw) && float.IsFinite(pitch);
    }

    private void MoveFromClient(Vec3<double> newPos, Angle? yaw = null, Angle? pitch = null) {
        double startY = Position.Y;
        Move(newPos, yaw, pitch);

        if (World == null) {
            return;
        }

        double dy = Position.Y - startY;
        EntityPhysics.CheckFallDamage(World, this, dy, OnGround);

        // Vanilla clears a player's fall whenever they move upwards at all, which is what stops a jump
        // taken part way down a fall from landing with the whole of it.
        if (dy > 0.0) {
            FallDistance = 0.0;
        }
    }

    public override ItemStack GetItemInHand(Hand hand) {
        return hand switch {
            Hand.MainHand => HeldItem,
            Hand.OffHand => Inventory.Offhand,
            _ => throw new ArgumentOutOfRangeException(nameof(hand), "Invalid hand specified.")
        };
    }

    public override void SetItemInHand(Hand hand, ItemStack item) {
        switch (hand) {
            case Hand.MainHand:
                HeldItem = item;
                break;
            case Hand.OffHand:
                Inventory.Offhand = item;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(hand), "Invalid hand specified.");
        }
        Inventory.SendUpdateTo(this);
    }

    public void SwapHeld() {
        (HeldItem, Inventory.Offhand) = (Inventory.Offhand, HeldItem);
        Inventory.SendUpdateTo(this);
    }

    public void RefreshEquipment() {
        SetEquipmentItem(EquipmentSlot.MainHand, HeldItem);
        SetEquipmentItem(EquipmentSlot.OffHand, Inventory.Offhand);
        SetEquipmentItem(EquipmentSlot.Helmet, Inventory.Helmet);
        SetEquipmentItem(EquipmentSlot.Chestplate, Inventory.Chestplate);
        SetEquipmentItem(EquipmentSlot.Leggings, Inventory.Leggings);
        SetEquipmentItem(EquipmentSlot.Boots, Inventory.Boots);
    }

    public override void SetWorld(World? world) {
        SetWorld(world);
    }

    protected MinecraftPacket GetRespawnPacket(World world) {
        return new ClientBoundRespawnPacket {
            DimensionName = world.DimensionId,
            DimensionType = Server.Registry.DimensionTypes.GetProtocolId(world.Dimension),
            HashedSeed = 0,
            GameMode = GameMode,
            DataKept = ClientBoundRespawnPacket.DataKeptTypes.All,
            IsDebug = false,
            IsFlat = false,
            Location = null,
            PortalCooldown = 0,
            PreviousGameMode = GameMode.Undefined,
            SeaLevel = 64
        };
    }

    public void SetWorld(World? world, bool sendRespawnPacket = true) {
        // Change the instance that the player sees
        if (World != null) {
            World.RemovePlayer(this);
            
            // Send a respawn packet to the player
            if (sendRespawnPacket && world != null) {
                SendPacket(GetRespawnPacket(world));
            }
        }

        world?.AddPlayer(this);

        base.SetWorld(world);
    }

    public void SetVelocity(Vec3<double> velocity) {
        Connection.SendPacket(new ClientBoundSynchronisePlayerPositionPacket {
            TeleportId = System.Random.Shared.Next(),
            Position = Vec3<double>.Zero,
            Velocity = velocity,
            Pitch = Angle.Zero,
            Yaw = Angle.Zero,
            Flags = TeleportFlags.RelativePosition | TeleportFlags.RelativeRotation
        });
    }
    
    /// <summary>
    /// <c>ServerPlayer.absSnapRotationTo</c> behind vanilla's own "only if it changed" guard. The
    /// wrapping is <c>Mth.wrapDegrees</c> and is in float, as it is upstream, because that is what the
    /// comparison against the current rotation is made in.
    /// </summary>
    private void SnapRotationTo(Angle yaw, Angle pitch) {
        float wrappedYaw = WrapDegrees(yaw.DegreesF);
        float wrappedPitch = WrapDegrees(pitch.DegreesF);

        if (wrappedPitch == Pitch.DegreesF && wrappedYaw == Yaw.DegreesF) {
            return;
        }

        Move(Position, Angle.FromDegrees(wrappedYaw), Angle.FromDegrees(wrappedPitch));
    }

    /// <summary><c>Mth.wrapDegrees</c>.</summary>
    private static float WrapDegrees(float angle) {
        float wrapped = angle % 360.0f;
        if (wrapped >= 180.0f) {
            wrapped -= 360.0f;
        }

        if (wrapped < -180.0f) {
            wrapped += 360.0f;
        }

        return wrapped;
    }

    /// <summary>
    /// Vanilla runs <see cref="UpdatePlayerAttributes"/> at the end of <c>ServerPlayer.tick</c>, which
    /// is what keeps the crouch driven one in step, so it is driven off the tick here too.
    /// </summary>
    protected override void Tick() {
        base.Tick();
        UpdatePlayerAttributes();
    }

    /// <summary>
    /// <c>ServerPlayer.updatePlayerAttributes</c>, the three attributes vanilla keeps in step with the
    /// game mode and the crouch rather than with anything a feature does. It runs every tick upstream
    /// and is idempotent there; here each modifier is only touched when it actually has to change,
    /// because adding one sends the attribute to every viewer.
    /// </summary>
    private void UpdatePlayerAttributes() {
        bool creative = GameMode == GameMode.Creative;
        SetTransientModifier(Attribute.BlockInteractionRange, CreativeBlockRange, creative, ref _creativeBlockRange);
        SetTransientModifier(Attribute.EntityInteractionRange, CreativeEntityRange, creative, ref _creativeEntityRange);
        SetTransientModifier(Attribute.WaypointTransmitRange, WaypointCrouch, Crouching, ref _waypointCrouch);
    }

    private void SetTransientModifier(IAttribute attribute, AttributeModifier modifier, bool wanted, ref bool applied) {
        if (wanted == applied) {
            return;
        }

        if (wanted) {
            AddAttributeModifier(attribute, modifier);
        }
        else {
            RemoveAttributeModifier(attribute, modifier.Id);
        }

        applied = wanted;
    }

    private static readonly AttributeModifier CreativeBlockRange =
        new("minecraft:creative_mode_block_range", 0.5, AttributeOperation.Add);

    private static readonly AttributeModifier CreativeEntityRange =
        new("minecraft:creative_mode_entity_range", 2.0, AttributeOperation.Add);

    private static readonly AttributeModifier WaypointCrouch =
        new("minecraft:waypoint_transmit_range_crouch", -1.0, AttributeOperation.AddMultipliedTotal);

    private bool _creativeBlockRange;
    private bool _creativeEntityRange;
    private bool _waypointCrouch;

    public void UpdateGameMode() {
        UpdatePlayerAttributes();
        Connection.SendPacket(ClientBoundGameEventPacket.ChangeGameMode(GameMode));
        SendToSelfAndViewers(new ClientBoundPlayerInfoUpdatePacket {
            Data = new ClientBoundPlayerInfoUpdatePacket.PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateGameMode)
                .WithPlayer(Uuid, new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateGameMode {
                    GameMode = GameMode
                })
        });
    }

    public void RefreshVisibleEntities() {
        Manager?.RefreshPlayerVisibleEntities(this);
    }

    public void Respawn() {
        Respawn(World!);
    }

    public void Respawn(World world) {
        SendPacket(GetRespawnPacket(world));
        
        // Send updates to the player
        Teleport(Position);
        Inventory.SendUpdateTo(this);
        SendHealthUpdate();
    }

    /// <summary>
    /// Respawns the entity by first despawning it and then respawning it again.
    /// </summary>
    public void ResetEntity() {
        if (World == null) {
            throw new InvalidOperationException("Cannot reset entity without a world.");
        }
        
        this.SendPackets(new ClientBoundSetHealthPacket {
            Health = 0,
            Saturation = 1,
            Food = 1
        });
        SendHealthUpdate();
        Respawn();
        World.ResetPlayer(this);
        Manager!.Respawn(this);
    }

    public override void Teleport(Vec3<double> pos, Angle? yaw = null, Angle? pitch = null) {
        _waitingTeleport = System.Random.Shared.Next();
        TeleportFlags teleportFlags = TeleportFlags.None;
        if (yaw == null) {
            teleportFlags |= TeleportFlags.RelativeYaw;
        }
        if (pitch == null) {
            teleportFlags |= TeleportFlags.RelativePitch;
        }
        
        Connection.SendPacket(new ClientBoundSynchronisePlayerPositionPacket {
            TeleportId = _waitingTeleport,
            Position = pos,
            Velocity = Vec3<double>.Zero,
            Yaw = yaw ?? Angle.Zero,
            Pitch = pitch ?? Angle.Zero,
            Flags = teleportFlags
        });
        
        Move(pos, yaw, pitch);
        // base.Teleport(pos, yaw, pitch);   Don't tell everyone else
    }

    public override void SendToSelf(params MinecraftPacket[] packets) {
        Connection?.SendPackets(packets);
    }

    public MinecraftPacket GetPlayerInfoPacket() {
        return new ClientBoundPlayerInfoUpdatePacket {
            Data = new ClientBoundPlayerInfoUpdatePacket.PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions
                    .AddPlayer)
                .WithPlayer(Uuid, new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                    Name = Name,
                    Properties = Skin == null
                        ? []
                        : [
                            new ProfileProperty {
                                Name = "textures",
                                Value = Skin.Textures,
                                Signature = Skin.Signature
                            }
                        ]
                })
        };
    }

    public override MinecraftPacket[] GenerateSpawnEntityPackets() {
        MinecraftPacket[] arr = [
            GetPlayerInfoPacket()
        ];
        return arr.Combine(base.GenerateSpawnEntityPackets()).ToArray();
    }

    public void SendPacket(MinecraftPacket packet) {
        Connection.SendPacket(packet);
    }

    /// <summary>
    /// The swing after an interaction that answered a <see cref="SwingSource"/> other than none, as
    /// the packet handlers end <c>handleUseItemOn</c>, <c>handleUseItem</c> and <c>handleInteract</c>.
    /// The player's own client is only told when it did not predict the swing itself.
    /// </summary>
    /// <param name="animation">The used stack's interact animation, read before the use changed it.</param>
    public void SwingAfterInteraction(Hand hand, SwingAnimation animation, SwingSource source) {
        if (source != SwingSource.None) {
            Swing(hand, animation, source != SwingSource.Predicted);
        }
    }
}

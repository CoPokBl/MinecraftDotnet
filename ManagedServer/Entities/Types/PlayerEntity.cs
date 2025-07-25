using System.Collections.Concurrent;
using ManagedServer.Events;
using ManagedServer.Inventory;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities.Types;

public class PlayerEntity : LivingEntity, IAudience {
    public readonly string Name;
    public readonly PlayerConnection Connection;
    public readonly PlayerInventory Inventory;

    public override List<PlayerEntity> Players => [this];
    
    public new PlayerMeta Meta {
        get => (PlayerMeta)base.Meta;
        set => base.Meta = value;
    }

    public Inventory.Inventory? OpenInventory {
        get => _openInventory;
        set {
            if (value == null) {
                if (_openInventory != null) SendPacket(new ClientBoundCloseContainerPacket {
                    WindowId = _openInventory.WindowId
                });
            } else value.AddViewer(this);
            _openInventory = value;
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
        get => _cursorItem;
        set {
            _cursorItem = value;
            SendPacket(new ClientBoundSetCursorItemPacket {
                Item = value
            });
        }
    }

    public GameMode GameMode {
        get => _gameMode;
        set {
            _gameMode = value;
            UpdateGameMode();
        }
    }
    
    public Func<PlayerEntity, bool> PlayerViewableRule {
        get => _playerViewableRule;
        set {
            _playerViewableRule = value;
            UpdateViewers();
        }
    }
    
    public int Level {
        get => _level;
        set {
            _level = value;
            SendPacket(new ClientBoundSetExperiencePacket {
                ExperienceProgress = 0f,
                Level = _level,
                TotalExperience = 0
            });
        }
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
        get => _cameraEntity;
        set {
            _cameraEntity = value;
            SendPacket(new ClientBoundSetCameraPacket {
                EntityId = value?.NetId ?? NetId
            });
        }
    }

    public PlayerSkin? Skin { get; internal set; }
    
    // Values according to https://minecraft.wiki/w/Player in the Trivia section
    // 1.27 seems to be the sqrt of 1.62 (the eye height of player while not crouching)
    public double EyeHeight => Crouching ? 1.27 : EntityType.Player.EyeHeight;

    public ManagedMinecraftServer Server;

    private int _waitingTeleport = -1;
    
    // backend fields
    private Entity? _cameraEntity;
    private int _level;
    private GameMode _gameMode;
    private Inventory.Inventory? _openInventory;
    private int _activeHotbarSlot;
    private ItemStack _cursorItem = ItemStack.Air;
    private Func<PlayerEntity, bool> _playerViewableRule = _ => true;
    private readonly ConcurrentQueue<MinecraftPacket> _packetSendingQueue = new();
    private readonly ConcurrentQueue<MinecraftPacket> _packetProcessQueue = new();

    // Listen to movement packets so we can do stuff
    public PlayerEntity(ManagedMinecraftServer server, PlayerConnection connection, string name, PlayerMeta? meta = null) 
        : base(EntityType.Player, meta ?? new PlayerMeta()) {
        Server = server;
        Name = name;
        Connection = connection;
        ViewableRule = p => p != this && PlayerViewableRule(p);
        Inventory = new PlayerInventory(server, this);
        
        connection.Disconnected += Despawn;

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

        Server.Events.AddListener<ServerTickEvent>(_ => {
            // Drain the packet queue
            while (_packetSendingQueue.TryDequeue(out MinecraftPacket? packet)) {
                Connection.SendPacket(packet);
            }
            
            // Process packets that were received
            while (_packetProcessQueue.TryDequeue(out MinecraftPacket? processPacket)) {
                HandlePacket(processPacket);
            }
        });
    }

    private void HandlePacket(MinecraftPacket packet) {
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
                Move(sp.Position);
                break;
            }

            case ServerBoundSetPlayerPosAndRotPacket sp: {
                if (_waitingTeleport != -1) return;
                OnGround = sp.Flags.HasFlag(MovePlayerFlags.OnGround);
                Move(sp.Position, Angle.FromDegrees(sp.Yaw), Angle.FromDegrees(sp.Pitch));
                break;
            }

            case ServerBoundSetPlayerRotationPacket sr: {
                if (_waitingTeleport != -1) return;
                OnGround = sr.Flags.HasFlag(MovePlayerFlags.OnGround);
                Move(Position, Angle.FromDegrees(sr.Yaw), Angle.FromDegrees(sr.Pitch));
                break;
            }

            // don't move player when they haven't sent ack for teleports
            case ServerBoundConfirmTeleportPacket ct: {
                if (ct.TeleportId == _waitingTeleport) {
                    _waitingTeleport = -1;
                }
                break;
            }

            case ServerBoundInteractPacket ip: {
                PlayerEntityInteractEvent interactEvent = new() {
                    Target = Manager!.GetEntityById(ip.EntityId)!,
                    Player = this,
                    Type = ip.Type,
                    TargetLocation = ip.Target,
                    UsedHand = ip.UsedHand,
                    SneakPressed = ip.SneakPressed,
                    World = World!
                };
                Events.CallEvent(interactEvent);
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
                    case ServerBoundPlayerActionPacket.Status.SwapItem:
                        SwapHeld();
                        break;
                }
                break;
            }
        }
    }
    
    public ItemStack GetItemInHand(Hand hand) {
        return hand switch {
            Hand.MainHand => HeldItem,
            Hand.OffHand => Inventory.Offhand,
            _ => throw new ArgumentOutOfRangeException(nameof(hand), "Invalid hand specified.")
        };
    }
    
    public void SetItemInHand(Hand hand, ItemStack item) {
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

    public override void SetWorld(World world) {
        SetWorld(world);
    }

    protected MinecraftPacket GetRespawnPacket(World world) {
        return new ClientBoundRespawnPacket {
            DimensionName = world.DimensionId,
            DimensionType = 0,
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

    public void SetWorld(World world, bool sendRespawnPacket = true) {
        // Change the instance that the player sees
        if (World != null) {
            World.RemovePlayer(this);
            
            // Send a respawn packet to the player
            if (sendRespawnPacket) {
                SendPacket(GetRespawnPacket(world));
            }
        }
        
        world.AddPlayer(this);
        
        base.SetWorld(world);
    }

    public void SetVelocity(Vec3<double> velocity) {
        Connection.SendPacket(new ClientBoundSynchronisePlayerPositionPacket {
            TeleportId = Random.Shared.Next(),
            Position = Vec3<double>.Zero,
            Velocity = velocity,
            Pitch = Angle.Zero,
            Yaw = Angle.Zero,
            Flags = TeleportFlags.RelativePosition | TeleportFlags.RelativeRotation
        });
    }
    
    public void UpdateGameMode() {
        Connection.SendPacket(ClientBoundGameEventPacket.ChangeGameMode(GameMode));
        SendToSelfAndViewers(new ClientBoundPlayerInfoUpdatePacket {
            Data = new ClientBoundPlayerInfoUpdatePacket.PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateGameMode)
                .WithPlayer(Uuid, new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateGameMode {
                    GameMode = GameMode
                })
        });
    }

    public void Respawn() {
        SendPacket(GetRespawnPacket(World!));
    }

    public override void Teleport(Vec3<double> pos, Angle? yaw = null, Angle? pitch = null) {
        _waitingTeleport = Random.Shared.Next();
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
                            new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer.Property {
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
}

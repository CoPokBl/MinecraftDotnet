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
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities.Types;

public class PlayerEntity : LivingEntity, IAudience {
    public readonly string Name;
    public readonly PlayerConnection Connection;
    public readonly PlayerInventory Inventory;

    public override List<PlayerEntity> Players => [this];

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
    
    public Func<PlayerConnection, bool> PlayerViewableRule {
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

    public bool OnGround;

    public ManagedMinecraftServer Server => World!.Server!;

    private int _waitingTeleport = -1;
    
    // backend fields
    private Entity? _cameraEntity;
    private int _level;
    private GameMode _gameMode;
    private Inventory.Inventory? _openInventory;
    private int _activeHotbarSlot;
    private ItemStack _cursorItem = ItemStack.Air;
    private Func<PlayerConnection, bool> _playerViewableRule = _ => true;
    private readonly AtomicCounter _blockBreakTickCounter = new(0, 20);

    // Listen to movement packets so we can do stuff
    public PlayerEntity(PlayerConnection connection, string name) : base(EntityType.Player) {
        Name = name;
        Connection = connection;
        ViewableRule = con => con != Connection && PlayerViewableRule(con);
        Inventory = new PlayerInventory(this);
        
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
            PlayerPacketHandleEvent playerEvent = new() {
                Player = this,
                Packet = e.Packet,
                World = World!
            };
            Events.CallEvent(playerEvent);
            
            switch (e.Packet) {
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
                    break;
                }

                case ServerBoundPlayerActionPacket pa: {
                    // MinecraftPacket ackPacket = new ClientBoundAcknowledgeBlockChangePacket {
                    //     SequenceId = pa.Sequence
                    // };
                    
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
        });
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

    public void SetWorld(World world, bool sendRespawnPacket = true) {
        // Change the instance that the player sees
        if (World != null) {
            World.RemovePlayer(this);
            
            // Send a respawn packet to the player
            if (sendRespawnPacket) {
                SendPacket(new ClientBoundRespawnPacket {
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
                });
            }
        }
        
        world.AddPlayer(this);
        
        base.SetWorld(world);
    }

    public void SetVelocity(Vec3 velocity) {
        Connection.SendPacket(new ClientBoundSynchronisePlayerPositionPacket {
            TeleportId = Random.Shared.Next(),
            Position = Vec3.Zero,
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
        // todo
    }

    public override void Teleport(Vec3 pos, Angle? yaw = null, Angle? pitch = null) {
        _waitingTeleport = Random.Shared.Next();
        Connection.SendPacket(new ClientBoundSynchronisePlayerPositionPacket {
            TeleportId = _waitingTeleport,
            Position = pos,
            Velocity = Vec3.Zero,
            Yaw = yaw ?? Angle.Zero,
            Pitch = pitch ?? Angle.Zero,
            Flags = TeleportFlags.None
        });
        // base.Teleport(pos, yaw, pitch);   Don't tell everyone else
    }

    public override void SendToSelf(params MinecraftPacket[] packets) {
        Connection.SendPackets(packets);
    }

    public override MinecraftPacket[] GenerateSpawnEntityPackets() {
        MinecraftPacket[] arr = [
            new ClientBoundPlayerInfoUpdatePacket {
                Data = new ClientBoundPlayerInfoUpdatePacket.PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions
                        .AddPlayer)
                    .WithPlayer(Uuid, new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                        Name = Name,
                        Properties = []
                    })
            }
        ];
        return arr.Combine(base.GenerateSpawnEntityPackets()).ToArray();
    }

    public void SendPacket(MinecraftPacket packet) {
        Connection.SendPacket(packet);
    }
}

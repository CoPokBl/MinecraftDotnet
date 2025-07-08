using ManagedServer.Events;
using ManagedServer.Inventory;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities.Types;

public class PlayerEntity : Entity, IAudience {
    private const double PlayerWidth = 0.6;
    private const double PlayerHeight = 1.8;
    
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
            } else SendPacket(value.GenerateOpenPacket());
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
        set => Inventory.SetHotbarItem(ActiveHotbarSlot, value);
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
    private Func<PlayerConnection, bool> _playerViewableRule = _ => true;
    private Timer? _blockBreakTimer;
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
        
        connection.Events.AddListener<PacketHandleEvent>(e => {
            PlayerPacketEvent playerEvent = new() {
                Player = this,
                Packet = e.Packet,
                World = World!
            };
            Events.CallEvent(playerEvent);
            if (playerEvent.Cancelled) {
                // don't process the packet
                return;
            }
            
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

                // Crouching and uncrouching
                case ServerBoundPlayerCommandPacket pc: {
                    Crouching = pc.PlayAction switch {
                        PlayerAction.PressSneak => true,
                        PlayerAction.ReleaseSneak => false,
                        _ => Crouching
                    };
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

                case ServerBoundUseItemOnPacket uio: {
                    CheckBlockPlace(uio);
                    return;
                }

                case ServerBoundSetHeldItemPacket sh: {
                    _activeHotbarSlot = sh.Slot;
                    break;
                }

                case ServerBoundPlayerActionPacket pa: {
                    MinecraftPacket ackPacket = new ClientBoundAcknowledgeBlockChangePacket {
                        SequenceId = pa.Sequence
                    };
                    
                    switch (pa.ActionStatus) {
                        case ServerBoundPlayerActionPacket.Status.StartedDigging:
                            if (ProcessDigStart(pa.Location) == DigResult.Acknowledge) {
                                SendPacket(ackPacket);
                            }
                            break;
                        case ServerBoundPlayerActionPacket.Status.CancelledDigging:
                            ProcessDigCancel(pa.Location);
                            SendPacket(ackPacket);
                            break;
                        case ServerBoundPlayerActionPacket.Status.FinishedDigging:
                            if (ProcessDigEnd(pa.Location) == DigResult.Acknowledge) {
                                SendPacket(ackPacket);
                            }
                            break;
                        case ServerBoundPlayerActionPacket.Status.DropItemStack:
                            Inventory.SendUpdateTo(this);
                            break;
                        case ServerBoundPlayerActionPacket.Status.DropItem:
                            Inventory.SendUpdateTo(this);
                            break;
                        case ServerBoundPlayerActionPacket.Status.UpdateHeldItem:
                            Inventory.SendUpdateTo(this);
                            break;
                        case ServerBoundPlayerActionPacket.Status.SwapItem:
                            SwapHeld();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                }
            }
        });
    }

    public void SwapHeld() {
        (HeldItem, Inventory.Offhand) = (Inventory.Offhand, HeldItem);
        Inventory.SendUpdateTo(this);
    }

    private DigResult ProcessDigStart(IVec3 pos) {
        IBlock block = World!.GetBlock(pos);
        
        PlayerStartBreakingBlockEvent startEvent = new() {
            Player = this,
            Position = pos,
            Block = block,
            World = World!
        };
        Events.CallEvent(startEvent);

        if (startEvent.Cancelled) {
            return DigResult.Acknowledge;
        }
        
        ItemStack heldItem = HeldItem;
        int breakTicks = BlockUtils.GetBreakSpeed(GameMode, block, heldItem, false, OnGround);

        if (breakTicks == 0) {
            // instamine
            BreakBlock(pos);
            return DigResult.Acknowledge;
        }
        
        // mining over time
        _blockBreakTimer?.Dispose();
        float breakSeconds = breakTicks / 20.0f;
        TimeSpan breakTickDuration = TimeSpan.FromSeconds(breakSeconds / 9f);  // 9 break ticks occur before it breaks
        _blockBreakTimer = new Timer(_ => {
            this.GetAudience().SendPacket(new ClientBoundSetBlockDestroyStagePacket {
                Block = pos,
                EntityId = NetId,
                Stage = (byte)Math.Min(_blockBreakTickCounter.Next(), 9)
            });
        }, null, breakTickDuration, breakTickDuration);

        return DigResult.Acknowledge;
    }

    private DigResult ProcessDigEnd(IVec3 pos) {
        StopBlockBreakAnimation(pos);
        
        IBlock block = World!.GetBlock(pos);
        
        // Well they broke it
        BreakBlock(pos);
        return DigResult.Acknowledge;
    }
    
    private void ProcessDigCancel(IVec3 pos) {
        PlayerCancelBreakingBlockEvent cancelEvent = new() {
            Player = this,
            Position = pos,
            Block = World!.GetBlock(pos),
            World = World!
        };
        Events.CallEvent(cancelEvent);
        
        StopBlockBreakAnimation(pos);
    }
    
    private void StopBlockBreakAnimation(IVec3 pos) {
        _blockBreakTimer?.Dispose();
        _blockBreakTimer = null;
        _blockBreakTickCounter.Value = 0;
        
        this.GetAudience().SendPacket(new ClientBoundSetBlockDestroyStagePacket {
            Block = pos,
            EntityId = NetId,
            Stage = 64  // invalid value means stop
        });
    }

    public void BreakBlock(IVec3 pos) {
        PlayerBreakBlockEvent breakEvent = new() {
            Player = this,
            Position = pos,
            World = World!,
            Block = World!.GetBlock(pos)
        };
        Events.CallEvent(breakEvent);
        
        if (breakEvent.Cancelled) {
            // don't break, send block update to client
            World!.SendBlockUpdate(pos, this);
            return;
        }
        
        World!.SetBlock(pos, Block.Air);
    }

    private void CheckBlockPlace(ServerBoundUseItemOnPacket use) {
        IVec3 target = use.Position.GetBlockTowards(use.Face);
        Inventory.SendSlotUpdate(ActiveHotbarSlot);
        
        // let's get the block
        ItemStack heldItem = HeldItem;
        Identifier? blockId = heldItem.Type.CorrespondingBlock;
        if (blockId == null) {
            return;  // no block to place
        }
        IBlock block = Server.Registry.Blocks[blockId.Value];
        
        // is player inside that block?
        bool insideEntity = false;
        foreach (Entity en in World!.Entities.Entities.Where(en => en is PlayerEntity)) {
            Vec3 pos = ((PlayerEntity)en).Position;
            Vec3 blockPos = new(target.X + 0.5, target.Y + 0.5, target.Z + 0.5);
            if (Math.Abs(pos.X - blockPos.X) < 0.5 + PlayerWidth/2 && 
                Math.Abs(pos.Z - blockPos.Z) < 0.5 + PlayerWidth/2 && 
                Math.Abs(pos.Y + PlayerHeight/2 - blockPos.Y) + 0.001 < 0.5 + PlayerHeight/2) {
                // they're in the block
                insideEntity = true;
                break;
            }
        }
        
        MinecraftPacket ackPacket = new ClientBoundAcknowledgeBlockChangePacket {
            SequenceId = use.Sequence
        };

        if (insideEntity) {
            // don't place, make it air again
            World!.SendBlockUpdate(target, this);
            SendPacket(ackPacket);
            return;
        }

        PlayerPlaceBlockEvent placeEvent = new() {
            Player = this,
            Block = block,
            Position = target,
            World = World!
        };
        Events.CallEvent(placeEvent);

        if (placeEvent.Cancelled) {
            World!.SendBlockUpdate(target, this);
            SendPacket(ackPacket);
            return;
        }
        
        // Okay place it
        World!.SetBlock(placeEvent.Position, placeEvent.Block);
        SendPacket(ackPacket);
    }

    public override void SetWorld(World world) {
        // Change the instance that the player sees
        if (World != null) {
            World.RemovePlayer(this);
            
            // TODO: Send respawn packet for new world
        }

        // Connection.SendPacket(new ClientBoundRespawnPacket(0, "minecraft:overworld", 0,
        //     GameMode.Survival, GameMode.Undefined, false, false, null, 0, 64,
        //     ClientBoundRespawnPacket.DataKeptTypes.All));
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

    public override void SendToSelfAndViewers(params MinecraftPacket[] packets) {
        Connection.SendPackets(packets);
        SendToViewers(packets);
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
    
    private enum DigResult {
        Ignore,
        Acknowledge
    }
}

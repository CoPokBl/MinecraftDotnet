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

    public ManagedMinecraftServer Server => World!.Server!;

    private int _waitingTeleport = -1;
    
    // backend fields
    private Entity? _cameraEntity;
    private int _level;
    private GameMode _gameMode;
    private Inventory.Inventory? _openInventory;
    private int _activeHotbarSlot = 0;
    private Func<PlayerConnection, bool> _playerViewableRule = _ => true;

    // Listen to movement packets so we can do stuff
    public PlayerEntity(PlayerConnection connection, string name) : base(EntityType.Player) {
        Name = name;
        Connection = connection;
        ViewableRule = con => con != Connection && PlayerViewableRule(con);
        Inventory = new PlayerInventory(this);
        
        connection.Events.Parents.Add(Events);

        connection.Disconnected += Despawn;
        
        connection.Events.AddListener<PacketHandleEvent>(e => {
            switch (e.Packet) {
                case ServerBoundSetPlayerPositionPacket sp: {
                    if (_waitingTeleport != -1) return;
                    Move(sp.Position);
                    break;
                }

                case ServerBoundSetPlayerPosAndRotPacket sp: {
                    if (_waitingTeleport != -1) return;
                    Move(sp.Position, Angle.FromDegrees(sp.Yaw), Angle.FromDegrees(sp.Pitch));
                    break;
                }

                case ServerBoundSetPlayerRotationPacket sr: {
                    if (_waitingTeleport != -1) return;
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
                        SneakPressed = ip.SneakPressed
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

                case ServerBoundSwingArmPacket sa: {
                    ClientBoundEntityAnimationPacket.AnimationType animation = sa.UsedHand switch {
                        Hand.MainHand => ClientBoundEntityAnimationPacket.AnimationType.SwingMainArm,
                        Hand.OffHand => ClientBoundEntityAnimationPacket.AnimationType.SwingOffhand,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    SendToViewers(new ClientBoundEntityAnimationPacket {
                        EntityId = NetId,
                        Animation = animation
                    });
                    break;
                }
            }
        });
    }

    private void CheckBlockPlace(ServerBoundUseItemOnPacket use) {
        IVec3 target = use.Position.GetBlockTowards(use.Face);
        
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
                Math.Abs(pos.Y + PlayerHeight/2 - blockPos.Y) < 0.5 + PlayerHeight/2) {
                // they're in the block
                insideEntity = true;
                break;
            }
        }

        if (target.Y > 1) {
            insideEntity = true;
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

        if (placeEvent.Ignore) {
            return;  // do nothing, not even acknowledge packet
        }

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
}

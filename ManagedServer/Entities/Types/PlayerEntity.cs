using ManagedServer.Events;
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
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities.Types;

public class PlayerEntity : Entity, IAudience {
    public readonly string Name;
    public readonly PlayerConnection Connection;
    
    public GameMode GameMode {
        get => _gameMode;
        set {
            _gameMode = value;
            UpdateGameMode();
        }
    }

    private Func<PlayerConnection, bool> _playerViewableRule = _ => true;
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
    
    public Entity? CameraEntity {
        get => _cameraEntity;
        set {
            _cameraEntity = value;
            SendPacket(new ClientBoundSetCameraPacket {
                EntityId = value?.NetId ?? NetId
            });
        }
    }

    private int _waitingTeleport = -1;
    
    // backend fields
    private Entity? _cameraEntity = null;
    private int _level;
    private GameMode _gameMode;

    // Listen to movement packets so we can do stuff
    public PlayerEntity(PlayerConnection connection, string name) : base(EntityType.Player) {
        Name = name;
        Connection = connection;
        ViewableRule = con => con != Connection && PlayerViewableRule(con);
        
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
                    PlayerEntityInteractEvent interactEvent = new PlayerEntityInteractEvent {
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

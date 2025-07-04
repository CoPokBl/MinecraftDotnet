using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities.Types;

public class PlayerEntity : Entity {
    public string Name;
    public GameMode GameMode;

    public PlayerConnection Connection;
    public Func<PlayerConnection, bool> PlayerViewableRule { get; set; } = _ => true;
    public int WaitingTeleport = -1;
    
    // Listen to movement packets so we can do stuff
    public PlayerEntity(PlayerConnection connection, string name) : base(148) {
        Name = name;
        Connection = connection;
        ViewableRule = con => con != Connection && PlayerViewableRule(con);
        
        connection.Events.AddListener<PacketHandleEvent>(e => {
            switch (e.Packet) {
                case ServerBoundSetPlayerPositionPacket sp: {
                    if (WaitingTeleport != -1) return;
                    Move(sp.Position);
                    break;
                }

                case ServerBoundSetPlayerPosAndRotPacket sp: {
                    if (WaitingTeleport != -1) return;
                    Move(sp.Position, Angle.FromDegrees(sp.Yaw), Angle.FromDegrees(sp.Pitch));
                    break;
                }

                case ServerBoundSetPlayerRotationPacket sr: {
                    if (WaitingTeleport != -1) return;
                    Move(Position, Angle.FromDegrees(sr.Yaw), Angle.FromDegrees(sr.Pitch));
                    break;
                }

                // don't move player when they haven't sent ack for teleports
                case ServerBoundConfirmTeleportPacket ct: {
                    if (ct.TeleportId == WaitingTeleport) {
                        WaitingTeleport = -1;
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
    
    public void SetGameMode(GameMode mode) {
        GameMode = mode;
        Connection.SendPacket(ClientBoundGameEventPacket.ChangeGameMode(mode));
        SendToViewers(new ClientBoundPlayerInfoUpdatePacket {
            Data = new ClientBoundPlayerInfoUpdatePacket.PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateGameMode)
                .WithPlayer(Uuid, new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateGameMode {
                    GameMode = mode
                })
        });
    }

    public override void Teleport(Vec3 pos, Angle? yaw = null, Angle? pitch = null) {
        WaitingTeleport = Random.Shared.Next();
        Connection.SendPacket(new ClientBoundSynchronisePlayerPositionPacket {
            TeleportId = WaitingTeleport,
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
}
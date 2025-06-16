using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Entities;

public class PlayerEntity : Entity {
    public string Name;

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

                case ServerBoundSwingArmPacket sa: {
                    ClientBoundEntityAnimationPacket.AnimationType animation = sa.UsedHand switch {
                        Hand.MainHand => ClientBoundEntityAnimationPacket.AnimationType.SwingMainArm,
                        Hand.OffHand => ClientBoundEntityAnimationPacket.AnimationType.SwingOffhand,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    SendToViewers(new ClientBoundEntityAnimationPacket(NetId, animation));
                    break;
                }
            }
        });
    }
    
    public void SetVelocity(Vec3 velocity) {
        Connection.SendPacket(new ClientBoundSynchronisePlayerPositionPacket(
            Random.Shared.Next(),
            Vec3.Zero,
            velocity,
            0f,
            0f,
            TeleportFlags.RelativePosition | TeleportFlags.RelativeRotation));
    }

    public override void Teleport(Vec3 pos, Angle? yaw = null, Angle? pitch = null) {
        WaitingTeleport = Random.Shared.Next();
        Connection.SendPacket(new ClientBoundSynchronisePlayerPositionPacket(
            WaitingTeleport, 
            new PlayerPosition(pos, Vec3.Zero, yaw ?? Angle.Zero, pitch ?? Angle.Zero),
            TeleportFlags.None));
    }
    
    public override void Teleport(PlayerPosition pos) {
        WaitingTeleport = Random.Shared.Next();
        Connection.SendPacket(new ClientBoundSynchronisePlayerPositionPacket(
            WaitingTeleport, 
            pos,
            TeleportFlags.None));
    }

    public override void SendToSelfAndViewers(params MinecraftPacket[] packets) {
        Connection.SendPackets(packets);
        SendToViewers(packets);
    }

    public override MinecraftPacket[] GenerateSpawnEntityPackets() {
        MinecraftPacket[] arr = [
            new ClientBoundPlayerInfoUpdatePacket(
                new ClientBoundPlayerInfoUpdatePacket.PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions
                        .AddPlayer)
                    .WithPlayer(Uuid, new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                        Name = Name,
                        Properties = []
                    }))
        ];
        return arr.Combine(base.GenerateSpawnEntityPackets()).ToArray();
    }
}
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerStartBreakingBlockEvent), typeof(PlayerCancelBreakingBlockEvent), typeof(PlayerBreakBlockEvent))]
public class BlockBreakingFeature : ScopedFeature {
    private static readonly Tag<AtomicCounter> BreakTickCounterTag = new("managedserver:blockbreakingfeat:block_break_tick_counter");
    private static readonly Tag<Timer?> BlockBreakAnimationTimerTag = new("managedserver:blockbreakingfeat:block_break_animation_timer");
    private static readonly Tag<Destroying?> DestroyingTag = new("managedserver:blockbreakingfeat:destroying");

    /// <summary>The level event for a mining tick that also plays the hit sound, every fourth tick.</summary>
    private const int DestroyHitEvent = 2020;

    /// <summary>The level event for every other mining tick, particles only.</summary>
    private const int DestroyTickEvent = 2019;

    /// <summary>
    /// <c>ServerPlayerGameMode</c>'s <c>isDestroyingBlock</c>, <c>destroyPos</c>,
    /// <c>destroyProgressStart</c> and <c>destroyDirection</c>. The direction is the face as the
    /// packet numbers it, which is <c>Direction.ordinal</c>.
    /// </summary>
    private sealed class Destroying(Vec3<int> pos, ulong startTick, BlockFace direction) {
        public Vec3<int> Pos { get; } = pos;
        public ulong StartTick { get; } = startTick;
        public BlockFace Direction { get; set; } = direction;
    }

    public override void Register() {
        AddEventHandler<ServerTickEvent>(e => {
            foreach (Player player in e.Server.Players) {
                TickDestroying(e.Server.CurrentTick, player);
            }
        });

        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundPlayerActionPacket packet) {
                return;
            }
            
            MinecraftPacket ackPacket = new ClientBoundAcknowledgeBlockChangePacket {
                SequenceId = packet.Sequence
            };

            switch (packet.ActionStatus) {
                case ServerBoundPlayerActionPacket.Status.StartedDigging:
                    ProcessDigStart(e.Player, packet.Location, packet.Face);
                    e.Player.SendPacket(ackPacket);
                    break;
                case ServerBoundPlayerActionPacket.Status.ChangeDestroyDirection:
                    // Unacknowledged, as vanilla leaves it: the client sends it with sequence zero.
                    if (e.Player.GetTagOrNull(DestroyingTag) is { } destroying) {
                        destroying.Direction = packet.Face;
                    }
                    break;
                case ServerBoundPlayerActionPacket.Status.CancelledDigging:
                    ProcessDigCancel(e.Player, packet.Location);
                    e.Player.SendPacket(ackPacket);
                    break;
                case ServerBoundPlayerActionPacket.Status.FinishedDigging:
                    ProcessDigEnd(e.Player, packet.Location);
                    e.Player.SendPacket(ackPacket);
                    break;
            }
        });
    }
    
    /// <summary>
    /// The mining half of <c>ServerPlayerGameMode.tick</c>: a destroy whose block has gone stops, and
    /// one still going sends the mining level event with the direction as its data. Ticks are counted
    /// on the server's clock rather than the game mode's own, so which tick is a fourth one can be one
    /// off upstream's, depending on whether the start packet was handled before or after the tick.
    /// </summary>
    private static void TickDestroying(ulong currentTick, Player player) {
        if (player.GetTagOrNull(DestroyingTag) is not { } destroying || player.World is not { } world) {
            return;
        }

        if (world.GetBlock(destroying.Pos).Air) {
            player.SetTag(DestroyingTag, null);
            return;
        }

        ulong ticksSpentDestroying = currentTick - destroying.StartTick;
        world.GetAudienceOf(destroying.Pos).SendPacket(new ClientBoundWorldEventPacket {
            Event = ticksSpentDestroying % 4 == 0 ? DestroyHitEvent : DestroyTickEvent,
            Location = destroying.Pos,
            Data = (int)destroying.Direction,
            DisableRelativeVolume = false
        });
    }

    private void ProcessDigStart(Player player, Vec3<int> pos, BlockFace face) {
        IBlock block = player.World!.GetBlock(pos);
        
        PlayerStartBreakingBlockEvent startEvent = new() {
            Player = player,
            Position = pos,
            Block = block,
            World = player.World!
        };
        Scope.Events.CallEvent(startEvent);

        if (startEvent.Cancelled) {
            return;
        }
        
        int breakTicks = BlockUtils.GetBreakSpeed(player, block);

        if (breakTicks == 0) {
            // instamine
            BreakBlock(player, pos);
            return;
        }

        if (breakTicks < 0) {
            // negative break ticks means we can't break it
            player.World!.SendBlockUpdate(pos, player);
            return;
        }
        
        // mining over time
        player.SetTag(DestroyingTag, new Destroying(pos, Scope.Server.CurrentTick, face));
        player.GetTagOrNull(BlockBreakAnimationTimerTag)?.Dispose();
        float breakSeconds = breakTicks / 20.0f;
        TimeSpan breakTickDuration = TimeSpan.FromSeconds(breakSeconds / 9f);  // 9 break ticks occur before it breaks
        Timer breakTimer = new(_ => {
            player.GetAudience().SendPacket(new ClientBoundSetBlockDestroyStagePacket {
                Block = pos,
                EntityId = player.NetId,
                Stage = (byte)Math.Min(player.GetTagOrSetDefault(BreakTickCounterTag, new AtomicCounter(0, 20)).Next(), 9)
            });
        }, null, breakTickDuration, breakTickDuration);
        
        player.SetTag(BlockBreakAnimationTimerTag, breakTimer);
    }

    private void ProcessDigEnd(Player player, Vec3<int> pos) {
        player.SetTag(DestroyingTag, null);
        StopBlockBreakAnimation(player, pos);
        
        IBlock block = player.World!.GetBlock(pos);
        
        // Well they broke it
        BreakBlock(player, pos);
    }
    
    private void ProcessDigCancel(Player player, Vec3<int> pos) {
        PlayerCancelBreakingBlockEvent cancelEvent = new() {
            Player = player,
            Position = pos,
            Block = player.World!.GetBlock(pos),
            World = player.World!
        };
        Scope.Events.CallEvent(cancelEvent);

        // ServerPlayerGameMode.abortDestroyBlock: a cancel naming another block than the one being
        // destroyed clears that one's cracks as well.
        if (player.GetTagOrNull(DestroyingTag) is { } destroying && destroying.Pos != pos) {
            StopBlockBreakAnimation(player, destroying.Pos);
        }

        player.SetTag(DestroyingTag, null);
        StopBlockBreakAnimation(player, pos);
    }
    
    private static void StopBlockBreakAnimation(Player player, Vec3<int> pos) {
        player.GetTagOrNull(BlockBreakAnimationTimerTag)?.Dispose();
        player.SetTag(BlockBreakAnimationTimerTag, null);
        player.GetTagOrSetDefault(BreakTickCounterTag, new AtomicCounter(0, 20)).Value = 0;
        
        player.GetAudience().SendPacket(new ClientBoundSetBlockDestroyStagePacket {
            Block = pos,
            EntityId = player.NetId,
            Stage = 64  // invalid value means stop
        });
    }

    private void BreakBlock(Player player, Vec3<int> pos) {
        PlayerBreakBlockEvent breakEvent = new() {
            Player = player,
            Position = pos,
            World = player.World!,
            Block = player.World!.GetBlock(pos)
        };
        Scope.Events.CallEvent(breakEvent);
        
        if (breakEvent.Cancelled) {
            // don't break, send block update to client
            player.World!.SendBlockUpdate(pos, player);
            return;
        }
        
        player.World!.SetBlock(pos, Block.Air);
    }
}

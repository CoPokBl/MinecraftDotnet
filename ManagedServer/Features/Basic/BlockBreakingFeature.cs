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
    
    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundPlayerActionPacket packet) {
                return;
            }
            
            MinecraftPacket ackPacket = new ClientBoundAcknowledgeBlockChangePacket {
                SequenceId = packet.Sequence
            };

            switch (packet.ActionStatus) {
                case ServerBoundPlayerActionPacket.Status.StartedDigging:
                    ProcessDigStart(e.Player, packet.Location);
                    e.Player.SendPacket(ackPacket);
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
    
    private void ProcessDigStart(PlayerEntity player, Vec3<int> pos) {
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
        
        ItemStack heldItem = player.HeldItem;
        int breakTicks = BlockUtils.GetBreakSpeed(player.GameMode, block, heldItem, false, player.OnGround);

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

    private void ProcessDigEnd(PlayerEntity player, Vec3<int> pos) {
        StopBlockBreakAnimation(player, pos);
        
        IBlock block = player.World!.GetBlock(pos);
        
        // Well they broke it
        BreakBlock(player, pos);
    }
    
    private void ProcessDigCancel(PlayerEntity player, Vec3<int> pos) {
        PlayerCancelBreakingBlockEvent cancelEvent = new() {
            Player = player,
            Position = pos,
            Block = player.World!.GetBlock(pos),
            World = player.World!
        };
        Scope.Events.CallEvent(cancelEvent);
        
        StopBlockBreakAnimation(player, pos);
    }
    
    private static void StopBlockBreakAnimation(PlayerEntity player, Vec3<int> pos) {
        player.GetTagOrNull(BlockBreakAnimationTimerTag)?.Dispose();
        player.SetTag(BlockBreakAnimationTimerTag, null);
        player.GetTagOrSetDefault(BreakTickCounterTag, new AtomicCounter(0, 20)).Value = 0;
        
        player.GetAudience().SendPacket(new ClientBoundSetBlockDestroyStagePacket {
            Block = pos,
            EntityId = player.NetId,
            Stage = 64  // invalid value means stop
        });
    }

    private void BreakBlock(PlayerEntity player, Vec3<int> pos) {
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

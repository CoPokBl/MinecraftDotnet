using ClientLib;
using ClientLib.Interaction;
using ClientLib.Player;
using Minecraft.Data.Blocks;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Sounds;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;

namespace GraphicalClient.Audio;

/// <summary>
/// The sounds of an item held in use that the player's own client makes: <c>ItemStack.onUseTick</c>'s
/// eating and drinking, the last mouthful when the server says the use finished, the spyglass and the
/// brush.
/// </summary>
public sealed class ItemUseSounds {
    private readonly ClientSounds _sounds;
    private readonly MinecraftClient _client;
    private readonly LegacyRandom _random = new();

    public ItemUseSounds(ClientSounds sounds, MinecraftClient client) {
        _sounds = sounds;
        _client = client;
        client.Interactions.StartedUsingItem += (_, stack) => SpyglassSound(stack, SoundType.SpyglassUse);
        client.Interactions.ReleasedUsingItem += (_, stack) => SpyglassSound(stack, SoundType.SpyglassStopUsing);
    }

    private MultiPlayerGameMode GameMode => _client.Interactions;

    /// <summary>
    /// <c>LivingEntity.updatingUsingItem</c>'s <c>onUseTick</c>, once a tick after the hands have ticked:
    /// <see cref="MultiPlayerGameMode.UseItemRemainingTicks"/> is then the count vanilla passes it.
    /// </summary>
    public void Tick() {
        if (_client.Player is not { } player || GameMode.UsingItem is not { } usedHand) {
            return;
        }
        ItemStack useItem = player.ItemInHand(usedHand);
        if (!useItem.Type.Identifier.Equals(GameMode.UsedStack.Type.Identifier)) {
            return;
        }
        int ticksRemaining = GameMode.UseItemRemainingTicks;
        if (ItemComponents.Get(useItem, DataComponent.Consumable) is { } consumable && ShouldEmitParticlesAndSounds(consumable, ticksRemaining)) {
            EmitParticlesAndSounds(player, consumable);
        }
        if (useItem.Type.Identifier.Equals(Item.Brush.Identifier)) {
            BrushOnUseTick(ticksRemaining);
        }
    }

    /// <summary>
    /// <c>ClientPacketListener.handleEntityEvent</c> for event 9, <c>LivingEntity.completeUsingItem</c>:
    /// the server finished the use, and the client finishes it too. This runs before the client handles
    /// the packet, so the use has not stopped yet.
    /// </summary>
    public void Handle(MinecraftPacket packet) {
        if (packet is not ClientBoundEntityEventPacket { Status: ClientBoundEntityEventPacket.EntityEventType.PlayerFinishedUsing } entityEvent
            || _client.Player is not { IsUsingItem: true } player || entityEvent.EntityId != player.Id) {
            return;
        }
        ItemStack useItem = player.UseItem;
        if (ItemComponents.IsEmpty(useItem)) {
            return;
        }
        // completeUsingItem releases rather than finishes a use whose hand no longer holds the stack.
        if (!useItem.Equals(player.ItemInHand(player.UsedItemHand))) {
            SpyglassSound(useItem, SoundType.SpyglassStopUsing);
            return;
        }
        // Item.finishUsingItem: Consumable.onConsume, whose emission is the sixteen particle one.
        if (ItemComponents.Get(useItem, DataComponent.Consumable) is { } consumable) {
            EmitParticlesAndSounds(player, consumable);
        }
        // SpyglassItem.finishUsingItem, when the 1200 ticks run out.
        SpyglassSound(useItem, SoundType.SpyglassStopUsing);
    }

    /// <summary><c>Consumable.shouldEmitParticlesAndSounds</c>.</summary>
    private static bool ShouldEmitParticlesAndSounds(ConsumableComponent.Data consumable, int useItemRemainingTicks) {
        int consumeTicks = (int)(consumable.ConsumeSeconds * 20.0F);
        int itemUsedForTicks = consumeTicks - useItemRemainingTicks;
        int waitTicksBeforeUseEffects = (int)(consumeTicks * 0.21875F);
        bool isValidTime = itemUsedForTicks > waitTicksBeforeUseEffects;
        return isValidTime && useItemRemainingTicks % 4 == 0;
    }

    /// <summary>
    /// <c>Consumable.emitParticlesAndSounds</c>. A player overrides no consume sound. Every draw is
    /// made whichever animation it is, as vanilla makes them.
    /// </summary>
    private void EmitParticlesAndSounds(LocalPlayer player, ConsumableComponent.Data consumable) {
        float eatVolume = _random.NextBoolean() ? 0.5F : 1.0F;
        float eatPitch = _random.Triangle(1.0F, 0.2F);
        float drinkPitch = _random.RandomBetween(0.9F, 1.0F);
        bool drink = consumable.Animation == ConsumableComponent.ConsumeAnimation.Drink;
        float consumableVolume = drink ? 0.5F : eatVolume;
        float consumablePitch = drink ? drinkPitch : eatPitch;
        _sounds.PlayFromPlayer(player, ClientSounds.TypeOf(consumable.Sound), consumableVolume, consumablePitch);
    }

    /// <summary>The <c>Item.use</c> and <c>Item.releaseUsing</c> sounds of items held in use.</summary>
    private void SpyglassSound(ItemStack stack, ISoundType sound) {
        if (_client.Player is { } player && stack.Type.Identifier.Equals(Item.Spyglass.Identifier)) {
            _sounds.PlayFromPlayer(player, sound, 1.0F, 1.0F);
        }
    }

    /// <summary>
    /// <c>BrushItem.onUseTick</c>'s sound. Vanilla asks <c>getHitResultOnViewVector</c> within the block
    /// interaction range; the crosshair's target stands in for it, which differs only when an entity
    /// out of block range but inside entity range is in the way.
    /// </summary>
    private void BrushOnUseTick(int ticksRemaining) {
        if (ticksRemaining < 0 || GameMode.Target is not BlockHitResult blockHitResult || _client.Level is not { } level) {
            return;
        }
        int timeElapsed = GameMode.UseDuration - ticksRemaining + 1;
        bool isLastTickBeforeBackswing = timeElapsed % 10 == 5;
        if (isLastTickBeforeBackswing) {
            IBlock state = level.GetBlock(blockHitResult.X, blockHitResult.Y, blockHitResult.Z);
            _sounds.PlayAtBlock(blockHitResult.X, blockHitResult.Y, blockHitResult.Z, BrushSoundOf(state) ?? SoundType.BrushBrushingGeneric, SoundCategory.Blocks, 1.0F, 1.0F);
        }
    }

    /// <summary><c>BrushableBlock.getBrushSound</c>, which the two brushable blocks are built with; null for any other block.</summary>
    internal static ISoundType? BrushSoundOf(IBlock state) => state switch {
        SuspiciousSandBlock => SoundType.BrushBrushingSand,
        SuspiciousGravelBlock => SoundType.BrushBrushingGravel,
        _ => null
    };
}

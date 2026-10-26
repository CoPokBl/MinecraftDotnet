using ClientLib;
using ClientLib.Interaction;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace GraphicalClient.Audio;

/// <summary>
/// What the player's hands sound like to the player: the hit as <c>MultiPlayerGameMode.startDestroyBlock</c>
/// starts digging, and the <c>level.playSound(player, ...)</c> calls an item's <c>useOn</c> makes, which a server
/// plays to everyone else.
/// </summary>
public sealed class GameModeSounds {
    private readonly ClientSounds _sounds;
    private readonly MinecraftClient _client;
    private readonly LegacyRandom _levelRandom = new();

    public GameModeSounds(ClientSounds sounds, MinecraftClient client) {
        _sounds = sounds;
        _client = client;
        client.Interactions.DestroyHit += DestroyHit;
        client.Interactions.UsedItemOn += UsedItemOn;
        client.Interactions.PlacedBlock += (pos, placedState, item) => BlockItemPlace(pos, placedState, item.Type.Identifier);
    }

    /// <summary><c>ClientLevel.playBreakingSound</c> as digging starts, a <c>SimpleSoundInstance</c> at the block's centre.</summary>
    private void DestroyHit((int X, int Y, int Z) pos, IBlock state) {
        BlockSoundGroup soundType = BlockSoundGroups.Of(state);
        PlayAt(pos, soundType.Hit, (soundType.Volume + 1.0F) / 8.0F, soundType.Pitch * 0.5F);
    }

    private void PlayAt((int X, int Y, int Z) pos, ISoundType sound, float volume, float pitch) =>
        _sounds.PlayAtBlock(pos.X, pos.Y, pos.Z, sound, SoundCategory.Blocks, volume, pitch);

    private IBlock StateOf(ushort state) => _client.Registry.Blocks.GetByStateId(state);

    /// <summary>
    /// The sounding half of the <c>useOn</c> each tool ran, told from what the server's answer changed
    /// at the clicked block and the one against its face.
    /// </summary>
    private void UsedItemOn(UseOnOutcome use) {
        if (use.Item.Type.Identifier.Equals(Item.FlintAndSteel.Identifier)) {
            FlintAndSteelUseOn(use);
        }
        else if (use.Tool is { Sound: { } sound } tool) {
            // BlockTransformer.transformBlock's sound, or HoneycombItem.useOn's.
            PlayAt(use.Clicked, sound, 1.0F, 1.0F);
            if (tool.PartnerRepeatsSound) {
                PlayAt(use.Clicked, sound, 1.0F, 1.0F);
            }
        }
    }

    /// <summary><c>BlockItem.place</c>'s sound, from the state that ended up placed.</summary>
    private void BlockItemPlace((int X, int Y, int Z) pos, IBlock placedState, Identifier item) {
        BlockSoundGroup soundType = BlockSoundGroups.Of(placedState);
        // SolidBucketItem.getPlaceSound: the powder snow bucket sounds like a bucket, not like snow.
        ISoundType placeSound = item.Equals(Item.PowderSnowBucket.Identifier) ? SoundType.BucketEmptyPowderSnow : soundType.Place;
        PlayAt(pos, placeSound, (soundType.Volume + 1.0F) / 2.0F, soundType.Pitch * 0.8F);
    }

    /// <summary>
    /// <c>FlintAndSteelItem.useOn</c>: lighting a candle, a cake's candle or a campfire sounds at it;
    /// otherwise fire placed against the face sounds there.
    /// </summary>
    private void FlintAndSteelUseOn(UseOnOutcome use) {
        IBlock before = StateOf(use.ClickedBefore);
        IBlock after = StateOf(use.ClickedAfter);
        if (before is ILit { Lit: false } && after is ILit { Lit: true } && before.Identifier.Equals(after.Identifier)) {
            PlayAt(use.Clicked, SoundType.FlintandsteelUse, 1.0F, _levelRandom.NextFloat() * 0.4F + 0.8F);
            return;
        }
        Identifier placed = StateOf(use.AgainstAfter).Identifier;
        if (use.AgainstAfter != use.AgainstBefore && (placed.Equals(Block.Fire.Identifier) || placed.Equals(Block.SoulFire.Identifier))) {
            PlayAt(use.Against, SoundType.FlintandsteelUse, 1.0F, _levelRandom.NextFloat() * 0.4F + 0.8F);
        }
    }
}

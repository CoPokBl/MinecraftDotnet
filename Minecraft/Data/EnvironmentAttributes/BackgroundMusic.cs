using Minecraft.Registry;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// The music the client plays here, picked by what the player is doing. Leaving all three unset is
/// how the vanilla data says "silence", and <c>minecraft:pale_garden</c> does exactly that.
/// </summary>
public record BackgroundMusic(Music? Default, Music? Creative, Music? Underwater) {

    public static readonly BackgroundMusic Silent = new(null, null, null);

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [];

        if (Default != null) {
            children.Add(("default", Default.ToNbt()));
        }

        if (Creative != null) {
            children.Add(("creative", Creative.ToNbt()));
        }

        if (Underwater != null) {
            children.Add(("underwater", Underwater.ToNbt()));
        }

        return new CompoundTag(children.ToArray());
    }

    public static BackgroundMusic FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new BackgroundMusic(
            compound.Contains("default") ? Music.FromNbt(compound["default"]!, reg) : null,
            compound.Contains("creative") ? Music.FromNbt(compound["creative"]!, reg) : null,
            compound.Contains("underwater") ? Music.FromNbt(compound["underwater"]!, reg) : null);
    }
}

/// <param name="MinDelay">Least number of ticks between plays.</param>
/// <param name="MaxDelay">Most number of ticks between plays.</param>
/// <param name="ReplaceCurrentMusic">Whether this cuts off whatever is already playing.</param>
public record Music(SoundEvent Sound, int MinDelay, int MaxDelay, bool ReplaceCurrentMusic = false) {

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("sound", Sound.ToNbt()),
            ("min_delay", new IntegerTag(MinDelay)),
            ("max_delay", new IntegerTag(MaxDelay))
        ];

        if (ReplaceCurrentMusic) {
            children.Add(("replace_current_music", new BooleanTag(true)));
        }

        return new CompoundTag(children.ToArray());
    }

    public static Music FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new Music(
            SoundEvent.FromNbt(compound["sound"]!, reg),
            compound["min_delay"]!.AsInt(),
            compound["max_delay"]!.AsInt(),
            compound.Contains("replace_current_music") && compound["replace_current_music"]!.AsBool());
    }
}

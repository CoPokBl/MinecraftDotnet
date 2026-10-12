using Minecraft.Registry;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>The background noise the client plays while the listener is somewhere with this set.</summary>
/// <param name="Loop">Played continuously.</param>
/// <param name="Mood">The cave noises that build up while the listener is somewhere dark.</param>
/// <param name="Additions">One shot sounds rolled for every tick.</param>
public record AmbientSounds(
    SoundEvent? Loop,
    AmbientMoodSettings? Mood,
    AmbientAdditionsSettings[] Additions) {

    public static readonly AmbientSounds None = new(null, null, []);

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [];

        if (Loop != null) {
            children.Add(("loop", Loop.ToNbt()));
        }

        if (Mood != null) {
            children.Add(("mood", Mood.ToNbt()));
        }

        if (Additions.Length > 0) {
            children.Add(("additions", Additions.Length == 1
                // A single addition is written unwrapped, which is what the vanilla data does
                ? Additions[0].ToNbt()
                : new ListTag<CompoundTag>(Additions.Select(a => (CompoundTag)a.ToNbt()).ToArray())));
        }

        return new CompoundTag(children.ToArray());
    }

    public static AmbientSounds FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;

        AmbientAdditionsSettings[] additions = [];
        if (compound.Contains("additions")) {
            additions = compound["additions"]!.AsCompactList()
                .Select(t => AmbientAdditionsSettings.FromNbt(t, reg))
                .ToArray();
        }

        return new AmbientSounds(
            compound.Contains("loop") ? SoundEvent.FromNbt(compound["loop"]!, reg) : null,
            compound.Contains("mood") ? AmbientMoodSettings.FromNbt(compound["mood"]!, reg) : null,
            additions);
    }

    public virtual bool Equals(AmbientSounds? other) {
        return other != null && Loop == other.Loop && Mood == other.Mood
               && Additions.SequenceEqual(other.Additions);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Loop, Mood, Additions.Length);
    }
}

/// <param name="TickDelay">Ticks of darkness before the sound may play.</param>
/// <param name="BlockSearchExtent">How far around the listener counts as dark.</param>
/// <param name="Offset">How far from the listener the sound is placed.</param>
public record AmbientMoodSettings(SoundEvent Sound, int TickDelay, int BlockSearchExtent, double Offset) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("sound", Sound.ToNbt()),
            ("tick_delay", new IntegerTag(TickDelay)),
            ("block_search_extent", new IntegerTag(BlockSearchExtent)),
            ("offset", new DoubleTag(Offset)));
    }

    public static AmbientMoodSettings FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new AmbientMoodSettings(
            SoundEvent.FromNbt(compound["sound"]!, reg),
            compound["tick_delay"]!.AsInt(),
            compound["block_search_extent"]!.AsInt(),
            compound["offset"]!.AsDouble());
    }
}

/// <param name="TickChance">Chance per tick that the sound plays.</param>
public record AmbientAdditionsSettings(SoundEvent Sound, double TickChance) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("sound", Sound.ToNbt()),
            ("tick_chance", new DoubleTag(TickChance)));
    }

    public static AmbientAdditionsSettings FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new AmbientAdditionsSettings(
            SoundEvent.FromNbt(compound["sound"]!, reg),
            compound["tick_chance"]!.AsDouble());
    }
}

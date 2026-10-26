using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Text;

namespace Minecraft.Data.JukeboxSong;

public record SimpleJukeboxSong(
    Identifier Identifier,
    SoundEvent SoundEvent,
    TextComponent Description,
    float LengthInSeconds,
    int ComparatorOutput) : IJukeboxSong;

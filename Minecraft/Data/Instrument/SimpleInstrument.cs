using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Text;

namespace Minecraft.Data.Instrument;

public record SimpleInstrument(
    Identifier Identifier,
    SoundEvent SoundEvent,
    float UseDuration,
    float Range,
    TextComponent Description) : IInstrument;

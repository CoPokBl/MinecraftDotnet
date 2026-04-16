using Minecraft.Schemas;
using NBT.Tags;

namespace Minecraft.Data.Timelines;

public record SimpleTimeline(
    Identifier Identifier,
    CompoundTag Data) : ITimeline;

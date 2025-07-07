using Minecraft.Schemas;

namespace Minecraft.Data.Sounds;

public record SimpleSoundType(Identifier Identifier, int ProtocolId) : ISoundType;

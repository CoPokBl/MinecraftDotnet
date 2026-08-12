using Minecraft.Schemas;
using Minecraft.Schemas.Tags;

namespace Minecraft.Data.SulfurCubeArchetype;

public record SimpleSulfurCubeArchetype(
    Identifier Identifier,
    HolderSet Items,
    SulfurCubeAttributeEntry[] AttributeModifiers,
    bool Buoyant,
    SulfurCubeExplosion? Explosion,
    SulfurCubeContactDamage? ContactDamage,
    SulfurCubeKnockbackModifiers KnockbackModifiers,
    SulfurCubeSoundSettings SoundSettings) : ISulfurCubeArchetype;

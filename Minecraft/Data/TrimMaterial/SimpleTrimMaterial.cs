using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.TrimMaterial;

public record SimpleTrimMaterial(Identifier Identifier, Identifier PaletteId, TextComponent Description) : ITrimMaterial;

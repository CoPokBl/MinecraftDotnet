using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class HorseRenderState : EquineRenderState {
    public HorseVariant Variant = HorseVariant.White;
    public HorseMarkings Markings = HorseMarkings.None;
}

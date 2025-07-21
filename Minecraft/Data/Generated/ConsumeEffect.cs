using Minecraft.Data.ConsumeEffects;
using Minecraft.Data.ConsumeEffects.Types;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
public static class ConsumeEffect {
    public static readonly ApplyEffectsConsumeEffect ApplyEffects = new("minecraft:apply_effects", 0);
    public static readonly SimpleConsumeEffect ClearAllEffects = new("minecraft:clear_all_effects", 2);
    public static readonly PlaySoundConsumeEffect PlaySound = new("minecraft:play_sound", 4);
    public static readonly RemoveEffectsConsumeEffect RemoveEffects = new("minecraft:remove_effects", 1);
    public static readonly TeleportRandomlyConsumeEffect TeleportRandomly = new("minecraft:teleport_randomly", 3);
}

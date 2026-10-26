using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities;

public static partial class EntityRenderers {
    static partial void RegisterAquatic() {
        Register(EntityType.Cod, context => new CodRenderer(context));
        Register(EntityType.Salmon, context => new SalmonRenderer(context));
        Register(EntityType.Pufferfish, context => new PufferfishRenderer(context));
        Register(EntityType.TropicalFish, context => new TropicalFishRenderer(context));
        Register(EntityType.Squid, context => new SquidRenderer(context));
        Register(EntityType.GlowSquid, context => new GlowSquidRenderer(context));
        Register(EntityType.Dolphin, context => new DolphinRenderer(context));
        Register(EntityType.Guardian, context => new GuardianRenderer(context));
        Register(EntityType.ElderGuardian, context => new ElderGuardianRenderer(context));
        Register(EntityType.Nautilus, context => new NautilusRenderer(context));
        Register(EntityType.ZombieNautilus, context => new ZombieNautilusRenderer(context));
    }
}

using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities;

public static partial class EntityRenderers {
    static partial void RegisterIllagersAndVillagers() {
        Register(EntityType.Villager, context => new VillagerRenderer(context));
        Register(EntityType.WanderingTrader, context => new WanderingTraderRenderer(context));
        Register(EntityType.Witch, context => new WitchRenderer(context));
        Register(EntityType.Pillager, context => new PillagerRenderer(context));
        Register(EntityType.Vindicator, context => new VindicatorRenderer(context));
        Register(EntityType.Evoker, context => new EvokerRenderer(context));
        Register(EntityType.Illusioner, context => new IllusionerRenderer(context));
        Register(EntityType.Ravager, context => new RavagerRenderer(context));
        Register(EntityType.Vex, context => new VexRenderer(context));
        Register(EntityType.Allay, context => new AllayRenderer(context));
        Register(EntityType.IronGolem, context => new IronGolemRenderer(context));
        Register(EntityType.SnowGolem, context => new SnowGolemRenderer(context));
        Register(EntityType.CopperGolem, context => new CopperGolemRenderer(context));
        Register(EntityType.EvokerFangs, context => new EvokerFangsRenderer(context));
    }
}

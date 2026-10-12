using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities;

public static partial class EntityRenderers {
    static partial void RegisterArthropodsAndBosses() {
        Register(EntityType.Spider, context => new SpiderRenderer(context));
        Register(EntityType.CaveSpider, context => new CaveSpiderRenderer(context));
        Register(EntityType.Silverfish, context => new SilverfishRenderer(context));
        Register(EntityType.Endermite, context => new EndermiteRenderer(context));
        Register(EntityType.Slime, context => new SlimeRenderer(context));
        Register(EntityType.MagmaCube, context => new MagmaCubeRenderer(context));
        Register(EntityType.SulfurCube, context => new SulfurCubeRenderer(context));
        Register(EntityType.Shulker, context => new ShulkerRenderer(context));
        Register(EntityType.Creaking, context => new CreakingRenderer(context));
        Register(EntityType.Warden, context => new WardenRenderer(context));
        Register(EntityType.EnderDragon, context => new EnderDragonRenderer(context));
        Register(EntityType.Wither, context => new WitherBossRenderer(context));
        Register(EntityType.EndCrystal, context => new EndCrystalRenderer(context));
    }
}

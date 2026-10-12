using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities;

public static partial class EntityRenderers {
    static partial void RegisterSmallAndFlying() {
        Register(EntityType.Chicken, context => new ChickenRenderer(context));
        Register(EntityType.Parrot, context => new ParrotRenderer(context));
        Register(EntityType.Bee, context => new BeeRenderer(context));
        Register(EntityType.Bat, context => new BatRenderer(context));
        Register(EntityType.Frog, context => new FrogRenderer(context));
        Register(EntityType.Tadpole, context => new TadpoleRenderer(context));
        Register(EntityType.Axolotl, context => new AxolotlRenderer(context));
        Register(EntityType.Ghast, context => new GhastRenderer(context));
        Register(EntityType.HappyGhast, context => new HappyGhastRenderer(context));
        Register(EntityType.Phantom, context => new PhantomRenderer(context));
        Register(EntityType.Blaze, context => new BlazeRenderer(context));
        Register(EntityType.Breeze, context => new BreezeRenderer(context));
    }
}

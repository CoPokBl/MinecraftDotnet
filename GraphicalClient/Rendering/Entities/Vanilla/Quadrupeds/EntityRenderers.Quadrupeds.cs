using Minecraft.Data.Generated;
using GraphicalClient.Rendering.Entities.Vanilla;

namespace GraphicalClient.Rendering.Entities;

public static partial class EntityRenderers {
    static partial void RegisterQuadrupeds() {
        Register(EntityType.Cow, _ => new CowRenderer());
        Register(EntityType.Mooshroom, context => new MushroomCowRenderer(context));
        Register(EntityType.Pig, context => new PigRenderer(context));
        Register(EntityType.Sheep, context => new SheepRenderer(context));
        Register(EntityType.PolarBear, _ => new PolarBearRenderer());
        Register(EntityType.Panda, context => new PandaRenderer(context));
        Register(EntityType.Goat, _ => new GoatRenderer());
        Register(EntityType.Turtle, _ => new TurtleRenderer());
        Register(EntityType.Sniffer, _ => new SnifferRenderer());
        Register(EntityType.Hoglin, _ => new HoglinRenderer());
        Register(EntityType.Zoglin, _ => new ZoglinRenderer());
        Register(EntityType.Armadillo, _ => new ArmadilloRenderer());
        Register(EntityType.Camel, context => new CamelRenderer(context));
        Register(EntityType.CamelHusk, context => new CamelHuskRenderer(context));
        Register(EntityType.Strider, context => new StriderRenderer(context));
    }
}

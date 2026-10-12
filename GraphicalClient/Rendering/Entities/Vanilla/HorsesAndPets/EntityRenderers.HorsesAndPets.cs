using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities;

public static partial class EntityRenderers {
    static partial void RegisterHorsesAndPets() {
        Register(EntityType.Horse, context => new HorseRenderer(context));
        Register(EntityType.Donkey, context => new DonkeyRenderer(context, DonkeyRenderer.Type.Donkey));
        Register(EntityType.Mule, context => new DonkeyRenderer(context, DonkeyRenderer.Type.Mule));
        Register(EntityType.SkeletonHorse, context => new UndeadHorseRenderer(context, UndeadHorseRenderer.Type.Skeleton));
        Register(EntityType.ZombieHorse, context => new UndeadHorseRenderer(context, UndeadHorseRenderer.Type.Zombie));
        Register(EntityType.Llama, context => new LlamaRenderer(context));
        Register(EntityType.TraderLlama, context => new LlamaRenderer(context));
        Register(EntityType.Wolf, context => new WolfRenderer(context));
        Register(EntityType.Cat, _ => new CatRenderer());
        Register(EntityType.Ocelot, _ => new OcelotRenderer());
        Register(EntityType.Fox, context => new FoxRenderer(context));
        Register(EntityType.Rabbit, _ => new RabbitRenderer());
    }
}

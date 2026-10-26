using Minecraft.Data.Generated;
using GraphicalClient.Rendering.Entities.Vanilla;

namespace GraphicalClient.Rendering.Entities;

public static partial class EntityRenderers {
    static partial void RegisterHumanoids() {
        Register(EntityType.Player, context => new AvatarRenderers(context));
        Register(EntityType.Mannequin, context => new AvatarRenderers(context));
        Register(EntityType.ArmorStand, context => new ArmorStandRenderer(context));
        Register(EntityType.Bogged, context => new BoggedRenderer(context));
        Register(EntityType.Drowned, context => new DrownedRenderer(context));
        Register(EntityType.Enderman, context => new EndermanRenderer(context));
        Register(EntityType.Giant, context => new GiantMobRenderer(context, 6.0F));
        Register(EntityType.Husk, context => new HuskRenderer(context));
        Register(EntityType.Parched, context => new ParchedRenderer(context));
        Register(EntityType.Piglin, PiglinRenderer.Piglin);
        Register(EntityType.PiglinBrute, PiglinRenderer.PiglinBrute);
        Register(EntityType.Skeleton, context => new SkeletonRenderer(context));
        Register(EntityType.Stray, context => new StrayRenderer(context));
        Register(EntityType.WitherSkeleton, context => new WitherSkeletonRenderer(context));
        Register(EntityType.Zombie, context => new ZombieRenderer(context));
        Register(EntityType.ZombieVillager, context => new ZombieVillagerRenderer(context));
        Register(EntityType.ZombifiedPiglin, context => new ZombifiedPiglinRenderer(context));
    }
}

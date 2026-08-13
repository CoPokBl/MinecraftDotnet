using Minecraft.Schemas;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
/// <summary>
/// A vanilla entity Java class, as named by <see cref="EntityClasses"/>.
/// <p/>
/// One member per distinct class in the table, so a name that does not exist upstream does not
/// compile, and a rename on a version bump breaks the build rather than silently matching nothing.
/// <see cref="Custom"/> is the way out for a class this build has never heard of; it is deliberately
/// wordy, because reaching for it is usually a mistake.
/// </summary>
public readonly record struct EntityClass {
    private readonly string? _name;

    private EntityClass(string name) {
        _name = name;
    }

    /// <summary>The simple Java class name. Empty for a default-constructed value.</summary>
    public string Name => _name ?? "";

    /// <summary>
    /// A class this build's table does not contain. Matches nothing unless something upstream of the
    /// generator puts the name into a chain, so it is only useful to code that extends the tables.
    /// </summary>
    public static EntityClass Custom(string name) {
        return new EntityClass(name);
    }

    public override string ToString() {
        return Name;
    }

    public static readonly EntityClass AbstractArrow = new("AbstractArrow");
    public static readonly EntityClass AbstractBoat = new("AbstractBoat");
    public static readonly EntityClass AbstractChestBoat = new("AbstractChestBoat");
    public static readonly EntityClass AbstractChestedHorse = new("AbstractChestedHorse");
    public static readonly EntityClass AbstractCow = new("AbstractCow");
    public static readonly EntityClass AbstractCubeMob = new("AbstractCubeMob");
    public static readonly EntityClass AbstractFish = new("AbstractFish");
    public static readonly EntityClass AbstractGolem = new("AbstractGolem");
    public static readonly EntityClass AbstractHorse = new("AbstractHorse");
    public static readonly EntityClass AbstractHurtingProjectile = new("AbstractHurtingProjectile");
    public static readonly EntityClass AbstractIllager = new("AbstractIllager");
    public static readonly EntityClass AbstractMinecart = new("AbstractMinecart");
    public static readonly EntityClass AbstractMinecartContainer = new("AbstractMinecartContainer");
    public static readonly EntityClass AbstractNautilus = new("AbstractNautilus");
    public static readonly EntityClass AbstractPiglin = new("AbstractPiglin");
    public static readonly EntityClass AbstractSchoolingFish = new("AbstractSchoolingFish");
    public static readonly EntityClass AbstractSkeleton = new("AbstractSkeleton");
    public static readonly EntityClass AbstractThrownPotion = new("AbstractThrownPotion");
    public static readonly EntityClass AbstractVillager = new("AbstractVillager");
    public static readonly EntityClass AbstractWindCharge = new("AbstractWindCharge");
    public static readonly EntityClass AgeableMob = new("AgeableMob");
    public static readonly EntityClass AgeableWaterCreature = new("AgeableWaterCreature");
    public static readonly EntityClass Allay = new("Allay");
    public static readonly EntityClass AmbientCreature = new("AmbientCreature");
    public static readonly EntityClass Animal = new("Animal");
    public static readonly EntityClass AreaEffectCloud = new("AreaEffectCloud");
    public static readonly EntityClass Armadillo = new("Armadillo");
    public static readonly EntityClass ArmorStand = new("ArmorStand");
    public static readonly EntityClass Arrow = new("Arrow");
    public static readonly EntityClass Avatar = new("Avatar");
    public static readonly EntityClass Axolotl = new("Axolotl");
    public static readonly EntityClass Bat = new("Bat");
    public static readonly EntityClass Bee = new("Bee");
    public static readonly EntityClass Blaze = new("Blaze");
    public static readonly EntityClass BlockAttachedEntity = new("BlockAttachedEntity");
    public static readonly EntityClass BlockDisplay = new("BlockDisplay");
    public static readonly EntityClass Boat = new("Boat");
    public static readonly EntityClass Bogged = new("Bogged");
    public static readonly EntityClass Breeze = new("Breeze");
    public static readonly EntityClass BreezeWindCharge = new("BreezeWindCharge");
    public static readonly EntityClass Camel = new("Camel");
    public static readonly EntityClass CamelHusk = new("CamelHusk");
    public static readonly EntityClass Cat = new("Cat");
    public static readonly EntityClass CaveSpider = new("CaveSpider");
    public static readonly EntityClass ChestBoat = new("ChestBoat");
    public static readonly EntityClass ChestRaft = new("ChestRaft");
    public static readonly EntityClass Chicken = new("Chicken");
    public static readonly EntityClass Cod = new("Cod");
    public static readonly EntityClass CopperGolem = new("CopperGolem");
    public static readonly EntityClass Cow = new("Cow");
    public static readonly EntityClass Creaking = new("Creaking");
    public static readonly EntityClass Creeper = new("Creeper");
    public static readonly EntityClass Display = new("Display");
    public static readonly EntityClass Dolphin = new("Dolphin");
    public static readonly EntityClass Donkey = new("Donkey");
    public static readonly EntityClass DragonFireball = new("DragonFireball");
    public static readonly EntityClass Drowned = new("Drowned");
    public static readonly EntityClass ElderGuardian = new("ElderGuardian");
    public static readonly EntityClass EndCrystal = new("EndCrystal");
    public static readonly EntityClass EnderDragon = new("EnderDragon");
    public static readonly EntityClass EnderMan = new("EnderMan");
    public static readonly EntityClass Endermite = new("Endermite");
    public static readonly EntityClass Entity = new("Entity");
    public static readonly EntityClass Evoker = new("Evoker");
    public static readonly EntityClass EvokerFangs = new("EvokerFangs");
    public static readonly EntityClass ExperienceOrb = new("ExperienceOrb");
    public static readonly EntityClass EyeOfEnder = new("EyeOfEnder");
    public static readonly EntityClass FallingBlockEntity = new("FallingBlockEntity");
    public static readonly EntityClass Fireball = new("Fireball");
    public static readonly EntityClass FireworkRocketEntity = new("FireworkRocketEntity");
    public static readonly EntityClass FishingHook = new("FishingHook");
    public static readonly EntityClass Fox = new("Fox");
    public static readonly EntityClass Frog = new("Frog");
    public static readonly EntityClass Ghast = new("Ghast");
    public static readonly EntityClass Giant = new("Giant");
    public static readonly EntityClass GlowItemFrame = new("GlowItemFrame");
    public static readonly EntityClass GlowSquid = new("GlowSquid");
    public static readonly EntityClass Goat = new("Goat");
    public static readonly EntityClass Guardian = new("Guardian");
    public static readonly EntityClass HangingEntity = new("HangingEntity");
    public static readonly EntityClass HappyGhast = new("HappyGhast");
    public static readonly EntityClass Hoglin = new("Hoglin");
    public static readonly EntityClass Horse = new("Horse");
    public static readonly EntityClass Husk = new("Husk");
    public static readonly EntityClass Illusioner = new("Illusioner");
    public static readonly EntityClass Interaction = new("Interaction");
    public static readonly EntityClass IronGolem = new("IronGolem");
    public static readonly EntityClass ItemDisplay = new("ItemDisplay");
    public static readonly EntityClass ItemEntity = new("ItemEntity");
    public static readonly EntityClass ItemFrame = new("ItemFrame");
    public static readonly EntityClass LargeFireball = new("LargeFireball");
    public static readonly EntityClass LeashFenceKnotEntity = new("LeashFenceKnotEntity");
    public static readonly EntityClass LightningBolt = new("LightningBolt");
    public static readonly EntityClass LivingEntity = new("LivingEntity");
    public static readonly EntityClass Llama = new("Llama");
    public static readonly EntityClass LlamaSpit = new("LlamaSpit");
    public static readonly EntityClass MagmaCube = new("MagmaCube");
    public static readonly EntityClass Mannequin = new("Mannequin");
    public static readonly EntityClass Marker = new("Marker");
    public static readonly EntityClass Minecart = new("Minecart");
    public static readonly EntityClass MinecartChest = new("MinecartChest");
    public static readonly EntityClass MinecartCommandBlock = new("MinecartCommandBlock");
    public static readonly EntityClass MinecartFurnace = new("MinecartFurnace");
    public static readonly EntityClass MinecartHopper = new("MinecartHopper");
    public static readonly EntityClass MinecartSpawner = new("MinecartSpawner");
    public static readonly EntityClass MinecartTNT = new("MinecartTNT");
    public static readonly EntityClass Mob = new("Mob");
    public static readonly EntityClass Monster = new("Monster");
    public static readonly EntityClass Mule = new("Mule");
    public static readonly EntityClass MushroomCow = new("MushroomCow");
    public static readonly EntityClass Nautilus = new("Nautilus");
    public static readonly EntityClass Ocelot = new("Ocelot");
    public static readonly EntityClass OminousItemSpawner = new("OminousItemSpawner");
    public static readonly EntityClass Painting = new("Painting");
    public static readonly EntityClass Panda = new("Panda");
    public static readonly EntityClass Parched = new("Parched");
    public static readonly EntityClass Parrot = new("Parrot");
    public static readonly EntityClass PathfinderMob = new("PathfinderMob");
    public static readonly EntityClass PatrollingMonster = new("PatrollingMonster");
    public static readonly EntityClass Phantom = new("Phantom");
    public static readonly EntityClass Pig = new("Pig");
    public static readonly EntityClass Piglin = new("Piglin");
    public static readonly EntityClass PiglinBrute = new("PiglinBrute");
    public static readonly EntityClass Pillager = new("Pillager");
    public static readonly EntityClass Player = new("Player");
    public static readonly EntityClass PolarBear = new("PolarBear");
    public static readonly EntityClass PrimedTnt = new("PrimedTnt");
    public static readonly EntityClass Projectile = new("Projectile");
    public static readonly EntityClass Pufferfish = new("Pufferfish");
    public static readonly EntityClass Rabbit = new("Rabbit");
    public static readonly EntityClass Raft = new("Raft");
    public static readonly EntityClass Raider = new("Raider");
    public static readonly EntityClass Ravager = new("Ravager");
    public static readonly EntityClass Salmon = new("Salmon");
    public static readonly EntityClass Sheep = new("Sheep");
    public static readonly EntityClass ShoulderRidingEntity = new("ShoulderRidingEntity");
    public static readonly EntityClass Shulker = new("Shulker");
    public static readonly EntityClass ShulkerBullet = new("ShulkerBullet");
    public static readonly EntityClass Silverfish = new("Silverfish");
    public static readonly EntityClass Skeleton = new("Skeleton");
    public static readonly EntityClass SkeletonHorse = new("SkeletonHorse");
    public static readonly EntityClass Slime = new("Slime");
    public static readonly EntityClass SmallFireball = new("SmallFireball");
    public static readonly EntityClass Sniffer = new("Sniffer");
    public static readonly EntityClass SnowGolem = new("SnowGolem");
    public static readonly EntityClass Snowball = new("Snowball");
    public static readonly EntityClass SpectralArrow = new("SpectralArrow");
    public static readonly EntityClass SpellcasterIllager = new("SpellcasterIllager");
    public static readonly EntityClass Spider = new("Spider");
    public static readonly EntityClass Squid = new("Squid");
    public static readonly EntityClass Stray = new("Stray");
    public static readonly EntityClass Strider = new("Strider");
    public static readonly EntityClass SulfurCube = new("SulfurCube");
    public static readonly EntityClass Tadpole = new("Tadpole");
    public static readonly EntityClass TamableAnimal = new("TamableAnimal");
    public static readonly EntityClass TextDisplay = new("TextDisplay");
    public static readonly EntityClass ThrowableItemProjectile = new("ThrowableItemProjectile");
    public static readonly EntityClass ThrowableProjectile = new("ThrowableProjectile");
    public static readonly EntityClass ThrownEgg = new("ThrownEgg");
    public static readonly EntityClass ThrownEnderpearl = new("ThrownEnderpearl");
    public static readonly EntityClass ThrownExperienceBottle = new("ThrownExperienceBottle");
    public static readonly EntityClass ThrownLingeringPotion = new("ThrownLingeringPotion");
    public static readonly EntityClass ThrownSplashPotion = new("ThrownSplashPotion");
    public static readonly EntityClass ThrownTrident = new("ThrownTrident");
    public static readonly EntityClass TraderLlama = new("TraderLlama");
    public static readonly EntityClass TropicalFish = new("TropicalFish");
    public static readonly EntityClass Turtle = new("Turtle");
    public static readonly EntityClass VehicleEntity = new("VehicleEntity");
    public static readonly EntityClass Vex = new("Vex");
    public static readonly EntityClass Villager = new("Villager");
    public static readonly EntityClass Vindicator = new("Vindicator");
    public static readonly EntityClass WanderingTrader = new("WanderingTrader");
    public static readonly EntityClass Warden = new("Warden");
    public static readonly EntityClass WaterAnimal = new("WaterAnimal");
    public static readonly EntityClass WindCharge = new("WindCharge");
    public static readonly EntityClass Witch = new("Witch");
    public static readonly EntityClass WitherBoss = new("WitherBoss");
    public static readonly EntityClass WitherSkeleton = new("WitherSkeleton");
    public static readonly EntityClass WitherSkull = new("WitherSkull");
    public static readonly EntityClass Wolf = new("Wolf");
    public static readonly EntityClass Zoglin = new("Zoglin");
    public static readonly EntityClass Zombie = new("Zombie");
    public static readonly EntityClass ZombieHorse = new("ZombieHorse");
    public static readonly EntityClass ZombieNautilus = new("ZombieNautilus");
    public static readonly EntityClass ZombieVillager = new("ZombieVillager");
    public static readonly EntityClass ZombifiedPiglin = new("ZombifiedPiglin");
}

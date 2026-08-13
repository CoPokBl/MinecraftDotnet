using Minecraft.Schemas;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
/// <summary>
/// Each entity type's vanilla Java class and everything it inherits from, nearest first.
/// <p/>
/// This exists because vanilla's AI is written against those classes and ours is written
/// against entity types. A goal upstream declares as <c>AvoidEntityGoal&lt;Raider&gt;</c>
/// becomes a test against this table.
/// </summary>
public static class EntityClasses {
    private static readonly Dictionary<Identifier, EntityClass[]> Chains = new() {
        { "minecraft:acacia_boat", [EntityClass.Boat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:acacia_chest_boat", [EntityClass.ChestBoat, EntityClass.AbstractChestBoat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:allay", [EntityClass.Allay, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:area_effect_cloud", [EntityClass.AreaEffectCloud, EntityClass.Entity] },
        { "minecraft:armadillo", [EntityClass.Armadillo, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:armor_stand", [EntityClass.ArmorStand, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:arrow", [EntityClass.Arrow, EntityClass.AbstractArrow, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:axolotl", [EntityClass.Axolotl, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:bamboo_chest_raft", [EntityClass.ChestRaft, EntityClass.AbstractChestBoat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:bamboo_raft", [EntityClass.Raft, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:bat", [EntityClass.Bat, EntityClass.AmbientCreature, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:bee", [EntityClass.Bee, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:birch_boat", [EntityClass.Boat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:birch_chest_boat", [EntityClass.ChestBoat, EntityClass.AbstractChestBoat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:blaze", [EntityClass.Blaze, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:block_display", [EntityClass.BlockDisplay, EntityClass.Display, EntityClass.Entity] },
        { "minecraft:bogged", [EntityClass.Bogged, EntityClass.AbstractSkeleton, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:breeze", [EntityClass.Breeze, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:breeze_wind_charge", [EntityClass.BreezeWindCharge, EntityClass.AbstractWindCharge, EntityClass.AbstractHurtingProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:camel", [EntityClass.Camel, EntityClass.AbstractHorse, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:camel_husk", [EntityClass.CamelHusk, EntityClass.Camel, EntityClass.AbstractHorse, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:cat", [EntityClass.Cat, EntityClass.TamableAnimal, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:cave_spider", [EntityClass.CaveSpider, EntityClass.Spider, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:cherry_boat", [EntityClass.Boat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:cherry_chest_boat", [EntityClass.ChestBoat, EntityClass.AbstractChestBoat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:chest_minecart", [EntityClass.MinecartChest, EntityClass.AbstractMinecartContainer, EntityClass.AbstractMinecart, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:chicken", [EntityClass.Chicken, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:cod", [EntityClass.Cod, EntityClass.AbstractSchoolingFish, EntityClass.AbstractFish, EntityClass.WaterAnimal, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:copper_golem", [EntityClass.CopperGolem, EntityClass.AbstractGolem, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:command_block_minecart", [EntityClass.MinecartCommandBlock, EntityClass.AbstractMinecart, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:cow", [EntityClass.Cow, EntityClass.AbstractCow, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:creaking", [EntityClass.Creaking, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:creeper", [EntityClass.Creeper, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:dark_oak_boat", [EntityClass.Boat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:dark_oak_chest_boat", [EntityClass.ChestBoat, EntityClass.AbstractChestBoat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:dolphin", [EntityClass.Dolphin, EntityClass.AgeableWaterCreature, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:donkey", [EntityClass.Donkey, EntityClass.AbstractChestedHorse, EntityClass.AbstractHorse, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:dragon_fireball", [EntityClass.DragonFireball, EntityClass.AbstractHurtingProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:drowned", [EntityClass.Drowned, EntityClass.Zombie, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:egg", [EntityClass.ThrownEgg, EntityClass.ThrowableItemProjectile, EntityClass.ThrowableProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:elder_guardian", [EntityClass.ElderGuardian, EntityClass.Guardian, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:enderman", [EntityClass.EnderMan, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:endermite", [EntityClass.Endermite, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:ender_dragon", [EntityClass.EnderDragon, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:ender_pearl", [EntityClass.ThrownEnderpearl, EntityClass.ThrowableItemProjectile, EntityClass.ThrowableProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:end_crystal", [EntityClass.EndCrystal, EntityClass.Entity] },
        { "minecraft:evoker", [EntityClass.Evoker, EntityClass.SpellcasterIllager, EntityClass.AbstractIllager, EntityClass.Raider, EntityClass.PatrollingMonster, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:evoker_fangs", [EntityClass.EvokerFangs, EntityClass.Entity] },
        { "minecraft:experience_bottle", [EntityClass.ThrownExperienceBottle, EntityClass.ThrowableItemProjectile, EntityClass.ThrowableProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:experience_orb", [EntityClass.ExperienceOrb, EntityClass.Entity] },
        { "minecraft:eye_of_ender", [EntityClass.EyeOfEnder, EntityClass.Entity] },
        { "minecraft:falling_block", [EntityClass.FallingBlockEntity, EntityClass.Entity] },
        { "minecraft:fireball", [EntityClass.LargeFireball, EntityClass.Fireball, EntityClass.AbstractHurtingProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:firework_rocket", [EntityClass.FireworkRocketEntity, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:fox", [EntityClass.Fox, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:frog", [EntityClass.Frog, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:furnace_minecart", [EntityClass.MinecartFurnace, EntityClass.AbstractMinecart, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:ghast", [EntityClass.Ghast, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:happy_ghast", [EntityClass.HappyGhast, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:giant", [EntityClass.Giant, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:glow_item_frame", [EntityClass.GlowItemFrame, EntityClass.ItemFrame, EntityClass.HangingEntity, EntityClass.BlockAttachedEntity, EntityClass.Entity] },
        { "minecraft:glow_squid", [EntityClass.GlowSquid, EntityClass.Squid, EntityClass.AgeableWaterCreature, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:goat", [EntityClass.Goat, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:guardian", [EntityClass.Guardian, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:hoglin", [EntityClass.Hoglin, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:hopper_minecart", [EntityClass.MinecartHopper, EntityClass.AbstractMinecartContainer, EntityClass.AbstractMinecart, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:horse", [EntityClass.Horse, EntityClass.AbstractHorse, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:husk", [EntityClass.Husk, EntityClass.Zombie, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:illusioner", [EntityClass.Illusioner, EntityClass.SpellcasterIllager, EntityClass.AbstractIllager, EntityClass.Raider, EntityClass.PatrollingMonster, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:interaction", [EntityClass.Interaction, EntityClass.Entity] },
        { "minecraft:iron_golem", [EntityClass.IronGolem, EntityClass.AbstractGolem, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:item", [EntityClass.ItemEntity, EntityClass.Entity] },
        { "minecraft:item_display", [EntityClass.ItemDisplay, EntityClass.Display, EntityClass.Entity] },
        { "minecraft:item_frame", [EntityClass.ItemFrame, EntityClass.HangingEntity, EntityClass.BlockAttachedEntity, EntityClass.Entity] },
        { "minecraft:jungle_boat", [EntityClass.Boat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:jungle_chest_boat", [EntityClass.ChestBoat, EntityClass.AbstractChestBoat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:leash_knot", [EntityClass.LeashFenceKnotEntity, EntityClass.BlockAttachedEntity, EntityClass.Entity] },
        { "minecraft:lightning_bolt", [EntityClass.LightningBolt, EntityClass.Entity] },
        { "minecraft:llama", [EntityClass.Llama, EntityClass.AbstractChestedHorse, EntityClass.AbstractHorse, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:llama_spit", [EntityClass.LlamaSpit, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:magma_cube", [EntityClass.MagmaCube, EntityClass.AbstractCubeMob, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:mangrove_boat", [EntityClass.Boat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:mangrove_chest_boat", [EntityClass.ChestBoat, EntityClass.AbstractChestBoat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:mannequin", [EntityClass.Mannequin, EntityClass.Avatar, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:marker", [EntityClass.Marker, EntityClass.Entity] },
        { "minecraft:minecart", [EntityClass.Minecart, EntityClass.AbstractMinecart, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:mooshroom", [EntityClass.MushroomCow, EntityClass.AbstractCow, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:mule", [EntityClass.Mule, EntityClass.AbstractChestedHorse, EntityClass.AbstractHorse, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:nautilus", [EntityClass.Nautilus, EntityClass.AbstractNautilus, EntityClass.TamableAnimal, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:oak_boat", [EntityClass.Boat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:oak_chest_boat", [EntityClass.ChestBoat, EntityClass.AbstractChestBoat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:ocelot", [EntityClass.Ocelot, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:ominous_item_spawner", [EntityClass.OminousItemSpawner, EntityClass.Entity] },
        { "minecraft:painting", [EntityClass.Painting, EntityClass.HangingEntity, EntityClass.BlockAttachedEntity, EntityClass.Entity] },
        { "minecraft:pale_oak_boat", [EntityClass.Boat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:pale_oak_chest_boat", [EntityClass.ChestBoat, EntityClass.AbstractChestBoat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:panda", [EntityClass.Panda, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:parched", [EntityClass.Parched, EntityClass.AbstractSkeleton, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:parrot", [EntityClass.Parrot, EntityClass.ShoulderRidingEntity, EntityClass.TamableAnimal, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:phantom", [EntityClass.Phantom, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:pig", [EntityClass.Pig, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:piglin", [EntityClass.Piglin, EntityClass.AbstractPiglin, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:piglin_brute", [EntityClass.PiglinBrute, EntityClass.AbstractPiglin, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:pillager", [EntityClass.Pillager, EntityClass.AbstractIllager, EntityClass.Raider, EntityClass.PatrollingMonster, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:polar_bear", [EntityClass.PolarBear, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:splash_potion", [EntityClass.ThrownSplashPotion, EntityClass.AbstractThrownPotion, EntityClass.ThrowableItemProjectile, EntityClass.ThrowableProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:lingering_potion", [EntityClass.ThrownLingeringPotion, EntityClass.AbstractThrownPotion, EntityClass.ThrowableItemProjectile, EntityClass.ThrowableProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:pufferfish", [EntityClass.Pufferfish, EntityClass.AbstractFish, EntityClass.WaterAnimal, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:rabbit", [EntityClass.Rabbit, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:ravager", [EntityClass.Ravager, EntityClass.Raider, EntityClass.PatrollingMonster, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:salmon", [EntityClass.Salmon, EntityClass.AbstractSchoolingFish, EntityClass.AbstractFish, EntityClass.WaterAnimal, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:sheep", [EntityClass.Sheep, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:shulker", [EntityClass.Shulker, EntityClass.AbstractGolem, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:shulker_bullet", [EntityClass.ShulkerBullet, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:silverfish", [EntityClass.Silverfish, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:skeleton", [EntityClass.Skeleton, EntityClass.AbstractSkeleton, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:skeleton_horse", [EntityClass.SkeletonHorse, EntityClass.AbstractHorse, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:slime", [EntityClass.Slime, EntityClass.AbstractCubeMob, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:small_fireball", [EntityClass.SmallFireball, EntityClass.Fireball, EntityClass.AbstractHurtingProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:sniffer", [EntityClass.Sniffer, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:snowball", [EntityClass.Snowball, EntityClass.ThrowableItemProjectile, EntityClass.ThrowableProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:snow_golem", [EntityClass.SnowGolem, EntityClass.AbstractGolem, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:spawner_minecart", [EntityClass.MinecartSpawner, EntityClass.AbstractMinecart, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:spectral_arrow", [EntityClass.SpectralArrow, EntityClass.AbstractArrow, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:spider", [EntityClass.Spider, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:spruce_boat", [EntityClass.Boat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:spruce_chest_boat", [EntityClass.ChestBoat, EntityClass.AbstractChestBoat, EntityClass.AbstractBoat, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:squid", [EntityClass.Squid, EntityClass.AgeableWaterCreature, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:stray", [EntityClass.Stray, EntityClass.AbstractSkeleton, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:strider", [EntityClass.Strider, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:sulfur_cube", [EntityClass.SulfurCube, EntityClass.AbstractCubeMob, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:tadpole", [EntityClass.Tadpole, EntityClass.AbstractFish, EntityClass.WaterAnimal, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:text_display", [EntityClass.TextDisplay, EntityClass.Display, EntityClass.Entity] },
        { "minecraft:tnt", [EntityClass.PrimedTnt, EntityClass.Entity] },
        { "minecraft:tnt_minecart", [EntityClass.MinecartTNT, EntityClass.AbstractMinecart, EntityClass.VehicleEntity, EntityClass.Entity] },
        { "minecraft:trader_llama", [EntityClass.TraderLlama, EntityClass.Llama, EntityClass.AbstractChestedHorse, EntityClass.AbstractHorse, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:trident", [EntityClass.ThrownTrident, EntityClass.AbstractArrow, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:tropical_fish", [EntityClass.TropicalFish, EntityClass.AbstractSchoolingFish, EntityClass.AbstractFish, EntityClass.WaterAnimal, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:turtle", [EntityClass.Turtle, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:vex", [EntityClass.Vex, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:villager", [EntityClass.Villager, EntityClass.AbstractVillager, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:vindicator", [EntityClass.Vindicator, EntityClass.AbstractIllager, EntityClass.Raider, EntityClass.PatrollingMonster, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:wandering_trader", [EntityClass.WanderingTrader, EntityClass.AbstractVillager, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:warden", [EntityClass.Warden, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:wind_charge", [EntityClass.WindCharge, EntityClass.AbstractWindCharge, EntityClass.AbstractHurtingProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:witch", [EntityClass.Witch, EntityClass.Raider, EntityClass.PatrollingMonster, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:wither", [EntityClass.WitherBoss, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:wither_skeleton", [EntityClass.WitherSkeleton, EntityClass.AbstractSkeleton, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:wither_skull", [EntityClass.WitherSkull, EntityClass.AbstractHurtingProjectile, EntityClass.Projectile, EntityClass.Entity] },
        { "minecraft:wolf", [EntityClass.Wolf, EntityClass.TamableAnimal, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:zoglin", [EntityClass.Zoglin, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:zombie", [EntityClass.Zombie, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:zombie_horse", [EntityClass.ZombieHorse, EntityClass.AbstractHorse, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:zombie_nautilus", [EntityClass.ZombieNautilus, EntityClass.AbstractNautilus, EntityClass.TamableAnimal, EntityClass.Animal, EntityClass.AgeableMob, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:zombie_villager", [EntityClass.ZombieVillager, EntityClass.Zombie, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:zombified_piglin", [EntityClass.ZombifiedPiglin, EntityClass.Zombie, EntityClass.Monster, EntityClass.PathfinderMob, EntityClass.Mob, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:player", [EntityClass.Player, EntityClass.Avatar, EntityClass.LivingEntity, EntityClass.Entity] },
        { "minecraft:fishing_bobber", [EntityClass.FishingHook, EntityClass.Projectile, EntityClass.Entity] },
    };

    /// <summary>
    /// The class chain, nearest first. Empty for something this table has never heard of, which
    /// cannot happen for a vanilla entry.
    /// </summary>
    public static EntityClass[] Of(Identifier id) {
        return Chains.TryGetValue(id, out EntityClass[]? chain) ? chain : [];
    }

    /// <summary>
    /// Whether the entry is, or inherits from, the given vanilla class. The name is the simple one
    /// (<c>Raider</c>, <c>DoorBlock</c>, <c>Monster</c>), because that is what the code being ported
    /// names and a package move upstream is not a behaviour change.
    /// </summary>
    public static bool Is(Identifier id, EntityClass className) {
        foreach (EntityClass name in Of(id)) {
            if (name == className) {
                return true;
            }
        }

        return false;
    }
}

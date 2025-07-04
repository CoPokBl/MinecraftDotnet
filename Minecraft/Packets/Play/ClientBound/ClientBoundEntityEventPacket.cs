using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundEntityEventPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:entity_event";
    
    public required int EntityId;
    public required EntityEventType Status;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteInteger(EntityId)
            .WriteByte((int)Status);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundEntityEventPacket {
        EntityId = r.ReadInteger(),
        Status = (EntityEventType)r.ReadByte()
    };
    
    /// <summary>
    /// Enum of all entity event types.
    /// </summary>
    public enum EntityEventType {
        // ENTITY
        
        /// <summary>
        /// Spawns honey block slide particles at the entity feet.
        /// </summary>
        EntityHoneyBlockSlideParticles = 53,
        
        // SNOWBALL
        
        /// <summary>
        /// Displays 8 snowball poof particles at snowball's location.
        /// </summary>
        SnowballPoof = 3,
        
        // EGG
        
        /// <summary>
        /// Displays 8 "iconcrack" particles at the egg's location.
        /// These are usually displayed when an egg spawns a baby chicken.
        /// </summary>
        EggCrack = 3,
        
        // FISHING HOOK
        
        /// <summary>
        /// Used when something is caught and is pulled.
        /// </summary>
        FishingHookPull = 31,
        
        // ARROW
        
        /// <summary>
        /// Spawns position effect particles for a tipped arrow.
        /// If colour is not -1.
        /// </summary>
        ArrowTippedParticles = 0,
        
        // FIREWORK ROCKET
        
        /// <summary>
        /// Triggers the explosion effect specified by the entity metadata.
        /// </summary>
        FireworkRocketExplode = 17,
        
        // LIVING ENTITY
        
        /// <summary>
        /// Plays the death sound and animation of the entity.
        /// </summary>
        LivingEntityDie = 3,
        
        /// <summary>
        /// Plays the shield block sound.
        /// </summary>
        LivingEntityShieldBlock = 29,
        
        /// <summary>
        /// Plays the shield break sound.
        /// </summary>
        LivingEntityShieldBreak = 30,
        
        /// <summary>
        /// Plays the totem use animation and sound.
        /// </summary>
        LivingEntityTotemPop = 35,
        
        /// <summary>
        /// Spawns portal particles around entity.
        /// This is normally triggered by eating chorus fruit or by endermen teleporting.
        /// </summary>
        LivingEntityEnderTeleport = 46,
        
        /// <summary>
        /// Sound and particles for main hand item breaking.
        /// </summary>
        LivingEntityMainHandBreak = 47,
        
        /// <summary>
        /// Sound and particles for off hand item breaking.
        /// </summary>
        LivingEntityOffHandBreak = 48,
        
        /// <summary>
        /// Sound and particles for head slot item breaking.
        /// </summary>
        LivingEntityHeadSlotBreak = 49,
        
        /// <summary>
        /// Sound and particles for chest slot item breaking.
        /// </summary>
        LivingEntityChestSlotBreak = 50,
        
        /// <summary>
        /// Sound and particles for legs slot item breaking.
        /// </summary>
        LivingEntityLegsSlotBreak = 51,
        
        /// <summary>
        /// Sound and particles for feet slot item breaking.
        /// </summary>
        LivingEntityFeetSlotBreak = 52,
        
        /// <summary>
        /// Spawns honey block fall particles at the entities feet.
        /// </summary>
        LivingEntityHoneyBlockFall = 54,
        
        /// <summary>
        /// Used to swap main hand and off hand.
        /// </summary>
        LivingEntityHandSwap = 55,
        
        /// <summary>
        /// Spawns death smoke particles.
        /// </summary>
        LivingEntityDeathSmoke = 60,
        
        // PLAYER
        
        /// <summary>
        /// Marks item use as finished (finished eating, finished drinking, etc).
        /// </summary>
        PlayerFinishedUsing = 9,
        
        /// <summary>
        /// Enables reduced debug screen information.
        /// </summary>
        PlayerEnableReducedDebug = 22,
        
        /// <summary>
        /// Disables reduced debug screen information.
        /// </summary>
        PlayerDisableReducedDebug = 23,
        
        /// <summary>
        /// Set OP permission level to 0.
        /// </summary>
        PlayerPermissionLevel0 = 24,
        
        /// <summary>
        /// Set OP permission level to 1.
        /// </summary>
        PlayerPermissionLevel1 = 25,
        
        /// <summary>
        /// Set OP permission level to 2.
        /// </summary>
        PlayerPermissionLevel2 = 26,
        
        /// <summary>
        /// Set OP permission level to 3.
        /// </summary>
        PlayerPermissionLevel3 = 27,
        
        /// <summary>
        /// Set OP permission level to 4.
        /// </summary>
        PlayerPermissionLevel4 = 28,
        
        /// <summary>
        /// Sent when bad omen is removed to either start a raid or increase its level.
        /// </summary>
        PlayerCloudParticles = 43,
        
        // ARMOR STAND
        
        /// <summary>
        /// Plays the hit sound and resets hit cooldown.
        /// </summary>
        ArmorStandHit = 32,
        
        // MOB
        
        /// <summary>
        /// Spawns explosion particle.
        /// Used for: silverfish enters block, silverfish exits block, mob spawners spawns mob.
        /// </summary>
        MobPoof = 20,
        
        // SQUID
        
        /// <summary>
        /// Resets rotation to 0 radians. Server usually does this when squid turns 2pi radians to loop it.
        /// </summary>
        SquidResetRotation = 19,
        
        // DOLPHIN
        
        /// <summary>
        /// Spawns happy villager particles. Used when a dolphin is fed and is locating a structure.
        /// </summary>
        DolphinHappy = 38,
        
        // ANIMAL
        
        /// <summary>
        /// Spawns "love mode" heart particles.
        /// It's when they have sex. Lol
        /// </summary>
        AnimalLoveMode = 18,
        
        // ABSTRACT HORSE (Horse, donkey, mule)
        
        /// <summary>
        /// Spawns smoke particles.
        /// </summary>
        HorseTamingFailed = 6,
        
        /// <summary>
        /// Spawns heart particles.
        /// </summary>
        HorseTamingSuccess = 7,
        
        // OCELOT
        
        /// <summary>
        /// Spawns smoke particles.
        /// </summary>
        OcelotTamingFailed = 40,
        
        /// <summary>
        /// Spawns heart particles.
        /// </summary>
        OcelotTamingSuccess = 41,
        
        // RABBIT
        
        /// <summary>
        /// Causes the rabbit to use its rotated jumping animation, and displays jumping particles.
        /// </summary>
        RabbitJump = 1,
        
        // SHEEP
        
        /// <summary>
        /// Causes sheep to display eating animation for 40 ticks.
        /// It leans down and eats the ground.
        /// </summary>
        SheepEat = 10,
        
        // FOX
        
        /// <summary>
        /// Causes particles based on item in fox's mouth (main hand) to indicate
        /// chewing.
        /// </summary>
        FoxChew = 45,
        
        // GOAT
        
        /// <summary>
        /// Makes the goat lower its head.
        /// </summary>
        GoatPrepareRamming = 58,
        
        /// <summary>
        /// Makes the goat stop lowering its head.
        /// </summary>
        GoatRelax = 59,
        
        // TAMEABLE ANIMAL
        
        /// <summary>
        /// Spawns smoke particles.
        /// </summary>
        TameableTamingFailed = 6,
        
        /// <summary>
        /// Spawns heart particles.
        /// </summary>
        TameableTamingSuccess = 7,
        
        // WOLF
        
        /// <summary>
        /// Play wolf shaking off water animation.
        /// </summary>
        WolfWaterShake = 8,
        
        /// <summary>
        /// Stop the shaking off water animation.
        /// </summary>
        WolfStopWaterShake = 56,
        
        // VILLAGER
        
        /// <summary>
        /// Spawn villager mating particles.
        /// </summary>
        VillagerMating = 12,
        
        /// <summary>
        /// Spawns angry villager particles.
        /// </summary>
        VillagerAngry = 13,
        
        /// <summary>
        /// Spawns happy villager particles.
        /// </summary>
        VillagerHappy = 14,
        
        /// <summary>
        /// Spawn "splash" particles. Normally triggered with 1% chance each tick while a raid is active.
        /// </summary>
        VillagerSplash = 42,
        
        // IRON GOLEM
        
        /// <summary>
        /// Plays attack animation and sound.
        /// </summary>
        IronGolemAttack = 4,
        
        /// <summary>
        /// Causes golem to hold out a poppy for 400 ticks (20 seconds).
        /// </summary>
        IronGolemFlower = 11,
        
        /// <summary>
        /// Causes golem to put away held flower.
        /// </summary>
        IronGolemRescindFlower = 34,
        
        // EVOKER FANGS
        
        /// <summary>
        /// Starts attack animation and plays attack sound.
        /// </summary>
        EvokerFangsAttack = 4,
        
        // WITCH
        
        /// <summary>
        /// Spawns between 10 and 45 witch magic particles.
        /// In vanilla this has a .075% chance of happening each tick.
        /// </summary>
        WitchMagic = 15,
        
        // RAVAGER
        
        /// <summary>
        /// Starts attack animation.
        /// </summary>
        RavagerAttack = 4,
        
        /// <summary>
        /// Marks the ravager as stunned for 40 ticks.
        /// </summary>
        RavagerStun = 39,
        
        // ZOMBIE VILLAGER
        
        /// <summary>
        /// Plays the cure sound effect.
        /// </summary>
        ZombieVillagerCure = 16,
        
        // GUARDIAN
        
        /// <summary>
        /// Plays the guardian attack sound effect.
        /// </summary>
        GuardianAttack = 21,
        
        // TNT Minecart
        
        /// <summary>
        /// Makes the TNT ignite visually. Does not play a sound.
        /// </summary>
        TntMinecartIgnite = 10,
        
        // MINECART SPAWNER
        
        /// <summary>
        /// What the hell is a minecart spawner.
        /// https://minecraft.wiki/w/Java_Edition_protocol/Entity_statuses#Minecart_Spawner
        /// </summary>
        MinecartSpawnerResetDelay = 1,
        
        // HOGLIN
        
        /// <summary>
        /// Plays attack animation for 10 ticks and plays sound.
        /// </summary>
        HoglinAttack = 4,
        
        // ZOGLIN
        
        /// <summary>
        /// Plays attack animation for 10 ticks and plays sound.
        /// </summary>
        ZoglinAttack = 4,
        
        // ALLAY
        
        /// <summary>
        /// Spawns heart particles. Normally used when allays duplicate.
        /// </summary>
        AllayMitosis = 18,
        
        // WARDEN
        
        /// <summary>
        /// Stops the roar animation and performs the attack animation.
        /// </summary>
        WardenAttack = 4,
        
        /// <summary>
        /// Plays tendril shake animation for 10 ticks.
        /// </summary>
        WardenTendrilShake = 61,
        
        /// <summary>
        /// Plays sonic boom animation, charge and release. Beam and sound are not created.
        /// </summary>
        WardenSonicBoom = 62,
        
        // SNIFFER
        
        /// <summary>
        /// Plays the digging sound. Only works if the Sniffer has a target, and is in a digging or searching state.
        /// State is part of entity metadata.
        /// </summary>
        SnifferDig = 63,
    }
}

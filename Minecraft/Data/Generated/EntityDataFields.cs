using Minecraft.Data.Blocks;
using Minecraft.Data.PaintingVariant;
using Minecraft.Data.Particles;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.

/// <summary>
/// The entity data each vanilla entity class declares, by the class's simple name. A field is valid
/// for an entity whose class chain contains the class it sits in.
/// </summary>
public static class EntityDataFields {
    public static class AbstractArrow {
        /// <summary><c>ID_FLAGS</c>.</summary>
        public static readonly EntityDataField<sbyte> IdFlags = new(8);
        /// <summary><c>PIERCE_LEVEL</c>.</summary>
        public static readonly EntityDataField<sbyte> PierceLevel = new(9);
        /// <summary><c>IN_GROUND</c>.</summary>
        public static readonly EntityDataField<bool> InGround = new(10);
    }

    public static class AbstractBoat {
        /// <summary><c>DATA_ID_PADDLE_LEFT</c>.</summary>
        public static readonly EntityDataField<bool> IdPaddleLeft = new(11);
        /// <summary><c>DATA_ID_PADDLE_RIGHT</c>.</summary>
        public static readonly EntityDataField<bool> IdPaddleRight = new(12);
        /// <summary><c>DATA_ID_BUBBLE_TIME</c>.</summary>
        public static readonly EntityDataField<int> IdBubbleTime = new(13);
    }

    public static class AbstractChestedHorse {
        /// <summary><c>DATA_ID_CHEST</c>.</summary>
        public static readonly EntityDataField<bool> IdChest = new(19);
    }

    public static class AbstractCubeMob {
        /// <summary><c>ID_SIZE</c>.</summary>
        public static readonly EntityDataField<int> IdSize = new(18);
    }

    public static class AbstractFish {
        /// <summary><c>FROM_BUCKET</c>.</summary>
        public static readonly EntityDataField<bool> FromBucket = new(16);
    }

    public static class AbstractHorse {
        /// <summary><c>DATA_ID_FLAGS</c>.</summary>
        public static readonly EntityDataField<sbyte> IdFlags = new(18);
    }

    public static class AbstractMinecart {
        /// <summary><c>DATA_ID_CUSTOM_DISPLAY_BLOCK</c>.</summary>
        public static readonly EntityDataField<Optional<IBlock>> IdCustomDisplayBlock = new(11);
        /// <summary><c>DATA_ID_DISPLAY_OFFSET</c>.</summary>
        public static readonly EntityDataField<int> IdDisplayOffset = new(12);
    }

    public static class AbstractNautilus {
        /// <summary><c>DASH</c>.</summary>
        public static readonly EntityDataField<bool> Dash = new(20);
    }

    public static class AbstractPiglin {
        /// <summary><c>DATA_IMMUNE_TO_ZOMBIFICATION</c>.</summary>
        public static readonly EntityDataField<bool> ImmuneToZombification = new(16);
    }

    public static class AbstractVillager {
        /// <summary><c>DATA_UNHAPPY_COUNTER</c>.</summary>
        public static readonly EntityDataField<int> UnhappyCounter = new(18);
    }

    public static class AgeableMob {
        /// <summary><c>DATA_BABY_ID</c>.</summary>
        public static readonly EntityDataField<bool> Baby = new(16);
        /// <summary><c>AGE_LOCKED</c>.</summary>
        public static readonly EntityDataField<bool> AgeLocked = new(17);
    }

    public static class Allay {
        /// <summary><c>DATA_DANCING</c>.</summary>
        public static readonly EntityDataField<bool> Dancing = new(16);
        /// <summary><c>DATA_CAN_DUPLICATE</c>.</summary>
        public static readonly EntityDataField<bool> CanDuplicate = new(17);
    }

    public static class AreaEffectCloud {
        /// <summary><c>DATA_RADIUS</c>.</summary>
        public static readonly EntityDataField<float> Radius = new(8);
        /// <summary><c>DATA_WAITING</c>.</summary>
        public static readonly EntityDataField<bool> Waiting = new(9);
        /// <summary><c>DATA_PARTICLE</c>.</summary>
        public static readonly EntityDataField<IParticle> Particle = new(10);
    }

    public static class Armadillo {
        /// <summary><c>ARMADILLO_STATE</c>.</summary>
        public static readonly EntityDataField<ArmadilloState> ArmadilloState = new(18);
    }

    public static class ArmorStand {
        /// <summary><c>DATA_CLIENT_FLAGS</c>.</summary>
        public static readonly EntityDataField<sbyte> ClientFlags = new(15);
        /// <summary><c>DATA_HEAD_POSE</c>.</summary>
        public static readonly EntityDataField<Vec3<float>> HeadPose = new(16);
        /// <summary><c>DATA_BODY_POSE</c>.</summary>
        public static readonly EntityDataField<Vec3<float>> BodyPose = new(17);
        /// <summary><c>DATA_LEFT_ARM_POSE</c>.</summary>
        public static readonly EntityDataField<Vec3<float>> LeftArmPose = new(18);
        /// <summary><c>DATA_RIGHT_ARM_POSE</c>.</summary>
        public static readonly EntityDataField<Vec3<float>> RightArmPose = new(19);
        /// <summary><c>DATA_LEFT_LEG_POSE</c>.</summary>
        public static readonly EntityDataField<Vec3<float>> LeftLegPose = new(20);
        /// <summary><c>DATA_RIGHT_LEG_POSE</c>.</summary>
        public static readonly EntityDataField<Vec3<float>> RightLegPose = new(21);
    }

    public static class Arrow {
        /// <summary><c>ID_EFFECT_COLOR</c>.</summary>
        public static readonly EntityDataField<int> IdEffectColor = new(11);
    }

    public static class Avatar {
        /// <summary><c>DATA_PLAYER_MAIN_HAND</c>.</summary>
        public static readonly EntityDataField<HumanoidArm> PlayerMainHand = new(15);
        /// <summary><c>DATA_PLAYER_MODE_CUSTOMISATION</c>.</summary>
        public static readonly EntityDataField<sbyte> PlayerModeCustomisation = new(16);
    }

    public static class Axolotl {
        /// <summary><c>DATA_VARIANT</c>.</summary>
        public static readonly EntityDataField<int> Variant = new(18);
        /// <summary><c>DATA_PLAYING_DEAD</c>.</summary>
        public static readonly EntityDataField<bool> PlayingDead = new(19);
        /// <summary><c>FROM_BUCKET</c>.</summary>
        public static readonly EntityDataField<bool> FromBucket = new(20);
    }

    public static class Bat {
        /// <summary><c>DATA_ID_FLAGS</c>.</summary>
        public static readonly EntityDataField<sbyte> IdFlags = new(16);
    }

    public static class Bee {
        /// <summary><c>DATA_FLAGS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Flags = new(18);
        /// <summary><c>DATA_ANGER_END_TIME</c>.</summary>
        public static readonly EntityDataField<long> AngerEndTime = new(19);
    }

    public static class Blaze {
        /// <summary><c>DATA_FLAGS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Flags = new(16);
    }

    public static class BlockDisplay {
        /// <summary><c>DATA_BLOCK_STATE_ID</c>.</summary>
        public static readonly EntityDataField<IBlock> BlockState = new(23);
    }

    public static class Bogged {
        /// <summary><c>DATA_SHEARED</c>.</summary>
        public static readonly EntityDataField<bool> Sheared = new(16);
    }

    public static class Camel {
        /// <summary><c>DASH</c>.</summary>
        public static readonly EntityDataField<bool> Dash = new(19);
        /// <summary><c>LAST_POSE_CHANGE_TICK</c>.</summary>
        public static readonly EntityDataField<long> LastPoseChangeTick = new(20);
    }

    public static class Cat {
        /// <summary><c>DATA_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> Variant = new(20);
        /// <summary><c>IS_LYING</c>.</summary>
        public static readonly EntityDataField<bool> IsLying = new(21);
        /// <summary><c>RELAX_STATE_ONE</c>.</summary>
        public static readonly EntityDataField<bool> RelaxStateOne = new(22);
        /// <summary><c>DATA_COLLAR_COLOR</c>.</summary>
        public static readonly EntityDataField<int> CollarColor = new(23);
        /// <summary><c>DATA_SOUND_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> SoundVariant = new(24);
    }

    public static class Chicken {
        /// <summary><c>DATA_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> Variant = new(18);
        /// <summary><c>DATA_SOUND_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> SoundVariant = new(19);
    }

    public static class CopperGolem {
        /// <summary><c>DATA_WEATHER_STATE</c>.</summary>
        public static readonly EntityDataField<WeatheringCopperState> WeatherState = new(16);
        /// <summary><c>COPPER_GOLEM_STATE</c>.</summary>
        public static readonly EntityDataField<CopperGolemState> CopperGolemState = new(17);
    }

    public static class Cow {
        /// <summary><c>DATA_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> Variant = new(18);
        /// <summary><c>DATA_SOUND_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> SoundVariant = new(19);
    }

    public static class Creaking {
        /// <summary><c>CAN_MOVE</c>.</summary>
        public static readonly EntityDataField<bool> CanMove = new(16);
        /// <summary><c>IS_ACTIVE</c>.</summary>
        public static readonly EntityDataField<bool> IsActive = new(17);
        /// <summary><c>IS_TEARING_DOWN</c>.</summary>
        public static readonly EntityDataField<bool> IsTearingDown = new(18);
        /// <summary><c>HOME_POS</c>.</summary>
        public static readonly EntityDataField<Optional<Vec3<int>>> HomePos = new(19);
    }

    public static class Creeper {
        /// <summary><c>DATA_SWELL_DIR</c>.</summary>
        public static readonly EntityDataField<int> SwellDir = new(16);
        /// <summary><c>DATA_IS_POWERED</c>.</summary>
        public static readonly EntityDataField<bool> IsPowered = new(17);
        /// <summary><c>DATA_IS_IGNITED</c>.</summary>
        public static readonly EntityDataField<bool> IsIgnited = new(18);
    }

    public static class Cushion {
        /// <summary><c>DATA_COLOR</c>.</summary>
        public static readonly EntityDataField<DyeColor> Color = new(8);
    }

    public static class Display {
        /// <summary><c>DATA_TRANSFORMATION_INTERPOLATION_START_DELTA_TICKS_ID</c>.</summary>
        public static readonly EntityDataField<int> TransformationInterpolationStartDeltaTicks = new(8);
        /// <summary><c>DATA_TRANSFORMATION_INTERPOLATION_DURATION_ID</c>.</summary>
        public static readonly EntityDataField<int> TransformationInterpolationDuration = new(9);
        /// <summary><c>DATA_POS_ROT_INTERPOLATION_DURATION_ID</c>.</summary>
        public static readonly EntityDataField<int> PosRotInterpolationDuration = new(10);
        /// <summary><c>DATA_TRANSLATION_ID</c>.</summary>
        public static readonly EntityDataField<Vec3<float>> Translation = new(11);
        /// <summary><c>DATA_SCALE_ID</c>.</summary>
        public static readonly EntityDataField<Vec3<float>> Scale = new(12);
        /// <summary><c>DATA_LEFT_ROTATION_ID</c>.</summary>
        public static readonly EntityDataField<Quaternion> LeftRotation = new(13);
        /// <summary><c>DATA_RIGHT_ROTATION_ID</c>.</summary>
        public static readonly EntityDataField<Quaternion> RightRotation = new(14);
        /// <summary><c>DATA_BILLBOARD_RENDER_CONSTRAINTS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> BillboardRenderConstraints = new(15);
        /// <summary><c>DATA_BRIGHTNESS_OVERRIDE_ID</c>.</summary>
        public static readonly EntityDataField<int> BrightnessOverride = new(16);
        /// <summary><c>DATA_VIEW_RANGE_ID</c>.</summary>
        public static readonly EntityDataField<float> ViewRange = new(17);
        /// <summary><c>DATA_SHADOW_RADIUS_ID</c>.</summary>
        public static readonly EntityDataField<float> ShadowRadius = new(18);
        /// <summary><c>DATA_SHADOW_STRENGTH_ID</c>.</summary>
        public static readonly EntityDataField<float> ShadowStrength = new(19);
        /// <summary><c>DATA_WIDTH_ID</c>.</summary>
        public static readonly EntityDataField<float> Width = new(20);
        /// <summary><c>DATA_HEIGHT_ID</c>.</summary>
        public static readonly EntityDataField<float> Height = new(21);
        /// <summary><c>DATA_GLOW_COLOR_OVERRIDE_ID</c>.</summary>
        public static readonly EntityDataField<int> GlowColorOverride = new(22);
    }

    public static class Dolphin {
        /// <summary><c>GOT_FISH</c>.</summary>
        public static readonly EntityDataField<bool> GotFish = new(18);
        /// <summary><c>MOISTNESS_LEVEL</c>.</summary>
        public static readonly EntityDataField<int> MoistnessLevel = new(19);
    }

    public static class EndCrystal {
        /// <summary><c>DATA_BEAM_TARGET</c>.</summary>
        public static readonly EntityDataField<Optional<Vec3<int>>> BeamTarget = new(8);
        /// <summary><c>DATA_SHOW_BOTTOM</c>.</summary>
        public static readonly EntityDataField<bool> ShowBottom = new(9);
    }

    public static class EnderDragon {
        /// <summary><c>DATA_PHASE</c>.</summary>
        public static readonly EntityDataField<int> Phase = new(16);
    }

    public static class Enderman {
        /// <summary><c>DATA_CARRY_STATE</c>.</summary>
        public static readonly EntityDataField<Optional<IBlock>> CarryState = new(16);
        /// <summary><c>DATA_CREEPY</c>.</summary>
        public static readonly EntityDataField<bool> Creepy = new(17);
        /// <summary><c>DATA_STARED_AT</c>.</summary>
        public static readonly EntityDataField<bool> StaredAt = new(18);
    }

    public static class Entity {
        /// <summary><c>DATA_SHARED_FLAGS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> SharedFlags = new(0);
        /// <summary><c>DATA_AIR_SUPPLY_ID</c>.</summary>
        public static readonly EntityDataField<int> AirSupply = new(1);
        /// <summary><c>DATA_CUSTOM_NAME</c>.</summary>
        public static readonly EntityDataField<Optional<TextComponent>> CustomName = new(2);
        /// <summary><c>DATA_CUSTOM_NAME_VISIBLE</c>.</summary>
        public static readonly EntityDataField<bool> CustomNameVisible = new(3);
        /// <summary><c>DATA_SILENT</c>.</summary>
        public static readonly EntityDataField<bool> Silent = new(4);
        /// <summary><c>DATA_NO_GRAVITY</c>.</summary>
        public static readonly EntityDataField<bool> NoGravity = new(5);
        /// <summary><c>DATA_POSE</c>.</summary>
        public static readonly EntityDataField<EntityPose> Pose = new(6);
        /// <summary><c>DATA_TICKS_FROZEN</c>.</summary>
        public static readonly EntityDataField<int> TicksFrozen = new(7);
    }

    public static class ExperienceOrb {
        /// <summary><c>DATA_VALUE</c>.</summary>
        public static readonly EntityDataField<int> Value = new(8);
    }

    public static class EyeOfEnder {
        /// <summary><c>DATA_ITEM_STACK</c>.</summary>
        public static readonly EntityDataField<ItemStack> ItemStack = new(8);
    }

    public static class FallingBlockEntity {
        /// <summary><c>DATA_START_POS</c>.</summary>
        public static readonly EntityDataField<Vec3<int>> StartPos = new(8);
    }

    public static class Fireball {
        /// <summary><c>DATA_ITEM_STACK</c>.</summary>
        public static readonly EntityDataField<ItemStack> ItemStack = new(8);
    }

    public static class FireworkRocketEntity {
        /// <summary><c>DATA_ID_FIREWORKS_ITEM</c>.</summary>
        public static readonly EntityDataField<ItemStack> IdFireworksItem = new(8);
        /// <summary><c>DATA_ATTACHED_TO_TARGET</c>.</summary>
        public static readonly EntityDataField<Optional<int>> AttachedToTarget = new(9);
        /// <summary><c>DATA_SHOT_AT_ANGLE</c>.</summary>
        public static readonly EntityDataField<bool> ShotAtAngle = new(10);
    }

    public static class FishingHook {
        /// <summary><c>DATA_HOOKED_ENTITY</c>.</summary>
        public static readonly EntityDataField<int> HookedEntity = new(8);
        /// <summary><c>DATA_BITING</c>.</summary>
        public static readonly EntityDataField<bool> Biting = new(9);
    }

    public static class Fox {
        /// <summary><c>DATA_TYPE_ID</c>.</summary>
        public static readonly EntityDataField<int> Type = new(18);
        /// <summary><c>DATA_FLAGS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Flags = new(19);
        /// <summary><c>DATA_TRUSTED_ID_0</c>.</summary>
        public static readonly EntityDataField<Optional<Guid>> TrustedId0 = new(20);
        /// <summary><c>DATA_TRUSTED_ID_1</c>.</summary>
        public static readonly EntityDataField<Optional<Guid>> TrustedId1 = new(21);
    }

    public static class Frog {
        /// <summary><c>DATA_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> Variant = new(18);
        /// <summary><c>DATA_TONGUE_TARGET_ID</c>.</summary>
        public static readonly EntityDataField<Optional<int>> TongueTarget = new(19);
    }

    public static class Ghast {
        /// <summary><c>DATA_IS_CHARGING</c>.</summary>
        public static readonly EntityDataField<bool> IsCharging = new(16);
    }

    public static class GlowSquid {
        /// <summary><c>DATA_DARK_TICKS_REMAINING</c>.</summary>
        public static readonly EntityDataField<int> DarkTicksRemaining = new(18);
    }

    public static class Goat {
        /// <summary><c>DATA_IS_SCREAMING_GOAT</c>.</summary>
        public static readonly EntityDataField<bool> IsScreamingGoat = new(18);
        /// <summary><c>DATA_HAS_LEFT_HORN</c>.</summary>
        public static readonly EntityDataField<bool> HasLeftHorn = new(19);
        /// <summary><c>DATA_HAS_RIGHT_HORN</c>.</summary>
        public static readonly EntityDataField<bool> HasRightHorn = new(20);
    }

    public static class Guardian {
        /// <summary><c>DATA_ID_MOVING</c>.</summary>
        public static readonly EntityDataField<bool> IdMoving = new(16);
        /// <summary><c>DATA_ID_ATTACK_TARGET</c>.</summary>
        public static readonly EntityDataField<int> IdAttackTarget = new(17);
    }

    public static class HangingEntity {
        /// <summary><c>DATA_DIRECTION</c>.</summary>
        public static readonly EntityDataField<Cardinal> Direction = new(8);
    }

    public static class HappyGhast {
        /// <summary><c>IS_LEASH_HOLDER</c>.</summary>
        public static readonly EntityDataField<bool> IsLeashHolder = new(18);
        /// <summary><c>STAYS_STILL</c>.</summary>
        public static readonly EntityDataField<bool> StaysStill = new(19);
    }

    public static class Hoglin {
        /// <summary><c>DATA_IMMUNE_TO_ZOMBIFICATION</c>.</summary>
        public static readonly EntityDataField<bool> ImmuneToZombification = new(18);
    }

    public static class Horse {
        /// <summary><c>DATA_ID_TYPE_VARIANT</c>.</summary>
        public static readonly EntityDataField<int> IdTypeVariant = new(19);
    }

    public static class Interaction {
        /// <summary><c>DATA_WIDTH_ID</c>.</summary>
        public static readonly EntityDataField<float> Width = new(8);
        /// <summary><c>DATA_HEIGHT_ID</c>.</summary>
        public static readonly EntityDataField<float> Height = new(9);
        /// <summary><c>DATA_RESPONSE_ID</c>.</summary>
        public static readonly EntityDataField<bool> Response = new(10);
    }

    public static class IronGolem {
        /// <summary><c>DATA_FLAGS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Flags = new(16);
    }

    public static class ItemDisplay {
        /// <summary><c>DATA_ITEM_STACK_ID</c>.</summary>
        public static readonly EntityDataField<ItemStack> ItemStack = new(23);
        /// <summary><c>DATA_ITEM_DISPLAY_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> ItemDisplayId = new(24);
    }

    public static class ItemEntity {
        /// <summary><c>DATA_ITEM</c>.</summary>
        public static readonly EntityDataField<ItemStack> Item = new(8);
    }

    public static class ItemFrame {
        /// <summary><c>DATA_ITEM</c>.</summary>
        public static readonly EntityDataField<ItemStack> Item = new(9);
        /// <summary><c>DATA_ROTATION</c>.</summary>
        public static readonly EntityDataField<int> Rotation = new(10);
    }

    public static class LivingEntity {
        /// <summary><c>DATA_LIVING_ENTITY_FLAGS</c>.</summary>
        public static readonly EntityDataField<sbyte> LivingEntityFlags = new(8);
        /// <summary><c>DATA_HEALTH_ID</c>.</summary>
        public static readonly EntityDataField<float> Health = new(9);
        /// <summary><c>DATA_EFFECT_PARTICLES</c>.</summary>
        public static readonly EntityDataField<IParticle[]> EffectParticles = new(10);
        /// <summary><c>DATA_EFFECT_AMBIENCE_ID</c>.</summary>
        public static readonly EntityDataField<bool> EffectAmbience = new(11);
        /// <summary><c>DATA_ARROW_COUNT_ID</c>.</summary>
        public static readonly EntityDataField<int> ArrowCount = new(12);
        /// <summary><c>DATA_STINGER_COUNT_ID</c>.</summary>
        public static readonly EntityDataField<int> StingerCount = new(13);
        /// <summary><c>SLEEPING_POS_ID</c>.</summary>
        public static readonly EntityDataField<Optional<Vec3<int>>> SleepingPos = new(14);
    }

    public static class Llama {
        /// <summary><c>DATA_STRENGTH_ID</c>.</summary>
        public static readonly EntityDataField<int> Strength = new(20);
        /// <summary><c>DATA_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> Variant = new(21);
    }

    public static class Mannequin {
        /// <summary><c>DATA_PROFILE</c>.</summary>
        public static readonly EntityDataField<object> Profile = new(17);
        /// <summary><c>DATA_IMMOVABLE</c>.</summary>
        public static readonly EntityDataField<bool> Immovable = new(18);
        /// <summary><c>DATA_DESCRIPTION</c>.</summary>
        public static readonly EntityDataField<Optional<TextComponent>> Description = new(19);
    }

    public static class MinecartCommandBlock {
        /// <summary><c>DATA_ID_COMMAND_NAME</c>.</summary>
        public static readonly EntityDataField<string> IdCommandName = new(13);
        /// <summary><c>DATA_ID_LAST_OUTPUT</c>.</summary>
        public static readonly EntityDataField<TextComponent> IdLastOutput = new(14);
    }

    public static class MinecartFurnace {
        /// <summary><c>DATA_ID_FUEL</c>.</summary>
        public static readonly EntityDataField<bool> IdFuel = new(13);
    }

    public static class Mob {
        /// <summary><c>DATA_MOB_FLAGS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> MobFlags = new(15);
    }

    public static class MushroomCow {
        /// <summary><c>DATA_TYPE</c>.</summary>
        public static readonly EntityDataField<int> Type = new(18);
    }

    public static class Ocelot {
        /// <summary><c>DATA_TRUSTING</c>.</summary>
        public static readonly EntityDataField<bool> Trusting = new(18);
    }

    public static class OminousItemSpawner {
        /// <summary><c>DATA_ITEM</c>.</summary>
        public static readonly EntityDataField<ItemStack> Item = new(8);
    }

    public static class Painting {
        /// <summary><c>DATA_PAINTING_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<Or<int, IPaintingVariant>> PaintingVariant = new(9);
    }

    public static class Panda {
        /// <summary><c>UNHAPPY_COUNTER</c>.</summary>
        public static readonly EntityDataField<int> UnhappyCounter = new(18);
        /// <summary><c>SNEEZE_COUNTER</c>.</summary>
        public static readonly EntityDataField<int> SneezeCounter = new(19);
        /// <summary><c>EAT_COUNTER</c>.</summary>
        public static readonly EntityDataField<int> EatCounter = new(20);
        /// <summary><c>MAIN_GENE_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> MainGene = new(21);
        /// <summary><c>HIDDEN_GENE_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> HiddenGene = new(22);
        /// <summary><c>DATA_ID_FLAGS</c>.</summary>
        public static readonly EntityDataField<sbyte> IdFlags = new(23);
    }

    public static class Parrot {
        /// <summary><c>DATA_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> Variant = new(20);
    }

    public static class Phantom {
        /// <summary><c>ID_SIZE</c>.</summary>
        public static readonly EntityDataField<int> IdSize = new(16);
    }

    public static class Pig {
        /// <summary><c>DATA_BOOST_TIME</c>.</summary>
        public static readonly EntityDataField<int> BoostTime = new(18);
        /// <summary><c>DATA_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> Variant = new(19);
        /// <summary><c>DATA_SOUND_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> SoundVariant = new(20);
    }

    public static class Piglin {
        /// <summary><c>DATA_BABY_ID</c>.</summary>
        public static readonly EntityDataField<bool> Baby = new(17);
        /// <summary><c>DATA_IS_CHARGING_CROSSBOW</c>.</summary>
        public static readonly EntityDataField<bool> IsChargingCrossbow = new(18);
        /// <summary><c>DATA_IS_DANCING</c>.</summary>
        public static readonly EntityDataField<bool> IsDancing = new(19);
    }

    public static class Pillager {
        /// <summary><c>IS_CHARGING_CROSSBOW</c>.</summary>
        public static readonly EntityDataField<bool> IsChargingCrossbow = new(17);
    }

    public static class Player {
        /// <summary><c>DATA_PLAYER_ABSORPTION_ID</c>.</summary>
        public static readonly EntityDataField<float> PlayerAbsorption = new(17);
        /// <summary><c>DATA_SCORE_ID</c>.</summary>
        public static readonly EntityDataField<int> Score = new(18);
        /// <summary><c>DATA_SHOULDER_PARROT_LEFT</c>.</summary>
        public static readonly EntityDataField<Optional<int>> ShoulderParrotLeft = new(19);
        /// <summary><c>DATA_SHOULDER_PARROT_RIGHT</c>.</summary>
        public static readonly EntityDataField<Optional<int>> ShoulderParrotRight = new(20);
    }

    public static class PolarBear {
        /// <summary><c>DATA_STANDING_ID</c>.</summary>
        public static readonly EntityDataField<bool> Standing = new(18);
    }

    public static class PrimedTnt {
        /// <summary><c>DATA_FUSE_ID</c>.</summary>
        public static readonly EntityDataField<int> Fuse = new(8);
        /// <summary><c>DATA_BLOCK_STATE_ID</c>.</summary>
        public static readonly EntityDataField<IBlock> BlockState = new(9);
    }

    public static class Pufferfish {
        /// <summary><c>PUFF_STATE</c>.</summary>
        public static readonly EntityDataField<int> PuffState = new(17);
    }

    public static class Rabbit {
        /// <summary><c>DATA_TYPE_ID</c>.</summary>
        public static readonly EntityDataField<int> Type = new(18);
    }

    public static class Raider {
        /// <summary><c>IS_CELEBRATING</c>.</summary>
        public static readonly EntityDataField<bool> IsCelebrating = new(16);
    }

    public static class Salmon {
        /// <summary><c>DATA_TYPE</c>.</summary>
        public static readonly EntityDataField<int> Type = new(17);
    }

    public static class Sheep {
        /// <summary><c>DATA_WOOL_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Wool = new(18);
    }

    public static class Shulker {
        /// <summary><c>DATA_ATTACH_FACE_ID</c>.</summary>
        public static readonly EntityDataField<Cardinal> AttachFace = new(16);
        /// <summary><c>DATA_PEEK_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Peek = new(17);
        /// <summary><c>DATA_COLOR_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Color = new(18);
    }

    public static class Skeleton {
        /// <summary><c>DATA_STRAY_CONVERSION_ID</c>.</summary>
        public static readonly EntityDataField<bool> StrayConversion = new(16);
    }

    public static class Sniffer {
        /// <summary><c>DATA_STATE</c>.</summary>
        public static readonly EntityDataField<SnifferState> State = new(18);
        /// <summary><c>DATA_DROP_SEED_AT_TICK</c>.</summary>
        public static readonly EntityDataField<int> DropSeedAtTick = new(19);
    }

    public static class SnowGolem {
        /// <summary><c>DATA_PUMPKIN_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Pumpkin = new(16);
    }

    public static class SpellcasterIllager {
        /// <summary><c>DATA_SPELL_CASTING_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> SpellCasting = new(17);
    }

    public static class Spider {
        /// <summary><c>DATA_FLAGS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Flags = new(16);
    }

    public static class Strider {
        /// <summary><c>DATA_BOOST_TIME</c>.</summary>
        public static readonly EntityDataField<int> BoostTime = new(18);
        /// <summary><c>DATA_SUFFOCATING</c>.</summary>
        public static readonly EntityDataField<bool> Suffocating = new(19);
    }

    public static class SulfurCube {
        /// <summary><c>MAX_FUSE</c>.</summary>
        public static readonly EntityDataField<int> MaxFuse = new(19);
        /// <summary><c>FROM_BUCKET</c>.</summary>
        public static readonly EntityDataField<bool> FromBucket = new(20);
    }

    public static class Tadpole {
        /// <summary><c>AGE_LOCKED</c>.</summary>
        public static readonly EntityDataField<bool> AgeLocked = new(17);
    }

    public static class TamableAnimal {
        /// <summary><c>DATA_FLAGS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Flags = new(18);
        /// <summary><c>DATA_OWNERUUID_ID</c>.</summary>
        public static readonly EntityDataField<Optional<Guid>> Owneruuid = new(19);
    }

    public static class TextDisplay {
        /// <summary><c>DATA_TEXT_ID</c>.</summary>
        public static readonly EntityDataField<TextComponent> Text = new(23);
        /// <summary><c>DATA_LINE_WIDTH_ID</c>.</summary>
        public static readonly EntityDataField<int> LineWidth = new(24);
        /// <summary><c>DATA_BACKGROUND_COLOR_ID</c>.</summary>
        public static readonly EntityDataField<int> BackgroundColor = new(25);
        /// <summary><c>DATA_TEXT_OPACITY_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> TextOpacity = new(26);
        /// <summary><c>DATA_STYLE_FLAGS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> StyleFlags = new(27);
    }

    public static class ThrowableItemProjectile {
        /// <summary><c>DATA_ITEM_STACK</c>.</summary>
        public static readonly EntityDataField<ItemStack> ItemStack = new(8);
    }

    public static class ThrownTrident {
        /// <summary><c>ID_LOYALTY</c>.</summary>
        public static readonly EntityDataField<sbyte> IdLoyalty = new(11);
        /// <summary><c>ID_FOIL</c>.</summary>
        public static readonly EntityDataField<bool> IdFoil = new(12);
    }

    public static class TropicalFish {
        /// <summary><c>DATA_ID_TYPE_VARIANT</c>.</summary>
        public static readonly EntityDataField<int> IdTypeVariant = new(17);
    }

    public static class Turtle {
        /// <summary><c>HAS_EGG</c>.</summary>
        public static readonly EntityDataField<bool> HasEgg = new(18);
        /// <summary><c>LAYING_EGG</c>.</summary>
        public static readonly EntityDataField<bool> LayingEgg = new(19);
    }

    public static class VehicleEntity {
        /// <summary><c>DATA_ID_HURT</c>.</summary>
        public static readonly EntityDataField<int> IdHurt = new(8);
        /// <summary><c>DATA_ID_HURTDIR</c>.</summary>
        public static readonly EntityDataField<int> IdHurtdir = new(9);
        /// <summary><c>DATA_ID_DAMAGE</c>.</summary>
        public static readonly EntityDataField<float> IdDamage = new(10);
    }

    public static class Vex {
        /// <summary><c>DATA_FLAGS_ID</c>.</summary>
        public static readonly EntityDataField<sbyte> Flags = new(16);
    }

    public static class Villager {
        /// <summary><c>DATA_VILLAGER_DATA</c>.</summary>
        public static readonly EntityDataField<(int, int, int)> VillagerData = new(19);
        /// <summary><c>DATA_VILLAGER_DATA_FINALIZED</c>.</summary>
        public static readonly EntityDataField<bool> VillagerDataFinalized = new(20);
    }

    public static class Warden {
        /// <summary><c>CLIENT_ANGER_LEVEL</c>.</summary>
        public static readonly EntityDataField<int> ClientAngerLevel = new(16);
    }

    public static class Witch {
        /// <summary><c>DATA_USING_ITEM</c>.</summary>
        public static readonly EntityDataField<bool> UsingItem = new(17);
    }

    public static class WitherBoss {
        /// <summary><c>DATA_TARGET_A</c>.</summary>
        public static readonly EntityDataField<int> TargetA = new(16);
        /// <summary><c>DATA_TARGET_B</c>.</summary>
        public static readonly EntityDataField<int> TargetB = new(17);
        /// <summary><c>DATA_TARGET_C</c>.</summary>
        public static readonly EntityDataField<int> TargetC = new(18);
        /// <summary><c>DATA_ID_INV</c>.</summary>
        public static readonly EntityDataField<int> IdInv = new(19);
    }

    public static class WitherSkull {
        /// <summary><c>DATA_DANGEROUS</c>.</summary>
        public static readonly EntityDataField<bool> Dangerous = new(8);
    }

    public static class Wolf {
        /// <summary><c>DATA_INTERESTED_ID</c>.</summary>
        public static readonly EntityDataField<bool> Interested = new(20);
        /// <summary><c>DATA_COLLAR_COLOR</c>.</summary>
        public static readonly EntityDataField<int> CollarColor = new(21);
        /// <summary><c>DATA_ANGER_END_TIME</c>.</summary>
        public static readonly EntityDataField<long> AngerEndTime = new(22);
        /// <summary><c>DATA_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> Variant = new(23);
        /// <summary><c>DATA_SOUND_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> SoundVariant = new(24);
    }

    public static class Zoglin {
        /// <summary><c>DATA_BABY_ID</c>.</summary>
        public static readonly EntityDataField<bool> Baby = new(16);
    }

    public static class Zombie {
        /// <summary><c>DATA_BABY_ID</c>.</summary>
        public static readonly EntityDataField<bool> Baby = new(16);
        /// <summary><c>DATA_SPECIAL_TYPE_ID</c>.</summary>
        public static readonly EntityDataField<int> SpecialType = new(17);
        /// <summary><c>DATA_DROWNED_CONVERSION_ID</c>.</summary>
        public static readonly EntityDataField<bool> DrownedConversion = new(18);
    }

    public static class ZombieNautilus {
        /// <summary><c>DATA_VARIANT_ID</c>.</summary>
        public static readonly EntityDataField<int> Variant = new(21);
    }

    public static class ZombieVillager {
        /// <summary><c>DATA_CONVERTING_ID</c>.</summary>
        public static readonly EntityDataField<bool> Converting = new(19);
        /// <summary><c>DATA_VILLAGER_DATA</c>.</summary>
        public static readonly EntityDataField<(int, int, int)> VillagerData = new(20);
        /// <summary><c>DATA_VILLAGER_DATA_FINALIZED</c>.</summary>
        public static readonly EntityDataField<bool> VillagerDataFinalized = new(21);
    }
}

using ClientLib.Entities;
using ClientLib.Player;
using Minecraft.Data;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Instrument;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Interaction;

/// <summary><c>InteractionResult</c> as the hand loop reads it.</summary>
public enum InteractionResult {
    Pass,
    /// <summary>Consumed, with the swing predicted on this side.</summary>
    Success,
    /// <summary>Consumed with no swing here.</summary>
    Consume
}

/// <summary>
/// Whether a right click is consumed, decided by the vanilla class or item instead of running the
/// block's and item's own interaction code as vanilla's client does. The packets sent are the same
/// either way; a wrong answer costs at most a swing, or an extra or missing packet for the off hand: a
/// <c>use_item</c>, or for an entity a second interact the server acts on too. It is wrong where the answer depends on state: a cake when the player is full, a jukebox with
/// no disc, a cauldron that cannot take the held item, a bucket aimed at nothing it can fill. A block
/// item's <c>useOn</c> is run for real instead.
/// </summary>
public static class UsePrediction {
    /// <summary>Blocks whose own class answers a click, matched on the nearest class so a subclass that passes is not swept in.</summary>
    private static readonly HashSet<BlockClass> InteractableBlocks = [
        BlockClass.ChestBlock, BlockClass.TrappedChestBlock, BlockClass.EnderChestBlock, BlockClass.BarrelBlock,
        BlockClass.ShulkerBoxBlock, BlockClass.FurnaceBlock, BlockClass.SmokerBlock, BlockClass.BlastFurnaceBlock,
        BlockClass.CraftingTableBlock, BlockClass.ButtonBlock, BlockClass.LeverBlock, BlockClass.BedBlock, BlockClass.AnvilBlock,
        BlockClass.EnchantingTableBlock, BlockClass.BrewingStandBlock, BlockClass.BeaconBlock, BlockClass.HopperBlock,
        BlockClass.DispenserBlock, BlockClass.DropperBlock, BlockClass.NoteBlock, BlockClass.RepeaterBlock,
        BlockClass.ComparatorBlock, BlockClass.DaylightDetectorBlock, BlockClass.LecternBlock, BlockClass.LoomBlock,
        BlockClass.CartographyTableBlock, BlockClass.GrindstoneBlock, BlockClass.SmithingTableBlock, BlockClass.StonecutterBlock,
        BlockClass.BellBlock, BlockClass.RespawnAnchorBlock, BlockClass.JukeboxBlock, BlockClass.FlowerPotBlock,
        BlockClass.CampfireBlock, BlockClass.CrafterBlock, BlockClass.ChiseledBookShelfBlock, BlockClass.ComposterBlock,
        BlockClass.CakeBlock, BlockClass.CandleCakeBlock, BlockClass.CauldronBlock, BlockClass.LayeredCauldronBlock,
        BlockClass.LavaCauldronBlock, BlockClass.RedstoneWireBlock, BlockClass.DecoratedPotBlock, BlockClass.ShelfBlock, BlockClass.CopperChestBlock,
        BlockClass.WeatheringCopperChestBlock, BlockClass.CopperGolemStatueBlock, BlockClass.WeatheringCopperGolemStatueBlock,
        BlockClass.CopperBulbBlock, BlockClass.WeatheringCopperBulbBlock, BlockClass.VaultBlock, BlockClass.TrialSpawnerBlock,
        BlockClass.StandingSignBlock, BlockClass.WallSignBlock, BlockClass.CeilingHangingSignBlock,
        BlockClass.WallHangingSignBlock, BlockClass.DragonEggBlock, BlockClass.PumpkinBlock, BlockClass.SweetBerryBushBlock,
        BlockClass.CaveVinesBlock, BlockClass.CaveVinesPlantBlock, BlockClass.BeehiveBlock, BlockClass.BrushableBlock
    ];

    public static bool BlockConsumesUse(IBlock block, Hand hand) {
        Identifier id = block.Identifier;
        if (BlockClasses.Is(id, BlockClass.DoorBlock)) {
            return BlockClasses.DoorOpensByHand(id);
        }
        if (BlockClasses.Is(id, BlockClass.TrapDoorBlock)) {
            return id != Block.IronTrapdoor.Identifier;
        }
        if (BlockClasses.Is(id, BlockClass.FenceGateBlock)) {
            return true;
        }
        // Most use is useWithoutItem, which vanilla only tries for the main hand.
        return hand == Hand.MainHand && BlockClasses.Of(id) is [var nearest, ..] && InteractableBlocks.Contains(nearest);
    }

    /// <summary>Items whose <c>useOn</c> answers every block, taking a <c>FAIL</c>, which also ends the click, as consumed.</summary>
    private static readonly HashSet<Identifier> UseOnItems = Ids(
        Item.FlintAndSteel, Item.FireCharge, Item.BoneMeal, Item.ItemFrame, Item.GlowItemFrame, Item.Painting, Item.ArmorStand,
        Item.EndCrystal, Item.Minecart, Item.ChestMinecart, Item.FurnaceMinecart, Item.HopperMinecart, Item.TntMinecart,
        Item.CommandBlockMinecart, Item.DebugStick);

    /// <summary>The <c>PotionItem</c>s: the splash and lingering potions extend it.</summary>
    private static readonly HashSet<Identifier> Potions = Ids(Item.Potion, Item.SplashPotion, Item.LingeringPotion);

    /// <summary>The <c>MapItem</c>s.</summary>
    private static readonly HashSet<Identifier> Maps = Ids(
        Item.FilledMap, Item.OceanMonumentMap, Item.WoodlandMansionMap, Item.BuriedTrialChambersMap, Item.JunglePyramidMap, Item.SwampHutMap,
        Item.DesertVillageMap, Item.PlainsVillageMap, Item.SavannaVillageMap, Item.SnowyVillageMap, Item.TaigaVillageMap, Item.BuriedTreasureMap,
        Item.BuriedAncientCityMap, Item.BuriedMineshaftMap, Item.DesertPyramidMap, Item.AbandonedCampMap, Item.WarmOceanRuinsMap);

    private static readonly Identifier ConvertibleToMud = "minecraft:convertible_to_mud";
    private static readonly Identifier Banners = "minecraft:banners";

    /// <summary><c>ItemTags.LECTERN_BOOKS</c>.</summary>
    private static readonly HashSet<Identifier> LecternBooks = Ids(Item.WritableBook, Item.WrittenBook);

    /// <summary>
    /// <c>useOn</c> of the held item's class as the client runs it. A pass falls through to the item's <c>use</c>,
    /// so an item with one of each must pass wherever vanilla's does. <see cref="InteractionResult.Consume"/> is
    /// the brush's, which starts using the item.
    /// </summary>
    /// <remarks>An item with a <c>block_transformer</c> is judged by <see cref="BlockTransforms"/> instead.</remarks>
    public static InteractionResult ItemUseOn(ItemStack held, IBlock target, BlockFace face, bool fallFlying, BlockTags tags) {
        Identifier item = held.Type.Identifier, block = target.Identifier;
        // Only SpawnEggItem carries entity_data by default.
        if (UseOnItems.Contains(item) || held.Type.DefaultComponents.ContainsKey(DataComponent.EntityData)) {
            return InteractionResult.Success;
        }
        if (item == Item.Brush.Identifier) {
            return InteractionResult.Consume;
        }
        if (item == Item.EnderEye.Identifier) {
            return target is EndPortalFrameBlock { Eye: false } ? InteractionResult.Success : InteractionResult.Pass;
        }
        if (item == Item.FireworkRocket.Identifier) {
            return fallFlying ? InteractionResult.Pass : InteractionResult.Success;
        }
        if (Potions.Contains(item)) {
            return face != BlockFace.NegY && tags.Contains(ConvertibleToMud, target)
                   && ItemComponents.Get(held, DataComponent.PotionContents)?.Potion?.Identifier == Potion.Water.Identifier
                ? InteractionResult.Success
                : InteractionResult.Pass;
        }
        if (item == Item.Compass.Identifier) {
            return block == Block.Lodestone.Identifier ? InteractionResult.Success : InteractionResult.Pass;
        }
        if (Maps.Contains(item)) {
            return tags.Contains(Banners, target) ? InteractionResult.Success : InteractionResult.Pass;
        }
        if (item == Item.Shears.Identifier) {
            return BlockClasses.Is(block, BlockClass.GrowingPlantHeadBlock) && target is IAged { Age: < 25 } ? InteractionResult.Success : InteractionResult.Pass;
        }
        // LecternBlock.useItemOn takes a book from either hand. A book has no useOn of its own, so anywhere
        // else the click falls through to use, which opens it.
        if (LecternBooks.Contains(item)) {
            return BlockClasses.Of(block) is [var lectern, ..] && lectern == BlockClass.LecternBlock ? InteractionResult.Success : InteractionResult.Pass;
        }
        if (item == Item.Honeycomb.Identifier) {
            return BlockConversions.Waxables.ContainsKey(block) ? InteractionResult.Success : InteractionResult.Pass;
        }
        return InteractionResult.Pass;
    }

    private static readonly HashSet<Identifier> HeldUntilReleased = Ids(
        Item.Bow, Item.Crossbow, Item.Trident, Item.Shield, Item.Spyglass, Item.GoatHorn, Item.Brush);

    private static readonly HashSet<Identifier> UsedAtOnce = Ids(
        Item.FishingRod, Item.EnderPearl, Item.Snowball, Item.Egg, Item.BlueEgg, Item.BrownEgg, Item.ExperienceBottle, Item.SplashPotion,
        Item.LingeringPotion, Item.WindCharge, Item.FireworkRocket, Item.EnderEye, Item.WritableBook, Item.WrittenBook, Item.Map,
        Item.Bundle, Item.GlassBottle, Item.Bucket, Item.WaterBucket, Item.LavaBucket, Item.PowderSnowBucket, Item.MilkBucket,
        Item.AxolotlBucket, Item.CodBucket, Item.PufferfishBucket, Item.SalmonBucket, Item.SulfurCubeBucket, Item.TadpoleBucket,
        Item.TropicalFishBucket);

    /// <returns>
    /// Whether using the item consumes the click, and <see cref="UseDuration"/> for an item that is held in
    /// use, 0 for one used at once. A consumable the player cannot consume yet is
    /// <c>Consumable.startConsuming</c>'s FAIL, which the hand loop treats as a pass.
    /// </returns>
    public static (bool Consumes, int Duration) ItemUse(ItemStack held, LocalPlayer? player = null) {
        Identifier item = held.Type.Identifier;
        if (ItemComponents.Has(held, DataComponent.Consumable)) {
            return player != null && !CanConsume(player, held) ? (false, 0) : (true, UseDuration(held));
        }
        if (item == Item.Trident.Identifier && player != null && player.TridentUseFails(held)) {
            return (false, 0);
        }
        if (HeldUntilReleased.Contains(item)) {
            // InstrumentItem.use fails for a horn with no instrument, the one held item whose duration can be 0.
            int duration = UseDuration(held);
            return duration > 0 ? (true, duration) : (false, 0);
        }
        if (UsedAtOnce.Contains(item) || ItemComponents.Has(held, DataComponent.Equippable)) {
            return (true, 0);
        }
        // Item.use: a spear, or anything given these components, is held until let go.
        if (ItemComponents.Has(held, DataComponent.BlocksAttacks) || ItemComponents.Has(held, DataComponent.KineticWeapon)) {
            return (true, UseDuration(held));
        }
        return (false, 0);
    }

    /// <summary>The <c>BundleItem</c>s: the bundle and its sixteen dyes.</summary>
    private static readonly HashSet<Identifier> Bundles = Ids(
        Item.Bundle, Item.WhiteBundle, Item.OrangeBundle, Item.MagentaBundle, Item.LightBlueBundle, Item.YellowBundle, Item.LimeBundle,
        Item.PinkBundle, Item.GrayBundle, Item.LightGrayBundle, Item.CyanBundle, Item.PurpleBundle, Item.BlueBundle, Item.BrownBundle,
        Item.GreenBundle, Item.RedBundle, Item.BlackBundle);

    /// <summary><c>ItemStack.getUseDuration</c>: <c>Item.getUseDuration</c> and the overrides of the items that have one.</summary>
    public static int UseDuration(ItemStack stack) {
        Identifier item = stack.Type.Identifier;
        if (item == Item.Spyglass.Identifier) {
            return 1200;
        }
        if (item == Item.Brush.Identifier || Bundles.Contains(item)) {
            return 200;
        }
        if (item == Item.GoatHorn.Identifier) {
            // The generated defaults leave out the horn's delayed instrument component, which is the ponder horn.
            IInstrument? instrument = stack.RemoveComponents.Contains(DataComponent.Instrument)
                ? null
                : ItemComponents.Get(stack, DataComponent.Instrument) ?? Instrument.PonderGoatHorn;
            return instrument != null ? (int)Math.Floor(instrument.UseDuration * 20.0F) : 0;
        }
        if (item == Item.Bow.Identifier || item == Item.Crossbow.Identifier || item == Item.Trident.Identifier) {
            return 72000;
        }
        if (ItemComponents.Get(stack, DataComponent.Consumable) is { } consumable) {
            return (int)(consumable.ConsumeSeconds * 20.0F);
        }
        return ItemComponents.Has(stack, DataComponent.BlocksAttacks) || ItemComponents.Has(stack, DataComponent.KineticWeapon) ? 72000 : 0;
    }

    /// <summary><c>Consumable.canConsume</c> with <c>Player.canEat</c>: food waits for hunger unless it can always be eaten.</summary>
    public static bool CanConsume(LocalPlayer player, ItemStack stack) =>
        ItemComponents.Get(stack, DataComponent.Food) is not { } food || player.Invulnerable || food.CanAlwaysEat || player.Food < 20;

    private static readonly HashSet<Identifier> EntityItems = Ids(Item.Lead, Item.NameTag, Item.Shears, Item.Bucket, Item.Bowl, Item.Saddle);

    private static readonly Identifier WolfFood = "minecraft:wolf_food";
    private static readonly Identifier WolfCollarDyes = "minecraft:wolf_collar_dyes";
    private static readonly Identifier CatFood = "minecraft:cat_food";
    private static readonly Identifier CatCollarDyes = "minecraft:cat_collar_dyes";
    private static readonly Identifier ParrotFood = "minecraft:parrot_food";
    private static readonly Identifier ParrotPoisonousFood = "minecraft:parrot_poisonous_food";
    private static readonly Identifier CannotBeAgeLocked = "minecraft:cannot_be_age_locked";
    private static readonly Identifier AxolotlFood = "minecraft:axolotl_food";
    private static readonly Identifier FrogFood = "minecraft:frog_food";

    /// <summary>Entities a right click does something to, before the held item gets a turn.</summary>
    /// <remarks>
    /// The pets run their own <c>mobInteract</c>: an owner's click on one must not pass, or the off hand
    /// sends a second interact and the server takes it as a second order to sit, standing the pet back up.
    /// </remarks>
    public static InteractionResult InteractWithEntity(MinecraftClient client, LocalPlayer player, ClientEntity entity, ItemStack held, bool sneaking) {
        if (entity.Is(EntityClass.ItemFrame)) {
            return InteractionResult.Success;
        }
        if (entity.Is(EntityClass.AbstractVillager) || entity.Is(EntityClass.ArmorStand) || entity.Is(EntityClass.AbstractBoat)
            || entity.Is(EntityClass.AbstractMinecart) || entity.Is(EntityClass.AbstractHorse) || entity.Is(EntityClass.Pig)
            || entity.Is(EntityClass.Strider) || entity.Is(EntityClass.AbstractNautilus) || entity.Is(EntityClass.HappyGhast)) {
            return sneaking ? InteractionResult.Pass : InteractionResult.Success;
        }
        if (!ItemComponents.IsEmpty(held) && EntityItems.Contains(held.Type.Identifier)) {
            return InteractionResult.Success;
        }
        if (entity.Is(EntityClass.Wolf)) {
            return WolfInteract(client, player, entity, held);
        }
        if (entity.Is(EntityClass.Cat)) {
            return CatInteract(client, player, entity, held);
        }
        if (entity.Is(EntityClass.Parrot)) {
            return ParrotInteract(client, player, entity, held);
        }
        if (entity.Is(EntityClass.Axolotl)) {
            return BucketMobPickup(entity, held) ? InteractionResult.Success : AnimalInteract(client, entity, held, client.InItemTag(held, AxolotlFood));
        }
        if (entity.Is(EntityClass.Tadpole)) {
            return TadpoleInteract(client, entity, held);
        }
        return entity.Is(EntityClass.AbstractFish) && BucketMobPickup(entity, held) ? InteractionResult.Success : InteractionResult.Pass;
    }

    /// <summary>
    /// <c>Bucketable.bucketMobPickup</c> with the default <c>canBePickedUpWithBucket</c>: the client fills
    /// the bucket too, so the bucket's own use never runs after it.
    /// </summary>
    private static bool BucketMobPickup(ClientEntity entity, ItemStack held) =>
        held.Type.Identifier == Item.WaterBucket.Identifier && entity.CurrentHealth > 0.0F;

    /// <summary><c>Tadpole.mobInteract</c>, then <c>AbstractFish</c>'s pickup; a tadpole is always a baby.</summary>
    private static InteractionResult TadpoleInteract(MinecraftClient client, ClientEntity tadpole, ItemStack held) {
        if (client.InItemTag(held, FrogFood) && !tadpole.Get(EntityDataFields.Tadpole.AgeLocked)) {
            return InteractionResult.Success;
        }
        if (held.Type.Identifier == Item.GoldenDandelion.Identifier && !client.InEntityTypeTag(tadpole.Type, CannotBeAgeLocked)) {
            return InteractionResult.Success;
        }
        return BucketMobPickup(tadpole, held) ? InteractionResult.Success : InteractionResult.Pass;
    }

    /// <summary><c>Wolf.mobInteract</c> as the client runs it, where taming with a bone is the server's alone.</summary>
    private static InteractionResult WolfInteract(MinecraftClient client, LocalPlayer player, ClientEntity wolf, ItemStack held) {
        bool food = client.InItemTag(held, WolfFood);
        if (IsTame(wolf)) {
            if (food && wolf.CurrentHealth < wolf.Attributes.Value(Attribute.MaxHealth)) {
                return InteractionResult.Success;
            }
            if (!client.InItemTag(held, WolfCollarDyes) || !IsOwnedBy(wolf, player)) {
                if (IsEquippableInBodySlot(client, wolf, held) && !IsWearingBodyArmor(client, wolf) && IsOwnedBy(wolf, player) && !wolf.IsBaby) {
                    return InteractionResult.Success;
                }
                ItemStack armor = wolf.GetItemBySlot(EquipmentSlot.Body);
                if (IsInSittingPose(wolf) && IsWearingBodyArmor(client, wolf) && IsOwnedBy(wolf, player) && ItemBars.IsDamaged(armor)
                    && ItemComponents.Get(armor, DataComponent.Repairable) is { } repairable && client.InItemSet(repairable, held.Type)) {
                    return InteractionResult.Success;
                }
                InteractionResult result = AnimalInteract(client, wolf, held, food);
                return result == InteractionResult.Pass && IsOwnedBy(wolf, player) ? InteractionResult.Success : result;
            }
            if (ItemComponents.Has(held, DataComponent.Dye)
                && (int)ItemComponents.Get(held, DataComponent.Dye) != wolf.Get(EntityDataFields.Wolf.CollarColor, (int)DyeColor.Red)) {
                return InteractionResult.Success;
            }
        }
        return AnimalInteract(client, wolf, held, food);
    }

    /// <summary><c>Cat.mobInteract</c>.</summary>
    private static InteractionResult CatInteract(MinecraftClient client, LocalPlayer player, ClientEntity cat, ItemStack held) {
        bool food = client.InItemTag(held, CatFood);
        if (IsTame(cat)) {
            if (IsOwnedBy(cat, player)) {
                if (client.InItemTag(held, CatCollarDyes)) {
                    if (ItemComponents.Has(held, DataComponent.Dye)
                        && (int)ItemComponents.Get(held, DataComponent.Dye) != cat.Get(EntityDataFields.Cat.CollarColor, (int)DyeColor.Red)) {
                        return InteractionResult.Success;
                    }
                }
                else if (food && cat.CurrentHealth < cat.Attributes.Value(Attribute.MaxHealth)) {
                    return InteractionResult.Success;
                }
                InteractionResult parent = AnimalInteract(client, cat, held, food);
                return parent == InteractionResult.Pass ? InteractionResult.Success : parent;
            }
        }
        else if (food) {
            return InteractionResult.Success;
        }
        return AnimalInteract(client, cat, held, food);
    }

    /// <summary><c>Parrot.mobInteract</c>, whose <c>isFood</c> is always false.</summary>
    private static InteractionResult ParrotInteract(MinecraftClient client, LocalPlayer player, ClientEntity parrot, ItemStack held) {
        if (!IsTame(parrot) && client.InItemTag(held, ParrotFood)) {
            return InteractionResult.Success;
        }
        if (!client.InItemTag(held, ParrotPoisonousFood)) {
            // Parrot.isFlying is !onGround.
            return parrot.OnGround && IsTame(parrot) && IsOwnedBy(parrot, player) ? InteractionResult.Success : AnimalInteract(client, parrot, held, false);
        }
        return InteractionResult.Success;
    }

    /// <summary>
    /// <c>Animal.mobInteract</c> on the client, where breeding is the server's: food grows a baby or is
    /// consumed unanswered. Then <c>AgeableMob</c>'s golden dandelion, taking the two second cooldown a
    /// client starts when it runs one itself as already over.
    /// </summary>
    private static InteractionResult AnimalInteract(MinecraftClient client, ClientEntity animal, ItemStack held, bool food) {
        if (food) {
            return animal.IsBaby && !animal.Get(EntityDataFields.AgeableMob.AgeLocked) ? InteractionResult.Success : InteractionResult.Consume;
        }
        return held.Type.Identifier == Item.GoldenDandelion.Identifier && animal.IsBaby && !client.InEntityTypeTag(animal.Type, CannotBeAgeLocked)
            ? InteractionResult.Success
            : InteractionResult.Pass;
    }

    private static bool IsTame(ClientEntity entity) => (entity.Get(EntityDataFields.TamableAnimal.Flags) & 4) != 0;

    private static bool IsInSittingPose(ClientEntity entity) => (entity.Get(EntityDataFields.TamableAnimal.Flags) & 1) != 0;

    /// <summary><c>TamableAnimal.isOwnedBy</c>: the owner reference resolves only to an entity the client has, which the local player always is.</summary>
    private static bool IsOwnedBy(ClientEntity entity, LocalPlayer player) =>
        entity.Get(EntityDataFields.TamableAnimal.Owneruuid) is { Present: true } owner && owner.Value == player.Uuid;

    /// <summary><c>LivingEntity.isEquippableInSlot</c> for the body, on a mob that can use every slot.</summary>
    private static bool IsEquippableInBodySlot(MinecraftClient client, ClientEntity entity, ItemStack stack) =>
        ItemComponents.Get(stack, DataComponent.Equippable) is { } equippable
        && equippable.Slot == EquippableComponent.Slot.Body && client.CanBeEquippedBy(equippable, entity.Type);

    /// <summary><c>Mob.isWearingBodyArmor</c>.</summary>
    private static bool IsWearingBodyArmor(MinecraftClient client, ClientEntity entity) {
        ItemStack armor = entity.GetItemBySlot(EquipmentSlot.Body);
        return !armor.IsAir() && IsEquippableInBodySlot(client, entity, armor);
    }

    private static HashSet<Identifier> Ids(params IProtocolType[] types) => types.Select(t => t.Identifier).ToHashSet();
}

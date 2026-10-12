using ClientLib.Entities;
using ClientLib.Player;
using Minecraft.Data;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Instrument;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Interaction;

/// <summary>
/// Whether a right click is consumed, decided by the vanilla class or item instead of running the
/// block's and item's own interaction code as vanilla's client does. The packets sent are the same
/// either way; a wrong answer costs at most a swing, or an extra or missing <c>use_item</c> for the off
/// hand. It is wrong where the answer depends on state: a cake when the player is full, a jukebox with
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
        BlockClass.LavaCauldronBlock, BlockClass.RedStoneWireBlock, BlockClass.DecoratedPotBlock, BlockClass.ShelfBlock, BlockClass.CopperChestBlock,
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

    private static readonly HashSet<Identifier> UseOnItems = Ids(
        Item.FlintAndSteel, Item.FireCharge, Item.BoneMeal, Item.ItemFrame, Item.GlowItemFrame, Item.Painting, Item.ArmorStand,
        Item.EndCrystal, Item.Lead, Item.Minecart, Item.ChestMinecart, Item.FurnaceMinecart, Item.HopperMinecart, Item.TntMinecart,
        Item.CommandBlockMinecart, Item.EnderEye, Item.Honeycomb, Item.Brush, Item.DebugStick, Item.GlassBottle);

    /// <summary><c>ItemTags.LECTERN_BOOKS</c>.</summary>
    private static readonly HashSet<Identifier> LecternBooks = Ids(Item.WritableBook, Item.WrittenBook);

    private static readonly HashSet<Identifier> Hoes = Ids(
        Item.WoodenHoe, Item.StoneHoe, Item.CopperHoe, Item.IronHoe, Item.GoldenHoe, Item.DiamondHoe, Item.NetheriteHoe);
    private static readonly HashSet<Identifier> Shovels = Ids(
        Item.WoodenShovel, Item.StoneShovel, Item.CopperShovel, Item.IronShovel, Item.GoldenShovel, Item.DiamondShovel, Item.NetheriteShovel);
    private static readonly HashSet<Identifier> Axes = Ids(
        Item.WoodenAxe, Item.StoneAxe, Item.CopperAxe, Item.IronAxe, Item.GoldenAxe, Item.DiamondAxe, Item.NetheriteAxe);

    /// <summary><c>HoeItem.TILLABLES</c>.</summary>
    private static readonly HashSet<Identifier> Tillables = Ids(Block.GrassBlock, Block.Dirt, Block.DirtPath, Block.CoarseDirt, Block.RootedDirt);

    /// <summary><c>ShovelItem.FLATTENABLES</c>.</summary>
    private static readonly HashSet<Identifier> Flattenables = Ids(Block.GrassBlock, Block.Dirt, Block.Podzol, Block.Mycelium, Block.CoarseDirt, Block.RootedDirt);

    public static bool ItemUseOnConsumes(ItemStack held, IBlock target) {
        Identifier item = held.Type.Identifier, block = target.Identifier;
        // Only SpawnEggItem carries entity_data by default.
        if (UseOnItems.Contains(item) || held.Type.DefaultComponents.ContainsKey(DataComponent.EntityData)) {
            return true;
        }
        // LecternBlock.useItemOn takes a book from either hand. A book has no useOn of its own, so anywhere
        // else the click falls through to use, which opens it.
        if (LecternBooks.Contains(item)) {
            return BlockClasses.Of(block) is [var lectern, ..] && lectern == BlockClass.LecternBlock;
        }
        if (Hoes.Contains(item)) {
            return Tillables.Contains(block);
        }
        if (Shovels.Contains(item)) {
            return Flattenables.Contains(block) || BlockClasses.Of(block) is [var nearest, ..] && nearest == BlockClass.CampfireBlock;
        }
        if (Axes.Contains(item)) {
            // The strippable and waxable blocks have no generated table, so they are matched by name.
            string path = block.Key;
            return path.EndsWith("_log") || path.EndsWith("_wood") || path.EndsWith("_stem") || path.EndsWith("_hyphae")
                   || path.Contains("copper") || block == Block.BambooBlock.Identifier;
        }
        return false;
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

    /// <summary>Entities a right click does something to, before the held item gets a turn.</summary>
    public static bool InteractWithEntity(ClientEntity entity, ItemStack held, bool sneaking) {
        if (entity.Is(EntityClass.ItemFrame)) {
            return true;
        }
        if (entity.Is(EntityClass.AbstractVillager) || entity.Is(EntityClass.ArmorStand) || entity.Is(EntityClass.AbstractBoat)
            || entity.Is(EntityClass.AbstractMinecart) || entity.Is(EntityClass.AbstractHorse) || entity.Is(EntityClass.Pig)
            || entity.Is(EntityClass.Strider) || entity.Is(EntityClass.AbstractNautilus) || entity.Is(EntityClass.HappyGhast)) {
            return !sneaking;
        }
        return !ItemComponents.IsEmpty(held) && EntityItems.Contains(held.Type.Identifier);
    }

    private static HashSet<Identifier> Ids(params IProtocolType[] types) => types.Select(t => t.Identifier).ToHashSet();
}

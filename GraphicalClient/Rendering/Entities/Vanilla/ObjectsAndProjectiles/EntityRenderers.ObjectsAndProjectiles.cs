using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;

namespace GraphicalClient.Rendering.Entities;

public static partial class EntityRenderers {
    static partial void RegisterObjectsAndProjectiles() {
        (IEntityType Boat, IEntityType ChestBoat, string Wood)[] boats = [
            (EntityType.AcaciaBoat, EntityType.AcaciaChestBoat, "acacia"), (EntityType.BirchBoat, EntityType.BirchChestBoat, "birch"),
            (EntityType.CherryBoat, EntityType.CherryChestBoat, "cherry"), (EntityType.DarkOakBoat, EntityType.DarkOakChestBoat, "dark_oak"),
            (EntityType.JungleBoat, EntityType.JungleChestBoat, "jungle"), (EntityType.MangroveBoat, EntityType.MangroveChestBoat, "mangrove"),
            (EntityType.OakBoat, EntityType.OakChestBoat, "oak"), (EntityType.PaleOakBoat, EntityType.PaleOakChestBoat, "pale_oak"),
            (EntityType.SpruceBoat, EntityType.SpruceChestBoat, "spruce")
        ];
        foreach ((IEntityType boat, IEntityType chestBoat, string wood) in boats) {
            Register(boat, _ => new BoatRenderer($"boat/{wood}", false));
            Register(chestBoat, _ => new BoatRenderer($"chest_boat/{wood}", true));
        }
        Register(EntityType.BambooRaft, _ => new RaftRenderer("boat/bamboo", false));
        Register(EntityType.BambooChestRaft, _ => new RaftRenderer("chest_boat/bamboo", true));

        foreach (IEntityType minecart in (IEntityType[])[EntityType.Minecart, EntityType.ChestMinecart, EntityType.CommandBlockMinecart, EntityType.FurnaceMinecart,
                     EntityType.HopperMinecart, EntityType.SpawnerMinecart]) {
            Register(minecart, context => new MinecartRenderer(context));
        }
        Register(EntityType.TntMinecart, context => new TntMinecartRenderer(context));

        Register(EntityType.Tnt, context => new TntRenderer(context));
        Register(EntityType.FallingBlock, context => new FallingBlockRenderer(context));
        Register(EntityType.ItemFrame, context => new ItemFrameRenderer(context));
        Register(EntityType.GlowItemFrame, context => new ItemFrameRenderer(context));
        Register(EntityType.Painting, _ => new PaintingRenderer());
        Register(EntityType.LeashKnot, _ => new LeashKnotRenderer());
        Register(EntityType.BlockDisplay, context => new DisplayRenderer.BlockDisplayRenderer(context));
        Register(EntityType.ItemDisplay, context => new DisplayRenderer.ItemDisplayRenderer(context));
        Register(EntityType.ExperienceOrb, _ => new ExperienceOrbRenderer());
        Register(EntityType.LightningBolt, _ => new LightningBoltRenderer());
        Register(EntityType.OminousItemSpawner, context => new OminousItemSpawnerRenderer(context));
        Register(EntityType.Interaction, _ => new NoopRenderer());
        Register(EntityType.Marker, _ => new NoopRenderer());

        Register(EntityType.Arrow, _ => new TippableArrowRenderer());
        Register(EntityType.SpectralArrow, _ => new SpectralArrowRenderer());
        Register(EntityType.Trident, _ => new ThrownTridentRenderer());

        foreach ((IEntityType type, IItem item) in (ReadOnlySpan<(IEntityType, IItem)>)[(EntityType.Snowball, Item.Snowball), (EntityType.Egg, Item.Egg),
                     (EntityType.EnderPearl, Item.EnderPearl), (EntityType.SplashPotion, Item.SplashPotion), (EntityType.LingeringPotion, Item.LingeringPotion),
                     (EntityType.ExperienceBottle, Item.ExperienceBottle)]) {
            Register(type, context => new ThrownItemRenderer(context, EntityDataFields.ThrowableItemProjectile.ItemStack, item,
                shouldRenderAtSqrDistance: ThrownItemRenderer.HiddenWhileCloseThenHurtingProjectile));
        }
        Register(EntityType.EyeOfEnder, context => new ThrownItemRenderer(context, EntityDataFields.EyeOfEnder.ItemStack, Item.EnderEye, 1.0F, true,
            ThrownItemRenderer.HiddenWhileCloseThenHurtingProjectile));
        Register(EntityType.Fireball, context => new ThrownItemRenderer(context, EntityDataFields.Fireball.ItemStack, Item.FireCharge, 3.0F, true,
            ThrownItemRenderer.HiddenWhileCloseThenHurtingProjectile));
        Register(EntityType.SmallFireball, context => new ThrownItemRenderer(context, EntityDataFields.Fireball.ItemStack, Item.FireCharge, 0.75F, true,
            ThrownItemRenderer.HiddenWhileCloseThenHurtingProjectile));
        Register(EntityType.DragonFireball, _ => new DragonFireballRenderer());
        Register(EntityType.WitherSkull, _ => new WitherSkullRenderer());
        Register(EntityType.ShulkerBullet, _ => new ShulkerBulletRenderer());
        Register(EntityType.LlamaSpit, _ => new LlamaSpitRenderer());
        Register(EntityType.WindCharge, _ => new WindChargeRenderer(true));
        Register(EntityType.BreezeWindCharge, _ => new WindChargeRenderer(false));
        Register(EntityType.FireworkRocket, context => new FireworkEntityRenderer(context));
        Register(EntityType.FishingBobber, _ => new FishingHookRenderer());
    }
}

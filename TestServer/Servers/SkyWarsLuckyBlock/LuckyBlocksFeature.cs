using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Implementations.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using TestServer.Servers.SkyWarsLuckyBlock.BlockResults;
using TestServer.Servers.SkyWarsLuckyBlock.Items;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class LuckyBlocksFeature : ScopedFeature {
    private static readonly Tag<LuckyBlockType> LuckyBlockItemTag = new("lucky_block_item");
    
    private static readonly (int weight, IBlockResult result)[] LuckyBlocks = [
        (10, new ItemBlockResult(typeof(KnockbackStickItem))),
        (3, new ItemBlockResult(typeof(MagicToyStickItem))),
        (10, new FullHealBlockResult()),
        (10, new ItemBlockResult(typeof(TeleportOrbItem))),
        (10, new ItemBlockResult(new ItemStack(Item.Potato))),
        (10, new BuildUpBlockResult()),
        (10, new ItemBlockResult(typeof(InstaboomTntItem))),
        (10, new ItemBlockResult(new ItemStack(Item.DiamondSword)
            .WithTag(SkyWarsCombatFeature.SelfAttackingTag, true)
            .WithTag(SkyWarsCombatFeature.DamageTag, 10f)
            .With(DataComponent.ItemName, "Self Attacking Sword")
            .With(DataComponent.Lore,
                [TextComponent.FromLegacyString("&7You didn't think we'd let you win that easily, did you?")]))),
        (5, new ItemBlockResult(new ItemStack(Item.LeatherHelmet)
            .WithTag(AttributeModifiersFeature.AttributeModifiersTag, [
                new AttributeModifiersFeature.Modifier(Attribute.Scale.Identifier, -0.5, "skywars:shrink_helmet", AttributeOperation.AddMultipliedTotal)
            ])
            .With(DataComponent.ItemName, TextComponent.FromLegacyString("&bShrink Helmet"))
            .With(DataComponent.EnchantmentGlintOverride, true)
            .With(DataComponent.DyedColor, TextColor.Hex("#21ed57")))),
        (10, new ItemBlockResult(typeof(OneUpItem))),
        (5, new JacobBlockResult()),
        (1, new NukeBlockResult()),
        (10, new ItemBlockResult(new ItemStack(Item.Shield).With(DataComponent.ItemName, "Cosmetic Shield")
            .With(DataComponent.Lore, [TextComponent.FromLegacyString("&7A shield that does nothing, but looks cool!")]))),
        (5, new ItemBlockResult(new ItemStack(Item.LeatherBoots).With(DataComponent.ItemName, "Boots of Jumping")
            .With(DataComponent.Lore, [
                TextComponent.FromLegacyString("&7These boots allow you to jump higher!"),
                TextComponent.FromLegacyString("&7However, they will not protect you.")
            ])
            .With(DataComponent.DyedColor, TextColor.Hex("#78ff00"))
            .With(DataComponent.EnchantmentGlintOverride, true)
            .WithTag(AttributeModifiersFeature.AttributeModifiersTag, [
                new AttributeModifiersFeature.Modifier(Attribute.JumpStrength.Identifier, 1, "skywars:jumping_boots", AttributeOperation.AddMultipliedTotal)
            ]))),
        (5, new ItemBlockResult(typeof(ExplosiveChestplateItem))),
        (500, new ItemBlockResult(new ItemStack(Item.Apple)
            .With(DataComponent.ItemName, "Newton's Apple")
            .With(DataComponent.Equippable, new EquippableComponent.Data(EquippableComponent.Slot.Head, 
                Or<ISoundType, SoundEvent>.FromValue2(new SoundEvent(SoundType.ArmorEquipDiamond, 1f)), 
                null, null, null, true, true, true, 
                true, false, Or<ISoundType, SoundEvent>.FromValue1(SoundType.AllayDeath)))
            // .With(DataComponent.AttributeModifiers, [
            //     new ItemAttributeModifier(Attribute.Gravity, "skywars:newtonsapple", -1.0, AttributeOperation.AddMultipliedTotal, AttributeActiveSlot.Body)
            // ])
            .WithTag(AttributeModifiersFeature.AttributeModifiersTag, [
                new AttributeModifiersFeature.Modifier(Attribute.Gravity.Identifier, -0.5, "skywars:newtons_apple", AttributeOperation.AddMultipliedTotal)
            ])
        )),
        (5, new ItemBlockResult(new ItemStack(Item.LeatherLeggings).With(DataComponent.Lore, [
            TextComponent.FromLegacyString("&7Thought you might need these.")
        ]).WithTag(SkyWarsCombatFeature.DamageReductionTag, 0.05f)))
    ];
    
    private enum LuckyBlockType {
        Normal,
        Super,
        Ultra
    }
    
    private record LuckyBlock(LuckyBlockType Type, Entity? PlacedEntity);
    
    private readonly Dictionary<Vec3<int>, LuckyBlock> _placedBlocks = [];

    public static ItemStack GetLuckyBlock(int count = 1) {
        return new ItemStack(Item.YellowStainedGlass, count)
            .WithTag(LuckyBlockItemTag, LuckyBlockType.Normal);
    }
    
    private static int TotalWeight => LuckyBlocks.Sum(x => x.weight);
    
    private static IBlockResult GetRandomResult() {
        int totalWeight = TotalWeight;
        int randomWeight = Random.Shared.Next(totalWeight);
        int currentWeight = 0;
        
        foreach ((int weight, IBlockResult result) in LuckyBlocks) {
            currentWeight += weight;
            if (randomWeight < currentWeight) {
                return result;
            }
        }
        
        // Fallback, should never happen
        throw new InvalidOperationException("No lucky block result found.");
    }
    
    public override void Register() {
        AddEventListener<PlayerPlaceBlockEvent>(e => {
            if (!e.UsedItem.HasTag(LuckyBlockItemTag)) {
                return;
            }
            
            LuckyBlockType block = e.UsedItem.GetTag(LuckyBlockItemTag);
            
            // Lucky block placed, let's do something
            e.Block = Block.YellowStainedGlass;

            Entity insideThing = new(EntityType.Bee) {
                Position = e.Position.BlockPosToDouble() - new Vec3<double>(0, 0.3, 0)
            };
            insideThing.Meta = insideThing.Meta with {
                NoGravity = true,
                Silent = true
            };
            e.World.Spawn(insideThing);
            
            _placedBlocks.TryAdd(e.Position, new LuckyBlock(block, insideThing));
        });
        
        AddEventListener<PlayerBreakBlockEvent>(e => {
            if (!_placedBlocks.Remove(e.Position, out LuckyBlock? block)) {
                return;
            }
            
            // Lucky block broken (by player), let's do something
            GetRandomResult().Trigger(e.World, e.Player, e.Position);
            block.PlacedEntity?.Despawn();
        });
        
        AddEventListener<WorldChangeEvent>(e => {
            if (e.NewState.Identifier == Block.YellowStainedGlass.Identifier) {
                return;
            }
            
            if (!_placedBlocks.Remove(e.Position, out LuckyBlock? block)) {
                return;
            }
            
            // Lucky block broken, let's do something
            IBlockResult blockResult = GetRandomResult();
            blockResult.Trigger(e.World, null, e.Position);
            block.PlacedEntity?.Despawn();
        });
    }
}

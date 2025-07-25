using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using TestServer.Servers.SkyWarsLuckyBlock.BlockResults;
using TestServer.Servers.SkyWarsLuckyBlock.Items;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class LuckyBlocksFeature : ScopedFeature {
    private static readonly Tag<LuckyBlockType> LuckyBlockItemTag = new("lucky_block_item");
    
    private static readonly IBlockResult[] LuckyBlocks = [
        new ItemBlockResult(typeof(KnockbackStickItem)),
        new ItemBlockResult(typeof(MagicToyStickItem)),
        new FullHealBlockResult(),
        new ItemBlockResult(typeof(TeleportOrbItem)),
        new ItemBlockResult(new ItemStack(1, Item.Potato)),
        new BuildUpBlockResult(),
        new ItemBlockResult(new ItemStack(1, Item.IronSword)
            .WithTag(SkyWarsCombatFeature.SelfAttackingTag, true)
            .WithTag(SkyWarsCombatFeature.DamageTag, 6f)
            .With(DataComponent.ItemName, "Self Attacking Sword")
            .With(DataComponent.Lore, [TextComponent.FromLegacyString("&7You didn't think we'd let you win that easily, did you?")])),
        new ItemBlockResult(typeof(OneUpItem)),
        new BobBlockResult(),
        new JacobBlockResult()
    ];
    
    private enum LuckyBlockType {
        Normal,
        Super,
        Ultra
    }
    
    private record LuckyBlock(LuckyBlockType Type, Entity? PlacedEntity);
    
    private readonly Dictionary<Vec3<int>, LuckyBlock> _placedBlocks = [];

    public static ItemStack GetLuckyBlock(int count = 1) {
        return new ItemStack(count, Item.YellowStainedGlass)
            .WithTag(LuckyBlockItemTag, LuckyBlockType.Normal);
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
            IBlockResult blockResult = LuckyBlocks[Random.Shared.Next(LuckyBlocks.Length)];
            blockResult.Trigger(e.World, e.Player, e.Position);
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
            IBlockResult blockResult = LuckyBlocks[Random.Shared.Next(LuckyBlocks.Length)];
            blockResult.Trigger(e.World, null, e.Position);
            block.PlacedEntity?.Despawn();
        });
    }
}

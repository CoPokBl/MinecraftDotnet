using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using ClientLib.World.BlockEntities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace ClientLib.Testing.Play;

/// <summary>
/// The client's block entities: made and dropped with their blocks as <c>LevelChunk.setBlockState</c>
/// does, driven by block events, and animated by their client tickers.
/// </summary>
public class BlockEntityTest {
    private static (MinecraftClient Client, ClientLevel Level, LocalPlayer Player) World() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld", VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -1; cx <= 1; cx++) {
            for (int cz = -1; cz <= 1; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    biomes[i] = new ushort[64];
                    sections[i] = new ClientSection(0, true);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, 100, 0.5);
        return (client, level, player);
    }

    private static void Set(MinecraftClient client, int x, int y, int z, IBlock state) =>
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(x, y, z), Block = state });

    private static void BlockEvent(MinecraftClient client, int x, int y, int z, IBlock block, int b0, int b1) =>
        client.Dispatch(new ClientBoundBlockActionPacket { Location = new Vec3<int>(x, y, z), Block = block, ActionId = (byte)b0, ActionParameter = (byte)b1 });

    [Test]
    public void ABlockEntityComesAndGoesWithItsBlock() {
        (MinecraftClient client, ClientLevel level, _) = World();
        Set(client, 2, 64, 3, Block.Chest);
        ClientBlockEntity? chest = level.GetBlockEntity(2, 64, 3);
        Assert.That(chest, Is.InstanceOf<ChestBlockEntity>());

        // Another state of the same block keeps it, and it sees the new state.
        Set(client, 2, 64, 3, Block.Chest with { Facing = Direction.East });
        Assert.That(level.GetBlockEntity(2, 64, 3), Is.SameAs(chest));
        Assert.That(((ChestBlock)chest!.State).Facing, Is.EqualTo(Direction.East));

        Set(client, 2, 64, 3, Block.Stone);
        Assert.That(chest.Removed, Is.True);
        Assert.That(level.GetBlockEntity(2, 64, 3), Is.Null);
    }

    [Test]
    public void AWeatheringCopperChestKeepsItsBlockEntity() {
        (MinecraftClient client, ClientLevel level, _) = World();
        Set(client, 0, 64, 0, Block.CopperChest);
        ClientBlockEntity? chest = level.GetBlockEntity(0, 64, 0);
        Set(client, 0, 64, 0, Block.ExposedCopperChest);
        Assert.That(level.GetBlockEntity(0, 64, 0), Is.SameAs(chest));
        Assert.That(chest!.Removed, Is.False);
    }

    [Test]
    public void TheOpenCountEventSwingsTheLidATenthATick() {
        (MinecraftClient client, ClientLevel level, _) = World();
        Set(client, 0, 64, 0, Block.Chest);
        ChestBlockEntity chest = (ChestBlockEntity)level.GetBlockEntity(0, 64, 0)!;
        BlockEvent(client, 0, 64, 0, Block.Chest, 1, 1);
        client.Tick();
        client.Tick();
        Assert.That(chest.GetOpenNess(1.0F), Is.EqualTo(0.2F).Within(1e-6F));
        Assert.That(chest.GetOpenNess(0.5F), Is.EqualTo(0.15F).Within(1e-6F));
        for (int i = 0; i < 20; i++) {
            client.Tick();
        }
        Assert.That(chest.GetOpenNess(1.0F), Is.EqualTo(1.0F));
        BlockEvent(client, 0, 64, 0, Block.Chest, 1, 0);
        client.Tick();
        Assert.That(chest.GetOpenNess(1.0F), Is.EqualTo(0.9F).Within(1e-6F));
    }

    /// <summary>A double chest opens as its wider half, so the half nobody opened swings with it.</summary>
    [Test]
    public void ADoubleChestOpensAsOne() {
        (MinecraftClient client, ClientLevel level, _) = World();
        // Facing north, the left half joins the chest to its east.
        Set(client, 0, 64, 0, Block.Chest with { Type = ChestType.Left });
        Set(client, 1, 64, 0, Block.Chest with { Type = ChestType.Right });
        ChestBlockEntity left = (ChestBlockEntity)level.GetBlockEntity(0, 64, 0)!;
        ChestBlockEntity right = (ChestBlockEntity)level.GetBlockEntity(1, 64, 0)!;
        Assert.That(left.Neighbour(level), Is.SameAs(right));
        Assert.That(right.Neighbour(level), Is.SameAs(left));
        BlockEvent(client, 1, 64, 0, Block.Chest, 1, 1);
        client.Tick();
        Assert.That(left.GetOpenNess(1.0F), Is.Zero);
        Assert.That(left.CombinedOpenness(level, 1.0F), Is.EqualTo(0.1F).Within(1e-6F));

        Set(client, 1, 64, 0, Block.Chest with { Facing = Direction.South, Type = ChestType.Right });
        Assert.That(left.Neighbour(level), Is.Null);
    }

    [Test]
    public void TheEnchantingTableBookOpensForANearbyPlayerOnly() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player) = World();
        Set(client, 0, 64, 0, Block.EnchantingTable);
        EnchantingTableBlockEntity table = (EnchantingTableBlockEntity)level.GetBlockEntity(0, 64, 0)!;
        player.Position = new Vec3d(10.5, 64, 0.5);
        client.Tick();
        Assert.That(table.Open, Is.Zero);
        Assert.That(table.TRot, Is.EqualTo(0.02F).Within(1e-6F));

        Set(client, 2, 63, 0, Block.Stone);
        player.Position = new Vec3d(2.5, 64, 0.5);
        for (int i = 0; i < 12; i++) {
            client.Tick();
        }
        Assert.That(table.Open, Is.EqualTo(1.0F));
        // atan2(0, 2): the player is due east of the table.
        Assert.That(table.TRot, Is.EqualTo(0.0F).Within(1e-3F));
        Assert.That(table.Time, Is.EqualTo(13));
    }

    [Test]
    public void TheBellSwingsForFiftyTicks() {
        (MinecraftClient client, ClientLevel level, _) = World();
        Set(client, 0, 64, 0, Block.Bell);
        BlockEvent(client, 0, 64, 0, Block.Bell, 1, (int)Cardinal.East);
        BellBlockEntity bell = (BellBlockEntity)level.GetBlockEntity(0, 64, 0)!;
        Assert.That(bell.Shaking, Is.True);
        Assert.That(bell.ClickDirection, Is.EqualTo(Cardinal.East));
        for (int i = 0; i < 49; i++) {
            client.Tick();
        }
        Assert.That(bell.Shaking, Is.True);
        client.Tick();
        Assert.That(bell.Shaking, Is.False);
        Assert.That(bell.Ticks, Is.Zero);
    }

    [Test]
    public void TheShulkerBoxLidRisesOverTenTicks() {
        (MinecraftClient client, ClientLevel level, _) = World();
        Set(client, 0, 64, 0, Block.RedShulkerBox);
        ShulkerBoxBlockEntity box = (ShulkerBoxBlockEntity)level.GetBlockEntity(0, 64, 0)!;
        Assert.That(box.Color, Is.EqualTo(DyeColor.Red));
        BlockEvent(client, 0, 64, 0, Block.RedShulkerBox, 1, 1);
        for (int i = 0; i < 10; i++) {
            client.Tick();
        }
        Assert.That(box.Status, Is.EqualTo(ShulkerBoxBlockEntity.AnimationStatus.Opened));
        Assert.That(box.GetProgress(1.0F), Is.EqualTo(1.0F));
    }

    [Test]
    public void SignTextIsReadFromTheUpdateTag() {
        (MinecraftClient client, ClientLevel level, _) = World();
        Set(client, 0, 64, 0, Block.OakSign);
        // A list mixing strings and compounds arrives with each string wrapped, as NbtOps writes it.
        static INbtTag Wrapped(string text) => new CompoundTag(("", new StringTag(text)));
        CompoundTag front = new(("messages", new ListTag(new INbtTag[] {
            Wrapped("one"), new CompoundTag(("text", new StringTag("two")), ("color", new StringTag("red"))), Wrapped(""), Wrapped("")
        })), ("color", new StringTag("light_blue")), ("has_glowing_text", new ByteTag(1)));
        client.Dispatch(new ClientBoundBlockEntityDataPacket {
            Position = new Vec3<int>(0, 64, 0), Type = BlockEntityType.Sign, Data = new CompoundTag(("front_text", front))
        });
        SignBlockEntity sign = (SignBlockEntity)level.GetBlockEntity(0, 64, 0)!;
        Assert.That(sign.FrontText.Color, Is.EqualTo(DyeColor.LightBlue));
        Assert.That(sign.FrontText.HasGlowingText, Is.True);
        Assert.That(TextFlattener.Plain(sign.FrontText.Messages[1]), Is.EqualTo("two"));
        Assert.That(sign.BackText, Is.SameAs(SignText.Empty));
        Assert.That(sign.MaxTextLineWidth, Is.EqualTo(90));

        // Data for another type is not loaded, as getBlockEntity(pos, type) finds nothing.
        client.Dispatch(new ClientBoundBlockEntityDataPacket {
            Position = new Vec3<int>(0, 64, 0), Type = BlockEntityType.Banner, Data = new CompoundTag()
        });
        Assert.That(sign.FrontText.HasGlowingText, Is.True);
    }

    [Test]
    public void ARemovedChunkTakesItsBlockEntitiesWithIt() {
        (MinecraftClient client, ClientLevel level, _) = World();
        Set(client, 0, 64, 0, Block.Chest);
        ClientBlockEntity chest = level.GetBlockEntity(0, 64, 0)!;
        level.RemoveChunk(0, 0);
        Assert.That(chest.Removed, Is.True);
    }

    [Test]
    public void ThePotWobblesFromTheGameTimeOfTheEvent() {
        (MinecraftClient client, ClientLevel level, _) = World();
        Set(client, 0, 64, 0, Block.DecoratedPot);
        level.GameTime = 1234;
        BlockEvent(client, 0, 64, 0, Block.DecoratedPot, 1, 1);
        DecoratedPotBlockEntity pot = (DecoratedPotBlockEntity)level.GetBlockEntity(0, 64, 0)!;
        Assert.That(pot.LastWobbleStyle, Is.EqualTo(DecoratedPotBlockEntity.WobbleStyle.Negative));
        Assert.That(pot.WobbleStartedAtTick, Is.EqualTo(1234));
    }

    /// <summary>A piston's block event moves the blocks on the client, through moving pistons that finish by themselves.</summary>
    [Test]
    public void APistonMovesTheBlockInFrontOfIt() {
        (MinecraftClient client, ClientLevel level, _) = World();
        Set(client, 0, 64, 0, Block.Piston with { Facing = Cardinal.East });
        Set(client, 1, 64, 0, Block.Stone);
        BlockEvent(client, 0, 64, 0, Block.Piston, 0, (int)Cardinal.East);
        Assert.That(level.GetBlock(0, 64, 0), Is.EqualTo(Block.Piston with { Facing = Cardinal.East, Extended = true }));
        PistonMovingBlockEntity head = (PistonMovingBlockEntity)level.GetBlockEntity(1, 64, 0)!;
        PistonMovingBlockEntity stone = (PistonMovingBlockEntity)level.GetBlockEntity(2, 64, 0)!;
        Assert.That(head.IsSourcePiston, Is.True);
        Assert.That(stone.MovedState, Is.EqualTo(Block.Stone));
        Assert.That(stone.GetOffset(0.0F).X, Is.EqualTo(-1.0F));
        client.Tick();
        Assert.That(stone.GetOffset(1.0F).X, Is.EqualTo(-0.5F));
        for (int i = 0; i < 10; i++) {
            client.Tick();
        }
        Assert.That(level.GetBlock(2, 64, 0), Is.EqualTo(Block.Stone));
        Assert.That(level.GetBlock(1, 64, 0), Is.EqualTo(Block.PistonHead with { Facing = Cardinal.East }));
        Assert.That(stone.Removed, Is.True);
    }

    [Test]
    public void ObsidianStopsAPiston() {
        (MinecraftClient client, ClientLevel level, _) = World();
        Set(client, 0, 64, 0, Block.Piston with { Facing = Cardinal.Up });
        Set(client, 0, 65, 0, Block.Obsidian);
        BlockEvent(client, 0, 64, 0, Block.Piston, 0, (int)Cardinal.Up);
        Assert.That(level.GetBlock(0, 64, 0), Is.EqualTo(Block.Piston with { Facing = Cardinal.Up }));
        Assert.That(level.GetBlockEntity(0, 65, 0), Is.Null);
    }
}

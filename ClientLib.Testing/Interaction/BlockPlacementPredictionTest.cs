using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Interaction;

/// <summary>
/// <c>BlockItem.useOn</c> run inside <c>useItemOn</c>'s prediction: the block goes into the level under the
/// packet's sequence in vanilla's state, the stack shrinks, and the acknowledgement settles it on the
/// server's word.
/// </summary>
public class BlockPlacementPredictionTest {
    private const int Floor = 15;

    private static (MinecraftClient Client, ClientLevel Level, LocalPlayer Player, List<MinecraftPacket> Sent) World(ItemStack held, Vec3d position) {
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
        for (int x = -3; x <= 3; x++) {
            for (int z = -3; z <= 3; z++) {
                level.SetState(x, Floor, z, (ushort)Block.Stone.StateId);
            }
        }
        LocalPlayer player = client.StartOffline(level);
        player.Position = position;
        client.Inventory.SetInventorySlot(0, held);
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;
        return (client, level, player, sent);
    }

    /// <summary>Turns the player so the crosshair goes through the point.</summary>
    private static void Aim(LocalPlayer player, Vec3d target) {
        Vec3d eye = Picking.EyePosition(player, 1.0F);
        double dx = target.X - eye.X, dy = target.Y - eye.Y, dz = target.Z - eye.Z;
        player.YRot = (float)(Math.Atan2(dz, dx) * 180.0 / Math.PI) - 90.0F;
        player.XRot = (float)(-Math.Atan2(dy, Math.Sqrt(dx * dx + dz * dz)) * 180.0 / Math.PI);
        player.YRotO = player.YRot;
        player.XRotO = player.XRot;
    }

    private static void Use(MinecraftClient client) {
        client.Interactions.Keys.Use.Press();
        client.Interactions.Keys.Use.SetDown(false);
        client.Interactions.Tick();
    }

    private static IBlock At(ClientLevel level, int x, int y, int z) => level.GetBlock(x, y, z);

    [Test]
    public void APlacedBlockIsPredictedUnderThePacketsSequence() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, List<MinecraftPacket> sent) = World(new ItemStack(Item.Stone, 5), new Vec3d(0.5, 16, 0.5));
        Aim(player, new Vec3d(2.5, 16, 0.5));
        Use(client);

        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.Stone));
        ServerBoundUseItemOnPacket use = sent.OfType<ServerBoundUseItemOnPacket>().Single();
        Assert.That(use.Position, Is.EqualTo(new Vec3<int>(2, 15, 0)));
        Assert.That(use.Face, Is.EqualTo(BlockFace.PosY));
        Assert.That(use.Sequence, Is.EqualTo(client.Interactions.Predictions.Sequence));
        // A placement swings and sends no use_item after it.
        Assert.That(sent.OfType<ServerBoundSwingArmPacket>().Count(), Is.EqualTo(1));
        Assert.That(sent.OfType<ServerBoundUseItemPacket>(), Is.Empty);

        // The server agrees: its update is held until the acknowledgement, which then changes nothing.
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(2, 16, 0), Block = Block.Stone });
        client.Dispatch(new ClientBoundAcknowledgeBlockChangePacket { SequenceId = use.Sequence });
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.Stone));
    }

    [Test]
    public void AServerCorrectionRollsThePredictionBack() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, List<MinecraftPacket> sent) = World(new ItemStack(Item.Stone, 5), new Vec3d(0.5, 16, 0.5));
        Aim(player, new Vec3d(2.5, 16, 0.5));
        Use(client);
        int sequence = sent.OfType<ServerBoundUseItemOnPacket>().Single().Sequence;

        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(2, 16, 0), Block = Block.Air });
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.Stone), "held back until the acknowledgement");
        client.Dispatch(new ClientBoundAcknowledgeBlockChangePacket { SequenceId = sequence });
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.Air));
    }

    [Test]
    public void AnUnansweredPredictionFallsBackToWhatTheServerLastSaid() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, List<MinecraftPacket> sent) = World(new ItemStack(Item.Stone, 5), new Vec3d(0.5, 16, 0.5));
        Aim(player, new Vec3d(2.5, 16, 0.5));
        Use(client);
        client.Dispatch(new ClientBoundAcknowledgeBlockChangePacket { SequenceId = sent.OfType<ServerBoundUseItemOnPacket>().Single().Sequence });
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.Air));
    }

    [Test]
    public void TheStackShrinksInSurvival() {
        (MinecraftClient client, _, LocalPlayer player, _) = World(new ItemStack(Item.Stone, 5), new Vec3d(0.5, 16, 0.5));
        Aim(player, new Vec3d(2.5, 16, 0.5));
        Use(client);
        Assert.That(client.Inventory.MainHand.Count, Is.EqualTo(4));
    }

    [Test]
    public void TheLastBlockEmptiesTheHand() {
        (MinecraftClient client, _, LocalPlayer player, _) = World(new ItemStack(Item.Stone, 1), new Vec3d(0.5, 16, 0.5));
        Aim(player, new Vec3d(2.5, 16, 0.5));
        Use(client);
        Assert.That(ItemComponents.IsEmpty(client.Inventory.MainHand), Is.True);
    }

    [Test]
    public void TheStackDoesNotShrinkInCreative() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World(new ItemStack(Item.Stone, 5), new Vec3d(0.5, 16, 0.5));
        player.GameMode = GameMode.Creative;
        player.InstaBuild = true;
        Aim(player, new Vec3d(2.5, 16, 0.5));
        Use(client);
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.Stone));
        Assert.That(client.Inventory.MainHand.Count, Is.EqualTo(5));
    }

    /// <summary>Straight down, the block would go where the player stands: <c>isUnobstructed</c> fails it, and a fail tries nothing else.</summary>
    [Test]
    public void APlacementInsideThePlayerIsRefused() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, List<MinecraftPacket> sent) = World(new ItemStack(Item.Stone, 5), new Vec3d(0.5, 16, 0.5));
        player.XRot = 90.0F;
        player.XRotO = 90.0F;
        Use(client);

        Assert.That(At(level, 0, 16, 0), Is.EqualTo(Block.Air));
        Assert.That(client.Inventory.MainHand.Count, Is.EqualTo(5));
        Assert.That(sent.OfType<ServerBoundUseItemOnPacket>().Count(), Is.EqualTo(1));
        Assert.That(sent.OfType<ServerBoundUseItemPacket>(), Is.Empty);
        Assert.That(sent.OfType<ServerBoundSwingArmPacket>(), Is.Empty);
    }

    /// <summary>Under <c>CollisionContext.placementContext</c> scaffolding has no shape, so it goes where the player stands.</summary>
    [Test]
    public void ScaffoldingIsPlacedInsideThePlayer() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World(new ItemStack(Item.Scaffolding, 5), new Vec3d(0.5, 16, 0.5));
        player.XRot = 90.0F;
        player.XRotO = 90.0F;
        Use(client);
        Assert.That(At(level, 0, 16, 0), Is.EqualTo(Block.Scaffolding with { Distance = 0, Bottom = false }));
    }

    /// <summary>
    /// Sneak bridging backwards: the new block goes under the player's overhanging feet, which only
    /// touch its top face, so it is not obstructed.
    /// </summary>
    [Test]
    public void ABlockUnderOverhangingFeetIsPlaced() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World(new ItemStack(Item.Stone, 5), new Vec3d(4.25, 16, 0.5));
        Aim(player, new Vec3d(4.0, 15.6, 0.5));
        client.Interactions.Pick(1.0F);
        Assert.That(client.Interactions.Target, Is.InstanceOf<BlockHitResult>().With.Property("X").EqualTo(3).And.Property("Face").EqualTo(BlockFace.PosX));
        Use(client);
        Assert.That(At(level, 4, 15, 0), Is.EqualTo(Block.Stone));
    }

    [Test]
    public void AStairFacesThePlayerAndSitsOnTheClickedHalf() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World(new ItemStack(Item.OakStairs, 5), new Vec3d(0.5, 16, 0.5));
        Aim(player, new Vec3d(2.5, 16, 0.5));
        Use(client);
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.OakStairs with { Facing = Direction.East, Half = TopBottom.Bottom, Shape = StairShape.Straight }));
    }

    [Test]
    public void ASlabClickedOnTopBecomesDouble() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World(new ItemStack(Item.OakSlab, 5), new Vec3d(0.5, 16, 0.5));
        Aim(player, new Vec3d(2.5, 16, 0.5));
        Use(client);
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.OakSlab with { Type = SlabType.Bottom }));

        Aim(player, new Vec3d(2.5, 16.5, 0.5));
        Use(client);
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.OakSlab with { Type = SlabType.Double }));
        Assert.That(At(level, 2, 17, 0), Is.EqualTo(Block.Air));
    }

    [Test]
    public void ALogLiesAlongTheClickedFace() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World(new ItemStack(Item.OakLog, 5), new Vec3d(0.5, 16, 0.5));
        level.SetState(3, 16, 0, (ushort)Block.Stone.StateId);
        level.SetState(3, 17, 0, (ushort)Block.Stone.StateId);
        Aim(player, new Vec3d(3.0, 17.5, 0.5));
        Use(client);
        Assert.That(At(level, 2, 17, 0), Is.EqualTo(Block.OakLog with { Axis = Axis.X }));
    }

    /// <summary><c>StandingAndWallBlockItem</c>: a torch aimed at a wall becomes the wall torch, facing out of it.</summary>
    [Test]
    public void ATorchAimedAtAWallIsAWallTorch() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World(new ItemStack(Item.Torch, 5), new Vec3d(0.5, 16, 0.5));
        level.SetState(3, 16, 0, (ushort)Block.Stone.StateId);
        level.SetState(3, 17, 0, (ushort)Block.Stone.StateId);
        Aim(player, new Vec3d(3.0, 17.5, 0.5));
        Use(client);
        Assert.That(At(level, 2, 17, 0), Is.EqualTo(Block.WallTorch with { Facing = Direction.West }));
    }

    [Test]
    public void ATorchOnTheFloorStands() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World(new ItemStack(Item.Torch, 5), new Vec3d(0.5, 16, 0.5));
        Aim(player, new Vec3d(2.5, 16, 0.5));
        Use(client);
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.Torch));
    }

    /// <summary>Both halves are predicted: the upper by <c>DoorBlock.setPlacedBy</c>, which runs on the client too.</summary>
    [Test]
    public void ADoorPlacesBothHalves() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World(new ItemStack(Item.OakDoor, 5), new Vec3d(0.5, 16, 0.3));
        Aim(player, new Vec3d(2.5, 16, 0.3));
        Use(client);
        OakDoorBlock lower = Block.OakDoor with { Facing = Direction.East, Hinge = LeftRight.Left, Half = BlockHalf.Lower };
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(lower));
        Assert.That(At(level, 2, 17, 0), Is.EqualTo(lower with { Half = BlockHalf.Upper }));
        Assert.That(client.Inventory.MainHand.Count, Is.EqualTo(4));
    }

    /// <summary>A fence placed beside another connects it in the same prediction, through the client's shape cascade.</summary>
    [Test]
    public void TheShapeCascadeRunsOnTheClient() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World(new ItemStack(Item.OakFence, 5), new Vec3d(0.5, 16, 0.5));
        level.SetState(2, 16, 1, (ushort)Block.OakFence.StateId);
        Aim(player, new Vec3d(2.5, 16, 0.5));
        Use(client);
        Assert.That(At(level, 2, 16, 0), Is.EqualTo(Block.OakFence with { South = true }));
        Assert.That(At(level, 2, 16, 1), Is.EqualTo(Block.OakFence with { North = true }));
    }
}

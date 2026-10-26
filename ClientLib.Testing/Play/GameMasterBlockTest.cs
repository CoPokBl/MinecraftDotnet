using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using ClientLib.World.BlockEntities;
using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using NBT.Tags;
using CommandBlockMode = Minecraft.Packets.Play.ServerBound.ServerBoundProgramCommandBlockPacket.CommandBlockMode;
using JigsawJointType = Minecraft.Packets.Play.ServerBound.ServerBoundProgramJigsawBlockPacket.JigsawJointType;
using TestBlockMode = Minecraft.Packets.Play.ServerBound.ServerBoundSetTestBlockPacket.TestBlockMode;
using EntityEvent = Minecraft.Packets.Play.ClientBound.ClientBoundEntityEventPacket.EntityEventType;

namespace ClientLib.Testing.Play;

/// <summary>
/// Game master blocks on the client: the data their editors show, such as what
/// <c>ServerPlayer.openCommandBlock</c> answers a use with, the <c>canUseGameMasterBlocks</c> gate on
/// opening an editor, and the packets the editors send.
/// </summary>
public class GameMasterBlockTest {
    private const int PlayerId = 1;

    private static (MinecraftClient Client, ClientLevel Level, LocalPlayer Player, List<MinecraftPacket> Sent) World() {
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
        LocalPlayer player = client.StartOffline(level, PlayerId);
        player.Position = new Vec3d(0.5, 16, 0.5);
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;
        return (client, level, player, sent);
    }

    private static void Set(MinecraftClient client, int x, int y, int z, IBlock state) =>
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(x, y, z), Block = state });

    /// <summary><c>saveCustomOnly</c> of a command block that last ran <c>say hi</c>.</summary>
    private static CompoundTag OpenedTag(bool trackOutput, bool auto) => new(
        ("Command", new StringTag("say hi")),
        ("SuccessCount", new IntegerTag(1)),
        ("TrackOutput", Byte(trackOutput)),
        ("LastOutput", new StringTag("[12:00:00] hi")),
        ("UpdateLastExecution", Byte(true)),
        ("powered", Byte(false)),
        ("conditionMet", Byte(true)),
        ("auto", Byte(auto)));

    private static ByteTag Byte(bool value) => new(value ? (sbyte)1 : (sbyte)0);

    private static void SendData(MinecraftClient client, int x, int y, int z, CompoundTag tag) =>
        client.Dispatch(new ClientBoundBlockEntityDataPacket { Position = new Vec3<int>(x, y, z), Type = BlockEntityType.CommandBlock, Data = tag });

    [Test]
    public void TheDataSentOnOpeningFillsTheBlockEntity() {
        (MinecraftClient client, ClientLevel level, _, _) = World();
        Set(client, 2, 15, 0, Block.CommandBlock with { Conditional = true });
        CommandBlockEntity commandBlock = (CommandBlockEntity)level.GetBlockEntity(2, 15, 0)!;
        Assert.That(commandBlock.CommandBlock.Command, Is.Empty, "the update tag is empty");
        List<ClientBlockEntity> loaded = [];
        client.BlockEntityDataLoaded += loaded.Add;

        SendData(client, 2, 15, 0, OpenedTag(true, true));
        Assert.That(loaded, Is.EqualTo(new[] { commandBlock }));
        Assert.That(commandBlock.CommandBlock.Command, Is.EqualTo("say hi"));
        Assert.That(commandBlock.CommandBlock.SuccessCount, Is.EqualTo(1));
        Assert.That(commandBlock.CommandBlock.TrackOutput, Is.True);
        Assert.That(TextFlattener.Plain(commandBlock.CommandBlock.LastOutput), Is.EqualTo("[12:00:00] hi"));
        Assert.That(commandBlock.Automatic, Is.True);
        Assert.That(commandBlock.ConditionMet, Is.True);
        Assert.That(commandBlock.Mode, Is.EqualTo(CommandBlockMode.Redstone));
        Assert.That(commandBlock.IsConditional, Is.True);
    }

    /// <summary><c>BaseCommandBlock.load</c> drops the output of a block that does not track it.</summary>
    [Test]
    public void AnUntrackedOutputIsNotKept() {
        (MinecraftClient client, ClientLevel level, _, _) = World();
        Set(client, 2, 15, 0, Block.CommandBlock);
        SendData(client, 2, 15, 0, OpenedTag(false, false));
        BaseCommandBlock commandBlock = ((CommandBlockEntity)level.GetBlockEntity(2, 15, 0)!).CommandBlock;
        Assert.That(commandBlock.TrackOutput, Is.False);
        Assert.That(TextFlattener.Plain(commandBlock.LastOutput), Is.Empty);
    }

    [Test]
    public void TheModeAndConditionComeFromTheBlock() {
        (MinecraftClient client, ClientLevel level, _, _) = World();
        Set(client, 2, 15, 0, Block.ChainCommandBlock);
        Set(client, 3, 15, 0, Block.RepeatingCommandBlock with { Conditional = true });
        CommandBlockEntity chain = (CommandBlockEntity)level.GetBlockEntity(2, 15, 0)!;
        CommandBlockEntity repeating = (CommandBlockEntity)level.GetBlockEntity(3, 15, 0)!;
        Assert.That(chain.Mode, Is.EqualTo(CommandBlockMode.Sequence));
        Assert.That(chain.IsConditional, Is.False);
        Assert.That(repeating.Mode, Is.EqualTo(CommandBlockMode.Auto));
        Assert.That(repeating.IsConditional, Is.True);

        Set(client, 3, 15, 0, Block.RepeatingCommandBlock with { Conditional = false });
        Assert.That(repeating.IsConditional, Is.False);
    }

    private static List<ClientBlockEntity> UseCommandBlock(MinecraftClient client, LocalPlayer player, bool creative, EntityEvent permission) {
        Set(client, 2, 15, 0, Block.CommandBlock);
        player.InstaBuild = creative;
        client.Dispatch(new ClientBoundEntityEventPacket { EntityId = PlayerId, Status = permission });
        // Straight at the block's west face from level with it.
        player.YRot = -90.0F;
        player.XRot = (float)(-Math.Atan2(15.5 - Picking.EyePosition(player, 1.0F).Y, 2.0) * 180.0 / Math.PI);
        player.YRotO = player.YRot;
        player.XRotO = player.XRot;
        List<ClientBlockEntity> opened = [];
        client.Interactions.GameMasterBlockOpened += opened.Add;
        client.Interactions.Keys.Use.Press();
        client.Interactions.Keys.Use.SetDown(false);
        client.Interactions.Tick();
        return opened;
    }

    [Test]
    public void AnOperatorInCreativeOpensTheEditor() {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, List<MinecraftPacket> sent) = World();
        List<ClientBlockEntity> opened = UseCommandBlock(client, player, true, EntityEvent.PlayerPermissionLevel2);
        Assert.That(opened, Is.EqualTo(new[] { level.GetBlockEntity(2, 15, 0) }));
        Assert.That(sent.OfType<ServerBoundUseItemOnPacket>().Single().Position, Is.EqualTo(new Vec3<int>(2, 15, 0)));
        Assert.That(player.IsSwinging, Is.True);
    }

    [Test]
    public void BelowTheGameMasterLevelTheUsePasses() {
        (MinecraftClient client, _, LocalPlayer player, List<MinecraftPacket> sent) = World();
        List<ClientBlockEntity> opened = UseCommandBlock(client, player, true, EntityEvent.PlayerPermissionLevel1);
        Assert.That(opened, Is.Empty);
        // A pass goes on to the off hand, so each hand sends a use_item_on, and neither swings.
        Assert.That(sent.OfType<ServerBoundUseItemOnPacket>().Select(use => use.ActiveHand), Is.EqualTo(new[] { Hand.MainHand, Hand.OffHand }));
        Assert.That(player.IsSwinging, Is.False);
    }

    [Test]
    public void OutsideCreativeAnOperatorCannotOpenIt() {
        (MinecraftClient client, _, LocalPlayer player, _) = World();
        Assert.That(UseCommandBlock(client, player, false, EntityEvent.PlayerPermissionLevel4), Is.Empty);
    }

    /// <summary><c>MultiPlayerGameMode.destroyBlock</c> predicts the break only for someone allowed to make it.</summary>
    [TestCase(EntityEvent.PlayerPermissionLevel2, true)]
    [TestCase(EntityEvent.PlayerPermissionLevel1, false)]
    public void BreakingACommandBlockIsPredictedForAGameMaster(EntityEvent permission, bool predicted) {
        (MinecraftClient client, ClientLevel level, LocalPlayer player, _) = World();
        player.GameMode = GameMode.Creative;
        UseCommandBlock(client, player, true, permission);
        client.Interactions.Keys.Attack.Press();
        client.Interactions.Tick();
        Assert.That(level.GetBlock(2, 15, 0), Is.EqualTo(predicted ? Block.Air : Block.CommandBlock));
    }

    [Test]
    public void DoneSendsTheEditsWithTheBlocksTrackOutput() {
        (MinecraftClient client, ClientLevel level, _, _) = World();
        Set(client, -5, 15, 7, Block.CommandBlock);
        CommandBlockEntity commandBlock = (CommandBlockEntity)level.GetBlockEntity(-5, 15, 7)!;
        SendData(client, -5, 15, 7, OpenedTag(true, false));
        commandBlock.CommandBlock.TrackOutput = false;

        ServerBoundProgramCommandBlockPacket packet = commandBlock.SetCommandPacket("say bye", CommandBlockMode.Auto, false, true);
        Assert.That(packet.Location, Is.EqualTo(new Vec3<int>(-5, 15, 7)));
        Assert.That(packet.Command, Is.EqualTo("say bye"));
        Assert.That(packet.Mode, Is.EqualTo(CommandBlockMode.Auto));
        Assert.That(packet.TrackOutput, Is.False);
        Assert.That(packet.Conditional, Is.False);
        Assert.That(packet.Automatic, Is.True);

        // ServerboundSetCommandBlockPacket.write: position, command, mode ordinal, then the flags byte.
        byte[] body = Body(packet);
        Assert.That(body[^2..], Is.EqualTo(new byte[] { 1, 4 }));
        Assert.That(System.Text.Encoding.UTF8.GetString(body, body.Length - 2 - 7, 7), Is.EqualTo("say bye"));
    }

    /// <summary>The packet's fields after its id, uncompressed.</summary>
    private static byte[] Body(MinecraftPacket packet) {
        byte[] framed = packet.Serialise(ConnectionState.Play);
        DataReader reader = new(framed);
        reader.ReadVarInt();
        reader.ReadVarInt();
        return reader.ReadRemaining();
    }

    [Test]
    public void AMinecartTakesItsCommandFromSyncedData() {
        (MinecraftClient client, _, _, _) = World();
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = 20,
            Uuid = Guid.NewGuid(),
            EntityType = EntityType.CommandBlockMinecart,
            Position = new Vec3<double>(2.5, 16, 0.5),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(0, 0, 0)
        });
        ClientMinecartCommandBlock minecart = (ClientMinecartCommandBlock)client.Entities[20];
        EntityMetaContainer meta = new();
        meta.Fields[EntityDataFields.MinecartCommandBlock.IdCommandName.Index] = new MetaField<string>(MetaFieldType.String, "say cart");
        meta.Fields[EntityDataFields.MinecartCommandBlock.IdLastOutput.Index] = new MetaField<TextComponent>(MetaFieldType.TextComponent, TextComponent.Text("[12:00:00] cart"));
        client.Dispatch(new ClientBoundSetEntityMetadataPacket { EntityId = 20, Meta = meta });
        Assert.That(minecart.CommandBlock.Command, Is.EqualTo("say cart"));
        Assert.That(TextFlattener.Plain(minecart.CommandBlock.LastOutput), Is.EqualTo("[12:00:00] cart"));

        minecart.CommandBlock.TrackOutput = false;
        ServerBoundProgramCommandBlockMinecartPacket packet = minecart.SetCommandPacket("say other");
        Assert.That((packet.EntityId, packet.Command, packet.TrackOutput), Is.EqualTo((20, "say other", false)));
    }

    [Test]
    public void ATestBlockTakesItsModeFromTheBlockUntilItsDataSaysOtherwise() {
        (MinecraftClient client, ClientLevel level, _, _) = World();
        Set(client, 2, 15, 0, Block.TestBlock with { ModeValue = TestBlockBlock.Mode.Log });
        TestBlockEntity testBlock = (TestBlockEntity)level.GetBlockEntity(2, 15, 0)!;
        Assert.That(testBlock.Mode, Is.EqualTo(TestBlockMode.Log));

        client.Dispatch(new ClientBoundBlockEntityDataPacket {
            Position = new Vec3<int>(2, 15, 0), Type = BlockEntityType.TestBlock,
            Data = new CompoundTag(("mode", new StringTag("accept")), ("message", new StringTag("done")))
        });
        Assert.That((testBlock.Mode, testBlock.Message), Is.EqualTo((TestBlockMode.Accept, "done")));

        // TestBlockEntity.loadAdditional: a mode the codec cannot read is FAIL.
        client.Dispatch(new ClientBoundBlockEntityDataPacket { Position = new Vec3<int>(2, 15, 0), Type = BlockEntityType.TestBlock, Data = new CompoundTag() });
        Assert.That((testBlock.Mode, testBlock.Message), Is.EqualTo((TestBlockMode.Fail, "")));

        ServerBoundSetTestBlockPacket packet = testBlock.SetTestBlockPacket(TestBlockMode.Start, "go");
        Assert.That((packet.Location, packet.Mode, packet.Message), Is.EqualTo((new Vec3<int>(2, 15, 0), TestBlockMode.Start, "go")));
    }

    [Test]
    public void AJigsawReadsItsUpdateTag() {
        (MinecraftClient client, ClientLevel level, _, _) = World();
        Set(client, 2, 15, 0, Block.Jigsaw with { Orientation = Orientation.UpNorth });
        Set(client, 3, 15, 0, Block.Jigsaw with { Orientation = Orientation.EastUp });
        JigsawBlockEntity vertical = (JigsawBlockEntity)level.GetBlockEntity(2, 15, 0)!;
        JigsawBlockEntity horizontal = (JigsawBlockEntity)level.GetBlockEntity(3, 15, 0)!;
        CompoundTag tag = new(("name", new StringTag("minecraft:bottom")), ("target", new StringTag("Not Valid")), ("pool", new StringTag("village/plains/streets")),
            ("final_state", new StringTag("minecraft:stone")), ("placement_priority", new IntegerTag(3)), ("selection_priority", new IntegerTag(-2)));
        client.Dispatch(new ClientBoundBlockEntityDataPacket { Position = new Vec3<int>(2, 15, 0), Type = BlockEntityType.Jigsaw, Data = tag });
        client.Dispatch(new ClientBoundBlockEntityDataPacket { Position = new Vec3<int>(3, 15, 0), Type = BlockEntityType.Jigsaw, Data = tag });

        Assert.That(vertical.Name, Is.EqualTo(new Identifier("minecraft", "bottom")));
        Assert.That(vertical.Target, Is.EqualTo(JigsawBlockEntity.EmptyId), "an identifier that does not parse is the empty one");
        Assert.That(vertical.Pool, Is.EqualTo(new Identifier("minecraft", "village/plains/streets")));
        Assert.That(vertical.FinalState, Is.EqualTo("minecraft:stone"));
        Assert.That((vertical.PlacementPriority, vertical.SelectionPriority), Is.EqualTo((3, -2)));
        // StructureTemplate.getDefaultJointType, for a tag with no joint.
        Assert.That(vertical.Joint, Is.EqualTo(JigsawJointType.Rollable));
        Assert.That(horizontal.Joint, Is.EqualTo(JigsawJointType.Aligned));
        Assert.That((vertical.FrontIsVertical, horizontal.FrontIsVertical), Is.EqualTo((true, false)));
    }
}

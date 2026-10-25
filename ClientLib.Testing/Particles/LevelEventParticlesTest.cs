using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Particles;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using ClientLib.World.BlockEntities;
using NBT.Tags;

namespace ClientLib.Testing.Particles;

/// <summary>
/// Which level events make particles and where they go: <c>LevelEventHandler.levelEvent</c>'s particle cases,
/// the block they read, and the paths an event takes to the engine.
/// </summary>
public class LevelEventParticlesTest {
    private const int Floor = 16;

    /// <summary>The level events vanilla's <c>levelEvent</c> only plays a sound for, or nothing.</summary>
    private static readonly int[] SoundOnly = [
        1000, 1001, 1002, 1004, 1009, 1010, 1011, 1015, 1016, 1017, 1018, 1019, 1020, 1021, 1022, 1024, 1025, 1026, 1027, 1029, 1030, 1031,
        1032, 1033, 1034, 1035, 1039, 1040, 1041, 1042, 1043, 1044, 1045, 1046, 1047, 1048, 1049, 1050, 1051, 1052, 3001
    ];

    /// <summary>The level events with particles that need nothing particular at the position.</summary>
    private static readonly int[] Unconditional = [
        1501, 1502, 1503, 2000, 2002, 2003, 2004, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 3000, 3002, 3003, 3004, 3005, 3006, 3007, 3009,
        3011, 3012, 3013, 3014, 3016, 3017, 3018, 3019, 3020, 3021
    ];

    /// <summary>Stone below <see cref="Floor"/>, air above, the player standing on it at the origin.</summary>
    private static (MinecraftClient Client, ParticleEngine Engine) World() {
        MinecraftClient client = new(new ClientOptions { Username = "Test", Particles = ParticleStatus.All });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld", VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -2; cx <= 2; cx++) {
            for (int cz = -2; cz <= 2; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    int baseY = level.MinY + i * 16;
                    biomes[i] = new ushort[64];
                    uint[] states = new uint[ClientSection.Volume];
                    for (int y = 0; y < 16; y++) {
                        if (baseY + y < Floor) {
                            Array.Fill(states, Block.Stone.StateId, y << 8, 256);
                        }
                    }
                    sections[i] = new ClientSection(states, level.IsAir);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, 0.5);
        client.Particles.Enabled = true;
        client.Particles.CameraPosition = new Vec3d(0.5, Floor + 1.62, 0.5);
        client.Particles.Tick();
        return (client, client.Particles);
    }

    private static void Set(MinecraftClient client, int x, int y, int z, IBlock block) => client.Level!.SetState(x, y, z, (ushort)block.StateId);

    [Test]
    public void EveryParticleCaseMakesParticles() {
        (_, ParticleEngine engine) = World();
        foreach (int type in Unconditional) {
            int before = engine.Pending.Length;
            engine.LevelEvent(type, 2, Floor, 2, type == 3006 ? 2 << 6 : 1);
            Assert.That(engine.Pending.Length, Is.GreaterThan(before), $"level event {type}");
        }
    }

    [Test]
    public void SoundOnlyCasesMakeNone() {
        (_, ParticleEngine engine) = World();
        foreach (int type in SoundOnly) {
            engine.LevelEvent(type, 2, Floor, 2, 1);
        }
        Assert.That(engine.Pending.Length, Is.Zero);
    }

    [Test]
    public void BreakingAndBrushingThrowTheBlocksFragments() {
        (_, ParticleEngine engine) = World();
        engine.LevelEvent(2001, 2, Floor, 2, (int)Block.Stone.StateId);
        Assert.That(engine.Pending.Length, Is.EqualTo(64));
        engine.LevelEvent(3008, 2, Floor, 2, (int)Block.SuspiciousSand.StateId);
        Assert.That(engine.Pending.Length, Is.EqualTo(128));
        engine.LevelEvent(2001, 2, Floor, 2, int.MaxValue);
        engine.LevelEvent(2001, 2, Floor, 2, 0);
        Assert.That(engine.Pending.Length, Is.EqualTo(128), "an unknown id is air, which makes nothing");
    }

    [Test]
    public void DispenserSmokeLeavesByTheFaceItsDataNames() {
        (_, ParticleEngine engine) = World();
        // Direction.from3DDataValue(5) is east.
        engine.LevelEvent(2000, 2, Floor, 2, 5);
        Assert.That(engine.Pending.Length, Is.EqualTo(10));
        foreach (ParticleState p in engine.Pending) {
            Assert.That(p.X, Is.GreaterThan(3.0));
            Assert.That(p.Z, Is.InRange(2.25, 2.75));
        }
    }

    [Test]
    public void GrassBoneMealSpreadsOverTheGroundAround() {
        (MinecraftClient client, ParticleEngine engine) = World();
        Set(client, 2, Floor - 1, 2, Block.GrassBlock);
        engine.LevelEvent(1505, 2, Floor - 1, 2, 15);
        // NEIGHBOR_SPREADER: forty five tries over six blocks square above it, kept only over something solid.
        Assert.That(engine.Pending.Length, Is.InRange(1, 45));
        foreach (ParticleState p in engine.Pending) {
            Assert.That(p.X, Is.InRange(-0.5, 5.5));
            Assert.That(p.Y, Is.InRange(Floor - 0.2, Floor + 1.0));
        }
    }

    [Test]
    public void SaplingBoneMealStaysInTheBlock() {
        (MinecraftClient client, ParticleEngine engine) = World();
        Set(client, 2, Floor, 2, Block.OakSapling);
        engine.LevelEvent(1505, 2, Floor, 2, 15);
        Assert.That(engine.Pending.Length, Is.EqualTo(15));
        foreach (ParticleState p in engine.Pending) {
            Assert.That(p.X, Is.InRange(2.0, 3.0));
        }
        int before = engine.Pending.Length;
        engine.LevelEvent(1505, 4, Floor, 4, 15);
        Assert.That(engine.Pending.Length, Is.EqualTo(before), "air is not bonemealable");
    }

    [Test]
    public void ComposterParticlesSitAboveItsContents() {
        (MinecraftClient client, ParticleEngine engine) = World();
        Set(client, 2, Floor, 2, Block.Composter);
        engine.LevelEvent(1500, 2, Floor, 2, 1);
        Assert.That(engine.Pending.Length, Is.EqualTo(10));
        foreach (ParticleState p in engine.Pending) {
            // An empty composter's floor is two pixels up; SuspendedTownParticle starts an eighth below where it is put.
            Assert.That(p.Y, Is.GreaterThanOrEqualTo(Floor + 2.0 / 16.0 + 0.03125 - 0.125 - 1.0E-6));
        }
    }

    [Test]
    public void DripstoneDripsWhatSitsAboveItsRoot() {
        (MinecraftClient client, ParticleEngine engine) = World();
        IBlock down = ((IVerticallyDirected)Block.PointedDripstone).WithVerticalDirection(VerticalDirection.Down);
        Set(client, 2, Floor + 3, 2, down);
        Set(client, 2, Floor + 4, 2, down);
        Set(client, 2, Floor + 5, 2, Block.DripstoneBlock);
        engine.LevelEvent(1504, 2, Floor + 3, 2, 0);
        Assert.That(engine.Pending.Length, Is.Zero, "nothing above the root");
        Set(client, 2, Floor + 6, 2, Block.Water);
        engine.LevelEvent(1504, 2, Floor + 3, 2, 0);
        Assert.That(engine.Pending.Length, Is.EqualTo(1));
        Assert.That(engine.Pending[0].Type, Is.EqualTo(VanillaRegistry.Data.Particles.GetProtocolId(Particle.DrippingDripstoneWater)));
    }

    [Test]
    public void AGlobalEventMakesNoParticles() {
        (MinecraftClient client, ParticleEngine engine) = World();
        client.Dispatch(new ClientBoundWorldEventPacket { Event = 2008, Location = new Vec3<int>(2, Floor, 2), Data = 0, DisableRelativeVolume = true });
        Assert.That(engine.Pending.Length, Is.Zero);
        client.Dispatch(new ClientBoundWorldEventPacket { Event = 2008, Location = new Vec3<int>(2, Floor, 2), Data = 0, DisableRelativeVolume = false });
        Assert.That(engine.Pending.Length, Is.EqualTo(1));
    }

    [Test]
    public void TheLevelsOwnEventsReachTheEngine() {
        (MinecraftClient client, ParticleEngine engine) = World();
        client.Level!.RaiseLevelEvent(2008, 2, Floor, 2, 0);
        Assert.That(engine.Pending.Length, Is.EqualTo(1));
    }

    [Test]
    public void ToolUsesAreToldFromWhatChanged() {
        Identifier axe = Item.IronAxe.Identifier, honeycomb = Item.Honeycomb.Identifier;
        Assert.That(ToolUseOn.Classify(axe, Block.OakLog, Block.StrippedOakLog), Is.EqualTo(ToolBlockChange.Strip));
        Assert.That(ToolUseOn.Classify(axe, Block.ExposedCopper, Block.CopperBlock), Is.EqualTo(ToolBlockChange.Scrape));
        Assert.That(ToolUseOn.Classify(axe, Block.WaxedExposedCopper, Block.ExposedCopper), Is.EqualTo(ToolBlockChange.WaxOff));
        Assert.That(ToolUseOn.Classify(honeycomb, Block.CopperBlock, Block.WaxedCopperBlock), Is.EqualTo(ToolBlockChange.WaxOn));
        Assert.That(ToolUseOn.Classify(axe, Block.ExposedCopper, Block.ExposedCopper), Is.EqualTo(ToolBlockChange.None));
        Assert.That(ToolUseOn.Classify(Item.Stick.Identifier, Block.ExposedCopper, Block.CopperBlock), Is.EqualTo(ToolBlockChange.None));
    }

    [Test]
    public void ScrapingADoubleChestScrapesBothHalves() {
        (MinecraftClient client, _) = World();
        List<(int Type, int X, int Z)> events = [];
        client.Level!.LevelEvent += (type, x, _, z, _) => events.Add((type, x, z));
        IBlock left = ((IHorizontalFacing)((IChestTyped)Block.ExposedCopperChest).WithType(ChestType.Left)).WithFacing(Direction.North);
        ToolUseOn.RaiseLevelEvents(client.Level, new UseOnOutcome(Hand.MainHand, new ItemStack(Item.IronAxe),
            (2, Floor, 2), (ushort)left.StateId, (ushort)Block.CopperChest.StateId, (2, Floor + 1, 2), 0, 0));
        // ChestBlock.getConnectedDirection: a left half facing north joins the block clockwise of north, east.
        Assert.That(events, Is.EqualTo(new List<(int, int, int)> { (3005, 2, 2), (3005, 3, 2) }));
    }

    [Test]
    public void AVaultActivatingConnectsToThePlayersItNames() {
        (MinecraftClient client, ParticleEngine engine) = World();
        LocalPlayer player = client.Player!;
        client.Entities[player.Id] = player;
        Set(client, 2, Floor, 2, Block.Vault);
        VaultBlockEntity vault = (VaultBlockEntity)ClientBlockEntity.Create(VanillaRegistry.Data, 2, Floor, 2, Block.Vault)!;
        Span<byte> bytes = player.Uuid.ToByteArray(bigEndian: true);
        int[] ints = new int[4];
        for (int i = 0; i < 4; i++) {
            ints[i] = System.Buffers.Binary.BinaryPrimitives.ReadInt32BigEndian(bytes[(i * 4)..]);
        }
        vault.Load(new CompoundTag(("shared_data", new CompoundTag(("connected_players", new ListTag(new ArrayTag<int>(ints)))))), VanillaRegistry.Data);
        client.Level!.SetBlockEntity(vault);
        Assert.That(vault.ConnectedPlayers, Does.Contain(player.Uuid));
        Assert.That(vault.ConnectedParticlesRange, Is.EqualTo(4.5));

        engine.LevelEvent(3015, 2, Floor, 2, 0);
        int connection = VanillaRegistry.Data.Particles.GetProtocolId(Particle.VaultConnection);
        // The player stands two blocks off, inside the range: two to five toward them, then smoke and flame in the cage.
        Assert.That(engine.Pending.ToArray().Count(p => p.Type == connection), Is.InRange(2, 5));
        Assert.That(engine.Pending.ToArray().Count(p => p.Type != connection), Is.EqualTo(40));

        int before = engine.Pending.Length;
        engine.LevelEvent(3015, 5, Floor, 5, 0);
        Assert.That(engine.Pending.Length, Is.EqualTo(before), "no vault, no activation");
    }
}

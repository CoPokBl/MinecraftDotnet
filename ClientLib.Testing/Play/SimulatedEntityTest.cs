using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Play;

/// <summary>
/// Entities whose client copy runs its own tick, against values worked by hand from vanilla's
/// <c>ItemEntity.tick</c> and <c>ClientPacketListener</c>.
/// </summary>
public class SimulatedEntityTest {
    private const int Floor = 16;
    private const int ItemId = 10;

    private static MinecraftClient FlatWorld() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        ushort stone = (ushort)Block.Stone.StateId;
        for (int cx = -4; cx <= 4; cx++) {
            for (int cz = -4; cz <= 4; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    biomes[i] = new ushort[64];
                    sections[i] = level.MinY + i * 16 < Floor ? new ClientSection(stone, false) : new ClientSection(0, true);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        // Well away from anything spawned, so an orb has nobody to chase.
        client.StartOffline(level).Position = new Vec3d(60.5, Floor, 60.5);
        return client;
    }

    private static SimulatedEntity Spawn(MinecraftClient client, IEntityType type, Vec3d position, Vec3d velocity, int id = ItemId) {
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = id,
            Uuid = Guid.NewGuid(),
            EntityType = type,
            Position = new Vec3<double>(position.X, position.Y, position.Z),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(velocity.X, velocity.Y, velocity.Z)
        });
        SimulatedEntity entity = (SimulatedEntity)client.Entities[id];
        if (type == EntityType.Item) {
            entity.Metadata[EntityDataFields.ItemEntity.Item.Index] = new MetaField<ItemStack>(MetaFieldType.Slot, new ItemStack(Item.Stone, 1));
        }
        return entity;
    }

    private static void Tick(MinecraftClient client, int ticks) {
        for (int i = 0; i < ticks; i++) {
            client.Tick();
        }
    }

    private static void Sync(MinecraftClient client, Vec3d position, Vec3d velocity, bool onGround) {
        client.HandleEntityTeleport(new ClientBoundTeleportEntityPacket {
            EntityId = ItemId,
            Position = new Vec3<double>(position.X, position.Y, position.Z),
            Velocity = new Vec3<double>(velocity.X, velocity.Y, velocity.Z),
            Yaw = Angle.FromDegrees(0),
            Pitch = Angle.FromDegrees(0),
            OnGround = onGround
        });
    }

    /// <summary>
    /// An item thrown from (0.5, 17, 0.5) at (0.1, 0.2, 0) over stone. Each tick takes 0.04 of gravity
    /// off y, moves, then multiplies by the air drag 0.98F, or by 0.98F * 0.6F = 0.588000059F
    /// horizontally on the ground, where a falling y is also turned round at half speed.
    /// <list type="bullet">
    /// <item>Tick 1: v = (0.1, 0.16), so x = 0.6 and y = 17.16, and v becomes (0.1, 0.16) * 0.98F.</item>
    /// <item>Tick 12 ends at y 16.2505938594963, still falling at -0.2650118914837.</item>
    /// <item>Tick 13 moves by -0.3050118914837, clipped to the floor at y 16: on the ground, so
    /// vx = 0.0784716907007681 * 0.588000059F and vy = -0.3050118914837 * 0.98F * -0.5.</item>
    /// <item>From tick 27 the horizontal speed is under 1e-5 squared and only ticks where
    /// <c>(tickCount + id) % 4 == 0</c> move, so ticks 27 to 29 hold x while gravity piles up in y.</item>
    /// </list>
    /// </summary>
    [Test]
    public void ThrownItemLandsWhereVanillaPutsIt() {
        MinecraftClient client = FlatWorld();
        SimulatedEntity item = Spawn(client, EntityType.Item, new Vec3d(0.5, 17.0, 0.5), new Vec3d(0.1, 0.2, 0.0));

        Tick(client, 1);
        Assert.That(item.Position.X, Is.EqualTo(0.6).Within(1e-12));
        Assert.That(item.Position.Y, Is.EqualTo(17.16).Within(1e-12));
        Assert.That(item.DeltaMovement.X, Is.EqualTo(0.1 * 0.98F).Within(1e-15));
        Assert.That(item.DeltaMovement.Y, Is.EqualTo(0.16 * 0.98F).Within(1e-15));
        Assert.That(item.OldPosition, Is.EqualTo(new Vec3d(0.5, 17.0, 0.5)));

        Tick(client, 11);
        Assert.That(item.Position.Y, Is.EqualTo(16.250593859496263).Within(1e-12));
        Assert.That(item.DeltaMovement.Y, Is.EqualTo(-0.26501189148371307).Within(1e-12));
        Assert.That(item.OnGround, Is.False);

        Tick(client, 1);
        Assert.That(item.Position.Y, Is.EqualTo(Floor));
        Assert.That(item.OnGround, Is.True);
        Assert.That(item.Position.X, Is.EqualTo(1.6548881822131236).Within(1e-12));
        Assert.That(item.DeltaMovement.X, Is.EqualTo(0.046141358771910695).Within(1e-12));
        Assert.That(item.DeltaMovement.Y, Is.EqualTo(0.14945582973583946).Within(1e-12));

        Tick(client, 13);
        Assert.That(item.Position.X, Is.EqualTo(2.0560462113515716).Within(1e-12));
        Tick(client, 3);
        Assert.That(item.Position.X, Is.EqualTo(2.0560462113515716).Within(1e-12));
        Assert.That(item.DeltaMovement.Y, Is.EqualTo(-0.10851485873872771).Within(1e-12));
        Tick(client, 1);
        Assert.That(item.Position.X, Is.EqualTo(2.05880542863276).Within(1e-12));
        Assert.That(item.Position.Y, Is.EqualTo(Floor));

        Tick(client, 200);
        Assert.That(item.Position.Y, Is.EqualTo(Floor));
        Assert.That(item.Position.Z, Is.EqualTo(0.5));
    }

    /// <summary>
    /// <c>ItemEntity</c> has no <c>InterpolationHandler</c>, so <c>moveOrInterpolateTo</c> sets the
    /// position at once and leaves the old one for the frame to blend from. The sync packet's velocity
    /// is not read.
    /// </summary>
    [Test]
    public void ServerPositionsLandAtOnce() {
        MinecraftClient client = FlatWorld();
        SimulatedEntity item = Spawn(client, EntityType.Item, new Vec3d(0.5, 18.0, 0.5), Vec3d.Zero);
        Tick(client, 1);
        Vec3d old = item.OldPosition;
        Vec3d velocity = item.DeltaMovement;

        Sync(client, new Vec3d(3.25, 20.0, 1.5), new Vec3d(1.0, 1.0, 1.0), false);
        Assert.That(item.Position, Is.EqualTo(new Vec3d(3.25, 20.0, 1.5)));
        Assert.That(item.OldPosition, Is.EqualTo(old));
        Assert.That(item.DeltaMovement, Is.EqualTo(velocity));

        // move_entity_pos is relative to the last position sent, in 1/4096ths.
        client.HandleMove(ItemId, new Vec3<float>(0.5F, -1.0F, 0.0F), null, null, false);
        Assert.That(item.Position, Is.EqualTo(new Vec3d(3.75, 19.0, 1.5)));

        // The next tick falls from there: -0.04 - 0.04 of gravity, then the drag.
        Tick(client, 1);
        Assert.That(item.Position.Y, Is.EqualTo(19.0 + (-0.04 * 0.98F - 0.04)).Within(1e-12));
        Assert.That(item.OldPosition, Is.EqualTo(new Vec3d(3.75, 19.0, 1.5)));
    }

    /// <summary>
    /// <c>handleEntityPositionSync</c> calls <c>setOnGround</c>, and a still item on the ground only
    /// moves when <c>(tickCount + id) % 4 == 0</c>, so one the server calls grounded hangs where it was
    /// put until that tick comes round.
    /// </summary>
    [Test]
    public void ServerOnGroundHoldsAStillItem() {
        MinecraftClient client = FlatWorld();
        SimulatedEntity item = Spawn(client, EntityType.Item, new Vec3d(0.5, 18.0, 0.5), Vec3d.Zero);
        // Spawned on tick count 0 with id 10: ticks 1 and 3 skip, tick 2 moves.
        Sync(client, new Vec3d(0.5, 17.0, 0.5), Vec3d.Zero, true);
        Tick(client, 1);
        Assert.That(item.Position.Y, Is.EqualTo(17.0));
        Tick(client, 1);
        Assert.That(item.Position.Y, Is.EqualTo(17.0 - 0.08).Within(1e-12));
        Assert.That(item.OnGround, Is.False);
    }

    [Test]
    public void FarSyncSnapsTheOldPositionToo() {
        MinecraftClient client = FlatWorld();
        SimulatedEntity item = Spawn(client, EntityType.Item, new Vec3d(0.5, 18.0, 0.5), Vec3d.Zero);
        Tick(client, 1);
        Sync(client, new Vec3d(70.5, 18.0, 0.5), Vec3d.Zero, false);
        Assert.That(item.OldPosition, Is.EqualTo(new Vec3d(70.5, 18.0, 0.5)));
    }

    /// <summary>
    /// <c>ExperienceOrb</c> keeps an <c>InterpolationHandler</c> of three steps, each taking a third of
    /// what is left, so a move of 0.3 is 0.1, then 0.1, then the rest.
    /// </summary>
    [Test]
    public void OrbInterpolatesOverThreeTicks() {
        MinecraftClient client = FlatWorld();
        SimulatedEntity orb = Spawn(client, EntityType.ExperienceOrb, new Vec3d(0.5, Floor, 0.5), Vec3d.Zero);
        Tick(client, 5);
        Assert.That(orb.Position, Is.EqualTo(new Vec3d(0.5, Floor, 0.5)));

        client.HandleMove(ItemId, new Vec3<float>(0.3F, 0.0F, 0.0F), null, null, true);
        Assert.That(orb.Position.X, Is.EqualTo(0.5));
        double target = Math.Round(0.3F * 4096.0) / 4096.0 + 0.5;
        Tick(client, 1);
        Assert.That(orb.Position.X, Is.EqualTo(0.5 + (target - 0.5) / 3.0).Within(1e-12));
        Tick(client, 2);
        Assert.That(orb.Position.X, Is.EqualTo(target).Within(1e-12));
        Assert.That(orb.Position.Y, Is.EqualTo(Floor));
    }
}

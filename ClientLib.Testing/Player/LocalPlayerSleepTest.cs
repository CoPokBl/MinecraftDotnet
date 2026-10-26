using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Vec;
using SchemaPose = Minecraft.Schemas.Entities.EntityPose;

namespace ClientLib.Testing.Player;

/// <summary>
/// Sleeping as the client sees it: the server's sleeping position puts the sleeper on the bed, a
/// sleeping player ignores its movement keys, and the wake up animation stands it back up.
/// </summary>
public class LocalPlayerSleepTest {
    private const int Floor = 16;

    private static readonly RedBedBlock Head = Block.RedBed with { Facing = Direction.North, Part = BedPart.Head, Occupied = true };
    private static readonly RedBedBlock Foot = Block.RedBed with { Facing = Direction.North, Part = BedPart.Foot, Occupied = true };

    private static (MinecraftClient Client, LocalPlayer Player) Bedroom() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        ushort stone = (ushort)Block.Stone.StateId;
        for (int cx = -2; cx <= 2; cx++) {
            for (int cz = -2; cz <= 2; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    biomes[i] = new ushort[64];
                    sections[i] = level.MinY + i * 16 < Floor ? new ClientSection(stone, false) : new ClientSection(0, true);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        level.SetState(0, Floor, 0, (ushort)Head.StateId);
        level.SetState(0, Floor, 1, (ushort)Foot.StateId);

        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, 3.5);
        Tick(client, player, PlayerInput.None, 2);
        return (client, player);
    }

    private static void Tick(MinecraftClient client, LocalPlayer player, PlayerInput input, int ticks) {
        for (int i = 0; i < ticks; i++) {
            player.Input = input;
            client.Tick();
        }
    }

    /// <summary>The server's <c>SLEEPING_POS_ID</c> arriving for the entity, as the metadata handler applies it.</summary>
    private static void SetSleepingPos(ClientEntity entity, int x, int y, int z) {
        int index = EntityDataFields.LivingEntity.SleepingPos.Index;
        entity.Metadata[index] = new MetaField<Optional<Vec3<int>>>(MetaFieldType.OptionalPosition, new Optional<Vec3<int>>(true, new Vec3<int>(x, y, z)));
        entity.OnSyncedDataUpdated(index);
    }

    [Test]
    public void TheSleepingPositionPutsThePlayerOnTheBed() {
        (MinecraftClient client, LocalPlayer player) = Bedroom();
        SetSleepingPos(player, 0, Floor, 0);

        Assert.That(player.Position, Is.EqualTo(new Vec3d(0.5, Floor + 0.6875, 0.5)));
        Assert.That(player.IsSleeping, Is.True);
        Assert.That(player.BedOrientation(client.Level!), Is.EqualTo(Direction.North));

        Tick(client, player, PlayerInput.None, 1);
        Assert.That(player.Pose, Is.EqualTo(EntityPose.Sleeping));
        Assert.That(player.CurrentEyeHeight, Is.EqualTo(0.2F));
        Assert.That(player.BoundingBox.MaxX - player.BoundingBox.MinX, Is.EqualTo(0.2).Within(1.0E-6));
    }

    [Test]
    public void MovementKeysAreIgnoredWhileAsleep() {
        (MinecraftClient client, LocalPlayer player) = Bedroom();
        SetSleepingPos(player, 0, Floor, 0);
        player.XRot = 30.0F;

        // Player.isImmobile drops the move and the jump; sprinting is not stopped by sleep, only by the
        // in bed screen taking the keys, so it is not pressed here.
        Tick(client, player, new PlayerInput(Forward: true, Left: true, Jump: true), 20);

        Assert.That(player.Position.X, Is.EqualTo(0.5));
        Assert.That(player.Position.Z, Is.EqualTo(0.5));
        Assert.That(player.Position.Y, Is.LessThanOrEqualTo(Floor + 0.6875));
        Assert.That(player.XRot, Is.EqualTo(0.0F));
        Assert.That(player.Pose, Is.EqualTo(EntityPose.Sleeping));
    }

    [Test]
    public void TheSleepTimerFillsAndTheWakeUpStandsThePlayerUp() {
        (MinecraftClient client, LocalPlayer player) = Bedroom();
        SetSleepingPos(player, 0, Floor, 0);
        Tick(client, player, PlayerInput.None, 99);
        Assert.That(player.SleepTimer, Is.EqualTo(99));
        Assert.That(player.IsSleepingLongEnough, Is.False);
        Tick(client, player, PlayerInput.None, 5);
        Assert.That(player.SleepTimer, Is.EqualTo(100));
        Assert.That(player.IsSleepingLongEnough, Is.True);

        player.StopSleepInBed(false);
        Assert.That(player.IsSleeping, Is.False);
        Assert.That(player.Pose, Is.EqualTo(EntityPose.Standing));
        Assert.That(player.Get(EntityDataFields.Entity.Pose), Is.EqualTo(SchemaPose.Standing));
        Assert.That(((Minecraft.Data.Blocks.Properties.IOccupied)client.Level!.GetBlock(0, Floor, 0)).Occupied, Is.False);

        // The fade back out runs from 100 to 110 and then stops.
        Tick(client, player, PlayerInput.None, 9);
        Assert.That(player.SleepTimer, Is.EqualTo(109));
        Tick(client, player, PlayerInput.None, 1);
        Assert.That(player.SleepTimer, Is.EqualTo(0));
    }

    [Test]
    public void AForcedWakeUpSkipsTheFade() {
        (MinecraftClient client, LocalPlayer player) = Bedroom();
        SetSleepingPos(player, 0, Floor, 0);
        Tick(client, player, PlayerInput.None, 40);
        player.StopSleepInBed(true);
        Assert.That(player.SleepTimer, Is.EqualTo(0));
        Tick(client, player, PlayerInput.None, 1);
        Assert.That(player.SleepTimer, Is.EqualTo(0));
    }

    [Test]
    public void AnotherPlayerSleepsOnTheBedAndWakesWithTheAnimation() {
        (MinecraftClient client, _) = Bedroom();
        ClientEntity other = new() { Id = 7, Type = EntityType.Player, Position = new Vec3d(3.5, Floor, 3.5) };
        client.Entities[other.Id] = other;
        SetSleepingPos(other, 0, Floor, 0);
        other.Metadata[EntityDataFields.Entity.Pose.Index] = new MetaField<SchemaPose>(MetaFieldType.Pose, SchemaPose.Sleeping);

        Assert.That(other.Position, Is.EqualTo(new Vec3d(0.5, Floor + 0.6875, 0.5)));
        Assert.That(other.BedOrientation(client.Level!), Is.EqualTo(Direction.North));

        other.StopSleeping(client.Level);
        Assert.That(other.IsSleeping, Is.False);
        Assert.That(other.Get(EntityDataFields.Entity.Pose), Is.EqualTo(SchemaPose.Standing));
    }
}

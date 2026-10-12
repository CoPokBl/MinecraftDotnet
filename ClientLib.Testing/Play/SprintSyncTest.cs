using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Attributes;
using Minecraft.Schemas.Entities.Meta;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Testing.Play;

/// <summary>
/// The local player's sprint is <c>Entity.isSprinting</c>, shared flag 3, so the server ending it after
/// a sprint hit reaches <c>aiStep</c> and <c>LocalPlayer.sendIsSprintingIfNeeded</c> as it does in vanilla.
/// A full strength sprint hit on another player ends it on this side first, in <c>causeExtraKnockback</c>.
/// </summary>
public class SprintSyncTest {
    private const int PlayerId = 1;
    private const int Floor = 16;

    private static (MinecraftClient Client, LocalPlayer Player, List<MinecraftPacket> Sent) FlatWorld() {
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
        LocalPlayer player = client.StartOffline(level, PlayerId);
        player.Position = new Vec3d(0.5, Floor, -40.5);
        player.Food = 20;
        player.XRot = 30.0F;
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;
        return (client, player, sent);
    }

    private static void Tick(MinecraftClient client, PlayerInput input, int ticks, int attackClicks = 0) {
        for (int i = 0; i < ticks; i++) {
            client.Player!.Input = input;
            for (int click = 0; click < attackClicks; click++) {
                client.Interactions.Keys.Attack.Press();
                client.Interactions.Keys.Attack.SetDown(false);
            }
            client.Interactions.Tick();
            client.Tick();
        }
    }

    private static List<PlayerAction> SprintCommands(List<MinecraftPacket> sent) =>
        sent.OfType<ServerBoundPlayerCommandPacket>().Select(p => p.PlayAction).ToList();

    private static ClientEntity InFrontOf(MinecraftClient client, Minecraft.Data.Entities.IEntityType type) {
        Vec3d at = client.Player!.Position + new Vec3d(0, 0, 1.5);
        ClientEntity entity = new() { Id = 10, Type = type, Position = at, OldPosition = at };
        client.Entities[entity.Id] = entity;
        return entity;
    }

    /// <summary>What <c>ServerPlayer</c> syncs back after <c>Player.attack</c> calls <c>setSprinting(false)</c> on the server.</summary>
    private static void ServerEndsTheSprint(MinecraftClient client) {
        EntityMetaContainer meta = new();
        meta.Fields[EntityDataFields.Entity.SharedFlags.Index] = new MetaField<sbyte>(MetaFieldType.Byte, 0);
        client.Dispatch(new ClientBoundSetEntityMetadataPacket { EntityId = PlayerId, Meta = meta });
        client.Dispatch(new ClientBoundUpdateAttributesPacket {
            EntityId = PlayerId,
            Attributes = [new AttributeValue(Attribute.MovementSpeed, 0.1)]
        });
    }

    private static double Speed(LocalPlayer player) => player.Attributes.Value(Attribute.MovementSpeed);

    /// <summary>One tick that clicks attack on whatever is in front, returning the velocity <c>Player.attack</c> left before the player's own tick.</summary>
    private static Vec3d AttackTick(MinecraftClient client, PlayerInput input) {
        client.Player!.Input = input;
        client.Interactions.Keys.Attack.Press();
        client.Interactions.Keys.Attack.SetDown(false);
        client.Interactions.Tick();
        Vec3d afterAttack = client.Player.DeltaMovement;
        client.Tick();
        return afterAttack;
    }

    private static int IndexOf<T>(List<MinecraftPacket> sent) => sent.FindIndex(p => p is T);

    /// <summary><c>getFrictionInfluencedSpeed</c> on stone, whose friction is 0.6.</summary>
    private static float GroundSpeed(float movementSpeed) => movementSpeed * (0.21600002F / (0.6F * 0.6F * 0.6F));

    private const float SprintSpeed = (float)(0.1F * (1.0 + 0.3F));

    [Test]
    public void TestASprintHitOnAPlayerSlowsTheAttackerAndEndsTheSprintBeforeItsMove() {
        (MinecraftClient client, LocalPlayer player, List<MinecraftPacket> sent) = FlatWorld();
        PlayerInput sprint = new(Forward: true, Sprint: true);
        Tick(client, sprint, 20);
        ClientEntity target = InFrontOf(client, EntityType.Player);
        player.DeltaMovement = new Vec3d(0.1, 0.0, 0.25);
        sent.Clear();

        Vec3d afterAttack = AttackTick(client, sprint);
        // knockback 0.5 from the sprint: the attacker keeps 0.6 of its horizontal speed, and the
        // target, facing +z with no resistance, gets half its old speed less 0.5 along -z.
        Assert.That(afterAttack.X, Is.EqualTo(0.1 * 0.6));
        Assert.That(afterAttack.Y, Is.EqualTo(0.0));
        Assert.That(afterAttack.Z, Is.EqualTo(0.25 * 0.6));
        Assert.That(target.DeltaMovement.Z, Is.EqualTo(0.5));

        // The held sprint key starts it again in the same aiStep, so wasSprinting never saw it end and
        // nothing is sent; the tick's travel starts from the slowed speed at sprint speed.
        Assert.That(player.Sprinting, Is.True);
        Assert.That(SprintCommands(sent), Is.Empty);
        double accelerationZ = 0.98F * (double)GroundSpeed(SprintSpeed);
        Assert.That(player.DeltaMovement.X, Is.EqualTo(0.1 * 0.6 * (0.6F * 0.91F)).Within(1.0E-15));
        Assert.That(player.DeltaMovement.Z, Is.EqualTo((0.25 * 0.6 + accelerationZ) * (0.6F * 0.91F)).Within(1.0E-15));
        Assert.That(IndexOf<ServerBoundAttackPacket>(sent), Is.LessThan(IndexOf<ServerBoundSetPlayerPositionPacket>(sent)));
    }

    [Test]
    public void TestASprintHitOnAPlayerWithoutTheSprintKeyIsSentAsStoppedThatTick() {
        (MinecraftClient client, LocalPlayer player, List<MinecraftPacket> sent) = FlatWorld();
        Tick(client, new PlayerInput(Forward: true, Sprint: true), 20);
        PlayerInput forward = new(Forward: true);
        Tick(client, forward, 5);
        InFrontOf(client, EntityType.Player);
        player.DeltaMovement = new Vec3d(0.0, 0.0, 0.25);
        sent.Clear();

        Vec3d afterAttack = AttackTick(client, forward);
        Assert.That(afterAttack.Z, Is.EqualTo(0.25 * 0.6));
        Assert.That(player.Sprinting, Is.False);
        Assert.That(Speed(player), Is.EqualTo((double)0.1F));
        Assert.That(player.DeltaMovement.Z, Is.EqualTo((0.25 * 0.6 + 0.98F * (double)GroundSpeed(0.1F)) * (0.6F * 0.91F)).Within(1.0E-15));
        Assert.That(SprintCommands(sent), Is.EqualTo(new[] { PlayerAction.StopSprinting }));
        int attack = IndexOf<ServerBoundAttackPacket>(sent);
        int stop = IndexOf<ServerBoundPlayerCommandPacket>(sent);
        Assert.That(attack, Is.LessThan(stop));
        Assert.That(stop, Is.LessThan(IndexOf<ServerBoundSetPlayerPositionPacket>(sent)));
    }

    [Test]
    public void TestAPartStrengthSprintHitOnAPlayerLeavesTheAttackerAlone() {
        (MinecraftClient client, LocalPlayer player, List<MinecraftPacket> sent) = FlatWorld();
        PlayerInput sprint = new(Forward: true, Sprint: true);
        Tick(client, sprint, 20);
        ClientEntity target = InFrontOf(client, EntityType.Player);
        player.ResetAttackStrengthTicker();
        // Three ticks into the five a fist takes: (3 + 0.5) / 5 is 0.7, under the 0.9 a knockback hit needs.
        Tick(client, sprint, 3);
        player.DeltaMovement = new Vec3d(0.0, 0.0, 0.25);
        sent.Clear();

        Vec3d afterAttack = AttackTick(client, sprint);
        Assert.That(sent.OfType<ServerBoundAttackPacket>().Count(), Is.EqualTo(1));
        Assert.That(afterAttack.Z, Is.EqualTo(0.25));
        Assert.That(target.DeltaMovement, Is.EqualTo(Vec3d.Zero));
        Assert.That(player.Sprinting, Is.True);
        Assert.That(SprintCommands(sent), Is.Empty);
    }

    [Test]
    public void TestAnAirborneSprintHitOnAPlayerSlowsOnlyTheHorizontal() {
        (MinecraftClient client, LocalPlayer player, List<MinecraftPacket> sent) = FlatWorld();
        PlayerInput sprint = new(Forward: true, Sprint: true);
        Tick(client, sprint, 20);
        player.Position = new Vec3d(player.Position.X, Floor + 1.0, player.Position.Z);
        player.OnGround = false;
        player.DeltaMovement = new Vec3d(0.0, 0.2, 0.3);
        ClientEntity target = InFrontOf(client, EntityType.Player);
        sent.Clear();

        Vec3d afterAttack = AttackTick(client, sprint);
        Assert.That(afterAttack.Y, Is.EqualTo(0.2));
        Assert.That(afterAttack.Z, Is.EqualTo(0.3 * 0.6));
        // The target is in the air too, so knockback leaves its vertical speed as it was.
        Assert.That(target.DeltaMovement.Y, Is.EqualTo(0.0));
        Assert.That(player.Sprinting, Is.True);
        // travelInAir: the sprinting flying speed, then air friction 0.91, and gravity 0.08 before drag 0.98.
        Assert.That(player.DeltaMovement.Z, Is.EqualTo((0.3 * 0.6 + 0.98F * (double)0.025999999F) * 0.91F).Within(1.0E-15));
        Assert.That(player.DeltaMovement.Y, Is.EqualTo((0.2 - 0.08) * 0.98F).Within(1.0E-15));
    }

    [Test]
    public void TestASprintHitOnAMobLeavesTheSprintToTheServer() {
        (MinecraftClient client, LocalPlayer player, List<MinecraftPacket> sent) = FlatWorld();
        PlayerInput sprint = new(Forward: true, Sprint: true);
        Tick(client, sprint, 20);
        Assert.That(SprintCommands(sent), Is.EqualTo(new[] { PlayerAction.StartSprinting }));

        InFrontOf(client, EntityType.Pig);
        player.DeltaMovement = new Vec3d(0.0, 0.0, 0.25);
        sent.Clear();
        Vec3d afterAttack = AttackTick(client, sprint);
        Assert.That(sent.OfType<ServerBoundAttackPacket>().Count(), Is.EqualTo(1));
        // A mob's hurtClient is false, so nothing on this side touches the speed or the sprint.
        Assert.That(afterAttack.Z, Is.EqualTo(0.25));
        Assert.That(player.Sprinting, Is.True);
        Assert.That(SprintCommands(sent), Is.Empty);
    }

    [Test]
    public void TestHeldSprintResumesAtOnceWithoutTellingTheServer() {
        (MinecraftClient client, LocalPlayer player, List<MinecraftPacket> sent) = FlatWorld();
        PlayerInput sprint = new(Forward: true, Sprint: true);
        Tick(client, sprint, 20);
        sent.Clear();

        ServerEndsTheSprint(client);
        Assert.That(player.Sprinting, Is.False);
        Assert.That(Speed(player), Is.EqualTo(0.1).Within(1.0E-9));

        // aiStep's canStartSprinting sets the flag and the modifier again before sendIsSprintingIfNeeded
        // compares it with wasSprinting, which never went false, so vanilla sends nothing.
        Tick(client, sprint, 1);
        Assert.That(player.Sprinting, Is.True);
        Assert.That(Speed(player), Is.EqualTo(0.1 * (1.0 + 0.3F)).Within(1.0E-12));
        Assert.That(SprintCommands(sent), Is.Empty);
    }

    [Test]
    public void TestASprintNotHeldStopsAndIsSentAsStopped() {
        (MinecraftClient client, LocalPlayer player, List<MinecraftPacket> sent) = FlatWorld();
        Tick(client, new PlayerInput(Forward: true, Sprint: true), 20);
        // The sprint carries on with only forward held, as it does after a double tap.
        Tick(client, new PlayerInput(Forward: true), 5);
        Assert.That(player.Sprinting, Is.True);
        sent.Clear();

        ServerEndsTheSprint(client);
        Tick(client, new PlayerInput(Forward: true), 3);
        Assert.That(player.Sprinting, Is.False);
        Assert.That(SprintCommands(sent), Is.EqualTo(new[] { PlayerAction.StopSprinting }));

        Tick(client, new PlayerInput(Forward: true, Sprint: true), 1);
        Assert.That(SprintCommands(sent), Is.EqualTo(new[] { PlayerAction.StopSprinting, PlayerAction.StartSprinting }));
    }

    [Test]
    public void TestASprintHitOnABoatEndsTheSprintHere() {
        (MinecraftClient client, LocalPlayer player, List<MinecraftPacket> sent) = FlatWorld();
        Tick(client, new PlayerInput(Forward: true, Sprint: true), 20);
        Tick(client, new PlayerInput(Forward: true), 5);
        ClientEntity boat = InFrontOf(client, EntityType.OakBoat);
        sent.Clear();

        // VehicleEntity's hurtClient is true, so causeExtraKnockback runs on the client.
        Tick(client, new PlayerInput(Forward: true), 1, attackClicks: 1);
        Assert.That(player.Sprinting, Is.False);
        Assert.That(boat.DeltaMovement.Z, Is.GreaterThan(0.0));
        Assert.That(SprintCommands(sent), Is.EqualTo(new[] { PlayerAction.StopSprinting }));
    }
}

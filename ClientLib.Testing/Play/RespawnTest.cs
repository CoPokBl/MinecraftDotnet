using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ClientLib.Testing.Play;

/// <summary>
/// What <c>ClientPacketListener.handleRespawn</c> keeps: <c>MultiPlayerGameMode</c> lives as long as the
/// connection's play phase, the <c>BlockStatePredictionHandler</c> as long as the <c>ClientLevel</c>, and the
/// inventory and abilities as long as the <c>LocalPlayer</c>.
/// </summary>
public class RespawnTest {
    private const int PlayerId = 1;

    private static (MinecraftClient Client, List<MinecraftPacket> Sent) Overworld() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        client.StartOffline(level, PlayerId);
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;
        return (client, sent);
    }

    private static void Respawn(MinecraftClient client, Identifier dimension, ClientBoundRespawnPacket.DataKeptTypes kept, GameMode mode = GameMode.Survival) {
        client.Dispatch(new ClientBoundRespawnPacket {
            DimensionType = VanillaRegistry.Data.DimensionTypes.GetProtocolId(dimension),
            DimensionName = dimension,
            HashedSeed = 0,
            GameMode = mode,
            PreviousGameMode = GameMode.Undefined,
            IsDebug = false,
            IsFlat = false,
            PortalCooldown = 0,
            SeaLevel = 32,
            DataKept = kept
        });
    }

    private static void TickInteractions(MinecraftClient client, int ticks) {
        for (int i = 0; i < ticks; i++) {
            client.Interactions.Tick();
            client.Tick();
        }
    }

    private static int DigSequence(MinecraftClient client, List<MinecraftPacket> sent, int x) {
        sent.Clear();
        client.Interactions.StartDestroyBlock(x, 10, 0, BlockFace.PosY);
        client.Interactions.StopDestroyBlock();
        return sent.OfType<ServerBoundPlayerActionPacket>().First(p => p.ActionStatus == ServerBoundPlayerActionPacket.Status.StartedDigging).Sequence;
    }

    [Test]
    public void TestTheFirstSlotIsNeverSentAfterJoining() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Overworld();
        TickInteractions(client, 3);
        Assert.That(sent.OfType<ServerBoundSetHeldItemPacket>(), Is.Empty);
    }

    [Test]
    public void TestADimensionChangeSendsNoCarriedItem() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Overworld();
        client.Inventory.SelectedSlot = 3;
        TickInteractions(client, 1);
        Assert.That(sent.OfType<ServerBoundSetHeldItemPacket>().Select(p => (int)p.Slot), Is.EqualTo(new[] { 3 }));
        sent.Clear();

        Respawn(client, "minecraft:the_nether", ClientBoundRespawnPacket.DataKeptTypes.All);
        // PlayerList.sendAllPlayerInfo, which ServerPlayer.teleport sends after the respawn.
        client.Dispatch(new ClientBoundSetHeldItemPacket { Slot = 3 });
        TickInteractions(client, 3);
        Assert.That(sent.OfType<ServerBoundSetHeldItemPacket>(), Is.Empty);
    }

    [Test]
    public void TestADeathRespawnStartsOnTheFirstSlot() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Overworld();
        client.Inventory.SelectedSlot = 3;
        TickInteractions(client, 1);
        sent.Clear();

        // PlayerList.respawn sends no held slot, and the new player's inventory starts on the first.
        Respawn(client, "minecraft:overworld", ClientBoundRespawnPacket.DataKeptTypes.None);
        TickInteractions(client, 1);
        Assert.That(sent.OfType<ServerBoundSetHeldItemPacket>().Select(p => (int)p.Slot), Is.EqualTo(new[] { 0 }));
    }

    [Test]
    public void TestTheSequenceStartsAgainInANewLevel() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Overworld();
        Assert.That(DigSequence(client, sent, 0), Is.EqualTo(1));
        Assert.That(DigSequence(client, sent, 1), Is.EqualTo(2));

        Respawn(client, "minecraft:overworld", ClientBoundRespawnPacket.DataKeptTypes.None);
        Assert.That(DigSequence(client, sent, 2), Is.EqualTo(3));

        Respawn(client, "minecraft:the_nether", ClientBoundRespawnPacket.DataKeptTypes.All);
        Assert.That(DigSequence(client, sent, 3), Is.EqualTo(1));
    }

    [Test]
    public void TestDiggingCarriesOnThroughARespawn() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Overworld();
        client.Interactions.StartDestroyBlock(0, 10, 0, BlockFace.PosY);
        Respawn(client, "minecraft:the_nether", ClientBoundRespawnPacket.DataKeptTypes.All);
        sent.Clear();

        // The old dig is still MultiPlayerGameMode's, so letting go aborts it on the server.
        TickInteractions(client, 1);
        Assert.That(sent.OfType<ServerBoundPlayerActionPacket>().Select(p => p.ActionStatus),
            Is.EqualTo(new[] { ServerBoundPlayerActionPacket.Status.CancelledDigging }));
    }

    [Test]
    public void TestAKeptRespawnSendsNothingTheServerWasAlreadyTold() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Overworld();
        LocalPlayer player = client.Player!;
        player.Position = new Vec3d(0.5, 400, 0.5);
        PlayerInput sprint = new(Forward: true, Sprint: true);
        for (int i = 0; i < 3; i++) {
            player.Input = sprint;
            client.Tick();
        }
        Assert.That(player.Sprinting, Is.True);

        Respawn(client, "minecraft:the_nether", ClientBoundRespawnPacket.DataKeptTypes.All);
        client.Dispatch(new ClientBoundGameEventPacket { Event = GameEvent.StartWaitingForLevelChunks, Value = 0 });
        client.Player!.Position = new Vec3d(0.5, 400, 0.5);
        sent.Clear();
        for (int i = 0; i < 3; i++) {
            client.Player.Input = sprint;
            client.Tick();
        }
        Assert.That(client.ClientLoaded, Is.True);
        Assert.That(client.Player.Sprinting, Is.True);
        Assert.That(sent.OfType<ServerBoundPlayerInputPacket>(), Is.Empty);
        Assert.That(sent.OfType<ServerBoundPlayerCommandPacket>(), Is.Empty);
    }

    [Test]
    public void TestRespawnAbilitiesComeFromTheGameModes() {
        (MinecraftClient client, _) = Overworld();
        client.Player!.GameMode = GameMode.Spectator;
        client.Player.FlyingSpeed = 0.2F;

        // adjustPlayer applies spectator's flying, and creative's setLocalMode leaves it.
        Respawn(client, "minecraft:the_nether", ClientBoundRespawnPacket.DataKeptTypes.All, GameMode.Creative);
        LocalPlayer player = client.Player!;
        Assert.That(player.MayFly, Is.True);
        Assert.That(player.InstaBuild, Is.True);
        Assert.That(player.Flying, Is.True);
        Assert.That(player.FlyingSpeed, Is.EqualTo(0.05F));
    }
}

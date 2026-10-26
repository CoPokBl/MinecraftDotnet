using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Testing.Play;

/// <summary>
/// Spectating another entity, <c>ClientPacketListener.handleSetCamera</c> and what <c>isControlledCamera</c>
/// turns off, and the spectator menu the number keys and wheel drive, <c>SpectatorGui</c> and <c>SpectatorMenu</c>.
/// </summary>
public class SpectatingTest {
    private const int PlayerId = 1;

    private static MinecraftClient Client() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        LocalPlayer player = client.StartOffline(level, PlayerId);
        player.GameMode = GameMode.Spectator;
        player.MayFly = true;
        player.Flying = true;
        return client;
    }

    private static ClientEntity Pig(MinecraftClient client) {
        ClientEntity pig = new() { Id = 10, Type = EntityType.Pig, Position = new Vec3d(5, 64, 5), OldPosition = new Vec3d(5, 64, 5) };
        client.Entities[10] = pig;
        return pig;
    }

    [Test]
    public void TestSetCameraMovesTheViewAndBack() {
        MinecraftClient client = Client();
        ClientEntity pig = Pig(client);
        Assert.That(client.CameraEntity, Is.SameAs(client.Player));
        Assert.That(client.Player!.IsControlledCamera, Is.True);

        client.Dispatch(new ClientBoundSetCameraPacket { EntityId = 10 });
        Assert.That(client.CameraEntity, Is.SameAs(pig));
        Assert.That(client.Player.IsControlledCamera, Is.False);

        client.Dispatch(new ClientBoundSetCameraPacket { EntityId = 99 });
        Assert.That(client.CameraEntity, Is.SameAs(pig));

        client.Dispatch(new ClientBoundSetCameraPacket { EntityId = PlayerId });
        Assert.That(client.CameraEntity, Is.SameAs(client.Player));
    }

    [Test]
    public void TestTheKeysDoNotMoveAPlayerSpectatingSomethingElse() {
        MinecraftClient client = Client();
        Pig(client);
        LocalPlayer player = client.Player!;
        player.Input = new PlayerInput(Forward: true, Jump: true);
        client.Dispatch(new ClientBoundSetCameraPacket { EntityId = 10 });
        Vec3d start = player.Position;
        for (int i = 0; i < 5; i++) {
            client.Tick();
        }
        Assert.That(player.Position, Is.EqualTo(start));

        client.Dispatch(new ClientBoundSetCameraPacket { EntityId = PlayerId });
        for (int i = 0; i < 5; i++) {
            client.Tick();
        }
        Assert.That(player.Position.Z, Is.GreaterThan(start.Z));
        Assert.That(player.Position.Y, Is.GreaterThan(start.Y));
    }

    [Test]
    public void TestThePickStartsAtTheCameraEntitysEye() {
        MinecraftClient client = Client();
        ClientEntity pig = Pig(client);
        client.Dispatch(new ClientBoundSetCameraPacket { EntityId = 10 });
        client.Interactions.Pick(1.0F);
        // Nothing to hit, so the miss lands at the end of the reach from the pig's eye, looking south.
        double reach = Math.Max(client.Player!.Attributes.Value(Attribute.BlockInteractionRange), client.Player.Attributes.Value(Attribute.EntityInteractionRange));
        Vec3d eye = new(pig.Position.X, pig.Position.Y + pig.CurrentEyeHeight, pig.Position.Z);
        Assert.That(client.Interactions.Target!.Location.DistanceToSqr(eye + new Vec3d(0, 0, reach)), Is.LessThan(1.0E-9));
    }

    [Test]
    public void TestTheFirstNumberOpensTheMenuAndTheSecondSelects() {
        MinecraftClient client = Client();
        SpectatorGui gui = client.SpectatorGui;
        gui.OnHotbarSelected(0);
        Assert.That(gui.IsMenuActive, Is.True);
        Assert.That(gui.Menu!.SelectedSlot, Is.EqualTo(-1));

        gui.OnHotbarSelected(8);
        Assert.That(gui.Menu!.SelectedSlot, Is.EqualTo(8));
        gui.OnHotbarSelected(8);
        Assert.That(gui.IsMenuActive, Is.False);
    }

    [Test]
    public void TestTheWheelSkipsDisabledSlotsAndStopsAtTheEnds() {
        MinecraftClient client = Client();
        SpectatorGui gui = client.SpectatorGui;
        gui.OnHotbarSelected(0);
        // With no other players and no teams both categories are disabled, so the first stop is close.
        gui.OnMouseScrolled(1);
        Assert.That(gui.Menu!.SelectedSlot, Is.EqualTo(8));
        gui.OnMouseScrolled(1);
        Assert.That(gui.Menu!.SelectedSlot, Is.EqualTo(8));
        gui.OnMouseScrolled(-1);
        Assert.That(gui.Menu!.SelectedSlot, Is.EqualTo(8));
    }

    [Test]
    public void TestTheTeleportListLeavesOutSpectatorsAndSortsLikeJava() {
        MinecraftClient client = Client();
        // Java compares a UUID's halves as signed longs, so a high first bit sorts first.
        Guid low = Guid.Parse("00000000-0000-0000-0000-000000000001");
        Guid high = Guid.Parse("80000000-0000-0000-0000-000000000000");
        Guid watching = Guid.Parse("00000000-0000-0000-0000-000000000002");
        client.PlayerList[low] = new PlayerListEntry(low, "Low") { Listed = true };
        client.PlayerList[high] = new PlayerListEntry(high, "High") { Listed = true };
        client.PlayerList[watching] = new PlayerListEntry(watching, "Watching") { Listed = true, GameMode = GameMode.Spectator };

        TeleportToPlayerMenuCategory category = new(client);
        Assert.That(category.Items.Select(item => ((PlayerMenuItem)item).Player.Name), Is.EqualTo(new[] { "High", "Low" }));
    }
}

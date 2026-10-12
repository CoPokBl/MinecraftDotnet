using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace ClientLib.Testing.Player;

/// <summary>
/// <c>LocalPlayer.handlePortalTransitionEffect</c>: the intensity runs at the start of <c>aiStep</c>, before
/// the move whose <c>entityInside</c> marks the player as in the portal, so it trails the portal by a tick.
/// It climbs 0.0125F a tick and falls 0.05F, clamped to 0 to 1, and the figures below are those float sums.
/// </summary>
public class LocalPlayerPortalTest {
    private const int Floor = 16;

    private static (MinecraftClient Client, LocalPlayer Player, ClientLevel Level) World(uint portal) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -1; cx <= 1; cx++) {
            for (int cz = -1; cz <= 1; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    int baseY = level.MinY + i * 16;
                    biomes[i] = new ushort[64];
                    uint[] states = new uint[ClientSection.Volume];
                    for (int y = 0; y < 16; y++) {
                        for (int z = 0; z < 16; z++) {
                            for (int x = 0; x < 16; x++) {
                                int wy = baseY + y;
                                states[y << 8 | z << 4 | x] = wy < Floor ? Block.Stone.StateId
                                    : cx * 16 + x == 0 && cz * 16 + z == 0 && wy is Floor or Floor + 1 ? portal
                                    : 0;
                            }
                        }
                    }
                    sections[i] = new ClientSection(states, level.IsAir);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, 0.5);
        return (client, player, level);
    }

    private static void Ticks(MinecraftClient client, int ticks) {
        for (int i = 0; i < ticks; i++) {
            client.Tick();
        }
    }

    [Test]
    public void TheEffectStartsTheTickAfterThePlayerEntersAndTriggersOnce() {
        (MinecraftClient client, LocalPlayer player, _) = World(Block.NetherPortal.StateId);
        List<float> triggers = [];
        int screenChecks = 0;
        player.PortalTriggered += triggers.Add;
        client.InsideConfusionPortal += () => screenChecks++;

        client.Tick();
        Assert.That(player.PortalEffectIntensity, Is.Zero);
        Assert.That(player.ActivePortalLocalTransition, Is.EqualTo(PortalTransition.Confusion));
        Assert.That(triggers, Is.Empty);

        client.Tick();
        Assert.That(player.OPortalEffectIntensity, Is.Zero);
        Assert.That(player.PortalEffectIntensity, Is.EqualTo(0.0125F));
        Assert.That(triggers, Has.Count.EqualTo(1));
        Assert.That(triggers[0], Is.InRange(0.8F, 1.2F));

        client.Tick();
        Assert.That(player.OPortalEffectIntensity, Is.EqualTo(0.0125F));
        Assert.That(player.PortalEffectIntensity, Is.EqualTo(0.025F));
        Assert.That(triggers, Has.Count.EqualTo(1));
        Assert.That(screenChecks, Is.EqualTo(2));
    }

    /// <summary>Eighty steps of 0.0125F sum to 0.99999934F, so the clamp to 1 comes on the eighty first.</summary>
    [Test]
    public void StayingInThePortalReachesFullIntensityOnTheEightySecondTick() {
        (MinecraftClient client, LocalPlayer player, _) = World(Block.NetherPortal.StateId);
        Ticks(client, 81);
        Assert.That(player.PortalEffectIntensity, Is.EqualTo(0.99999934F));
        client.Tick();
        Assert.That(player.PortalEffectIntensity, Is.EqualTo(1.0F));
        Ticks(client, 100);
        Assert.That(player.PortalEffectIntensity, Is.EqualTo(1.0F));
        Assert.That(player.OPortalEffectIntensity, Is.EqualTo(1.0F));
    }

    /// <summary>The 0.05F steps leave 0.049999844F after nineteen, and the twentieth clamps to 0.</summary>
    [Test]
    public void LeavingThePortalFadesTheEffectOverTwentyTicks() {
        (MinecraftClient client, LocalPlayer player, ClientLevel level) = World(Block.NetherPortal.StateId);
        Ticks(client, 82);
        level.SetState(0, Floor, 0, 0);
        level.SetState(0, Floor + 1, 0, 0);
        int triggers = 0;
        player.PortalTriggered += _ => triggers++;
        // The last move in the portal marked it for this tick.
        client.Tick();
        Assert.That(player.PortalEffectIntensity, Is.EqualTo(1.0F));
        client.Tick();
        Assert.That(player.PortalEffectIntensity, Is.EqualTo(0.95F));
        Ticks(client, 18);
        Assert.That(player.PortalEffectIntensity, Is.EqualTo(0.049999844F));
        client.Tick();
        Assert.That(player.PortalEffectIntensity, Is.Zero);
        Assert.That(player.OPortalEffectIntensity, Is.EqualTo(0.049999844F));
        Assert.That(triggers, Is.Zero);
    }

    /// <summary>
    /// A player that arrived through a portal starts on the server's cooldown, which standing in the exit
    /// portal keeps topped up at <c>Player.getDimensionChangingDelay</c>, so no processor is made.
    /// </summary>
    [Test]
    public void TheCooldownKeepsTheEffectOffWhileThePlayerStaysInThePortal() {
        (MinecraftClient client, LocalPlayer player, _) = World(Block.NetherPortal.StateId);
        player.PortalCooldown = 10;
        Ticks(client, 100);
        Assert.That(player.PortalCooldown, Is.EqualTo(10));
        Assert.That(player.PortalProcess, Is.Null);
        Assert.That(player.PortalEffectIntensity, Is.Zero);
    }

    [Test]
    public void TheCooldownRunsOutOnceThePlayerIsOutOfThePortal() {
        (MinecraftClient client, LocalPlayer player, _) = World(0);
        player.PortalCooldown = 10;
        Ticks(client, 10);
        Assert.That(player.PortalCooldown, Is.Zero);
    }

    /// <summary>An end portal has no local transition, so standing in one holds a processor and shows nothing.</summary>
    [Test]
    public void AnEndPortalShowsNoEffect() {
        (MinecraftClient client, LocalPlayer player, _) = World(Block.EndPortal.StateId);
        Ticks(client, 20);
        Assert.That(player.PortalProcess, Is.Not.Null);
        Assert.That(player.ActivePortalLocalTransition, Is.EqualTo(PortalTransition.None));
        Assert.That(player.PortalEffectIntensity, Is.Zero);
    }
}

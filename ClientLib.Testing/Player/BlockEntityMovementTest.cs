using ClientLib.Maths;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Player;

/// <summary>
/// The block entity tickers that move the player, which run after the player's own tick so that what they add lands
/// in the next tick's move. Each expected figure is vanilla's arithmetic written out: <c>travelInAir</c> takes 0.08
/// gravity and keeps 0.98F, <c>LAUNCH_ENTITY_TICKER</c> adds 0.2F while the speed is under 0.3F and a tenth per
/// water block, and <c>moveCollidedEntities</c> moves by the lid's sweep plus 0.01.
/// </summary>
public class BlockEntityMovementTest {
    private const int Floor = 16;

    /// <summary>A stone floor, potent sulfur at the origin on it, water sources over that and anything else <paramref name="extra"/> places.</summary>
    private static (MinecraftClient Client, LocalPlayer Player) Geyser(PotentSulfurState state, int waterBlocks, Vec3d start,
        Func<int, int, int, uint?>? extra = null) {
        (MinecraftClient client, LocalPlayer player) = LocalPlayerMechanicsTest.World((x, y, z) =>
            extra?.Invoke(x, y, z) ?? (y < Floor ? Block.Stone.StateId : x == 0 && z == 0 && y > Floor && y <= Floor + waterBlocks ? Block.Water.StateId : 0),
            start);
        client.Dispatch(new ClientBoundBlockUpdatePacket {
            Location = new Vec3<int>(0, Floor, 0), Block = Block.PotentSulfur with { PotentSulfurState = state }
        });
        return (client, player);
    }

    /// <summary>
    /// One water block makes a column six blocks high from the water up, and a cap of 0.3F + 0.1. The player starts
    /// still in the air inside it: each tick falls by gravity and then gains 0.2F, until the speed after gravity is
    /// past the cap on the sixth tick.
    /// </summary>
    [Test]
    public void AnEruptingGeyserLiftsThePlayer() {
        (MinecraftClient client, LocalPlayer player) = Geyser(PotentSulfurState.Erupting, 1, new Vec3d(0.5, Floor + 3, 0.5));
        double y = Floor + 3, v = 0.0;
        bool capped = false;
        for (int tick = 0; tick < 6; tick++) {
            client.Tick();
            y += v;
            v = (v - 0.08) * 0.98F;
            if (v < 0.3F + 1 * 0.1) {
                v += 0.2F;
            }
            else {
                capped = true;
            }
            Assert.That(player.Position.Y, Is.EqualTo(y).Within(1e-12), $"tick {tick}");
            Assert.That(player.DeltaMovement.Y, Is.EqualTo(v).Within(1e-12), $"tick {tick}");
        }
        Assert.That(capped, Is.True);
        Assert.That(player.Position.Y, Is.GreaterThan(Floor + 4.7));
    }

    [Test]
    public void ADormantGeyserLeavesThePlayerToFall() {
        (MinecraftClient client, LocalPlayer player) = Geyser(PotentSulfurState.Dormant, 1, new Vec3d(0.5, Floor + 3, 0.5));
        client.Tick();
        client.Tick();
        double v = (0.0 - 0.08) * 0.98F;
        Assert.That(player.Position.Y, Is.EqualTo(Floor + 3 + v).Within(1e-12));
        Assert.That(player.DeltaMovement.Y, Is.EqualTo((v - 0.08) * 0.98F).Within(1e-12));
    }

    /// <summary><c>instanceof Player player &amp;&amp; player.getAbilities().flying</c>: a flying player hovers, its speed scaled by 0.6.</summary>
    [Test]
    public void AFlyingPlayerIsNotLifted() {
        (MinecraftClient client, LocalPlayer player) = Geyser(PotentSulfurState.Continuous, 1, new Vec3d(0.5, Floor + 3, 0.5));
        player.MayFly = true;
        player.Flying = true;
        for (int tick = 0; tick < 3; tick++) {
            client.Tick();
        }
        Assert.That(player.Position.Y, Is.EqualTo(Floor + 3));
        Assert.That(player.DeltaMovement.Y, Is.Zero);
    }

    /// <summary>
    /// <c>getUnobstructedBlockCount</c>: stone two blocks over the sulfur ends the column at the water and the air
    /// above it, so a player standing on the stone stays standing.
    /// </summary>
    [Test]
    public void ASolidBlockCapsTheColumn() {
        (MinecraftClient client, LocalPlayer player) = Geyser(PotentSulfurState.Erupting, 1, new Vec3d(0.5, Floor + 4, 0.5),
            (x, y, z) => x == 0 && z == 0 && y == Floor + 3 ? Block.Stone.StateId : null);
        for (int tick = 0; tick < 4; tick++) {
            client.Tick();
            Assert.That(player.Position.Y, Is.EqualTo(Floor + 4));
            Assert.That(player.DeltaMovement.Y, Is.EqualTo((0.0 - 0.08) * 0.98F).Within(1e-12));
        }
    }

    /// <summary>
    /// <c>checkFallDistanceAccumulation</c>: a player falling into the column keeps its fall until the lift has
    /// brought its speed above -0.5, when the fall is cut to one block. <c>checkFallDamage</c> adds the move as a float.
    /// </summary>
    [Test]
    public void TheColumnCutsAFallToOneBlock() {
        (MinecraftClient client, LocalPlayer player) = Geyser(PotentSulfurState.Erupting, 1, new Vec3d(0.5, Floor + 9, 0.5));
        double y = Floor + 9, v = 0.0, fall = 0.0;
        bool cut = false;
        for (int tick = 0; tick < 10; tick++) {
            client.Tick();
            y += v;
            if (v < 0.0) {
                fall -= (float)v;
            }
            v = (v - 0.08) * 0.98F;
            // The column is Floor + 1 to Floor + 7.
            if (y < Floor + 7) {
                if (v > -0.5 && fall > 1.0) {
                    fall = 1.0;
                    cut = true;
                }
                if (v < 0.3F + 1 * 0.1) {
                    v += 0.2F;
                }
            }
            Assert.That(player.Position.Y, Is.EqualTo(y).Within(1e-12), $"tick {tick}");
            Assert.That(player.DeltaMovement.Y, Is.EqualTo(v).Within(1e-12), $"tick {tick}");
            Assert.That(player.FallDistance, Is.EqualTo(fall).Within(1e-9), $"tick {tick}");
        }
        Assert.That(cut, Is.True);
    }

    /// <summary>
    /// <c>ShulkerBoxBlockEntity.moveCollidedEntities</c> sweeps the whole progress, 0.1 a tick, and moves the player by
    /// it plus 0.01, while the box's collision shape, its lid, rises by only half the progress. The player lands back
    /// on the lid each tick and comes to rest on it half a block up.
    /// </summary>
    [Test]
    public void AnOpeningShulkerBoxLiftsThePlayerOntoItsLid() {
        (MinecraftClient client, LocalPlayer player) = LocalPlayerMechanicsTest.World((x, y, z) => y < Floor ? Block.Stone.StateId : 0,
            new Vec3d(0.5, Floor + 1.2, 0.5));
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(0, Floor, 0), Block = Block.RedShulkerBox with { Facing = Cardinal.Up } });
        for (int tick = 0; tick < 5; tick++) {
            client.Tick();
        }
        Assert.That(player.Position.Y, Is.EqualTo(Floor + 1));
        client.Dispatch(new ClientBoundBlockActionPacket {
            Location = new Vec3<int>(0, Floor, 0), Block = Block.RedShulkerBox, ActionId = 1, ActionParameter = 1
        });

        // Shulker.getProgressDeltaAabb facing up spans 1 + the older progress to 1 + the newer, moved to the block.
        static double Sweep(float from, float to) => (1.0 + to + Floor) - (1.0 + from + Floor);

        client.Tick();
        double first = Floor + 1 + Sweep(0.0F, 0.1F) + 0.01;
        Assert.That(player.Position.Y, Is.EqualTo(first).Within(1e-12));

        client.Tick();
        // Falling 0.0784 from there lands on the lid at half of 0.1, and the next sweep moves the player on.
        double lid = 1.0 + 0.5F * 0.1F + Floor;
        Assert.That(first - 0.08 * 0.98F, Is.LessThan(lid));
        Assert.That(player.Position.Y, Is.EqualTo(lid + Sweep(0.1F, 0.1F + 0.1F) + 0.01).Within(1e-9));

        for (int tick = 0; tick < 40; tick++) {
            client.Tick();
        }
        Assert.That(player.Position.Y, Is.EqualTo(Floor + 1.5).Within(1e-9));
        Assert.That(player.OnGround, Is.True);
    }
}

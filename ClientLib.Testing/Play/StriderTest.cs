using ClientLib.Entities;
using ClientLib.Entities.Vehicles;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Play;

/// <summary>
/// A ridden strider on lava, against <c>LiquidBlock.getCollisionShape</c>, <c>Strider.floatStrider</c> and
/// <c>LivingEntity.travelInAir</c>, with the numbers worked by hand. A strider stands on lava, so it never
/// takes the fluid path: gravity is 0.08 and the vertical drag 0.98 as in air, the lava source under it
/// collides as <c>Block.column(16, 0, 8)</c> while its feet are above that half block, and while it is
/// in lava with its feet below the half block (or lava above it) <c>floatStrider</c> halves its motion and
/// adds 0.05.
/// </summary>
public class StriderTest {
    private const int PlayerId = 1;
    private const int StriderId = 20;
    private const int LavaBottom = 12;

    /// <summary>Stone up to y 12, lava sources from 12 up to <paramref name="lavaTop"/>, air above.</summary>
    private static (MinecraftClient Client, LocalPlayer Player) World(int lavaTop) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -2; cx <= 2; cx++) {
            for (int cz = -2; cz <= 2; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    int baseY = level.MinY + i * 16;
                    biomes[i] = new ushort[64];
                    uint[] states = new uint[ClientSection.Volume];
                    for (int y = 0; y < 16; y++) {
                        uint state = baseY + y < LavaBottom ? Block.Stone.StateId : baseY + y < lavaTop ? Block.Lava.StateId : 0;
                        for (int j = 0; j < 256; j++) {
                            states[y << 8 | j] = state;
                        }
                    }
                    sections[i] = new ClientSection(states, level.IsAir);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        // The tags as the server would synchronise them: the saddle's equippable component names the first,
        // and Strider.tick reads the second.
        client.Tags["minecraft:entity_type"] = new Dictionary<Identifier, int[]> {
            ["minecraft:can_equip_saddle"] = [VanillaRegistry.Data.EntityTypes.GetProtocolId(EntityType.Strider)]
        };
        client.Tags["minecraft:block"] = new Dictionary<Identifier, int[]> {
            ["minecraft:strider_warm_blocks"] = [VanillaRegistry.Data.Blocks.GetProtocolId(Block.Lava)]
        };
        LocalPlayer player = client.StartOffline(level, PlayerId);
        player.Position = new Vec3d(0.5, lavaTop + 2, 0.5);
        client.Inventory.SetInventorySlot(0, new ItemStack(Item.WarpedFungusOnAStick, 1));
        return (client, player);
    }

    private static ClientEntity Ride(MinecraftClient client, LocalPlayer player, Vec3d position) {
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = StriderId,
            Uuid = Guid.NewGuid(),
            EntityType = EntityType.Strider,
            Position = new Vec3<double>(position.X, position.Y, position.Z),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(0, 0, 0)
        });
        ClientEntity strider = client.Entities[StriderId];
        strider.Equipment[EquipmentSlot.Saddle] = new ItemStack(Item.Saddle, 1);
        client.HandlePassengers(new ClientBoundSetPassengersPacket { VehicleEntityId = StriderId, PassengerEntityIds = [PlayerId] });
        player.YRot = 0.0F;
        Assert.That(strider, Is.InstanceOf<ClientStrider>());
        Assert.That(strider.IsLocalInstanceAuthoritative, Is.True);
        return strider;
    }

    /// <summary>
    /// <c>Strider.getRiddenSpeed</c> on warm ground: the 0.175 movement speed times 0.55, the boost factor
    /// being 1.
    /// </summary>
    private static readonly float RiddenSpeed = (float)((double)0.175F * 0.55F * 1.0F);

    /// <summary>
    /// Dropped from a block above the surface of a pool four deep, it falls as in air until its feet pass
    /// the half block of the top lava source, which <c>LiquidBlock</c> gives it as a floor because its
    /// feet are above it and no lava is above that source. It lands at 15.5 and stays there.
    /// </summary>
    [Test]
    public void SettlesOnTheLavaSurface() {
        (MinecraftClient client, LocalPlayer player) = World(16);
        ClientEntity strider = Ride(client, player, new Vec3d(0.5, 16.0, 0.5));

        // y 16, 15.9216, 15.766368, 15.53584064, then the 0.3043 fall is cut short at 15.5.
        double y = 16.0, vy = 0.0;
        for (int tick = 1; tick <= 5; tick++) {
            client.Tick();
            y = Math.Max(y + vy, 15.5);
            vy = (vy - 0.08) * 0.98F;
            Assert.That(strider.Position.Y, Is.EqualTo(y).Within(1.0E-9), $"tick {tick}");
        }
        Assert.That(strider.Position.Y, Is.EqualTo(15.5));

        for (int tick = 0; tick < 40; tick++) {
            client.Tick();
            Assert.That(strider.Position.Y, Is.EqualTo(15.5));
        }
        ClientStrider ridden = (ClientStrider)strider;
        Assert.That(ridden.OnGround, Is.True);
        Assert.That(ridden.IsInLava, Is.True);
        Assert.That(ridden.IsSuffocating, Is.False);
    }

    /// <summary>
    /// Standing on the lava, ridden forward. The first tick it is not yet on the ground, so it moves at a
    /// tenth of its speed with the 0.91 air drag; <c>floatStrider</c> then grounds it, and from there it walks
    /// at full ridden speed with the 0.6 * 0.91 slowdown of the lava under the source it stands on.
    /// </summary>
    [Test]
    public void WalksForwardOnTheLava() {
        (MinecraftClient client, LocalPlayer player) = World(16);
        ClientEntity strider = Ride(client, player, new Vec3d(0.5, 15.5, 0.5));

        double z = 0.5, vz = 0.0;
        for (int tick = 1; tick <= 20; tick++) {
            client.Tick();
            if (tick == 1) {
                vz += RiddenSpeed * 0.1F;
                z += vz;
                vz *= 0.91F;
            }
            else {
                vz += RiddenSpeed;
                z += vz;
                vz *= 0.6F * 0.91F;
            }
            Assert.That(strider.Position.Y, Is.EqualTo(15.5), $"tick {tick}");
            Assert.That(strider.Position.Z, Is.EqualTo(z).Within(1.0E-9), $"tick {tick}");
        }
        Assert.That(strider.Position.X, Is.EqualTo(0.5));
        Assert.That(strider.Position.Z, Is.EqualTo(4.302038215538266).Within(1.0E-6));
        Assert.That(strider.OnGround, Is.True);
    }

    /// <summary>
    /// Deep in a lava column it rises: v' = ((v - 0.08) * 0.98) / 2 + 0.05 tends to 0.0108 / 0.51, about
    /// 0.0212 a tick, and once its feet clear the top source's half block it is grounded there.
    /// </summary>
    [Test]
    public void FloatsUpALavaColumn() {
        (MinecraftClient client, LocalPlayer player) = World(16);
        ClientEntity strider = Ride(client, player, new Vec3d(0.5, 13.0, -30.5));

        double y = 13.0, vy = 0.0;
        for (int tick = 1; tick <= 20; tick++) {
            client.Tick();
            y += vy;
            vy = (vy - 0.08) * 0.98F * 0.5 + 0.05;
            Assert.That(strider.Position.Y, Is.EqualTo(y).Within(1.0E-9), $"tick {tick}");
        }
        Assert.That(strider.DeltaMovement.Y, Is.EqualTo(vy).Within(1.0E-9));
        Assert.That(vy, Is.EqualTo(0.0108 / 0.51).Within(1.0E-6));

        for (int tick = 0; tick < 200; tick++) {
            client.Tick();
        }
        Assert.That(strider.Position.Y, Is.EqualTo(15.5));
        Assert.That(strider.OnGround, Is.True);
    }
}

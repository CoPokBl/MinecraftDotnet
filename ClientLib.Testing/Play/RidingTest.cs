using ClientLib.Entities;
using ClientLib.Entities.Vehicles;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace ClientLib.Testing.Play;

/// <summary>
/// Riding, against <c>ClientPacketListener.handleSetEntityPassengersPacket</c> and the vehicle physics
/// the rider's client runs, with the numbers worked by hand from <c>AbstractBoat</c> and
/// <c>LivingEntity.travelInAir</c>.
/// </summary>
public class RidingTest {
    private const int PlayerId = 1;
    private const int VehicleId = 20;
    private const int OtherId = 21;

    /// <summary>A world of stone up to y 16, or of stone to y 12 with still water from 12 to 16.</summary>
    private static (MinecraftClient Client, LocalPlayer Player) World(bool water) {
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
                        uint state = baseY + y < (water ? 12 : 16) ? Block.Stone.StateId : baseY + y < 16 ? Block.Water.StateId : 0;
                        for (int j = 0; j < 256; j++) {
                            states[y << 8 | j] = state;
                        }
                    }
                    sections[i] = new ClientSection(states, level.IsAir);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        // The tag a saddle's equippable component names, as the server would synchronise it.
        client.Tags["minecraft:entity_type"] = new Dictionary<Identifier, int[]> {
            ["minecraft:can_equip_saddle"] = [
                VanillaRegistry.Data.EntityTypes.GetProtocolId(EntityType.Horse), VanillaRegistry.Data.EntityTypes.GetProtocolId(EntityType.Nautilus)
            ]
        };
        LocalPlayer player = client.StartOffline(level, PlayerId);
        player.Position = new Vec3d(0.5, 16, 0.5);
        return (client, player);
    }

    private static ClientEntity Spawn(MinecraftClient client, IEntityType type, int id, Vec3d position) {
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = id,
            Uuid = Guid.NewGuid(),
            EntityType = type,
            Position = new Vec3<double>(position.X, position.Y, position.Z),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(0, 0, 0)
        });
        return client.Entities[id];
    }

    private static void Mount(MinecraftClient client, int vehicle, params int[] passengers) {
        client.HandlePassengers(new ClientBoundSetPassengersPacket { VehicleEntityId = vehicle, PassengerEntityIds = passengers });
    }

    [Test]
    public void PassengersPacketSeatsThePlayerAndSaysHowToGetOff() {
        (MinecraftClient client, LocalPlayer player) = World(true);
        ClientEntity boat = Spawn(client, EntityType.OakBoat, VehicleId, new Vec3d(4.5, 15.5, 4.5));
        boat.YRot = 30.0F;
        ClientEntity pig = Spawn(client, EntityType.Pig, OtherId, new Vec3d(6.5, 16, 6.5));

        Mount(client, VehicleId, PlayerId, OtherId);

        Assert.That(boat, Is.InstanceOf<ClientBoat>());
        Assert.That(player.Vehicle, Is.SameAs(boat));
        Assert.That(pig.Vehicle, Is.SameAs(boat));
        Assert.That(boat.PassengerList, Is.EqualTo(new[] { player, pig }));
        Assert.That(boat.Passengers, Is.EqualTo(new[] { PlayerId, OtherId }));
        Assert.That(boat.ControllingPassenger, Is.SameAs(player));
        Assert.That(boat.IsLocalInstanceAuthoritative, Is.True);
        // A boat turns a new rider to face its bow.
        Assert.That(player.YRot, Is.EqualTo(30.0F));
        Assert.That(client.ActionBar, Is.Not.Null);
        TextComponent expected = TextComponent.Translatable("mount.onboard", with: [TextComponent.Translatable("key.keyboard.left.shift")]);
        Assert.That(TextFlattener.Plain(client.ActionBar!), Is.EqualTo(TextFlattener.Plain(expected)));

        Mount(client, VehicleId, OtherId);
        Assert.That(player.Vehicle, Is.Null);
        Assert.That(boat.PassengerList, Is.EqualTo(new[] { pig }));
        Assert.That(boat.IsLocalInstanceAuthoritative, Is.False);
    }

    [Test]
    public void RemovingTheVehicleDropsItsPassengers() {
        (MinecraftClient client, LocalPlayer player) = World(false);
        Spawn(client, EntityType.Horse, VehicleId, new Vec3d(4.5, 16, 4.5));
        Mount(client, VehicleId, PlayerId);
        client.RemoveEntity(VehicleId);
        Assert.That(player.Vehicle, Is.Null);
        Assert.That(player.IsPassenger, Is.False);
    }

    /// <summary>
    /// <c>positionRider</c>: the boat's front seat is 0.2 forward when two ride, at a third of its height,
    /// less the player's 0.6 vehicle attachment, all turned with the boat.
    /// </summary>
    [Test]
    public void RidersSitInTheBoatsSeats() {
        (MinecraftClient client, LocalPlayer player) = World(true);
        ClientEntity boat = Spawn(client, EntityType.OakBoat, VehicleId, new Vec3d(4.5, 15.5, 4.5));
        boat.YRot = 90.0F;
        Spawn(client, EntityType.Pig, OtherId, new Vec3d(6.5, 16, 6.5));
        Mount(client, VehicleId, PlayerId, OtherId);

        boat.PositionRider(player);
        // Facing west, forward is -x.
        Assert.That(player.Position.X, Is.EqualTo(boat.Position.X - 0.2).Within(1.0E-6));
        Assert.That(player.Position.Y, Is.EqualTo(boat.Position.Y + 0.5625 / 3.0 - 0.6).Within(1.0E-6));
        Assert.That(player.Position.Z, Is.EqualTo(boat.Position.Z).Within(1.0E-6));
    }

    /// <summary>
    /// A boat rowed forward on still water. <c>floatBoat</c> keeps 0.9 of the speed each tick, and
    /// <c>controlBoat</c> adds 0.04 along the bow; the keys reach the boat a tick late, from
    /// <c>LocalPlayer.rideTick</c> after the boat has moved. Worked by hand: no push on the first tick, then
    /// v = 0.9v + 0.04 for the nineteen after, ending 4.486 blocks on at 0.346 a tick.
    /// </summary>
    [Test]
    public void BoatRowsForwardOnWater() {
        (MinecraftClient client, LocalPlayer player) = World(true);
        ClientEntity boat = Spawn(client, EntityType.OakBoat, VehicleId, new Vec3d(0.5, 15.5, 0.5));
        Mount(client, VehicleId, PlayerId);
        player.Input = new PlayerInput(Forward: true);

        for (int i = 0; i < 20; i++) {
            client.Tick();
        }

        Assert.That(boat.Position.X, Is.EqualTo(0.5));
        Assert.That(boat.Position.Z, Is.EqualTo(4.986306028541979).Within(1.0E-9));
        Assert.That(boat.DeltaMovement.Z, Is.EqualTo(0.3459658682723071).Within(1.0E-9));
        Assert.That(((ClientBoat)boat).PaddleState(0) && ((ClientBoat)boat).PaddleState(1), Is.True);
        // The boat floats where its buoyancy holds it, below the water's surface.
        Assert.That(boat.Position.Y, Is.InRange(15.45, 15.6));
        // The rider sits in it, a tick of the boat's own movement behind nothing.
        Assert.That(player.Position.Z, Is.EqualTo(boat.Position.Z).Within(1.0E-9));
    }

    /// <summary>
    /// A saddled horse ridden over stone. <c>getRiddenSpeed</c> is the movement speed attribute, which
    /// on friction 0.6 ground moves it 0.98 * 0.225 a tick before the 0.6 * 0.91 slowdown. The rider's
    /// input reaches the horse a tick late, so it stands still the first tick.
    /// </summary>
    [Test]
    public void HorseWalksAtItsMovementSpeedAttribute() {
        (MinecraftClient client, LocalPlayer player) = World(false);
        ClientEntity horse = Spawn(client, EntityType.Horse, VehicleId, new Vec3d(0.5, 16, 0.5));
        horse.Attributes.GetOrCreate(Minecraft.Data.Generated.Attribute.MovementSpeed).BaseValue = 0.22499999403953552;
        horse.Equipment[EquipmentSlot.Saddle] = new ItemStack(Item.Saddle, 1);
        // What set_entity_motion says of a mob standing on the ground: the 0.08 of gravity it lost, less drag.
        // Without it the first tick's move has nothing vertical, so the horse leaves the ground for a tick.
        horse.DeltaMovement = new Vec3d(0.0, -0.0784000015258789, 0.0);
        Mount(client, VehicleId, PlayerId);
        player.YRot = 0.0F;
        player.Input = new PlayerInput(Forward: true);

        for (int i = 0; i < 20; i++) {
            client.Tick();
        }

        Assert.That(player.Zza, Is.EqualTo(0.98F).Within(1.0E-6F));
        double speed = (float)0.22499999403953552;
        double friction = 0.6F * 0.91F;
        double z = 0.5, vz = 0.0;
        for (int tick = 2; tick <= 20; tick++) {
            vz += player.Zza * speed;
            z += vz;
            vz *= friction;
        }
        Assert.That(horse.Position.X, Is.EqualTo(0.5));
        Assert.That(horse.Position.Y, Is.EqualTo(16.0));
        Assert.That(horse.Position.Z, Is.EqualTo(z).Within(1.0E-9));
        Assert.That(horse.Position.Z, Is.EqualTo(9.143877370474849).Within(1.0E-5));
        Assert.That(horse.OnGround, Is.True);
        // The rider sits 1.44375 up the horse, less its own 0.6.
        Assert.That(player.Position.Y, Is.EqualTo(16.0 + 1.443750023841858 - 0.6).Within(1.0E-6));
    }

    /// <summary>An unsaddled horse is ridden but not steered: the client leaves it to the server.</summary>
    [Test]
    public void UnsaddledHorseIsNotSteered() {
        (MinecraftClient client, LocalPlayer player) = World(false);
        ClientEntity horse = Spawn(client, EntityType.Horse, VehicleId, new Vec3d(0.5, 16, 0.5));
        Mount(client, VehicleId, PlayerId);
        player.Input = new PlayerInput(Forward: true);
        for (int i = 0; i < 10; i++) {
            client.Tick();
        }
        Assert.That(horse.IsLocalInstanceAuthoritative, Is.False);
        Assert.That(horse.Position, Is.EqualTo(new Vec3d(0.5, 16, 0.5)));
        Assert.That(player.JumpableVehicle, Is.Null);
    }

    /// <summary>
    /// <c>Mob.isSaddled</c> asks <c>canUseSlot</c>, which a nautilus only allows once tamed: an untamed one
    /// wearing a saddle stays the server's to move, or the two sides would each wait for the other.
    /// </summary>
    [Test]
    public void SaddleOnAnUntamedNautilusDoesNotSteer() {
        (MinecraftClient client, LocalPlayer _) = World(true);
        ClientEntity nautilus = Spawn(client, EntityType.Nautilus, VehicleId, new Vec3d(0.5, 13, 0.5));
        nautilus.Equipment[EquipmentSlot.Saddle] = new ItemStack(Item.Saddle, 1);
        Mount(client, VehicleId, PlayerId);
        Assert.That(nautilus.IsLocalInstanceAuthoritative, Is.False);

        nautilus.Metadata[EntityDataFields.TamableAnimal.Flags.Index] = new MetaField<sbyte>(MetaFieldType.Byte, 4);
        Assert.That(nautilus.IsLocalInstanceAuthoritative, Is.True);
    }

    /// <summary><c>LocalPlayer.aiStep</c>'s jump bar: ten ticks to 0.9, then easing back toward 0.8.</summary>
    [Test]
    public void JumpBarChargesWhileJumpIsHeld() {
        (MinecraftClient client, LocalPlayer player) = World(false);
        ClientEntity horse = Spawn(client, EntityType.Horse, VehicleId, new Vec3d(0.5, 16, 0.5));
        horse.Equipment[EquipmentSlot.Saddle] = new ItemStack(Item.Saddle, 1);
        Mount(client, VehicleId, PlayerId);
        client.Tick();
        player.Input = new PlayerInput(Jump: true);
        client.Tick();
        Assert.That(player.JumpRidingScale, Is.Zero);
        for (int i = 0; i < 5; i++) {
            client.Tick();
        }
        Assert.That(player.JumpRidingScale, Is.EqualTo(0.5F).Within(1.0E-6F));
        for (int i = 0; i < 6; i++) {
            client.Tick();
        }
        Assert.That(player.JumpRidingScale, Is.EqualTo(0.8F + 2.0F / 2 * 0.1F).Within(1.0E-6F));
    }
}

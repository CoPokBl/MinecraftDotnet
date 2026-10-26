using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Damage;

/// <summary>
/// What a hit looks like on the client that took it. The red flash, the camera tilt and the hurt
/// sound are all <c>hurtTime</c>, and the client sets it from two different packets:
/// <c>handleDamageEvent</c> for a hit that broadcast one, and <c>LocalPlayer.hurtTo</c> for any drop
/// in the health <see cref="ClientBoundSetHealthPacket"/> carries.
/// <p/>
/// The second is the only one a hit topped up inside the invulnerable window gets, since vanilla
/// broadcasts no damage event for one, so a player must be able to see their own health fall. That
/// is why an entity is never sent its own entity data: health rides in it, and the client reads its
/// own health straight off it.
/// </summary>
[TestFixture]
public class DamageFeedbackTest {
    /// <summary>Keeps what was sent, so a fixture can say which packets carried the hit.</summary>
    private sealed class RecordingConnection : PlayerConnection {
        public readonly List<MinecraftPacket> Sent = [];

        protected override void SendPacketInternal(MinecraftPacket packet) => Sent.Add(packet);
        public override void InitialiseEncryption() { }
        public override Task HandlePackets() => Task.CompletedTask;
        public override void Disconnect() { }
    }

    private ManagedMinecraftServer _server = null!;
    private World _world = null!;
    private Player _player = null!;
    private RecordingConnection _connection = null!;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { };
        _world = _server.CreateWorld(new VoidProvider(), "minecraft:overworld", new FullBrightLightingProvider());
        _world.LoadChunk(new Vec2<int>(0, 0)).Wait();

        _connection = new RecordingConnection();
        _player = new Player(_server, _connection, "tester") {
            Position = new Vec3<double>(8.5, 64, 8.5)
        };
        _player.SetWorld(_world);
        _connection.Sent.Clear();
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    /// <summary>The window is counted against the tick counter, which nothing moves in a test.</summary>
    private void AdvanceTicks(int count) {
        typeof(ManagedMinecraftServer)
            .GetProperty(nameof(ManagedMinecraftServer.CurrentTick))!
            .SetValue(_server, _server.CurrentTick + (ulong)count);
    }

    private T? LastSent<T>() where T : MinecraftPacket => _connection.Sent.OfType<T>().LastOrDefault();

    /// <summary>
    /// <c>ChunkMap.TrackedEntity.updatePlayer</c> returns early for the tracked entity itself, so a
    /// player is never in their own <c>seenBy</c> and never hears about their own entity data.
    /// <p/>
    /// Sending it anyway is silent and costs the whole hurt animation: the client's health is the
    /// value in that data, so it is already at the new one when <c>hurtTo</c> subtracts, and the
    /// difference it plays the flash and the tilt from comes out as zero.
    /// </summary>
    [Test]
    public void APlayerIsNotSentTheirOwnEntityData() {
        _player.Damage(new DamageSource(DamageType.Fall), 3f);

        Assert.That(_connection.Sent.OfType<ClientBoundSetEntityMetadataPacket>().ToArray(), Is.Empty);
    }

    /// <summary>The health the hit left, which is what the client works the hurt animation out from.</summary>
    [Test]
    public void TheHealthUpdateCarriesTheDrop() {
        _player.Damage(new DamageSource(DamageType.Fall), 3f);

        ClientBoundSetHealthPacket? health = LastSent<ClientBoundSetHealthPacket>();
        Assert.That(health, Is.Not.Null);
        Assert.That(health.Health, Is.EqualTo(17f));
    }

    /// <summary>
    /// A hit inside the invulnerable window lands for the difference and, as in vanilla, broadcasts
    /// no damage event. The health update is all the client gets, so it has to be a real drop.
    /// </summary>
    [Test]
    public void AToppedUpHitStillTellsTheClientItsHealthFell() {
        _player.Damage(new DamageSource(DamageType.Fall), 3f);
        AdvanceTicks(2);
        _connection.Sent.Clear();

        _player.Damage(new DamageSource(DamageType.Fall), 8f);

        Assert.Multiple(() => {
            Assert.That(_connection.Sent.OfType<ClientBoundDamageEventPacket>().ToArray(), Is.Empty,
                "a hit inside the window broadcast a damage event");
            Assert.That(LastSent<ClientBoundSetHealthPacket>()?.Health, Is.EqualTo(12f));
        });
    }

    /// <summary>
    /// The damage event still goes to the player as well as to whoever can see them: vanilla's
    /// <c>ServerLevel.broadcastDamageEvent</c> is <c>sendToTrackingPlayersAndSelf</c>, and it is what
    /// carries the hurt sound and the damage type.
    /// </summary>
    [Test]
    public void TheDamageEventGoesToThePlayerThatTookTheHit() {
        _player.Damage(new DamageSource(DamageType.Fall), 3f);

        ClientBoundDamageEventPacket? damage = LastSent<ClientBoundDamageEventPacket>();
        Assert.That(damage, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(damage.EntityId, Is.EqualTo(_player.NetId));
            Assert.That(damage.SourceType.Identifier, Is.EqualTo(DamageType.Fall.Identifier));
        });
    }

    /// <summary>Someone watching still gets the entity data, which is where their health lives.</summary>
    [Test]
    public void AWatchingPlayerIsStillSentTheEntityData() {
        RecordingConnection watcherConnection = new();
        Player watcher = new(_server, watcherConnection, "watcher") {
            Position = new Vec3<double>(9.5, 64, 8.5)
        };
        watcher.SetWorld(_world);
        watcherConnection.Sent.Clear();

        _player.Damage(new DamageSource(DamageType.Fall), 3f);

        Assert.That(watcherConnection.Sent.OfType<ClientBoundSetEntityMetadataPacket>().ToArray(),
            Is.Not.Empty);
    }
}

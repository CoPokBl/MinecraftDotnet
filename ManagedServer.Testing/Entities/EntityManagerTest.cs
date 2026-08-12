using ManagedServer.Entities;
using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Entities;

public class EntityManagerTest {

    [Test]
    public void EntitiesInRangeTest() {
        EntityManager manager = new(new EventNode<IServerEvent>(), 128);
        Entity entity1 = new(EntityType.AcaciaBoat) {
            Position = new Vec3<double>(0, 0, 0)
        };
        Entity entity2 = new(EntityType.AcaciaBoat) {
            Position = new Vec3<double>(10, 0, 0)
        };
        Entity entity3 = new(EntityType.AcaciaBoat) {
            Position = new Vec3<double>(0, 0, 10)
        };
        manager.Register(entity1);
        manager.Register(entity2);
        manager.Register(entity3);
        
        Entity[] nearbyEntities = manager.GetNearbyEntities(new Vec3<double>(0, 0, 0), 15);
        Assert.That(nearbyEntities, Has.Length.EqualTo(3));
        
        Entity entity4 = new(EntityType.AcaciaBoat) {
            Position = new Vec3<double>(20, 0, 0)
        };
        manager.Register(entity4);
        
        nearbyEntities = manager.GetNearbyEntities(new Vec3<double>(0, 0, 0), 15);
        Assert.That(nearbyEntities, Has.Length.EqualTo(3));
    }
    
    [Test]
    public void EntitiesInRangeFarTest() {
        EntityManager manager = new(new EventNode<IServerEvent>(), 128);
        Entity entity1 = new(EntityType.AcaciaBoat) {
            Position = new Vec3<double>(-10, 0, 0)
        };
        Entity entity2 = new(EntityType.AcaciaBoat) {
            Position = new Vec3<double>(1000, 0, 1000)
        };
        Entity entity3 = new(EntityType.AcaciaBoat) {
            Position = new Vec3<double>(1000, 0, 1000)
        };
        manager.Register(entity1);
        manager.Register(entity2);
        manager.Register(entity3);
        
        Entity[] nearbyEntities = manager.GetNearbyEntities(new Vec3<double>(990, 0, 1010), 150);
        Assert.That(nearbyEntities, Has.Length.EqualTo(2));
        
        Entity entity4 = new(EntityType.AcaciaBoat) {
            Position = new Vec3<double>(200, 0, 0)
        };
        manager.Register(entity4);
        
        nearbyEntities = manager.GetNearbyEntities(new Vec3<double>(190, 0, 10), 150);
        Assert.That(nearbyEntities, Has.Length.EqualTo(1));
    }

    /// <summary>
    /// Zero is vanilla's "id not assigned yet". An entity sent with it kills the connection as
    /// soon as the client touches the entity, so the very first id a world hands out matters.
    /// </summary>
    [Test]
    public void NetIdsAreNeverZero() {
        EntityManager manager = new(new EventNode<IServerEvent>(), 128);

        for (int i = 0; i < 5; i++) {
            Entity entity = new(EntityType.AcaciaBoat) {
                Position = new Vec3<double>(0, 0, 0)
            };
            manager.Register(entity);
            Assert.That(entity.NetId, Is.Not.Zero);
        }
    }
}

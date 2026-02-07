using System.Diagnostics;
using ManagedServer.Entities;
using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;
using Minecraft.Schemas.Vec;

namespace Tests;

public class EntitiesTest {

    [Test]
    public void EntitiesInRangeTest() {
        IEntityManager manager = new EntityManager(new EventNode<IServerEvent>(), 128);
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
        IEntityManager manager = new EntityManager(new EventNode<IServerEvent>(), 128);
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

    [Test]
    public void EntityLookupSpeedTest() {
        const int amount = 10_000;
        const int queries = 1_000;
        
        EntityManager manager = new(new EventNode<IServerEvent>(), 16*16);
        for (int i = 0; i < amount; i++) {
            Entity entity = new(EntityType.AcaciaBoat) {
                Position = RandomPos()
            };
            manager.Register(entity);
        }
        
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < queries; i++) {
            manager.GetNearbyEntities(RandomPos(), 64);
        }
        stopwatch.Stop();
        Console.WriteLine($"Looked up {queries} times in {stopwatch.ElapsedMilliseconds}ms");

        return;

        Vec3<double> RandomPos() => new(
            Random.Shared.Next(-1000, 1000), 
            Random.Shared.Next(0, 256), 
            Random.Shared.Next(-1000, 1000));
    }
}

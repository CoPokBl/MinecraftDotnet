using System.Diagnostics;
using ManagedServer.Entities;
using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;
using Minecraft.Schemas.Vec;

namespace Tests;

public class EntitiesTest {
    
    [Test]
    public void GetChunksInRadius() {
        for (int i = 0; i < 12; i++) {
            IEntityManager.GetChunksInRadius(i);
        }
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

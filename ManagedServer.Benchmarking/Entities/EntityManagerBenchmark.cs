using BenchmarkDotNet.Attributes;
using ManagedServer.Entities;
using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Benchmarking.Entities;

public class EntityManagerBenchmark {
    private EntityManager _manager = null!;
    private Random _random = null!;
    
    private Vec3<double> RandomPos() => new(
        _random.Next(-1000, 1000), 
        _random.Next(0, 256), 
        _random.Next(-1000, 1000));
    
    [IterationSetup(Target = "EntityLookupSpeed")]
    public void SetupEntityLookupSpeed() {
        const int amount = 10_000;
        _random = new Random(123456);
        _manager = new EntityManager(new EventNode<IServerEvent>(), 16*16);
        for (int i = 0; i < amount; i++) {
            Entity entity = new(EntityType.AcaciaBoat) {
                Position = RandomPos()
            };
            _manager.Register(entity);
        }
    }
    
    private const int LookupIterations = 20_000;
    [Benchmark(OperationsPerInvoke = LookupIterations)]
    public void EntityLookupSpeed() {
        for (int i = 0; i < LookupIterations; i++) {
            _manager.GetNearbyEntities(RandomPos(), 64);
        }
    }
}

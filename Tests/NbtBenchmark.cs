using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Minecraft;
using NBT;
using NBT.Tags;

namespace Tests;

[MemoryDiagnoser]
[SimpleJob(warmupCount: 3, iterationCount: 10)]
public class NbtBenchmark {
    private byte[] _simpleNbtData = null!;
    private byte[] _complexNbtData = null!;
    private byte[] _nestedNbtData = null!;
    private CompoundTag _simpleTag = null!;
    private CompoundTag _complexTag = null!;
    private CompoundTag _nestedTag = null!;

    [GlobalSetup]
    public void Setup() {
        // Create simple NBT structure (player-like data)
        var playerData = new CompoundTag("", [
            new StringTag("Name", "TestPlayer"),
            new IntegerTag("Level", 42),
            new FloatTag("Health", 20.0f),
            new DoubleTag("X", 100.5),
            new DoubleTag("Y", 64.0),
            new DoubleTag("Z", 200.5)
        ]);
        _simpleTag = new CompoundTag("", [playerData]);
        _simpleNbtData = _simpleTag.Serialise();

        // Create complex NBT structure (inventory-like data)
        var inventoryItems = new List<INbtTag>();
        for (int i = 0; i < 36; i++) {
            inventoryItems.Add(new CompoundTag(null, [
                new ByteTag("Slot", (sbyte)i),
                new StringTag("id", "minecraft:stone"),
                new ByteTag("Count", (sbyte)(i % 64 + 1)),
                new CompoundTag("tag", [
                    new IntegerTag("Damage", i * 10),
                    new ByteTag("Unbreakable", 1)
                ])
            ]));
        }
        var inventoryData = new CompoundTag("", [
            new StringTag("Name", "PlayerInventory"),
            new ListTag("Items", inventoryItems.ToArray())
        ]);
        _complexTag = new CompoundTag("", [inventoryData]);
        _complexNbtData = _complexTag.Serialise();

        // Create deeply nested NBT structure
        CompoundTag deepestLevel = new CompoundTag("level10", [
            new StringTag("data", "deepest"),
            new IntegerTag("depth", 10)
        ]);
        
        CompoundTag currentLevel = deepestLevel;
        for (int i = 9; i >= 0; i--) {
            currentLevel = new CompoundTag($"level{i}", [
                new IntegerTag("depth", i),
                new StringTag("data", $"level_{i}"),
                currentLevel
            ]);
        }
        _nestedTag = new CompoundTag("", [currentLevel]);
        _nestedNbtData = _nestedTag.Serialise();
    }

    [Benchmark]
    public INbtTag DeserializeSimple() {
        return NbtReader.ReadNbt(_simpleNbtData, true);
    }

    [Benchmark]
    public byte[] SerializeSimple() {
        return _simpleTag.Serialise();
    }

    [Benchmark]
    public INbtTag DeserializeComplex() {
        return NbtReader.ReadNbt(_complexNbtData, true);
    }

    [Benchmark]
    public byte[] SerializeComplex() {
        return _complexTag.Serialise();
    }

    [Benchmark]
    public INbtTag DeserializeNested() {
        return NbtReader.ReadNbt(_nestedNbtData, true);
    }

    [Benchmark]
    public byte[] SerializeNested() {
        return _nestedTag.Serialise();
    }

    [Benchmark]
    public INbtTag RoundTripSimple() {
        byte[] serialized = _simpleTag.Serialise();
        return NbtReader.ReadNbt(serialized, true);
    }

    [Benchmark]
    public INbtTag RoundTripComplex() {
        byte[] serialized = _complexTag.Serialise();
        return NbtReader.ReadNbt(serialized, true);
    }
    
    [Benchmark]
    public byte[] SerializeViaDataWriter() {
        return new DataWriter().WriteNbt(_simpleTag).ToArray();
    }
    
    [Benchmark]
    public INbtTag DeserializeViaDataReader() {
        return new DataReader(_simpleNbtData).ReadNbt();
    }
}

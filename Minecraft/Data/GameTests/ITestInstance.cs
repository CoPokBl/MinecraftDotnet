using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.GameTests;

/// <summary>One game test: where it runs, how long it gets, and how it decides it passed.</summary>
public interface ITestInstance : IProtocolType {
    /// <summary>Which kind of test this is.</summary>
    public Identifier Type { get; }

    public TestData Data { get; }

    /// <summary>The fields this kind adds on top of <see cref="Data"/>.</summary>
    protected (string, INbtTag)[] ExtraFields { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [("type", new StringTag(Type.ToString()))];
        children.AddRange(Data.ToFields());
        children.AddRange(ExtraFields);
        return new CompoundTag(children.ToArray());
    }

    public static ITestInstance FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        Identifier type = tag["type"]!.GetString();
        TestData data = TestData.FromNbt(tag);

        return type.ToString() switch {
            "minecraft:block_based" => new BlockBasedTestInstance(ident, data),
            "minecraft:function" => new FunctionTestInstance(ident, data, tag["function"]!.GetString()),
            _ => throw new ArgumentException($"Unknown test instance type {type}", nameof(tag))
        };
    }
}

/// <summary>A test that passes when the test blocks in its structure say so.</summary>
public record BlockBasedTestInstance(Identifier Identifier, TestData Data) : ITestInstance {
    public Identifier Type => "minecraft:block_based";
    (string, INbtTag)[] ITestInstance.ExtraFields => [];
}

/// <summary>A test driven by a registered test function.</summary>
public record FunctionTestInstance(
    Identifier Identifier,
    TestData Data,
    Identifier Function) : ITestInstance {

    public Identifier Type => "minecraft:function";

    (string, INbtTag)[] ITestInstance.ExtraFields => [
        ("function", new StringTag(Function.ToString()))
    ];
}

/// <param name="Environment">The test environment entry this runs under.</param>
/// <param name="Structure">The structure template placed before the test starts.</param>
/// <param name="MaxTicks">How long the test may run before it's failed.</param>
/// <param name="SetupTicks">Ticks of grace before the test starts being judged.</param>
/// <param name="Required">Whether failing this test fails the whole run.</param>
/// <param name="ManualOnly">Whether it's skipped unless someone asks for it by name.</param>
/// <param name="SkyAccess">Whether the test area is left open to the sky.</param>
/// <param name="Padding">Empty blocks left around the structure.</param>
public record TestData(
    Identifier Environment,
    Identifier Structure,
    int MaxTicks,
    int SetupTicks = 0,
    bool Required = true,
    StructureRotation Rotation = StructureRotation.None,
    bool ManualOnly = false,
    int MaxAttempts = 1,
    int RequiredSuccesses = 1,
    bool SkyAccess = false,
    int Padding = 0) {

    public (string, INbtTag)[] ToFields() {
        List<(string, INbtTag)> fields = [
            ("environment", new StringTag(Environment.ToString())),
            ("structure", new StringTag(Structure.ToString())),
            ("max_ticks", new IntegerTag(MaxTicks))
        ];

        if (SetupTicks != 0) {
            fields.Add(("setup_ticks", new IntegerTag(SetupTicks)));
        }

        if (!Required) {
            fields.Add(("required", new BooleanTag(false)));
        }

        if (Rotation != StructureRotation.None) {
            fields.Add(("rotation", new StringTag(Rotation.ToProtocolString())));
        }

        if (ManualOnly) {
            fields.Add(("manual_only", new BooleanTag(true)));
        }

        if (MaxAttempts != 1) {
            fields.Add(("max_attempts", new IntegerTag(MaxAttempts)));
        }

        if (RequiredSuccesses != 1) {
            fields.Add(("required_successes", new IntegerTag(RequiredSuccesses)));
        }

        if (SkyAccess) {
            fields.Add(("sky_access", new BooleanTag(true)));
        }

        if (Padding != 0) {
            fields.Add(("padding", new IntegerTag(Padding)));
        }

        return fields.ToArray();
    }

    public static TestData FromNbt(CompoundTag tag) {
        return new TestData(
            tag["environment"]!.GetString(),
            tag["structure"]!.GetString(),
            tag["max_ticks"]!.GetInteger(),
            tag.Contains("setup_ticks") ? tag["setup_ticks"]!.GetInteger() : 0,
            !tag.Contains("required") || tag["required"]!.GetBoolean(),
            tag.Contains("rotation")
                ? StructureRotationExtensions.ParseStructureRotation(tag["rotation"]!.GetString())
                : StructureRotation.None,
            tag.Contains("manual_only") && tag["manual_only"]!.GetBoolean(),
            tag.Contains("max_attempts") ? tag["max_attempts"]!.GetInteger() : 1,
            tag.Contains("required_successes") ? tag["required_successes"]!.GetInteger() : 1,
            tag.Contains("sky_access") && tag["sky_access"]!.GetBoolean(),
            tag.Contains("padding") ? tag["padding"]!.GetInteger() : 0);
    }
}

public enum StructureRotation {
    None,
    Clockwise90,
    Clockwise180,
    Counterclockwise90
}

public static class StructureRotationExtensions {
    public static string ToProtocolString(this StructureRotation rotation) => rotation switch {
        StructureRotation.None => "none",
        StructureRotation.Clockwise90 => "clockwise_90",
        StructureRotation.Clockwise180 => "180",
        StructureRotation.Counterclockwise90 => "counterclockwise_90",
        _ => throw new ArgumentOutOfRangeException(nameof(rotation), rotation, null)
    };

    public static StructureRotation ParseStructureRotation(string value) => value switch {
        "none" => StructureRotation.None,
        "clockwise_90" => StructureRotation.Clockwise90,
        "180" => StructureRotation.Clockwise180,
        "counterclockwise_90" => StructureRotation.Counterclockwise90,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown structure rotation")
    };
}

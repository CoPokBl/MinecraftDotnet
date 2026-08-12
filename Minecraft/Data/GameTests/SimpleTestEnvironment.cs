using Minecraft.Schemas;

namespace Minecraft.Data.GameTests;

public record SimpleTestEnvironment(
    Identifier Identifier,
    TestEnvironmentDefinition Definition) : ITestEnvironment;

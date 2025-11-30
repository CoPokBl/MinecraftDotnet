namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// A terrain generator that uses a lambda/delegate for generation.
/// This provides a convenient way to create terrain generators without
/// implementing the full interface.
/// </summary>
/// <example>
/// <code>
/// var generator = new LambdaTerrainGenerator(unit => {
///     var start = unit.AbsoluteStart();
///     
///     // Create a snow carpet
///     unit.Modifier().FillHeight(-64, -60, Block.Snow);
///     
///     // Fork to add a tall structure
///     var fork = unit.Fork(start, start + new Vec3&lt;int&gt;(16, 32, 16));
///     fork.Modifier().Fill(start, start + new Vec3&lt;int&gt;(3, 19, 3), Block.PowderSnow);
/// });
/// </code>
/// </example>
public class LambdaTerrainGenerator : ITerrainGenerator {
    private readonly Action<IGenerationUnit> _generator;

    /// <summary>
    /// Creates a new LambdaTerrainGenerator with the specified generation action.
    /// </summary>
    /// <param name="generator">The action that generates terrain for a generation unit.</param>
    public LambdaTerrainGenerator(Action<IGenerationUnit> generator) {
        _generator = generator;
    }

    /// <inheritdoc />
    public void Generate(IGenerationUnit unit) {
        _generator(unit);
    }
}

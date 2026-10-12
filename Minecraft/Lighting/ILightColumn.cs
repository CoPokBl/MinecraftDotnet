namespace Minecraft.Lighting;

/// <summary>
/// A chunk's blocks as a store other than <see cref="Minecraft.Schemas.Chunks.ChunkData"/> holds them,
/// for <see cref="CalculatedLightingProvider"/> to light without converting them first.
/// </summary>
public interface ILightColumn {
    int SectionCount { get; }

    LightSection Section(int index);
}

/// <summary>
/// One section's states, indexed <c>y &lt;&lt; 8 | z &lt;&lt; 4 | x</c>: a single state, or a palette with
/// each block's index into it, or each block's state. The arrays are read, never kept or written.
/// </summary>
public readonly record struct LightSection(uint Uniform, ushort[]? Palette, int PaletteSize, byte[]? Indices, ushort[]? States) {
    public bool IsUniform => Indices == null && States == null;
}

namespace Minecraft.Schemas;

public record ChunkPosition(int X, int Z) {

    public bool IsWithinRadiusOf(ChunkPosition other, int radius) {
        return Math.Abs(X - other.X) <= radius && Math.Abs(Z - other.Z) <= radius;
    }

    public virtual bool Equals(ChunkPosition? other) {
        return X == other?.X && Z == other.Z;
    }
}
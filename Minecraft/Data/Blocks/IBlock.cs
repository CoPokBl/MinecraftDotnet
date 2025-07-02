using Minecraft.Schemas;

namespace Minecraft.Data.Blocks;

public interface IBlock {
    public uint StateId { get; }
    public Identifier Identifier { get; }

    public IBlock GetState(uint state);

    public bool Equals(IBlock? other) {
        return other?.StateId == StateId;
    }
    
    public static bool Equals(IBlock? b1, IBlock? b2) {
        if (b1 is null && b2 is null) return true;
        if (b1 is null || b2 is null) return false;
        return b1.Equals(b2);
    }
}

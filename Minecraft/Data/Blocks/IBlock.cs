using Minecraft.Schemas;
using NBT.Tags;

namespace Minecraft.Data.Blocks;

public interface IBlock {
    public uint StateId { get; }
    public Identifier Identifier { get; }

    public IBlock WithState(uint state);
    public IBlock WithState(CompoundTag properties);

    public bool Equals(IBlock? other) {
        return other?.StateId == StateId;
    }
    
    public static bool Equals(IBlock? b1, IBlock? b2) {
        if (b1 is null && b2 is null) return true;
        if (b1 is null || b2 is null) return false;
        return b1.Equals(b2);
    }
}

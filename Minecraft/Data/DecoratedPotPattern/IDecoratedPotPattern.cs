using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.DecoratedPotPattern;

/// <summary>The face a sherd puts on a decorated pot.</summary>
public interface IDecoratedPotPattern : IProtocolType {
    public Identifier AssetId { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(("asset_id", new StringTag(AssetId.ToString())));
    }

    public static IDecoratedPotPattern FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleDecoratedPotPattern(ident, tag["asset_id"].GetString());
    }
}

public record SimpleDecoratedPotPattern(Identifier Identifier, Identifier AssetId) : IDecoratedPotPattern;

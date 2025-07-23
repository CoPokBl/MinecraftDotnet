using Minecraft.Schemas;

namespace Minecraft.Data.BlockEntityTypes;

public record SimpleBlockEntityType(Identifier Identifier, int ProtocolId) : IBlockEntityType;

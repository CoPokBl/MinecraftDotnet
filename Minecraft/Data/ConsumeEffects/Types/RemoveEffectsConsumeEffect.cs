using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;

namespace Minecraft.Data.ConsumeEffects.Types;

public record RemoveEffectsConsumeEffect(Identifier Identifier, int ProtocolId, IdSet? Effects = null) : IConsumeEffect {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(Effects ?? new IdSet.Ids([]), registry);
    }

    public IConsumeEffect ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            Effects = reader.Read<IdSet>(registry)
        };
    }
}

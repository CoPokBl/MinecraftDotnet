using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ConsumeEffects.Types;

public record RemoveEffectsConsumeEffect(Identifier Identifier, int ProtocolId, IdSet? Effects = null) : IConsumeEffect {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(w => (Effects ?? new IdSet.Ids([])).Write(w));
    }

    public IConsumeEffect ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            Effects = IdSet.Read(reader)
        };
    }
}

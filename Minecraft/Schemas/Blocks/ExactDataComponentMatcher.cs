using Minecraft.Data.Components;
using Minecraft.Registry;

namespace Minecraft.Schemas.Blocks;

public record ExactDataComponentMatcher(IDataComponent Component) {
    public void Write(DataWriter writer, MinecraftRegistry registry) {
        writer.WriteVarInt(registry.DataComponents[Component.Identifier])
            .Write(w => Component.WriteData(w, registry));
    }
    
    public static ExactDataComponentMatcher Read(DataReader reader, MinecraftRegistry registry) {
        int id = reader.ReadVarInt();
        IDataComponent component = registry.DataComponents[id];
        return new ExactDataComponentMatcher(component.ReadData(reader, registry));
    }
}

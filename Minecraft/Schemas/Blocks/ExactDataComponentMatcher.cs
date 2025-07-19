using Minecraft.Data.Components;
using Minecraft.Registry;

namespace Minecraft.Schemas.Blocks;

public record ExactDataComponentMatcher(IDataComponent Component, object Value) {
    public void Write(DataWriter writer, MinecraftRegistry registry) {
        writer.WriteVarInt(Component.ProtocolId)
            .Write(w => Component.WriteData(Value, w, registry));
    }
    
    public static ExactDataComponentMatcher Read(DataReader reader, MinecraftRegistry registry) {
        int id = reader.ReadVarInt();
        IDataComponent component = registry.DataComponents[id];
        return new ExactDataComponentMatcher(component, component.ReadData(reader, registry));
    }
}

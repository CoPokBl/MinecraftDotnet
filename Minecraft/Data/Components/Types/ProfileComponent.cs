using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record ProfileComponent(int ProtocolId) : IDataComponent<ProfileComponent.Data> {
    public override Identifier Identifier => "minecraft:profile";

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WritePrefixedOptional(val.Name, (s, wr) => wr.WriteString(s))
            .WritePrefixedOptional(val.UniqueId, (guid, wr) => wr.WriteUuid(guid))
            .WritePrefixedArray(val.Properties, registry);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(
            reader.ReadPrefixedOptional(r => r.ReadString()),
            reader.ReadPrefixedOptional(r => r.ReadUuid()),
            reader.ReadPrefixedArray(r => ProfileProperty.ReadData(r, registry))
        );
    }
    
    public record Data(string? Name, Guid? UniqueId, ProfileProperty[] Properties);
}

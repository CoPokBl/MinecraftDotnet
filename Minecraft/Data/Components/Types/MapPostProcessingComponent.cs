using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// What the client does to the map the next time it is handed one. The component is network only,
/// so it is a one shot instruction rather than state.
/// </summary>
public record MapPostProcessingComponent() : IDataComponent<MapPostProcessing> {
    public override Identifier Identifier => "minecraft:map_post_processing";

    /// <summary>
    /// None. <b>Vanilla marks this component transient</b>, so it has no persistent form to port:
    /// it is a one shot instruction consumed as the map is made, and no datapack or saved stack ever carries one.
    /// </summary>
    public override NbtCodec<MapPostProcessing>? Codec => null;

    public override DataWriter WriteData(MapPostProcessing val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (MapPostProcessing)reader.ReadVarInt();
    }

    public override bool ValuesEqual(MapPostProcessing val1, MapPostProcessing val2) {
        return val1 == val2;
    }
}

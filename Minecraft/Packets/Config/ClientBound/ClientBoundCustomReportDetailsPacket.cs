using Minecraft.Data;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundCustomReportDetailsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:custom_report_details";
    
    public required Detail[] Details;

    public record Detail(string Title, string Description) : INetworkType<Detail> {
        public DataWriter WriteData(DataWriter writer, MinecraftRegistry _) {
            return writer
                .WriteString(Title)
                .WriteString(Description);
        }

        public static Detail ReadData(DataReader reader, MinecraftRegistry _) {
            return new Detail(reader.ReadString(), reader.ReadString());
        }
    }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WritePrefixedArray(Details, reg);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundCustomReportDetailsPacket {
        Details = r.ReadPrefixedArray<Detail>(reg)
    };
}

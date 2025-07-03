using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundCustomReportDetailsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:custom_report_details";
    
    public required Detail[] Details;

    public record Detail(string Title, string Description) : IWritable {
        public void Write(DataWriter writer) {
            writer
                .WriteString(Title)
                .WriteString(Description);
        }

        public static Detail Read(DataReader reader) {
            return new Detail(reader.ReadString(), reader.ReadString());
        }
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePrefixedArray(Details, (detail, w) => w.Write(detail))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundCustomReportDetailsPacket {
        Details = r.ReadPrefixedArray(Detail.Read)
    };
}

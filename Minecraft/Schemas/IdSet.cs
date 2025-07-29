using Minecraft.Data;
using Minecraft.Registry;

namespace Minecraft.Schemas;

public abstract record IdSet : INetworkType<IdSet> {
    
    public static IdSet ReadData(DataReader reader, MinecraftRegistry _) {
        int length = reader.ReadVarInt();
        if (length == 0) {
            return new Tag(reader.ReadString());
        }
        
        int valsCount = length - 1;
        int[] vals = reader.ReadArray(valsCount, r => r.ReadVarInt());
        return new Ids(vals);
    }

    public record Tag(Identifier TagName) : IdSet {
        public override DataWriter WriteData(DataWriter writer, MinecraftRegistry reg) {
            return writer.WriteVarInt(0).Write(TagName);
        }
    }

    public record Ids(int[] Values) : IdSet {
        public override DataWriter WriteData(DataWriter writer, MinecraftRegistry reg) {
            return writer.WriteVarInt(Values.Length + 1).WriteArray(Values, (i, w) => w.WriteVarInt(i));
        }
    }

    public static Ids FromProtocolTypes(params IProtocolType[] protocolTypes) {
        return new Ids(protocolTypes.Select(t => t.ProtocolId).ToArray());
    }

    public abstract DataWriter WriteData(DataWriter writer, MinecraftRegistry reg);
}

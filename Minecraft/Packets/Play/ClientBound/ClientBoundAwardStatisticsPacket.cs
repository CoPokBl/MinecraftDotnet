using Minecraft.Data;
using Minecraft.Data.Blocks;
using Minecraft.Data.CustomStatistics;
using Minecraft.Data.Entities;
using Minecraft.Data.Items;
using Minecraft.Data.StatisticTypes;
using Minecraft.Registry;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundAwardStatisticsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:award_stats";

    public record Entry(
        IStatisticType Category,
        int Statistic,
        int Value) {

        public Entry(IStatisticType category, IProtocolType stat, int val) : this(category, stat.ProtocolId, val) { }

        public T GetStatistic<TReg, T>(ProtocolTypeRegistry<TReg, T> registry) where TReg : ProtocolTypeRegistry<TReg, T> where T : IProtocolType {
            return registry[Statistic];
        }

        public T GetStatistic<T>(MinecraftRegistry registry) where T : IProtocolType {
            return registry.Get<T>(Statistic);
        }
        
        public IBlock GetBlock(MinecraftRegistry registry) {
            return GetStatistic<IBlock>(registry);
        }
        
        public IItem GetItem(MinecraftRegistry registry) {
            return GetStatistic<IItem>(registry);
        }
        
        public IEntityType GetEntityType(MinecraftRegistry registry) {
            return GetStatistic<IEntityType>(registry);
        }
        
        public ICustomStatistic GetCustomStatistic(MinecraftRegistry registry) {
            return GetStatistic<ICustomStatistic>(registry);
        }
    }
    
    public required Entry[] Statistics { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w.WritePrefixedArray(Statistics, (entry, wr) => wr
            .WriteVarInt(entry.Category.ProtocolId)
            .WriteVarInt(entry.Statistic)
            .WriteVarInt(entry.Value));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundAwardStatisticsPacket {
        Statistics = r.ReadPrefixedArray(re => new Entry(
            reg.Get<IStatisticType>(re.ReadVarInt()),
            re.ReadVarInt(),
            re.ReadVarInt()
        ))
    };
}

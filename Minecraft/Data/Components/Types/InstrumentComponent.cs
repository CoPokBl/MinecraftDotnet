using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Instrument;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>The note a goat horn sounds.</summary>
public record InstrumentComponent() : IDataComponent<IInstrument> {
    public override Identifier Identifier => "minecraft:instrument";

    public override NbtCodec<IInstrument>? Codec => Persistent;
    private static readonly NbtCodec<IInstrument> Persistent = NbtCodecs.Holder<IInstrument>("minecraft:instrument", reg => reg.Instruments);

    public override DataWriter WriteData(IInstrument val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteHolder(val, registry.Instruments, (inline, w) => w.Write(inline, registry));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadHolder(id => registry.Instruments[id], r => IInstrument.ReadData(r, registry));
    }

    public override bool ValuesEqual(IInstrument val1, IInstrument val2) {
        return val1.Identifier == val2.Identifier;
    }
}

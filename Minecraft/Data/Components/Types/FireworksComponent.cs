using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>What a firework rocket carries: how long it flies and what it does at the top.</summary>
public record FireworksComponent() : IDataComponent<FireworksComponent.Data> {
    public override Identifier Identifier => "minecraft:fireworks";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, registry) => new CompoundBuilder()
            .Int("flight_duration", val.FlightDuration, 0)
            .ListOrOmit("explosions", val.Explosions,
                explosion => FireworkExplosionComponent.Persistent.ToNbt(explosion, registry))
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:fireworks");
            Data data = new(
                node.Int("flight_duration", 0),
                node.List("explosions",
                    explosion => FireworkExplosionComponent.Persistent.FromNbt(explosion, registry)));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(val.FlightDuration)
            .WritePrefixedArray(val.Explosions, (e, w) => FireworkExplosionComponent.Write(e, w));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(reader.ReadVarInt(), reader.ReadPrefixedArray(FireworkExplosionComponent.Read));
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Equals(val2);
    }

    /// <param name="FlightDuration">Roughly the number of seconds of gunpowder in the rocket.</param>
    public record Data(int FlightDuration = 0, FireworkExplosionComponent.Data[]? Explosions = null) {
        public FireworkExplosionComponent.Data[] Explosions { get; init; } = Explosions ?? [];

        public virtual bool Equals(Data? other) {
            return other != null && FlightDuration == other.FlightDuration &&
                   Explosions.SequenceEqual(other.Explosions);
        }

        public override int GetHashCode() {
            return HashCode.Combine(FlightDuration, Explosions.Length);
        }
    }
}

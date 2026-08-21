using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>What a lodestone compass points at.</summary>
public record LodestoneTrackerComponent() : IDataComponent<LodestoneTrackerComponent.Data> {
    public override Identifier Identifier => "minecraft:lodestone_tracker";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Maybe("target", val.Target, target => new CompoundBuilder()
                .Id("dimension", target.Dimension)
                .Tag("pos", new ArrayTag<int>(target.Position.X, target.Position.Y, target.Position.Z))
                .Build())
            .Bool("tracked", val.Tracked, true)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:lodestone_tracker");

            Data data = new(
                node.ObjectOrNull("target", target => {
                    Identifier dimension = target.Id("dimension");
                    ReadOnlySpan<int> pos = target.Require("pos").GetIntegers();
                    target.AssertRead();
                    return new GlobalPosition(dimension, new Vec3<int>(pos[0], pos[1], pos[2]));
                }),
                node.Bool("tracked", true));

            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WritePrefixedOptional(val.Target, (target, w) => w.Write(target.Dimension).WritePosition(target.Position))
            .WriteBoolean(val.Tracked);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(
            reader.ReadPrefixedOptional(r => new GlobalPosition(r.ReadString(), r.ReadPosition())),
            reader.ReadBoolean());
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }

    /// <param name="Tracked">
    /// Whether the server checks the lodestone is still there. An untracked compass keeps pointing at
    /// the spot whatever happens to the block.
    /// </param>
    public record Data(GlobalPosition? Target, bool Tracked = true);

    public record GlobalPosition(Identifier Dimension, Vec3<int> Position);
}

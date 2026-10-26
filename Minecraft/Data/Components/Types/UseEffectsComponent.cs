using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>What holding the item up does to its user, vanilla's <c>UseEffects</c>.</summary>
public record UseEffectsComponent() : IDataComponent<UseEffectsComponent.Data> {
    public override Identifier Identifier => "minecraft:use_effects";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Bool("can_sprint", val.CanSprint, false)
            .Bool("interact_vibrations", val.InteractVibrations, true)
            .Float("speed_multiplier", val.SpeedMultiplier, 0.2f)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:use_effects");
            Data data = new(
                node.Bool("can_sprint", false),
                node.Bool("interact_vibrations", true),
                node.Float("speed_multiplier", 0.2f));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteBoolean(val.CanSprint)
            .WriteBoolean(val.InteractVibrations)
            .WriteFloat(val.SpeedMultiplier);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(reader.ReadBoolean(), reader.ReadBoolean(), reader.ReadFloat());
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }

    /// <param name="SpeedMultiplier">What the user's walking speed is scaled by while using it.</param>
    public record Data(bool CanSprint = false, bool InteractVibrations = true, float SpeedMultiplier = 0.2f) {
        /// <summary>Vanilla's own defaults, which every item carries unless it says otherwise.</summary>
        public static Data Default => new();
    }
}

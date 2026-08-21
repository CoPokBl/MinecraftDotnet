using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// What an item is as a weapon, vanilla's <c>Weapon</c>. Only two things, and the interesting one is
/// <see cref="Data.DisableBlockingForSeconds"/>: an axe disabling a shield is this field being five
/// rather than anything written about axes.
/// </summary>
public record WeaponComponent() : IDataComponent<WeaponComponent.Data> {
    public override Identifier Identifier => "minecraft:weapon";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Int("item_damage_per_attack", val.ItemDamagePerAttack, 1)
            .Float("disable_blocking_for_seconds", val.DisableBlockingForSeconds, 0f)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:weapon");
            Data data = new(
                node.Int("item_damage_per_attack", 1),
                node.Float("disable_blocking_for_seconds", 0f));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(val.ItemDamagePerAttack)
            .WriteFloat(val.DisableBlockingForSeconds);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(reader.ReadVarInt(), reader.ReadFloat());
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Equals(val2);
    }

    /// <param name="ItemDamagePerAttack">Durability an attack costs the weapon.</param>
    /// <param name="DisableBlockingForSeconds">
    /// How long hitting a blocking entity takes their blocking item out of use. Zero for everything
    /// but axes, which carry vanilla's <see cref="AxeDisablesBlockingForSeconds"/>.
    /// </param>
    public record Data(int ItemDamagePerAttack, float DisableBlockingForSeconds) {
        public static Data Default => new(1, 0f);
    }

    /// <summary><c>Weapon.AXE_DISABLES_BLOCKING_FOR_SECONDS</c>.</summary>
    public const float AxeDisablesBlockingForSeconds = 5f;
}

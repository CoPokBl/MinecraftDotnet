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

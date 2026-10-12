using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.SulfurCubeArchetype;

/// <summary>
/// One flavour of sulfur cube: which items turn into it, and how the resulting cube behaves once
/// it's in the world.
/// </summary>
public interface ISulfurCubeArchetype : IProtocolType {
    /// <summary>The items that place a cube of this archetype.</summary>
    public HolderSet Items { get; }

    public SulfurCubeAttributeEntry[] AttributeModifiers { get; }

    /// <summary>Whether the cube floats.</summary>
    public bool Buoyant { get; }

    public SulfurCubeExplosion? Explosion { get; }
    public SulfurCubeContactDamage? ContactDamage { get; }
    public SulfurCubeKnockbackModifiers KnockbackModifiers { get; }
    public SulfurCubeSoundSettings SoundSettings { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("items", Items.ToNbt()),
            ("attribute_modifiers", new ListTag<CompoundTag>(AttributeModifiers
                .Select(a => (CompoundTag)a.ToNbt())
                .ToArray())),
            ("knockback_modifiers", KnockbackModifiers.ToNbt()),
            ("sound_settings", SoundSettings.ToNbt())
        ];

        if (Buoyant) {
            children.Add(("buoyant", new BooleanTag(true)));
        }

        if (Explosion != null) {
            children.Add(("explosion", Explosion.ToNbt()));
        }

        if (ContactDamage != null) {
            children.Add(("contact_damage", ContactDamage.ToNbt()));
        }

        return new CompoundTag(children.ToArray());
    }

    public static ISulfurCubeArchetype FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleSulfurCubeArchetype(
            ident,
            HolderSet.FromNbt(tag["items"]!),
            tag["attribute_modifiers"]!.AsList()
                .Select(t => SulfurCubeAttributeEntry.FromNbt(t, reg))
                .ToArray(),
            tag.Contains("buoyant") && tag["buoyant"]!.AsBool(),
            tag.Contains("explosion") ? SulfurCubeExplosion.FromNbt(tag["explosion"]!) : null,
            tag.Contains("contact_damage")
                ? SulfurCubeContactDamage.FromNbt(tag["contact_damage"]!, reg)
                : null,
            SulfurCubeKnockbackModifiers.FromNbt(tag["knockback_modifiers"]!),
            SulfurCubeSoundSettings.FromNbt(tag["sound_settings"]!, reg));
    }
}

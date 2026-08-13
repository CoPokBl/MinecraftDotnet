using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnchantmentEffects.Types;

/// <summary>
/// <c>minecraft:damage_protection</c>: how many protection points an enchantment is worth against a
/// hit, which is what the Magic stage of the damage pipeline spends. The four protection enchantments
/// and feather falling all work through this.
/// <p/>
/// Vanilla's requirements are full loot conditions, and this parses only the shape the vanilla
/// enchantments actually use: a <c>damage_source_properties</c> condition testing damage type tags,
/// optionally wrapped in an <c>all_of</c>. Anything else throws rather than being read as no
/// requirement at all, which would turn fire protection into plain protection.
/// </summary>
public record DamageProtectionEnchantmentEffect(DamageProtectionEnchantmentEffect.Entry[] Entries)
    : IEnchantmentEffectImpl {
    public string Id => "minecraft:damage_protection";

    /// <summary>
    /// One conditional grant of protection points. <see cref="Requirements"/> all have to hold for
    /// <see cref="Amount"/> to count, and an empty set always holds.
    /// </summary>
    public record Entry(ILevelBasedValue Amount, Requirement[] Requirements);

    /// <summary>
    /// A damage type tag the hit has to be in, or has to be out of when <see cref="Expected"/> is
    /// false. Every vanilla protection enchantment excludes <c>minecraft:bypasses_invulnerability</c>
    /// this way, and the specialised ones additionally require their own tag.
    /// </summary>
    public record Requirement(Identifier Tag, bool Expected);

    public static IEnchantmentEffect ParseData(INbtTag tag, MinecraftRegistry reg) {
        return new DamageProtectionEnchantmentEffect(tag.GetList().Tags
            .ToArray()
            .Select(t => ParseEntry(t.GetCompound()))
            .ToArray());
    }

    private static Entry ParseEntry(CompoundTag compound) {
        CompoundTag effect = compound["effect"].GetCompound();
        Identifier type = effect["type"].GetString();
        if (type.Key != "add") {
            // Only add appears on the vanilla enchantments. Multiply and the rest would have to be
            // applied differently, so guessing at one is worse than stopping here.
            throw new ArgumentException("Unsupported damage_protection value effect: " + type);
        }

        List<Requirement> requirements = [];
        if (compound.Contains("requirements")) {
            ParseCondition(compound["requirements"].GetCompound(), requirements);
        }

        return new Entry(ILevelBasedValue.FromNbt(effect["value"].ThrowIfNull()), requirements.ToArray());
    }

    private static void ParseCondition(CompoundTag condition, List<Requirement> into) {
        Identifier type = condition["condition"].GetString();
        switch (type.Key) {
            case "all_of":
                foreach (INbtTag term in condition["terms"].GetList().Tags.ToArray()) {
                    ParseCondition(term.GetCompound(), into);
                }

                return;

            case "damage_source_properties":
                foreach (INbtTag entry in condition["predicate"].GetCompound()["tags"].GetList().Tags.ToArray()) {
                    CompoundTag tag = entry.GetCompound();
                    into.Add(new Requirement(tag["id"].GetString(), tag["expected"].GetBoolean()));
                }

                return;

            default:
                throw new ArgumentException("Unsupported damage_protection requirement: " + type);
        }
    }

    /// <summary>
    /// Written back as one flat <c>damage_source_properties</c> per entry rather than in whatever
    /// nesting it arrived in. That is the same condition to vanilla's codec, which is what matters:
    /// this travels to the client as part of the enchantment registry.
    /// </summary>
    public INbtTag SerialiseData() {
        return new ListTag(Entries.Select(INbtTag (entry) => {
            List<(string, INbtTag)> children = [
                ("effect", new CompoundTag(
                    ("type", new StringTag("minecraft:add")),
                    ("value", entry.Amount.ToNbt())))
            ];

            if (entry.Requirements.Length > 0) {
                children.Add(("requirements", new CompoundTag(
                    ("condition", new StringTag("minecraft:damage_source_properties")),
                    ("predicate", new CompoundTag(
                        ("tags", new ListTag(entry.Requirements.Select(INbtTag (r) => new CompoundTag(
                            ("id", new StringTag(r.Tag)),
                            ("expected", new BooleanTag(r.Expected)))).ToArray())))))));
            }

            return new CompoundTag(children.ToArray());
        }).ToArray());
    }
}

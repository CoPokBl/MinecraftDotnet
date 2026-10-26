using Minecraft.Schemas.Tags;
using Minecraft.Data;
using Minecraft.Data.Components;
using Minecraft.Data.Items;
using Minecraft.Data.TrimPattern;
using Minecraft.Registry;
using Minecraft.Schemas.Items;

namespace Minecraft.Schemas.Recipes;

/// <summary>
/// What the recipe book draws in one slot of a recipe. It isn't a fixed item: a slot can stand
/// for a whole tag, or for a demonstration the client animates through, so the client resolves it
/// to a rotating list of stacks rather than a single one.
/// </summary>
public abstract record SlotDisplay : INetworkType<SlotDisplay> {
    /// <summary>Key of this kind in the slot display registry.</summary>
    public abstract Identifier Type { get; }

    protected abstract void WriteContents(DataWriter w, MinecraftRegistry reg);

    public DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        w.WriteVarInt(reg.SlotDisplayTypes.GetProtocolId(Type));
        WriteContents(w, reg);
        return w;
    }

    public static SlotDisplay ReadData(DataReader r, MinecraftRegistry reg) {
        Identifier type = reg.SlotDisplayTypes[r.ReadVarInt()].Identifier;
        return type.ToString() switch {
            "minecraft:empty" => Empty.Instance,
            "minecraft:any_fuel" => AnyFuel.Instance,
            "minecraft:item" => new Item(reg.Items[r.ReadVarInt()]),
            "minecraft:item_stack" => new Stack(ItemStack.ReadTemplateData(r, reg)),
            "minecraft:tag" => new Tag(r.Read<IdSet>(reg)),
            "minecraft:with_any_potion" => new WithAnyPotion(ReadData(r, reg)),
            "minecraft:only_with_component" => new OnlyWithComponent(ReadData(r, reg), reg.DataComponents[r.ReadVarInt()]),
            "minecraft:dyed" => new Dyed(ReadData(r, reg), ReadData(r, reg)),
            "minecraft:smithing_trim" => new SmithingTrim(
                ReadData(r, reg),
                ReadData(r, reg),
                r.ReadIdOr(id => reg.TrimPatterns[id].Identifier, reader => ReadDirectTrimPattern(reader))),
            "minecraft:with_remainder" => new WithRemainder(ReadData(r, reg), ReadData(r, reg)),
            "minecraft:composite" => new Composite(r.ReadPrefixedArray(reader => ReadData(reader, reg))),
            _ => throw new ArgumentException($"Unknown slot display type {type}", nameof(r))
        };
    }

    /// <summary>Draws nothing, used for the slots a recipe leaves unused.</summary>
    public record Empty : SlotDisplay {
        public static readonly Empty Instance = new();

        public override Identifier Type => "minecraft:empty";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) { }
    }

    /// <summary>Cycles through every item that can fuel a furnace.</summary>
    public record AnyFuel : SlotDisplay {
        public static readonly AnyFuel Instance = new();

        public override Identifier Type => "minecraft:any_fuel";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) { }
    }

    /// <summary>A single item, with no components.</summary>
    public record Item(IItem Value) : SlotDisplay {
        public override Identifier Type => "minecraft:item";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.WriteVarInt(reg.Items.GetProtocolId(Value));
        }
    }

    /// <summary>A stack with a count and components, such as an enchanted book.</summary>
    public record Stack(ItemStack Value) : SlotDisplay {
        public override Identifier Type => "minecraft:item_stack";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            Value.WriteTemplateData(w, reg);
        }
    }

    /// <summary>
    /// Cycles through every item in a set: an item tag, or the items listed inline, which is how
    /// <c>Ingredient.display</c> shows every ingredient.
    /// </summary>
    public record Tag(IdSet Items) : SlotDisplay {
        public override Identifier Type => "minecraft:tag";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.Write(Items, reg);
        }
    }

    /// <summary>Cycles the inner display through every potion variant.</summary>
    public record WithAnyPotion(SlotDisplay Display) : SlotDisplay {
        public override Identifier Type => "minecraft:with_any_potion";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.Write(Display, reg);
        }
    }

    /// <summary>Keeps only those stacks of the inner display that carry a given component.</summary>
    public record OnlyWithComponent(SlotDisplay Source, IDataComponent Component) : SlotDisplay {
        public override Identifier Type => "minecraft:only_with_component";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.Write(Source, reg)
                .WriteVarInt(reg.DataComponents.GetProtocolId(Component));
        }
    }

    /// <summary>Shows the target dyed with each dye, as the crafting book does for leather armour.</summary>
    public record Dyed(SlotDisplay Dye, SlotDisplay Target) : SlotDisplay {
        public override Identifier Type => "minecraft:dyed";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.Write(Dye, reg).Write(Target, reg);
        }
    }

    /// <summary>Shows the base armour wearing the trim, for the smithing table's preview.</summary>
    /// <param name="Pattern">
    /// Either the key of a trim pattern in the trim pattern registry, or one sent inline.
    /// </param>
    public record SmithingTrim(SlotDisplay Base, SlotDisplay Material, Or<Identifier, ITrimPattern> Pattern)
        : SlotDisplay {
        public override Identifier Type => "minecraft:smithing_trim";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.Write(Base, reg).Write(Material, reg);

            Or<int, ITrimPattern> idOr = Pattern.IsValue1
                ? Or<int, ITrimPattern>.FromValue1(reg.TrimPatterns.GetProtocolId(Pattern.Value1))
                : Or<int, ITrimPattern>.FromValue2(Pattern.Value2!);
            w.WriteIdOr(idOr, (pattern, writer) => writer
                .Write(pattern.AssetId)
                .WriteNbt(pattern.Description)
                .WriteBoolean(pattern.Decal));
        }
    }

    /// <summary>Pairs an input with what is left of it after crafting, such as a bucket.</summary>
    public record WithRemainder(SlotDisplay Input, SlotDisplay Remainder) : SlotDisplay {
        public override Identifier Type => "minecraft:with_remainder";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.Write(Input, reg).Write(Remainder, reg);
        }
    }

    /// <summary>Cycles through several displays in turn.</summary>
    public record Composite(SlotDisplay[] Contents) : SlotDisplay {
        public override Identifier Type => "minecraft:composite";

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.WritePrefixedArray(Contents, reg);
        }

        public virtual bool Equals(Composite? other) {
            return other != null && Contents.SequenceEqual(other.Contents);
        }

        public override int GetHashCode() {
            return Contents.Length;
        }
    }

    private static ITrimPattern ReadDirectTrimPattern(DataReader r) {
        // An inline trim pattern has no registry key, so it gets a placeholder.
        return new SimpleTrimPattern("minecraft:inline_trim_pattern", r.ReadString(), r.ReadText(), r.ReadBoolean());
    }
}

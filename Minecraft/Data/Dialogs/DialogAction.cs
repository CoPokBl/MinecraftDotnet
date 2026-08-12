using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Dialogs;

/// <summary>What pressing a dialog button does.</summary>
public abstract record DialogAction {
    public abstract Identifier Type { get; }

    protected abstract (string, INbtTag)[] Fields { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [("type", new StringTag(Type.ToString()))];
        children.AddRange(Fields);
        return new CompoundTag(children.ToArray());
    }

    public static DialogAction FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        Identifier type = compound["type"]!.GetString();

        switch (type.ToString()) {
            case "minecraft:dynamic/run_command":
                return new RunCommandTemplate(compound["template"]!.GetString());

            case "minecraft:dynamic/custom":
                return new Custom(
                    compound["id"]!.GetString(),
                    compound.Contains("additions") ? (CompoundTag)compound["additions"]! : null);

            default:
                // Everything else is a click event wearing the dialog's discriminator, so it can
                // be carried without knowing which one it is
                return new Static(type, compound.Children
                    .Where(c => c.Item1 != "type")
                    .ToArray());
        }
    }

    /// <summary>
    /// A click event, the same set a text component can carry. The action's own name is the type,
    /// so <c>minecraft:open_url</c> here is the <c>open_url</c> click event.
    /// </summary>
    public record Static(Identifier ActionType, (string Key, INbtTag Value)[] Values) : DialogAction {
        public override Identifier Type => ActionType;
        protected override (string, INbtTag)[] Fields => Values.Select(v => (v.Key, v.Value)).ToArray();

        public virtual bool Equals(Static? other) {
            return other != null && ActionType == other.ActionType && Values.SequenceEqual(other.Values);
        }

        public override int GetHashCode() => HashCode.Combine(ActionType, Values.Length);
    }

    /// <summary>
    /// Runs a command built from the dialog's inputs, with <c>$(key)</c> standing in for the value
    /// the player gave for that input.
    /// </summary>
    public record RunCommandTemplate(string Template) : DialogAction {
        public override Identifier Type => "minecraft:dynamic/run_command";
        protected override (string, INbtTag)[] Fields => [("template", new StringTag(Template))];
    }

    /// <summary>
    /// Sends the dialog's inputs back to the server as a custom payload, along with anything in
    /// <paramref name="Additions"/>.
    /// </summary>
    public record Custom(Identifier Id, CompoundTag? Additions) : DialogAction {
        public override Identifier Type => "minecraft:dynamic/custom";

        protected override (string, INbtTag)[] Fields => Additions == null
            ? [("id", new StringTag(Id.ToString()))]
            : [("id", new StringTag(Id.ToString())), ("additions", Additions)];
    }
}

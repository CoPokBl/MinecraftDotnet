using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Dialogs;

/// <summary>Something shown in the middle of a dialog, above its buttons.</summary>
public abstract record DialogBody {
    public abstract Identifier Type { get; }

    protected abstract (string, INbtTag)[] Fields { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [("type", new StringTag(Type.ToString()))];
        children.AddRange(Fields);
        return new CompoundTag(children.ToArray());
    }

    public static DialogBody FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        Identifier type = compound["type"]!.GetString();

        return type.ToString() switch {
            "minecraft:plain_message" => PlainMessage.FromFields(compound),
            "minecraft:item" => new ItemBody(
                DialogItem.FromNbt(compound["item"]!),
                compound["description"] switch {
                    null => null,
                    CompoundTag fields => PlainMessage.FromFields(fields),
                    { } text => new PlainMessage(TextComponent.FromTag(text))
                },
                !compound.Contains("show_decorations") || compound["show_decorations"]!.AsBool(),
                !compound.Contains("show_tooltip") || compound["show_tooltip"]!.AsBool(),
                compound.Contains("width") ? compound["width"]!.AsInt() : 16,
                compound.Contains("height") ? compound["height"]!.AsInt() : 16),
            _ => throw new ArgumentException($"Unknown dialog body type {type}", nameof(tag))
        };
    }

    /// <summary>Reads a body list, which is written unwrapped when there's only one of them.</summary>
    public static DialogBody[] ListFromNbt(INbtTag tag) {
        return tag.AsCompactList().Select(FromNbt).ToArray();
    }

    public static INbtTag ListToNbt(DialogBody[] bodies) {
        return bodies.Length == 1
            ? bodies[0].ToNbt()
            : new ListTag<CompoundTag>(bodies.Select(b => (CompoundTag)b.ToNbt()).ToArray());
    }

    /// <param name="Width">How wide the text is allowed to get before it wraps.</param>
    public record PlainMessage(TextComponent Contents, int Width = 200) : DialogBody {
        public override Identifier Type => "minecraft:plain_message";

        protected override (string, INbtTag)[] Fields => Width == 200
            ? [("contents", Contents.SerialiseToTag())]
            : [("contents", Contents.SerialiseToTag()), ("width", new IntegerTag(Width))];

        /// <summary>The same fields without the type, which is how an item body's description is written.</summary>
        public CompoundTag ToFieldsNbt() {
            return new CompoundTag(Fields);
        }

        public static PlainMessage FromFields(CompoundTag compound) {
            // A bare text component is accepted wherever these fields are, and vanilla's codec
            // falls back to reading one when there's no contents field
            if (!compound.Contains("contents")) {
                return new PlainMessage(TextComponent.FromTag(compound));
            }

            return new PlainMessage(
                TextComponent.FromTag(compound["contents"]!),
                compound.Contains("width") ? compound["width"]!.AsInt() : 200);
        }
    }

    /// <param name="ShowDecorations">Whether the count and durability bar are drawn.</param>
    /// <param name="ShowTooltip">Whether hovering the item shows its tooltip.</param>
    public record ItemBody(
        DialogItem Item,
        PlainMessage? Description = null,
        bool ShowDecorations = true,
        bool ShowTooltip = true,
        int Width = 16,
        int Height = 16) : DialogBody {

        public override Identifier Type => "minecraft:item";

        protected override (string, INbtTag)[] Fields {
            get {
                List<(string, INbtTag)> fields = [("item", Item.ToNbt())];

                if (Description != null) {
                    fields.Add(("description", Description.ToFieldsNbt()));
                }

                if (!ShowDecorations) {
                    fields.Add(("show_decorations", new BooleanTag(false)));
                }

                if (!ShowTooltip) {
                    fields.Add(("show_tooltip", new BooleanTag(false)));
                }

                if (Width != 16) {
                    fields.Add(("width", new IntegerTag(Width)));
                }

                if (Height != 16) {
                    fields.Add(("height", new IntegerTag(Height)));
                }

                return fields.ToArray();
            }
        }
    }
}

/// <summary>The item an <see cref="DialogBody.ItemBody"/> draws.</summary>
/// <param name="Components">
/// The component patch applied on top of the item's defaults, kept as it was read. Data components
/// only have a wire form on our side, and the data form written here isn't the same shape, so
/// there's nothing to decode them into yet.
/// </param>
public record DialogItem(Identifier Id, int Count = 1, CompoundTag? Components = null) {

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [("id", new StringTag(Id.ToString()))];

        if (Count != 1) {
            children.Add(("count", new IntegerTag(Count)));
        }

        if (Components != null) {
            children.Add(("components", Components));
        }

        return new CompoundTag(children.ToArray());
    }

    public static DialogItem FromNbt(INbtTag tag) {
        if (tag is StringTag id) {
            return new DialogItem(id.Value);
        }

        CompoundTag compound = (CompoundTag)tag;
        return new DialogItem(
            compound["id"]!.GetString(),
            compound.Contains("count") ? compound["count"]!.AsInt() : 1,
            compound.Contains("components") ? (CompoundTag)compound["components"]! : null);
    }
}

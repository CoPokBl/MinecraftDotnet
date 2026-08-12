using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Dialogs;

/// <summary>
/// A control the player fills in before pressing a button. The key names the value in a command
/// template, where <c>$(key)</c> is replaced by whatever the player entered.
/// </summary>
public record DialogInput(string Key, InputControl Control) {

    public INbtTag ToNbt() {
        // The control's fields sit alongside the key rather than nested under it
        List<(string, INbtTag)> children = [
            ("key", new StringTag(Key)),
            ("type", new StringTag(Control.Type.ToString()))
        ];
        children.AddRange(Control.ToFields());
        return new CompoundTag(children.ToArray());
    }

    public static DialogInput FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new DialogInput(compound["key"]!.GetString(), InputControl.FromNbt(compound));
    }
}

public abstract record InputControl {
    public abstract Identifier Type { get; }

    public abstract (string, INbtTag)[] ToFields();

    public static InputControl FromNbt(CompoundTag compound) {
        Identifier type = compound["type"]!.GetString();

        return type.ToString() switch {
            "minecraft:boolean" => new Boolean(
                TextComponent.FromTag(compound["label"]!),
                compound.Contains("initial") && compound["initial"]!.GetBoolean(),
                compound.Contains("on_true") ? compound["on_true"]!.GetString() : "true",
                compound.Contains("on_false") ? compound["on_false"]!.GetString() : "false"),

            "minecraft:number_range" => new NumberRange(
                TextComponent.FromTag(compound["label"]!),
                RangeInfo.FromNbt(compound),
                compound.Contains("width") ? compound["width"]!.GetInteger() : 200,
                compound.Contains("label_format") ? compound["label_format"]!.GetString() : "options.generic_value"),

            "minecraft:single_option" => new SingleOption(
                TextComponent.FromTag(compound["label"]!),
                ((ListTag)compound["options"]!).Tags.ToArray().Select(SingleOptionEntry.FromNbt).ToArray(),
                compound.Contains("width") ? compound["width"]!.GetInteger() : 200,
                !compound.Contains("label_visible") || compound["label_visible"]!.GetBoolean()),

            "minecraft:text" => new Text(
                TextComponent.FromTag(compound["label"]!),
                compound.Contains("width") ? compound["width"]!.GetInteger() : 200,
                !compound.Contains("label_visible") || compound["label_visible"]!.GetBoolean(),
                compound.Contains("initial") ? compound["initial"]!.GetString() : "",
                compound.Contains("max_length") ? compound["max_length"]!.GetInteger() : 32,
                compound.Contains("multiline") ? MultilineOptions.FromNbt(compound["multiline"]!) : null),

            _ => throw new ArgumentException($"Unknown dialog input control type {type}", nameof(compound))
        };
    }

    /// <param name="OnTrue">The value substituted into a command template when ticked.</param>
    /// <param name="OnFalse">The value substituted when not.</param>
    public record Boolean(
        TextComponent Label,
        bool Initial = false,
        string OnTrue = "true",
        string OnFalse = "false") : InputControl {

        public override Identifier Type => "minecraft:boolean";

        public override (string, INbtTag)[] ToFields() {
            List<(string, INbtTag)> fields = [("label", Label.SerialiseToTag())];

            if (Initial) {
                fields.Add(("initial", new BooleanTag(true)));
            }

            if (OnTrue != "true") {
                fields.Add(("on_true", new StringTag(OnTrue)));
            }

            if (OnFalse != "false") {
                fields.Add(("on_false", new StringTag(OnFalse)));
            }

            return fields.ToArray();
        }
    }

    /// <param name="LabelFormat">Translation key the label and the current value are fed through.</param>
    public record NumberRange(
        TextComponent Label,
        RangeInfo Range,
        int Width = 200,
        string LabelFormat = "options.generic_value") : InputControl {

        public override Identifier Type => "minecraft:number_range";

        public override (string, INbtTag)[] ToFields() {
            List<(string, INbtTag)> fields = [];

            if (Width != 200) {
                fields.Add(("width", new IntegerTag(Width)));
            }

            fields.Add(("label", Label.SerialiseToTag()));

            if (LabelFormat != "options.generic_value") {
                fields.Add(("label_format", new StringTag(LabelFormat)));
            }

            // The range is a map codec on the vanilla side, so its fields sit alongside the
            // control's rather than under a key of their own
            fields.AddRange(Range.ToFields());
            return fields.ToArray();
        }
    }

    public record SingleOption(
        TextComponent Label,
        SingleOptionEntry[] Options,
        int Width = 200,
        bool LabelVisible = true) : InputControl {

        public override Identifier Type => "minecraft:single_option";

        public override (string, INbtTag)[] ToFields() {
            List<(string, INbtTag)> fields = [];

            if (Width != 200) {
                fields.Add(("width", new IntegerTag(Width)));
            }

            fields.Add(("options", new ListTag<CompoundTag>(Options
                .Select(o => (CompoundTag)o.ToNbt())
                .ToArray())));
            fields.Add(("label", Label.SerialiseToTag()));

            if (!LabelVisible) {
                fields.Add(("label_visible", new BooleanTag(false)));
            }

            return fields.ToArray();
        }

        public virtual bool Equals(SingleOption? other) {
            return other != null && Label.Equals(other.Label) && Width == other.Width
                   && LabelVisible == other.LabelVisible && Options.SequenceEqual(other.Options);
        }

        public override int GetHashCode() => HashCode.Combine(Width, LabelVisible, Options.Length);
    }

    /// <param name="Multiline">Set to turn the single line box into a multi line one.</param>
    public record Text(
        TextComponent Label,
        int Width = 200,
        bool LabelVisible = true,
        string Initial = "",
        int MaxLength = 32,
        MultilineOptions? Multiline = null) : InputControl {

        public override Identifier Type => "minecraft:text";

        public override (string, INbtTag)[] ToFields() {
            List<(string, INbtTag)> fields = [];

            if (Width != 200) {
                fields.Add(("width", new IntegerTag(Width)));
            }

            fields.Add(("label", Label.SerialiseToTag()));

            if (!LabelVisible) {
                fields.Add(("label_visible", new BooleanTag(false)));
            }

            if (Initial.Length > 0) {
                fields.Add(("initial", new StringTag(Initial)));
            }

            if (MaxLength != 32) {
                fields.Add(("max_length", new IntegerTag(MaxLength)));
            }

            if (Multiline != null) {
                fields.Add(("multiline", Multiline.ToNbt()));
            }

            return fields.ToArray();
        }
    }
}

/// <param name="Step">How far the slider moves per notch; continuous when unset.</param>
public record RangeInfo(float Start, float End, float? Initial = null, float? Step = null) {

    public (string, INbtTag)[] ToFields() {
        List<(string, INbtTag)> children = [
            ("start", new FloatTag(Start)),
            ("end", new FloatTag(End))
        ];

        if (Initial != null) {
            children.Add(("initial", new FloatTag(Initial.Value)));
        }

        if (Step != null) {
            children.Add(("step", new FloatTag(Step.Value)));
        }

        return children.ToArray();
    }

    public static RangeInfo FromNbt(CompoundTag compound) {
        return new RangeInfo(
            compound["start"]!.GetFloat(),
            compound["end"]!.GetFloat(),
            compound.Contains("initial") ? compound["initial"]!.GetFloat() : null,
            compound.Contains("step") ? compound["step"]!.GetFloat() : null);
    }
}

/// <param name="Id">What gets substituted into a command template when this option is picked.</param>
/// <param name="Display">Shown instead of the id; the id itself is used when unset.</param>
public record SingleOptionEntry(string Id, TextComponent? Display = null, bool Initial = false) {

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [("id", new StringTag(Id))];

        if (Display != null) {
            children.Add(("display", Display.SerialiseToTag()));
        }

        if (Initial) {
            children.Add(("initial", new BooleanTag(true)));
        }

        return new CompoundTag(children.ToArray());
    }

    public static SingleOptionEntry FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new SingleOptionEntry(
            compound["id"]!.GetString(),
            compound.Contains("display") ? TextComponent.FromTag(compound["display"]!) : null,
            compound.Contains("initial") && compound["initial"]!.GetBoolean());
    }
}

public record MultilineOptions(int? MaxLines = null, int? Height = null) {

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [];

        if (MaxLines != null) {
            children.Add(("max_lines", new IntegerTag(MaxLines.Value)));
        }

        if (Height != null) {
            children.Add(("height", new IntegerTag(Height.Value)));
        }

        return new CompoundTag(children.ToArray());
    }

    public static MultilineOptions FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new MultilineOptions(
            compound.Contains("max_lines") ? compound["max_lines"]!.GetInteger() : null,
            compound.Contains("height") ? compound["height"]!.GetInteger() : null);
    }
}

namespace Minecraft.Data.PigVariant;

/// <summary>The model the client renders a pig of this variant with.</summary>
public enum PigVariantModel {
    Normal,
    Cold
}

public static class PigVariantModelExtensions {
    public static string ToProtocolString(this PigVariantModel model) => model switch {
        PigVariantModel.Normal => "normal",
        PigVariantModel.Cold => "cold",
        _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
    };

    public static PigVariantModel ParsePigVariantModel(string value) => value switch {
        "normal" => PigVariantModel.Normal,
        "cold" => PigVariantModel.Cold,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown pig model")
    };
}

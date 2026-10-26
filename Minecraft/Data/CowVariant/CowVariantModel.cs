namespace Minecraft.Data.CowVariant;

/// <summary>The model the client renders a cow of this variant with.</summary>
public enum CowVariantModel {
    Normal,
    Cold,
    Warm
}

public static class CowVariantModelExtensions {
    public static string ToProtocolString(this CowVariantModel model) => model switch {
        CowVariantModel.Normal => "normal",
        CowVariantModel.Cold => "cold",
        CowVariantModel.Warm => "warm",
        _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
    };

    public static CowVariantModel ParseCowVariantModel(string value) => value switch {
        "normal" => CowVariantModel.Normal,
        "cold" => CowVariantModel.Cold,
        "warm" => CowVariantModel.Warm,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown cow model")
    };
}

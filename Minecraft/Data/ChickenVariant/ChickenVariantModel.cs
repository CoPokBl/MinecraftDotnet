namespace Minecraft.Data.ChickenVariant;

/// <summary>The model the client renders a chicken of this variant with.</summary>
public enum ChickenVariantModel {
    Normal,
    Cold
}

public static class ChickenVariantModelExtensions {
    public static string ToProtocolString(this ChickenVariantModel model) => model switch {
        ChickenVariantModel.Normal => "normal",
        ChickenVariantModel.Cold => "cold",
        _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
    };

    public static ChickenVariantModel ParseChickenVariantModel(string value) => value switch {
        "normal" => ChickenVariantModel.Normal,
        "cold" => ChickenVariantModel.Cold,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown chicken model")
    };
}

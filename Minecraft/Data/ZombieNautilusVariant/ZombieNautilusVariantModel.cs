namespace Minecraft.Data.ZombieNautilusVariant;

/// <summary>The model the client renders a zombie nautilus of this variant with.</summary>
public enum ZombieNautilusVariantModel {
    Normal,
    Warm
}

public static class ZombieNautilusVariantModelExtensions {
    public static string ToProtocolString(this ZombieNautilusVariantModel model) => model switch {
        ZombieNautilusVariantModel.Normal => "normal",
        ZombieNautilusVariantModel.Warm => "warm",
        _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
    };

    public static ZombieNautilusVariantModel ParseZombieNautilusVariantModel(string value) => value switch {
        "normal" => ZombieNautilusVariantModel.Normal,
        "warm" => ZombieNautilusVariantModel.Warm,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown zombie nautilus model")
    };
}

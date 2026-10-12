using System.Numerics;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace GraphicalClient.Assets;

/// <summary>
/// The built in art's item definitions for items a special renderer draws, which without a pack would
/// otherwise be their flat icon. Each pose is this client's own, given as where the model's centre sits
/// (in sixteenths of the display context's space), how it is turned and how big it is.
/// </summary>
public static class DevArtItemModels {
    private static readonly Dictionary<Identifier, ItemModelNode> Definitions = new() {
        [Item.Shield.Identifier] = new ConditionalItemModelNode(ItemModelTree.UsingItem, Shield(0, true), Shield(1, false))
    };

    /// <summary>The definition a model id names without a pack; null for an item drawn as its icon.</summary>
    public static ItemModelNode? Definition(Identifier modelId) =>
        Definitions.GetValueOrDefault(modelId) ?? Rendering.BlockEntities.BlockEntityItemModels.Definition(modelId);

    private static ItemModelLeaf Shield(int id, bool usingItem) => new(id, new ItemModel([], [], ShieldDisplay(usingItem), false) {
        Local = ShieldSpecialRenderer.DefaultTransformation,
        Special = ShieldSpecialRenderer.Unbaked.Instance
    }, []);

    private static Dictionary<string, ItemTransform> ShieldDisplay(bool usingItem) {
        Dictionary<string, ItemTransform> display = new() {
            ["gui"] = Centred(new Vector3(10, -30, 0), Vector3.Zero, 0.62F, false),
            ["ground"] = Centred(Vector3.Zero, Vector3.Zero, 0.3F, false),
            ["fixed"] = Centred(new Vector3(0, 180, 0), Vector3.Zero, 0.5F, false)
        };
        if (usingItem) {
            Hands(display, "thirdperson", new Vector3(45, 150, 0), new Vector3(0, -2, 0), 1.0F);
            Hands(display, "firstperson", new Vector3(0, 180, -5), new Vector3(-4, -6, -1), 1.2F);
        }
        else {
            Hands(display, "thirdperson", new Vector3(0, 90, 0), new Vector3(2, -2, 4), 1.0F);
            Hands(display, "firstperson", new Vector3(0, 180, 5), new Vector3(-1, -9, 0), 1.2F);
        }
        return display;
    }

    /// <summary>A right hand pose, and the left hand's as its mirror once <c>ItemTransform.apply</c>'s left hand fix has run.</summary>
    private static void Hands(Dictionary<string, ItemTransform> display, string prefix, Vector3 rotation, Vector3 centre, float scale) {
        display[prefix + "_righthand"] = Centred(rotation, centre, scale, false);
        display[prefix + "_lefthand"] = Centred(rotation, centre with { X = -centre.X }, scale, true);
    }

    /// <summary>
    /// The transform that puts the model's origin at <paramref name="centre"/>: <c>ItemTransform.apply</c>
    /// moves the origin to minus half a block before scaling and turning, so the translation makes up for it.
    /// </summary>
    private static ItemTransform Centred(Vector3 rotation, Vector3 centre, float scale, bool leftHand) {
        float sign = leftHand ? -1 : 1;
        const float toRadians = MathF.PI / 180.0F;
        Matrix4x4 turn = Matrix4x4.CreateRotationZ(rotation.Z * sign * toRadians) * Matrix4x4.CreateRotationY(rotation.Y * sign * toRadians)
                         * Matrix4x4.CreateRotationX(rotation.X * toRadians);
        Vector3 translation = centre / 16.0F - Vector3.Transform(new Vector3(-0.5F * scale), turn);
        return new ItemTransform(rotation, translation with { X = translation.X * sign }, new Vector3(scale));
    }
}

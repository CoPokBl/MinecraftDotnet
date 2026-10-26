using System.Numerics;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Item = Minecraft.Data.Generated.Item;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary>
/// The built in art's item definitions for the items a block entity renderer draws: each the special
/// renderer its vanilla definition names, moved into the block's space by the block renderer's own
/// transform, and posed as a block is in each display context. The poses are this client's own.
/// </summary>
public static class BlockEntityItemModels {
    private static readonly Lazy<Dictionary<Identifier, ItemModelNode>> Definitions = new(Build);

    /// <summary>The definition a model id names without a pack; null for one these do not cover.</summary>
    public static ItemModelNode? Definition(Identifier modelId) => Definitions.Value.GetValueOrDefault(modelId);

    private static Dictionary<Identifier, ItemModelNode> Build() {
        Dictionary<Identifier, ItemModelNode> definitions = new();
        int id = 100;
        void Add(IItem item, ISpecialModelUnbaked special, Matrix4x4 local, float scale = 1.0F, float guiYRot = 225) =>
            definitions[item.Identifier] = new ItemModelLeaf(id++, new ItemModel([], [], BlockDisplay(scale, guiYRot), true) { Local = local, Special = special }, []);

        Add(Item.Chest, Parse("minecraft:chest", ("texture", "minecraft:normal")), Matrix4x4.Identity);
        Add(Item.TrappedChest, Parse("minecraft:chest", ("texture", "minecraft:trapped")), Matrix4x4.Identity);
        Add(Item.EnderChest, Parse("minecraft:chest", ("texture", "minecraft:ender")), Matrix4x4.Identity);
        (IItem[] Items, string Texture)[] copper = [
            ([Item.CopperChest, Item.WaxedCopperChest], "minecraft:copper"),
            ([Item.ExposedCopperChest, Item.WaxedExposedCopperChest], "minecraft:copper_exposed"),
            ([Item.WeatheredCopperChest, Item.WaxedWeatheredCopperChest], "minecraft:copper_weathered"),
            ([Item.OxidizedCopperChest, Item.WaxedOxidizedCopperChest], "minecraft:copper_oxidized")
        ];
        foreach ((IItem[] items, string texture) in copper) {
            foreach (IItem item in items) {
                Add(item, Parse("minecraft:chest", ("texture", texture)), Matrix4x4.Identity);
            }
        }

        Matrix4x4 shulker = ShulkerBoxRenderer.ModelTransform(Cardinal.Up);
        Add(Item.ShulkerBox, Parse("minecraft:shulker_box", ("texture", "minecraft:shulker")), shulker);
        IItem[] shulkerBoxes = [
            Item.WhiteShulkerBox, Item.OrangeShulkerBox, Item.MagentaShulkerBox, Item.LightBlueShulkerBox, Item.YellowShulkerBox, Item.LimeShulkerBox,
            Item.PinkShulkerBox, Item.GrayShulkerBox, Item.LightGrayShulkerBox, Item.CyanShulkerBox, Item.PurpleShulkerBox, Item.BlueShulkerBox,
            Item.BrownShulkerBox, Item.GreenShulkerBox, Item.RedShulkerBox, Item.BlackShulkerBox
        ];
        IItem[] banners = [
            Item.WhiteBanner, Item.OrangeBanner, Item.MagentaBanner, Item.LightBlueBanner, Item.YellowBanner, Item.LimeBanner, Item.PinkBanner,
            Item.GrayBanner, Item.LightGrayBanner, Item.CyanBanner, Item.PurpleBanner, Item.BlueBanner, Item.BrownBanner, Item.GreenBanner,
            Item.RedBanner, Item.BlackBanner
        ];
        // A standing banner is near two blocks tall; drawn at a block's size it is centred on its middle.
        Matrix4x4 banner = Matrix4x4.CreateTranslation(-0.5F, -0.9F, -0.5F) * Matrix4x4.CreateScale(0.75F) * Matrix4x4.CreateTranslation(0.5F, 0.5F, 0.5F);
        for (int i = 0; i < 16; i++) {
            string dye = Sheets.DyeName((DyeColor)i);
            Add(shulkerBoxes[i], Parse("minecraft:shulker_box", ("texture", "minecraft:shulker_" + dye)), shulker);
            Add(banners[i], Parse("minecraft:banner", ("color", dye)),
                BlockEntityTransforms.Transformation(new Vector3(0.5F, 0.0F, 0.5F), Matrix4x4.Identity, new Vector3(0.6666667F, -0.6666667F, -0.6666667F)) * banner,
                guiYRot: 20);
        }

        Add(Item.DecoratedPot, Parse("minecraft:decorated_pot"), Matrix4x4.Identity);
        Add(Item.Conduit, Parse("minecraft:conduit"), Matrix4x4.CreateTranslation(0.5F, 0.5F, 0.5F));

        // A head is half a block tall from the floor up; lifted so its middle is the block's. Turned to show its face in the GUI.
        Matrix4x4 head = BlockEntityTransforms.Transformation(new Vector3(0.5F, 0.25F, 0.5F), Matrix4x4.CreateRotationX(MathF.PI), Vector3.One);
        Add(Item.SkeletonSkull, Parse("minecraft:head", ("kind", "skeleton")), head, 1.6F, guiYRot: 45);
        Add(Item.WitherSkeletonSkull, Parse("minecraft:head", ("kind", "wither_skeleton")), head, 1.6F, guiYRot: 45);
        Add(Item.ZombieHead, Parse("minecraft:head", ("kind", "zombie")), head, 1.6F, guiYRot: 45);
        Add(Item.CreeperHead, Parse("minecraft:head", ("kind", "creeper")), head, 1.6F, guiYRot: 45);
        Add(Item.PiglinHead, Parse("minecraft:head", ("kind", "piglin")), head, 1.6F, guiYRot: 45);
        Add(Item.DragonHead, Parse("minecraft:head", ("kind", "dragon")), head, guiYRot: 45);
        Add(Item.PlayerHead, Parse("minecraft:player_head"), head, 1.6F, guiYRot: 45);

        (IItem[] Items, int Oxidation)[] statues = [
            ([Item.CopperGolemStatue, Item.WaxedCopperGolemStatue], 0),
            ([Item.ExposedCopperGolemStatue, Item.WaxedExposedCopperGolemStatue], 1),
            ([Item.WeatheredCopperGolemStatue, Item.WaxedWeatheredCopperGolemStatue], 2),
            ([Item.OxidizedCopperGolemStatue, Item.WaxedOxidizedCopperGolemStatue], 3)
        ];
        foreach ((IItem[] items, int oxidation) in statues) {
            string texture = CopperGolemStatueRenderer.TexturePath(oxidation).ToString();
            foreach (IItem item in items) {
                Add(item, Parse("minecraft:copper_golem_statue", ("texture", texture), ("pose", "standing")),
                    CopperGolemStatueRenderer.ModelTransformation(Direction.North));
            }
        }
        return definitions;
    }

    private static ISpecialModelUnbaked Parse(string type, params (string Key, string Value)[] fields) {
        Newtonsoft.Json.Linq.JObject json = new() { ["type"] = type };
        foreach ((string key, string value) in fields) {
            json[key] = value;
        }
        return SpecialModelRenderers.Parse(json) ?? throw new InvalidOperationException($"No special renderer for {type}");
    }

    /// <summary>A block's poses: turned to show three faces in the GUI, small on the ground, held at an angle.</summary>
    private static Dictionary<string, ItemTransform> BlockDisplay(float scale, float guiYRot) {
        ItemTransform Pose(float rx, float ry, float rz, float ty, float s) => new(new Vector3(rx, ry, rz), new Vector3(0, ty, 0) / 16.0F, new Vector3(s * scale));
        return new Dictionary<string, ItemTransform> {
            ["gui"] = Pose(30, guiYRot, 0, 0, 0.625F),
            ["ground"] = Pose(0, 0, 0, 3, 0.25F),
            ["fixed"] = Pose(0, 0, 0, 0, 0.5F),
            ["head"] = Pose(0, 0, 0, 0, 1.0F),
            ["thirdperson_righthand"] = Pose(75, 45, 0, 2.5F, 0.375F),
            ["thirdperson_lefthand"] = Pose(75, 45, 0, 2.5F, 0.375F),
            ["firstperson_righthand"] = Pose(0, 45, 0, 0, 0.4F),
            ["firstperson_lefthand"] = Pose(0, 225, 0, 0, 0.4F)
        };
    }
}

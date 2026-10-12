using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace GraphicalClient.Rendering.Entities.Special;

/// <summary><c>ChestRenderState.ChestMaterialType</c>.</summary>
public enum ChestMaterialType {
    EnderChest, Christmas, Trapped, CopperUnaffected, CopperExposed, CopperWeathered, CopperOxidized, Regular
}

/// <summary><c>MultiblockChestResources</c>: one of a thing for each half a chest can be.</summary>
public sealed record MultiblockChestResources<T>(T Single, T Left, T Right) {
    public T Select(ChestType type) => type switch {
        ChestType.Left => Left,
        ChestType.Right => Right,
        _ => Single
    };

    public MultiblockChestResources<TOut> Map<TOut>(Func<T, TOut> mapper) => new(mapper(Single), mapper(Left), mapper(Right));
}

public static partial class Sheets {
    public static readonly Identifier BlocksSheet = "minecraft:textures/atlas/blocks.png";
    public static readonly Identifier ChestSheet = "minecraft:textures/atlas/chest.png";
    public static readonly Identifier ShulkerSheet = "minecraft:textures/atlas/shulker_boxes.png";
    public static readonly Identifier DecoratedPotSheet = "minecraft:textures/atlas/decorated_pot.png";

    /// <summary><c>CHEST_MAPPER</c>.</summary>
    public static SpriteId ChestSprite(Identifier id) => new(ChestSheet, new Identifier(id.Namespace, "entity/chest/" + id.Key));

    /// <summary><c>SHULKER_MAPPER</c>.</summary>
    public static SpriteId ShulkerSprite(Identifier id) => new(ShulkerSheet, new Identifier(id.Namespace, "entity/shulker/" + id.Key));

    /// <summary><c>DECORATED_POT_MAPPER</c>.</summary>
    public static SpriteId DecoratedPotSprite(Identifier id) => new(DecoratedPotSheet, new Identifier(id.Namespace, "entity/decorated_pot/" + id.Key));

    /// <summary><c>BLOCK_ENTITIES_MAPPER</c>: textures under <c>entity/</c> that vanilla stitches into the block atlas.</summary>
    public static SpriteId BlockEntitySprite(string path) => new(BlocksSheet, new Identifier("minecraft", "entity/" + path));

    /// <summary>
    /// A whole texture named by its file, <c>minecraft:textures/entity/zombie/zombie.png</c>, as a sprite, so
    /// the built in art can stand in for it the way it does for an atlas sprite.
    /// </summary>
    public static SpriteId TextureSprite(Identifier texture) {
        string key = texture.Key;
        if (key.StartsWith("textures/", StringComparison.Ordinal)) {
            key = key["textures/".Length..];
        }
        if (key.EndsWith(".png", StringComparison.Ordinal)) {
            key = key[..^4];
        }
        return new SpriteId(texture, new Identifier(texture.Namespace, key));
    }

    private static MultiblockChestResources<Identifier> DefaultChestTextures(string prefix) =>
        new($"minecraft:{prefix}", $"minecraft:{prefix}_left", $"minecraft:{prefix}_right");

    /// <summary><c>ChestSpecialRenderer</c>'s texture names, which the item definitions also name.</summary>
    public static readonly MultiblockChestResources<Identifier> ChestRegularNames = DefaultChestTextures("normal");
    public static readonly MultiblockChestResources<Identifier> ChestTrappedNames = DefaultChestTextures("trapped");
    public static readonly MultiblockChestResources<Identifier> ChestChristmasNames = DefaultChestTextures("christmas");

    public static readonly MultiblockChestResources<Identifier>[] ChestCopperNames = [
        DefaultChestTextures("copper"), DefaultChestTextures("copper_exposed"), DefaultChestTextures("copper_weathered"), DefaultChestTextures("copper_oxidized")
    ];

    public static readonly SpriteId EnderChestLocation = ChestSprite("minecraft:ender");
    public static readonly MultiblockChestResources<SpriteId> ChestRegular = ChestRegularNames.Map(ChestSprite);
    public static readonly MultiblockChestResources<SpriteId> ChestTrapped = ChestTrappedNames.Map(ChestSprite);
    public static readonly MultiblockChestResources<SpriteId> ChestChristmas = ChestChristmasNames.Map(ChestSprite);
    public static readonly MultiblockChestResources<SpriteId>[] ChestCopper = ChestCopperNames.Select(r => r.Map(ChestSprite)).ToArray();

    public static readonly SpriteId DefaultShulkerTextureLocation = ShulkerSprite("minecraft:shulker");
    public static readonly SpriteId BannerBase = BannerSprite("minecraft:banner_base");
    public static readonly SpriteId DecoratedPotBase = DecoratedPotSprite("minecraft:decorated_pot_base");
    public static readonly SpriteId DecoratedPotSide = DecoratedPotSprite("minecraft:decorated_pot_side");

    /// <summary><c>chooseSprite</c>.</summary>
    public static SpriteId ChooseSprite(ChestMaterialType material, ChestType type) => material switch {
        ChestMaterialType.EnderChest => EnderChestLocation,
        ChestMaterialType.Christmas => ChestChristmas.Select(type),
        ChestMaterialType.Trapped => ChestTrapped.Select(type),
        ChestMaterialType.CopperUnaffected => ChestCopper[0].Select(type),
        ChestMaterialType.CopperExposed => ChestCopper[1].Select(type),
        ChestMaterialType.CopperWeathered => ChestCopper[2].Select(type),
        ChestMaterialType.CopperOxidized => ChestCopper[3].Select(type),
        _ => ChestRegular.Select(type)
    };

    /// <summary><c>getShulkerBoxSprite</c>.</summary>
    public static SpriteId GetShulkerBoxSprite(DyeColor color) => ShulkerSprite($"minecraft:shulker_{DyeName(color)}");

    /// <summary><c>DyeColor.getSerializedName</c>.</summary>
    public static string DyeName(DyeColor color) => color switch {
        DyeColor.LightBlue => "light_blue",
        DyeColor.LightGray => "light_gray",
        _ => color.ToString().ToLowerInvariant()
    };
}

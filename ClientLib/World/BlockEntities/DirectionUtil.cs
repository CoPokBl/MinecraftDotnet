using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ClientLib.World.BlockEntities;

/// <summary>The parts of vanilla's <c>Direction</c> the block entities turn by.</summary>
public static class DirectionUtil {
    public static Direction ClockWise(Direction direction) => direction switch {
        Direction.North => Direction.East,
        Direction.East => Direction.South,
        Direction.South => Direction.West,
        _ => Direction.North
    };

    public static Direction CounterClockWise(Direction direction) => direction switch {
        Direction.North => Direction.West,
        Direction.West => Direction.South,
        Direction.South => Direction.East,
        _ => Direction.North
    };

    public static Direction Opposite(Direction direction) => ClockWise(ClockWise(direction));

    public static (int X, int Z) Step(Direction direction) => direction switch {
        Direction.North => (0, -1),
        Direction.South => (0, 1),
        Direction.West => (-1, 0),
        _ => (1, 0)
    };

    /// <summary><c>get2DDataValue</c>: south, west, north, east from 0.</summary>
    public static int Get2DDataValue(Direction direction) => direction switch {
        Direction.South => 0,
        Direction.West => 1,
        Direction.North => 2,
        _ => 3
    };

    public static Direction From2DDataValue(int value) => (Math.Abs(value % 4)) switch {
        0 => Direction.South,
        1 => Direction.West,
        2 => Direction.North,
        _ => Direction.East
    };

    /// <summary><c>toYRot</c>: south is 0 and the angle grows clockwise seen from above.</summary>
    public static float ToYRot(Direction direction) => Get2DDataValue(direction) * 90.0F;

    /// <summary><c>from3DDataValue</c>, which <see cref="Cardinal"/>'s values already are.</summary>
    public static Cardinal From3DDataValue(int value) => (Cardinal)Math.Abs(value % 6);

    public static (int X, int Y, int Z) Step(Cardinal direction) => direction switch {
        Cardinal.Down => (0, -1, 0),
        Cardinal.Up => (0, 1, 0),
        Cardinal.North => (0, 0, -1),
        Cardinal.South => (0, 0, 1),
        Cardinal.West => (-1, 0, 0),
        _ => (1, 0, 0)
    };

    public static Cardinal ToCardinal(Direction direction) => direction switch {
        Direction.North => Cardinal.North,
        Direction.South => Cardinal.South,
        Direction.West => Cardinal.West,
        _ => Cardinal.East
    };
}

/// <summary>The blocks that carry a dye colour in their identity rather than in a property.</summary>
public static class DyedBlocks {
    private static readonly IBlock[] ShulkerBoxes = [
        Block.WhiteShulkerBox, Block.OrangeShulkerBox, Block.MagentaShulkerBox, Block.LightBlueShulkerBox, Block.YellowShulkerBox, Block.LimeShulkerBox,
        Block.PinkShulkerBox, Block.GrayShulkerBox, Block.LightGrayShulkerBox, Block.CyanShulkerBox, Block.PurpleShulkerBox, Block.BlueShulkerBox,
        Block.BrownShulkerBox, Block.GreenShulkerBox, Block.RedShulkerBox, Block.BlackShulkerBox
    ];

    private static readonly IBlock[] Banners = [
        Block.WhiteBanner, Block.OrangeBanner, Block.MagentaBanner, Block.LightBlueBanner, Block.YellowBanner, Block.LimeBanner, Block.PinkBanner,
        Block.GrayBanner, Block.LightGrayBanner, Block.CyanBanner, Block.PurpleBanner, Block.BlueBanner, Block.BrownBanner, Block.GreenBanner,
        Block.RedBanner, Block.BlackBanner
    ];

    private static readonly IBlock[] WallBanners = [
        Block.WhiteWallBanner, Block.OrangeWallBanner, Block.MagentaWallBanner, Block.LightBlueWallBanner, Block.YellowWallBanner,
        Block.LimeWallBanner, Block.PinkWallBanner, Block.GrayWallBanner, Block.LightGrayWallBanner, Block.CyanWallBanner, Block.PurpleWallBanner,
        Block.BlueWallBanner, Block.BrownWallBanner, Block.GreenWallBanner, Block.RedWallBanner, Block.BlackWallBanner
    ];

    private static readonly IBlock[] StainedGlass = [
        Block.WhiteStainedGlass, Block.OrangeStainedGlass, Block.MagentaStainedGlass, Block.LightBlueStainedGlass, Block.YellowStainedGlass,
        Block.LimeStainedGlass, Block.PinkStainedGlass, Block.GrayStainedGlass, Block.LightGrayStainedGlass, Block.CyanStainedGlass,
        Block.PurpleStainedGlass, Block.BlueStainedGlass, Block.BrownStainedGlass, Block.GreenStainedGlass, Block.RedStainedGlass,
        Block.BlackStainedGlass
    ];

    private static readonly IBlock[] StainedGlassPanes = [
        Block.WhiteStainedGlassPane, Block.OrangeStainedGlassPane, Block.MagentaStainedGlassPane, Block.LightBlueStainedGlassPane,
        Block.YellowStainedGlassPane, Block.LimeStainedGlassPane, Block.PinkStainedGlassPane, Block.GrayStainedGlassPane,
        Block.LightGrayStainedGlassPane, Block.CyanStainedGlassPane, Block.PurpleStainedGlassPane, Block.BlueStainedGlassPane,
        Block.BrownStainedGlassPane, Block.GreenStainedGlassPane, Block.RedStainedGlassPane, Block.BlackStainedGlassPane
    ];

    private static DyeColor? Find(IBlock[] blocks, IBlock state) {
        for (int i = 0; i < blocks.Length; i++) {
            if (blocks[i].Identifier.Equals(state.Identifier)) {
                return (DyeColor)i;
            }
        }
        return null;
    }

    /// <summary><c>ShulkerBoxBlock.getColor</c>.</summary>
    public static DyeColor? ShulkerBoxColor(IBlock state) => Find(ShulkerBoxes, state);

    /// <summary><c>AbstractBannerBlock.getColor</c>, and whether it hangs on a wall.</summary>
    public static (DyeColor Color, bool Wall)? BannerColor(IBlock state) =>
        Find(Banners, state) is { } ground ? (ground, false) : Find(WallBanners, state) is { } wall ? (wall, true) : null;

    /// <summary><c>StainedGlassBlock.getColor</c> and <c>StainedGlassPaneBlock.getColor</c>.</summary>
    public static DyeColor? StainedGlassColor(IBlock state) => Find(StainedGlass, state) ?? Find(StainedGlassPanes, state);
}

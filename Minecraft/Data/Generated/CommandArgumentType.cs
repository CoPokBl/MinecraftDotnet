using Minecraft.Data.ArgumentParsers.Types;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
public static class CommandArgumentType {
    public static BooleanArgumentType Bool => new(0);
    public static DoubleArgumentType Double => new(2);
    public static FloatArgumentType Float => new(1);
    public static IntegerArgumentType Integer => new(3);
    public static LongArgumentType Long => new(4);
    public static StringArgumentType String => new(5);
    public static BlockPosArgumentType BlockPos => new(8);
    public static BlockStateArgumentType BlockState => new(12);
    public static ColorArgumentType Color => new(16);
    public static ChunkPosArgumentType ColumnPos => new(9);
    public static GameModeArgumentType Gamemode => new(42);
    public static HexColourArgumentType HexColor => new(17);
    public static SwizzleArgumentType Swizzle => new(32);
    public static Vec2ArgumentType Vec2 => new(11);
    public static Vec3ArgumentType Vec3 => new(10);
}

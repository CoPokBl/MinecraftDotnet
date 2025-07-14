using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WildflowersBlock(Identifier Identifier, Direction Facing, int FlowerAmount) : IBlock {

    public Identifier Category => "minecraft:flower_bed";
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "pink_petals";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:wildflowers";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [0.5, 0.1875, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.wildflowers";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => FlowerAmount switch {
                    1 => 25903,
                    2 => 25904,
                    3 => 25905,
                    4 => 25906,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.South => FlowerAmount switch {
                    1 => 25907,
                    2 => 25908,
                    3 => 25909,
                    4 => 25910,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.West => FlowerAmount switch {
                    1 => 25911,
                    2 => 25912,
                    3 => 25913,
                    4 => 25914,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.East => FlowerAmount switch {
                    1 => 25915,
                    2 => 25916,
                    3 => 25917,
                    4 => 25918,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25903 => new WildflowersBlock(Identifier, Direction.North, 1),
            25904 => new WildflowersBlock(Identifier, Direction.North, 2),
            25905 => new WildflowersBlock(Identifier, Direction.North, 3),
            25906 => new WildflowersBlock(Identifier, Direction.North, 4),
            25907 => new WildflowersBlock(Identifier, Direction.South, 1),
            25908 => new WildflowersBlock(Identifier, Direction.South, 2),
            25909 => new WildflowersBlock(Identifier, Direction.South, 3),
            25910 => new WildflowersBlock(Identifier, Direction.South, 4),
            25911 => new WildflowersBlock(Identifier, Direction.West, 1),
            25912 => new WildflowersBlock(Identifier, Direction.West, 2),
            25913 => new WildflowersBlock(Identifier, Direction.West, 3),
            25914 => new WildflowersBlock(Identifier, Direction.West, 4),
            25915 => new WildflowersBlock(Identifier, Direction.East, 1),
            25916 => new WildflowersBlock(Identifier, Direction.East, 2),
            25917 => new WildflowersBlock(Identifier, Direction.East, 3),
            25918 => new WildflowersBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            FlowerAmount = int.Parse(properties["flower_amount"].GetString()),
        };
    }
    
}

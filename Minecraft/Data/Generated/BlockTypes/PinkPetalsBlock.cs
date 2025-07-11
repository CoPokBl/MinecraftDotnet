using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PinkPetalsBlock(Identifier Identifier, Direction Facing, int FlowerAmount) : IBlock {

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
    public Identifier? Item => "minecraft:pink_petals";
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
    public string TranslationKey => "block.minecraft.pink_petals";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => FlowerAmount switch {
                    1 => 25855,
                    2 => 25856,
                    3 => 25857,
                    4 => 25858,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.South => FlowerAmount switch {
                    1 => 25859,
                    2 => 25860,
                    3 => 25861,
                    4 => 25862,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.West => FlowerAmount switch {
                    1 => 25863,
                    2 => 25864,
                    3 => 25865,
                    4 => 25866,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.East => FlowerAmount switch {
                    1 => 25867,
                    2 => 25868,
                    3 => 25869,
                    4 => 25870,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25855 => new PinkPetalsBlock(Identifier, Direction.North, 1),
            25856 => new PinkPetalsBlock(Identifier, Direction.North, 2),
            25857 => new PinkPetalsBlock(Identifier, Direction.North, 3),
            25858 => new PinkPetalsBlock(Identifier, Direction.North, 4),
            25859 => new PinkPetalsBlock(Identifier, Direction.South, 1),
            25860 => new PinkPetalsBlock(Identifier, Direction.South, 2),
            25861 => new PinkPetalsBlock(Identifier, Direction.South, 3),
            25862 => new PinkPetalsBlock(Identifier, Direction.South, 4),
            25863 => new PinkPetalsBlock(Identifier, Direction.West, 1),
            25864 => new PinkPetalsBlock(Identifier, Direction.West, 2),
            25865 => new PinkPetalsBlock(Identifier, Direction.West, 3),
            25866 => new PinkPetalsBlock(Identifier, Direction.West, 4),
            25867 => new PinkPetalsBlock(Identifier, Direction.East, 1),
            25868 => new PinkPetalsBlock(Identifier, Direction.East, 2),
            25869 => new PinkPetalsBlock(Identifier, Direction.East, 3),
            25870 => new PinkPetalsBlock(Identifier, Direction.East, 4),
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

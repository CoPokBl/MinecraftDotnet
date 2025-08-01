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
    public int ProtocolId => 1050;
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
                    1 => 25887,
                    2 => 25888,
                    3 => 25889,
                    4 => 25890,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.South => FlowerAmount switch {
                    1 => 25891,
                    2 => 25892,
                    3 => 25893,
                    4 => 25894,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.West => FlowerAmount switch {
                    1 => 25895,
                    2 => 25896,
                    3 => 25897,
                    4 => 25898,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.East => FlowerAmount switch {
                    1 => 25899,
                    2 => 25900,
                    3 => 25901,
                    4 => 25902,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25887 => new PinkPetalsBlock(Identifier, Direction.North, 1),
            25888 => new PinkPetalsBlock(Identifier, Direction.North, 2),
            25889 => new PinkPetalsBlock(Identifier, Direction.North, 3),
            25890 => new PinkPetalsBlock(Identifier, Direction.North, 4),
            25891 => new PinkPetalsBlock(Identifier, Direction.South, 1),
            25892 => new PinkPetalsBlock(Identifier, Direction.South, 2),
            25893 => new PinkPetalsBlock(Identifier, Direction.South, 3),
            25894 => new PinkPetalsBlock(Identifier, Direction.South, 4),
            25895 => new PinkPetalsBlock(Identifier, Direction.West, 1),
            25896 => new PinkPetalsBlock(Identifier, Direction.West, 2),
            25897 => new PinkPetalsBlock(Identifier, Direction.West, 3),
            25898 => new PinkPetalsBlock(Identifier, Direction.West, 4),
            25899 => new PinkPetalsBlock(Identifier, Direction.East, 1),
            25900 => new PinkPetalsBlock(Identifier, Direction.East, 2),
            25901 => new PinkPetalsBlock(Identifier, Direction.East, 3),
            25902 => new PinkPetalsBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            FlowerAmount = int.Parse(properties["flower_amount"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("flower_amount", FlowerAmount.ToString())
        );
    }
    
}

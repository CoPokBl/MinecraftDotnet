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
                    1 => 30307,
                    2 => 30308,
                    3 => 30309,
                    4 => 30310,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.South => FlowerAmount switch {
                    1 => 30311,
                    2 => 30312,
                    3 => 30313,
                    4 => 30314,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.West => FlowerAmount switch {
                    1 => 30315,
                    2 => 30316,
                    3 => 30317,
                    4 => 30318,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.East => FlowerAmount switch {
                    1 => 30319,
                    2 => 30320,
                    3 => 30321,
                    4 => 30322,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30307 => new PinkPetalsBlock(Identifier, Direction.North, 1),
            30308 => new PinkPetalsBlock(Identifier, Direction.North, 2),
            30309 => new PinkPetalsBlock(Identifier, Direction.North, 3),
            30310 => new PinkPetalsBlock(Identifier, Direction.North, 4),
            30311 => new PinkPetalsBlock(Identifier, Direction.South, 1),
            30312 => new PinkPetalsBlock(Identifier, Direction.South, 2),
            30313 => new PinkPetalsBlock(Identifier, Direction.South, 3),
            30314 => new PinkPetalsBlock(Identifier, Direction.South, 4),
            30315 => new PinkPetalsBlock(Identifier, Direction.West, 1),
            30316 => new PinkPetalsBlock(Identifier, Direction.West, 2),
            30317 => new PinkPetalsBlock(Identifier, Direction.West, 3),
            30318 => new PinkPetalsBlock(Identifier, Direction.West, 4),
            30319 => new PinkPetalsBlock(Identifier, Direction.East, 1),
            30320 => new PinkPetalsBlock(Identifier, Direction.East, 2),
            30321 => new PinkPetalsBlock(Identifier, Direction.East, 3),
            30322 => new PinkPetalsBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            FlowerAmount = properties.Contains("flower_amount") ? int.Parse(properties["flower_amount"].GetString()) : FlowerAmount,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("flower_amount", new StringTag(FlowerAmount.ToString()))
        );
    }
    
}

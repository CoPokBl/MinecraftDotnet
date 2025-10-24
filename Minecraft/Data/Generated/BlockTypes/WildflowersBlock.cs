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
    public int ProtocolId => 1112;
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
                    1 => 27628,
                    2 => 27629,
                    3 => 27630,
                    4 => 27631,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.South => FlowerAmount switch {
                    1 => 27632,
                    2 => 27633,
                    3 => 27634,
                    4 => 27635,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.West => FlowerAmount switch {
                    1 => 27636,
                    2 => 27637,
                    3 => 27638,
                    4 => 27639,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.East => FlowerAmount switch {
                    1 => 27640,
                    2 => 27641,
                    3 => 27642,
                    4 => 27643,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27628 => new WildflowersBlock(Identifier, Direction.North, 1),
            27629 => new WildflowersBlock(Identifier, Direction.North, 2),
            27630 => new WildflowersBlock(Identifier, Direction.North, 3),
            27631 => new WildflowersBlock(Identifier, Direction.North, 4),
            27632 => new WildflowersBlock(Identifier, Direction.South, 1),
            27633 => new WildflowersBlock(Identifier, Direction.South, 2),
            27634 => new WildflowersBlock(Identifier, Direction.South, 3),
            27635 => new WildflowersBlock(Identifier, Direction.South, 4),
            27636 => new WildflowersBlock(Identifier, Direction.West, 1),
            27637 => new WildflowersBlock(Identifier, Direction.West, 2),
            27638 => new WildflowersBlock(Identifier, Direction.West, 3),
            27639 => new WildflowersBlock(Identifier, Direction.West, 4),
            27640 => new WildflowersBlock(Identifier, Direction.East, 1),
            27641 => new WildflowersBlock(Identifier, Direction.East, 2),
            27642 => new WildflowersBlock(Identifier, Direction.East, 3),
            27643 => new WildflowersBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            FlowerAmount = properties.ChildrenMap.ContainsKey("flower_amount") ? int.Parse(properties["flower_amount"].GetString()) : FlowerAmount,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("flower_amount", FlowerAmount.ToString())
        );
    }
    
}

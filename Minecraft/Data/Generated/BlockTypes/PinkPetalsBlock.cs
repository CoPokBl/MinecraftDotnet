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
    public int ProtocolId => 1111;
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
                    1 => 27612,
                    2 => 27613,
                    3 => 27614,
                    4 => 27615,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.South => FlowerAmount switch {
                    1 => 27616,
                    2 => 27617,
                    3 => 27618,
                    4 => 27619,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.West => FlowerAmount switch {
                    1 => 27620,
                    2 => 27621,
                    3 => 27622,
                    4 => 27623,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.East => FlowerAmount switch {
                    1 => 27624,
                    2 => 27625,
                    3 => 27626,
                    4 => 27627,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27612 => new PinkPetalsBlock(Identifier, Direction.North, 1),
            27613 => new PinkPetalsBlock(Identifier, Direction.North, 2),
            27614 => new PinkPetalsBlock(Identifier, Direction.North, 3),
            27615 => new PinkPetalsBlock(Identifier, Direction.North, 4),
            27616 => new PinkPetalsBlock(Identifier, Direction.South, 1),
            27617 => new PinkPetalsBlock(Identifier, Direction.South, 2),
            27618 => new PinkPetalsBlock(Identifier, Direction.South, 3),
            27619 => new PinkPetalsBlock(Identifier, Direction.South, 4),
            27620 => new PinkPetalsBlock(Identifier, Direction.West, 1),
            27621 => new PinkPetalsBlock(Identifier, Direction.West, 2),
            27622 => new PinkPetalsBlock(Identifier, Direction.West, 3),
            27623 => new PinkPetalsBlock(Identifier, Direction.West, 4),
            27624 => new PinkPetalsBlock(Identifier, Direction.East, 1),
            27625 => new PinkPetalsBlock(Identifier, Direction.East, 2),
            27626 => new PinkPetalsBlock(Identifier, Direction.East, 3),
            27627 => new PinkPetalsBlock(Identifier, Direction.East, 4),
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

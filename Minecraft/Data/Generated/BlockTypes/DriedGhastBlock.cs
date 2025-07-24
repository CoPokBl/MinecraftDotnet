using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DriedGhastBlock(Identifier Identifier, Direction Facing, int Hydration, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:dried_ghast";
    public int ProtocolId => 715;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "dried_ghast";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:dried_ghast";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.625, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.625, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.625, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 21;
    public string TranslationKey => "block.minecraft.dried_ghast";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Hydration switch {
                    0 => Waterlogged switch {
                        true => 13826,
                        false => 13827,
                    },
                    1 => Waterlogged switch {
                        true => 13828,
                        false => 13829,
                    },
                    2 => Waterlogged switch {
                        true => 13830,
                        false => 13831,
                    },
                    3 => Waterlogged switch {
                        true => 13832,
                        false => 13833,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.South => Hydration switch {
                    0 => Waterlogged switch {
                        true => 13834,
                        false => 13835,
                    },
                    1 => Waterlogged switch {
                        true => 13836,
                        false => 13837,
                    },
                    2 => Waterlogged switch {
                        true => 13838,
                        false => 13839,
                    },
                    3 => Waterlogged switch {
                        true => 13840,
                        false => 13841,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.West => Hydration switch {
                    0 => Waterlogged switch {
                        true => 13842,
                        false => 13843,
                    },
                    1 => Waterlogged switch {
                        true => 13844,
                        false => 13845,
                    },
                    2 => Waterlogged switch {
                        true => 13846,
                        false => 13847,
                    },
                    3 => Waterlogged switch {
                        true => 13848,
                        false => 13849,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.East => Hydration switch {
                    0 => Waterlogged switch {
                        true => 13850,
                        false => 13851,
                    },
                    1 => Waterlogged switch {
                        true => 13852,
                        false => 13853,
                    },
                    2 => Waterlogged switch {
                        true => 13854,
                        false => 13855,
                    },
                    3 => Waterlogged switch {
                        true => 13856,
                        false => 13857,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13826 => new DriedGhastBlock(Identifier, Direction.North, 0, true),
            13827 => new DriedGhastBlock(Identifier, Direction.North, 0, false),
            13828 => new DriedGhastBlock(Identifier, Direction.North, 1, true),
            13829 => new DriedGhastBlock(Identifier, Direction.North, 1, false),
            13830 => new DriedGhastBlock(Identifier, Direction.North, 2, true),
            13831 => new DriedGhastBlock(Identifier, Direction.North, 2, false),
            13832 => new DriedGhastBlock(Identifier, Direction.North, 3, true),
            13833 => new DriedGhastBlock(Identifier, Direction.North, 3, false),
            13834 => new DriedGhastBlock(Identifier, Direction.South, 0, true),
            13835 => new DriedGhastBlock(Identifier, Direction.South, 0, false),
            13836 => new DriedGhastBlock(Identifier, Direction.South, 1, true),
            13837 => new DriedGhastBlock(Identifier, Direction.South, 1, false),
            13838 => new DriedGhastBlock(Identifier, Direction.South, 2, true),
            13839 => new DriedGhastBlock(Identifier, Direction.South, 2, false),
            13840 => new DriedGhastBlock(Identifier, Direction.South, 3, true),
            13841 => new DriedGhastBlock(Identifier, Direction.South, 3, false),
            13842 => new DriedGhastBlock(Identifier, Direction.West, 0, true),
            13843 => new DriedGhastBlock(Identifier, Direction.West, 0, false),
            13844 => new DriedGhastBlock(Identifier, Direction.West, 1, true),
            13845 => new DriedGhastBlock(Identifier, Direction.West, 1, false),
            13846 => new DriedGhastBlock(Identifier, Direction.West, 2, true),
            13847 => new DriedGhastBlock(Identifier, Direction.West, 2, false),
            13848 => new DriedGhastBlock(Identifier, Direction.West, 3, true),
            13849 => new DriedGhastBlock(Identifier, Direction.West, 3, false),
            13850 => new DriedGhastBlock(Identifier, Direction.East, 0, true),
            13851 => new DriedGhastBlock(Identifier, Direction.East, 0, false),
            13852 => new DriedGhastBlock(Identifier, Direction.East, 1, true),
            13853 => new DriedGhastBlock(Identifier, Direction.East, 1, false),
            13854 => new DriedGhastBlock(Identifier, Direction.East, 2, true),
            13855 => new DriedGhastBlock(Identifier, Direction.East, 2, false),
            13856 => new DriedGhastBlock(Identifier, Direction.East, 3, true),
            13857 => new DriedGhastBlock(Identifier, Direction.East, 3, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Hydration = int.Parse(properties["hydration"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}

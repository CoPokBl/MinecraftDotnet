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
    public int ProtocolId => 745;
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
                        true => 14903,
                        false => 14904,
                    },
                    1 => Waterlogged switch {
                        true => 14905,
                        false => 14906,
                    },
                    2 => Waterlogged switch {
                        true => 14907,
                        false => 14908,
                    },
                    3 => Waterlogged switch {
                        true => 14909,
                        false => 14910,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.South => Hydration switch {
                    0 => Waterlogged switch {
                        true => 14911,
                        false => 14912,
                    },
                    1 => Waterlogged switch {
                        true => 14913,
                        false => 14914,
                    },
                    2 => Waterlogged switch {
                        true => 14915,
                        false => 14916,
                    },
                    3 => Waterlogged switch {
                        true => 14917,
                        false => 14918,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.West => Hydration switch {
                    0 => Waterlogged switch {
                        true => 14919,
                        false => 14920,
                    },
                    1 => Waterlogged switch {
                        true => 14921,
                        false => 14922,
                    },
                    2 => Waterlogged switch {
                        true => 14923,
                        false => 14924,
                    },
                    3 => Waterlogged switch {
                        true => 14925,
                        false => 14926,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.East => Hydration switch {
                    0 => Waterlogged switch {
                        true => 14927,
                        false => 14928,
                    },
                    1 => Waterlogged switch {
                        true => 14929,
                        false => 14930,
                    },
                    2 => Waterlogged switch {
                        true => 14931,
                        false => 14932,
                    },
                    3 => Waterlogged switch {
                        true => 14933,
                        false => 14934,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14903 => new DriedGhastBlock(Identifier, Direction.North, 0, true),
            14904 => new DriedGhastBlock(Identifier, Direction.North, 0, false),
            14905 => new DriedGhastBlock(Identifier, Direction.North, 1, true),
            14906 => new DriedGhastBlock(Identifier, Direction.North, 1, false),
            14907 => new DriedGhastBlock(Identifier, Direction.North, 2, true),
            14908 => new DriedGhastBlock(Identifier, Direction.North, 2, false),
            14909 => new DriedGhastBlock(Identifier, Direction.North, 3, true),
            14910 => new DriedGhastBlock(Identifier, Direction.North, 3, false),
            14911 => new DriedGhastBlock(Identifier, Direction.South, 0, true),
            14912 => new DriedGhastBlock(Identifier, Direction.South, 0, false),
            14913 => new DriedGhastBlock(Identifier, Direction.South, 1, true),
            14914 => new DriedGhastBlock(Identifier, Direction.South, 1, false),
            14915 => new DriedGhastBlock(Identifier, Direction.South, 2, true),
            14916 => new DriedGhastBlock(Identifier, Direction.South, 2, false),
            14917 => new DriedGhastBlock(Identifier, Direction.South, 3, true),
            14918 => new DriedGhastBlock(Identifier, Direction.South, 3, false),
            14919 => new DriedGhastBlock(Identifier, Direction.West, 0, true),
            14920 => new DriedGhastBlock(Identifier, Direction.West, 0, false),
            14921 => new DriedGhastBlock(Identifier, Direction.West, 1, true),
            14922 => new DriedGhastBlock(Identifier, Direction.West, 1, false),
            14923 => new DriedGhastBlock(Identifier, Direction.West, 2, true),
            14924 => new DriedGhastBlock(Identifier, Direction.West, 2, false),
            14925 => new DriedGhastBlock(Identifier, Direction.West, 3, true),
            14926 => new DriedGhastBlock(Identifier, Direction.West, 3, false),
            14927 => new DriedGhastBlock(Identifier, Direction.East, 0, true),
            14928 => new DriedGhastBlock(Identifier, Direction.East, 0, false),
            14929 => new DriedGhastBlock(Identifier, Direction.East, 1, true),
            14930 => new DriedGhastBlock(Identifier, Direction.East, 1, false),
            14931 => new DriedGhastBlock(Identifier, Direction.East, 2, true),
            14932 => new DriedGhastBlock(Identifier, Direction.East, 2, false),
            14933 => new DriedGhastBlock(Identifier, Direction.East, 3, true),
            14934 => new DriedGhastBlock(Identifier, Direction.East, 3, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Hydration = properties.ChildrenMap.ContainsKey("hydration") ? int.Parse(properties["hydration"].GetString()) : Hydration,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("hydration", Hydration.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}

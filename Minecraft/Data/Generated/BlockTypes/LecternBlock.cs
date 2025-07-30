using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LecternBlock(Identifier Identifier, Direction Facing, bool HasBook, bool Powered) : IBlock {

    public Identifier Category => "minecraft:lectern";
    public int ProtocolId => 813;
    public double Hardness => 2.5;
    public double ExplosionResistance => 2.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:lectern";
    public Identifier? Item => "minecraft:lectern";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0], AABB[0.25, 0.125, 0.25] -> [0.75, 0.875, 0.75], AABB[0.0, 0.625, 0.0625] -> [0.25, 0.875, 0.3333333125], AABB[0.25, 0.625, 0.0625] -> [1.0, 0.875, 0.25], AABB[0.75, 0.625, 0.25] -> [1.0, 0.875, 0.3333333125], AABB[0.0, 0.75, 0.3333333125] -> [0.25, 1.0, 0.6041666875], AABB[0.75, 0.75, 0.3333333125] -> [1.0, 1.0, 0.6041666875], AABB[0.0, 0.875, 0.6041666875] -> [1.0, 1.125, 0.875], AABB[0.25, 0.875, 0.3333333125] -> [0.75, 1.0, 0.6041666875]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0], AABB[0.25, 0.125, 0.25] -> [0.75, 0.875, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0], AABB[0.25, 0.125, 0.25] -> [0.75, 0.875, 0.75]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0], AABB[0.25, 0.125, 0.25] -> [0.75, 0.875, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.lectern";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HasBook switch {
                    true => Powered switch {
                        true => 19505,
                        false => 19506,
                    },
                    false => Powered switch {
                        true => 19507,
                        false => 19508,
                    },
                },
                Direction.South => HasBook switch {
                    true => Powered switch {
                        true => 19509,
                        false => 19510,
                    },
                    false => Powered switch {
                        true => 19511,
                        false => 19512,
                    },
                },
                Direction.West => HasBook switch {
                    true => Powered switch {
                        true => 19513,
                        false => 19514,
                    },
                    false => Powered switch {
                        true => 19515,
                        false => 19516,
                    },
                },
                Direction.East => HasBook switch {
                    true => Powered switch {
                        true => 19517,
                        false => 19518,
                    },
                    false => Powered switch {
                        true => 19519,
                        false => 19520,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19505 => new LecternBlock(Identifier, Direction.North, true, true),
            19506 => new LecternBlock(Identifier, Direction.North, true, false),
            19507 => new LecternBlock(Identifier, Direction.North, false, true),
            19508 => new LecternBlock(Identifier, Direction.North, false, false),
            19509 => new LecternBlock(Identifier, Direction.South, true, true),
            19510 => new LecternBlock(Identifier, Direction.South, true, false),
            19511 => new LecternBlock(Identifier, Direction.South, false, true),
            19512 => new LecternBlock(Identifier, Direction.South, false, false),
            19513 => new LecternBlock(Identifier, Direction.West, true, true),
            19514 => new LecternBlock(Identifier, Direction.West, true, false),
            19515 => new LecternBlock(Identifier, Direction.West, false, true),
            19516 => new LecternBlock(Identifier, Direction.West, false, false),
            19517 => new LecternBlock(Identifier, Direction.East, true, true),
            19518 => new LecternBlock(Identifier, Direction.East, true, false),
            19519 => new LecternBlock(Identifier, Direction.East, false, true),
            19520 => new LecternBlock(Identifier, Direction.East, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HasBook = properties["has_book"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("has_book", HasBook.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}

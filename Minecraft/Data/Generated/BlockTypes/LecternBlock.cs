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
                        true => 20784,
                        false => 20785,
                    },
                    false => Powered switch {
                        true => 20786,
                        false => 20787,
                    },
                },
                Direction.South => HasBook switch {
                    true => Powered switch {
                        true => 20788,
                        false => 20789,
                    },
                    false => Powered switch {
                        true => 20790,
                        false => 20791,
                    },
                },
                Direction.West => HasBook switch {
                    true => Powered switch {
                        true => 20792,
                        false => 20793,
                    },
                    false => Powered switch {
                        true => 20794,
                        false => 20795,
                    },
                },
                Direction.East => HasBook switch {
                    true => Powered switch {
                        true => 20796,
                        false => 20797,
                    },
                    false => Powered switch {
                        true => 20798,
                        false => 20799,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20784 => new LecternBlock(Identifier, Direction.North, true, true),
            20785 => new LecternBlock(Identifier, Direction.North, true, false),
            20786 => new LecternBlock(Identifier, Direction.North, false, true),
            20787 => new LecternBlock(Identifier, Direction.North, false, false),
            20788 => new LecternBlock(Identifier, Direction.South, true, true),
            20789 => new LecternBlock(Identifier, Direction.South, true, false),
            20790 => new LecternBlock(Identifier, Direction.South, false, true),
            20791 => new LecternBlock(Identifier, Direction.South, false, false),
            20792 => new LecternBlock(Identifier, Direction.West, true, true),
            20793 => new LecternBlock(Identifier, Direction.West, true, false),
            20794 => new LecternBlock(Identifier, Direction.West, false, true),
            20795 => new LecternBlock(Identifier, Direction.West, false, false),
            20796 => new LecternBlock(Identifier, Direction.East, true, true),
            20797 => new LecternBlock(Identifier, Direction.East, true, false),
            20798 => new LecternBlock(Identifier, Direction.East, false, true),
            20799 => new LecternBlock(Identifier, Direction.East, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HasBook = properties.Contains("has_book") ? properties["has_book"].GetString() == "true" : HasBook,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("has_book", new StringTag(HasBook.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}

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
    public int ProtocolId => 843;
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
                        true => 20582,
                        false => 20583,
                    },
                    false => Powered switch {
                        true => 20584,
                        false => 20585,
                    },
                },
                Direction.South => HasBook switch {
                    true => Powered switch {
                        true => 20586,
                        false => 20587,
                    },
                    false => Powered switch {
                        true => 20588,
                        false => 20589,
                    },
                },
                Direction.West => HasBook switch {
                    true => Powered switch {
                        true => 20590,
                        false => 20591,
                    },
                    false => Powered switch {
                        true => 20592,
                        false => 20593,
                    },
                },
                Direction.East => HasBook switch {
                    true => Powered switch {
                        true => 20594,
                        false => 20595,
                    },
                    false => Powered switch {
                        true => 20596,
                        false => 20597,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20582 => new LecternBlock(Identifier, Direction.North, true, true),
            20583 => new LecternBlock(Identifier, Direction.North, true, false),
            20584 => new LecternBlock(Identifier, Direction.North, false, true),
            20585 => new LecternBlock(Identifier, Direction.North, false, false),
            20586 => new LecternBlock(Identifier, Direction.South, true, true),
            20587 => new LecternBlock(Identifier, Direction.South, true, false),
            20588 => new LecternBlock(Identifier, Direction.South, false, true),
            20589 => new LecternBlock(Identifier, Direction.South, false, false),
            20590 => new LecternBlock(Identifier, Direction.West, true, true),
            20591 => new LecternBlock(Identifier, Direction.West, true, false),
            20592 => new LecternBlock(Identifier, Direction.West, false, true),
            20593 => new LecternBlock(Identifier, Direction.West, false, false),
            20594 => new LecternBlock(Identifier, Direction.East, true, true),
            20595 => new LecternBlock(Identifier, Direction.East, true, false),
            20596 => new LecternBlock(Identifier, Direction.East, false, true),
            20597 => new LecternBlock(Identifier, Direction.East, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HasBook = properties.ChildrenMap.ContainsKey("has_book") ? properties["has_book"].GetString() == "true" : HasBook,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
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

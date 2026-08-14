using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LecternBlock(Identifier Identifier, Direction Facing, bool HasBook, bool Powered) : IBlock, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("minecraft:lectern", "block.minecraft.lectern", 2.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:lectern", "minecraft:lectern", BlockInfo.VanillaOnly, "minecraft:blocks/lectern");
    private static readonly BlockStateInfo I0 = new(2.5f, 0, 0, PushReaction.Normal, 13, "wood", NoteBlockInstrument.Bass, false, true, false, true, true, false, false, false, true, false, true, false, false, false, true, false, false, false, [], null, BlockShapes.S625, BlockShapes.S626, BlockShapes.S1, BlockShapes.S626, BlockShapes.S626, BlockShapes.S626);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S627 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S628 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S629 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I1, I1, I1, I1, I2, I2, I2, I2, I3, I3, I3, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 20784];

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public ICollisionBox SupportShape => StateInfo.SupportShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


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

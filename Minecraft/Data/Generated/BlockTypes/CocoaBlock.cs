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
public record CocoaBlock(Identifier Identifier, int Age, Direction Facing) : IBlock, IAged, IHorizontalFacing {
    private static readonly BlockInfo Data = new("minecraft:cocoa", "block.minecraft.cocoa", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cocoa_beans", BlockInfo.VanillaOnly, "minecraft:blocks/cocoa");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 0, PushReaction.Destroy, 7, "wood", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false, false, [], null, BlockShapes.S484, BlockShapes.S484, BlockShapes.S1, BlockShapes.S1, BlockShapes.S484, BlockShapes.S484);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S485, CollisionShape = BlockShapes.S485, VisualShape = BlockShapes.S485, SupportShape = BlockShapes.S485 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S486, CollisionShape = BlockShapes.S486, VisualShape = BlockShapes.S486, SupportShape = BlockShapes.S486 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S487, CollisionShape = BlockShapes.S487, VisualShape = BlockShapes.S487, SupportShape = BlockShapes.S487 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S488, CollisionShape = BlockShapes.S488, VisualShape = BlockShapes.S488, SupportShape = BlockShapes.S488 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S489, CollisionShape = BlockShapes.S489, VisualShape = BlockShapes.S489, SupportShape = BlockShapes.S489 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S490, CollisionShape = BlockShapes.S490, VisualShape = BlockShapes.S490, SupportShape = BlockShapes.S490 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S491, CollisionShape = BlockShapes.S491, VisualShape = BlockShapes.S491, SupportShape = BlockShapes.S491 };
    private static readonly BlockStateInfo I8 = I0 with { RandomlyTicking = false, BlockShape = BlockShapes.S492, CollisionShape = BlockShapes.S492, VisualShape = BlockShapes.S492, SupportShape = BlockShapes.S492 };
    private static readonly BlockStateInfo I9 = I0 with { RandomlyTicking = false, BlockShape = BlockShapes.S493, CollisionShape = BlockShapes.S493, VisualShape = BlockShapes.S493, SupportShape = BlockShapes.S493 };
    private static readonly BlockStateInfo I10 = I0 with { RandomlyTicking = false, BlockShape = BlockShapes.S494, CollisionShape = BlockShapes.S494, VisualShape = BlockShapes.S494, SupportShape = BlockShapes.S494 };
    private static readonly BlockStateInfo I11 = I0 with { RandomlyTicking = false, BlockShape = BlockShapes.S495, CollisionShape = BlockShapes.S495, VisualShape = BlockShapes.S495, SupportShape = BlockShapes.S495 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11
    ];

    public BlockStateInfo StateInfo => States[StateId - 9481];

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

    public IBlock WithAge(int age) => this with { Age = age };

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Age switch {
                0 => Facing switch {
                    Direction.North => 9481,
                    Direction.South => 9482,
                    Direction.West => 9483,
                    Direction.East => 9484,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                1 => Facing switch {
                    Direction.North => 9485,
                    Direction.South => 9486,
                    Direction.West => 9487,
                    Direction.East => 9488,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                2 => Facing switch {
                    Direction.North => 9489,
                    Direction.South => 9490,
                    Direction.West => 9491,
                    Direction.East => 9492,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9481 => new CocoaBlock(Identifier, 0, Direction.North),
            9482 => new CocoaBlock(Identifier, 0, Direction.South),
            9483 => new CocoaBlock(Identifier, 0, Direction.West),
            9484 => new CocoaBlock(Identifier, 0, Direction.East),
            9485 => new CocoaBlock(Identifier, 1, Direction.North),
            9486 => new CocoaBlock(Identifier, 1, Direction.South),
            9487 => new CocoaBlock(Identifier, 1, Direction.West),
            9488 => new CocoaBlock(Identifier, 1, Direction.East),
            9489 => new CocoaBlock(Identifier, 2, Direction.North),
            9490 => new CocoaBlock(Identifier, 2, Direction.South),
            9491 => new CocoaBlock(Identifier, 2, Direction.West),
            9492 => new CocoaBlock(Identifier, 2, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString())),
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}

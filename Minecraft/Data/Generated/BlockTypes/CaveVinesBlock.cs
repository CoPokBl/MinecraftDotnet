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
public record CaveVinesBlock(Identifier Identifier, int Age, bool Berries) : IBlock, IAged, IBerried {
    private static readonly BlockInfo Data = new("block.minecraft.cave_vines", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:glow_berries", BlockInfo.VanillaOnly, "minecraft:blocks/cave_vines");
    private static readonly BlockStateInfo I0 = new(0f, 14, 0, PushReaction.Popped, 7, "cave_vines", NoteBlockInstrument.Harp, true, false, false, true, false, false, false, false, false, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S401, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = false };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, RandomlyTicking = false };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 33606];

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
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
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithAge(int age) => this with { Age = age };

    public IBlock WithBerries(bool berries) => this with { Berries = berries };


    public uint StateId {
        get {
            return Age switch {
                0 => Berries switch {
                    true => 33606,
                    false => 33607,
                },
                1 => Berries switch {
                    true => 33608,
                    false => 33609,
                },
                2 => Berries switch {
                    true => 33610,
                    false => 33611,
                },
                3 => Berries switch {
                    true => 33612,
                    false => 33613,
                },
                4 => Berries switch {
                    true => 33614,
                    false => 33615,
                },
                5 => Berries switch {
                    true => 33616,
                    false => 33617,
                },
                6 => Berries switch {
                    true => 33618,
                    false => 33619,
                },
                7 => Berries switch {
                    true => 33620,
                    false => 33621,
                },
                8 => Berries switch {
                    true => 33622,
                    false => 33623,
                },
                9 => Berries switch {
                    true => 33624,
                    false => 33625,
                },
                10 => Berries switch {
                    true => 33626,
                    false => 33627,
                },
                11 => Berries switch {
                    true => 33628,
                    false => 33629,
                },
                12 => Berries switch {
                    true => 33630,
                    false => 33631,
                },
                13 => Berries switch {
                    true => 33632,
                    false => 33633,
                },
                14 => Berries switch {
                    true => 33634,
                    false => 33635,
                },
                15 => Berries switch {
                    true => 33636,
                    false => 33637,
                },
                16 => Berries switch {
                    true => 33638,
                    false => 33639,
                },
                17 => Berries switch {
                    true => 33640,
                    false => 33641,
                },
                18 => Berries switch {
                    true => 33642,
                    false => 33643,
                },
                19 => Berries switch {
                    true => 33644,
                    false => 33645,
                },
                20 => Berries switch {
                    true => 33646,
                    false => 33647,
                },
                21 => Berries switch {
                    true => 33648,
                    false => 33649,
                },
                22 => Berries switch {
                    true => 33650,
                    false => 33651,
                },
                23 => Berries switch {
                    true => 33652,
                    false => 33653,
                },
                24 => Berries switch {
                    true => 33654,
                    false => 33655,
                },
                25 => Berries switch {
                    true => 33656,
                    false => 33657,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33606 => new CaveVinesBlock(Identifier, 0, true),
            33607 => new CaveVinesBlock(Identifier, 0, false),
            33608 => new CaveVinesBlock(Identifier, 1, true),
            33609 => new CaveVinesBlock(Identifier, 1, false),
            33610 => new CaveVinesBlock(Identifier, 2, true),
            33611 => new CaveVinesBlock(Identifier, 2, false),
            33612 => new CaveVinesBlock(Identifier, 3, true),
            33613 => new CaveVinesBlock(Identifier, 3, false),
            33614 => new CaveVinesBlock(Identifier, 4, true),
            33615 => new CaveVinesBlock(Identifier, 4, false),
            33616 => new CaveVinesBlock(Identifier, 5, true),
            33617 => new CaveVinesBlock(Identifier, 5, false),
            33618 => new CaveVinesBlock(Identifier, 6, true),
            33619 => new CaveVinesBlock(Identifier, 6, false),
            33620 => new CaveVinesBlock(Identifier, 7, true),
            33621 => new CaveVinesBlock(Identifier, 7, false),
            33622 => new CaveVinesBlock(Identifier, 8, true),
            33623 => new CaveVinesBlock(Identifier, 8, false),
            33624 => new CaveVinesBlock(Identifier, 9, true),
            33625 => new CaveVinesBlock(Identifier, 9, false),
            33626 => new CaveVinesBlock(Identifier, 10, true),
            33627 => new CaveVinesBlock(Identifier, 10, false),
            33628 => new CaveVinesBlock(Identifier, 11, true),
            33629 => new CaveVinesBlock(Identifier, 11, false),
            33630 => new CaveVinesBlock(Identifier, 12, true),
            33631 => new CaveVinesBlock(Identifier, 12, false),
            33632 => new CaveVinesBlock(Identifier, 13, true),
            33633 => new CaveVinesBlock(Identifier, 13, false),
            33634 => new CaveVinesBlock(Identifier, 14, true),
            33635 => new CaveVinesBlock(Identifier, 14, false),
            33636 => new CaveVinesBlock(Identifier, 15, true),
            33637 => new CaveVinesBlock(Identifier, 15, false),
            33638 => new CaveVinesBlock(Identifier, 16, true),
            33639 => new CaveVinesBlock(Identifier, 16, false),
            33640 => new CaveVinesBlock(Identifier, 17, true),
            33641 => new CaveVinesBlock(Identifier, 17, false),
            33642 => new CaveVinesBlock(Identifier, 18, true),
            33643 => new CaveVinesBlock(Identifier, 18, false),
            33644 => new CaveVinesBlock(Identifier, 19, true),
            33645 => new CaveVinesBlock(Identifier, 19, false),
            33646 => new CaveVinesBlock(Identifier, 20, true),
            33647 => new CaveVinesBlock(Identifier, 20, false),
            33648 => new CaveVinesBlock(Identifier, 21, true),
            33649 => new CaveVinesBlock(Identifier, 21, false),
            33650 => new CaveVinesBlock(Identifier, 22, true),
            33651 => new CaveVinesBlock(Identifier, 22, false),
            33652 => new CaveVinesBlock(Identifier, 23, true),
            33653 => new CaveVinesBlock(Identifier, 23, false),
            33654 => new CaveVinesBlock(Identifier, 24, true),
            33655 => new CaveVinesBlock(Identifier, 24, false),
            33656 => new CaveVinesBlock(Identifier, 25, true),
            33657 => new CaveVinesBlock(Identifier, 25, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
            Berries = properties.Contains("berries") ? properties["berries"].GetString() == "true" : Berries,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString())),
            ("berries", new StringTag(Berries.ToString().ToLower()))
        );
    }
    
}

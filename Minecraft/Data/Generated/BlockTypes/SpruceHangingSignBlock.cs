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
public record SpruceHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.spruce_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:spruce_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/spruce_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 34, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 7567];

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

    public IBlock WithAttached(bool attached) => this with { Attached = attached };

    public IBlock WithRotation(int rotation) => this with { Rotation = rotation };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7567,
                        false => 7568,
                    },
                    1 => Waterlogged switch {
                        true => 7569,
                        false => 7570,
                    },
                    2 => Waterlogged switch {
                        true => 7571,
                        false => 7572,
                    },
                    3 => Waterlogged switch {
                        true => 7573,
                        false => 7574,
                    },
                    4 => Waterlogged switch {
                        true => 7575,
                        false => 7576,
                    },
                    5 => Waterlogged switch {
                        true => 7577,
                        false => 7578,
                    },
                    6 => Waterlogged switch {
                        true => 7579,
                        false => 7580,
                    },
                    7 => Waterlogged switch {
                        true => 7581,
                        false => 7582,
                    },
                    8 => Waterlogged switch {
                        true => 7583,
                        false => 7584,
                    },
                    9 => Waterlogged switch {
                        true => 7585,
                        false => 7586,
                    },
                    10 => Waterlogged switch {
                        true => 7587,
                        false => 7588,
                    },
                    11 => Waterlogged switch {
                        true => 7589,
                        false => 7590,
                    },
                    12 => Waterlogged switch {
                        true => 7591,
                        false => 7592,
                    },
                    13 => Waterlogged switch {
                        true => 7593,
                        false => 7594,
                    },
                    14 => Waterlogged switch {
                        true => 7595,
                        false => 7596,
                    },
                    15 => Waterlogged switch {
                        true => 7597,
                        false => 7598,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7599,
                        false => 7600,
                    },
                    1 => Waterlogged switch {
                        true => 7601,
                        false => 7602,
                    },
                    2 => Waterlogged switch {
                        true => 7603,
                        false => 7604,
                    },
                    3 => Waterlogged switch {
                        true => 7605,
                        false => 7606,
                    },
                    4 => Waterlogged switch {
                        true => 7607,
                        false => 7608,
                    },
                    5 => Waterlogged switch {
                        true => 7609,
                        false => 7610,
                    },
                    6 => Waterlogged switch {
                        true => 7611,
                        false => 7612,
                    },
                    7 => Waterlogged switch {
                        true => 7613,
                        false => 7614,
                    },
                    8 => Waterlogged switch {
                        true => 7615,
                        false => 7616,
                    },
                    9 => Waterlogged switch {
                        true => 7617,
                        false => 7618,
                    },
                    10 => Waterlogged switch {
                        true => 7619,
                        false => 7620,
                    },
                    11 => Waterlogged switch {
                        true => 7621,
                        false => 7622,
                    },
                    12 => Waterlogged switch {
                        true => 7623,
                        false => 7624,
                    },
                    13 => Waterlogged switch {
                        true => 7625,
                        false => 7626,
                    },
                    14 => Waterlogged switch {
                        true => 7627,
                        false => 7628,
                    },
                    15 => Waterlogged switch {
                        true => 7629,
                        false => 7630,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7567 => new SpruceHangingSignBlock(Identifier, true, 0, true),
            7568 => new SpruceHangingSignBlock(Identifier, true, 0, false),
            7569 => new SpruceHangingSignBlock(Identifier, true, 1, true),
            7570 => new SpruceHangingSignBlock(Identifier, true, 1, false),
            7571 => new SpruceHangingSignBlock(Identifier, true, 2, true),
            7572 => new SpruceHangingSignBlock(Identifier, true, 2, false),
            7573 => new SpruceHangingSignBlock(Identifier, true, 3, true),
            7574 => new SpruceHangingSignBlock(Identifier, true, 3, false),
            7575 => new SpruceHangingSignBlock(Identifier, true, 4, true),
            7576 => new SpruceHangingSignBlock(Identifier, true, 4, false),
            7577 => new SpruceHangingSignBlock(Identifier, true, 5, true),
            7578 => new SpruceHangingSignBlock(Identifier, true, 5, false),
            7579 => new SpruceHangingSignBlock(Identifier, true, 6, true),
            7580 => new SpruceHangingSignBlock(Identifier, true, 6, false),
            7581 => new SpruceHangingSignBlock(Identifier, true, 7, true),
            7582 => new SpruceHangingSignBlock(Identifier, true, 7, false),
            7583 => new SpruceHangingSignBlock(Identifier, true, 8, true),
            7584 => new SpruceHangingSignBlock(Identifier, true, 8, false),
            7585 => new SpruceHangingSignBlock(Identifier, true, 9, true),
            7586 => new SpruceHangingSignBlock(Identifier, true, 9, false),
            7587 => new SpruceHangingSignBlock(Identifier, true, 10, true),
            7588 => new SpruceHangingSignBlock(Identifier, true, 10, false),
            7589 => new SpruceHangingSignBlock(Identifier, true, 11, true),
            7590 => new SpruceHangingSignBlock(Identifier, true, 11, false),
            7591 => new SpruceHangingSignBlock(Identifier, true, 12, true),
            7592 => new SpruceHangingSignBlock(Identifier, true, 12, false),
            7593 => new SpruceHangingSignBlock(Identifier, true, 13, true),
            7594 => new SpruceHangingSignBlock(Identifier, true, 13, false),
            7595 => new SpruceHangingSignBlock(Identifier, true, 14, true),
            7596 => new SpruceHangingSignBlock(Identifier, true, 14, false),
            7597 => new SpruceHangingSignBlock(Identifier, true, 15, true),
            7598 => new SpruceHangingSignBlock(Identifier, true, 15, false),
            7599 => new SpruceHangingSignBlock(Identifier, false, 0, true),
            7600 => new SpruceHangingSignBlock(Identifier, false, 0, false),
            7601 => new SpruceHangingSignBlock(Identifier, false, 1, true),
            7602 => new SpruceHangingSignBlock(Identifier, false, 1, false),
            7603 => new SpruceHangingSignBlock(Identifier, false, 2, true),
            7604 => new SpruceHangingSignBlock(Identifier, false, 2, false),
            7605 => new SpruceHangingSignBlock(Identifier, false, 3, true),
            7606 => new SpruceHangingSignBlock(Identifier, false, 3, false),
            7607 => new SpruceHangingSignBlock(Identifier, false, 4, true),
            7608 => new SpruceHangingSignBlock(Identifier, false, 4, false),
            7609 => new SpruceHangingSignBlock(Identifier, false, 5, true),
            7610 => new SpruceHangingSignBlock(Identifier, false, 5, false),
            7611 => new SpruceHangingSignBlock(Identifier, false, 6, true),
            7612 => new SpruceHangingSignBlock(Identifier, false, 6, false),
            7613 => new SpruceHangingSignBlock(Identifier, false, 7, true),
            7614 => new SpruceHangingSignBlock(Identifier, false, 7, false),
            7615 => new SpruceHangingSignBlock(Identifier, false, 8, true),
            7616 => new SpruceHangingSignBlock(Identifier, false, 8, false),
            7617 => new SpruceHangingSignBlock(Identifier, false, 9, true),
            7618 => new SpruceHangingSignBlock(Identifier, false, 9, false),
            7619 => new SpruceHangingSignBlock(Identifier, false, 10, true),
            7620 => new SpruceHangingSignBlock(Identifier, false, 10, false),
            7621 => new SpruceHangingSignBlock(Identifier, false, 11, true),
            7622 => new SpruceHangingSignBlock(Identifier, false, 11, false),
            7623 => new SpruceHangingSignBlock(Identifier, false, 12, true),
            7624 => new SpruceHangingSignBlock(Identifier, false, 12, false),
            7625 => new SpruceHangingSignBlock(Identifier, false, 13, true),
            7626 => new SpruceHangingSignBlock(Identifier, false, 13, false),
            7627 => new SpruceHangingSignBlock(Identifier, false, 14, true),
            7628 => new SpruceHangingSignBlock(Identifier, false, 14, false),
            7629 => new SpruceHangingSignBlock(Identifier, false, 15, true),
            7630 => new SpruceHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.Contains("attached") ? properties["attached"].GetString() == "true" : Attached,
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attached", new StringTag(Attached.ToString().ToLower())),
            ("rotation", new StringTag(Rotation.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}

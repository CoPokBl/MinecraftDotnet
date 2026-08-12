using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TripwireBlock(Identifier Identifier, bool Attached, bool Disarmed, bool East, bool North, bool Powered, bool South, bool West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:tripwire", "block.minecraft.tripwire", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:string", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, [], null, BlockShapes.S923, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S87 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 9599];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Attached switch {
                true => Disarmed switch {
                    true => East switch {
                        true => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9599,
                                        false => 9600,
                                    },
                                    false => West switch {
                                        true => 9601,
                                        false => 9602,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9603,
                                        false => 9604,
                                    },
                                    false => West switch {
                                        true => 9605,
                                        false => 9606,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9607,
                                        false => 9608,
                                    },
                                    false => West switch {
                                        true => 9609,
                                        false => 9610,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9611,
                                        false => 9612,
                                    },
                                    false => West switch {
                                        true => 9613,
                                        false => 9614,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9615,
                                        false => 9616,
                                    },
                                    false => West switch {
                                        true => 9617,
                                        false => 9618,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9619,
                                        false => 9620,
                                    },
                                    false => West switch {
                                        true => 9621,
                                        false => 9622,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9623,
                                        false => 9624,
                                    },
                                    false => West switch {
                                        true => 9625,
                                        false => 9626,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9627,
                                        false => 9628,
                                    },
                                    false => West switch {
                                        true => 9629,
                                        false => 9630,
                                    },
                                },
                            },
                        },
                    },
                    false => East switch {
                        true => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9631,
                                        false => 9632,
                                    },
                                    false => West switch {
                                        true => 9633,
                                        false => 9634,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9635,
                                        false => 9636,
                                    },
                                    false => West switch {
                                        true => 9637,
                                        false => 9638,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9639,
                                        false => 9640,
                                    },
                                    false => West switch {
                                        true => 9641,
                                        false => 9642,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9643,
                                        false => 9644,
                                    },
                                    false => West switch {
                                        true => 9645,
                                        false => 9646,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9647,
                                        false => 9648,
                                    },
                                    false => West switch {
                                        true => 9649,
                                        false => 9650,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9651,
                                        false => 9652,
                                    },
                                    false => West switch {
                                        true => 9653,
                                        false => 9654,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9655,
                                        false => 9656,
                                    },
                                    false => West switch {
                                        true => 9657,
                                        false => 9658,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9659,
                                        false => 9660,
                                    },
                                    false => West switch {
                                        true => 9661,
                                        false => 9662,
                                    },
                                },
                            },
                        },
                    },
                },
                false => Disarmed switch {
                    true => East switch {
                        true => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9663,
                                        false => 9664,
                                    },
                                    false => West switch {
                                        true => 9665,
                                        false => 9666,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9667,
                                        false => 9668,
                                    },
                                    false => West switch {
                                        true => 9669,
                                        false => 9670,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9671,
                                        false => 9672,
                                    },
                                    false => West switch {
                                        true => 9673,
                                        false => 9674,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9675,
                                        false => 9676,
                                    },
                                    false => West switch {
                                        true => 9677,
                                        false => 9678,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9679,
                                        false => 9680,
                                    },
                                    false => West switch {
                                        true => 9681,
                                        false => 9682,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9683,
                                        false => 9684,
                                    },
                                    false => West switch {
                                        true => 9685,
                                        false => 9686,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9687,
                                        false => 9688,
                                    },
                                    false => West switch {
                                        true => 9689,
                                        false => 9690,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9691,
                                        false => 9692,
                                    },
                                    false => West switch {
                                        true => 9693,
                                        false => 9694,
                                    },
                                },
                            },
                        },
                    },
                    false => East switch {
                        true => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9695,
                                        false => 9696,
                                    },
                                    false => West switch {
                                        true => 9697,
                                        false => 9698,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9699,
                                        false => 9700,
                                    },
                                    false => West switch {
                                        true => 9701,
                                        false => 9702,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9703,
                                        false => 9704,
                                    },
                                    false => West switch {
                                        true => 9705,
                                        false => 9706,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9707,
                                        false => 9708,
                                    },
                                    false => West switch {
                                        true => 9709,
                                        false => 9710,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9711,
                                        false => 9712,
                                    },
                                    false => West switch {
                                        true => 9713,
                                        false => 9714,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9715,
                                        false => 9716,
                                    },
                                    false => West switch {
                                        true => 9717,
                                        false => 9718,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9719,
                                        false => 9720,
                                    },
                                    false => West switch {
                                        true => 9721,
                                        false => 9722,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9723,
                                        false => 9724,
                                    },
                                    false => West switch {
                                        true => 9725,
                                        false => 9726,
                                    },
                                },
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9599 => new TripwireBlock(Identifier, true, true, true, true, true, true, true),
            9600 => new TripwireBlock(Identifier, true, true, true, true, true, true, false),
            9601 => new TripwireBlock(Identifier, true, true, true, true, true, false, true),
            9602 => new TripwireBlock(Identifier, true, true, true, true, true, false, false),
            9603 => new TripwireBlock(Identifier, true, true, true, true, false, true, true),
            9604 => new TripwireBlock(Identifier, true, true, true, true, false, true, false),
            9605 => new TripwireBlock(Identifier, true, true, true, true, false, false, true),
            9606 => new TripwireBlock(Identifier, true, true, true, true, false, false, false),
            9607 => new TripwireBlock(Identifier, true, true, true, false, true, true, true),
            9608 => new TripwireBlock(Identifier, true, true, true, false, true, true, false),
            9609 => new TripwireBlock(Identifier, true, true, true, false, true, false, true),
            9610 => new TripwireBlock(Identifier, true, true, true, false, true, false, false),
            9611 => new TripwireBlock(Identifier, true, true, true, false, false, true, true),
            9612 => new TripwireBlock(Identifier, true, true, true, false, false, true, false),
            9613 => new TripwireBlock(Identifier, true, true, true, false, false, false, true),
            9614 => new TripwireBlock(Identifier, true, true, true, false, false, false, false),
            9615 => new TripwireBlock(Identifier, true, true, false, true, true, true, true),
            9616 => new TripwireBlock(Identifier, true, true, false, true, true, true, false),
            9617 => new TripwireBlock(Identifier, true, true, false, true, true, false, true),
            9618 => new TripwireBlock(Identifier, true, true, false, true, true, false, false),
            9619 => new TripwireBlock(Identifier, true, true, false, true, false, true, true),
            9620 => new TripwireBlock(Identifier, true, true, false, true, false, true, false),
            9621 => new TripwireBlock(Identifier, true, true, false, true, false, false, true),
            9622 => new TripwireBlock(Identifier, true, true, false, true, false, false, false),
            9623 => new TripwireBlock(Identifier, true, true, false, false, true, true, true),
            9624 => new TripwireBlock(Identifier, true, true, false, false, true, true, false),
            9625 => new TripwireBlock(Identifier, true, true, false, false, true, false, true),
            9626 => new TripwireBlock(Identifier, true, true, false, false, true, false, false),
            9627 => new TripwireBlock(Identifier, true, true, false, false, false, true, true),
            9628 => new TripwireBlock(Identifier, true, true, false, false, false, true, false),
            9629 => new TripwireBlock(Identifier, true, true, false, false, false, false, true),
            9630 => new TripwireBlock(Identifier, true, true, false, false, false, false, false),
            9631 => new TripwireBlock(Identifier, true, false, true, true, true, true, true),
            9632 => new TripwireBlock(Identifier, true, false, true, true, true, true, false),
            9633 => new TripwireBlock(Identifier, true, false, true, true, true, false, true),
            9634 => new TripwireBlock(Identifier, true, false, true, true, true, false, false),
            9635 => new TripwireBlock(Identifier, true, false, true, true, false, true, true),
            9636 => new TripwireBlock(Identifier, true, false, true, true, false, true, false),
            9637 => new TripwireBlock(Identifier, true, false, true, true, false, false, true),
            9638 => new TripwireBlock(Identifier, true, false, true, true, false, false, false),
            9639 => new TripwireBlock(Identifier, true, false, true, false, true, true, true),
            9640 => new TripwireBlock(Identifier, true, false, true, false, true, true, false),
            9641 => new TripwireBlock(Identifier, true, false, true, false, true, false, true),
            9642 => new TripwireBlock(Identifier, true, false, true, false, true, false, false),
            9643 => new TripwireBlock(Identifier, true, false, true, false, false, true, true),
            9644 => new TripwireBlock(Identifier, true, false, true, false, false, true, false),
            9645 => new TripwireBlock(Identifier, true, false, true, false, false, false, true),
            9646 => new TripwireBlock(Identifier, true, false, true, false, false, false, false),
            9647 => new TripwireBlock(Identifier, true, false, false, true, true, true, true),
            9648 => new TripwireBlock(Identifier, true, false, false, true, true, true, false),
            9649 => new TripwireBlock(Identifier, true, false, false, true, true, false, true),
            9650 => new TripwireBlock(Identifier, true, false, false, true, true, false, false),
            9651 => new TripwireBlock(Identifier, true, false, false, true, false, true, true),
            9652 => new TripwireBlock(Identifier, true, false, false, true, false, true, false),
            9653 => new TripwireBlock(Identifier, true, false, false, true, false, false, true),
            9654 => new TripwireBlock(Identifier, true, false, false, true, false, false, false),
            9655 => new TripwireBlock(Identifier, true, false, false, false, true, true, true),
            9656 => new TripwireBlock(Identifier, true, false, false, false, true, true, false),
            9657 => new TripwireBlock(Identifier, true, false, false, false, true, false, true),
            9658 => new TripwireBlock(Identifier, true, false, false, false, true, false, false),
            9659 => new TripwireBlock(Identifier, true, false, false, false, false, true, true),
            9660 => new TripwireBlock(Identifier, true, false, false, false, false, true, false),
            9661 => new TripwireBlock(Identifier, true, false, false, false, false, false, true),
            9662 => new TripwireBlock(Identifier, true, false, false, false, false, false, false),
            9663 => new TripwireBlock(Identifier, false, true, true, true, true, true, true),
            9664 => new TripwireBlock(Identifier, false, true, true, true, true, true, false),
            9665 => new TripwireBlock(Identifier, false, true, true, true, true, false, true),
            9666 => new TripwireBlock(Identifier, false, true, true, true, true, false, false),
            9667 => new TripwireBlock(Identifier, false, true, true, true, false, true, true),
            9668 => new TripwireBlock(Identifier, false, true, true, true, false, true, false),
            9669 => new TripwireBlock(Identifier, false, true, true, true, false, false, true),
            9670 => new TripwireBlock(Identifier, false, true, true, true, false, false, false),
            9671 => new TripwireBlock(Identifier, false, true, true, false, true, true, true),
            9672 => new TripwireBlock(Identifier, false, true, true, false, true, true, false),
            9673 => new TripwireBlock(Identifier, false, true, true, false, true, false, true),
            9674 => new TripwireBlock(Identifier, false, true, true, false, true, false, false),
            9675 => new TripwireBlock(Identifier, false, true, true, false, false, true, true),
            9676 => new TripwireBlock(Identifier, false, true, true, false, false, true, false),
            9677 => new TripwireBlock(Identifier, false, true, true, false, false, false, true),
            9678 => new TripwireBlock(Identifier, false, true, true, false, false, false, false),
            9679 => new TripwireBlock(Identifier, false, true, false, true, true, true, true),
            9680 => new TripwireBlock(Identifier, false, true, false, true, true, true, false),
            9681 => new TripwireBlock(Identifier, false, true, false, true, true, false, true),
            9682 => new TripwireBlock(Identifier, false, true, false, true, true, false, false),
            9683 => new TripwireBlock(Identifier, false, true, false, true, false, true, true),
            9684 => new TripwireBlock(Identifier, false, true, false, true, false, true, false),
            9685 => new TripwireBlock(Identifier, false, true, false, true, false, false, true),
            9686 => new TripwireBlock(Identifier, false, true, false, true, false, false, false),
            9687 => new TripwireBlock(Identifier, false, true, false, false, true, true, true),
            9688 => new TripwireBlock(Identifier, false, true, false, false, true, true, false),
            9689 => new TripwireBlock(Identifier, false, true, false, false, true, false, true),
            9690 => new TripwireBlock(Identifier, false, true, false, false, true, false, false),
            9691 => new TripwireBlock(Identifier, false, true, false, false, false, true, true),
            9692 => new TripwireBlock(Identifier, false, true, false, false, false, true, false),
            9693 => new TripwireBlock(Identifier, false, true, false, false, false, false, true),
            9694 => new TripwireBlock(Identifier, false, true, false, false, false, false, false),
            9695 => new TripwireBlock(Identifier, false, false, true, true, true, true, true),
            9696 => new TripwireBlock(Identifier, false, false, true, true, true, true, false),
            9697 => new TripwireBlock(Identifier, false, false, true, true, true, false, true),
            9698 => new TripwireBlock(Identifier, false, false, true, true, true, false, false),
            9699 => new TripwireBlock(Identifier, false, false, true, true, false, true, true),
            9700 => new TripwireBlock(Identifier, false, false, true, true, false, true, false),
            9701 => new TripwireBlock(Identifier, false, false, true, true, false, false, true),
            9702 => new TripwireBlock(Identifier, false, false, true, true, false, false, false),
            9703 => new TripwireBlock(Identifier, false, false, true, false, true, true, true),
            9704 => new TripwireBlock(Identifier, false, false, true, false, true, true, false),
            9705 => new TripwireBlock(Identifier, false, false, true, false, true, false, true),
            9706 => new TripwireBlock(Identifier, false, false, true, false, true, false, false),
            9707 => new TripwireBlock(Identifier, false, false, true, false, false, true, true),
            9708 => new TripwireBlock(Identifier, false, false, true, false, false, true, false),
            9709 => new TripwireBlock(Identifier, false, false, true, false, false, false, true),
            9710 => new TripwireBlock(Identifier, false, false, true, false, false, false, false),
            9711 => new TripwireBlock(Identifier, false, false, false, true, true, true, true),
            9712 => new TripwireBlock(Identifier, false, false, false, true, true, true, false),
            9713 => new TripwireBlock(Identifier, false, false, false, true, true, false, true),
            9714 => new TripwireBlock(Identifier, false, false, false, true, true, false, false),
            9715 => new TripwireBlock(Identifier, false, false, false, true, false, true, true),
            9716 => new TripwireBlock(Identifier, false, false, false, true, false, true, false),
            9717 => new TripwireBlock(Identifier, false, false, false, true, false, false, true),
            9718 => new TripwireBlock(Identifier, false, false, false, true, false, false, false),
            9719 => new TripwireBlock(Identifier, false, false, false, false, true, true, true),
            9720 => new TripwireBlock(Identifier, false, false, false, false, true, true, false),
            9721 => new TripwireBlock(Identifier, false, false, false, false, true, false, true),
            9722 => new TripwireBlock(Identifier, false, false, false, false, true, false, false),
            9723 => new TripwireBlock(Identifier, false, false, false, false, false, true, true),
            9724 => new TripwireBlock(Identifier, false, false, false, false, false, true, false),
            9725 => new TripwireBlock(Identifier, false, false, false, false, false, false, true),
            9726 => new TripwireBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.Contains("attached") ? properties["attached"].GetString() == "true" : Attached,
            Disarmed = properties.Contains("disarmed") ? properties["disarmed"].GetString() == "true" : Disarmed,
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attached", new StringTag(Attached.ToString().ToLower())),
            ("disarmed", new StringTag(Disarmed.ToString().ToLower())),
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}

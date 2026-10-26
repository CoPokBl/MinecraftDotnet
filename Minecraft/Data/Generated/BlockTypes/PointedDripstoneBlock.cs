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
public record PointedDripstoneBlock(Identifier Identifier, SpeleothemThickness Thickness, VerticalDirection VerticalDirection, bool Waterlogged) : IBlock, ISpeleothem, IVerticallyDirected, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.pointed_dripstone", 3f, 0.6f, 1f, 1f, 0f, 0f, false, true, BlockOffsetType.Xz, 0.125f, 0f, null, "minecraft:pointed_dripstone", BlockInfo.VanillaOnly, "minecraft:blocks/pointed_dripstone") { ShapeOffsets = BlockShapeOffsets.Block | BlockShapeOffsets.Collision | BlockShapeOffsets.Visual };
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Popped, 48, "pointed_dripstone", NoteBlockInstrument.Basedrum, false, false, false, false, false, false, false, true, false, false, true, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S330, BlockShapes.S330, BlockShapes.S1, BlockShapes.S1, BlockShapes.S330, BlockShapes.S330);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S826, CollisionShape = BlockShapes.S826, VisualShape = BlockShapes.S826, SupportShape = BlockShapes.S826 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S826, CollisionShape = BlockShapes.S826, VisualShape = BlockShapes.S826, SupportShape = BlockShapes.S826 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S827, CollisionShape = BlockShapes.S827, VisualShape = BlockShapes.S827, SupportShape = BlockShapes.S827 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S827, CollisionShape = BlockShapes.S827, VisualShape = BlockShapes.S827, SupportShape = BlockShapes.S827 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S87, CollisionShape = BlockShapes.S87, VisualShape = BlockShapes.S87, SupportShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S87, CollisionShape = BlockShapes.S87, VisualShape = BlockShapes.S87, SupportShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S77, CollisionShape = BlockShapes.S77, VisualShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S77, CollisionShape = BlockShapes.S77, VisualShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S828, CollisionShape = BlockShapes.S828, VisualShape = BlockShapes.S828, SupportShape = BlockShapes.S828 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S828, CollisionShape = BlockShapes.S828, VisualShape = BlockShapes.S828, SupportShape = BlockShapes.S828 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I4, I5, I6, I7, I6, I7, I8, I9, I8, I9, I10, I11, I10, I11
    ];

    public BlockStateInfo StateInfo => States[StateId - 33566];

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

    public IBlock WithThickness(SpeleothemThickness thickness) => this with { Thickness = thickness };

    public IBlock WithVerticalDirection(VerticalDirection verticalDirection) => this with { VerticalDirection = verticalDirection };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Thickness switch {
                SpeleothemThickness.TipMerge => VerticalDirection switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 33566,
                        false => 33567,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 33568,
                        false => 33569,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirection), VerticalDirection, "Unknown value for property vertical_direction.")
                },
                SpeleothemThickness.Tip => VerticalDirection switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 33570,
                        false => 33571,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 33572,
                        false => 33573,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirection), VerticalDirection, "Unknown value for property vertical_direction.")
                },
                SpeleothemThickness.Frustum => VerticalDirection switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 33574,
                        false => 33575,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 33576,
                        false => 33577,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirection), VerticalDirection, "Unknown value for property vertical_direction.")
                },
                SpeleothemThickness.Middle => VerticalDirection switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 33578,
                        false => 33579,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 33580,
                        false => 33581,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirection), VerticalDirection, "Unknown value for property vertical_direction.")
                },
                SpeleothemThickness.Base => VerticalDirection switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 33582,
                        false => 33583,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 33584,
                        false => 33585,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirection), VerticalDirection, "Unknown value for property vertical_direction.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Thickness), Thickness, "Unknown value for property thickness.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33566 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.TipMerge, VerticalDirection.Up, true),
            33567 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.TipMerge, VerticalDirection.Up, false),
            33568 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.TipMerge, VerticalDirection.Down, true),
            33569 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.TipMerge, VerticalDirection.Down, false),
            33570 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Tip, VerticalDirection.Up, true),
            33571 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Tip, VerticalDirection.Up, false),
            33572 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Tip, VerticalDirection.Down, true),
            33573 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Tip, VerticalDirection.Down, false),
            33574 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Frustum, VerticalDirection.Up, true),
            33575 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Frustum, VerticalDirection.Up, false),
            33576 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Frustum, VerticalDirection.Down, true),
            33577 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Frustum, VerticalDirection.Down, false),
            33578 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Middle, VerticalDirection.Up, true),
            33579 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Middle, VerticalDirection.Up, false),
            33580 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Middle, VerticalDirection.Down, true),
            33581 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Middle, VerticalDirection.Down, false),
            33582 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Base, VerticalDirection.Up, true),
            33583 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Base, VerticalDirection.Up, false),
            33584 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Base, VerticalDirection.Down, true),
            33585 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Base, VerticalDirection.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Thickness = properties.Contains("thickness") ? SpeleothemThicknessExtensions.FromString(properties["thickness"].GetString()) : Thickness,
            VerticalDirection = properties.Contains("vertical_direction") ? VerticalDirectionExtensions.FromString(properties["vertical_direction"].GetString()) : VerticalDirection,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("thickness", new StringTag(Thickness.ToName())),
            ("vertical_direction", new StringTag(VerticalDirection.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}

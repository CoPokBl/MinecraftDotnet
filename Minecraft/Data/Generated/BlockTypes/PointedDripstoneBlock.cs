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
    private static readonly BlockInfo Data = new("minecraft:pointed_dripstone", "block.minecraft.pointed_dripstone", 3f, 0.6f, 1f, 1f, 0f, false, true, BlockOffsetType.Xz, 0.125f, 0f, null, "minecraft:pointed_dripstone", BlockInfo.VanillaOnly, "minecraft:blocks/pointed_dripstone") { ShapeOffsets = BlockShapeOffsets.Block | BlockShapeOffsets.Collision | BlockShapeOffsets.Visual };
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Destroy, 48, "pointed_dripstone", NoteBlockInstrument.Basedrum, false, false, false, true, false, false, false, false, true, false, false, true, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S330, BlockShapes.S330, BlockShapes.S1, BlockShapes.S1, BlockShapes.S330, BlockShapes.S330);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S825, CollisionShape = BlockShapes.S825, VisualShape = BlockShapes.S825, SupportShape = BlockShapes.S825 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S825, CollisionShape = BlockShapes.S825, VisualShape = BlockShapes.S825, SupportShape = BlockShapes.S825 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S826, CollisionShape = BlockShapes.S826, VisualShape = BlockShapes.S826, SupportShape = BlockShapes.S826 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S826, CollisionShape = BlockShapes.S826, VisualShape = BlockShapes.S826, SupportShape = BlockShapes.S826 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S87, CollisionShape = BlockShapes.S87, VisualShape = BlockShapes.S87, SupportShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S87, CollisionShape = BlockShapes.S87, VisualShape = BlockShapes.S87, SupportShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S77, CollisionShape = BlockShapes.S77, VisualShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S77, CollisionShape = BlockShapes.S77, VisualShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S827, CollisionShape = BlockShapes.S827, VisualShape = BlockShapes.S827, SupportShape = BlockShapes.S827 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S827, CollisionShape = BlockShapes.S827, VisualShape = BlockShapes.S827, SupportShape = BlockShapes.S827 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I4, I5, I6, I7, I6, I7, I8, I9, I8, I9, I10, I11, I10, I11
    ];

    public BlockStateInfo StateInfo => States[StateId - 30209];

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

    public IBlock WithThickness(SpeleothemThickness thickness) => this with { Thickness = thickness };

    public IBlock WithVerticalDirection(VerticalDirection verticalDirection) => this with { VerticalDirection = verticalDirection };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Thickness switch {
                SpeleothemThickness.TipMerge => VerticalDirection switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30209,
                        false => 30210,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30211,
                        false => 30212,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirection), VerticalDirection, "Unknown value for property vertical_direction.")
                },
                SpeleothemThickness.Tip => VerticalDirection switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30213,
                        false => 30214,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30215,
                        false => 30216,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirection), VerticalDirection, "Unknown value for property vertical_direction.")
                },
                SpeleothemThickness.Frustum => VerticalDirection switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30217,
                        false => 30218,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30219,
                        false => 30220,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirection), VerticalDirection, "Unknown value for property vertical_direction.")
                },
                SpeleothemThickness.Middle => VerticalDirection switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30221,
                        false => 30222,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30223,
                        false => 30224,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirection), VerticalDirection, "Unknown value for property vertical_direction.")
                },
                SpeleothemThickness.Base => VerticalDirection switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30225,
                        false => 30226,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30227,
                        false => 30228,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirection), VerticalDirection, "Unknown value for property vertical_direction.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Thickness), Thickness, "Unknown value for property thickness.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30209 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.TipMerge, VerticalDirection.Up, true),
            30210 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.TipMerge, VerticalDirection.Up, false),
            30211 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.TipMerge, VerticalDirection.Down, true),
            30212 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.TipMerge, VerticalDirection.Down, false),
            30213 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Tip, VerticalDirection.Up, true),
            30214 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Tip, VerticalDirection.Up, false),
            30215 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Tip, VerticalDirection.Down, true),
            30216 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Tip, VerticalDirection.Down, false),
            30217 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Frustum, VerticalDirection.Up, true),
            30218 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Frustum, VerticalDirection.Up, false),
            30219 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Frustum, VerticalDirection.Down, true),
            30220 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Frustum, VerticalDirection.Down, false),
            30221 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Middle, VerticalDirection.Up, true),
            30222 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Middle, VerticalDirection.Up, false),
            30223 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Middle, VerticalDirection.Down, true),
            30224 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Middle, VerticalDirection.Down, false),
            30225 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Base, VerticalDirection.Up, true),
            30226 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Base, VerticalDirection.Up, false),
            30227 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Base, VerticalDirection.Down, true),
            30228 => new PointedDripstoneBlock(Identifier, SpeleothemThickness.Base, VerticalDirection.Down, false),
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

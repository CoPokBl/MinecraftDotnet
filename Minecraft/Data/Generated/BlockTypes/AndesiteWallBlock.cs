using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AndesiteWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:wall", "block.minecraft.andesite_wall", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:andesite_wall", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 11, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S85, BlockShapes.S130, BlockShapes.S1, BlockShapes.S85, BlockShapes.S130);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S131, CollisionShape = BlockShapes.S132, OcclusionShape = BlockShapes.S131, VisualShape = BlockShapes.S132 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S133, CollisionShape = BlockShapes.S132, OcclusionShape = BlockShapes.S133, VisualShape = BlockShapes.S132 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I4 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S131, CollisionShape = BlockShapes.S132, OcclusionShape = BlockShapes.S131, VisualShape = BlockShapes.S132 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S133, CollisionShape = BlockShapes.S132, OcclusionShape = BlockShapes.S133, VisualShape = BlockShapes.S132 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S1, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S1, VisualShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S134, CollisionShape = BlockShapes.S135, OcclusionShape = BlockShapes.S134, VisualShape = BlockShapes.S135 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S136, CollisionShape = BlockShapes.S135, OcclusionShape = BlockShapes.S136, VisualShape = BlockShapes.S135 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S1, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S1, VisualShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I10 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S134, CollisionShape = BlockShapes.S135, OcclusionShape = BlockShapes.S134, VisualShape = BlockShapes.S135 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S136, CollisionShape = BlockShapes.S135, OcclusionShape = BlockShapes.S136, VisualShape = BlockShapes.S135 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S137, CollisionShape = BlockShapes.S138, OcclusionShape = BlockShapes.S137, VisualShape = BlockShapes.S138 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S139, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S139, VisualShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S141, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S141, VisualShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S137, CollisionShape = BlockShapes.S138, OcclusionShape = BlockShapes.S137, VisualShape = BlockShapes.S138 };
    private static readonly BlockStateInfo I16 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S139, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S139, VisualShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S141, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S141, VisualShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S142, CollisionShape = BlockShapes.S143, OcclusionShape = BlockShapes.S142, VisualShape = BlockShapes.S143 };
    private static readonly BlockStateInfo I19 = I0 with { BlockShape = BlockShapes.S144, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S144, VisualShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S146, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S146, VisualShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S142, CollisionShape = BlockShapes.S143, OcclusionShape = BlockShapes.S142, VisualShape = BlockShapes.S143 };
    private static readonly BlockStateInfo I22 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S144, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S144, VisualShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S146, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S146, VisualShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S147, CollisionShape = BlockShapes.S138, OcclusionShape = BlockShapes.S147, VisualShape = BlockShapes.S138 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S148, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S148, VisualShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S149, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S149, VisualShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S147, CollisionShape = BlockShapes.S138, OcclusionShape = BlockShapes.S147, VisualShape = BlockShapes.S138 };
    private static readonly BlockStateInfo I28 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S148, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S148, VisualShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I29 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S149, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S149, VisualShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I30 = I0 with { BlockShape = BlockShapes.S150, CollisionShape = BlockShapes.S143, OcclusionShape = BlockShapes.S150, VisualShape = BlockShapes.S143 };
    private static readonly BlockStateInfo I31 = I0 with { BlockShape = BlockShapes.S151, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S151, VisualShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I32 = I0 with { BlockShape = BlockShapes.S152, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S152, VisualShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I33 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S150, CollisionShape = BlockShapes.S143, OcclusionShape = BlockShapes.S150, VisualShape = BlockShapes.S143 };
    private static readonly BlockStateInfo I34 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S151, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S151, VisualShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S152, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S152, VisualShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I36 = I0 with { BlockShape = BlockShapes.S153, CollisionShape = BlockShapes.S154, OcclusionShape = BlockShapes.S153, VisualShape = BlockShapes.S154 };
    private static readonly BlockStateInfo I37 = I0 with { BlockShape = BlockShapes.S155, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S155, VisualShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I38 = I0 with { BlockShape = BlockShapes.S157, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S157, VisualShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S153, CollisionShape = BlockShapes.S154, OcclusionShape = BlockShapes.S153, VisualShape = BlockShapes.S154 };
    private static readonly BlockStateInfo I40 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S155, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S155, VisualShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I41 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S157, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S157, VisualShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I42 = I0 with { BlockShape = BlockShapes.S158, CollisionShape = BlockShapes.S159, OcclusionShape = BlockShapes.S158, VisualShape = BlockShapes.S159 };
    private static readonly BlockStateInfo I43 = I0 with { BlockShape = BlockShapes.S160, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S160, VisualShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S162, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S162, VisualShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I45 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S158, CollisionShape = BlockShapes.S159, OcclusionShape = BlockShapes.S158, VisualShape = BlockShapes.S159 };
    private static readonly BlockStateInfo I46 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S160, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S160, VisualShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S162, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S162, VisualShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I48 = I0 with { BlockShape = BlockShapes.S163, CollisionShape = BlockShapes.S164, OcclusionShape = BlockShapes.S163, VisualShape = BlockShapes.S164 };
    private static readonly BlockStateInfo I49 = I0 with { BlockShape = BlockShapes.S165, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S165, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I50 = I0 with { BlockShape = BlockShapes.S167, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S167, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I51 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S163, CollisionShape = BlockShapes.S164, OcclusionShape = BlockShapes.S163, VisualShape = BlockShapes.S164 };
    private static readonly BlockStateInfo I52 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S165, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S165, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I53 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S167, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S167, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I54 = I0 with { BlockShape = BlockShapes.S168, CollisionShape = BlockShapes.S169, OcclusionShape = BlockShapes.S168, VisualShape = BlockShapes.S169 };
    private static readonly BlockStateInfo I55 = I0 with { BlockShape = BlockShapes.S170, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S170, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I56 = I0 with { BlockShape = BlockShapes.S172, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S172, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I57 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S168, CollisionShape = BlockShapes.S169, OcclusionShape = BlockShapes.S168, VisualShape = BlockShapes.S169 };
    private static readonly BlockStateInfo I58 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S170, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S170, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I59 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S172, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S172, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I60 = I0 with { BlockShape = BlockShapes.S173, CollisionShape = BlockShapes.S164, OcclusionShape = BlockShapes.S173, VisualShape = BlockShapes.S164 };
    private static readonly BlockStateInfo I61 = I0 with { BlockShape = BlockShapes.S174, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S174, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I62 = I0 with { BlockShape = BlockShapes.S175, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S175, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I63 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S173, CollisionShape = BlockShapes.S164, OcclusionShape = BlockShapes.S173, VisualShape = BlockShapes.S164 };
    private static readonly BlockStateInfo I64 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S174, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S174, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I65 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S175, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S175, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I66 = I0 with { BlockShape = BlockShapes.S176, CollisionShape = BlockShapes.S169, OcclusionShape = BlockShapes.S176, VisualShape = BlockShapes.S169 };
    private static readonly BlockStateInfo I67 = I0 with { BlockShape = BlockShapes.S177, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S177, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I68 = I0 with { BlockShape = BlockShapes.S178, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S178, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I69 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S176, CollisionShape = BlockShapes.S169, OcclusionShape = BlockShapes.S176, VisualShape = BlockShapes.S169 };
    private static readonly BlockStateInfo I70 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S177, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S177, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I71 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S178, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S178, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I72 = I0 with { BlockShape = BlockShapes.S179, CollisionShape = BlockShapes.S154, OcclusionShape = BlockShapes.S179, VisualShape = BlockShapes.S154 };
    private static readonly BlockStateInfo I73 = I0 with { BlockShape = BlockShapes.S180, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S180, VisualShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I74 = I0 with { BlockShape = BlockShapes.S181, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S181, VisualShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I75 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S179, CollisionShape = BlockShapes.S154, OcclusionShape = BlockShapes.S179, VisualShape = BlockShapes.S154 };
    private static readonly BlockStateInfo I76 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S180, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S180, VisualShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I77 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S181, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S181, VisualShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I78 = I0 with { BlockShape = BlockShapes.S182, CollisionShape = BlockShapes.S159, OcclusionShape = BlockShapes.S182, VisualShape = BlockShapes.S159 };
    private static readonly BlockStateInfo I79 = I0 with { BlockShape = BlockShapes.S183, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S183, VisualShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I80 = I0 with { BlockShape = BlockShapes.S184, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S184, VisualShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I81 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S182, CollisionShape = BlockShapes.S159, OcclusionShape = BlockShapes.S182, VisualShape = BlockShapes.S159 };
    private static readonly BlockStateInfo I82 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S183, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S183, VisualShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I83 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S184, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S184, VisualShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I84 = I0 with { BlockShape = BlockShapes.S185, CollisionShape = BlockShapes.S164, OcclusionShape = BlockShapes.S185, VisualShape = BlockShapes.S164 };
    private static readonly BlockStateInfo I85 = I0 with { BlockShape = BlockShapes.S186, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S186, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I86 = I0 with { BlockShape = BlockShapes.S187, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S187, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I87 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S185, CollisionShape = BlockShapes.S164, OcclusionShape = BlockShapes.S185, VisualShape = BlockShapes.S164 };
    private static readonly BlockStateInfo I88 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S186, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S186, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I89 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S187, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S187, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I90 = I0 with { BlockShape = BlockShapes.S188, CollisionShape = BlockShapes.S169, OcclusionShape = BlockShapes.S188, VisualShape = BlockShapes.S169 };
    private static readonly BlockStateInfo I91 = I0 with { BlockShape = BlockShapes.S189, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S189, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I92 = I0 with { BlockShape = BlockShapes.S190, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S190, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I93 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S188, CollisionShape = BlockShapes.S169, OcclusionShape = BlockShapes.S188, VisualShape = BlockShapes.S169 };
    private static readonly BlockStateInfo I94 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S189, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S189, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I95 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S190, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S190, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I96 = I0 with { BlockShape = BlockShapes.S191, CollisionShape = BlockShapes.S164, OcclusionShape = BlockShapes.S191, VisualShape = BlockShapes.S164 };
    private static readonly BlockStateInfo I97 = I0 with { BlockShape = BlockShapes.S192, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S192, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I98 = I0 with { BlockShape = BlockShapes.S193, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S193, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I99 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S191, CollisionShape = BlockShapes.S164, OcclusionShape = BlockShapes.S191, VisualShape = BlockShapes.S164 };
    private static readonly BlockStateInfo I100 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S192, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S192, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I101 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S193, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S193, VisualShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I102 = I0 with { BlockShape = BlockShapes.S194, CollisionShape = BlockShapes.S169, OcclusionShape = BlockShapes.S194, VisualShape = BlockShapes.S169 };
    private static readonly BlockStateInfo I103 = I0 with { BlockShape = BlockShapes.S195, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S195, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I104 = I0 with { BlockShape = BlockShapes.S196, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S196, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I105 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S194, CollisionShape = BlockShapes.S169, OcclusionShape = BlockShapes.S194, VisualShape = BlockShapes.S169 };
    private static readonly BlockStateInfo I106 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S195, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S195, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I107 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S196, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S196, VisualShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I108 = I0 with { BlockShape = BlockShapes.S197, CollisionShape = BlockShapes.S198, OcclusionShape = BlockShapes.S197, VisualShape = BlockShapes.S198 };
    private static readonly BlockStateInfo I109 = I0 with { BlockShape = BlockShapes.S199, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S199, VisualShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I110 = I0 with { BlockShape = BlockShapes.S201, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S201, VisualShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I111 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S197, CollisionShape = BlockShapes.S198, OcclusionShape = BlockShapes.S197, VisualShape = BlockShapes.S198 };
    private static readonly BlockStateInfo I112 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S199, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S199, VisualShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I113 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S201, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S201, VisualShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I114 = I0 with { BlockShape = BlockShapes.S202, CollisionShape = BlockShapes.S203, OcclusionShape = BlockShapes.S202, VisualShape = BlockShapes.S203 };
    private static readonly BlockStateInfo I115 = I0 with { BlockShape = BlockShapes.S204, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S204, VisualShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I116 = I0 with { BlockShape = BlockShapes.S206, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S206, VisualShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I117 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S202, CollisionShape = BlockShapes.S203, OcclusionShape = BlockShapes.S202, VisualShape = BlockShapes.S203 };
    private static readonly BlockStateInfo I118 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S204, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S204, VisualShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I119 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S206, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S206, VisualShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I120 = I0 with { BlockShape = BlockShapes.S207, CollisionShape = BlockShapes.S208, OcclusionShape = BlockShapes.S207, VisualShape = BlockShapes.S208 };
    private static readonly BlockStateInfo I121 = I0 with { BlockShape = BlockShapes.S209, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S209, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I122 = I0 with { BlockShape = BlockShapes.S211, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S211, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I123 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S207, CollisionShape = BlockShapes.S208, OcclusionShape = BlockShapes.S207, VisualShape = BlockShapes.S208 };
    private static readonly BlockStateInfo I124 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S209, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S209, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I125 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S211, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S211, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I126 = I0 with { BlockShape = BlockShapes.S212, CollisionShape = BlockShapes.S213, OcclusionShape = BlockShapes.S212, VisualShape = BlockShapes.S213 };
    private static readonly BlockStateInfo I127 = I0 with { BlockShape = BlockShapes.S214, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S214, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I128 = I0 with { BlockShape = BlockShapes.S216, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S216, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I129 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S212, CollisionShape = BlockShapes.S213, OcclusionShape = BlockShapes.S212, VisualShape = BlockShapes.S213 };
    private static readonly BlockStateInfo I130 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S214, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S214, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I131 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S216, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S216, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I132 = I0 with { BlockShape = BlockShapes.S217, CollisionShape = BlockShapes.S208, OcclusionShape = BlockShapes.S217, VisualShape = BlockShapes.S208 };
    private static readonly BlockStateInfo I133 = I0 with { BlockShape = BlockShapes.S218, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S218, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I134 = I0 with { BlockShape = BlockShapes.S219, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S219, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I135 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S217, CollisionShape = BlockShapes.S208, OcclusionShape = BlockShapes.S217, VisualShape = BlockShapes.S208 };
    private static readonly BlockStateInfo I136 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S218, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S218, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I137 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S219, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S219, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I138 = I0 with { BlockShape = BlockShapes.S220, CollisionShape = BlockShapes.S213, OcclusionShape = BlockShapes.S220, VisualShape = BlockShapes.S213 };
    private static readonly BlockStateInfo I139 = I0 with { BlockShape = BlockShapes.S221, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S221, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I140 = I0 with { BlockShape = BlockShapes.S222, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S222, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I141 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S220, CollisionShape = BlockShapes.S213, OcclusionShape = BlockShapes.S220, VisualShape = BlockShapes.S213 };
    private static readonly BlockStateInfo I142 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S221, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S221, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I143 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S222, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S222, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I144 = I0 with { BlockShape = BlockShapes.S223, CollisionShape = BlockShapes.S224, OcclusionShape = BlockShapes.S223, VisualShape = BlockShapes.S224 };
    private static readonly BlockStateInfo I145 = I0 with { BlockShape = BlockShapes.S225, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S225, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I146 = I0 with { BlockShape = BlockShapes.S227, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S227, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I147 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S223, CollisionShape = BlockShapes.S224, OcclusionShape = BlockShapes.S223, VisualShape = BlockShapes.S224 };
    private static readonly BlockStateInfo I148 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S225, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S225, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I149 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S227, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S227, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I150 = I0 with { BlockShape = BlockShapes.S228, CollisionShape = BlockShapes.S229, OcclusionShape = BlockShapes.S228, VisualShape = BlockShapes.S229 };
    private static readonly BlockStateInfo I151 = I0 with { BlockShape = BlockShapes.S230, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S230, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I152 = I0 with { BlockShape = BlockShapes.S232, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S232, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I153 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S228, CollisionShape = BlockShapes.S229, OcclusionShape = BlockShapes.S228, VisualShape = BlockShapes.S229 };
    private static readonly BlockStateInfo I154 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S230, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S230, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I155 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S232, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S232, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I156 = I0 with { BlockShape = BlockShapes.S233, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S233, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I157 = I0 with { BlockShape = BlockShapes.S235, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S235, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I158 = I0 with { BlockShape = BlockShapes.S237, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S237, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I159 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S233, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S233, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I160 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S235, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S235, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I161 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S237, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S237, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I162 = I0 with { BlockShape = BlockShapes.S238, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S238, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I163 = I0 with { BlockShape = BlockShapes.S240, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S240, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I164 = I0 with { BlockShape = BlockShapes.S242, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S242, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I165 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S238, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S238, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I166 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S240, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S240, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I167 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S242, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S242, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I168 = I0 with { BlockShape = BlockShapes.S243, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S243, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I169 = I0 with { BlockShape = BlockShapes.S244, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S244, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I170 = I0 with { BlockShape = BlockShapes.S245, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S245, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I171 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S243, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S243, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I172 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S244, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S244, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I173 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S245, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S245, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I174 = I0 with { BlockShape = BlockShapes.S246, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S246, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I175 = I0 with { BlockShape = BlockShapes.S247, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S247, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I176 = I0 with { BlockShape = BlockShapes.S248, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S248, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I177 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S246, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S246, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I178 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S247, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S247, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I179 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S248, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S248, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I180 = I0 with { BlockShape = BlockShapes.S249, CollisionShape = BlockShapes.S224, OcclusionShape = BlockShapes.S249, VisualShape = BlockShapes.S224 };
    private static readonly BlockStateInfo I181 = I0 with { BlockShape = BlockShapes.S250, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S250, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I182 = I0 with { BlockShape = BlockShapes.S251, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S251, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I183 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S249, CollisionShape = BlockShapes.S224, OcclusionShape = BlockShapes.S249, VisualShape = BlockShapes.S224 };
    private static readonly BlockStateInfo I184 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S250, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S250, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I185 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S251, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S251, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I186 = I0 with { BlockShape = BlockShapes.S252, CollisionShape = BlockShapes.S229, OcclusionShape = BlockShapes.S252, VisualShape = BlockShapes.S229 };
    private static readonly BlockStateInfo I187 = I0 with { BlockShape = BlockShapes.S253, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S253, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I188 = I0 with { BlockShape = BlockShapes.S254, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S254, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I189 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S252, CollisionShape = BlockShapes.S229, OcclusionShape = BlockShapes.S252, VisualShape = BlockShapes.S229 };
    private static readonly BlockStateInfo I190 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S253, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S253, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I191 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S254, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S254, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I192 = I0 with { BlockShape = BlockShapes.S255, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S255, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I193 = I0 with { BlockShape = BlockShapes.S256, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S256, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I194 = I0 with { BlockShape = BlockShapes.S257, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S257, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I195 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S255, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S255, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I196 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S256, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S256, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I197 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S257, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S257, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I198 = I0 with { BlockShape = BlockShapes.S258, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S258, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I199 = I0 with { BlockShape = BlockShapes.S259, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S259, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I200 = I0 with { BlockShape = BlockShapes.S260, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S260, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I201 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S258, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S258, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I202 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S259, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S259, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I203 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S260, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S260, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I204 = I0 with { BlockShape = BlockShapes.S261, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S261, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I205 = I0 with { BlockShape = BlockShapes.S262, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S262, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I206 = I0 with { BlockShape = BlockShapes.S263, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S263, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I207 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S261, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S261, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I208 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S262, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S262, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I209 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S263, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S263, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I210 = I0 with { BlockShape = BlockShapes.S264, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S264, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I211 = I0 with { BlockShape = BlockShapes.S265, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S265, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I212 = I0 with { BlockShape = BlockShapes.S266, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S266, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I213 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S264, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S264, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I214 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S265, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S265, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I215 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S266, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S266, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I216 = I0 with { BlockShape = BlockShapes.S267, CollisionShape = BlockShapes.S198, OcclusionShape = BlockShapes.S267, VisualShape = BlockShapes.S198 };
    private static readonly BlockStateInfo I217 = I0 with { BlockShape = BlockShapes.S268, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S268, VisualShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I218 = I0 with { BlockShape = BlockShapes.S269, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S269, VisualShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I219 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S267, CollisionShape = BlockShapes.S198, OcclusionShape = BlockShapes.S267, VisualShape = BlockShapes.S198 };
    private static readonly BlockStateInfo I220 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S268, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S268, VisualShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I221 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S269, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S269, VisualShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I222 = I0 with { BlockShape = BlockShapes.S270, CollisionShape = BlockShapes.S203, OcclusionShape = BlockShapes.S270, VisualShape = BlockShapes.S203 };
    private static readonly BlockStateInfo I223 = I0 with { BlockShape = BlockShapes.S271, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S271, VisualShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I224 = I0 with { BlockShape = BlockShapes.S272, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S272, VisualShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I225 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S270, CollisionShape = BlockShapes.S203, OcclusionShape = BlockShapes.S270, VisualShape = BlockShapes.S203 };
    private static readonly BlockStateInfo I226 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S271, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S271, VisualShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I227 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S272, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S272, VisualShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I228 = I0 with { BlockShape = BlockShapes.S273, CollisionShape = BlockShapes.S208, OcclusionShape = BlockShapes.S273, VisualShape = BlockShapes.S208 };
    private static readonly BlockStateInfo I229 = I0 with { BlockShape = BlockShapes.S274, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S274, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I230 = I0 with { BlockShape = BlockShapes.S275, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S275, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I231 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S273, CollisionShape = BlockShapes.S208, OcclusionShape = BlockShapes.S273, VisualShape = BlockShapes.S208 };
    private static readonly BlockStateInfo I232 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S274, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S274, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I233 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S275, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S275, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I234 = I0 with { BlockShape = BlockShapes.S276, CollisionShape = BlockShapes.S213, OcclusionShape = BlockShapes.S276, VisualShape = BlockShapes.S213 };
    private static readonly BlockStateInfo I235 = I0 with { BlockShape = BlockShapes.S277, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S277, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I236 = I0 with { BlockShape = BlockShapes.S278, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S278, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I237 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S276, CollisionShape = BlockShapes.S213, OcclusionShape = BlockShapes.S276, VisualShape = BlockShapes.S213 };
    private static readonly BlockStateInfo I238 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S277, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S277, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I239 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S278, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S278, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I240 = I0 with { BlockShape = BlockShapes.S279, CollisionShape = BlockShapes.S208, OcclusionShape = BlockShapes.S279, VisualShape = BlockShapes.S208 };
    private static readonly BlockStateInfo I241 = I0 with { BlockShape = BlockShapes.S280, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S280, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I242 = I0 with { BlockShape = BlockShapes.S281, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S281, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I243 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S279, CollisionShape = BlockShapes.S208, OcclusionShape = BlockShapes.S279, VisualShape = BlockShapes.S208 };
    private static readonly BlockStateInfo I244 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S280, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S280, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I245 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S281, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S281, VisualShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I246 = I0 with { BlockShape = BlockShapes.S282, CollisionShape = BlockShapes.S213, OcclusionShape = BlockShapes.S282, VisualShape = BlockShapes.S213 };
    private static readonly BlockStateInfo I247 = I0 with { BlockShape = BlockShapes.S283, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S283, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I248 = I0 with { BlockShape = BlockShapes.S284, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S284, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I249 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S282, CollisionShape = BlockShapes.S213, OcclusionShape = BlockShapes.S282, VisualShape = BlockShapes.S213 };
    private static readonly BlockStateInfo I250 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S283, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S283, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I251 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S284, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S284, VisualShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I252 = I0 with { BlockShape = BlockShapes.S285, CollisionShape = BlockShapes.S224, OcclusionShape = BlockShapes.S285, VisualShape = BlockShapes.S224 };
    private static readonly BlockStateInfo I253 = I0 with { BlockShape = BlockShapes.S286, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S286, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I254 = I0 with { BlockShape = BlockShapes.S287, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S287, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I255 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S285, CollisionShape = BlockShapes.S224, OcclusionShape = BlockShapes.S285, VisualShape = BlockShapes.S224 };
    private static readonly BlockStateInfo I256 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S286, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S286, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I257 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S287, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S287, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I258 = I0 with { BlockShape = BlockShapes.S288, CollisionShape = BlockShapes.S229, OcclusionShape = BlockShapes.S288, VisualShape = BlockShapes.S229 };
    private static readonly BlockStateInfo I259 = I0 with { BlockShape = BlockShapes.S289, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S289, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I260 = I0 with { BlockShape = BlockShapes.S290, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S290, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I261 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S288, CollisionShape = BlockShapes.S229, OcclusionShape = BlockShapes.S288, VisualShape = BlockShapes.S229 };
    private static readonly BlockStateInfo I262 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S289, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S289, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I263 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S290, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S290, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I264 = I0 with { BlockShape = BlockShapes.S291, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S291, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I265 = I0 with { BlockShape = BlockShapes.S292, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S292, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I266 = I0 with { BlockShape = BlockShapes.S293, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S293, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I267 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S291, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S291, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I268 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S292, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S292, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I269 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S293, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S293, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I270 = I0 with { BlockShape = BlockShapes.S294, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S294, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I271 = I0 with { BlockShape = BlockShapes.S295, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S295, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I272 = I0 with { BlockShape = BlockShapes.S296, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S296, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I273 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S294, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S294, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I274 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S295, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S295, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I275 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S296, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S296, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I276 = I0 with { BlockShape = BlockShapes.S297, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S297, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I277 = I0 with { BlockShape = BlockShapes.S298, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S298, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I278 = I0 with { BlockShape = BlockShapes.S299, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S299, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I279 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S297, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S297, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I280 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S298, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S298, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I281 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S299, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S299, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I282 = I0 with { BlockShape = BlockShapes.S300, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S300, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I283 = I0 with { BlockShape = BlockShapes.S301, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S301, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I284 = I0 with { BlockShape = BlockShapes.S302, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S302, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I285 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S300, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S300, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I286 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S301, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S301, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I287 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S302, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S302, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I288 = I0 with { BlockShape = BlockShapes.S303, CollisionShape = BlockShapes.S224, OcclusionShape = BlockShapes.S303, VisualShape = BlockShapes.S224 };
    private static readonly BlockStateInfo I289 = I0 with { BlockShape = BlockShapes.S304, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S304, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I290 = I0 with { BlockShape = BlockShapes.S305, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S305, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I291 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S303, CollisionShape = BlockShapes.S224, OcclusionShape = BlockShapes.S303, VisualShape = BlockShapes.S224 };
    private static readonly BlockStateInfo I292 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S304, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S304, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I293 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S305, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S305, VisualShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I294 = I0 with { BlockShape = BlockShapes.S306, CollisionShape = BlockShapes.S229, OcclusionShape = BlockShapes.S306, VisualShape = BlockShapes.S229 };
    private static readonly BlockStateInfo I295 = I0 with { BlockShape = BlockShapes.S307, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S307, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I296 = I0 with { BlockShape = BlockShapes.S308, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S308, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I297 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S306, CollisionShape = BlockShapes.S229, OcclusionShape = BlockShapes.S306, VisualShape = BlockShapes.S229 };
    private static readonly BlockStateInfo I298 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S307, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S307, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I299 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S308, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S308, VisualShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I300 = I0 with { BlockShape = BlockShapes.S309, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S309, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I301 = I0 with { BlockShape = BlockShapes.S310, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S310, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I302 = I0 with { BlockShape = BlockShapes.S311, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S311, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I303 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S309, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S309, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I304 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S310, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S310, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I305 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S311, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S311, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I306 = I0 with { BlockShape = BlockShapes.S312, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S312, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I307 = I0 with { BlockShape = BlockShapes.S313, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S313, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I308 = I0 with { BlockShape = BlockShapes.S314, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S314, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I309 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S312, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S312, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I310 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S313, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S313, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I311 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S314, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S314, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I312 = I0 with { BlockShape = BlockShapes.S315, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S315, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I313 = I0 with { BlockShape = BlockShapes.S316, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S316, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I314 = I0 with { BlockShape = BlockShapes.S317, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S317, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I315 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S315, CollisionShape = BlockShapes.S234, OcclusionShape = BlockShapes.S315, VisualShape = BlockShapes.S234 };
    private static readonly BlockStateInfo I316 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S316, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S316, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I317 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S317, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S317, VisualShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I318 = I0 with { BlockShape = BlockShapes.S318, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S318, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I319 = I0 with { BlockShape = BlockShapes.S319, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S319, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I320 = I0 with { BlockShape = BlockShapes.S320, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S320, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I321 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S318, CollisionShape = BlockShapes.S239, OcclusionShape = BlockShapes.S318, VisualShape = BlockShapes.S239 };
    private static readonly BlockStateInfo I322 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S319, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S319, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I323 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S320, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S320, VisualShape = BlockShapes.S241 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I42, I43, I44, I45, I46, I47, I48, I49, I50, I51, I52, I53, I54, I55, I56, I57, I58, I59, I60, I61, I62, I63, I64, I65, I66, I67, I68, I69, I70, I71, I72, I73, I74, I75, I76, I77, I78, I79, I80, I81, I82, I83, I84, I85, I86, I87, I88, I89, I90, I91, I92, I93, I94, I95, I96, I97, I98, I99, I100, I101, I102, I103, I104, I105, I106, I107, I108, I109, I110, I111, I112, I113, I114, I115, I116, I117, I118, I119, I120, I121, I122, I123, I124, I125, I126, I127, I128, I129, I130, I131, I132, I133, I134, I135, I136, I137, I138, I139, I140, I141, I142, I143, I144, I145, I146, I147, I148, I149, I150, I151, I152, I153, I154, I155, I156, I157, I158, I159, I160, I161, I162, I163, I164, I165, I166, I167, I168, I169, I170, I171, I172, I173, I174, I175, I176, I177, I178, I179, I180, I181, I182, I183, I184, I185, I186, I187, I188, I189, I190, I191, I192, I193, I194, I195, I196, I197, I198, I199, I200, I201, I202, I203, I204, I205, I206, I207, I208, I209, I210, I211, I212, I213, I214, I215, I216, I217, I218, I219, I220, I221, I222, I223, I224, I225, I226, I227, I228, I229, I230, I231, I232, I233, I234, I235, I236, I237, I238, I239, I240, I241, I242, I243, I244, I245, I246, I247, I248, I249, I250, I251, I252, I253, I254, I255, I256, I257, I258, I259, I260, I261, I262, I263, I264, I265, I266, I267, I268, I269, I270, I271, I272, I273, I274, I275, I276, I277, I278, I279, I280, I281, I282, I283, I284, I285, I286, I287, I288, I289, I290, I291, I292, I293, I294, I295, I296, I297, I298, I299, I300, I301, I302, I303, I304, I305, I306, I307, I308, I309, I310, I311, I312, I313, I314, I315, I316, I317, I318, I319, I320, I321, I322, I323
    ];

    public BlockStateInfo StateInfo => States[StateId - 19086];

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
            return East switch {
                WallSide.None => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19086,
                                    WallSide.Low => 19087,
                                    WallSide.Tall => 19088,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19089,
                                    WallSide.Low => 19090,
                                    WallSide.Tall => 19091,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19092,
                                    WallSide.Low => 19093,
                                    WallSide.Tall => 19094,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19095,
                                    WallSide.Low => 19096,
                                    WallSide.Tall => 19097,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19098,
                                    WallSide.Low => 19099,
                                    WallSide.Tall => 19100,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19101,
                                    WallSide.Low => 19102,
                                    WallSide.Tall => 19103,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19104,
                                    WallSide.Low => 19105,
                                    WallSide.Tall => 19106,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19107,
                                    WallSide.Low => 19108,
                                    WallSide.Tall => 19109,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19110,
                                    WallSide.Low => 19111,
                                    WallSide.Tall => 19112,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19113,
                                    WallSide.Low => 19114,
                                    WallSide.Tall => 19115,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19116,
                                    WallSide.Low => 19117,
                                    WallSide.Tall => 19118,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19119,
                                    WallSide.Low => 19120,
                                    WallSide.Tall => 19121,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Low => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19122,
                                    WallSide.Low => 19123,
                                    WallSide.Tall => 19124,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19125,
                                    WallSide.Low => 19126,
                                    WallSide.Tall => 19127,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19128,
                                    WallSide.Low => 19129,
                                    WallSide.Tall => 19130,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19131,
                                    WallSide.Low => 19132,
                                    WallSide.Tall => 19133,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19134,
                                    WallSide.Low => 19135,
                                    WallSide.Tall => 19136,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19137,
                                    WallSide.Low => 19138,
                                    WallSide.Tall => 19139,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19140,
                                    WallSide.Low => 19141,
                                    WallSide.Tall => 19142,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19143,
                                    WallSide.Low => 19144,
                                    WallSide.Tall => 19145,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19146,
                                    WallSide.Low => 19147,
                                    WallSide.Tall => 19148,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19149,
                                    WallSide.Low => 19150,
                                    WallSide.Tall => 19151,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19152,
                                    WallSide.Low => 19153,
                                    WallSide.Tall => 19154,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19155,
                                    WallSide.Low => 19156,
                                    WallSide.Tall => 19157,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Tall => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19158,
                                    WallSide.Low => 19159,
                                    WallSide.Tall => 19160,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19161,
                                    WallSide.Low => 19162,
                                    WallSide.Tall => 19163,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19164,
                                    WallSide.Low => 19165,
                                    WallSide.Tall => 19166,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19167,
                                    WallSide.Low => 19168,
                                    WallSide.Tall => 19169,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19170,
                                    WallSide.Low => 19171,
                                    WallSide.Tall => 19172,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19173,
                                    WallSide.Low => 19174,
                                    WallSide.Tall => 19175,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19176,
                                    WallSide.Low => 19177,
                                    WallSide.Tall => 19178,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19179,
                                    WallSide.Low => 19180,
                                    WallSide.Tall => 19181,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19182,
                                    WallSide.Low => 19183,
                                    WallSide.Tall => 19184,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19185,
                                    WallSide.Low => 19186,
                                    WallSide.Tall => 19187,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19188,
                                    WallSide.Low => 19189,
                                    WallSide.Tall => 19190,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19191,
                                    WallSide.Low => 19192,
                                    WallSide.Tall => 19193,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                WallSide.Low => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19194,
                                    WallSide.Low => 19195,
                                    WallSide.Tall => 19196,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19197,
                                    WallSide.Low => 19198,
                                    WallSide.Tall => 19199,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19200,
                                    WallSide.Low => 19201,
                                    WallSide.Tall => 19202,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19203,
                                    WallSide.Low => 19204,
                                    WallSide.Tall => 19205,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19206,
                                    WallSide.Low => 19207,
                                    WallSide.Tall => 19208,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19209,
                                    WallSide.Low => 19210,
                                    WallSide.Tall => 19211,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19212,
                                    WallSide.Low => 19213,
                                    WallSide.Tall => 19214,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19215,
                                    WallSide.Low => 19216,
                                    WallSide.Tall => 19217,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19218,
                                    WallSide.Low => 19219,
                                    WallSide.Tall => 19220,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19221,
                                    WallSide.Low => 19222,
                                    WallSide.Tall => 19223,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19224,
                                    WallSide.Low => 19225,
                                    WallSide.Tall => 19226,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19227,
                                    WallSide.Low => 19228,
                                    WallSide.Tall => 19229,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Low => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19230,
                                    WallSide.Low => 19231,
                                    WallSide.Tall => 19232,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19233,
                                    WallSide.Low => 19234,
                                    WallSide.Tall => 19235,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19236,
                                    WallSide.Low => 19237,
                                    WallSide.Tall => 19238,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19239,
                                    WallSide.Low => 19240,
                                    WallSide.Tall => 19241,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19242,
                                    WallSide.Low => 19243,
                                    WallSide.Tall => 19244,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19245,
                                    WallSide.Low => 19246,
                                    WallSide.Tall => 19247,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19248,
                                    WallSide.Low => 19249,
                                    WallSide.Tall => 19250,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19251,
                                    WallSide.Low => 19252,
                                    WallSide.Tall => 19253,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19254,
                                    WallSide.Low => 19255,
                                    WallSide.Tall => 19256,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19257,
                                    WallSide.Low => 19258,
                                    WallSide.Tall => 19259,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19260,
                                    WallSide.Low => 19261,
                                    WallSide.Tall => 19262,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19263,
                                    WallSide.Low => 19264,
                                    WallSide.Tall => 19265,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Tall => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19266,
                                    WallSide.Low => 19267,
                                    WallSide.Tall => 19268,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19269,
                                    WallSide.Low => 19270,
                                    WallSide.Tall => 19271,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19272,
                                    WallSide.Low => 19273,
                                    WallSide.Tall => 19274,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19275,
                                    WallSide.Low => 19276,
                                    WallSide.Tall => 19277,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19278,
                                    WallSide.Low => 19279,
                                    WallSide.Tall => 19280,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19281,
                                    WallSide.Low => 19282,
                                    WallSide.Tall => 19283,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19284,
                                    WallSide.Low => 19285,
                                    WallSide.Tall => 19286,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19287,
                                    WallSide.Low => 19288,
                                    WallSide.Tall => 19289,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19290,
                                    WallSide.Low => 19291,
                                    WallSide.Tall => 19292,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19293,
                                    WallSide.Low => 19294,
                                    WallSide.Tall => 19295,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19296,
                                    WallSide.Low => 19297,
                                    WallSide.Tall => 19298,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19299,
                                    WallSide.Low => 19300,
                                    WallSide.Tall => 19301,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                WallSide.Tall => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19302,
                                    WallSide.Low => 19303,
                                    WallSide.Tall => 19304,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19305,
                                    WallSide.Low => 19306,
                                    WallSide.Tall => 19307,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19308,
                                    WallSide.Low => 19309,
                                    WallSide.Tall => 19310,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19311,
                                    WallSide.Low => 19312,
                                    WallSide.Tall => 19313,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19314,
                                    WallSide.Low => 19315,
                                    WallSide.Tall => 19316,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19317,
                                    WallSide.Low => 19318,
                                    WallSide.Tall => 19319,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19320,
                                    WallSide.Low => 19321,
                                    WallSide.Tall => 19322,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19323,
                                    WallSide.Low => 19324,
                                    WallSide.Tall => 19325,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19326,
                                    WallSide.Low => 19327,
                                    WallSide.Tall => 19328,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19329,
                                    WallSide.Low => 19330,
                                    WallSide.Tall => 19331,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19332,
                                    WallSide.Low => 19333,
                                    WallSide.Tall => 19334,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19335,
                                    WallSide.Low => 19336,
                                    WallSide.Tall => 19337,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Low => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19338,
                                    WallSide.Low => 19339,
                                    WallSide.Tall => 19340,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19341,
                                    WallSide.Low => 19342,
                                    WallSide.Tall => 19343,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19344,
                                    WallSide.Low => 19345,
                                    WallSide.Tall => 19346,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19347,
                                    WallSide.Low => 19348,
                                    WallSide.Tall => 19349,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19350,
                                    WallSide.Low => 19351,
                                    WallSide.Tall => 19352,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19353,
                                    WallSide.Low => 19354,
                                    WallSide.Tall => 19355,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19356,
                                    WallSide.Low => 19357,
                                    WallSide.Tall => 19358,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19359,
                                    WallSide.Low => 19360,
                                    WallSide.Tall => 19361,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19362,
                                    WallSide.Low => 19363,
                                    WallSide.Tall => 19364,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19365,
                                    WallSide.Low => 19366,
                                    WallSide.Tall => 19367,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19368,
                                    WallSide.Low => 19369,
                                    WallSide.Tall => 19370,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19371,
                                    WallSide.Low => 19372,
                                    WallSide.Tall => 19373,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Tall => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19374,
                                    WallSide.Low => 19375,
                                    WallSide.Tall => 19376,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19377,
                                    WallSide.Low => 19378,
                                    WallSide.Tall => 19379,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19380,
                                    WallSide.Low => 19381,
                                    WallSide.Tall => 19382,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19383,
                                    WallSide.Low => 19384,
                                    WallSide.Tall => 19385,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19386,
                                    WallSide.Low => 19387,
                                    WallSide.Tall => 19388,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19389,
                                    WallSide.Low => 19390,
                                    WallSide.Tall => 19391,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19392,
                                    WallSide.Low => 19393,
                                    WallSide.Tall => 19394,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19395,
                                    WallSide.Low => 19396,
                                    WallSide.Tall => 19397,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19398,
                                    WallSide.Low => 19399,
                                    WallSide.Tall => 19400,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19401,
                                    WallSide.Low => 19402,
                                    WallSide.Tall => 19403,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 19404,
                                    WallSide.Low => 19405,
                                    WallSide.Tall => 19406,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 19407,
                                    WallSide.Low => 19408,
                                    WallSide.Tall => 19409,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19086 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            19087 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            19088 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            19089 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            19090 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            19091 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            19092 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            19093 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            19094 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            19095 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            19096 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            19097 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            19098 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            19099 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            19100 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            19101 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            19102 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            19103 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            19104 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            19105 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            19106 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            19107 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            19108 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            19109 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            19110 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            19111 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            19112 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            19113 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            19114 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            19115 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            19116 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            19117 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            19118 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            19119 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            19120 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            19121 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            19122 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            19123 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            19124 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            19125 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            19126 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            19127 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            19128 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            19129 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            19130 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            19131 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            19132 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            19133 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            19134 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            19135 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            19136 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            19137 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            19138 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            19139 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            19140 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            19141 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            19142 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            19143 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            19144 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            19145 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            19146 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            19147 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            19148 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            19149 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            19150 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            19151 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            19152 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            19153 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            19154 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            19155 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            19156 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            19157 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            19158 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            19159 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            19160 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            19161 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            19162 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            19163 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            19164 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            19165 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            19166 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            19167 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            19168 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            19169 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            19170 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            19171 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            19172 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            19173 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            19174 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            19175 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            19176 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            19177 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            19178 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            19179 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            19180 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            19181 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            19182 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            19183 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            19184 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            19185 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            19186 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            19187 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            19188 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            19189 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            19190 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            19191 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            19192 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            19193 => new AndesiteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            19194 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            19195 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            19196 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            19197 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            19198 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            19199 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            19200 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            19201 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            19202 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            19203 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            19204 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            19205 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            19206 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            19207 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            19208 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            19209 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            19210 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            19211 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            19212 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            19213 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            19214 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            19215 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            19216 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            19217 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            19218 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            19219 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            19220 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            19221 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            19222 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            19223 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            19224 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            19225 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            19226 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            19227 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            19228 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            19229 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            19230 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            19231 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            19232 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            19233 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            19234 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            19235 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            19236 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            19237 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            19238 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            19239 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            19240 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            19241 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            19242 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            19243 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            19244 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            19245 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            19246 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            19247 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            19248 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            19249 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            19250 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            19251 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            19252 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            19253 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            19254 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            19255 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            19256 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            19257 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            19258 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            19259 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            19260 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            19261 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            19262 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            19263 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            19264 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            19265 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            19266 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            19267 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            19268 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            19269 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            19270 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            19271 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            19272 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            19273 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            19274 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            19275 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            19276 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            19277 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            19278 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            19279 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            19280 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            19281 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            19282 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            19283 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            19284 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            19285 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            19286 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            19287 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            19288 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            19289 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            19290 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            19291 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            19292 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            19293 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            19294 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            19295 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            19296 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            19297 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            19298 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            19299 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            19300 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            19301 => new AndesiteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            19302 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            19303 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            19304 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            19305 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            19306 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            19307 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            19308 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            19309 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            19310 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            19311 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            19312 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            19313 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            19314 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            19315 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            19316 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            19317 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            19318 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            19319 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            19320 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            19321 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            19322 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            19323 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            19324 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            19325 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            19326 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            19327 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            19328 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            19329 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            19330 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            19331 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            19332 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            19333 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            19334 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            19335 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            19336 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            19337 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            19338 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            19339 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            19340 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            19341 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            19342 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            19343 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            19344 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            19345 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            19346 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            19347 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            19348 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            19349 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            19350 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            19351 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            19352 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            19353 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            19354 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            19355 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            19356 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            19357 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            19358 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            19359 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            19360 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            19361 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            19362 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            19363 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            19364 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            19365 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            19366 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            19367 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            19368 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            19369 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            19370 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            19371 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            19372 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            19373 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            19374 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            19375 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            19376 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            19377 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            19378 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            19379 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            19380 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            19381 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            19382 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            19383 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            19384 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            19385 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            19386 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            19387 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            19388 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            19389 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            19390 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            19391 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            19392 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            19393 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            19394 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            19395 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            19396 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            19397 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            19398 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            19399 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            19400 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            19401 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            19402 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            19403 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            19404 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            19405 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            19406 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            19407 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            19408 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            19409 => new AndesiteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? WallSideExtensions.FromString(properties["east"].GetString()) : East,
            North = properties.Contains("north") ? WallSideExtensions.FromString(properties["north"].GetString()) : North,
            South = properties.Contains("south") ? WallSideExtensions.FromString(properties["south"].GetString()) : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.Contains("west") ? WallSideExtensions.FromString(properties["west"].GetString()) : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToName())),
            ("north", new StringTag(North.ToName())),
            ("south", new StringTag(South.ToName())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())),
            ("west", new StringTag(West.ToName()))
        );
    }
    
}

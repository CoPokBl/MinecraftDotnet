using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedDeepslateWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:wall", "block.minecraft.polished_deepslate_wall", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_deepslate_wall", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3.5f, 0, 1, PushReaction.Normal, 59, "polished_deepslate", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S85, BlockShapes.S130, BlockShapes.S1, BlockShapes.S85, BlockShapes.S130);
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

    public BlockStateInfo StateInfo => States[StateId - 30917];

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
                                    WallSide.None => 30917,
                                    WallSide.Low => 30918,
                                    WallSide.Tall => 30919,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30920,
                                    WallSide.Low => 30921,
                                    WallSide.Tall => 30922,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30923,
                                    WallSide.Low => 30924,
                                    WallSide.Tall => 30925,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30926,
                                    WallSide.Low => 30927,
                                    WallSide.Tall => 30928,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30929,
                                    WallSide.Low => 30930,
                                    WallSide.Tall => 30931,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30932,
                                    WallSide.Low => 30933,
                                    WallSide.Tall => 30934,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30935,
                                    WallSide.Low => 30936,
                                    WallSide.Tall => 30937,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30938,
                                    WallSide.Low => 30939,
                                    WallSide.Tall => 30940,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30941,
                                    WallSide.Low => 30942,
                                    WallSide.Tall => 30943,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30944,
                                    WallSide.Low => 30945,
                                    WallSide.Tall => 30946,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30947,
                                    WallSide.Low => 30948,
                                    WallSide.Tall => 30949,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30950,
                                    WallSide.Low => 30951,
                                    WallSide.Tall => 30952,
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
                                    WallSide.None => 30953,
                                    WallSide.Low => 30954,
                                    WallSide.Tall => 30955,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30956,
                                    WallSide.Low => 30957,
                                    WallSide.Tall => 30958,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30959,
                                    WallSide.Low => 30960,
                                    WallSide.Tall => 30961,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30962,
                                    WallSide.Low => 30963,
                                    WallSide.Tall => 30964,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30965,
                                    WallSide.Low => 30966,
                                    WallSide.Tall => 30967,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30968,
                                    WallSide.Low => 30969,
                                    WallSide.Tall => 30970,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30971,
                                    WallSide.Low => 30972,
                                    WallSide.Tall => 30973,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30974,
                                    WallSide.Low => 30975,
                                    WallSide.Tall => 30976,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30977,
                                    WallSide.Low => 30978,
                                    WallSide.Tall => 30979,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30980,
                                    WallSide.Low => 30981,
                                    WallSide.Tall => 30982,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30983,
                                    WallSide.Low => 30984,
                                    WallSide.Tall => 30985,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30986,
                                    WallSide.Low => 30987,
                                    WallSide.Tall => 30988,
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
                                    WallSide.None => 30989,
                                    WallSide.Low => 30990,
                                    WallSide.Tall => 30991,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30992,
                                    WallSide.Low => 30993,
                                    WallSide.Tall => 30994,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30995,
                                    WallSide.Low => 30996,
                                    WallSide.Tall => 30997,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30998,
                                    WallSide.Low => 30999,
                                    WallSide.Tall => 31000,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31001,
                                    WallSide.Low => 31002,
                                    WallSide.Tall => 31003,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31004,
                                    WallSide.Low => 31005,
                                    WallSide.Tall => 31006,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31007,
                                    WallSide.Low => 31008,
                                    WallSide.Tall => 31009,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31010,
                                    WallSide.Low => 31011,
                                    WallSide.Tall => 31012,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31013,
                                    WallSide.Low => 31014,
                                    WallSide.Tall => 31015,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31016,
                                    WallSide.Low => 31017,
                                    WallSide.Tall => 31018,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31019,
                                    WallSide.Low => 31020,
                                    WallSide.Tall => 31021,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31022,
                                    WallSide.Low => 31023,
                                    WallSide.Tall => 31024,
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
                                    WallSide.None => 31025,
                                    WallSide.Low => 31026,
                                    WallSide.Tall => 31027,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31028,
                                    WallSide.Low => 31029,
                                    WallSide.Tall => 31030,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31031,
                                    WallSide.Low => 31032,
                                    WallSide.Tall => 31033,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31034,
                                    WallSide.Low => 31035,
                                    WallSide.Tall => 31036,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31037,
                                    WallSide.Low => 31038,
                                    WallSide.Tall => 31039,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31040,
                                    WallSide.Low => 31041,
                                    WallSide.Tall => 31042,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31043,
                                    WallSide.Low => 31044,
                                    WallSide.Tall => 31045,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31046,
                                    WallSide.Low => 31047,
                                    WallSide.Tall => 31048,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31049,
                                    WallSide.Low => 31050,
                                    WallSide.Tall => 31051,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31052,
                                    WallSide.Low => 31053,
                                    WallSide.Tall => 31054,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31055,
                                    WallSide.Low => 31056,
                                    WallSide.Tall => 31057,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31058,
                                    WallSide.Low => 31059,
                                    WallSide.Tall => 31060,
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
                                    WallSide.None => 31061,
                                    WallSide.Low => 31062,
                                    WallSide.Tall => 31063,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31064,
                                    WallSide.Low => 31065,
                                    WallSide.Tall => 31066,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31067,
                                    WallSide.Low => 31068,
                                    WallSide.Tall => 31069,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31070,
                                    WallSide.Low => 31071,
                                    WallSide.Tall => 31072,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31073,
                                    WallSide.Low => 31074,
                                    WallSide.Tall => 31075,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31076,
                                    WallSide.Low => 31077,
                                    WallSide.Tall => 31078,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31079,
                                    WallSide.Low => 31080,
                                    WallSide.Tall => 31081,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31082,
                                    WallSide.Low => 31083,
                                    WallSide.Tall => 31084,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31085,
                                    WallSide.Low => 31086,
                                    WallSide.Tall => 31087,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31088,
                                    WallSide.Low => 31089,
                                    WallSide.Tall => 31090,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31091,
                                    WallSide.Low => 31092,
                                    WallSide.Tall => 31093,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31094,
                                    WallSide.Low => 31095,
                                    WallSide.Tall => 31096,
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
                                    WallSide.None => 31097,
                                    WallSide.Low => 31098,
                                    WallSide.Tall => 31099,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31100,
                                    WallSide.Low => 31101,
                                    WallSide.Tall => 31102,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31103,
                                    WallSide.Low => 31104,
                                    WallSide.Tall => 31105,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31106,
                                    WallSide.Low => 31107,
                                    WallSide.Tall => 31108,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31109,
                                    WallSide.Low => 31110,
                                    WallSide.Tall => 31111,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31112,
                                    WallSide.Low => 31113,
                                    WallSide.Tall => 31114,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31115,
                                    WallSide.Low => 31116,
                                    WallSide.Tall => 31117,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31118,
                                    WallSide.Low => 31119,
                                    WallSide.Tall => 31120,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31121,
                                    WallSide.Low => 31122,
                                    WallSide.Tall => 31123,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31124,
                                    WallSide.Low => 31125,
                                    WallSide.Tall => 31126,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31127,
                                    WallSide.Low => 31128,
                                    WallSide.Tall => 31129,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31130,
                                    WallSide.Low => 31131,
                                    WallSide.Tall => 31132,
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
                                    WallSide.None => 31133,
                                    WallSide.Low => 31134,
                                    WallSide.Tall => 31135,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31136,
                                    WallSide.Low => 31137,
                                    WallSide.Tall => 31138,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31139,
                                    WallSide.Low => 31140,
                                    WallSide.Tall => 31141,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31142,
                                    WallSide.Low => 31143,
                                    WallSide.Tall => 31144,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31145,
                                    WallSide.Low => 31146,
                                    WallSide.Tall => 31147,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31148,
                                    WallSide.Low => 31149,
                                    WallSide.Tall => 31150,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31151,
                                    WallSide.Low => 31152,
                                    WallSide.Tall => 31153,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31154,
                                    WallSide.Low => 31155,
                                    WallSide.Tall => 31156,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31157,
                                    WallSide.Low => 31158,
                                    WallSide.Tall => 31159,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31160,
                                    WallSide.Low => 31161,
                                    WallSide.Tall => 31162,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31163,
                                    WallSide.Low => 31164,
                                    WallSide.Tall => 31165,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31166,
                                    WallSide.Low => 31167,
                                    WallSide.Tall => 31168,
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
                                    WallSide.None => 31169,
                                    WallSide.Low => 31170,
                                    WallSide.Tall => 31171,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31172,
                                    WallSide.Low => 31173,
                                    WallSide.Tall => 31174,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31175,
                                    WallSide.Low => 31176,
                                    WallSide.Tall => 31177,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31178,
                                    WallSide.Low => 31179,
                                    WallSide.Tall => 31180,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31181,
                                    WallSide.Low => 31182,
                                    WallSide.Tall => 31183,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31184,
                                    WallSide.Low => 31185,
                                    WallSide.Tall => 31186,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31187,
                                    WallSide.Low => 31188,
                                    WallSide.Tall => 31189,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31190,
                                    WallSide.Low => 31191,
                                    WallSide.Tall => 31192,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31193,
                                    WallSide.Low => 31194,
                                    WallSide.Tall => 31195,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31196,
                                    WallSide.Low => 31197,
                                    WallSide.Tall => 31198,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31199,
                                    WallSide.Low => 31200,
                                    WallSide.Tall => 31201,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31202,
                                    WallSide.Low => 31203,
                                    WallSide.Tall => 31204,
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
                                    WallSide.None => 31205,
                                    WallSide.Low => 31206,
                                    WallSide.Tall => 31207,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31208,
                                    WallSide.Low => 31209,
                                    WallSide.Tall => 31210,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31211,
                                    WallSide.Low => 31212,
                                    WallSide.Tall => 31213,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31214,
                                    WallSide.Low => 31215,
                                    WallSide.Tall => 31216,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31217,
                                    WallSide.Low => 31218,
                                    WallSide.Tall => 31219,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31220,
                                    WallSide.Low => 31221,
                                    WallSide.Tall => 31222,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31223,
                                    WallSide.Low => 31224,
                                    WallSide.Tall => 31225,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31226,
                                    WallSide.Low => 31227,
                                    WallSide.Tall => 31228,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31229,
                                    WallSide.Low => 31230,
                                    WallSide.Tall => 31231,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31232,
                                    WallSide.Low => 31233,
                                    WallSide.Tall => 31234,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 31235,
                                    WallSide.Low => 31236,
                                    WallSide.Tall => 31237,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 31238,
                                    WallSide.Low => 31239,
                                    WallSide.Tall => 31240,
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
            30917 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            30918 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            30919 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            30920 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            30921 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            30922 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            30923 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            30924 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            30925 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            30926 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            30927 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            30928 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            30929 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            30930 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            30931 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            30932 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            30933 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            30934 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            30935 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            30936 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            30937 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            30938 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            30939 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            30940 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            30941 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            30942 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            30943 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            30944 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            30945 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            30946 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            30947 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            30948 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            30949 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            30950 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            30951 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            30952 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            30953 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            30954 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            30955 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            30956 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            30957 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            30958 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            30959 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            30960 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            30961 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            30962 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            30963 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            30964 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            30965 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            30966 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            30967 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            30968 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            30969 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            30970 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            30971 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            30972 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            30973 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            30974 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            30975 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            30976 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            30977 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            30978 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            30979 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            30980 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            30981 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            30982 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            30983 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            30984 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            30985 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            30986 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            30987 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            30988 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            30989 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            30990 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            30991 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            30992 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            30993 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            30994 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            30995 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            30996 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            30997 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            30998 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            30999 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            31000 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            31001 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            31002 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            31003 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            31004 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            31005 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            31006 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            31007 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            31008 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            31009 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            31010 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            31011 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            31012 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            31013 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            31014 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            31015 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            31016 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            31017 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            31018 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            31019 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            31020 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            31021 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            31022 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            31023 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            31024 => new PolishedDeepslateWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            31025 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            31026 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            31027 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            31028 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            31029 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            31030 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            31031 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            31032 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            31033 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            31034 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            31035 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            31036 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            31037 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            31038 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            31039 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            31040 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            31041 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            31042 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            31043 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            31044 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            31045 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            31046 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            31047 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            31048 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            31049 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            31050 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            31051 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            31052 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            31053 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            31054 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            31055 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            31056 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            31057 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            31058 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            31059 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            31060 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            31061 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            31062 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            31063 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            31064 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            31065 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            31066 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            31067 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            31068 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            31069 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            31070 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            31071 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            31072 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            31073 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            31074 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            31075 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            31076 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            31077 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            31078 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            31079 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            31080 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            31081 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            31082 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            31083 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            31084 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            31085 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            31086 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            31087 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            31088 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            31089 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            31090 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            31091 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            31092 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            31093 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            31094 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            31095 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            31096 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            31097 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            31098 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            31099 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            31100 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            31101 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            31102 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            31103 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            31104 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            31105 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            31106 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            31107 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            31108 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            31109 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            31110 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            31111 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            31112 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            31113 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            31114 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            31115 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            31116 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            31117 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            31118 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            31119 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            31120 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            31121 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            31122 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            31123 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            31124 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            31125 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            31126 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            31127 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            31128 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            31129 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            31130 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            31131 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            31132 => new PolishedDeepslateWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            31133 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            31134 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            31135 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            31136 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            31137 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            31138 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            31139 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            31140 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            31141 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            31142 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            31143 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            31144 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            31145 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            31146 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            31147 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            31148 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            31149 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            31150 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            31151 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            31152 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            31153 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            31154 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            31155 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            31156 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            31157 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            31158 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            31159 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            31160 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            31161 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            31162 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            31163 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            31164 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            31165 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            31166 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            31167 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            31168 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            31169 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            31170 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            31171 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            31172 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            31173 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            31174 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            31175 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            31176 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            31177 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            31178 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            31179 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            31180 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            31181 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            31182 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            31183 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            31184 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            31185 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            31186 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            31187 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            31188 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            31189 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            31190 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            31191 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            31192 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            31193 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            31194 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            31195 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            31196 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            31197 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            31198 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            31199 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            31200 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            31201 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            31202 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            31203 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            31204 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            31205 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            31206 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            31207 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            31208 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            31209 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            31210 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            31211 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            31212 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            31213 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            31214 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            31215 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            31216 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            31217 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            31218 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            31219 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            31220 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            31221 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            31222 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            31223 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            31224 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            31225 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            31226 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            31227 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            31228 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            31229 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            31230 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            31231 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            31232 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            31233 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            31234 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            31235 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            31236 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            31237 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            31238 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            31239 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            31240 => new PolishedDeepslateWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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

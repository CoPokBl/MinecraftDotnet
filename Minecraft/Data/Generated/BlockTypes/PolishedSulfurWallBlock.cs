using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedSulfurWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:wall", "block.minecraft.polished_sulfur_wall", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_sulfur_wall", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 18, "sulfur", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S85, BlockShapes.S130, BlockShapes.S1, BlockShapes.S85, BlockShapes.S130);
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

    public BlockStateInfo StateInfo => States[StateId - 25190];

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
                                    WallSide.None => 25190,
                                    WallSide.Low => 25191,
                                    WallSide.Tall => 25192,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25193,
                                    WallSide.Low => 25194,
                                    WallSide.Tall => 25195,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25196,
                                    WallSide.Low => 25197,
                                    WallSide.Tall => 25198,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25199,
                                    WallSide.Low => 25200,
                                    WallSide.Tall => 25201,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25202,
                                    WallSide.Low => 25203,
                                    WallSide.Tall => 25204,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25205,
                                    WallSide.Low => 25206,
                                    WallSide.Tall => 25207,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25208,
                                    WallSide.Low => 25209,
                                    WallSide.Tall => 25210,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25211,
                                    WallSide.Low => 25212,
                                    WallSide.Tall => 25213,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25214,
                                    WallSide.Low => 25215,
                                    WallSide.Tall => 25216,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25217,
                                    WallSide.Low => 25218,
                                    WallSide.Tall => 25219,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25220,
                                    WallSide.Low => 25221,
                                    WallSide.Tall => 25222,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25223,
                                    WallSide.Low => 25224,
                                    WallSide.Tall => 25225,
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
                                    WallSide.None => 25226,
                                    WallSide.Low => 25227,
                                    WallSide.Tall => 25228,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25229,
                                    WallSide.Low => 25230,
                                    WallSide.Tall => 25231,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25232,
                                    WallSide.Low => 25233,
                                    WallSide.Tall => 25234,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25235,
                                    WallSide.Low => 25236,
                                    WallSide.Tall => 25237,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25238,
                                    WallSide.Low => 25239,
                                    WallSide.Tall => 25240,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25241,
                                    WallSide.Low => 25242,
                                    WallSide.Tall => 25243,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25244,
                                    WallSide.Low => 25245,
                                    WallSide.Tall => 25246,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25247,
                                    WallSide.Low => 25248,
                                    WallSide.Tall => 25249,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25250,
                                    WallSide.Low => 25251,
                                    WallSide.Tall => 25252,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25253,
                                    WallSide.Low => 25254,
                                    WallSide.Tall => 25255,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25256,
                                    WallSide.Low => 25257,
                                    WallSide.Tall => 25258,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25259,
                                    WallSide.Low => 25260,
                                    WallSide.Tall => 25261,
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
                                    WallSide.None => 25262,
                                    WallSide.Low => 25263,
                                    WallSide.Tall => 25264,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25265,
                                    WallSide.Low => 25266,
                                    WallSide.Tall => 25267,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25268,
                                    WallSide.Low => 25269,
                                    WallSide.Tall => 25270,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25271,
                                    WallSide.Low => 25272,
                                    WallSide.Tall => 25273,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25274,
                                    WallSide.Low => 25275,
                                    WallSide.Tall => 25276,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25277,
                                    WallSide.Low => 25278,
                                    WallSide.Tall => 25279,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25280,
                                    WallSide.Low => 25281,
                                    WallSide.Tall => 25282,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25283,
                                    WallSide.Low => 25284,
                                    WallSide.Tall => 25285,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25286,
                                    WallSide.Low => 25287,
                                    WallSide.Tall => 25288,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25289,
                                    WallSide.Low => 25290,
                                    WallSide.Tall => 25291,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25292,
                                    WallSide.Low => 25293,
                                    WallSide.Tall => 25294,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25295,
                                    WallSide.Low => 25296,
                                    WallSide.Tall => 25297,
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
                                    WallSide.None => 25298,
                                    WallSide.Low => 25299,
                                    WallSide.Tall => 25300,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25301,
                                    WallSide.Low => 25302,
                                    WallSide.Tall => 25303,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25304,
                                    WallSide.Low => 25305,
                                    WallSide.Tall => 25306,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25307,
                                    WallSide.Low => 25308,
                                    WallSide.Tall => 25309,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25310,
                                    WallSide.Low => 25311,
                                    WallSide.Tall => 25312,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25313,
                                    WallSide.Low => 25314,
                                    WallSide.Tall => 25315,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25316,
                                    WallSide.Low => 25317,
                                    WallSide.Tall => 25318,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25319,
                                    WallSide.Low => 25320,
                                    WallSide.Tall => 25321,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25322,
                                    WallSide.Low => 25323,
                                    WallSide.Tall => 25324,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25325,
                                    WallSide.Low => 25326,
                                    WallSide.Tall => 25327,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25328,
                                    WallSide.Low => 25329,
                                    WallSide.Tall => 25330,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25331,
                                    WallSide.Low => 25332,
                                    WallSide.Tall => 25333,
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
                                    WallSide.None => 25334,
                                    WallSide.Low => 25335,
                                    WallSide.Tall => 25336,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25337,
                                    WallSide.Low => 25338,
                                    WallSide.Tall => 25339,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25340,
                                    WallSide.Low => 25341,
                                    WallSide.Tall => 25342,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25343,
                                    WallSide.Low => 25344,
                                    WallSide.Tall => 25345,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25346,
                                    WallSide.Low => 25347,
                                    WallSide.Tall => 25348,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25349,
                                    WallSide.Low => 25350,
                                    WallSide.Tall => 25351,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25352,
                                    WallSide.Low => 25353,
                                    WallSide.Tall => 25354,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25355,
                                    WallSide.Low => 25356,
                                    WallSide.Tall => 25357,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25358,
                                    WallSide.Low => 25359,
                                    WallSide.Tall => 25360,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25361,
                                    WallSide.Low => 25362,
                                    WallSide.Tall => 25363,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25364,
                                    WallSide.Low => 25365,
                                    WallSide.Tall => 25366,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25367,
                                    WallSide.Low => 25368,
                                    WallSide.Tall => 25369,
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
                                    WallSide.None => 25370,
                                    WallSide.Low => 25371,
                                    WallSide.Tall => 25372,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25373,
                                    WallSide.Low => 25374,
                                    WallSide.Tall => 25375,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25376,
                                    WallSide.Low => 25377,
                                    WallSide.Tall => 25378,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25379,
                                    WallSide.Low => 25380,
                                    WallSide.Tall => 25381,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25382,
                                    WallSide.Low => 25383,
                                    WallSide.Tall => 25384,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25385,
                                    WallSide.Low => 25386,
                                    WallSide.Tall => 25387,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25388,
                                    WallSide.Low => 25389,
                                    WallSide.Tall => 25390,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25391,
                                    WallSide.Low => 25392,
                                    WallSide.Tall => 25393,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25394,
                                    WallSide.Low => 25395,
                                    WallSide.Tall => 25396,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25397,
                                    WallSide.Low => 25398,
                                    WallSide.Tall => 25399,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25400,
                                    WallSide.Low => 25401,
                                    WallSide.Tall => 25402,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25403,
                                    WallSide.Low => 25404,
                                    WallSide.Tall => 25405,
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
                                    WallSide.None => 25406,
                                    WallSide.Low => 25407,
                                    WallSide.Tall => 25408,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25409,
                                    WallSide.Low => 25410,
                                    WallSide.Tall => 25411,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25412,
                                    WallSide.Low => 25413,
                                    WallSide.Tall => 25414,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25415,
                                    WallSide.Low => 25416,
                                    WallSide.Tall => 25417,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25418,
                                    WallSide.Low => 25419,
                                    WallSide.Tall => 25420,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25421,
                                    WallSide.Low => 25422,
                                    WallSide.Tall => 25423,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25424,
                                    WallSide.Low => 25425,
                                    WallSide.Tall => 25426,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25427,
                                    WallSide.Low => 25428,
                                    WallSide.Tall => 25429,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25430,
                                    WallSide.Low => 25431,
                                    WallSide.Tall => 25432,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25433,
                                    WallSide.Low => 25434,
                                    WallSide.Tall => 25435,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25436,
                                    WallSide.Low => 25437,
                                    WallSide.Tall => 25438,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25439,
                                    WallSide.Low => 25440,
                                    WallSide.Tall => 25441,
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
                                    WallSide.None => 25442,
                                    WallSide.Low => 25443,
                                    WallSide.Tall => 25444,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25445,
                                    WallSide.Low => 25446,
                                    WallSide.Tall => 25447,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25448,
                                    WallSide.Low => 25449,
                                    WallSide.Tall => 25450,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25451,
                                    WallSide.Low => 25452,
                                    WallSide.Tall => 25453,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25454,
                                    WallSide.Low => 25455,
                                    WallSide.Tall => 25456,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25457,
                                    WallSide.Low => 25458,
                                    WallSide.Tall => 25459,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25460,
                                    WallSide.Low => 25461,
                                    WallSide.Tall => 25462,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25463,
                                    WallSide.Low => 25464,
                                    WallSide.Tall => 25465,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25466,
                                    WallSide.Low => 25467,
                                    WallSide.Tall => 25468,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25469,
                                    WallSide.Low => 25470,
                                    WallSide.Tall => 25471,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25472,
                                    WallSide.Low => 25473,
                                    WallSide.Tall => 25474,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25475,
                                    WallSide.Low => 25476,
                                    WallSide.Tall => 25477,
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
                                    WallSide.None => 25478,
                                    WallSide.Low => 25479,
                                    WallSide.Tall => 25480,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25481,
                                    WallSide.Low => 25482,
                                    WallSide.Tall => 25483,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25484,
                                    WallSide.Low => 25485,
                                    WallSide.Tall => 25486,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25487,
                                    WallSide.Low => 25488,
                                    WallSide.Tall => 25489,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25490,
                                    WallSide.Low => 25491,
                                    WallSide.Tall => 25492,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25493,
                                    WallSide.Low => 25494,
                                    WallSide.Tall => 25495,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25496,
                                    WallSide.Low => 25497,
                                    WallSide.Tall => 25498,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25499,
                                    WallSide.Low => 25500,
                                    WallSide.Tall => 25501,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25502,
                                    WallSide.Low => 25503,
                                    WallSide.Tall => 25504,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25505,
                                    WallSide.Low => 25506,
                                    WallSide.Tall => 25507,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25508,
                                    WallSide.Low => 25509,
                                    WallSide.Tall => 25510,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25511,
                                    WallSide.Low => 25512,
                                    WallSide.Tall => 25513,
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
            25190 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            25191 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            25192 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            25193 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            25194 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            25195 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            25196 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            25197 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            25198 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            25199 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            25200 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            25201 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            25202 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            25203 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            25204 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            25205 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            25206 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            25207 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            25208 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            25209 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            25210 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            25211 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            25212 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            25213 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            25214 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            25215 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            25216 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            25217 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            25218 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            25219 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            25220 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            25221 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            25222 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            25223 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            25224 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            25225 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            25226 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            25227 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            25228 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            25229 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            25230 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            25231 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            25232 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            25233 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            25234 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            25235 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            25236 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            25237 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            25238 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            25239 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            25240 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            25241 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            25242 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            25243 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            25244 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            25245 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            25246 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            25247 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            25248 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            25249 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            25250 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            25251 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            25252 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            25253 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            25254 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            25255 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            25256 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            25257 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            25258 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            25259 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            25260 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            25261 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            25262 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            25263 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            25264 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            25265 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            25266 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            25267 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            25268 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            25269 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            25270 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            25271 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            25272 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            25273 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            25274 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            25275 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            25276 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            25277 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            25278 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            25279 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            25280 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            25281 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            25282 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            25283 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            25284 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            25285 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            25286 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            25287 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            25288 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            25289 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            25290 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            25291 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            25292 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            25293 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            25294 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            25295 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            25296 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            25297 => new PolishedSulfurWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            25298 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            25299 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            25300 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            25301 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            25302 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            25303 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            25304 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            25305 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            25306 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            25307 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            25308 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            25309 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            25310 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            25311 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            25312 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            25313 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            25314 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            25315 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            25316 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            25317 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            25318 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            25319 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            25320 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            25321 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            25322 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            25323 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            25324 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            25325 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            25326 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            25327 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            25328 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            25329 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            25330 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            25331 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            25332 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            25333 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            25334 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            25335 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            25336 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            25337 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            25338 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            25339 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            25340 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            25341 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            25342 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            25343 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            25344 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            25345 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            25346 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            25347 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            25348 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            25349 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            25350 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            25351 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            25352 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            25353 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            25354 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            25355 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            25356 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            25357 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            25358 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            25359 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            25360 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            25361 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            25362 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            25363 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            25364 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            25365 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            25366 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            25367 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            25368 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            25369 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            25370 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            25371 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            25372 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            25373 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            25374 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            25375 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            25376 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            25377 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            25378 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            25379 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            25380 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            25381 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            25382 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            25383 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            25384 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            25385 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            25386 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            25387 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            25388 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            25389 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            25390 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            25391 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            25392 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            25393 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            25394 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            25395 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            25396 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            25397 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            25398 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            25399 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            25400 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            25401 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            25402 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            25403 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            25404 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            25405 => new PolishedSulfurWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            25406 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            25407 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            25408 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            25409 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            25410 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            25411 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            25412 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            25413 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            25414 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            25415 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            25416 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            25417 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            25418 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            25419 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            25420 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            25421 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            25422 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            25423 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            25424 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            25425 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            25426 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            25427 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            25428 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            25429 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            25430 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            25431 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            25432 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            25433 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            25434 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            25435 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            25436 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            25437 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            25438 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            25439 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            25440 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            25441 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            25442 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            25443 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            25444 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            25445 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            25446 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            25447 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            25448 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            25449 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            25450 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            25451 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            25452 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            25453 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            25454 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            25455 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            25456 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            25457 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            25458 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            25459 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            25460 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            25461 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            25462 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            25463 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            25464 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            25465 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            25466 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            25467 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            25468 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            25469 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            25470 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            25471 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            25472 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            25473 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            25474 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            25475 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            25476 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            25477 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            25478 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            25479 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            25480 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            25481 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            25482 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            25483 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            25484 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            25485 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            25486 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            25487 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            25488 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            25489 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            25490 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            25491 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            25492 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            25493 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            25494 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            25495 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            25496 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            25497 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            25498 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            25499 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            25500 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            25501 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            25502 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            25503 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            25504 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            25505 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            25506 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            25507 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            25508 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            25509 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            25510 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            25511 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            25512 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            25513 => new PolishedSulfurWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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

using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GraniteWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:wall", "block.minecraft.granite_wall", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:granite_wall", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 10, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S85, BlockShapes.S130, BlockShapes.S1, BlockShapes.S85, BlockShapes.S130);
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

    public BlockStateInfo StateInfo => States[StateId - 17790];

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
                                    WallSide.None => 17790,
                                    WallSide.Low => 17791,
                                    WallSide.Tall => 17792,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17793,
                                    WallSide.Low => 17794,
                                    WallSide.Tall => 17795,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17796,
                                    WallSide.Low => 17797,
                                    WallSide.Tall => 17798,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17799,
                                    WallSide.Low => 17800,
                                    WallSide.Tall => 17801,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17802,
                                    WallSide.Low => 17803,
                                    WallSide.Tall => 17804,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17805,
                                    WallSide.Low => 17806,
                                    WallSide.Tall => 17807,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17808,
                                    WallSide.Low => 17809,
                                    WallSide.Tall => 17810,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17811,
                                    WallSide.Low => 17812,
                                    WallSide.Tall => 17813,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17814,
                                    WallSide.Low => 17815,
                                    WallSide.Tall => 17816,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17817,
                                    WallSide.Low => 17818,
                                    WallSide.Tall => 17819,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17820,
                                    WallSide.Low => 17821,
                                    WallSide.Tall => 17822,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17823,
                                    WallSide.Low => 17824,
                                    WallSide.Tall => 17825,
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
                                    WallSide.None => 17826,
                                    WallSide.Low => 17827,
                                    WallSide.Tall => 17828,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17829,
                                    WallSide.Low => 17830,
                                    WallSide.Tall => 17831,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17832,
                                    WallSide.Low => 17833,
                                    WallSide.Tall => 17834,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17835,
                                    WallSide.Low => 17836,
                                    WallSide.Tall => 17837,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17838,
                                    WallSide.Low => 17839,
                                    WallSide.Tall => 17840,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17841,
                                    WallSide.Low => 17842,
                                    WallSide.Tall => 17843,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17844,
                                    WallSide.Low => 17845,
                                    WallSide.Tall => 17846,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17847,
                                    WallSide.Low => 17848,
                                    WallSide.Tall => 17849,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17850,
                                    WallSide.Low => 17851,
                                    WallSide.Tall => 17852,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17853,
                                    WallSide.Low => 17854,
                                    WallSide.Tall => 17855,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17856,
                                    WallSide.Low => 17857,
                                    WallSide.Tall => 17858,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17859,
                                    WallSide.Low => 17860,
                                    WallSide.Tall => 17861,
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
                                    WallSide.None => 17862,
                                    WallSide.Low => 17863,
                                    WallSide.Tall => 17864,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17865,
                                    WallSide.Low => 17866,
                                    WallSide.Tall => 17867,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17868,
                                    WallSide.Low => 17869,
                                    WallSide.Tall => 17870,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17871,
                                    WallSide.Low => 17872,
                                    WallSide.Tall => 17873,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17874,
                                    WallSide.Low => 17875,
                                    WallSide.Tall => 17876,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17877,
                                    WallSide.Low => 17878,
                                    WallSide.Tall => 17879,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17880,
                                    WallSide.Low => 17881,
                                    WallSide.Tall => 17882,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17883,
                                    WallSide.Low => 17884,
                                    WallSide.Tall => 17885,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17886,
                                    WallSide.Low => 17887,
                                    WallSide.Tall => 17888,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17889,
                                    WallSide.Low => 17890,
                                    WallSide.Tall => 17891,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17892,
                                    WallSide.Low => 17893,
                                    WallSide.Tall => 17894,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17895,
                                    WallSide.Low => 17896,
                                    WallSide.Tall => 17897,
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
                                    WallSide.None => 17898,
                                    WallSide.Low => 17899,
                                    WallSide.Tall => 17900,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17901,
                                    WallSide.Low => 17902,
                                    WallSide.Tall => 17903,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17904,
                                    WallSide.Low => 17905,
                                    WallSide.Tall => 17906,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17907,
                                    WallSide.Low => 17908,
                                    WallSide.Tall => 17909,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17910,
                                    WallSide.Low => 17911,
                                    WallSide.Tall => 17912,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17913,
                                    WallSide.Low => 17914,
                                    WallSide.Tall => 17915,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17916,
                                    WallSide.Low => 17917,
                                    WallSide.Tall => 17918,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17919,
                                    WallSide.Low => 17920,
                                    WallSide.Tall => 17921,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17922,
                                    WallSide.Low => 17923,
                                    WallSide.Tall => 17924,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17925,
                                    WallSide.Low => 17926,
                                    WallSide.Tall => 17927,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17928,
                                    WallSide.Low => 17929,
                                    WallSide.Tall => 17930,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17931,
                                    WallSide.Low => 17932,
                                    WallSide.Tall => 17933,
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
                                    WallSide.None => 17934,
                                    WallSide.Low => 17935,
                                    WallSide.Tall => 17936,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17937,
                                    WallSide.Low => 17938,
                                    WallSide.Tall => 17939,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17940,
                                    WallSide.Low => 17941,
                                    WallSide.Tall => 17942,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17943,
                                    WallSide.Low => 17944,
                                    WallSide.Tall => 17945,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17946,
                                    WallSide.Low => 17947,
                                    WallSide.Tall => 17948,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17949,
                                    WallSide.Low => 17950,
                                    WallSide.Tall => 17951,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17952,
                                    WallSide.Low => 17953,
                                    WallSide.Tall => 17954,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17955,
                                    WallSide.Low => 17956,
                                    WallSide.Tall => 17957,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17958,
                                    WallSide.Low => 17959,
                                    WallSide.Tall => 17960,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17961,
                                    WallSide.Low => 17962,
                                    WallSide.Tall => 17963,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17964,
                                    WallSide.Low => 17965,
                                    WallSide.Tall => 17966,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17967,
                                    WallSide.Low => 17968,
                                    WallSide.Tall => 17969,
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
                                    WallSide.None => 17970,
                                    WallSide.Low => 17971,
                                    WallSide.Tall => 17972,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17973,
                                    WallSide.Low => 17974,
                                    WallSide.Tall => 17975,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17976,
                                    WallSide.Low => 17977,
                                    WallSide.Tall => 17978,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17979,
                                    WallSide.Low => 17980,
                                    WallSide.Tall => 17981,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17982,
                                    WallSide.Low => 17983,
                                    WallSide.Tall => 17984,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17985,
                                    WallSide.Low => 17986,
                                    WallSide.Tall => 17987,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17988,
                                    WallSide.Low => 17989,
                                    WallSide.Tall => 17990,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17991,
                                    WallSide.Low => 17992,
                                    WallSide.Tall => 17993,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17994,
                                    WallSide.Low => 17995,
                                    WallSide.Tall => 17996,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17997,
                                    WallSide.Low => 17998,
                                    WallSide.Tall => 17999,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18000,
                                    WallSide.Low => 18001,
                                    WallSide.Tall => 18002,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18003,
                                    WallSide.Low => 18004,
                                    WallSide.Tall => 18005,
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
                                    WallSide.None => 18006,
                                    WallSide.Low => 18007,
                                    WallSide.Tall => 18008,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18009,
                                    WallSide.Low => 18010,
                                    WallSide.Tall => 18011,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18012,
                                    WallSide.Low => 18013,
                                    WallSide.Tall => 18014,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18015,
                                    WallSide.Low => 18016,
                                    WallSide.Tall => 18017,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18018,
                                    WallSide.Low => 18019,
                                    WallSide.Tall => 18020,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18021,
                                    WallSide.Low => 18022,
                                    WallSide.Tall => 18023,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18024,
                                    WallSide.Low => 18025,
                                    WallSide.Tall => 18026,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18027,
                                    WallSide.Low => 18028,
                                    WallSide.Tall => 18029,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18030,
                                    WallSide.Low => 18031,
                                    WallSide.Tall => 18032,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18033,
                                    WallSide.Low => 18034,
                                    WallSide.Tall => 18035,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18036,
                                    WallSide.Low => 18037,
                                    WallSide.Tall => 18038,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18039,
                                    WallSide.Low => 18040,
                                    WallSide.Tall => 18041,
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
                                    WallSide.None => 18042,
                                    WallSide.Low => 18043,
                                    WallSide.Tall => 18044,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18045,
                                    WallSide.Low => 18046,
                                    WallSide.Tall => 18047,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18048,
                                    WallSide.Low => 18049,
                                    WallSide.Tall => 18050,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18051,
                                    WallSide.Low => 18052,
                                    WallSide.Tall => 18053,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18054,
                                    WallSide.Low => 18055,
                                    WallSide.Tall => 18056,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18057,
                                    WallSide.Low => 18058,
                                    WallSide.Tall => 18059,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18060,
                                    WallSide.Low => 18061,
                                    WallSide.Tall => 18062,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18063,
                                    WallSide.Low => 18064,
                                    WallSide.Tall => 18065,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18066,
                                    WallSide.Low => 18067,
                                    WallSide.Tall => 18068,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18069,
                                    WallSide.Low => 18070,
                                    WallSide.Tall => 18071,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18072,
                                    WallSide.Low => 18073,
                                    WallSide.Tall => 18074,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18075,
                                    WallSide.Low => 18076,
                                    WallSide.Tall => 18077,
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
                                    WallSide.None => 18078,
                                    WallSide.Low => 18079,
                                    WallSide.Tall => 18080,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18081,
                                    WallSide.Low => 18082,
                                    WallSide.Tall => 18083,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18084,
                                    WallSide.Low => 18085,
                                    WallSide.Tall => 18086,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18087,
                                    WallSide.Low => 18088,
                                    WallSide.Tall => 18089,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18090,
                                    WallSide.Low => 18091,
                                    WallSide.Tall => 18092,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18093,
                                    WallSide.Low => 18094,
                                    WallSide.Tall => 18095,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18096,
                                    WallSide.Low => 18097,
                                    WallSide.Tall => 18098,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18099,
                                    WallSide.Low => 18100,
                                    WallSide.Tall => 18101,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18102,
                                    WallSide.Low => 18103,
                                    WallSide.Tall => 18104,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18105,
                                    WallSide.Low => 18106,
                                    WallSide.Tall => 18107,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 18108,
                                    WallSide.Low => 18109,
                                    WallSide.Tall => 18110,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 18111,
                                    WallSide.Low => 18112,
                                    WallSide.Tall => 18113,
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
            17790 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            17791 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            17792 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            17793 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            17794 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            17795 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            17796 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            17797 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            17798 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            17799 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            17800 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            17801 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            17802 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            17803 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            17804 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            17805 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            17806 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            17807 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            17808 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            17809 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            17810 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            17811 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            17812 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            17813 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            17814 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            17815 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            17816 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            17817 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            17818 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            17819 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            17820 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            17821 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            17822 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            17823 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            17824 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            17825 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            17826 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            17827 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            17828 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            17829 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            17830 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            17831 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            17832 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            17833 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            17834 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            17835 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            17836 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            17837 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            17838 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            17839 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            17840 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            17841 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            17842 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            17843 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            17844 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            17845 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            17846 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            17847 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            17848 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            17849 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            17850 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            17851 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            17852 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            17853 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            17854 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            17855 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            17856 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            17857 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            17858 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            17859 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            17860 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            17861 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            17862 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            17863 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            17864 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            17865 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            17866 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            17867 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            17868 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            17869 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            17870 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            17871 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            17872 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            17873 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            17874 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            17875 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            17876 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            17877 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            17878 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            17879 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            17880 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            17881 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            17882 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            17883 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            17884 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            17885 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            17886 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            17887 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            17888 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            17889 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            17890 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            17891 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            17892 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            17893 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            17894 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            17895 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            17896 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            17897 => new GraniteWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            17898 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            17899 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            17900 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            17901 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            17902 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            17903 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            17904 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            17905 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            17906 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            17907 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            17908 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            17909 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            17910 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            17911 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            17912 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            17913 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            17914 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            17915 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            17916 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            17917 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            17918 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            17919 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            17920 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            17921 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            17922 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            17923 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            17924 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            17925 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            17926 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            17927 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            17928 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            17929 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            17930 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            17931 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            17932 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            17933 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            17934 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            17935 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            17936 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            17937 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            17938 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            17939 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            17940 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            17941 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            17942 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            17943 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            17944 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            17945 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            17946 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            17947 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            17948 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            17949 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            17950 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            17951 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            17952 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            17953 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            17954 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            17955 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            17956 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            17957 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            17958 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            17959 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            17960 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            17961 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            17962 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            17963 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            17964 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            17965 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            17966 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            17967 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            17968 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            17969 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            17970 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            17971 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            17972 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            17973 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            17974 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            17975 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            17976 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            17977 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            17978 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            17979 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            17980 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            17981 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            17982 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            17983 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            17984 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            17985 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            17986 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            17987 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            17988 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            17989 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            17990 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            17991 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            17992 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            17993 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            17994 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            17995 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            17996 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            17997 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            17998 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            17999 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            18000 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            18001 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            18002 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            18003 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            18004 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            18005 => new GraniteWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            18006 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            18007 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            18008 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            18009 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            18010 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            18011 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            18012 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            18013 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            18014 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            18015 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            18016 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            18017 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            18018 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            18019 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            18020 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            18021 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            18022 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            18023 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            18024 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            18025 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            18026 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            18027 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            18028 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            18029 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            18030 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            18031 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            18032 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            18033 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            18034 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            18035 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            18036 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            18037 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            18038 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            18039 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            18040 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            18041 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            18042 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            18043 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            18044 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            18045 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            18046 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            18047 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            18048 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            18049 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            18050 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            18051 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            18052 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            18053 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            18054 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            18055 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            18056 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            18057 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            18058 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            18059 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            18060 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            18061 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            18062 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            18063 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            18064 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            18065 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            18066 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            18067 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            18068 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            18069 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            18070 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            18071 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            18072 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            18073 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            18074 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            18075 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            18076 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            18077 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            18078 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            18079 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            18080 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            18081 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            18082 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            18083 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            18084 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            18085 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            18086 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            18087 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            18088 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            18089 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            18090 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            18091 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            18092 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            18093 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            18094 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            18095 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            18096 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            18097 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            18098 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            18099 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            18100 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            18101 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            18102 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            18103 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            18104 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            18105 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            18106 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            18107 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            18108 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            18109 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            18110 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            18111 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            18112 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            18113 => new GraniteWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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

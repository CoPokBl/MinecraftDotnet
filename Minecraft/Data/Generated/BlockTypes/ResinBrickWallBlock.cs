using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ResinBrickWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:wall", "block.minecraft.resin_brick_wall", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:resin_brick_wall", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 37, "resin_bricks", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S85, BlockShapes.S130, BlockShapes.S1, BlockShapes.S85, BlockShapes.S130);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S131, CollisionShape = BlockShapes.S132, OcclusionShape = BlockShapes.S131, VisualShape = BlockShapes.S132 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S133, CollisionShape = BlockShapes.S132, OcclusionShape = BlockShapes.S133, VisualShape = BlockShapes.S132 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I4 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S131, CollisionShape = BlockShapes.S132, OcclusionShape = BlockShapes.S131, VisualShape = BlockShapes.S132 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S133, CollisionShape = BlockShapes.S132, OcclusionShape = BlockShapes.S133, VisualShape = BlockShapes.S132 };
    private static readonly BlockStateInfo I6 = I0 with { CanRespawnIn = true, BlocksMotion = false, Solid = false, BlockShape = BlockShapes.S1, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S1, VisualShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S134, CollisionShape = BlockShapes.S135, OcclusionShape = BlockShapes.S134, VisualShape = BlockShapes.S135 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S136, CollisionShape = BlockShapes.S135, OcclusionShape = BlockShapes.S136, VisualShape = BlockShapes.S135 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, CanRespawnIn = true, BlocksMotion = false, Solid = false, Fluid = null, BlockShape = BlockShapes.S1, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S1, VisualShape = BlockShapes.S1 };
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

    public BlockStateInfo StateInfo => States[StateId - 9009];

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
                                    WallSide.None => 9009,
                                    WallSide.Low => 9010,
                                    WallSide.Tall => 9011,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9012,
                                    WallSide.Low => 9013,
                                    WallSide.Tall => 9014,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9015,
                                    WallSide.Low => 9016,
                                    WallSide.Tall => 9017,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9018,
                                    WallSide.Low => 9019,
                                    WallSide.Tall => 9020,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9021,
                                    WallSide.Low => 9022,
                                    WallSide.Tall => 9023,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9024,
                                    WallSide.Low => 9025,
                                    WallSide.Tall => 9026,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9027,
                                    WallSide.Low => 9028,
                                    WallSide.Tall => 9029,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9030,
                                    WallSide.Low => 9031,
                                    WallSide.Tall => 9032,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9033,
                                    WallSide.Low => 9034,
                                    WallSide.Tall => 9035,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9036,
                                    WallSide.Low => 9037,
                                    WallSide.Tall => 9038,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9039,
                                    WallSide.Low => 9040,
                                    WallSide.Tall => 9041,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9042,
                                    WallSide.Low => 9043,
                                    WallSide.Tall => 9044,
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
                                    WallSide.None => 9045,
                                    WallSide.Low => 9046,
                                    WallSide.Tall => 9047,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9048,
                                    WallSide.Low => 9049,
                                    WallSide.Tall => 9050,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9051,
                                    WallSide.Low => 9052,
                                    WallSide.Tall => 9053,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9054,
                                    WallSide.Low => 9055,
                                    WallSide.Tall => 9056,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9057,
                                    WallSide.Low => 9058,
                                    WallSide.Tall => 9059,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9060,
                                    WallSide.Low => 9061,
                                    WallSide.Tall => 9062,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9063,
                                    WallSide.Low => 9064,
                                    WallSide.Tall => 9065,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9066,
                                    WallSide.Low => 9067,
                                    WallSide.Tall => 9068,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9069,
                                    WallSide.Low => 9070,
                                    WallSide.Tall => 9071,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9072,
                                    WallSide.Low => 9073,
                                    WallSide.Tall => 9074,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9075,
                                    WallSide.Low => 9076,
                                    WallSide.Tall => 9077,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9078,
                                    WallSide.Low => 9079,
                                    WallSide.Tall => 9080,
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
                                    WallSide.None => 9081,
                                    WallSide.Low => 9082,
                                    WallSide.Tall => 9083,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9084,
                                    WallSide.Low => 9085,
                                    WallSide.Tall => 9086,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9087,
                                    WallSide.Low => 9088,
                                    WallSide.Tall => 9089,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9090,
                                    WallSide.Low => 9091,
                                    WallSide.Tall => 9092,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9093,
                                    WallSide.Low => 9094,
                                    WallSide.Tall => 9095,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9096,
                                    WallSide.Low => 9097,
                                    WallSide.Tall => 9098,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9099,
                                    WallSide.Low => 9100,
                                    WallSide.Tall => 9101,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9102,
                                    WallSide.Low => 9103,
                                    WallSide.Tall => 9104,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9105,
                                    WallSide.Low => 9106,
                                    WallSide.Tall => 9107,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9108,
                                    WallSide.Low => 9109,
                                    WallSide.Tall => 9110,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9111,
                                    WallSide.Low => 9112,
                                    WallSide.Tall => 9113,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9114,
                                    WallSide.Low => 9115,
                                    WallSide.Tall => 9116,
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
                                    WallSide.None => 9117,
                                    WallSide.Low => 9118,
                                    WallSide.Tall => 9119,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9120,
                                    WallSide.Low => 9121,
                                    WallSide.Tall => 9122,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9123,
                                    WallSide.Low => 9124,
                                    WallSide.Tall => 9125,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9126,
                                    WallSide.Low => 9127,
                                    WallSide.Tall => 9128,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9129,
                                    WallSide.Low => 9130,
                                    WallSide.Tall => 9131,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9132,
                                    WallSide.Low => 9133,
                                    WallSide.Tall => 9134,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9135,
                                    WallSide.Low => 9136,
                                    WallSide.Tall => 9137,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9138,
                                    WallSide.Low => 9139,
                                    WallSide.Tall => 9140,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9141,
                                    WallSide.Low => 9142,
                                    WallSide.Tall => 9143,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9144,
                                    WallSide.Low => 9145,
                                    WallSide.Tall => 9146,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9147,
                                    WallSide.Low => 9148,
                                    WallSide.Tall => 9149,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9150,
                                    WallSide.Low => 9151,
                                    WallSide.Tall => 9152,
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
                                    WallSide.None => 9153,
                                    WallSide.Low => 9154,
                                    WallSide.Tall => 9155,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9156,
                                    WallSide.Low => 9157,
                                    WallSide.Tall => 9158,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9159,
                                    WallSide.Low => 9160,
                                    WallSide.Tall => 9161,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9162,
                                    WallSide.Low => 9163,
                                    WallSide.Tall => 9164,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9165,
                                    WallSide.Low => 9166,
                                    WallSide.Tall => 9167,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9168,
                                    WallSide.Low => 9169,
                                    WallSide.Tall => 9170,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9171,
                                    WallSide.Low => 9172,
                                    WallSide.Tall => 9173,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9174,
                                    WallSide.Low => 9175,
                                    WallSide.Tall => 9176,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9177,
                                    WallSide.Low => 9178,
                                    WallSide.Tall => 9179,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9180,
                                    WallSide.Low => 9181,
                                    WallSide.Tall => 9182,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9183,
                                    WallSide.Low => 9184,
                                    WallSide.Tall => 9185,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9186,
                                    WallSide.Low => 9187,
                                    WallSide.Tall => 9188,
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
                                    WallSide.None => 9189,
                                    WallSide.Low => 9190,
                                    WallSide.Tall => 9191,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9192,
                                    WallSide.Low => 9193,
                                    WallSide.Tall => 9194,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9195,
                                    WallSide.Low => 9196,
                                    WallSide.Tall => 9197,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9198,
                                    WallSide.Low => 9199,
                                    WallSide.Tall => 9200,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9201,
                                    WallSide.Low => 9202,
                                    WallSide.Tall => 9203,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9204,
                                    WallSide.Low => 9205,
                                    WallSide.Tall => 9206,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9207,
                                    WallSide.Low => 9208,
                                    WallSide.Tall => 9209,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9210,
                                    WallSide.Low => 9211,
                                    WallSide.Tall => 9212,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9213,
                                    WallSide.Low => 9214,
                                    WallSide.Tall => 9215,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9216,
                                    WallSide.Low => 9217,
                                    WallSide.Tall => 9218,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9219,
                                    WallSide.Low => 9220,
                                    WallSide.Tall => 9221,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9222,
                                    WallSide.Low => 9223,
                                    WallSide.Tall => 9224,
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
                                    WallSide.None => 9225,
                                    WallSide.Low => 9226,
                                    WallSide.Tall => 9227,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9228,
                                    WallSide.Low => 9229,
                                    WallSide.Tall => 9230,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9231,
                                    WallSide.Low => 9232,
                                    WallSide.Tall => 9233,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9234,
                                    WallSide.Low => 9235,
                                    WallSide.Tall => 9236,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9237,
                                    WallSide.Low => 9238,
                                    WallSide.Tall => 9239,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9240,
                                    WallSide.Low => 9241,
                                    WallSide.Tall => 9242,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9243,
                                    WallSide.Low => 9244,
                                    WallSide.Tall => 9245,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9246,
                                    WallSide.Low => 9247,
                                    WallSide.Tall => 9248,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9249,
                                    WallSide.Low => 9250,
                                    WallSide.Tall => 9251,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9252,
                                    WallSide.Low => 9253,
                                    WallSide.Tall => 9254,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9255,
                                    WallSide.Low => 9256,
                                    WallSide.Tall => 9257,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9258,
                                    WallSide.Low => 9259,
                                    WallSide.Tall => 9260,
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
                                    WallSide.None => 9261,
                                    WallSide.Low => 9262,
                                    WallSide.Tall => 9263,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9264,
                                    WallSide.Low => 9265,
                                    WallSide.Tall => 9266,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9267,
                                    WallSide.Low => 9268,
                                    WallSide.Tall => 9269,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9270,
                                    WallSide.Low => 9271,
                                    WallSide.Tall => 9272,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9273,
                                    WallSide.Low => 9274,
                                    WallSide.Tall => 9275,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9276,
                                    WallSide.Low => 9277,
                                    WallSide.Tall => 9278,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9279,
                                    WallSide.Low => 9280,
                                    WallSide.Tall => 9281,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9282,
                                    WallSide.Low => 9283,
                                    WallSide.Tall => 9284,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9285,
                                    WallSide.Low => 9286,
                                    WallSide.Tall => 9287,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9288,
                                    WallSide.Low => 9289,
                                    WallSide.Tall => 9290,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9291,
                                    WallSide.Low => 9292,
                                    WallSide.Tall => 9293,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9294,
                                    WallSide.Low => 9295,
                                    WallSide.Tall => 9296,
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
                                    WallSide.None => 9297,
                                    WallSide.Low => 9298,
                                    WallSide.Tall => 9299,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9300,
                                    WallSide.Low => 9301,
                                    WallSide.Tall => 9302,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9303,
                                    WallSide.Low => 9304,
                                    WallSide.Tall => 9305,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9306,
                                    WallSide.Low => 9307,
                                    WallSide.Tall => 9308,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9309,
                                    WallSide.Low => 9310,
                                    WallSide.Tall => 9311,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9312,
                                    WallSide.Low => 9313,
                                    WallSide.Tall => 9314,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9315,
                                    WallSide.Low => 9316,
                                    WallSide.Tall => 9317,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9318,
                                    WallSide.Low => 9319,
                                    WallSide.Tall => 9320,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9321,
                                    WallSide.Low => 9322,
                                    WallSide.Tall => 9323,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9324,
                                    WallSide.Low => 9325,
                                    WallSide.Tall => 9326,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 9327,
                                    WallSide.Low => 9328,
                                    WallSide.Tall => 9329,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 9330,
                                    WallSide.Low => 9331,
                                    WallSide.Tall => 9332,
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
            9009 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            9010 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            9011 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            9012 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            9013 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            9014 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            9015 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            9016 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            9017 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            9018 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            9019 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            9020 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            9021 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            9022 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            9023 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            9024 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            9025 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            9026 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            9027 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            9028 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            9029 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            9030 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            9031 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            9032 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            9033 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            9034 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            9035 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            9036 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            9037 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            9038 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            9039 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            9040 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            9041 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            9042 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            9043 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            9044 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            9045 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            9046 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            9047 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            9048 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            9049 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            9050 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            9051 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            9052 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            9053 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            9054 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            9055 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            9056 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            9057 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            9058 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            9059 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            9060 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            9061 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            9062 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            9063 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            9064 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            9065 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            9066 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            9067 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            9068 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            9069 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            9070 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            9071 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            9072 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            9073 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            9074 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            9075 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            9076 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            9077 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            9078 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            9079 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            9080 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            9081 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            9082 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            9083 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            9084 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            9085 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            9086 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            9087 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            9088 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            9089 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            9090 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            9091 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            9092 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            9093 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            9094 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            9095 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            9096 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            9097 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            9098 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            9099 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            9100 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            9101 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            9102 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            9103 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            9104 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            9105 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            9106 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            9107 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            9108 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            9109 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            9110 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            9111 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            9112 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            9113 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            9114 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            9115 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            9116 => new ResinBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            9117 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            9118 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            9119 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            9120 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            9121 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            9122 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            9123 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            9124 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            9125 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            9126 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            9127 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            9128 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            9129 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            9130 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            9131 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            9132 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            9133 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            9134 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            9135 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            9136 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            9137 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            9138 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            9139 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            9140 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            9141 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            9142 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            9143 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            9144 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            9145 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            9146 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            9147 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            9148 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            9149 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            9150 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            9151 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            9152 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            9153 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            9154 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            9155 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            9156 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            9157 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            9158 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            9159 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            9160 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            9161 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            9162 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            9163 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            9164 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            9165 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            9166 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            9167 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            9168 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            9169 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            9170 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            9171 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            9172 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            9173 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            9174 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            9175 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            9176 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            9177 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            9178 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            9179 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            9180 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            9181 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            9182 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            9183 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            9184 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            9185 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            9186 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            9187 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            9188 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            9189 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            9190 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            9191 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            9192 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            9193 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            9194 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            9195 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            9196 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            9197 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            9198 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            9199 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            9200 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            9201 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            9202 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            9203 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            9204 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            9205 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            9206 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            9207 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            9208 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            9209 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            9210 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            9211 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            9212 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            9213 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            9214 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            9215 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            9216 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            9217 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            9218 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            9219 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            9220 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            9221 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            9222 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            9223 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            9224 => new ResinBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            9225 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            9226 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            9227 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            9228 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            9229 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            9230 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            9231 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            9232 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            9233 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            9234 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            9235 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            9236 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            9237 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            9238 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            9239 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            9240 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            9241 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            9242 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            9243 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            9244 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            9245 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            9246 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            9247 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            9248 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            9249 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            9250 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            9251 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            9252 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            9253 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            9254 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            9255 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            9256 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            9257 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            9258 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            9259 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            9260 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            9261 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            9262 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            9263 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            9264 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            9265 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            9266 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            9267 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            9268 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            9269 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            9270 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            9271 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            9272 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            9273 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            9274 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            9275 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            9276 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            9277 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            9278 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            9279 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            9280 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            9281 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            9282 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            9283 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            9284 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            9285 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            9286 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            9287 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            9288 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            9289 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            9290 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            9291 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            9292 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            9293 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            9294 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            9295 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            9296 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            9297 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            9298 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            9299 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            9300 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            9301 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            9302 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            9303 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            9304 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            9305 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            9306 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            9307 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            9308 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            9309 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            9310 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            9311 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            9312 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            9313 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            9314 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            9315 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            9316 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            9317 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            9318 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            9319 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            9320 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            9321 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            9322 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            9323 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            9324 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            9325 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            9326 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            9327 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            9328 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            9329 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            9330 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            9331 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            9332 => new ResinBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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

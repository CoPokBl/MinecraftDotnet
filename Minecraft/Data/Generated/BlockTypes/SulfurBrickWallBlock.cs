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
public record SulfurBrickWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock, IWaterlogged, IFaceConnected, IWallConnected {
    private static readonly BlockInfo Data = new("block.minecraft.sulfur_brick_wall", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:sulfur_brick_wall", BlockInfo.VanillaOnly, "minecraft:blocks/sulfur_brick_wall");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 18, "sulfur", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S87, BlockShapes.S132, BlockShapes.S1, BlockShapes.S87, BlockShapes.S132, BlockShapes.S132);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S133, CollisionShape = BlockShapes.S134, OcclusionShape = BlockShapes.S133, VisualShape = BlockShapes.S134, SupportShape = BlockShapes.S134 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S135, CollisionShape = BlockShapes.S134, OcclusionShape = BlockShapes.S135, VisualShape = BlockShapes.S134, SupportShape = BlockShapes.S134 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I4 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S133, CollisionShape = BlockShapes.S134, OcclusionShape = BlockShapes.S133, VisualShape = BlockShapes.S134, SupportShape = BlockShapes.S134 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S135, CollisionShape = BlockShapes.S134, OcclusionShape = BlockShapes.S135, VisualShape = BlockShapes.S134, SupportShape = BlockShapes.S134 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S1, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S136, CollisionShape = BlockShapes.S137, OcclusionShape = BlockShapes.S136, VisualShape = BlockShapes.S137, SupportShape = BlockShapes.S137 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S138, CollisionShape = BlockShapes.S137, OcclusionShape = BlockShapes.S138, VisualShape = BlockShapes.S137, SupportShape = BlockShapes.S137 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S1, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I10 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S136, CollisionShape = BlockShapes.S137, OcclusionShape = BlockShapes.S136, VisualShape = BlockShapes.S137, SupportShape = BlockShapes.S137 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S138, CollisionShape = BlockShapes.S137, OcclusionShape = BlockShapes.S138, VisualShape = BlockShapes.S137, SupportShape = BlockShapes.S137 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S139, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S139, VisualShape = BlockShapes.S140, SupportShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S141, CollisionShape = BlockShapes.S142, OcclusionShape = BlockShapes.S141, VisualShape = BlockShapes.S142, SupportShape = BlockShapes.S142 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S143, CollisionShape = BlockShapes.S142, OcclusionShape = BlockShapes.S143, VisualShape = BlockShapes.S142, SupportShape = BlockShapes.S142 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S139, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S139, VisualShape = BlockShapes.S140, SupportShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I16 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S141, CollisionShape = BlockShapes.S142, OcclusionShape = BlockShapes.S141, VisualShape = BlockShapes.S142, SupportShape = BlockShapes.S142 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S143, CollisionShape = BlockShapes.S142, OcclusionShape = BlockShapes.S143, VisualShape = BlockShapes.S142, SupportShape = BlockShapes.S142 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S144, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S144, VisualShape = BlockShapes.S145, SupportShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I19 = I0 with { BlockShape = BlockShapes.S146, CollisionShape = BlockShapes.S147, OcclusionShape = BlockShapes.S146, VisualShape = BlockShapes.S147, SupportShape = BlockShapes.S147 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S148, CollisionShape = BlockShapes.S147, OcclusionShape = BlockShapes.S148, VisualShape = BlockShapes.S147, SupportShape = BlockShapes.S147 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S144, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S144, VisualShape = BlockShapes.S145, SupportShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I22 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S146, CollisionShape = BlockShapes.S147, OcclusionShape = BlockShapes.S146, VisualShape = BlockShapes.S147, SupportShape = BlockShapes.S147 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S148, CollisionShape = BlockShapes.S147, OcclusionShape = BlockShapes.S148, VisualShape = BlockShapes.S147, SupportShape = BlockShapes.S147 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S149, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S149, VisualShape = BlockShapes.S140, SupportShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S150, CollisionShape = BlockShapes.S142, OcclusionShape = BlockShapes.S150, VisualShape = BlockShapes.S142, SupportShape = BlockShapes.S142 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S151, CollisionShape = BlockShapes.S142, OcclusionShape = BlockShapes.S151, VisualShape = BlockShapes.S142, SupportShape = BlockShapes.S142 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S149, CollisionShape = BlockShapes.S140, OcclusionShape = BlockShapes.S149, VisualShape = BlockShapes.S140, SupportShape = BlockShapes.S140 };
    private static readonly BlockStateInfo I28 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S150, CollisionShape = BlockShapes.S142, OcclusionShape = BlockShapes.S150, VisualShape = BlockShapes.S142, SupportShape = BlockShapes.S142 };
    private static readonly BlockStateInfo I29 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S151, CollisionShape = BlockShapes.S142, OcclusionShape = BlockShapes.S151, VisualShape = BlockShapes.S142, SupportShape = BlockShapes.S142 };
    private static readonly BlockStateInfo I30 = I0 with { BlockShape = BlockShapes.S152, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S152, VisualShape = BlockShapes.S145, SupportShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I31 = I0 with { BlockShape = BlockShapes.S153, CollisionShape = BlockShapes.S147, OcclusionShape = BlockShapes.S153, VisualShape = BlockShapes.S147, SupportShape = BlockShapes.S147 };
    private static readonly BlockStateInfo I32 = I0 with { BlockShape = BlockShapes.S154, CollisionShape = BlockShapes.S147, OcclusionShape = BlockShapes.S154, VisualShape = BlockShapes.S147, SupportShape = BlockShapes.S147 };
    private static readonly BlockStateInfo I33 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S152, CollisionShape = BlockShapes.S145, OcclusionShape = BlockShapes.S152, VisualShape = BlockShapes.S145, SupportShape = BlockShapes.S145 };
    private static readonly BlockStateInfo I34 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S153, CollisionShape = BlockShapes.S147, OcclusionShape = BlockShapes.S153, VisualShape = BlockShapes.S147, SupportShape = BlockShapes.S147 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S154, CollisionShape = BlockShapes.S147, OcclusionShape = BlockShapes.S154, VisualShape = BlockShapes.S147, SupportShape = BlockShapes.S147 };
    private static readonly BlockStateInfo I36 = I0 with { BlockShape = BlockShapes.S155, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S155, VisualShape = BlockShapes.S156, SupportShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I37 = I0 with { BlockShape = BlockShapes.S157, CollisionShape = BlockShapes.S158, OcclusionShape = BlockShapes.S157, VisualShape = BlockShapes.S158, SupportShape = BlockShapes.S158 };
    private static readonly BlockStateInfo I38 = I0 with { BlockShape = BlockShapes.S159, CollisionShape = BlockShapes.S158, OcclusionShape = BlockShapes.S159, VisualShape = BlockShapes.S158, SupportShape = BlockShapes.S158 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S155, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S155, VisualShape = BlockShapes.S156, SupportShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I40 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S157, CollisionShape = BlockShapes.S158, OcclusionShape = BlockShapes.S157, VisualShape = BlockShapes.S158, SupportShape = BlockShapes.S158 };
    private static readonly BlockStateInfo I41 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S159, CollisionShape = BlockShapes.S158, OcclusionShape = BlockShapes.S159, VisualShape = BlockShapes.S158, SupportShape = BlockShapes.S158 };
    private static readonly BlockStateInfo I42 = I0 with { BlockShape = BlockShapes.S160, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S160, VisualShape = BlockShapes.S161, SupportShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I43 = I0 with { BlockShape = BlockShapes.S162, CollisionShape = BlockShapes.S163, OcclusionShape = BlockShapes.S162, VisualShape = BlockShapes.S163, SupportShape = BlockShapes.S163 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S164, CollisionShape = BlockShapes.S163, OcclusionShape = BlockShapes.S164, VisualShape = BlockShapes.S163, SupportShape = BlockShapes.S163 };
    private static readonly BlockStateInfo I45 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S160, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S160, VisualShape = BlockShapes.S161, SupportShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I46 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S162, CollisionShape = BlockShapes.S163, OcclusionShape = BlockShapes.S162, VisualShape = BlockShapes.S163, SupportShape = BlockShapes.S163 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S164, CollisionShape = BlockShapes.S163, OcclusionShape = BlockShapes.S164, VisualShape = BlockShapes.S163, SupportShape = BlockShapes.S163 };
    private static readonly BlockStateInfo I48 = I0 with { BlockShape = BlockShapes.S165, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S165, VisualShape = BlockShapes.S166, SupportShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I49 = I0 with { BlockShape = BlockShapes.S167, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S167, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I50 = I0 with { BlockShape = BlockShapes.S169, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S169, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I51 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S165, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S165, VisualShape = BlockShapes.S166, SupportShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I52 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S167, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S167, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I53 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S169, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S169, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I54 = I0 with { BlockShape = BlockShapes.S170, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S170, VisualShape = BlockShapes.S171, SupportShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I55 = I0 with { BlockShape = BlockShapes.S172, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S172, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I56 = I0 with { BlockShape = BlockShapes.S174, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S174, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I57 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S170, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S170, VisualShape = BlockShapes.S171, SupportShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I58 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S172, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S172, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I59 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S174, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S174, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I60 = I0 with { BlockShape = BlockShapes.S175, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S175, VisualShape = BlockShapes.S166, SupportShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I61 = I0 with { BlockShape = BlockShapes.S176, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S176, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I62 = I0 with { BlockShape = BlockShapes.S177, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S177, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I63 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S175, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S175, VisualShape = BlockShapes.S166, SupportShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I64 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S176, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S176, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I65 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S177, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S177, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I66 = I0 with { BlockShape = BlockShapes.S178, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S178, VisualShape = BlockShapes.S171, SupportShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I67 = I0 with { BlockShape = BlockShapes.S179, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S179, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I68 = I0 with { BlockShape = BlockShapes.S180, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S180, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I69 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S178, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S178, VisualShape = BlockShapes.S171, SupportShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I70 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S179, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S179, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I71 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S180, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S180, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I72 = I0 with { BlockShape = BlockShapes.S181, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S181, VisualShape = BlockShapes.S156, SupportShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I73 = I0 with { BlockShape = BlockShapes.S182, CollisionShape = BlockShapes.S158, OcclusionShape = BlockShapes.S182, VisualShape = BlockShapes.S158, SupportShape = BlockShapes.S158 };
    private static readonly BlockStateInfo I74 = I0 with { BlockShape = BlockShapes.S183, CollisionShape = BlockShapes.S158, OcclusionShape = BlockShapes.S183, VisualShape = BlockShapes.S158, SupportShape = BlockShapes.S158 };
    private static readonly BlockStateInfo I75 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S181, CollisionShape = BlockShapes.S156, OcclusionShape = BlockShapes.S181, VisualShape = BlockShapes.S156, SupportShape = BlockShapes.S156 };
    private static readonly BlockStateInfo I76 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S182, CollisionShape = BlockShapes.S158, OcclusionShape = BlockShapes.S182, VisualShape = BlockShapes.S158, SupportShape = BlockShapes.S158 };
    private static readonly BlockStateInfo I77 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S183, CollisionShape = BlockShapes.S158, OcclusionShape = BlockShapes.S183, VisualShape = BlockShapes.S158, SupportShape = BlockShapes.S158 };
    private static readonly BlockStateInfo I78 = I0 with { BlockShape = BlockShapes.S184, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S184, VisualShape = BlockShapes.S161, SupportShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I79 = I0 with { BlockShape = BlockShapes.S185, CollisionShape = BlockShapes.S163, OcclusionShape = BlockShapes.S185, VisualShape = BlockShapes.S163, SupportShape = BlockShapes.S163 };
    private static readonly BlockStateInfo I80 = I0 with { BlockShape = BlockShapes.S186, CollisionShape = BlockShapes.S163, OcclusionShape = BlockShapes.S186, VisualShape = BlockShapes.S163, SupportShape = BlockShapes.S163 };
    private static readonly BlockStateInfo I81 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S184, CollisionShape = BlockShapes.S161, OcclusionShape = BlockShapes.S184, VisualShape = BlockShapes.S161, SupportShape = BlockShapes.S161 };
    private static readonly BlockStateInfo I82 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S185, CollisionShape = BlockShapes.S163, OcclusionShape = BlockShapes.S185, VisualShape = BlockShapes.S163, SupportShape = BlockShapes.S163 };
    private static readonly BlockStateInfo I83 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S186, CollisionShape = BlockShapes.S163, OcclusionShape = BlockShapes.S186, VisualShape = BlockShapes.S163, SupportShape = BlockShapes.S163 };
    private static readonly BlockStateInfo I84 = I0 with { BlockShape = BlockShapes.S187, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S187, VisualShape = BlockShapes.S166, SupportShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I85 = I0 with { BlockShape = BlockShapes.S188, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S188, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I86 = I0 with { BlockShape = BlockShapes.S189, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S189, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I87 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S187, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S187, VisualShape = BlockShapes.S166, SupportShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I88 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S188, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S188, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I89 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S189, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S189, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I90 = I0 with { BlockShape = BlockShapes.S190, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S190, VisualShape = BlockShapes.S171, SupportShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I91 = I0 with { BlockShape = BlockShapes.S191, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S191, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I92 = I0 with { BlockShape = BlockShapes.S192, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S192, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I93 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S190, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S190, VisualShape = BlockShapes.S171, SupportShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I94 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S191, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S191, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I95 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S192, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S192, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I96 = I0 with { BlockShape = BlockShapes.S193, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S193, VisualShape = BlockShapes.S166, SupportShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I97 = I0 with { BlockShape = BlockShapes.S194, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S194, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I98 = I0 with { BlockShape = BlockShapes.S195, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S195, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I99 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S193, CollisionShape = BlockShapes.S166, OcclusionShape = BlockShapes.S193, VisualShape = BlockShapes.S166, SupportShape = BlockShapes.S166 };
    private static readonly BlockStateInfo I100 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S194, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S194, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I101 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S195, CollisionShape = BlockShapes.S168, OcclusionShape = BlockShapes.S195, VisualShape = BlockShapes.S168, SupportShape = BlockShapes.S168 };
    private static readonly BlockStateInfo I102 = I0 with { BlockShape = BlockShapes.S196, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S196, VisualShape = BlockShapes.S171, SupportShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I103 = I0 with { BlockShape = BlockShapes.S197, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S197, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I104 = I0 with { BlockShape = BlockShapes.S198, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S198, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I105 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S196, CollisionShape = BlockShapes.S171, OcclusionShape = BlockShapes.S196, VisualShape = BlockShapes.S171, SupportShape = BlockShapes.S171 };
    private static readonly BlockStateInfo I106 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S197, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S197, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I107 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S198, CollisionShape = BlockShapes.S173, OcclusionShape = BlockShapes.S198, VisualShape = BlockShapes.S173, SupportShape = BlockShapes.S173 };
    private static readonly BlockStateInfo I108 = I0 with { BlockShape = BlockShapes.S199, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S199, VisualShape = BlockShapes.S200, SupportShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I109 = I0 with { BlockShape = BlockShapes.S201, CollisionShape = BlockShapes.S202, OcclusionShape = BlockShapes.S201, VisualShape = BlockShapes.S202, SupportShape = BlockShapes.S202 };
    private static readonly BlockStateInfo I110 = I0 with { BlockShape = BlockShapes.S203, CollisionShape = BlockShapes.S202, OcclusionShape = BlockShapes.S203, VisualShape = BlockShapes.S202, SupportShape = BlockShapes.S202 };
    private static readonly BlockStateInfo I111 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S199, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S199, VisualShape = BlockShapes.S200, SupportShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I112 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S201, CollisionShape = BlockShapes.S202, OcclusionShape = BlockShapes.S201, VisualShape = BlockShapes.S202, SupportShape = BlockShapes.S202 };
    private static readonly BlockStateInfo I113 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S203, CollisionShape = BlockShapes.S202, OcclusionShape = BlockShapes.S203, VisualShape = BlockShapes.S202, SupportShape = BlockShapes.S202 };
    private static readonly BlockStateInfo I114 = I0 with { BlockShape = BlockShapes.S204, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S204, VisualShape = BlockShapes.S205, SupportShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I115 = I0 with { BlockShape = BlockShapes.S206, CollisionShape = BlockShapes.S207, OcclusionShape = BlockShapes.S206, VisualShape = BlockShapes.S207, SupportShape = BlockShapes.S207 };
    private static readonly BlockStateInfo I116 = I0 with { BlockShape = BlockShapes.S208, CollisionShape = BlockShapes.S207, OcclusionShape = BlockShapes.S208, VisualShape = BlockShapes.S207, SupportShape = BlockShapes.S207 };
    private static readonly BlockStateInfo I117 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S204, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S204, VisualShape = BlockShapes.S205, SupportShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I118 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S206, CollisionShape = BlockShapes.S207, OcclusionShape = BlockShapes.S206, VisualShape = BlockShapes.S207, SupportShape = BlockShapes.S207 };
    private static readonly BlockStateInfo I119 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S208, CollisionShape = BlockShapes.S207, OcclusionShape = BlockShapes.S208, VisualShape = BlockShapes.S207, SupportShape = BlockShapes.S207 };
    private static readonly BlockStateInfo I120 = I0 with { BlockShape = BlockShapes.S209, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S209, VisualShape = BlockShapes.S210, SupportShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I121 = I0 with { BlockShape = BlockShapes.S211, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S211, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I122 = I0 with { BlockShape = BlockShapes.S213, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S213, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I123 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S209, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S209, VisualShape = BlockShapes.S210, SupportShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I124 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S211, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S211, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I125 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S213, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S213, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I126 = I0 with { BlockShape = BlockShapes.S214, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S214, VisualShape = BlockShapes.S215, SupportShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I127 = I0 with { BlockShape = BlockShapes.S216, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S216, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I128 = I0 with { BlockShape = BlockShapes.S218, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S218, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I129 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S214, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S214, VisualShape = BlockShapes.S215, SupportShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I130 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S216, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S216, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I131 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S218, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S218, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I132 = I0 with { BlockShape = BlockShapes.S219, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S219, VisualShape = BlockShapes.S210, SupportShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I133 = I0 with { BlockShape = BlockShapes.S220, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S220, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I134 = I0 with { BlockShape = BlockShapes.S221, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S221, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I135 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S219, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S219, VisualShape = BlockShapes.S210, SupportShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I136 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S220, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S220, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I137 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S221, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S221, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I138 = I0 with { BlockShape = BlockShapes.S222, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S222, VisualShape = BlockShapes.S215, SupportShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I139 = I0 with { BlockShape = BlockShapes.S223, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S223, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I140 = I0 with { BlockShape = BlockShapes.S224, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S224, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I141 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S222, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S222, VisualShape = BlockShapes.S215, SupportShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I142 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S223, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S223, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I143 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S224, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S224, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I144 = I0 with { BlockShape = BlockShapes.S225, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S225, VisualShape = BlockShapes.S226, SupportShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I145 = I0 with { BlockShape = BlockShapes.S227, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S227, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I146 = I0 with { BlockShape = BlockShapes.S229, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S229, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I147 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S225, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S225, VisualShape = BlockShapes.S226, SupportShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I148 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S227, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S227, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I149 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S229, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S229, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I150 = I0 with { BlockShape = BlockShapes.S230, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S230, VisualShape = BlockShapes.S231, SupportShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I151 = I0 with { BlockShape = BlockShapes.S232, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S232, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I152 = I0 with { BlockShape = BlockShapes.S234, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S234, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I153 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S230, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S230, VisualShape = BlockShapes.S231, SupportShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I154 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S232, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S232, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I155 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S234, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S234, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I156 = I0 with { BlockShape = BlockShapes.S235, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S235, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I157 = I0 with { BlockShape = BlockShapes.S237, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S237, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I158 = I0 with { BlockShape = BlockShapes.S239, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S239, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I159 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S235, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S235, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I160 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S237, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S237, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I161 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S239, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S239, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I162 = I0 with { BlockShape = BlockShapes.S240, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S240, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I163 = I0 with { BlockShape = BlockShapes.S242, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S242, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I164 = I0 with { BlockShape = BlockShapes.S244, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S244, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I165 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S240, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S240, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I166 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S242, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S242, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I167 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S244, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S244, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I168 = I0 with { BlockShape = BlockShapes.S245, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S245, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I169 = I0 with { BlockShape = BlockShapes.S246, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S246, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I170 = I0 with { BlockShape = BlockShapes.S247, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S247, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I171 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S245, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S245, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I172 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S246, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S246, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I173 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S247, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S247, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I174 = I0 with { BlockShape = BlockShapes.S248, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S248, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I175 = I0 with { BlockShape = BlockShapes.S249, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S249, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I176 = I0 with { BlockShape = BlockShapes.S250, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S250, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I177 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S248, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S248, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I178 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S249, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S249, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I179 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S250, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S250, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I180 = I0 with { BlockShape = BlockShapes.S251, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S251, VisualShape = BlockShapes.S226, SupportShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I181 = I0 with { BlockShape = BlockShapes.S252, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S252, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I182 = I0 with { BlockShape = BlockShapes.S253, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S253, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I183 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S251, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S251, VisualShape = BlockShapes.S226, SupportShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I184 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S252, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S252, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I185 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S253, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S253, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I186 = I0 with { BlockShape = BlockShapes.S254, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S254, VisualShape = BlockShapes.S231, SupportShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I187 = I0 with { BlockShape = BlockShapes.S255, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S255, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I188 = I0 with { BlockShape = BlockShapes.S256, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S256, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I189 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S254, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S254, VisualShape = BlockShapes.S231, SupportShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I190 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S255, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S255, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I191 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S256, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S256, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I192 = I0 with { BlockShape = BlockShapes.S257, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S257, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I193 = I0 with { BlockShape = BlockShapes.S258, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S258, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I194 = I0 with { BlockShape = BlockShapes.S259, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S259, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I195 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S257, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S257, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I196 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S258, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S258, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I197 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S259, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S259, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I198 = I0 with { BlockShape = BlockShapes.S260, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S260, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I199 = I0 with { BlockShape = BlockShapes.S261, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S261, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I200 = I0 with { BlockShape = BlockShapes.S262, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S262, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I201 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S260, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S260, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I202 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S261, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S261, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I203 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S262, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S262, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I204 = I0 with { BlockShape = BlockShapes.S263, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S263, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I205 = I0 with { BlockShape = BlockShapes.S264, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S264, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I206 = I0 with { BlockShape = BlockShapes.S265, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S265, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I207 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S263, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S263, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I208 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S264, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S264, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I209 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S265, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S265, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I210 = I0 with { BlockShape = BlockShapes.S266, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S266, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I211 = I0 with { BlockShape = BlockShapes.S267, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S267, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I212 = I0 with { BlockShape = BlockShapes.S268, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S268, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I213 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S266, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S266, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I214 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S267, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S267, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I215 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S268, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S268, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I216 = I0 with { BlockShape = BlockShapes.S269, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S269, VisualShape = BlockShapes.S200, SupportShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I217 = I0 with { BlockShape = BlockShapes.S270, CollisionShape = BlockShapes.S202, OcclusionShape = BlockShapes.S270, VisualShape = BlockShapes.S202, SupportShape = BlockShapes.S202 };
    private static readonly BlockStateInfo I218 = I0 with { BlockShape = BlockShapes.S271, CollisionShape = BlockShapes.S202, OcclusionShape = BlockShapes.S271, VisualShape = BlockShapes.S202, SupportShape = BlockShapes.S202 };
    private static readonly BlockStateInfo I219 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S269, CollisionShape = BlockShapes.S200, OcclusionShape = BlockShapes.S269, VisualShape = BlockShapes.S200, SupportShape = BlockShapes.S200 };
    private static readonly BlockStateInfo I220 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S270, CollisionShape = BlockShapes.S202, OcclusionShape = BlockShapes.S270, VisualShape = BlockShapes.S202, SupportShape = BlockShapes.S202 };
    private static readonly BlockStateInfo I221 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S271, CollisionShape = BlockShapes.S202, OcclusionShape = BlockShapes.S271, VisualShape = BlockShapes.S202, SupportShape = BlockShapes.S202 };
    private static readonly BlockStateInfo I222 = I0 with { BlockShape = BlockShapes.S272, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S272, VisualShape = BlockShapes.S205, SupportShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I223 = I0 with { BlockShape = BlockShapes.S273, CollisionShape = BlockShapes.S207, OcclusionShape = BlockShapes.S273, VisualShape = BlockShapes.S207, SupportShape = BlockShapes.S207 };
    private static readonly BlockStateInfo I224 = I0 with { BlockShape = BlockShapes.S274, CollisionShape = BlockShapes.S207, OcclusionShape = BlockShapes.S274, VisualShape = BlockShapes.S207, SupportShape = BlockShapes.S207 };
    private static readonly BlockStateInfo I225 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S272, CollisionShape = BlockShapes.S205, OcclusionShape = BlockShapes.S272, VisualShape = BlockShapes.S205, SupportShape = BlockShapes.S205 };
    private static readonly BlockStateInfo I226 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S273, CollisionShape = BlockShapes.S207, OcclusionShape = BlockShapes.S273, VisualShape = BlockShapes.S207, SupportShape = BlockShapes.S207 };
    private static readonly BlockStateInfo I227 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S274, CollisionShape = BlockShapes.S207, OcclusionShape = BlockShapes.S274, VisualShape = BlockShapes.S207, SupportShape = BlockShapes.S207 };
    private static readonly BlockStateInfo I228 = I0 with { BlockShape = BlockShapes.S275, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S275, VisualShape = BlockShapes.S210, SupportShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I229 = I0 with { BlockShape = BlockShapes.S276, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S276, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I230 = I0 with { BlockShape = BlockShapes.S277, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S277, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I231 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S275, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S275, VisualShape = BlockShapes.S210, SupportShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I232 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S276, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S276, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I233 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S277, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S277, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I234 = I0 with { BlockShape = BlockShapes.S278, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S278, VisualShape = BlockShapes.S215, SupportShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I235 = I0 with { BlockShape = BlockShapes.S279, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S279, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I236 = I0 with { BlockShape = BlockShapes.S280, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S280, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I237 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S278, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S278, VisualShape = BlockShapes.S215, SupportShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I238 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S279, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S279, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I239 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S280, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S280, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I240 = I0 with { BlockShape = BlockShapes.S281, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S281, VisualShape = BlockShapes.S210, SupportShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I241 = I0 with { BlockShape = BlockShapes.S282, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S282, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I242 = I0 with { BlockShape = BlockShapes.S283, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S283, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I243 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S281, CollisionShape = BlockShapes.S210, OcclusionShape = BlockShapes.S281, VisualShape = BlockShapes.S210, SupportShape = BlockShapes.S210 };
    private static readonly BlockStateInfo I244 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S282, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S282, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I245 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S283, CollisionShape = BlockShapes.S212, OcclusionShape = BlockShapes.S283, VisualShape = BlockShapes.S212, SupportShape = BlockShapes.S212 };
    private static readonly BlockStateInfo I246 = I0 with { BlockShape = BlockShapes.S284, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S284, VisualShape = BlockShapes.S215, SupportShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I247 = I0 with { BlockShape = BlockShapes.S285, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S285, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I248 = I0 with { BlockShape = BlockShapes.S286, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S286, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I249 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S284, CollisionShape = BlockShapes.S215, OcclusionShape = BlockShapes.S284, VisualShape = BlockShapes.S215, SupportShape = BlockShapes.S215 };
    private static readonly BlockStateInfo I250 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S285, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S285, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I251 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S286, CollisionShape = BlockShapes.S217, OcclusionShape = BlockShapes.S286, VisualShape = BlockShapes.S217, SupportShape = BlockShapes.S217 };
    private static readonly BlockStateInfo I252 = I0 with { BlockShape = BlockShapes.S287, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S287, VisualShape = BlockShapes.S226, SupportShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I253 = I0 with { BlockShape = BlockShapes.S288, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S288, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I254 = I0 with { BlockShape = BlockShapes.S289, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S289, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I255 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S287, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S287, VisualShape = BlockShapes.S226, SupportShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I256 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S288, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S288, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I257 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S289, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S289, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I258 = I0 with { BlockShape = BlockShapes.S290, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S290, VisualShape = BlockShapes.S231, SupportShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I259 = I0 with { BlockShape = BlockShapes.S291, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S291, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I260 = I0 with { BlockShape = BlockShapes.S292, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S292, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I261 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S290, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S290, VisualShape = BlockShapes.S231, SupportShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I262 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S291, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S291, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I263 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S292, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S292, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I264 = I0 with { BlockShape = BlockShapes.S293, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S293, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I265 = I0 with { BlockShape = BlockShapes.S294, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S294, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I266 = I0 with { BlockShape = BlockShapes.S295, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S295, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I267 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S293, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S293, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I268 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S294, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S294, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I269 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S295, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S295, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I270 = I0 with { BlockShape = BlockShapes.S296, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S296, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I271 = I0 with { BlockShape = BlockShapes.S297, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S297, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I272 = I0 with { BlockShape = BlockShapes.S298, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S298, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I273 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S296, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S296, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I274 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S297, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S297, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I275 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S298, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S298, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I276 = I0 with { BlockShape = BlockShapes.S299, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S299, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I277 = I0 with { BlockShape = BlockShapes.S300, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S300, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I278 = I0 with { BlockShape = BlockShapes.S301, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S301, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I279 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S299, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S299, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I280 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S300, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S300, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I281 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S301, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S301, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I282 = I0 with { BlockShape = BlockShapes.S302, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S302, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I283 = I0 with { BlockShape = BlockShapes.S303, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S303, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I284 = I0 with { BlockShape = BlockShapes.S304, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S304, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I285 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S302, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S302, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I286 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S303, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S303, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I287 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S304, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S304, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I288 = I0 with { BlockShape = BlockShapes.S305, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S305, VisualShape = BlockShapes.S226, SupportShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I289 = I0 with { BlockShape = BlockShapes.S306, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S306, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I290 = I0 with { BlockShape = BlockShapes.S307, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S307, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I291 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S305, CollisionShape = BlockShapes.S226, OcclusionShape = BlockShapes.S305, VisualShape = BlockShapes.S226, SupportShape = BlockShapes.S226 };
    private static readonly BlockStateInfo I292 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S306, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S306, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I293 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S307, CollisionShape = BlockShapes.S228, OcclusionShape = BlockShapes.S307, VisualShape = BlockShapes.S228, SupportShape = BlockShapes.S228 };
    private static readonly BlockStateInfo I294 = I0 with { BlockShape = BlockShapes.S308, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S308, VisualShape = BlockShapes.S231, SupportShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I295 = I0 with { BlockShape = BlockShapes.S309, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S309, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I296 = I0 with { BlockShape = BlockShapes.S310, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S310, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I297 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S308, CollisionShape = BlockShapes.S231, OcclusionShape = BlockShapes.S308, VisualShape = BlockShapes.S231, SupportShape = BlockShapes.S231 };
    private static readonly BlockStateInfo I298 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S309, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S309, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I299 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S310, CollisionShape = BlockShapes.S233, OcclusionShape = BlockShapes.S310, VisualShape = BlockShapes.S233, SupportShape = BlockShapes.S233 };
    private static readonly BlockStateInfo I300 = I0 with { BlockShape = BlockShapes.S311, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S311, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I301 = I0 with { BlockShape = BlockShapes.S312, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S312, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I302 = I0 with { BlockShape = BlockShapes.S313, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S313, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I303 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S311, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S311, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I304 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S312, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S312, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I305 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S313, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S313, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I306 = I0 with { BlockShape = BlockShapes.S314, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S314, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I307 = I0 with { BlockShape = BlockShapes.S315, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S315, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I308 = I0 with { BlockShape = BlockShapes.S316, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S316, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I309 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S314, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S314, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I310 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S315, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S315, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I311 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S316, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S316, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I312 = I0 with { BlockShape = BlockShapes.S317, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S317, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I313 = I0 with { BlockShape = BlockShapes.S318, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S318, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I314 = I0 with { BlockShape = BlockShapes.S319, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S319, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I315 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S317, CollisionShape = BlockShapes.S236, OcclusionShape = BlockShapes.S317, VisualShape = BlockShapes.S236, SupportShape = BlockShapes.S236 };
    private static readonly BlockStateInfo I316 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S318, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S318, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I317 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S319, CollisionShape = BlockShapes.S238, OcclusionShape = BlockShapes.S319, VisualShape = BlockShapes.S238, SupportShape = BlockShapes.S238 };
    private static readonly BlockStateInfo I318 = I0 with { BlockShape = BlockShapes.S320, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S320, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I319 = I0 with { BlockShape = BlockShapes.S321, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S321, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I320 = I0 with { BlockShape = BlockShapes.S322, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S322, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I321 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S320, CollisionShape = BlockShapes.S241, OcclusionShape = BlockShapes.S320, VisualShape = BlockShapes.S241, SupportShape = BlockShapes.S241 };
    private static readonly BlockStateInfo I322 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S321, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S321, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo I323 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S322, CollisionShape = BlockShapes.S243, OcclusionShape = BlockShapes.S322, VisualShape = BlockShapes.S243, SupportShape = BlockShapes.S243 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I42, I43, I44, I45, I46, I47, I48, I49, I50, I51, I52, I53, I54, I55, I56, I57, I58, I59, I60, I61, I62, I63, I64, I65, I66, I67, I68, I69, I70, I71, I72, I73, I74, I75, I76, I77, I78, I79, I80, I81, I82, I83, I84, I85, I86, I87, I88, I89, I90, I91, I92, I93, I94, I95, I96, I97, I98, I99, I100, I101, I102, I103, I104, I105, I106, I107, I108, I109, I110, I111, I112, I113, I114, I115, I116, I117, I118, I119, I120, I121, I122, I123, I124, I125, I126, I127, I128, I129, I130, I131, I132, I133, I134, I135, I136, I137, I138, I139, I140, I141, I142, I143, I144, I145, I146, I147, I148, I149, I150, I151, I152, I153, I154, I155, I156, I157, I158, I159, I160, I161, I162, I163, I164, I165, I166, I167, I168, I169, I170, I171, I172, I173, I174, I175, I176, I177, I178, I179, I180, I181, I182, I183, I184, I185, I186, I187, I188, I189, I190, I191, I192, I193, I194, I195, I196, I197, I198, I199, I200, I201, I202, I203, I204, I205, I206, I207, I208, I209, I210, I211, I212, I213, I214, I215, I216, I217, I218, I219, I220, I221, I222, I223, I224, I225, I226, I227, I228, I229, I230, I231, I232, I233, I234, I235, I236, I237, I238, I239, I240, I241, I242, I243, I244, I245, I246, I247, I248, I249, I250, I251, I252, I253, I254, I255, I256, I257, I258, I259, I260, I261, I262, I263, I264, I265, I266, I267, I268, I269, I270, I271, I272, I273, I274, I275, I276, I277, I278, I279, I280, I281, I282, I283, I284, I285, I286, I287, I288, I289, I290, I291, I292, I293, I294, I295, I296, I297, I298, I299, I300, I301, I302, I303, I304, I305, I306, I307, I308, I309, I310, I311, I312, I313, I314, I315, I316, I317, I318, I319, I320, I321, I322, I323
    ];

    public BlockStateInfo StateInfo => States[StateId - 28958];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };

    public bool HasFace(BlockFace face) => face is BlockFace.PosY;

    public bool Connected(BlockFace face) => face switch {
        BlockFace.PosY => Up,
        _ => false
    };

    public IBlock WithConnection(BlockFace face, bool connected) => face switch {
        BlockFace.PosY => this with { Up = connected },
        _ => this
    };

    public WallSide Side(BlockFace face) => face switch {
        BlockFace.NegZ => North,
        BlockFace.PosZ => South,
        BlockFace.NegX => West,
        BlockFace.PosX => East,
        _ => WallSide.None
    };

    public IBlock WithSide(BlockFace face, WallSide side) => face switch {
        BlockFace.NegZ => this with { North = side },
        BlockFace.PosZ => this with { South = side },
        BlockFace.NegX => this with { West = side },
        BlockFace.PosX => this with { East = side },
        _ => this
    };


    public uint StateId {
        get {
            return East switch {
                WallSide.None => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 28958,
                                    WallSide.Low => 28959,
                                    WallSide.Tall => 28960,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 28961,
                                    WallSide.Low => 28962,
                                    WallSide.Tall => 28963,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 28964,
                                    WallSide.Low => 28965,
                                    WallSide.Tall => 28966,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 28967,
                                    WallSide.Low => 28968,
                                    WallSide.Tall => 28969,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 28970,
                                    WallSide.Low => 28971,
                                    WallSide.Tall => 28972,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 28973,
                                    WallSide.Low => 28974,
                                    WallSide.Tall => 28975,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 28976,
                                    WallSide.Low => 28977,
                                    WallSide.Tall => 28978,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 28979,
                                    WallSide.Low => 28980,
                                    WallSide.Tall => 28981,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 28982,
                                    WallSide.Low => 28983,
                                    WallSide.Tall => 28984,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 28985,
                                    WallSide.Low => 28986,
                                    WallSide.Tall => 28987,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 28988,
                                    WallSide.Low => 28989,
                                    WallSide.Tall => 28990,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 28991,
                                    WallSide.Low => 28992,
                                    WallSide.Tall => 28993,
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
                                    WallSide.None => 28994,
                                    WallSide.Low => 28995,
                                    WallSide.Tall => 28996,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 28997,
                                    WallSide.Low => 28998,
                                    WallSide.Tall => 28999,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29000,
                                    WallSide.Low => 29001,
                                    WallSide.Tall => 29002,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29003,
                                    WallSide.Low => 29004,
                                    WallSide.Tall => 29005,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29006,
                                    WallSide.Low => 29007,
                                    WallSide.Tall => 29008,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29009,
                                    WallSide.Low => 29010,
                                    WallSide.Tall => 29011,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29012,
                                    WallSide.Low => 29013,
                                    WallSide.Tall => 29014,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29015,
                                    WallSide.Low => 29016,
                                    WallSide.Tall => 29017,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29018,
                                    WallSide.Low => 29019,
                                    WallSide.Tall => 29020,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29021,
                                    WallSide.Low => 29022,
                                    WallSide.Tall => 29023,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29024,
                                    WallSide.Low => 29025,
                                    WallSide.Tall => 29026,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29027,
                                    WallSide.Low => 29028,
                                    WallSide.Tall => 29029,
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
                                    WallSide.None => 29030,
                                    WallSide.Low => 29031,
                                    WallSide.Tall => 29032,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29033,
                                    WallSide.Low => 29034,
                                    WallSide.Tall => 29035,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29036,
                                    WallSide.Low => 29037,
                                    WallSide.Tall => 29038,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29039,
                                    WallSide.Low => 29040,
                                    WallSide.Tall => 29041,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29042,
                                    WallSide.Low => 29043,
                                    WallSide.Tall => 29044,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29045,
                                    WallSide.Low => 29046,
                                    WallSide.Tall => 29047,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29048,
                                    WallSide.Low => 29049,
                                    WallSide.Tall => 29050,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29051,
                                    WallSide.Low => 29052,
                                    WallSide.Tall => 29053,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29054,
                                    WallSide.Low => 29055,
                                    WallSide.Tall => 29056,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29057,
                                    WallSide.Low => 29058,
                                    WallSide.Tall => 29059,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29060,
                                    WallSide.Low => 29061,
                                    WallSide.Tall => 29062,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29063,
                                    WallSide.Low => 29064,
                                    WallSide.Tall => 29065,
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
                                    WallSide.None => 29066,
                                    WallSide.Low => 29067,
                                    WallSide.Tall => 29068,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29069,
                                    WallSide.Low => 29070,
                                    WallSide.Tall => 29071,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29072,
                                    WallSide.Low => 29073,
                                    WallSide.Tall => 29074,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29075,
                                    WallSide.Low => 29076,
                                    WallSide.Tall => 29077,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29078,
                                    WallSide.Low => 29079,
                                    WallSide.Tall => 29080,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29081,
                                    WallSide.Low => 29082,
                                    WallSide.Tall => 29083,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29084,
                                    WallSide.Low => 29085,
                                    WallSide.Tall => 29086,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29087,
                                    WallSide.Low => 29088,
                                    WallSide.Tall => 29089,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29090,
                                    WallSide.Low => 29091,
                                    WallSide.Tall => 29092,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29093,
                                    WallSide.Low => 29094,
                                    WallSide.Tall => 29095,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29096,
                                    WallSide.Low => 29097,
                                    WallSide.Tall => 29098,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29099,
                                    WallSide.Low => 29100,
                                    WallSide.Tall => 29101,
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
                                    WallSide.None => 29102,
                                    WallSide.Low => 29103,
                                    WallSide.Tall => 29104,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29105,
                                    WallSide.Low => 29106,
                                    WallSide.Tall => 29107,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29108,
                                    WallSide.Low => 29109,
                                    WallSide.Tall => 29110,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29111,
                                    WallSide.Low => 29112,
                                    WallSide.Tall => 29113,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29114,
                                    WallSide.Low => 29115,
                                    WallSide.Tall => 29116,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29117,
                                    WallSide.Low => 29118,
                                    WallSide.Tall => 29119,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29120,
                                    WallSide.Low => 29121,
                                    WallSide.Tall => 29122,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29123,
                                    WallSide.Low => 29124,
                                    WallSide.Tall => 29125,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29126,
                                    WallSide.Low => 29127,
                                    WallSide.Tall => 29128,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29129,
                                    WallSide.Low => 29130,
                                    WallSide.Tall => 29131,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29132,
                                    WallSide.Low => 29133,
                                    WallSide.Tall => 29134,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29135,
                                    WallSide.Low => 29136,
                                    WallSide.Tall => 29137,
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
                                    WallSide.None => 29138,
                                    WallSide.Low => 29139,
                                    WallSide.Tall => 29140,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29141,
                                    WallSide.Low => 29142,
                                    WallSide.Tall => 29143,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29144,
                                    WallSide.Low => 29145,
                                    WallSide.Tall => 29146,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29147,
                                    WallSide.Low => 29148,
                                    WallSide.Tall => 29149,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29150,
                                    WallSide.Low => 29151,
                                    WallSide.Tall => 29152,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29153,
                                    WallSide.Low => 29154,
                                    WallSide.Tall => 29155,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29156,
                                    WallSide.Low => 29157,
                                    WallSide.Tall => 29158,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29159,
                                    WallSide.Low => 29160,
                                    WallSide.Tall => 29161,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29162,
                                    WallSide.Low => 29163,
                                    WallSide.Tall => 29164,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29165,
                                    WallSide.Low => 29166,
                                    WallSide.Tall => 29167,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29168,
                                    WallSide.Low => 29169,
                                    WallSide.Tall => 29170,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29171,
                                    WallSide.Low => 29172,
                                    WallSide.Tall => 29173,
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
                                    WallSide.None => 29174,
                                    WallSide.Low => 29175,
                                    WallSide.Tall => 29176,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29177,
                                    WallSide.Low => 29178,
                                    WallSide.Tall => 29179,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29180,
                                    WallSide.Low => 29181,
                                    WallSide.Tall => 29182,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29183,
                                    WallSide.Low => 29184,
                                    WallSide.Tall => 29185,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29186,
                                    WallSide.Low => 29187,
                                    WallSide.Tall => 29188,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29189,
                                    WallSide.Low => 29190,
                                    WallSide.Tall => 29191,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29192,
                                    WallSide.Low => 29193,
                                    WallSide.Tall => 29194,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29195,
                                    WallSide.Low => 29196,
                                    WallSide.Tall => 29197,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29198,
                                    WallSide.Low => 29199,
                                    WallSide.Tall => 29200,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29201,
                                    WallSide.Low => 29202,
                                    WallSide.Tall => 29203,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29204,
                                    WallSide.Low => 29205,
                                    WallSide.Tall => 29206,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29207,
                                    WallSide.Low => 29208,
                                    WallSide.Tall => 29209,
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
                                    WallSide.None => 29210,
                                    WallSide.Low => 29211,
                                    WallSide.Tall => 29212,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29213,
                                    WallSide.Low => 29214,
                                    WallSide.Tall => 29215,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29216,
                                    WallSide.Low => 29217,
                                    WallSide.Tall => 29218,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29219,
                                    WallSide.Low => 29220,
                                    WallSide.Tall => 29221,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29222,
                                    WallSide.Low => 29223,
                                    WallSide.Tall => 29224,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29225,
                                    WallSide.Low => 29226,
                                    WallSide.Tall => 29227,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29228,
                                    WallSide.Low => 29229,
                                    WallSide.Tall => 29230,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29231,
                                    WallSide.Low => 29232,
                                    WallSide.Tall => 29233,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29234,
                                    WallSide.Low => 29235,
                                    WallSide.Tall => 29236,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29237,
                                    WallSide.Low => 29238,
                                    WallSide.Tall => 29239,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29240,
                                    WallSide.Low => 29241,
                                    WallSide.Tall => 29242,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29243,
                                    WallSide.Low => 29244,
                                    WallSide.Tall => 29245,
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
                                    WallSide.None => 29246,
                                    WallSide.Low => 29247,
                                    WallSide.Tall => 29248,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29249,
                                    WallSide.Low => 29250,
                                    WallSide.Tall => 29251,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29252,
                                    WallSide.Low => 29253,
                                    WallSide.Tall => 29254,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29255,
                                    WallSide.Low => 29256,
                                    WallSide.Tall => 29257,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29258,
                                    WallSide.Low => 29259,
                                    WallSide.Tall => 29260,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29261,
                                    WallSide.Low => 29262,
                                    WallSide.Tall => 29263,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29264,
                                    WallSide.Low => 29265,
                                    WallSide.Tall => 29266,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29267,
                                    WallSide.Low => 29268,
                                    WallSide.Tall => 29269,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29270,
                                    WallSide.Low => 29271,
                                    WallSide.Tall => 29272,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29273,
                                    WallSide.Low => 29274,
                                    WallSide.Tall => 29275,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29276,
                                    WallSide.Low => 29277,
                                    WallSide.Tall => 29278,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29279,
                                    WallSide.Low => 29280,
                                    WallSide.Tall => 29281,
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
            28958 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            28959 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            28960 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            28961 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            28962 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            28963 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            28964 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            28965 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            28966 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            28967 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            28968 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            28969 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            28970 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            28971 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            28972 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            28973 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            28974 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            28975 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            28976 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            28977 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            28978 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            28979 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            28980 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            28981 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            28982 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            28983 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            28984 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            28985 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            28986 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            28987 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            28988 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            28989 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            28990 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            28991 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            28992 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            28993 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            28994 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            28995 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            28996 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            28997 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            28998 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            28999 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            29000 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            29001 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            29002 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            29003 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            29004 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            29005 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            29006 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            29007 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            29008 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            29009 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            29010 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            29011 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            29012 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            29013 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            29014 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            29015 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            29016 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            29017 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            29018 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            29019 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            29020 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            29021 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            29022 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            29023 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            29024 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            29025 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            29026 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            29027 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            29028 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            29029 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            29030 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            29031 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            29032 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            29033 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            29034 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            29035 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            29036 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            29037 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            29038 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            29039 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            29040 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            29041 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            29042 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            29043 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            29044 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            29045 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            29046 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            29047 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            29048 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            29049 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            29050 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            29051 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            29052 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            29053 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            29054 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            29055 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            29056 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            29057 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            29058 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            29059 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            29060 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            29061 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            29062 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            29063 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            29064 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            29065 => new SulfurBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            29066 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            29067 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            29068 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            29069 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            29070 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            29071 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            29072 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            29073 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            29074 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            29075 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            29076 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            29077 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            29078 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            29079 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            29080 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            29081 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            29082 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            29083 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            29084 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            29085 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            29086 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            29087 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            29088 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            29089 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            29090 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            29091 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            29092 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            29093 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            29094 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            29095 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            29096 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            29097 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            29098 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            29099 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            29100 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            29101 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            29102 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            29103 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            29104 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            29105 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            29106 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            29107 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            29108 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            29109 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            29110 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            29111 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            29112 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            29113 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            29114 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            29115 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            29116 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            29117 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            29118 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            29119 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            29120 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            29121 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            29122 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            29123 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            29124 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            29125 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            29126 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            29127 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            29128 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            29129 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            29130 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            29131 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            29132 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            29133 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            29134 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            29135 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            29136 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            29137 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            29138 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            29139 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            29140 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            29141 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            29142 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            29143 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            29144 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            29145 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            29146 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            29147 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            29148 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            29149 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            29150 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            29151 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            29152 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            29153 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            29154 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            29155 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            29156 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            29157 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            29158 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            29159 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            29160 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            29161 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            29162 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            29163 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            29164 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            29165 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            29166 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            29167 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            29168 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            29169 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            29170 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            29171 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            29172 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            29173 => new SulfurBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            29174 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            29175 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            29176 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            29177 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            29178 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            29179 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            29180 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            29181 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            29182 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            29183 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            29184 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            29185 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            29186 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            29187 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            29188 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            29189 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            29190 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            29191 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            29192 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            29193 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            29194 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            29195 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            29196 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            29197 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            29198 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            29199 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            29200 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            29201 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            29202 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            29203 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            29204 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            29205 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            29206 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            29207 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            29208 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            29209 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            29210 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            29211 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            29212 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            29213 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            29214 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            29215 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            29216 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            29217 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            29218 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            29219 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            29220 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            29221 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            29222 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            29223 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            29224 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            29225 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            29226 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            29227 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            29228 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            29229 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            29230 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            29231 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            29232 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            29233 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            29234 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            29235 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            29236 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            29237 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            29238 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            29239 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            29240 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            29241 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            29242 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            29243 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            29244 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            29245 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            29246 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            29247 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            29248 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            29249 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            29250 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            29251 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            29252 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            29253 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            29254 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            29255 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            29256 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            29257 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            29258 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            29259 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            29260 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            29261 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            29262 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            29263 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            29264 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            29265 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            29266 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            29267 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            29268 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            29269 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            29270 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            29271 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            29272 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            29273 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            29274 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            29275 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            29276 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            29277 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            29278 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            29279 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            29280 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            29281 => new SulfurBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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

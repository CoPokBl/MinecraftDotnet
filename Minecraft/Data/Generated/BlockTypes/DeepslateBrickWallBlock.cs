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
public record DeepslateBrickWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock, IWaterlogged, IFaceConnected, IWallConnected {
    private static readonly BlockInfo Data = new("block.minecraft.deepslate_brick_wall", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:deepslate_brick_wall", BlockInfo.VanillaOnly, "minecraft:blocks/deepslate_brick_wall");
    private static readonly BlockStateInfo I0 = new(3.5f, 0, 1, PushReaction.PushPull, 59, "deepslate_bricks", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S87, BlockShapes.S132, BlockShapes.S1, BlockShapes.S87, BlockShapes.S132, BlockShapes.S132);
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

    public BlockStateInfo StateInfo => States[StateId - 35096];

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
                                    WallSide.None => 35096,
                                    WallSide.Low => 35097,
                                    WallSide.Tall => 35098,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35099,
                                    WallSide.Low => 35100,
                                    WallSide.Tall => 35101,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35102,
                                    WallSide.Low => 35103,
                                    WallSide.Tall => 35104,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35105,
                                    WallSide.Low => 35106,
                                    WallSide.Tall => 35107,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35108,
                                    WallSide.Low => 35109,
                                    WallSide.Tall => 35110,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35111,
                                    WallSide.Low => 35112,
                                    WallSide.Tall => 35113,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35114,
                                    WallSide.Low => 35115,
                                    WallSide.Tall => 35116,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35117,
                                    WallSide.Low => 35118,
                                    WallSide.Tall => 35119,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35120,
                                    WallSide.Low => 35121,
                                    WallSide.Tall => 35122,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35123,
                                    WallSide.Low => 35124,
                                    WallSide.Tall => 35125,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35126,
                                    WallSide.Low => 35127,
                                    WallSide.Tall => 35128,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35129,
                                    WallSide.Low => 35130,
                                    WallSide.Tall => 35131,
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
                                    WallSide.None => 35132,
                                    WallSide.Low => 35133,
                                    WallSide.Tall => 35134,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35135,
                                    WallSide.Low => 35136,
                                    WallSide.Tall => 35137,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35138,
                                    WallSide.Low => 35139,
                                    WallSide.Tall => 35140,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35141,
                                    WallSide.Low => 35142,
                                    WallSide.Tall => 35143,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35144,
                                    WallSide.Low => 35145,
                                    WallSide.Tall => 35146,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35147,
                                    WallSide.Low => 35148,
                                    WallSide.Tall => 35149,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35150,
                                    WallSide.Low => 35151,
                                    WallSide.Tall => 35152,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35153,
                                    WallSide.Low => 35154,
                                    WallSide.Tall => 35155,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35156,
                                    WallSide.Low => 35157,
                                    WallSide.Tall => 35158,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35159,
                                    WallSide.Low => 35160,
                                    WallSide.Tall => 35161,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35162,
                                    WallSide.Low => 35163,
                                    WallSide.Tall => 35164,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35165,
                                    WallSide.Low => 35166,
                                    WallSide.Tall => 35167,
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
                                    WallSide.None => 35168,
                                    WallSide.Low => 35169,
                                    WallSide.Tall => 35170,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35171,
                                    WallSide.Low => 35172,
                                    WallSide.Tall => 35173,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35174,
                                    WallSide.Low => 35175,
                                    WallSide.Tall => 35176,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35177,
                                    WallSide.Low => 35178,
                                    WallSide.Tall => 35179,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35180,
                                    WallSide.Low => 35181,
                                    WallSide.Tall => 35182,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35183,
                                    WallSide.Low => 35184,
                                    WallSide.Tall => 35185,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35186,
                                    WallSide.Low => 35187,
                                    WallSide.Tall => 35188,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35189,
                                    WallSide.Low => 35190,
                                    WallSide.Tall => 35191,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35192,
                                    WallSide.Low => 35193,
                                    WallSide.Tall => 35194,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35195,
                                    WallSide.Low => 35196,
                                    WallSide.Tall => 35197,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35198,
                                    WallSide.Low => 35199,
                                    WallSide.Tall => 35200,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35201,
                                    WallSide.Low => 35202,
                                    WallSide.Tall => 35203,
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
                                    WallSide.None => 35204,
                                    WallSide.Low => 35205,
                                    WallSide.Tall => 35206,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35207,
                                    WallSide.Low => 35208,
                                    WallSide.Tall => 35209,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35210,
                                    WallSide.Low => 35211,
                                    WallSide.Tall => 35212,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35213,
                                    WallSide.Low => 35214,
                                    WallSide.Tall => 35215,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35216,
                                    WallSide.Low => 35217,
                                    WallSide.Tall => 35218,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35219,
                                    WallSide.Low => 35220,
                                    WallSide.Tall => 35221,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35222,
                                    WallSide.Low => 35223,
                                    WallSide.Tall => 35224,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35225,
                                    WallSide.Low => 35226,
                                    WallSide.Tall => 35227,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35228,
                                    WallSide.Low => 35229,
                                    WallSide.Tall => 35230,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35231,
                                    WallSide.Low => 35232,
                                    WallSide.Tall => 35233,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35234,
                                    WallSide.Low => 35235,
                                    WallSide.Tall => 35236,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35237,
                                    WallSide.Low => 35238,
                                    WallSide.Tall => 35239,
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
                                    WallSide.None => 35240,
                                    WallSide.Low => 35241,
                                    WallSide.Tall => 35242,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35243,
                                    WallSide.Low => 35244,
                                    WallSide.Tall => 35245,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35246,
                                    WallSide.Low => 35247,
                                    WallSide.Tall => 35248,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35249,
                                    WallSide.Low => 35250,
                                    WallSide.Tall => 35251,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35252,
                                    WallSide.Low => 35253,
                                    WallSide.Tall => 35254,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35255,
                                    WallSide.Low => 35256,
                                    WallSide.Tall => 35257,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35258,
                                    WallSide.Low => 35259,
                                    WallSide.Tall => 35260,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35261,
                                    WallSide.Low => 35262,
                                    WallSide.Tall => 35263,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35264,
                                    WallSide.Low => 35265,
                                    WallSide.Tall => 35266,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35267,
                                    WallSide.Low => 35268,
                                    WallSide.Tall => 35269,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35270,
                                    WallSide.Low => 35271,
                                    WallSide.Tall => 35272,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35273,
                                    WallSide.Low => 35274,
                                    WallSide.Tall => 35275,
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
                                    WallSide.None => 35276,
                                    WallSide.Low => 35277,
                                    WallSide.Tall => 35278,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35279,
                                    WallSide.Low => 35280,
                                    WallSide.Tall => 35281,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35282,
                                    WallSide.Low => 35283,
                                    WallSide.Tall => 35284,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35285,
                                    WallSide.Low => 35286,
                                    WallSide.Tall => 35287,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35288,
                                    WallSide.Low => 35289,
                                    WallSide.Tall => 35290,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35291,
                                    WallSide.Low => 35292,
                                    WallSide.Tall => 35293,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35294,
                                    WallSide.Low => 35295,
                                    WallSide.Tall => 35296,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35297,
                                    WallSide.Low => 35298,
                                    WallSide.Tall => 35299,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35300,
                                    WallSide.Low => 35301,
                                    WallSide.Tall => 35302,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35303,
                                    WallSide.Low => 35304,
                                    WallSide.Tall => 35305,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35306,
                                    WallSide.Low => 35307,
                                    WallSide.Tall => 35308,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35309,
                                    WallSide.Low => 35310,
                                    WallSide.Tall => 35311,
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
                                    WallSide.None => 35312,
                                    WallSide.Low => 35313,
                                    WallSide.Tall => 35314,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35315,
                                    WallSide.Low => 35316,
                                    WallSide.Tall => 35317,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35318,
                                    WallSide.Low => 35319,
                                    WallSide.Tall => 35320,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35321,
                                    WallSide.Low => 35322,
                                    WallSide.Tall => 35323,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35324,
                                    WallSide.Low => 35325,
                                    WallSide.Tall => 35326,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35327,
                                    WallSide.Low => 35328,
                                    WallSide.Tall => 35329,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35330,
                                    WallSide.Low => 35331,
                                    WallSide.Tall => 35332,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35333,
                                    WallSide.Low => 35334,
                                    WallSide.Tall => 35335,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35336,
                                    WallSide.Low => 35337,
                                    WallSide.Tall => 35338,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35339,
                                    WallSide.Low => 35340,
                                    WallSide.Tall => 35341,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35342,
                                    WallSide.Low => 35343,
                                    WallSide.Tall => 35344,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35345,
                                    WallSide.Low => 35346,
                                    WallSide.Tall => 35347,
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
                                    WallSide.None => 35348,
                                    WallSide.Low => 35349,
                                    WallSide.Tall => 35350,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35351,
                                    WallSide.Low => 35352,
                                    WallSide.Tall => 35353,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35354,
                                    WallSide.Low => 35355,
                                    WallSide.Tall => 35356,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35357,
                                    WallSide.Low => 35358,
                                    WallSide.Tall => 35359,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35360,
                                    WallSide.Low => 35361,
                                    WallSide.Tall => 35362,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35363,
                                    WallSide.Low => 35364,
                                    WallSide.Tall => 35365,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35366,
                                    WallSide.Low => 35367,
                                    WallSide.Tall => 35368,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35369,
                                    WallSide.Low => 35370,
                                    WallSide.Tall => 35371,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35372,
                                    WallSide.Low => 35373,
                                    WallSide.Tall => 35374,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35375,
                                    WallSide.Low => 35376,
                                    WallSide.Tall => 35377,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35378,
                                    WallSide.Low => 35379,
                                    WallSide.Tall => 35380,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35381,
                                    WallSide.Low => 35382,
                                    WallSide.Tall => 35383,
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
                                    WallSide.None => 35384,
                                    WallSide.Low => 35385,
                                    WallSide.Tall => 35386,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35387,
                                    WallSide.Low => 35388,
                                    WallSide.Tall => 35389,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35390,
                                    WallSide.Low => 35391,
                                    WallSide.Tall => 35392,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35393,
                                    WallSide.Low => 35394,
                                    WallSide.Tall => 35395,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35396,
                                    WallSide.Low => 35397,
                                    WallSide.Tall => 35398,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35399,
                                    WallSide.Low => 35400,
                                    WallSide.Tall => 35401,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35402,
                                    WallSide.Low => 35403,
                                    WallSide.Tall => 35404,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35405,
                                    WallSide.Low => 35406,
                                    WallSide.Tall => 35407,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35408,
                                    WallSide.Low => 35409,
                                    WallSide.Tall => 35410,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35411,
                                    WallSide.Low => 35412,
                                    WallSide.Tall => 35413,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 35414,
                                    WallSide.Low => 35415,
                                    WallSide.Tall => 35416,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 35417,
                                    WallSide.Low => 35418,
                                    WallSide.Tall => 35419,
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
            35096 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            35097 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            35098 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            35099 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            35100 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            35101 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            35102 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            35103 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            35104 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            35105 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            35106 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            35107 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            35108 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            35109 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            35110 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            35111 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            35112 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            35113 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            35114 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            35115 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            35116 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            35117 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            35118 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            35119 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            35120 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            35121 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            35122 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            35123 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            35124 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            35125 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            35126 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            35127 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            35128 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            35129 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            35130 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            35131 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            35132 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            35133 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            35134 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            35135 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            35136 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            35137 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            35138 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            35139 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            35140 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            35141 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            35142 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            35143 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            35144 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            35145 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            35146 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            35147 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            35148 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            35149 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            35150 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            35151 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            35152 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            35153 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            35154 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            35155 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            35156 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            35157 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            35158 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            35159 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            35160 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            35161 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            35162 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            35163 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            35164 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            35165 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            35166 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            35167 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            35168 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            35169 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            35170 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            35171 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            35172 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            35173 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            35174 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            35175 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            35176 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            35177 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            35178 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            35179 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            35180 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            35181 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            35182 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            35183 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            35184 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            35185 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            35186 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            35187 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            35188 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            35189 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            35190 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            35191 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            35192 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            35193 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            35194 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            35195 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            35196 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            35197 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            35198 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            35199 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            35200 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            35201 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            35202 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            35203 => new DeepslateBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            35204 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            35205 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            35206 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            35207 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            35208 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            35209 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            35210 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            35211 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            35212 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            35213 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            35214 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            35215 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            35216 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            35217 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            35218 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            35219 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            35220 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            35221 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            35222 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            35223 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            35224 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            35225 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            35226 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            35227 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            35228 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            35229 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            35230 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            35231 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            35232 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            35233 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            35234 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            35235 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            35236 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            35237 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            35238 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            35239 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            35240 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            35241 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            35242 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            35243 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            35244 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            35245 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            35246 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            35247 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            35248 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            35249 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            35250 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            35251 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            35252 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            35253 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            35254 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            35255 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            35256 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            35257 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            35258 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            35259 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            35260 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            35261 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            35262 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            35263 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            35264 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            35265 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            35266 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            35267 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            35268 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            35269 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            35270 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            35271 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            35272 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            35273 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            35274 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            35275 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            35276 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            35277 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            35278 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            35279 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            35280 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            35281 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            35282 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            35283 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            35284 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            35285 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            35286 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            35287 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            35288 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            35289 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            35290 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            35291 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            35292 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            35293 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            35294 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            35295 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            35296 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            35297 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            35298 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            35299 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            35300 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            35301 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            35302 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            35303 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            35304 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            35305 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            35306 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            35307 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            35308 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            35309 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            35310 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            35311 => new DeepslateBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            35312 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            35313 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            35314 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            35315 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            35316 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            35317 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            35318 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            35319 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            35320 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            35321 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            35322 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            35323 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            35324 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            35325 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            35326 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            35327 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            35328 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            35329 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            35330 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            35331 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            35332 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            35333 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            35334 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            35335 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            35336 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            35337 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            35338 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            35339 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            35340 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            35341 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            35342 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            35343 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            35344 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            35345 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            35346 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            35347 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            35348 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            35349 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            35350 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            35351 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            35352 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            35353 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            35354 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            35355 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            35356 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            35357 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            35358 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            35359 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            35360 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            35361 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            35362 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            35363 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            35364 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            35365 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            35366 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            35367 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            35368 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            35369 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            35370 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            35371 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            35372 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            35373 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            35374 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            35375 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            35376 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            35377 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            35378 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            35379 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            35380 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            35381 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            35382 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            35383 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            35384 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            35385 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            35386 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            35387 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            35388 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            35389 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            35390 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            35391 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            35392 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            35393 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            35394 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            35395 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            35396 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            35397 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            35398 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            35399 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            35400 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            35401 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            35402 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            35403 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            35404 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            35405 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            35406 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            35407 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            35408 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            35409 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            35410 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            35411 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            35412 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            35413 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            35414 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            35415 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            35416 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            35417 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            35418 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            35419 => new DeepslateBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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

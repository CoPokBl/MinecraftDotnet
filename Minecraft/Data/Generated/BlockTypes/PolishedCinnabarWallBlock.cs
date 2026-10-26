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
public record PolishedCinnabarWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock, IWaterlogged, IFaceConnected, IWallConnected {
    private static readonly BlockInfo Data = new("block.minecraft.polished_cinnabar_wall", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_cinnabar_wall", BlockInfo.VanillaOnly, "minecraft:blocks/polished_cinnabar_wall");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 28, "cinnabar", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S87, BlockShapes.S132, BlockShapes.S1, BlockShapes.S87, BlockShapes.S132, BlockShapes.S132);
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

    public BlockStateInfo StateInfo => States[StateId - 29781];

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
                                    WallSide.None => 29781,
                                    WallSide.Low => 29782,
                                    WallSide.Tall => 29783,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29784,
                                    WallSide.Low => 29785,
                                    WallSide.Tall => 29786,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29787,
                                    WallSide.Low => 29788,
                                    WallSide.Tall => 29789,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29790,
                                    WallSide.Low => 29791,
                                    WallSide.Tall => 29792,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29793,
                                    WallSide.Low => 29794,
                                    WallSide.Tall => 29795,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29796,
                                    WallSide.Low => 29797,
                                    WallSide.Tall => 29798,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29799,
                                    WallSide.Low => 29800,
                                    WallSide.Tall => 29801,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29802,
                                    WallSide.Low => 29803,
                                    WallSide.Tall => 29804,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29805,
                                    WallSide.Low => 29806,
                                    WallSide.Tall => 29807,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29808,
                                    WallSide.Low => 29809,
                                    WallSide.Tall => 29810,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29811,
                                    WallSide.Low => 29812,
                                    WallSide.Tall => 29813,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29814,
                                    WallSide.Low => 29815,
                                    WallSide.Tall => 29816,
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
                                    WallSide.None => 29817,
                                    WallSide.Low => 29818,
                                    WallSide.Tall => 29819,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29820,
                                    WallSide.Low => 29821,
                                    WallSide.Tall => 29822,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29823,
                                    WallSide.Low => 29824,
                                    WallSide.Tall => 29825,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29826,
                                    WallSide.Low => 29827,
                                    WallSide.Tall => 29828,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29829,
                                    WallSide.Low => 29830,
                                    WallSide.Tall => 29831,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29832,
                                    WallSide.Low => 29833,
                                    WallSide.Tall => 29834,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29835,
                                    WallSide.Low => 29836,
                                    WallSide.Tall => 29837,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29838,
                                    WallSide.Low => 29839,
                                    WallSide.Tall => 29840,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29841,
                                    WallSide.Low => 29842,
                                    WallSide.Tall => 29843,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29844,
                                    WallSide.Low => 29845,
                                    WallSide.Tall => 29846,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29847,
                                    WallSide.Low => 29848,
                                    WallSide.Tall => 29849,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29850,
                                    WallSide.Low => 29851,
                                    WallSide.Tall => 29852,
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
                                    WallSide.None => 29853,
                                    WallSide.Low => 29854,
                                    WallSide.Tall => 29855,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29856,
                                    WallSide.Low => 29857,
                                    WallSide.Tall => 29858,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29859,
                                    WallSide.Low => 29860,
                                    WallSide.Tall => 29861,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29862,
                                    WallSide.Low => 29863,
                                    WallSide.Tall => 29864,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29865,
                                    WallSide.Low => 29866,
                                    WallSide.Tall => 29867,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29868,
                                    WallSide.Low => 29869,
                                    WallSide.Tall => 29870,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29871,
                                    WallSide.Low => 29872,
                                    WallSide.Tall => 29873,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29874,
                                    WallSide.Low => 29875,
                                    WallSide.Tall => 29876,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29877,
                                    WallSide.Low => 29878,
                                    WallSide.Tall => 29879,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29880,
                                    WallSide.Low => 29881,
                                    WallSide.Tall => 29882,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29883,
                                    WallSide.Low => 29884,
                                    WallSide.Tall => 29885,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29886,
                                    WallSide.Low => 29887,
                                    WallSide.Tall => 29888,
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
                                    WallSide.None => 29889,
                                    WallSide.Low => 29890,
                                    WallSide.Tall => 29891,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29892,
                                    WallSide.Low => 29893,
                                    WallSide.Tall => 29894,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29895,
                                    WallSide.Low => 29896,
                                    WallSide.Tall => 29897,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29898,
                                    WallSide.Low => 29899,
                                    WallSide.Tall => 29900,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29901,
                                    WallSide.Low => 29902,
                                    WallSide.Tall => 29903,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29904,
                                    WallSide.Low => 29905,
                                    WallSide.Tall => 29906,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29907,
                                    WallSide.Low => 29908,
                                    WallSide.Tall => 29909,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29910,
                                    WallSide.Low => 29911,
                                    WallSide.Tall => 29912,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29913,
                                    WallSide.Low => 29914,
                                    WallSide.Tall => 29915,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29916,
                                    WallSide.Low => 29917,
                                    WallSide.Tall => 29918,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29919,
                                    WallSide.Low => 29920,
                                    WallSide.Tall => 29921,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29922,
                                    WallSide.Low => 29923,
                                    WallSide.Tall => 29924,
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
                                    WallSide.None => 29925,
                                    WallSide.Low => 29926,
                                    WallSide.Tall => 29927,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29928,
                                    WallSide.Low => 29929,
                                    WallSide.Tall => 29930,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29931,
                                    WallSide.Low => 29932,
                                    WallSide.Tall => 29933,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29934,
                                    WallSide.Low => 29935,
                                    WallSide.Tall => 29936,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29937,
                                    WallSide.Low => 29938,
                                    WallSide.Tall => 29939,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29940,
                                    WallSide.Low => 29941,
                                    WallSide.Tall => 29942,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29943,
                                    WallSide.Low => 29944,
                                    WallSide.Tall => 29945,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29946,
                                    WallSide.Low => 29947,
                                    WallSide.Tall => 29948,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29949,
                                    WallSide.Low => 29950,
                                    WallSide.Tall => 29951,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29952,
                                    WallSide.Low => 29953,
                                    WallSide.Tall => 29954,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29955,
                                    WallSide.Low => 29956,
                                    WallSide.Tall => 29957,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29958,
                                    WallSide.Low => 29959,
                                    WallSide.Tall => 29960,
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
                                    WallSide.None => 29961,
                                    WallSide.Low => 29962,
                                    WallSide.Tall => 29963,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29964,
                                    WallSide.Low => 29965,
                                    WallSide.Tall => 29966,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29967,
                                    WallSide.Low => 29968,
                                    WallSide.Tall => 29969,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29970,
                                    WallSide.Low => 29971,
                                    WallSide.Tall => 29972,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29973,
                                    WallSide.Low => 29974,
                                    WallSide.Tall => 29975,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29976,
                                    WallSide.Low => 29977,
                                    WallSide.Tall => 29978,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29979,
                                    WallSide.Low => 29980,
                                    WallSide.Tall => 29981,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29982,
                                    WallSide.Low => 29983,
                                    WallSide.Tall => 29984,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29985,
                                    WallSide.Low => 29986,
                                    WallSide.Tall => 29987,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29988,
                                    WallSide.Low => 29989,
                                    WallSide.Tall => 29990,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 29991,
                                    WallSide.Low => 29992,
                                    WallSide.Tall => 29993,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 29994,
                                    WallSide.Low => 29995,
                                    WallSide.Tall => 29996,
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
                                    WallSide.None => 29997,
                                    WallSide.Low => 29998,
                                    WallSide.Tall => 29999,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30000,
                                    WallSide.Low => 30001,
                                    WallSide.Tall => 30002,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30003,
                                    WallSide.Low => 30004,
                                    WallSide.Tall => 30005,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30006,
                                    WallSide.Low => 30007,
                                    WallSide.Tall => 30008,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30009,
                                    WallSide.Low => 30010,
                                    WallSide.Tall => 30011,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30012,
                                    WallSide.Low => 30013,
                                    WallSide.Tall => 30014,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30015,
                                    WallSide.Low => 30016,
                                    WallSide.Tall => 30017,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30018,
                                    WallSide.Low => 30019,
                                    WallSide.Tall => 30020,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30021,
                                    WallSide.Low => 30022,
                                    WallSide.Tall => 30023,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30024,
                                    WallSide.Low => 30025,
                                    WallSide.Tall => 30026,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30027,
                                    WallSide.Low => 30028,
                                    WallSide.Tall => 30029,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30030,
                                    WallSide.Low => 30031,
                                    WallSide.Tall => 30032,
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
                                    WallSide.None => 30033,
                                    WallSide.Low => 30034,
                                    WallSide.Tall => 30035,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30036,
                                    WallSide.Low => 30037,
                                    WallSide.Tall => 30038,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30039,
                                    WallSide.Low => 30040,
                                    WallSide.Tall => 30041,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30042,
                                    WallSide.Low => 30043,
                                    WallSide.Tall => 30044,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30045,
                                    WallSide.Low => 30046,
                                    WallSide.Tall => 30047,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30048,
                                    WallSide.Low => 30049,
                                    WallSide.Tall => 30050,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30051,
                                    WallSide.Low => 30052,
                                    WallSide.Tall => 30053,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30054,
                                    WallSide.Low => 30055,
                                    WallSide.Tall => 30056,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30057,
                                    WallSide.Low => 30058,
                                    WallSide.Tall => 30059,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30060,
                                    WallSide.Low => 30061,
                                    WallSide.Tall => 30062,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30063,
                                    WallSide.Low => 30064,
                                    WallSide.Tall => 30065,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30066,
                                    WallSide.Low => 30067,
                                    WallSide.Tall => 30068,
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
                                    WallSide.None => 30069,
                                    WallSide.Low => 30070,
                                    WallSide.Tall => 30071,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30072,
                                    WallSide.Low => 30073,
                                    WallSide.Tall => 30074,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30075,
                                    WallSide.Low => 30076,
                                    WallSide.Tall => 30077,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30078,
                                    WallSide.Low => 30079,
                                    WallSide.Tall => 30080,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30081,
                                    WallSide.Low => 30082,
                                    WallSide.Tall => 30083,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30084,
                                    WallSide.Low => 30085,
                                    WallSide.Tall => 30086,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30087,
                                    WallSide.Low => 30088,
                                    WallSide.Tall => 30089,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30090,
                                    WallSide.Low => 30091,
                                    WallSide.Tall => 30092,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30093,
                                    WallSide.Low => 30094,
                                    WallSide.Tall => 30095,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30096,
                                    WallSide.Low => 30097,
                                    WallSide.Tall => 30098,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 30099,
                                    WallSide.Low => 30100,
                                    WallSide.Tall => 30101,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 30102,
                                    WallSide.Low => 30103,
                                    WallSide.Tall => 30104,
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
            29781 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            29782 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            29783 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            29784 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            29785 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            29786 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            29787 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            29788 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            29789 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            29790 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            29791 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            29792 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            29793 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            29794 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            29795 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            29796 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            29797 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            29798 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            29799 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            29800 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            29801 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            29802 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            29803 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            29804 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            29805 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            29806 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            29807 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            29808 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            29809 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            29810 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            29811 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            29812 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            29813 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            29814 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            29815 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            29816 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            29817 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            29818 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            29819 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            29820 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            29821 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            29822 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            29823 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            29824 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            29825 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            29826 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            29827 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            29828 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            29829 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            29830 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            29831 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            29832 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            29833 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            29834 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            29835 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            29836 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            29837 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            29838 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            29839 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            29840 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            29841 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            29842 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            29843 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            29844 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            29845 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            29846 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            29847 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            29848 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            29849 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            29850 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            29851 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            29852 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            29853 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            29854 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            29855 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            29856 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            29857 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            29858 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            29859 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            29860 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            29861 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            29862 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            29863 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            29864 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            29865 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            29866 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            29867 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            29868 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            29869 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            29870 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            29871 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            29872 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            29873 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            29874 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            29875 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            29876 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            29877 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            29878 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            29879 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            29880 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            29881 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            29882 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            29883 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            29884 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            29885 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            29886 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            29887 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            29888 => new PolishedCinnabarWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            29889 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            29890 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            29891 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            29892 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            29893 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            29894 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            29895 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            29896 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            29897 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            29898 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            29899 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            29900 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            29901 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            29902 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            29903 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            29904 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            29905 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            29906 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            29907 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            29908 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            29909 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            29910 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            29911 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            29912 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            29913 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            29914 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            29915 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            29916 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            29917 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            29918 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            29919 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            29920 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            29921 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            29922 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            29923 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            29924 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            29925 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            29926 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            29927 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            29928 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            29929 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            29930 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            29931 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            29932 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            29933 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            29934 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            29935 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            29936 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            29937 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            29938 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            29939 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            29940 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            29941 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            29942 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            29943 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            29944 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            29945 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            29946 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            29947 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            29948 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            29949 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            29950 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            29951 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            29952 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            29953 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            29954 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            29955 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            29956 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            29957 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            29958 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            29959 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            29960 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            29961 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            29962 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            29963 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            29964 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            29965 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            29966 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            29967 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            29968 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            29969 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            29970 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            29971 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            29972 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            29973 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            29974 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            29975 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            29976 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            29977 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            29978 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            29979 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            29980 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            29981 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            29982 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            29983 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            29984 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            29985 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            29986 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            29987 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            29988 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            29989 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            29990 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            29991 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            29992 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            29993 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            29994 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            29995 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            29996 => new PolishedCinnabarWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            29997 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            29998 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            29999 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            30000 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            30001 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            30002 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            30003 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            30004 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            30005 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            30006 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            30007 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            30008 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            30009 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            30010 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            30011 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            30012 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            30013 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            30014 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            30015 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            30016 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            30017 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            30018 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            30019 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            30020 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            30021 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            30022 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            30023 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            30024 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            30025 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            30026 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            30027 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            30028 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            30029 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            30030 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            30031 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            30032 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            30033 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            30034 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            30035 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            30036 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            30037 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            30038 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            30039 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            30040 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            30041 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            30042 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            30043 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            30044 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            30045 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            30046 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            30047 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            30048 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            30049 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            30050 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            30051 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            30052 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            30053 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            30054 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            30055 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            30056 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            30057 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            30058 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            30059 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            30060 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            30061 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            30062 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            30063 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            30064 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            30065 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            30066 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            30067 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            30068 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            30069 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            30070 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            30071 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            30072 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            30073 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            30074 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            30075 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            30076 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            30077 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            30078 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            30079 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            30080 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            30081 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            30082 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            30083 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            30084 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            30085 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            30086 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            30087 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            30088 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            30089 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            30090 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            30091 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            30092 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            30093 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            30094 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            30095 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            30096 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            30097 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            30098 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            30099 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            30100 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            30101 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            30102 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            30103 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            30104 => new PolishedCinnabarWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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

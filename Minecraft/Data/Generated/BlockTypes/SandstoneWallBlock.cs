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
public record SandstoneWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock, IWaterlogged, IFaceConnected, IWallConnected {
    private static readonly BlockInfo Data = new("block.minecraft.sandstone_wall", 0.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:sandstone_wall", BlockInfo.VanillaOnly, "minecraft:blocks/sandstone_wall");
    private static readonly BlockStateInfo I0 = new(0.8f, 0, 1, PushReaction.PushPull, 2, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S87, BlockShapes.S132, BlockShapes.S1, BlockShapes.S87, BlockShapes.S132, BlockShapes.S132);
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

    public BlockStateInfo StateInfo => States[StateId - 23091];

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
                                    WallSide.None => 23091,
                                    WallSide.Low => 23092,
                                    WallSide.Tall => 23093,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23094,
                                    WallSide.Low => 23095,
                                    WallSide.Tall => 23096,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23097,
                                    WallSide.Low => 23098,
                                    WallSide.Tall => 23099,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23100,
                                    WallSide.Low => 23101,
                                    WallSide.Tall => 23102,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23103,
                                    WallSide.Low => 23104,
                                    WallSide.Tall => 23105,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23106,
                                    WallSide.Low => 23107,
                                    WallSide.Tall => 23108,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23109,
                                    WallSide.Low => 23110,
                                    WallSide.Tall => 23111,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23112,
                                    WallSide.Low => 23113,
                                    WallSide.Tall => 23114,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23115,
                                    WallSide.Low => 23116,
                                    WallSide.Tall => 23117,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23118,
                                    WallSide.Low => 23119,
                                    WallSide.Tall => 23120,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23121,
                                    WallSide.Low => 23122,
                                    WallSide.Tall => 23123,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23124,
                                    WallSide.Low => 23125,
                                    WallSide.Tall => 23126,
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
                                    WallSide.None => 23127,
                                    WallSide.Low => 23128,
                                    WallSide.Tall => 23129,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23130,
                                    WallSide.Low => 23131,
                                    WallSide.Tall => 23132,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23133,
                                    WallSide.Low => 23134,
                                    WallSide.Tall => 23135,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23136,
                                    WallSide.Low => 23137,
                                    WallSide.Tall => 23138,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23139,
                                    WallSide.Low => 23140,
                                    WallSide.Tall => 23141,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23142,
                                    WallSide.Low => 23143,
                                    WallSide.Tall => 23144,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23145,
                                    WallSide.Low => 23146,
                                    WallSide.Tall => 23147,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23148,
                                    WallSide.Low => 23149,
                                    WallSide.Tall => 23150,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23151,
                                    WallSide.Low => 23152,
                                    WallSide.Tall => 23153,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23154,
                                    WallSide.Low => 23155,
                                    WallSide.Tall => 23156,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23157,
                                    WallSide.Low => 23158,
                                    WallSide.Tall => 23159,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23160,
                                    WallSide.Low => 23161,
                                    WallSide.Tall => 23162,
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
                                    WallSide.None => 23163,
                                    WallSide.Low => 23164,
                                    WallSide.Tall => 23165,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23166,
                                    WallSide.Low => 23167,
                                    WallSide.Tall => 23168,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23169,
                                    WallSide.Low => 23170,
                                    WallSide.Tall => 23171,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23172,
                                    WallSide.Low => 23173,
                                    WallSide.Tall => 23174,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23175,
                                    WallSide.Low => 23176,
                                    WallSide.Tall => 23177,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23178,
                                    WallSide.Low => 23179,
                                    WallSide.Tall => 23180,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23181,
                                    WallSide.Low => 23182,
                                    WallSide.Tall => 23183,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23184,
                                    WallSide.Low => 23185,
                                    WallSide.Tall => 23186,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23187,
                                    WallSide.Low => 23188,
                                    WallSide.Tall => 23189,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23190,
                                    WallSide.Low => 23191,
                                    WallSide.Tall => 23192,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23193,
                                    WallSide.Low => 23194,
                                    WallSide.Tall => 23195,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23196,
                                    WallSide.Low => 23197,
                                    WallSide.Tall => 23198,
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
                                    WallSide.None => 23199,
                                    WallSide.Low => 23200,
                                    WallSide.Tall => 23201,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23202,
                                    WallSide.Low => 23203,
                                    WallSide.Tall => 23204,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23205,
                                    WallSide.Low => 23206,
                                    WallSide.Tall => 23207,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23208,
                                    WallSide.Low => 23209,
                                    WallSide.Tall => 23210,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23211,
                                    WallSide.Low => 23212,
                                    WallSide.Tall => 23213,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23214,
                                    WallSide.Low => 23215,
                                    WallSide.Tall => 23216,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23217,
                                    WallSide.Low => 23218,
                                    WallSide.Tall => 23219,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23220,
                                    WallSide.Low => 23221,
                                    WallSide.Tall => 23222,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23223,
                                    WallSide.Low => 23224,
                                    WallSide.Tall => 23225,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23226,
                                    WallSide.Low => 23227,
                                    WallSide.Tall => 23228,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23229,
                                    WallSide.Low => 23230,
                                    WallSide.Tall => 23231,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23232,
                                    WallSide.Low => 23233,
                                    WallSide.Tall => 23234,
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
                                    WallSide.None => 23235,
                                    WallSide.Low => 23236,
                                    WallSide.Tall => 23237,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23238,
                                    WallSide.Low => 23239,
                                    WallSide.Tall => 23240,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23241,
                                    WallSide.Low => 23242,
                                    WallSide.Tall => 23243,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23244,
                                    WallSide.Low => 23245,
                                    WallSide.Tall => 23246,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23247,
                                    WallSide.Low => 23248,
                                    WallSide.Tall => 23249,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23250,
                                    WallSide.Low => 23251,
                                    WallSide.Tall => 23252,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23253,
                                    WallSide.Low => 23254,
                                    WallSide.Tall => 23255,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23256,
                                    WallSide.Low => 23257,
                                    WallSide.Tall => 23258,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23259,
                                    WallSide.Low => 23260,
                                    WallSide.Tall => 23261,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23262,
                                    WallSide.Low => 23263,
                                    WallSide.Tall => 23264,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23265,
                                    WallSide.Low => 23266,
                                    WallSide.Tall => 23267,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23268,
                                    WallSide.Low => 23269,
                                    WallSide.Tall => 23270,
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
                                    WallSide.None => 23271,
                                    WallSide.Low => 23272,
                                    WallSide.Tall => 23273,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23274,
                                    WallSide.Low => 23275,
                                    WallSide.Tall => 23276,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23277,
                                    WallSide.Low => 23278,
                                    WallSide.Tall => 23279,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23280,
                                    WallSide.Low => 23281,
                                    WallSide.Tall => 23282,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23283,
                                    WallSide.Low => 23284,
                                    WallSide.Tall => 23285,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23286,
                                    WallSide.Low => 23287,
                                    WallSide.Tall => 23288,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23289,
                                    WallSide.Low => 23290,
                                    WallSide.Tall => 23291,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23292,
                                    WallSide.Low => 23293,
                                    WallSide.Tall => 23294,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23295,
                                    WallSide.Low => 23296,
                                    WallSide.Tall => 23297,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23298,
                                    WallSide.Low => 23299,
                                    WallSide.Tall => 23300,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23301,
                                    WallSide.Low => 23302,
                                    WallSide.Tall => 23303,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23304,
                                    WallSide.Low => 23305,
                                    WallSide.Tall => 23306,
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
                                    WallSide.None => 23307,
                                    WallSide.Low => 23308,
                                    WallSide.Tall => 23309,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23310,
                                    WallSide.Low => 23311,
                                    WallSide.Tall => 23312,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23313,
                                    WallSide.Low => 23314,
                                    WallSide.Tall => 23315,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23316,
                                    WallSide.Low => 23317,
                                    WallSide.Tall => 23318,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23319,
                                    WallSide.Low => 23320,
                                    WallSide.Tall => 23321,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23322,
                                    WallSide.Low => 23323,
                                    WallSide.Tall => 23324,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23325,
                                    WallSide.Low => 23326,
                                    WallSide.Tall => 23327,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23328,
                                    WallSide.Low => 23329,
                                    WallSide.Tall => 23330,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23331,
                                    WallSide.Low => 23332,
                                    WallSide.Tall => 23333,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23334,
                                    WallSide.Low => 23335,
                                    WallSide.Tall => 23336,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23337,
                                    WallSide.Low => 23338,
                                    WallSide.Tall => 23339,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23340,
                                    WallSide.Low => 23341,
                                    WallSide.Tall => 23342,
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
                                    WallSide.None => 23343,
                                    WallSide.Low => 23344,
                                    WallSide.Tall => 23345,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23346,
                                    WallSide.Low => 23347,
                                    WallSide.Tall => 23348,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23349,
                                    WallSide.Low => 23350,
                                    WallSide.Tall => 23351,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23352,
                                    WallSide.Low => 23353,
                                    WallSide.Tall => 23354,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23355,
                                    WallSide.Low => 23356,
                                    WallSide.Tall => 23357,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23358,
                                    WallSide.Low => 23359,
                                    WallSide.Tall => 23360,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23361,
                                    WallSide.Low => 23362,
                                    WallSide.Tall => 23363,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23364,
                                    WallSide.Low => 23365,
                                    WallSide.Tall => 23366,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23367,
                                    WallSide.Low => 23368,
                                    WallSide.Tall => 23369,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23370,
                                    WallSide.Low => 23371,
                                    WallSide.Tall => 23372,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23373,
                                    WallSide.Low => 23374,
                                    WallSide.Tall => 23375,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23376,
                                    WallSide.Low => 23377,
                                    WallSide.Tall => 23378,
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
                                    WallSide.None => 23379,
                                    WallSide.Low => 23380,
                                    WallSide.Tall => 23381,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23382,
                                    WallSide.Low => 23383,
                                    WallSide.Tall => 23384,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23385,
                                    WallSide.Low => 23386,
                                    WallSide.Tall => 23387,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23388,
                                    WallSide.Low => 23389,
                                    WallSide.Tall => 23390,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23391,
                                    WallSide.Low => 23392,
                                    WallSide.Tall => 23393,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23394,
                                    WallSide.Low => 23395,
                                    WallSide.Tall => 23396,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23397,
                                    WallSide.Low => 23398,
                                    WallSide.Tall => 23399,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23400,
                                    WallSide.Low => 23401,
                                    WallSide.Tall => 23402,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23403,
                                    WallSide.Low => 23404,
                                    WallSide.Tall => 23405,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23406,
                                    WallSide.Low => 23407,
                                    WallSide.Tall => 23408,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23409,
                                    WallSide.Low => 23410,
                                    WallSide.Tall => 23411,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23412,
                                    WallSide.Low => 23413,
                                    WallSide.Tall => 23414,
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
            23091 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            23092 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            23093 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            23094 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            23095 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            23096 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            23097 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            23098 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            23099 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            23100 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            23101 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            23102 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            23103 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            23104 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            23105 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            23106 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            23107 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            23108 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            23109 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            23110 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            23111 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            23112 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            23113 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            23114 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            23115 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            23116 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            23117 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            23118 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            23119 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            23120 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            23121 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            23122 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            23123 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            23124 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            23125 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            23126 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            23127 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            23128 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            23129 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            23130 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            23131 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            23132 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            23133 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            23134 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            23135 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            23136 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            23137 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            23138 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            23139 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            23140 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            23141 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            23142 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            23143 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            23144 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            23145 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            23146 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            23147 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            23148 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            23149 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            23150 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            23151 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            23152 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            23153 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            23154 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            23155 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            23156 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            23157 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            23158 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            23159 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            23160 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            23161 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            23162 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            23163 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            23164 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            23165 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            23166 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            23167 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            23168 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            23169 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            23170 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            23171 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            23172 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            23173 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            23174 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            23175 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            23176 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            23177 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            23178 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            23179 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            23180 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            23181 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            23182 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            23183 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            23184 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            23185 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            23186 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            23187 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            23188 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            23189 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            23190 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            23191 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            23192 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            23193 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            23194 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            23195 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            23196 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            23197 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            23198 => new SandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            23199 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            23200 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            23201 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            23202 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            23203 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            23204 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            23205 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            23206 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            23207 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            23208 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            23209 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            23210 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            23211 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            23212 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            23213 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            23214 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            23215 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            23216 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            23217 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            23218 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            23219 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            23220 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            23221 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            23222 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            23223 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            23224 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            23225 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            23226 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            23227 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            23228 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            23229 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            23230 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            23231 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            23232 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            23233 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            23234 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            23235 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            23236 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            23237 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            23238 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            23239 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            23240 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            23241 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            23242 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            23243 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            23244 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            23245 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            23246 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            23247 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            23248 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            23249 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            23250 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            23251 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            23252 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            23253 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            23254 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            23255 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            23256 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            23257 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            23258 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            23259 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            23260 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            23261 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            23262 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            23263 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            23264 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            23265 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            23266 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            23267 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            23268 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            23269 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            23270 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            23271 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            23272 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            23273 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            23274 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            23275 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            23276 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            23277 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            23278 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            23279 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            23280 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            23281 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            23282 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            23283 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            23284 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            23285 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            23286 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            23287 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            23288 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            23289 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            23290 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            23291 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            23292 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            23293 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            23294 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            23295 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            23296 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            23297 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            23298 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            23299 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            23300 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            23301 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            23302 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            23303 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            23304 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            23305 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            23306 => new SandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            23307 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            23308 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            23309 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            23310 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            23311 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            23312 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            23313 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            23314 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            23315 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            23316 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            23317 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            23318 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            23319 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            23320 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            23321 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            23322 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            23323 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            23324 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            23325 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            23326 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            23327 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            23328 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            23329 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            23330 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            23331 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            23332 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            23333 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            23334 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            23335 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            23336 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            23337 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            23338 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            23339 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            23340 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            23341 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            23342 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            23343 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            23344 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            23345 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            23346 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            23347 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            23348 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            23349 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            23350 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            23351 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            23352 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            23353 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            23354 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            23355 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            23356 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            23357 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            23358 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            23359 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            23360 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            23361 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            23362 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            23363 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            23364 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            23365 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            23366 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            23367 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            23368 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            23369 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            23370 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            23371 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            23372 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            23373 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            23374 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            23375 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            23376 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            23377 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            23378 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            23379 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            23380 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            23381 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            23382 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            23383 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            23384 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            23385 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            23386 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            23387 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            23388 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            23389 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            23390 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            23391 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            23392 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            23393 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            23394 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            23395 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            23396 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            23397 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            23398 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            23399 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            23400 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            23401 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            23402 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            23403 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            23404 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            23405 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            23406 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            23407 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            23408 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            23409 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            23410 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            23411 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            23412 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            23413 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            23414 => new SandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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

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
public record PolishedBlackstoneBrickWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock, IWaterlogged, IFaceConnected, IWallConnected {
    private static readonly BlockInfo Data = new("block.minecraft.polished_blackstone_brick_wall", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_blackstone_brick_wall", BlockInfo.VanillaOnly, "minecraft:blocks/polished_blackstone_brick_wall");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 29, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S87, BlockShapes.S132, BlockShapes.S1, BlockShapes.S87, BlockShapes.S132, BlockShapes.S132);
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

    public BlockStateInfo StateInfo => States[StateId - 25689];

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
                                    WallSide.None => 25689,
                                    WallSide.Low => 25690,
                                    WallSide.Tall => 25691,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25692,
                                    WallSide.Low => 25693,
                                    WallSide.Tall => 25694,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25695,
                                    WallSide.Low => 25696,
                                    WallSide.Tall => 25697,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25698,
                                    WallSide.Low => 25699,
                                    WallSide.Tall => 25700,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25701,
                                    WallSide.Low => 25702,
                                    WallSide.Tall => 25703,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25704,
                                    WallSide.Low => 25705,
                                    WallSide.Tall => 25706,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25707,
                                    WallSide.Low => 25708,
                                    WallSide.Tall => 25709,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25710,
                                    WallSide.Low => 25711,
                                    WallSide.Tall => 25712,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25713,
                                    WallSide.Low => 25714,
                                    WallSide.Tall => 25715,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25716,
                                    WallSide.Low => 25717,
                                    WallSide.Tall => 25718,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25719,
                                    WallSide.Low => 25720,
                                    WallSide.Tall => 25721,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25722,
                                    WallSide.Low => 25723,
                                    WallSide.Tall => 25724,
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
                                    WallSide.None => 25725,
                                    WallSide.Low => 25726,
                                    WallSide.Tall => 25727,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25728,
                                    WallSide.Low => 25729,
                                    WallSide.Tall => 25730,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25731,
                                    WallSide.Low => 25732,
                                    WallSide.Tall => 25733,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25734,
                                    WallSide.Low => 25735,
                                    WallSide.Tall => 25736,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25737,
                                    WallSide.Low => 25738,
                                    WallSide.Tall => 25739,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25740,
                                    WallSide.Low => 25741,
                                    WallSide.Tall => 25742,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25743,
                                    WallSide.Low => 25744,
                                    WallSide.Tall => 25745,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25746,
                                    WallSide.Low => 25747,
                                    WallSide.Tall => 25748,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25749,
                                    WallSide.Low => 25750,
                                    WallSide.Tall => 25751,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25752,
                                    WallSide.Low => 25753,
                                    WallSide.Tall => 25754,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25755,
                                    WallSide.Low => 25756,
                                    WallSide.Tall => 25757,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25758,
                                    WallSide.Low => 25759,
                                    WallSide.Tall => 25760,
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
                                    WallSide.None => 25761,
                                    WallSide.Low => 25762,
                                    WallSide.Tall => 25763,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25764,
                                    WallSide.Low => 25765,
                                    WallSide.Tall => 25766,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25767,
                                    WallSide.Low => 25768,
                                    WallSide.Tall => 25769,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25770,
                                    WallSide.Low => 25771,
                                    WallSide.Tall => 25772,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25773,
                                    WallSide.Low => 25774,
                                    WallSide.Tall => 25775,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25776,
                                    WallSide.Low => 25777,
                                    WallSide.Tall => 25778,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25779,
                                    WallSide.Low => 25780,
                                    WallSide.Tall => 25781,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25782,
                                    WallSide.Low => 25783,
                                    WallSide.Tall => 25784,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25785,
                                    WallSide.Low => 25786,
                                    WallSide.Tall => 25787,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25788,
                                    WallSide.Low => 25789,
                                    WallSide.Tall => 25790,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25791,
                                    WallSide.Low => 25792,
                                    WallSide.Tall => 25793,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25794,
                                    WallSide.Low => 25795,
                                    WallSide.Tall => 25796,
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
                                    WallSide.None => 25797,
                                    WallSide.Low => 25798,
                                    WallSide.Tall => 25799,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25800,
                                    WallSide.Low => 25801,
                                    WallSide.Tall => 25802,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25803,
                                    WallSide.Low => 25804,
                                    WallSide.Tall => 25805,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25806,
                                    WallSide.Low => 25807,
                                    WallSide.Tall => 25808,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25809,
                                    WallSide.Low => 25810,
                                    WallSide.Tall => 25811,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25812,
                                    WallSide.Low => 25813,
                                    WallSide.Tall => 25814,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25815,
                                    WallSide.Low => 25816,
                                    WallSide.Tall => 25817,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25818,
                                    WallSide.Low => 25819,
                                    WallSide.Tall => 25820,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25821,
                                    WallSide.Low => 25822,
                                    WallSide.Tall => 25823,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25824,
                                    WallSide.Low => 25825,
                                    WallSide.Tall => 25826,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25827,
                                    WallSide.Low => 25828,
                                    WallSide.Tall => 25829,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25830,
                                    WallSide.Low => 25831,
                                    WallSide.Tall => 25832,
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
                                    WallSide.None => 25833,
                                    WallSide.Low => 25834,
                                    WallSide.Tall => 25835,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25836,
                                    WallSide.Low => 25837,
                                    WallSide.Tall => 25838,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25839,
                                    WallSide.Low => 25840,
                                    WallSide.Tall => 25841,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25842,
                                    WallSide.Low => 25843,
                                    WallSide.Tall => 25844,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25845,
                                    WallSide.Low => 25846,
                                    WallSide.Tall => 25847,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25848,
                                    WallSide.Low => 25849,
                                    WallSide.Tall => 25850,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25851,
                                    WallSide.Low => 25852,
                                    WallSide.Tall => 25853,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25854,
                                    WallSide.Low => 25855,
                                    WallSide.Tall => 25856,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25857,
                                    WallSide.Low => 25858,
                                    WallSide.Tall => 25859,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25860,
                                    WallSide.Low => 25861,
                                    WallSide.Tall => 25862,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25863,
                                    WallSide.Low => 25864,
                                    WallSide.Tall => 25865,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25866,
                                    WallSide.Low => 25867,
                                    WallSide.Tall => 25868,
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
                                    WallSide.None => 25869,
                                    WallSide.Low => 25870,
                                    WallSide.Tall => 25871,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25872,
                                    WallSide.Low => 25873,
                                    WallSide.Tall => 25874,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25875,
                                    WallSide.Low => 25876,
                                    WallSide.Tall => 25877,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25878,
                                    WallSide.Low => 25879,
                                    WallSide.Tall => 25880,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25881,
                                    WallSide.Low => 25882,
                                    WallSide.Tall => 25883,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25884,
                                    WallSide.Low => 25885,
                                    WallSide.Tall => 25886,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25887,
                                    WallSide.Low => 25888,
                                    WallSide.Tall => 25889,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25890,
                                    WallSide.Low => 25891,
                                    WallSide.Tall => 25892,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25893,
                                    WallSide.Low => 25894,
                                    WallSide.Tall => 25895,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25896,
                                    WallSide.Low => 25897,
                                    WallSide.Tall => 25898,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25899,
                                    WallSide.Low => 25900,
                                    WallSide.Tall => 25901,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25902,
                                    WallSide.Low => 25903,
                                    WallSide.Tall => 25904,
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
                                    WallSide.None => 25905,
                                    WallSide.Low => 25906,
                                    WallSide.Tall => 25907,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25908,
                                    WallSide.Low => 25909,
                                    WallSide.Tall => 25910,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25911,
                                    WallSide.Low => 25912,
                                    WallSide.Tall => 25913,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25914,
                                    WallSide.Low => 25915,
                                    WallSide.Tall => 25916,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25917,
                                    WallSide.Low => 25918,
                                    WallSide.Tall => 25919,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25920,
                                    WallSide.Low => 25921,
                                    WallSide.Tall => 25922,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25923,
                                    WallSide.Low => 25924,
                                    WallSide.Tall => 25925,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25926,
                                    WallSide.Low => 25927,
                                    WallSide.Tall => 25928,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25929,
                                    WallSide.Low => 25930,
                                    WallSide.Tall => 25931,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25932,
                                    WallSide.Low => 25933,
                                    WallSide.Tall => 25934,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25935,
                                    WallSide.Low => 25936,
                                    WallSide.Tall => 25937,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25938,
                                    WallSide.Low => 25939,
                                    WallSide.Tall => 25940,
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
                                    WallSide.None => 25941,
                                    WallSide.Low => 25942,
                                    WallSide.Tall => 25943,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25944,
                                    WallSide.Low => 25945,
                                    WallSide.Tall => 25946,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25947,
                                    WallSide.Low => 25948,
                                    WallSide.Tall => 25949,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25950,
                                    WallSide.Low => 25951,
                                    WallSide.Tall => 25952,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25953,
                                    WallSide.Low => 25954,
                                    WallSide.Tall => 25955,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25956,
                                    WallSide.Low => 25957,
                                    WallSide.Tall => 25958,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25959,
                                    WallSide.Low => 25960,
                                    WallSide.Tall => 25961,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25962,
                                    WallSide.Low => 25963,
                                    WallSide.Tall => 25964,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25965,
                                    WallSide.Low => 25966,
                                    WallSide.Tall => 25967,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25968,
                                    WallSide.Low => 25969,
                                    WallSide.Tall => 25970,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25971,
                                    WallSide.Low => 25972,
                                    WallSide.Tall => 25973,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25974,
                                    WallSide.Low => 25975,
                                    WallSide.Tall => 25976,
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
                                    WallSide.None => 25977,
                                    WallSide.Low => 25978,
                                    WallSide.Tall => 25979,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25980,
                                    WallSide.Low => 25981,
                                    WallSide.Tall => 25982,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25983,
                                    WallSide.Low => 25984,
                                    WallSide.Tall => 25985,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25986,
                                    WallSide.Low => 25987,
                                    WallSide.Tall => 25988,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25989,
                                    WallSide.Low => 25990,
                                    WallSide.Tall => 25991,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25992,
                                    WallSide.Low => 25993,
                                    WallSide.Tall => 25994,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 25995,
                                    WallSide.Low => 25996,
                                    WallSide.Tall => 25997,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 25998,
                                    WallSide.Low => 25999,
                                    WallSide.Tall => 26000,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 26001,
                                    WallSide.Low => 26002,
                                    WallSide.Tall => 26003,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 26004,
                                    WallSide.Low => 26005,
                                    WallSide.Tall => 26006,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 26007,
                                    WallSide.Low => 26008,
                                    WallSide.Tall => 26009,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 26010,
                                    WallSide.Low => 26011,
                                    WallSide.Tall => 26012,
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
            25689 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            25690 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            25691 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            25692 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            25693 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            25694 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            25695 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            25696 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            25697 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            25698 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            25699 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            25700 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            25701 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            25702 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            25703 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            25704 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            25705 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            25706 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            25707 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            25708 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            25709 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            25710 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            25711 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            25712 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            25713 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            25714 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            25715 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            25716 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            25717 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            25718 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            25719 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            25720 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            25721 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            25722 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            25723 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            25724 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            25725 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            25726 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            25727 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            25728 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            25729 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            25730 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            25731 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            25732 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            25733 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            25734 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            25735 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            25736 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            25737 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            25738 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            25739 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            25740 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            25741 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            25742 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            25743 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            25744 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            25745 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            25746 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            25747 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            25748 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            25749 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            25750 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            25751 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            25752 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            25753 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            25754 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            25755 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            25756 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            25757 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            25758 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            25759 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            25760 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            25761 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            25762 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            25763 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            25764 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            25765 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            25766 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            25767 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            25768 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            25769 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            25770 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            25771 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            25772 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            25773 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            25774 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            25775 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            25776 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            25777 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            25778 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            25779 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            25780 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            25781 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            25782 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            25783 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            25784 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            25785 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            25786 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            25787 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            25788 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            25789 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            25790 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            25791 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            25792 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            25793 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            25794 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            25795 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            25796 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            25797 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            25798 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            25799 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            25800 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            25801 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            25802 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            25803 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            25804 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            25805 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            25806 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            25807 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            25808 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            25809 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            25810 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            25811 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            25812 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            25813 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            25814 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            25815 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            25816 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            25817 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            25818 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            25819 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            25820 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            25821 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            25822 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            25823 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            25824 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            25825 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            25826 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            25827 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            25828 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            25829 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            25830 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            25831 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            25832 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            25833 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            25834 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            25835 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            25836 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            25837 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            25838 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            25839 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            25840 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            25841 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            25842 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            25843 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            25844 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            25845 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            25846 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            25847 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            25848 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            25849 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            25850 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            25851 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            25852 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            25853 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            25854 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            25855 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            25856 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            25857 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            25858 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            25859 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            25860 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            25861 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            25862 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            25863 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            25864 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            25865 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            25866 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            25867 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            25868 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            25869 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            25870 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            25871 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            25872 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            25873 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            25874 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            25875 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            25876 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            25877 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            25878 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            25879 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            25880 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            25881 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            25882 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            25883 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            25884 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            25885 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            25886 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            25887 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            25888 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            25889 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            25890 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            25891 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            25892 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            25893 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            25894 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            25895 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            25896 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            25897 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            25898 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            25899 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            25900 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            25901 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            25902 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            25903 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            25904 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            25905 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            25906 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            25907 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            25908 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            25909 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            25910 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            25911 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            25912 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            25913 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            25914 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            25915 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            25916 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            25917 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            25918 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            25919 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            25920 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            25921 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            25922 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            25923 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            25924 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            25925 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            25926 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            25927 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            25928 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            25929 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            25930 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            25931 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            25932 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            25933 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            25934 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            25935 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            25936 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            25937 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            25938 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            25939 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            25940 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            25941 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            25942 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            25943 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            25944 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            25945 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            25946 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            25947 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            25948 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            25949 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            25950 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            25951 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            25952 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            25953 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            25954 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            25955 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            25956 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            25957 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            25958 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            25959 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            25960 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            25961 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            25962 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            25963 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            25964 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            25965 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            25966 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            25967 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            25968 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            25969 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            25970 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            25971 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            25972 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            25973 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            25974 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            25975 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            25976 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            25977 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            25978 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            25979 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            25980 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            25981 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            25982 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            25983 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            25984 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            25985 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            25986 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            25987 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            25988 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            25989 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            25990 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            25991 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            25992 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            25993 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            25994 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            25995 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            25996 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            25997 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            25998 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            25999 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            26000 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            26001 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            26002 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            26003 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            26004 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            26005 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            26006 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            26007 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            26008 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            26009 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            26010 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            26011 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            26012 => new PolishedBlackstoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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

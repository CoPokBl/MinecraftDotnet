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
public record PaleMossCarpetBlock(Identifier Identifier, bool Bottom, WallSide East, WallSide North, WallSide South, WallSide West) : IBlock, IBottomed, IWallConnected {
    private static readonly BlockInfo Data = new("minecraft:mossy_carpet", "block.minecraft.pale_moss_carpet", 0.1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pale_moss_carpet", BlockInfo.VanillaOnly, "minecraft:blocks/pale_moss_carpet");
    private static readonly BlockStateInfo I0 = new(0.1f, 0, 0, PushReaction.Destroy, 22, "moss_carpet", NoteBlockInstrument.Harp, true, false, false, false, true, false, false, false, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S371, BlockShapes.S371, BlockShapes.S1, BlockShapes.S1, BlockShapes.S371, BlockShapes.S371);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S659 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S591 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S660 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S661 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S662 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S588 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S663 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S587 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S664 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S665 };
    private static readonly BlockStateInfo I11 = I0 with { BlockShape = BlockShapes.S666 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S667 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S668 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S669 };
    private static readonly BlockStateInfo I15 = I0 with { BlockShape = BlockShapes.S670 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S671 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S672 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S584 };
    private static readonly BlockStateInfo I19 = I0 with { BlockShape = BlockShapes.S673 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S583 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S674 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S675 };
    private static readonly BlockStateInfo I23 = I0 with { BlockShape = BlockShapes.S676 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S580 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S677 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S579 };
    private static readonly BlockStateInfo I27 = I0 with { BlockShape = BlockShapes.S678 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S679 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S680 };
    private static readonly BlockStateInfo I30 = I0 with { BlockShape = BlockShapes.S681 };
    private static readonly BlockStateInfo I31 = I0 with { BlockShape = BlockShapes.S682 };
    private static readonly BlockStateInfo I32 = I0 with { BlockShape = BlockShapes.S683 };
    private static readonly BlockStateInfo I33 = I0 with { BlockShape = BlockShapes.S684 };
    private static readonly BlockStateInfo I34 = I0 with { BlockShape = BlockShapes.S685 };
    private static readonly BlockStateInfo I35 = I0 with { BlockShape = BlockShapes.S686 };
    private static readonly BlockStateInfo I36 = I0 with { BlockShape = BlockShapes.S687 };
    private static readonly BlockStateInfo I37 = I0 with { BlockShape = BlockShapes.S688 };
    private static readonly BlockStateInfo I38 = I0 with { BlockShape = BlockShapes.S689 };
    private static readonly BlockStateInfo I39 = I0 with { BlockShape = BlockShapes.S690 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S691 };
    private static readonly BlockStateInfo I41 = I0 with { BlockShape = BlockShapes.S692 };
    private static readonly BlockStateInfo I42 = I0 with { BlockShape = BlockShapes.S693 };
    private static readonly BlockStateInfo I43 = I0 with { BlockShape = BlockShapes.S694 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S695 };
    private static readonly BlockStateInfo I45 = I0 with { BlockShape = BlockShapes.S696 };
    private static readonly BlockStateInfo I46 = I0 with { BlockShape = BlockShapes.S697 };
    private static readonly BlockStateInfo I47 = I0 with { BlockShape = BlockShapes.S698 };
    private static readonly BlockStateInfo I48 = I0 with { BlockShape = BlockShapes.S699 };
    private static readonly BlockStateInfo I49 = I0 with { BlockShape = BlockShapes.S700 };
    private static readonly BlockStateInfo I50 = I0 with { BlockShape = BlockShapes.S701 };
    private static readonly BlockStateInfo I51 = I0 with { BlockShape = BlockShapes.S702 };
    private static readonly BlockStateInfo I52 = I0 with { BlockShape = BlockShapes.S703 };
    private static readonly BlockStateInfo I53 = I0 with { BlockShape = BlockShapes.S704 };
    private static readonly BlockStateInfo I54 = I0 with { BlockShape = BlockShapes.S576 };
    private static readonly BlockStateInfo I55 = I0 with { BlockShape = BlockShapes.S705 };
    private static readonly BlockStateInfo I56 = I0 with { BlockShape = BlockShapes.S575 };
    private static readonly BlockStateInfo I57 = I0 with { BlockShape = BlockShapes.S706 };
    private static readonly BlockStateInfo I58 = I0 with { BlockShape = BlockShapes.S707 };
    private static readonly BlockStateInfo I59 = I0 with { BlockShape = BlockShapes.S708 };
    private static readonly BlockStateInfo I60 = I0 with { BlockShape = BlockShapes.S572 };
    private static readonly BlockStateInfo I61 = I0 with { BlockShape = BlockShapes.S709 };
    private static readonly BlockStateInfo I62 = I0 with { BlockShape = BlockShapes.S571 };
    private static readonly BlockStateInfo I63 = I0 with { BlockShape = BlockShapes.S710 };
    private static readonly BlockStateInfo I64 = I0 with { BlockShape = BlockShapes.S711 };
    private static readonly BlockStateInfo I65 = I0 with { BlockShape = BlockShapes.S712 };
    private static readonly BlockStateInfo I66 = I0 with { BlockShape = BlockShapes.S713 };
    private static readonly BlockStateInfo I67 = I0 with { BlockShape = BlockShapes.S714 };
    private static readonly BlockStateInfo I68 = I0 with { BlockShape = BlockShapes.S715 };
    private static readonly BlockStateInfo I69 = I0 with { BlockShape = BlockShapes.S716 };
    private static readonly BlockStateInfo I70 = I0 with { BlockShape = BlockShapes.S717 };
    private static readonly BlockStateInfo I71 = I0 with { BlockShape = BlockShapes.S718 };
    private static readonly BlockStateInfo I72 = I0 with { BlockShape = BlockShapes.S568 };
    private static readonly BlockStateInfo I73 = I0 with { BlockShape = BlockShapes.S719 };
    private static readonly BlockStateInfo I74 = I0 with { BlockShape = BlockShapes.S567 };
    private static readonly BlockStateInfo I75 = I0 with { BlockShape = BlockShapes.S720 };
    private static readonly BlockStateInfo I76 = I0 with { BlockShape = BlockShapes.S721 };
    private static readonly BlockStateInfo I77 = I0 with { BlockShape = BlockShapes.S722 };
    private static readonly BlockStateInfo I78 = I0 with { BlockShape = BlockShapes.S564 };
    private static readonly BlockStateInfo I79 = I0 with { BlockShape = BlockShapes.S723 };
    private static readonly BlockStateInfo I80 = I0 with { BlockShape = BlockShapes.S563 };
    private static readonly BlockStateInfo I81 = I0 with { BlockShape = BlockShapes.S79, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I82 = I0 with { BlockShape = BlockShapes.S724, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I83 = I0 with { BlockShape = BlockShapes.S559, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I84 = I0 with { BlockShape = BlockShapes.S725, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I85 = I0 with { BlockShape = BlockShapes.S726, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I86 = I0 with { BlockShape = BlockShapes.S727, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I87 = I0 with { BlockShape = BlockShapes.S556, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I88 = I0 with { BlockShape = BlockShapes.S728, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I89 = I0 with { BlockShape = BlockShapes.S555, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I90 = I0 with { BlockShape = BlockShapes.S729, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I91 = I0 with { BlockShape = BlockShapes.S730, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I92 = I0 with { BlockShape = BlockShapes.S731, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I93 = I0 with { BlockShape = BlockShapes.S732, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I94 = I0 with { BlockShape = BlockShapes.S733, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I95 = I0 with { BlockShape = BlockShapes.S734, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I96 = I0 with { BlockShape = BlockShapes.S735, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I97 = I0 with { BlockShape = BlockShapes.S736, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I98 = I0 with { BlockShape = BlockShapes.S737, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I99 = I0 with { BlockShape = BlockShapes.S552, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I100 = I0 with { BlockShape = BlockShapes.S738, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I101 = I0 with { BlockShape = BlockShapes.S551, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I102 = I0 with { BlockShape = BlockShapes.S739, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I103 = I0 with { BlockShape = BlockShapes.S740, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I104 = I0 with { BlockShape = BlockShapes.S741, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I105 = I0 with { BlockShape = BlockShapes.S548, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I106 = I0 with { BlockShape = BlockShapes.S742, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I107 = I0 with { BlockShape = BlockShapes.S547, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I108 = I0 with { BlockShape = BlockShapes.S743, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I109 = I0 with { BlockShape = BlockShapes.S744, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I110 = I0 with { BlockShape = BlockShapes.S745, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I111 = I0 with { BlockShape = BlockShapes.S746, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I112 = I0 with { BlockShape = BlockShapes.S747, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I113 = I0 with { BlockShape = BlockShapes.S748, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I114 = I0 with { BlockShape = BlockShapes.S749, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I115 = I0 with { BlockShape = BlockShapes.S750, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I116 = I0 with { BlockShape = BlockShapes.S751, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I117 = I0 with { BlockShape = BlockShapes.S752, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I118 = I0 with { BlockShape = BlockShapes.S753, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I119 = I0 with { BlockShape = BlockShapes.S754, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I120 = I0 with { BlockShape = BlockShapes.S755, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I121 = I0 with { BlockShape = BlockShapes.S756, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I122 = I0 with { BlockShape = BlockShapes.S757, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I123 = I0 with { BlockShape = BlockShapes.S758, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I124 = I0 with { BlockShape = BlockShapes.S759, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I125 = I0 with { BlockShape = BlockShapes.S760, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I126 = I0 with { BlockShape = BlockShapes.S761, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I127 = I0 with { BlockShape = BlockShapes.S762, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I128 = I0 with { BlockShape = BlockShapes.S763, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I129 = I0 with { BlockShape = BlockShapes.S764, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I130 = I0 with { BlockShape = BlockShapes.S765, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I131 = I0 with { BlockShape = BlockShapes.S766, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I132 = I0 with { BlockShape = BlockShapes.S767, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I133 = I0 with { BlockShape = BlockShapes.S768, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I134 = I0 with { BlockShape = BlockShapes.S769, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I135 = I0 with { BlockShape = BlockShapes.S544, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I136 = I0 with { BlockShape = BlockShapes.S770, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I137 = I0 with { BlockShape = BlockShapes.S543, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I138 = I0 with { BlockShape = BlockShapes.S771, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I139 = I0 with { BlockShape = BlockShapes.S772, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I140 = I0 with { BlockShape = BlockShapes.S773, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I141 = I0 with { BlockShape = BlockShapes.S540, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I142 = I0 with { BlockShape = BlockShapes.S774, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I143 = I0 with { BlockShape = BlockShapes.S539, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I144 = I0 with { BlockShape = BlockShapes.S775, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I145 = I0 with { BlockShape = BlockShapes.S776, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I146 = I0 with { BlockShape = BlockShapes.S777, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I147 = I0 with { BlockShape = BlockShapes.S778, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I148 = I0 with { BlockShape = BlockShapes.S779, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I149 = I0 with { BlockShape = BlockShapes.S780, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I150 = I0 with { BlockShape = BlockShapes.S781, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I151 = I0 with { BlockShape = BlockShapes.S782, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I152 = I0 with { BlockShape = BlockShapes.S783, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I153 = I0 with { BlockShape = BlockShapes.S536, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I154 = I0 with { BlockShape = BlockShapes.S784, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I155 = I0 with { BlockShape = BlockShapes.S535, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I156 = I0 with { BlockShape = BlockShapes.S785, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I157 = I0 with { BlockShape = BlockShapes.S786, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I158 = I0 with { BlockShape = BlockShapes.S787, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I159 = I0 with { BlockShape = BlockShapes.S532, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I160 = I0 with { BlockShape = BlockShapes.S788, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I161 = I0 with { BlockShape = BlockShapes.S531, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I42, I43, I44, I45, I46, I47, I48, I49, I50, I51, I52, I53, I54, I55, I56, I57, I58, I59, I60, I61, I62, I63, I64, I65, I66, I67, I68, I69, I70, I71, I72, I73, I74, I75, I76, I77, I78, I79, I80, I81, I82, I83, I84, I85, I86, I87, I88, I89, I90, I91, I92, I93, I94, I95, I96, I97, I98, I99, I100, I101, I102, I103, I104, I105, I106, I107, I108, I109, I110, I111, I112, I113, I114, I115, I116, I117, I118, I119, I120, I121, I122, I123, I124, I125, I126, I127, I128, I129, I130, I131, I132, I133, I134, I135, I136, I137, I138, I139, I140, I141, I142, I143, I144, I145, I146, I147, I148, I149, I150, I151, I152, I153, I154, I155, I156, I157, I158, I159, I160, I161
    ];

    public BlockStateInfo StateInfo => States[StateId - 32197];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithBottom(bool bottom) => this with { Bottom = bottom };

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
            return Bottom switch {
                true => East switch {
                    WallSide.None => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32197,
                                WallSide.Low => 32198,
                                WallSide.Tall => 32199,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32200,
                                WallSide.Low => 32201,
                                WallSide.Tall => 32202,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32203,
                                WallSide.Low => 32204,
                                WallSide.Tall => 32205,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32206,
                                WallSide.Low => 32207,
                                WallSide.Tall => 32208,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32209,
                                WallSide.Low => 32210,
                                WallSide.Tall => 32211,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32212,
                                WallSide.Low => 32213,
                                WallSide.Tall => 32214,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32215,
                                WallSide.Low => 32216,
                                WallSide.Tall => 32217,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32218,
                                WallSide.Low => 32219,
                                WallSide.Tall => 32220,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32221,
                                WallSide.Low => 32222,
                                WallSide.Tall => 32223,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Low => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32224,
                                WallSide.Low => 32225,
                                WallSide.Tall => 32226,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32227,
                                WallSide.Low => 32228,
                                WallSide.Tall => 32229,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32230,
                                WallSide.Low => 32231,
                                WallSide.Tall => 32232,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32233,
                                WallSide.Low => 32234,
                                WallSide.Tall => 32235,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32236,
                                WallSide.Low => 32237,
                                WallSide.Tall => 32238,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32239,
                                WallSide.Low => 32240,
                                WallSide.Tall => 32241,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32242,
                                WallSide.Low => 32243,
                                WallSide.Tall => 32244,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32245,
                                WallSide.Low => 32246,
                                WallSide.Tall => 32247,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32248,
                                WallSide.Low => 32249,
                                WallSide.Tall => 32250,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Tall => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32251,
                                WallSide.Low => 32252,
                                WallSide.Tall => 32253,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32254,
                                WallSide.Low => 32255,
                                WallSide.Tall => 32256,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32257,
                                WallSide.Low => 32258,
                                WallSide.Tall => 32259,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32260,
                                WallSide.Low => 32261,
                                WallSide.Tall => 32262,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32263,
                                WallSide.Low => 32264,
                                WallSide.Tall => 32265,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32266,
                                WallSide.Low => 32267,
                                WallSide.Tall => 32268,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32269,
                                WallSide.Low => 32270,
                                WallSide.Tall => 32271,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32272,
                                WallSide.Low => 32273,
                                WallSide.Tall => 32274,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32275,
                                WallSide.Low => 32276,
                                WallSide.Tall => 32277,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
                },
                false => East switch {
                    WallSide.None => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32278,
                                WallSide.Low => 32279,
                                WallSide.Tall => 32280,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32281,
                                WallSide.Low => 32282,
                                WallSide.Tall => 32283,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32284,
                                WallSide.Low => 32285,
                                WallSide.Tall => 32286,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32287,
                                WallSide.Low => 32288,
                                WallSide.Tall => 32289,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32290,
                                WallSide.Low => 32291,
                                WallSide.Tall => 32292,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32293,
                                WallSide.Low => 32294,
                                WallSide.Tall => 32295,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32296,
                                WallSide.Low => 32297,
                                WallSide.Tall => 32298,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32299,
                                WallSide.Low => 32300,
                                WallSide.Tall => 32301,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32302,
                                WallSide.Low => 32303,
                                WallSide.Tall => 32304,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Low => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32305,
                                WallSide.Low => 32306,
                                WallSide.Tall => 32307,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32308,
                                WallSide.Low => 32309,
                                WallSide.Tall => 32310,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32311,
                                WallSide.Low => 32312,
                                WallSide.Tall => 32313,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32314,
                                WallSide.Low => 32315,
                                WallSide.Tall => 32316,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32317,
                                WallSide.Low => 32318,
                                WallSide.Tall => 32319,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32320,
                                WallSide.Low => 32321,
                                WallSide.Tall => 32322,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32323,
                                WallSide.Low => 32324,
                                WallSide.Tall => 32325,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32326,
                                WallSide.Low => 32327,
                                WallSide.Tall => 32328,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32329,
                                WallSide.Low => 32330,
                                WallSide.Tall => 32331,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Tall => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32332,
                                WallSide.Low => 32333,
                                WallSide.Tall => 32334,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32335,
                                WallSide.Low => 32336,
                                WallSide.Tall => 32337,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32338,
                                WallSide.Low => 32339,
                                WallSide.Tall => 32340,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32341,
                                WallSide.Low => 32342,
                                WallSide.Tall => 32343,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32344,
                                WallSide.Low => 32345,
                                WallSide.Tall => 32346,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32347,
                                WallSide.Low => 32348,
                                WallSide.Tall => 32349,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32350,
                                WallSide.Low => 32351,
                                WallSide.Tall => 32352,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32353,
                                WallSide.Low => 32354,
                                WallSide.Tall => 32355,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32356,
                                WallSide.Low => 32357,
                                WallSide.Tall => 32358,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            32197 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.None),
            32198 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.Low),
            32199 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.Tall),
            32200 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.None),
            32201 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.Low),
            32202 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.Tall),
            32203 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.None),
            32204 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Low),
            32205 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Tall),
            32206 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.None),
            32207 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.Low),
            32208 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.Tall),
            32209 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.None),
            32210 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Low),
            32211 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Tall),
            32212 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.None),
            32213 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Low),
            32214 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32215 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.None),
            32216 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Low),
            32217 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Tall),
            32218 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.None),
            32219 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Low),
            32220 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32221 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.None),
            32222 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32223 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            32224 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.None),
            32225 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.Low),
            32226 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.Tall),
            32227 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.None),
            32228 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Low),
            32229 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Tall),
            32230 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.None),
            32231 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Low),
            32232 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Tall),
            32233 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.None),
            32234 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Low),
            32235 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Tall),
            32236 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.None),
            32237 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Low),
            32238 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Tall),
            32239 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.None),
            32240 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Low),
            32241 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32242 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.None),
            32243 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Low),
            32244 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Tall),
            32245 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.None),
            32246 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Low),
            32247 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32248 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.None),
            32249 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32250 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            32251 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.None),
            32252 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Low),
            32253 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Tall),
            32254 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.None),
            32255 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Low),
            32256 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Tall),
            32257 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.None),
            32258 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Low),
            32259 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Tall),
            32260 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.None),
            32261 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Low),
            32262 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Tall),
            32263 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.None),
            32264 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Low),
            32265 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Tall),
            32266 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.None),
            32267 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Low),
            32268 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32269 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.None),
            32270 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Low),
            32271 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Tall),
            32272 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.None),
            32273 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Low),
            32274 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32275 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.None),
            32276 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32277 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            32278 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.None),
            32279 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.Low),
            32280 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.Tall),
            32281 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.None),
            32282 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.Low),
            32283 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.Tall),
            32284 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.None),
            32285 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Low),
            32286 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Tall),
            32287 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.None),
            32288 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.Low),
            32289 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.Tall),
            32290 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.None),
            32291 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Low),
            32292 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Tall),
            32293 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.None),
            32294 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Low),
            32295 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32296 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.None),
            32297 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Low),
            32298 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Tall),
            32299 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.None),
            32300 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Low),
            32301 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32302 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.None),
            32303 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32304 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            32305 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.None),
            32306 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.Low),
            32307 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.Tall),
            32308 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.None),
            32309 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Low),
            32310 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Tall),
            32311 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.None),
            32312 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Low),
            32313 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Tall),
            32314 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.None),
            32315 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Low),
            32316 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Tall),
            32317 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.None),
            32318 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Low),
            32319 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Tall),
            32320 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.None),
            32321 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Low),
            32322 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32323 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.None),
            32324 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Low),
            32325 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Tall),
            32326 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.None),
            32327 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Low),
            32328 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32329 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.None),
            32330 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32331 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            32332 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.None),
            32333 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Low),
            32334 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Tall),
            32335 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.None),
            32336 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Low),
            32337 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Tall),
            32338 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.None),
            32339 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Low),
            32340 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Tall),
            32341 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.None),
            32342 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Low),
            32343 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Tall),
            32344 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.None),
            32345 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Low),
            32346 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Tall),
            32347 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.None),
            32348 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Low),
            32349 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32350 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.None),
            32351 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Low),
            32352 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Tall),
            32353 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.None),
            32354 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Low),
            32355 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32356 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.None),
            32357 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32358 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bottom = properties.Contains("bottom") ? properties["bottom"].GetString() == "true" : Bottom,
            East = properties.Contains("east") ? WallSideExtensions.FromString(properties["east"].GetString()) : East,
            North = properties.Contains("north") ? WallSideExtensions.FromString(properties["north"].GetString()) : North,
            South = properties.Contains("south") ? WallSideExtensions.FromString(properties["south"].GetString()) : South,
            West = properties.Contains("west") ? WallSideExtensions.FromString(properties["west"].GetString()) : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("bottom", new StringTag(Bottom.ToString().ToLower())),
            ("east", new StringTag(East.ToName())),
            ("north", new StringTag(North.ToName())),
            ("south", new StringTag(South.ToName())),
            ("west", new StringTag(West.ToName()))
        );
    }
    
}

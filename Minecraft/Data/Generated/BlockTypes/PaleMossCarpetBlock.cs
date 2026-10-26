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
    private static readonly BlockInfo Data = new("block.minecraft.pale_moss_carpet", 0.1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pale_moss_carpet", BlockInfo.VanillaOnly, "minecraft:blocks/pale_moss_carpet");
    private static readonly BlockStateInfo I0 = new(0.1f, 0, 0, PushReaction.Popped, 22, "moss_carpet", NoteBlockInstrument.Harp, true, false, false, true, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S371, BlockShapes.S371, BlockShapes.S1, BlockShapes.S1, BlockShapes.S371, BlockShapes.S371);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S660 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S592 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S661 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S662 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S663 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S589 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S664 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S588 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S665 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S666 };
    private static readonly BlockStateInfo I11 = I0 with { BlockShape = BlockShapes.S667 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S668 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S669 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S670 };
    private static readonly BlockStateInfo I15 = I0 with { BlockShape = BlockShapes.S671 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S672 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S673 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S585 };
    private static readonly BlockStateInfo I19 = I0 with { BlockShape = BlockShapes.S674 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S584 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S675 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S676 };
    private static readonly BlockStateInfo I23 = I0 with { BlockShape = BlockShapes.S677 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S581 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S678 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S580 };
    private static readonly BlockStateInfo I27 = I0 with { BlockShape = BlockShapes.S679 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S680 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S681 };
    private static readonly BlockStateInfo I30 = I0 with { BlockShape = BlockShapes.S682 };
    private static readonly BlockStateInfo I31 = I0 with { BlockShape = BlockShapes.S683 };
    private static readonly BlockStateInfo I32 = I0 with { BlockShape = BlockShapes.S684 };
    private static readonly BlockStateInfo I33 = I0 with { BlockShape = BlockShapes.S685 };
    private static readonly BlockStateInfo I34 = I0 with { BlockShape = BlockShapes.S686 };
    private static readonly BlockStateInfo I35 = I0 with { BlockShape = BlockShapes.S687 };
    private static readonly BlockStateInfo I36 = I0 with { BlockShape = BlockShapes.S688 };
    private static readonly BlockStateInfo I37 = I0 with { BlockShape = BlockShapes.S689 };
    private static readonly BlockStateInfo I38 = I0 with { BlockShape = BlockShapes.S690 };
    private static readonly BlockStateInfo I39 = I0 with { BlockShape = BlockShapes.S691 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S692 };
    private static readonly BlockStateInfo I41 = I0 with { BlockShape = BlockShapes.S693 };
    private static readonly BlockStateInfo I42 = I0 with { BlockShape = BlockShapes.S694 };
    private static readonly BlockStateInfo I43 = I0 with { BlockShape = BlockShapes.S695 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S696 };
    private static readonly BlockStateInfo I45 = I0 with { BlockShape = BlockShapes.S697 };
    private static readonly BlockStateInfo I46 = I0 with { BlockShape = BlockShapes.S698 };
    private static readonly BlockStateInfo I47 = I0 with { BlockShape = BlockShapes.S699 };
    private static readonly BlockStateInfo I48 = I0 with { BlockShape = BlockShapes.S700 };
    private static readonly BlockStateInfo I49 = I0 with { BlockShape = BlockShapes.S701 };
    private static readonly BlockStateInfo I50 = I0 with { BlockShape = BlockShapes.S702 };
    private static readonly BlockStateInfo I51 = I0 with { BlockShape = BlockShapes.S703 };
    private static readonly BlockStateInfo I52 = I0 with { BlockShape = BlockShapes.S704 };
    private static readonly BlockStateInfo I53 = I0 with { BlockShape = BlockShapes.S705 };
    private static readonly BlockStateInfo I54 = I0 with { BlockShape = BlockShapes.S577 };
    private static readonly BlockStateInfo I55 = I0 with { BlockShape = BlockShapes.S706 };
    private static readonly BlockStateInfo I56 = I0 with { BlockShape = BlockShapes.S576 };
    private static readonly BlockStateInfo I57 = I0 with { BlockShape = BlockShapes.S707 };
    private static readonly BlockStateInfo I58 = I0 with { BlockShape = BlockShapes.S708 };
    private static readonly BlockStateInfo I59 = I0 with { BlockShape = BlockShapes.S709 };
    private static readonly BlockStateInfo I60 = I0 with { BlockShape = BlockShapes.S573 };
    private static readonly BlockStateInfo I61 = I0 with { BlockShape = BlockShapes.S710 };
    private static readonly BlockStateInfo I62 = I0 with { BlockShape = BlockShapes.S572 };
    private static readonly BlockStateInfo I63 = I0 with { BlockShape = BlockShapes.S711 };
    private static readonly BlockStateInfo I64 = I0 with { BlockShape = BlockShapes.S712 };
    private static readonly BlockStateInfo I65 = I0 with { BlockShape = BlockShapes.S713 };
    private static readonly BlockStateInfo I66 = I0 with { BlockShape = BlockShapes.S714 };
    private static readonly BlockStateInfo I67 = I0 with { BlockShape = BlockShapes.S715 };
    private static readonly BlockStateInfo I68 = I0 with { BlockShape = BlockShapes.S716 };
    private static readonly BlockStateInfo I69 = I0 with { BlockShape = BlockShapes.S717 };
    private static readonly BlockStateInfo I70 = I0 with { BlockShape = BlockShapes.S718 };
    private static readonly BlockStateInfo I71 = I0 with { BlockShape = BlockShapes.S719 };
    private static readonly BlockStateInfo I72 = I0 with { BlockShape = BlockShapes.S569 };
    private static readonly BlockStateInfo I73 = I0 with { BlockShape = BlockShapes.S720 };
    private static readonly BlockStateInfo I74 = I0 with { BlockShape = BlockShapes.S568 };
    private static readonly BlockStateInfo I75 = I0 with { BlockShape = BlockShapes.S721 };
    private static readonly BlockStateInfo I76 = I0 with { BlockShape = BlockShapes.S722 };
    private static readonly BlockStateInfo I77 = I0 with { BlockShape = BlockShapes.S723 };
    private static readonly BlockStateInfo I78 = I0 with { BlockShape = BlockShapes.S565 };
    private static readonly BlockStateInfo I79 = I0 with { BlockShape = BlockShapes.S724 };
    private static readonly BlockStateInfo I80 = I0 with { BlockShape = BlockShapes.S564 };
    private static readonly BlockStateInfo I81 = I0 with { BlockShape = BlockShapes.S79, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I82 = I0 with { BlockShape = BlockShapes.S725, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I83 = I0 with { BlockShape = BlockShapes.S560, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I84 = I0 with { BlockShape = BlockShapes.S726, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I85 = I0 with { BlockShape = BlockShapes.S727, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I86 = I0 with { BlockShape = BlockShapes.S728, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I87 = I0 with { BlockShape = BlockShapes.S557, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I88 = I0 with { BlockShape = BlockShapes.S729, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I89 = I0 with { BlockShape = BlockShapes.S556, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I90 = I0 with { BlockShape = BlockShapes.S730, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I91 = I0 with { BlockShape = BlockShapes.S731, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I92 = I0 with { BlockShape = BlockShapes.S732, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I93 = I0 with { BlockShape = BlockShapes.S733, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I94 = I0 with { BlockShape = BlockShapes.S734, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I95 = I0 with { BlockShape = BlockShapes.S735, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I96 = I0 with { BlockShape = BlockShapes.S736, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I97 = I0 with { BlockShape = BlockShapes.S737, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I98 = I0 with { BlockShape = BlockShapes.S738, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I99 = I0 with { BlockShape = BlockShapes.S553, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I100 = I0 with { BlockShape = BlockShapes.S739, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I101 = I0 with { BlockShape = BlockShapes.S552, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I102 = I0 with { BlockShape = BlockShapes.S740, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I103 = I0 with { BlockShape = BlockShapes.S741, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I104 = I0 with { BlockShape = BlockShapes.S742, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I105 = I0 with { BlockShape = BlockShapes.S549, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I106 = I0 with { BlockShape = BlockShapes.S743, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I107 = I0 with { BlockShape = BlockShapes.S548, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I108 = I0 with { BlockShape = BlockShapes.S744, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I109 = I0 with { BlockShape = BlockShapes.S745, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I110 = I0 with { BlockShape = BlockShapes.S746, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I111 = I0 with { BlockShape = BlockShapes.S747, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I112 = I0 with { BlockShape = BlockShapes.S748, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I113 = I0 with { BlockShape = BlockShapes.S749, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I114 = I0 with { BlockShape = BlockShapes.S750, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I115 = I0 with { BlockShape = BlockShapes.S751, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I116 = I0 with { BlockShape = BlockShapes.S752, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I117 = I0 with { BlockShape = BlockShapes.S753, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I118 = I0 with { BlockShape = BlockShapes.S754, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I119 = I0 with { BlockShape = BlockShapes.S755, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I120 = I0 with { BlockShape = BlockShapes.S756, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I121 = I0 with { BlockShape = BlockShapes.S757, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I122 = I0 with { BlockShape = BlockShapes.S758, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I123 = I0 with { BlockShape = BlockShapes.S759, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I124 = I0 with { BlockShape = BlockShapes.S760, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I125 = I0 with { BlockShape = BlockShapes.S761, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I126 = I0 with { BlockShape = BlockShapes.S762, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I127 = I0 with { BlockShape = BlockShapes.S763, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I128 = I0 with { BlockShape = BlockShapes.S764, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I129 = I0 with { BlockShape = BlockShapes.S765, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I130 = I0 with { BlockShape = BlockShapes.S766, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I131 = I0 with { BlockShape = BlockShapes.S767, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I132 = I0 with { BlockShape = BlockShapes.S768, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I133 = I0 with { BlockShape = BlockShapes.S769, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I134 = I0 with { BlockShape = BlockShapes.S770, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I135 = I0 with { BlockShape = BlockShapes.S545, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I136 = I0 with { BlockShape = BlockShapes.S771, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I137 = I0 with { BlockShape = BlockShapes.S544, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I138 = I0 with { BlockShape = BlockShapes.S772, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I139 = I0 with { BlockShape = BlockShapes.S773, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I140 = I0 with { BlockShape = BlockShapes.S774, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I141 = I0 with { BlockShape = BlockShapes.S541, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I142 = I0 with { BlockShape = BlockShapes.S775, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I143 = I0 with { BlockShape = BlockShapes.S540, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I144 = I0 with { BlockShape = BlockShapes.S776, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I145 = I0 with { BlockShape = BlockShapes.S777, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I146 = I0 with { BlockShape = BlockShapes.S778, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I147 = I0 with { BlockShape = BlockShapes.S779, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I148 = I0 with { BlockShape = BlockShapes.S780, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I149 = I0 with { BlockShape = BlockShapes.S781, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I150 = I0 with { BlockShape = BlockShapes.S782, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I151 = I0 with { BlockShape = BlockShapes.S783, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I152 = I0 with { BlockShape = BlockShapes.S784, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I153 = I0 with { BlockShape = BlockShapes.S537, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I154 = I0 with { BlockShape = BlockShapes.S785, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I155 = I0 with { BlockShape = BlockShapes.S536, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I156 = I0 with { BlockShape = BlockShapes.S786, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I157 = I0 with { BlockShape = BlockShapes.S787, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I158 = I0 with { BlockShape = BlockShapes.S788, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I159 = I0 with { BlockShape = BlockShapes.S533, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I160 = I0 with { BlockShape = BlockShapes.S789, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I161 = I0 with { BlockShape = BlockShapes.S532, CollisionShape = BlockShapes.S1, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I42, I43, I44, I45, I46, I47, I48, I49, I50, I51, I52, I53, I54, I55, I56, I57, I58, I59, I60, I61, I62, I63, I64, I65, I66, I67, I68, I69, I70, I71, I72, I73, I74, I75, I76, I77, I78, I79, I80, I81, I82, I83, I84, I85, I86, I87, I88, I89, I90, I91, I92, I93, I94, I95, I96, I97, I98, I99, I100, I101, I102, I103, I104, I105, I106, I107, I108, I109, I110, I111, I112, I113, I114, I115, I116, I117, I118, I119, I120, I121, I122, I123, I124, I125, I126, I127, I128, I129, I130, I131, I132, I133, I134, I135, I136, I137, I138, I139, I140, I141, I142, I143, I144, I145, I146, I147, I148, I149, I150, I151, I152, I153, I154, I155, I156, I157, I158, I159, I160, I161
    ];

    public BlockStateInfo StateInfo => States[StateId - 35554];

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
                                WallSide.None => 35554,
                                WallSide.Low => 35555,
                                WallSide.Tall => 35556,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35557,
                                WallSide.Low => 35558,
                                WallSide.Tall => 35559,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35560,
                                WallSide.Low => 35561,
                                WallSide.Tall => 35562,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35563,
                                WallSide.Low => 35564,
                                WallSide.Tall => 35565,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35566,
                                WallSide.Low => 35567,
                                WallSide.Tall => 35568,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35569,
                                WallSide.Low => 35570,
                                WallSide.Tall => 35571,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35572,
                                WallSide.Low => 35573,
                                WallSide.Tall => 35574,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35575,
                                WallSide.Low => 35576,
                                WallSide.Tall => 35577,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35578,
                                WallSide.Low => 35579,
                                WallSide.Tall => 35580,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Low => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35581,
                                WallSide.Low => 35582,
                                WallSide.Tall => 35583,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35584,
                                WallSide.Low => 35585,
                                WallSide.Tall => 35586,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35587,
                                WallSide.Low => 35588,
                                WallSide.Tall => 35589,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35590,
                                WallSide.Low => 35591,
                                WallSide.Tall => 35592,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35593,
                                WallSide.Low => 35594,
                                WallSide.Tall => 35595,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35596,
                                WallSide.Low => 35597,
                                WallSide.Tall => 35598,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35599,
                                WallSide.Low => 35600,
                                WallSide.Tall => 35601,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35602,
                                WallSide.Low => 35603,
                                WallSide.Tall => 35604,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35605,
                                WallSide.Low => 35606,
                                WallSide.Tall => 35607,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Tall => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35608,
                                WallSide.Low => 35609,
                                WallSide.Tall => 35610,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35611,
                                WallSide.Low => 35612,
                                WallSide.Tall => 35613,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35614,
                                WallSide.Low => 35615,
                                WallSide.Tall => 35616,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35617,
                                WallSide.Low => 35618,
                                WallSide.Tall => 35619,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35620,
                                WallSide.Low => 35621,
                                WallSide.Tall => 35622,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35623,
                                WallSide.Low => 35624,
                                WallSide.Tall => 35625,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35626,
                                WallSide.Low => 35627,
                                WallSide.Tall => 35628,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35629,
                                WallSide.Low => 35630,
                                WallSide.Tall => 35631,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35632,
                                WallSide.Low => 35633,
                                WallSide.Tall => 35634,
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
                                WallSide.None => 35635,
                                WallSide.Low => 35636,
                                WallSide.Tall => 35637,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35638,
                                WallSide.Low => 35639,
                                WallSide.Tall => 35640,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35641,
                                WallSide.Low => 35642,
                                WallSide.Tall => 35643,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35644,
                                WallSide.Low => 35645,
                                WallSide.Tall => 35646,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35647,
                                WallSide.Low => 35648,
                                WallSide.Tall => 35649,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35650,
                                WallSide.Low => 35651,
                                WallSide.Tall => 35652,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35653,
                                WallSide.Low => 35654,
                                WallSide.Tall => 35655,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35656,
                                WallSide.Low => 35657,
                                WallSide.Tall => 35658,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35659,
                                WallSide.Low => 35660,
                                WallSide.Tall => 35661,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Low => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35662,
                                WallSide.Low => 35663,
                                WallSide.Tall => 35664,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35665,
                                WallSide.Low => 35666,
                                WallSide.Tall => 35667,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35668,
                                WallSide.Low => 35669,
                                WallSide.Tall => 35670,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35671,
                                WallSide.Low => 35672,
                                WallSide.Tall => 35673,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35674,
                                WallSide.Low => 35675,
                                WallSide.Tall => 35676,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35677,
                                WallSide.Low => 35678,
                                WallSide.Tall => 35679,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35680,
                                WallSide.Low => 35681,
                                WallSide.Tall => 35682,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35683,
                                WallSide.Low => 35684,
                                WallSide.Tall => 35685,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35686,
                                WallSide.Low => 35687,
                                WallSide.Tall => 35688,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Tall => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35689,
                                WallSide.Low => 35690,
                                WallSide.Tall => 35691,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35692,
                                WallSide.Low => 35693,
                                WallSide.Tall => 35694,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35695,
                                WallSide.Low => 35696,
                                WallSide.Tall => 35697,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35698,
                                WallSide.Low => 35699,
                                WallSide.Tall => 35700,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35701,
                                WallSide.Low => 35702,
                                WallSide.Tall => 35703,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35704,
                                WallSide.Low => 35705,
                                WallSide.Tall => 35706,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 35707,
                                WallSide.Low => 35708,
                                WallSide.Tall => 35709,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 35710,
                                WallSide.Low => 35711,
                                WallSide.Tall => 35712,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 35713,
                                WallSide.Low => 35714,
                                WallSide.Tall => 35715,
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
            35554 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.None),
            35555 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.Low),
            35556 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.Tall),
            35557 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.None),
            35558 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.Low),
            35559 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.Tall),
            35560 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.None),
            35561 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Low),
            35562 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Tall),
            35563 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.None),
            35564 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.Low),
            35565 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.Tall),
            35566 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.None),
            35567 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Low),
            35568 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Tall),
            35569 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.None),
            35570 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Low),
            35571 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Tall),
            35572 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.None),
            35573 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Low),
            35574 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Tall),
            35575 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.None),
            35576 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Low),
            35577 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Tall),
            35578 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.None),
            35579 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Low),
            35580 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            35581 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.None),
            35582 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.Low),
            35583 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.Tall),
            35584 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.None),
            35585 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Low),
            35586 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Tall),
            35587 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.None),
            35588 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Low),
            35589 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Tall),
            35590 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.None),
            35591 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Low),
            35592 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Tall),
            35593 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.None),
            35594 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Low),
            35595 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Tall),
            35596 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.None),
            35597 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Low),
            35598 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Tall),
            35599 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.None),
            35600 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Low),
            35601 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Tall),
            35602 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.None),
            35603 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Low),
            35604 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Tall),
            35605 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.None),
            35606 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Low),
            35607 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            35608 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.None),
            35609 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Low),
            35610 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Tall),
            35611 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.None),
            35612 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Low),
            35613 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Tall),
            35614 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.None),
            35615 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Low),
            35616 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Tall),
            35617 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.None),
            35618 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Low),
            35619 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Tall),
            35620 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.None),
            35621 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Low),
            35622 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Tall),
            35623 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.None),
            35624 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Low),
            35625 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Tall),
            35626 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.None),
            35627 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Low),
            35628 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Tall),
            35629 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.None),
            35630 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Low),
            35631 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Tall),
            35632 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.None),
            35633 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Low),
            35634 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            35635 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.None),
            35636 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.Low),
            35637 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.Tall),
            35638 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.None),
            35639 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.Low),
            35640 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.Tall),
            35641 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.None),
            35642 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Low),
            35643 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Tall),
            35644 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.None),
            35645 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.Low),
            35646 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.Tall),
            35647 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.None),
            35648 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Low),
            35649 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Tall),
            35650 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.None),
            35651 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Low),
            35652 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Tall),
            35653 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.None),
            35654 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Low),
            35655 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Tall),
            35656 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.None),
            35657 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Low),
            35658 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Tall),
            35659 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.None),
            35660 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Low),
            35661 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            35662 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.None),
            35663 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.Low),
            35664 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.Tall),
            35665 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.None),
            35666 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Low),
            35667 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Tall),
            35668 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.None),
            35669 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Low),
            35670 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Tall),
            35671 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.None),
            35672 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Low),
            35673 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Tall),
            35674 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.None),
            35675 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Low),
            35676 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Tall),
            35677 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.None),
            35678 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Low),
            35679 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Tall),
            35680 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.None),
            35681 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Low),
            35682 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Tall),
            35683 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.None),
            35684 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Low),
            35685 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Tall),
            35686 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.None),
            35687 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Low),
            35688 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            35689 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.None),
            35690 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Low),
            35691 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Tall),
            35692 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.None),
            35693 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Low),
            35694 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Tall),
            35695 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.None),
            35696 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Low),
            35697 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Tall),
            35698 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.None),
            35699 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Low),
            35700 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Tall),
            35701 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.None),
            35702 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Low),
            35703 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Tall),
            35704 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.None),
            35705 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Low),
            35706 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Tall),
            35707 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.None),
            35708 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Low),
            35709 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Tall),
            35710 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.None),
            35711 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Low),
            35712 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Tall),
            35713 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.None),
            35714 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Low),
            35715 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Tall),
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

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
public record RedstoneWireBlock(Identifier Identifier, RedstoneWireConnection East, RedstoneWireConnection North, int Power, RedstoneWireConnection South, RedstoneWireConnection West) : IBlock, IRedstoneConnected {
    private static readonly BlockInfo Data = new("block.minecraft.redstone_wire", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:redstone", BlockInfo.VanillaOnly, "minecraft:blocks/redstone_wire");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S829, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S830 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S831 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S832 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S833 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S834 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S835 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S836 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S837 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S838 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S839 };
    private static readonly BlockStateInfo I11 = I0 with { BlockShape = BlockShapes.S840 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S841 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S842 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S843 };
    private static readonly BlockStateInfo I15 = I0 with { BlockShape = BlockShapes.S844 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S845 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S846 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S847 };
    private static readonly BlockStateInfo I19 = I0 with { BlockShape = BlockShapes.S848 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S849 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S850 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S851 };
    private static readonly BlockStateInfo I23 = I0 with { BlockShape = BlockShapes.S852 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S853 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S854 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S855 };
    private static readonly BlockStateInfo I27 = I0 with { BlockShape = BlockShapes.S856 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S857 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S858 };
    private static readonly BlockStateInfo I30 = I0 with { BlockShape = BlockShapes.S859 };
    private static readonly BlockStateInfo I31 = I0 with { BlockShape = BlockShapes.S860 };
    private static readonly BlockStateInfo I32 = I0 with { BlockShape = BlockShapes.S861 };
    private static readonly BlockStateInfo I33 = I0 with { BlockShape = BlockShapes.S862 };
    private static readonly BlockStateInfo I34 = I0 with { BlockShape = BlockShapes.S863 };
    private static readonly BlockStateInfo I35 = I0 with { BlockShape = BlockShapes.S864 };
    private static readonly BlockStateInfo I36 = I0 with { BlockShape = BlockShapes.S865 };
    private static readonly BlockStateInfo I37 = I0 with { BlockShape = BlockShapes.S866 };
    private static readonly BlockStateInfo I38 = I0 with { BlockShape = BlockShapes.S867 };
    private static readonly BlockStateInfo I39 = I0 with { BlockShape = BlockShapes.S868 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S869 };
    private static readonly BlockStateInfo I41 = I0 with { BlockShape = BlockShapes.S870 };
    private static readonly BlockStateInfo I42 = I0 with { BlockShape = BlockShapes.S871 };
    private static readonly BlockStateInfo I43 = I0 with { BlockShape = BlockShapes.S872 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S873 };
    private static readonly BlockStateInfo I45 = I0 with { BlockShape = BlockShapes.S874 };
    private static readonly BlockStateInfo I46 = I0 with { BlockShape = BlockShapes.S875 };
    private static readonly BlockStateInfo I47 = I0 with { BlockShape = BlockShapes.S876 };
    private static readonly BlockStateInfo I48 = I0 with { BlockShape = BlockShapes.S877 };
    private static readonly BlockStateInfo I49 = I0 with { BlockShape = BlockShapes.S878 };
    private static readonly BlockStateInfo I50 = I0 with { BlockShape = BlockShapes.S879 };
    private static readonly BlockStateInfo I51 = I0 with { BlockShape = BlockShapes.S880 };
    private static readonly BlockStateInfo I52 = I0 with { BlockShape = BlockShapes.S881 };
    private static readonly BlockStateInfo I53 = I0 with { BlockShape = BlockShapes.S882 };
    private static readonly BlockStateInfo I54 = I0 with { BlockShape = BlockShapes.S883 };
    private static readonly BlockStateInfo I55 = I0 with { BlockShape = BlockShapes.S884 };
    private static readonly BlockStateInfo I56 = I0 with { BlockShape = BlockShapes.S885 };
    private static readonly BlockStateInfo I57 = I0 with { BlockShape = BlockShapes.S886 };
    private static readonly BlockStateInfo I58 = I0 with { BlockShape = BlockShapes.S887 };
    private static readonly BlockStateInfo I59 = I0 with { BlockShape = BlockShapes.S888 };
    private static readonly BlockStateInfo I60 = I0 with { BlockShape = BlockShapes.S889 };
    private static readonly BlockStateInfo I61 = I0 with { BlockShape = BlockShapes.S890 };
    private static readonly BlockStateInfo I62 = I0 with { BlockShape = BlockShapes.S891 };
    private static readonly BlockStateInfo I63 = I0 with { BlockShape = BlockShapes.S892 };
    private static readonly BlockStateInfo I64 = I0 with { BlockShape = BlockShapes.S893 };
    private static readonly BlockStateInfo I65 = I0 with { BlockShape = BlockShapes.S894 };
    private static readonly BlockStateInfo I66 = I0 with { BlockShape = BlockShapes.S895 };
    private static readonly BlockStateInfo I67 = I0 with { BlockShape = BlockShapes.S896 };
    private static readonly BlockStateInfo I68 = I0 with { BlockShape = BlockShapes.S897 };
    private static readonly BlockStateInfo I69 = I0 with { BlockShape = BlockShapes.S898 };
    private static readonly BlockStateInfo I70 = I0 with { BlockShape = BlockShapes.S899 };
    private static readonly BlockStateInfo I71 = I0 with { BlockShape = BlockShapes.S900 };
    private static readonly BlockStateInfo I72 = I0 with { BlockShape = BlockShapes.S901 };
    private static readonly BlockStateInfo I73 = I0 with { BlockShape = BlockShapes.S902 };
    private static readonly BlockStateInfo I74 = I0 with { BlockShape = BlockShapes.S903 };
    private static readonly BlockStateInfo I75 = I0 with { BlockShape = BlockShapes.S904 };
    private static readonly BlockStateInfo I76 = I0 with { BlockShape = BlockShapes.S905 };
    private static readonly BlockStateInfo I77 = I0 with { BlockShape = BlockShapes.S906 };
    private static readonly BlockStateInfo I78 = I0 with { BlockShape = BlockShapes.S907 };
    private static readonly BlockStateInfo I79 = I0 with { BlockShape = BlockShapes.S908 };
    private static readonly BlockStateInfo I80 = I0 with { BlockShape = BlockShapes.S909 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I36, I37, I38, I39, I40, I41, I42, I43, I44, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I45, I46, I47, I48, I49, I50, I51, I52, I53, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I54, I55, I56, I57, I58, I59, I60, I61, I62, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I63, I64, I65, I66, I67, I68, I69, I70, I71, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80, I72, I73, I74, I75, I76, I77, I78, I79, I80
    ];

    public BlockStateInfo StateInfo => States[StateId - 5567];

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

    public RedstoneWireConnection Connection(BlockFace face) => face switch {
        BlockFace.NegZ => North,
        BlockFace.PosZ => South,
        BlockFace.NegX => West,
        BlockFace.PosX => East,
        _ => RedstoneWireConnection.None
    };

    public IBlock WithConnection(BlockFace face, RedstoneWireConnection connection) => face switch {
        BlockFace.NegZ => this with { North = connection },
        BlockFace.PosZ => this with { South = connection },
        BlockFace.NegX => this with { West = connection },
        BlockFace.PosX => this with { East = connection },
        _ => this
    };


    public uint StateId {
        get {
            return East switch {
                RedstoneWireConnection.Up => North switch {
                    RedstoneWireConnection.Up => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5567,
                                RedstoneWireConnection.Side => 5568,
                                RedstoneWireConnection.None => 5569,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5570,
                                RedstoneWireConnection.Side => 5571,
                                RedstoneWireConnection.None => 5572,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5573,
                                RedstoneWireConnection.Side => 5574,
                                RedstoneWireConnection.None => 5575,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5576,
                                RedstoneWireConnection.Side => 5577,
                                RedstoneWireConnection.None => 5578,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5579,
                                RedstoneWireConnection.Side => 5580,
                                RedstoneWireConnection.None => 5581,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5582,
                                RedstoneWireConnection.Side => 5583,
                                RedstoneWireConnection.None => 5584,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5585,
                                RedstoneWireConnection.Side => 5586,
                                RedstoneWireConnection.None => 5587,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5588,
                                RedstoneWireConnection.Side => 5589,
                                RedstoneWireConnection.None => 5590,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5591,
                                RedstoneWireConnection.Side => 5592,
                                RedstoneWireConnection.None => 5593,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5594,
                                RedstoneWireConnection.Side => 5595,
                                RedstoneWireConnection.None => 5596,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5597,
                                RedstoneWireConnection.Side => 5598,
                                RedstoneWireConnection.None => 5599,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5600,
                                RedstoneWireConnection.Side => 5601,
                                RedstoneWireConnection.None => 5602,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5603,
                                RedstoneWireConnection.Side => 5604,
                                RedstoneWireConnection.None => 5605,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5606,
                                RedstoneWireConnection.Side => 5607,
                                RedstoneWireConnection.None => 5608,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5609,
                                RedstoneWireConnection.Side => 5610,
                                RedstoneWireConnection.None => 5611,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5612,
                                RedstoneWireConnection.Side => 5613,
                                RedstoneWireConnection.None => 5614,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5615,
                                RedstoneWireConnection.Side => 5616,
                                RedstoneWireConnection.None => 5617,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5618,
                                RedstoneWireConnection.Side => 5619,
                                RedstoneWireConnection.None => 5620,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5621,
                                RedstoneWireConnection.Side => 5622,
                                RedstoneWireConnection.None => 5623,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5624,
                                RedstoneWireConnection.Side => 5625,
                                RedstoneWireConnection.None => 5626,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5627,
                                RedstoneWireConnection.Side => 5628,
                                RedstoneWireConnection.None => 5629,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5630,
                                RedstoneWireConnection.Side => 5631,
                                RedstoneWireConnection.None => 5632,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5633,
                                RedstoneWireConnection.Side => 5634,
                                RedstoneWireConnection.None => 5635,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5636,
                                RedstoneWireConnection.Side => 5637,
                                RedstoneWireConnection.None => 5638,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5639,
                                RedstoneWireConnection.Side => 5640,
                                RedstoneWireConnection.None => 5641,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5642,
                                RedstoneWireConnection.Side => 5643,
                                RedstoneWireConnection.None => 5644,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5645,
                                RedstoneWireConnection.Side => 5646,
                                RedstoneWireConnection.None => 5647,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5648,
                                RedstoneWireConnection.Side => 5649,
                                RedstoneWireConnection.None => 5650,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5651,
                                RedstoneWireConnection.Side => 5652,
                                RedstoneWireConnection.None => 5653,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5654,
                                RedstoneWireConnection.Side => 5655,
                                RedstoneWireConnection.None => 5656,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5657,
                                RedstoneWireConnection.Side => 5658,
                                RedstoneWireConnection.None => 5659,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5660,
                                RedstoneWireConnection.Side => 5661,
                                RedstoneWireConnection.None => 5662,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5663,
                                RedstoneWireConnection.Side => 5664,
                                RedstoneWireConnection.None => 5665,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5666,
                                RedstoneWireConnection.Side => 5667,
                                RedstoneWireConnection.None => 5668,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5669,
                                RedstoneWireConnection.Side => 5670,
                                RedstoneWireConnection.None => 5671,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5672,
                                RedstoneWireConnection.Side => 5673,
                                RedstoneWireConnection.None => 5674,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5675,
                                RedstoneWireConnection.Side => 5676,
                                RedstoneWireConnection.None => 5677,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5678,
                                RedstoneWireConnection.Side => 5679,
                                RedstoneWireConnection.None => 5680,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5681,
                                RedstoneWireConnection.Side => 5682,
                                RedstoneWireConnection.None => 5683,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5684,
                                RedstoneWireConnection.Side => 5685,
                                RedstoneWireConnection.None => 5686,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5687,
                                RedstoneWireConnection.Side => 5688,
                                RedstoneWireConnection.None => 5689,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5690,
                                RedstoneWireConnection.Side => 5691,
                                RedstoneWireConnection.None => 5692,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5693,
                                RedstoneWireConnection.Side => 5694,
                                RedstoneWireConnection.None => 5695,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5696,
                                RedstoneWireConnection.Side => 5697,
                                RedstoneWireConnection.None => 5698,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5699,
                                RedstoneWireConnection.Side => 5700,
                                RedstoneWireConnection.None => 5701,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5702,
                                RedstoneWireConnection.Side => 5703,
                                RedstoneWireConnection.None => 5704,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5705,
                                RedstoneWireConnection.Side => 5706,
                                RedstoneWireConnection.None => 5707,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5708,
                                RedstoneWireConnection.Side => 5709,
                                RedstoneWireConnection.None => 5710,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.Side => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5711,
                                RedstoneWireConnection.Side => 5712,
                                RedstoneWireConnection.None => 5713,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5714,
                                RedstoneWireConnection.Side => 5715,
                                RedstoneWireConnection.None => 5716,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5717,
                                RedstoneWireConnection.Side => 5718,
                                RedstoneWireConnection.None => 5719,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5720,
                                RedstoneWireConnection.Side => 5721,
                                RedstoneWireConnection.None => 5722,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5723,
                                RedstoneWireConnection.Side => 5724,
                                RedstoneWireConnection.None => 5725,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5726,
                                RedstoneWireConnection.Side => 5727,
                                RedstoneWireConnection.None => 5728,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5729,
                                RedstoneWireConnection.Side => 5730,
                                RedstoneWireConnection.None => 5731,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5732,
                                RedstoneWireConnection.Side => 5733,
                                RedstoneWireConnection.None => 5734,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5735,
                                RedstoneWireConnection.Side => 5736,
                                RedstoneWireConnection.None => 5737,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5738,
                                RedstoneWireConnection.Side => 5739,
                                RedstoneWireConnection.None => 5740,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5741,
                                RedstoneWireConnection.Side => 5742,
                                RedstoneWireConnection.None => 5743,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5744,
                                RedstoneWireConnection.Side => 5745,
                                RedstoneWireConnection.None => 5746,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5747,
                                RedstoneWireConnection.Side => 5748,
                                RedstoneWireConnection.None => 5749,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5750,
                                RedstoneWireConnection.Side => 5751,
                                RedstoneWireConnection.None => 5752,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5753,
                                RedstoneWireConnection.Side => 5754,
                                RedstoneWireConnection.None => 5755,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5756,
                                RedstoneWireConnection.Side => 5757,
                                RedstoneWireConnection.None => 5758,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5759,
                                RedstoneWireConnection.Side => 5760,
                                RedstoneWireConnection.None => 5761,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5762,
                                RedstoneWireConnection.Side => 5763,
                                RedstoneWireConnection.None => 5764,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5765,
                                RedstoneWireConnection.Side => 5766,
                                RedstoneWireConnection.None => 5767,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5768,
                                RedstoneWireConnection.Side => 5769,
                                RedstoneWireConnection.None => 5770,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5771,
                                RedstoneWireConnection.Side => 5772,
                                RedstoneWireConnection.None => 5773,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5774,
                                RedstoneWireConnection.Side => 5775,
                                RedstoneWireConnection.None => 5776,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5777,
                                RedstoneWireConnection.Side => 5778,
                                RedstoneWireConnection.None => 5779,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5780,
                                RedstoneWireConnection.Side => 5781,
                                RedstoneWireConnection.None => 5782,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5783,
                                RedstoneWireConnection.Side => 5784,
                                RedstoneWireConnection.None => 5785,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5786,
                                RedstoneWireConnection.Side => 5787,
                                RedstoneWireConnection.None => 5788,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5789,
                                RedstoneWireConnection.Side => 5790,
                                RedstoneWireConnection.None => 5791,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5792,
                                RedstoneWireConnection.Side => 5793,
                                RedstoneWireConnection.None => 5794,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5795,
                                RedstoneWireConnection.Side => 5796,
                                RedstoneWireConnection.None => 5797,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5798,
                                RedstoneWireConnection.Side => 5799,
                                RedstoneWireConnection.None => 5800,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5801,
                                RedstoneWireConnection.Side => 5802,
                                RedstoneWireConnection.None => 5803,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5804,
                                RedstoneWireConnection.Side => 5805,
                                RedstoneWireConnection.None => 5806,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5807,
                                RedstoneWireConnection.Side => 5808,
                                RedstoneWireConnection.None => 5809,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5810,
                                RedstoneWireConnection.Side => 5811,
                                RedstoneWireConnection.None => 5812,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5813,
                                RedstoneWireConnection.Side => 5814,
                                RedstoneWireConnection.None => 5815,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5816,
                                RedstoneWireConnection.Side => 5817,
                                RedstoneWireConnection.None => 5818,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5819,
                                RedstoneWireConnection.Side => 5820,
                                RedstoneWireConnection.None => 5821,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5822,
                                RedstoneWireConnection.Side => 5823,
                                RedstoneWireConnection.None => 5824,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5825,
                                RedstoneWireConnection.Side => 5826,
                                RedstoneWireConnection.None => 5827,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5828,
                                RedstoneWireConnection.Side => 5829,
                                RedstoneWireConnection.None => 5830,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5831,
                                RedstoneWireConnection.Side => 5832,
                                RedstoneWireConnection.None => 5833,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5834,
                                RedstoneWireConnection.Side => 5835,
                                RedstoneWireConnection.None => 5836,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5837,
                                RedstoneWireConnection.Side => 5838,
                                RedstoneWireConnection.None => 5839,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5840,
                                RedstoneWireConnection.Side => 5841,
                                RedstoneWireConnection.None => 5842,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5843,
                                RedstoneWireConnection.Side => 5844,
                                RedstoneWireConnection.None => 5845,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5846,
                                RedstoneWireConnection.Side => 5847,
                                RedstoneWireConnection.None => 5848,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5849,
                                RedstoneWireConnection.Side => 5850,
                                RedstoneWireConnection.None => 5851,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5852,
                                RedstoneWireConnection.Side => 5853,
                                RedstoneWireConnection.None => 5854,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.None => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5855,
                                RedstoneWireConnection.Side => 5856,
                                RedstoneWireConnection.None => 5857,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5858,
                                RedstoneWireConnection.Side => 5859,
                                RedstoneWireConnection.None => 5860,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5861,
                                RedstoneWireConnection.Side => 5862,
                                RedstoneWireConnection.None => 5863,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5864,
                                RedstoneWireConnection.Side => 5865,
                                RedstoneWireConnection.None => 5866,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5867,
                                RedstoneWireConnection.Side => 5868,
                                RedstoneWireConnection.None => 5869,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5870,
                                RedstoneWireConnection.Side => 5871,
                                RedstoneWireConnection.None => 5872,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5873,
                                RedstoneWireConnection.Side => 5874,
                                RedstoneWireConnection.None => 5875,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5876,
                                RedstoneWireConnection.Side => 5877,
                                RedstoneWireConnection.None => 5878,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5879,
                                RedstoneWireConnection.Side => 5880,
                                RedstoneWireConnection.None => 5881,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5882,
                                RedstoneWireConnection.Side => 5883,
                                RedstoneWireConnection.None => 5884,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5885,
                                RedstoneWireConnection.Side => 5886,
                                RedstoneWireConnection.None => 5887,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5888,
                                RedstoneWireConnection.Side => 5889,
                                RedstoneWireConnection.None => 5890,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5891,
                                RedstoneWireConnection.Side => 5892,
                                RedstoneWireConnection.None => 5893,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5894,
                                RedstoneWireConnection.Side => 5895,
                                RedstoneWireConnection.None => 5896,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5897,
                                RedstoneWireConnection.Side => 5898,
                                RedstoneWireConnection.None => 5899,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5900,
                                RedstoneWireConnection.Side => 5901,
                                RedstoneWireConnection.None => 5902,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5903,
                                RedstoneWireConnection.Side => 5904,
                                RedstoneWireConnection.None => 5905,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5906,
                                RedstoneWireConnection.Side => 5907,
                                RedstoneWireConnection.None => 5908,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5909,
                                RedstoneWireConnection.Side => 5910,
                                RedstoneWireConnection.None => 5911,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5912,
                                RedstoneWireConnection.Side => 5913,
                                RedstoneWireConnection.None => 5914,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5915,
                                RedstoneWireConnection.Side => 5916,
                                RedstoneWireConnection.None => 5917,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5918,
                                RedstoneWireConnection.Side => 5919,
                                RedstoneWireConnection.None => 5920,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5921,
                                RedstoneWireConnection.Side => 5922,
                                RedstoneWireConnection.None => 5923,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5924,
                                RedstoneWireConnection.Side => 5925,
                                RedstoneWireConnection.None => 5926,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5927,
                                RedstoneWireConnection.Side => 5928,
                                RedstoneWireConnection.None => 5929,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5930,
                                RedstoneWireConnection.Side => 5931,
                                RedstoneWireConnection.None => 5932,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5933,
                                RedstoneWireConnection.Side => 5934,
                                RedstoneWireConnection.None => 5935,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5936,
                                RedstoneWireConnection.Side => 5937,
                                RedstoneWireConnection.None => 5938,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5939,
                                RedstoneWireConnection.Side => 5940,
                                RedstoneWireConnection.None => 5941,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5942,
                                RedstoneWireConnection.Side => 5943,
                                RedstoneWireConnection.None => 5944,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5945,
                                RedstoneWireConnection.Side => 5946,
                                RedstoneWireConnection.None => 5947,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5948,
                                RedstoneWireConnection.Side => 5949,
                                RedstoneWireConnection.None => 5950,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5951,
                                RedstoneWireConnection.Side => 5952,
                                RedstoneWireConnection.None => 5953,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5954,
                                RedstoneWireConnection.Side => 5955,
                                RedstoneWireConnection.None => 5956,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5957,
                                RedstoneWireConnection.Side => 5958,
                                RedstoneWireConnection.None => 5959,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5960,
                                RedstoneWireConnection.Side => 5961,
                                RedstoneWireConnection.None => 5962,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5963,
                                RedstoneWireConnection.Side => 5964,
                                RedstoneWireConnection.None => 5965,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5966,
                                RedstoneWireConnection.Side => 5967,
                                RedstoneWireConnection.None => 5968,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5969,
                                RedstoneWireConnection.Side => 5970,
                                RedstoneWireConnection.None => 5971,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5972,
                                RedstoneWireConnection.Side => 5973,
                                RedstoneWireConnection.None => 5974,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5975,
                                RedstoneWireConnection.Side => 5976,
                                RedstoneWireConnection.None => 5977,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5978,
                                RedstoneWireConnection.Side => 5979,
                                RedstoneWireConnection.None => 5980,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5981,
                                RedstoneWireConnection.Side => 5982,
                                RedstoneWireConnection.None => 5983,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5984,
                                RedstoneWireConnection.Side => 5985,
                                RedstoneWireConnection.None => 5986,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5987,
                                RedstoneWireConnection.Side => 5988,
                                RedstoneWireConnection.None => 5989,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5990,
                                RedstoneWireConnection.Side => 5991,
                                RedstoneWireConnection.None => 5992,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5993,
                                RedstoneWireConnection.Side => 5994,
                                RedstoneWireConnection.None => 5995,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5996,
                                RedstoneWireConnection.Side => 5997,
                                RedstoneWireConnection.None => 5998,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                RedstoneWireConnection.Side => North switch {
                    RedstoneWireConnection.Up => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5999,
                                RedstoneWireConnection.Side => 6000,
                                RedstoneWireConnection.None => 6001,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6002,
                                RedstoneWireConnection.Side => 6003,
                                RedstoneWireConnection.None => 6004,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6005,
                                RedstoneWireConnection.Side => 6006,
                                RedstoneWireConnection.None => 6007,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6008,
                                RedstoneWireConnection.Side => 6009,
                                RedstoneWireConnection.None => 6010,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6011,
                                RedstoneWireConnection.Side => 6012,
                                RedstoneWireConnection.None => 6013,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6014,
                                RedstoneWireConnection.Side => 6015,
                                RedstoneWireConnection.None => 6016,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6017,
                                RedstoneWireConnection.Side => 6018,
                                RedstoneWireConnection.None => 6019,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6020,
                                RedstoneWireConnection.Side => 6021,
                                RedstoneWireConnection.None => 6022,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6023,
                                RedstoneWireConnection.Side => 6024,
                                RedstoneWireConnection.None => 6025,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6026,
                                RedstoneWireConnection.Side => 6027,
                                RedstoneWireConnection.None => 6028,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6029,
                                RedstoneWireConnection.Side => 6030,
                                RedstoneWireConnection.None => 6031,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6032,
                                RedstoneWireConnection.Side => 6033,
                                RedstoneWireConnection.None => 6034,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6035,
                                RedstoneWireConnection.Side => 6036,
                                RedstoneWireConnection.None => 6037,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6038,
                                RedstoneWireConnection.Side => 6039,
                                RedstoneWireConnection.None => 6040,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6041,
                                RedstoneWireConnection.Side => 6042,
                                RedstoneWireConnection.None => 6043,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6044,
                                RedstoneWireConnection.Side => 6045,
                                RedstoneWireConnection.None => 6046,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6047,
                                RedstoneWireConnection.Side => 6048,
                                RedstoneWireConnection.None => 6049,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6050,
                                RedstoneWireConnection.Side => 6051,
                                RedstoneWireConnection.None => 6052,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6053,
                                RedstoneWireConnection.Side => 6054,
                                RedstoneWireConnection.None => 6055,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6056,
                                RedstoneWireConnection.Side => 6057,
                                RedstoneWireConnection.None => 6058,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6059,
                                RedstoneWireConnection.Side => 6060,
                                RedstoneWireConnection.None => 6061,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6062,
                                RedstoneWireConnection.Side => 6063,
                                RedstoneWireConnection.None => 6064,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6065,
                                RedstoneWireConnection.Side => 6066,
                                RedstoneWireConnection.None => 6067,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6068,
                                RedstoneWireConnection.Side => 6069,
                                RedstoneWireConnection.None => 6070,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6071,
                                RedstoneWireConnection.Side => 6072,
                                RedstoneWireConnection.None => 6073,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6074,
                                RedstoneWireConnection.Side => 6075,
                                RedstoneWireConnection.None => 6076,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6077,
                                RedstoneWireConnection.Side => 6078,
                                RedstoneWireConnection.None => 6079,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6080,
                                RedstoneWireConnection.Side => 6081,
                                RedstoneWireConnection.None => 6082,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6083,
                                RedstoneWireConnection.Side => 6084,
                                RedstoneWireConnection.None => 6085,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6086,
                                RedstoneWireConnection.Side => 6087,
                                RedstoneWireConnection.None => 6088,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6089,
                                RedstoneWireConnection.Side => 6090,
                                RedstoneWireConnection.None => 6091,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6092,
                                RedstoneWireConnection.Side => 6093,
                                RedstoneWireConnection.None => 6094,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6095,
                                RedstoneWireConnection.Side => 6096,
                                RedstoneWireConnection.None => 6097,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6098,
                                RedstoneWireConnection.Side => 6099,
                                RedstoneWireConnection.None => 6100,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6101,
                                RedstoneWireConnection.Side => 6102,
                                RedstoneWireConnection.None => 6103,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6104,
                                RedstoneWireConnection.Side => 6105,
                                RedstoneWireConnection.None => 6106,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6107,
                                RedstoneWireConnection.Side => 6108,
                                RedstoneWireConnection.None => 6109,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6110,
                                RedstoneWireConnection.Side => 6111,
                                RedstoneWireConnection.None => 6112,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6113,
                                RedstoneWireConnection.Side => 6114,
                                RedstoneWireConnection.None => 6115,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6116,
                                RedstoneWireConnection.Side => 6117,
                                RedstoneWireConnection.None => 6118,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6119,
                                RedstoneWireConnection.Side => 6120,
                                RedstoneWireConnection.None => 6121,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6122,
                                RedstoneWireConnection.Side => 6123,
                                RedstoneWireConnection.None => 6124,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6125,
                                RedstoneWireConnection.Side => 6126,
                                RedstoneWireConnection.None => 6127,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6128,
                                RedstoneWireConnection.Side => 6129,
                                RedstoneWireConnection.None => 6130,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6131,
                                RedstoneWireConnection.Side => 6132,
                                RedstoneWireConnection.None => 6133,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6134,
                                RedstoneWireConnection.Side => 6135,
                                RedstoneWireConnection.None => 6136,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6137,
                                RedstoneWireConnection.Side => 6138,
                                RedstoneWireConnection.None => 6139,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6140,
                                RedstoneWireConnection.Side => 6141,
                                RedstoneWireConnection.None => 6142,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.Side => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6143,
                                RedstoneWireConnection.Side => 6144,
                                RedstoneWireConnection.None => 6145,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6146,
                                RedstoneWireConnection.Side => 6147,
                                RedstoneWireConnection.None => 6148,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6149,
                                RedstoneWireConnection.Side => 6150,
                                RedstoneWireConnection.None => 6151,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6152,
                                RedstoneWireConnection.Side => 6153,
                                RedstoneWireConnection.None => 6154,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6155,
                                RedstoneWireConnection.Side => 6156,
                                RedstoneWireConnection.None => 6157,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6158,
                                RedstoneWireConnection.Side => 6159,
                                RedstoneWireConnection.None => 6160,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6161,
                                RedstoneWireConnection.Side => 6162,
                                RedstoneWireConnection.None => 6163,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6164,
                                RedstoneWireConnection.Side => 6165,
                                RedstoneWireConnection.None => 6166,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6167,
                                RedstoneWireConnection.Side => 6168,
                                RedstoneWireConnection.None => 6169,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6170,
                                RedstoneWireConnection.Side => 6171,
                                RedstoneWireConnection.None => 6172,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6173,
                                RedstoneWireConnection.Side => 6174,
                                RedstoneWireConnection.None => 6175,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6176,
                                RedstoneWireConnection.Side => 6177,
                                RedstoneWireConnection.None => 6178,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6179,
                                RedstoneWireConnection.Side => 6180,
                                RedstoneWireConnection.None => 6181,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6182,
                                RedstoneWireConnection.Side => 6183,
                                RedstoneWireConnection.None => 6184,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6185,
                                RedstoneWireConnection.Side => 6186,
                                RedstoneWireConnection.None => 6187,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6188,
                                RedstoneWireConnection.Side => 6189,
                                RedstoneWireConnection.None => 6190,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6191,
                                RedstoneWireConnection.Side => 6192,
                                RedstoneWireConnection.None => 6193,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6194,
                                RedstoneWireConnection.Side => 6195,
                                RedstoneWireConnection.None => 6196,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6197,
                                RedstoneWireConnection.Side => 6198,
                                RedstoneWireConnection.None => 6199,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6200,
                                RedstoneWireConnection.Side => 6201,
                                RedstoneWireConnection.None => 6202,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6203,
                                RedstoneWireConnection.Side => 6204,
                                RedstoneWireConnection.None => 6205,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6206,
                                RedstoneWireConnection.Side => 6207,
                                RedstoneWireConnection.None => 6208,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6209,
                                RedstoneWireConnection.Side => 6210,
                                RedstoneWireConnection.None => 6211,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6212,
                                RedstoneWireConnection.Side => 6213,
                                RedstoneWireConnection.None => 6214,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6215,
                                RedstoneWireConnection.Side => 6216,
                                RedstoneWireConnection.None => 6217,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6218,
                                RedstoneWireConnection.Side => 6219,
                                RedstoneWireConnection.None => 6220,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6221,
                                RedstoneWireConnection.Side => 6222,
                                RedstoneWireConnection.None => 6223,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6224,
                                RedstoneWireConnection.Side => 6225,
                                RedstoneWireConnection.None => 6226,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6227,
                                RedstoneWireConnection.Side => 6228,
                                RedstoneWireConnection.None => 6229,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6230,
                                RedstoneWireConnection.Side => 6231,
                                RedstoneWireConnection.None => 6232,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6233,
                                RedstoneWireConnection.Side => 6234,
                                RedstoneWireConnection.None => 6235,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6236,
                                RedstoneWireConnection.Side => 6237,
                                RedstoneWireConnection.None => 6238,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6239,
                                RedstoneWireConnection.Side => 6240,
                                RedstoneWireConnection.None => 6241,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6242,
                                RedstoneWireConnection.Side => 6243,
                                RedstoneWireConnection.None => 6244,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6245,
                                RedstoneWireConnection.Side => 6246,
                                RedstoneWireConnection.None => 6247,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6248,
                                RedstoneWireConnection.Side => 6249,
                                RedstoneWireConnection.None => 6250,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6251,
                                RedstoneWireConnection.Side => 6252,
                                RedstoneWireConnection.None => 6253,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6254,
                                RedstoneWireConnection.Side => 6255,
                                RedstoneWireConnection.None => 6256,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6257,
                                RedstoneWireConnection.Side => 6258,
                                RedstoneWireConnection.None => 6259,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6260,
                                RedstoneWireConnection.Side => 6261,
                                RedstoneWireConnection.None => 6262,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6263,
                                RedstoneWireConnection.Side => 6264,
                                RedstoneWireConnection.None => 6265,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6266,
                                RedstoneWireConnection.Side => 6267,
                                RedstoneWireConnection.None => 6268,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6269,
                                RedstoneWireConnection.Side => 6270,
                                RedstoneWireConnection.None => 6271,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6272,
                                RedstoneWireConnection.Side => 6273,
                                RedstoneWireConnection.None => 6274,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6275,
                                RedstoneWireConnection.Side => 6276,
                                RedstoneWireConnection.None => 6277,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6278,
                                RedstoneWireConnection.Side => 6279,
                                RedstoneWireConnection.None => 6280,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6281,
                                RedstoneWireConnection.Side => 6282,
                                RedstoneWireConnection.None => 6283,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6284,
                                RedstoneWireConnection.Side => 6285,
                                RedstoneWireConnection.None => 6286,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.None => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6287,
                                RedstoneWireConnection.Side => 6288,
                                RedstoneWireConnection.None => 6289,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6290,
                                RedstoneWireConnection.Side => 6291,
                                RedstoneWireConnection.None => 6292,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6293,
                                RedstoneWireConnection.Side => 6294,
                                RedstoneWireConnection.None => 6295,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6296,
                                RedstoneWireConnection.Side => 6297,
                                RedstoneWireConnection.None => 6298,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6299,
                                RedstoneWireConnection.Side => 6300,
                                RedstoneWireConnection.None => 6301,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6302,
                                RedstoneWireConnection.Side => 6303,
                                RedstoneWireConnection.None => 6304,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6305,
                                RedstoneWireConnection.Side => 6306,
                                RedstoneWireConnection.None => 6307,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6308,
                                RedstoneWireConnection.Side => 6309,
                                RedstoneWireConnection.None => 6310,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6311,
                                RedstoneWireConnection.Side => 6312,
                                RedstoneWireConnection.None => 6313,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6314,
                                RedstoneWireConnection.Side => 6315,
                                RedstoneWireConnection.None => 6316,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6317,
                                RedstoneWireConnection.Side => 6318,
                                RedstoneWireConnection.None => 6319,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6320,
                                RedstoneWireConnection.Side => 6321,
                                RedstoneWireConnection.None => 6322,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6323,
                                RedstoneWireConnection.Side => 6324,
                                RedstoneWireConnection.None => 6325,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6326,
                                RedstoneWireConnection.Side => 6327,
                                RedstoneWireConnection.None => 6328,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6329,
                                RedstoneWireConnection.Side => 6330,
                                RedstoneWireConnection.None => 6331,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6332,
                                RedstoneWireConnection.Side => 6333,
                                RedstoneWireConnection.None => 6334,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6335,
                                RedstoneWireConnection.Side => 6336,
                                RedstoneWireConnection.None => 6337,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6338,
                                RedstoneWireConnection.Side => 6339,
                                RedstoneWireConnection.None => 6340,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6341,
                                RedstoneWireConnection.Side => 6342,
                                RedstoneWireConnection.None => 6343,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6344,
                                RedstoneWireConnection.Side => 6345,
                                RedstoneWireConnection.None => 6346,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6347,
                                RedstoneWireConnection.Side => 6348,
                                RedstoneWireConnection.None => 6349,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6350,
                                RedstoneWireConnection.Side => 6351,
                                RedstoneWireConnection.None => 6352,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6353,
                                RedstoneWireConnection.Side => 6354,
                                RedstoneWireConnection.None => 6355,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6356,
                                RedstoneWireConnection.Side => 6357,
                                RedstoneWireConnection.None => 6358,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6359,
                                RedstoneWireConnection.Side => 6360,
                                RedstoneWireConnection.None => 6361,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6362,
                                RedstoneWireConnection.Side => 6363,
                                RedstoneWireConnection.None => 6364,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6365,
                                RedstoneWireConnection.Side => 6366,
                                RedstoneWireConnection.None => 6367,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6368,
                                RedstoneWireConnection.Side => 6369,
                                RedstoneWireConnection.None => 6370,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6371,
                                RedstoneWireConnection.Side => 6372,
                                RedstoneWireConnection.None => 6373,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6374,
                                RedstoneWireConnection.Side => 6375,
                                RedstoneWireConnection.None => 6376,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6377,
                                RedstoneWireConnection.Side => 6378,
                                RedstoneWireConnection.None => 6379,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6380,
                                RedstoneWireConnection.Side => 6381,
                                RedstoneWireConnection.None => 6382,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6383,
                                RedstoneWireConnection.Side => 6384,
                                RedstoneWireConnection.None => 6385,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6386,
                                RedstoneWireConnection.Side => 6387,
                                RedstoneWireConnection.None => 6388,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6389,
                                RedstoneWireConnection.Side => 6390,
                                RedstoneWireConnection.None => 6391,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6392,
                                RedstoneWireConnection.Side => 6393,
                                RedstoneWireConnection.None => 6394,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6395,
                                RedstoneWireConnection.Side => 6396,
                                RedstoneWireConnection.None => 6397,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6398,
                                RedstoneWireConnection.Side => 6399,
                                RedstoneWireConnection.None => 6400,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6401,
                                RedstoneWireConnection.Side => 6402,
                                RedstoneWireConnection.None => 6403,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6404,
                                RedstoneWireConnection.Side => 6405,
                                RedstoneWireConnection.None => 6406,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6407,
                                RedstoneWireConnection.Side => 6408,
                                RedstoneWireConnection.None => 6409,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6410,
                                RedstoneWireConnection.Side => 6411,
                                RedstoneWireConnection.None => 6412,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6413,
                                RedstoneWireConnection.Side => 6414,
                                RedstoneWireConnection.None => 6415,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6416,
                                RedstoneWireConnection.Side => 6417,
                                RedstoneWireConnection.None => 6418,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6419,
                                RedstoneWireConnection.Side => 6420,
                                RedstoneWireConnection.None => 6421,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6422,
                                RedstoneWireConnection.Side => 6423,
                                RedstoneWireConnection.None => 6424,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6425,
                                RedstoneWireConnection.Side => 6426,
                                RedstoneWireConnection.None => 6427,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6428,
                                RedstoneWireConnection.Side => 6429,
                                RedstoneWireConnection.None => 6430,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                RedstoneWireConnection.None => North switch {
                    RedstoneWireConnection.Up => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6431,
                                RedstoneWireConnection.Side => 6432,
                                RedstoneWireConnection.None => 6433,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6434,
                                RedstoneWireConnection.Side => 6435,
                                RedstoneWireConnection.None => 6436,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6437,
                                RedstoneWireConnection.Side => 6438,
                                RedstoneWireConnection.None => 6439,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6440,
                                RedstoneWireConnection.Side => 6441,
                                RedstoneWireConnection.None => 6442,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6443,
                                RedstoneWireConnection.Side => 6444,
                                RedstoneWireConnection.None => 6445,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6446,
                                RedstoneWireConnection.Side => 6447,
                                RedstoneWireConnection.None => 6448,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6449,
                                RedstoneWireConnection.Side => 6450,
                                RedstoneWireConnection.None => 6451,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6452,
                                RedstoneWireConnection.Side => 6453,
                                RedstoneWireConnection.None => 6454,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6455,
                                RedstoneWireConnection.Side => 6456,
                                RedstoneWireConnection.None => 6457,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6458,
                                RedstoneWireConnection.Side => 6459,
                                RedstoneWireConnection.None => 6460,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6461,
                                RedstoneWireConnection.Side => 6462,
                                RedstoneWireConnection.None => 6463,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6464,
                                RedstoneWireConnection.Side => 6465,
                                RedstoneWireConnection.None => 6466,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6467,
                                RedstoneWireConnection.Side => 6468,
                                RedstoneWireConnection.None => 6469,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6470,
                                RedstoneWireConnection.Side => 6471,
                                RedstoneWireConnection.None => 6472,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6473,
                                RedstoneWireConnection.Side => 6474,
                                RedstoneWireConnection.None => 6475,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6476,
                                RedstoneWireConnection.Side => 6477,
                                RedstoneWireConnection.None => 6478,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6479,
                                RedstoneWireConnection.Side => 6480,
                                RedstoneWireConnection.None => 6481,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6482,
                                RedstoneWireConnection.Side => 6483,
                                RedstoneWireConnection.None => 6484,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6485,
                                RedstoneWireConnection.Side => 6486,
                                RedstoneWireConnection.None => 6487,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6488,
                                RedstoneWireConnection.Side => 6489,
                                RedstoneWireConnection.None => 6490,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6491,
                                RedstoneWireConnection.Side => 6492,
                                RedstoneWireConnection.None => 6493,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6494,
                                RedstoneWireConnection.Side => 6495,
                                RedstoneWireConnection.None => 6496,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6497,
                                RedstoneWireConnection.Side => 6498,
                                RedstoneWireConnection.None => 6499,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6500,
                                RedstoneWireConnection.Side => 6501,
                                RedstoneWireConnection.None => 6502,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6503,
                                RedstoneWireConnection.Side => 6504,
                                RedstoneWireConnection.None => 6505,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6506,
                                RedstoneWireConnection.Side => 6507,
                                RedstoneWireConnection.None => 6508,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6509,
                                RedstoneWireConnection.Side => 6510,
                                RedstoneWireConnection.None => 6511,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6512,
                                RedstoneWireConnection.Side => 6513,
                                RedstoneWireConnection.None => 6514,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6515,
                                RedstoneWireConnection.Side => 6516,
                                RedstoneWireConnection.None => 6517,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6518,
                                RedstoneWireConnection.Side => 6519,
                                RedstoneWireConnection.None => 6520,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6521,
                                RedstoneWireConnection.Side => 6522,
                                RedstoneWireConnection.None => 6523,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6524,
                                RedstoneWireConnection.Side => 6525,
                                RedstoneWireConnection.None => 6526,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6527,
                                RedstoneWireConnection.Side => 6528,
                                RedstoneWireConnection.None => 6529,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6530,
                                RedstoneWireConnection.Side => 6531,
                                RedstoneWireConnection.None => 6532,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6533,
                                RedstoneWireConnection.Side => 6534,
                                RedstoneWireConnection.None => 6535,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6536,
                                RedstoneWireConnection.Side => 6537,
                                RedstoneWireConnection.None => 6538,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6539,
                                RedstoneWireConnection.Side => 6540,
                                RedstoneWireConnection.None => 6541,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6542,
                                RedstoneWireConnection.Side => 6543,
                                RedstoneWireConnection.None => 6544,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6545,
                                RedstoneWireConnection.Side => 6546,
                                RedstoneWireConnection.None => 6547,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6548,
                                RedstoneWireConnection.Side => 6549,
                                RedstoneWireConnection.None => 6550,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6551,
                                RedstoneWireConnection.Side => 6552,
                                RedstoneWireConnection.None => 6553,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6554,
                                RedstoneWireConnection.Side => 6555,
                                RedstoneWireConnection.None => 6556,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6557,
                                RedstoneWireConnection.Side => 6558,
                                RedstoneWireConnection.None => 6559,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6560,
                                RedstoneWireConnection.Side => 6561,
                                RedstoneWireConnection.None => 6562,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6563,
                                RedstoneWireConnection.Side => 6564,
                                RedstoneWireConnection.None => 6565,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6566,
                                RedstoneWireConnection.Side => 6567,
                                RedstoneWireConnection.None => 6568,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6569,
                                RedstoneWireConnection.Side => 6570,
                                RedstoneWireConnection.None => 6571,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6572,
                                RedstoneWireConnection.Side => 6573,
                                RedstoneWireConnection.None => 6574,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.Side => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6575,
                                RedstoneWireConnection.Side => 6576,
                                RedstoneWireConnection.None => 6577,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6578,
                                RedstoneWireConnection.Side => 6579,
                                RedstoneWireConnection.None => 6580,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6581,
                                RedstoneWireConnection.Side => 6582,
                                RedstoneWireConnection.None => 6583,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6584,
                                RedstoneWireConnection.Side => 6585,
                                RedstoneWireConnection.None => 6586,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6587,
                                RedstoneWireConnection.Side => 6588,
                                RedstoneWireConnection.None => 6589,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6590,
                                RedstoneWireConnection.Side => 6591,
                                RedstoneWireConnection.None => 6592,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6593,
                                RedstoneWireConnection.Side => 6594,
                                RedstoneWireConnection.None => 6595,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6596,
                                RedstoneWireConnection.Side => 6597,
                                RedstoneWireConnection.None => 6598,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6599,
                                RedstoneWireConnection.Side => 6600,
                                RedstoneWireConnection.None => 6601,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6602,
                                RedstoneWireConnection.Side => 6603,
                                RedstoneWireConnection.None => 6604,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6605,
                                RedstoneWireConnection.Side => 6606,
                                RedstoneWireConnection.None => 6607,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6608,
                                RedstoneWireConnection.Side => 6609,
                                RedstoneWireConnection.None => 6610,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6611,
                                RedstoneWireConnection.Side => 6612,
                                RedstoneWireConnection.None => 6613,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6614,
                                RedstoneWireConnection.Side => 6615,
                                RedstoneWireConnection.None => 6616,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6617,
                                RedstoneWireConnection.Side => 6618,
                                RedstoneWireConnection.None => 6619,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6620,
                                RedstoneWireConnection.Side => 6621,
                                RedstoneWireConnection.None => 6622,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6623,
                                RedstoneWireConnection.Side => 6624,
                                RedstoneWireConnection.None => 6625,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6626,
                                RedstoneWireConnection.Side => 6627,
                                RedstoneWireConnection.None => 6628,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6629,
                                RedstoneWireConnection.Side => 6630,
                                RedstoneWireConnection.None => 6631,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6632,
                                RedstoneWireConnection.Side => 6633,
                                RedstoneWireConnection.None => 6634,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6635,
                                RedstoneWireConnection.Side => 6636,
                                RedstoneWireConnection.None => 6637,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6638,
                                RedstoneWireConnection.Side => 6639,
                                RedstoneWireConnection.None => 6640,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6641,
                                RedstoneWireConnection.Side => 6642,
                                RedstoneWireConnection.None => 6643,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6644,
                                RedstoneWireConnection.Side => 6645,
                                RedstoneWireConnection.None => 6646,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6647,
                                RedstoneWireConnection.Side => 6648,
                                RedstoneWireConnection.None => 6649,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6650,
                                RedstoneWireConnection.Side => 6651,
                                RedstoneWireConnection.None => 6652,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6653,
                                RedstoneWireConnection.Side => 6654,
                                RedstoneWireConnection.None => 6655,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6656,
                                RedstoneWireConnection.Side => 6657,
                                RedstoneWireConnection.None => 6658,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6659,
                                RedstoneWireConnection.Side => 6660,
                                RedstoneWireConnection.None => 6661,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6662,
                                RedstoneWireConnection.Side => 6663,
                                RedstoneWireConnection.None => 6664,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6665,
                                RedstoneWireConnection.Side => 6666,
                                RedstoneWireConnection.None => 6667,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6668,
                                RedstoneWireConnection.Side => 6669,
                                RedstoneWireConnection.None => 6670,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6671,
                                RedstoneWireConnection.Side => 6672,
                                RedstoneWireConnection.None => 6673,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6674,
                                RedstoneWireConnection.Side => 6675,
                                RedstoneWireConnection.None => 6676,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6677,
                                RedstoneWireConnection.Side => 6678,
                                RedstoneWireConnection.None => 6679,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6680,
                                RedstoneWireConnection.Side => 6681,
                                RedstoneWireConnection.None => 6682,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6683,
                                RedstoneWireConnection.Side => 6684,
                                RedstoneWireConnection.None => 6685,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6686,
                                RedstoneWireConnection.Side => 6687,
                                RedstoneWireConnection.None => 6688,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6689,
                                RedstoneWireConnection.Side => 6690,
                                RedstoneWireConnection.None => 6691,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6692,
                                RedstoneWireConnection.Side => 6693,
                                RedstoneWireConnection.None => 6694,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6695,
                                RedstoneWireConnection.Side => 6696,
                                RedstoneWireConnection.None => 6697,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6698,
                                RedstoneWireConnection.Side => 6699,
                                RedstoneWireConnection.None => 6700,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6701,
                                RedstoneWireConnection.Side => 6702,
                                RedstoneWireConnection.None => 6703,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6704,
                                RedstoneWireConnection.Side => 6705,
                                RedstoneWireConnection.None => 6706,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6707,
                                RedstoneWireConnection.Side => 6708,
                                RedstoneWireConnection.None => 6709,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6710,
                                RedstoneWireConnection.Side => 6711,
                                RedstoneWireConnection.None => 6712,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6713,
                                RedstoneWireConnection.Side => 6714,
                                RedstoneWireConnection.None => 6715,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6716,
                                RedstoneWireConnection.Side => 6717,
                                RedstoneWireConnection.None => 6718,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.None => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6719,
                                RedstoneWireConnection.Side => 6720,
                                RedstoneWireConnection.None => 6721,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6722,
                                RedstoneWireConnection.Side => 6723,
                                RedstoneWireConnection.None => 6724,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6725,
                                RedstoneWireConnection.Side => 6726,
                                RedstoneWireConnection.None => 6727,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6728,
                                RedstoneWireConnection.Side => 6729,
                                RedstoneWireConnection.None => 6730,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6731,
                                RedstoneWireConnection.Side => 6732,
                                RedstoneWireConnection.None => 6733,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6734,
                                RedstoneWireConnection.Side => 6735,
                                RedstoneWireConnection.None => 6736,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6737,
                                RedstoneWireConnection.Side => 6738,
                                RedstoneWireConnection.None => 6739,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6740,
                                RedstoneWireConnection.Side => 6741,
                                RedstoneWireConnection.None => 6742,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6743,
                                RedstoneWireConnection.Side => 6744,
                                RedstoneWireConnection.None => 6745,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6746,
                                RedstoneWireConnection.Side => 6747,
                                RedstoneWireConnection.None => 6748,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6749,
                                RedstoneWireConnection.Side => 6750,
                                RedstoneWireConnection.None => 6751,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6752,
                                RedstoneWireConnection.Side => 6753,
                                RedstoneWireConnection.None => 6754,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6755,
                                RedstoneWireConnection.Side => 6756,
                                RedstoneWireConnection.None => 6757,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6758,
                                RedstoneWireConnection.Side => 6759,
                                RedstoneWireConnection.None => 6760,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6761,
                                RedstoneWireConnection.Side => 6762,
                                RedstoneWireConnection.None => 6763,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6764,
                                RedstoneWireConnection.Side => 6765,
                                RedstoneWireConnection.None => 6766,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6767,
                                RedstoneWireConnection.Side => 6768,
                                RedstoneWireConnection.None => 6769,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6770,
                                RedstoneWireConnection.Side => 6771,
                                RedstoneWireConnection.None => 6772,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6773,
                                RedstoneWireConnection.Side => 6774,
                                RedstoneWireConnection.None => 6775,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6776,
                                RedstoneWireConnection.Side => 6777,
                                RedstoneWireConnection.None => 6778,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6779,
                                RedstoneWireConnection.Side => 6780,
                                RedstoneWireConnection.None => 6781,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6782,
                                RedstoneWireConnection.Side => 6783,
                                RedstoneWireConnection.None => 6784,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6785,
                                RedstoneWireConnection.Side => 6786,
                                RedstoneWireConnection.None => 6787,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6788,
                                RedstoneWireConnection.Side => 6789,
                                RedstoneWireConnection.None => 6790,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6791,
                                RedstoneWireConnection.Side => 6792,
                                RedstoneWireConnection.None => 6793,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6794,
                                RedstoneWireConnection.Side => 6795,
                                RedstoneWireConnection.None => 6796,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6797,
                                RedstoneWireConnection.Side => 6798,
                                RedstoneWireConnection.None => 6799,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6800,
                                RedstoneWireConnection.Side => 6801,
                                RedstoneWireConnection.None => 6802,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6803,
                                RedstoneWireConnection.Side => 6804,
                                RedstoneWireConnection.None => 6805,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6806,
                                RedstoneWireConnection.Side => 6807,
                                RedstoneWireConnection.None => 6808,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6809,
                                RedstoneWireConnection.Side => 6810,
                                RedstoneWireConnection.None => 6811,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6812,
                                RedstoneWireConnection.Side => 6813,
                                RedstoneWireConnection.None => 6814,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6815,
                                RedstoneWireConnection.Side => 6816,
                                RedstoneWireConnection.None => 6817,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6818,
                                RedstoneWireConnection.Side => 6819,
                                RedstoneWireConnection.None => 6820,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6821,
                                RedstoneWireConnection.Side => 6822,
                                RedstoneWireConnection.None => 6823,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6824,
                                RedstoneWireConnection.Side => 6825,
                                RedstoneWireConnection.None => 6826,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6827,
                                RedstoneWireConnection.Side => 6828,
                                RedstoneWireConnection.None => 6829,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6830,
                                RedstoneWireConnection.Side => 6831,
                                RedstoneWireConnection.None => 6832,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6833,
                                RedstoneWireConnection.Side => 6834,
                                RedstoneWireConnection.None => 6835,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6836,
                                RedstoneWireConnection.Side => 6837,
                                RedstoneWireConnection.None => 6838,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6839,
                                RedstoneWireConnection.Side => 6840,
                                RedstoneWireConnection.None => 6841,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6842,
                                RedstoneWireConnection.Side => 6843,
                                RedstoneWireConnection.None => 6844,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6845,
                                RedstoneWireConnection.Side => 6846,
                                RedstoneWireConnection.None => 6847,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6848,
                                RedstoneWireConnection.Side => 6849,
                                RedstoneWireConnection.None => 6850,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6851,
                                RedstoneWireConnection.Side => 6852,
                                RedstoneWireConnection.None => 6853,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 6854,
                                RedstoneWireConnection.Side => 6855,
                                RedstoneWireConnection.None => 6856,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 6857,
                                RedstoneWireConnection.Side => 6858,
                                RedstoneWireConnection.None => 6859,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 6860,
                                RedstoneWireConnection.Side => 6861,
                                RedstoneWireConnection.None => 6862,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5567 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5568 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5569 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5570 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5571 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5572 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5573 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5574 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5575 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5576 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5577 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5578 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5579 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5580 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5581 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5582 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5583 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5584 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5585 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5586 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5587 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5588 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5589 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5590 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5591 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5592 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5593 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5594 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5595 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5596 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5597 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5598 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5599 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5600 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5601 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5602 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5603 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5604 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5605 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5606 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5607 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5608 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5609 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5610 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5611 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5612 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5613 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5614 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5615 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5616 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5617 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5618 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5619 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5620 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5621 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5622 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5623 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5624 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5625 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5626 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5627 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5628 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5629 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5630 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5631 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5632 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5633 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5634 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5635 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5636 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5637 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5638 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5639 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5640 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5641 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5642 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5643 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5644 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5645 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5646 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5647 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5648 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5649 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5650 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5651 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5652 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5653 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5654 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5655 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5656 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5657 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5658 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5659 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5660 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5661 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5662 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5663 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5664 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5665 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5666 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5667 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5668 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5669 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5670 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5671 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5672 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5673 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5674 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5675 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5676 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5677 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5678 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5679 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5680 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5681 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5682 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5683 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5684 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5685 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5686 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5687 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5688 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5689 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5690 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5691 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5692 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5693 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5694 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5695 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5696 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5697 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5698 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5699 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5700 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5701 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5702 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5703 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5704 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5705 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5706 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5707 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5708 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5709 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5710 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5711 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5712 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5713 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5714 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5715 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5716 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5717 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5718 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5719 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5720 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5721 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5722 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5723 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5724 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5725 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5726 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5727 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5728 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5729 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5730 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5731 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5732 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5733 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5734 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5735 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5736 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5737 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5738 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5739 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5740 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5741 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5742 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5743 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5744 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5745 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5746 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5747 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5748 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5749 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5750 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5751 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5752 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5753 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5754 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5755 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5756 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5757 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5758 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5759 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5760 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5761 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5762 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5763 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5764 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5765 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5766 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5767 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5768 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5769 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5770 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5771 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5772 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5773 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5774 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5775 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5776 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5777 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5778 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5779 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5780 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5781 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5782 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5783 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5784 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5785 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5786 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5787 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5788 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5789 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5790 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5791 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5792 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5793 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5794 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5795 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5796 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5797 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5798 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5799 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5800 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5801 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5802 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5803 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5804 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5805 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5806 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5807 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5808 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5809 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5810 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5811 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5812 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5813 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5814 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5815 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5816 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5817 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5818 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5819 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5820 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5821 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5822 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5823 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5824 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5825 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5826 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5827 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5828 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5829 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5830 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5831 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5832 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5833 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5834 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5835 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5836 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5837 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5838 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5839 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5840 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5841 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5842 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5843 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5844 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5845 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5846 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5847 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5848 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5849 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5850 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5851 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5852 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5853 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5854 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5855 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5856 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5857 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5858 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5859 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5860 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5861 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5862 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5863 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5864 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5865 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5866 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5867 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5868 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5869 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5870 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5871 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5872 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5873 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5874 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5875 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5876 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5877 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5878 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5879 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5880 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5881 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5882 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5883 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5884 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5885 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5886 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5887 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5888 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5889 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5890 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5891 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5892 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5893 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5894 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5895 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5896 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5897 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5898 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5899 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5900 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5901 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5902 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5903 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5904 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5905 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5906 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5907 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5908 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5909 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5910 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5911 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5912 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5913 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5914 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5915 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5916 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5917 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5918 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5919 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5920 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5921 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5922 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5923 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5924 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5925 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5926 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5927 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5928 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5929 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5930 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5931 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5932 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5933 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5934 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5935 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5936 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5937 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5938 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5939 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5940 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5941 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5942 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5943 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5944 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5945 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5946 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5947 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5948 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5949 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5950 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5951 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5952 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5953 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5954 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5955 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5956 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5957 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5958 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5959 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5960 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5961 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5962 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5963 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5964 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5965 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5966 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5967 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5968 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5969 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5970 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5971 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5972 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5973 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5974 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5975 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5976 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5977 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5978 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5979 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5980 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5981 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5982 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5983 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5984 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5985 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5986 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5987 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5988 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5989 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5990 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5991 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5992 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5993 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5994 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5995 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5996 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5997 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5998 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5999 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6000 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6001 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6002 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6003 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6004 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6005 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6006 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6007 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6008 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6009 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6010 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6011 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6012 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6013 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6014 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6015 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6016 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6017 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6018 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6019 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6020 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6021 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6022 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6023 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6024 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6025 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6026 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6027 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6028 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6029 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6030 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6031 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6032 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6033 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6034 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6035 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6036 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6037 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6038 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6039 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6040 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6041 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6042 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6043 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6044 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6045 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6046 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6047 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6048 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6049 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6050 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6051 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6052 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6053 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6054 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6055 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6056 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6057 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6058 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6059 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6060 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6061 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6062 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6063 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6064 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6065 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6066 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6067 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6068 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6069 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6070 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6071 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6072 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6073 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6074 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6075 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6076 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6077 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6078 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6079 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6080 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6081 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6082 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6083 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6084 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6085 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6086 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6087 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6088 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6089 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6090 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6091 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6092 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6093 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6094 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6095 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6096 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6097 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6098 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6099 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6100 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6101 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6102 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6103 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6104 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6105 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6106 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6107 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6108 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6109 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6110 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6111 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6112 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6113 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6114 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6115 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6116 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6117 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6118 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6119 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6120 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6121 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6122 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6123 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6124 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6125 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6126 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6127 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6128 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6129 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6130 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6131 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6132 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6133 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6134 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6135 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6136 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6137 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6138 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6139 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6140 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6141 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6142 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6143 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6144 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6145 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6146 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6147 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6148 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6149 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6150 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6151 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6152 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6153 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6154 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6155 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6156 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6157 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6158 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6159 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6160 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6161 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6162 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6163 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6164 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6165 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6166 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6167 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6168 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6169 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6170 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6171 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6172 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6173 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6174 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6175 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6176 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6177 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6178 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6179 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6180 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6181 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6182 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6183 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6184 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6185 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6186 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6187 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6188 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6189 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6190 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6191 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6192 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6193 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6194 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6195 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6196 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6197 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6198 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6199 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6200 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6201 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6202 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6203 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6204 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6205 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6206 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6207 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6208 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6209 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6210 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6211 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6212 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6213 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6214 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6215 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6216 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6217 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6218 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6219 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6220 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6221 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6222 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6223 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6224 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6225 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6226 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6227 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6228 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6229 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6230 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6231 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6232 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6233 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6234 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6235 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6236 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6237 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6238 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6239 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6240 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6241 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6242 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6243 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6244 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6245 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6246 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6247 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6248 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6249 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6250 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6251 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6252 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6253 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6254 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6255 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6256 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6257 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6258 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6259 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6260 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6261 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6262 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6263 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6264 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6265 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6266 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6267 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6268 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6269 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6270 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6271 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6272 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6273 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6274 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6275 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6276 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6277 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6278 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6279 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6280 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6281 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6282 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6283 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6284 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6285 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6286 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6287 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6288 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6289 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6290 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6291 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6292 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6293 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6294 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6295 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6296 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6297 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6298 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6299 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6300 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6301 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6302 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6303 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6304 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6305 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6306 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6307 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6308 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6309 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6310 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6311 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6312 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6313 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6314 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6315 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6316 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6317 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6318 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6319 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6320 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6321 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6322 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6323 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6324 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6325 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6326 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6327 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6328 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6329 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6330 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6331 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6332 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6333 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6334 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6335 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6336 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6337 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6338 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6339 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6340 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6341 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6342 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6343 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6344 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6345 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6346 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6347 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6348 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6349 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6350 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6351 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6352 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6353 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6354 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6355 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6356 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6357 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6358 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6359 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6360 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6361 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6362 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6363 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6364 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6365 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6366 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6367 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6368 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6369 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6370 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6371 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6372 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6373 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6374 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6375 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6376 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6377 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6378 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6379 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6380 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6381 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6382 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6383 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6384 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6385 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6386 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6387 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6388 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6389 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6390 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6391 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6392 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6393 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6394 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6395 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6396 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6397 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6398 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6399 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6400 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6401 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6402 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6403 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6404 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6405 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6406 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6407 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6408 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6409 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6410 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6411 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6412 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6413 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6414 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6415 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6416 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6417 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6418 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6419 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6420 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6421 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6422 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6423 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6424 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6425 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6426 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6427 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6428 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6429 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6430 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6431 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6432 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6433 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6434 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6435 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6436 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6437 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6438 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6439 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6440 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6441 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6442 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6443 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6444 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6445 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6446 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6447 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6448 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6449 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6450 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6451 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6452 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6453 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6454 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6455 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6456 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6457 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6458 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6459 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6460 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6461 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6462 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6463 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6464 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6465 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6466 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6467 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6468 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6469 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6470 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6471 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6472 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6473 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6474 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6475 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6476 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6477 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6478 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6479 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6480 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6481 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6482 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6483 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6484 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6485 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6486 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6487 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6488 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6489 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6490 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6491 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6492 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6493 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6494 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6495 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6496 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6497 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6498 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6499 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6500 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6501 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6502 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6503 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6504 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6505 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6506 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6507 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6508 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6509 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6510 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6511 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6512 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6513 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6514 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6515 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6516 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6517 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6518 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6519 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6520 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6521 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6522 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6523 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6524 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6525 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6526 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6527 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6528 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6529 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6530 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6531 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6532 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6533 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6534 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6535 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6536 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6537 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6538 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6539 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6540 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6541 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6542 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6543 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6544 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6545 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6546 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6547 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6548 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6549 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6550 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6551 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6552 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6553 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6554 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6555 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6556 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6557 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6558 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6559 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6560 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6561 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6562 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6563 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6564 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6565 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6566 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6567 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6568 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6569 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6570 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6571 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6572 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6573 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6574 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6575 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6576 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6577 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6578 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6579 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6580 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6581 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6582 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6583 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6584 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6585 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6586 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6587 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6588 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6589 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6590 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6591 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6592 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6593 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6594 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6595 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6596 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6597 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6598 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6599 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6600 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6601 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6602 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6603 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6604 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6605 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6606 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6607 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6608 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6609 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6610 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6611 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6612 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6613 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6614 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6615 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6616 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6617 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6618 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6619 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6620 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6621 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6622 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6623 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6624 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6625 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6626 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6627 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6628 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6629 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6630 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6631 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6632 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6633 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6634 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6635 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6636 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6637 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6638 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6639 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6640 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6641 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6642 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6643 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6644 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6645 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6646 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6647 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6648 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6649 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6650 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6651 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6652 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6653 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6654 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6655 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6656 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6657 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6658 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6659 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6660 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6661 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6662 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6663 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6664 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6665 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6666 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6667 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6668 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6669 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6670 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6671 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6672 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6673 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6674 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6675 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6676 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6677 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6678 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6679 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6680 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6681 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6682 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6683 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6684 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6685 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6686 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6687 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6688 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6689 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6690 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6691 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6692 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6693 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6694 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6695 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6696 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6697 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6698 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6699 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6700 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6701 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6702 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6703 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6704 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6705 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6706 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6707 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6708 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6709 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6710 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6711 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6712 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6713 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6714 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6715 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6716 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6717 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6718 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6719 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6720 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6721 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6722 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6723 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6724 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6725 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6726 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6727 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6728 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6729 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6730 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6731 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6732 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6733 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6734 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6735 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6736 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6737 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6738 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6739 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6740 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6741 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6742 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6743 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6744 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6745 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6746 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6747 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6748 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6749 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6750 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6751 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6752 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6753 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6754 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6755 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6756 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6757 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6758 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6759 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6760 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6761 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6762 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6763 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6764 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6765 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6766 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6767 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6768 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6769 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6770 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6771 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6772 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6773 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6774 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6775 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6776 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6777 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6778 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6779 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6780 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6781 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6782 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6783 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6784 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6785 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6786 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6787 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6788 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6789 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6790 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6791 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6792 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6793 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6794 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6795 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6796 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6797 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6798 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6799 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6800 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6801 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6802 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6803 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6804 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6805 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6806 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6807 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6808 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6809 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6810 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6811 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6812 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6813 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6814 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6815 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6816 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6817 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6818 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6819 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6820 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6821 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6822 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6823 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6824 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6825 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6826 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6827 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6828 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6829 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6830 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6831 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6832 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6833 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6834 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6835 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6836 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6837 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6838 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6839 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6840 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6841 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6842 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6843 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6844 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6845 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6846 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6847 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6848 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6849 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6850 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6851 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6852 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6853 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            6854 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            6855 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            6856 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            6857 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            6858 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            6859 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            6860 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            6861 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            6862 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? RedstoneWireConnectionExtensions.FromString(properties["east"].GetString()) : East,
            North = properties.Contains("north") ? RedstoneWireConnectionExtensions.FromString(properties["north"].GetString()) : North,
            Power = properties.Contains("power") ? int.Parse(properties["power"].GetString()) : Power,
            South = properties.Contains("south") ? RedstoneWireConnectionExtensions.FromString(properties["south"].GetString()) : South,
            West = properties.Contains("west") ? RedstoneWireConnectionExtensions.FromString(properties["west"].GetString()) : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToName())),
            ("north", new StringTag(North.ToName())),
            ("power", new StringTag(Power.ToString())),
            ("south", new StringTag(South.ToName())),
            ("west", new StringTag(West.ToName()))
        );
    }
    
}

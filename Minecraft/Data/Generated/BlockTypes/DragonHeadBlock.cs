using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DragonHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 9836,
                    1 => 9837,
                    2 => 9838,
                    3 => 9839,
                    4 => 9840,
                    5 => 9841,
                    6 => 9842,
                    7 => 9843,
                    8 => 9844,
                    9 => 9845,
                    10 => 9846,
                    11 => 9847,
                    12 => 9848,
                    13 => 9849,
                    14 => 9850,
                    15 => 9851,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 9852,
                    1 => 9853,
                    2 => 9854,
                    3 => 9855,
                    4 => 9856,
                    5 => 9857,
                    6 => 9858,
                    7 => 9859,
                    8 => 9860,
                    9 => 9861,
                    10 => 9862,
                    11 => 9863,
                    12 => 9864,
                    13 => 9865,
                    14 => 9866,
                    15 => 9867,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9836 => new DragonHeadBlock(Identifier, true, 0),
            9837 => new DragonHeadBlock(Identifier, true, 1),
            9838 => new DragonHeadBlock(Identifier, true, 2),
            9839 => new DragonHeadBlock(Identifier, true, 3),
            9840 => new DragonHeadBlock(Identifier, true, 4),
            9841 => new DragonHeadBlock(Identifier, true, 5),
            9842 => new DragonHeadBlock(Identifier, true, 6),
            9843 => new DragonHeadBlock(Identifier, true, 7),
            9844 => new DragonHeadBlock(Identifier, true, 8),
            9845 => new DragonHeadBlock(Identifier, true, 9),
            9846 => new DragonHeadBlock(Identifier, true, 10),
            9847 => new DragonHeadBlock(Identifier, true, 11),
            9848 => new DragonHeadBlock(Identifier, true, 12),
            9849 => new DragonHeadBlock(Identifier, true, 13),
            9850 => new DragonHeadBlock(Identifier, true, 14),
            9851 => new DragonHeadBlock(Identifier, true, 15),
            9852 => new DragonHeadBlock(Identifier, false, 0),
            9853 => new DragonHeadBlock(Identifier, false, 1),
            9854 => new DragonHeadBlock(Identifier, false, 2),
            9855 => new DragonHeadBlock(Identifier, false, 3),
            9856 => new DragonHeadBlock(Identifier, false, 4),
            9857 => new DragonHeadBlock(Identifier, false, 5),
            9858 => new DragonHeadBlock(Identifier, false, 6),
            9859 => new DragonHeadBlock(Identifier, false, 7),
            9860 => new DragonHeadBlock(Identifier, false, 8),
            9861 => new DragonHeadBlock(Identifier, false, 9),
            9862 => new DragonHeadBlock(Identifier, false, 10),
            9863 => new DragonHeadBlock(Identifier, false, 11),
            9864 => new DragonHeadBlock(Identifier, false, 12),
            9865 => new DragonHeadBlock(Identifier, false, 13),
            9866 => new DragonHeadBlock(Identifier, false, 14),
            9867 => new DragonHeadBlock(Identifier, false, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties["powered"].GetString() == "true",
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}

using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TurtleEggBlock(Identifier Identifier, int Eggs, int Hatch) : IBlock {

    public uint StateId {
        get {
            return Eggs switch {
                1 => Hatch switch {
                    0 => 13811,
                    1 => 13812,
                    2 => 13813,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                2 => Hatch switch {
                    0 => 13814,
                    1 => 13815,
                    2 => 13816,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                3 => Hatch switch {
                    0 => 13817,
                    1 => 13818,
                    2 => 13819,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                4 => Hatch switch {
                    0 => 13820,
                    1 => 13821,
                    2 => 13822,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Eggs), Eggs, "Unknown value for property eggs.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13811 => new TurtleEggBlock(Identifier, 1, 0),
            13812 => new TurtleEggBlock(Identifier, 1, 1),
            13813 => new TurtleEggBlock(Identifier, 1, 2),
            13814 => new TurtleEggBlock(Identifier, 2, 0),
            13815 => new TurtleEggBlock(Identifier, 2, 1),
            13816 => new TurtleEggBlock(Identifier, 2, 2),
            13817 => new TurtleEggBlock(Identifier, 3, 0),
            13818 => new TurtleEggBlock(Identifier, 3, 1),
            13819 => new TurtleEggBlock(Identifier, 3, 2),
            13820 => new TurtleEggBlock(Identifier, 4, 0),
            13821 => new TurtleEggBlock(Identifier, 4, 1),
            13822 => new TurtleEggBlock(Identifier, 4, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Eggs = int.Parse(properties["eggs"].GetString()),
            Hatch = int.Parse(properties["hatch"].GetString()),
        };
    }
    
}

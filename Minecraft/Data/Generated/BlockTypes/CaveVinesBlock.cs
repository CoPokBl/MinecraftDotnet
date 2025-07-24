using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CaveVinesBlock(Identifier Identifier, int Age, bool Berries) : IBlock {

    public Identifier Category => "minecraft:cave_vines";
    public int ProtocolId => 1044;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "cave_vines";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:glow_berries";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 1.0, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.cave_vines";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => Berries switch {
                    true => 25829,
                    false => 25830,
                },
                1 => Berries switch {
                    true => 25831,
                    false => 25832,
                },
                2 => Berries switch {
                    true => 25833,
                    false => 25834,
                },
                3 => Berries switch {
                    true => 25835,
                    false => 25836,
                },
                4 => Berries switch {
                    true => 25837,
                    false => 25838,
                },
                5 => Berries switch {
                    true => 25839,
                    false => 25840,
                },
                6 => Berries switch {
                    true => 25841,
                    false => 25842,
                },
                7 => Berries switch {
                    true => 25843,
                    false => 25844,
                },
                8 => Berries switch {
                    true => 25845,
                    false => 25846,
                },
                9 => Berries switch {
                    true => 25847,
                    false => 25848,
                },
                10 => Berries switch {
                    true => 25849,
                    false => 25850,
                },
                11 => Berries switch {
                    true => 25851,
                    false => 25852,
                },
                12 => Berries switch {
                    true => 25853,
                    false => 25854,
                },
                13 => Berries switch {
                    true => 25855,
                    false => 25856,
                },
                14 => Berries switch {
                    true => 25857,
                    false => 25858,
                },
                15 => Berries switch {
                    true => 25859,
                    false => 25860,
                },
                16 => Berries switch {
                    true => 25861,
                    false => 25862,
                },
                17 => Berries switch {
                    true => 25863,
                    false => 25864,
                },
                18 => Berries switch {
                    true => 25865,
                    false => 25866,
                },
                19 => Berries switch {
                    true => 25867,
                    false => 25868,
                },
                20 => Berries switch {
                    true => 25869,
                    false => 25870,
                },
                21 => Berries switch {
                    true => 25871,
                    false => 25872,
                },
                22 => Berries switch {
                    true => 25873,
                    false => 25874,
                },
                23 => Berries switch {
                    true => 25875,
                    false => 25876,
                },
                24 => Berries switch {
                    true => 25877,
                    false => 25878,
                },
                25 => Berries switch {
                    true => 25879,
                    false => 25880,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25829 => new CaveVinesBlock(Identifier, 0, true),
            25830 => new CaveVinesBlock(Identifier, 0, false),
            25831 => new CaveVinesBlock(Identifier, 1, true),
            25832 => new CaveVinesBlock(Identifier, 1, false),
            25833 => new CaveVinesBlock(Identifier, 2, true),
            25834 => new CaveVinesBlock(Identifier, 2, false),
            25835 => new CaveVinesBlock(Identifier, 3, true),
            25836 => new CaveVinesBlock(Identifier, 3, false),
            25837 => new CaveVinesBlock(Identifier, 4, true),
            25838 => new CaveVinesBlock(Identifier, 4, false),
            25839 => new CaveVinesBlock(Identifier, 5, true),
            25840 => new CaveVinesBlock(Identifier, 5, false),
            25841 => new CaveVinesBlock(Identifier, 6, true),
            25842 => new CaveVinesBlock(Identifier, 6, false),
            25843 => new CaveVinesBlock(Identifier, 7, true),
            25844 => new CaveVinesBlock(Identifier, 7, false),
            25845 => new CaveVinesBlock(Identifier, 8, true),
            25846 => new CaveVinesBlock(Identifier, 8, false),
            25847 => new CaveVinesBlock(Identifier, 9, true),
            25848 => new CaveVinesBlock(Identifier, 9, false),
            25849 => new CaveVinesBlock(Identifier, 10, true),
            25850 => new CaveVinesBlock(Identifier, 10, false),
            25851 => new CaveVinesBlock(Identifier, 11, true),
            25852 => new CaveVinesBlock(Identifier, 11, false),
            25853 => new CaveVinesBlock(Identifier, 12, true),
            25854 => new CaveVinesBlock(Identifier, 12, false),
            25855 => new CaveVinesBlock(Identifier, 13, true),
            25856 => new CaveVinesBlock(Identifier, 13, false),
            25857 => new CaveVinesBlock(Identifier, 14, true),
            25858 => new CaveVinesBlock(Identifier, 14, false),
            25859 => new CaveVinesBlock(Identifier, 15, true),
            25860 => new CaveVinesBlock(Identifier, 15, false),
            25861 => new CaveVinesBlock(Identifier, 16, true),
            25862 => new CaveVinesBlock(Identifier, 16, false),
            25863 => new CaveVinesBlock(Identifier, 17, true),
            25864 => new CaveVinesBlock(Identifier, 17, false),
            25865 => new CaveVinesBlock(Identifier, 18, true),
            25866 => new CaveVinesBlock(Identifier, 18, false),
            25867 => new CaveVinesBlock(Identifier, 19, true),
            25868 => new CaveVinesBlock(Identifier, 19, false),
            25869 => new CaveVinesBlock(Identifier, 20, true),
            25870 => new CaveVinesBlock(Identifier, 20, false),
            25871 => new CaveVinesBlock(Identifier, 21, true),
            25872 => new CaveVinesBlock(Identifier, 21, false),
            25873 => new CaveVinesBlock(Identifier, 22, true),
            25874 => new CaveVinesBlock(Identifier, 22, false),
            25875 => new CaveVinesBlock(Identifier, 23, true),
            25876 => new CaveVinesBlock(Identifier, 23, false),
            25877 => new CaveVinesBlock(Identifier, 24, true),
            25878 => new CaveVinesBlock(Identifier, 24, false),
            25879 => new CaveVinesBlock(Identifier, 25, true),
            25880 => new CaveVinesBlock(Identifier, 25, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
            Berries = properties["berries"].GetString() == "true",
        };
    }
    
}

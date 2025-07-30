using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PiglinHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {

    public Identifier Category => "minecraft:skull";
    public int ProtocolId => 433;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:skull";
    public Identifier? Item => "minecraft:piglin_head";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.5, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.5, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.5, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.piglin_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 9876,
                    1 => 9877,
                    2 => 9878,
                    3 => 9879,
                    4 => 9880,
                    5 => 9881,
                    6 => 9882,
                    7 => 9883,
                    8 => 9884,
                    9 => 9885,
                    10 => 9886,
                    11 => 9887,
                    12 => 9888,
                    13 => 9889,
                    14 => 9890,
                    15 => 9891,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 9892,
                    1 => 9893,
                    2 => 9894,
                    3 => 9895,
                    4 => 9896,
                    5 => 9897,
                    6 => 9898,
                    7 => 9899,
                    8 => 9900,
                    9 => 9901,
                    10 => 9902,
                    11 => 9903,
                    12 => 9904,
                    13 => 9905,
                    14 => 9906,
                    15 => 9907,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9876 => new PiglinHeadBlock(Identifier, true, 0),
            9877 => new PiglinHeadBlock(Identifier, true, 1),
            9878 => new PiglinHeadBlock(Identifier, true, 2),
            9879 => new PiglinHeadBlock(Identifier, true, 3),
            9880 => new PiglinHeadBlock(Identifier, true, 4),
            9881 => new PiglinHeadBlock(Identifier, true, 5),
            9882 => new PiglinHeadBlock(Identifier, true, 6),
            9883 => new PiglinHeadBlock(Identifier, true, 7),
            9884 => new PiglinHeadBlock(Identifier, true, 8),
            9885 => new PiglinHeadBlock(Identifier, true, 9),
            9886 => new PiglinHeadBlock(Identifier, true, 10),
            9887 => new PiglinHeadBlock(Identifier, true, 11),
            9888 => new PiglinHeadBlock(Identifier, true, 12),
            9889 => new PiglinHeadBlock(Identifier, true, 13),
            9890 => new PiglinHeadBlock(Identifier, true, 14),
            9891 => new PiglinHeadBlock(Identifier, true, 15),
            9892 => new PiglinHeadBlock(Identifier, false, 0),
            9893 => new PiglinHeadBlock(Identifier, false, 1),
            9894 => new PiglinHeadBlock(Identifier, false, 2),
            9895 => new PiglinHeadBlock(Identifier, false, 3),
            9896 => new PiglinHeadBlock(Identifier, false, 4),
            9897 => new PiglinHeadBlock(Identifier, false, 5),
            9898 => new PiglinHeadBlock(Identifier, false, 6),
            9899 => new PiglinHeadBlock(Identifier, false, 7),
            9900 => new PiglinHeadBlock(Identifier, false, 8),
            9901 => new PiglinHeadBlock(Identifier, false, 9),
            9902 => new PiglinHeadBlock(Identifier, false, 10),
            9903 => new PiglinHeadBlock(Identifier, false, 11),
            9904 => new PiglinHeadBlock(Identifier, false, 12),
            9905 => new PiglinHeadBlock(Identifier, false, 13),
            9906 => new PiglinHeadBlock(Identifier, false, 14),
            9907 => new PiglinHeadBlock(Identifier, false, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties["powered"].GetString() == "true",
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("rotation", Rotation.ToString())
        );
    }
    
}

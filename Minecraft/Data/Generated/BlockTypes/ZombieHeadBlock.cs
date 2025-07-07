using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ZombieHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {

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
    public Identifier? Item => "minecraft:zombie_head";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.5, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.5, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.5, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.zombie_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 9716,
                    1 => 9717,
                    2 => 9718,
                    3 => 9719,
                    4 => 9720,
                    5 => 9721,
                    6 => 9722,
                    7 => 9723,
                    8 => 9724,
                    9 => 9725,
                    10 => 9726,
                    11 => 9727,
                    12 => 9728,
                    13 => 9729,
                    14 => 9730,
                    15 => 9731,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 9732,
                    1 => 9733,
                    2 => 9734,
                    3 => 9735,
                    4 => 9736,
                    5 => 9737,
                    6 => 9738,
                    7 => 9739,
                    8 => 9740,
                    9 => 9741,
                    10 => 9742,
                    11 => 9743,
                    12 => 9744,
                    13 => 9745,
                    14 => 9746,
                    15 => 9747,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9716 => new ZombieHeadBlock(Identifier, true, 0),
            9717 => new ZombieHeadBlock(Identifier, true, 1),
            9718 => new ZombieHeadBlock(Identifier, true, 2),
            9719 => new ZombieHeadBlock(Identifier, true, 3),
            9720 => new ZombieHeadBlock(Identifier, true, 4),
            9721 => new ZombieHeadBlock(Identifier, true, 5),
            9722 => new ZombieHeadBlock(Identifier, true, 6),
            9723 => new ZombieHeadBlock(Identifier, true, 7),
            9724 => new ZombieHeadBlock(Identifier, true, 8),
            9725 => new ZombieHeadBlock(Identifier, true, 9),
            9726 => new ZombieHeadBlock(Identifier, true, 10),
            9727 => new ZombieHeadBlock(Identifier, true, 11),
            9728 => new ZombieHeadBlock(Identifier, true, 12),
            9729 => new ZombieHeadBlock(Identifier, true, 13),
            9730 => new ZombieHeadBlock(Identifier, true, 14),
            9731 => new ZombieHeadBlock(Identifier, true, 15),
            9732 => new ZombieHeadBlock(Identifier, false, 0),
            9733 => new ZombieHeadBlock(Identifier, false, 1),
            9734 => new ZombieHeadBlock(Identifier, false, 2),
            9735 => new ZombieHeadBlock(Identifier, false, 3),
            9736 => new ZombieHeadBlock(Identifier, false, 4),
            9737 => new ZombieHeadBlock(Identifier, false, 5),
            9738 => new ZombieHeadBlock(Identifier, false, 6),
            9739 => new ZombieHeadBlock(Identifier, false, 7),
            9740 => new ZombieHeadBlock(Identifier, false, 8),
            9741 => new ZombieHeadBlock(Identifier, false, 9),
            9742 => new ZombieHeadBlock(Identifier, false, 10),
            9743 => new ZombieHeadBlock(Identifier, false, 11),
            9744 => new ZombieHeadBlock(Identifier, false, 12),
            9745 => new ZombieHeadBlock(Identifier, false, 13),
            9746 => new ZombieHeadBlock(Identifier, false, 14),
            9747 => new ZombieHeadBlock(Identifier, false, 15),
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

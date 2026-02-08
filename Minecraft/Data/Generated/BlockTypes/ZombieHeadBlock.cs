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
    public Identifier Category => "minecraft:skull";
    public int ProtocolId => 455;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
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
                    0 => 10793,
                    1 => 10794,
                    2 => 10795,
                    3 => 10796,
                    4 => 10797,
                    5 => 10798,
                    6 => 10799,
                    7 => 10800,
                    8 => 10801,
                    9 => 10802,
                    10 => 10803,
                    11 => 10804,
                    12 => 10805,
                    13 => 10806,
                    14 => 10807,
                    15 => 10808,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 10809,
                    1 => 10810,
                    2 => 10811,
                    3 => 10812,
                    4 => 10813,
                    5 => 10814,
                    6 => 10815,
                    7 => 10816,
                    8 => 10817,
                    9 => 10818,
                    10 => 10819,
                    11 => 10820,
                    12 => 10821,
                    13 => 10822,
                    14 => 10823,
                    15 => 10824,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10793 => new ZombieHeadBlock(Identifier, true, 0),
            10794 => new ZombieHeadBlock(Identifier, true, 1),
            10795 => new ZombieHeadBlock(Identifier, true, 2),
            10796 => new ZombieHeadBlock(Identifier, true, 3),
            10797 => new ZombieHeadBlock(Identifier, true, 4),
            10798 => new ZombieHeadBlock(Identifier, true, 5),
            10799 => new ZombieHeadBlock(Identifier, true, 6),
            10800 => new ZombieHeadBlock(Identifier, true, 7),
            10801 => new ZombieHeadBlock(Identifier, true, 8),
            10802 => new ZombieHeadBlock(Identifier, true, 9),
            10803 => new ZombieHeadBlock(Identifier, true, 10),
            10804 => new ZombieHeadBlock(Identifier, true, 11),
            10805 => new ZombieHeadBlock(Identifier, true, 12),
            10806 => new ZombieHeadBlock(Identifier, true, 13),
            10807 => new ZombieHeadBlock(Identifier, true, 14),
            10808 => new ZombieHeadBlock(Identifier, true, 15),
            10809 => new ZombieHeadBlock(Identifier, false, 0),
            10810 => new ZombieHeadBlock(Identifier, false, 1),
            10811 => new ZombieHeadBlock(Identifier, false, 2),
            10812 => new ZombieHeadBlock(Identifier, false, 3),
            10813 => new ZombieHeadBlock(Identifier, false, 4),
            10814 => new ZombieHeadBlock(Identifier, false, 5),
            10815 => new ZombieHeadBlock(Identifier, false, 6),
            10816 => new ZombieHeadBlock(Identifier, false, 7),
            10817 => new ZombieHeadBlock(Identifier, false, 8),
            10818 => new ZombieHeadBlock(Identifier, false, 9),
            10819 => new ZombieHeadBlock(Identifier, false, 10),
            10820 => new ZombieHeadBlock(Identifier, false, 11),
            10821 => new ZombieHeadBlock(Identifier, false, 12),
            10822 => new ZombieHeadBlock(Identifier, false, 13),
            10823 => new ZombieHeadBlock(Identifier, false, 14),
            10824 => new ZombieHeadBlock(Identifier, false, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            Rotation = properties.ChildrenMap.ContainsKey("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("rotation", Rotation.ToString())
        );
    }
    
}

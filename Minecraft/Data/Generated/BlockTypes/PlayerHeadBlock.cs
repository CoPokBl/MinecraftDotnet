using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PlayerHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
    public Identifier Category => "minecraft:player_head";
    public int ProtocolId => 457;
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
    public Identifier? Item => "minecraft:player_head";
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
    public string TranslationKey => "block.minecraft.player_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 10833,
                    1 => 10834,
                    2 => 10835,
                    3 => 10836,
                    4 => 10837,
                    5 => 10838,
                    6 => 10839,
                    7 => 10840,
                    8 => 10841,
                    9 => 10842,
                    10 => 10843,
                    11 => 10844,
                    12 => 10845,
                    13 => 10846,
                    14 => 10847,
                    15 => 10848,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 10849,
                    1 => 10850,
                    2 => 10851,
                    3 => 10852,
                    4 => 10853,
                    5 => 10854,
                    6 => 10855,
                    7 => 10856,
                    8 => 10857,
                    9 => 10858,
                    10 => 10859,
                    11 => 10860,
                    12 => 10861,
                    13 => 10862,
                    14 => 10863,
                    15 => 10864,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10833 => new PlayerHeadBlock(Identifier, true, 0),
            10834 => new PlayerHeadBlock(Identifier, true, 1),
            10835 => new PlayerHeadBlock(Identifier, true, 2),
            10836 => new PlayerHeadBlock(Identifier, true, 3),
            10837 => new PlayerHeadBlock(Identifier, true, 4),
            10838 => new PlayerHeadBlock(Identifier, true, 5),
            10839 => new PlayerHeadBlock(Identifier, true, 6),
            10840 => new PlayerHeadBlock(Identifier, true, 7),
            10841 => new PlayerHeadBlock(Identifier, true, 8),
            10842 => new PlayerHeadBlock(Identifier, true, 9),
            10843 => new PlayerHeadBlock(Identifier, true, 10),
            10844 => new PlayerHeadBlock(Identifier, true, 11),
            10845 => new PlayerHeadBlock(Identifier, true, 12),
            10846 => new PlayerHeadBlock(Identifier, true, 13),
            10847 => new PlayerHeadBlock(Identifier, true, 14),
            10848 => new PlayerHeadBlock(Identifier, true, 15),
            10849 => new PlayerHeadBlock(Identifier, false, 0),
            10850 => new PlayerHeadBlock(Identifier, false, 1),
            10851 => new PlayerHeadBlock(Identifier, false, 2),
            10852 => new PlayerHeadBlock(Identifier, false, 3),
            10853 => new PlayerHeadBlock(Identifier, false, 4),
            10854 => new PlayerHeadBlock(Identifier, false, 5),
            10855 => new PlayerHeadBlock(Identifier, false, 6),
            10856 => new PlayerHeadBlock(Identifier, false, 7),
            10857 => new PlayerHeadBlock(Identifier, false, 8),
            10858 => new PlayerHeadBlock(Identifier, false, 9),
            10859 => new PlayerHeadBlock(Identifier, false, 10),
            10860 => new PlayerHeadBlock(Identifier, false, 11),
            10861 => new PlayerHeadBlock(Identifier, false, 12),
            10862 => new PlayerHeadBlock(Identifier, false, 13),
            10863 => new PlayerHeadBlock(Identifier, false, 14),
            10864 => new PlayerHeadBlock(Identifier, false, 15),
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

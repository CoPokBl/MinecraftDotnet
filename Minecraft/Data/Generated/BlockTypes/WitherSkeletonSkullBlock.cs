using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WitherSkeletonSkullBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
    public Identifier Category => "minecraft:wither_skull";
    public int ProtocolId => 453;
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
    public Identifier? Item => "minecraft:wither_skeleton_skull";
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
    public string TranslationKey => "block.minecraft.wither_skeleton_skull";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 10753,
                    1 => 10754,
                    2 => 10755,
                    3 => 10756,
                    4 => 10757,
                    5 => 10758,
                    6 => 10759,
                    7 => 10760,
                    8 => 10761,
                    9 => 10762,
                    10 => 10763,
                    11 => 10764,
                    12 => 10765,
                    13 => 10766,
                    14 => 10767,
                    15 => 10768,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 10769,
                    1 => 10770,
                    2 => 10771,
                    3 => 10772,
                    4 => 10773,
                    5 => 10774,
                    6 => 10775,
                    7 => 10776,
                    8 => 10777,
                    9 => 10778,
                    10 => 10779,
                    11 => 10780,
                    12 => 10781,
                    13 => 10782,
                    14 => 10783,
                    15 => 10784,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10753 => new WitherSkeletonSkullBlock(Identifier, true, 0),
            10754 => new WitherSkeletonSkullBlock(Identifier, true, 1),
            10755 => new WitherSkeletonSkullBlock(Identifier, true, 2),
            10756 => new WitherSkeletonSkullBlock(Identifier, true, 3),
            10757 => new WitherSkeletonSkullBlock(Identifier, true, 4),
            10758 => new WitherSkeletonSkullBlock(Identifier, true, 5),
            10759 => new WitherSkeletonSkullBlock(Identifier, true, 6),
            10760 => new WitherSkeletonSkullBlock(Identifier, true, 7),
            10761 => new WitherSkeletonSkullBlock(Identifier, true, 8),
            10762 => new WitherSkeletonSkullBlock(Identifier, true, 9),
            10763 => new WitherSkeletonSkullBlock(Identifier, true, 10),
            10764 => new WitherSkeletonSkullBlock(Identifier, true, 11),
            10765 => new WitherSkeletonSkullBlock(Identifier, true, 12),
            10766 => new WitherSkeletonSkullBlock(Identifier, true, 13),
            10767 => new WitherSkeletonSkullBlock(Identifier, true, 14),
            10768 => new WitherSkeletonSkullBlock(Identifier, true, 15),
            10769 => new WitherSkeletonSkullBlock(Identifier, false, 0),
            10770 => new WitherSkeletonSkullBlock(Identifier, false, 1),
            10771 => new WitherSkeletonSkullBlock(Identifier, false, 2),
            10772 => new WitherSkeletonSkullBlock(Identifier, false, 3),
            10773 => new WitherSkeletonSkullBlock(Identifier, false, 4),
            10774 => new WitherSkeletonSkullBlock(Identifier, false, 5),
            10775 => new WitherSkeletonSkullBlock(Identifier, false, 6),
            10776 => new WitherSkeletonSkullBlock(Identifier, false, 7),
            10777 => new WitherSkeletonSkullBlock(Identifier, false, 8),
            10778 => new WitherSkeletonSkullBlock(Identifier, false, 9),
            10779 => new WitherSkeletonSkullBlock(Identifier, false, 10),
            10780 => new WitherSkeletonSkullBlock(Identifier, false, 11),
            10781 => new WitherSkeletonSkullBlock(Identifier, false, 12),
            10782 => new WitherSkeletonSkullBlock(Identifier, false, 13),
            10783 => new WitherSkeletonSkullBlock(Identifier, false, 14),
            10784 => new WitherSkeletonSkullBlock(Identifier, false, 15),
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

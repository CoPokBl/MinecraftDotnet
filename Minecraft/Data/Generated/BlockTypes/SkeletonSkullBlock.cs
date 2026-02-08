using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SkeletonSkullBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
    public Identifier Category => "minecraft:skull";
    public int ProtocolId => 451;
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
    public Identifier? Item => "minecraft:skeleton_skull";
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
    public string TranslationKey => "block.minecraft.skeleton_skull";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 10713,
                    1 => 10714,
                    2 => 10715,
                    3 => 10716,
                    4 => 10717,
                    5 => 10718,
                    6 => 10719,
                    7 => 10720,
                    8 => 10721,
                    9 => 10722,
                    10 => 10723,
                    11 => 10724,
                    12 => 10725,
                    13 => 10726,
                    14 => 10727,
                    15 => 10728,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 10729,
                    1 => 10730,
                    2 => 10731,
                    3 => 10732,
                    4 => 10733,
                    5 => 10734,
                    6 => 10735,
                    7 => 10736,
                    8 => 10737,
                    9 => 10738,
                    10 => 10739,
                    11 => 10740,
                    12 => 10741,
                    13 => 10742,
                    14 => 10743,
                    15 => 10744,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10713 => new SkeletonSkullBlock(Identifier, true, 0),
            10714 => new SkeletonSkullBlock(Identifier, true, 1),
            10715 => new SkeletonSkullBlock(Identifier, true, 2),
            10716 => new SkeletonSkullBlock(Identifier, true, 3),
            10717 => new SkeletonSkullBlock(Identifier, true, 4),
            10718 => new SkeletonSkullBlock(Identifier, true, 5),
            10719 => new SkeletonSkullBlock(Identifier, true, 6),
            10720 => new SkeletonSkullBlock(Identifier, true, 7),
            10721 => new SkeletonSkullBlock(Identifier, true, 8),
            10722 => new SkeletonSkullBlock(Identifier, true, 9),
            10723 => new SkeletonSkullBlock(Identifier, true, 10),
            10724 => new SkeletonSkullBlock(Identifier, true, 11),
            10725 => new SkeletonSkullBlock(Identifier, true, 12),
            10726 => new SkeletonSkullBlock(Identifier, true, 13),
            10727 => new SkeletonSkullBlock(Identifier, true, 14),
            10728 => new SkeletonSkullBlock(Identifier, true, 15),
            10729 => new SkeletonSkullBlock(Identifier, false, 0),
            10730 => new SkeletonSkullBlock(Identifier, false, 1),
            10731 => new SkeletonSkullBlock(Identifier, false, 2),
            10732 => new SkeletonSkullBlock(Identifier, false, 3),
            10733 => new SkeletonSkullBlock(Identifier, false, 4),
            10734 => new SkeletonSkullBlock(Identifier, false, 5),
            10735 => new SkeletonSkullBlock(Identifier, false, 6),
            10736 => new SkeletonSkullBlock(Identifier, false, 7),
            10737 => new SkeletonSkullBlock(Identifier, false, 8),
            10738 => new SkeletonSkullBlock(Identifier, false, 9),
            10739 => new SkeletonSkullBlock(Identifier, false, 10),
            10740 => new SkeletonSkullBlock(Identifier, false, 11),
            10741 => new SkeletonSkullBlock(Identifier, false, 12),
            10742 => new SkeletonSkullBlock(Identifier, false, 13),
            10743 => new SkeletonSkullBlock(Identifier, false, 14),
            10744 => new SkeletonSkullBlock(Identifier, false, 15),
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

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
    public int ProtocolId => 423;
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
                    0 => 9676,
                    1 => 9677,
                    2 => 9678,
                    3 => 9679,
                    4 => 9680,
                    5 => 9681,
                    6 => 9682,
                    7 => 9683,
                    8 => 9684,
                    9 => 9685,
                    10 => 9686,
                    11 => 9687,
                    12 => 9688,
                    13 => 9689,
                    14 => 9690,
                    15 => 9691,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 9692,
                    1 => 9693,
                    2 => 9694,
                    3 => 9695,
                    4 => 9696,
                    5 => 9697,
                    6 => 9698,
                    7 => 9699,
                    8 => 9700,
                    9 => 9701,
                    10 => 9702,
                    11 => 9703,
                    12 => 9704,
                    13 => 9705,
                    14 => 9706,
                    15 => 9707,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9676 => new WitherSkeletonSkullBlock(Identifier, true, 0),
            9677 => new WitherSkeletonSkullBlock(Identifier, true, 1),
            9678 => new WitherSkeletonSkullBlock(Identifier, true, 2),
            9679 => new WitherSkeletonSkullBlock(Identifier, true, 3),
            9680 => new WitherSkeletonSkullBlock(Identifier, true, 4),
            9681 => new WitherSkeletonSkullBlock(Identifier, true, 5),
            9682 => new WitherSkeletonSkullBlock(Identifier, true, 6),
            9683 => new WitherSkeletonSkullBlock(Identifier, true, 7),
            9684 => new WitherSkeletonSkullBlock(Identifier, true, 8),
            9685 => new WitherSkeletonSkullBlock(Identifier, true, 9),
            9686 => new WitherSkeletonSkullBlock(Identifier, true, 10),
            9687 => new WitherSkeletonSkullBlock(Identifier, true, 11),
            9688 => new WitherSkeletonSkullBlock(Identifier, true, 12),
            9689 => new WitherSkeletonSkullBlock(Identifier, true, 13),
            9690 => new WitherSkeletonSkullBlock(Identifier, true, 14),
            9691 => new WitherSkeletonSkullBlock(Identifier, true, 15),
            9692 => new WitherSkeletonSkullBlock(Identifier, false, 0),
            9693 => new WitherSkeletonSkullBlock(Identifier, false, 1),
            9694 => new WitherSkeletonSkullBlock(Identifier, false, 2),
            9695 => new WitherSkeletonSkullBlock(Identifier, false, 3),
            9696 => new WitherSkeletonSkullBlock(Identifier, false, 4),
            9697 => new WitherSkeletonSkullBlock(Identifier, false, 5),
            9698 => new WitherSkeletonSkullBlock(Identifier, false, 6),
            9699 => new WitherSkeletonSkullBlock(Identifier, false, 7),
            9700 => new WitherSkeletonSkullBlock(Identifier, false, 8),
            9701 => new WitherSkeletonSkullBlock(Identifier, false, 9),
            9702 => new WitherSkeletonSkullBlock(Identifier, false, 10),
            9703 => new WitherSkeletonSkullBlock(Identifier, false, 11),
            9704 => new WitherSkeletonSkullBlock(Identifier, false, 12),
            9705 => new WitherSkeletonSkullBlock(Identifier, false, 13),
            9706 => new WitherSkeletonSkullBlock(Identifier, false, 14),
            9707 => new WitherSkeletonSkullBlock(Identifier, false, 15),
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

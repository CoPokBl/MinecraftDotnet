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
    public int ProtocolId => 427;
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
                    0 => 9756,
                    1 => 9757,
                    2 => 9758,
                    3 => 9759,
                    4 => 9760,
                    5 => 9761,
                    6 => 9762,
                    7 => 9763,
                    8 => 9764,
                    9 => 9765,
                    10 => 9766,
                    11 => 9767,
                    12 => 9768,
                    13 => 9769,
                    14 => 9770,
                    15 => 9771,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 9772,
                    1 => 9773,
                    2 => 9774,
                    3 => 9775,
                    4 => 9776,
                    5 => 9777,
                    6 => 9778,
                    7 => 9779,
                    8 => 9780,
                    9 => 9781,
                    10 => 9782,
                    11 => 9783,
                    12 => 9784,
                    13 => 9785,
                    14 => 9786,
                    15 => 9787,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9756 => new PlayerHeadBlock(Identifier, true, 0),
            9757 => new PlayerHeadBlock(Identifier, true, 1),
            9758 => new PlayerHeadBlock(Identifier, true, 2),
            9759 => new PlayerHeadBlock(Identifier, true, 3),
            9760 => new PlayerHeadBlock(Identifier, true, 4),
            9761 => new PlayerHeadBlock(Identifier, true, 5),
            9762 => new PlayerHeadBlock(Identifier, true, 6),
            9763 => new PlayerHeadBlock(Identifier, true, 7),
            9764 => new PlayerHeadBlock(Identifier, true, 8),
            9765 => new PlayerHeadBlock(Identifier, true, 9),
            9766 => new PlayerHeadBlock(Identifier, true, 10),
            9767 => new PlayerHeadBlock(Identifier, true, 11),
            9768 => new PlayerHeadBlock(Identifier, true, 12),
            9769 => new PlayerHeadBlock(Identifier, true, 13),
            9770 => new PlayerHeadBlock(Identifier, true, 14),
            9771 => new PlayerHeadBlock(Identifier, true, 15),
            9772 => new PlayerHeadBlock(Identifier, false, 0),
            9773 => new PlayerHeadBlock(Identifier, false, 1),
            9774 => new PlayerHeadBlock(Identifier, false, 2),
            9775 => new PlayerHeadBlock(Identifier, false, 3),
            9776 => new PlayerHeadBlock(Identifier, false, 4),
            9777 => new PlayerHeadBlock(Identifier, false, 5),
            9778 => new PlayerHeadBlock(Identifier, false, 6),
            9779 => new PlayerHeadBlock(Identifier, false, 7),
            9780 => new PlayerHeadBlock(Identifier, false, 8),
            9781 => new PlayerHeadBlock(Identifier, false, 9),
            9782 => new PlayerHeadBlock(Identifier, false, 10),
            9783 => new PlayerHeadBlock(Identifier, false, 11),
            9784 => new PlayerHeadBlock(Identifier, false, 12),
            9785 => new PlayerHeadBlock(Identifier, false, 13),
            9786 => new PlayerHeadBlock(Identifier, false, 14),
            9787 => new PlayerHeadBlock(Identifier, false, 15),
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

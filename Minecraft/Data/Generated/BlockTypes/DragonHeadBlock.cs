using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DragonHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
    public Identifier Category => "minecraft:skull";
    public int ProtocolId => 461;
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
    public Identifier? Item => "minecraft:dragon_head";
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
    public string TranslationKey => "block.minecraft.dragon_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 10913,
                    1 => 10914,
                    2 => 10915,
                    3 => 10916,
                    4 => 10917,
                    5 => 10918,
                    6 => 10919,
                    7 => 10920,
                    8 => 10921,
                    9 => 10922,
                    10 => 10923,
                    11 => 10924,
                    12 => 10925,
                    13 => 10926,
                    14 => 10927,
                    15 => 10928,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 10929,
                    1 => 10930,
                    2 => 10931,
                    3 => 10932,
                    4 => 10933,
                    5 => 10934,
                    6 => 10935,
                    7 => 10936,
                    8 => 10937,
                    9 => 10938,
                    10 => 10939,
                    11 => 10940,
                    12 => 10941,
                    13 => 10942,
                    14 => 10943,
                    15 => 10944,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10913 => new DragonHeadBlock(Identifier, true, 0),
            10914 => new DragonHeadBlock(Identifier, true, 1),
            10915 => new DragonHeadBlock(Identifier, true, 2),
            10916 => new DragonHeadBlock(Identifier, true, 3),
            10917 => new DragonHeadBlock(Identifier, true, 4),
            10918 => new DragonHeadBlock(Identifier, true, 5),
            10919 => new DragonHeadBlock(Identifier, true, 6),
            10920 => new DragonHeadBlock(Identifier, true, 7),
            10921 => new DragonHeadBlock(Identifier, true, 8),
            10922 => new DragonHeadBlock(Identifier, true, 9),
            10923 => new DragonHeadBlock(Identifier, true, 10),
            10924 => new DragonHeadBlock(Identifier, true, 11),
            10925 => new DragonHeadBlock(Identifier, true, 12),
            10926 => new DragonHeadBlock(Identifier, true, 13),
            10927 => new DragonHeadBlock(Identifier, true, 14),
            10928 => new DragonHeadBlock(Identifier, true, 15),
            10929 => new DragonHeadBlock(Identifier, false, 0),
            10930 => new DragonHeadBlock(Identifier, false, 1),
            10931 => new DragonHeadBlock(Identifier, false, 2),
            10932 => new DragonHeadBlock(Identifier, false, 3),
            10933 => new DragonHeadBlock(Identifier, false, 4),
            10934 => new DragonHeadBlock(Identifier, false, 5),
            10935 => new DragonHeadBlock(Identifier, false, 6),
            10936 => new DragonHeadBlock(Identifier, false, 7),
            10937 => new DragonHeadBlock(Identifier, false, 8),
            10938 => new DragonHeadBlock(Identifier, false, 9),
            10939 => new DragonHeadBlock(Identifier, false, 10),
            10940 => new DragonHeadBlock(Identifier, false, 11),
            10941 => new DragonHeadBlock(Identifier, false, 12),
            10942 => new DragonHeadBlock(Identifier, false, 13),
            10943 => new DragonHeadBlock(Identifier, false, 14),
            10944 => new DragonHeadBlock(Identifier, false, 15),
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

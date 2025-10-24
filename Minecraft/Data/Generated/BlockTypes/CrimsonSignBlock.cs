using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 899;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:crimson_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 21440,
                    false => 21441,
                },
                1 => Waterlogged switch {
                    true => 21442,
                    false => 21443,
                },
                2 => Waterlogged switch {
                    true => 21444,
                    false => 21445,
                },
                3 => Waterlogged switch {
                    true => 21446,
                    false => 21447,
                },
                4 => Waterlogged switch {
                    true => 21448,
                    false => 21449,
                },
                5 => Waterlogged switch {
                    true => 21450,
                    false => 21451,
                },
                6 => Waterlogged switch {
                    true => 21452,
                    false => 21453,
                },
                7 => Waterlogged switch {
                    true => 21454,
                    false => 21455,
                },
                8 => Waterlogged switch {
                    true => 21456,
                    false => 21457,
                },
                9 => Waterlogged switch {
                    true => 21458,
                    false => 21459,
                },
                10 => Waterlogged switch {
                    true => 21460,
                    false => 21461,
                },
                11 => Waterlogged switch {
                    true => 21462,
                    false => 21463,
                },
                12 => Waterlogged switch {
                    true => 21464,
                    false => 21465,
                },
                13 => Waterlogged switch {
                    true => 21466,
                    false => 21467,
                },
                14 => Waterlogged switch {
                    true => 21468,
                    false => 21469,
                },
                15 => Waterlogged switch {
                    true => 21470,
                    false => 21471,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21440 => new CrimsonSignBlock(Identifier, 0, true),
            21441 => new CrimsonSignBlock(Identifier, 0, false),
            21442 => new CrimsonSignBlock(Identifier, 1, true),
            21443 => new CrimsonSignBlock(Identifier, 1, false),
            21444 => new CrimsonSignBlock(Identifier, 2, true),
            21445 => new CrimsonSignBlock(Identifier, 2, false),
            21446 => new CrimsonSignBlock(Identifier, 3, true),
            21447 => new CrimsonSignBlock(Identifier, 3, false),
            21448 => new CrimsonSignBlock(Identifier, 4, true),
            21449 => new CrimsonSignBlock(Identifier, 4, false),
            21450 => new CrimsonSignBlock(Identifier, 5, true),
            21451 => new CrimsonSignBlock(Identifier, 5, false),
            21452 => new CrimsonSignBlock(Identifier, 6, true),
            21453 => new CrimsonSignBlock(Identifier, 6, false),
            21454 => new CrimsonSignBlock(Identifier, 7, true),
            21455 => new CrimsonSignBlock(Identifier, 7, false),
            21456 => new CrimsonSignBlock(Identifier, 8, true),
            21457 => new CrimsonSignBlock(Identifier, 8, false),
            21458 => new CrimsonSignBlock(Identifier, 9, true),
            21459 => new CrimsonSignBlock(Identifier, 9, false),
            21460 => new CrimsonSignBlock(Identifier, 10, true),
            21461 => new CrimsonSignBlock(Identifier, 10, false),
            21462 => new CrimsonSignBlock(Identifier, 11, true),
            21463 => new CrimsonSignBlock(Identifier, 11, false),
            21464 => new CrimsonSignBlock(Identifier, 12, true),
            21465 => new CrimsonSignBlock(Identifier, 12, false),
            21466 => new CrimsonSignBlock(Identifier, 13, true),
            21467 => new CrimsonSignBlock(Identifier, 13, false),
            21468 => new CrimsonSignBlock(Identifier, 14, true),
            21469 => new CrimsonSignBlock(Identifier, 14, false),
            21470 => new CrimsonSignBlock(Identifier, 15, true),
            21471 => new CrimsonSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = properties.ChildrenMap.ContainsKey("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("rotation", Rotation.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}

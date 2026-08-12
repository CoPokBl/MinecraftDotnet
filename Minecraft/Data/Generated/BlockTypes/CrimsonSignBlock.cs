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
                    true => 21642,
                    false => 21643,
                },
                1 => Waterlogged switch {
                    true => 21644,
                    false => 21645,
                },
                2 => Waterlogged switch {
                    true => 21646,
                    false => 21647,
                },
                3 => Waterlogged switch {
                    true => 21648,
                    false => 21649,
                },
                4 => Waterlogged switch {
                    true => 21650,
                    false => 21651,
                },
                5 => Waterlogged switch {
                    true => 21652,
                    false => 21653,
                },
                6 => Waterlogged switch {
                    true => 21654,
                    false => 21655,
                },
                7 => Waterlogged switch {
                    true => 21656,
                    false => 21657,
                },
                8 => Waterlogged switch {
                    true => 21658,
                    false => 21659,
                },
                9 => Waterlogged switch {
                    true => 21660,
                    false => 21661,
                },
                10 => Waterlogged switch {
                    true => 21662,
                    false => 21663,
                },
                11 => Waterlogged switch {
                    true => 21664,
                    false => 21665,
                },
                12 => Waterlogged switch {
                    true => 21666,
                    false => 21667,
                },
                13 => Waterlogged switch {
                    true => 21668,
                    false => 21669,
                },
                14 => Waterlogged switch {
                    true => 21670,
                    false => 21671,
                },
                15 => Waterlogged switch {
                    true => 21672,
                    false => 21673,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21642 => new CrimsonSignBlock(Identifier, 0, true),
            21643 => new CrimsonSignBlock(Identifier, 0, false),
            21644 => new CrimsonSignBlock(Identifier, 1, true),
            21645 => new CrimsonSignBlock(Identifier, 1, false),
            21646 => new CrimsonSignBlock(Identifier, 2, true),
            21647 => new CrimsonSignBlock(Identifier, 2, false),
            21648 => new CrimsonSignBlock(Identifier, 3, true),
            21649 => new CrimsonSignBlock(Identifier, 3, false),
            21650 => new CrimsonSignBlock(Identifier, 4, true),
            21651 => new CrimsonSignBlock(Identifier, 4, false),
            21652 => new CrimsonSignBlock(Identifier, 5, true),
            21653 => new CrimsonSignBlock(Identifier, 5, false),
            21654 => new CrimsonSignBlock(Identifier, 6, true),
            21655 => new CrimsonSignBlock(Identifier, 6, false),
            21656 => new CrimsonSignBlock(Identifier, 7, true),
            21657 => new CrimsonSignBlock(Identifier, 7, false),
            21658 => new CrimsonSignBlock(Identifier, 8, true),
            21659 => new CrimsonSignBlock(Identifier, 8, false),
            21660 => new CrimsonSignBlock(Identifier, 9, true),
            21661 => new CrimsonSignBlock(Identifier, 9, false),
            21662 => new CrimsonSignBlock(Identifier, 10, true),
            21663 => new CrimsonSignBlock(Identifier, 10, false),
            21664 => new CrimsonSignBlock(Identifier, 11, true),
            21665 => new CrimsonSignBlock(Identifier, 11, false),
            21666 => new CrimsonSignBlock(Identifier, 12, true),
            21667 => new CrimsonSignBlock(Identifier, 12, false),
            21668 => new CrimsonSignBlock(Identifier, 13, true),
            21669 => new CrimsonSignBlock(Identifier, 13, false),
            21670 => new CrimsonSignBlock(Identifier, 14, true),
            21671 => new CrimsonSignBlock(Identifier, 14, false),
            21672 => new CrimsonSignBlock(Identifier, 15, true),
            21673 => new CrimsonSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("rotation", new StringTag(Rotation.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}

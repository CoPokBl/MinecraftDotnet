using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
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
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:mangrove_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5591,
                    false => 5592,
                },
                1 => Waterlogged switch {
                    true => 5593,
                    false => 5594,
                },
                2 => Waterlogged switch {
                    true => 5595,
                    false => 5596,
                },
                3 => Waterlogged switch {
                    true => 5597,
                    false => 5598,
                },
                4 => Waterlogged switch {
                    true => 5599,
                    false => 5600,
                },
                5 => Waterlogged switch {
                    true => 5601,
                    false => 5602,
                },
                6 => Waterlogged switch {
                    true => 5603,
                    false => 5604,
                },
                7 => Waterlogged switch {
                    true => 5605,
                    false => 5606,
                },
                8 => Waterlogged switch {
                    true => 5607,
                    false => 5608,
                },
                9 => Waterlogged switch {
                    true => 5609,
                    false => 5610,
                },
                10 => Waterlogged switch {
                    true => 5611,
                    false => 5612,
                },
                11 => Waterlogged switch {
                    true => 5613,
                    false => 5614,
                },
                12 => Waterlogged switch {
                    true => 5615,
                    false => 5616,
                },
                13 => Waterlogged switch {
                    true => 5617,
                    false => 5618,
                },
                14 => Waterlogged switch {
                    true => 5619,
                    false => 5620,
                },
                15 => Waterlogged switch {
                    true => 5621,
                    false => 5622,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5591 => new MangroveSignBlock(Identifier, 0, true),
            5592 => new MangroveSignBlock(Identifier, 0, false),
            5593 => new MangroveSignBlock(Identifier, 1, true),
            5594 => new MangroveSignBlock(Identifier, 1, false),
            5595 => new MangroveSignBlock(Identifier, 2, true),
            5596 => new MangroveSignBlock(Identifier, 2, false),
            5597 => new MangroveSignBlock(Identifier, 3, true),
            5598 => new MangroveSignBlock(Identifier, 3, false),
            5599 => new MangroveSignBlock(Identifier, 4, true),
            5600 => new MangroveSignBlock(Identifier, 4, false),
            5601 => new MangroveSignBlock(Identifier, 5, true),
            5602 => new MangroveSignBlock(Identifier, 5, false),
            5603 => new MangroveSignBlock(Identifier, 6, true),
            5604 => new MangroveSignBlock(Identifier, 6, false),
            5605 => new MangroveSignBlock(Identifier, 7, true),
            5606 => new MangroveSignBlock(Identifier, 7, false),
            5607 => new MangroveSignBlock(Identifier, 8, true),
            5608 => new MangroveSignBlock(Identifier, 8, false),
            5609 => new MangroveSignBlock(Identifier, 9, true),
            5610 => new MangroveSignBlock(Identifier, 9, false),
            5611 => new MangroveSignBlock(Identifier, 10, true),
            5612 => new MangroveSignBlock(Identifier, 10, false),
            5613 => new MangroveSignBlock(Identifier, 11, true),
            5614 => new MangroveSignBlock(Identifier, 11, false),
            5615 => new MangroveSignBlock(Identifier, 12, true),
            5616 => new MangroveSignBlock(Identifier, 12, false),
            5617 => new MangroveSignBlock(Identifier, 13, true),
            5618 => new MangroveSignBlock(Identifier, 13, false),
            5619 => new MangroveSignBlock(Identifier, 14, true),
            5620 => new MangroveSignBlock(Identifier, 14, false),
            5621 => new MangroveSignBlock(Identifier, 15, true),
            5622 => new MangroveSignBlock(Identifier, 15, false),
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

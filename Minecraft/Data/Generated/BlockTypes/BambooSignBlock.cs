using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
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
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:bamboo_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5623,
                    false => 5624,
                },
                1 => Waterlogged switch {
                    true => 5625,
                    false => 5626,
                },
                2 => Waterlogged switch {
                    true => 5627,
                    false => 5628,
                },
                3 => Waterlogged switch {
                    true => 5629,
                    false => 5630,
                },
                4 => Waterlogged switch {
                    true => 5631,
                    false => 5632,
                },
                5 => Waterlogged switch {
                    true => 5633,
                    false => 5634,
                },
                6 => Waterlogged switch {
                    true => 5635,
                    false => 5636,
                },
                7 => Waterlogged switch {
                    true => 5637,
                    false => 5638,
                },
                8 => Waterlogged switch {
                    true => 5639,
                    false => 5640,
                },
                9 => Waterlogged switch {
                    true => 5641,
                    false => 5642,
                },
                10 => Waterlogged switch {
                    true => 5643,
                    false => 5644,
                },
                11 => Waterlogged switch {
                    true => 5645,
                    false => 5646,
                },
                12 => Waterlogged switch {
                    true => 5647,
                    false => 5648,
                },
                13 => Waterlogged switch {
                    true => 5649,
                    false => 5650,
                },
                14 => Waterlogged switch {
                    true => 5651,
                    false => 5652,
                },
                15 => Waterlogged switch {
                    true => 5653,
                    false => 5654,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5623 => new BambooSignBlock(Identifier, 0, true),
            5624 => new BambooSignBlock(Identifier, 0, false),
            5625 => new BambooSignBlock(Identifier, 1, true),
            5626 => new BambooSignBlock(Identifier, 1, false),
            5627 => new BambooSignBlock(Identifier, 2, true),
            5628 => new BambooSignBlock(Identifier, 2, false),
            5629 => new BambooSignBlock(Identifier, 3, true),
            5630 => new BambooSignBlock(Identifier, 3, false),
            5631 => new BambooSignBlock(Identifier, 4, true),
            5632 => new BambooSignBlock(Identifier, 4, false),
            5633 => new BambooSignBlock(Identifier, 5, true),
            5634 => new BambooSignBlock(Identifier, 5, false),
            5635 => new BambooSignBlock(Identifier, 6, true),
            5636 => new BambooSignBlock(Identifier, 6, false),
            5637 => new BambooSignBlock(Identifier, 7, true),
            5638 => new BambooSignBlock(Identifier, 7, false),
            5639 => new BambooSignBlock(Identifier, 8, true),
            5640 => new BambooSignBlock(Identifier, 8, false),
            5641 => new BambooSignBlock(Identifier, 9, true),
            5642 => new BambooSignBlock(Identifier, 9, false),
            5643 => new BambooSignBlock(Identifier, 10, true),
            5644 => new BambooSignBlock(Identifier, 10, false),
            5645 => new BambooSignBlock(Identifier, 11, true),
            5646 => new BambooSignBlock(Identifier, 11, false),
            5647 => new BambooSignBlock(Identifier, 12, true),
            5648 => new BambooSignBlock(Identifier, 12, false),
            5649 => new BambooSignBlock(Identifier, 13, true),
            5650 => new BambooSignBlock(Identifier, 13, false),
            5651 => new BambooSignBlock(Identifier, 14, true),
            5652 => new BambooSignBlock(Identifier, 14, false),
            5653 => new BambooSignBlock(Identifier, 15, true),
            5654 => new BambooSignBlock(Identifier, 15, false),
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

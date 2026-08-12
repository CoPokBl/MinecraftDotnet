using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:warped_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 21674,
                    false => 21675,
                },
                1 => Waterlogged switch {
                    true => 21676,
                    false => 21677,
                },
                2 => Waterlogged switch {
                    true => 21678,
                    false => 21679,
                },
                3 => Waterlogged switch {
                    true => 21680,
                    false => 21681,
                },
                4 => Waterlogged switch {
                    true => 21682,
                    false => 21683,
                },
                5 => Waterlogged switch {
                    true => 21684,
                    false => 21685,
                },
                6 => Waterlogged switch {
                    true => 21686,
                    false => 21687,
                },
                7 => Waterlogged switch {
                    true => 21688,
                    false => 21689,
                },
                8 => Waterlogged switch {
                    true => 21690,
                    false => 21691,
                },
                9 => Waterlogged switch {
                    true => 21692,
                    false => 21693,
                },
                10 => Waterlogged switch {
                    true => 21694,
                    false => 21695,
                },
                11 => Waterlogged switch {
                    true => 21696,
                    false => 21697,
                },
                12 => Waterlogged switch {
                    true => 21698,
                    false => 21699,
                },
                13 => Waterlogged switch {
                    true => 21700,
                    false => 21701,
                },
                14 => Waterlogged switch {
                    true => 21702,
                    false => 21703,
                },
                15 => Waterlogged switch {
                    true => 21704,
                    false => 21705,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21674 => new WarpedSignBlock(Identifier, 0, true),
            21675 => new WarpedSignBlock(Identifier, 0, false),
            21676 => new WarpedSignBlock(Identifier, 1, true),
            21677 => new WarpedSignBlock(Identifier, 1, false),
            21678 => new WarpedSignBlock(Identifier, 2, true),
            21679 => new WarpedSignBlock(Identifier, 2, false),
            21680 => new WarpedSignBlock(Identifier, 3, true),
            21681 => new WarpedSignBlock(Identifier, 3, false),
            21682 => new WarpedSignBlock(Identifier, 4, true),
            21683 => new WarpedSignBlock(Identifier, 4, false),
            21684 => new WarpedSignBlock(Identifier, 5, true),
            21685 => new WarpedSignBlock(Identifier, 5, false),
            21686 => new WarpedSignBlock(Identifier, 6, true),
            21687 => new WarpedSignBlock(Identifier, 6, false),
            21688 => new WarpedSignBlock(Identifier, 7, true),
            21689 => new WarpedSignBlock(Identifier, 7, false),
            21690 => new WarpedSignBlock(Identifier, 8, true),
            21691 => new WarpedSignBlock(Identifier, 8, false),
            21692 => new WarpedSignBlock(Identifier, 9, true),
            21693 => new WarpedSignBlock(Identifier, 9, false),
            21694 => new WarpedSignBlock(Identifier, 10, true),
            21695 => new WarpedSignBlock(Identifier, 10, false),
            21696 => new WarpedSignBlock(Identifier, 11, true),
            21697 => new WarpedSignBlock(Identifier, 11, false),
            21698 => new WarpedSignBlock(Identifier, 12, true),
            21699 => new WarpedSignBlock(Identifier, 12, false),
            21700 => new WarpedSignBlock(Identifier, 13, true),
            21701 => new WarpedSignBlock(Identifier, 13, false),
            21702 => new WarpedSignBlock(Identifier, 14, true),
            21703 => new WarpedSignBlock(Identifier, 14, false),
            21704 => new WarpedSignBlock(Identifier, 15, true),
            21705 => new WarpedSignBlock(Identifier, 15, false),
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

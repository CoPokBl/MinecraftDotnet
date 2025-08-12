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
    public int ProtocolId => 206;
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
                    true => 4654,
                    false => 4655,
                },
                1 => Waterlogged switch {
                    true => 4656,
                    false => 4657,
                },
                2 => Waterlogged switch {
                    true => 4658,
                    false => 4659,
                },
                3 => Waterlogged switch {
                    true => 4660,
                    false => 4661,
                },
                4 => Waterlogged switch {
                    true => 4662,
                    false => 4663,
                },
                5 => Waterlogged switch {
                    true => 4664,
                    false => 4665,
                },
                6 => Waterlogged switch {
                    true => 4666,
                    false => 4667,
                },
                7 => Waterlogged switch {
                    true => 4668,
                    false => 4669,
                },
                8 => Waterlogged switch {
                    true => 4670,
                    false => 4671,
                },
                9 => Waterlogged switch {
                    true => 4672,
                    false => 4673,
                },
                10 => Waterlogged switch {
                    true => 4674,
                    false => 4675,
                },
                11 => Waterlogged switch {
                    true => 4676,
                    false => 4677,
                },
                12 => Waterlogged switch {
                    true => 4678,
                    false => 4679,
                },
                13 => Waterlogged switch {
                    true => 4680,
                    false => 4681,
                },
                14 => Waterlogged switch {
                    true => 4682,
                    false => 4683,
                },
                15 => Waterlogged switch {
                    true => 4684,
                    false => 4685,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4654 => new BambooSignBlock(Identifier, 0, true),
            4655 => new BambooSignBlock(Identifier, 0, false),
            4656 => new BambooSignBlock(Identifier, 1, true),
            4657 => new BambooSignBlock(Identifier, 1, false),
            4658 => new BambooSignBlock(Identifier, 2, true),
            4659 => new BambooSignBlock(Identifier, 2, false),
            4660 => new BambooSignBlock(Identifier, 3, true),
            4661 => new BambooSignBlock(Identifier, 3, false),
            4662 => new BambooSignBlock(Identifier, 4, true),
            4663 => new BambooSignBlock(Identifier, 4, false),
            4664 => new BambooSignBlock(Identifier, 5, true),
            4665 => new BambooSignBlock(Identifier, 5, false),
            4666 => new BambooSignBlock(Identifier, 6, true),
            4667 => new BambooSignBlock(Identifier, 6, false),
            4668 => new BambooSignBlock(Identifier, 7, true),
            4669 => new BambooSignBlock(Identifier, 7, false),
            4670 => new BambooSignBlock(Identifier, 8, true),
            4671 => new BambooSignBlock(Identifier, 8, false),
            4672 => new BambooSignBlock(Identifier, 9, true),
            4673 => new BambooSignBlock(Identifier, 9, false),
            4674 => new BambooSignBlock(Identifier, 10, true),
            4675 => new BambooSignBlock(Identifier, 10, false),
            4676 => new BambooSignBlock(Identifier, 11, true),
            4677 => new BambooSignBlock(Identifier, 11, false),
            4678 => new BambooSignBlock(Identifier, 12, true),
            4679 => new BambooSignBlock(Identifier, 12, false),
            4680 => new BambooSignBlock(Identifier, 13, true),
            4681 => new BambooSignBlock(Identifier, 13, false),
            4682 => new BambooSignBlock(Identifier, 14, true),
            4683 => new BambooSignBlock(Identifier, 14, false),
            4684 => new BambooSignBlock(Identifier, 15, true),
            4685 => new BambooSignBlock(Identifier, 15, false),
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

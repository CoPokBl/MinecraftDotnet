using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 209;
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
    public Identifier? Item => "minecraft:oak_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5134,
                    false => 5135,
                },
                1 => Waterlogged switch {
                    true => 5136,
                    false => 5137,
                },
                2 => Waterlogged switch {
                    true => 5138,
                    false => 5139,
                },
                3 => Waterlogged switch {
                    true => 5140,
                    false => 5141,
                },
                4 => Waterlogged switch {
                    true => 5142,
                    false => 5143,
                },
                5 => Waterlogged switch {
                    true => 5144,
                    false => 5145,
                },
                6 => Waterlogged switch {
                    true => 5146,
                    false => 5147,
                },
                7 => Waterlogged switch {
                    true => 5148,
                    false => 5149,
                },
                8 => Waterlogged switch {
                    true => 5150,
                    false => 5151,
                },
                9 => Waterlogged switch {
                    true => 5152,
                    false => 5153,
                },
                10 => Waterlogged switch {
                    true => 5154,
                    false => 5155,
                },
                11 => Waterlogged switch {
                    true => 5156,
                    false => 5157,
                },
                12 => Waterlogged switch {
                    true => 5158,
                    false => 5159,
                },
                13 => Waterlogged switch {
                    true => 5160,
                    false => 5161,
                },
                14 => Waterlogged switch {
                    true => 5162,
                    false => 5163,
                },
                15 => Waterlogged switch {
                    true => 5164,
                    false => 5165,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5134 => new OakSignBlock(Identifier, 0, true),
            5135 => new OakSignBlock(Identifier, 0, false),
            5136 => new OakSignBlock(Identifier, 1, true),
            5137 => new OakSignBlock(Identifier, 1, false),
            5138 => new OakSignBlock(Identifier, 2, true),
            5139 => new OakSignBlock(Identifier, 2, false),
            5140 => new OakSignBlock(Identifier, 3, true),
            5141 => new OakSignBlock(Identifier, 3, false),
            5142 => new OakSignBlock(Identifier, 4, true),
            5143 => new OakSignBlock(Identifier, 4, false),
            5144 => new OakSignBlock(Identifier, 5, true),
            5145 => new OakSignBlock(Identifier, 5, false),
            5146 => new OakSignBlock(Identifier, 6, true),
            5147 => new OakSignBlock(Identifier, 6, false),
            5148 => new OakSignBlock(Identifier, 7, true),
            5149 => new OakSignBlock(Identifier, 7, false),
            5150 => new OakSignBlock(Identifier, 8, true),
            5151 => new OakSignBlock(Identifier, 8, false),
            5152 => new OakSignBlock(Identifier, 9, true),
            5153 => new OakSignBlock(Identifier, 9, false),
            5154 => new OakSignBlock(Identifier, 10, true),
            5155 => new OakSignBlock(Identifier, 10, false),
            5156 => new OakSignBlock(Identifier, 11, true),
            5157 => new OakSignBlock(Identifier, 11, false),
            5158 => new OakSignBlock(Identifier, 12, true),
            5159 => new OakSignBlock(Identifier, 12, false),
            5160 => new OakSignBlock(Identifier, 13, true),
            5161 => new OakSignBlock(Identifier, 13, false),
            5162 => new OakSignBlock(Identifier, 14, true),
            5163 => new OakSignBlock(Identifier, 14, false),
            5164 => new OakSignBlock(Identifier, 15, true),
            5165 => new OakSignBlock(Identifier, 15, false),
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

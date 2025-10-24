using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 211;
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
    public Identifier? Item => "minecraft:birch_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.birch_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5198,
                    false => 5199,
                },
                1 => Waterlogged switch {
                    true => 5200,
                    false => 5201,
                },
                2 => Waterlogged switch {
                    true => 5202,
                    false => 5203,
                },
                3 => Waterlogged switch {
                    true => 5204,
                    false => 5205,
                },
                4 => Waterlogged switch {
                    true => 5206,
                    false => 5207,
                },
                5 => Waterlogged switch {
                    true => 5208,
                    false => 5209,
                },
                6 => Waterlogged switch {
                    true => 5210,
                    false => 5211,
                },
                7 => Waterlogged switch {
                    true => 5212,
                    false => 5213,
                },
                8 => Waterlogged switch {
                    true => 5214,
                    false => 5215,
                },
                9 => Waterlogged switch {
                    true => 5216,
                    false => 5217,
                },
                10 => Waterlogged switch {
                    true => 5218,
                    false => 5219,
                },
                11 => Waterlogged switch {
                    true => 5220,
                    false => 5221,
                },
                12 => Waterlogged switch {
                    true => 5222,
                    false => 5223,
                },
                13 => Waterlogged switch {
                    true => 5224,
                    false => 5225,
                },
                14 => Waterlogged switch {
                    true => 5226,
                    false => 5227,
                },
                15 => Waterlogged switch {
                    true => 5228,
                    false => 5229,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5198 => new BirchSignBlock(Identifier, 0, true),
            5199 => new BirchSignBlock(Identifier, 0, false),
            5200 => new BirchSignBlock(Identifier, 1, true),
            5201 => new BirchSignBlock(Identifier, 1, false),
            5202 => new BirchSignBlock(Identifier, 2, true),
            5203 => new BirchSignBlock(Identifier, 2, false),
            5204 => new BirchSignBlock(Identifier, 3, true),
            5205 => new BirchSignBlock(Identifier, 3, false),
            5206 => new BirchSignBlock(Identifier, 4, true),
            5207 => new BirchSignBlock(Identifier, 4, false),
            5208 => new BirchSignBlock(Identifier, 5, true),
            5209 => new BirchSignBlock(Identifier, 5, false),
            5210 => new BirchSignBlock(Identifier, 6, true),
            5211 => new BirchSignBlock(Identifier, 6, false),
            5212 => new BirchSignBlock(Identifier, 7, true),
            5213 => new BirchSignBlock(Identifier, 7, false),
            5214 => new BirchSignBlock(Identifier, 8, true),
            5215 => new BirchSignBlock(Identifier, 8, false),
            5216 => new BirchSignBlock(Identifier, 9, true),
            5217 => new BirchSignBlock(Identifier, 9, false),
            5218 => new BirchSignBlock(Identifier, 10, true),
            5219 => new BirchSignBlock(Identifier, 10, false),
            5220 => new BirchSignBlock(Identifier, 11, true),
            5221 => new BirchSignBlock(Identifier, 11, false),
            5222 => new BirchSignBlock(Identifier, 12, true),
            5223 => new BirchSignBlock(Identifier, 12, false),
            5224 => new BirchSignBlock(Identifier, 13, true),
            5225 => new BirchSignBlock(Identifier, 13, false),
            5226 => new BirchSignBlock(Identifier, 14, true),
            5227 => new BirchSignBlock(Identifier, 14, false),
            5228 => new BirchSignBlock(Identifier, 15, true),
            5229 => new BirchSignBlock(Identifier, 15, false),
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

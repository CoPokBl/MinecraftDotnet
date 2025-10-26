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
    public int ProtocolId => 218;
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
                    true => 5422,
                    false => 5423,
                },
                1 => Waterlogged switch {
                    true => 5424,
                    false => 5425,
                },
                2 => Waterlogged switch {
                    true => 5426,
                    false => 5427,
                },
                3 => Waterlogged switch {
                    true => 5428,
                    false => 5429,
                },
                4 => Waterlogged switch {
                    true => 5430,
                    false => 5431,
                },
                5 => Waterlogged switch {
                    true => 5432,
                    false => 5433,
                },
                6 => Waterlogged switch {
                    true => 5434,
                    false => 5435,
                },
                7 => Waterlogged switch {
                    true => 5436,
                    false => 5437,
                },
                8 => Waterlogged switch {
                    true => 5438,
                    false => 5439,
                },
                9 => Waterlogged switch {
                    true => 5440,
                    false => 5441,
                },
                10 => Waterlogged switch {
                    true => 5442,
                    false => 5443,
                },
                11 => Waterlogged switch {
                    true => 5444,
                    false => 5445,
                },
                12 => Waterlogged switch {
                    true => 5446,
                    false => 5447,
                },
                13 => Waterlogged switch {
                    true => 5448,
                    false => 5449,
                },
                14 => Waterlogged switch {
                    true => 5450,
                    false => 5451,
                },
                15 => Waterlogged switch {
                    true => 5452,
                    false => 5453,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5422 => new BambooSignBlock(Identifier, 0, true),
            5423 => new BambooSignBlock(Identifier, 0, false),
            5424 => new BambooSignBlock(Identifier, 1, true),
            5425 => new BambooSignBlock(Identifier, 1, false),
            5426 => new BambooSignBlock(Identifier, 2, true),
            5427 => new BambooSignBlock(Identifier, 2, false),
            5428 => new BambooSignBlock(Identifier, 3, true),
            5429 => new BambooSignBlock(Identifier, 3, false),
            5430 => new BambooSignBlock(Identifier, 4, true),
            5431 => new BambooSignBlock(Identifier, 4, false),
            5432 => new BambooSignBlock(Identifier, 5, true),
            5433 => new BambooSignBlock(Identifier, 5, false),
            5434 => new BambooSignBlock(Identifier, 6, true),
            5435 => new BambooSignBlock(Identifier, 6, false),
            5436 => new BambooSignBlock(Identifier, 7, true),
            5437 => new BambooSignBlock(Identifier, 7, false),
            5438 => new BambooSignBlock(Identifier, 8, true),
            5439 => new BambooSignBlock(Identifier, 8, false),
            5440 => new BambooSignBlock(Identifier, 9, true),
            5441 => new BambooSignBlock(Identifier, 9, false),
            5442 => new BambooSignBlock(Identifier, 10, true),
            5443 => new BambooSignBlock(Identifier, 10, false),
            5444 => new BambooSignBlock(Identifier, 11, true),
            5445 => new BambooSignBlock(Identifier, 11, false),
            5446 => new BambooSignBlock(Identifier, 12, true),
            5447 => new BambooSignBlock(Identifier, 12, false),
            5448 => new BambooSignBlock(Identifier, 13, true),
            5449 => new BambooSignBlock(Identifier, 13, false),
            5450 => new BambooSignBlock(Identifier, 14, true),
            5451 => new BambooSignBlock(Identifier, 14, false),
            5452 => new BambooSignBlock(Identifier, 15, true),
            5453 => new BambooSignBlock(Identifier, 15, false),
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

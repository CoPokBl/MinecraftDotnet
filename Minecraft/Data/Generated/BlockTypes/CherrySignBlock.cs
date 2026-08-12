using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherrySignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:cherry_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5463,
                    false => 5464,
                },
                1 => Waterlogged switch {
                    true => 5465,
                    false => 5466,
                },
                2 => Waterlogged switch {
                    true => 5467,
                    false => 5468,
                },
                3 => Waterlogged switch {
                    true => 5469,
                    false => 5470,
                },
                4 => Waterlogged switch {
                    true => 5471,
                    false => 5472,
                },
                5 => Waterlogged switch {
                    true => 5473,
                    false => 5474,
                },
                6 => Waterlogged switch {
                    true => 5475,
                    false => 5476,
                },
                7 => Waterlogged switch {
                    true => 5477,
                    false => 5478,
                },
                8 => Waterlogged switch {
                    true => 5479,
                    false => 5480,
                },
                9 => Waterlogged switch {
                    true => 5481,
                    false => 5482,
                },
                10 => Waterlogged switch {
                    true => 5483,
                    false => 5484,
                },
                11 => Waterlogged switch {
                    true => 5485,
                    false => 5486,
                },
                12 => Waterlogged switch {
                    true => 5487,
                    false => 5488,
                },
                13 => Waterlogged switch {
                    true => 5489,
                    false => 5490,
                },
                14 => Waterlogged switch {
                    true => 5491,
                    false => 5492,
                },
                15 => Waterlogged switch {
                    true => 5493,
                    false => 5494,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5463 => new CherrySignBlock(Identifier, 0, true),
            5464 => new CherrySignBlock(Identifier, 0, false),
            5465 => new CherrySignBlock(Identifier, 1, true),
            5466 => new CherrySignBlock(Identifier, 1, false),
            5467 => new CherrySignBlock(Identifier, 2, true),
            5468 => new CherrySignBlock(Identifier, 2, false),
            5469 => new CherrySignBlock(Identifier, 3, true),
            5470 => new CherrySignBlock(Identifier, 3, false),
            5471 => new CherrySignBlock(Identifier, 4, true),
            5472 => new CherrySignBlock(Identifier, 4, false),
            5473 => new CherrySignBlock(Identifier, 5, true),
            5474 => new CherrySignBlock(Identifier, 5, false),
            5475 => new CherrySignBlock(Identifier, 6, true),
            5476 => new CherrySignBlock(Identifier, 6, false),
            5477 => new CherrySignBlock(Identifier, 7, true),
            5478 => new CherrySignBlock(Identifier, 7, false),
            5479 => new CherrySignBlock(Identifier, 8, true),
            5480 => new CherrySignBlock(Identifier, 8, false),
            5481 => new CherrySignBlock(Identifier, 9, true),
            5482 => new CherrySignBlock(Identifier, 9, false),
            5483 => new CherrySignBlock(Identifier, 10, true),
            5484 => new CherrySignBlock(Identifier, 10, false),
            5485 => new CherrySignBlock(Identifier, 11, true),
            5486 => new CherrySignBlock(Identifier, 11, false),
            5487 => new CherrySignBlock(Identifier, 12, true),
            5488 => new CherrySignBlock(Identifier, 12, false),
            5489 => new CherrySignBlock(Identifier, 13, true),
            5490 => new CherrySignBlock(Identifier, 13, false),
            5491 => new CherrySignBlock(Identifier, 14, true),
            5492 => new CherrySignBlock(Identifier, 14, false),
            5493 => new CherrySignBlock(Identifier, 15, true),
            5494 => new CherrySignBlock(Identifier, 15, false),
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

using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:dark_oak_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5527,
                    false => 5528,
                },
                1 => Waterlogged switch {
                    true => 5529,
                    false => 5530,
                },
                2 => Waterlogged switch {
                    true => 5531,
                    false => 5532,
                },
                3 => Waterlogged switch {
                    true => 5533,
                    false => 5534,
                },
                4 => Waterlogged switch {
                    true => 5535,
                    false => 5536,
                },
                5 => Waterlogged switch {
                    true => 5537,
                    false => 5538,
                },
                6 => Waterlogged switch {
                    true => 5539,
                    false => 5540,
                },
                7 => Waterlogged switch {
                    true => 5541,
                    false => 5542,
                },
                8 => Waterlogged switch {
                    true => 5543,
                    false => 5544,
                },
                9 => Waterlogged switch {
                    true => 5545,
                    false => 5546,
                },
                10 => Waterlogged switch {
                    true => 5547,
                    false => 5548,
                },
                11 => Waterlogged switch {
                    true => 5549,
                    false => 5550,
                },
                12 => Waterlogged switch {
                    true => 5551,
                    false => 5552,
                },
                13 => Waterlogged switch {
                    true => 5553,
                    false => 5554,
                },
                14 => Waterlogged switch {
                    true => 5555,
                    false => 5556,
                },
                15 => Waterlogged switch {
                    true => 5557,
                    false => 5558,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5527 => new DarkOakSignBlock(Identifier, 0, true),
            5528 => new DarkOakSignBlock(Identifier, 0, false),
            5529 => new DarkOakSignBlock(Identifier, 1, true),
            5530 => new DarkOakSignBlock(Identifier, 1, false),
            5531 => new DarkOakSignBlock(Identifier, 2, true),
            5532 => new DarkOakSignBlock(Identifier, 2, false),
            5533 => new DarkOakSignBlock(Identifier, 3, true),
            5534 => new DarkOakSignBlock(Identifier, 3, false),
            5535 => new DarkOakSignBlock(Identifier, 4, true),
            5536 => new DarkOakSignBlock(Identifier, 4, false),
            5537 => new DarkOakSignBlock(Identifier, 5, true),
            5538 => new DarkOakSignBlock(Identifier, 5, false),
            5539 => new DarkOakSignBlock(Identifier, 6, true),
            5540 => new DarkOakSignBlock(Identifier, 6, false),
            5541 => new DarkOakSignBlock(Identifier, 7, true),
            5542 => new DarkOakSignBlock(Identifier, 7, false),
            5543 => new DarkOakSignBlock(Identifier, 8, true),
            5544 => new DarkOakSignBlock(Identifier, 8, false),
            5545 => new DarkOakSignBlock(Identifier, 9, true),
            5546 => new DarkOakSignBlock(Identifier, 9, false),
            5547 => new DarkOakSignBlock(Identifier, 10, true),
            5548 => new DarkOakSignBlock(Identifier, 10, false),
            5549 => new DarkOakSignBlock(Identifier, 11, true),
            5550 => new DarkOakSignBlock(Identifier, 11, false),
            5551 => new DarkOakSignBlock(Identifier, 12, true),
            5552 => new DarkOakSignBlock(Identifier, 12, false),
            5553 => new DarkOakSignBlock(Identifier, 13, true),
            5554 => new DarkOakSignBlock(Identifier, 13, false),
            5555 => new DarkOakSignBlock(Identifier, 14, true),
            5556 => new DarkOakSignBlock(Identifier, 14, false),
            5557 => new DarkOakSignBlock(Identifier, 15, true),
            5558 => new DarkOakSignBlock(Identifier, 15, false),
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

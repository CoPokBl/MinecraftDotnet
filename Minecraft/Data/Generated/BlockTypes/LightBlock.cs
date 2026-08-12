using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlock(Identifier Identifier, int Level, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:light";
    public double Hardness => -1;
    public double ExplosionResistance => 3600000.8;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 15;
    public bool Replaceable => true;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:light";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.light";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Level switch {
                0 => Waterlogged switch {
                    true => 12535,
                    false => 12536,
                },
                1 => Waterlogged switch {
                    true => 12537,
                    false => 12538,
                },
                2 => Waterlogged switch {
                    true => 12539,
                    false => 12540,
                },
                3 => Waterlogged switch {
                    true => 12541,
                    false => 12542,
                },
                4 => Waterlogged switch {
                    true => 12543,
                    false => 12544,
                },
                5 => Waterlogged switch {
                    true => 12545,
                    false => 12546,
                },
                6 => Waterlogged switch {
                    true => 12547,
                    false => 12548,
                },
                7 => Waterlogged switch {
                    true => 12549,
                    false => 12550,
                },
                8 => Waterlogged switch {
                    true => 12551,
                    false => 12552,
                },
                9 => Waterlogged switch {
                    true => 12553,
                    false => 12554,
                },
                10 => Waterlogged switch {
                    true => 12555,
                    false => 12556,
                },
                11 => Waterlogged switch {
                    true => 12557,
                    false => 12558,
                },
                12 => Waterlogged switch {
                    true => 12559,
                    false => 12560,
                },
                13 => Waterlogged switch {
                    true => 12561,
                    false => 12562,
                },
                14 => Waterlogged switch {
                    true => 12563,
                    false => 12564,
                },
                15 => Waterlogged switch {
                    true => 12565,
                    false => 12566,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12535 => new LightBlock(Identifier, 0, true),
            12536 => new LightBlock(Identifier, 0, false),
            12537 => new LightBlock(Identifier, 1, true),
            12538 => new LightBlock(Identifier, 1, false),
            12539 => new LightBlock(Identifier, 2, true),
            12540 => new LightBlock(Identifier, 2, false),
            12541 => new LightBlock(Identifier, 3, true),
            12542 => new LightBlock(Identifier, 3, false),
            12543 => new LightBlock(Identifier, 4, true),
            12544 => new LightBlock(Identifier, 4, false),
            12545 => new LightBlock(Identifier, 5, true),
            12546 => new LightBlock(Identifier, 5, false),
            12547 => new LightBlock(Identifier, 6, true),
            12548 => new LightBlock(Identifier, 6, false),
            12549 => new LightBlock(Identifier, 7, true),
            12550 => new LightBlock(Identifier, 7, false),
            12551 => new LightBlock(Identifier, 8, true),
            12552 => new LightBlock(Identifier, 8, false),
            12553 => new LightBlock(Identifier, 9, true),
            12554 => new LightBlock(Identifier, 9, false),
            12555 => new LightBlock(Identifier, 10, true),
            12556 => new LightBlock(Identifier, 10, false),
            12557 => new LightBlock(Identifier, 11, true),
            12558 => new LightBlock(Identifier, 11, false),
            12559 => new LightBlock(Identifier, 12, true),
            12560 => new LightBlock(Identifier, 12, false),
            12561 => new LightBlock(Identifier, 13, true),
            12562 => new LightBlock(Identifier, 13, false),
            12563 => new LightBlock(Identifier, 14, true),
            12564 => new LightBlock(Identifier, 14, false),
            12565 => new LightBlock(Identifier, 15, true),
            12566 => new LightBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = properties.Contains("level") ? int.Parse(properties["level"].GetString()) : Level,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("level", new StringTag(Level.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}

using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CaveVinesBlock(Identifier Identifier, int Age, bool Berries) : IBlock {
    public Identifier Category => "minecraft:cave_vines";
    public int ProtocolId => 1105;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "cave_vines";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:glow_berries";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 1.0, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.cave_vines";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => Berries switch {
                    true => 27554,
                    false => 27555,
                },
                1 => Berries switch {
                    true => 27556,
                    false => 27557,
                },
                2 => Berries switch {
                    true => 27558,
                    false => 27559,
                },
                3 => Berries switch {
                    true => 27560,
                    false => 27561,
                },
                4 => Berries switch {
                    true => 27562,
                    false => 27563,
                },
                5 => Berries switch {
                    true => 27564,
                    false => 27565,
                },
                6 => Berries switch {
                    true => 27566,
                    false => 27567,
                },
                7 => Berries switch {
                    true => 27568,
                    false => 27569,
                },
                8 => Berries switch {
                    true => 27570,
                    false => 27571,
                },
                9 => Berries switch {
                    true => 27572,
                    false => 27573,
                },
                10 => Berries switch {
                    true => 27574,
                    false => 27575,
                },
                11 => Berries switch {
                    true => 27576,
                    false => 27577,
                },
                12 => Berries switch {
                    true => 27578,
                    false => 27579,
                },
                13 => Berries switch {
                    true => 27580,
                    false => 27581,
                },
                14 => Berries switch {
                    true => 27582,
                    false => 27583,
                },
                15 => Berries switch {
                    true => 27584,
                    false => 27585,
                },
                16 => Berries switch {
                    true => 27586,
                    false => 27587,
                },
                17 => Berries switch {
                    true => 27588,
                    false => 27589,
                },
                18 => Berries switch {
                    true => 27590,
                    false => 27591,
                },
                19 => Berries switch {
                    true => 27592,
                    false => 27593,
                },
                20 => Berries switch {
                    true => 27594,
                    false => 27595,
                },
                21 => Berries switch {
                    true => 27596,
                    false => 27597,
                },
                22 => Berries switch {
                    true => 27598,
                    false => 27599,
                },
                23 => Berries switch {
                    true => 27600,
                    false => 27601,
                },
                24 => Berries switch {
                    true => 27602,
                    false => 27603,
                },
                25 => Berries switch {
                    true => 27604,
                    false => 27605,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27554 => new CaveVinesBlock(Identifier, 0, true),
            27555 => new CaveVinesBlock(Identifier, 0, false),
            27556 => new CaveVinesBlock(Identifier, 1, true),
            27557 => new CaveVinesBlock(Identifier, 1, false),
            27558 => new CaveVinesBlock(Identifier, 2, true),
            27559 => new CaveVinesBlock(Identifier, 2, false),
            27560 => new CaveVinesBlock(Identifier, 3, true),
            27561 => new CaveVinesBlock(Identifier, 3, false),
            27562 => new CaveVinesBlock(Identifier, 4, true),
            27563 => new CaveVinesBlock(Identifier, 4, false),
            27564 => new CaveVinesBlock(Identifier, 5, true),
            27565 => new CaveVinesBlock(Identifier, 5, false),
            27566 => new CaveVinesBlock(Identifier, 6, true),
            27567 => new CaveVinesBlock(Identifier, 6, false),
            27568 => new CaveVinesBlock(Identifier, 7, true),
            27569 => new CaveVinesBlock(Identifier, 7, false),
            27570 => new CaveVinesBlock(Identifier, 8, true),
            27571 => new CaveVinesBlock(Identifier, 8, false),
            27572 => new CaveVinesBlock(Identifier, 9, true),
            27573 => new CaveVinesBlock(Identifier, 9, false),
            27574 => new CaveVinesBlock(Identifier, 10, true),
            27575 => new CaveVinesBlock(Identifier, 10, false),
            27576 => new CaveVinesBlock(Identifier, 11, true),
            27577 => new CaveVinesBlock(Identifier, 11, false),
            27578 => new CaveVinesBlock(Identifier, 12, true),
            27579 => new CaveVinesBlock(Identifier, 12, false),
            27580 => new CaveVinesBlock(Identifier, 13, true),
            27581 => new CaveVinesBlock(Identifier, 13, false),
            27582 => new CaveVinesBlock(Identifier, 14, true),
            27583 => new CaveVinesBlock(Identifier, 14, false),
            27584 => new CaveVinesBlock(Identifier, 15, true),
            27585 => new CaveVinesBlock(Identifier, 15, false),
            27586 => new CaveVinesBlock(Identifier, 16, true),
            27587 => new CaveVinesBlock(Identifier, 16, false),
            27588 => new CaveVinesBlock(Identifier, 17, true),
            27589 => new CaveVinesBlock(Identifier, 17, false),
            27590 => new CaveVinesBlock(Identifier, 18, true),
            27591 => new CaveVinesBlock(Identifier, 18, false),
            27592 => new CaveVinesBlock(Identifier, 19, true),
            27593 => new CaveVinesBlock(Identifier, 19, false),
            27594 => new CaveVinesBlock(Identifier, 20, true),
            27595 => new CaveVinesBlock(Identifier, 20, false),
            27596 => new CaveVinesBlock(Identifier, 21, true),
            27597 => new CaveVinesBlock(Identifier, 21, false),
            27598 => new CaveVinesBlock(Identifier, 22, true),
            27599 => new CaveVinesBlock(Identifier, 22, false),
            27600 => new CaveVinesBlock(Identifier, 23, true),
            27601 => new CaveVinesBlock(Identifier, 23, false),
            27602 => new CaveVinesBlock(Identifier, 24, true),
            27603 => new CaveVinesBlock(Identifier, 24, false),
            27604 => new CaveVinesBlock(Identifier, 25, true),
            27605 => new CaveVinesBlock(Identifier, 25, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.ChildrenMap.ContainsKey("age") ? int.Parse(properties["age"].GetString()) : Age,
            Berries = properties.ChildrenMap.ContainsKey("berries") ? properties["berries"].GetString() == "true" : Berries,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("age", Age.ToString()),
            new StringTag("berries", Berries.ToString().ToLower())
        );
    }
    
}

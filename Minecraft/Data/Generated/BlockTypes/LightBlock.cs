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
    public int ProtocolId => 523;
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
                    true => 12333,
                    false => 12334,
                },
                1 => Waterlogged switch {
                    true => 12335,
                    false => 12336,
                },
                2 => Waterlogged switch {
                    true => 12337,
                    false => 12338,
                },
                3 => Waterlogged switch {
                    true => 12339,
                    false => 12340,
                },
                4 => Waterlogged switch {
                    true => 12341,
                    false => 12342,
                },
                5 => Waterlogged switch {
                    true => 12343,
                    false => 12344,
                },
                6 => Waterlogged switch {
                    true => 12345,
                    false => 12346,
                },
                7 => Waterlogged switch {
                    true => 12347,
                    false => 12348,
                },
                8 => Waterlogged switch {
                    true => 12349,
                    false => 12350,
                },
                9 => Waterlogged switch {
                    true => 12351,
                    false => 12352,
                },
                10 => Waterlogged switch {
                    true => 12353,
                    false => 12354,
                },
                11 => Waterlogged switch {
                    true => 12355,
                    false => 12356,
                },
                12 => Waterlogged switch {
                    true => 12357,
                    false => 12358,
                },
                13 => Waterlogged switch {
                    true => 12359,
                    false => 12360,
                },
                14 => Waterlogged switch {
                    true => 12361,
                    false => 12362,
                },
                15 => Waterlogged switch {
                    true => 12363,
                    false => 12364,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12333 => new LightBlock(Identifier, 0, true),
            12334 => new LightBlock(Identifier, 0, false),
            12335 => new LightBlock(Identifier, 1, true),
            12336 => new LightBlock(Identifier, 1, false),
            12337 => new LightBlock(Identifier, 2, true),
            12338 => new LightBlock(Identifier, 2, false),
            12339 => new LightBlock(Identifier, 3, true),
            12340 => new LightBlock(Identifier, 3, false),
            12341 => new LightBlock(Identifier, 4, true),
            12342 => new LightBlock(Identifier, 4, false),
            12343 => new LightBlock(Identifier, 5, true),
            12344 => new LightBlock(Identifier, 5, false),
            12345 => new LightBlock(Identifier, 6, true),
            12346 => new LightBlock(Identifier, 6, false),
            12347 => new LightBlock(Identifier, 7, true),
            12348 => new LightBlock(Identifier, 7, false),
            12349 => new LightBlock(Identifier, 8, true),
            12350 => new LightBlock(Identifier, 8, false),
            12351 => new LightBlock(Identifier, 9, true),
            12352 => new LightBlock(Identifier, 9, false),
            12353 => new LightBlock(Identifier, 10, true),
            12354 => new LightBlock(Identifier, 10, false),
            12355 => new LightBlock(Identifier, 11, true),
            12356 => new LightBlock(Identifier, 11, false),
            12357 => new LightBlock(Identifier, 12, true),
            12358 => new LightBlock(Identifier, 12, false),
            12359 => new LightBlock(Identifier, 13, true),
            12360 => new LightBlock(Identifier, 13, false),
            12361 => new LightBlock(Identifier, 14, true),
            12362 => new LightBlock(Identifier, 14, false),
            12363 => new LightBlock(Identifier, 15, true),
            12364 => new LightBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = properties.ChildrenMap.ContainsKey("level") ? int.Parse(properties["level"].GetString()) : Level,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("level", Level.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}

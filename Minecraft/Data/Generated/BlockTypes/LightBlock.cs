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
    public int ProtocolId => 493;
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
                    true => 11256,
                    false => 11257,
                },
                1 => Waterlogged switch {
                    true => 11258,
                    false => 11259,
                },
                2 => Waterlogged switch {
                    true => 11260,
                    false => 11261,
                },
                3 => Waterlogged switch {
                    true => 11262,
                    false => 11263,
                },
                4 => Waterlogged switch {
                    true => 11264,
                    false => 11265,
                },
                5 => Waterlogged switch {
                    true => 11266,
                    false => 11267,
                },
                6 => Waterlogged switch {
                    true => 11268,
                    false => 11269,
                },
                7 => Waterlogged switch {
                    true => 11270,
                    false => 11271,
                },
                8 => Waterlogged switch {
                    true => 11272,
                    false => 11273,
                },
                9 => Waterlogged switch {
                    true => 11274,
                    false => 11275,
                },
                10 => Waterlogged switch {
                    true => 11276,
                    false => 11277,
                },
                11 => Waterlogged switch {
                    true => 11278,
                    false => 11279,
                },
                12 => Waterlogged switch {
                    true => 11280,
                    false => 11281,
                },
                13 => Waterlogged switch {
                    true => 11282,
                    false => 11283,
                },
                14 => Waterlogged switch {
                    true => 11284,
                    false => 11285,
                },
                15 => Waterlogged switch {
                    true => 11286,
                    false => 11287,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11256 => new LightBlock(Identifier, 0, true),
            11257 => new LightBlock(Identifier, 0, false),
            11258 => new LightBlock(Identifier, 1, true),
            11259 => new LightBlock(Identifier, 1, false),
            11260 => new LightBlock(Identifier, 2, true),
            11261 => new LightBlock(Identifier, 2, false),
            11262 => new LightBlock(Identifier, 3, true),
            11263 => new LightBlock(Identifier, 3, false),
            11264 => new LightBlock(Identifier, 4, true),
            11265 => new LightBlock(Identifier, 4, false),
            11266 => new LightBlock(Identifier, 5, true),
            11267 => new LightBlock(Identifier, 5, false),
            11268 => new LightBlock(Identifier, 6, true),
            11269 => new LightBlock(Identifier, 6, false),
            11270 => new LightBlock(Identifier, 7, true),
            11271 => new LightBlock(Identifier, 7, false),
            11272 => new LightBlock(Identifier, 8, true),
            11273 => new LightBlock(Identifier, 8, false),
            11274 => new LightBlock(Identifier, 9, true),
            11275 => new LightBlock(Identifier, 9, false),
            11276 => new LightBlock(Identifier, 10, true),
            11277 => new LightBlock(Identifier, 10, false),
            11278 => new LightBlock(Identifier, 11, true),
            11279 => new LightBlock(Identifier, 11, false),
            11280 => new LightBlock(Identifier, 12, true),
            11281 => new LightBlock(Identifier, 12, false),
            11282 => new LightBlock(Identifier, 13, true),
            11283 => new LightBlock(Identifier, 13, false),
            11284 => new LightBlock(Identifier, 14, true),
            11285 => new LightBlock(Identifier, 14, false),
            11286 => new LightBlock(Identifier, 15, true),
            11287 => new LightBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = int.Parse(properties["level"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}

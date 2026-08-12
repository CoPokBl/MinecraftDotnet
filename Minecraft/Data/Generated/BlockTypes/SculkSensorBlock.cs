using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SculkSensorBlock(Identifier Identifier, int Power, SculkSensorPhase SculkSensorPhase, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:sculk_sensor";
    public double Hardness => 1.5;
    public double ExplosionResistance => 1.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 1;
    public bool Replaceable => false;
    public string SoundType => "sculk_sensor";
    public Identifier? BlockEntity => "minecraft:sculk_sensor";
    public Identifier? Item => "minecraft:sculk_sensor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 23;
    public string TranslationKey => "block.minecraft.sculk_sensor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Power switch {
                0 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27163,
                        false => 27164,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27165,
                        false => 27166,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27167,
                        false => 27168,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                1 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27169,
                        false => 27170,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27171,
                        false => 27172,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27173,
                        false => 27174,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                2 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27175,
                        false => 27176,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27177,
                        false => 27178,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27179,
                        false => 27180,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                3 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27181,
                        false => 27182,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27183,
                        false => 27184,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27185,
                        false => 27186,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                4 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27187,
                        false => 27188,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27189,
                        false => 27190,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27191,
                        false => 27192,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                5 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27193,
                        false => 27194,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27195,
                        false => 27196,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27197,
                        false => 27198,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                6 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27199,
                        false => 27200,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27201,
                        false => 27202,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27203,
                        false => 27204,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                7 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27205,
                        false => 27206,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27207,
                        false => 27208,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27209,
                        false => 27210,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                8 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27211,
                        false => 27212,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27213,
                        false => 27214,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27215,
                        false => 27216,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                9 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27217,
                        false => 27218,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27219,
                        false => 27220,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27221,
                        false => 27222,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                10 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27223,
                        false => 27224,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27225,
                        false => 27226,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27227,
                        false => 27228,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                11 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27229,
                        false => 27230,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27231,
                        false => 27232,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27233,
                        false => 27234,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                12 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27235,
                        false => 27236,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27237,
                        false => 27238,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27239,
                        false => 27240,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                13 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27241,
                        false => 27242,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27243,
                        false => 27244,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27245,
                        false => 27246,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                14 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27247,
                        false => 27248,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27249,
                        false => 27250,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27251,
                        false => 27252,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                15 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 27253,
                        false => 27254,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 27255,
                        false => 27256,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 27257,
                        false => 27258,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27163 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Inactive, true),
            27164 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Inactive, false),
            27165 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Active, true),
            27166 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Active, false),
            27167 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Cooldown, true),
            27168 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Cooldown, false),
            27169 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Inactive, true),
            27170 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Inactive, false),
            27171 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Active, true),
            27172 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Active, false),
            27173 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Cooldown, true),
            27174 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Cooldown, false),
            27175 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Inactive, true),
            27176 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Inactive, false),
            27177 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Active, true),
            27178 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Active, false),
            27179 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Cooldown, true),
            27180 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Cooldown, false),
            27181 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Inactive, true),
            27182 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Inactive, false),
            27183 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Active, true),
            27184 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Active, false),
            27185 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Cooldown, true),
            27186 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Cooldown, false),
            27187 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Inactive, true),
            27188 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Inactive, false),
            27189 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Active, true),
            27190 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Active, false),
            27191 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Cooldown, true),
            27192 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Cooldown, false),
            27193 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Inactive, true),
            27194 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Inactive, false),
            27195 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Active, true),
            27196 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Active, false),
            27197 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Cooldown, true),
            27198 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Cooldown, false),
            27199 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Inactive, true),
            27200 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Inactive, false),
            27201 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Active, true),
            27202 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Active, false),
            27203 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Cooldown, true),
            27204 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Cooldown, false),
            27205 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Inactive, true),
            27206 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Inactive, false),
            27207 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Active, true),
            27208 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Active, false),
            27209 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Cooldown, true),
            27210 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Cooldown, false),
            27211 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Inactive, true),
            27212 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Inactive, false),
            27213 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Active, true),
            27214 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Active, false),
            27215 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Cooldown, true),
            27216 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Cooldown, false),
            27217 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Inactive, true),
            27218 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Inactive, false),
            27219 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Active, true),
            27220 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Active, false),
            27221 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Cooldown, true),
            27222 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Cooldown, false),
            27223 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Inactive, true),
            27224 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Inactive, false),
            27225 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Active, true),
            27226 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Active, false),
            27227 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Cooldown, true),
            27228 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Cooldown, false),
            27229 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Inactive, true),
            27230 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Inactive, false),
            27231 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Active, true),
            27232 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Active, false),
            27233 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Cooldown, true),
            27234 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Cooldown, false),
            27235 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Inactive, true),
            27236 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Inactive, false),
            27237 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Active, true),
            27238 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Active, false),
            27239 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Cooldown, true),
            27240 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Cooldown, false),
            27241 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Inactive, true),
            27242 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Inactive, false),
            27243 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Active, true),
            27244 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Active, false),
            27245 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Cooldown, true),
            27246 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Cooldown, false),
            27247 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Inactive, true),
            27248 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Inactive, false),
            27249 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Active, true),
            27250 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Active, false),
            27251 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Cooldown, true),
            27252 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Cooldown, false),
            27253 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Inactive, true),
            27254 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Inactive, false),
            27255 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Active, true),
            27256 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Active, false),
            27257 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Cooldown, true),
            27258 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Cooldown, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = properties.Contains("power") ? int.Parse(properties["power"].GetString()) : Power,
            SculkSensorPhase = properties.Contains("sculk_sensor_phase") ? SculkSensorPhaseExtensions.FromString(properties["sculk_sensor_phase"].GetString()) : SculkSensorPhase,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("power", new StringTag(Power.ToString())),
            ("sculk_sensor_phase", new StringTag(SculkSensorPhase.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}

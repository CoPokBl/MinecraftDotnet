using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {

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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:crimson_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 20299,
                    false => 20300,
                },
                1 => Waterlogged switch {
                    true => 20301,
                    false => 20302,
                },
                2 => Waterlogged switch {
                    true => 20303,
                    false => 20304,
                },
                3 => Waterlogged switch {
                    true => 20305,
                    false => 20306,
                },
                4 => Waterlogged switch {
                    true => 20307,
                    false => 20308,
                },
                5 => Waterlogged switch {
                    true => 20309,
                    false => 20310,
                },
                6 => Waterlogged switch {
                    true => 20311,
                    false => 20312,
                },
                7 => Waterlogged switch {
                    true => 20313,
                    false => 20314,
                },
                8 => Waterlogged switch {
                    true => 20315,
                    false => 20316,
                },
                9 => Waterlogged switch {
                    true => 20317,
                    false => 20318,
                },
                10 => Waterlogged switch {
                    true => 20319,
                    false => 20320,
                },
                11 => Waterlogged switch {
                    true => 20321,
                    false => 20322,
                },
                12 => Waterlogged switch {
                    true => 20323,
                    false => 20324,
                },
                13 => Waterlogged switch {
                    true => 20325,
                    false => 20326,
                },
                14 => Waterlogged switch {
                    true => 20327,
                    false => 20328,
                },
                15 => Waterlogged switch {
                    true => 20329,
                    false => 20330,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20299 => new CrimsonSignBlock(Identifier, 0, true),
            20300 => new CrimsonSignBlock(Identifier, 0, false),
            20301 => new CrimsonSignBlock(Identifier, 1, true),
            20302 => new CrimsonSignBlock(Identifier, 1, false),
            20303 => new CrimsonSignBlock(Identifier, 2, true),
            20304 => new CrimsonSignBlock(Identifier, 2, false),
            20305 => new CrimsonSignBlock(Identifier, 3, true),
            20306 => new CrimsonSignBlock(Identifier, 3, false),
            20307 => new CrimsonSignBlock(Identifier, 4, true),
            20308 => new CrimsonSignBlock(Identifier, 4, false),
            20309 => new CrimsonSignBlock(Identifier, 5, true),
            20310 => new CrimsonSignBlock(Identifier, 5, false),
            20311 => new CrimsonSignBlock(Identifier, 6, true),
            20312 => new CrimsonSignBlock(Identifier, 6, false),
            20313 => new CrimsonSignBlock(Identifier, 7, true),
            20314 => new CrimsonSignBlock(Identifier, 7, false),
            20315 => new CrimsonSignBlock(Identifier, 8, true),
            20316 => new CrimsonSignBlock(Identifier, 8, false),
            20317 => new CrimsonSignBlock(Identifier, 9, true),
            20318 => new CrimsonSignBlock(Identifier, 9, false),
            20319 => new CrimsonSignBlock(Identifier, 10, true),
            20320 => new CrimsonSignBlock(Identifier, 10, false),
            20321 => new CrimsonSignBlock(Identifier, 11, true),
            20322 => new CrimsonSignBlock(Identifier, 11, false),
            20323 => new CrimsonSignBlock(Identifier, 12, true),
            20324 => new CrimsonSignBlock(Identifier, 12, false),
            20325 => new CrimsonSignBlock(Identifier, 13, true),
            20326 => new CrimsonSignBlock(Identifier, 13, false),
            20327 => new CrimsonSignBlock(Identifier, 14, true),
            20328 => new CrimsonSignBlock(Identifier, 14, false),
            20329 => new CrimsonSignBlock(Identifier, 15, true),
            20330 => new CrimsonSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}

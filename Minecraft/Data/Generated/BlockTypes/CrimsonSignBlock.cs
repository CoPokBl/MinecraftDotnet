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
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 861;
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
                    true => 20331,
                    false => 20332,
                },
                1 => Waterlogged switch {
                    true => 20333,
                    false => 20334,
                },
                2 => Waterlogged switch {
                    true => 20335,
                    false => 20336,
                },
                3 => Waterlogged switch {
                    true => 20337,
                    false => 20338,
                },
                4 => Waterlogged switch {
                    true => 20339,
                    false => 20340,
                },
                5 => Waterlogged switch {
                    true => 20341,
                    false => 20342,
                },
                6 => Waterlogged switch {
                    true => 20343,
                    false => 20344,
                },
                7 => Waterlogged switch {
                    true => 20345,
                    false => 20346,
                },
                8 => Waterlogged switch {
                    true => 20347,
                    false => 20348,
                },
                9 => Waterlogged switch {
                    true => 20349,
                    false => 20350,
                },
                10 => Waterlogged switch {
                    true => 20351,
                    false => 20352,
                },
                11 => Waterlogged switch {
                    true => 20353,
                    false => 20354,
                },
                12 => Waterlogged switch {
                    true => 20355,
                    false => 20356,
                },
                13 => Waterlogged switch {
                    true => 20357,
                    false => 20358,
                },
                14 => Waterlogged switch {
                    true => 20359,
                    false => 20360,
                },
                15 => Waterlogged switch {
                    true => 20361,
                    false => 20362,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20331 => new CrimsonSignBlock(Identifier, 0, true),
            20332 => new CrimsonSignBlock(Identifier, 0, false),
            20333 => new CrimsonSignBlock(Identifier, 1, true),
            20334 => new CrimsonSignBlock(Identifier, 1, false),
            20335 => new CrimsonSignBlock(Identifier, 2, true),
            20336 => new CrimsonSignBlock(Identifier, 2, false),
            20337 => new CrimsonSignBlock(Identifier, 3, true),
            20338 => new CrimsonSignBlock(Identifier, 3, false),
            20339 => new CrimsonSignBlock(Identifier, 4, true),
            20340 => new CrimsonSignBlock(Identifier, 4, false),
            20341 => new CrimsonSignBlock(Identifier, 5, true),
            20342 => new CrimsonSignBlock(Identifier, 5, false),
            20343 => new CrimsonSignBlock(Identifier, 6, true),
            20344 => new CrimsonSignBlock(Identifier, 6, false),
            20345 => new CrimsonSignBlock(Identifier, 7, true),
            20346 => new CrimsonSignBlock(Identifier, 7, false),
            20347 => new CrimsonSignBlock(Identifier, 8, true),
            20348 => new CrimsonSignBlock(Identifier, 8, false),
            20349 => new CrimsonSignBlock(Identifier, 9, true),
            20350 => new CrimsonSignBlock(Identifier, 9, false),
            20351 => new CrimsonSignBlock(Identifier, 10, true),
            20352 => new CrimsonSignBlock(Identifier, 10, false),
            20353 => new CrimsonSignBlock(Identifier, 11, true),
            20354 => new CrimsonSignBlock(Identifier, 11, false),
            20355 => new CrimsonSignBlock(Identifier, 12, true),
            20356 => new CrimsonSignBlock(Identifier, 12, false),
            20357 => new CrimsonSignBlock(Identifier, 13, true),
            20358 => new CrimsonSignBlock(Identifier, 13, false),
            20359 => new CrimsonSignBlock(Identifier, 14, true),
            20360 => new CrimsonSignBlock(Identifier, 14, false),
            20361 => new CrimsonSignBlock(Identifier, 15, true),
            20362 => new CrimsonSignBlock(Identifier, 15, false),
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

using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {

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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:warped_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_sign";
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
            20331 => new WarpedSignBlock(Identifier, 0, true),
            20332 => new WarpedSignBlock(Identifier, 0, false),
            20333 => new WarpedSignBlock(Identifier, 1, true),
            20334 => new WarpedSignBlock(Identifier, 1, false),
            20335 => new WarpedSignBlock(Identifier, 2, true),
            20336 => new WarpedSignBlock(Identifier, 2, false),
            20337 => new WarpedSignBlock(Identifier, 3, true),
            20338 => new WarpedSignBlock(Identifier, 3, false),
            20339 => new WarpedSignBlock(Identifier, 4, true),
            20340 => new WarpedSignBlock(Identifier, 4, false),
            20341 => new WarpedSignBlock(Identifier, 5, true),
            20342 => new WarpedSignBlock(Identifier, 5, false),
            20343 => new WarpedSignBlock(Identifier, 6, true),
            20344 => new WarpedSignBlock(Identifier, 6, false),
            20345 => new WarpedSignBlock(Identifier, 7, true),
            20346 => new WarpedSignBlock(Identifier, 7, false),
            20347 => new WarpedSignBlock(Identifier, 8, true),
            20348 => new WarpedSignBlock(Identifier, 8, false),
            20349 => new WarpedSignBlock(Identifier, 9, true),
            20350 => new WarpedSignBlock(Identifier, 9, false),
            20351 => new WarpedSignBlock(Identifier, 10, true),
            20352 => new WarpedSignBlock(Identifier, 10, false),
            20353 => new WarpedSignBlock(Identifier, 11, true),
            20354 => new WarpedSignBlock(Identifier, 11, false),
            20355 => new WarpedSignBlock(Identifier, 12, true),
            20356 => new WarpedSignBlock(Identifier, 12, false),
            20357 => new WarpedSignBlock(Identifier, 13, true),
            20358 => new WarpedSignBlock(Identifier, 13, false),
            20359 => new WarpedSignBlock(Identifier, 14, true),
            20360 => new WarpedSignBlock(Identifier, 14, false),
            20361 => new WarpedSignBlock(Identifier, 15, true),
            20362 => new WarpedSignBlock(Identifier, 15, false),
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

using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:oak_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5335,
                    false => 5336,
                },
                1 => Waterlogged switch {
                    true => 5337,
                    false => 5338,
                },
                2 => Waterlogged switch {
                    true => 5339,
                    false => 5340,
                },
                3 => Waterlogged switch {
                    true => 5341,
                    false => 5342,
                },
                4 => Waterlogged switch {
                    true => 5343,
                    false => 5344,
                },
                5 => Waterlogged switch {
                    true => 5345,
                    false => 5346,
                },
                6 => Waterlogged switch {
                    true => 5347,
                    false => 5348,
                },
                7 => Waterlogged switch {
                    true => 5349,
                    false => 5350,
                },
                8 => Waterlogged switch {
                    true => 5351,
                    false => 5352,
                },
                9 => Waterlogged switch {
                    true => 5353,
                    false => 5354,
                },
                10 => Waterlogged switch {
                    true => 5355,
                    false => 5356,
                },
                11 => Waterlogged switch {
                    true => 5357,
                    false => 5358,
                },
                12 => Waterlogged switch {
                    true => 5359,
                    false => 5360,
                },
                13 => Waterlogged switch {
                    true => 5361,
                    false => 5362,
                },
                14 => Waterlogged switch {
                    true => 5363,
                    false => 5364,
                },
                15 => Waterlogged switch {
                    true => 5365,
                    false => 5366,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5335 => new OakSignBlock(Identifier, 0, true),
            5336 => new OakSignBlock(Identifier, 0, false),
            5337 => new OakSignBlock(Identifier, 1, true),
            5338 => new OakSignBlock(Identifier, 1, false),
            5339 => new OakSignBlock(Identifier, 2, true),
            5340 => new OakSignBlock(Identifier, 2, false),
            5341 => new OakSignBlock(Identifier, 3, true),
            5342 => new OakSignBlock(Identifier, 3, false),
            5343 => new OakSignBlock(Identifier, 4, true),
            5344 => new OakSignBlock(Identifier, 4, false),
            5345 => new OakSignBlock(Identifier, 5, true),
            5346 => new OakSignBlock(Identifier, 5, false),
            5347 => new OakSignBlock(Identifier, 6, true),
            5348 => new OakSignBlock(Identifier, 6, false),
            5349 => new OakSignBlock(Identifier, 7, true),
            5350 => new OakSignBlock(Identifier, 7, false),
            5351 => new OakSignBlock(Identifier, 8, true),
            5352 => new OakSignBlock(Identifier, 8, false),
            5353 => new OakSignBlock(Identifier, 9, true),
            5354 => new OakSignBlock(Identifier, 9, false),
            5355 => new OakSignBlock(Identifier, 10, true),
            5356 => new OakSignBlock(Identifier, 10, false),
            5357 => new OakSignBlock(Identifier, 11, true),
            5358 => new OakSignBlock(Identifier, 11, false),
            5359 => new OakSignBlock(Identifier, 12, true),
            5360 => new OakSignBlock(Identifier, 12, false),
            5361 => new OakSignBlock(Identifier, 13, true),
            5362 => new OakSignBlock(Identifier, 13, false),
            5363 => new OakSignBlock(Identifier, 14, true),
            5364 => new OakSignBlock(Identifier, 14, false),
            5365 => new OakSignBlock(Identifier, 15, true),
            5366 => new OakSignBlock(Identifier, 15, false),
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

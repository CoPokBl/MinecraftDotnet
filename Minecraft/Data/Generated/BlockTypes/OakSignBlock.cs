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
    public int ProtocolId => 197;
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
                    true => 4366,
                    false => 4367,
                },
                1 => Waterlogged switch {
                    true => 4368,
                    false => 4369,
                },
                2 => Waterlogged switch {
                    true => 4370,
                    false => 4371,
                },
                3 => Waterlogged switch {
                    true => 4372,
                    false => 4373,
                },
                4 => Waterlogged switch {
                    true => 4374,
                    false => 4375,
                },
                5 => Waterlogged switch {
                    true => 4376,
                    false => 4377,
                },
                6 => Waterlogged switch {
                    true => 4378,
                    false => 4379,
                },
                7 => Waterlogged switch {
                    true => 4380,
                    false => 4381,
                },
                8 => Waterlogged switch {
                    true => 4382,
                    false => 4383,
                },
                9 => Waterlogged switch {
                    true => 4384,
                    false => 4385,
                },
                10 => Waterlogged switch {
                    true => 4386,
                    false => 4387,
                },
                11 => Waterlogged switch {
                    true => 4388,
                    false => 4389,
                },
                12 => Waterlogged switch {
                    true => 4390,
                    false => 4391,
                },
                13 => Waterlogged switch {
                    true => 4392,
                    false => 4393,
                },
                14 => Waterlogged switch {
                    true => 4394,
                    false => 4395,
                },
                15 => Waterlogged switch {
                    true => 4396,
                    false => 4397,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4366 => new OakSignBlock(Identifier, 0, true),
            4367 => new OakSignBlock(Identifier, 0, false),
            4368 => new OakSignBlock(Identifier, 1, true),
            4369 => new OakSignBlock(Identifier, 1, false),
            4370 => new OakSignBlock(Identifier, 2, true),
            4371 => new OakSignBlock(Identifier, 2, false),
            4372 => new OakSignBlock(Identifier, 3, true),
            4373 => new OakSignBlock(Identifier, 3, false),
            4374 => new OakSignBlock(Identifier, 4, true),
            4375 => new OakSignBlock(Identifier, 4, false),
            4376 => new OakSignBlock(Identifier, 5, true),
            4377 => new OakSignBlock(Identifier, 5, false),
            4378 => new OakSignBlock(Identifier, 6, true),
            4379 => new OakSignBlock(Identifier, 6, false),
            4380 => new OakSignBlock(Identifier, 7, true),
            4381 => new OakSignBlock(Identifier, 7, false),
            4382 => new OakSignBlock(Identifier, 8, true),
            4383 => new OakSignBlock(Identifier, 8, false),
            4384 => new OakSignBlock(Identifier, 9, true),
            4385 => new OakSignBlock(Identifier, 9, false),
            4386 => new OakSignBlock(Identifier, 10, true),
            4387 => new OakSignBlock(Identifier, 10, false),
            4388 => new OakSignBlock(Identifier, 11, true),
            4389 => new OakSignBlock(Identifier, 11, false),
            4390 => new OakSignBlock(Identifier, 12, true),
            4391 => new OakSignBlock(Identifier, 12, false),
            4392 => new OakSignBlock(Identifier, 13, true),
            4393 => new OakSignBlock(Identifier, 13, false),
            4394 => new OakSignBlock(Identifier, 14, true),
            4395 => new OakSignBlock(Identifier, 14, false),
            4396 => new OakSignBlock(Identifier, 15, true),
            4397 => new OakSignBlock(Identifier, 15, false),
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

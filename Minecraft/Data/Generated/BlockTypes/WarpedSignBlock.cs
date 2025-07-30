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
    public int ProtocolId => 862;
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
                    true => 20363,
                    false => 20364,
                },
                1 => Waterlogged switch {
                    true => 20365,
                    false => 20366,
                },
                2 => Waterlogged switch {
                    true => 20367,
                    false => 20368,
                },
                3 => Waterlogged switch {
                    true => 20369,
                    false => 20370,
                },
                4 => Waterlogged switch {
                    true => 20371,
                    false => 20372,
                },
                5 => Waterlogged switch {
                    true => 20373,
                    false => 20374,
                },
                6 => Waterlogged switch {
                    true => 20375,
                    false => 20376,
                },
                7 => Waterlogged switch {
                    true => 20377,
                    false => 20378,
                },
                8 => Waterlogged switch {
                    true => 20379,
                    false => 20380,
                },
                9 => Waterlogged switch {
                    true => 20381,
                    false => 20382,
                },
                10 => Waterlogged switch {
                    true => 20383,
                    false => 20384,
                },
                11 => Waterlogged switch {
                    true => 20385,
                    false => 20386,
                },
                12 => Waterlogged switch {
                    true => 20387,
                    false => 20388,
                },
                13 => Waterlogged switch {
                    true => 20389,
                    false => 20390,
                },
                14 => Waterlogged switch {
                    true => 20391,
                    false => 20392,
                },
                15 => Waterlogged switch {
                    true => 20393,
                    false => 20394,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20363 => new WarpedSignBlock(Identifier, 0, true),
            20364 => new WarpedSignBlock(Identifier, 0, false),
            20365 => new WarpedSignBlock(Identifier, 1, true),
            20366 => new WarpedSignBlock(Identifier, 1, false),
            20367 => new WarpedSignBlock(Identifier, 2, true),
            20368 => new WarpedSignBlock(Identifier, 2, false),
            20369 => new WarpedSignBlock(Identifier, 3, true),
            20370 => new WarpedSignBlock(Identifier, 3, false),
            20371 => new WarpedSignBlock(Identifier, 4, true),
            20372 => new WarpedSignBlock(Identifier, 4, false),
            20373 => new WarpedSignBlock(Identifier, 5, true),
            20374 => new WarpedSignBlock(Identifier, 5, false),
            20375 => new WarpedSignBlock(Identifier, 6, true),
            20376 => new WarpedSignBlock(Identifier, 6, false),
            20377 => new WarpedSignBlock(Identifier, 7, true),
            20378 => new WarpedSignBlock(Identifier, 7, false),
            20379 => new WarpedSignBlock(Identifier, 8, true),
            20380 => new WarpedSignBlock(Identifier, 8, false),
            20381 => new WarpedSignBlock(Identifier, 9, true),
            20382 => new WarpedSignBlock(Identifier, 9, false),
            20383 => new WarpedSignBlock(Identifier, 10, true),
            20384 => new WarpedSignBlock(Identifier, 10, false),
            20385 => new WarpedSignBlock(Identifier, 11, true),
            20386 => new WarpedSignBlock(Identifier, 11, false),
            20387 => new WarpedSignBlock(Identifier, 12, true),
            20388 => new WarpedSignBlock(Identifier, 12, false),
            20389 => new WarpedSignBlock(Identifier, 13, true),
            20390 => new WarpedSignBlock(Identifier, 13, false),
            20391 => new WarpedSignBlock(Identifier, 14, true),
            20392 => new WarpedSignBlock(Identifier, 14, false),
            20393 => new WarpedSignBlock(Identifier, 15, true),
            20394 => new WarpedSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("rotation", Rotation.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}

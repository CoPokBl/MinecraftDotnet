using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherrySignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 213;
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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:cherry_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5262,
                    false => 5263,
                },
                1 => Waterlogged switch {
                    true => 5264,
                    false => 5265,
                },
                2 => Waterlogged switch {
                    true => 5266,
                    false => 5267,
                },
                3 => Waterlogged switch {
                    true => 5268,
                    false => 5269,
                },
                4 => Waterlogged switch {
                    true => 5270,
                    false => 5271,
                },
                5 => Waterlogged switch {
                    true => 5272,
                    false => 5273,
                },
                6 => Waterlogged switch {
                    true => 5274,
                    false => 5275,
                },
                7 => Waterlogged switch {
                    true => 5276,
                    false => 5277,
                },
                8 => Waterlogged switch {
                    true => 5278,
                    false => 5279,
                },
                9 => Waterlogged switch {
                    true => 5280,
                    false => 5281,
                },
                10 => Waterlogged switch {
                    true => 5282,
                    false => 5283,
                },
                11 => Waterlogged switch {
                    true => 5284,
                    false => 5285,
                },
                12 => Waterlogged switch {
                    true => 5286,
                    false => 5287,
                },
                13 => Waterlogged switch {
                    true => 5288,
                    false => 5289,
                },
                14 => Waterlogged switch {
                    true => 5290,
                    false => 5291,
                },
                15 => Waterlogged switch {
                    true => 5292,
                    false => 5293,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5262 => new CherrySignBlock(Identifier, 0, true),
            5263 => new CherrySignBlock(Identifier, 0, false),
            5264 => new CherrySignBlock(Identifier, 1, true),
            5265 => new CherrySignBlock(Identifier, 1, false),
            5266 => new CherrySignBlock(Identifier, 2, true),
            5267 => new CherrySignBlock(Identifier, 2, false),
            5268 => new CherrySignBlock(Identifier, 3, true),
            5269 => new CherrySignBlock(Identifier, 3, false),
            5270 => new CherrySignBlock(Identifier, 4, true),
            5271 => new CherrySignBlock(Identifier, 4, false),
            5272 => new CherrySignBlock(Identifier, 5, true),
            5273 => new CherrySignBlock(Identifier, 5, false),
            5274 => new CherrySignBlock(Identifier, 6, true),
            5275 => new CherrySignBlock(Identifier, 6, false),
            5276 => new CherrySignBlock(Identifier, 7, true),
            5277 => new CherrySignBlock(Identifier, 7, false),
            5278 => new CherrySignBlock(Identifier, 8, true),
            5279 => new CherrySignBlock(Identifier, 8, false),
            5280 => new CherrySignBlock(Identifier, 9, true),
            5281 => new CherrySignBlock(Identifier, 9, false),
            5282 => new CherrySignBlock(Identifier, 10, true),
            5283 => new CherrySignBlock(Identifier, 10, false),
            5284 => new CherrySignBlock(Identifier, 11, true),
            5285 => new CherrySignBlock(Identifier, 11, false),
            5286 => new CherrySignBlock(Identifier, 12, true),
            5287 => new CherrySignBlock(Identifier, 12, false),
            5288 => new CherrySignBlock(Identifier, 13, true),
            5289 => new CherrySignBlock(Identifier, 13, false),
            5290 => new CherrySignBlock(Identifier, 14, true),
            5291 => new CherrySignBlock(Identifier, 14, false),
            5292 => new CherrySignBlock(Identifier, 15, true),
            5293 => new CherrySignBlock(Identifier, 15, false),
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

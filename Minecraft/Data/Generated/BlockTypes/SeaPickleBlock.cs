using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SeaPickleBlock(Identifier Identifier, int Pickles, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:sea_pickle";
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 6;
    public bool Replaceable => false;
    public string SoundType => "slime_block";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:sea_pickle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 0.375, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 0.375, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 0.375, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 27;
    public string TranslationKey => "block.minecraft.sea_pickle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Pickles switch {
                1 => Waterlogged switch {
                    true => 15267,
                    false => 15268,
                },
                2 => Waterlogged switch {
                    true => 15269,
                    false => 15270,
                },
                3 => Waterlogged switch {
                    true => 15271,
                    false => 15272,
                },
                4 => Waterlogged switch {
                    true => 15273,
                    false => 15274,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Pickles), Pickles, "Unknown value for property pickles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15267 => new SeaPickleBlock(Identifier, 1, true),
            15268 => new SeaPickleBlock(Identifier, 1, false),
            15269 => new SeaPickleBlock(Identifier, 2, true),
            15270 => new SeaPickleBlock(Identifier, 2, false),
            15271 => new SeaPickleBlock(Identifier, 3, true),
            15272 => new SeaPickleBlock(Identifier, 3, false),
            15273 => new SeaPickleBlock(Identifier, 4, true),
            15274 => new SeaPickleBlock(Identifier, 4, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Pickles = properties.Contains("pickles") ? int.Parse(properties["pickles"].GetString()) : Pickles,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("pickles", new StringTag(Pickles.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}

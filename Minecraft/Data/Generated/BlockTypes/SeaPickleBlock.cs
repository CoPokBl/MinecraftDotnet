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
    public int ProtocolId => 786;
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
                    true => 15065,
                    false => 15066,
                },
                2 => Waterlogged switch {
                    true => 15067,
                    false => 15068,
                },
                3 => Waterlogged switch {
                    true => 15069,
                    false => 15070,
                },
                4 => Waterlogged switch {
                    true => 15071,
                    false => 15072,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Pickles), Pickles, "Unknown value for property pickles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15065 => new SeaPickleBlock(Identifier, 1, true),
            15066 => new SeaPickleBlock(Identifier, 1, false),
            15067 => new SeaPickleBlock(Identifier, 2, true),
            15068 => new SeaPickleBlock(Identifier, 2, false),
            15069 => new SeaPickleBlock(Identifier, 3, true),
            15070 => new SeaPickleBlock(Identifier, 3, false),
            15071 => new SeaPickleBlock(Identifier, 4, true),
            15072 => new SeaPickleBlock(Identifier, 4, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Pickles = properties.ChildrenMap.ContainsKey("pickles") ? int.Parse(properties["pickles"].GetString()) : Pickles,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("pickles", Pickles.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}

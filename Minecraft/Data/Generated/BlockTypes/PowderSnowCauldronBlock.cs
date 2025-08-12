using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PowderSnowCauldronBlock(Identifier Identifier, int Level) : IBlock {
    public Identifier Category => "minecraft:layered_cauldron";
    public int ProtocolId => 359;
    public double Hardness => 2;
    public double ExplosionResistance => 2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cauldron";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [0.125, 1.0, 0.25], AABB[0.0, 0.0, 0.75] -> [0.125, 1.0, 1.0], AABB[0.125, 0.0, 0.0] -> [0.25, 1.0, 0.125], AABB[0.125, 0.0, 0.875] -> [0.25, 1.0, 1.0], AABB[0.75, 0.0, 0.0] -> [1.0, 1.0, 0.125], AABB[0.75, 0.0, 0.875] -> [1.0, 1.0, 1.0], AABB[0.875, 0.0, 0.125] -> [1.0, 1.0, 0.25], AABB[0.875, 0.0, 0.75] -> [1.0, 1.0, 0.875], AABB[0.0, 0.1875, 0.25] -> [1.0, 0.25, 0.75], AABB[0.125, 0.1875, 0.125] -> [0.875, 0.25, 0.25], AABB[0.125, 0.1875, 0.75] -> [0.875, 0.25, 0.875], AABB[0.25, 0.1875, 0.0] -> [0.75, 1.0, 0.125], AABB[0.25, 0.1875, 0.875] -> [0.75, 1.0, 1.0], AABB[0.0, 0.25, 0.25] -> [0.125, 1.0, 0.75], AABB[0.875, 0.25, 0.25] -> [1.0, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [0.125, 1.0, 0.25], AABB[0.0, 0.0, 0.75] -> [0.125, 1.0, 1.0], AABB[0.125, 0.0, 0.0] -> [0.25, 1.0, 0.125], AABB[0.125, 0.0, 0.875] -> [0.25, 1.0, 1.0], AABB[0.75, 0.0, 0.0] -> [1.0, 1.0, 0.125], AABB[0.75, 0.0, 0.875] -> [1.0, 1.0, 1.0], AABB[0.875, 0.0, 0.125] -> [1.0, 1.0, 0.25], AABB[0.875, 0.0, 0.75] -> [1.0, 1.0, 0.875], AABB[0.0, 0.1875, 0.25] -> [1.0, 0.25, 0.75], AABB[0.125, 0.1875, 0.125] -> [0.875, 0.25, 0.25], AABB[0.125, 0.1875, 0.75] -> [0.875, 0.25, 0.875], AABB[0.25, 0.1875, 0.0] -> [0.75, 1.0, 0.125], AABB[0.25, 0.1875, 0.875] -> [0.75, 1.0, 1.0], AABB[0.0, 0.25, 0.25] -> [0.125, 1.0, 0.75], AABB[0.875, 0.25, 0.25] -> [1.0, 1.0, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.125, 0.25, 0.125] -> [0.875, 1.0, 0.875]]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [0.125, 1.0, 0.25], AABB[0.0, 0.0, 0.75] -> [0.125, 1.0, 1.0], AABB[0.125, 0.0, 0.0] -> [0.25, 1.0, 0.125], AABB[0.125, 0.0, 0.875] -> [0.25, 1.0, 1.0], AABB[0.75, 0.0, 0.0] -> [1.0, 1.0, 0.125], AABB[0.75, 0.0, 0.875] -> [1.0, 1.0, 1.0], AABB[0.875, 0.0, 0.125] -> [1.0, 1.0, 0.25], AABB[0.875, 0.0, 0.75] -> [1.0, 1.0, 0.875], AABB[0.0, 0.1875, 0.25] -> [1.0, 0.25, 0.75], AABB[0.125, 0.1875, 0.125] -> [0.875, 0.25, 0.25], AABB[0.125, 0.1875, 0.75] -> [0.875, 0.25, 0.875], AABB[0.25, 0.1875, 0.0] -> [0.75, 1.0, 0.125], AABB[0.25, 0.1875, 0.875] -> [0.75, 1.0, 1.0], AABB[0.0, 0.25, 0.25] -> [0.125, 1.0, 0.75], AABB[0.875, 0.25, 0.25] -> [1.0, 1.0, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.powder_snow_cauldron";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Level switch {
                1 => 8187,
                2 => 8188,
                3 => 8189,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8187 => new PowderSnowCauldronBlock(Identifier, 1),
            8188 => new PowderSnowCauldronBlock(Identifier, 2),
            8189 => new PowderSnowCauldronBlock(Identifier, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = properties.ChildrenMap.ContainsKey("level") ? int.Parse(properties["level"].GetString()) : Level,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("level", Level.ToString())
        );
    }
    
}

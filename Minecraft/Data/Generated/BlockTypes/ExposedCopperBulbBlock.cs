using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {

    public Identifier Category => "minecraft:weathering_copper_bulb";
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper_bulb";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:exposed_copper_bulb";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.exposed_copper_bulb";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Lit switch {
                true => Powered switch {
                    true => 25756,
                    false => 25757,
                },
                false => Powered switch {
                    true => 25758,
                    false => 25759,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25756 => new ExposedCopperBulbBlock(Identifier, true, true),
            25757 => new ExposedCopperBulbBlock(Identifier, true, false),
            25758 => new ExposedCopperBulbBlock(Identifier, false, true),
            25759 => new ExposedCopperBulbBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Lit = properties["lit"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}

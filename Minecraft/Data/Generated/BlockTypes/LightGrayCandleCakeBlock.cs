using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightGrayCandleCakeBlock(Identifier Identifier, bool Lit) : IBlock {

    public Identifier Category => "minecraft:candle_cake";
    public double Hardness => 0.5;
    public double ExplosionResistance => 0.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wool";
    public Identifier? BlockEntity => null;
    public Identifier? Item => null;
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.5, 0.9375], AABB[0.4375, 0.5, 0.4375] -> [0.5625, 0.875, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.5, 0.9375], AABB[0.4375, 0.5, 0.4375] -> [0.5625, 0.875, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.5, 0.9375], AABB[0.4375, 0.5, 0.4375] -> [0.5625, 0.875, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.5, 0.9375], AABB[0.4375, 0.5, 0.4375] -> [0.5625, 0.875, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.light_gray_candle_cake";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Lit switch {
                true => 22043,
                false => 22044,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22043 => new LightGrayCandleCakeBlock(Identifier, true),
            22044 => new LightGrayCandleCakeBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Lit = properties["lit"].GetString() == "true",
        };
    }
    
}

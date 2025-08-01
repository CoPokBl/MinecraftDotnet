using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakSaplingBlock(Identifier Identifier, int Stage) : IBlock {

    public Identifier Category => "minecraft:sapling";
    public int ProtocolId => 25;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:oak_sapling";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.125, 0.0, 0.125] -> [0.875, 0.75, 0.875]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.oak_sapling";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Stage switch {
                0 => 29,
                1 => 30,
                _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29 => new OakSaplingBlock(Identifier, 0),
            30 => new OakSaplingBlock(Identifier, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Stage = int.Parse(properties["stage"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("stage", Stage.ToString())
        );
    }
    
}

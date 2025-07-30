using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TargetBlock(Identifier Identifier, int Power) : IBlock {

    public Identifier Category => "minecraft:target";
    public int ProtocolId => 870;
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
    public string SoundType => "grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:target";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => true;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.target";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Power switch {
                0 => 20441,
                1 => 20442,
                2 => 20443,
                3 => 20444,
                4 => 20445,
                5 => 20446,
                6 => 20447,
                7 => 20448,
                8 => 20449,
                9 => 20450,
                10 => 20451,
                11 => 20452,
                12 => 20453,
                13 => 20454,
                14 => 20455,
                15 => 20456,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20441 => new TargetBlock(Identifier, 0),
            20442 => new TargetBlock(Identifier, 1),
            20443 => new TargetBlock(Identifier, 2),
            20444 => new TargetBlock(Identifier, 3),
            20445 => new TargetBlock(Identifier, 4),
            20446 => new TargetBlock(Identifier, 5),
            20447 => new TargetBlock(Identifier, 6),
            20448 => new TargetBlock(Identifier, 7),
            20449 => new TargetBlock(Identifier, 8),
            20450 => new TargetBlock(Identifier, 9),
            20451 => new TargetBlock(Identifier, 10),
            20452 => new TargetBlock(Identifier, 11),
            20453 => new TargetBlock(Identifier, 12),
            20454 => new TargetBlock(Identifier, 13),
            20455 => new TargetBlock(Identifier, 14),
            20456 => new TargetBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = int.Parse(properties["power"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("power", Power.ToString())
        );
    }
    
}
